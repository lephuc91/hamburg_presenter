using System.Collections.Generic;
using Pro.Common.Components.Reversibility;
using ProPresenter.DO.Actions;

namespace ProPresenter.DO;

public interface IActionRepoContainer
{
	UndoStack? UndoStack { get; }

	void Insert(IEnumerable<IActionRepository> newRepos, IActionRepository? repo, bool insertBefore);
}
