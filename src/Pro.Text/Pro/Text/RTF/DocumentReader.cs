using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Text.RTF.Tokens;

namespace Pro.Text.RTF;

public abstract class DocumentReader
{
	private static readonly Encoding DefaultEncoding = 0.GetEncoding();

	private readonly FontTable _fontTable = new FontTable();

	private readonly ColorTable _colorTable = new ColorTable();

	private readonly Dictionary<int, int> _listTableLookup = new Dictionary<int, int>();

	private readonly Dictionary<int, int> _listOverrideTableLookup = new Dictionary<int, int>();

	private readonly TypefaceLibrary _typefaceLibrary = SharedTypefaceLibrary.Library;

	protected virtual int AddList()
	{
		return -1;
	}

	protected virtual void AddLevel(int listIndex, FollowType follow, NumberingScheme numberingScheme, string numberingFormat, bool isBullet, int startNumber)
	{
	}

	protected virtual void AddTabStop(double position, TabStopType type = TabStopType.Left)
	{
	}

	protected virtual void ChangeAdditionalLineSpacing(double spacing)
	{
	}

	protected virtual void ChangeAlignment(ParagraphAlignment alignment)
	{
	}

	protected virtual void ChangeCharacterSpacing(double spacing)
	{
	}

	protected virtual void ChangeFontSize(int fontSize)
	{
	}

	protected virtual void ChangeLevel(int levelIndex)
	{
	}

	protected virtual void ChangeLineSpacing(LineSpacingMode spacingMode, double spacing)
	{
	}

	protected virtual void ChangeList(int listIndex)
	{
	}

	protected virtual void ChangePaperWidth(double width)
	{
	}

	protected virtual void ChangeLeftMargin(double margin)
	{
	}

	protected virtual void ChangeRightMargin(double margin)
	{
	}

	protected virtual void ChangeTopMargin(double margin)
	{
	}

	protected virtual void ChangeBottomMargin(double margin)
	{
	}

	protected virtual void ChangeParagraphSpacing(bool isBefore, double spacing)
	{
	}

	protected virtual void ChangeShadowBlurRadius(double radius)
	{
	}

	protected virtual void ChangeShadowColor(Color color)
	{
	}

	protected virtual void ChangeShadowOpacity(double opacity)
	{
	}

	protected virtual void ChangeShadowPosition(double x, double y)
	{
	}

	protected virtual void ChangeUnderline(BarType underline)
	{
	}

	protected virtual void StartUnderlineColor(Color color)
	{
	}

	protected virtual void EndUnderlineColor()
	{
	}

	protected virtual void StartHighlightColor(Color color)
	{
	}

	protected virtual void StartBackgroundColor(Color color)
	{
	}

	protected virtual void EndHighlightColor()
	{
	}

	protected virtual void EndBackgroundColor()
	{
	}

	protected virtual void EndBold()
	{
	}

	protected virtual void EndItalic()
	{
	}

	protected virtual void EndParagraph()
	{
	}

	protected virtual void EndScript()
	{
	}

	protected virtual void EndShadow()
	{
	}

	protected virtual void EndStrikethrough()
	{
	}

	protected virtual void InsertPlainText(string text)
	{
	}

	protected virtual void InsertTab()
	{
	}

	protected virtual void PopSettings()
	{
	}

	protected virtual void PushSettings()
	{
	}

	protected virtual void ResetList()
	{
	}

	protected virtual void ResetParagraphSettings()
	{
	}

	protected virtual void ResetRunSettings()
	{
	}

	protected virtual void SetFirstLineIndent(double indent)
	{
	}

	protected virtual void SetFillColor(Color color)
	{
	}

	protected virtual void SetLeftIndent(double indent)
	{
	}

	protected virtual void SetRightIndent(double indent)
	{
	}

	protected virtual void SetStrikethroughColor(Color color)
	{
	}

	protected virtual void SetStrokeColor(Color color)
	{
	}

	protected virtual void SetStrokeThickness(double thickness)
	{
	}

	protected virtual void SetBulletColor(Color color)
	{
	}

	protected virtual void SetBulletSize(int fontSize)
	{
	}

	protected virtual void StartBold()
	{
	}

	protected virtual void StartItalic()
	{
	}

	protected virtual void StartParagraph()
	{
	}

