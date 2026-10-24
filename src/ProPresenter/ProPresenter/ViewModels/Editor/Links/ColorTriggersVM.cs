using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Links;
using ProPresenter.UI.ViewModels.Editor.Links;

namespace ProPresenter.ViewModels.Editor.Links;

public class ColorTriggersVM : ObservableObject, IColorTriggersVM, INotifyPropertyChanged, IDragDropCollection<IColorTriggerItemVM>
{
	private IColorTriggerCollection? _source;

	private IEnumerable<IColorTriggerItemVM>? _colorTriggers;

	private readonly IColorTriggerVMFactory _factory;

	private readonly IApp _app;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? addColorTriggerCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? removeColorTriggersCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? saveAsDefaultColorTriggersCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? resetToDefaultColorTriggersCommand;

	public IEnumerable<IColorTriggerItemVM>? ColorTriggers => _colorTriggers;

	public ObservableCollection<IColorTriggerItemVM> SelectedItems { get; } = new ObservableCollection<IColorTriggerItemVM>();

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand AddColorTriggerCommand => addColorTriggerCommand ?? (addColorTriggerCommand = new RelayCommand(AddColorTrigger, CanExecute_Commands));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand RemoveColorTriggersCommand => removeColorTriggersCommand ?? (removeColorTriggersCommand = new RelayCommand(RemoveColorTriggers, CanExecute_RemoveColorTriggersCommands));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand SaveAsDefaultColorTriggersCommand => saveAsDefaultColorTriggersCommand ?? (saveAsDefaultColorTriggersCommand = new RelayCommand(SaveAsDefaultColorTriggers, CanExecute_Commands));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ResetToDefaultColorTriggersCommand => resetToDefaultColorTriggersCommand ?? (resetToDefaultColorTriggersCommand = new RelayCommand(ResetToDefaultColorTriggers, CanExecute_Commands));

	public ColorTriggersVM(IColorTriggerVMFactory factory, IApp app)
	{
		_factory = factory;
		_app = app;
		SelectedItems.CollectionChanged += SelectedItems_CollectionChanged;
	}

	[RelayCommand(CanExecute = "CanExecute_Commands")]
	private void AddColorTrigger()
	{
		if (CanExecute_Commands())
		{
			_source.Add();
		}
	}

	[RelayCommand(CanExecute = "CanExecute_RemoveColorTriggersCommands")]
	private void RemoveColorTriggers()
	{
		if (CanExecute_Commands())
		{
			IColorTrigger[] colorTriggers = (from i in SelectedItems.OfType<IColorTriggerItemVMInternal>()
				select i.ColorTrigger).ToArray();
			_source.Remove(colorTriggers);
		}
	}

	[RelayCommand(CanExecute = "CanExecute_Commands")]
	private void SaveAsDefaultColorTriggers()
	{
		if (CanExecute_Commands())
		{
			_app.DefaultColorTriggers.Clear();
			_app.DefaultColorTriggers.Add(_source.CloneItems());
		}
	}

	[RelayCommand(CanExecute = "CanExecute_Commands")]
	private void ResetToDefaultColorTriggers()
	{
		if (CanExecute_Commands())
		{
			_source.Clear();
			_source.Add(_app.DefaultColorTriggers.CloneItems());
		}
	}

	[MemberNotNullWhen(true, "_source")]
	private bool CanExecute_Commands()
	{
		return _source != null;
	}

	private bool CanExecute_RemoveColorTriggersCommands()
	{
		if (CanExecute_Commands())
		{
			return SelectedItems.Any();
		}
		return false;
	}

	private void SelectedItems_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		RemoveColorTriggersCommand.NotifyCanExecuteChanged();
	}

	private void Reset(ColorTriggerCollection? colorTriggers)
	{
		_source = colorTriggers;
		_colorTriggers = colorTriggers?.Select(_factory.Create).ToArray() ?? Array.Empty<IColorTriggerItemVM>();
		OnPropertyChanged("ColorTriggers");
		AddColorTriggerCommand.NotifyCanExecuteChanged();
		RemoveColorTriggersCommand.NotifyCanExecuteChanged();
		SaveAsDefaultColorTriggersCommand.NotifyCanExecuteChanged();
		ResetToDefaultColorTriggersCommand.NotifyCanExecuteChanged();
	}

	public void UpdateColorTriggers(IFormatDataVM formatDataVM)
	{
		Reset(formatDataVM.FormatData?.ColorTriggers);
	}

	public int IndexOf(IColorTriggerItemVM item)
	{
		if (!(item is IColorTriggerItemVMInternal colorTriggerItemVMInternal))
		{
			return -1;
		}
		return _source?.IndexOf(colorTriggerItemVMInternal.ColorTrigger) ?? (-1);
	}

	public void DraggedFrom(IEnumerable<IColorTriggerItemVM> items)
	{
		IColorTrigger[] items2 = (from i in items.OfType<IColorTriggerItemVMInternal>()
			select i.ColorTrigger).ToArray();
		_source?.DraggedFrom(items2);
	}

	public void DroppedInto(IEnumerable<IColorTriggerItemVM> items, int index, bool isCopy)
	{
		IColorTrigger[] items2 = (from i in items.OfType<IColorTriggerItemVMInternal>()
			select i.ColorTrigger).ToArray();
		_source?.DroppedInto(items2, index, isCopy);
	}

	public void MoveTo(IEnumerable<IColorTriggerItemVM> items, int index)
	{
		IColorTrigger[] items2 = (from i in items.OfType<IColorTriggerItemVMInternal>()
			select i.ColorTrigger).ToArray();
		_source?.MoveTo(items2, index);
	}
}
