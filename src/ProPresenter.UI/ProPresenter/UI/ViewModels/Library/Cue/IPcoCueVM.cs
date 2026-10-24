using System;
using System.ComponentModel;
using Pro.DO.Storage;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Actions.PCO;
using ProPresenter.DO.Cues.PCO;
using ProPresenter.DO.PCO;

namespace ProPresenter.UI.ViewModels.Library.Cue;

public interface IPcoCueVM : IProPresenterCueVM, INotifyPropertyChanged, IDisposable, IDocumentCueVM, IFileResource
{
	PCOCueBase Pco { get; }

	PCOActionBase? PCOAction { get; }

	HeaderAction? HeaderAction { get; }

	PCOItemType PCOItemType { get; }
}
