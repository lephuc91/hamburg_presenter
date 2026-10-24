using ProPresenter.DO.Actions;

namespace ProPresenter.DO.Cues;

public interface ILinkableCue
{
	bool IsLinked { get; }

	IDocumentAction? DocumentAction { get; }

	MediaAction? MediaAction { get; }
}
