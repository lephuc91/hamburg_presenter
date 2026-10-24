using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Pro.Common.OAuth;

namespace ProPresenter.DO.SongSelect;

public interface ISongSelectConsumer : IConsumer, INotifyPropertyChanged
{
	string Organization { get; }

	string SessionId { get; }

	string GetLoginUrl();

	bool IsAuthorizationCallback(string url);

	Task CompleteAuthorizationWithUrlAsync(string url);

	Task<SongSelectSearchResults> SearchAsync(string query, int pageIndex, int resultsPerPage);

	Task<SongSelectSongInfo?> GetSongDetailsAsync(int songId);

	Task<IEnumerable<string>> ReportUsagesAsync(IEnumerable<SongSelectUsageReport> usages);
}
