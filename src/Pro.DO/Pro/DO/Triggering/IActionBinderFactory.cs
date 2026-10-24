using Pro.Common.ObjectBinding;
using Pro.Entity;

namespace Pro.DO.Triggering;

public interface IActionBinderFactory
{
	IReadOnlyObjectBinder<IAction, Pro.Entity.IAction> CreateBinder(IAction left, Pro.Entity.IAction right);

	IAction CreateAction(Pro.Entity.IAction right, string containerId);
}
