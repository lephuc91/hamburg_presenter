using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_ScreenConfig : IMessage<API_v1_ScreenConfig>, IMessage, IEquatable<API_v1_ScreenConfig>, IDeepCloneable<API_v1_ScreenConfig>
{
	private static readonly MessageParser<API_v1_ScreenConfig> _parser = new MessageParser<API_v1_ScreenConfig>(() => new API_v1_ScreenConfig());

	private UnknownFieldSet _unknownFields;

	public const int IdFieldNumber = 1;

	private API_v1_Identifier id_;

	public const int SizeFieldNumber = 2;

	private API_v1_Size size_;

	public const int ScreenTypeFieldNumber = 3;

	private API_v1_ScreenType screenType_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_ScreenConfig> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1StatusReflection.Descriptor.MessageTypes[1];

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
	public API_v1_Size Size
	{
		get
		{
			return size_;
		}
		set
		{
			size_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_ScreenType ScreenType
	{
		get
		{
			return screenType_;
		}
		set
		{
			screenType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_ScreenConfig()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_ScreenConfig(API_v1_ScreenConfig other)
		: this()
	{
		id_ = ((other.id_ != null) ? other.id_.Clone() : null);
		size_ = ((other.size_ != null) ? other.size_.Clone() : null);
		screenType_ = other.screenType_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_ScreenConfig Clone()
	{
		return new API_v1_ScreenConfig(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_ScreenConfig);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_ScreenConfig other)
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
		if (!object.Equals(Size, other.Size))
		{
			return false;
		}
		if (ScreenType != other.ScreenType)
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
		if (size_ != null)
		{
			num ^= Size.GetHashCode();
		}
		if (ScreenType != 0)
		{
			num ^= ScreenType.GetHashCode();
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
		if (size_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Size);
		}
		if (ScreenType != 0)
		{
			output.WriteRawTag(24);
			output.WriteEnum((int)ScreenType);
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
		if (size_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Size);
		}
		if (ScreenType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)ScreenType);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_ScreenConfig other)
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
		if (other.size_ != null)
		{
			if (size_ == null)
			{
				Size = new API_v1_Size();
			}
			Size.MergeFrom(other.Size);
		}
		if (other.ScreenType != 0)
		{
			ScreenType = other.ScreenType;
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
			case 18u:
				if (size_ == null)
				{
					Size = new API_v1_Size();
				}
				input.ReadMessage(Size);
				break;
			case 24u:
				ScreenType = (API_v1_ScreenType)input.ReadEnum();
				break;
			}
		}
	}
}
