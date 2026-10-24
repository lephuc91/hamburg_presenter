using System;
using System.ComponentModel;
using ProPresenter.DO.Cues;

namespace ProPresenter.UI.ViewModels.Library.Cue;

public interface IProPresenterCueVM : INotifyPropertyChanged, IDisposable
{
	ProPresenterCue Cue { get; }

	CueType Type { get; }

	string Name { get; set; }
}
