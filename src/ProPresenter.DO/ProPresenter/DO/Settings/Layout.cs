using System.ComponentModel;
using System.IO;
using System.Windows;
using Pro.Common.DataStore;
using Pro.Common.Mathematics;
using Pro.Common.Win32;

namespace ProPresenter.DO.Settings;

public class Layout : StoreBase, ILayout, INotifyPropertyChanged
{
	private const string SettingsFile = "LayoutPreferences.proPref";

	public const double MainWindowMinHeight = 688.0;

	public const double MainWindowMinWidth = 1280.0;

	public static readonly double LeftColumnMinWidth = 960.0;

	public const double RightColumnMinWidth = 300.0;

	public const double TopRowMinHeight = 200.0;

	public const double LibraryMinWidth = 160.0;

	public const double MainViewMinWidth = 800.0;

	public const double PresentationViewRowMinHeight = 160.0;

	public const double EditorSlidePreviewColumnMinWidth = 150.0;

	public const double EditorCanvasColumnMinWidth = 800.0;

	public const double EditorBuildOrderInspectorTopRowMinHeight = 315.0;

	public const double EditorBuildOrderInspectorBottomRowMinHeight = 200.0;

	public static Layout Settings { get; } = new Layout();

	public GridLength LeftColumnWidth
	{
		get
		{
			return GetValue("LeftColumnWidth", new GridLength(8.0, GridUnitType.Star));
		}
		set
		{
			SetValue("LeftColumnWidth", value);
			OnPropertyChanged("LeftColumnWidth");
		}
	}

	public GridLength RightColumnWidth
	{
		get
		{
			return GetValue("RightColumnWidth", new GridLength(2.0, GridUnitType.Star));
		}
		set
		{
			SetValue("RightColumnWidth", value);
			OnPropertyChanged("RightColumnWidth");
		}
	}

	public GridLength TopRowHeight
	{
		get
		{
			return GetValue("TopRowHeight", new GridLength(7.5, GridUnitType.Star));
		}
		set
		{
			SetValue("TopRowHeight", value);
			OnPropertyChanged("TopRowHeight");
		}
	}

	public GridLength BottomRowHeight
	{
		get
		{
			if (!MediaLibraryCollapsed)
			{
				return GetValue("BottomRowHeight", new GridLength(2.5, GridUnitType.Star));
			}
			return new GridLength(0.0);
		}
		set
		{
			SetValue("BottomRowHeight", value);
			OnPropertyChanged("BottomRowHeight");
		}
	}

	public GridLength LibraryWidth
	{
		get
		{
			return GetValue("LibraryWidth", new GridLength(12.5, GridUnitType.Star));
		}
		set
		{
			SetValue("LibraryWidth", value);
			OnPropertyChanged("LibraryWidth");
		}
	}

	public GridLength LibraryHeight
	{
		get
		{
			if (!LibraryCollapsed)
			{
				return GetValue("LibraryHeight", new GridLength(3.5, GridUnitType.Star));
			}
			return new GridLength(0.0);
		}
		set
		{
			SetValue("LibraryHeight", value);
			OnPropertyChanged("LibraryHeight");
		}
	}

	public bool LibraryCollapsed
	{
		get
		{
			return GetValue("LibraryCollapsed", defaultValue: false);
		}
		set
		{
			SetValue("LibraryCollapsed", value);
			OnPropertyChanged("LibraryCollapsed");
			OnPropertyChanged("LibraryHeight");
		}
	}

	public GridLength MainViewWidth
	{
		get
		{
			return GetValue("MainViewWidth", new GridLength(87.5, GridUnitType.Star));
		}
		set
		{
			SetValue("MainViewWidth", value);
			OnPropertyChanged("MainViewWidth");
		}
	}

	public GridLength ItemsHeight
	{
		get
		{
			return GetValue("ItemsHeight", new GridLength(6.5, GridUnitType.Star));
		}
		set
		{
			SetValue("ItemsHeight", value);
			OnPropertyChanged("ItemsHeight");
		}
	}

	public GridLength MediaLeftWidth
	{
		get
		{
			if (!MediaPlaylistsCollapsed)
			{
				return GetValue("MediaLeftWidth", new GridLength(12.5, GridUnitType.Star));
			}
			return new GridLength(0.0);
		}
		set
		{
			SetValue("MediaLeftWidth", value);
			OnPropertyChanged("MediaLeftWidth");
		}
	}

