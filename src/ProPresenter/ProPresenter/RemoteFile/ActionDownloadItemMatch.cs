using System.Collections.Generic;
using Pro.Common.Downloads;
using ProPresenter.DO.Actions;

namespace ProPresenter.RemoteFile;

public record ActionDownloadItemMatch(MediaAction Action, IReadOnlyList<IDownloadItem> DownloadItems);
