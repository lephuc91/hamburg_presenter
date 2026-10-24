using Pro.Common.Components;
using Pro.DO.Triggering;
using ProPresenter.DO.Actions;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels.Actions;

public abstract class ActionDialogContentVM : LinkedNotifyPropertyChangedBase, IActionDialogContentVM
{
	private IActionDialogContext? _context;

	public IActionRepository? ActionStore => _context?.ActionStore;

	public IAction? Action => _context?.Action;

	public void SetContext(IActionDialogContext? context)
	{
		IActionDialogContext context2 = _context;
		_context = context;
		OnContextChanged(context2, context);
		OnPropertyChanged("ActionStore");
		OnPropertyChanged("Action");
	}

	protected virtual void OnContextChanged(IActionDialogContext? oldValue, IActionDialogContext? newValue)
	{
	}

	public void OnDone()
	{
		_context?.OnDone();
	}
}
