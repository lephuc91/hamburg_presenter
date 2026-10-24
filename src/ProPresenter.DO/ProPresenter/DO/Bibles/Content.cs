namespace ProPresenter.DO.Bibles;

public class Content
{
	public string Text { get; }

	public AttributeRange[] AttributeRanges { get; }

	public Content(string text, AttributeRange[]? attributeRanges = null)
	{
		Text = text;
		AttributeRanges = attributeRanges ?? new AttributeRange[0];
	}
}
