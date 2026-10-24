using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Startup;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class DiskUsage : IMessage<DiskUsage>, IMessage, IEquatable<DiskUsage>, IDeepCloneable<DiskUsage>
{
	private static readonly MessageParser<DiskUsage> _parser = new MessageParser<DiskUsage>(() => new DiskUsage());

	private UnknownFieldSet _unknownFields;

	public const int BytesOfShowFilesFieldNumber = 1;

	private ulong bytesOfShowFiles_;

	public const int BytesOfMediaAssetFilesFieldNumber = 2;

	private ulong bytesOfMediaAssetFiles_;

	public const int NumberOfMediaAssetFilesFieldNumber = 3;

	private ulong numberOfMediaAssetFiles_;

	public const int BytesOfUnmanagedMediaAssetFilesFieldNumber = 4;

	private ulong bytesOfUnmanagedMediaAssetFiles_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<DiskUsage> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsStartupReflection.Descriptor.MessageTypes[18];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ulong BytesOfShowFiles
	{
		get
		{
			return bytesOfShowFiles_;
		}
		set
		{
			bytesOfShowFiles_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ulong BytesOfMediaAssetFiles
	{
		get
		{
			return bytesOfMediaAssetFiles_;
		}
		set
		{
			bytesOfMediaAssetFiles_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ulong NumberOfMediaAssetFiles
	{
		get
		{
			return numberOfMediaAssetFiles_;
		}
		set
		{
			numberOfMediaAssetFiles_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ulong BytesOfUnmanagedMediaAssetFiles
	{
		get
		{
			return bytesOfUnmanagedMediaAssetFiles_;
		}
		set
		{
			bytesOfUnmanagedMediaAssetFiles_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DiskUsage()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DiskUsage(DiskUsage other)
		: this()
	{
		bytesOfShowFiles_ = other.bytesOfShowFiles_;
		bytesOfMediaAssetFiles_ = other.bytesOfMediaAssetFiles_;
		numberOfMediaAssetFiles_ = other.numberOfMediaAssetFiles_;
		bytesOfUnmanagedMediaAssetFiles_ = other.bytesOfUnmanagedMediaAssetFiles_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DiskUsage Clone()
	{
		return new DiskUsage(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as DiskUsage);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(DiskUsage other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (BytesOfShowFiles != other.BytesOfShowFiles)
		{
			return false;
		}
		if (BytesOfMediaAssetFiles != other.BytesOfMediaAssetFiles)
		{
			return false;
		}
		if (NumberOfMediaAssetFiles != other.NumberOfMediaAssetFiles)
		{
			return false;
		}
		if (BytesOfUnmanagedMediaAssetFiles != other.BytesOfUnmanagedMediaAssetFiles)
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
		if (BytesOfShowFiles != 0L)
		{
			num ^= BytesOfShowFiles.GetHashCode();
		}
		if (BytesOfMediaAssetFiles != 0L)
		{
			num ^= BytesOfMediaAssetFiles.GetHashCode();
		}
		if (NumberOfMediaAssetFiles != 0L)
		{
			num ^= NumberOfMediaAssetFiles.GetHashCode();
		}
		if (BytesOfUnmanagedMediaAssetFiles != 0L)
		{
			num ^= BytesOfUnmanagedMediaAssetFiles.GetHashCode();
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
		if (BytesOfShowFiles != 0L)
		{
			output.WriteRawTag(8);
			output.WriteUInt64(BytesOfShowFiles);
		}
		if (BytesOfMediaAssetFiles != 0L)
		{
			output.WriteRawTag(16);
			output.WriteUInt64(BytesOfMediaAssetFiles);
		}
		if (NumberOfMediaAssetFiles != 0L)
		{
			output.WriteRawTag(24);
			output.WriteUInt64(NumberOfMediaAssetFiles);
		}
		if (BytesOfUnmanagedMediaAssetFiles != 0L)
		{
			output.WriteRawTag(32);
			output.WriteUInt64(BytesOfUnmanagedMediaAssetFiles);
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
		if (BytesOfShowFiles != 0L)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(BytesOfShowFiles);
		}
		if (BytesOfMediaAssetFiles != 0L)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(BytesOfMediaAssetFiles);
		}
		if (NumberOfMediaAssetFiles != 0L)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(NumberOfMediaAssetFiles);
		}
		if (BytesOfUnmanagedMediaAssetFiles != 0L)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(BytesOfUnmanagedMediaAssetFiles);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(DiskUsage other)
	{
		if (other != null)
		{
			if (other.BytesOfShowFiles != 0L)
			{
				BytesOfShowFiles = other.BytesOfShowFiles;
			}
			if (other.BytesOfMediaAssetFiles != 0L)
			{
				BytesOfMediaAssetFiles = other.BytesOfMediaAssetFiles;
			}
			if (other.NumberOfMediaAssetFiles != 0L)
			{
				NumberOfMediaAssetFiles = other.NumberOfMediaAssetFiles;
			}
			if (other.BytesOfUnmanagedMediaAssetFiles != 0L)
			{
				BytesOfUnmanagedMediaAssetFiles = other.BytesOfUnmanagedMediaAssetFiles;
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
				BytesOfShowFiles = input.ReadUInt64();
				break;
			case 16u:
				BytesOfMediaAssetFiles = input.ReadUInt64();
				break;
			case 24u:
				NumberOfMediaAssetFiles = input.ReadUInt64();
				break;
			case 32u:
				BytesOfUnmanagedMediaAssetFiles = input.ReadUInt64();
				break;
			}
		}
	}
}
