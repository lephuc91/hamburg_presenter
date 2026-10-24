using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Effects;
using Pro.DO.Effects.Descriptions;
using Pro.DO.Effects.Extensions;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Media;

public class EffectsCollection : ImmutableObservableCollection<EffectParameters>, IDragDropCollection<EffectParameters>, ICloneable<EffectsCollection>
{
	private Guid _id = Guid.Empty;

	private string _name;

	private bool _hasChanges;

	public Guid ID
	{
		get
		{
			return _id;
		}
		set
		{
			SetValue("ID", ref _id, value, OnDataModified);
		}
	}

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			SetValue("Name", ref _name, value, delegate(string o, string n)
			{
				this.FilenameModified?.Invoke(this, n);
			});
		}
	}

	public bool HasChanges
	{
		get
		{
			return _hasChanges;
		}
		set
		{
			SetValue("HasChanges", ref _hasChanges, value, OnDataModified);
		}
	}

	public bool IsLocked { get; private set; }

	public event Action<EffectsCollection>? DataModified;

	public event Action<EffectsCollection, EffectParameters>? ParametersDataModified;

	public event Action<EffectsCollection, string>? FilenameModified;

	public static ObjectBinder<EffectsCollection, IComplexCollection<IEffect>> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, IReadOnlyList<EffectDescription> availableEffects, EffectsCollection left, IComplexCollection<IEffect> right)
	{
		return new ObjectBinder<EffectsCollection, IComplexCollection<IEffect>>(left, right).Bind((EffectsCollection l) => l.WhenCollectionChanges(), (IComplexCollection<IEffect> r) => r.WhenCollectionChanges, delegate(EffectsCollection l, IComplexCollection<IEffect> r)
		{
			r.SynchronizeFrom(l, (EffectParameters lParameters, IEffect rEffect) => lParameters.ID == rEffect.Uuid.Value, delegate(EffectParameters lParameters)
			{
				IEffect effect = entityFactory.Create<IEffect>();
				ObjectBinder<EffectParameters, IEffect> objectBinder = EffectParameters.CreateBinder(entityFactory, lParameters, effect);
				objectBinder.InitializeRightFromLeft();
				effect.RegisterLinkedDisposable(objectBinder);
				return effect;
			});
		}, delegate(IComplexCollection<IEffect> r, EffectsCollection l)
		{
			r.Items.SynchronizeTo(l, (IEffect rEffect, EffectParameters lParameters) => lParameters.ID == rEffect.Uuid.Value, delegate(IEffect rEffect, int i)
			{
				EffectDescription description = availableEffects.First((EffectDescription x) => x.ID == Guid.Parse(rEffect.RenderId.Value));
				EffectParameters effectParameters = new EffectParameters(rEffect.Uuid.Value, description);
				ObjectBinder<EffectParameters, IEffect> objectBinder2 = EffectParameters.CreateBinder(entityFactory, effectParameters, rEffect);
				objectBinder2.InitializeLeftFromRight();
				rEffect.RegisterLinkedDisposable(objectBinder2);
				l.InsertEffect(effectParameters, i);
			}, l.Collection.Move, delegate(int index)
			{
				EffectParameters parameters = l[index];
				l.RemoveEffect(parameters);
			});
		}, null, scheduler.Scheduler);
	}

	public void SerializeToEntity(IEntityFactory entityFactory, Pro.Entity.Collections.ICollection<IEffect> effects)
	{
		base.Collection.SynchronizeTo(effects.Items, (EffectParameters lParameters, IEffect rEffect) => lParameters.ID == rEffect.Uuid.Value, delegate(EffectParameters lParameters, int index)
		{
			IEffect effect = entityFactory.Create<IEffect>();
			lParameters.SerializeToEntity(entityFactory, effect);
			effects.Insert(index, effect);
		}, effects.Move, delegate(int index)
		{
			effects.Items[index].Dispose();
			effects.RemoveAt(index);
		});
	}

	public void DeserializeEntity(Pro.Entity.Collections.ICollection<IEffect> effects, IReadOnlyList<EffectDescription> availableEffects)
	{
		effects.Items.SynchronizeTo(base.Collection, (IEffect rEffect, EffectParameters lParameters) => lParameters.ID == rEffect.Uuid.Value, delegate(IEffect rEffect, int index)
		{
			EffectDescription description = availableEffects.First((EffectDescription x) => x.ID == Guid.Parse(rEffect.RenderId.Value));
			EffectParameters effectParameters = new EffectParameters(rEffect.Uuid.Value, description);
			effectParameters.DeserializeEntity(rEffect);
			InsertEffect(effectParameters, index);
		}, base.Collection.Move, delegate(int index)
		{
			EffectParameters parameters = base.Collection[index];
			RemoveEffect(parameters);
		});
	}

	public EffectsCollection(string name = "")
	{
		_name = name;
	}

	public void ReplaceEffect(EffectParameters targetParameters, EffectParameters newParameters)
	{
		if (!IsLocked)
		{
			OnReplaceEffect(targetParameters, newParameters);
			OnDataModified();
			return;
		}
		throw new Exception("Update to collection not allowed. Collection is locked.");
	}

	public void AddEffect(EffectParameters parameters)
	{
		if (!IsLocked)
		{
			OnAddEffects(new global::_003C_003Ez__ReadOnlySingleElementList<EffectParameters>(parameters));
			OnDataModified();
			return;
		}
		throw new Exception("Update to collection not allowed. Collection is locked.");
	}

	private void InsertEffect(EffectParameters parameters, int index)
	{
		if (!IsLocked)
		{
			OnInsertEffect(parameters, index);
			OnDataModified();
			return;
		}
		throw new Exception("Update to collection not allowed. Collection is locked.");
	}

	public void RemoveEffect(EffectParameters parameters)
	{
		if (!IsLocked)
		{
			OnRemoveEffects(new global::_003C_003Ez__ReadOnlySingleElementList<EffectParameters>(parameters));
			OnDataModified();
			return;
		}
		throw new Exception("Update to collection not allowed. Collection is locked.");
	}

	public void RemoveAllEffects()
	{
		if (!IsLocked)
		{
			OnRemoveEffects(base.Collection.ToArray());
			OnDataModified();
			return;
		}
		throw new Exception("Update to collection not allowed. Collection is locked.");
	}

	public void UpdateEffects(IEnumerable<EffectParameters> effects)
	{
		OnRemoveEffects(base.Collection.ToArray());
		OnAddEffects(effects);
		HasChanges = false;
		OnDataModified();
	}

	private void OnAddEffects(IEnumerable<EffectParameters> effects)
	{
		HasChanges = true;
		effects.ForEach(delegate(EffectParameters e)
		{
			e.ParametersChanged += Parameters_DataModified;
			base.Collection.Add(e);
		});
	}

	private void OnInsertEffect(EffectParameters effect, int index)
	{
		HasChanges = true;
		effect.ParametersChanged += Parameters_DataModified;
		base.Collection.Insert(index, effect);
	}

	private void OnRemoveEffects(IEnumerable<EffectParameters> effects)
	{
		HasChanges = true;
		effects.ForEach(delegate(EffectParameters e)
		{
			e.ParametersChanged -= Parameters_DataModified;
			base.Collection.Remove(e);
		});
	}

	private void OnReplaceEffect(EffectParameters targetParameters, EffectParameters newParameters)
	{
		HasChanges = true;
		targetParameters.ParametersChanged -= Parameters_DataModified;
		newParameters.ParametersChanged += Parameters_DataModified;
		int num = base.Collection.IndexOf(targetParameters);
		if (num >= 0)
		{
			base.Collection[num] = newParameters;
		}
	}

	void IDragDropCollection<EffectParameters>.DraggedFrom(IEnumerable<EffectParameters> items)
	{
		throw new NotSupportedException("Removing items from drag source not supported.");
	}

	void IDragDropCollection<EffectParameters>.DroppedInto(IEnumerable<EffectParameters> items, int index, bool isCopy)
	{
		throw new NotSupportedException("Adding items from drag source not supported.");
	}

	public void MoveTo(IEnumerable<EffectParameters> items, int index)
	{
		HasChanges = true;
		base.Collection.MoveTo(items, index);
		OnDataModified();
	}

	private void Parameters_DataModified(EffectParameters parameters)
	{
		HasChanges = true;
		OnParametersDataModified(parameters);
	}

	public EffectsCollection Clone()
	{
		EffectsCollection effectsCollection = new EffectsCollection();
		effectsCollection._id = _id;
		effectsCollection._name = _name;
		using (IEnumerator<EffectParameters> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				EffectParameters current = enumerator.Current;
				effectsCollection.AddEffect(current.MakeCopy());
			}
		}
		effectsCollection._hasChanges = _hasChanges;
		return effectsCollection;
	}

	public void Lock()
	{
		IsLocked = true;
	}

	protected internal Effect.Types.Preset SerializePreset()
	{
		Effect.Types.Preset preset = new Effect.Types.Preset();
		preset.Uuid = ID.ToUUID();
		preset.Name = Name ?? string.Empty;
		foreach (Effect item in SerializeEffects())
		{
			preset.Effects.Add(item);
		}
		return preset;
	}

	protected internal void DeserializePreset(string filename, Effect.Types.Preset data, IReadOnlyList<EffectDescription> availableEffects)
	{
		if (data != null)
		{
			Name = (string.IsNullOrWhiteSpace(filename) ? data.Name : Path.GetFileNameWithoutExtension(filename));
			DeserializeEffects(data.Uuid.ToGuid(), data.Effects.ToList(), availableEffects);
			HasChanges = false;
		}
	}

	public List<Effect> SerializeEffects()
	{
		List<Effect> list = new List<Effect>();
		using IEnumerator<EffectParameters> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			EffectParameters current = enumerator.Current;
			list.Add(current.Serialize());
		}
		return list;
	}

	public void DeserializeEffects(Guid id, IEnumerable<Effect> effects, IReadOnlyList<EffectDescription> availableEffects)
	{
		ID = id;
		base.Collection.DeserializeCollection(effects, (EffectParameters p, Effect e) => e.Uuid != null && p?.EffectDescription?.ID == e.Uuid.ToGuid() && availableEffects.Any((EffectDescription a) => a.ID == e.Uuid.ToGuid()), (Effect e) => new EffectParameters(availableEffects?.FirstOrDefault((EffectDescription a) => a.ID.ToString().ToUpperInvariant() == e.RenderId), e.Enabled), AddEffect, RemoveEffect, delegate(EffectParameters p, Effect e)
		{
			p?.Deserialize(e);
		});
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke(this);
	}

	private void OnParametersDataModified(EffectParameters parameters)
	{
		this.ParametersDataModified?.Invoke(this, parameters);
		OnDataModified();
	}
}
