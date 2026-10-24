using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Text.RTF;
using Pro.Text.Runs;

namespace Pro.Text;

public class TextDocumentReader : DocumentReader
{
	private const string DefaultPlaceholderText = "Double-click to edit";

	private TextDocument? _document;

	private Paragraph? _paragraph;

	private double? _bulletSize;

	private double? _fontSize;

	private RunBase? _run;

	private bool _isRunUsed;

	private RunSettings? _runSettings;

	private readonly Stack<RunSettings> _runSettingsStack = new Stack<RunSettings>();

	private FontInfo _font;

	public TextDocument ReadDocument(string rtfData)
	{
		_document = new TextDocument();
		_paragraph = _document.First();
		_run = _paragraph.First();
		_isRunUsed = false;
		_runSettings = _run.Settings;
		_runSettingsStack.Clear();
		_font = RunSettings.DefaultFont;
		if (string.IsNullOrEmpty(rtfData))
		{
			return _document;
		}
		ParseData(TokenReader.Parse(rtfData));
		_document.CompactRuns();
		return _document;
	}

	protected override int AddList()
	{
		if ((object)_document != null)
		{
			_document.ListSettingsCollection.AddList(ListPreset.None, out var settingsIndex);
			return settingsIndex;
		}
		throw new InvalidOperationException();
	}

	protected override void AddLevel(int listIndex, FollowType follow, NumberingScheme numberingScheme, string numberingFormat, bool isBullet, int startNumber)
	{
		if ((object)_document == null)
		{
			throw new InvalidOperationException();
		}
		LevelSettings levelSettings = _document.ListSettingsCollection[listIndex].Levels.AddLevel();
		if ((object)levelSettings != null)
		{
			levelSettings.Follow = follow;
			levelSettings.IsBullet = isBullet;
			levelSettings.StartNumber = startNumber;
			levelSettings.NumberingScheme = numberingScheme;
			levelSettings.NumberingFormat = numberingFormat;
		}
	}

	protected override void ChangePaperWidth(double width)
	{
		if (_document != null && _document.Settings != null)
		{
			_document.Settings.LayoutWidth = width;
			return;
		}
		throw new InvalidOperationException();
	}

	protected override void ChangeLeftMargin(double margin)
	{
		if (_document != null && _document.Settings != null)
		{
			_document.Settings.Margins.Left = margin;
		}
	}

	protected override void ChangeRightMargin(double margin)
	{
		if (_document != null && _document.Settings != null)
		{
			_document.Settings.Margins.Right = margin;
		}
	}

	protected override void ChangeTopMargin(double margin)
	{
		if (_document != null && _document.Settings != null)
		{
			_document.Settings.Margins.Top = margin;
		}
	}

	protected override void ChangeBottomMargin(double margin)
	{
		if (_document != null && _document.Settings != null)
		{
			_document.Settings.Margins.Bottom = margin;
		}
	}

	protected override void AddTabStop(double position, TabStopType type = TabStopType.Left)
	{
		_paragraph?.Settings?.TabStops.AddStop(position, type);
	}

	protected override void StartParagraph()
	{
		ResetBulletScalarParameters();
		_paragraph = _document?.AddParagraph(_paragraph?.Settings, _run?.Settings);
		_run = _paragraph?.First();
		_isRunUsed = false;
	}

	protected override void EndParagraph()
	{
		if (!_isRunUsed)
		{
			InsertPlainText(string.Empty);
		}
	}

	protected override void ResetList()
	{
		if (_paragraph?.Settings != null)
		{
			_paragraph.Settings.ListIndex = -1;
		}
	}

	protected override void ResetParagraphSettings()
	{
		_paragraph?.AssignSettings(Constants.DefaultParagraphSettings);
	}

	protected override void ResetRunSettings()
	{
		_run?.AssignSettings(Constants.DefaultRunSettings);
	}

	protected override void PopSettings()
	{
		if (!_runSettingsStack.Empty())
		{
			_runSettings = _runSettingsStack.Pop();
			_font = _runSettings.Font;
		}
	}

	protected override void PushSettings()
	{
		if (_runSettings != null)
		{
			_runSettings.Font = _font;
			_runSettingsStack.Push(_runSettings.Clone());
		}
	}

	protected override void SwitchFont(string name)
	{
		_font.PSName = name;
		_font.SystemFamilyName = name;
	}

	protected override void ChangeFontSize(int fontSize)
	{
		if (_runSettings != null)
		{
			if (!_fontSize.HasValue)
			{
				_fontSize = fontSize;
				TryCalculateBulletScalar();
			}
			_runSettings.CharacterSize = fontSize;
		}
	}

	protected override void StartBold()
	{
		_font.Weight = FontWeights.Bold;
	}

	protected override void EndBold()
	{
		_font.Weight = FontWeights.Normal;
	}

	protected override void StartItalic()
	{
		_font.IsItalic = true;
	}

	protected override void EndItalic()
	{
		_font.IsItalic = false;
	}

	protected override void StartShadow()
	{
	}

	protected override void EndShadow()
	{
	}

	protected override void StartStrikethrough()
	{
		if (_runSettings != null)
		{
			_runSettings.Strikethrough = true;
		}
	}

	protected override void EndStrikethrough()
	{
		if (_runSettings != null)
		{
			_runSettings.Strikethrough = false;
		}
	}

	protected override void StartSuperscript(int level)
	{
		if (_runSettings != null)
		{
			_runSettings.ScriptLevel = level;
		}
	}

	protected override void StartSubscript(int level)
	{
		if (_runSettings != null)
		{
			_runSettings.ScriptLevel = -level;
		}
	}

	protected override void EndScript()
	{
		if (_runSettings != null)
		{
			_runSettings.ScriptLevel = 0;
		}
	}

