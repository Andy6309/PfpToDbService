using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using Microsoft.Extensions.Logging;

namespace PfpToDbService.Services
{
    public class FileMonitorService : IDisposable
    {
        private readonly List<FolderConfig> _folders;
        private readonly PfpFileParser _parser;
        private readonly DatabaseService _dbService;
        private readonly ILogger<FileMonitorService> _logger;
        private readonly List<CustomSingleEventFileWatcher> _watchers;
        private bool _disposed;

        public FileMonitorService(IConfiguration config,
            PfpFileParser parser,
            DatabaseService dbService, ILogger<FileMonitorService> logger)
        {
            _parser = parser;
            _dbService = dbService;
            _logger = logger;
            _folders = config.GetSection("FileMonitoring:Folders").Get<List<FolderConfig>>() ?? new List<FolderConfig>();
            _watchers = new List<CustomSingleEventFileWatcher>();
        }

        /// <summary>
        /// Starts the file monitoring loop.
        /// </summary>
        public async Task StartMonitoring()
        {
            _logger.LogInformation("Starting file monitoring...");

            // Process existing files on startup
            await ProcessExistingPfpFiles();

            // Set up watchers for each folder
            foreach (var folder in _folders)
            {
                if (!Directory.Exists(folder.Path)) continue;

                var watcher = new CustomSingleEventFileWatcher(folder.Path, folder.PanelBendable, "*.pfp");
                watcher.FileReady += OnFileReady;    
                watcher.FileDeleted += OnFileDeleted; // subscribe to file Deleted Event -AM

                _watchers.Add(watcher);
                _logger.LogInformation($"Started monitoring folder: {folder.Path}");
            }
        }

        /// <summary>
        /// Stops the file monitoring loop.
        /// </summary>
        public void StopMonitoring()
        {
            _logger.LogInformation("Stopping file monitoring...");

            foreach (var watcher in _watchers)
            {
                watcher.FileReady -= OnFileReady;    
                watcher.FileDeleted -= OnFileDeleted; // Unsubscribe from Deleted event -AM
                watcher.Dispose();
            }

            _watchers.Clear();
        }

        private async void OnFileReady(object? sender, FileReadyEventArgs e)
        {
            _logger.LogInformation($"File ready for processing: {e.FilePath}");
            await ProcessPfpFile(e.FilePath, e.PanelBendable);
        }

        private async void OnFileDeleted(object? sender, FileDeletedEventArgs e)
        {
            _logger.LogInformation($"File deleted: {e.FilePath}");
            await _dbService.DeleteFileRecordAsync(e.FilePath);
            _logger.LogInformation($"Removed file record from database: {e.FilePath}");
        }

        private string ComputeFileHash(string filePath)
        {
            using var stream = File.OpenRead(filePath);
            using var hasher = SHA256.Create();
            return Convert.ToBase64String(hasher.ComputeHash(stream));
        }

        private async Task ProcessExistingPfpFiles()
        {
            _logger.LogDebug("Entry - ProcessExistingPfpFiles()");
            foreach (var folder in _folders)
            {
                if (Directory.Exists(folder.Path))
                {
                    var pfpFiles = Directory.GetFiles(folder.Path, "*.pfp", SearchOption.AllDirectories);
                    foreach (var pfpFile in pfpFiles)
                    {
                        await ProcessPfpFile(pfpFile, folder.PanelBendable);
                    }
                }
            }
            _logger.LogDebug("Exit - ProcessExistingPfpFiles()");
        }

        private async Task ProcessPfpFile(string filePath, bool panelBendable)
        {
            try
            {
                _logger.LogDebug($"Entry - ProcessPfpFile(filePath: {filePath}) ");
                var fileInfo = new FileInfo(filePath);
                var fileHash = ComputeFileHash(filePath);

                var fileLastModifiedRounded = new DateTime(
                    fileInfo.LastWriteTime.Year,
                    fileInfo.LastWriteTime.Month,
                    fileInfo.LastWriteTime.Day,
                    fileInfo.LastWriteTime.Hour,
                    fileInfo.LastWriteTime.Minute,
                    fileInfo.LastWriteTime.Second,
                    fileInfo.LastWriteTime.Kind
                );

                if (await _dbService.IsFileModifiedOrNewAsync(filePath, fileHash, fileLastModifiedRounded))
                {
                    var parsedData = _parser.ParsePfpFile(filePath);
                    parsedData.PanelBendable = panelBendable;
                    _dbService.UpsertPfpData(parsedData, filePath, fileHash, fileLastModifiedRounded);
                    _logger.LogInformation($"Processed and upserted file: {filePath}");
                }
                else
                {
                    _logger.LogDebug($"File is not modified. It already exists in the database: {filePath}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error processing file {filePath}");
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    StopMonitoring();
                }

                _disposed = true;
            }
        }
    }

    public class FolderConfig
    {
        public string Path { get; set; }
        public bool PanelBendable { get; set; }
    }
}
