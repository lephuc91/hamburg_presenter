using System;
using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents;

public record PrintEvent(uint DocumentCount, PrintMode Mode, PrintInclusionFlags Flags, uint NumberColumns, string PrintToDevice) : IAnalyticEvent
{
	public record PrintInclusionFlags(bool IncludeMetadata, bool IncludePresentationNotes, bool IncludeCurrentDate, bool IncludeSlideLabels, bool IncludeSlideNotes, bool IncludeDisabledSlides);

	public enum PrintMode
	{
		Thumbnail,
		Outline
	}

	public static void Publish(uint documentCount, PrintMode mode, PrintInclusionFlags flags, uint numberColumns, string printToDevice)
	{
		EventPublisher.Publish(new PrintEvent(documentCount, mode, flags, numberColumns, printToDevice));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.Print print = new Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.Print
			{
				DocumentCount = DocumentCount
			};
			Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.Print print2 = print;
			print2.Mode = Mode switch
			{
				PrintMode.Thumbnail => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.Print.Types.PrintMode.Thumbnail, 
				PrintMode.Outline => Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents.Print.Types.PrintMode.Outline, 
				_ => throw new NotImplementedException($"Unknown {"PrintMode"} {Mode} encountered."), 
			};
			print.IncludeMetadata = Flags.IncludeMetadata;
			print.IncludePresentationNotes = Flags.IncludePresentationNotes;
			print.IncludeCurrentDate = Flags.IncludeCurrentDate;
			print.IncludeSlideLabels = Flags.IncludeSlideLabels;
			print.IncludeSlideNotes = Flags.IncludeSlideNotes;
			print.IncludeDisabledSlides = Flags.IncludeDisabledSlides;
			print.NumberColumns = NumberColumns;
			print.PrintToDevice = PrintToDevice;
			e.Print = print;
		});
	}
}
