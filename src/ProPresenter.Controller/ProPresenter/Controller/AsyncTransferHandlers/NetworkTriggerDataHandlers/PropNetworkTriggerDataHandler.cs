using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO.Props;
using ProPresenter.DO.Slide.Custom;

namespace ProPresenter.Controller.AsyncTransferHandlers.NetworkTriggerDataHandlers;

public class PropNetworkTriggerDataHandler : INetworkTriggerDataHandler
{
	private readonly IPropSource _props;

	public PropNetworkTriggerDataHandler(IPropSource props)
	{
		_props = props;
	}

	public NetworkTriggerDataItem? Handle(NetworkIdentifier id, ITriggerOperation op)
	{
		if (_props == null)
		{
			return null;
		}
		IPropCue propCue = id.FindItem(_props.FlatCollection);
		if (propCue != null)
		{
			op.SlidePool.AddSlide((propCue.SlideAction?.Slide as CustomSlide)?.Clone(null, preserveID: true, userInitiated: false, includeBackgroundMedia: true, ignoreMediaNotifications: true));
			op.AttachPropCueInfo(propCue, propCue.Serialize().GetSlide());
		}
		return propCue?.SlideAction?.ToTriggerDataItem();
	}
}
