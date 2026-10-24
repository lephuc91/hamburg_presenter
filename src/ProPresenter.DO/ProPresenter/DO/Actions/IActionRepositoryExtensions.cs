using System.Linq;
using Pro.Common.Collections;
using Pro.DO.Triggering;
using ProPresenter.DO.Macros;

namespace ProPresenter.DO.Actions;

public static class IActionRepositoryExtensions
{
	public static bool CanAssignData(this IActionRepository? repo, object? data, IAction? action)
	{
		bool flag = false;
		if (data != null && repo != null)
		{
			flag = (!(repo is ProPresenterMacro proPresenterMacro) || !(data is ProPresenterMacro obj) || !proPresenterMacro.Equals(obj)) && repo.Actions.OfType<ActionBase>().None((ActionBase a) => a.IsDataSelected(data));
		}
		if (!flag)
		{
			if (action != null && data != null)
			{
				return action.IsDataSelected(data);
			}
			return false;
		}
		return true;
	}
}
