using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_PropData : IMessage<API_v1_PropData>, IMessage, IEquatable<API_v1_PropData>, IDeepCloneable<API_v1_PropData>
{
	private static readonly MessageParser<API_v1_PropData> _parser = new MessageParser<API_v1_PropData>(() => new API_v1_PropData());

	private UnknownFieldSet _unknownFields;

	public const int IdFieldNumber = 1;

	private API_v1_Identifier id_;

	public const int IsActiveFieldNumber = 2;

	private bool isActive_;

	public const int AutoClearEnabledFieldNumber = 3;

	private bool autoClearEnabled_;

	public const int AutoClearDurationFieldNumber = 4;

	private double autoClearDuration_;

	public const int TransitionFieldNumber = 5;

	private API_v1_Transition transition_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_PropData> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1PropReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Identifier Id
	{
		get
		{
			return id_;
		}
		set
		{
			id_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool IsActive
	{
		get
		{
			return isActive_;
		}
		set
		{
			isActive_ = value;
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
	public API_v1_Transition Transition
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
	public API_v1_PropData()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_PropData(API_v1_PropData other)
		: this()
	{
		id_ = ((other.id_ != null) ? other.id_.Clone() : null);
		isActive_ = other.isActive_;
		autoClearEnabled_ = other.autoClearEnabled_;
		autoClearDuration_ = other.autoClearDuration_;
		transition_ = ((other.transition_ != null) ? other.transition_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_PropData Clone()
	{
		return new API_v1_PropData(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_PropData);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_PropData other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Id, other.Id))
		{
			return false;
		}
		if (IsActive != other.IsActive)
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
		if (!object.Equals(Transition, other.Transition))
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
		if (id_ != null)
		{
			num ^= Id.GetHashCode();
		}
		if (IsActive)
		{
			num ^= IsActive.GetHashCode();
		}
		if (AutoClearEnabled)
		{
			num ^= AutoClearEnabled.GetHashCode();
		}
		if (AutoClearDuration != 0.0)
		{
			num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(AutoClearDuration);
		}
		if (transition_ != null)
		{
			num ^= Transition.GetHashCode();
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
		if (id_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Id);
		}
		if (IsActive)
		{
			output.WriteRawTag(16);
			output.WriteBool(IsActive);
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
		if (transition_ != null)
		{
			output.WriteRawTag(42);
			output.WriteMessage(Transition);
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
		if (id_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Id);
		}
		if (IsActive)
		{
			num += 2;
		}
		if (AutoClearEnabled)
		{
			num += 2;
		}
		if (AutoClearDuration != 0.0)
		{
			num += 9;
		}
		if (transition_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Transition);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_PropData other)
	{
		if (other == null)
		{
			return;
		}
		if (other.id_ != null)
		{
			if (id_ == null)
			{
				Id = new API_v1_Identifier();
			}
			Id.MergeFrom(other.Id);
		}
		if (other.IsActive)
		{
			IsActive = other.IsActive;
		}
		if (other.AutoClearEnabled)
		{
			AutoClearEnabled = other.AutoClearEnabled;
		}
		if (other.AutoClearDuration != 0.0)
		{
			AutoClearDuration = other.AutoClearDuration;
		}
		if (other.transition_ != null)
		{
			if (transition_ == null)
			{
				Transition = new API_v1_Transition();
			}
			Transition.MergeFrom(other.Transition);
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
				if (id_ == null)
				{
					Id = new API_v1_Identifier();
				}
				input.ReadMessage(Id);
				break;
			case 16u:
				IsActive = input.ReadBool();
				break;
			case 24u:
				AutoClearEnabled = input.ReadBool();
				break;
			case 33u:
				AutoClearDuration = input.ReadDouble();
				break;
			case 42u:
				if (transition_ == null)
				{
					Transition = new API_v1_Transition();
				}
				input.ReadMessage(Transition);
				break;
			}
		}
	}
}
