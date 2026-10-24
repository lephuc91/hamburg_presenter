using System;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(OutputDestination), typeof(Pro.SerializationInterop.RVProtoData.Action.Types.ContentDestination), DestinationToSourceMethodName = "ToDestination", SourceToDestinationMethodName = "ToProtoDestination", UnmatchedDestinationNames = new string[] { "Global", "Announcements" }, UnmatchedSourceNames = new string[] { "Presentation", "Announcement" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(OutputDestination), typeof(IAction.Types.ContentDestination), DestinationToSourceMethodName = "ToOutputDestination", SourceToDestinationMethodName = "ToContentDestination", UnmatchedDestinationNames = new string[] { "Global", "Announcements" }, UnmatchedSourceNames = new string[] { "Presentation", "Announcement" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(OutputDestination), typeof(API_v1_Presentation.Types.Destination), DestinationToSourceMethodName = "ToContentDestination", SourceToDestinationMethodName = "ToAPIProtoDestination", UnmatchedDestinationNames = new string[] { "Presentation", "Announcements" }, UnmatchedSourceNames = new string[] { "Presentation", "Announcement" })]
public static class OutputDestinationExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Action.Types.ContentDestination ToProtoDestination(this OutputDestination source)
	{
		return source switch
		{
			OutputDestination.Presentation => Pro.SerializationInterop.RVProtoData.Action.Types.ContentDestination.Global, 
			OutputDestination.Announcement => Pro.SerializationInterop.RVProtoData.Action.Types.ContentDestination.Announcements, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static OutputDestination ToDestination(this Pro.SerializationInterop.RVProtoData.Action.Types.ContentDestination source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Action.Types.ContentDestination.Global => OutputDestination.Presentation, 
			Pro.SerializationInterop.RVProtoData.Action.Types.ContentDestination.Announcements => OutputDestination.Announcement, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static IAction.Types.ContentDestination ToContentDestination(this OutputDestination source)
	{
		return source switch
		{
			OutputDestination.Presentation => IAction.Types.ContentDestination.Global, 
			OutputDestination.Announcement => IAction.Types.ContentDestination.Announcements, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static OutputDestination ToOutputDestination(this IAction.Types.ContentDestination source)
	{
		return source switch
		{
			IAction.Types.ContentDestination.Global => OutputDestination.Presentation, 
			IAction.Types.ContentDestination.Announcements => OutputDestination.Announcement, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static API_v1_Presentation.Types.Destination ToAPIProtoDestination(this OutputDestination source)
	{
		return source switch
		{
			OutputDestination.Presentation => API_v1_Presentation.Types.Destination.Presentation, 
			OutputDestination.Announcement => API_v1_Presentation.Types.Destination.Announcements, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static OutputDestination ToContentDestination(this API_v1_Presentation.Types.Destination source)
	{
		return source switch
		{
			API_v1_Presentation.Types.Destination.Presentation => OutputDestination.Presentation, 
			API_v1_Presentation.Types.Destination.Announcements => OutputDestination.Announcement, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}
}
