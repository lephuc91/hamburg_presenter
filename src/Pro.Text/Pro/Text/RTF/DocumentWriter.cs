using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Common.Strings;
using Pro.Common.Utility;
using Pro.Text.RTF.Tokens;

namespace Pro.Text.RTF;

public abstract class DocumentWriter
{
	private const string UnicodePlaceholder = "?";

	private const DefaultCharacterSet.CharacterSet DocumentCharacterSet = DefaultCharacterSet.CharacterSet.ANSI;

	private const int DocumentCodePage = 1252;

	private bool _writeInProgress;

	private bool _isFirstParagraph = true;

	private readonly FontTable _fontTable = new FontTable();

	private readonly ColorTable _colorTable = new ColorTable();

	private readonly ListTable _listTable = new ListTable();

	private readonly List<IToken> _tokens = new List<IToken>();

	[GeneratedRegex("(\\{+)([0-9]+)(\\}+)")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex PlaceholderRegex()
	{
		return _003CRegexGenerator_g_003EF57B2832C340465DE9FCA1C1E54A7405D72AD510F32C0D9562DDA1404CB5DF29C__PlaceholderRegex_9.Instance;
	}

	protected void PrepareWrite()
	{
		if (_writeInProgress)
		{
			throw new InvalidOperationException("Previous write was not completed");
		}
		_writeInProgress = true;
		_isFirstParagraph = true;
		_fontTable.Clear();
		_colorTable.Clear();
		_listTable.Clear();
		_tokens.Clear();
	}

	protected string CompleteWrite()
	{
		if (!_writeInProgress)
		{
			throw new InvalidOperationException("Prepare write was never called");
		}
		Pro.Text.RTF.Tokens.Group group = new Pro.Text.RTF.Tokens.Group();
		group.Tokens.Add(new DocumentVersion());
		group.Tokens.Add(new DefaultCharacterSet
		{
			DefaultSet = DefaultCharacterSet.CharacterSet.ANSI
		});
		group.Tokens.Add(new CodePage
		{
			IsGlobal = true,
			Page = 1252
		});
		Pro.Text.RTF.Tokens.Group group2 = new Pro.Text.RTF.Tokens.Group();
		group2.Tokens.Add(new Pro.Text.RTF.Tokens.FontTable());
		foreach (int index in _fontTable.Indices)
		{
			FontData fontData = _fontTable.GetFontData(index);
			group2.Tokens.Add(new Pro.Text.RTF.Tokens.Font
			{
				FontIndex = index
			});
			group2.Tokens.Add(new Pro.Text.RTF.Tokens.FontFamily
			{
				Family = Pro.Text.RTF.Tokens.FontFamily.FamilyType.Unknown
			});
			if (fontData.CharacterSet.HasValue)
			{
				group2.Tokens.Add(new FontCharacterSet
				{
					CharacterSet = fontData.CharacterSet.Value
				});
			}
			if (fontData.CodePage.HasValue)
			{
				group2.Tokens.Add(new CodePage
				{
					Page = fontData.CodePage.Value
				});
			}
			AddTextTokens(group2.Tokens, fontData.Name);
			group2.Tokens.Add(new GroupDelimiter());
		}
		group.Tokens.Add(group2);
		Pro.Text.RTF.Tokens.Group group3 = new Pro.Text.RTF.Tokens.Group();
		Pro.Text.RTF.Tokens.Group group4 = new Pro.Text.RTF.Tokens.Group();
		group3.Tokens.Add(new Pro.Text.RTF.Tokens.ColorTable());
		group4.Tokens.Add(new ExtendedMarker());
		group4.Tokens.Add(new ExpandedColorTable());
		group3.Tokens.Add(new GroupDelimiter());
		group4.Tokens.Add(new GroupDelimiter());
		for (int i = 1; i < _colorTable.EntryCount; i++)
		{
			Color color = _colorTable.GetColor(i);
			group3.Tokens.Add(new ColorComponent
			{
				Component = ColorComponent.ComponentType.Red,
				Value = color.R
			});
			group3.Tokens.Add(new ColorComponent
			{
				Component = ColorComponent.ComponentType.Green,
				Value = color.G
			});
			group3.Tokens.Add(new ColorComponent
			{
				Component = ColorComponent.ComponentType.Blue,
				Value = color.B
			});
			group3.Tokens.Add(new GroupDelimiter());
			group4.Tokens.Add(new ColorSpaceGenericRGB());
			group4.Tokens.Add(new ExpandedColorComponent
			{
				Value = ColorExtensions.NormalizeComponent(color.R)
			});
			group4.Tokens.Add(new ExpandedColorComponent
			{
				Value = ColorExtensions.NormalizeComponent(color.G)
			});
			group4.Tokens.Add(new ExpandedColorComponent
			{
				Value = ColorExtensions.NormalizeComponent(color.B)
			});
			group4.Tokens.Add(new ExpandedColorComponent
			{
				Value = ColorExtensions.NormalizeComponent(color.A)
			});
			group4.Tokens.Add(new GroupDelimiter());
		}
		group.Tokens.Add(group3);
		group.Tokens.Add(group4);
		Pro.Text.RTF.Tokens.Group group5 = new Pro.Text.RTF.Tokens.Group();
		Pro.Text.RTF.Tokens.Group group6 = new Pro.Text.RTF.Tokens.Group();
		group5.Tokens.Add(new ExtendedMarker());
		group5.Tokens.Add(new Pro.Text.RTF.Tokens.ListTable());
		group6.Tokens.Add(new ExtendedMarker());
		group6.Tokens.Add(new ListOverrideTable());
		ListData[] listData = _listTable.ListData;
		foreach (ListData listData2 in listData)
		{
			Pro.Text.RTF.Tokens.Group group7 = new Pro.Text.RTF.Tokens.Group();
			group7.Tokens.Add(new List());
			group7.Tokens.Add(new ListID
			{
				ID = listData2.ID
			});
			group7.Tokens.Add(new ListTemplate
			{
				TemplateID = listData2.ID
			});
			group7.Tokens.Add(new ListHybrid());
			foreach (LevelData level in listData2.Levels)
			{
				Pro.Text.RTF.Tokens.Group group8 = new Pro.Text.RTF.Tokens.Group();
				group8.Tokens.Add(new ListLevel());
				group8.Tokens.Add(new LevelNumberType
				{
					Numbering = level.NumberType,
					IsImportant = false
				});
				group8.Tokens.Add(new LevelNumberType
				{
					Numbering = level.NumberType,
					IsImportant = true
				});
				group8.Tokens.Add(new LevelJustification
				{
					Justification = LevelJustification.JustificationType.Left,
					IsImportant = false
				});
				group8.Tokens.Add(new LevelJustification
				{
					Justification = LevelJustification.JustificationType.Left,
					IsImportant = true
				});
				group8.Tokens.Add(new LevelFollow
				{
					Follow = level.Follow
				});
				group8.Tokens.Add(new LevelStartAt
				{
					StartingNumber = level.StartNumber
				});
				Pro.Text.RTF.Tokens.Group levelText = new Pro.Text.RTF.Tokens.Group();
				levelText.Tokens.Add(new LevelText());
				levelText.Tokens.Add(new LevelTemplate
				{
					TemplateID = listData2.ID
				});
				Pro.Text.RTF.Tokens.Group levelNumbers = new Pro.Text.RTF.Tokens.Group();
				levelNumbers.Tokens.Add(new LevelNumbers());
				Func<string, string> func = (string v) => v.Replace("{{", "{").Replace("}}", "}");
				string numberingFormat = level.NumberingFormat;
				int offset = 0;
				string text = string.Empty;
				List<string> list = new List<string>();
				List<int> placeholders = new List<int>();
				foreach (Match item in PlaceholderRegex().Matches(numberingFormat).Cast<Match>())
				{
					System.Text.RegularExpressions.Group group9 = item.Groups[1];
					System.Text.RegularExpressions.Group group10 = item.Groups[2];
					System.Text.RegularExpressions.Group group11 = item.Groups[3];
					bool num = group9.Length.IsOdd() || group11.Length.IsOdd();
					string text2 = func(group9.Value);
					string text3 = func(group11.Value);
					if (num)
					{
						placeholders.Add(int.Parse(group10.Value));
						text2 = text2.Substring(1);
						text3 = text3.Substring(1);
					}
					string text4 = func(numberingFormat.Substring(offset, item.Index - offset));
					text = text + text4 + text2;
					if (num)
					{
						list.Add(text);
						text = string.Empty;
					}
					else
					{
						text += group10.Value;
					}
					text += text3;
					offset = item.Index + item.Length;
				}
				if (offset < numberingFormat.Length)
				{
					text += func(numberingFormat.Substring(offset));
				}
				if (!string.IsNullOrEmpty(text))
				{
					list.Add(text);
				}
				levelText.Tokens.Add(new HexCharacter
				{
					EncodedCharacter = (byte)(list.Sum((string s) => s.Length) + placeholders.Count)
				});
				offset = 0;
				Action action = delegate
				{
					if (placeholders.Any())
					{
						int num2 = placeholders.First();
						placeholders.RemoveAt(0);
						levelText.Tokens.Add(new HexCharacter
						{
							EncodedCharacter = (byte)num2
						});
						levelNumbers.Tokens.Add(new HexCharacter
						{
							EncodedCharacter = (byte)(offset + 1)
						});
					}
				};
				foreach (string item2 in list)
				{
					offset += item2.Length;
					AddTextTokens(levelText.Tokens, item2);
					action();
				}
				action();
				levelText.Tokens.Add(new GroupDelimiter());
				levelNumbers.Tokens.Add(new GroupDelimiter());
				group8.Tokens.Add(levelText);
				group8.Tokens.Add(levelNumbers);
				group7.Tokens.Add(group8);
			}
			group5.Tokens.Add(group7);
			Pro.Text.RTF.Tokens.Group group12 = new Pro.Text.RTF.Tokens.Group();
			group12.Tokens.Add(new ListOverride());
			group12.Tokens.Add(new ListID
			{
				ID = listData2.ID
			});
			group12.Tokens.Add(new ListOverrideCount
			{
				Count = 0
			});
			group12.Tokens.Add(new ListIndex
			{
				Index = listData2.ID
			});
			group6.Tokens.Add(group12);
		}
		group.Tokens.Add(group5);
		group.Tokens.Add(group6);
		group.Tokens.Add(new UnicodeCharacterPlaceholder
		{
			CharacterCount = "?".Length
		});
		group.Tokens.AddRange(_tokens);
		_writeInProgress = false;
		return TokenWriter.WriteDocument(group);
	}

	protected void AddLevel(int listIndex, FollowType follow, NumberingScheme numberingScheme, string numberingFormat, bool isBullet, int startNumber)
	{
		_listTable.AddLevel(listIndex, follow, numberingScheme, numberingFormat, isBullet, startNumber);
	}

	protected void AddList(int listIndex)
	{
		_listTable.AddList(listIndex);
	}

	protected void AddTabStop(double position, TabStopType type)
	{
		switch (type)
		{
		case TabStopType.Center:
			_tokens.Add(new TabStopCenter());
			break;
		case TabStopType.Right:
			_tokens.Add(new TabStopRight());
			break;
		case TabStopType.Decimal:
			_tokens.Add(new TabStopDecimal());
			break;
		}
		_tokens.Add(new Pro.Text.RTF.Tokens.TabStop
		{
			Position = position
		});
	}

	protected void ChangeFontSize(int fontSize)
	{
		_tokens.Add(new FontSize
		{
			CharacterSize = fontSize
		});
	}

	protected void ChangeAlignment(ParagraphAlignment alignment)
	{
		_tokens.Add(new Alignment
		{
			ParagraphAlignment = alignment
		});
	}

	protected void ChangeParagraphSpacing(bool isBefore, double spacing)
	{
		_tokens.Add(new ParagraphSpacing
		{
			IsBefore = isBefore,
			Spacing = spacing
		});
	}

	protected void ChangeCharacterSpacing(double spacing)
	{
		_tokens.Add(new CharacterSpacing
		{
			Spacing = spacing
		});
	}

	protected void SetLigaturesEnabled(bool value)
	{
		_tokens.Add(new Ligatures
		{
			IsActive = value
		});
	}

	protected void ChangeLineSpacing(LineSpacingMode lineSpacingMode, double spacing)
	{
		Pro.Text.RTF.Tokens.LineSpacingMode.SpacingMode mode = Pro.Text.RTF.Tokens.LineSpacingMode.SpacingMode.Absolute;
		switch (lineSpacingMode)
		{
		case LineSpacingMode.Absolute:
			spacing *= -1.0;
			mode = Pro.Text.RTF.Tokens.LineSpacingMode.SpacingMode.Absolute;
			break;
		case LineSpacingMode.Multiple:
			spacing *= 12.0;
			mode = Pro.Text.RTF.Tokens.LineSpacingMode.SpacingMode.Multiple;
			break;
		}
		_tokens.Add(new LineSpacing
		{
			Spacing = spacing
		});
		_tokens.Add(new Pro.Text.RTF.Tokens.LineSpacingMode
		{
			Mode = mode
		});
	}

	protected void ChangeLevel(int levelIndex)
	{
		_tokens.Add(new LevelIndex
		{
			Index = levelIndex
		});
	}

	protected void ChangeList(int listIndex)
	{
		_tokens.Add(new ListIndex
		{
			Index = (_listTable.GetListData(listIndex)?.ID ?? 0)
		});
	}

	protected void ChangeAdditionalLineSpacing(double spacing)
	{
		_tokens.Add(new AdditionalLineSpacing
		{
			Spacing = spacing
		});
	}

	protected void ChangeShadowBlurRadius(double radius)
	{
		_tokens.Add(new ShadowRadius
		{
			Radius = radius
		});
	}

	protected void ChangeShadowColor(Color color)
	{
		_tokens.Add(new ShadowColor
		{
			ColorIndex = _colorTable.GetIndex(color)
		});
	}

	protected void ChangeShadowOpacity(double opacity)
	{
		_tokens.Add(new ShadowOpacity
		{
			Opacity = opacity
		});
	}

	protected void ChangeShadowPosition(double x, double y)
	{
		_tokens.Add(new ShadowPosX
		{
			X = x
		});
		_tokens.Add(new ShadowPosY
		{
			Y = y
		});
	}

	protected void ChangeUnderline(BarType underline)
	{
		_tokens.Add(new Underline
		{
			UnderlineType = underline
		});
	}

	protected void StartUnderlineColor(Color color)
	{
		_tokens.Add(new UnderlineColor
		{
			ColorIndex = _colorTable.GetIndex(color)
		});
	}

	protected void EndUnderlineColor()
	{
		_tokens.Add(new UnderlineColor
		{
			ColorIndex = 0
		});
	}

	protected void StartHighlightColor(Color color)
	{
		_tokens.Add(new HighlightColor
		{
			ColorIndex = _colorTable.GetIndex(color)
		});
	}

	protected void StartBackgroundColor(Color color)
	{
		_tokens.Add(new BackgroundColor
		{
			ColorIndex = _colorTable.GetIndex(color)
		});
	}

	protected void EndHighlightColor()
	{
		_tokens.Add(new HighlightColor
		{
			ColorIndex = _colorTable.GetIndex(HighlightColor.DefaultColor)
		});
	}

	protected void EndBackgroundColor()
	{
		_tokens.Add(new BackgroundColor
		{
			ColorIndex = _colorTable.GetIndex(BackgroundColor.DefaultColor)
		});
	}

	protected void EndBold()
	{
		_tokens.Add(new Bold
		{
			IsActive = false
		});
	}

	protected void EndItalic()
	{
		_tokens.Add(new Italic
		{
			IsActive = false
		});
	}

	protected void EndUnderline()
	{
		_tokens.Add(new Underline
		{
			UnderlineType = BarType.None
		});
	}

	protected void EndScript()
	{
		_tokens.Add(new ClearScript());
	}

	protected void EndShadow()
	{
		_tokens.Add(new Pro.Text.RTF.Tokens.Shadow
		{
			IsActive = false
		});
	}

	protected void EndStrikethrough()
	{
		_tokens.Add(new Strikethrough
		{
			IsActive = false
		});
	}

	protected void InsertPlainText(string text)
	{
		AddTextTokens(_tokens, text);
	}

	protected void InsertTabs(int tabCount)
	{
		for (int i = 0; i < tabCount; i++)
		{
			_tokens.Add(new TabCharacter());
		}
	}

	protected void ResetParagraphSettings()
	{
		_tokens.Add(new ParagraphReset());
	}

	protected void ResetRunSettings()
	{
		_tokens.Add(new RunReset());
	}

	protected void ResetList()
	{
		_tokens.Add(new ListIndex
		{
			Index = 0
		});
	}

	protected void SetPaperWidth(double width)
	{
		_tokens.Add(new PaperWidth
		{
			Width = width
		});
	}

	protected void SetLeftMargin(double margin)
	{
		_tokens.Add(new Margin
		{
			Edge = Margin.MarginEdge.Left,
			Value = margin
		});
	}

	protected void SetRightMargin(double margin)
	{
		_tokens.Add(new Margin
		{
			Edge = Margin.MarginEdge.Right,
			Value = margin
		});
	}

	protected void SetTopMargin(double margin)
	{
		_tokens.Add(new Margin
		{
			Edge = Margin.MarginEdge.Top,
			Value = margin
		});
	}

	protected void SetBottomMargin(double margin)
	{
		_tokens.Add(new Margin
		{
			Edge = Margin.MarginEdge.Bottom,
			Value = margin
		});
	}

	protected void SetLeftIndent(double indent)
	{
		_tokens.Add(new LeftIndent
		{
			Indentation = indent
		});
	}

	protected void SetFirstLineIndent(double indent)
	{
		_tokens.Add(new FirstLineIndent
		{
			Indentation = indent
		});
	}

	protected void SetRightIndent(double indent)
	{
		_tokens.Add(new RightIndent
		{
			Indentation = indent
		});
	}

	protected void SetFillColor(Color color)
	{
		_tokens.Add(new FillColor
		{
			ColorIndex = _colorTable.GetIndex(color)
		});
	}

	protected void SetStrikethroughColor(Color color)
	{
		_tokens.Add(new StrikethroughColor
		{
			ColorIndex = _colorTable.GetIndex(color)
		});
	}

	protected void SetStrokeColor(Color color)
	{
		_tokens.Add(new StrokeColor
		{
			ColorIndex = _colorTable.GetIndex(color)
		});
	}

	protected void SetStrokeThickness(double thickness)
	{
		_tokens.Add(new StrokeThickness
		{
			Thickness = thickness
		});
	}

	protected void SetListTextSettings(Color bulletColor, double bulletSize, string listText)
	{
		Pro.Text.RTF.Tokens.Group group = new Pro.Text.RTF.Tokens.Group();
		group.Tokens.Add(new ListText());
		group.Tokens.Add(new FillColor
		{
			ColorIndex = _colorTable.GetIndex(bulletColor)
		});
		group.Tokens.Add(new FontSize
		{
			CharacterSize = (int)Math.Round(bulletSize)
		});
		AddTextTokens(group.Tokens, listText);
		_tokens.Add(group);
	}

	protected void StartBold()
	{
		_tokens.Add(new Bold
		{
			IsActive = true
		});
	}

	protected void StartItalic()
	{
		_tokens.Add(new Italic
		{
			IsActive = true
		});
	}

	protected void StartUnderline()
	{
		_tokens.Add(new Underline
		{
			UnderlineType = BarType.Solid
		});
	}

	protected void StartParagraph()
	{
		if (!_isFirstParagraph)
		{
			_tokens.Add(new ParagraphBreak());
		}
		else
		{
			_isFirstParagraph = false;
		}
	}

	protected void StartShadow()
	{
		_tokens.Add(new Pro.Text.RTF.Tokens.Shadow
		{
			IsActive = true
		});
	}

	protected void StartStrikethrough()
	{
		_tokens.Add(new Strikethrough
		{
			IsActive = true
		});
	}

	protected void StartSubscript(int level)
	{
		_tokens.Add(new Subscript
		{
			Level = level
		});
	}

	protected void StartSuperscript(int level)
	{
		_tokens.Add(new Superscript
		{
			Level = level
		});
	}

	protected void SwitchFont(string name)
	{
		_tokens.Add(new Pro.Text.RTF.Tokens.Font
		{
			FontIndex = _fontTable.GetIndex(new FontData(null, null, name))
		});
	}

	private void AddTextTokens(List<IToken> tokenCollection, string text)
	{
		int start = -1;
		for (int i = 0; i < text.Length; i++)
		{
			char c = text[i];
			if (c > '\u007f')
			{
				finishRun(i - 1);
				tokenCollection.Add(new UnicodeCharacter
				{
					Character = c
				});
				tokenCollection.Add(new PlainText("?"));
			}
			else if (start < 0)
			{
				start = i;
			}
		}
		finishRun(text.Length - 1);
		void finishRun(int end)
		{
			if (start >= 0)
			{
				tokenCollection.Add(new PlainText(text.SubstringRange(start, end)));
				start = -1;
			}
		}
	}
}
