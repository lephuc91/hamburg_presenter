using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.DO.Looks;

public class ScreenLookCollection : ImmutableObservableCollection<ScreenLook>
{
	public event System.Action? DataModified;

	public static ObjectBinder<ScreenLookCollection, IComplexCollection<IProAudienceLook.Types.IProScreenLook>> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, ScreenLookCollection? left, IComplexCollection<IProAudienceLook.Types.IProScreenLook> right)
	{
		ObjectBinder<ScreenLookCollection, IComplexCollection<IProAudienceLook.Types.IProScreenLook>> objectBinder = new ObjectBinder<ScreenLookCollection, IComplexCollection<IProAudienceLook.Types.IProScreenLook>>(left, right);
		objectBinder.Bind((ScreenLookCollection l) => l.WhenCollectionChanges(), (IComplexCollection<IProAudienceLook.Types.IProScreenLook> r) => r.WhenCollectionChanges, delegate(ScreenLookCollection l, IComplexCollection<IProAudienceLook.Types.IProScreenLook> r)
		{
			r.SynchronizeFrom(l.Collection, (ScreenLook m, IProAudienceLook.Types.IProScreenLook e) => m.ScreenId == e.ProScreenUuid.Value, delegate(ScreenLook m)
			{
				IProAudienceLook.Types.IProScreenLook proScreenLook = entityFactory.Create<IProAudienceLook.Types.IProScreenLook>();
				ObjectBinder<ScreenLook, IProAudienceLook.Types.IProScreenLook> objectBinder2 = ScreenLook.CreateBinder(scheduler, m, proScreenLook);
				objectBinder2.InitializeRightFromLeft();
				proScreenLook.RegisterLinkedDisposable(objectBinder2);
				return proScreenLook;
			});
		}, delegate(IComplexCollection<IProAudienceLook.Types.IProScreenLook> r, ScreenLookCollection l)
		{
			r.Items.SynchronizeTo(l, (IProAudienceLook.Types.IProScreenLook e, ScreenLook m) => m.ScreenId == e.ProScreenUuid.Value, delegate(IProAudienceLook.Types.IProScreenLook e, int i)
			{
				ScreenLook screenLook = new ScreenLook(e.ProScreenUuid.Value);
				ObjectBinder<ScreenLook, IProAudienceLook.Types.IProScreenLook> objectBinder3 = ScreenLook.CreateBinder(scheduler, screenLook, e);
				objectBinder3.InitializeLeftFromRight();
				e.RegisterLinkedDisposable(objectBinder3);
				l.InsertScreenLook(i, screenLook);
			}, l.Collection.Move, delegate(int i)
			{
				ScreenLook screenLook2 = l.Items.ElementAtOrDefault(i);
				if ((object)screenLook2 != null)
				{
					l.RemoveScreenLook(screenLook2);
				}
			});
		}, null, scheduler.Scheduler);
		return objectBinder;
	}

	public ScreenLookCollection()
	{
		base.CollectionChanged += delegate
		{
			OnDataModified();
		};
	}

	public void AddScreenLook(Guid? screenId)
	{
		InsertScreenLook(base.Collection.Count, screenId);
	}

	public void AddScreenLook(ScreenLook? screenLook)
	{
		InsertScreenLook(base.Collection.Count, screenLook);
	}

	public void InsertScreenLook(int index, Guid? screenId)
	{
		if (screenId.HasValue && !base.Collection.Any(delegate(ScreenLook s)
		{
			Guid? screenId2 = s.ScreenId;
			Guid? guid = screenId;
			if (screenId2.HasValue != guid.HasValue)
			{
				return false;
			}
			return !screenId2.HasValue || screenId2.GetValueOrDefault() == guid.GetValueOrDefault();
		}))
		{
			InsertScreenLook(index, new ScreenLook(screenId));
		}
	}

	public void InsertScreenLook(int index, ScreenLook? screenLook)
	{
		if (!(screenLook == null) && !base.Collection.Any(delegate(ScreenLook s)
		{
			Guid? screenId = s.ScreenId;
			Guid? screenId2 = screenLook.ScreenId;
			if (screenId.HasValue != screenId2.HasValue)
			{
				return false;
			}
			return !screenId.HasValue || screenId.GetValueOrDefault() == screenId2.GetValueOrDefault();
		}))
		{
			screenLook.DataModified += OnDataModified;
			base.Collection.Insert(index, screenLook);
		}
	}

	public void RemoveScreenLook(ScreenArrangementBase screen)
	{
		ScreenLook screenLook = base.Collection.FirstOrDefault((ScreenLook l) => l.ScreenId == screen.ID);
		if ((object)screenLook != null)
		{
			RemoveScreenLook(screenLook);
		}
	}

	public void RemoveScreenLook(ScreenLook screenLook)
	{
		screenLook.DataModified -= OnDataModified;
		base.Collection.Remove(screenLook);
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	internal void Update(IEnumerable<ScreenLook> screenLooks)
	{
		base.Collection.ToArray().ForEach(RemoveScreenLook);
		screenLooks.Select((ScreenLook s) => s.Clone()).ForEach(AddScreenLook);
	}

	internal IEnumerable<ProAudienceLook.Types.ProScreenLook> Serialize()
	{
		return base.Collection.Select((ScreenLook s) => s.Serialize());
	}

	internal void Deserialize(IEnumerable<ProAudienceLook.Types.ProScreenLook> screenLooks)
	{
		base.Collection.DeserializeCollection(screenLooks, delegate(ScreenLook s, ProAudienceLook.Types.ProScreenLook d)
		{
			Guid? guid = s?.ScreenId;
			Guid? guid2 = d.ProScreenUuid?.ToGuid();
			if (guid.HasValue != guid2.HasValue)
			{
				return false;
			}
			return !guid.HasValue || guid.GetValueOrDefault() == guid2.GetValueOrDefault();
		}, (ProAudienceLook.Types.ProScreenLook d) => new ScreenLook(d.ProScreenUuid?.ToGuid()), AddScreenLook, delegate
		{
		}, delegate(ScreenLook s, ProAudienceLook.Types.ProScreenLook d)
		{
			if (!(s == null))
			{
				s.DataModified -= OnDataModified;
				s.Deserialize(d);
				s.DataModified += OnDataModified;
			}
		});
	}
}
