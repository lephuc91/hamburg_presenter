using System.IO;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.DataStore;

namespace ProPresenter.DO.Settings;

public class EditorPreferences : StoreBase
{
	private const string SettingsFile = "EditorPreferences.proPref";

	private static EditorPreferences _settings = new EditorPreferences();

	public static EditorPreferences Settings => _settings;

	public Color SlideGuidelineColor
	{
		get
		{
			return GetValue("SlideGuidelineColor", Colors.Yellow);
		}
		set
		{
			SetValue("SlideGuidelineColor", value);
			OnPropertyChanged("SlideGuidelineColor");
		}
	}

	public Color TemplateGuidelineColor
	{
		get
		{
			return GetValue("TemplateGuidelineColor", Colors.Red);
		}
		set
		{
			SetValue("TemplateGuidelineColor", value);
			OnPropertyChanged("TemplateGuidelineColor");
		}
	}

	public Color AlignmentGuidelineColor
	{
		get
		{
			return GetValue("AlignmentGuidelineColor", Colors.Red);
		}
		set
		{
			SetValue("AlignmentGuidelineColor", value);
			OnPropertyChanged("AlignmentGuidelineColor");
		}
	}

	public bool ScaleToFit
	{
		get
		{
			return GetValue("ScaleToFit", defaultValue: true);
		}
		set
		{
			SetValue("ScaleToFit", value);
			OnPropertyChanged("ScaleToFit");
		}
	}

	public bool ShowSlideGuidelines
	{
		get
		{
			return GetValue("ShowSlideGuidelines", defaultValue: true);
		}
		set
		{
			SetValue("ShowSlideGuidelines", value);
			OnPropertyChanged("ShowSlideGuidelines");
		}
	}

	public bool ShowTemplateGuidelines
	{
		get
		{
			return GetValue("ShowTemplateGuidelines", defaultValue: true);
		}
		set
		{
			SetValue("ShowTemplateGuidelines", value);
			OnPropertyChanged("ShowTemplateGuidelines");
		}
	}

	public bool ShowRelativeSpacingGuidelines
	{
		get
		{
			return GetValue("ShowRelativeSpacingGuidelines", defaultValue: true);
		}
		set
		{
			SetValue("ShowRelativeSpacingGuidelines", value);
			OnPropertyChanged("ShowRelativeSpacingGuidelines");
		}
	}

	public bool ShowRelativeSizingGuidelines
	{
		get
		{
			return GetValue("ShowRelativeSizingGuidelines", defaultValue: true);
		}
		set
		{
			SetValue("ShowRelativeSizingGuidelines", value);
			OnPropertyChanged("ShowRelativeSizingGuidelines");
		}
	}

	public bool ShowCenterAlignmentGuidelines
	{
		get
		{
			return GetValue("ShowCenterAlignmentGuidelines", defaultValue: true);
		}
		set
		{
			SetValue("ShowCenterAlignmentGuidelines", value);
			OnPropertyChanged("ShowCenterAlignmentGuidelines");
		}
	}

	public bool ShowEdgeAlignmentGuidelines
	{
		get
		{
			return GetValue("ShowEdgeAlignmentGuidelines", defaultValue: true);
		}
		set
		{
			SetValue("ShowEdgeAlignmentGuidelines", value);
			OnPropertyChanged("ShowEdgeAlignmentGuidelines");
		}
	}

	public bool ShowRuler
	{
		get
		{
			return GetValue("ShowRuler", defaultValue: true);
		}
		set
		{
			SetValue("ShowRuler", value);
			OnPropertyChanged("ShowRuler");
		}
	}

	public double ZoomFactor
	{
		get
		{
			return GetValue("ZoomFactor", 1.0);
		}
		set
		{
			SetValue("ZoomFactor", value);
			OnPropertyChanged("ZoomFactor");
		}
	}

	public bool ShowCanvasGrid
	{
		get
		{
			return GetValue("ShowCanvasGrid", defaultValue: false);
		}
		set
		{
			SetValue("ShowCanvasGrid", value);
			OnPropertyChanged("ShowCanvasGrid");
		}
	}

	public Color CanvasGridColor
	{
		get
		{
			return GetValue("CanvasGridColor", Colors.Gray);
		}
		set
		{
			SetValue("CanvasGridColor", value);
			OnPropertyChanged("CanvasGridColor");
		}
	}

	public double CanvasGridSpacing
	{
		get
		{
			return GetValue("CanvasGridSpacing", 120.0);
		}
		set
		{
			SetValue("CanvasGridSpacing", value);
			OnPropertyChanged("CanvasGridSpacing");
		}
	}

	public int CanvasGridSubdivisions
	{
		get
		{
			return GetValue("CanvasGridSubdivisions", 3);
		}
		set
		{
			SetValue("CanvasGridSubdivisions", value);
			OnPropertyChanged("CanvasGridSubdivisions");
		}
	}

	public ObservableDictionary<EditMode, bool> ShowCheckerboard => GetValue("ShowCheckerboard", GetDefaultShowCheckerboard());

	public Color SlideNoteBackground
	{
		get
		{
			return GetValue("SlideNoteBackground", Colors.DarkGray);
		}
		set
		{
			SetValue("SlideNoteBackground", value);
			OnPropertyChanged("SlideNoteBackground");
		}
	}

	public bool ShowSlideNotesRuler
	{
		get
		{
			return GetValue("ShowSlideNotesRuler", defaultValue: true);
		}
		set
		{
			SetValue("ShowSlideNotesRuler", value);
			OnPropertyChanged("ShowSlideNotesRuler");
		}
	}

	public double OverlayEditorZoomFactor
	{
		get
		{
			return GetValue("OverlayEditorZoomFactor", 1.0);
		}
		set
		{
			SetValue("OverlayEditorZoomFactor", value);
			OnPropertyChanged("OverlayEditorZoomFactor");
		}
	}

	private EditorPreferences()
		: base(Path.Combine(CommonPaths.Preferences, "EditorPreferences.proPref"))
	{
		RegisterEnumType<EditMode>();
		RegisterDictionaryType<EditMode, bool, ObservableDictionary<EditMode, bool>>();
		if (ShowCheckerboard != null)
		{
			ShowCheckerboard.CollectionChanged += delegate
			{
				SetValue("ShowCheckerboard", ShowCheckerboard);
			};
		}
	}

	private ObservableDictionary<EditMode, bool> GetDefaultShowCheckerboard()
	{
		return new ObservableDictionary<EditMode, bool> { [EditMode.Mask] = true };
	}
}
