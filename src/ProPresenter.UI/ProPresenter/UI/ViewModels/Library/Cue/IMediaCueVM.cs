using System;
using System.ComponentModel;
using Pro.DO.Storage;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;

namespace ProPresenter.UI.ViewModels.Library.Cue;

public interface IMediaCueVM : IProPresenterCueVM, INotifyPropertyChanged, IDisposable, IFileResource
{
	MediaCue Media { get; }

	MediaAction MediaAction { get; }
}
