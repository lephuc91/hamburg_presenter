using System;
using System.ComponentModel;
using Pro.DO.Storage;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;

namespace ProPresenter.UI.ViewModels.Library.Cue;

public interface IPlaceholderCueVM : IProPresenterCueVM, INotifyPropertyChanged, IDisposable, IDocumentCueVM, IFileResource
{
	PlaceholderCue Placeholder { get; }

	PlaceholderAction PlaceholderAction { get; }

	bool IsLinked { get; }
}
