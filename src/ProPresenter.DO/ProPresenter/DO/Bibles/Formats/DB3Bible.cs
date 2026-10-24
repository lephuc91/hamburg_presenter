using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml;
using Microsoft.Data.Sqlite;

namespace ProPresenter.DO.Bibles.Formats;

public class DB3Bible : BibleBase
{
	private const string BookKeyFile = "documents/LegacyToUSXKeys.xml";

	private const string BibleTable = "ZBIBLE";

	private const string BibleName = "ZBIBLE_NAME";

	private const string BibleAbbreviation = "ZBIBLE_ABBREVIATION";

	private const string BibleCopyright = "ZBIBLE_COPYRIGHT";

	private const string BookTable = "ZBOOK";

	private const string BookKey = "Z_PK";

	private const string BookIndex = "ZBOOK_INDEX";

	private const string BookName = "ZBOOK_NAME";

	private const string ChapterTable = "ZCHAPTER";

	private const string ChapterKey = "Z_PK";

	private const string ChapterNumber = "ZCHAPTER_NUMBER";

	private const string ChapterBook = "ZTOBOOK";

	private const string VerseTable = "ZVERSE";

	private const string VerseKey = "Z_PK";

	private const string VerseNumber = "ZVERSE_NUMBER";

	private const string VerseContent = "ZVERSE_CONTENT";

	private const string VerseChapter = "ZTOCHAPTER";

	private readonly string _biblePath;

	private string _name = string.Empty;

	private string _trackingAbbreviation = string.Empty;

	private string _displayAbbreviation = string.Empty;

	private string _internalAbbreviation = string.Empty;

	private string _copyright = string.Empty;

	private string _version = string.Empty;

	private string _revision = string.Empty;

	private readonly SqliteConnection _bibleDatabase;

	private static ReadOnlyDictionary<string, string[]> BookKeyMap { get; }

	public override BibleFormat Format => BibleFormat.DB3;

	public override string Name => _name;

	public override string TrackingAbbreviation => _trackingAbbreviation;

	public override string DisplayAbbreviation => _displayAbbreviation;

	public override string Copyright => _copyright;

	public override string Version => _version;

	public override string Revision => _revision;

	static DB3Bible()
	{
		Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>();
		XmlDocument xmlDocument = new XmlDocument();
		using (FileStream inStream = new FileStream("documents/LegacyToUSXKeys.xml", FileMode.Open, FileAccess.Read))
		{
			xmlDocument.Load(inStream);
			IEnumerable enumerable = xmlDocument.DocumentElement?.SelectSingleNode("//USXKeys");
			foreach (XmlNode item in enumerable ?? Enumerable.Empty<XmlNode>())
			{
				string stringAttribute = item.GetStringAttribute("abbreviation", string.Empty);
				if (string.IsNullOrWhiteSpace(stringAttribute))
				{
					continue;
				}
				string[] array = new string[item.ChildNodes.Count];
				foreach (XmlNode item2 in item)
				{
					array[item2.GetIntAttribute("index", 0) - 1] = item2.GetStringAttribute("code", string.Empty);
				}
				if (!array.Any(string.IsNullOrWhiteSpace))
				{
					dictionary.Add(stringAttribute, array);
				}
			}
		}
		BookKeyMap = new ReadOnlyDictionary<string, string[]>(dictionary);
	}

	public DB3Bible(string biblePath)
		: base(Path.Combine(biblePath, "SearchIndex"))
	{
		_biblePath = biblePath;
		_bibleDatabase = new SqliteConnection("Filename=" + Path.Combine(biblePath, "bible.db3") + "; Mode=ReadWriteCreate; Cache=Default");
		_bibleDatabase.Open();
		LoadMetadata();
	}

	protected override void OnDispose(bool disposeObjects)
	{
		if (disposeObjects)
		{
			_bibleDatabase.Close();
			_bibleDatabase.Dispose();
		}
	}

