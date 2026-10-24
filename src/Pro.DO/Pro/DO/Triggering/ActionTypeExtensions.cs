using System;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Triggering;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(Pro.SerializationInterop.RVProtoData.Action.Types.ActionType), typeof(ActionType), SourceToDestinationMethodName = "ToActionType", DestinationToSourceMethodName = "ToProtoActionType", ExcludeSourceNames = new string[] { "Unknown", "Mask", "Multiscreen", "SocialMedia", "ForegroundMedia", "BackgroundMedia", "ExternalPresentation" }, ExcludeDestinationNames = new string[] { "Header", "LiveVideo", "GoToNext", "Placeholder" }, UnmatchedSourceNames = new string[] { "PresentationDocument", "PresentationSlide", "AudioBinPlaylist", "MediaBinPlaylist" }, UnmatchedDestinationNames = new string[] { "Document", "Slide", "AudioPlaylist", "VisualPlaylist" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(Pro.Entity.IAction.Types.ActionType), typeof(ActionType), SourceToDestinationMethodName = "ToActionType", DestinationToSourceMethodName = "ToEntityActionType", ExcludeSourceNames = new string[] { "Unknown", "Mask", "Multiscreen", "SocialMedia", "ForegroundMedia", "BackgroundMedia", "ExternalPresentation" }, ExcludeDestinationNames = new string[] { "Header", "LiveVideo", "GoToNext", "Placeholder" }, UnmatchedSourceNames = new string[] { "PresentationDocument", "PresentationSlide", "AudioBinPlaylist", "MediaBinPlaylist" }, UnmatchedDestinationNames = new string[] { "Document", "Slide", "AudioPlaylist", "VisualPlaylist" })]
public static class ActionTypeExtensions
{
	public static ActionType ToActionType(this Pro.SerializationInterop.RVProtoData.Action.Types.ActionType source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.StageLayout => ActionType.StageLayout, 
			Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.Media => ActionType.Media, 
			Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.Timer => ActionType.Timer, 
			Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.Communication => ActionType.Communication, 
			Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.Clear => ActionType.Clear, 
			Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.Prop => ActionType.Prop, 
			Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.Message => ActionType.Message, 
			Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.PresentationSlide => ActionType.Slide, 
			Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.PresentationDocument => ActionType.Document, 
			Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.PropSlide => ActionType.PropSlide, 
			Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.AudienceLook => ActionType.AudienceLook, 
			Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.AudioInput => ActionType.AudioInput, 
			Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.AudioBinPlaylist => ActionType.AudioPlaylist, 
			Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.MediaBinPlaylist => ActionType.VisualPlaylist, 
			Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.SlideDestination => ActionType.SlideDestination, 
			Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.Macro => ActionType.Macro, 
			Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.ClearGroup => ActionType.ClearGroup, 
			Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.Capture => ActionType.Capture, 
			Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.LibraryPlaylist => ActionType.LibraryPlaylist, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static Pro.SerializationInterop.RVProtoData.Action.Types.ActionType ToProtoActionType(this ActionType source)
	{
		return source switch
		{
			ActionType.StageLayout => Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.StageLayout, 
			ActionType.Media => Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.Media, 
			ActionType.Timer => Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.Timer, 
			ActionType.Communication => Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.Communication, 
			ActionType.Clear => Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.Clear, 
			ActionType.Prop => Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.Prop, 
			ActionType.Message => Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.Message, 
			ActionType.Slide => Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.PresentationSlide, 
			ActionType.Document => Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.PresentationDocument, 
			ActionType.PropSlide => Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.PropSlide, 
			ActionType.AudienceLook => Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.AudienceLook, 
			ActionType.AudioInput => Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.AudioInput, 
			ActionType.VisualPlaylist => Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.MediaBinPlaylist, 
			ActionType.AudioPlaylist => Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.AudioBinPlaylist, 
			ActionType.SlideDestination => Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.SlideDestination, 
			ActionType.Macro => Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.Macro, 
			ActionType.ClearGroup => Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.ClearGroup, 
			ActionType.Capture => Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.Capture, 
			ActionType.LibraryPlaylist => Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.LibraryPlaylist, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static ActionType ToActionType(this Pro.Entity.IAction.Types.ActionType source)
	{
		return source switch
		{
			Pro.Entity.IAction.Types.ActionType.StageLayout => ActionType.StageLayout, 
			Pro.Entity.IAction.Types.ActionType.Media => ActionType.Media, 
			Pro.Entity.IAction.Types.ActionType.Timer => ActionType.Timer, 
			Pro.Entity.IAction.Types.ActionType.Communication => ActionType.Communication, 
			Pro.Entity.IAction.Types.ActionType.Clear => ActionType.Clear, 
			Pro.Entity.IAction.Types.ActionType.Prop => ActionType.Prop, 
			Pro.Entity.IAction.Types.ActionType.Message => ActionType.Message, 
			Pro.Entity.IAction.Types.ActionType.PresentationSlide => ActionType.Slide, 
			Pro.Entity.IAction.Types.ActionType.PresentationDocument => ActionType.Document, 
			Pro.Entity.IAction.Types.ActionType.PropSlide => ActionType.PropSlide, 
			Pro.Entity.IAction.Types.ActionType.AudienceLook => ActionType.AudienceLook, 
			Pro.Entity.IAction.Types.ActionType.AudioInput => ActionType.AudioInput, 
			Pro.Entity.IAction.Types.ActionType.AudioBinPlaylist => ActionType.AudioPlaylist, 
			Pro.Entity.IAction.Types.ActionType.MediaBinPlaylist => ActionType.VisualPlaylist, 
			Pro.Entity.IAction.Types.ActionType.SlideDestination => ActionType.SlideDestination, 
			Pro.Entity.IAction.Types.ActionType.Macro => ActionType.Macro, 
			Pro.Entity.IAction.Types.ActionType.ClearGroup => ActionType.ClearGroup, 
			Pro.Entity.IAction.Types.ActionType.Capture => ActionType.Capture, 
			Pro.Entity.IAction.Types.ActionType.LibraryPlaylist => ActionType.LibraryPlaylist, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static Pro.Entity.IAction.Types.ActionType ToEntityActionType(this ActionType source)
	{
		return source switch
		{
			ActionType.StageLayout => Pro.Entity.IAction.Types.ActionType.StageLayout, 
			ActionType.Media => Pro.Entity.IAction.Types.ActionType.Media, 
			ActionType.Timer => Pro.Entity.IAction.Types.ActionType.Timer, 
			ActionType.Communication => Pro.Entity.IAction.Types.ActionType.Communication, 
			ActionType.Clear => Pro.Entity.IAction.Types.ActionType.Clear, 
			ActionType.Prop => Pro.Entity.IAction.Types.ActionType.Prop, 
			ActionType.Message => Pro.Entity.IAction.Types.ActionType.Message, 
			ActionType.Slide => Pro.Entity.IAction.Types.ActionType.PresentationSlide, 
			ActionType.Document => Pro.Entity.IAction.Types.ActionType.PresentationDocument, 
			ActionType.PropSlide => Pro.Entity.IAction.Types.ActionType.PropSlide, 
			ActionType.AudienceLook => Pro.Entity.IAction.Types.ActionType.AudienceLook, 
			ActionType.AudioInput => Pro.Entity.IAction.Types.ActionType.AudioInput, 
			ActionType.VisualPlaylist => Pro.Entity.IAction.Types.ActionType.MediaBinPlaylist, 
			ActionType.AudioPlaylist => Pro.Entity.IAction.Types.ActionType.AudioBinPlaylist, 
			ActionType.SlideDestination => Pro.Entity.IAction.Types.ActionType.SlideDestination, 
			ActionType.Macro => Pro.Entity.IAction.Types.ActionType.Macro, 
			ActionType.ClearGroup => Pro.Entity.IAction.Types.ActionType.ClearGroup, 
			ActionType.Capture => Pro.Entity.IAction.Types.ActionType.Capture, 
			ActionType.LibraryPlaylist => Pro.Entity.IAction.Types.ActionType.LibraryPlaylist, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}
}
