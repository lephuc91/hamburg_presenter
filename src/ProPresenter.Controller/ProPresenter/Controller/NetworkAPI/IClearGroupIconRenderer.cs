using Google.Protobuf;
using ProPresenter.DO.ClearGroups;

namespace ProPresenter.Controller.NetworkAPI;

public interface IClearGroupIconRenderer
{
	ByteString Render(ClearGroup group);
}