	protected virtual void StartShadow()
	{
	}

	protected virtual void StartStrikethrough()
	{
	}

	protected virtual void StartSubscript(int level)
	{
	}

	protected virtual void StartSuperscript(int level)
	{
	}

	protected virtual void SwitchFont(string name)
	{
	}

	protected virtual void EnableLigatures(bool value)
	{
	}

	private bool TryFindAndSwitchFont(string fontName)
	{
		if ((object)_typefaceLibrary.AvailableTypefaces.AllFonts.FirstOrDefault((Font f) => f.Info.PSName != null && f.Info.PSName.Equals(fontName, StringComparison.OrdinalIgnoreCase)) == null)
		{
			return false;
		}
		SwitchFont(fontName);
		return true;
	}

	protected void ParseData(Group rootGroup)
	{
		_fontTable.Clear();
		_colorTable.Clear();
		Group group = rootGroup.Tokens.FirstOrDefaultOf((Group g) => g.GroupType == TokenType.FontTable);
		Group group2 = rootGroup.Tokens.FirstOrDefaultOf((Group g) => g.GroupType == TokenType.ColorTable);
		Group group3 = rootGroup.Tokens.FirstOrDefaultOf((Group g) => g.GroupType == TokenType.ExpandedColorTable);
		Group group4 = rootGroup.Tokens.FirstOrDefaultOf((Group g) => g.GroupType == TokenType.ListTable);
		Group group5 = rootGroup.Tokens.FirstOrDefaultOf((Group g) => g.GroupType == TokenType.ListOverrideTable);
		Group group6 = rootGroup.Tokens.FirstOrDefaultOf((Group g) => g.GroupType == TokenType.StyleSheet);
		if (group == null)
		{
			throw new InvalidOperationException("Failed to locate the font table");
		}
		CodePage codePage = rootGroup.Tokens.FirstOrDefaultOf((CodePage c) => c.IsGlobal);
		Encoding encoding = ((codePage != null) ? codePage.GetEncoding() : DefaultEncoding);
		bool macRTF = rootGroup.Tokens.FirstOrDefaultOf((MacRTF t) => t.TokenType == TokenType.MacRTF) != null;
		ParseFontTable(group, encoding);
		if (group2 != null)
		{
			ParseColorTable(group2);
		}
		_colorTable.ResetLoadIndex();
		if (group3 != null)
		{
			ParseExpandedColorTable(group3);
		}
		if (group4 != null && group5 != null)
		{
			ParseListTable(group4, group5, macRTF);
		}
		string name = _fontTable.GetFontData(0).Name;
		TryFindAndSwitchFont(name);
		ParseGroup(rootGroup, encoding, new Group[6] { group, group2, group3, group4, group5, group6 }, macRTF);
	}

