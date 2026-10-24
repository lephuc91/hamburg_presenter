using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class TargetSet : IMessage<TargetSet>, IMessage, IEquatable<TargetSet>, IDeepCloneable<TargetSet>
{
	private static readonly MessageParser<TargetSet> _parser = new MessageParser<TargetSet>(() => new TargetSet());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private UUID uuid_;

	public const int NameFieldNumber = 2;

	private string name_ = "";

	public const int ColorFieldNumber = 3;

	private Color color_;

	public const int TestImagePathFieldNumber = 4;

	private URL testImagePath_;

	public const int SourceSizeFieldNumber = 5;

	private Graphics.Types.Size sourceSize_;

	public const int TargetsFieldNumber = 6;

	private static readonly FieldCodec<Target> _repeated_targets_codec = FieldCodec.ForMessage(50u, Target.Parser);

	private readonly RepeatedField<Target> targets_ = new RepeatedField<Target>();

	public const int TestPatternFieldNumber = 7;

	private TestPattern testPattern_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<TargetSet> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => TargetsReflection.Descriptor.MessageTypes[0];

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
	public Color Color
	{
		get
		{
			return color_;
		}
		set
		{
			color_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public URL TestImagePath
	{
		get
		{
			return testImagePath_;
		}
		set
		{
			testImagePath_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Graphics.Types.Size SourceSize
	{
		get
		{
			return sourceSize_;
		}
		set
		{
			sourceSize_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<Target> Targets => targets_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TestPattern TestPattern
	{
		get
		{
			return testPattern_;
		}
		set
		{
			testPattern_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TargetSet()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TargetSet(TargetSet other)
		: this()
	{
		uuid_ = ((other.uuid_ != null) ? other.uuid_.Clone() : null);
		name_ = other.name_;
		color_ = ((other.color_ != null) ? other.color_.Clone() : null);
		testImagePath_ = ((other.testImagePath_ != null) ? other.testImagePath_.Clone() : null);
		sourceSize_ = ((other.sourceSize_ != null) ? other.sourceSize_.Clone() : null);
		targets_ = other.targets_.Clone();
		testPattern_ = ((other.testPattern_ != null) ? other.testPattern_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TargetSet Clone()
	{
		return new TargetSet(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as TargetSet);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(TargetSet other)
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
		if (!object.Equals(Color, other.Color))
		{
			return false;
		}
		if (!object.Equals(TestImagePath, other.TestImagePath))
		{
			return false;
		}
		if (!object.Equals(SourceSize, other.SourceSize))
		{
			return false;
		}
		if (!targets_.Equals(other.targets_))
		{
			return false;
		}
		if (!object.Equals(TestPattern, other.TestPattern))
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
		if (color_ != null)
		{
			num ^= Color.GetHashCode();
		}
		if (testImagePath_ != null)
		{
			num ^= TestImagePath.GetHashCode();
		}
		if (sourceSize_ != null)
		{
			num ^= SourceSize.GetHashCode();
		}
		num ^= targets_.GetHashCode();
		if (testPattern_ != null)
		{
			num ^= TestPattern.GetHashCode();
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
		if (color_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Color);
		}
		if (testImagePath_ != null)
		{
			output.WriteRawTag(34);
			output.WriteMessage(TestImagePath);
		}
		if (sourceSize_ != null)
		{
			output.WriteRawTag(42);
			output.WriteMessage(SourceSize);
		}
		targets_.WriteTo(output, _repeated_targets_codec);
		if (testPattern_ != null)
		{
			output.WriteRawTag(58);
			output.WriteMessage(TestPattern);
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
		if (color_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Color);
		}
		if (testImagePath_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TestImagePath);
		}
		if (sourceSize_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SourceSize);
		}
		num += targets_.CalculateSize(_repeated_targets_codec);
		if (testPattern_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TestPattern);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(TargetSet other)
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
		if (other.color_ != null)
		{
			if (color_ == null)
			{
				Color = new Color();
			}
			Color.MergeFrom(other.Color);
		}
		if (other.testImagePath_ != null)
		{
			if (testImagePath_ == null)
			{
				TestImagePath = new URL();
			}
			TestImagePath.MergeFrom(other.TestImagePath);
		}
		if (other.sourceSize_ != null)
		{
			if (sourceSize_ == null)
			{
				SourceSize = new Graphics.Types.Size();
			}
			SourceSize.MergeFrom(other.SourceSize);
		}
		targets_.Add(other.targets_);
		if (other.testPattern_ != null)
		{
			if (testPattern_ == null)
			{
				TestPattern = new TestPattern();
			}
			TestPattern.MergeFrom(other.TestPattern);
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
				if (color_ == null)
				{
					Color = new Color();
				}
				input.ReadMessage(Color);
				break;
			case 34u:
				if (testImagePath_ == null)
				{
					TestImagePath = new URL();
				}
				input.ReadMessage(TestImagePath);
				break;
			case 42u:
				if (sourceSize_ == null)
				{
					SourceSize = new Graphics.Types.Size();
				}
				input.ReadMessage(SourceSize);
				break;
			case 50u:
				targets_.AddEntriesFrom(input, _repeated_targets_codec);
				break;
			case 58u:
				if (testPattern_ == null)
				{
					TestPattern = new TestPattern();
				}
				input.ReadMessage(TestPattern);
				break;
			}
		}
	}
}
