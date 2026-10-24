using ProPresenter.DO.Actions;

namespace ProPresenter.DO.Cues;

public interface IHeaderCue
{
	string Name { get; }

	HeaderAction HeaderAction { get; }
}
