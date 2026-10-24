using System;

namespace ProPresenter.DO.Resi;

public interface IResiEndpoints
{
	string TargetRedirectHost { get; }

	Uri DownloadPlugin { get; }

	bool IsCustom { get; }

	Uri Login { get; }

	Uri Logout { get; }

	string ManageAccount { get; }

	string MoreInfo { get; }

	string Support { get; }

	string HomePage { get; }
}
