using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Trigger.Media;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Image : IMessage<Image>, IMessage, IEquatable<Image>, IDeepCloneable<Image>
{
	private static readonly MessageParser<Image> _parser = new MessageParser<Image>(() => new Image());

	private UnknownFieldSet _unknownFields;

	public const int VisualMediaFieldNumber = 1;

	private VisualMedia visualMedia_;

	public const int CompletionTargetFieldNumber = 2;

	private CompletionTarget completionTarget_;

	public const int SourceTypeFieldNumber = 3;

	private SourceType sourceType_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Image> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTriggerMediaReflection.Descriptor.MessageTypes[5];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public VisualMedia VisualMedia
	{
		get
		{
			return visualMedia_;
		}
		set
		{
			visualMedia_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CompletionTarget CompletionTarget
	{
		get
		{
			return completionTarget_;
		}
		set
		{
			completionTarget_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SourceType SourceType
	{
		get
		{
			return sourceType_;
		}
		set
		{
			sourceType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Image()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Image(Image other)
		: this()
	{
		visualMedia_ = ((other.visualMedia_ != null) ? other.visualMedia_.Clone() : null);
		completionTarget_ = other.completionTarget_;
		sourceType_ = other.sourceType_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Image Clone()
	{
		return new Image(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Image);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Image other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(VisualMedia, other.VisualMedia))
		{
			return false;
		}
		if (CompletionTarget != other.CompletionTarget)
		{
			return false;
		}
		if (SourceType != other.SourceType)
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
		if (visualMedia_ != null)
		{
			num ^= VisualMedia.GetHashCode();
		}
		if (CompletionTarget != 0)
		{
			num ^= CompletionTarget.GetHashCode();
		}
		if (SourceType != 0)
		{
			num ^= SourceType.GetHashCode();
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
		if (visualMedia_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(VisualMedia);
		}
		if (CompletionTarget != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)CompletionTarget);
		}
		if (SourceType != 0)
		{
			output.WriteRawTag(24);
			output.WriteEnum((int)SourceType);
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
		if (visualMedia_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(VisualMedia);
		}
		if (CompletionTarget != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)CompletionTarget);
		}
		if (SourceType != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)SourceType);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Image other)
	{
		if (other == null)
		{
			return;
		}
		if (other.visualMedia_ != null)
		{
			if (visualMedia_ == null)
			{
				VisualMedia = new VisualMedia();
			}
			VisualMedia.MergeFrom(other.VisualMedia);
		}
		if (other.CompletionTarget != 0)
		{
			CompletionTarget = other.CompletionTarget;
		}
		if (other.SourceType != 0)
		{
			SourceType = other.SourceType;
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
				if (visualMedia_ == null)
				{
					VisualMedia = new VisualMedia();
				}
				input.ReadMessage(VisualMedia);
				break;
			case 16u:
				CompletionTarget = (CompletionTarget)input.ReadEnum();
				break;
			case 24u:
				SourceType = (SourceType)input.ReadEnum();
				break;
			}
		}
	}
}
