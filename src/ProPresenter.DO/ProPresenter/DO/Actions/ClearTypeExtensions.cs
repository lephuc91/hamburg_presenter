using System;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Actions;

public static class ClearTypeExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Action.Types.ClearType.Types.ClearTargetLayer ToProtoClearTargetLayer(this ClearType clearType, out Pro.SerializationInterop.RVProtoData.Action.Types.ContentDestination destination)
	{
		destination = Pro.SerializationInterop.RVProtoData.Action.Types.ContentDestination.Global;
		switch (clearType)
		{
		case ClearType.All:
			return Pro.SerializationInterop.RVProtoData.Action.Types.ClearType.Types.ClearTargetLayer.All;
		case ClearType.Audio:
			return Pro.SerializationInterop.RVProtoData.Action.Types.ClearType.Types.ClearTargetLayer.Audio;
		case ClearType.AudioEffects:
			return Pro.SerializationInterop.RVProtoData.Action.Types.ClearType.Types.ClearTargetLayer.AudioEffects;
		case ClearType.Background:
			return Pro.SerializationInterop.RVProtoData.Action.Types.ClearType.Types.ClearTargetLayer.Background;
		case ClearType.LiveVideo:
			return Pro.SerializationInterop.RVProtoData.Action.Types.ClearType.Types.ClearTargetLayer.LiveVideo;
		case ClearType.Props:
			return Pro.SerializationInterop.RVProtoData.Action.Types.ClearType.Types.ClearTargetLayer.Prop;
		case ClearType.Messages:
			return Pro.SerializationInterop.RVProtoData.Action.Types.ClearType.Types.ClearTargetLayer.Messages;
		case ClearType.Slide:
			return Pro.SerializationInterop.RVProtoData.Action.Types.ClearType.Types.ClearTargetLayer.Slide;
		case ClearType.ToLogo:
			return Pro.SerializationInterop.RVProtoData.Action.Types.ClearType.Types.ClearTargetLayer.Logo;
		case ClearType.Announcement:
			destination = Pro.SerializationInterop.RVProtoData.Action.Types.ContentDestination.Announcements;
			return Pro.SerializationInterop.RVProtoData.Action.Types.ClearType.Types.ClearTargetLayer.All;
		default:
			throw new NotSupportedException();
		}
	}

	public static ClearType ToClearType(this Pro.SerializationInterop.RVProtoData.Action.Types.ClearType.Types.ClearTargetLayer protoClearTargetLayer)
	{
		return protoClearTargetLayer switch
		{
			Pro.SerializationInterop.RVProtoData.Action.Types.ClearType.Types.ClearTargetLayer.All => ClearType.All, 
			Pro.SerializationInterop.RVProtoData.Action.Types.ClearType.Types.ClearTargetLayer.Audio => ClearType.Audio, 
			Pro.SerializationInterop.RVProtoData.Action.Types.ClearType.Types.ClearTargetLayer.AudioEffects => ClearType.AudioEffects, 
			Pro.SerializationInterop.RVProtoData.Action.Types.ClearType.Types.ClearTargetLayer.Background => ClearType.Background, 
			Pro.SerializationInterop.RVProtoData.Action.Types.ClearType.Types.ClearTargetLayer.LiveVideo => ClearType.LiveVideo, 
			Pro.SerializationInterop.RVProtoData.Action.Types.ClearType.Types.ClearTargetLayer.Prop => ClearType.Props, 
			Pro.SerializationInterop.RVProtoData.Action.Types.ClearType.Types.ClearTargetLayer.Messages => ClearType.Messages, 
			Pro.SerializationInterop.RVProtoData.Action.Types.ClearType.Types.ClearTargetLayer.Slide => ClearType.Slide, 
			Pro.SerializationInterop.RVProtoData.Action.Types.ClearType.Types.ClearTargetLayer.Logo => ClearType.ToLogo, 
			_ => throw new NotSupportedException(), 
		};
	}

	public static ClearType ToClearType(this API_v1_ClearGroup.Types.API_v1_ClearGroupLayerType protoAPILayerType)
	{
		return protoAPILayerType switch
		{
			API_v1_ClearGroup.Types.API_v1_ClearGroupLayerType.Music => ClearType.Audio, 
			API_v1_ClearGroup.Types.API_v1_ClearGroupLayerType.AudioEffects => ClearType.AudioEffects, 
			API_v1_ClearGroup.Types.API_v1_ClearGroupLayerType.Props => ClearType.Props, 
			API_v1_ClearGroup.Types.API_v1_ClearGroupLayerType.Messages => ClearType.Messages, 
			API_v1_ClearGroup.Types.API_v1_ClearGroupLayerType.Presentation => ClearType.Slide, 
			API_v1_ClearGroup.Types.API_v1_ClearGroupLayerType.Announcements => ClearType.Announcement, 
			API_v1_ClearGroup.Types.API_v1_ClearGroupLayerType.PresentationMedia => ClearType.Background, 
			API_v1_ClearGroup.Types.API_v1_ClearGroupLayerType.VideoInput => ClearType.LiveVideo, 
			_ => ClearType.Slide, 
		};
	}

	public static API_v1_ClearGroup.Types.API_v1_ClearGroupLayerType ToProtoAPILayerType(this ClearType clearType)
	{
		return clearType switch
		{
			ClearType.Audio => API_v1_ClearGroup.Types.API_v1_ClearGroupLayerType.Music, 
			ClearType.AudioEffects => API_v1_ClearGroup.Types.API_v1_ClearGroupLayerType.AudioEffects, 
			ClearType.Background => API_v1_ClearGroup.Types.API_v1_ClearGroupLayerType.PresentationMedia, 
			ClearType.LiveVideo => API_v1_ClearGroup.Types.API_v1_ClearGroupLayerType.VideoInput, 
			ClearType.Props => API_v1_ClearGroup.Types.API_v1_ClearGroupLayerType.Props, 
			ClearType.Messages => API_v1_ClearGroup.Types.API_v1_ClearGroupLayerType.Messages, 
			ClearType.Slide => API_v1_ClearGroup.Types.API_v1_ClearGroupLayerType.Presentation, 
			ClearType.Announcement => API_v1_ClearGroup.Types.API_v1_ClearGroupLayerType.Announcements, 
			_ => API_v1_ClearGroup.Types.API_v1_ClearGroupLayerType.Presentation, 
		};
	}

	public static IAction.Types.ClearType ToEntityClearType(this ClearType type)
	{
		IAction.Types.ContentDestination contentDestination = IAction.Types.ContentDestination.Global;
		int targetLayer = type switch
		{
			ClearType.All => 0, 
			ClearType.Audio => 1, 
			ClearType.AudioEffects => 8, 
			ClearType.Background => 2, 
			ClearType.LiveVideo => 3, 
			ClearType.Props => 4, 
			ClearType.Messages => 7, 
			ClearType.Slide => 5, 
			ClearType.ToLogo => 6, 
			ClearType.Announcement => 0, 
			_ => 0, 
		};
		if (type == ClearType.Announcement)
		{
			contentDestination = IAction.Types.ContentDestination.Announcements;
		}
		return new IAction.Types.ClearType((IAction.Types.ClearType.Types.ClearTargetLayer)targetLayer, contentDestination);
	}

	public static ClearType ToClearType(this IAction.Types.ClearType clearType)
	{
		IAction.Types.ClearType.Types.ClearTargetLayer targetLayer = clearType.TargetLayer;
		if (clearType.ContentDestination == IAction.Types.ContentDestination.Announcements)
		{
			return ClearType.Announcement;
		}
		return targetLayer switch
		{
			IAction.Types.ClearType.Types.ClearTargetLayer.All => ClearType.All, 
			IAction.Types.ClearType.Types.ClearTargetLayer.Audio => ClearType.Audio, 
			IAction.Types.ClearType.Types.ClearTargetLayer.Background => ClearType.Background, 
			IAction.Types.ClearType.Types.ClearTargetLayer.LiveVideo => ClearType.LiveVideo, 
			IAction.Types.ClearType.Types.ClearTargetLayer.Prop => ClearType.Props, 
			IAction.Types.ClearType.Types.ClearTargetLayer.Slide => ClearType.Slide, 
			IAction.Types.ClearType.Types.ClearTargetLayer.Logo => ClearType.ToLogo, 
			IAction.Types.ClearType.Types.ClearTargetLayer.Messages => ClearType.Messages, 
			IAction.Types.ClearType.Types.ClearTargetLayer.AudioEffects => ClearType.AudioEffects, 
			_ => ClearType.All, 
		};
	}
}
