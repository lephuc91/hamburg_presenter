using ProPresenter.DO.Librarian;

namespace ProPresenter.DO.Cues;

public interface IMaybeUnresolvedCue
{
	bool NeedsResolve();

	ProPresenterCue? Resolve(ILibraryCollection cues);
}