	private void ParseGroup(Group rootGroup, Encoding encoding, IEnumerable<Group?>? ignoredGroups, bool macRTF, int placeholderCount = 1)
	{
		bool flag = false;
		bool flag2 = false;
		List<byte> encodedCharacters = new List<byte>();
		int num = 0;
		for (int i = 0; i < rootGroup.Tokens.Count; i++)
		{
			if (flag)
			{
				flag = false;
				continue;
			}
			if (i >= 1)
			{
				_ = rootGroup.Tokens[i - 1];
			}
			IToken token = ((i < rootGroup.Tokens.Count - 1) ? rootGroup.Tokens[i + 1] : null);
			IToken token2 = rootGroup.Tokens[i];
			if (token2.TokenType != TokenType.HexCharacter)
			{
				parseEncodedCharacters();
				num = 0;
			}
			else if (num > 0)
			{
				num--;
				continue;
			}
			switch (token2.TokenType)
			{
			case TokenType.Group:
			{
				Group group = (Group)token2;
				if (macRTF && (group.GroupType == TokenType.TabCharacter || group.GroupType == TokenType.ListText))
				{
					group.Tokens.RemoveAll((IToken x) => x is TabCharacter);
				}
				if (group.GroupType == TokenType.ListText)
				{
					ParseListText(group);
				}
				else if (ignoredGroups == null || !ignoredGroups.Contains<Group>(group))
				{
					PushSettings();
					ParseGroup(group, encoding, null, macRTF, placeholderCount);
					PopSettings();
				}
				break;
			}
			case TokenType.AdditionalLineSpacing:
				ChangeAdditionalLineSpacing(((AdditionalLineSpacing)token2).Spacing);
				break;
			case TokenType.PlainText:
				InsertPlainText(((PlainText)token2).Text);
				break;
			case TokenType.TabCharacter:
				InsertTab();
				break;
			case TokenType.GroupDelimiter:
				InsertPlainText(";");
				break;
			case TokenType.LeftQuote:
				InsertPlainText("‘");
				break;
			case TokenType.RightQuote:
				InsertPlainText("’");
				break;
			case TokenType.Alignment:
				ChangeAlignment(((Alignment)token2).ParagraphAlignment);
				break;
			case TokenType.Bold:
				if (((Bold)token2).IsActive)
				{
					StartBold();
				}
				else
				{
					EndBold();
				}
				break;
			case TokenType.ClearScript:
				EndScript();
				break;
			case TokenType.CharacterSpacing:
				ChangeCharacterSpacing(((CharacterSpacing)token2).Spacing);
				break;
			case TokenType.FillColor:
				SetFillColor(_colorTable.GetColor(((FillColor)token2).ColorIndex));
				break;
			case TokenType.FirstLineIndent:
				SetFirstLineIndent(((FirstLineIndent)token2).Indentation);
				break;
			case TokenType.FontIndex:
			{
				FontData fontData = _fontTable.GetFontData(((Pro.Text.RTF.Tokens.Font)token2).FontIndex);
				TryFindAndSwitchFont(fontData.Name);
				if (fontData.CodePage.HasValue)
				{
					encoding = Encoding.GetEncoding(fontData.CodePage.Value);
				}
				else if (fontData.CharacterSet.HasValue)
				{
					encoding = fontData.CharacterSet.Value.GetEncoding();
				}
				break;
			}
			case TokenType.FontSize:
				ChangeFontSize(((FontSize)token2).CharacterSize);
				break;
			case TokenType.HexCharacter:
				encodedCharacters.Add(((HexCharacter)token2).EncodedCharacter);
				break;
			case TokenType.Italic:
				if (((Italic)token2).IsActive)
				{
					StartItalic();
				}
				else
				{
					EndItalic();
				}
				break;
			case TokenType.LeftIndent:
				SetLeftIndent(((LeftIndent)token2).Indentation);
				break;
			case TokenType.LevelIndex:
				ChangeLevel(((LevelIndex)token2).Index);
				break;
			case TokenType.LineSpacing:
			{
				double spacing = ((LineSpacing)token2).Spacing;
				Pro.Text.RTF.Tokens.LineSpacingMode.SpacingMode spacingMode = Pro.Text.RTF.Tokens.LineSpacingMode.SpacingMode.Absolute;
				if (token != null && token.TokenType == TokenType.LineSpacingMode)
				{
					spacingMode = ((Pro.Text.RTF.Tokens.LineSpacingMode)token).Mode;
					flag = true;
				}
				if (spacingMode == Pro.Text.RTF.Tokens.LineSpacingMode.SpacingMode.Absolute)
				{
					ChangeLineSpacing((!(spacing < 0.0)) ? LineSpacingMode.Relative : LineSpacingMode.Absolute, spacing);
				}
				else
				{
					ChangeLineSpacing(LineSpacingMode.Multiple, spacing / 12.0);
				}
				break;
			}
			case TokenType.ListIndex:
			{
				int index = ((ListIndex)token2).Index;
				if (index > 0)
				{
					ChangeList(_listOverrideTableLookup[index]);
				}
				else
				{
					ResetList();
				}
				break;
			}
			case TokenType.PaperWidth:
				ChangePaperWidth(((PaperWidth)token2).Width);
				break;
			case TokenType.Margin:
			{
				Margin margin = (Margin)token2;
				switch (margin.Edge)
				{
				case Margin.MarginEdge.Left:
					ChangeLeftMargin(margin.Value);
					break;
				case Margin.MarginEdge.Right:
					ChangeRightMargin(margin.Value);
					break;
				case Margin.MarginEdge.Top:
					ChangeTopMargin(margin.Value);
					break;
				case Margin.MarginEdge.Bottom:
					ChangeBottomMargin(margin.Value);
					break;
				}
				break;
			}
			case TokenType.ParagraphBreak:
				if (flag2)
				{
					EndParagraph();
				}
				StartParagraph();
				flag2 = true;
				break;
			case TokenType.ParagraphReset:
				ResetParagraphSettings();
				break;
			case TokenType.ParagraphSpacing:
			{
				ParagraphSpacing paragraphSpacing = (ParagraphSpacing)token2;
				ChangeParagraphSpacing(paragraphSpacing.IsBefore, paragraphSpacing.Spacing);
				break;
			}
			case TokenType.RightIndent:
				SetRightIndent(((RightIndent)token2).Indentation);
				break;
			case TokenType.RunReset:
				ResetRunSettings();
				break;
			case TokenType.Shadow:
				if (((Pro.Text.RTF.Tokens.Shadow)token2).IsActive)
				{
					StartShadow();
				}
				else
				{
					EndShadow();
				}
				break;
			case TokenType.ShadowColor:
				ChangeShadowColor(_colorTable.GetColor(((ShadowColor)token2).ColorIndex));
				break;
			case TokenType.ShadowOpacity:
				ChangeShadowOpacity(((ShadowOpacity)token2).Opacity);
				break;
			case TokenType.ShadowPosX:
				if (token != null && token.TokenType == TokenType.ShadowPosY)
				{
					flag = true;
					ChangeShadowPosition(((ShadowPosX)token2).X, ((ShadowPosY)token).Y);
				}
				break;
			case TokenType.ShadowPosY:
				if (token != null && token.TokenType == TokenType.ShadowPosX)
				{
					flag = true;
					ChangeShadowPosition(((ShadowPosX)token).X, ((ShadowPosY)token2).Y);
				}
				break;
			case TokenType.ShadowRadius:
				ChangeShadowBlurRadius(((ShadowRadius)token2).Radius);
				break;
			case TokenType.Strikethrough:
				if (((Strikethrough)token2).IsActive)
				{
					StartStrikethrough();
				}
				else
				{
					EndStrikethrough();
				}
				break;
			case TokenType.StrikethroughColor:
				SetStrikethroughColor(_colorTable.GetColor(((StrikethroughColor)token2).ColorIndex));
				break;
			case TokenType.StrokeColor:
				SetStrokeColor(_colorTable.GetColor(((StrokeColor)token2).ColorIndex));
				break;
			case TokenType.StrokeThickness:
				SetStrokeThickness(((StrokeThickness)token2).Thickness.Abs());
				break;
			case TokenType.Subscript:
				StartSubscript(((Subscript)token2).Level);
				break;
			case TokenType.Superscript:
				StartSuperscript(((Superscript)token2).Level);
				break;
			case TokenType.TabStop:
				AddTabStop(((Pro.Text.RTF.Tokens.TabStop)token2).Position);
				break;
			case TokenType.TabStopCenter:
			case TokenType.TabStopRight:
			case TokenType.TabStopDecimal:
				if (token is Pro.Text.RTF.Tokens.TabStop { Position: var position })
				{
					AddTabStop(position, token2.TokenType switch
					{
						TokenType.TabStopCenter => TabStopType.Center, 
						TokenType.TabStopRight => TabStopType.Right, 
						TokenType.TabStopDecimal => TabStopType.Decimal, 
						_ => TabStopType.Left, 
					});
					flag = true;
				}
				break;
			case TokenType.Underline:
				ChangeUnderline(((Underline)token2).UnderlineType);
				break;
			case TokenType.UnderlineColor:
			{
				int colorIndex3 = ((UnderlineColor)token2).ColorIndex;
				Color color3 = _colorTable.GetColor(colorIndex3);
				if (colorIndex3 > 0 && color3 != UnderlineColor.DefaultColor)
				{
					StartUnderlineColor(color3);
				}
				else
				{
					EndUnderlineColor();
				}
				break;
			}
			case TokenType.HighlightColor:
			{
				int colorIndex2 = ((HighlightColor)token2).ColorIndex;
				Color color2 = _colorTable.GetColor(colorIndex2);
				if (colorIndex2 > 0 && color2 != HighlightColor.DefaultColor)
				{
					StartHighlightColor(color2);
				}
				else
				{
					EndHighlightColor();
				}
				break;
			}
			case TokenType.BackgroundColor:
			{
				int colorIndex = ((BackgroundColor)token2).ColorIndex;
				Color color = _colorTable.GetColor(colorIndex);
				if (colorIndex > 0 && color != BackgroundColor.DefaultColor)
				{
					StartBackgroundColor(color);
				}
				else
				{
					EndBackgroundColor();
				}
				break;
			}
			case TokenType.UnicodeCharacter:
				InsertPlainText(((UnicodeCharacter)token2).Character.ToString());
				if (placeholderCount <= 0)
				{
					break;
				}
				if (token != null && token.TokenType == TokenType.PlainText)
				{
					string text = ((PlainText)token).Text.Substring(placeholderCount);
					if (!string.IsNullOrEmpty(text))
					{
						InsertPlainText(text);
					}
					flag = true;
				}
				else if (token != null && token.TokenType == TokenType.HexCharacter)
				{
					num = placeholderCount;
				}
				break;
			case TokenType.UnicodeCharacterPlaceholder:
				placeholderCount = ((UnicodeCharacterPlaceholder)token2).CharacterCount;
				break;
			case TokenType.EmDash:
				InsertPlainText("—");
				break;
			case TokenType.NonBreakingSpace:
				InsertPlainText(" ");
				break;
			case TokenType.Ligatures:
				EnableLigatures(((Ligatures)token2).IsActive);
				break;
			}
		}
		parseEncodedCharacters();
		EndParagraph();
		void parseEncodedCharacters()
		{
			if (encodedCharacters.Any())
			{
				InsertPlainText(encoding.GetString(encodedCharacters.ToArray()));
				encodedCharacters.Clear();
			}
		}
	}

