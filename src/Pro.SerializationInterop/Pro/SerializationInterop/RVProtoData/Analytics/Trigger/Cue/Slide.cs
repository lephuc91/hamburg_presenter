using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Cue;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Slide : IMessage<Slide>, IMessage, IEquatable<Slide>, IDeepCloneable<Slide>
{
	private static readonly MessageParser<Slide> _parser = new MessageParser<Slide>(() => new Slide());

	private UnknownFieldSet _unknownFields;

	public const int ObjectCountFieldNumber = 1;

	private int objectCount_;

	public const int ScrollingObjectCountFieldNumber = 2;

	private int scrollingObjectCount_;

	public const int BackgroundFxObjectCountFieldNumber = 3;

	private int backgroundFxObjectCount_;

	public const int ActionCountFieldNumber = 4;

	private int actionCount_;

	public const int HasTextFxFieldNumber = 5;

	private bool hasTextFx_;

	public const int MediaTextFillObjectCountFieldNumber = 6;

	private int mediaTextFillObjectCount_;

	public const int CutOutTextFillObjectCountFieldNumber = 7;

	private int cutOutTextFillObjectCount_;

	public const int BackgroundBlurTextFillObjectCountFieldNumber = 8;

	private int backgroundBlurTextFillObjectCount_;

	public const int BackgroundInvertTextFillObjectCountFieldNumber = 9;

	private int backgroundInvertTextFillObjectCount_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Slide> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTriggerCueReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int ObjectCount
	{
		get
		{
			return objectCount_;
		}
		set
		{
			objectCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int ScrollingObjectCount
	{
		get
		{
			return scrollingObjectCount_;
		}
		set
		{
			scrollingObjectCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int BackgroundFxObjectCount
	{
		get
		{
			return backgroundFxObjectCount_;
		}
		set
		{
			backgroundFxObjectCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int ActionCount
	{
		get
		{
			return actionCount_;
		}
		set
		{
			actionCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasTextFx
	{
		get
		{
			return hasTextFx_;
		}
		set
		{
			hasTextFx_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int MediaTextFillObjectCount
	{
		get
		{
			return mediaTextFillObjectCount_;
		}
		set
		{
			mediaTextFillObjectCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int CutOutTextFillObjectCount
	{
		get
		{
			return cutOutTextFillObjectCount_;
		}
		set
		{
			cutOutTextFillObjectCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int BackgroundBlurTextFillObjectCount
	{
		get
		{
			return backgroundBlurTextFillObjectCount_;
		}
		set
		{
			backgroundBlurTextFillObjectCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int BackgroundInvertTextFillObjectCount
	{
		get
		{
			return backgroundInvertTextFillObjectCount_;
		}
		set
		{
			backgroundInvertTextFillObjectCount_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Slide()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Slide(Slide other)
		: this()
	{
		objectCount_ = other.objectCount_;
		scrollingObjectCount_ = other.scrollingObjectCount_;
		backgroundFxObjectCount_ = other.backgroundFxObjectCount_;
		actionCount_ = other.actionCount_;
		hasTextFx_ = other.hasTextFx_;
		mediaTextFillObjectCount_ = other.mediaTextFillObjectCount_;
		cutOutTextFillObjectCount_ = other.cutOutTextFillObjectCount_;
		backgroundBlurTextFillObjectCount_ = other.backgroundBlurTextFillObjectCount_;
		backgroundInvertTextFillObjectCount_ = other.backgroundInvertTextFillObjectCount_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Slide Clone()
	{
		return new Slide(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Slide);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Slide other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (ObjectCount != other.ObjectCount)
		{
			return false;
		}
		if (ScrollingObjectCount != other.ScrollingObjectCount)
		{
			return false;
		}
		if (BackgroundFxObjectCount != other.BackgroundFxObjectCount)
		{
			return false;
		}
		if (ActionCount != other.ActionCount)
		{
			return false;
		}
		if (HasTextFx != other.HasTextFx)
		{
			return false;
		}
		if (MediaTextFillObjectCount != other.MediaTextFillObjectCount)
		{
			return false;
		}
		if (CutOutTextFillObjectCount != other.CutOutTextFillObjectCount)
		{
			return false;
		}
		if (BackgroundBlurTextFillObjectCount != other.BackgroundBlurTextFillObjectCount)
		{
			return false;
		}
		if (BackgroundInvertTextFillObjectCount != other.BackgroundInvertTextFillObjectCount)
		{
			return false;
		}
		return object.Equals(_unknownFields, other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override int GetHashCode()
	{
		int num = 1;
		if (ObjectCount != 0)
		{
			num ^= ObjectCount.GetHashCode();
		}
		if (ScrollingObjectCount != 0)
		{
			num ^= ScrollingObjectCount.GetHashCode();
		}
		if (BackgroundFxObjectCount != 0)
		{
			num ^= BackgroundFxObjectCount.GetHashCode();
		}
		if (ActionCount != 0)
		{
			num ^= ActionCount.GetHashCode();
		}
		if (HasTextFx)
		{
			num ^= HasTextFx.GetHashCode();
		}
		if (MediaTextFillObjectCount != 0)
		{
			num ^= MediaTextFillObjectCount.GetHashCode();
		}
		if (CutOutTextFillObjectCount != 0)
		{
			num ^= CutOutTextFillObjectCount.GetHashCode();
		}
		if (BackgroundBlurTextFillObjectCount != 0)
		{
			num ^= BackgroundBlurTextFillObjectCount.GetHashCode();
		}
		if (BackgroundInvertTextFillObjectCount != 0)
		{
			num ^= BackgroundInvertTextFillObjectCount.GetHashCode();
		}
		if (_unknownFields != null)
		{
			num ^= _unknownFields.GetHashCode();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override string ToString()
	{
		return JsonFormatter.ToDiagnosticString(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void WriteTo(CodedOutputStream output)
	{
		if (ObjectCount != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(ObjectCount);
		}
		if (ScrollingObjectCount != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(ScrollingObjectCount);
		}
		if (BackgroundFxObjectCount != 0)
		{
			output.WriteRawTag(24);
			output.WriteInt32(BackgroundFxObjectCount);
		}
		if (ActionCount != 0)
		{
			output.WriteRawTag(32);
			output.WriteInt32(ActionCount);
		}
		if (HasTextFx)
		{
			output.WriteRawTag(40);
			output.WriteBool(HasTextFx);
		}
		if (MediaTextFillObjectCount != 0)
		{
			output.WriteRawTag(48);
			output.WriteInt32(MediaTextFillObjectCount);
		}
		if (CutOutTextFillObjectCount != 0)
		{
			output.WriteRawTag(56);
			output.WriteInt32(CutOutTextFillObjectCount);
		}
		if (BackgroundBlurTextFillObjectCount != 0)
		{
			output.WriteRawTag(64);
			output.WriteInt32(BackgroundBlurTextFillObjectCount);
		}
		if (BackgroundInvertTextFillObjectCount != 0)
		{
			output.WriteRawTag(72);
			output.WriteInt32(BackgroundInvertTextFillObjectCount);
		}
		if (_unknownFields != null)
		{
			_unknownFields.WriteTo(output);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int CalculateSize()
	{
		int num = 0;
		if (ObjectCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(ObjectCount);
		}
		if (ScrollingObjectCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(ScrollingObjectCount);
		}
		if (BackgroundFxObjectCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(BackgroundFxObjectCount);
		}
		if (ActionCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(ActionCount);
		}
		if (HasTextFx)
		{
			num += 2;
		}
		if (MediaTextFillObjectCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(MediaTextFillObjectCount);
		}
		if (CutOutTextFillObjectCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(CutOutTextFillObjectCount);
		}
		if (BackgroundBlurTextFillObjectCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(BackgroundBlurTextFillObjectCount);
		}
		if (BackgroundInvertTextFillObjectCount != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(BackgroundInvertTextFillObjectCount);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Slide other)
	{
		if (other != null)
		{
			if (other.ObjectCount != 0)
			{
				ObjectCount = other.ObjectCount;
			}
			if (other.ScrollingObjectCount != 0)
			{
				ScrollingObjectCount = other.ScrollingObjectCount;
			}
			if (other.BackgroundFxObjectCount != 0)
			{
				BackgroundFxObjectCount = other.BackgroundFxObjectCount;
			}
			if (other.ActionCount != 0)
			{
				ActionCount = other.ActionCount;
			}
			if (other.HasTextFx)
			{
				HasTextFx = other.HasTextFx;
			}
			if (other.MediaTextFillObjectCount != 0)
			{
				MediaTextFillObjectCount = other.MediaTextFillObjectCount;
			}
			if (other.CutOutTextFillObjectCount != 0)
			{
				CutOutTextFillObjectCount = other.CutOutTextFillObjectCount;
			}
			if (other.BackgroundBlurTextFillObjectCount != 0)
			{
				BackgroundBlurTextFillObjectCount = other.BackgroundBlurTextFillObjectCount;
			}
			if (other.BackgroundInvertTextFillObjectCount != 0)
			{
				BackgroundInvertTextFillObjectCount = other.BackgroundInvertTextFillObjectCount;
			}
			_unknownFields = UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(CodedInputStream input)
	{
		uint num;
		while ((num = input.ReadTag()) != 0 && (num & 7) != 4)
		{
			switch (num)
			{
			default:
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				break;
			case 8u:
				ObjectCount = input.ReadInt32();
				break;
			case 16u:
				ScrollingObjectCount = input.ReadInt32();
				break;
			case 24u:
				BackgroundFxObjectCount = input.ReadInt32();
				break;
			case 32u:
				ActionCount = input.ReadInt32();
				break;
			case 40u:
				HasTextFx = input.ReadBool();
				break;
			case 48u:
				MediaTextFillObjectCount = input.ReadInt32();
				break;
			case 56u:
				CutOutTextFillObjectCount = input.ReadInt32();
				break;
			case 64u:
				BackgroundBlurTextFillObjectCount = input.ReadInt32();
				break;
			case 72u:
				BackgroundInvertTextFillObjectCount = input.ReadInt32();
				break;
			}
		}
	}
}
