using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using Pro.UI.Components;
using Pro.ssAPI.Devices;
using ProPresenter.Controller.RenderClockSource;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages.Screens;

namespace ProPresenter.ViewModels.Settings.Pages.Screens;

public class ClockSourceVM : LinkedNotifyPropertyChangedBase, IClockSourceVM, INotifyPropertyChanged
{
	private readonly IClockSourceService _service;

	private readonly IDisplay _display;

	private ClockSource _selectedClockSource;

	public ClockSourceCollection ClockSources => _service.ClockSources;

	public ClockSource SelectedClockSource
	{
		get
		{
			return _selectedClockSource;
		}
		[MemberNotNull("_selectedClockSource")]
		private set
		{
			SetValue("SelectedClockSource", ref _selectedClockSource, value, delegate(ClockSource o, ClockSource n)
			{
				ChangeRenderClockSource(n);
				OnPropertyChanged("SelectedClockSourceName");
			});
		}
	}

	public string SelectedClockSourceName => GetSelectedClockSourceName();

	public IEnumerable<ClockSource> Outputs => ClockSources.Where((ClockSource c) => c.Connected && c.Type == ClockSourceType.Output);

	public IEnumerable<ClockSource> Inputs => ClockSources.Where((ClockSource c) => c.Connected && c.Type == ClockSourceType.Input);

	public ICommand<ClockSource> SelectClockSourceCommand => new RelayCommand<ClockSource>(delegate(ClockSource c)
	{
		SelectedClockSource = c;
	}, (ClockSource c) => c != null);

	public ClockSourceVM(IClockSourceService service, IDisplay display)
	{
		ClockSourceVM @object = this;
		_service = service;
		_display = display;
		if (display.SelectedClockSource != null)
		{
			ClockSource clockSource = ClockSources.FirstOrDefaultOf(delegate(ClockSource c)
			{
				bool flag = c.UUID == display.SelectedClockSource.Uuid;
				if (flag)
				{
					ClockSourceType type = c.Type;
					flag = type == (ClockSourceType)(display.SelectedClockSource.Type switch
					{
						ProClockSource.Types.Type.Input => 1, 
						ProClockSource.Types.Type.Output => 2, 
						_ => 0, 
					});
				}
				return flag;
			});
			if (clockSource == null)
			{
				clockSource = new ClockSource();
				clockSource.Deserialize(display.SelectedClockSource);
			}
			SelectedClockSource = clockSource;
		}
		else
		{
			SelectedClockSource = new ClockSource();
		}
		LinkProperties("SelectedClockSource", new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "SelectedClockSource", "SelectedClockSourceName" }));
		LinkProperties("Connected", new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "Outputs", "Inputs" }));
		LinkProperties("Active", new global::_003C_003Ez__ReadOnlySingleElementList<string>("SelectedClockSourceName"));
		display.PropertyChanged += base.RaiseLinkedValues;
		_service.ClockSources.CollectionChanged += ClockSources_CollectionChanged;
		_service.ClockSources.ForEach(delegate(ClockSource c)
		{
			c.PropertyChanged += @object.RaiseLinkedValues;
		});
	}

	private void ClockSources_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<ClockSource>().ForEach(delegate(ClockSource c)
		{
			c.PropertyChanged -= base.RaiseLinkedValues;
		});
		e.NewItems?.OfType<ClockSource>().ForEach(delegate(ClockSource c)
		{
			c.PropertyChanged += base.RaiseLinkedValues;
		});
		OnPropertyChanged("Outputs");
		OnPropertyChanged("Inputs");
		OnPropertyChanged("SelectedClockSourceName");
	}

	private void ChangeRenderClockSource(ClockSource clockSource)
	{
		if (clockSource != null)
		{
			_service.SetClockSource(clockSource);
			_display.SelectedClockSource = clockSource.Serialize();
		}
	}

	private string GetSelectedClockSourceName()
	{
		if (SelectedClockSource != null && !string.IsNullOrEmpty(SelectedClockSource.UUID))
		{
			string value = (ClockSources.Any((ClockSource c) => c.Connected && c.UUID == SelectedClockSource.UUID) ? string.Empty : LocalizedStrings.Get("SETTINGS_SCREENS_TIMING_SOURCE_DISCONNECTED_label"));
			return $"{LocalizedStrings.Get(SelectedClockSource.Type)} {SelectedClockSource.DisplayName} {value}";
		}
		return LocalizedStrings.Get("SETTINGS_SCREENS_TIMING_SOURCE_AUTOMATIC_title");
	}

	public void RefreshClockSources()
	{
		_service.RefreshClockSources();
	}
}
