using System.ComponentModel;

namespace ProPresenter.DO.Capture;

public interface IRtmpDestination : IDestination, INotifyPropertyChanged
{
	string Address { get; set; }

	string Key { get; set; }
}
