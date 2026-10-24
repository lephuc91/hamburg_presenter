using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents.MissingFonts;

public record FontReplacementEvent(string MissingFont, string ReplacementFont, ReplacementFontSource Source) : IAnalyticEvent
{
	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.FontReplacement = new FontReplacement
			{
				MissingFont = MissingFont,
				ReplacementFont = ReplacementFont,
				Source = (FontReplacement.Types.Source)Source
			};
		});
	}
}
