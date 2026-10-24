using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class MacroIcons : IMessage<MacroIcons>, IMessage, IEquatable<MacroIcons>, IDeepCloneable<MacroIcons>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class MacroIcon : IMessage<MacroIcon>, IMessage, IEquatable<MacroIcon>, IDeepCloneable<MacroIcon>
		{
			private static readonly MessageParser<MacroIcon> _parser = new MessageParser<MacroIcon>(() => new MacroIcon());

			private UnknownFieldSet _unknownFields;

			public const int ImageTypeFieldNumber = 1;

			private MacrosDocument.Types.Macro.Types.ImageType imageType_;

			public const int ImageDataFieldNumber = 2;

			private ByteString imageData_ = ByteString.Empty;

			public const int ContentTypeFieldNumber = 3;

			private string contentType_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<MacroIcon> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => MacroIcons.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MacrosDocument.Types.Macro.Types.ImageType ImageType
			{
				get
				{
					return imageType_;
				}
				set
				{
					imageType_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ByteString ImageData
			{
				get
				{
					return imageData_;
				}
				set
				{
					imageData_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string ContentType
			{
				get
				{
					return contentType_;
				}
				set
				{
					contentType_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MacroIcon()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MacroIcon(MacroIcon other)
				: this()
			{
				imageType_ = other.imageType_;
				imageData_ = other.imageData_;
				contentType_ = other.contentType_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MacroIcon Clone()
			{
				return new MacroIcon(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as MacroIcon);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(MacroIcon other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (ImageType != other.ImageType)
				{
					return false;
				}
				if (ImageData != other.ImageData)
				{
					return false;
				}
				if (ContentType != other.ContentType)
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
				if (ImageType != 0)
				{
					num ^= ImageType.GetHashCode();
				}
				if (ImageData.Length != 0)
				{
					num ^= ImageData.GetHashCode();
				}
				if (ContentType.Length != 0)
				{
					num ^= ContentType.GetHashCode();
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
				if (ImageType != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)ImageType);
				}
				if (ImageData.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteBytes(ImageData);
				}
				if (ContentType.Length != 0)
				{
					output.WriteRawTag(26);
					output.WriteString(ContentType);
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
				if (ImageType != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)ImageType);
				}
				if (ImageData.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeBytesSize(ImageData);
				}
				if (ContentType.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(ContentType);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(MacroIcon other)
			{
				if (other != null)
				{
					if (other.ImageType != 0)
					{
						ImageType = other.ImageType;
					}
					if (other.ImageData.Length != 0)
					{
						ImageData = other.ImageData;
					}
					if (other.ContentType.Length != 0)
					{
						ContentType = other.ContentType;
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
						ImageType = (MacrosDocument.Types.Macro.Types.ImageType)input.ReadEnum();
						break;
					case 18u:
						ImageData = input.ReadBytes();
						break;
					case 26u:
						ContentType = input.ReadString();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<MacroIcons> _parser = new MessageParser<MacroIcons>(() => new MacroIcons());

	private UnknownFieldSet _unknownFields;

	public const int IconsFieldNumber = 1;

	private static readonly FieldCodec<Types.MacroIcon> _repeated_icons_codec = FieldCodec.ForMessage(10u, Types.MacroIcon.Parser);

	private readonly RepeatedField<Types.MacroIcon> icons_ = new RepeatedField<Types.MacroIcon>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<MacroIcons> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[14];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Types.MacroIcon> Icons => icons_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MacroIcons()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MacroIcons(MacroIcons other)
		: this()
	{
		icons_ = other.icons_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MacroIcons Clone()
	{
		return new MacroIcons(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as MacroIcons);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(MacroIcons other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!icons_.Equals(other.icons_))
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
		num ^= icons_.GetHashCode();
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
		icons_.WriteTo(output, _repeated_icons_codec);
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
		num += icons_.CalculateSize(_repeated_icons_codec);
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(MacroIcons other)
	{
		if (other != null)
		{
			icons_.Add(other.icons_);
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
				icons_.AddEntriesFrom(input, _repeated_icons_codec);
			}
		}
	}
}
