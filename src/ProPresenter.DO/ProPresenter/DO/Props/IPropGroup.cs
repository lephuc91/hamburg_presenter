using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.DO.Application;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.Props;

public interface IPropGroup : IImmutableObservableCollection<IPropCue>, IReadOnlyList<IPropCue>, IEnumerable<IPropCue>, IEnumerable, IReadOnlyCollection<IPropCue>, INotifyEnumerableChanged<IPropCue>, INotifyCollectionChanged, IDragDropNotifyEnumerableChanged<IPropCue>, IDragDropCollection<IPropCue>, ICutPasteCollection<IPropCue>, ICutCollection<IPropCue>, INotifyPropertyChanged, ICloneable<IPropGroup>, IIdentifiable
{
	bool SingleMode { get; set; }

	UndoStack? UndoStack { get; set; }

	event System.Action? DataModified;

	IPropCue AddProp(TemplateSlide? template = null);

	void AddProp(IPropCue cue);

	void AddProps(IEnumerable<IPropCue> cues);

	void InsertProp(IPropCue cue, int index);

	IPropCue InsertProp(TemplateSlide? template, int index);

	void RemoveProp(IPropCue cue);

	void RemoveProps(IEnumerable<IPropCue> cues);

	PropDocument.Types.PropCollection Serialize();

	void Deserialize(PropDocument document, PropDocument.Types.PropCollection collection, ApplicationData? applicationData);

	IReadOnlyObjectBinder<IPropGroup, IPropDocument.Types.IPropCollection> Bind(IUiScheduler scheduler, IApp app, IProPresenterDOFactoryProvider factoryProvider, IPropDocument.Types.IPropCollection entity);
}
