using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.DO.Transitions;
using Pro.UI.Components;
using Pro.UI.DependencyInjection;
using Pro.UI.Utility;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO.Media;
using ProPresenter.UI.ViewModels.MediaLibrary;

namespace ProPresenter.UI.MediaLibrary;

public partial class MediaPlaylistView : UserControl, IComponentConnector
{
	private readonly IMediaActionService _mediaActionService;

	public static readonly DependencyProperty OutputControllerProperty = DependencyProperty.Register("OutputController", typeof(ssAPIOutput), typeof(MediaPlaylistView));

	public static readonly DependencyProperty SortMediaItemsCommandProperty = DependencyProperty.Register("SortMediaItemsCommand", typeof(ICommand<SortMediaItemsCommandParameter>), typeof(MediaPlaylistView));

	public static readonly DependencyProperty GotFocusCommandProperty = DependencyProperty.Register("GotFocusCommand", typeof(ICommand), typeof(MediaPlaylistView));

	public static readonly DependencyProperty SetMediaTransitionCommandProperty = DependencyProperty.Register("SetMediaTransitionCommand", typeof(ICommand<TransitionParameters>), typeof(MediaPlaylistView));

	public static readonly DependencyProperty MediaContextMenuPlacementTargetProperty = DependencyProperty.Register("MediaContextMenuPlacementTarget", typeof(UIElement), typeof(MediaPlaylistView));

	public ssAPIOutput? OutputController
	{
		get
		{
			return (ssAPIOutput)((DependencyObject)this).GetValue(OutputControllerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OutputControllerProperty, (object)value);
		}
	}

	public ICommand<SortMediaItemsCommandParameter>? SortMediaItemsCommand
	{
		get
		{
			return (ICommand<SortMediaItemsCommandParameter>)((DependencyObject)this).GetValue(SortMediaItemsCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SortMediaItemsCommandProperty, (object)value);
		}
	}

	public ICommand? GotFocusCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(GotFocusCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(GotFocusCommandProperty, (object)value);
		}
	}

	public ICommand<TransitionParameters>? SetMediaTransitionCommand
	{
		get
		{
			return (ICommand<TransitionParameters>)((DependencyObject)this).GetValue(SetMediaTransitionCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SetMediaTransitionCommandProperty, (object)value);
		}
	}

	private UIElement? MediaContextMenuPlacementTarget
	{
		get
		{
			return (UIElement)((DependencyObject)this).GetValue(MediaContextMenuPlacementTargetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MediaContextMenuPlacementTargetProperty, (object)value);
		}
	}

	public MediaPlaylistView()
	{
		InitializeComponent();
		_mediaActionService = UIServiceProvider.GetService<IMediaActionService>();
	}

	private void Transitions_Click(object? sender, RoutedEventArgs e)
	{
		UIElement placementTarget = ((DependencyObject)(object)(sender as MenuItem))?.FindVisualParent<ContextMenu>()?.PlacementTarget;
		_mediaActionService.SetTransition((base.DataContext as IMediaLibraryVM)?.SelectedMediaCueTransition, placementTarget, delegate(TransitionParameters t)
		{
			SetMediaTransitionCommand?.Invoke(t);
		});
	}

	private void Control_RequestBringIntoView(object? sender, RequestBringIntoViewEventArgs e)
	{
		e.Handled = true;
	}

	private void Sort_Click(object? sender, RoutedEventArgs e)
	{
		if ((e.OriginalSource as MenuItem)?.DataContext is VisualSortType sortType)
		{
			SortMediaItemsCommand?.Invoke(new SortMediaItemsCommandParameter(sortType, isAscending: true));
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
