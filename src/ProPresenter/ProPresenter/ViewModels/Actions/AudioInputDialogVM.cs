using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.DO.Triggering;
using Pro.Localization;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Audio;
using ProPresenter.DO.LiveVideo;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels.Actions;

public class AudioInputDialogVM : ActionDialogContentVM
{
	private readonly IAudioInputProvider _audioInputProvider;

	private static IEnumerable<AudioInput> AudioInputs
	{
		get
		{
			IEnumerable<AudioInput> availableAudioInputs = OutputVault.AvailableAudioInputs;
			return availableAudioInputs ?? Enumerable.Empty<AudioInput>();
		}
	}

	private AudioInputAction? AudioInputAction => base.Action as AudioInputAction;

	public IEnumerable<AudioInput> AvailableAudioInputs => AudioInputs.Where(_audioInputProvider.GetAvailableInputs().Append<AudioInput>(SelectedAudioInput).Contains<AudioInput>);

	public IEnumerable<LiveVideoInput> VideoInputs
	{
		get
		{
			IEnumerable<LiveVideoInput> availableLiveVideoInputs = OutputVault.AvailableLiveVideoInputs;
			return availableLiveVideoInputs ?? Enumerable.Empty<LiveVideoInput>();
		}
	}

	public string SelectedAudioInputDescription => SelectedAudioInput?.LongName ?? LocalizedStrings.Get("AUDIO_INPUT_ACTION_POPOVER_SELECT_INPUT_MENU_ITEM_title");

	public AudioInput? SelectedAudioInput
	{
		get
		{
			return AudioInputs.ElementAtOrDefault(AudioInputAction?.Index ?? (-1));
		}
		private set
		{
			if (AudioInputAction != null)
			{
				AudioInputAction.Index = AudioInputs.IndexOf<AudioInput>(value);
			}
		}
	}

	public ICommand<AudioInput> SelectInputCommand => new RelayCommand<AudioInput>(delegate(AudioInput i)
	{
		SelectedAudioInput = i;
	});

	public AudioInputDialogVM(IAudioInputProvider? audioInputProvider = null)
	{
		_audioInputProvider = audioInputProvider ?? new SlideAudioInputProvider(null, () => base.ActionStore?.Actions ?? Enumerable.Empty<IAction>());
		LinkProperties("Index", new string[3] { "SelectedAudioInput", "SelectedAudioInputDescription", "AvailableAudioInputs" });
	}

	protected override void OnContextChanged(IActionDialogContext? oldValue, IActionDialogContext? newValue)
	{
		if (oldValue?.Action is AudioInputAction audioInputAction)
		{
			audioInputAction.PropertyChanged -= base.RaiseLinkedValues;
		}
		if (newValue?.Action is AudioInputAction audioInputAction2)
		{
			audioInputAction2.PropertyChanged += base.RaiseLinkedValues;
		}
		OnPropertyChanged("SelectedAudioInput");
		OnPropertyChanged("SelectedAudioInputDescription");
		OnPropertyChanged("AvailableAudioInputs");
	}
}
