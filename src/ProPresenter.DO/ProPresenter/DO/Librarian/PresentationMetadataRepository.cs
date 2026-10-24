using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Microsoft.Data.Sqlite;
using Pro.Common.Components;
using Pro.Common.Logging;
using Pro.Common.Utility;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Librarian;

public class PresentationMetadataRepository : DisposableBase, IPresentationMetadataRepository, IDisposable
{
	private const string DBFilename = "cache.sqlite3";

	private const int DBVersion = 2;

	private static readonly string PresentationsTableName = $"Presentations_{2}";

	private SqliteConnection _metadataDatabase;

	public PresentationMetadataRepository(string dbFolder, bool clearCache = false)
	{
		Log.Info("Opening presentation metadata cache...");
		Directory.CreateDirectory(dbFolder);
		string text = Path.Combine(dbFolder, "cache.sqlite3");
		if (clearCache && File.Exists(text))
		{
			File.Delete(text);
		}
		_metadataDatabase = new SqliteConnection("Filename=" + text + "; Mode=ReadWriteCreate; Cache=Default; Pooling=False");
		_metadataDatabase.Open();
		CreateDBTables();
	}

	protected override void OnDispose(bool disposeObjects)
	{
		if (disposeObjects)
		{
			_metadataDatabase.Close();
			_metadataDatabase.Dispose();
		}
	}

	private void CreateDBTables()
	{
		ExecuteCommand($"\r\n                CREATE TABLE IF NOT EXISTS {PresentationsTableName} (\r\n                    Key\t             TEXT     NOT NULL  UNIQUE,\r\n                    Fingerprint      TEXT     NOT NULL        ,\r\n                    Uuid             BLOB     NOT NULL        ,\r\n                    Type             INTEGER  NOT NULL        ,\r\n                    Destination      INTEGER  NOT NULL        ,\r\n                    ArrangementName  TEXT                     ,\r\n                    LastUsed         INTEGER                  ,\r\n                    LastModified     INTEGER  NOT NULL        ,\r\n                    CopyrightData    BLOB                     ,\r\n                    PRIMARY KEY(Key)\r\n                );");
		ExecuteCommand(string.Format("\r\n                CREATE INDEX IF NOT EXISTS {0}KeyIndex ON {0} (\r\n                    Key\r\n                );", PresentationsTableName));
		ExecuteCommand(string.Format("\r\n                CREATE INDEX IF NOT EXISTS {0}KeyFingerprintIndex ON {0} (\r\n                    Key,\r\n                    Fingerprint\r\n                );", PresentationsTableName));
	}

	public bool TryGetCachedMetadata(string key, string fingerprint, [NotNullWhen(true)] out PresentationMetadata? presentationMetadata)
	{
		presentationMetadata = null;
		if (base.IsDisposed)
		{
			return false;
		}
		using (SqliteDataReader sqliteDataReader = ExecuteRead($"SELECT * FROM {PresentationsTableName} WHERE Key = @param0 AND Fingerprint = @param1;", key, fingerprint))
		{
			if (sqliteDataReader.Read())
			{
				presentationMetadata = new PresentationMetadata(new Guid((byte[])sqliteDataReader["Uuid"]), (PresentationType)(long)sqliteDataReader["Type"], (OutputDestination)(long)sqliteDataReader["Destination"], (sqliteDataReader["ArrangementName"] is string text) ? text : null, (sqliteDataReader["LastUsed"] is long timestamp) ? new DateTime?(timestamp.FromUnixTimestamp()) : ((DateTime?)null), ((long)sqliteDataReader["LastModified"]).FromUnixTimestamp(), ((byte[])sqliteDataReader["CopyrightData"]) ?? Array.Empty<byte>());
				return true;
			}
		}
		return false;
	}

	public void CacheMetadata(string key, string fingerprint, PresentationMetadata presentationMetadata)
	{
		if (!base.IsDisposed)
		{
			SqliteCommand sqliteCommand = new SqliteCommand("\r\n                INSERT OR REPLACE INTO " + PresentationsTableName + " (\r\n                    Key            ,\r\n                    Fingerprint    ,\r\n                    Uuid           ,\r\n                    Type           ,\r\n                    Destination    ,\r\n                    ArrangementName,\r\n                    LastUsed       ,\r\n                    LastModified   ,\r\n                    CopyrightData\r\n                )\r\n                VALUES (@key, @fingerprint, @uuid, @type, @destination, @arrangementName, @lastUsed, @lastModified, @copyrightData);", _metadataDatabase);
			sqliteCommand.Parameters.Add(new SqliteParameter("@key", key));
			sqliteCommand.Parameters.Add(new SqliteParameter("@fingerprint", fingerprint));
			sqliteCommand.Parameters.Add(new SqliteParameter("@uuid", presentationMetadata.ID.ToByteArray()));
			sqliteCommand.Parameters.Add(new SqliteParameter("@type", (long)presentationMetadata.Type));
			sqliteCommand.Parameters.Add(new SqliteParameter("@destination", (long)presentationMetadata.Destination));
			sqliteCommand.Parameters.Add(new SqliteParameter("@arrangementName", presentationMetadata.ActiveArrangementName ?? string.Empty));
			sqliteCommand.Parameters.Add(new SqliteParameter("@lastUsed", presentationMetadata.LastUsed.HasValue ? ((object)presentationMetadata.LastUsed?.ToUnixTimestamp()) : "NULL"));
			sqliteCommand.Parameters.Add(new SqliteParameter("@lastModified", presentationMetadata.LastModified.ToUnixTimestamp()));
			sqliteCommand.Parameters.Add(new SqliteParameter("@copyrightData", presentationMetadata.CopyrightInfoData));
			sqliteCommand.ExecuteNonQuery();
		}
	}

	private int ExecuteCommand(string command, params object[] parameters)
	{
		SqliteCommand sqliteCommand = new SqliteCommand(command, _metadataDatabase);
		for (int i = 0; i < parameters.Length; i++)
		{
			sqliteCommand.Parameters.AddWithValue($"@param{i}", parameters[i]);
		}
		return sqliteCommand.ExecuteNonQuery();
	}

	private SqliteDataReader ExecuteRead(string query, params object[] parameters)
	{
		SqliteCommand sqliteCommand = new SqliteCommand(query, _metadataDatabase);
		for (int i = 0; i < parameters.Length; i++)
		{
			sqliteCommand.Parameters.AddWithValue($"@param{i}", parameters[i]);
		}
		return sqliteCommand.ExecuteReader();
	}
}
