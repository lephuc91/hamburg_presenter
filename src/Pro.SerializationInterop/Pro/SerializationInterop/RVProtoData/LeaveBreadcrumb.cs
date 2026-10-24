using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class LeaveBreadcrumb : IMessage<LeaveBreadcrumb>, IMessage, IEquatable<LeaveBreadcrumb>, IDeepCloneable<LeaveBreadcrumb>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Type
		{
			[OriginalName("Navigation")]
			Navigation,
			[OriginalName("Request")]
			Request,
			[OriginalName("Process")]
			Process,
			[OriginalName("Log")]
			Log,
			[OriginalName("User")]
			User,
			[OriginalName("State")]
			State,
			[OriginalName("Error")]
			Error,
			[OriginalName("Manual")]
			Manual
		}
	}

	private static readonly MessageParser<LeaveBreadcrumb> _parser = new MessageParser<LeaveBreadcrumb>(() => new LeaveBreadcrumb());

	private UnknownFieldSet _unknownFields;

	public const int TypeFieldNumber = 1;

	private Types.Type type_;

	public const int DescriptionFieldNumber = 2;

	private string description_ = "";

	public const int MetadataFieldNumber = 3;

	private static readonly MapField<string, string>.Codec _map_metadata_codec = new MapField<string, string>.Codec(FieldCodec.ForString(10u, ""), FieldCodec.ForString(18u, ""), 26u);

	private readonly MapField<string, string> metadata_ = new MapField<string, string>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<LeaveBreadcrumb> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[26];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Type Type
	{
		get
		{
			return type_;
		}
		set
		{
			type_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Description
	{
		get
		{
			return description_;
		}
		set
		{
			description_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MapField<string, string> Metadata => metadata_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LeaveBreadcrumb()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LeaveBreadcrumb(LeaveBreadcrumb other)
		: this()
	{
		type_ = other.type_;
		description_ = other.description_;
		metadata_ = other.metadata_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LeaveBreadcrumb Clone()
	{
		return new LeaveBreadcrumb(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as LeaveBreadcrumb);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(LeaveBreadcrumb other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Type != other.Type)
		{
			return false;
		}
		if (Description != other.Description)
		{
			return false;
		}
		if (!Metadata.Equals(other.Metadata))
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
		if (Type != 0)
		{
			num ^= Type.GetHashCode();
		}
		if (Description.Length != 0)
		{
			num ^= Description.GetHashCode();
		}
		num ^= Metadata.GetHashCode();
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
		if (Type != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Type);
		}
		if (Description.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Description);
		}
		metadata_.WriteTo(output, _map_metadata_codec);
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
		if (Type != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Type);
		}
		if (Description.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Description);
		}
		num += metadata_.CalculateSize(_map_metadata_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(LeaveBreadcrumb other)
	{
		if (other != null)
		{
			if (other.Type != 0)
			{
				Type = other.Type;
			}
			if (other.Description.Length != 0)
			{
				Description = other.Description;
			}
			metadata_.MergeFrom(other.metadata_);
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
				Type = (Types.Type)input.ReadEnum();
				break;
			case 18u:
				Description = input.ReadString();
				break;
			case 26u:
				metadata_.AddEntriesFrom(input, _map_metadata_codec);
				break;
			}
		}
	}
}
