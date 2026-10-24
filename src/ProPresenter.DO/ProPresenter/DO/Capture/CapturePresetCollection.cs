using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Google.Protobuf.Collections;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Capture;

public class CapturePresetCollection : ImmutableObservableCollection<ICapturePreset>, ICapturePresetCollection, INotifyEnumerableChanged<ICapturePreset>, IEnumerable<ICapturePreset>, IEnumerable, INotifyCollectionChanged, IReadOnlyCollection<ICapturePreset>
{
	private readonly ICapturePresetFactory _presetFactory;

	private UndoStack? _undoStack;

	public UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			_undoStack = value;
			foreach (ICapturePreset item in base.Collection)
			{
				item.UndoStack = value;
			}
		}
	}

	public ICapturePresetFactory Factory => _presetFactory;

	public event System.Action? DataModified;

	public event Action<ICapturePreset>? PresetRenamed;

	public IReadOnlyObjectBinder<ICapturePresetCollection, IComplexCollection<IRecording.Types.IPreset>> CreateBinder(IUiScheduler scheduler, IEntityFactory entityFactory, IComplexCollection<IRecording.Types.IPreset> right)
	{
		ObjectBinder<CapturePresetCollection, IComplexCollection<IRecording.Types.IPreset>> objectBinder = new ObjectBinder<CapturePresetCollection, IComplexCollection<IRecording.Types.IPreset>>(this, right);
		objectBinder.Bind((CapturePresetCollection l) => l.WhenCollectionChanges(), (IComplexCollection<IRecording.Types.IPreset> r) => r.WhenCollectionChanges, delegate(CapturePresetCollection l, IComplexCollection<IRecording.Types.IPreset> r)
		{
			r.SynchronizeFrom(l, (ICapturePreset m, IRecording.Types.IPreset e) => m.ID == e.Id.Value, delegate(ICapturePreset m)
			{
				IRecording.Types.IPreset preset = entityFactory.Create<IRecording.Types.IPreset>();
				ObjectBinder<ICapturePreset, IRecording.Types.IPreset> objectBinder2 = CapturePreset.CreateBinder(scheduler, entityFactory, m, preset);
				objectBinder2.InitializeRightFromLeft();
				preset.RegisterLinkedDisposable(objectBinder2);
				return preset;
			});
		}, delegate(IComplexCollection<IRecording.Types.IPreset> r, CapturePresetCollection l)
		{
			r.Items.SynchronizeTo(l, (IRecording.Types.IPreset e, ICapturePreset m) => m.ID == e.Id.Value, delegate(IRecording.Types.IPreset e, int i)
			{
				ICapturePreset capturePreset = l.Factory.Create();
				ObjectBinder<ICapturePreset, IRecording.Types.IPreset> objectBinder3 = CapturePreset.CreateBinder(scheduler, entityFactory, capturePreset, e);
				objectBinder3.InitializeLeftFromRight();
				e.RegisterLinkedDisposable(objectBinder3);
				l.InsertPreset(capturePreset, i);
			}, l.Collection.Move, delegate(int i)
			{
				ICapturePreset capturePreset2 = l.ElementAtOrDefault(i);
				if (capturePreset2 != null)
				{
					l.RemovePreset(capturePreset2);
				}
			});
		}, null, scheduler.Scheduler);
		return objectBinder;
	}

	public CapturePresetCollection(ICapturePresetFactory presetFactory)
		: base(new ObservableCollection<ICapturePreset>())
	{
		_presetFactory = presetFactory;
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public void Clear()
	{
		base.Collection.ForEach(RemovePreset);
	}

	public void AddPreset(ICapturePreset preset)
	{
		InsertPreset(preset, base.Collection.Count);
	}

	public void InsertPreset(ICapturePreset preset, int index)
	{
		if (!base.Collection.Contains(preset))
		{
			preset.DataModified += OnDataModified;
			preset.UndoStack = UndoStack;
			preset.PropertyChanged += Preset_PropertyChanged;
			base.Collection.Insert(index, preset);
			OnDataModified();
			UndoStack?.Commit(UndoActionTypes.CreatePreset.ToAction(), delegate
			{
				RemovePreset(preset);
			}, delegate
			{
				InsertPreset(preset, index);
			});
		}
	}

	private void Preset_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (sender is ICapturePreset obj && e.PropertyName == "Name")
		{
			this.PresetRenamed?.Invoke(obj);
		}
	}

	public void RemovePreset(ICapturePreset preset)
	{
		preset.DataModified -= OnDataModified;
		base.Collection.Remove(preset);
		OnDataModified();
		UndoStack?.Commit(UndoActionTypes.DeletePreset.ToAction(), delegate
		{
			AddPreset(preset);
		}, delegate
		{
			RemovePreset(preset);
		});
	}

	public void Deserialize(RepeatedField<Recording.Types.Preset> protoPresets)
	{
		UndoStack?.StartIgnoring();
		base.Collection.DeserializeCollection(protoPresets, (ICapturePreset m, Recording.Types.Preset p) => m.ID == p.Id.ToGuid(), (Recording.Types.Preset p) => Create(), delegate(ICapturePreset m)
		{
			AddPreset(m);
		}, RemovePreset, delegate(ICapturePreset m, Recording.Types.Preset p)
		{
			if (m != null)
			{
				m.DataModified -= OnDataModified;
				m.Deserialize(p);
				m.DataModified += OnDataModified;
			}
		});
		UndoStack?.StopIgnoring();
	}

	public IEnumerable<Recording.Types.Preset> Serialize()
	{
		return base.Collection.Select((ICapturePreset p) => p.Serialize()).ToArray();
	}

	public ICapturePreset Create()
	{
		return _presetFactory.Create();
	}
}
