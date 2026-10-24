using Pro.DO.Storage;

namespace ProPresenter.DO.PCO.Items;

public interface IPCOContent
{
	string PCOItemID { get; }

	string Filename { get; }

	string RemoteDownloadURL { get; }

	RelativePath? LocalDownloadPath { get; set; }

	RelativePath? LocalWorkingPath { get; set; }
}
