using System;

namespace ProPresenter.DO.Actions;

public interface IActionDataIdentifier
{
	void SetIdentifier(Guid id, string name);
}
