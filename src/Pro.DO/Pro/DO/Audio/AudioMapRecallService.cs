using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Pro.Common.SourceGenerator.Attributes;
using Pro.ssAPI.Devices;

namespace Pro.DO.Audio;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class AudioMapRecallService<I, O> : IAudioMapRecallService<I, O>, IDisposable where I : IChannel, new() where O : IChannel, new()
{
	private readonly Dictionary<IDevice, IAudioMap<I, O>> _audioDeviceToRoutingMap = new Dictionary<IDevice, IAudioMap<I, O>>();

	private readonly Func<ChannelSet<I>, ChannelSet<O>, IAudioMap<I, O>> _createAudiMap;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public AudioMapRecallService(Func<ChannelSet<I>, ChannelSet<O>, IAudioMap<I, O>> createAudiMap)
	{
		_createAudiMap = createAudiMap;
	}

	public void RecallAudioMap(IDevice selectedDevice, IAudioMap<I, O> targetMap)
	{
		if (_audioDeviceToRoutingMap.TryGetValue(selectedDevice, out IAudioMap<I, O> value))
		{
			RecallMap(targetMap, value);
			return;
		}
		targetMap.ClearMap();
		targetMap.AutoMap();
		StoreAudioMap(selectedDevice, targetMap);
	}

	public void AddOrUpdateAudioMap(IDevice selectedDevice, IAudioMap<I, O> map)
	{
		if (!_audioDeviceToRoutingMap.TryGetValue(selectedDevice, out IAudioMap<I, O> value))
		{
			value = StoreAudioMap(selectedDevice, map);
		}
		RecallMap(value, map, resizeTarget: true);
	}

	private static void RecallMap(IAudioMap<I, O> target, IAudioMap<I, O> source, bool resizeTarget = false)
	{
		target.CopyFrom(source);
		if (resizeTarget)
		{
			if (source.InputSet.ChannelCount > target.InputSet.ChannelCount)
			{
				target.InputSet.Resize(source.InputSet.ChannelCount);
			}
			if (source.OutputSet.ChannelCount > target.OutputSet.ChannelCount)
			{
				target.OutputSet.Resize(source.OutputSet.ChannelCount);
			}
		}
	}

	private IAudioMap<I, O> StoreAudioMap(IDevice selectedDevice, IAudioMap<I, O> map)
	{
		ChannelSet<I> channelSet = new ChannelSet<I>();
		channelSet.Resize(map.InputSet.ChannelCount);
		ChannelSet<O> channelSet2 = new ChannelSet<O>();
		channelSet2.Resize(map.OutputSet.ChannelCount);
		IAudioMap<I, O> audioMap = _createAudiMap(channelSet, channelSet2);
		_audioDeviceToRoutingMap[selectedDevice] = audioMap;
		return audioMap;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		foreach (KeyValuePair<IDevice, IAudioMap<I, O>> item in _audioDeviceToRoutingMap)
		{
			item.Deconstruct(out var _, out var value);
			value.Dispose();
		}
		_audioDeviceToRoutingMap.Clear();
	}
}