	private void LoadMetadata()
	{
		EnsureValid();
		try
		{
			global::_003C_003Ey__InlineArray4<object> buffer = default(global::_003C_003Ey__InlineArray4<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 0) = "ZBIBLE_NAME";
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 1) = "ZBIBLE_ABBREVIATION";
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 2) = "ZBIBLE_COPYRIGHT";
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 3) = "ZBIBLE";
			using (SqliteDataReader sqliteDataReader = ExecuteRead(string.Format("SELECT {0}, {1}, {2} FROM {3}", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray4<object>, object>(in buffer, 4))))
			{
				if (!sqliteDataReader.Read())
				{
					throw new InvalidOperationException();
				}
				_name = Convert.ToString(sqliteDataReader["ZBIBLE_NAME"]) ?? string.Empty;
				_trackingAbbreviation = Convert.ToString(sqliteDataReader["ZBIBLE_ABBREVIATION"]) ?? string.Empty;
				_displayAbbreviation = _trackingAbbreviation.ToUpperInvariant();
				_internalAbbreviation = _trackingAbbreviation;
				_copyright = Convert.ToString(sqliteDataReader["ZBIBLE_COPYRIGHT"]) ?? string.Empty;
			}
			RVMetadataLoader.TryParseMetadata(_biblePath, ref _name, ref _trackingAbbreviation, ref _displayAbbreviation, out _version, out _revision, ref _copyright);
		}
		catch (Exception innerException)
		{
			throw new Exception("Error trying to load the metadata", innerException);
		}
	}

	protected override Book[] OnLoadBooks()
	{
		EnsureValid();
		try
		{
			Book[] array;
			using (SqliteDataReader sqliteDataReader = ExecuteRead(string.Format("SELECT COUNT(*) FROM {0}", "ZBOOK")))
			{
				if (!sqliteDataReader.Read())
				{
					throw new InvalidOperationException();
				}
				array = new Book[sqliteDataReader.GetInt32(0)];
			}
			global::_003C_003Ey__InlineArray4<object> buffer = default(global::_003C_003Ey__InlineArray4<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 0) = "Z_PK";
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 1) = "ZBOOK_INDEX";
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 2) = "ZBOOK_NAME";
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 3) = "ZBOOK";
			using SqliteDataReader sqliteDataReader2 = ExecuteRead(string.Format("SELECT {0}, {1}, {2} FROM {3} ORDER BY {1} ASC", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray4<object>, object>(in buffer, 4)));
			while (sqliteDataReader2.Read())
			{
				object obj = sqliteDataReader2["Z_PK"];
				int num = Convert.ToInt32(sqliteDataReader2["ZBOOK_INDEX"]) - 1;
				string name = (string)sqliteDataReader2["ZBOOK_NAME"];
				List<Chapter> list = new List<Chapter>();
				global::_003C_003Ey__InlineArray5<object> buffer2 = default(global::_003C_003Ey__InlineArray5<object>);
				global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray5<object>, object>(ref buffer2, 0) = "Z_PK";
				global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray5<object>, object>(ref buffer2, 1) = "ZCHAPTER_NUMBER";
				global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray5<object>, object>(ref buffer2, 2) = "ZCHAPTER";
				global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray5<object>, object>(ref buffer2, 3) = "ZTOBOOK";
				global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray5<object>, object>(ref buffer2, 4) = obj;
				using (SqliteDataReader sqliteDataReader3 = ExecuteRead(string.Format("SELECT {0}, {1} FROM {2} WHERE {3} = {4} ORDER BY {1} ASC", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray5<object>, object>(in buffer2, 5))))
				{
					while (sqliteDataReader3.Read())
					{
						object obj2 = sqliteDataReader3["Z_PK"];
						int currentChapterNumber = Convert.ToInt32(sqliteDataReader3["ZCHAPTER_NUMBER"]);
						List<Verse> list2 = new List<Verse>();
						global::_003C_003Ey__InlineArray5<object> buffer3 = default(global::_003C_003Ey__InlineArray5<object>);
						global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray5<object>, object>(ref buffer3, 0) = "Z_PK";
						global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray5<object>, object>(ref buffer3, 1) = "ZVERSE_NUMBER";
						global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray5<object>, object>(ref buffer3, 2) = "ZVERSE";
						global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray5<object>, object>(ref buffer3, 3) = "ZTOCHAPTER";
						global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray5<object>, object>(ref buffer3, 4) = obj2;
						using (SqliteDataReader sqliteDataReader4 = ExecuteRead(string.Format("SELECT {0}, {1} FROM {2} WHERE {3} = {4} ORDER BY {1} ASC", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray5<object>, object>(in buffer3, 5))))
						{
							while (sqliteDataReader4.Read())
							{
								int num2 = Convert.ToInt32(sqliteDataReader4["Z_PK"]);
								Verse item = new Verse(Convert.ToInt32(sqliteDataReader4["ZVERSE_NUMBER"]))
								{
									SourceKey = num2
								};
								list2.Add(item);
							}
						}
						int num3 = list.FindIndex((Chapter c) => c.Number == currentChapterNumber);
						if (num3 < 0)
						{
							list.Add(new Chapter(currentChapterNumber, list2));
						}
						else
						{
							list[num3] = new Chapter(currentChapterNumber, list[num3].Verses.Concat(list2));
						}
					}
				}
				if (!BookKeyMap.TryGetValue(_trackingAbbreviation, out string[] value) && !BookKeyMap.TryGetValue(_internalAbbreviation, out value))
				{
					throw new KeyNotFoundException("Failed to find the bible in the book key map");
				}
				string key = value[num];
				if ((object)array[num] == null)
				{
					array[num] = new Book(num, key, name, list);
				}
				else
				{
					array[num] = new Book(num, key, name, array[num].Chapters.Concat(list));
				}
			}
			return array;
		}
		catch (Exception innerException)
		{
			throw new Exception("Error trying to load the books", innerException);
		}
	}

	protected internal override Content LoadVerse(Book book, Chapter chapter, Verse verse)
	{
		EnsureValid();
		try
		{
			global::_003C_003Ey__InlineArray4<object> buffer = default(global::_003C_003Ey__InlineArray4<object>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 0) = "ZVERSE_CONTENT";
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 1) = "ZVERSE";
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 2) = "Z_PK";
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 3) = (int)(verse.SourceKey ?? ((object)0));
			using SqliteDataReader sqliteDataReader = ExecuteRead(string.Format("SELECT {0} FROM {1} WHERE {2} = {3}", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray4<object>, object>(in buffer, 4)));
			string text = string.Empty;
			if (sqliteDataReader.Read())
			{
				text = (string)sqliteDataReader["ZVERSE_CONTENT"];
			}
			return new Content(text.Trim() + " ");
		}
		catch (Exception innerException)
		{
			throw new Exception("Error trying to load a verse", innerException);
		}
	}

	private SqliteDataReader ExecuteRead(string query)
	{
		return new SqliteCommand(query, _bibleDatabase).ExecuteReader();
	}
}
