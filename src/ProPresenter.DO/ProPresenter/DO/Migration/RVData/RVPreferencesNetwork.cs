using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class RVPreferencesNetwork
{
	[Child]
	[Alias("CheckPlanUpdatesMode", typeof(string), false)]
	public string? CheckPlanUpdatesMode { get; internal set; }

	[Child]
	[Alias("DownloadDocumentsMode", typeof(string), false)]
	public string? DownloadDocumentsMode { get; internal set; }

	[Child]
	[Alias("IsControllerModeEnabled", typeof(bool), false)]
	public bool IsControllerModeEnabled { get; internal set; }

	[Child]
	[Alias("IsMasterControlEnabled", typeof(bool), false)]
	public bool IsMasterControlEnabled { get; internal set; }

	[Child]
	[Alias("IsObserverModeEnabled", typeof(bool), false)]
	public bool IsObserverModeEnabled { get; internal set; }

	[Child]
	[Alias("IsProNetworkEnabled", typeof(bool), false)]
	public bool IsProNetworkEnabled { get; internal set; }

	[Child]
	[Alias("IsProRemoteEnabled", typeof(bool), false)]
	public bool IsProRemoteEnabled { get; internal set; }

	[Child]
	[Alias("IsSendSlidesEnabled", typeof(bool), false)]
	public bool IsSendSlidesEnabled { get; internal set; }

	[Child]
	[Alias("MakeArrangementsFromSeq", typeof(bool), false)]
	public bool MakeArrangementsFromSeq { get; internal set; }

	[Child]
	[Alias("MatchSongsInLibrary", typeof(bool), false)]
	public bool MatchSongsInLibrary { get; internal set; }

	[Child]
	[Alias("ProNetworkName", typeof(string), false)]
	public string? ProNetworkName { get; internal set; }

	[Child]
	[Alias("ProNetworkPort", typeof(int), false)]
	public int ProNetworkPort { get; internal set; }

	[Child]
	[Alias("ProRemoteControllerPassword", typeof(string), false)]
	public string? ProRemoteControllerPassword { get; internal set; }

	[Child]
	[Alias("ProRemoteObserverPassword", typeof(string), false)]
	public string? ProRemoteObserverPassword { get; internal set; }

	[Child]
	[Alias("RemoteStageDisplayEnable", typeof(bool), false)]
	public bool RemoteStageDisplayEnable { get; internal set; }

	[Child]
	[Alias("RemoteStageDisplayPassword", typeof(string), false)]
	public string? RemoteStageDisplayPassword { get; internal set; }

	[Child]
	[Alias("RemoteStageDisplayPort", typeof(int), false)]
	public int RemoteStageDisplayPort { get; internal set; }

	[Child]
	[Alias("SendSlidesName", typeof(string), false)]
	public string? SendSlidesName { get; internal set; }

	[Child]
	[Alias("SendSlidesPort", typeof(int), false)]
	public int SendSlidesPort { get; internal set; }

	[Child]
	[Alias("ShowHistoricalPlans", typeof(bool), false)]
	public bool ShowHistoricalPlans { get; internal set; }

	[Child]
	[Alias("UploadDocumentsMode", typeof(string), false)]
	public string? UploadDocumentsMode { get; internal set; }
}
