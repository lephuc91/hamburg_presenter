using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using Pro.Common.Collections;
using Pro.Common.Logging;
using Pro.Common.Nullability;
using Pro.Text;
using ProPresenter.DO.Bibles.Formats.USX;
using ProPresenter.DO.Bibles.Formats.USX.Elements;

namespace ProPresenter.DO.Bibles.Formats;

public class USXBible : BibleBase
{
	private enum DBLVersion
	{
		Unknown,
		V1x,
		V2x
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass49_0
	{
		public StreamReader streamReader;
	}

	private const string Root = "DBLMetadata";

	private const string TypeVersionAttribute = "typeVersion";

	private const string VersionAttribute = "version";

	private const string IdTag = "identification";

	private const string NameTag = "name";

	private const string AbbreviationTag = "abbreviation";

	private const string BookNames = "bookNames";

	private const string BookNamesBook = "book";

	private const string BookNamesBookCodeAttribute = "code";

	private const string BookNamesBookName = "short";

	private const string Names = "names";

	private const string NamesName = "name";

	private const string NamesNameIDAttribute = "id";

	private const string NamesNameName = "short";

	private const string CopyrightRoot = "copyright";

	private const string CopyrightTag = "statement";

	private static readonly ParagraphStyle[] SupportedParagraphStyles = new ParagraphStyle[24]
	{
		ParagraphStyle.NormalParagraph,
		ParagraphStyle.NoBreakParagraph,
		ParagraphStyle.MarginParagraph,
		ParagraphStyle.OpeningSection,
		ParagraphStyle.RightAlignParagraph,
		ParagraphStyle.ClosingSection,
		ParagraphStyle.EmbeddedTextOpening,
		ParagraphStyle.EmbeddedText,
		ParagraphStyle.EmbeddedTextClosing,
		ParagraphStyle.EmbeddedTextRefrain,
		ParagraphStyle.IndentedParagraph,
		ParagraphStyle.FlushIndentedParagraph,
		ParagraphStyle.CenterAlignParagraph,
		ParagraphStyle.HangingIndentParagraph,
		ParagraphStyle.PoeticLine,
		ParagraphStyle.RightAlignPoeticLine,
		ParagraphStyle.CenterAlignPoeticLine,
		ParagraphStyle.EmbeddedTextPoeticLine,
		ParagraphStyle.HebrewNote,
		ParagraphStyle.BlankLine,
		ParagraphStyle.ListHeader,
		ParagraphStyle.ListEntry,
		ParagraphStyle.ListFooter,
		ParagraphStyle.EmbeddedListEntry
	};

	private readonly string _biblePath;

	private readonly string _usxPath = string.Empty;

	private DBLVersion _dblVersion;

	private string _name = string.Empty;

	private string _trackingAbbreviation = string.Empty;

	private string _displayAbbreviation = string.Empty;

	private string _version = string.Empty;

	private string _revision = string.Empty;

	private string _copyright = string.Empty;

	private readonly Dictionary<Book, USXElement> _bookSourceMap = new Dictionary<Book, USXElement>();

	public override BibleFormat Format => BibleFormat.USX;

	public override string Name => _name;

	public override string TrackingAbbreviation => _trackingAbbreviation;

	public override string DisplayAbbreviation => _displayAbbreviation;

	public override string Copyright => _copyright;

	public override string Version => _version;

	public override string Revision => _revision;

	public USXBible(string biblePath)
		: base(Path.Combine(biblePath, "SearchIndex"))
	{
		_biblePath = biblePath;
		_usxPath = Directory.GetDirectories(_biblePath).FirstOrDefault((string d) => Path.GetFileName(d).StartsWith("USX", StringComparison.OrdinalIgnoreCase)) ?? string.Empty;
		LoadMetaData();
	}

	private void LoadMetaData()
	{
		try
		{
			string path = Path.Combine(_biblePath, "metadata.xml");
			if (File.Exists(path))
			{
				XmlDocument xmlDocument = new XmlDocument();
				using FileStream inStream = new FileStream(path, FileMode.Open, FileAccess.Read);
				xmlDocument.Load(inStream);
				xmlDocument.DocumentElement.ThrowWhenNull("metaDoc.DocumentElement");
				ParseFormatVersion(xmlDocument.DocumentElement.SelectSingleNode("//DBLMetadata"));
				_name = xmlDocument.DocumentElement.GetValue("//DBLMetadata/identification/name");
				_trackingAbbreviation = xmlDocument.DocumentElement.GetValue("//DBLMetadata/identification/abbreviation");
				_displayAbbreviation = _trackingAbbreviation.ToUpperInvariant();
				_copyright = xmlDocument.DocumentElement.GetValue("//DBLMetadata/copyright/statement");
			}
			RVMetadataLoader.TryParseMetadata(_biblePath, ref _name, ref _trackingAbbreviation, ref _displayAbbreviation, out _version, out _revision, ref _copyright);
		}
		catch (Exception innerException)
		{
			throw new Exception("Error trying to load the metadata", innerException);
		}
	}

