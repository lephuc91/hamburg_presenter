using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class PlaylistTemplate : IMessage<PlaylistTemplate>, IMessage, IEquatable<PlaylistTemplate>, IDeepCloneable<PlaylistTemplate>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Template : IMessage<Template>, IMessage, IEquatable<Template>, IDeepCloneable<Template>
		{
			private static readonly MessageParser<Template> _parser = new MessageParser<Template>(() => new Template());

			private UnknownFieldSet _unknownFields;

			public const int NameFieldNumber = 1;

			private string name_ = "";

			public const int PlaylistItemsFieldNumber = 2;

			private static readonly FieldCodec<PlaylistItem> _repeated_playlistItems_codec = FieldCodec.ForMessage(18u, PlaylistItem.Parser);

			private readonly RepeatedField<PlaylistItem> playlistItems_ = new RepeatedField<PlaylistItem>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Template> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => PlaylistTemplate.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Name
			{
				get
				{
					return name_;
				}
				set
				{
					name_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<PlaylistItem> PlaylistItems => playlistItems_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Template()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Template(Template other)
				: this()
			{
				name_ = other.name_;
				playlistItems_ = other.playlistItems_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Template Clone()
			{
				return new Template(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Template);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Template other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Name != other.Name)
				{
					return false;
				}
				if (!playlistItems_.Equals(other.playlistItems_))
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
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
				}
				num ^= playlistItems_.GetHashCode();
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
				if (Name.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Name);
				}
				playlistItems_.WriteTo(output, _repeated_playlistItems_codec);
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
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				num += playlistItems_.CalculateSize(_repeated_playlistItems_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Template other)
			{
				if (other != null)
				{
					if (other.Name.Length != 0)
					{
						Name = other.Name;
					}
					playlistItems_.Add(other.playlistItems_);
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
						Name = input.ReadString();
						break;
					case 18u:
						playlistItems_.AddEntriesFrom(input, _repeated_playlistItems_codec);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<PlaylistTemplate> _parser = new MessageParser<PlaylistTemplate>(() => new PlaylistTemplate());

	private UnknownFieldSet _unknownFields;

	public const int TemplatesFieldNumber = 1;

	private static readonly FieldCodec<Types.Template> _repeated_templates_codec = FieldCodec.ForMessage(10u, Types.Template.Parser);

	private readonly RepeatedField<Types.Template> templates_ = new RepeatedField<Types.Template>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<PlaylistTemplate> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => PlaylistTemplateReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Types.Template> Templates => templates_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PlaylistTemplate()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PlaylistTemplate(PlaylistTemplate other)
		: this()
	{
		templates_ = other.templates_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PlaylistTemplate Clone()
	{
		return new PlaylistTemplate(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as PlaylistTemplate);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(PlaylistTemplate other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!templates_.Equals(other.templates_))
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
		num ^= templates_.GetHashCode();
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
		templates_.WriteTo(output, _repeated_templates_codec);
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
		num += templates_.CalculateSize(_repeated_templates_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(PlaylistTemplate other)
	{
		if (other != null)
		{
			templates_.Add(other.templates_);
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
			if (num != 10)
			{
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
			}
			else
			{
				templates_.AddEntriesFrom(input, _repeated_templates_codec);
			}
		}
	}
}
