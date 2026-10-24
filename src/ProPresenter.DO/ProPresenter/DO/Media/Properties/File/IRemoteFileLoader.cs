using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ProPresenter.DO.Media.Properties.File;

public interface IRemoteFileLoader
{
	Task<BitmapSource?> LoadThumbnailAsync(IRemoteFileProperties remoteFile);

	Task StartDownloadAsync(IRemoteFileProperties remoteFile);
}
