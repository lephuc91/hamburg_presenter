using System;
using System.ComponentModel;

namespace ProPresenter.DO.Capture;

public interface IResiDestination : IDestination, INotifyPropertyChanged
{
	Guid Group { get; set; }

	Guid Profile { get; set; }
}
