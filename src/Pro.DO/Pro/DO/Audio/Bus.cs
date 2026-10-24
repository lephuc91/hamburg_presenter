using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Audio;

public class Bus : ChannelBase
{
	private string _name = string.Empty;

	public override string Name
	{
		get
		{
			if (!string.IsNullOrWhiteSpace(_name))
			{
				return _name;
			}
			return DefaultName;
		}
		set
		{
			SetValue("Name", ref _name, value, base.OnDataModified);
		}
	}

	public string DefaultName => LocalizedStrings.Get("AUDIO_PREFERENCES_ROUTING_PROPRESENTER_CHANNEL_INDEX_label", new object[1] { base.Index + 1 });

	public override bool CanRename => true;

	public static ObjectBinder<Bus, IDigitalAudio.Types.IBus> CreateBinder(Bus? left, IDigitalAudio.Types.IBus? right)
	{
		ObjectBinder<Bus, IDigitalAudio.Types.IBus> objectBinder = new ObjectBinder<Bus, IDigitalAudio.Types.IBus>(left, right);
		objectBinder.Bind((Bus l) => l.WhenPropertyChanges("Name"), (IDigitalAudio.Types.IBus r) => r.Name.WhenValueChanges, delegate(Bus l, IDigitalAudio.Types.IBus r)
		{
			r.Name.Set(l.Name);
		}, delegate(IDigitalAudio.Types.IBus r, Bus l)
		{
			l.Name = r.Name.Value;
		}).Bind((Bus l) => l.WhenPropertyChanges("MuteActive"), (IDigitalAudio.Types.IBus r) => r.Muted.WhenValueChanges, delegate(Bus l, IDigitalAudio.Types.IBus r)
		{
			r.Muted.Set(l.MuteActive);
		}, delegate(IDigitalAudio.Types.IBus r, Bus l)
		{
			l.MuteActive = r.Muted.Value;
		}).Bind((Bus l) => l.WhenPropertyChanges("SoloActive"), (IDigitalAudio.Types.IBus r) => r.Solo.WhenValueChanges, delegate(Bus l, IDigitalAudio.Types.IBus r)
		{
			r.Solo.Set(l.SoloActive);
		}, delegate(IDigitalAudio.Types.IBus r, Bus l)
		{
			l.SoloActive = r.Solo.Value;
		})
			.Bind((Bus l) => l.WhenPropertyChanges("TestActive"), (IDigitalAudio.Types.IBus r) => r.TestTone.WhenValueChanges, delegate(Bus l, IDigitalAudio.Types.IBus r)
			{
				r.TestTone.Set(l.TestActive);
			}, delegate(IDigitalAudio.Types.IBus r, Bus l)
			{
				l.TestActive = r.TestTone.Value;
			})
			.Bind((Bus l) => l.WhenPropertyChanges("Level"), (IDigitalAudio.Types.IBus r) => r.MasterLevel.WhenValueChanges, delegate(Bus l, IDigitalAudio.Types.IBus r)
			{
				r.MasterLevel.Set(l.Level);
			}, delegate(IDigitalAudio.Types.IBus r, Bus l)
			{
				l.Level = r.MasterLevel.Value;
			});
		return objectBinder;
	}

	public DigitalAudio.Types.Bus Serialize()
	{
		return new DigitalAudio.Types.Bus
		{
			Name = (Name ?? string.Empty),
			Muted = MuteActive,
			Solo = SoloActive,
			TestTone = TestActive,
			MasterLevel = base.Level
		};
	}

	public void Deserialize(DigitalAudio.Types.Bus protoBus)
	{
		if (protoBus != null)
		{
			Name = protoBus.Name;
			MuteActive = protoBus.Muted;
			SoloActive = protoBus.Solo;
			TestActive = protoBus.TestTone;
			base.Level = protoBus.MasterLevel;
		}
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.Audio.Types.LogicalChannel protoChannel)
	{
		if (protoChannel != null)
		{
			Name = protoChannel.Name;
			MuteActive = protoChannel.Muted;
		}
	}
}
