using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.DO;
using Pro.DO.Application;
using Pro.DO.Transitions;
using Pro.DO.Utility;
using Pro.Localization.Services;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Transitions;

namespace ProPresenter.DO.Props;

public class PropCueCollection : PropGroup, IPropCueCollection, IPropGroup, IImmutableObservableCollection<IPropCue>, IReadOnlyList<IPropCue>, IEnumerable<IPropCue>, IEnumerable, IReadOnlyCollection<IPropCue>, INotifyEnumerableChanged<IPropCue>, INotifyCollectionChanged, IDragDropNotifyEnumerableChanged<IPropCue>, IDragDropCollection<IPropCue>, ICutPasteCollection<IPropCue>, ICutCollection<IPropCue>, INotifyPropertyChanged, ICloneable<IPropGroup>, IIdentifiable
{
	private TransitionParameters? _selectedTransition;

	public TransitionParameters? SelectedTransition
	{
		get
		{
			return _selectedTransition;
		}
		set
		{
			SetValue("SelectedTransition", ref _selectedTransition, value, base.OnDataModified);
		}
	}

	public PropCueCollection(IApp app, ILocalization localization, ITransitionDescriptionCollection transitionDescriptions, IProPresenterDOFactoryProvider factoryProvider)
		: base(app, localization, factoryProvider, transitionDescriptions)
	{
		base.UndoStack = new UndoStack();
	}

	public void Deserialize(PropDocument document, bool removeExisting = true)
	{
		base.UndoStack?.StartIgnoring();
		ApplicationData applicationData = ApplicationData.Deserialize(document.ApplicationInfo);
		base.Collection.DeserializeCollection(document.Cues, (IPropCue s, Cue c) => s.ID == c.Uuid.ToGuid(), (Cue c) => new PropCue(base.App, base.FactoryProvider, base.TransitionDescriptions), AddProp, delegate(IPropCue p)
		{
			if (removeExisting)
			{
				RemoveProp(p);
			}
		}, delegate(IPropCue s, Cue c)
		{
			s.Deserialize(c, applicationData, MediaContainerIds.Prop(base.ID));
		});
		SelectedTransition = document.Transition.ToTransition(base.TransitionDescriptions);
		base.UndoStack?.StopIgnoring();
	}

	public PropDocument SerializePropDocument()
	{
		PropDocument propDocument = new PropDocument();
		propDocument.ApplicationInfo = new ApplicationData(ApplicationType.ProPresenter).Serialize();
		propDocument.Transition = SelectedTransition?.Serialize();
		propDocument.Cues.AddRange(base.Collection.Select((IPropCue p) => p.Serialize()));
		return propDocument;
	}

	public void Save()
	{
		OnDataModified();
	}
}