	protected override void ChangeList(int listIndex)
	{
		if (_paragraph != null && _paragraph.Settings != null)
		{
			_paragraph.Settings.ListIndex = listIndex;
		}
	}

	protected override void ChangeLevel(int levelIndex)
	{
		if (_paragraph != null && _paragraph.Settings != null)
		{
			_paragraph.Settings.LevelIndex = levelIndex;
		}
	}

	protected override void ChangeShadowBlurRadius(double radius)
	{
	}

	protected override void ChangeShadowColor(Color color)
	{
	}

	protected override void ChangeShadowOpacity(double opacity)
	{
	}

	protected override void ChangeShadowPosition(double x, double y)
	{
	}

	protected override void ChangeUnderline(BarType underline)
	{
		if (_runSettings != null)
		{
			_runSettings.Underline = underline != BarType.None;
		}
	}

	protected override void StartUnderlineColor(Color color)
	{
		if (_runSettings != null)
		{
			_runSettings.UnderlineColor = color;
		}
	}

	protected override void EndUnderlineColor()
	{
		if (_runSettings != null)
		{
			_runSettings.UnderlineColor = null;
		}
	}

	protected override void StartHighlightColor(Color color)
	{
		if (_runSettings != null)
		{
			_runSettings.HighlightColor = color;
		}
	}

	protected override void EndHighlightColor()
	{
		if (_runSettings != null)
		{
			_runSettings.HighlightColor = null;
		}
	}

	protected override void StartBackgroundColor(Color color)
	{
		if (_runSettings != null)
		{
			_runSettings.HighlightColor = color;
		}
	}

	protected override void EndBackgroundColor()
	{
		if (_runSettings != null)
		{
			_runSettings.HighlightColor = null;
		}
	}

	protected override void ChangeAlignment(ParagraphAlignment alignment)
	{
		if (_paragraph?.Settings != null)
		{
			_paragraph.Settings.Alignment = alignment;
		}
	}

	protected override void ChangeParagraphSpacing(bool isBefore, double spacing)
	{
		if (_paragraph?.Settings != null)
		{
			if (isBefore)
			{
				_paragraph.Settings.BeforeParagraph = spacing;
			}
			else
			{
				_paragraph.Settings.AfterParagraph = spacing;
			}
		}
	}

	protected override void ChangeAdditionalLineSpacing(double spacing)
	{
		if (_paragraph?.Settings != null)
		{
			_paragraph.Settings.AdditionalLineSpacing = spacing;
		}
	}

	protected override void ChangeLineSpacing(LineSpacingMode spacingMode, double spacing)
	{
		if (_paragraph?.Settings != null)
		{
			_paragraph.Settings.SpacingMode = spacingMode;
			_paragraph.Settings.LineSpacing = spacing;
		}
	}

	protected override void ChangeCharacterSpacing(double spacing)
	{
		if (_runSettings != null)
		{
			_runSettings.CharacterSpacing = spacing;
		}
	}

	protected override void SetFillColor(Color color)
	{
		if (_runSettings != null)
		{
			_runSettings.Fill = new SolidTextFill(color);
		}
	}

	protected override void SetFirstLineIndent(double indent)
	{
		if (_paragraph?.Settings != null)
		{
			_paragraph.Settings.FirstLineIndent = indent;
		}
	}

	protected override void SetLeftIndent(double indent)
	{
		if (_paragraph?.Settings != null)
		{
			_paragraph.Settings.LeftIndent = indent;
		}
	}

	protected override void SetRightIndent(double indent)
	{
		if (_paragraph?.Settings != null)
		{
			_paragraph.Settings.RightIndent = indent;
		}
	}

	protected override void SetStrikethroughColor(Color color)
	{
	}

	protected override void SetStrokeColor(Color color)
	{
		if (_runSettings != null)
		{
			_runSettings.StrokeColor = color;
		}
	}

	protected override void SetStrokeThickness(double thickness)
	{
		if (_runSettings != null)
		{
			_runSettings.StrokeThickness = thickness;
		}
	}

	protected override void SetBulletColor(Color color)
	{
		if (_paragraph?.Settings != null)
		{
			_paragraph.Settings.BulletColor = color;
		}
	}

	protected override void SetBulletSize(int fontSize)
	{
		_bulletSize = fontSize;
		TryCalculateBulletScalar();
	}

	protected override void InsertPlainText(string text)
	{
		if ((object)_runSettings == null)
		{
			return;
		}
		_runSettings.Font = _font;
		text = (text.Equals("Double-click to edit") ? string.Empty : text);
		if (!_isRunUsed)
		{
			RunBase? run = _run;
			if ((object)run != null && run.RunType == RunType.Text)
			{
				_run.AssignSettings(_runSettings);
				((TextRun)_run).Text = text;
				_isRunUsed = true;
				return;
			}
		}
		_run = new TextRun(text, _runSettings.Clone());
		_paragraph?.AddRun(_run);
	}

	protected override void InsertTab()
	{
		if ((object)_runSettings != null)
		{
			_paragraph?.AddRun(new TabRun(1, _runSettings.Clone()));
			_isRunUsed = true;
		}
	}

	protected override void EnableLigatures(bool value)
	{
		if (_runSettings != null)
		{
			_runSettings.LigaturesEnabled = value;
		}
	}

	private void TryCalculateBulletScalar()
	{
		if (_bulletSize.HasValue && _fontSize.HasValue)
		{
			if (_paragraph?.Settings != null)
			{
				_paragraph.Settings.BulletScalar = _bulletSize.Value / _fontSize.Value;
			}
			ResetBulletScalarParameters();
		}
	}

	private void ResetBulletScalarParameters()
	{
		_bulletSize = null;
		_fontSize = null;
	}
}