	public GridLength MediaRightWidth
	{
		get
		{
			return GetValue("MediaRightWidth", new GridLength(87.5, GridUnitType.Star));
		}
		set
		{
			SetValue("MediaRightWidth", value);
			OnPropertyChanged("MediaRightWidth");
		}
	}

	public GridLength PreviewHeight
	{
		get
		{
			return GetValue("PreviewHeight", new GridLength(1.0, GridUnitType.Star));
		}
		set
		{
			SetValue("PreviewHeight", value);
			OnPropertyChanged("PreviewHeight");
		}
	}

	public GridLength GoferHeight
	{
		get
		{
			return GetValue("GoferHeight", new GridLength(2.0, GridUnitType.Star));
		}
		set
		{
			SetValue("GoferHeight", value);
			OnPropertyChanged("GoferHeight");
		}
	}

	public bool AudioOutlineVisible
	{
		get
		{
			return GetValue("AudioOutlineVisible", defaultValue: true);
		}
		set
		{
			SetValue("AudioOutlineVisible", value);
			OnPropertyChanged("AudioOutlineVisible");
			OnPropertyChanged("AudioTreeViewHeight");
		}
	}

	public GridLength AudioTreeViewHeight
	{
		get
		{
			if (!AudioOutlineVisible)
			{
				return new GridLength(0.0, GridUnitType.Star);
			}
			return GetValue("AudioTreeViewHeight", new GridLength(3.5, GridUnitType.Star));
		}
		set
		{
			SetValue("AudioTreeViewHeight", value);
			OnPropertyChanged("AudioTreeViewHeight");
		}
	}

	public GridLength AudioItemViewHeight
	{
		get
		{
			return GetValue("AudioItemViewHeight", new GridLength(6.5, GridUnitType.Star));
		}
		set
		{
			SetValue("AudioItemViewHeight", value);
			OnPropertyChanged("AudioItemViewHeight");
		}
	}

	public bool MessagesOutlineVisible
	{
		get
		{
			return GetValue("MessagesOutlineVisible", defaultValue: true);
		}
		set
		{
			SetValue("MessagesOutlineVisible", value);
			OnPropertyChanged("MessagesOutlineVisible");
		}
	}

	public GridLength MessageOutlineHeight
	{
		get
		{
			if (!MessagesOutlineVisible)
			{
				return new GridLength(0.0, GridUnitType.Star);
			}
			return GetValue("MessageOutlineHeight", new GridLength(1.0, GridUnitType.Star));
		}
		set
		{
			SetValue("MessageOutlineHeight", value);
			OnPropertyChanged("MessageOutlineHeight");
		}
	}

	public GridLength MessageDetailHeight
	{
		get
		{
			return GetValue("MessageDetailHeight", new GridLength(4.0, GridUnitType.Star));
		}
		set
		{
			SetValue("MessageDetailHeight", value);
			OnPropertyChanged("MessageDetailHeight");
		}
	}

	public bool MessageDetailVisible
	{
		get
		{
			return GetValue("MessageDetailVisible", defaultValue: true);
		}
		set
		{
			SetValue("MessageDetailVisible", value);
			OnPropertyChanged("MessageDetailVisible");
		}
	}

	public bool MediaLibraryCollapsed
	{
		get
		{
			return GetValue("MediaLibraryCollapsed", defaultValue: false);
		}
		set
		{
			SetValue("MediaLibraryCollapsed", value);
			OnPropertyChanged("MediaLibraryCollapsed");
			OnPropertyChanged("BottomRowHeight");
		}
	}

	public bool MediaPlaylistsCollapsed
	{
		get
		{
			return GetValue("MediaPlaylistsCollapsed", defaultValue: false);
		}
		set
		{
			SetValue("MediaPlaylistsCollapsed", value);
			OnPropertyChanged("MediaPlaylistsCollapsed");
			OnPropertyChanged("MediaLeftWidth");
		}
	}

	public bool IsMainPositionSaved
	{
		get
		{
			return GetValue("IsMainPositionSaved", defaultValue: false);
		}
		set
		{
			SetValue("IsMainPositionSaved", value);
			OnPropertyChanged("IsMainPositionSaved");
		}
	}

	public SW MainWindowState
	{
		get
		{
			return GetValue("MainWindowState", SW.SHOWNORMAL);
		}
		set
		{
			SetValue("MainWindowState", value);
			OnPropertyChanged("MainWindowState");
		}
	}

