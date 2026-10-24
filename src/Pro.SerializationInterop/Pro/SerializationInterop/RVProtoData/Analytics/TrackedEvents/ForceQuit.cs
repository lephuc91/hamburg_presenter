using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ForceQuit : IMessage<ForceQuit>, IMessage, IEquatable<ForceQuit>, IDeepCloneable<ForceQuit>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Reason
		{
			[OriginalName("UNKNOWN")]
			Unknown,
			[OriginalName("HOSTS_FILE")]
			HostsFile,
			[OriginalName("SYSTEM_TIME_SKEW")]
			SystemTimeSkew,
			[OriginalName("INVALID_WATERMARK")]
			InvalidWatermark,
			[OriginalName("PIRATED_SOFTWARE")]
			PiratedSoftware,
			[OriginalName("METAL_UNAVAILABLE")]
			MetalUnavailable,
			[OriginalName("UBIQUITY_DOWNLOAD_ABORTED")]
			UbiquityDownloadAborted,
			[OriginalName("CORE_RUST_CONTROLLER_FAILURE")]
			CoreRustControllerFailure
		}
	}

	private static readonly MessageParser<ForceQuit> _parser = new MessageParser<ForceQuit>(() => new ForceQuit());

	private UnknownFieldSet _unknownFields;

	public const int ReasonFieldNumber = 1;

	private Types.Reason reason_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ForceQuit> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTrackedEventsReflection.Descriptor.MessageTypes[30];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Reason Reason
	{
		get
		{
			return reason_;
		}
		set
		{
			reason_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ForceQuit()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ForceQuit(ForceQuit other)
		: this()
	{
		reason_ = other.reason_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ForceQuit Clone()
	{
		return new ForceQuit(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ForceQuit);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ForceQuit other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Reason != other.Reason)
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
		if (Reason != 0)
		{
			num ^= Reason.GetHashCode();
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
		if (Reason != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Reason);
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
		if (Reason != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Reason);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ForceQuit other)
	{
		if (other != null)
		{
			if (other.Reason != 0)
			{
				Reason = other.Reason;
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
				Reason = (Types.Reason)input.ReadEnum();
			}
		}
	}
}
