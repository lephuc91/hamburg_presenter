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
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Audio;
using Pro.Entity;
using Pro.Entity.Merged.Collections;
using Pro.Entity.Merged.Entities;
using Pro.Entity.Merged.Factory;
using Pro.Localization.Services;
using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI.Devices;
using ProPresenter.DO.Analytics.Events.TrackedEvents;

namespace ProPresenter.DO.Audio;

public class AudioInputCollection : ImmutableObservableCollection<AudioInput>, IAudioInputCollection, INotifyEnumerableChanged<AudioInput>, IEnumerable<AudioInput>, IEnumerable, INotifyCollectionChanged, IDragDropCollection<AudioInput>, IReadOnlyList<AudioInput>, IReadOnlyCollection<AudioInput>
{
	private readonly IAudioSetup _audioSetup;

	private readonly IAudioMapRecallService<DeviceChannel, Bus> _audioMapRecallService;

	private readonly ILocalization _localization;

	private readonly IAudioSettingsAnalyticsEventPublisher _analyticsEventPublisher;

	public UndoStack UndoStack { get; } = new UndoStack();

	public event System.Action? CollectionModified;

	public IReadOnlyObjectBinder<AudioInputCollection, IMergedCollection<IMergedAudioInput>> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IMergedEntityFactory mergedEntityFactory, IAudioInputDeviceCollection audioDevices, IVideoInputDeviceCollection videoDevices, IMergedCollection<IMergedAudioInput> right)
	{
		ObjectBinder<AudioInputCollection, IMergedCollection<IMergedAudioInput>> objectBinder = new ObjectBinder<AudioInputCollection, IMergedCollection<IMergedAudioInput>>(this, right);
		objectBinder.Bind((AudioInputCollection l) => l.WhenCollectionChanges(), (IMergedCollection<IMergedAudioInput> r) => r.WhenCollectionChanges, delegate(AudioInputCollection l, IMergedCollection<IMergedAudioInput> r)
		{
			r.SynchronizeFrom(l, (AudioInput m, IMergedAudioInput e) => m.ID == e.Uuid.Value, delegate(AudioInput m)
			{
				IMergedAudioInput mergedAudioInput = mergedEntityFactory.CreateMergedAudioInput(m.ID);
				ObjectBinder<AudioInput, IMergedAudioInput> objectBinder2 = m.Bind(scheduler, entityFactory, audioDevices, videoDevices, mergedAudioInput);
				objectBinder2.InitializeRightFromLeft();
				mergedAudioInput.RegisterLinkedDisposable(objectBinder2);
				return mergedAudioInput;
			});
		}, delegate(IMergedCollection<IMergedAudioInput> r, AudioInputCollection l)
		{
			r.Items.SynchronizeTo(l, (IMergedAudioInput e, AudioInput m) => m.ID == e.Uuid.Value, delegate(IMergedAudioInput e, int i)
			{
				AudioInput audioInput = new AudioInput(_audioSetup.Buses, _audioMapRecallService, _localization, _analyticsEventPublisher);
				ObjectBinder<AudioInput, IMergedAudioInput> objectBinder3 = audioInput.Bind(scheduler, entityFactory, audioDevices, videoDevices, e);
				objectBinder3.InitializeLeftFromRight();
				e.RegisterLinkedDisposable(objectBinder3);
				l.InsertInput(audioInput, i);
			}, l.Collection.Move, delegate(int i)
			{
				AudioInput audioInput2 = l.Items.ElementAtOrDefault(i);
				if (audioInput2 != null)
				{
					l.RemoveInput(audioInput2);
				}
			});
		}, null, scheduler.Scheduler);
		return objectBinder;
	}

	public AudioInputCollection(IAudioSetup audioSetup, IAudioMapRecallService<DeviceChannel, Bus> audioMapRecallService, ILocalization localization, IAudioSettingsAnalyticsEventPublisher analyticsEventPublisher)
	{
		_audioSetup = audioSetup;
		_audioMapRecallService = audioMapRecallService;
		_localization = localization;
		_analyticsEventPublisher = analyticsEventPublisher;
		base.CollectionChanged += delegate
		{
			OnCollectionModified();
		};
	}

	private void OnCollectionModified()
	{
		UpdateIndices();
		this.CollectionModified?.Invoke();
	}

	private void UpdateIndices()
	{
		int num = 1;
		foreach (AudioInput item in base.Collection)
		{
			item.Index = num++;
		}
	}

	public AudioInput AddInput()
	{
		AudioInput audioInput = new AudioInput(_audioSetup.Buses, _audioMapRecallService, _localization, _analyticsEventPublisher);
		AddInput(audioInput);
		return audioInput;
	}

	private void AddInput(AudioInput input)
	{
		InsertInput(input, base.Count);
	}

	private void InsertInput(AudioInput input, int index)
	{
		onInsert();
		UndoStack.Commit(UndoActionTypes.AddAudioInput.ToAction(), delegate
		{
			RemoveInput(input);
		}, onInsert, null, null, autoFinalize: true);
		void onInsert()
		{
			input.UndoStack = UndoStack;
			input.DataModified += OnCollectionModified;
			base.Collection.Insert(index, input);
		}
	}

	public void RemoveInput(AudioInput input)
	{
		onRemove();
		UndoStack.Commit(UndoActionTypes.RemoveAudioInput.ToAction(), delegate
		{
			AddInput(input);
		}, onRemove, null, null, autoFinalize: true);
		void onRemove()
		{
			int num = IndexOf(input);
			if (num >= 0)
			{
				input.DataModified -= OnCollectionModified;
				base.Collection.RemoveAt(num);
			}
		}
	}

	public void Deserialize(RepeatedField<Pro.SerializationInterop.RVProtoData.AudioInput> protoAudioInputs, AudioInputDeviceCollection audioDevices, VideoInputDeviceCollection videoDevices)
	{
		UndoStack?.StartIgnoring();
		base.Collection.ToArray().ForEach(RemoveInput);
		foreach (Pro.SerializationInterop.RVProtoData.AudioInput protoAudioInput in protoAudioInputs)
		{
			AddInput().Deserialize(protoAudioInput, audioDevices, videoDevices);
		}
		UndoStack?.StopIgnoring();
	}

	void IDragDropCollection<AudioInput>.DraggedFrom(IEnumerable<AudioInput> items)
	{
		throw new NotSupportedException();
	}

	void IDragDropCollection<AudioInput>.DroppedInto(IEnumerable<AudioInput> items, int index, bool isCopy)
	{
		throw new NotSupportedException();
	}

	public void MoveTo(IEnumerable<AudioInput> items, int index)
	{
		AudioInput audioInput = items.FirstOrDefault();
		int origIndex = ((audioInput == null) ? (-1) : base.Collection.IndexOf(audioInput));
		if (origIndex > index)
		{
			origIndex++;
		}
		base.Collection.MoveTo(items, index);
		UndoStack.Commit(UndoActionTypes.MoveAudioInput.ToAction(), delegate
		{
			((IDragDropCollection<AudioInput>)this).MoveTo(items, origIndex);
		}, delegate
		{
			((IDragDropCollection<AudioInput>)this).MoveTo(items, index);
		}, null, null, autoFinalize: true);
	}
}