	public Rect<int> MainWindowRect
	{
		get
		{
			return GetValue("MainWindowRect", Rect<int>.Empty);
		}
		set
		{
			SetValue("MainWindowRect", value);
			OnPropertyChanged("MainWindowRect");
		}
	}

	public bool IsPdfViewerPositionSaved
	{
		get
		{
			return GetValue("IsPdfViewerPositionSaved", defaultValue: false);
		}
		set
		{
			SetValue("IsPdfViewerPositionSaved", value);
			OnPropertyChanged("IsPdfViewerPositionSaved");
		}
	}

	public SW PdfViewerWindowState
	{
		get
		{
			return GetValue("PdfViewerWindowState", SW.SHOWNORMAL);
		}
		set
		{
			SetValue("PdfViewerWindowState", value);
			OnPropertyChanged("PdfViewerWindowState");
		}
	}

	public Rect<int> PdfViewerWindowRect
	{
		get
		{
			return GetValue("PdfViewerWindowRect", Rect<int>.Empty);
		}
		set
		{
			SetValue("PdfViewerWindowRect", value);
			OnPropertyChanged("PdfViewerWindowRect");
		}
	}

	public int PreferencesWindowSelectedTab
	{
		get
		{
			return GetValue("PreferencesWindowSelectedTab", 0);
		}
		set
		{
			SetValue("PreferencesWindowSelectedTab", value);
			OnPropertyChanged("PreferencesWindowSelectedTab");
		}
	}

	public GridLength PreviewColumnWidth
	{
		get
		{
			return GetValue("PreviewColumnWidth", new GridLength(1.0, GridUnitType.Star));
		}
		set
		{
			SetValue("PreviewColumnWidth", value);
			OnPropertyChanged("PreviewColumnWidth");
		}
	}

	public GridLength CanvasColumnWidth
	{
		get
		{
			return GetValue("CanvasColumnWidth", new GridLength(9.0, GridUnitType.Star));
		}
		set
		{
			SetValue("CanvasColumnWidth", value);
			OnPropertyChanged("CanvasColumnWidth");
		}
	}

	public GridLength CanvasRowHeight
	{
		get
		{
			return GetValue("CanvasRowHeight", new GridLength(7.5, GridUnitType.Star));
		}
		set
		{
			SetValue("CanvasRowHeight", value);
			OnPropertyChanged("CanvasRowHeight");
		}
	}

	public GridLength SlideNotesRowHeight
	{
		get
		{
			if (SlideNotesVisible)
			{
				return GetValue("SlideNotesRowHeight", new GridLength(2.5, GridUnitType.Star));
			}
			return new GridLength(0.0);
		}
		set
		{
			SetValue("SlideNotesRowHeight", value);
			OnPropertyChanged("SlideNotesRowHeight");
		}
	}

	public bool SlideNotesVisible
	{
		get
		{
			return GetValue("SlideNotesVisible", defaultValue: false);
		}
		set
		{
			SetValue("SlideNotesVisible", value);
			OnPropertyChanged("SlideNotesVisible");
			OnPropertyChanged("SlideNotesRowHeight");
		}
	}

	public GridLength PreviewRowHeight
	{
		get
		{
			return GetValue("PreviewRowHeight", new GridLength(7.5, GridUnitType.Star));
		}
		set
		{
			SetValue("PreviewRowHeight", value);
			OnPropertyChanged("PreviewRowHeight");
		}
	}

	public GridLength ElementViewerRowHeight
	{
		get
		{
			return GetValue("ElementViewerRowHeight", new GridLength(2.5, GridUnitType.Star));
		}
		set
		{
			SetValue("ElementViewerRowHeight", value);
			OnPropertyChanged("ElementViewerRowHeight");
		}
	}

	public bool ProContentOutlineVisible
	{
		get
		{
			return GetValue("ProContentOutlineVisible", defaultValue: true);
		}
		set
		{
			SetValue("ProContentOutlineVisible", value);
			OnPropertyChanged("ProContentOutlineVisible");
		}
	}

	private Layout()
		: base(Path.Combine(CommonPaths.Preferences, "LayoutPreferences.proPref"))
	{
		RegisterEnumType<SW>();
		RegisterCustomType((GridLength g) => g.Value.ToString(), (string v) => new GridLength(double.Parse(v), GridUnitType.Star));
	}
}
