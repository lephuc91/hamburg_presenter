using System.Collections.Specialized;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Common.Collections;
using Pro.UI.Commands;
using Pro.UI.Components;
using ProPresenter.UI.ViewModels.Preview;

namespace ProPresenter.UI.Preview;

public partial class WindowedOutputMenuItem : MenuItem, IComponentConnector
{
	public WindowedOutputMenuItem()
	{
		InitializeComponent();
		SetupCommandBindings(base.DataContext as IWindowedOutputVM);
	}

	private void OutputScreens_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		object dataContext = base.DataContext;
		IWindowedOutputVM vm = dataContext as IWindowedOutputVM;
		if (vm == null)
		{
			return;
		}
		switch (e.Action)
		{
		case NotifyCollectionChangedAction.Add:
			e.NewItems.OfType<IOutputScreenVM>().ForEach(delegate(IOutputScreenVM i)
			{
				SetUpCommandBindings(i.Command, vm.CreateOutputWindowCommand);
			});
			break;
		case NotifyCollectionChangedAction.Remove:
			e.OldItems.OfType<IOutputScreenVM>().ForEach(delegate(IOutputScreenVM i)
			{
				base.CommandBindings.Remove(i.Command);
			});
			break;
		case NotifyCollectionChangedAction.Reset:
			base.CommandBindings.Clear();
			break;
		case NotifyCollectionChangedAction.Replace:
		case NotifyCollectionChangedAction.Move:
			break;
		}
	}

	private void SetupCommandBindings(IWindowedOutputVM? vm)
	{
		if (vm != null)
		{
			vm.AudienceScreens.CollectionChanged += OutputScreens_CollectionChanged;
			vm.StageScreens.CollectionChanged += OutputScreens_CollectionChanged;
			vm.AudienceScreens.ForEach(delegate(IOutputScreenVM i)
			{
				SetUpCommandBindings(i.Command, vm.CreateOutputWindowCommand);
			});
			vm.StageScreens.ForEach(delegate(IOutputScreenVM i)
			{
				SetUpCommandBindings(i.Command, vm.CreateOutputWindowCommand);
			});
		}
	}

	private void SetUpCommandBindings(BindableRoutedCommand? command, ICommand<IOutputScreenVM?> targetCommand)
	{
		if (command != null)
		{
			base.CommandBindings.Add(command, targetCommand);
		}
	}
}
