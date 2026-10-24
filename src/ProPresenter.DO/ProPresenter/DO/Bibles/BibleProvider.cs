using Pro.Common.Components;
using Pro.Common.Dispatcher;
using ProPresenter.DO.Registration.Operations;
using ProPresenter.DO.Registration.State;

namespace ProPresenter.DO.Bibles;

public class BibleProvider : DisposableBase, IBibleProvider
{
	public AvailableBibleCollection AvailableBibles { get; }

	public InstalledBibleCollection InstalledBibles { get; }

	public LoadedBibleCollection LoadedBibles { get; }

	public BibleProvider(IRegistrationOperationFactory registrationOperationFactory, IRegistrationStateProvider registrationStateProvider, IUiDispatcher dispatcher, IBibleDataStore bibleStore)
	{
		InstalledBibles = new InstalledBibleCollection(registrationOperationFactory, CommonPaths.Bibles, dispatcher, bibleStore);
		AvailableBibles = new AvailableBibleCollection(registrationStateProvider, InstalledBibles, dispatcher);
		LoadedBibles = new LoadedBibleCollection(InstalledBibles, AvailableBibles);
	}

	protected override void OnDispose(bool disposeObjects)
	{
		base.OnDispose(disposeObjects);
		if (disposeObjects)
		{
			AvailableBibles.Dispose();
		}
	}
}
