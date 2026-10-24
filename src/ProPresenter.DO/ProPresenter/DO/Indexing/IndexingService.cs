using System.ComponentModel;
using Pro.Common.Components;

namespace ProPresenter.DO.Indexing;

public class IndexingService : NotifyPropertyChangedBase, IIndexingService, INotifyPropertyChanged
{
	public bool IsIndexing { get; private set; }

	public int TotalIndexCount { get; private set; }

	public int CurrentIndexedCount { get; private set; }

	public void IncrementCurrentIndexedCount()
	{
		CurrentIndexedCount++;
		OnPropertyChanged("CurrentIndexedCount");
	}

	public void SetIsIndexing(bool isIndexing, int totalIndexCount = 0)
	{
		if (isIndexing)
		{
			IsIndexing = isIndexing;
			CurrentIndexedCount = 0;
			TotalIndexCount = totalIndexCount;
		}
		else
		{
			IsIndexing = isIndexing;
			TotalIndexCount = 0;
			CurrentIndexedCount = 0;
		}
		OnPropertyChanged("IsIndexing");
		OnPropertyChanged("TotalIndexCount");
		OnPropertyChanged("CurrentIndexedCount");
	}
}
