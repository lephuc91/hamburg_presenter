using System;
using ProPresenter.DO.Downloads;

namespace ProPresenter.DO.ProContent.Downloads;

public interface IProContentDownloadProcessFactory
{
	IProContentDownloadProcess Create(Action<IDownloadObserverCallbackData>? importCallback = null);
}
