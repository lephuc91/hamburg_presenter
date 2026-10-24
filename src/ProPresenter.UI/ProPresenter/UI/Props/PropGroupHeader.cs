using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Threading;
using Pro.Common.Time;
using Pro.UI;
using ProPresenter.UI.ViewModels.Props;

namespace ProPresenter.UI.Props;

public partial class PropGroupHeader : UserControl, IComponentConnector
{
	private static readonly TimeSlice CloseDelayInterval = TimeSlice.FromSeconds(SystemParameters.MouseHoverTime.TotalSeconds);

	private bool _shouldClose;

	private bool _canClose = true;

	private readonly DispatcherTimer _closeDelayTimer = new DispatcherTimer
	{
		Interval = CloseDelayInterval
	};

	public PropGroupHeader()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		InitializeComponent();
		DropdownButton.DragEnter += DropdownButton_DragEnter;
		GroupPicker.GroupList_DragEnter += GroupPicker_DragEnter;
		GroupPicker.GroupList_DragLeave += GroupPicker_DragLeave;
		_closeDelayTimer.Tick += CloseDelayTimer_Tick;
	}

	private void DropdownButton_DragEnter(object? sender, DragEventArgs e)
	{
		if (base.DataContext is IPropGroupCollectionVM propGroupCollectionVM && e.Data.GetDataPresent(typeof(DraggedItems<IPropCueVM>)))
		{
			_shouldClose = true;
			propGroupCollectionVM.IsCollectionPopupOpen = true;
		}
	}

	private void GroupPicker_DragEnter(object? sender, DragEventArgs e)
	{
		_canClose = false;
	}

	private void GroupPicker_DragLeave(object? sender, DragEventArgs e)
	{
		_canClose = true;
		if (_shouldClose)
		{
			_closeDelayTimer.Stop();
			_closeDelayTimer.Start();
		}
	}

	private void CloseDelayTimer_Tick(object? sender, EventArgs e)
	{
		_closeDelayTimer.Stop();
		if (_canClose && base.DataContext is IPropGroupCollectionVM propGroupCollectionVM)
		{
			propGroupCollectionVM.IsCollectionPopupOpen = false;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
