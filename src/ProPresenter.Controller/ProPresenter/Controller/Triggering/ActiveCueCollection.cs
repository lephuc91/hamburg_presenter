using Pro.Common.Collections;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenter.Controller.Triggering;

public class ActiveCueCollection : OutputDestinationIndexedCollection<ArrangedCue?>
{
	private readonly TriggerHandle[] _handles;

	private readonly IDocumentCue?[] _documents;

	public ActiveCueCollection()
	{
		_handles = new TriggerHandle[base.Count];
		_documents = new IDocumentCue[base.Count];
		for (int i = 0; i < base.Count; i++)
		{
			_handles[i] = TriggerHandle.Invalid;
			_documents[i] = null;
		}
	}

	public TriggerHandle GetActiveHandle(OutputDestination destination)
	{
		return _handles[(int)destination];
	}

	public TriggerHandle GetActiveHandle(Action.Types.ContentDestination destination)
	{
		return GetActiveHandle(destination.ToDestination());
	}

	public IDocumentCue? GetActiveDocument(OutputDestination destination)
	{
		return _documents[(int)destination];
	}

	public void SetActiveCue(OutputDestination destination, ArrangedCue? cue, IDocumentCue? documentCue, TriggerHandle handle)
	{
		base.Items[(int)destination] = cue;
		_handles[(int)destination] = handle;
		_documents[(int)destination] = documentCue;
		UpdateLink(destination);
	}

	public bool UpdateLink(OutputDestination destination)
	{
		IDocumentCue? obj = _documents[(int)destination];
		ArrangedCue arrangedCue = base.Items[(int)destination];
		IImmutableObservableCollection<ArrangedCue> immutableObservableCollection = obj?.DocumentAction?.ActiveArrangement?.ArrangedCues;
		if (immutableObservableCollection == null)
		{
			return false;
		}
		if (arrangedCue != null)
		{
			if (immutableObservableCollection.Contains(arrangedCue))
			{
				return true;
			}
			foreach (ArrangedCue item in immutableObservableCollection)
			{
				if (item.Source.ID == arrangedCue.Source.ID && item.Source.ParentPresentation == arrangedCue.Source.ParentPresentation)
				{
					base.Items[(int)destination] = item;
					return true;
				}
			}
		}
		return false;
	}
}
