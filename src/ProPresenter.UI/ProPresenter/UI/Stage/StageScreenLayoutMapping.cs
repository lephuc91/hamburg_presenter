using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.Utility;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;

namespace ProPresenter.UI.Stage;

public partial class StageScreenLayoutMapping : UserControl, IComponentConnector, IStyleConnector
{
	public static readonly DependencyProperty ScreenAssignmentsProperty = DependencyProperty.Register("ScreenAssignments", typeof(StageScreenAssignments), typeof(StageScreenLayoutMapping));

	public static readonly DependencyProperty LayoutsProperty = DependencyProperty.Register("Layouts", typeof(IEnumerable<SlideCue>), typeof(StageScreenLayoutMapping));

	public StageScreenAssignments ScreenAssignments
	{
		get
		{
			return (StageScreenAssignments)((DependencyObject)this).GetValue(ScreenAssignmentsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ScreenAssignmentsProperty, (object)value);
		}
	}

	public IEnumerable<SlideCue> Layouts
	{
		get
		{
			return (IEnumerable<SlideCue>)((DependencyObject)this).GetValue(LayoutsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LayoutsProperty, (object)value);
		}
	}

	public StageScreenLayoutMapping()
	{
		InitializeComponent();
	}

	private void MenuItem_Click(object? sender, RoutedEventArgs e)
	{
		if (sender is MenuItem menuItem && ((DependencyObject)(object)menuItem).FindVisualParent<ContextMenu>()?.PlacementTarget is FrameworkElement { DataContext: StageScreenAssignment dataContext })
		{
			dataContext.Layout = ((menuItem.DataContext is SlideCue slideCue) ? new Identifier(slideCue.ID, slideCue.Name) : null);
		}
	}

	private void LayoutsMenuOpened(object? sender, RoutedEventArgs e)
	{
		if (!(sender is ContextMenu { DataContext: StageScreenAssignment dataContext } contextMenu))
		{
			return;
		}
		foreach (MenuItem item in ((DependencyObject)(object)contextMenu).FindVisualChildren<MenuItem>())
		{
			item.IsChecked = ((item.DataContext is SlideCue slideCue) ? ((object)dataContext.Layout != null && slideCue.ID == dataContext.Layout.ID) : ((object)dataContext.Layout == null));
		}
	}
}
