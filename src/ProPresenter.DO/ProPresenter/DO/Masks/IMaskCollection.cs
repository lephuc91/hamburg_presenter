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
using Pro.Entity.Collections;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.Masks;

public interface IMaskCollection : IImmutableObservableCollection<SlideCue>, IReadOnlyList<SlideCue>, IEnumerable<SlideCue>, IEnumerable, IReadOnlyCollection<SlideCue>, INotifyEnumerableChanged<SlideCue>, INotifyCollectionChanged, ICutPasteCollection<SlideCue>, ICutCollection<SlideCue>, INotifyPropertyChanged
{
	UndoStack UndoStack { get; }

	event System.Action? CollectionModified;

	IReadOnlyObjectBinder<IMaskCollection, IComplexCollection<IProMask>> CreateBinder(IUiScheduler scheduler, IComplexCollection<IProMask> right);

	void ReplaceMasks(IEnumerable<SlideCue> masks);

	void MoveTo(IEnumerable<SlideCue> items, int index);

	void Add();

	void Insert(int index, SlideCue cue);

	SlideCue Insert(int index, TemplateSlide template);

	void Remove(SlideCue cue);

	void RemoveRange(IEnumerable<SlideCue> masks);

	void Clear();

	IEnumerable<ProMask> Serialize();

	void Deserialize(IEnumerable<ProMask> protoMasks, ApplicationData? applicationData, bool removeExisting = true);
}
