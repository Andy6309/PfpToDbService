using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
using Microsoft.Extensions.Logging;
using PfpToDbService.Models;

namespace PfpToDbService.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString;
        private readonly ILogger<DatabaseService> _logger;

        public DatabaseService(string connectionString, ILogger<DatabaseService> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }

        public async Task<bool> IsFileModifiedOrNewAsync(string filePath, string fileHash, DateTime lastModified)
        {
            _logger.LogDebug("Entry - IsFileModifiedOrNewAsync");
            const string query = @"
                SELECT COUNT(1)
                FROM PfpData
                WHERE FilePath = @FilePath AND FileHash = @FileHash AND FileLastModified = @FileLastModified";

            using var connection = new SqlConnection(_connectionString);

            return await connection.ExecuteScalarAsync<int>(query, new
            {
                FilePath = filePath,
                FileHash = fileHash,
                FileLastModified = lastModified
            }) == 0;
        }

        public void UpsertPfpData(ParsedPfpData parsedData, string filePath, string fileHash, DateTime fileInfoLastWriteTime)
        {
            _logger.LogDebug("Entry - UpsertPfpData");
            using IDbConnection db = new SqlConnection(_connectionString);

            if (RecordExists(db, filePath))
            {

                UpdateRecord(db, parsedData, filePath, fileHash, fileInfoLastWriteTime);
            }
            else
            {
                InsertRecord(db, parsedData, filePath, fileHash, fileInfoLastWriteTime);
            }
        }

        private bool RecordExists(IDbConnection db, string filePath)
        {
            const string selectSql = @"
                SELECT COUNT(*)
                FROM PfpData
                WHERE FilePath = @FilePath";

            return db.ExecuteScalar<int>(selectSql, new { FilePath = filePath }) > 0;
        }

        private void UpdateRecord(IDbConnection db, ParsedPfpData parsedData, string filePath, string fileHash, DateTime fileInfoLastWriteTime)
        {
            _logger.LogDebug($"Entry - UpdateRecord {filePath}");
            const string updateSql = @"
                UPDATE PfpData
                SET 
                    BendingMachineName       = @BendingMachineName,
                    PartName                 = @PartName,
                    UBC                      = @UBC,
                    ASP                      = @ASP,
                    AUT                      = @AUT,
                    Tested                   = @Tested,
                    PanelBendable            = @PanelBendable,
                    LastUpdatedTimestamp     = @LastUpdatedTimestamp,
                    FileHash                 = @FileHash,
                    FileLastModified         = @FileLastModified,
                    FileName                 = @FileName
                WHERE FilePath = @FilePath";

            db.Execute(updateSql, new
            {
                parsedData.BendingMachineName,
                parsedData.PartName,
                parsedData.UBC,
                parsedData.ASP,
                parsedData.AUT,
                parsedData.Tested,
                PanelBendable = parsedData.PanelBendable,
                LastUpdatedTimestamp = DateTime.UtcNow,
                FileHash = fileHash,
                FileLastModified = fileInfoLastWriteTime,
                FileName = Path.GetFileName(filePath),
                FilePath = filePath
            });
        }

        private void InsertRecord(IDbConnection db, ParsedPfpData parsedData, string filePath, string fileHash, DateTime fileInfoLastWriteTime)
        {
            _logger.LogDebug($"Entry - InsertRecord {filePath}");
            const string insertSql = @"
                INSERT INTO PfpData (
                    BendingMachineName,
                    PartName,
                    UBC,
                    ASP,
                    AUT,
                    Tested,
                    PanelBendable,
                    LastUpdatedTimestamp,
                    FileHash,
                    FileLastModified,
                    FileName,
                    FilePath
                ) VALUES (
                    @BendingMachineName,
                    @PartName,
                    @UBC,
                    @ASP,
                    @AUT,
                    @Tested,
                    @PanelBendable,
                    @LastUpdatedTimestamp,
                    @FileHash,
                    @FileLastModified,
                    @FileName,
                    @FilePath
                )";

            db.Execute(insertSql, new
            {
                parsedData.BendingMachineName,
                parsedData.PartName,
                parsedData.UBC,
                parsedData.ASP,
                parsedData.AUT,
                parsedData.Tested,
                PanelBendable = parsedData.PanelBendable,
                LastUpdatedTimestamp = DateTime.UtcNow,
                FileHash = fileHash,
                FileLastModified = fileInfoLastWriteTime,
                FileName = Path.GetFileName(filePath),
                FilePath = filePath
            });
        }

        //Add DeleteFileRecord -AM

        public async Task DeleteFileRecordAsync(string filePath)
        {
            _logger.LogDebug($"Entry - DeleteFileRecordAsync {filePath}");

            const string deleteSql = @"
        DELETE FROM PfpData
        WHERE FilePath = @FilePath";

            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                int rowsAffected = await connection.ExecuteAsync(deleteSql, new { FilePath = filePath });

                if (rowsAffected > 0)
                {
                    _logger.LogInformation($"Successfully deleted record for file: {filePath}");
                }
                else
                {
                    _logger.LogWarning($"No record found for deletion: {filePath}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting record for file {filePath}");
            }
        }

    }
}
