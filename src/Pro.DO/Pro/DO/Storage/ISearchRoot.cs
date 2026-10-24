using System.ComponentModel;

namespace Pro.DO.Storage;

public interface ISearchRoot : INotifyPropertyChanged
{
	bool IsActive { get; set; }

	SearchRootType Type { get; }
}
