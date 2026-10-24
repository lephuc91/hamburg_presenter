using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Pro.Common.OAuth;
using ProPresenter.DO.PCO.Items;

namespace ProPresenter.DO.PCO;

public interface IPCOConsumer : IConsumer, INotifyPropertyChanged
{
	bool IsPCOBusy { get; set; }

	string PCOBusyMessage { get; set; }

	string Username { get; }

	string CacheSessionId { get; }

	Func<Task>? RequestPCOLogin { get; set; }

	event Action<PCOPlan> PlanRefreshed;

	event Action Deauthorized;

	string GetLoginUrl();

	bool IsAuthorizationCallback(string url);

	Task CompleteAuthorizationWithUrlAsync(string url);

	Task DownloadFileAsync(PCOAttachmentDetails file);

	Task<IList<PCOAttachmentDetails>> DownloadFilesAsync(PCOItem[] planItems, Action<string> displayStatusMessage);

	Task<IList<PCOAttachmentDetails>> DownloadFilesAsync(PCOPlan plan, Action<string> displayStatusMessage);

	Task<PCOPlan> LoadPlanItemsAsync(PCOPlan plan, bool isRefresh = false);

	Task<PlanRefreshResult> RefreshPCOPlanAsync(PCOPlan plan);

	void ReloadOrganizationData();

	Task UploadFilesAsync(IEnumerable<PCOUpdateInformation> updateRequests, Action<string> displayStatusMessage, Action<PCOUpdateInformation, bool, PCOItem?>? onUploadRequestComplete = null);

	Task RefreshOAuthTokenAsync();

	Task<DateTime?> GetLastUpdateTimeForPlanAsync(string serviceID, string planID);
}
