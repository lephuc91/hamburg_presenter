using Pro.Common.Collections;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.ViewModels;

public class RemoveScreenOperation : IRemoveScreenOperation
{
	private readonly IRemoveScreenValidator? _validator;

	public RemoveScreenOperation(IRemoveScreenValidator? validator = null)
	{
		_validator = validator;
	}

	public bool Execute(ScreenArrangementBase target, ScreenArrangementCollectionBase collection, out ScreenArrangementBase? newSelection)
	{
		newSelection = null;
		if (_validator != null && !_validator.CanRemoveScreen(target))
		{
			return false;
		}
		if (target.ScreenTargetType == ScreenTargetType.Stage || collection.Count > 1)
		{
			newSelection = collection.GetPrevious(target) ?? collection.GetNext(target);
			collection.RemoveScreen(target);
			return true;
		}
		return false;
	}
}
