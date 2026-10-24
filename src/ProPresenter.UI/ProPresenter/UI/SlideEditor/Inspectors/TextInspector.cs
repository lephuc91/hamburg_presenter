using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.DO.Analytics;
using Pro.Text;
using Pro.Text.Reversibility;
using Pro.UI.Components;
using Pro.UI.Controls;
using Pro.UI.DependencyInjection;
using Pro.UI.Utility;
using ProPresenter.DO;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Media;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.UI.Commands;
using ProPresenter.UI.SlideEditor.Inspectors.Links;
using ProPresenter.UI.ViewModels.Editor;
using Xceed.Wpf.Toolkit.Primitives;

namespace ProPresenter.UI.SlideEditor.Inspectors;

public partial class TextInspector : UserControl, IComponentConnector, IStyleConnector
{
	private const double DefaultLeftIndent = 1.0;

	private const double DefaultFirstLineIndent = 25.0;

	private const double DefaultListTabStop = 119.0;

	private readonly IApp _app;

	private Pro.Text.Reversibility.UndoActionTypes? _overrideFontUndoActionType = Pro.Text.Reversibility.UndoActionTypes.Font;

	public static readonly DependencyProperty DocumentProperty = DependencyProperty.Register("Document", typeof(TextDocument), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnDocumentPropertyChanged)));

	public static readonly DependencyProperty ChordsEnabledProperty = DependencyProperty.Register("ChordsEnabled", typeof(bool), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnChordsEnabledChanged)));

	public static readonly DependencyProperty ChordColorProperty = DependencyProperty.Register("ChordColor", typeof(Color), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnChordColorChanged)));

	public static readonly DependencyProperty ChordNotationProperty = DependencyProperty.Register("ChordNotation", typeof(ChordProNotationType), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnChordNotationChanged)));

	public static readonly DependencyProperty IsTextLinkEnabledProperty = DependencyProperty.Register("IsTextLinkEnabled", typeof(bool), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty SelectionRangesProperty = DependencyProperty.Register("SelectionRanges", typeof(Pro.Text.Range[]), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnSelectionRangesChanged)));

	public static readonly DependencyProperty CaretIndexProperty = DependencyProperty.Register("CaretIndex", typeof(int), typeof(TextInspector));

	public static readonly DependencyProperty ActiveLineFillMaskProperty = DependencyProperty.Register("ActiveLineFillMask", typeof(LineFillMask), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnActiveLineFillMaskChanged)));

	public static readonly DependencyProperty ActiveRunSettingsProperty = DependencyProperty.Register("ActiveRunSettings", typeof(RunSettings), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnActiveRunSettingsPropertyChanged)));

	public static readonly DependencyProperty ActiveLevelSettingsProperty = DependencyProperty.Register("ActiveLevelSettings", typeof(LevelSettings), typeof(TextInspector));

	public static readonly DependencyProperty IsListEnabledProperty = DependencyProperty.Register("IsListEnabled", typeof(bool), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnIsListEnabledChanged)));

	public static readonly DependencyProperty CharacterSizeProperty = DependencyProperty.Register("CharacterSize", typeof(int), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnCharacterSizePropertyChanged)));

	public static readonly DependencyProperty FontProperty = DependencyProperty.Register("Font", typeof(FontInfo), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnFontPropertyChanged)));

	public static readonly DependencyProperty FontGroupProperty = DependencyProperty.Register("FontGroup", typeof(FontGroup), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnFontGroupChanged)));

	public static readonly DependencyProperty MissingFontProperty = DependencyProperty.Register("MissingFont", typeof(string), typeof(TextInspector));

	public static readonly DependencyProperty FillTypeProperty = DependencyProperty.Register("FillType", typeof(TextFillType), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnFillTypePropertyChanged)));

	public static readonly DependencyProperty FillProperty = DependencyProperty.Register("Fill", typeof(TextFillBase), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnFillPropertyChanged)));

	public static readonly DependencyProperty ParagraphAlignmentProperty = DependencyProperty.Register("ParagraphAlignment", typeof(ParagraphAlignment), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnParagraphAlignmentPropertyChanged)));

	public static readonly DependencyProperty LineSpacingProperty = DependencyProperty.Register("LineSpacing", typeof(double), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnLineSpacingPropertyChanged)));

	public static readonly DependencyProperty AdditionalLineSpacingProperty = DependencyProperty.Register("AdditionalLineSpacing", typeof(double), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnAdditionalLineSpacingPropertyChanged)));

	public static readonly DependencyProperty ParagraphSpacingProperty = DependencyProperty.Register("ParagraphSpacing", typeof(double), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnAfterParagraphPropertyChanged)));

	public static readonly DependencyProperty CharacterSpacingProperty = DependencyProperty.Register("CharacterSpacing", typeof(double), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnCharacterSpacingPropertyChanged)));

	public static readonly DependencyProperty LigaturesEnabledProperty = DependencyProperty.Register("LigaturesEnabled", typeof(bool), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnLigaturesEnabledChanged)));

	public static readonly DependencyProperty DocumentAlignmentProperty = DependencyProperty.Register("DocumentAlignment", typeof(DocumentAlignment), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnDocumentAlignmentPropertyChanged)));

	public static readonly DependencyProperty ScaleBehaviorProperty = DependencyProperty.Register("ScaleBehavior", typeof(ScaleMode), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnScaleBehaviorPropertyChanged)));

	public static readonly DependencyProperty TextTransformProperty = DependencyProperty.Register("TextTransform", typeof(TextTransform), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnTextTransformPropertyChanged)));

	public static readonly DependencyProperty TextTransformDelimiterProperty = DependencyProperty.Register("TextTransformDelimiter", typeof(string), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnTextTransformDelimiterPropertyChanged)));

	public static readonly DependencyProperty IsStrokeVisibleProperty = DependencyProperty.Register("IsStrokeVisible", typeof(bool), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnIsStrokeVisiblePropertyChanged)));

	public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register("StrokeThickness", typeof(double), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnStrokeThicknessPropertyChanged)));

	public static readonly DependencyProperty StrokeColorProperty = DependencyProperty.Register("StrokeColor", typeof(Color), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnStrokeColorPropertyChanged)));

	public static readonly DependencyProperty ListTextIndentProperty = DependencyProperty.Register("ListTextIndent", typeof(double), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnListTextIndentPropertyChanged)));

	public static readonly DependencyProperty ListBulletIndentProperty = DependencyProperty.Register("ListBulletIndent", typeof(double), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnListBulletIndentPropertyChanged)));

	public static readonly DependencyProperty RightIndentProperty = DependencyProperty.Register("RightIndent", typeof(double), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnRightIndentPropertyChanged)));

	public static readonly DependencyProperty MarginLeftProperty = DependencyProperty.Register("MarginLeft", typeof(double), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnMarginLeftPropertyChanged)));

	public static readonly DependencyProperty MarginTopProperty = DependencyProperty.Register("MarginTop", typeof(double), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnMarginTopPropertyChanged)));

	public static readonly DependencyProperty MarginBottomProperty = DependencyProperty.Register("MarginBottom", typeof(double), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnMarginBottomPropertyChanged)));

	public static readonly DependencyProperty MarginRightProperty = DependencyProperty.Register("MarginRight", typeof(double), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnMarginRightPropertyChanged)));

	public static readonly DependencyProperty CapitalizationProperty = DependencyProperty.Register("Capitalization", typeof(CapitalizationType), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnCapitalizationChanged)));

	public static readonly DependencyProperty IsSubscriptProperty = DependencyProperty.Register("IsSubscript", typeof(bool), typeof(TextInspector));

	public static readonly DependencyProperty IsSuperscriptProperty = DependencyProperty.Register("IsSuperscript", typeof(bool), typeof(TextInspector));

	public static readonly DependencyProperty SubscriptLevelProperty = DependencyProperty.Register("SubscriptLevel", typeof(string), typeof(TextInspector));

	public static readonly DependencyProperty SuperscriptLevelProperty = DependencyProperty.Register("SuperscriptLevel", typeof(string), typeof(TextInspector));

	public static readonly DependencyProperty ShadowEnabledProperty = DependencyProperty.Register("ShadowEnabled", typeof(bool), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnShadowEnabledPropertyChanged)));

	public static readonly DependencyProperty ShadowBlurRadiusProperty = DependencyProperty.Register("ShadowBlurRadius", typeof(double), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnShadowBlurRadiusPropertyChanged)));

	public static readonly DependencyProperty ShadowOpacityProperty = DependencyProperty.Register("ShadowOpacity", typeof(double), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnShadowOpacityPropertyChanged)));

	public static readonly DependencyProperty ShadowColorProperty = DependencyProperty.Register("ShadowColor", typeof(Color), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnShadowColorPropertyChanged)));

	public static readonly DependencyProperty ShadowAngleProperty = DependencyProperty.Register("ShadowAngle", typeof(Angle<double>), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnShadowAnglePropertyChanged)));

	public static readonly DependencyProperty ShadowOffsetProperty = DependencyProperty.Register("ShadowOffset", typeof(double), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnShadowOffsetPropertyChanged)));

	public static readonly DependencyProperty ListPresetProperty = DependencyProperty.Register("ListPreset", typeof(ListPreset), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnListPresetPropertyChanged)));

	public static readonly DependencyProperty DefaultListPresetProperty = DependencyProperty.Register("DefaultListPreset", typeof(ListPreset), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)ListPreset.Circle));

	public static readonly DependencyProperty AvailableListPresetsProperty = DependencyProperty.Register("AvailableListPresets", typeof(IEnumerable<ListPreset>), typeof(TextInspector));

	private static readonly DependencyProperty BulletScalarProperty = DependencyProperty.Register("BulletScalar", typeof(double), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnBulletScalarChanged)));

	private static readonly DependencyProperty BulletColorProperty = DependencyProperty.Register("BulletColor", typeof(Color), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnBulletColorChanged)));

	public static readonly DependencyProperty IsBoldEnabledProperty = DependencyProperty.Register("IsBoldEnabled", typeof(bool), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnIsBoldEnabledChanged)));

	public static readonly DependencyProperty IsItalicEnabledProperty = DependencyProperty.Register("IsItalicEnabled", typeof(bool), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnIsItalicEnabledChanged)));

	public static readonly DependencyProperty IsStrikethroughEnabledProperty = DependencyProperty.Register("IsStrikethroughEnabled", typeof(bool), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnIsStrikethroughEnabledChanged)));

	public static readonly DependencyProperty IsUnderlineEnabledProperty = DependencyProperty.Register("IsUnderlineEnabled", typeof(bool), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnIsUnderlineEnabledChanged)));

	public static readonly DependencyProperty UnderlineColorProperty = DependencyProperty.Register("UnderlineColor", typeof(Color), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnUnderlineColorChanged)));

	public static readonly DependencyProperty IsUnderlineColorEnabledProperty = DependencyProperty.Register("IsUnderlineColorEnabled", typeof(bool), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnIsUnderlineColorEnabledChanged)));

	public static readonly DependencyProperty HighlightColorProperty = DependencyProperty.Register("HighlightColor", typeof(Color), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnHighlightColorChanged)));

	public static readonly DependencyProperty InspectorTypeProperty = DependencyProperty.Register("InspectorType", typeof(TextInspectorType), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)TextInspectorType.Element));

	public static readonly DependencyProperty ShowTextStyleControlsProperty = DependencyProperty.Register("ShowTextStyleControls", typeof(bool), typeof(TextInspector));

	private static readonly DependencyProperty CanToggleBoldProperty = DependencyProperty.Register("CanToggleBold", typeof(bool), typeof(TextInspector));

	private static readonly DependencyProperty CanToggleItalicProperty = DependencyProperty.Register("CanToggleItalic", typeof(bool), typeof(TextInspector));

	private static readonly DependencyProperty IsTextLineMaskEnabledProperty = DependencyProperty.Register("IsTextLineMaskEnabled", typeof(bool), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnIsTextLineMaskEnabledChanged)));

	private static readonly DependencyProperty TextLineMaskStyleProperty = DependencyProperty.Register("TextLineMaskStyle", typeof(LineMaskStyle), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnTextLineMaskStyleChanged)));

	private static readonly DependencyProperty TextLineMaskHeightOffsetProperty = DependencyProperty.Register("TextLineMaskHeightOffset", typeof(double), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnTextLineMaskHeightOffsetChanged)));

	private static readonly DependencyProperty TextLineMaskVerticalOffsetProperty = DependencyProperty.Register("TextLineMaskVerticalOffset", typeof(double), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnTextLineMaskVerticalOffsetChanged)));

	private static readonly DependencyProperty TextLineMaskWidthOffsetProperty = DependencyProperty.Register("TextLineMaskWidthOffset", typeof(double), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnTextLineMaskWidthOffsetChanged)));

	private static readonly DependencyProperty TextLineMaskHorizontalOffsetProperty = DependencyProperty.Register("TextLineMaskHorizontalOffset", typeof(double), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnTextLineMaskHorizontalOffsetChanged)));

	public static readonly DependencyProperty CommandTargetTypeProperty = DependencyProperty.Register("CommandTargetType", typeof(CommandTargetType), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnCommandTargetTypeChanged)));

	public static readonly DependencyProperty IsFontFamilySelectionOpenProperty = DependencyProperty.Register("IsFontFamilySelectionOpen", typeof(bool), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));

	public static readonly DependencyProperty PreserveFormatProperty = DependencyProperty.Register("PreserveFormat", typeof(bool), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));

	public static readonly DependencyProperty AllowTextFillProperty = DependencyProperty.Register("AllowTextFill", typeof(bool), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty ChangeTextFillTypeCommandProperty = DependencyProperty.Register("ChangeTextFillTypeCommand", typeof(ICommand<TextFillType>), typeof(TextInspector));

	public static readonly DependencyProperty ApplyDocumentSettingsCommandProperty = DependencyProperty.Register("ApplyDocumentSettingsCommand", typeof(ICommand<DocumentSettingsCommandParameters>), typeof(TextInspector));

	public static readonly DependencyProperty ApplyParagraphSettingsCommandProperty = DependencyProperty.Register("ApplyParagraphSettingsCommand", typeof(ICommand<ParagraphSettingsCommandParameters>), typeof(TextInspector));

	public static readonly DependencyProperty ApplyRunSettingsCommandProperty = DependencyProperty.Register("ApplyRunSettingsCommand", typeof(ICommand<RunSettingsCommandParameters>), typeof(TextInspector));

	public static readonly DependencyProperty ApplyLineFillMaskSettingsCommandProperty = DependencyProperty.Register("ApplyLineFillMaskSettingsCommand", typeof(ICommand<LineFillMaskCommandParameters>), typeof(TextInspector));

	public static readonly DependencyProperty FocusTextBoxCommandProperty = DependencyProperty.Register("FocusTextBoxCommand", typeof(ICommand), typeof(TextInspector));

	public static readonly DependencyProperty MediaProviderProperty = DependencyProperty.Register("MediaProvider", typeof(IMediaProvider), typeof(TextInspector));

	public static readonly DependencyProperty EditModeProperty = DependencyProperty.Register("EditMode", typeof(EditMode), typeof(TextInspector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnEditModePropertyChanged)));

	public static readonly DependencyProperty TextInspectorVMProperty = DependencyProperty.Register("TextInspectorVM", typeof(ITextInspectorVM), typeof(TextInspector));

	public FontGroup[] FontGroups => SharedTypefaceLibrary.Library.AvailableTypefaces.FontGroups;

	public bool SettingsUpdateInProgress { get; private set; }

	public bool ChordsEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ChordsEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ChordsEnabledProperty, (object)value);
		}
	}

	private Color ChordColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(ChordColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ChordColorProperty, (object)value);
		}
	}

	private ChordProNotationType ChordNotation
	{
		get
		{
			return (ChordProNotationType)((DependencyObject)this).GetValue(ChordNotationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ChordNotationProperty, (object)value);
		}
	}

	public bool IsTextLinkEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsTextLinkEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsTextLinkEnabledProperty, (object)value);
		}
	}

	public TextDocument? Document
	{
		get
		{
			return (TextDocument)((DependencyObject)this).GetValue(DocumentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DocumentProperty, (object)value);
		}
	}

	public Pro.Text.Range[]? SelectionRanges
	{
		get
		{
			return (Pro.Text.Range[])((DependencyObject)this).GetValue(SelectionRangesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectionRangesProperty, (object)value);
		}
	}

	public int CaretIndex
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(CaretIndexProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CaretIndexProperty, (object)value);
		}
	}

	public LineFillMask? ActiveLineFillMask
	{
		get
		{
			return (LineFillMask)((DependencyObject)this).GetValue(ActiveLineFillMaskProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveLineFillMaskProperty, (object)value);
		}
	}

	public RunSettings? ActiveRunSettings
	{
		get
		{
			return (RunSettings)((DependencyObject)this).GetValue(ActiveRunSettingsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveRunSettingsProperty, (object)value);
		}
	}

	public LevelSettings? ActiveLevelSettings
	{
		get
		{
			return (LevelSettings)((DependencyObject)this).GetValue(ActiveLevelSettingsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveLevelSettingsProperty, (object)value);
		}
	}

	public bool IsListEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsListEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsListEnabledProperty, (object)value);
		}
	}

	public FontInfo Font
	{
		get
		{
			return (FontInfo)((DependencyObject)this).GetValue(FontProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FontProperty, (object)value);
		}
	}

	public FontGroup? FontGroup
	{
		get
		{
			return (FontGroup)((DependencyObject)this).GetValue(FontGroupProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FontGroupProperty, (object)value);
		}
	}

	public string? MissingFont
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(MissingFontProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MissingFontProperty, (object)value);
		}
	}

	public int CharacterSize
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(CharacterSizeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CharacterSizeProperty, (object)value);
		}
	}

	public TextFillType FillType
	{
		get
		{
			return (TextFillType)((DependencyObject)this).GetValue(FillTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FillTypeProperty, (object)value);
		}
	}

	public TextFillBase? Fill
	{
		get
		{
			return (TextFillBase)((DependencyObject)this).GetValue(FillProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FillProperty, (object)value);
		}
	}

	public ParagraphAlignment ParagraphAlignment
	{
		get
		{
			return (ParagraphAlignment)((DependencyObject)this).GetValue(ParagraphAlignmentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ParagraphAlignmentProperty, (object)value);
		}
	}

	public double LineSpacing
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(LineSpacingProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LineSpacingProperty, (object)value);
		}
	}

	public double AdditionalLineSpacing
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(AdditionalLineSpacingProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AdditionalLineSpacingProperty, (object)value);
		}
	}

	public double ParagraphSpacing
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ParagraphSpacingProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ParagraphSpacingProperty, (object)value);
		}
	}

	public double CharacterSpacing
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(CharacterSpacingProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CharacterSpacingProperty, (object)value);
		}
	}

	public bool LigaturesEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(LigaturesEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LigaturesEnabledProperty, (object)value);
		}
	}

	public DocumentAlignment DocumentAlignment
	{
		get
		{
			return (DocumentAlignment)((DependencyObject)this).GetValue(DocumentAlignmentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DocumentAlignmentProperty, (object)value);
		}
	}

	public TextTransform TextTransform
	{
		get
		{
			return (TextTransform)((DependencyObject)this).GetValue(TextTransformProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextTransformProperty, (object)value);
		}
	}

	public string? TextTransformDelimiter
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(TextTransformDelimiterProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextTransformDelimiterProperty, (object)value);
		}
	}

	public ScaleMode ScaleBehavior
	{
		get
		{
			return (ScaleMode)((DependencyObject)this).GetValue(ScaleBehaviorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ScaleBehaviorProperty, (object)value);
		}
	}

	public bool IsStrokeVisible
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsStrokeVisibleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsStrokeVisibleProperty, (object)value);
		}
	}

	public double StrokeThickness
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(StrokeThicknessProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StrokeThicknessProperty, (object)value);
		}
	}

	public Color StrokeColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(StrokeColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StrokeColorProperty, (object)value);
		}
	}

	public double ListTextIndent
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ListTextIndentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ListTextIndentProperty, (object)value);
		}
	}

	public double ListBulletIndent
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ListBulletIndentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ListBulletIndentProperty, (object)value);
		}
	}

	public double RightIndent
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(RightIndentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RightIndentProperty, (object)value);
		}
	}

	public double MarginLeft
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MarginLeftProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MarginLeftProperty, (object)value);
		}
	}

	public double MarginTop
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MarginTopProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MarginTopProperty, (object)value);
		}
	}

	public double MarginBottom
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MarginBottomProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MarginBottomProperty, (object)value);
		}
	}

	public double MarginRight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MarginRightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MarginRightProperty, (object)value);
		}
	}

	public CapitalizationType Capitalization
	{
		get
		{
			return (CapitalizationType)((DependencyObject)this).GetValue(CapitalizationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CapitalizationProperty, (object)value);
		}
	}

	public bool IsSubscript
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsSubscriptProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsSubscriptProperty, (object)value);
		}
	}

	public bool IsSuperscript
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsSuperscriptProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsSuperscriptProperty, (object)value);
		}
	}

	public string? SubscriptLevel
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(SubscriptLevelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SubscriptLevelProperty, (object)value);
		}
	}

	public string? SuperscriptLevel
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(SuperscriptLevelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SuperscriptLevelProperty, (object)value);
		}
	}

	public bool ShadowEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShadowEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShadowEnabledProperty, (object)value);
		}
	}

	public double ShadowBlurRadius
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ShadowBlurRadiusProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShadowBlurRadiusProperty, (object)value);
		}
	}

	public double ShadowOpacity
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ShadowOpacityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShadowOpacityProperty, (object)value);
		}
	}

	public Color ShadowColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(ShadowColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShadowColorProperty, (object)value);
		}
	}

	public Angle<double> ShadowAngle
	{
		get
		{
			return (Angle<double>)((DependencyObject)this).GetValue(ShadowAngleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShadowAngleProperty, (object)value);
		}
	}

	public double ShadowOffset
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ShadowOffsetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShadowOffsetProperty, (object)value);
		}
	}

	public ListPreset ListPreset
	{
		get
		{
			return (ListPreset)((DependencyObject)this).GetValue(ListPresetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ListPresetProperty, (object)value);
		}
	}

	public ListPreset DefaultListPreset
	{
		get
		{
			return (ListPreset)((DependencyObject)this).GetValue(DefaultListPresetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DefaultListPresetProperty, (object)value);
		}
	}

	public IEnumerable<ListPreset>? AvailableListPresets
	{
		get
		{
			return (IEnumerable<ListPreset>)((DependencyObject)this).GetValue(AvailableListPresetsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AvailableListPresetsProperty, (object)value);
		}
	}

	private double BulletScalar
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(BulletScalarProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BulletScalarProperty, (object)value);
		}
	}

	private Color BulletColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(BulletColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BulletColorProperty, (object)value);
		}
	}

	public bool IsBoldEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsBoldEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsBoldEnabledProperty, (object)value);
		}
	}

	public bool IsItalicEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsItalicEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsItalicEnabledProperty, (object)value);
		}
	}

	public bool IsStrikethroughEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsStrikethroughEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsStrikethroughEnabledProperty, (object)value);
		}
	}

	public bool IsUnderlineEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsUnderlineEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsUnderlineEnabledProperty, (object)value);
		}
	}

	public Color UnderlineColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(UnderlineColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(UnderlineColorProperty, (object)value);
		}
	}

	public bool IsUnderlineColorEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsUnderlineColorEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsUnderlineColorEnabledProperty, (object)value);
		}
	}

	public Color HighlightColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(HighlightColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HighlightColorProperty, (object)value);
		}
	}

	public TextInspectorType InspectorType
	{
		get
		{
			return (TextInspectorType)((DependencyObject)this).GetValue(InspectorTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(InspectorTypeProperty, (object)value);
		}
	}

	public bool ShowTextStyleControls
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowTextStyleControlsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowTextStyleControlsProperty, (object)value);
		}
	}

	private bool CanToggleBold
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanToggleBoldProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanToggleBoldProperty, (object)value);
		}
	}

	private bool CanToggleItalic
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanToggleItalicProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanToggleItalicProperty, (object)value);
		}
	}

	private bool IsTextLineMaskEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsTextLineMaskEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsTextLineMaskEnabledProperty, (object)value);
		}
	}

	private LineMaskStyle TextLineMaskStyle
	{
		get
		{
			return (LineMaskStyle)((DependencyObject)this).GetValue(TextLineMaskStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextLineMaskStyleProperty, (object)value);
		}
	}

	private double TextLineMaskHeightOffset
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(TextLineMaskHeightOffsetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextLineMaskHeightOffsetProperty, (object)value);
		}
	}

	private double TextLineMaskVerticalOffset
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(TextLineMaskVerticalOffsetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextLineMaskVerticalOffsetProperty, (object)value);
		}
	}

	private double TextLineMaskWidthOffset
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(TextLineMaskWidthOffsetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextLineMaskWidthOffsetProperty, (object)value);
		}
	}

	private double TextLineMaskHorizontalOffset
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(TextLineMaskHorizontalOffsetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextLineMaskHorizontalOffsetProperty, (object)value);
		}
	}

	public bool IsFontFamilySelectionOpen
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsFontFamilySelectionOpenProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsFontFamilySelectionOpenProperty, (object)value);
		}
	}

	public bool PreserveFormat
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(PreserveFormatProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PreserveFormatProperty, (object)value);
		}
	}

	public bool AllowTextFill
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AllowTextFillProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AllowTextFillProperty, (object)value);
		}
	}

	public CommandTargetType CommandTargetType
	{
		get
		{
			return (CommandTargetType)((DependencyObject)this).GetValue(CommandTargetTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CommandTargetTypeProperty, (object)value);
		}
	}

	public ICommand<TextFillType>? ChangeTextFillTypeCommand
	{
		get
		{
			return (ICommand<TextFillType>)((DependencyObject)this).GetValue(ChangeTextFillTypeCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ChangeTextFillTypeCommandProperty, (object)value);
		}
	}

	public ICommand<DocumentSettingsCommandParameters>? ApplyDocumentSettingsCommand
	{
		get
		{
			return (ICommand<DocumentSettingsCommandParameters>)((DependencyObject)this).GetValue(ApplyDocumentSettingsCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ApplyDocumentSettingsCommandProperty, (object)value);
		}
	}

	public ICommand<ParagraphSettingsCommandParameters>? ApplyParagraphSettingsCommand
	{
		get
		{
			return (ICommand<ParagraphSettingsCommandParameters>)((DependencyObject)this).GetValue(ApplyParagraphSettingsCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ApplyParagraphSettingsCommandProperty, (object)value);
		}
	}

	public ICommand<RunSettingsCommandParameters>? ApplyRunSettingsCommand
	{
		get
		{
			return (ICommand<RunSettingsCommandParameters>)((DependencyObject)this).GetValue(ApplyRunSettingsCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ApplyRunSettingsCommandProperty, (object)value);
		}
	}

	public ICommand<LineFillMaskCommandParameters>? ApplyLineFillMaskSettingsCommand
	{
		get
		{
			return (ICommand<LineFillMaskCommandParameters>)((DependencyObject)this).GetValue(ApplyLineFillMaskSettingsCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ApplyRunSettingsCommandProperty, (object)value);
		}
	}

	public ICommand? FocusTextBoxCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(FocusTextBoxCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FocusTextBoxCommandProperty, (object)value);
		}
	}

	public IMediaProvider? MediaProvider
	{
		get
		{
			return (IMediaProvider)((DependencyObject)this).GetValue(MediaProviderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MediaProviderProperty, (object)value);
		}
	}

	public EditMode EditMode
	{
		get
		{
			return (EditMode)((DependencyObject)this).GetValue(EditModeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EditModeProperty, (object)value);
		}
	}

	public ITextInspectorVM TextInspectorVM
	{
		get
		{
			return (ITextInspectorVM)((DependencyObject)this).GetValue(TextInspectorVMProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextInspectorVMProperty, (object)value);
		}
	}

	private static void OnDocumentPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		((TextInspector)(object)caller).DocumentPropertyChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as TextDocument, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as TextDocument);
	}

	private static void OnActiveLineFillMaskChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		((TextInspector)(object)caller).LineFillMaskChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as LineFillMask, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as LineFillMask);
	}

	private static void OnSelectionRangesChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		((TextInspector)(object)caller).UpdateParagraphSettings();
	}

	private static void OnActiveRunSettingsPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		((TextInspector)(object)caller).UpdateRunSettings();
	}

	private static void OnIsListEnabledChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		((TextInspector)(object)caller).IsListEnabledChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnChordsEnabledChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		((TextInspector)(object)caller).ChordsEnabledChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnChordColorChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		((TextInspector)(object)caller).ChordColorChanged((Color)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnChordNotationChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		((TextInspector)(object)caller).ChordNotationChanged((ChordProNotationType)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnFontPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		TextInspector textInspector = (TextInspector)(object)caller;
		textInspector.ApplyRunSettings(delegate(RunSettings s, RangeSelectionType t, TextDocument? _)
		{
			s.Font = (FontInfo)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
			s.UpdateOriginalFont();
		}, textInspector._overrideFontUndoActionType ?? Pro.Text.Reversibility.UndoActionTypes.Font, autoFinalize: true);
	}

	private static void OnFontGroupChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		((TextInspector)(object)caller).FontGroupChanged(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as FontGroup);
	}

	private static void OnCharacterSizePropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyRunSettings(delegate(RunSettings s, RangeSelectionType t, TextDocument? _)
		{
			s.CharacterSize = (int)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.CharacterSize, autoFinalize: false);
	}

	private static void OnFillPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyRunSettings(delegate(RunSettings s, RangeSelectionType t, TextDocument? _)
		{
			s.Fill = (TextFillBase)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.TextFill, autoFinalize: true);
	}

	private static void OnParagraphAlignmentPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyParagraphSettings(delegate(ParagraphSettings p, RunSettings r, RangeSelectionType t)
		{
			p.Alignment = (ParagraphAlignment)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.ParagraphAlignment, autoFinalize: true);
	}

	private static void OnLineSpacingPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyParagraphSettings(delegate(ParagraphSettings p, RunSettings r, RangeSelectionType t)
		{
			p.SpacingMode = LineSpacingMode.Multiple;
			p.LineSpacing = (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.LineSpacing, autoFinalize: false);
	}

	private static void OnAdditionalLineSpacingPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyParagraphSettings(delegate(ParagraphSettings p, RunSettings r, RangeSelectionType t)
		{
			p.SpacingMode = LineSpacingMode.Multiple;
			p.AdditionalLineSpacing = (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.LineSpacing, autoFinalize: false);
	}

	private static void OnAfterParagraphPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyParagraphSettings(delegate(ParagraphSettings p, RunSettings r, RangeSelectionType t)
		{
			p.AfterParagraph = (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.AfterParagraph, autoFinalize: false);
	}

	private static void OnCharacterSpacingPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyRunSettings(delegate(RunSettings s, RangeSelectionType t, TextDocument? _)
		{
			s.CharacterSpacing = (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.CharacterSpacing, autoFinalize: false);
	}

	private static void OnLigaturesEnabledChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyRunSettings(delegate(RunSettings s, RangeSelectionType t, TextDocument? _)
		{
			s.LigaturesEnabled = (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.EnableLigatures, autoFinalize: false);
	}

	private static void OnDocumentAlignmentPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyDocumentSettings(delegate(TextDocumentSettings s, RangeSelectionType t)
		{
			s.Alignment = (DocumentAlignment)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.DocumentAlignment, autoFinalize: true);
	}

	private static void OnScaleBehaviorPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyDocumentSettings(delegate(TextDocumentSettings s, RangeSelectionType t)
		{
			s.ScaleMode = (ScaleMode)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.DocumentScaleBehavior, autoFinalize: true);
	}

	private static void OnTextTransformPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		((TextInspector)(object)caller).OnTextTransformChanged((TextTransform)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnTextTransformDelimiterPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyDocumentSettings(delegate(TextDocumentSettings s, RangeSelectionType t)
		{
			s.TransformDelimiter = (string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.DocumentTransformDelimiter, autoFinalize: true);
	}

	private static void OnIsStrokeVisiblePropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyRunSettings(delegate(RunSettings s, RangeSelectionType t, TextDocument? _)
		{
			s.IsStrokeVisible = (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.TextStrokeEnabled, autoFinalize: true);
	}

	private static void OnStrokeThicknessPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyRunSettings(delegate(RunSettings s, RangeSelectionType t, TextDocument? _)
		{
			s.StrokeThickness = (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.TextStrokeThickness, autoFinalize: false);
	}

	private static void OnStrokeColorPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyRunSettings(delegate(RunSettings s, RangeSelectionType t, TextDocument? _)
		{
			s.StrokeColor = (Color)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.TextStrokeColor, autoFinalize: true);
	}

	private static void OnListTextIndentPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyParagraphSettings(delegate(ParagraphSettings p, RunSettings r, RangeSelectionType t)
		{
			p.TabStops.Clear();
			p.TabStops.AddStop(p.LeftIndent + p.FirstLineIndent + (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}, Pro.Text.Reversibility.UndoActionTypes.FirstLineIndent, autoFinalize: false);
	}

	private static void OnListBulletIndentPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyParagraphSettings(delegate(ParagraphSettings p, RunSettings r, RangeSelectionType t)
		{
			double num = (double)((DependencyPropertyChangedEventArgs)(ref e)).OldValue;
			double num2 = (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
			if (p.TabStops.Any())
			{
				p.TabStops[0].Position += num2 - num;
			}
			p.LeftIndent = num2;
		}, Pro.Text.Reversibility.UndoActionTypes.LeftIndent, autoFinalize: false);
	}

	private static void OnRightIndentPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyParagraphSettings(delegate(ParagraphSettings p, RunSettings r, RangeSelectionType t)
		{
			p.RightIndent = (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.RightIndent, autoFinalize: false);
	}

	private static void OnCapitalizationChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyRunSettings(delegate(RunSettings s, RangeSelectionType t, TextDocument? _)
		{
			s.CapitalizationType = (CapitalizationType)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.Capitalization, autoFinalize: true);
	}

	private static void OnMarginLeftPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyDocumentSettings(delegate(TextDocumentSettings d, RangeSelectionType t)
		{
			d.Margins.Left = (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.LeftMargin, autoFinalize: false);
	}

	private static void OnMarginTopPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyDocumentSettings(delegate(TextDocumentSettings d, RangeSelectionType t)
		{
			d.Margins.Top = (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.TopMargin, autoFinalize: false);
	}

	private static void OnMarginBottomPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyDocumentSettings(delegate(TextDocumentSettings d, RangeSelectionType t)
		{
			d.Margins.Bottom = (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.BottomMargin, autoFinalize: false);
	}

	private static void OnMarginRightPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyDocumentSettings(delegate(TextDocumentSettings d, RangeSelectionType t)
		{
			d.Margins.Right = (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.RightMargin, autoFinalize: false);
	}

	private static void OnShadowEnabledPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyDocumentSettings(delegate(TextDocumentSettings d, RangeSelectionType t)
		{
			d.Shadow.IsEnabled = (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.TextShadowEnabled, autoFinalize: true);
	}

	private static void OnShadowBlurRadiusPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyDocumentSettings(delegate(TextDocumentSettings d, RangeSelectionType t)
		{
			d.Shadow.BlurRadius = (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.TextShadowBlurRadius, autoFinalize: false);
	}

	private static void OnShadowOpacityPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyDocumentSettings(delegate(TextDocumentSettings d, RangeSelectionType t)
		{
			d.Shadow.Opacity = (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.TextShadowOpacity, autoFinalize: false);
	}

	private static void OnShadowColorPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyDocumentSettings(delegate(TextDocumentSettings d, RangeSelectionType t)
		{
			d.Shadow.Color = (Color)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.TextShadowColor, autoFinalize: true);
	}

	private static void OnShadowAnglePropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyDocumentSettings(delegate(TextDocumentSettings d, RangeSelectionType t)
		{
			d.Shadow.Angle = (Angle<double>)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.TextShadowAngle, autoFinalize: false);
	}

	private static void OnShadowOffsetPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyDocumentSettings(delegate(TextDocumentSettings d, RangeSelectionType t)
		{
			d.Shadow.Offset = (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.TextShadowOffset, autoFinalize: false);
	}

	private static void OnListPresetPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		((TextInspector)(object)caller).ListPresetChanged((ListPreset)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (ListPreset)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnBulletScalarChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyParagraphSettings(delegate(ParagraphSettings p, RunSettings r, RangeSelectionType t)
		{
			p.BulletScalar = (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.ListBulletSize, autoFinalize: false);
	}

	private static void OnBulletColorChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyParagraphSettings(delegate(ParagraphSettings p, RunSettings r, RangeSelectionType t)
		{
			p.BulletColor = (Color)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.ListBulletColor, autoFinalize: false);
	}

	private static void OnIsBoldEnabledChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		((TextInspector)(object)caller).IsBoldEnabledChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnIsItalicEnabledChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		((TextInspector)(object)caller).IsItalicEnabledChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnIsStrikethroughEnabledChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyRunSettings(delegate(RunSettings s, RangeSelectionType t, TextDocument? _)
		{
			s.Strikethrough = (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.Strikethrough, autoFinalize: true);
	}

	private static void OnIsUnderlineEnabledChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyRunSettings(delegate(RunSettings s, RangeSelectionType t, TextDocument? _)
		{
			s.Underline = (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, Pro.Text.Reversibility.UndoActionTypes.Underline, autoFinalize: true);
	}

	private static void OnUnderlineColorChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyRunSettings(delegate(RunSettings s, RangeSelectionType t, TextDocument? _)
		{
			s.UnderlineColor = ((((DependencyPropertyChangedEventArgs)(ref e)).NewValue is Color color && color != Colors.Transparent) ? new Color?(color) : ((Color?)null));
		}, Pro.Text.Reversibility.UndoActionTypes.UnderlineColor, autoFinalize: false);
	}

	private static void OnIsUnderlineColorEnabledChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		((TextInspector)(object)caller).OnIsUnderlineColorEnabledChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnHighlightColorChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		((TextInspector)(object)caller).OnHighlightColorChanged((((DependencyPropertyChangedEventArgs)(ref e)).NewValue is Color color && color != Colors.Transparent) ? new Color?(color) : ((Color?)null));
	}

	private static void OnIsTextLineMaskEnabledChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyLineFillMaskSettings(delegate(LineFillMask m, RangeSelectionType t)
		{
			m.IsEnabled = (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, ProPresenter.DO.UndoActionTypes.LineFillMaskEnabled, autoFinalize: true);
	}

	private static void OnTextLineMaskStyleChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyLineFillMaskSettings(delegate(LineFillMask m, RangeSelectionType t)
		{
			m.MaskStyle = (LineMaskStyle)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, ProPresenter.DO.UndoActionTypes.LineFillMaskStyle, autoFinalize: true);
	}

	private static void OnTextLineMaskHeightOffsetChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyLineFillMaskSettings(delegate(LineFillMask m, RangeSelectionType t)
		{
			m.HeightOffset = (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, ProPresenter.DO.UndoActionTypes.LineFillMaskHeightOffset, autoFinalize: false);
	}

	private static void OnTextLineMaskVerticalOffsetChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyLineFillMaskSettings(delegate(LineFillMask m, RangeSelectionType t)
		{
			m.VerticalOffset = (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, ProPresenter.DO.UndoActionTypes.LineFillMaskVerticalOffset, autoFinalize: false);
	}

	private static void OnTextLineMaskWidthOffsetChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyLineFillMaskSettings(delegate(LineFillMask m, RangeSelectionType t)
		{
			m.WidthOffset = (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, ProPresenter.DO.UndoActionTypes.LineFillMaskWidthOffset, autoFinalize: false);
	}

	private static void OnTextLineMaskHorizontalOffsetChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		((TextInspector)(object)caller).ApplyLineFillMaskSettings(delegate(LineFillMask m, RangeSelectionType t)
		{
			m.HorizontalOffset = (double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		}, ProPresenter.DO.UndoActionTypes.LineFillMaskHorizontalOffset, autoFinalize: false);
	}

	private static void OnCommandTargetTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		CommandTargets.SetRegister(d, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void OnEditModePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		CollectionViewSource obj = ((TextInspector)(object)d).Resources["CollectionViewSource_TextFills"] as CollectionViewSource;
		if (obj != null)
		{
			obj.View.Refresh();
		}
	}

	public TextInspector()
	{
		_app = UIServiceProvider.GetService<IApp>();
		InitializeComponent();
		bool editModeActive;
		Func<TextDocument[]> getDocumentsAction = () => TextInspectorVM?.GetActiveDocuments(out editModeActive)?.ToArray();
		SolidTextFill.ApplyRunSettingsProvider = ApplyRunSettings;
		SolidTextFill.ApplyParagraphSettingsProvider = ApplyParagraphSettings;
		SolidTextFill.GetDocumentsAction = getDocumentsAction;
		GradientTextFill.ApplyRunSettingsProvider = ApplyRunSettings;
		GradientTextFill.ApplyParagraphSettingsProvider = ApplyParagraphSettings;
		GradientTextFill.GetDocumentsAction = getDocumentsAction;
		TextMediaFill.ApplyRunSettingsProvider = ApplyRunSettings;
		TextMediaFill.ApplyParagraphSettingsProvider = ApplyParagraphSettings;
		TextMediaFill.GetDocumentsAction = getDocumentsAction;
		TextBlurFill.ApplyRunSettingsProvider = ApplyRunSettings;
		TextBlurFill.ApplyParagraphSettingsProvider = ApplyParagraphSettings;
		TextBlurFill.GetDocumentsAction = getDocumentsAction;
	}

	private void DocumentPropertyChanged(TextDocument? oldDocument, TextDocument? newDocument)
	{
		if (oldDocument != null)
		{
			oldDocument.DocumentChanged -= OnDocumentChanged;
		}
		if (newDocument != null)
		{
			newDocument.DocumentChanged += OnDocumentChanged;
		}
		OnDocumentChanged(newDocument);
	}

	private void LineFillMaskChanged(LineFillMask? oldValue, LineFillMask? newValue)
	{
		if (oldValue != null)
		{
			oldValue.PropertyChanged -= LineFillMaskPropertyChanged;
		}
		if (newValue != null)
		{
			newValue.PropertyChanged += LineFillMaskPropertyChanged;
		}
		UpdateLineFillMaskSettings();
	}

	private void LineFillMaskPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		UpdateLineFillMaskSettings();
	}

	private void UpdateLineFillMaskSettings()
	{
		SettingsUpdateInProgress = true;
		IsTextLineMaskEnabled = ActiveLineFillMask?.IsEnabled ?? false;
		TextLineMaskStyle = ActiveLineFillMask?.MaskStyle ?? LineMaskStyle.FullWidth;
		TextLineMaskHeightOffset = ActiveLineFillMask?.HeightOffset ?? 0.0;
		TextLineMaskVerticalOffset = ActiveLineFillMask?.VerticalOffset ?? 0.0;
		TextLineMaskWidthOffset = ActiveLineFillMask?.WidthOffset ?? 0.0;
		TextLineMaskHorizontalOffset = ActiveLineFillMask?.HorizontalOffset ?? 0.0;
		SettingsUpdateInProgress = false;
	}

	private void OnDocumentChanged(TextDocument? document)
	{
		UpdateDocumentSettings();
		UpdateParagraphSettings();
		UpdateRunSettings();
	}

	private void ApplyDocumentSettings(Action<TextDocumentSettings, RangeSelectionType> callback, Pro.Text.Reversibility.UndoActionTypes undoActionType, bool autoFinalize)
	{
		if (!SettingsUpdateInProgress)
		{
			if (ApplyDocumentSettingsCommand != null)
			{
				ApplyDocumentSettingsCommand.Invoke(new DocumentSettingsCommandParameters(callback, undoActionType, autoFinalize));
			}
			else if (Document != null)
			{
				callback(Document.Settings, RangeSelectionType.Document);
			}
			ReturnFocus();
		}
	}

	private void ApplyParagraphSettings(Action<ParagraphSettings, RunSettings, RangeSelectionType> callback, Pro.Text.Reversibility.UndoActionTypes undoActionType, bool autoFinalize)
	{
		if (SettingsUpdateInProgress)
		{
			return;
		}
		if (ApplyParagraphSettingsCommand != null)
		{
			ApplyParagraphSettingsCommand.Invoke(new ParagraphSettingsCommandParameters(callback, undoActionType, autoFinalize));
		}
		else
		{
			RangeSelectionType rangeSelectionType = GetRangeSelectionType();
			Document?.IterateParagraphs(SelectionRanges, delegate(Paragraph p)
			{
				callback(p.Settings, p.First().Settings, rangeSelectionType);
			});
		}
		ReturnFocus();
	}

	private void ApplyRunSettings(Action<RunSettings, RangeSelectionType, TextDocument?> callback, Pro.Text.Reversibility.UndoActionTypes undoActionType, bool autoFinalize)
	{
		if (SettingsUpdateInProgress)
		{
			return;
		}
		if (ApplyRunSettingsCommand != null)
		{
			ApplyRunSettingsCommand.Invoke(new RunSettingsCommandParameters(callback, undoActionType, autoFinalize));
		}
		else
		{
			Pro.Text.Range[]? selectionRanges = SelectionRanges;
			if (selectionRanges != null && selectionRanges.ContainsSelection())
			{
				RangeSelectionType rangeSelectionType = GetRangeSelectionType();
				Document?.IterateRuns(SelectionRanges, splitRuns: true, delegate(RunBase r)
				{
					callback(r.Settings, rangeSelectionType, Document);
				});
			}
			else if (ActiveRunSettings != null)
			{
				callback(ActiveRunSettings, RangeSelectionType.NextUp, Document);
			}
		}
		ReturnFocus();
	}

	private void ApplyLineFillMaskSettings(Action<LineFillMask, RangeSelectionType> action, ProPresenter.DO.UndoActionTypes undoActionType, bool autoFinalize)
	{
		if (!SettingsUpdateInProgress)
		{
			if (ApplyLineFillMaskSettingsCommand != null)
			{
				ApplyLineFillMaskSettingsCommand.Invoke(new LineFillMaskCommandParameters(action, undoActionType, autoFinalize));
			}
			else if (ActiveLineFillMask != null)
			{
				action(ActiveLineFillMask, RangeSelectionType.NextUp);
			}
		}
	}

	private void ReturnFocus()
	{
		FrameworkElement frameworkElement = ((DependencyObject)(object)this).FindVisualChild((FrameworkElement q) => q.IsFocused);
		ColorPicker? colorPicker = ((DependencyObject)(object)this).FindVisualChild((ColorPicker q) => q.IsOpen);
		IInputElement focusedElement = Keyboard.FocusedElement;
		DoubleUpDown doubleUpDown = ((DependencyObject)((focusedElement is DependencyObject) ? focusedElement : null))?.FindVisualParent<DoubleUpDown>();
		ColorPicker colorPicker2 = ((DependencyObject)(object)UnderlineButtonColorPicker.ContextMenu).FindVisualChild((ColorPicker q) => q.IsOpen);
		if (colorPicker == null && colorPicker2 == null && !(frameworkElement is TextBox) && (!(frameworkElement is RepeatButton) || Mouse.LeftButton != MouseButtonState.Pressed) && doubleUpDown == null)
		{
			FocusTextBoxCommand?.Invoke();
		}
	}

	private void UpdateDocumentSettings()
	{
		SettingsUpdateInProgress = true;
		DocumentAlignment = Document?.Settings.Alignment ?? DocumentAlignment.Middle;
		TextTransform = Document?.Settings.Transform ?? TextTransform.None;
		TextTransformDelimiter = Document?.Settings.TransformDelimiter ?? string.Empty;
		ScaleBehavior = Document?.Settings.ScaleMode ?? ScaleMode.None;
		MarginLeft = Document?.Settings.Margins.Left ?? 0.0;
		MarginTop = Document?.Settings.Margins.Top ?? 0.0;
		MarginBottom = Document?.Settings.Margins.Bottom ?? 0.0;
		MarginRight = Document?.Settings.Margins.Right ?? 0.0;
		ShadowEnabled = Document?.Settings.Shadow.IsEnabled ?? false;
		ShadowBlurRadius = Document?.Settings.Shadow.BlurRadius ?? 0.0;
		ShadowOpacity = Document?.Settings.Shadow.Opacity ?? 0.0;
		ShadowColor = Document?.Settings.Shadow.Color ?? Colors.Black;
		ShadowAngle = Document?.Settings.Shadow.Angle ?? Angle<double>.Zero;
		ShadowOffset = Document?.Settings.Shadow.Offset ?? 0.0;
		ChordsEnabled = Document?.Settings.ChordPro.Enabled ?? false;
		ChordNotation = Document?.Settings.ChordPro.Notation ?? ChordProNotationType.Chords;
		ChordColor = Document?.Settings.ChordPro.Color ?? Fill?.PrimaryColor ?? Colors.Transparent;
		SettingsUpdateInProgress = false;
	}

	private void UpdateParagraphSettings()
	{
		SettingsUpdateInProgress = true;
		int index = SelectionRanges?.FirstIndex() ?? (-1);
		RangeSelectionType rangeSelectionType = SelectionRanges?.GetRangeSelectionType(Document) ?? RangeSelectionType.Document;
		if (Document == null)
		{
			ActiveLevelSettings = null;
		}
		else if (rangeSelectionType != 0)
		{
			Document.IterateParagraphs(new Pro.Text.Range(index), delegate(Paragraph p)
			{
				setParagraphSettings(p.Settings);
			});
		}
		else
		{
			setParagraphSettings(Document.Attributes.ParagraphSettings);
		}
		IsListEnabled = (object)ActiveLevelSettings != null;
		ListPreset = (((object)ActiveLevelSettings != null) ? ListPresetFactory.MatchToPreset(ActiveLevelSettings) : ListPreset.None);
		SettingsUpdateInProgress = false;
		void setParagraphSettings(ParagraphSettings settings)
		{
			ParagraphAlignment = settings.Alignment;
			LineSpacing = settings.LineSpacing;
			AdditionalLineSpacing = settings.AdditionalLineSpacing;
			ParagraphSpacing = settings.AfterParagraph;
			ListTextIndent = (settings.TabStops?.FirstOrDefault()?.Position - settings.LeftIndent - settings.FirstLineIndent) ?? ((ListTextIndent <= 0.0) ? 119.0 : ListTextIndent);
			ListBulletIndent = settings.LeftIndent;
			RightIndent = settings.RightIndent;
			BulletScalar = settings.BulletScalar;
			BulletColor = settings.BulletColor ?? Fill?.PrimaryColor ?? Colors.Transparent;
			ActiveLevelSettings = Document.ListSettingsCollection.ElementAtOrDefault(settings.ListIndex)?.Levels.GetLevelSettings(settings.LevelIndex);
		}
	}

	private void UpdateRunSettings()
	{
		SettingsUpdateInProgress = true;
		RunSettings runSettings = ActiveRunSettings ?? new RunSettings();
		IsItalicEnabled = runSettings.Font.IsItalic;
		IsBoldEnabled = runSettings.Font.IsBold;
		FontInfo fontInfo = (Font = runSettings.Font.GetStyledFontVariant());
		FontGroup = fontInfo.GetFontGroup();
		if (FontGroup == null)
		{
			SetMissingFont(runSettings.Font.DisplayName ?? string.Empty);
		}
		UpdateAvailableFontSettings(FontGroup);
		CharacterSize = runSettings.CharacterSize;
		CharacterSpacing = runSettings.CharacterSpacing;
		FillType = runSettings.Fill.TextFillType;
		Fill = runSettings.Fill;
		IsStrokeVisible = runSettings.IsStrokeVisible;
		StrokeThickness = runSettings.StrokeThickness;
		StrokeColor = runSettings.StrokeColor;
		Capitalization = runSettings.CapitalizationType;
		LigaturesEnabled = runSettings.LigaturesEnabled;
		IsSuperscript = runSettings.ScriptLevel > 0;
		IsSubscript = runSettings.ScriptLevel < 0;
		SubscriptLevel = (IsSubscript ? runSettings.ScriptLevel : 0).Abs().ToString();
		SuperscriptLevel = (IsSuperscript ? runSettings.ScriptLevel : 0).ToString();
		IsUnderlineEnabled = runSettings.Underline;
		IsStrikethroughEnabled = runSettings.Strikethrough;
		IsUnderlineColorEnabled = runSettings.UnderlineColor.HasValue;
		bool flag = runSettings.StrokeThickness > 0.0 && runSettings.StrokeColor.A > 0;
		UnderlineColor = runSettings.UnderlineColor ?? (flag ? runSettings.StrokeColor : (runSettings.Fill?.PrimaryColor ?? Colors.Transparent));
		HighlightColor = runSettings.HighlightColor ?? Colors.Transparent;
		BulletSizeUpDown.GetBindingExpression(UpDownBase<double?>.ValueProperty)?.UpdateTarget();
		SettingsUpdateInProgress = false;
	}

	protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
	{
		if (e.OriginalSource is FrameworkElement { ContextMenu: null } frameworkElement && !((DependencyObject)(object)frameworkElement).FindAllVisualParents(typeof(ComboBox), typeof(Thumb), typeof(RepeatButton), typeof(TextBox), typeof(ClockTokenTextBox), typeof(TimerTokenTextBox)).Any())
		{
			FocusTextBox();
		}
	}

	private void ColorPicker_Closed(object? sender, RoutedEventArgs e)
	{
		FocusTextBox();
	}

	private void FocusTextBox()
	{
		((DispatcherObject)this).Dispatcher.InvokeAsync((Action)delegate
		{
			FocusTextBoxCommand?.Invoke();
		});
	}

	private void ListPresetChanged(ListPreset oldValue, ListPreset newValue)
	{
		if (!SettingsUpdateInProgress)
		{
			Document?.UndoStack?.BeginCommit(new TaggedUndoAction<Pro.Text.Reversibility.UndoActionTypes>(Pro.Text.Reversibility.UndoActionTypes.AddList));
			Document?.UndoStack?.Commit(this, "ListPreset", oldValue, newValue);
			ApplyListPreset(newValue);
			Document?.UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	private void ApplyListPreset(ListPreset preset)
	{
		int settingsIndex = -1;
		bool isList = preset != ListPreset.None;
		if (isList)
		{
			if ((object)ActiveLevelSettings != null)
			{
				LevelSettings levelSettings = ListPresetFactory.LoadPreset(preset).Levels[0];
				ActiveLevelSettings.BulletType = levelSettings.BulletType;
				ActiveLevelSettings.NumberingScheme = levelSettings.NumberingScheme;
				ActiveLevelSettings.IsBullet = levelSettings.IsBullet;
				ActiveLevelSettings.Prefix = levelSettings.Prefix;
				ActiveLevelSettings.Suffix = levelSettings.Suffix;
			}
			else
			{
				Document?.ListSettingsCollection.AddList(preset, out settingsIndex);
			}
		}
		ApplyParagraphSettings(delegate(ParagraphSettings p, RunSettings r, RangeSelectionType t)
		{
			p.ListIndex = (isList ? Math.Max(p.ListIndex, settingsIndex) : (-1));
			p.LevelIndex = (isList ? Math.Max(0, p.LevelIndex) : (-1));
			Color? bulletColor = p.BulletColor;
			Color valueOrDefault = bulletColor.GetValueOrDefault();
			if (!bulletColor.HasValue)
			{
				valueOrDefault = Fill?.PrimaryColor ?? Colors.Transparent;
				Color? bulletColor2 = valueOrDefault;
				p.BulletColor = bulletColor2;
			}
			p.LeftIndent = (isList ? (1.0 * p.BulletScalar) : 0.0);
			p.FirstLineIndent = (isList ? (25.0 * p.BulletScalar) : 0.0);
			if (isList)
			{
				p.TabStops.AddStop(119.0 * p.BulletScalar);
			}
			else
			{
				p.TabStops.Clear();
			}
		}, Pro.Text.Reversibility.UndoActionTypes.AddList, autoFinalize: true);
		UpdateParagraphSettings();
	}

	private void IsListEnabledChanged(bool isListEnabled)
	{
		ListPreset = (isListEnabled ? DefaultListPreset : ListPreset.None);
	}

	private void ChordsEnabledChanged(bool chordsEnabled)
	{
		ApplyDocumentSettings(delegate(TextDocumentSettings s, RangeSelectionType t)
		{
			s.ChordPro.Enabled = chordsEnabled;
		}, Pro.Text.Reversibility.UndoActionTypes.ChordProEnabled, autoFinalize: true);
	}

	private void ChordColorChanged(Color newColor)
	{
		ApplyDocumentSettings(delegate(TextDocumentSettings s, RangeSelectionType t)
		{
			s.ChordPro.Color = newColor;
			Color oldColor = _app.MultiTracksChordNotationTextColor;
			_app.MultiTracksChordNotationTextColor = newColor;
			Document?.UndoStack?.Commit(delegate
			{
				_app.MultiTracksChordNotationTextColor = oldColor;
			}, delegate
			{
				_app.MultiTracksChordNotationTextColor = newColor;
			});
		}, Pro.Text.Reversibility.UndoActionTypes.ChordProColor, autoFinalize: true);
	}

	private void ChordNotationChanged(ChordProNotationType newNotation)
	{
		ApplyDocumentSettings(delegate(TextDocumentSettings s, RangeSelectionType t)
		{
			s.ChordPro.Notation = newNotation;
		}, Pro.Text.Reversibility.UndoActionTypes.ChordProNotation, autoFinalize: true);
	}

	private void FontGroupChanged(FontGroup? newGroup)
	{
		if (!SettingsUpdateInProgress)
		{
			if (newGroup != null)
			{
				Font = FontHelper.FindFont(FontGroup, IsBoldEnabled, IsItalicEnabled)?.Info ?? newGroup.Fonts.First().Info;
			}
			else
			{
				Font = default(FontInfo);
			}
			UpdateAvailableFontSettings(newGroup);
		}
	}

	private void UpdateAvailableFontSettings(FontGroup? group)
	{
		CanToggleBold = group?.IsBoldAvailable() ?? false;
		CanToggleItalic = group?.IsItalicAvailable() ?? false;
	}

	private void SetMissingFont(string font)
	{
		MissingFont = font ?? "";
	}

	private void IsBoldEnabledChanged(bool isBold)
	{
		if (FontGroup != null && !SettingsUpdateInProgress)
		{
			FontInfo? fontInfo = FontHelper.FindFont(FontGroup, isBold, IsItalicEnabled)?.Info;
			if (!fontInfo.HasValue)
			{
				fontInfo = ((!isBold) ? FontHelper.FindFont(FontGroup, isBold: false, IsItalicEnabled)?.Info : FontHelper.FindFont(FontGroup, isBold, isItalic: false)?.Info);
			}
			_overrideFontUndoActionType = Pro.Text.Reversibility.UndoActionTypes.Bold;
			Font = fontInfo ?? FontGroup.Fonts.First().Info;
			_overrideFontUndoActionType = null;
		}
	}

	private void IsItalicEnabledChanged(bool isItalic)
	{
		if (FontGroup != null && !SettingsUpdateInProgress)
		{
			FontInfo? fontInfo = FontHelper.FindFont(FontGroup, IsBoldEnabled, isItalic)?.Info;
			if (!fontInfo.HasValue)
			{
				fontInfo = ((!isItalic) ? FontHelper.FindFont(FontGroup, IsBoldEnabled, isItalic: false)?.Info : FontHelper.FindFont(FontGroup, isBold: false, isItalic)?.Info);
			}
			_overrideFontUndoActionType = Pro.Text.Reversibility.UndoActionTypes.Italic;
			Font = fontInfo ?? FontGroup.Fonts.First().Info;
			_overrideFontUndoActionType = null;
		}
	}

	private void OnIsUnderlineColorEnabledChanged(bool isEnabled)
	{
		ApplyRunSettings(delegate(RunSettings s, RangeSelectionType t, TextDocument? _)
		{
			s.UnderlineColor = (isEnabled ? new Color?(UnderlineColor) : ((Color?)null));
		}, Pro.Text.Reversibility.UndoActionTypes.UnderlineColorEnabled, autoFinalize: true);
		if (!SettingsUpdateInProgress)
		{
			EventPublisher.Publish(new UnderlineColorEvent(isEnabled, SelectionRanges.ToSelectionType()));
		}
	}

	private void OnHighlightColorChanged(Color? color)
	{
		ApplyRunSettings(delegate(RunSettings s, RangeSelectionType t, TextDocument? _)
		{
			s.HighlightColor = color;
		}, Pro.Text.Reversibility.UndoActionTypes.HighlightColor, autoFinalize: false);
		if (!SettingsUpdateInProgress)
		{
			EventPublisher.Publish(new BackgroundColorEvent(color.ToColorType(), SelectionRanges.ToSelectionType()));
		}
	}

	private void OnFilterTextFillTypes(object? sender, FilterEventArgs e)
	{
		bool accepted = EditMode == EditMode.Presentation || EditMode == EditMode.Template;
		switch ((TextFillType)e.Item)
		{
		case TextFillType.SolidColor:
		case TextFillType.Gradient:
		case TextFillType.CutOut:
		case TextFillType.Media:
			e.Accepted = true;
			break;
		case TextFillType.BackgroundInvert:
		case TextFillType.BackgroundBlur:
			e.Accepted = accepted;
			break;
		}
	}

	private static void OnFillTypePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		TextInspector source = (TextInspector)(object)d;
		TextFillType textFillType = (TextFillType)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		if (!source.SettingsUpdateInProgress)
		{
			source.ChangeTextFillTypeCommand?.Invoke(textFillType);
			((DispatcherObject)source).Dispatcher.InvokeAsync((Action)delegate
			{
				source.SettingsUpdateInProgress = true;
				source.FillType = (source.ActiveRunSettings ?? new RunSettings()).Fill.TextFillType;
				source.SettingsUpdateInProgress = false;
			});
			EventPublisher.Publish(new ForegroundEvent(textFillType.ToFillType(), source.SelectionRanges.ToSelectionType()));
		}
	}

	private void OnTextTransformChanged(TextTransform transform)
	{
		if (!SettingsUpdateInProgress)
		{
			TextTransformEvent.Publish(transform.ToTextTransformType());
		}
		ApplyDocumentSettings(delegate(TextDocumentSettings s, RangeSelectionType t)
		{
			s.Transform = transform;
		}, Pro.Text.Reversibility.UndoActionTypes.DocumentTransform, autoFinalize: true);
	}

	private void Superscript_Click(object? sender, RoutedEventArgs e)
	{
		ApplyScriptLevel((ActiveRunSettings?.ScriptLevel ?? (-1)) + 1);
	}

	private void Subscript_Click(object? sender, RoutedEventArgs e)
	{
		ApplyScriptLevel((ActiveRunSettings?.ScriptLevel ?? (-1)) - 1);
	}

	public void ApplyScriptLevel(int scriptLevel)
	{
		ApplyRunSettings(delegate(RunSettings s, RangeSelectionType t, TextDocument? _)
		{
			s.ScriptLevel = scriptLevel;
		}, Pro.Text.Reversibility.UndoActionTypes.ScriptLevel, autoFinalize: true);
		UpdateRunSettings();
	}

	public void OpenFontSelector()
	{
		if (IsFontFamilySelectionOpen)
		{
			((DependencyObject)this).SetCurrentValue(IsFontFamilySelectionOpenProperty, (object)false);
		}
		((DependencyObject)this).SetCurrentValue(IsFontFamilySelectionOpenProperty, (object)true);
	}

	private void InvalidateCommand(object? sender, RoutedEventArgs e)
	{
		CommandManager.InvalidateRequerySuggested();
	}

	private RangeSelectionType GetRangeSelectionType()
	{
		return SelectionRanges.GetRangeSelectionType(Document);
	}

	private void TextFillType_Click(object? sender, RoutedEventArgs e)
	{
		if (sender is MenuItem { DataContext: var dataContext } && dataContext is TextFillType textFillType)
		{
			((DependencyObject)this).SetCurrentValue(FillTypeProperty, (object)textFillType);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
