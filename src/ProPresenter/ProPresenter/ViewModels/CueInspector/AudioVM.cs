using System.ComponentModel;
using Pro.Common.Components;
using Pro.Common.Time;
using Pro.DO.Audio;
using ProPresenter.Controller;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Media.Properties;
using ProPresenter.UI.ViewModels.CueInspector;

namespace ProPresenter.ViewModels.CueInspector;

public class AudioVM : LinkedNotifyPropertyChangedBase, IAudioVM, INotifyPropertyChanged
{
	private readonly ICoreManager _manager;

	private bool _updateFades;

	private MediaCue? _activeMediaCue;

	public MediaCue? ActiveMediaCue
	{
		get
		{
			return _activeMediaCue;
		}
		set
		{
			SetValue<MediaCue>("ActiveMediaCue", ref _activeMediaCue, value, delegate(MediaCue o, MediaCue n)
			{
				if (o != null)
				{
					if (o.MediaAction?.Media is IAudioMedia audioMedia)
					{
						audioMedia.Audio.DataModified -= AudioPropertiesModified;
					}
					if (o.MediaAction?.Media is ITransportMedia transportMedia)
					{
						transportMedia.Transport.PropertyChanged -= base.RaiseLinkedValues;
					}
				}
				_updateFades = false;
				OnPropertyChanged("Media");
				OnPropertyChanged("AudioMap");
				OnPropertyChanged("InputChannelSet");
				if (n != null)
				{
					if (n.MediaAction?.Media is IAudioMedia audioMedia2)
					{
						_updateFades = true;
						audioMedia2.Audio.DataModified += AudioPropertiesModified;
						UpdateFades();
						AudioPropertiesModified();
					}
					if (n.MediaAction?.Media is ITransportMedia transportMedia2)
					{
						transportMedia2.Transport.PropertyChanged += base.RaiseLinkedValues;
					}
				}
				OnPropertyChanged("FadeIn");
				OnPropertyChanged("FadeOut");
			});
		}
	}

	public MediaBase? Media => _activeMediaCue?.MediaAction?.Media;

	private TransportProperties? Transport => (Media as ITransportMedia)?.Transport;

	private AudioProperties? Audio => (Media as IAudioMedia)?.Audio;

	public TimeSlice FadeIn
	{
		get
		{
			return Transport?.FadeIn ?? TimeSlice.Zero;
		}
		set
		{
			if (Transport != null)
			{
				Transport.FadeIn = value;
			}
		}
	}

	public TimeSlice FadeOut
	{
		get
		{
			return Transport?.FadeOut ?? TimeSlice.Zero;
		}
		set
		{
			if (Transport != null)
			{
				Transport.FadeOut = value;
			}
		}
	}

	public AudioMap<MediaChannel, Bus>? AudioMap => Audio?.AudioMap;

	public ChannelSet<MediaChannel>? InputChannelSet => Audio?.InputChannelSet;

	public AudioVM(ICoreManager manager)
	{
		_manager = manager;
		LinkProperties("FadeIn", "FadeIn");
		LinkProperties("FadeOut", "FadeOut");
	}

	private void UpdateFades()
	{
		if (_updateFades && Transport != null)
		{
			_manager.UpdateCIAudioFades(Transport.FadeIn != TimeSlice.Zero, Transport.FadeIn, Transport.FadeOut != TimeSlice.Zero, Transport.FadeOut);
		}
	}

	private void AudioPropertiesModified()
	{
		_manager.UpdateCIAudioProperties(Audio);
	}
}
