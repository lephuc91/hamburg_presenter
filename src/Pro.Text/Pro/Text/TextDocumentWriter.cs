using Pro.Common.Collections;
using Pro.Text.RTF;
using Pro.Text.Runs;

namespace Pro.Text;

public class TextDocumentWriter : DocumentWriter
{
	public string WriteDocument(TextDocument document)
	{
		PrepareWrite();
		for (int i = 0; i < document.ListSettingsCollection.Count; i++)
		{
			AddList(i);
			ListSettings listSettings = document.ListSettingsCollection[i];
			for (int j = 0; j < listSettings.Levels.Count; j++)
			{
				LevelSettings levelSettings = listSettings.Levels[j];
				AddLevel(i, levelSettings.Follow, levelSettings.NumberingScheme, levelSettings.NumberingFormat, levelSettings.IsBullet, levelSettings.StartNumber);
			}
		}
		SetPaperWidth(document.Settings.LayoutWidth);
		SetLeftMargin(document.Settings.Margins.Left);
		SetRightMargin(document.Settings.Margins.Right);
		SetTopMargin(document.Settings.Margins.Top);
		SetBottomMargin(document.Settings.Margins.Bottom);
		foreach (Paragraph item in document)
		{
			StartParagraph();
			ResetParagraphSettings();
			ParagraphSettings settings = item.Settings;
			RunSettings runSettings = Constants.DefaultRunSettings;
			bool flag = true;
			settings.TabStops.ForEach(delegate(TabStop s)
			{
				AddTabStop(s.Position, s.Type);
			});
			if (settings.IsPartOfList)
			{
				ChangeList(settings.ListIndex);
				ChangeLevel(settings.LevelIndex);
				LevelSettings levelSettings2 = ((settings.ListIndex < document.ListSettingsCollection.Count) ? document.ListSettingsCollection[settings.ListIndex].Levels.GetLevelSettings(settings.LevelIndex) : new LevelSettings
				{
					LevelIndex = settings.LevelIndex
				});
				SetListTextSettings(settings.BulletColor ?? item[0].Settings.Fill.PrimaryColor, settings.BulletScalar * (double)item[0].Settings.CharacterSize, levelSettings2.GetFlatText(document.IndexOf(item)));
			}
			SetLeftIndent(settings.LeftIndent);
			SetFirstLineIndent(settings.FirstLineIndent);
			SetRightIndent(settings.RightIndent);
			ChangeAlignment(settings.Alignment);
			ChangeParagraphSpacing(isBefore: true, settings.BeforeParagraph);
			ChangeParagraphSpacing(isBefore: false, settings.AfterParagraph);
			ChangeLineSpacing(settings.SpacingMode, settings.LineSpacing);
			ChangeAdditionalLineSpacing(settings.AdditionalLineSpacing);
			foreach (RunBase item2 in item)
			{
				RunSettings settings2 = item2.Settings;
				if (flag || settings2.Font != runSettings.Font)
				{
					if (!string.IsNullOrWhiteSpace(settings2.Font.PSName))
					{
						SwitchFont(settings2.Font.PSName);
					}
					else if (!string.IsNullOrWhiteSpace(settings2.Font.FullName))
					{
						SwitchFont(settings2.Font.FullName);
					}
					else
					{
						SwitchFont(settings2.Font.SystemFamilyName + " " + settings2.Font.SystemFaceName);
					}
				}
				if (flag || settings2.Font.IsBold != runSettings.Font.IsBold)
				{
					if (settings2.Font.IsBold)
					{
						StartBold();
					}
					else
					{
						EndBold();
					}
				}
				if (flag || settings2.Font.IsItalic != runSettings.Font.IsItalic)
				{
					if (settings2.Font.IsItalic)
					{
						StartItalic();
					}
					else
					{
						EndItalic();
					}
				}
				if (flag || settings2.Underline != runSettings.Underline)
				{
					if (settings2.Underline)
					{
						StartUnderline();
					}
					else
					{
						EndUnderline();
					}
				}
				if (flag || settings2.Strikethrough != runSettings.Strikethrough)
				{
					if (settings2.Strikethrough)
					{
						StartStrikethrough();
					}
					else
					{
						EndStrikethrough();
					}
				}
				if (flag || settings2.CharacterSize != runSettings.CharacterSize)
				{
					ChangeFontSize(settings2.CharacterSize);
				}
				if (flag || settings2.CharacterSpacing != runSettings.CharacterSpacing)
				{
					ChangeCharacterSpacing(settings2.CharacterSpacing);
				}
				if (flag || settings2.LigaturesEnabled != runSettings.LigaturesEnabled)
				{
					SetLigaturesEnabled(settings2.LigaturesEnabled);
				}
				if (flag || settings2.Fill != runSettings.Fill)
				{
					SetFillColor(settings2.Fill.PrimaryColor);
				}
				if (flag || settings2.StrokeThickness != runSettings.StrokeThickness)
				{
					SetStrokeThickness(settings2.StrokeThickness);
				}
				if (flag || settings2.StrokeColor != runSettings.StrokeColor)
				{
					SetStrokeColor(settings2.StrokeColor);
				}
				if (flag || settings2.ScriptLevel != runSettings.ScriptLevel)
				{
					int scriptLevel = settings2.ScriptLevel;
					if (scriptLevel > 0)
					{
						StartSuperscript(scriptLevel);
					}
					else if (scriptLevel < 0)
					{
						StartSubscript(-scriptLevel);
					}
					else
					{
						EndScript();
					}
				}
				if (flag || settings2.UnderlineColor != runSettings.UnderlineColor)
				{
					if (settings2.UnderlineColor.HasValue)
					{
						StartUnderlineColor(settings2.UnderlineColor.Value);
					}
					else
					{
						EndUnderlineColor();
					}
				}
				if (flag || settings2.HighlightColor != runSettings.HighlightColor)
				{
					if (settings2.HighlightColor.HasValue)
					{
						StartHighlightColor(settings2.HighlightColor.Value);
						StartBackgroundColor(settings2.HighlightColor.Value);
					}
					else
					{
						EndHighlightColor();
						EndBackgroundColor();
					}
				}
				switch (item2.RunType)
				{
				case RunType.Text:
					InsertPlainText(((TextRun)item2).Text);
					break;
				case RunType.Tab:
					InsertTabs(((TabRun)item2).TabCount);
					break;
				}
				runSettings = settings2;
				flag = false;
			}
		}
		return CompleteWrite();
	}
}
