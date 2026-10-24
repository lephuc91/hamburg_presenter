using System.ComponentModel;

namespace ProPresenter.DO.Sync.Local;

public interface ISyncData : INotifyPropertyChanged
{
	string Name { get; }

	long Size { get; }

	long DateModified { get; }

	bool CanModify { get; }

	bool SkipFileCheck { get; }
}
