using System;
using System.CodeDom.Compiler;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using System.Xml;

namespace ProPresenter.DO.Bibles.Formats.USX.Elements;

internal class VerseElement : ElementBase
{
	public override ElementType Type => ElementType.Verse;

	public int StartNumber { get; }

	public int EndNumber { get; }

	public string StartID { get; } = string.Empty;

	public string EndID { get; } = string.Empty;

	public bool IsValid
	{
		get
		{
			if (StartNumber >= 0)
			{
				return EndNumber >= 0;
			}
			return false;
		}
	}

	[GeneratedRegex("([0-9]+)[A-Za-z]?[\\-\\,]*([0-9]*)[A-Za-z]?")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex NumberRangeRegex()
	{
		return _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__NumberRangeRegex_1.Instance;
	}

	public VerseElement(XmlNode node)
	{
		Match match = NumberRangeRegex().Match(node.GetAttribute("number") ?? string.Empty);
		if (match.Success)
		{
			Group group = match.Groups[1];
			Group group2 = match.Groups[2];
			int num = ((!string.IsNullOrEmpty(group.Value)) ? int.Parse(group.Value) : (-1));
			int val = ((!string.IsNullOrEmpty(group2.Value)) ? int.Parse(group2.Value) : num);
			StartNumber = Math.Min(num, val);
			EndNumber = Math.Max(num, val);
		}
		else
		{
			StartNumber = -1;
			EndNumber = -1;
		}
		StartID = node.GetAttribute("sid") ?? string.Empty;
		EndID = node.GetAttribute("eid") ?? string.Empty;
	}
}
