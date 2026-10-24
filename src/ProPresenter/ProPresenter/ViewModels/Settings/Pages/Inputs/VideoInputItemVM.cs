using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Components;
using ProPresenter.DO.Analytics.Events.TrackedEvents;
using ProPresenter.DO.Audio;
using ProPresenter.DO.LiveVideo;
using ProPresenter.UI.ViewModels.Settings.Pages.Inputs;

namespace ProPresenter.ViewModels.Settings.Pages.Inputs;

public class VideoInputItemVM : LinkedObservableObjectBase, IVideoInputItemVM, INotifyPropertyChanged
{
	private readonly LiveVideoInput _liveVideoInput;

	[ObservableProperty]
	[NotifyPropertyChangedFor("IsLinked")]
	private IAudioInput? _audioInput;

	public string Name => _liveVideoInput.Name;

	public bool IsLinked
	{
		get
		{
			return AudioInput?.LinkedVideoInputs.IsLinked(_liveVideoInput) ?? false;
		}
		set
		{
			AudioInput?.LinkedVideoInputs.ToggleLink(_liveVideoInput);
			OnPropertyChanged("IsLinked");
			AudioInputAutoOnChangeEvent.Publish((uint)(AudioInput?.LinkedVideoInputs.Count ?? 0));
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAudioInput? AudioInput
	{
		get
		{
			return _audioInput;
		}
		set
		{
			if (!EqualityComparer<IAudioInput>.Default.Equals(_audioInput, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.AudioInput);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsLinked);
				_audioInput = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.AudioInput);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsLinked);
			}
		}
	}

	public VideoInputItemVM(LiveVideoInput liveVideoInput)
	{
		_liveVideoInput = liveVideoInput;
		LinkProperties("Name", "Name");
		liveVideoInput.PropertyChanged += base.RaiseLinkedValues;
	}
}
