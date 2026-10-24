using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Startup;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class LibraryUsage : IMessage<LibraryUsage>, IMessage, IEquatable<LibraryUsage>, IDeepCloneable<LibraryUsage>
{
	private static readonly MessageParser<LibraryUsage> _parser = new MessageParser<LibraryUsage>(() => new LibraryUsage());

	private UnknownFieldSet _unknownFields;

	public const int NumberOfPresentationsFieldNumber = 1;

	private ulong numberOfPresentations_;

	public const int BytesOfPresentationsFieldNumber = 2;

	private ulong bytesOfPresentations_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<LibraryUsage> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsStartupReflection.Descriptor.MessageTypes[19];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ulong NumberOfPresentations
	{
		get
		{
			return numberOfPresentations_;
		}
		set
		{
			numberOfPresentations_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ulong BytesOfPresentations
	{
		get
		{
			return bytesOfPresentations_;
		}
		set
		{
			bytesOfPresentations_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LibraryUsage()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LibraryUsage(LibraryUsage other)
		: this()
	{
		numberOfPresentations_ = other.numberOfPresentations_;
		bytesOfPresentations_ = other.bytesOfPresentations_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LibraryUsage Clone()
	{
		return new LibraryUsage(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as LibraryUsage);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(LibraryUsage other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (NumberOfPresentations != other.NumberOfPresentations)
		{
			return false;
		}
		if (BytesOfPresentations != other.BytesOfPresentations)
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
		if (NumberOfPresentations != 0L)
		{
			num ^= NumberOfPresentations.GetHashCode();
		}
		if (BytesOfPresentations != 0L)
		{
			num ^= BytesOfPresentations.GetHashCode();
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
		if (NumberOfPresentations != 0L)
		{
			output.WriteRawTag(8);
			output.WriteUInt64(NumberOfPresentations);
		}
		if (BytesOfPresentations != 0L)
		{
			output.WriteRawTag(16);
			output.WriteUInt64(BytesOfPresentations);
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
		if (NumberOfPresentations != 0L)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(NumberOfPresentations);
		}
		if (BytesOfPresentations != 0L)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(BytesOfPresentations);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(LibraryUsage other)
	{
		if (other != null)
		{
			if (other.NumberOfPresentations != 0L)
			{
				NumberOfPresentations = other.NumberOfPresentations;
			}
			if (other.BytesOfPresentations != 0L)
			{
				BytesOfPresentations = other.BytesOfPresentations;
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
				NumberOfPresentations = input.ReadUInt64();
				break;
			case 16u:
				BytesOfPresentations = input.ReadUInt64();
				break;
			}
		}
	}
}
