using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class Version : IMessage<Version>, IMessage, IEquatable<Version>, IDeepCloneable<Version>
{
	private static readonly MessageParser<Version> _parser = new MessageParser<Version>(() => new Version());

	private UnknownFieldSet _unknownFields;

	public const int MajorVersionFieldNumber = 1;

	private uint majorVersion_;

	public const int MinorVersionFieldNumber = 2;

	private uint minorVersion_;

	public const int PatchVersionFieldNumber = 3;

	private uint patchVersion_;

	public const int BuildFieldNumber = 4;

	private string build_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<Version> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => VersionReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint MajorVersion
	{
		get
		{
			return majorVersion_;
		}
		set
		{
			majorVersion_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint MinorVersion
	{
		get
		{
			return minorVersion_;
		}
		set
		{
			minorVersion_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint PatchVersion
	{
		get
		{
			return patchVersion_;
		}
		set
		{
			patchVersion_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Build
	{
		get
		{
			return build_;
		}
		set
		{
			build_ = ProtoPreconditions.CheckNotNull(value, "value");
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
		majorVersion_ = other.majorVersion_;
		minorVersion_ = other.minorVersion_;
		patchVersion_ = other.patchVersion_;
		build_ = other.build_;
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
		if (MajorVersion != other.MajorVersion)
		{
			return false;
		}
		if (MinorVersion != other.MinorVersion)
		{
			return false;
		}
		if (PatchVersion != other.PatchVersion)
		{
			return false;
		}
		if (Build != other.Build)
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
		if (MajorVersion != 0)
		{
			num ^= MajorVersion.GetHashCode();
		}
		if (MinorVersion != 0)
		{
			num ^= MinorVersion.GetHashCode();
		}
		if (PatchVersion != 0)
		{
			num ^= PatchVersion.GetHashCode();
		}
		if (Build.Length != 0)
		{
			num ^= Build.GetHashCode();
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
		if (MajorVersion != 0)
		{
			output.WriteRawTag(8);
			output.WriteUInt32(MajorVersion);
		}
		if (MinorVersion != 0)
		{
			output.WriteRawTag(16);
			output.WriteUInt32(MinorVersion);
		}
		if (PatchVersion != 0)
		{
			output.WriteRawTag(24);
			output.WriteUInt32(PatchVersion);
		}
		if (Build.Length != 0)
		{
			output.WriteRawTag(34);
			output.WriteString(Build);
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
		if (MajorVersion != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(MajorVersion);
		}
		if (MinorVersion != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(MinorVersion);
		}
		if (PatchVersion != 0)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(PatchVersion);
		}
		if (Build.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Build);
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
			if (other.MajorVersion != 0)
			{
				MajorVersion = other.MajorVersion;
			}
			if (other.MinorVersion != 0)
			{
				MinorVersion = other.MinorVersion;
			}
			if (other.PatchVersion != 0)
			{
				PatchVersion = other.PatchVersion;
			}
			if (other.Build.Length != 0)
			{
				Build = other.Build;
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
				MajorVersion = input.ReadUInt32();
				break;
			case 16u:
				MinorVersion = input.ReadUInt32();
				break;
			case 24u:
				PatchVersion = input.ReadUInt32();
				break;
			case 34u:
				Build = input.ReadString();
				break;
			}
		}
	}
}
