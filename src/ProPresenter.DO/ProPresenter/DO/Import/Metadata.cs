using System;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;

namespace ProPresenter.DO.Import;

public class Metadata
{
	public string? Title { get; private set; }

	public string? Author { get; private set; }

	public string? Copyright { get; private set; }

	public string? CCLI { get; private set; }

	public string? SongID { get; private set; }

	public string? Notes { get; private set; }

	public string? Hymnal { get; private set; }

	public string[]? PlayOrder { get; private set; }

	[GeneratedRegex("Title:(.*)", RegexOptions.Multiline)]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex TitleRegex()
	{
		return _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__TitleRegex_7.Instance;
	}

	[GeneratedRegex("Author:(.*)", RegexOptions.Multiline)]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex AuthorRegex()
	{
		return _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__AuthorRegex_8.Instance;
	}

	[GeneratedRegex("Copyright:.*(\\d{4})|©.*(\\d{4})", RegexOptions.Multiline)]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex CopyrightRegex()
	{
		return _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__CopyrightRegex_9.Instance;
	}

	[GeneratedRegex("CCLI:(.*)|CCLI License #(.*)", RegexOptions.Multiline)]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex CCLINumRegex()
	{
		return _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__CCLINumRegex_10.Instance;
	}

	[GeneratedRegex("Song ID:(.*)|CCLI Song #(.*)", RegexOptions.Multiline)]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex SongIDRegex()
	{
		return _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__SongIDRegex_11.Instance;
	}

	[GeneratedRegex("Hymnal:(.*)", RegexOptions.Multiline)]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex HymnalRegex()
	{
		return _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__HymnalRegex_12.Instance;
	}

	[GeneratedRegex("Notes:(.*)", RegexOptions.Multiline)]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex NotesRegex()
	{
		return _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__NotesRegex_13.Instance;
	}

	[GeneratedRegex("PlayOrder:(.*)", RegexOptions.Multiline)]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex PlayOrderRegex()
	{
		return _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__PlayOrderRegex_14.Instance;
	}

	public static bool IsMetadata(string text)
	{
		if (!TitleRegex().IsMatch(text) && !AuthorRegex().IsMatch(text) && !CopyrightRegex().IsMatch(text) && !CCLINumRegex().IsMatch(text) && !SongIDRegex().IsMatch(text) && !HymnalRegex().IsMatch(text) && !NotesRegex().IsMatch(text))
		{
			return PlayOrderRegex().IsMatch(text);
		}
		return true;
	}

	public static bool TryParse(string text, [NotNullWhen(true)] out Metadata? metadata)
	{
		metadata = null;
		if (!IsMetadata(text))
		{
			return false;
		}
		Match match2 = TitleRegex().Match(text);
		Match match3 = AuthorRegex().Match(text);
		Match match4 = CopyrightRegex().Match(text);
		Match match5 = CCLINumRegex().Match(text);
		Match match6 = SongIDRegex().Match(text);
		Match match7 = HymnalRegex().Match(text);
		Match match8 = NotesRegex().Match(text);
		Match match9 = PlayOrderRegex().Match(text);
		Metadata data = new Metadata();
		getData(match2, delegate(string s)
		{
			data.Title = s;
		});
		getData(match3, delegate(string s)
		{
			data.Author = s;
		});
		getData(match4, delegate(string s)
		{
			data.Copyright = s;
		});
		getData(match5, delegate(string s)
		{
			data.CCLI = s;
		});
		getData(match6, delegate(string s)
		{
			data.SongID = s;
		});
		getData(match7, delegate(string s)
		{
			data.Hymnal = s;
		});
		getData(match8, delegate(string s)
		{
			data.Notes = s;
		});
		getData(match9, delegate(string s)
		{
			data.PlayOrder = s?.Split(',') ?? Array.Empty<string>();
		});
		metadata = data;
		return true;
		static bool getData(Match match, Action<string> setField)
		{
			if (match.Success)
			{
				setField(getValue(match.Groups));
				return true;
			}
			return false;
		}
		static string getValue(GroupCollection groupCollection)
		{
			return groupCollection.OfType<Group>().Skip(1).FirstOrDefault((Group g) => g.Success)?.Value.Trim() ?? string.Empty;
		}
	}
}
