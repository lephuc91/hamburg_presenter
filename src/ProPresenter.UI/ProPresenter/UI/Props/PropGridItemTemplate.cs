using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Utility;
using Pro.UI.Utility;
using ProPresenter.DO;
using ProPresenter.DO.PanelSourcing;
using ProPresenter.UI.Thumbnails;
using ProPresenter.UI.ViewModels.Props;

namespace ProPresenter.UI.Props;

public partial class PropGridItemTemplate : UserControl, IUniformViewControl, IComponentConnector
{
	public delegate void PropGridEventDelegate(PropGridItemTemplate thumbnail, ModifierKeys modifierKeys);

	private bool _canToggle;

	public int Index { get; set; }

	public IUniformViewSource? Source
	{
		get
		{
			return base.DataContext as IUniformViewSource;
		}
		set
		{
			base.DataContext = value;
		}
	}

	public bool IsSelected { get; set; }

	public IPanelViewSettings? ViewSettings { get; set; }

	public PropGridEventDelegate? ClickedDelegate { get; set; }

	public PropGridItemTemplate()
	{
		InitializeComponent();
	}

	protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if (e.ChangedButton == MouseButton.Left && !(e.OriginalSource is ButtonBase))
		{
			ClickedDelegate?.Invoke(this, Keyboard.Modifiers);
		}
	}

	public void TearDown()
	{
	}

	protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		if (!KeyboardHelper.IsModifierPressed((ModifierKeys)2) && _canToggle && base.DataContext is IPropCueVM propCueVM)
		{
			propCueVM.Parent?.TogglePropCommand.Invoke<IPropCueVM>(propCueVM);
			e.Handled = true;
		}
		_canToggle = false;
	}

	protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		_canToggle = e.OriginalSource is UIElement depObj && ((DependencyObject)(object)depObj).FindVisualParent<PropsThumbnailView>() != null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
