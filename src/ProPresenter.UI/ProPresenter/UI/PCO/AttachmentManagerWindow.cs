using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Markup;
using Pro.Common.Win32;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.PCO;

public partial class AttachmentManagerWindow : ChromedWindow, IComponentConnector
{
	public AttachmentManagerWindow()
	{
		InitializeComponent();
		System.Windows.Interop.HwndSource.FromHwnd(new WindowInteropHelper(Application.Current.MainWindow).EnsureHandle()).AddHook(MainWindowWndProc);
	}

	private nint MainWindowWndProc(nint hWnd, int msg, nint wParam, nint lParam, ref bool handled)
	{
		if (msg == 70 && base.IsVisible)
		{
			WINDOWPOS structure = Marshal.PtrToStructure<WINDOWPOS>(lParam);
			structure.HwndInsertAfter = base.Handle;
			Marshal.StructureToPtr(structure, lParam, fDeleteOld: true);
		}
		return IntPtr.Zero;
	}
}