	private void ParseFontTable(Group fontGroup, Encoding encoding, int placeholderCount = 1)
	{
		FlattenGroup(fontGroup);
		foreach (IToken[] item in fontGroup.Tokens.Skip(1).Split((IToken t) => t.TokenType == TokenType.GroupDelimiter))
		{
			int num = -1;
			int? characterSet = null;
			int? codePage = null;
			string family = string.Empty;
			bool flag = false;
			List<byte> encodedCharacters = new List<byte>();
			IToken[] array = item;
			foreach (IToken token in array)
			{
				if (flag)
				{
					flag = false;
					continue;
				}
				IToken next = item.GetNext(token);
				if (token.TokenType != TokenType.HexCharacter)
				{
					parseEncodedCharacters();
				}
				switch (token.TokenType)
				{
				case TokenType.FontIndex:
					num = ((Pro.Text.RTF.Tokens.Font)token).FontIndex;
					break;
				case TokenType.FontCharacterSet:
					characterSet = ((FontCharacterSet)token).CharacterSet;
					break;
				case TokenType.CodePage:
					codePage = ((CodePage)token).Page;
					break;
				case TokenType.PlainText:
					family += ((PlainText)token).Text.Trim();
					break;
				case TokenType.HexCharacter:
					encodedCharacters.Add(((HexCharacter)token).EncodedCharacter);
					break;
				case TokenType.UnicodeCharacter:
					family += ((UnicodeCharacter)token).Character;
					if (placeholderCount > 0 && next is PlainText plainText)
					{
						family += plainText.Text.Substring(placeholderCount);
					}
					break;
				case TokenType.UnicodeCharacterPlaceholder:
					placeholderCount = ((UnicodeCharacterPlaceholder)token).CharacterCount;
					break;
				}
			}
			parseEncodedCharacters();
			if (num >= 0 && !string.IsNullOrEmpty(family))
			{
				_fontTable.LoadFont(characterSet, codePage, family, num);
			}
			void parseEncodedCharacters()
			{
				if (!encodedCharacters.Empty())
				{
					family += encoding.GetString(encodedCharacters.ToArray());
					encodedCharacters.Clear();
				}
			}
		}
	}

