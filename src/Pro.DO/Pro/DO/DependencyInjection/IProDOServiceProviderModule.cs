using Jab;
using Pro.DO.Audio;
using Pro.DO.Utility;

namespace Pro.DO.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Singleton<ITextDocumentFactory, TextDocumentFactory>]
[Jab.Singleton<IAudioSetup, AudioSetup>]
[Jab.Singleton<IAudioMapRecallService<DeviceChannel, Bus>>(Factory = "CreateAudioMapRecallService")]
public interface IProDOServiceProviderModule
{
	static IAudioMapRecallService<DeviceChannel, Bus> CreateAudioMapRecallService()
	{
		return new AudioMapRecallService<DeviceChannel, Bus>((ChannelSet<DeviceChannel> i, ChannelSet<Bus> o) => new AudioMap<DeviceChannel, Bus>(i, o));
	}
}
