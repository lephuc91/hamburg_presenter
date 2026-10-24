using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Time;
using ProPresenter.DO;
using ProPresenter.DO.Actions;

namespace ProPresenter.UI.ViewModels.CueInspector;

public interface IPlaybackMarkerItemVM : INotifyPropertyChanged
{
	IPlaybackMarker Marker { get; }

	TimeSlice Timestamp { get; set; }

	Color Color { get; set; }

	string Name { get; set; }

	IEnumerable<IScrimSource> ScrimItems { get; }

	IRelayCommand StartDragCommand { get; }

	IRelayCommand StopDragCommand { get; }

	string? PlaybackMarkerTooltip { get; set; }
}
