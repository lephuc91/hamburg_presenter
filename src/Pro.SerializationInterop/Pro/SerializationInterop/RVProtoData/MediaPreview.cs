using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class MediaPreview : IMessage<MediaPreview>, IMessage, IEquatable<MediaPreview>, IDeepCloneable<MediaPreview>
{
	private static readonly MessageParser<MediaPreview> _parser = new MessageParser<MediaPreview>(() => new MediaPreview());

	private UnknownFieldSet _unknownFields;

	public const int ActionFieldNumber = 1;

	private Action action_;

	public const int MediaFieldNumber = 2;

	private Media media_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<MediaPreview> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => Rv2DReflection.Descriptor.MessageTypes[5];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Action Action
	{
		get
		{
			return action_;
		}
		set
		{
			action_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Media Media
	{
		get
		{
			return media_;
		}
		set
		{
			media_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaPreview()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaPreview(MediaPreview other)
		: this()
	{
		action_ = ((other.action_ != null) ? other.action_.Clone() : null);
		media_ = ((other.media_ != null) ? other.media_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaPreview Clone()
	{
		return new MediaPreview(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as MediaPreview);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(MediaPreview other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Action, other.Action))
		{
			return false;
		}
		if (!object.Equals(Media, other.Media))
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
		if (action_ != null)
		{
			num ^= Action.GetHashCode();
		}
		if (media_ != null)
		{
			num ^= Media.GetHashCode();
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
		if (action_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Action);
		}
		if (media_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Media);
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
		if (action_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Action);
		}
		if (media_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Media);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(MediaPreview other)
	{
		if (other == null)
		{
			return;
		}
		if (other.action_ != null)
		{
			if (action_ == null)
			{
				Action = new Action();
			}
			Action.MergeFrom(other.Action);
		}
		if (other.media_ != null)
		{
			if (media_ == null)
			{
				Media = new Media();
			}
			Media.MergeFrom(other.Media);
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
				if (action_ == null)
				{
					Action = new Action();
				}
				input.ReadMessage(Action);
				break;
			case 18u:
				if (media_ == null)
				{
					Media = new Media();
				}
				input.ReadMessage(Media);
				break;
			}
		}
	}
}
