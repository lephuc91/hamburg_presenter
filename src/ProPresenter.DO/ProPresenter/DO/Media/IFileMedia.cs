using Pro.Common.Components;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Media.Properties;

namespace ProPresenter.DO.Media;

public interface IFileMedia : ITrackedMedia, IHasMediaContainerId, ICanReceiveMediaContainerIdUpdates
{
	ProPresenter.DO.Media.Properties.FileProperties File { get; }

	bool IsPending { get; }

	bool IsValid { get; }

	MediaAvailability Availability { get; }

	void ProtoDeserialize(Pro.SerializationInterop.RVProtoData.Media protoMedia, string containerId);
}