	private void ParseColorTable(Group colorGroup)
	{
		foreach (IToken[] item in colorGroup.Tokens.Skip(1).Split((IToken t) => t.TokenType == TokenType.GroupDelimiter))
		{
			byte r = ColorTable.DefaultColor.R;
			byte g = ColorTable.DefaultColor.G;
			byte b = ColorTable.DefaultColor.B;
			foreach (ColorComponent item2 in item.OfType<ColorComponent>())
			{
				switch (item2.Component)
				{
				case ColorComponent.ComponentType.Red:
					r = item2.Value;
					break;
				case ColorComponent.ComponentType.Green:
					g = item2.Value;
					break;
				case ColorComponent.ComponentType.Blue:
					b = item2.Value;
					break;
				}
			}
			_colorTable.LoadRGBAColor(r, g, b, ColorTable.DefaultColor.A);
		}
	}

	private void ParseExpandedColorTable(Group expandedColorGroup)
	{
		foreach (IToken[] item in expandedColorGroup.Tokens.Skip(2).Split((IToken t) => t.TokenType == TokenType.GroupDelimiter))
		{
			if (!item.Any())
			{
				_colorTable.LoadDefaultColor();
				continue;
			}
			double[] components = (from c in item.OfType<ExpandedColorComponent>()
				select c.Value).ToArray();
			switch (item[0].TokenType)
			{
			case TokenType.ColorSpaceGrayscale:
				_colorTable.LoadGrayscaleColor(getComponent(0), getComponent(1, isAlpha: true));
				break;
			case TokenType.ColorSpaceCMYK:
				_colorTable.LoadCMYKAColor(getComponent(0), getComponent(1), getComponent(2), getComponent(3), getComponent(4, isAlpha: true));
				break;
			case TokenType.ColorSpaceP3:
			case TokenType.ColorSpaceSRGB:
			case TokenType.ColorSpaceGenericRGB:
				_colorTable.LoadNormalizedRGBAColor(getComponent(0), getComponent(1), getComponent(2), getComponent(3, isAlpha: true));
				break;
			default:
				_colorTable.LoadDefaultColor();
				break;
			}
			double getComponent(int index, bool isAlpha = false)
			{
				if (index >= components.Length)
				{
					if (!isAlpha)
					{
						return 0.0;
					}
					return 1.0;
				}
				return components[index];
			}
		}
	}

