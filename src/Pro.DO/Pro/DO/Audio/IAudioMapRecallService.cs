using Pro.ssAPI.Devices;

namespace Pro.DO.Audio;

public interface IAudioMapRecallService<I, O> where I : IChannel, new() where O : IChannel, new()
{
	void RecallAudioMap(IDevice selectedDevice, IAudioMap<I, O> targetMap);

	void AddOrUpdateAudioMap(IDevice selectedDevice, IAudioMap<I, O> map);
}
