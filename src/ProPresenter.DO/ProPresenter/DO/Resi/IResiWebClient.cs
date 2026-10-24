using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Pro.Common.OAuth;

namespace ProPresenter.DO.Resi;

public interface IResiWebClient : IConsumer, INotifyPropertyChanged
{
	string MoreInfoLink { get; }

	string SupportEmail { get; }

	string SupportLink { get; }

	string ManageAccountUrl { get; }

	bool UsesCustomEndpoints { get; }

	Task<string> BeginAuthorizationAsync();

	bool TryCompleteAuthorization(string url);

	Task<Version?> GetLatestVersionAsync(Version apiVersion);

	Task<string> GetLatestVersionDownloadLinkAsync(Version apiVersion);

	Task<string> GetDeauthorizationResourceAsync();
}
