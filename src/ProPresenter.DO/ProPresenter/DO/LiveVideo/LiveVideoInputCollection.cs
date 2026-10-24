using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Google.Protobuf.Collections;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Audio;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Merged.Collections;
using Pro.Entity.Merged.Entities;
using Pro.Entity.Merged.Factory;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI.Devices;

namespace ProPresenter.DO.LiveVideo;

public class LiveVideoInputCollection : ImmutableObservableCollection<LiveVideoInput>, ILiveVideoInputCollection, INotifyEnumerableChanged<LiveVideoInput>, IEnumerable<LiveVideoInput>, IEnumerable, INotifyCollectionChanged, IDragDropCollection<LiveVideoInput>, IReadOnlyList<LiveVideoInput>, IReadOnlyCollection<LiveVideoInput>
{
	private int _inputCount;

	private readonly IAudioSetup _audioSetup;

	private readonly IAudioMapRecallService<DeviceChannel, Bus> _audioMapRecallService;

	public int InputCount
	{
		get
		{
			return _inputCount;
		}
		set
		{
			SetValue("InputCount", ref _inputCount, value, delegate(int o, int n)
			{
				UndoStack.Commit(UndoActionTypes.AddVideoInput.ToAction(), this, "InputCount", o, n, null, null, autoFinalize: true);
				OnInputCountChanged(o, n);
			});
		}
	}

	public UndoStack UndoStack { get; } = new UndoStack();

	public event System.Action? CollectionModified;

