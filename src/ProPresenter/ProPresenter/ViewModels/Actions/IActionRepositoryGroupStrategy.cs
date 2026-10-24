using System.Collections.Generic;
using ProPresenter.DO;
using ProPresenter.DO.Actions;

namespace ProPresenter.ViewModels.Actions;

public interface IActionRepositoryGroupStrategy
{
	void AssignGroup(IActionRepoContainer container, string label, IEnumerable<IActionRepository> repos);
}
