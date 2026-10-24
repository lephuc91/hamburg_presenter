using Pro.Common.Components;
using Pro.Common.Downloads;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Media.Properties.File;

public interface IRemoteFileProperties : ICloneable<IRemoteFileProperties>
{
	Pro.SerializationInterop.RVProtoData.FileProperties.Types.RemoteProperties Serialize();

	string GetManufacture();

	bool Matches(IDownloadItem item);
}
