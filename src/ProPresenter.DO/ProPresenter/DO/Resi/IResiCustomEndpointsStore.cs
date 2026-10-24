namespace ProPresenter.DO.Resi;

public interface IResiCustomEndpointsStore
{
	string? MoreInfo { get; }

	string? Support { get; }

	string? HomePage { get; }

	string? ManageAccount { get; }

	string? Login { get; }

	string? Logout { get; }

	string? DownloadPlugin { get; }
}
