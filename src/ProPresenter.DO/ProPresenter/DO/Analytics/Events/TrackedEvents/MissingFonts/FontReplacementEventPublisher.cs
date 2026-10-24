using Pro.DO.Analytics;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents.MissingFonts;

public class FontReplacementEventPublisher : IFontReplacementEventPublisher
{
	public void Publish(string missingFont, string replacementFont, ReplacementFontSource source)
	{
		EventPublisher.Publish(new FontReplacementEvent(missingFont, replacementFont, source));
	}
}
