using ProPresenter.DO.Cues;
using ProPresenter.DO.Downloads;

namespace ProPresenter.DO.ProContent;

public record ProContentDownloadObserveCallbackData(MediaCue MediaCue, bool Cleanup = false) : IDownloadObserverCallbackData;
