using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_ThemeGroup : IMessage<API_v1_ThemeGroup>, IMessage, IEquatable<API_v1_ThemeGroup>, IDeepCloneable<API_v1_ThemeGroup>
{
	private static readonly MessageParser<API_v1_ThemeGroup> _parser = new MessageParser<API_v1_ThemeGroup>(() => new API_v1_ThemeGroup());

	private UnknownFieldSet _unknownFields;

	public const int IdFieldNumber = 1;

	private API_v1_Identifier id_;

	public const int GroupsFieldNumber = 2;

	private static readonly FieldCodec<API_v1_ThemeGroup> _repeated_groups_codec = FieldCodec.ForMessage(18u, Parser);

	private readonly RepeatedField<API_v1_ThemeGroup> groups_ = new RepeatedField<API_v1_ThemeGroup>();

	public const int ThemesFieldNumber = 3;

	private static readonly FieldCodec<API_v1_Theme> _repeated_themes_codec = FieldCodec.ForMessage(26u, API_v1_Theme.Parser);

	private readonly RepeatedField<API_v1_Theme> themes_ = new RepeatedField<API_v1_Theme>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_ThemeGroup> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1ThemeReflection.Descriptor.MessageTypes[0];

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
	public RepeatedField<API_v1_ThemeGroup> Groups => groups_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<API_v1_Theme> Themes => themes_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_ThemeGroup()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_ThemeGroup(API_v1_ThemeGroup other)
		: this()
	{
		id_ = ((other.id_ != null) ? other.id_.Clone() : null);
		groups_ = other.groups_.Clone();
		themes_ = other.themes_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_ThemeGroup Clone()
	{
		return new API_v1_ThemeGroup(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_ThemeGroup);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_ThemeGroup other)
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
		if (!groups_.Equals(other.groups_))
		{
			return false;
		}
		if (!themes_.Equals(other.themes_))
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
		num ^= groups_.GetHashCode();
		num ^= themes_.GetHashCode();
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
		groups_.WriteTo(output, _repeated_groups_codec);
		themes_.WriteTo(output, _repeated_themes_codec);
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
		num += groups_.CalculateSize(_repeated_groups_codec);
		num += themes_.CalculateSize(_repeated_themes_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_ThemeGroup other)
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
		groups_.Add(other.groups_);
		themes_.Add(other.themes_);
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
				groups_.AddEntriesFrom(input, _repeated_groups_codec);
				break;
			case 26u:
				themes_.AddEntriesFrom(input, _repeated_themes_codec);
				break;
			}
		}
	}
}
