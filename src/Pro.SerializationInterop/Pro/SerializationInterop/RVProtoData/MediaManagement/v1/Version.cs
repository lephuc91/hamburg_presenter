using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaManagement.v1;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Version : IMessage<Version>, IMessage, IEquatable<Version>, IDeepCloneable<Version>
{
	private static readonly MessageParser<Version> _parser = new MessageParser<Version>(() => new Version());

	private UnknownFieldSet _unknownFields;

	public const int MajorFieldNumber = 1;

	private int major_;

	public const int MinorFieldNumber = 2;

	private int minor_;

	public const int PatchFieldNumber = 3;

	private int patch_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Version> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V1HelperCommonReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int Major
	{
		get
		{
			return major_;
		}
		set
		{
			major_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int Minor
	{
		get
		{
			return minor_;
		}
		set
		{
			minor_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int Patch
	{
		get
		{
			return patch_;
		}
		set
		{
			patch_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Version()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Version(Version other)
		: this()
	{
		major_ = other.major_;
		minor_ = other.minor_;
		patch_ = other.patch_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Version Clone()
	{
		return new Version(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as Version);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(Version other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Major != other.Major)
		{
			return false;
		}
		if (Minor != other.Minor)
		{
			return false;
		}
		if (Patch != other.Patch)
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
		if (Major != 0)
		{
			num ^= Major.GetHashCode();
		}
		if (Minor != 0)
		{
			num ^= Minor.GetHashCode();
		}
		if (Patch != 0)
		{
			num ^= Patch.GetHashCode();
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
		if (Major != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(Major);
		}
		if (Minor != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(Minor);
		}
		if (Patch != 0)
		{
			output.WriteRawTag(24);
			output.WriteInt32(Patch);
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
		if (Major != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(Major);
		}
		if (Minor != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(Minor);
		}
		if (Patch != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(Patch);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(Version other)
	{
		if (other != null)
		{
			if (other.Major != 0)
			{
				Major = other.Major;
			}
			if (other.Minor != 0)
			{
				Minor = other.Minor;
			}
			if (other.Patch != 0)
			{
				Patch = other.Patch;
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
				Major = input.ReadInt32();
				break;
			case 16u:
				Minor = input.ReadInt32();
				break;
			case 24u:
				Patch = input.ReadInt32();
				break;
			}
		}
	}
}
