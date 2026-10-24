using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Google.Protobuf.Collections;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Entity;
using Pro.Entity.Merged.Collections;
using Pro.Entity.Merged.Entities;
using Pro.Entity.Merged.Factory;
using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI.Devices;

namespace ProPresenter.DO.LiveVideo;

public interface ILiveVideoInputCollection : INotifyEnumerableChanged<LiveVideoInput>, IEnumerable<LiveVideoInput>, IEnumerable, INotifyCollectionChanged, IDragDropCollection<LiveVideoInput>, IReadOnlyList<LiveVideoInput>, IReadOnlyCollection<LiveVideoInput>
{
	int InputCount { get; set; }

	UndoStack UndoStack { get; }

	event System.Action? CollectionModified;

	void RemoveInput(LiveVideoInput input);

	void Deserialize(RepeatedField<VideoInput> videoInputs, AudioInputDeviceCollection audioDevices, VideoInputDeviceCollection videoDevices);

	IReadOnlyObjectBinder<LiveVideoInputCollection, IMergedCollection<IMergedVideoInput>> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IMergedEntityFactory mergedEntityFactory, IAudioInputDeviceCollection audioDevices, IVideoInputDeviceCollection videoDevices, IMergedCollection<IMergedVideoInput> right);
}