	private void ParseFormatVersion(XmlNode? rootNode)
	{
		string text = (rootNode?.Attributes?["version"] ?? rootNode?.Attributes?["typeVersion"])?.Value ?? string.Empty;
		if (text.StartsWith("1."))
		{
			_dblVersion = DBLVersion.V1x;
		}
		else if (text.StartsWith("2."))
		{
			_dblVersion = DBLVersion.V2x;
		}
		else
		{
			_dblVersion = DBLVersion.Unknown;
		}
	}

	protected override Book[] OnLoadBooks()
	{
		string path = Path.Combine(_biblePath, "metadata.xml");
		if (!File.Exists(path))
		{
			return Array.Empty<Book>();
		}
		XmlDocument xmlDocument = new XmlDocument();
		using FileStream inStream = new FileStream(path, FileMode.Open, FileAccess.Read);
		xmlDocument.Load(inStream);
		xmlDocument.DocumentElement.ThrowWhenNull("metaDoc.DocumentElement");
		switch (_dblVersion)
		{
		case DBLVersion.V1x:
			return CollectBookData_Rev1(xmlDocument.DocumentElement);
		case DBLVersion.V2x:
			return CollectBookData_Rev2(xmlDocument.DocumentElement);
		default:
			Log.Error("_dblVersion not recognized. Loading DBLVersion.V1x by default");
			return CollectBookData_Rev1(xmlDocument.DocumentElement);
		}
	}

	private Book[] CollectBookData_Rev1(XmlNode documentNode)
	{
		return CollectBookData(documentNode, "bookNames", "book", "code", "short", (string? code) => (bookCode: code, bookPath: _usxPath + "/" + code + ".usx"), "contents/bookList/books/book", "code");
	}

	private Book[] CollectBookData_Rev2(XmlNode documentNode)
	{
		Dictionary<string, Tuple<string, string>> bookCodeMap = new Dictionary<string, Tuple<string, string>>();
		IEnumerable<XmlNode> source = documentNode.SelectNodes("//DBLMetadata/publications/publication")?.Cast<XmlNode>() ?? Enumerable.Empty<XmlNode>();
		foreach (XmlNode item in (source.FirstOrDefault((XmlNode pn) => pn.Attributes?["default"]?.Value == "true") ?? source.First()).SelectNodes("structure/content")?.Cast<XmlNode>() ?? Enumerable.Empty<XmlNode>())
		{
			string text = item.Attributes?["name"]?.Value;
			string text2 = item.Attributes?["role"]?.Value;
			string text3 = item.Attributes?["src"]?.Value;
			text.ThrowWhenNull("name");
			text2.ThrowWhenNull("role");
			text3.ThrowWhenNull("src");
			bookCodeMap.Add(text, new Tuple<string, string>(text2, text3));
		}
		Tuple<string, string> value;
		return CollectBookData(documentNode, "names", "name", "id", "short", (string? code) => (code == null || !bookCodeMap.TryGetValue(code, out value)) ? (bookCode: null, bookPath: null) : (bookCode: value.Item1, bookPath: Path.Combine(_biblePath, value.Item2)), "publications/publication/structure/content", "role");
	}

	private Book[] CollectBookData(XmlNode documentNode, string bookNamesRoot, string bookNameNode, string bookIDAttribute, string bookNodeNameTag, Func<string?, (string? bookCode, string? bookPath)> getCodeAndPath, string orderNodesPath, string orderNodeBookAttribute)
	{
		string[] bookOrder = ((from XmlNode x in documentNode.SelectNodes("//DBLMetadata/" + orderNodesPath)?
			select x.Attributes?[orderNodeBookAttribute]?.Value) ?? Enumerable.Empty<string>()).NotNull().ToArray();
		XmlNodeList? obj = documentNode.SelectSingleNode("//DBLMetadata/" + bookNamesRoot)?.SelectNodes("./" + bookNameNode);
		List<(string, string, string)> list = new List<(string, string, string)>();
		IEnumerable enumerable = obj;
		foreach (XmlNode item in enumerable ?? Enumerable.Empty<XmlNode>())
		{
			string value = item.GetValue("./" + bookNodeNameTag);
			(string, string) tuple = getCodeAndPath(item.Attributes?[bookIDAttribute]?.Value);
			if (tuple.Item1 != null && tuple.Item2 != null && File.Exists(tuple.Item2))
			{
				list.Add((value, tuple.Item1, tuple.Item2));
			}
		}
		list.Sort(((string bookName, string bookCode, string bookPath) a, (string bookName, string bookCode, string bookPath) b) => bookOrder.IndexOf(a.bookCode).CompareTo(bookOrder.IndexOf(b.bookCode)));
		Book[] array = new Book[list.Count];
		for (int i = 0; i < list.Count; i++)
		{
			var (bookName, bookCode, bookPath) = list[i];
			array[i] = LoadBook(bookPath, i, bookCode, bookName);
		}
		return array;
	}

