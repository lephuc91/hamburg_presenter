using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.RVError;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ReportedError : IMessage<ReportedError>, IMessage, IEquatable<ReportedError>, IDeepCloneable<ReportedError>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Severity
		{
			[OriginalName("HANDLED")]
			Handled,
			[OriginalName("FATAL")]
			Fatal
		}
	}

	private static readonly MessageParser<ReportedError> _parser = new MessageParser<ReportedError>(() => new ReportedError());

	private UnknownFieldSet _unknownFields;

	public const int DescriptionFieldNumber = 1;

	private string description_ = "";

	public const int TypeFieldNumber = 2;

	private string type_ = "";

	public const int FileFieldNumber = 3;

	private string file_ = "";

	public const int LineFieldNumber = 4;

	private uint line_;

	public const int SeverityFieldNumber = 5;

	private Types.Severity severity_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ReportedError> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => RverrorReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

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
	public string Type
	{
		get
		{
			return type_;
		}
		set
		{
			type_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string File
	{
		get
		{
			return file_;
		}
		set
		{
			file_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint Line
	{
		get
		{
			return line_;
		}
		set
		{
			line_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Severity Severity
	{
		get
		{
			return severity_;
		}
		set
		{
			severity_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ReportedError()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ReportedError(ReportedError other)
		: this()
	{
		description_ = other.description_;
		type_ = other.type_;
		file_ = other.file_;
		line_ = other.line_;
		severity_ = other.severity_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ReportedError Clone()
	{
		return new ReportedError(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ReportedError);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ReportedError other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Description != other.Description)
		{
			return false;
		}
		if (Type != other.Type)
		{
			return false;
		}
		if (File != other.File)
		{
			return false;
		}
		if (Line != other.Line)
		{
			return false;
		}
		if (Severity != other.Severity)
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
		if (Description.Length != 0)
		{
			num ^= Description.GetHashCode();
		}
		if (Type.Length != 0)
		{
			num ^= Type.GetHashCode();
		}
		if (File.Length != 0)
		{
			num ^= File.GetHashCode();
		}
		if (Line != 0)
		{
			num ^= Line.GetHashCode();
		}
		if (Severity != 0)
		{
			num ^= Severity.GetHashCode();
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
		if (Description.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(Description);
		}
		if (Type.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Type);
		}
		if (File.Length != 0)
		{
			output.WriteRawTag(26);
			output.WriteString(File);
		}
		if (Line != 0)
		{
			output.WriteRawTag(32);
			output.WriteUInt32(Line);
		}
		if (Severity != 0)
		{
			output.WriteRawTag(40);
			output.WriteEnum((int)Severity);
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
		if (Description.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Description);
		}
		if (Type.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Type);
		}
		if (File.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(File);
		}
		if (Line != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(Line);
		}
		if (Severity != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Severity);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ReportedError other)
	{
		if (other != null)
		{
			if (other.Description.Length != 0)
			{
				Description = other.Description;
			}
			if (other.Type.Length != 0)
			{
				Type = other.Type;
			}
			if (other.File.Length != 0)
			{
				File = other.File;
			}
			if (other.Line != 0)
			{
				Line = other.Line;
			}
			if (other.Severity != 0)
			{
				Severity = other.Severity;
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
			case 10u:
				Description = input.ReadString();
				break;
			case 18u:
				Type = input.ReadString();
				break;
			case 26u:
				File = input.ReadString();
				break;
			case 32u:
				Line = input.ReadUInt32();
				break;
			case 40u:
				Severity = (Types.Severity)input.ReadEnum();
				break;
			}
		}
	}
}
