using Pro.Common.Dispatcher;
using Pro.DO.Transitions;
using ProPresenter.Controller.TransferHandlers;
using ProPresenter.DO;
using ProPresenter.DO.DependencyInjection;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller;

public class TransferHandlerFactory : ITransferHandlerFactory
{
	private readonly IProPresenterResourceService _resources;

	private readonly ITimecodeService _timecodeService;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly IUiDispatcher _uiDispatcher;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	public TransferHandlerFactory(IProPresenterResourceService resources, ITimecodeService timecodeService, IProPresenterDOFactoryProvider factoryProvider, IUiDispatcher uiDispatcher, ITransitionDescriptionCollection transitionDescriptions)
	{
		_resources = resources;
		_timecodeService = timecodeService;
		_factoryProvider = factoryProvider;
		_uiDispatcher = uiDispatcher;
		_transitionDescriptions = transitionDescriptions;
	}

	public ITransferHandler? CreateTransferHandler(ICoreManager manager, ProTriggerTransferType type)
	{
		if (type == ProTriggerTransferType.GetNewContext)
		{
			return new NewContextTransferHandler(manager, _resources, _uiDispatcher, _timecodeService, _factoryProvider, _transitionDescriptions);
		}
		return null;
	}
}