	private void FlattenGroup(Group rootGroup)
	{
		foreach (Group item in rootGroup.Tokens.ToArray().OfType<Group>())
		{
			FlattenGroup(item);
			int index = rootGroup.Tokens.IndexOf(item);
			rootGroup.Tokens.RemoveAt(index);
			rootGroup.Tokens.InsertRange(index, item.Tokens);
		}
	}

	private void ParseListTable(Group listGroup, Group listOverrideGroup, bool macRTF)
	{
		foreach (Group item in from g in listGroup.Tokens.OfType<Group>()
			where g.GroupType == TokenType.List
			select g)
		{
			ParseListGroup(item, macRTF);
		}
		foreach (Group item2 in from g in listOverrideGroup.Tokens.OfType<Group>()
			where g.GroupType == TokenType.ListOverride
			select g)
		{
			ListID listID = item2.Tokens.FirstOrDefaultOf<ListID>();
			ListIndex listIndex = item2.Tokens.FirstOrDefaultOf<ListIndex>();
			if (listID != null && listIndex != null)
			{
				_listOverrideTableLookup.Add(listIndex.Index, _listTableLookup[listID.ID]);
			}
		}
	}

	private void ParseListGroup(Group listGroup, bool macRTF)
	{
		if (!listGroup.Tokens.AnyOf<ListHybrid>())
		{
			return;
		}
		int num = AddList();
		if (num < 0)
		{
			return;
		}
		foreach (Group item in from g in listGroup.Tokens.OfType<Group>()
			where g.GroupType == TokenType.ListLevel
			select g)
		{
			ParseLevelGroup(item, num, macRTF);
		}
		ListID listID = listGroup.Tokens.FirstOrDefaultOf<ListID>();
		if (listID != null)
		{
			_listTableLookup.Add(listID.ID, num);
		}
	}

