using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Audio;

public static class BehaviorModeExtensions
{
	public static Pro.SerializationInterop.RVProtoData.AudioInput.Types.BehaviorMode ToProtoBehaviorMode(this BehaviorMode behaviorMode, IEnumerable<uint> linkedVideoInputs)
	{
		Pro.SerializationInterop.RVProtoData.AudioInput.Types.BehaviorMode behaviorMode2 = new Pro.SerializationInterop.RVProtoData.AudioInput.Types.BehaviorMode();
		switch (behaviorMode)
		{
		case BehaviorMode.On:
			behaviorMode2.On = new Pro.SerializationInterop.RVProtoData.AudioInput.Types.BehaviorMode.Types.On();
			break;
		case BehaviorMode.Off:
			behaviorMode2.Off = new Pro.SerializationInterop.RVProtoData.AudioInput.Types.BehaviorMode.Types.Off();
			break;
		case BehaviorMode.AutoOff:
			behaviorMode2.AutoOff = new Pro.SerializationInterop.RVProtoData.AudioInput.Types.BehaviorMode.Types.AutoOff();
			break;
		case BehaviorMode.AutoOn:
			behaviorMode2.AutoOn = new Pro.SerializationInterop.RVProtoData.AudioInput.Types.BehaviorMode.Types.AutoOn();
			behaviorMode2.AutoOn.LinkedVideoInputs.AddRange(linkedVideoInputs);
			break;
		default:
			throw new NotSupportedException();
		}
		return behaviorMode2;
	}

	public static (BehaviorMode behaviorMode, IEnumerable<int>? linkedVideoInputs) ToBehaviorMode(this Pro.SerializationInterop.RVProtoData.AudioInput.Types.BehaviorMode protoBehaviorMode)
	{
		BehaviorMode behaviorMode = BehaviorMode.On;
		IEnumerable<int> item = null;
		switch (protoBehaviorMode?.ModeCase ?? Pro.SerializationInterop.RVProtoData.AudioInput.Types.BehaviorMode.ModeOneofCase.None)
		{
		default:
			behaviorMode = BehaviorMode.On;
			break;
		case Pro.SerializationInterop.RVProtoData.AudioInput.Types.BehaviorMode.ModeOneofCase.Off:
			behaviorMode = BehaviorMode.Off;
			break;
		case Pro.SerializationInterop.RVProtoData.AudioInput.Types.BehaviorMode.ModeOneofCase.AutoOff:
			behaviorMode = BehaviorMode.AutoOff;
			break;
		case Pro.SerializationInterop.RVProtoData.AudioInput.Types.BehaviorMode.ModeOneofCase.AutoOn:
			behaviorMode = BehaviorMode.AutoOn;
			item = protoBehaviorMode?.AutoOn.LinkedVideoInputs.Select((uint i) => (int)i);
			break;
		}
		return (behaviorMode: behaviorMode, linkedVideoInputs: item);
	}

	public static (BehaviorMode behaviorMode, IEnumerable<int>? linkedVideoInputs) ToBehaviorMode(this Pro.Entity.IAudioInput.Types.IBehaviorMode entity)
	{
		BehaviorMode item = BehaviorMode.On;
		IEnumerable<int> item2 = null;
		if (entity.Mode.Value is Pro.Entity.IAudioInput.Types.IBehaviorMode.Types.IMode.IOn)
		{
			item = BehaviorMode.On;
		}
		else if (entity.Mode.Value is Pro.Entity.IAudioInput.Types.IBehaviorMode.Types.IMode.IOff)
		{
			item = BehaviorMode.Off;
		}
		else if (entity.Mode.Value is Pro.Entity.IAudioInput.Types.IBehaviorMode.Types.IMode.IAutoOff)
		{
			item = BehaviorMode.AutoOff;
		}
		else if (entity.Mode.Value is Pro.Entity.IAudioInput.Types.IBehaviorMode.Types.IMode.IAutoOn autoOn)
		{
			item = BehaviorMode.AutoOn;
			item2 = autoOn.Value.LinkedVideoInputs.Items.Select((uint i) => (int)i);
		}
		return (behaviorMode: item, linkedVideoInputs: item2);
	}
}
