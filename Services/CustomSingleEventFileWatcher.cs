using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace PfpToDbService.Services
{
    /// <summary>
    /// Custom FileSystemWatcher wrapper that consolidates Created/Changed events
    /// into a single "FileReady" event, fired only once per file operation.
    /// Also raises an event when a file is deleted.
    /// </summary>
    public class CustomSingleEventFileWatcher : IDisposable
    {
        private FileSystemWatcher _watcher;

        // Keep a dictionary of <file path, Timer> for debouncing
        private readonly Dictionary<string, Timer> _debounceTimers
            = new Dictionary<string, Timer>();

        private readonly bool _panelBendable;
        private readonly int _debounceDelayMs;

        /// <summary>
        /// This event is raised once a file is verified to be fully written (copied or saved).
        /// </summary>
        public event EventHandler<FileReadyEventArgs> FileReady;

        /// <summary>
        /// This event is raised when a file is deleted from the watched folder.
        /// </summary>
        public event EventHandler<FileDeletedEventArgs> FileDeleted;

        public CustomSingleEventFileWatcher(string path,
            bool panelBendable,
            string filter = "*.*",
            int debounceDelayMs = 1000)
        {
            _panelBendable = panelBendable;
            _debounceDelayMs = debounceDelayMs;

            _watcher = new FileSystemWatcher(path)
            {
                IncludeSubdirectories = true,
                Filter = filter,
                NotifyFilter = NotifyFilters.FileName
                             | NotifyFilters.LastWrite
                             | NotifyFilters.Size
                             | NotifyFilters.CreationTime
            };

            _watcher.Created += OnFileEvent;
            _watcher.Changed += OnFileEvent;
            _watcher.Deleted += OnFileDeleted; // Added event for deletions

            _watcher.EnableRaisingEvents = true;
        }

        private void OnFileEvent(object sender, FileSystemEventArgs e)
        {
            lock (_debounceTimers)
            {
                if (_debounceTimers.ContainsKey(e.FullPath))
                {
                    _debounceTimers[e.FullPath].Dispose();
                    _debounceTimers.Remove(e.FullPath);
                }

                Timer timer = new Timer(OnDebounceTimerElapsed, e.FullPath, _debounceDelayMs, Timeout.Infinite);
                _debounceTimers[e.FullPath] = timer;
            }
        }

        private void OnDebounceTimerElapsed(object state)
        {
            string filePath = (string)state;

            lock (_debounceTimers)
            {
                if (_debounceTimers.ContainsKey(filePath))
                {
                    _debounceTimers[filePath].Dispose();
                    _debounceTimers.Remove(filePath);
                }
            }

            if (WaitForFileToBeReady(filePath))
            {
                OnFileReady(filePath);
            }
        }

        private bool WaitForFileToBeReady(string filePath)
        {
            const int maxRetries = 10;
            const int delayBetweenRetriesMs = 500;

            for (int i = 0; i < maxRetries; i++)
            {
                try
                {
                    using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                    {
                        return true;
                    }
                }
                catch (IOException)
                {
                    Thread.Sleep(delayBetweenRetriesMs);
                }
            }

            return false;
        }

        private void OnFileReady(string filePath)
        {
            FileReady?.Invoke(this, new FileReadyEventArgs(filePath, _panelBendable));
        }

        /// <summary>
        /// Handles file deletions and raises the FileDeleted event.
        /// </summary>
        private void OnFileDeleted(object sender, FileSystemEventArgs e)
        {
            FileDeleted?.Invoke(this, new FileDeletedEventArgs(e.FullPath));
        }

        public void Dispose()
        {
            if (_watcher != null)
            {
                _watcher.EnableRaisingEvents = false;
                _watcher.Created -= OnFileEvent;
                _watcher.Changed -= OnFileEvent;
                _watcher.Deleted -= OnFileDeleted; // Remove deleted event handler
                _watcher.Dispose();
                _watcher = null;
            }

            lock (_debounceTimers)
            {
                foreach (var timer in _debounceTimers.Values)
                {
                    timer.Dispose();
                }
                _debounceTimers.Clear();
            }
        }
    }

    /// <summary>
    /// Event args for when a file becomes ready.
    /// </summary>
    public class FileReadyEventArgs : EventArgs
    {
        public string FilePath { get; }
        public bool PanelBendable { get; }

        public FileReadyEventArgs(string filePath, bool panelBendable)
        {
            FilePath = filePath;
            PanelBendable = panelBendable;
        }
    }

    /// <summary>
    /// Event args for when a file is deleted.
    /// </summary>
    public class FileDeletedEventArgs : EventArgs
    {
        public string FilePath { get; }

        public FileDeletedEventArgs(string filePath)
        {
            FilePath = filePath;
        }
    }
}