	protected Book LoadBook(string bookPath, int bookCount, string bookCode, string bookName)
	{
		XmlDocument xmlDocument = new XmlDocument
		{
			PreserveWhitespace = true
		};
		using FileStream stream = new FileStream(bookPath, FileMode.Open, FileAccess.Read);
		_003C_003Ec__DisplayClass49_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass49_0();
		CS_0024_003C_003E8__locals2.streamReader = new StreamReader(stream);
		xmlDocument.LoadXml(string.Join("\n", readAllAndTrimStart()));
		xmlDocument.DocumentElement.ThrowWhenNull("bookDoc.DocumentElement");
		ElementBase elementBase = ElementProvider.ParseElement(xmlDocument.DocumentElement);
		if (elementBase == null || elementBase.Type != ElementType.USX)
		{
			throw new Exception("USX data is in a bad format");
		}
		Book book = new Book(bookCount, bookCode, bookName, ParseBookMeta((USXElement)elementBase));
		_bookSourceMap[book] = (USXElement)elementBase;
		return book;
		[IteratorStateMachine(typeof(_003C_003Ec__DisplayClass49_0._003C_003CLoadBook_003Eg__readAllAndTrimStart_007C0_003Ed))]
		IEnumerable<string> readAllAndTrimStart()
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003C_003Ec__DisplayClass49_0._003C_003CLoadBook_003Eg__readAllAndTrimStart_007C0_003Ed(-2)
			{
				_003C_003E4__this = CS_0024_003C_003E8__locals2
			};
		}
	}

	protected internal override Content? LoadVerse(Book book, Chapter chapter, Verse verse)
	{
		USXElement uSXElement = _bookSourceMap[book];
		Content activeContent = null;
		Chapter currentChapter = null;
		Verse currentVerse = null;
		StringBuilder verseContent = new StringBuilder();
		bool addSpace = false;
		List<AttributeRange> attributeRanges = new List<AttributeRange>();
		ElementBase[] children = uSXElement.Children;
		foreach (ElementBase elementBase in children)
		{
			switch (elementBase.Type)
			{
			case ElementType.Chapter:
				handleChapter((ChapterElement)elementBase);
				break;
			case ElementType.Paragraph:
				handleParagraph((ParagraphElement)elementBase);
				break;
			case ElementType.Table:
				handleTable((TableElement)elementBase);
				break;
			}
		}
		storeVerse();
		return activeContent;
		void handleChapter(ChapterElement element)
		{
			storeVerse();
			if (element.IsValid)
			{
				currentChapter = book.Chapters.FirstOrDefault((Chapter c) => c.Number == element.Number);
			}
		}
		void handleCharacter(CharacterElement element)
		{
			int length = verseContent.Length;
			ElementBase[] children4 = element.Children;
			foreach (ElementBase elementBase4 in children4)
			{
				switch (elementBase4.Type)
				{
				case ElementType.Character:
					handleCharacter((CharacterElement)elementBase4);
					break;
				case ElementType.Text:
					handleText((TextElement)elementBase4);
					break;
				case ElementType.Note:
					handleNote((NoteElement)elementBase4);
					break;
				}
			}
			if (length != verseContent.Length)
			{
				int length2 = verseContent.Length;
				switch (element.Style)
				{
				case CharacterStyle.WordsOfJesus:
					attributeRanges.Add(new AttributeRange(AttributeType.WordsOfJesus, new Pro.Text.Range(length, length2)));
					break;
				case CharacterStyle.DeityName:
				case CharacterStyle.SmallCaps:
					attributeRanges.Add(new AttributeRange(AttributeType.SmallCaps, new Pro.Text.Range(length, length2)));
					break;
				case CharacterStyle.Superscript:
					attributeRanges.Add(new AttributeRange(AttributeType.Superscript, new Pro.Text.Range(length, length2)));
					break;
				}
			}
		}
		void handleNote(NoteElement element)
		{
			if ((object)currentChapter != null && (object)currentVerse != null)
			{
				NoteStyle style = element.Style;
				if (style == NoteStyle.Footnote || style == NoteStyle.CrossReference)
				{
					addSpace = true;
				}
			}
		}
		void handleParagraph(ParagraphElement element)
		{
			if (SupportedParagraphStyles.Contains(element.Style))
			{
				ElementBase[] children3 = element.Children;
				foreach (ElementBase elementBase3 in children3)
				{
					switch (elementBase3.Type)
					{
					case ElementType.Verse:
						handleVerse((VerseElement)elementBase3);
						break;
					case ElementType.Character:
						handleCharacter((CharacterElement)elementBase3);
						break;
					case ElementType.Text:
						handleText((TextElement)elementBase3);
						break;
					case ElementType.Note:
						handleNote((NoteElement)elementBase3);
						break;
					}
				}
				if (verseContent.Length > 0)
				{
					verseContent.Append("\n");
				}
			}
		}
		void handleTable(TableElement element)
		{
			storeVerse();
			foreach (RowElement item in element.Children.OfType<RowElement>())
			{
				if ((object)currentVerse != null)
				{
					verseContent.Append("\n");
				}
				foreach (CellElement item2 in item.Children.OfType<CellElement>())
				{
					ElementBase[] children2 = item2.Children;
					foreach (ElementBase elementBase2 in children2)
					{
						switch (elementBase2.Type)
						{
						case ElementType.Verse:
							handleVerse((VerseElement)elementBase2);
							break;
						case ElementType.Text:
							handleText((TextElement)elementBase2);
							break;
						}
					}
				}
			}
		}
		void handleText(TextElement element)
		{
			if ((object)currentChapter != null && (object)currentVerse != null)
			{
				string text = element.Content;
				int num;
				if (verseContent.Length > 0)
				{
					StringBuilder stringBuilder = verseContent;
					num = (char.IsWhiteSpace(stringBuilder[stringBuilder.Length - 1]) ? 1 : 0);
				}
				else
				{
					num = 1;
				}
				bool flag = (byte)num != 0;
				if (addSpace && !flag)
				{
					verseContent.Append(" ");
				}
				if (addSpace || flag)
				{
					text = text.TrimStart();
				}
				verseContent.Append(text);
				addSpace = false;
			}
		}
		void handleVerse(VerseElement element)
		{
			storeVerse();
			if (element.IsValid && (object)currentChapter != null)
			{
				currentVerse = currentChapter.Verses.First((Verse v) => v.StartNumber == element.StartNumber && v.EndNumber == element.EndNumber);
			}
		}
		void storeVerse()
		{
			if ((object)currentChapter != null && (object)currentVerse != null)
			{
				Content content = new Content(verseContent.ToString(), attributeRanges.ToArray());
				CacheVerseContent(book, currentChapter, currentVerse, content);
				if (currentChapter == chapter && currentVerse == verse)
				{
					activeContent = content;
				}
				currentVerse = null;
				verseContent.Clear();
				addSpace = false;
				attributeRanges.Clear();
			}
		}
	}

