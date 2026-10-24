using System;
using System.ComponentModel;
using Pro.DO.Storage;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;

namespace ProPresenter.UI.ViewModels.Library.Cue;

public interface IDocumentCueVM : IProPresenterCueVM, INotifyPropertyChanged, IDisposable, IFileResource
{
	IDocumentCue Document { get; }

	IDocumentAction? DocumentAction { get; }
}
