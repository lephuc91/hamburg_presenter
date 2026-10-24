using System;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Audio;

public class DeviceChannel : ChannelBase
{
	public override string Name
	{
		get
		{
			return $"{base.Index + 1}";
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public override bool CanRename => false;

	public static ObjectBinder<DeviceChannel, IDigitalAudio.Types.IDevice.Types.IChannel> CreateBinder(DeviceChannel? left, IDigitalAudio.Types.IDevice.Types.IChannel? right)
	{
		ObjectBinder<DeviceChannel, IDigitalAudio.Types.IDevice.Types.IChannel> objectBinder = new ObjectBinder<DeviceChannel, IDigitalAudio.Types.IDevice.Types.IChannel>(left, right);
		objectBinder.Bind((DeviceChannel l) => l.WhenPropertyChanges("MuteActive"), (IDigitalAudio.Types.IDevice.Types.IChannel r) => r.MuteEnable.WhenValueChanges, delegate(DeviceChannel l, IDigitalAudio.Types.IDevice.Types.IChannel r)
		{
			r.MuteEnable.Set(l.MuteActive);
		}, delegate(IDigitalAudio.Types.IDevice.Types.IChannel r, DeviceChannel l)
		{
			l.MuteActive = r.MuteEnable.Value;
		}).Bind((DeviceChannel l) => l.WhenPropertyChanges("SoloActive"), (IDigitalAudio.Types.IDevice.Types.IChannel r) => r.SoloEnable.WhenValueChanges, delegate(DeviceChannel l, IDigitalAudio.Types.IDevice.Types.IChannel r)
		{
			r.SoloEnable.Set(l.SoloActive);
		}, delegate(IDigitalAudio.Types.IDevice.Types.IChannel r, DeviceChannel l)
		{
			l.SoloActive = r.SoloEnable.Value;
		}).Bind((DeviceChannel l) => l.WhenPropertyChanges("TestActive"), (IDigitalAudio.Types.IDevice.Types.IChannel r) => r.ToneEnable.WhenValueChanges, delegate(DeviceChannel l, IDigitalAudio.Types.IDevice.Types.IChannel r)
		{
			r.ToneEnable.Set(l.TestActive);
		}, delegate(IDigitalAudio.Types.IDevice.Types.IChannel r, DeviceChannel l)
		{
			l.TestActive = r.ToneEnable.Value;
		})
			.Bind((DeviceChannel l) => l.WhenPropertyChanges("Delay"), (IDigitalAudio.Types.IDevice.Types.IChannel r) => r.AudioDelay.WhenValueChanges, delegate(DeviceChannel l, IDigitalAudio.Types.IDevice.Types.IChannel r)
			{
				r.AudioDelay.Set(l.Delay.TotalSeconds);
			}, delegate(IDigitalAudio.Types.IDevice.Types.IChannel r, DeviceChannel l)
			{
				l.Delay = TimeSlice.FromSeconds(r.AudioDelay.Value);
			})
			.Bind((DeviceChannel l) => l.WhenPropertyChanges("Level"), (IDigitalAudio.Types.IDevice.Types.IChannel r) => r.Level.WhenValueChanges, delegate(DeviceChannel l, IDigitalAudio.Types.IDevice.Types.IChannel r)
			{
				r.Level.Set(l.Level);
			}, delegate(IDigitalAudio.Types.IDevice.Types.IChannel r, DeviceChannel l)
			{
				l.Level = r.Level.Value;
			});
		return objectBinder;
	}

	public DigitalAudio.Types.Device.Types.Channel Serialize()
	{
		return new DigitalAudio.Types.Device.Types.Channel
		{
			MuteEnable = MuteActive,
			SoloEnable = SoloActive,
			ToneEnable = TestActive,
			AudioDelay = Delay.TotalSeconds,
			Level = base.Level
		};
	}

	public void Deserialize(DigitalAudio.Types.Device.Types.Channel? protoDeviceChannel)
	{
		if (protoDeviceChannel == null)
		{
			Delay = TimeSlice.Zero;
			base.Level = 0.0;
			MuteActive = false;
			SoloActive = false;
			TestActive = false;
		}
		else
		{
			MuteActive = protoDeviceChannel.MuteEnable;
			SoloActive = protoDeviceChannel.SoloEnable;
			TestActive = protoDeviceChannel.ToneEnable;
			Delay = TimeSlice.FromSeconds(protoDeviceChannel.AudioDelay);
			base.Level = protoDeviceChannel.Level;
		}
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.Audio.Types.PhysicalChannel? protoPhysicalChannel)
	{
		Delay = TimeSlice.Zero;
		base.Level = 0.0;
		if (protoPhysicalChannel == null)
		{
			MuteActive = false;
			SoloActive = false;
			TestActive = false;
		}
		else
		{
			MuteActive = protoPhysicalChannel.MuteEnable;
			SoloActive = protoPhysicalChannel.SoloEnable;
			TestActive = protoPhysicalChannel.ToneEnable;
		}
	}
}
