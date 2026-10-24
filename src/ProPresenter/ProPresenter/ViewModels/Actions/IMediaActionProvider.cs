using System.Collections.Generic;
using ProPresenter.DO.Actions;

namespace ProPresenter.ViewModels.Actions;

public interface IMediaActionProvider
{
	IEnumerable<MediaAction> GetActions();

	IEnumerable<(string DirectoryName, IEnumerable<MediaAction> Actions)> GetGroupedActions();
}
