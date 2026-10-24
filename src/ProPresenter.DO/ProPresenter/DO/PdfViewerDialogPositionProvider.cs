using Pro.Common.Mathematics;
using Pro.Common.Win32;
using Pro.UI.Components;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO;

public class PdfViewerDialogPositionProvider : IDialogPositionProvider
{
	public bool IsPositionSaved
	{
		get
		{
			return Layout.Settings.IsPdfViewerPositionSaved;
		}
		set
		{
			Layout.Settings.IsPdfViewerPositionSaved = value;
		}
	}

	public SW LastWindowState
	{
		get
		{
			return Layout.Settings.PdfViewerWindowState;
		}
		set
		{
			Layout.Settings.PdfViewerWindowState = value;
		}
	}

	public Rect<int> LastWindowRect
	{
		get
		{
			return Layout.Settings.PdfViewerWindowRect;
		}
		set
		{
			Layout.Settings.PdfViewerWindowRect = value;
		}
	}
}
