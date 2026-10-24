using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.UI.Components;
using Pro.UI.Controls;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI.CueInspector;

public partial class PlaybackMarkerContextMenuSource : FrameworkCollection, IComponentConnector
{
	private AnchoredPopup? _popup;

	public static readonly DependencyProperty UsePopupRenameProperty = DependencyProperty.Register("UsePopupRename", typeof(bool), typeof(PlaybackMarkerContextMenuSource), new PropertyMetadata((object)false));

	public static readonly DependencyProperty MarkerNameProperty = DependencyProperty.Register("MarkerName", typeof(string), typeof(PlaybackMarkerContextMenuSource), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty MarkerColorProperty = DependencyProperty.Register("MarkerColor", typeof(Color), typeof(PlaybackMarkerContextMenuSource), new PropertyMetadata((object)default(Color)));

	public static readonly DependencyProperty MoveToPlayheadCommandProperty = DependencyProperty.Register("MoveToPlayheadCommand", typeof(ICommand), typeof(PlaybackMarkerContextMenuSource));

	public static readonly DependencyProperty ActionsMenuVMProperty = DependencyProperty.Register("ActionsMenuVM", typeof(IActionsMenuVM), typeof(PlaybackMarkerContextMenuSource));

	public static readonly DependencyProperty ContextMenuTargetProperty = DependencyProperty.Register("ContextMenuTarget", typeof(FrameworkElement), typeof(PlaybackMarkerContextMenuSource));

	private static readonly DependencyProperty ShowRenamePopupCommandProperty = DependencyProperty.Register("ShowRenamePopupCommand", typeof(ICommand<AnchoredPopup>), typeof(PlaybackMarkerContextMenuSource));

	public bool UsePopupRename
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(UsePopupRenameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(UsePopupRenameProperty, (object)value);
		}
	}

	public string MarkerName
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(MarkerNameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MarkerNameProperty, (object)value);
		}
	}

	public Color MarkerColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(MarkerColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MarkerColorProperty, (object)value);
		}
	}

	public ICommand? MoveToPlayheadCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(MoveToPlayheadCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MoveToPlayheadCommandProperty, (object)value);
		}
	}

	public IActionsMenuVM? ActionsMenuVM
	{
		get
		{
			return (IActionsMenuVM)((DependencyObject)this).GetValue(ActionsMenuVMProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActionsMenuVMProperty, (object)value);
		}
	}

	public FrameworkElement? ContextMenuTarget
	{
		get
		{
			return (FrameworkElement)((DependencyObject)this).GetValue(ContextMenuTargetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ContextMenuTargetProperty, (object)value);
		}
	}

	private ICommand<AnchoredPopup>? ShowRenamePopupCommand
	{
		get
		{
			return (ICommand<AnchoredPopup>)((DependencyObject)this).GetValue(ShowRenamePopupCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowRenamePopupCommandProperty, (object)value);
		}
	}

	public PlaybackMarkerContextMenuSource()
	{
		InitializeComponent();
		((DependencyObject)this).SetCurrentValue(ShowRenamePopupCommandProperty, (object)new RelayCommand<AnchoredPopup>(ShowRenamePopupCommandExecuted));
	}

	private void ShowRenamePopupCommandExecuted(AnchoredPopup popup)
	{
		_popup = popup;
		popup.PlacementTarget = ContextMenuTarget;
		popup.IsOpen = true;
		TextBox textBox = ((DependencyObject)(object)popup.Child)?.FindVisualChild<TextBox>();
		if (textBox != null)
		{
			textBox.Text = MarkerName;
			textBox.Focus();
			textBox.SelectAll();
		}
	}

	private void MarkerName_KeyDown(object? sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if ((int)e.Key == 6 && _popup != null)
		{
			_popup.IsOpen = false;
		}
	}

	private void MarkerName_KeyboardLostFocus(object? sender, KeyboardFocusChangedEventArgs e)
	{
		if (sender is TextBox textBox)
		{
			((DependencyObject)this).SetCurrentValue(MarkerNameProperty, (object)textBox.Text);
		}
	}

	private void MarkerName_LostFocus(object? sender, RoutedEventArgs e)
	{
		if (sender is TextBox textBox)
		{
			((DependencyObject)this).SetCurrentValue(MarkerNameProperty, (object)textBox.Text);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
