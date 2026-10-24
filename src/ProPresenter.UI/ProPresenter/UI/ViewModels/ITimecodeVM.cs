using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Pro.UI.Components;
using Pro.ssAPI.Devices;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Timecode;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.UI.ViewModels;

public interface ITimecodeVM : INotifyPropertyChanged
{
	string TimecodeTimeStr { get; }

	TimedPlaybackState State { get; }

	IAudioInputDevice? SelectedDevice { get; }

	AudioInputDeviceCollection Devices { get; }

	int Channel { get; }

	IEnumerable<int> Channels { get; }

	TimecodeFormat Format { get; }

	IEnumerable<TimecodeFormat> Formats { get; }

	double Offset { get; set; }

	Playlist<ProPresenterCue>? SelectedPlaylist { get; set; }

	bool IsActive { get; set; }

	LibraryPlaylistCollection Playlists { get; }

	ICollectionView Items { get; }

	ICommand<Playlist<ProPresenterCue>> SelectPlaylistCommand { get; }

	ICommand ToggleTimecodeCommand { get; }

	ICommand<IAudioInputDevice?> SelectDeviceCommand { get; }

	ICommand<int> SelectChannelCommand { get; }

	ICommand<TimecodeFormat> SelectFormatCommand { get; }

	ICommand<bool> MonitorCommand { get; }
}
