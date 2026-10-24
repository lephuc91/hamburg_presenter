using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Pro.Common.Components;
using Pro.UI.Commands;
using Pro.UI.Components;
using Pro.UI.Controls;
using Pro.UI.Utility;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.OutputConfiguration;

public class ScreenSelectionListBox : DragDropListBox<ScreenArrangementBase>
{
	public static readonly DependencyProperty DeleteCommandProperty = DependencyProperty.Register("DeleteCommand", typeof(ICommand<ScreenArrangementBase>), typeof(ScreenSelectionListBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, (PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ScreenSelectionListBox)(object)s).OnDeleteCommandChanged(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ICommand<ScreenArrangementBase>);
	}));

	protected override IDragDropCollection<ScreenArrangementBase>? SourceCollection => ScreenArragementCollection;

	private ScreenArrangementCollectionBase? ScreenArragementCollection => base.ItemsSource as ScreenArrangementCollectionBase;

	public ICommand<ScreenArrangementBase> DeleteCommand
	{
		get
		{
			return (ICommand<ScreenArrangementBase>)((DependencyObject)this).GetValue(DeleteCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DeleteCommandProperty, (object)value);
		}
	}

	private void OnDeleteCommandChanged(ICommand<ScreenArrangementBase>? command)
	{
		if (command != null)
		{
			base.CommandBindings.Add(CommonApplicationCommands.Delete, delegate(ScreenArrangementBase? p)
			{
				command.Execute((ScreenArrangementBase)(p ?? base.SelectedItem));
			}, (ScreenArrangementBase? p) => command.CanExecute((ScreenArrangementBase)(p ?? base.SelectedItem)));
		}
	}

	public ScreenSelectionListBox()
	{
		AddDropType((IEnumerable<ScreenArrangementBase> i) => i, IsDropValid);
	}

	private bool IsDropValid(IEnumerable<ScreenArrangementBase> draggedItems, DragEventArgs e)
	{
		return draggedItems.All((ScreenArrangementBase i) => i.ScreenTargetType == ScreenArragementCollection?.TargetType);
	}

	protected override void OnUpdateSelection(ScreenArrangementBase item)
	{
		ScreenSelectionControl screenSelectionControl = ((DependencyObject)(object)this).FindVisualParent<ScreenSelectionControl>();
		if (screenSelectionControl == null || screenSelectionControl.ShouldAllowSelectionChange(item))
		{
			base.OnUpdateSelection(item);
		}
	}
}
