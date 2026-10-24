using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class GetMediaThumbnail : IMessage<GetMediaThumbnail>, IMessage, IEquatable<GetMediaThumbnail>, IDeepCloneable<GetMediaThumbnail>
{
	public enum MediaTypeOneofCase
	{
		None,
		Media,
		Action
	}

	private static readonly MessageParser<GetMediaThumbnail> _parser = new MessageParser<GetMediaThumbnail>(() => new GetMediaThumbnail());

	private UnknownFieldSet _unknownFields;

	public const int MediaFieldNumber = 1;

	public const int ActionFieldNumber = 2;

	public const int WidthHintFieldNumber = 3;

	private int widthHint_;

	public const int HeightHintFieldNumber = 4;

	private int heightHint_;

	private object mediaType_;

	private MediaTypeOneofCase mediaTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<GetMediaThumbnail> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[29];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Media Media
	{
		get
		{
			if (mediaTypeCase_ != MediaTypeOneofCase.Media)
			{
				return null;
			}
			return (Media)mediaType_;
		}
		set
		{
			mediaType_ = value;
			mediaTypeCase_ = ((value != null) ? MediaTypeOneofCase.Media : MediaTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Action Action
	{
		get
		{
			if (mediaTypeCase_ != MediaTypeOneofCase.Action)
			{
				return null;
			}
			return (Action)mediaType_;
		}
		set
		{
			mediaType_ = value;
			mediaTypeCase_ = ((value != null) ? MediaTypeOneofCase.Action : MediaTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int WidthHint
	{
		get
		{
			return widthHint_;
		}
		set
		{
			widthHint_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int HeightHint
	{
		get
		{
			return heightHint_;
		}
		set
		{
			heightHint_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaTypeOneofCase MediaTypeCase => mediaTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public GetMediaThumbnail()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public GetMediaThumbnail(GetMediaThumbnail other)
		: this()
	{
		widthHint_ = other.widthHint_;
		heightHint_ = other.heightHint_;
		switch (other.MediaTypeCase)
		{
		case MediaTypeOneofCase.Media:
			Media = other.Media.Clone();
			break;
		case MediaTypeOneofCase.Action:
			Action = other.Action.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public GetMediaThumbnail Clone()
	{
		return new GetMediaThumbnail(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearMediaType()
	{
		mediaTypeCase_ = MediaTypeOneofCase.None;
		mediaType_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as GetMediaThumbnail);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(GetMediaThumbnail other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Media, other.Media))
		{
			return false;
		}
		if (!object.Equals(Action, other.Action))
		{
			return false;
		}
		if (WidthHint != other.WidthHint)
		{
			return false;
		}
		if (HeightHint != other.HeightHint)
		{
			return false;
		}
		if (MediaTypeCase != other.MediaTypeCase)
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
		if (mediaTypeCase_ == MediaTypeOneofCase.Media)
		{
			num ^= Media.GetHashCode();
		}
		if (mediaTypeCase_ == MediaTypeOneofCase.Action)
		{
			num ^= Action.GetHashCode();
		}
		if (WidthHint != 0)
		{
			num ^= WidthHint.GetHashCode();
		}
		if (HeightHint != 0)
		{
			num ^= HeightHint.GetHashCode();
		}
		num ^= (int)mediaTypeCase_;
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
		if (mediaTypeCase_ == MediaTypeOneofCase.Media)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Media);
		}
		if (mediaTypeCase_ == MediaTypeOneofCase.Action)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Action);
		}
		if (WidthHint != 0)
		{
			output.WriteRawTag(24);
			output.WriteInt32(WidthHint);
		}
		if (HeightHint != 0)
		{
			output.WriteRawTag(32);
			output.WriteInt32(HeightHint);
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
		if (mediaTypeCase_ == MediaTypeOneofCase.Media)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Media);
		}
		if (mediaTypeCase_ == MediaTypeOneofCase.Action)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Action);
		}
		if (WidthHint != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(WidthHint);
		}
		if (HeightHint != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(HeightHint);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(GetMediaThumbnail other)
	{
		if (other == null)
		{
			return;
		}
		if (other.WidthHint != 0)
		{
			WidthHint = other.WidthHint;
		}
		if (other.HeightHint != 0)
		{
			HeightHint = other.HeightHint;
		}
		switch (other.MediaTypeCase)
		{
		case MediaTypeOneofCase.Media:
			if (Media == null)
			{
				Media = new Media();
			}
			Media.MergeFrom(other.Media);
			break;
		case MediaTypeOneofCase.Action:
			if (Action == null)
			{
				Action = new Action();
			}
			Action.MergeFrom(other.Action);
			break;
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
			{
				Media media = new Media();
				if (mediaTypeCase_ == MediaTypeOneofCase.Media)
				{
					media.MergeFrom(Media);
				}
				input.ReadMessage(media);
				Media = media;
				break;
			}
			case 18u:
			{
				Action action = new Action();
				if (mediaTypeCase_ == MediaTypeOneofCase.Action)
				{
					action.MergeFrom(Action);
				}
				input.ReadMessage(action);
				Action = action;
				break;
			}
			case 24u:
				WidthHint = input.ReadInt32();
				break;
			case 32u:
				HeightHint = input.ReadInt32();
				break;
			}
		}
	}
}
