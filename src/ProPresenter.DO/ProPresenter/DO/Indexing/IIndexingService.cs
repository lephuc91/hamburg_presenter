using System.ComponentModel;

namespace ProPresenter.DO.Indexing;

public interface IIndexingService : INotifyPropertyChanged
{
	int TotalIndexCount { get; }

	int CurrentIndexedCount { get; }

	bool IsIndexing { get; }

	void SetIsIndexing(bool isIndexing, int totalIndexCount = 0);

	void IncrementCurrentIndexedCount();
}
