using System;
using System.ComponentModel;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;

namespace ProPresenter.UI.ViewModels.Library.Cue;

public interface IHeaderCueVM : IProPresenterCueVM, INotifyPropertyChanged, IDisposable
{
	HeaderCue Header { get; }

	HeaderAction HeaderAction { get; }
}