	private void ParseLevelGroup(Group levelGroup, int listIndex, bool macRTF)
	{
		FollowType follow = FollowType.Tab;
		NumberingScheme numberingScheme = NumberingScheme.Arabic;
		string text = string.Empty;
		bool isBullet = false;
		int startNumber = 1;
		LevelFollow levelFollow = levelGroup.Tokens.FirstOrDefaultOf<LevelFollow>();
		LevelNumberType levelNumberType = levelGroup.Tokens.FirstOrDefaultOf<LevelNumberType>();
		LevelStartAt levelStartAt = levelGroup.Tokens.FirstOrDefaultOf<LevelStartAt>();
		Group group = levelGroup.Tokens.FirstOrDefaultOf((Group g) => g.GroupType == TokenType.LevelNumbers);
		Group group2 = levelGroup.Tokens.FirstOrDefaultOf((Group g) => g.GroupType == TokenType.LevelText);
		if (levelFollow != null)
		{
			follow = levelFollow.Follow;
		}
		if (levelNumberType != null)
		{
			numberingScheme = ParseNumberingType(levelNumberType.Numbering, out isBullet);
		}
		if (levelStartAt != null)
		{
			startNumber = levelStartAt.StartingNumber;
		}
		if (group != null && group2 != null)
		{
			List<int> list = new List<int>();
			list.AddRange(from h in @group.Tokens.OfType<HexCharacter>()
				select h.EncodedCharacter - 1);
			HexCharacter hexCharacter = group2.Tokens.FirstOf<HexCharacter>();
			string text2 = string.Empty;
			foreach (IToken item in group2.Tokens.Skip(group2.Tokens.IndexOf(hexCharacter) + 1))
			{
				switch (item.TokenType)
				{
				case TokenType.PlainText:
					text2 += ((PlainText)item).Text;
					break;
				case TokenType.HexCharacter:
					text2 += ((HexCharacter)item).EncodedCharacter;
					break;
				case TokenType.UnicodeCharacter:
					text2 += ((UnicodeCharacter)item).Character;
					break;
				}
			}
			text2 = text2.Substring(0, Math.Min(text2.Length, hexCharacter.EncodedCharacter));
			foreach (int item2 in list.OrderByDescending((int p) => p))
			{
				text2 = text2.Insert(item2 + 1, "}").Insert(item2, "{");
			}
			text = text2;
		}
		if (macRTF && text == "{0}")
		{
			isBullet = false;
		}
		AddLevel(listIndex, follow, numberingScheme, text, isBullet, startNumber);
	}

	private void ParseListText(Group group)
	{
		FillColor fillColor = group.Tokens.FirstOrDefaultOf<FillColor>();
		FontSize fontSize = group.Tokens.FirstOrDefaultOf<FontSize>();
		if (fillColor != null)
		{
			SetBulletColor(_colorTable.GetColor(fillColor.ColorIndex));
		}
		if (fontSize != null)
		{
			SetBulletSize(fontSize.CharacterSize);
		}
	}

	private NumberingScheme ParseNumberingType(LevelNumberType.NumberType numberType, out bool isBullet)
	{
		isBullet = false;
		switch (numberType)
		{
		case LevelNumberType.NumberType.Arabic:
			return NumberingScheme.Arabic;
		case LevelNumberType.NumberType.ArabicWithLeadingZero:
			return NumberingScheme.ArabicWithLeadingZero;
		case LevelNumberType.NumberType.OrdinalNumber:
			return NumberingScheme.OrdinalNumber;
		case LevelNumberType.NumberType.UppercaseRomanNumeral:
			return NumberingScheme.UppercaseRomanNumeral;
		case LevelNumberType.NumberType.LowercaseRomanNumeral:
			return NumberingScheme.LowercaseRomanNumeral;
		case LevelNumberType.NumberType.UppercaseLetter:
			return NumberingScheme.UppercaseLetter;
		case LevelNumberType.NumberType.LowercaseLetter:
			return NumberingScheme.LowercaseLetter;
		case LevelNumberType.NumberType.LowercaseRussianAlphabet:
			return NumberingScheme.LowercaseRussianAlphabet;
		case LevelNumberType.NumberType.UppercaseRussianAlphabet:
			return NumberingScheme.UppercaseRomanNumeral;
		case LevelNumberType.NumberType.LowercaseGreekNumerals:
			return NumberingScheme.LowercaseGreekNumerals;
		case LevelNumberType.NumberType.UppercaseGreekNumerals:
			return NumberingScheme.UppercaseGreekNumerals;
		case LevelNumberType.NumberType.Bullet:
			isBullet = true;
			return NumberingScheme.Arabic;
		default:
			return NumberingScheme.Arabic;
		}
	}
}
