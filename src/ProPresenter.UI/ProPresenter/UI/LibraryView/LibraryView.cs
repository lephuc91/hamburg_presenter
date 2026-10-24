using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Controls;
using Pro.UI.Utility;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ViewModels.Library;
using ProPresenter.UI.ViewModels.Library.Cue;

namespace ProPresenter.UI.LibraryView;

public partial class LibraryView : UserControl, IComponentConnector, IStyleConnector
{
	private const double DragCollapseThreshold = 100.0;

	private ILibraryVM? LibraryVM => base.DataContext as ILibraryVM;

	public LibraryView()
	{
		InitializeComponent();
	}

	protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		LibraryVM?.GotFocusCommand?.Invoke((DependencyObject)e.NewFocus);
	}

	private void ContextMenu_Opened(object? sender, RoutedEventArgs e)
	{
		if (sender is ContextMenu contextMenu)
		{
			contextMenu.Items.Refresh();
		}
	}

	private void LibrarySplitter_DragDelta(object? sender, DragDeltaEventArgs e)
	{
		if (e.VerticalChange <= -100.0)
		{
			Layout.Settings.LibraryCollapsed = true;
		}
		else if (e.VerticalChange >= 100.0)
		{
			Layout.Settings.LibraryCollapsed = false;
		}
	}

	private void ReflowMenuItemClick(object? sender, RoutedEventArgs e)
	{
		if (LibraryVM != null && sender is MenuItem { DataContext: IProPresenterCueVM dataContext })
		{
			LibraryVM.ReflowTargetCue = dataContext;
		}
	}

	private void LibraryListBox_NavigationCrested(bool isDown)
	{
		if (LibraryVM?.LibraryNavigationCrestedCommand?.Invoke(isDown) == true)
		{
			PlaylistTreeView.Focus();
		}
	}

	private void PlaylistTreeView_NavigationCrested(bool isDown)
	{
		if (LibraryVM?.PlaylistNavigationCrestedCommand?.Invoke(isDown) == true)
		{
			LibraryListBox.Focus();
		}
	}

	private void OnNewLibraryClick(object? sender, RoutedEventArgs e)
	{
		LibraryCreateEvent.Publish(LibraryCreateSource.OutlineAddButton);
	}

	private void OnNewPresentationClick(object? sender, RoutedEventArgs e)
	{
		PresentationCreateEvent.Publish(PresentationCreateSource.OutlineAddButton);
	}

	private void OnNewGeneralPlaylistClick(object? sender, RoutedEventArgs e)
	{
		PlaylistCreateEvent.Publish(PlaylistCreateSource.OutlineAddButton, PlaylistCreateType.General);
	}

	private void OnNewGroupPlaylistClick(object? sender, RoutedEventArgs e)
	{
		PlaylistCreateEvent.Publish(PlaylistCreateSource.OutlineAddButton, PlaylistCreateType.Group);
	}

	private void OnNewPCOPlaylistClick(object? sender, RoutedEventArgs e)
	{
		PlaylistCreateEvent.Publish(PlaylistCreateSource.OutlineAddButton, PlaylistCreateType.PCO);
	}

	private void OnNewPlaylistFromTemplateClick(object? sender, RoutedEventArgs e)
	{
		PlaylistCreateEvent.Publish(PlaylistCreateSource.OutlineAddButton, PlaylistCreateType.Template);
	}

	private void Rename_Click(object? sender, RoutedEventArgs e)
	{
		if (Layout.Settings.LibraryCollapsed)
		{
			ActiveItemTb.EnterEditMode();
			return;
		}
		FrameworkElement frameworkElement = null;
		if (LibraryVM?.ActivePlaylist != null)
		{
			frameworkElement = ((DependencyObject)(object)PlaylistTreeView).FindVisualChild((FrameworkElement d) => d.DataContext == LibraryVM.ActivePlaylist);
		}
		else if (LibraryVM?.ActiveLibrary != null)
		{
			frameworkElement = LibraryListBox.ItemContainerGenerator.ContainerFromItem(LibraryVM.ActiveLibrary) as FrameworkElement;
		}
		((DependencyObject)(object)frameworkElement)?.FindVisualChild<EditableTextBlock>()?.EnterEditMode();
	}

	private void Grid_PreviewMouseDown(object? sender, MouseButtonEventArgs e)
	{
		if (sender is Grid { ContextMenu: not null } grid && e.ChangedButton == MouseButton.Right)
		{
			grid.ContextMenu.IsOpen = true;
			e.Handled = true;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
