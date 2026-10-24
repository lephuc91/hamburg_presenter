using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class RemoveContainer : IMessage<RemoveContainer>, IMessage, IEquatable<RemoveContainer>, IDeepCloneable<RemoveContainer>
{
	private static readonly MessageParser<RemoveContainer> _parser = new MessageParser<RemoveContainer>(() => new RemoveContainer());

	private UnknownFieldSet _unknownFields;

	private int _hasBits0;

	public const int ContainerIdFieldNumber = 1;

	private static readonly FieldCodec<string> _repeated_containerId_codec = FieldCodec.ForString(10u);

	private readonly RepeatedField<string> containerId_ = new RepeatedField<string>();

	public const int UserInitiatedFieldNumber = 2;

	private static readonly bool UserInitiatedDefaultValue = false;

	private bool userInitiated_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<RemoveContainer> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V2HelperCommonReflection.Descriptor.MessageTypes[29];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<string> ContainerId => containerId_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool UserInitiated
	{
		get
		{
			if ((_hasBits0 & 1) != 0)
			{
				return userInitiated_;
			}
			return UserInitiatedDefaultValue;
		}
		set
		{
			_hasBits0 |= 1;
			userInitiated_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasUserInitiated => (_hasBits0 & 1) != 0;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RemoveContainer()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RemoveContainer(RemoveContainer other)
		: this()
	{
		_hasBits0 = other._hasBits0;
		containerId_ = other.containerId_.Clone();
		userInitiated_ = other.userInitiated_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RemoveContainer Clone()
	{
		return new RemoveContainer(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearUserInitiated()
	{
		_hasBits0 &= -2;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as RemoveContainer);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(RemoveContainer other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!containerId_.Equals(other.containerId_))
		{
			return false;
		}
		if (UserInitiated != other.UserInitiated)
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
		num ^= containerId_.GetHashCode();
		if (HasUserInitiated)
		{
			num ^= UserInitiated.GetHashCode();
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
		containerId_.WriteTo(output, _repeated_containerId_codec);
		if (HasUserInitiated)
		{
			output.WriteRawTag(16);
			output.WriteBool(UserInitiated);
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
		num += containerId_.CalculateSize(_repeated_containerId_codec);
		if (HasUserInitiated)
		{
			num += 2;
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(RemoveContainer other)
	{
		if (other != null)
		{
			containerId_.Add(other.containerId_);
			if (other.HasUserInitiated)
			{
				UserInitiated = other.UserInitiated;
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
			case 10u:
				containerId_.AddEntriesFrom(input, _repeated_containerId_codec);
				break;
			case 16u:
				UserInitiated = input.ReadBool();
				break;
			}
		}
	}
}
