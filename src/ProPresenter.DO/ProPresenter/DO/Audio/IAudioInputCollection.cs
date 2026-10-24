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

namespace ProPresenter.DO.Audio;

public interface IAudioInputCollection : INotifyEnumerableChanged<AudioInput>, IEnumerable<AudioInput>, IEnumerable, INotifyCollectionChanged, IDragDropCollection<AudioInput>, IReadOnlyList<AudioInput>, IReadOnlyCollection<AudioInput>
{
	UndoStack UndoStack { get; }

	event System.Action? CollectionModified;

	AudioInput AddInput();

	IReadOnlyObjectBinder<AudioInputCollection, IMergedCollection<IMergedAudioInput>> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IMergedEntityFactory mergedEntityFactory, IAudioInputDeviceCollection audioDevices, IVideoInputDeviceCollection videoDevices, IMergedCollection<IMergedAudioInput> right);

	void Deserialize(RepeatedField<Pro.SerializationInterop.RVProtoData.AudioInput> protoAudioInputs, AudioInputDeviceCollection audioDevices, VideoInputDeviceCollection videoDevices);

	void RemoveInput(AudioInput input);
}
