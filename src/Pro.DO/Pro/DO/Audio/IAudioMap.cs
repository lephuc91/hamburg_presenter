using System;
using System.Collections.Generic;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Audio;

public interface IAudioMap<I, O> : IDisposable where I : IChannel, new() where O : IChannel, new()
{
	ChannelSet<I> InputSet { get; }

	bool IsCustomMap { get; }

	bool MuteActive { get; set; }

	ChannelSet<O> OutputSet { get; }

	bool SoloActive { get; set; }

	event Action<bool>? IsCustomMapChanged;

	event System.Action? MapInvalidated;

	void AutoMap();

	void ClearMap();

	void CopyFrom(IAudioMap<I, O> sourceMap);

	void Deserialize(IEnumerable<DigitalAudio.Types.Device.Types.Map> protoMaps, bool isCustomMap, bool inputToOutput);

	bool IsMapped(I input, O output);

	IEnumerable<DigitalAudio.Types.Device.Types.Map> Serialize(bool inputToOutput);

	void Toggle(I input, O output);

	void ToggleOff(I input, O output);

	void ToggleOn(I input, O output);
}
