using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Microsoft.Data.Sqlite;
using Pro.Common.Components;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using Pro.Common.Time;

namespace ProPresenter.DO.Media;

public class MediaMetadataCacheRepository : DisposableBase, IMediaMetadataCacheRepository, IDisposable
{
	private const string DBFilename = "cache.sqlite3";

	private readonly SqliteConnection _metadataDatabase;

	public MediaMetadataCacheRepository(string? dbFolder = null, bool clearCache = false)
	{
		Log.Info("Opening media metadata cache...");
		string text = dbFolder;
		if (text == null)
		{
			string reference = CommonPaths.ThumbnailCache;
			text = Path.Combine(new ReadOnlySpan<string>(in reference));
		}
		dbFolder = text;
		Directory.CreateDirectory(dbFolder);
		string text2 = Path.Combine(dbFolder, "cache.sqlite3");
		if (clearCache && File.Exists(text2))
		{
			File.Delete(text2);
		}
		_metadataDatabase = new SqliteConnection("Filename=" + text2 + "; Mode=ReadWriteCreate; Cache=Default; Pooling=False");
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
		ExecuteCommand("\r\n                CREATE TABLE IF NOT EXISTS Media (\r\n\t                Key\t          TEXT     NOT NULL,\r\n                    Fingerprint   TEXT     NOT NULL,\r\n                    Thumbnail     TEXT     NOT NULL,\r\n                    Artist        TEXT     NOT NULL,\r\n                    Codec         TEXT     NOT NULL,\r\n                    Duration      REAL     NOT NULL,\r\n                    FPS           REAL     NOT NULL,\r\n                    Width         INTEGER  NOT NULL,\r\n                    Height        INTEGER  NOT NULL,\r\n                    ChannelCount  INTEGER  NOT NULL,\r\n                    Rotation      INTEGER  NOT NULL,\r\n                    Title         TEXT     NOT NULL,\r\n                    SupportsAlphaChannel         INTEGER     NOT NULL,\r\n                    PRIMARY KEY(Key, Fingerprint)\r\n                );");
		ExecuteCommand("\r\n                CREATE INDEX IF NOT EXISTS MediaKeyFingerprintIndex ON Media (\r\n                    Key,\r\n                    Fingerprint\r\n                );");
		if (!ColumnExists("SupportsAlphaChannel", "Media"))
		{
			ExecuteCommand("ALTER TABLE Media ADD COLUMN SupportsAlphaChannel INTEGER DEFAULT 0");
		}
	}

	public bool TryGetCachedMetadata(string key, string fingerprint, [NotNullWhen(true)] out string? thumbnail, [NotNullWhen(true)] out MediaMetadata? mediaMetadata)
	{
		thumbnail = null;
		mediaMetadata = null;
		using (SqliteCommand sqliteCommand = GetReadCommand("SELECT * FROM Media WHERE Key = @param0 AND Fingerprint = @param1;", key, fingerprint))
		{
			using SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader();
			if (sqliteDataReader.Read())
			{
				thumbnail = (string)sqliteDataReader["Thumbnail"];
				mediaMetadata = new MediaMetadata((string)sqliteDataReader["Artist"], (string)sqliteDataReader["Codec"], TimeSlice.FromSeconds((double)sqliteDataReader["Duration"]), (double)sqliteDataReader["FPS"], new Vector2<int>((int)(long)sqliteDataReader["Width"], (int)(long)sqliteDataReader["Height"]), (int)(long)sqliteDataReader["ChannelCount"], (NativeRotation)(long)sqliteDataReader["Rotation"], (string)sqliteDataReader["Title"], ToNullableBool((int)(long)sqliteDataReader["SupportsAlphaChannel"]), IsHdrContent: false, GammaVariant.HLG, string.Empty, MediaAvailability.Unset);
				return true;
			}
		}
		return false;
	}

