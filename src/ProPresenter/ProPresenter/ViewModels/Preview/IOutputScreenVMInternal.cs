using System;
using System.ComponentModel;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.UI.ViewModels.Preview;

namespace ProPresenter.ViewModels.Preview;

public interface IOutputScreenVMInternal : IOutputScreenVM, INotifyPropertyChanged, IEquatable<IOutputScreenVM>
{
	ScreenArrangementBase? Screen { get; }
}
