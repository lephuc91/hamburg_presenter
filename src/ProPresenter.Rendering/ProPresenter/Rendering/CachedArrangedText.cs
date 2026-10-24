using Pro.Text;

namespace ProPresenter.Rendering;

internal class CachedArrangedText
{
	public bool IsValid { get; set; }

	public TextDocument? Document { get; set; }

	public ArrangedText? ArrangedText { get; set; }

	public CachedArrangedText(TextDocument document)
	{
		Document = document;
	}
}