	public IReadOnlyObjectBinder<LiveVideoInputCollection, IMergedCollection<IMergedVideoInput>> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IMergedEntityFactory mergedEntityFactory, IAudioInputDeviceCollection audioDevices, IVideoInputDeviceCollection videoDevices, IMergedCollection<IMergedVideoInput> mergedCollection)
	{
		ObjectBinder<LiveVideoInputCollection, IMergedCollection<IMergedVideoInput>> objectBinder = new ObjectBinder<LiveVideoInputCollection, IMergedCollection<IMergedVideoInput>>(this, mergedCollection);
		objectBinder.Bind((LiveVideoInputCollection l) => l.WhenCollectionChanges(), (IMergedCollection<IMergedVideoInput> r) => r.WhenCollectionChanges, delegate(LiveVideoInputCollection l, IMergedCollection<IMergedVideoInput> r)
		{
			r.SynchronizeFrom(l, (LiveVideoInput m, IMergedVideoInput e) => m.ID == e.Uuid.Value, delegate(LiveVideoInput m)
			{
				IMergedVideoInput mergedVideoInput = mergedEntityFactory.CreateMergedVideoInput(m.ID);
				ObjectBinder<LiveVideoInput, IMergedVideoInput> objectBinder2 = m.Bind(scheduler, entityFactory, audioDevices, videoDevices, mergedVideoInput);
				objectBinder2.InitializeRightFromLeft();
				mergedVideoInput.RegisterLinkedDisposable(objectBinder2);
				return mergedVideoInput;
			});
		}, delegate(IMergedCollection<IMergedVideoInput> r, LiveVideoInputCollection l)
		{
			r.Items.SynchronizeTo(l, (IMergedVideoInput e, LiveVideoInput m) => m.ID == e.Uuid.Value, delegate(IMergedVideoInput e, int i)
			{
				LiveVideoInput liveVideoInput = new LiveVideoInput(-1, _audioSetup.Buses, _audioMapRecallService);
				ObjectBinder<LiveVideoInput, IMergedVideoInput> objectBinder3 = liveVideoInput.Bind(scheduler, entityFactory, audioDevices, videoDevices, e);
				objectBinder3.InitializeLeftFromRight();
				e.RegisterLinkedDisposable(objectBinder3);
				l.InsertInput(liveVideoInput, i);
			}, l.Collection.Move, delegate(int i)
			{
				LiveVideoInput liveVideoInput2 = l.Items.ElementAtOrDefault(i);
				if (liveVideoInput2 != null)
				{
					l.RemoveInput(liveVideoInput2);
				}
			});
		}, null, scheduler.Scheduler);
		return objectBinder;
	}

	public LiveVideoInputCollection(IAudioSetup audioSetup, IAudioMapRecallService<DeviceChannel, Bus> audioMapRecallService)
	{
		_audioSetup = audioSetup;
		_audioMapRecallService = audioMapRecallService;
		base.CollectionChanged += delegate
		{
			OnCollectionModified();
		};
	}

	private void OnInputCountChanged(int oldCount, int newCount)
	{
		bool flag = newCount - oldCount > 0;
		for (int i = Math.Min(oldCount, newCount); i < Math.Max(oldCount, newCount); i++)
		{
			if (flag)
			{
				int count = base.Collection.Count;
				OnInsertInput(new LiveVideoInput(count, _audioSetup.Buses, _audioMapRecallService), count);
			}
			else
			{
				OnRemoveInput(base.Collection.LastOrDefault());
			}
		}
	}

	public void RemoveInput(LiveVideoInput input)
	{
		int index = base.Collection.IndexOf(input);
		if (index >= 0)
		{
			onRemove();
			UndoStack.Commit(UndoActionTypes.RemoveVideoInput.ToAction(), delegate
			{
				InsertInput(input, index);
			}, onRemove, null, null, autoFinalize: true);
		}
		void onRemove()
		{
			_inputCount--;
			OnRemoveInput(input);
		}
	}

	private void OnRemoveInput(LiveVideoInput? input)
	{
		if (input != null)
		{
			input.DataModified -= OnCollectionModified;
			base.Collection.Remove(input);
			input.Dispose();
		}
	}

	private void InsertInput(LiveVideoInput input, int index)
	{
		_inputCount++;
		OnInsertInput(input, index);
	}

	private void OnInsertInput(LiveVideoInput input, int index)
	{
		input.UndoStack = UndoStack;
		input.DataModified += OnCollectionModified;
		index = index.Clamp(0, base.Collection.Count());
		base.Collection.Insert(index, input);
	}

	internal void AddInput(LiveVideoInput input)
	{
		InsertInput(input, base.Collection.Count);
	}

	private void OnCollectionModified()
	{
		UpdateIndices();
		this.CollectionModified?.Invoke();
	}

	public void Deserialize(RepeatedField<VideoInput> videoInputs, AudioInputDeviceCollection audioDevices, VideoInputDeviceCollection videoDevices)
	{
		UndoStack?.StartIgnoring();
		int index = 0;
		base.Collection.DeserializeCollection(videoInputs, (LiveVideoInput l, VideoInput p) => l.ID == p.Uuid.ToGuid(), (VideoInput p) => new LiveVideoInput(-1, _audioSetup.Buses, _audioMapRecallService), AddInput, OnRemoveInput, delegate(LiveVideoInput l, VideoInput p)
		{
			l.DataModified -= OnCollectionModified;
			l.Deserialize(p, index++, audioDevices, videoDevices);
			l.DataModified += OnCollectionModified;
		});
		UndoStack?.StopIgnoring();
	}

	void IDragDropCollection<LiveVideoInput>.DraggedFrom(IEnumerable<LiveVideoInput> items)
	{
		throw new NotSupportedException();
	}

	void IDragDropCollection<LiveVideoInput>.DroppedInto(IEnumerable<LiveVideoInput> items, int index, bool isCopy)
	{
		throw new NotSupportedException();
	}

	public void MoveTo(IEnumerable<LiveVideoInput> items, int index)
	{
		LiveVideoInput liveVideoInput = items.FirstOrDefault();
		int origIndex = ((liveVideoInput == null) ? (-1) : base.Collection.IndexOf(liveVideoInput));
		if (origIndex > index)
		{
			origIndex++;
		}
		base.Collection.MoveTo(items, index);
		UndoStack.Commit(UndoActionTypes.MoveVideoInput.ToAction(), delegate
		{
			((IDragDropCollection<LiveVideoInput>)this).MoveTo(items, origIndex);
		}, delegate
		{
			((IDragDropCollection<LiveVideoInput>)this).MoveTo(items, index);
		}, null, null, autoFinalize: true);
	}

	private void UpdateIndices()
	{
		for (int i = 0; i < base.Count; i++)
		{
			base.Collection[i].Index = i;
		}
	}
}
