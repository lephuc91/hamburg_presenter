using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;

namespace ProPresenter.Controller.AsyncTransferHandlers.NetworkTriggerDataHandlers;

public class PresentationLibraryNetworkTriggerDataHandler : INetworkTriggerDataHandler
{
	private readonly ICoreManager _coreManager;

	private readonly LibraryCollection _libraries;

	public PresentationLibraryNetworkTriggerDataHandler(ICoreManager coreManager, LibraryCollection libraries)
	{
		_coreManager = coreManager;
		_libraries = libraries;
	}

	public NetworkTriggerDataItem? Handle(NetworkIdentifier id, ITriggerOperation op)
	{
		if (_libraries == null || id.Identifiers.Count != 3)
		{
			return null;
		}
		ILibrary library = id.Identifiers[0].FindItem(_libraries);
		if (library == null)
		{
			return null;
		}
		DocumentCue documentCue = id.Identifiers[1].FindItem(library.SortedItems);
		if (documentCue == null)
		{
			return null;
		}
		ArrangedCue slide = id.Identifiers[2].FindItem(documentCue.DocumentAction.ActiveArrangement?.ArrangedCues, (ArrangedCue s) => s.Name ?? string.Empty);
		return _coreManager.ToTriggerDataItem(slide, documentCue, op);
	}
}
