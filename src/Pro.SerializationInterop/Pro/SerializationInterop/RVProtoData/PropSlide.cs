using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class PropSlide : IMessage<PropSlide>, IMessage, IEquatable<PropSlide>, IDeepCloneable<PropSlide>
{
	private static readonly MessageParser<PropSlide> _parser = new MessageParser<PropSlide>(() => new PropSlide());

	private UnknownFieldSet _unknownFields;

	public const int BaseSlideFieldNumber = 1;

	private Slide baseSlide_;

	public const int TransitionFieldNumber = 2;

	private Transition transition_;

	public const int AutoClearEnabledFieldNumber = 3;

	private bool autoClearEnabled_;

	public const int AutoClearDurationFieldNumber = 4;

	private double autoClearDuration_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<PropSlide> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => PropSlideReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Slide BaseSlide
	{
		get
		{
			return baseSlide_;
		}
		set
		{
			baseSlide_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Transition Transition
	{
		get
		{
			return transition_;
		}
		set
		{
			transition_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool AutoClearEnabled
	{
		get
		{
			return autoClearEnabled_;
		}
		set
		{
			autoClearEnabled_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public double AutoClearDuration
	{
		get
		{
			return autoClearDuration_;
		}
		set
		{
			autoClearDuration_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PropSlide()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PropSlide(PropSlide other)
		: this()
	{
		baseSlide_ = ((other.baseSlide_ != null) ? other.baseSlide_.Clone() : null);
		transition_ = ((other.transition_ != null) ? other.transition_.Clone() : null);
		autoClearEnabled_ = other.autoClearEnabled_;
		autoClearDuration_ = other.autoClearDuration_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PropSlide Clone()
	{
		return new PropSlide(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as PropSlide);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(PropSlide other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(BaseSlide, other.BaseSlide))
		{
			return false;
		}
		if (!object.Equals(Transition, other.Transition))
		{
			return false;
		}
		if (AutoClearEnabled != other.AutoClearEnabled)
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(AutoClearDuration, other.AutoClearDuration))
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
		if (baseSlide_ != null)
		{
			num ^= BaseSlide.GetHashCode();
		}
		if (transition_ != null)
		{
			num ^= Transition.GetHashCode();
		}
		if (AutoClearEnabled)
		{
			num ^= AutoClearEnabled.GetHashCode();
		}
		if (AutoClearDuration != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(AutoClearDuration);
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
		if (baseSlide_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(BaseSlide);
		}
		if (transition_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Transition);
		}
		if (AutoClearEnabled)
		{
			output.WriteRawTag(24);
			output.WriteBool(AutoClearEnabled);
		}
		if (AutoClearDuration != 0.0)
		{
			output.WriteRawTag(33);
			output.WriteDouble(AutoClearDuration);
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
		if (baseSlide_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(BaseSlide);
		}
		if (transition_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Transition);
		}
		if (AutoClearEnabled)
		{
			num += 2;
		}
		if (AutoClearDuration != 0.0)
		{
			num += 9;
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(PropSlide other)
	{
		if (other == null)
		{
			return;
		}
		if (other.baseSlide_ != null)
		{
			if (baseSlide_ == null)
			{
				BaseSlide = new Slide();
			}
			BaseSlide.MergeFrom(other.BaseSlide);
		}
		if (other.transition_ != null)
		{
			if (transition_ == null)
			{
				Transition = new Transition();
			}
			Transition.MergeFrom(other.Transition);
		}
		if (other.AutoClearEnabled)
		{
			AutoClearEnabled = other.AutoClearEnabled;
		}
		if (other.AutoClearDuration != 0.0)
		{
			AutoClearDuration = other.AutoClearDuration;
		}
		_unknownFields = UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
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
			case 10u:
				if (baseSlide_ == null)
				{
					BaseSlide = new Slide();
				}
				input.ReadMessage(BaseSlide);
				break;
			case 18u:
				if (transition_ == null)
				{
					Transition = new Transition();
				}
				input.ReadMessage(Transition);
				break;
			case 24u:
				AutoClearEnabled = input.ReadBool();
				break;
			case 33u:
				AutoClearDuration = input.ReadDouble();
				break;
			}
		}
	}
}
