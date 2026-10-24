using System.ComponentModel;
using Pro.DO.Storage;

namespace ProPresenter.DO.Capture;

public interface IDiskDestination : IDestination, INotifyPropertyChanged
{
	Container Container { get; set; }

	RelativePath Location { get; set; }
}
