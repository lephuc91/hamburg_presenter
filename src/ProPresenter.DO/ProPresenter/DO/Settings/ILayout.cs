using System.ComponentModel;
using System.Windows;
using Pro.Common.Mathematics;
using Pro.Common.Win32;

namespace ProPresenter.DO.Settings;

public interface ILayout : INotifyPropertyChanged
{
	GridLength AudioItemViewHeight { get; set; }

	bool AudioOutlineVisible { get; set; }

	GridLength AudioTreeViewHeight { get; set; }

	GridLength BottomRowHeight { get; set; }

	GridLength CanvasColumnWidth { get; set; }

	GridLength CanvasRowHeight { get; set; }

	GridLength ElementViewerRowHeight { get; set; }

	GridLength GoferHeight { get; set; }

	bool IsMainPositionSaved { get; set; }

	bool IsPdfViewerPositionSaved { get; set; }

	GridLength ItemsHeight { get; set; }

	GridLength LeftColumnWidth { get; set; }

	bool LibraryCollapsed { get; set; }

	GridLength LibraryHeight { get; set; }

	GridLength LibraryWidth { get; set; }

	GridLength MainViewWidth { get; set; }

	Rect<int> MainWindowRect { get; set; }

	SW MainWindowState { get; set; }

	GridLength MediaLeftWidth { get; set; }

	bool MediaLibraryCollapsed { get; set; }

	bool MediaPlaylistsCollapsed { get; set; }

	GridLength MediaRightWidth { get; set; }

	GridLength MessageDetailHeight { get; set; }

	bool MessageDetailVisible { get; set; }

	GridLength MessageOutlineHeight { get; set; }

	bool MessagesOutlineVisible { get; set; }

	Rect<int> PdfViewerWindowRect { get; set; }

	SW PdfViewerWindowState { get; set; }

	int PreferencesWindowSelectedTab { get; set; }

	GridLength PreviewColumnWidth { get; set; }

	GridLength PreviewHeight { get; set; }

	GridLength PreviewRowHeight { get; set; }

	bool ProContentOutlineVisible { get; set; }

	GridLength RightColumnWidth { get; set; }

	GridLength SlideNotesRowHeight { get; set; }

	bool SlideNotesVisible { get; set; }

	GridLength TopRowHeight { get; set; }
}
