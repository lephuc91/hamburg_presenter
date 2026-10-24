using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Target : IMessage<Target>, IMessage, IEquatable<Target>, IDeepCloneable<Target>
{
	private static readonly MessageParser<Target> _parser = new MessageParser<Target>(() => new Target());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private UUID uuid_;

	public const int NameFieldNumber = 2;

	private string name_ = "";

	public const int SourceUnitRectFieldNumber = 3;

	private Graphics.Types.Rect sourceUnitRect_;

	public const int TestImageFillFieldNumber = 4;

	private Media testImageFill_;

	public const int ShapeFieldNumber = 5;

	private Graphics.Types.Element shape_;

	public const int FlipModeFieldNumber = 6;

	private Graphics.Types.Element.Types.FlipMode flipMode_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Target> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => TargetsReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID Uuid
	{
		get
		{
			return uuid_;
		}
		set
		{
			uuid_ = value;
		}
	}

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
	public Graphics.Types.Rect SourceUnitRect
	{
		get
		{
			return sourceUnitRect_;
		}
		set
		{
			sourceUnitRect_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Media TestImageFill
	{
		get
		{
			return testImageFill_;
		}
		set
		{
			testImageFill_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Graphics.Types.Element Shape
	{
		get
		{
			return shape_;
		}
		set
		{
			shape_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Graphics.Types.Element.Types.FlipMode FlipMode
	{
		get
		{
			return flipMode_;
		}
		set
		{
			flipMode_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Target()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Target(Target other)
		: this()
	{
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		name_ = other.name_;
		sourceUnitRect_ = ((other.sourceUnitRect_ != null) ? other.sourceUnitRect_.Clone() : null);
		testImageFill_ = ((other.testImageFill_ != null) ? other.testImageFill_.Clone() : null);
		shape_ = ((other.shape_ != null) ? other.shape_.Clone() : null);
		flipMode_ = other.flipMode_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Target Clone()
	{
		return new Target(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Target);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Target other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Uuid, other.Uuid))
		{
			return false;
		}
		if (Name != other.Name)
		{
			return false;
		}
		if (!object.Equals(SourceUnitRect, other.SourceUnitRect))
		{
			return false;
		}
		if (!object.Equals(TestImageFill, other.TestImageFill))
		{
			return false;
		}
		if (!object.Equals(Shape, other.Shape))
		{
			return false;
		}
		if (FlipMode != other.FlipMode)
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
		if (uuid_ != null)
		{
			num ^= Uuid.GetHashCode();
		}
		if (Name.Length != 0)
		{
			num ^= Name.GetHashCode();
		}
		if (sourceUnitRect_ != null)
		{
			num ^= SourceUnitRect.GetHashCode();
		}
		if (testImageFill_ != null)
		{
			num ^= TestImageFill.GetHashCode();
		}
		if (shape_ != null)
		{
			num ^= Shape.GetHashCode();
		}
		if (FlipMode != 0)
		{
			num ^= FlipMode.GetHashCode();
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
		if (uuid_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Uuid);
		}
		if (Name.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Name);
		}
		if (sourceUnitRect_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(SourceUnitRect);
		}
		if (testImageFill_ != null)
		{
			output.WriteRawTag(34);
			output.WriteMessage(TestImageFill);
		}
		if (shape_ != null)
		{
			output.WriteRawTag(42);
			output.WriteMessage(Shape);
		}
		if (FlipMode != 0)
		{
			output.WriteRawTag(48);
			output.WriteEnum((int)FlipMode);
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
		if (uuid_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Uuid);
		}
		if (Name.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Name);
		}
		if (sourceUnitRect_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SourceUnitRect);
		}
		if (testImageFill_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TestImageFill);
		}
		if (shape_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Shape);
		}
		if (FlipMode != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)FlipMode);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Target other)
	{
		if (other == null)
		{
			return;
		}
		if (other.uuid_ != null)
		{
			if (uuid_ == null)
			{
				Uuid = new UUID();
			}
			Uuid.MergeFrom(other.Uuid);
		}
		if (other.Name.Length != 0)
		{
			Name = other.Name;
		}
		if (other.sourceUnitRect_ != null)
		{
			if (sourceUnitRect_ == null)
			{
				SourceUnitRect = new Graphics.Types.Rect();
			}
			SourceUnitRect.MergeFrom(other.SourceUnitRect);
		}
		if (other.testImageFill_ != null)
		{
			if (testImageFill_ == null)
			{
				TestImageFill = new Media();
			}
			TestImageFill.MergeFrom(other.TestImageFill);
		}
		if (other.shape_ != null)
		{
			if (shape_ == null)
			{
				Shape = new Graphics.Types.Element();
			}
			Shape.MergeFrom(other.Shape);
		}
		if (other.FlipMode != 0)
		{
			FlipMode = other.FlipMode;
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
				if (uuid_ == null)
				{
					Uuid = new UUID();
				}
				input.ReadMessage(Uuid);
				break;
			case 18u:
				Name = input.ReadString();
				break;
			case 26u:
				if (sourceUnitRect_ == null)
				{
					SourceUnitRect = new Graphics.Types.Rect();
				}
				input.ReadMessage(SourceUnitRect);
				break;
			case 34u:
				if (testImageFill_ == null)
				{
					TestImageFill = new Media();
				}
				input.ReadMessage(TestImageFill);
				break;
			case 42u:
				if (shape_ == null)
				{
					Shape = new Graphics.Types.Element();
				}
				input.ReadMessage(Shape);
				break;
			case 48u:
				FlipMode = (Graphics.Types.Element.Types.FlipMode)input.ReadEnum();
				break;
			}
		}
	}
}
