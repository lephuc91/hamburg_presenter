using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.DO.Transitions;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Props;

public interface IPropCueCollection : IPropGroup, IImmutableObservableCollection<IPropCue>, IReadOnlyList<IPropCue>, IEnumerable<IPropCue>, IEnumerable, IReadOnlyCollection<IPropCue>, INotifyEnumerableChanged<IPropCue>, INotifyCollectionChanged, IDragDropNotifyEnumerableChanged<IPropCue>, IDragDropCollection<IPropCue>, ICutPasteCollection<IPropCue>, ICutCollection<IPropCue>, INotifyPropertyChanged, ICloneable<IPropGroup>, IIdentifiable
{
	TransitionParameters? SelectedTransition { get; set; }

	void Deserialize(PropDocument document, bool removeExisting = true);

	void Save();

	PropDocument SerializePropDocument();
}
