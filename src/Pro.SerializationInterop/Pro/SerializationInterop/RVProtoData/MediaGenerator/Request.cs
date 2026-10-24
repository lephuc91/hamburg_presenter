using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaGenerator;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Request : IMessage<Request>, IMessage, IEquatable<Request>, IDeepCloneable<Request>
{
	private static readonly MessageParser<Request> _parser = new MessageParser<Request>(() => new Request());

	private UnknownFieldSet _unknownFields;

	public const int InputFieldNumber = 1;

	private string input_ = "";

	public const int OutputFieldNumber = 2;

	private string output_ = "";

	public const int TransformationFieldNumber = 3;

	private Transformation transformation_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Request> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => HelperSnapshotReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Input
	{
		get
		{
			return input_;
		}
		set
		{
			input_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Output
	{
		get
		{
			return output_;
		}
		set
		{
			output_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Transformation Transformation
	{
		get
		{
			return transformation_;
		}
		set
		{
			transformation_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Request()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Request(Request other)
		: this()
	{
		input_ = other.input_;
		output_ = other.output_;
		transformation_ = ((other.transformation_ != null) ? other.transformation_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Request Clone()
	{
		return new Request(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Request);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Request other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Input != other.Input)
		{
			return false;
		}
		if (Output != other.Output)
		{
			return false;
		}
		if (!object.Equals(Transformation, other.Transformation))
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
		if (Input.Length != 0)
		{
			num ^= Input.GetHashCode();
		}
		if (Output.Length != 0)
		{
			num ^= Output.GetHashCode();
		}
		if (transformation_ != null)
		{
			num ^= Transformation.GetHashCode();
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
		if (Input.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(Input);
		}
		if (Output.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Output);
		}
		if (transformation_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Transformation);
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
		if (Input.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Input);
		}
		if (Output.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Output);
		}
		if (transformation_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Transformation);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Request other)
	{
		if (other == null)
		{
			return;
		}
		if (other.Input.Length != 0)
		{
			Input = other.Input;
		}
		if (other.Output.Length != 0)
		{
			Output = other.Output;
		}
		if (other.transformation_ != null)
		{
			if (transformation_ == null)
			{
				Transformation = new Transformation();
			}
			Transformation.MergeFrom(other.Transformation);
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
				Input = input.ReadString();
				break;
			case 18u:
				Output = input.ReadString();
				break;
			case 26u:
				if (transformation_ == null)
				{
					Transformation = new Transformation();
				}
				input.ReadMessage(Transformation);
				break;
			}
		}
	}
}
