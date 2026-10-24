using System.Windows.Input;

namespace Pro.UI.Controls.Markdown.Renderer;

public interface IHyperlinkCommandProvider
{
	ICommand? Get(string? key);
}
