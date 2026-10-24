using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Masks;

namespace ProPresenter.Controller.NetworkAPI;

public static class MaskHandler
{
	internal static NetworkAPI_v1 Handle(IMaskCollection masks, API_v1_Masks_Request request)
	{
		if (request != null)
		{
			if (request.Masks != null)
			{
				return Masks(masks);
			}
			API_v1_Masks_Request.Types.GetMask getMask = request.GetMask;
			if (getMask != null)
			{
				return Mask(masks, getMask.Id);
			}
			API_v1_Masks_Request.Types.GetThumbnail getThumbnail = request.GetThumbnail;
			if (getThumbnail != null)
			{
				return GetThumbnail(masks, getThumbnail.Id, getThumbnail.Quality);
			}
		}
		global::_003CPrivateImplementationDetails_003E.ThrowSwitchExpressionException(request);
		NetworkAPI_v1 result = default(NetworkAPI_v1);
		return result;
	}

	private static NetworkAPI_v1 Masks(IMaskCollection masks)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().MasksResponse().Masks = new API_v1_Masks_Response.Types.Masks
			{
				Masks_ = { masks.ToIdentifiers() }
			};
		});
	}

	private static NetworkAPI_v1 Mask(IMaskCollection masks, string id)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(masks, id, out ItemPacket<SlideCue> packet))
			{
				v1.Action().MasksResponse().GetMask = new API_v1_Masks_Response.Types.GetMask
				{
					Id = Common.ID(packet)
				};
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static NetworkAPI_v1 GetThumbnail(IMaskCollection masks, string id, int quality)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(masks, id, out ItemPacket<SlideCue> packet))
			{
				v1.Action().MasksResponse().GetThumbnail = new API_v1_Masks_Response.Types.GetThumbnail
				{
					Data = packet.Item.GetThumbnail(null, quality)
				};
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static API_v1_Masks_Response MasksResponse(this NetworkAPI_v1.Types.Action action)
	{
		return action.MasksResponse = new API_v1_Masks_Response();
	}
}