	private IEnumerable<Chapter> ParseBookMeta(USXElement rootElement)
	{
		List<Chapter> chapters = new List<Chapter>();
		List<Verse> verses = new List<Verse>();
		bool inChapter = false;
		int chapterNumber = -1;
		ElementBase[] children = rootElement.Children;
		foreach (ElementBase elementBase in children)
		{
			switch (elementBase.Type)
			{
			case ElementType.Chapter:
				handleChapter((ChapterElement)elementBase);
				break;
			case ElementType.Paragraph:
				handleParagraph((ParagraphElement)elementBase);
				break;
			case ElementType.Table:
				handleTable((TableElement)elementBase);
				break;
			}
		}
		addChapter();
		return chapters.ToArray();
		void addChapter()
		{
			if (inChapter)
			{
				if (verses.Any())
				{
					chapters.Add(new Chapter(chapterNumber, verses));
				}
				verses.Clear();
				inChapter = false;
			}
		}
		void handleChapter(ChapterElement element)
		{
			addChapter();
			if (element.IsValid)
			{
				inChapter = true;
				chapterNumber = element.Number;
			}
		}
		void handleParagraph(ParagraphElement element)
		{
			if (SupportedParagraphStyles.Contains(element.Style))
			{
				ElementBase[] children2 = element.Children;
				foreach (ElementBase elementBase2 in children2)
				{
					if (elementBase2.Type == ElementType.Verse)
					{
						handleVerse((VerseElement)elementBase2);
					}
				}
			}
		}
		void handleTable(TableElement element)
		{
			foreach (RowElement item in element.Children.OfType<RowElement>())
			{
				foreach (CellElement item2 in item.Children.OfType<CellElement>())
				{
					foreach (VerseElement item3 in item2.Children.OfType<VerseElement>())
					{
						handleVerse(item3);
					}
				}
			}
		}
		void handleVerse(VerseElement element)
		{
			if (element.IsValid)
			{
				verses.Add(new Verse(element.StartNumber, element.EndNumber));
			}
		}
	}
}
