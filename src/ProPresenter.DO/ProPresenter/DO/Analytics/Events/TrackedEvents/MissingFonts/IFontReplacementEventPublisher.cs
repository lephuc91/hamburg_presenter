namespace ProPresenter.DO.Analytics.Events.TrackedEvents.MissingFonts;

public interface IFontReplacementEventPublisher
{
	void Publish(string missingFont, string replacementFont, ReplacementFontSource source);
}
