using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class RemoteStreamStart : IMessage<RemoteStreamStart>, IMessage, IEquatable<RemoteStreamStart>, IDeepCloneable<RemoteStreamStart>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum StartResult
		{
			[OriginalName("SUCCESS")]
			Success,
			[OriginalName("FAILED")]
			Failed,
			[OriginalName("USERCANCELED")]
			Usercanceled
		}
	}

	private static readonly MessageParser<RemoteStreamStart> _parser = new MessageParser<RemoteStreamStart>(() => new RemoteStreamStart());

	private UnknownFieldSet _unknownFields;

	public const int ResultFieldNumber = 1;

	private Types.StartResult result_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<RemoteStreamStart> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTrackedEventsReflection.Descriptor.MessageTypes[17];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.StartResult Result
	{
		get
		{
			return result_;
		}
		set
		{
			result_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RemoteStreamStart()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RemoteStreamStart(RemoteStreamStart other)
		: this()
	{
		result_ = other.result_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RemoteStreamStart Clone()
	{
		return new RemoteStreamStart(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as RemoteStreamStart);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(RemoteStreamStart other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Result != other.Result)
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
		if (Result != 0)
		{
			num ^= Result.GetHashCode();
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
		if (Result != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Result);
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
		if (Result != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Result);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(RemoteStreamStart other)
	{
		if (other != null)
		{
			if (other.Result != 0)
			{
				Result = other.Result;
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
			if (num != 8)
			{
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
			}
			else
			{
				Result = (Types.StartResult)input.ReadEnum();
			}
		}
	}
}