	public void CacheMetadata(string key, string fingerprint, string thumbnail, MediaMetadata mediaMetadata)
	{
		using SqliteCommand sqliteCommand = new SqliteCommand("\r\n                INSERT OR REPLACE INTO Media (\r\n                    Key         ,\r\n                    Fingerprint ,\r\n                    Thumbnail   ,\r\n                    Artist      ,\r\n                    Codec       ,\r\n                    Duration    ,\r\n                    FPS         ,\r\n                    Width       ,\r\n                    Height      ,\r\n                    ChannelCount,\r\n                    Rotation    ,\r\n                    Title       ,\r\n                    SupportsAlphaChannel\r\n                )\r\n                VALUES (@key, @fingerprint, @thumbnail, @artist, @codec, @duration, @fps, @sizeX, @sizeY, @channelCount, @rotation, @title, @supportsAlphaChannel);", _metadataDatabase);
		sqliteCommand.Parameters.Add(new SqliteParameter("@key", key));
		sqliteCommand.Parameters.Add(new SqliteParameter("@fingerprint", fingerprint));
		sqliteCommand.Parameters.Add(new SqliteParameter("@thumbnail", thumbnail));
		sqliteCommand.Parameters.Add(new SqliteParameter("@artist", mediaMetadata.Artist));
		sqliteCommand.Parameters.Add(new SqliteParameter("@codec", mediaMetadata.Codec));
		sqliteCommand.Parameters.Add(new SqliteParameter("@duration", mediaMetadata.Duration.TotalSeconds));
		sqliteCommand.Parameters.Add(new SqliteParameter("@fps", mediaMetadata.FPS));
		sqliteCommand.Parameters.Add(new SqliteParameter("@sizeX", mediaMetadata.Size.X));
		sqliteCommand.Parameters.Add(new SqliteParameter("@sizeY", mediaMetadata.Size.Y));
		sqliteCommand.Parameters.Add(new SqliteParameter("@channelCount", mediaMetadata.AudioChannelCount));
		sqliteCommand.Parameters.Add(new SqliteParameter("@rotation", mediaMetadata.Rotation));
		sqliteCommand.Parameters.Add(new SqliteParameter("@title", mediaMetadata.Title));
		sqliteCommand.Parameters.Add(new SqliteParameter("@supportsAlphaChannel", FromNullableBool(mediaMetadata.SupportsAlphaChannel)));
		sqliteCommand.ExecuteNonQuery();
	}

	public void RemoveCachedMetadata(string key, string fingerprint)
	{
		ExecuteCommand("DELETE FROM Media WHERE Key = @param0 AND Fingerprint = @param1;", key, fingerprint);
	}

	public IReadOnlyCollection<string> GetAllThumbnailFilenames()
	{
		List<string> list = new List<string>();
		using SqliteCommand sqliteCommand = GetReadCommand("SELECT Thumbnail FROM Media;");
		using SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader();
		while (sqliteDataReader.Read())
		{
			list.Add((string)sqliteDataReader["Thumbnail"]);
		}
		return list;
	}

	private void ExecuteCommand(string command, params object[] parameters)
	{
		using SqliteCommand sqliteCommand = new SqliteCommand(command, _metadataDatabase);
		for (int i = 0; i < parameters.Length; i++)
		{
			sqliteCommand.Parameters.AddWithValue($"@param{i}", parameters[i]);
		}
		sqliteCommand.ExecuteNonQuery();
	}

	private SqliteCommand GetReadCommand(string query, params object[] parameters)
	{
		SqliteCommand sqliteCommand = new SqliteCommand(query, _metadataDatabase);
		for (int i = 0; i < parameters.Length; i++)
		{
			sqliteCommand.Parameters.AddWithValue($"@param{i}", parameters[i]);
		}
		return sqliteCommand;
	}

	private static bool? ToNullableBool(int value)
	{
		return value switch
		{
			1 => true, 
			2 => false, 
			_ => null, 
		};
	}

	private static int FromNullableBool(bool? value)
	{
		if (value.HasValue)
		{
			if (value == true)
			{
				return 1;
			}
			return 2;
		}
		return 0;
	}

	private bool ColumnExists(string columnName, string tableName)
	{
		string query = "PRAGMA table_info(" + tableName + ")";
		using (SqliteCommand sqliteCommand = GetReadCommand(query))
		{
			using SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader();
			while (sqliteDataReader.Read())
			{
				if (sqliteDataReader.GetString(1).Equals(columnName, StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
		}
		return false;
	}
}
