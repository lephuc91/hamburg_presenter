using Pro.Text;

namespace ProPresenter.Rendering;

internal class CachedTextLayers
{
	public bool IsValid { get; set; }

	public TextDocument? Document { get; set; }

	public TextLayerInfo[]? TextLayers { get; set; }

	public CachedTextLayers(TextDocument document)
	{
		Document = document;
	}
}
