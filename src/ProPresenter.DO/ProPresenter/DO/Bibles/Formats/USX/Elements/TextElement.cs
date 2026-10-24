namespace ProPresenter.DO.Bibles.Formats.USX.Elements;

internal class TextElement : ElementBase
{
	public override ElementType Type => ElementType.Text;

	public string Content { get; }

	public TextElement(string content)
	{
		Content = content;
	}
}
