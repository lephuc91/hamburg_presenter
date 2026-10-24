using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Strings;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Events;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.DO.Looks;

public class AudienceLookCollection : ImmutableObservableCollection<AudienceLook>, IAudienceLookCollection, INotifyEnumerableChanged<AudienceLook>, IEnumerable<AudienceLook>, IEnumerable, INotifyCollectionChanged, IReadOnlyList<AudienceLook>, IReadOnlyCollection<AudienceLook>, ICutPasteCollection<AudienceLook>, ICutCollection<AudienceLook>, IDragDropCollection<AudienceLook>
{
	private readonly AudienceScreenArrangementCollection _audienceScreenArrangements;

	public event System.Action? CollectionModified;

	public static ObjectBinder<AudienceLookCollection, IComplexCollection<IProAudienceLook>> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, AudienceScreenArrangementCollection audienceScreens, AudienceLookCollection left, IComplexCollection<IProAudienceLook> right)
	{
		ObjectBinder<AudienceLookCollection, IComplexCollection<IProAudienceLook>> objectBinder = new ObjectBinder<AudienceLookCollection, IComplexCollection<IProAudienceLook>>(left, right);
		objectBinder.Bind((AudienceLookCollection l) => l.WhenCollectionChanges(), (IComplexCollection<IProAudienceLook> r) => r.WhenCollectionChanges, delegate(AudienceLookCollection l, IComplexCollection<IProAudienceLook> r)
		{
			r.SynchronizeFrom(l.Collection, (AudienceLook m, IProAudienceLook e) => m.ID == e.Uuid.Value, delegate(AudienceLook m)
			{
				IProAudienceLook proAudienceLook = entityFactory.Create<IProAudienceLook>();
				ObjectBinder<AudienceLook, IProAudienceLook> objectBinder2 = AudienceLook.CreateBinder(scheduler, entityFactory, m, proAudienceLook);
				objectBinder2.InitializeRightFromLeft();
				proAudienceLook.RegisterLinkedDisposable(objectBinder2);
				return proAudienceLook;
			});
		}, delegate(IComplexCollection<IProAudienceLook> r, AudienceLookCollection l)
		{
			r.Items.SynchronizeTo(l, (IProAudienceLook e, AudienceLook m) => m.ID == e.Uuid.Value, delegate(IProAudienceLook e, int i)
			{
				AudienceLook audienceLook = new AudienceLook(audienceScreens);
				ObjectBinder<AudienceLook, IProAudienceLook> objectBinder3 = AudienceLook.CreateBinder(scheduler, entityFactory, audienceLook, e);
				objectBinder3.InitializeLeftFromRight();
				e.RegisterLinkedDisposable(objectBinder3);
				l.Insert(i, audienceLook);
			}, l.Collection.Move, delegate(int i)
			{
				AudienceLook audienceLook2 = l.Items.ElementAtOrDefault(i);
				if (audienceLook2 != null)
				{
					l.Remove(audienceLook2);
				}
			});
		}, null, scheduler.Scheduler);
		return objectBinder;
	}

	public AudienceLookCollection(AudienceScreenArrangementCollection audienceScreenArrangements)
	{
		_audienceScreenArrangements = audienceScreenArrangements;
		base.CollectionChanged += delegate
		{
			OnCollectionModified();
		};
	}

	public AudienceLook Add(string name = "")
	{
		AudienceLook audienceLook = new AudienceLook(name, _audienceScreenArrangements);
		Add(audienceLook);
		return audienceLook;
	}

	public void Add(AudienceLook audienceLook)
	{
		Insert(base.Count, audienceLook);
	}

	public void Insert(int index, AudienceLook audienceLook)
	{
		OnInsert(audienceLook.ToEnumerable(), index);
	}

	private void OnInsert(IEnumerable<AudienceLook> looks, int index)
	{
		foreach (AudienceLook look in looks)
		{
			if (string.IsNullOrEmpty(look.Name))
			{
				look.Name = LocalizedStrings.Get("AUDIENCE_LOOKS_NEW_LOOK_name");
			}
			look.Name = look.Name.DuplicateName(base.Collection, (AudienceLook a) => a.Name);
			look.DataModified += OnCollectionModified;
			base.Collection.Insert(index, look);
			index++;
		}
	}

	public void Remove(AudienceLook audienceLook)
	{
		audienceLook.DataModified -= OnCollectionModified;
		base.Collection.Remove(audienceLook);
	}

	private void OnCollectionModified()
	{
		this.CollectionModified?.Invoke();
		LooksUpdated.Publish(base.Collection);
	}

	internal IEnumerable<ProAudienceLook> Serialize()
	{
		return base.Collection.Select((AudienceLook a) => a.Serialize());
	}

	public Pro.SerializationInterop.RVProtoData.AudienceLookCollection SerializeLooks()
	{
		Pro.SerializationInterop.RVProtoData.AudienceLookCollection audienceLookCollection = new Pro.SerializationInterop.RVProtoData.AudienceLookCollection();
		audienceLookCollection.Collection.AddRange(Serialize());
		return audienceLookCollection;
	}

	internal void Deserialize(IEnumerable<ProAudienceLook>? audienceLooks, bool removeExisting = true)
	{
		base.Collection.DeserializeCollection(audienceLooks ?? Enumerable.Empty<ProAudienceLook>(), (AudienceLook a, ProAudienceLook d) => a.ID == d.Uuid.ToGuid(), (ProAudienceLook d) => new AudienceLook(d.Name, _audienceScreenArrangements), Add, delegate(AudienceLook l)
		{
			if (removeExisting)
			{
				Remove(l);
			}
		}, delegate(AudienceLook a, ProAudienceLook d)
		{
			a.DataModified -= OnCollectionModified;
			a.Deserialize(d, deserializeID: true);
			a.DataModified += OnCollectionModified;
		});
	}

	public void DraggedFrom(IEnumerable<AudienceLook> items)
	{
	}

	public void DroppedInto(IEnumerable<AudienceLook> items, int index, bool isCopy)
	{
		items = (isCopy ? items.CloneItems() : items);
		OnInsert(items, index);
	}

	public void MoveTo(IEnumerable<AudienceLook> items, int index)
	{
		base.Collection.MoveTo(items, index);
	}

	public void CutFrom(IEnumerable<AudienceLook> items)
	{
		items.ForEach(Remove);
	}

	public void PasteInto(IEnumerable<AudienceLook> items, int index)
	{
		items.Reverse().ForEach(delegate(AudienceLook i)
		{
			Insert(index, i);
		});
	}
}
