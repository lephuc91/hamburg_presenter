using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class LocalWorkspaceStats : IMessage<LocalWorkspaceStats>, IMessage, IEquatable<LocalWorkspaceStats>, IDeepCloneable<LocalWorkspaceStats>
{
	private static readonly MessageParser<LocalWorkspaceStats> _parser = new MessageParser<LocalWorkspaceStats>(() => new LocalWorkspaceStats());

	private UnknownFieldSet _unknownFields;

	public const int TotalWorkspacesFieldNumber = 1;

	private int totalWorkspaces_;

	public const int NumberOfWorkspaceSwitchesFieldNumber = 2;

	private int numberOfWorkspaceSwitches_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<LocalWorkspaceStats> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTrackedEventsReflection.Descriptor.MessageTypes[33];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int TotalWorkspaces
	{
		get
		{
			return totalWorkspaces_;
		}
		set
		{
			totalWorkspaces_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int NumberOfWorkspaceSwitches
	{
		get
		{
			return numberOfWorkspaceSwitches_;
		}
		set
		{
			numberOfWorkspaceSwitches_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LocalWorkspaceStats()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LocalWorkspaceStats(LocalWorkspaceStats other)
		: this()
	{
		totalWorkspaces_ = other.totalWorkspaces_;
		numberOfWorkspaceSwitches_ = other.numberOfWorkspaceSwitches_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public LocalWorkspaceStats Clone()
	{
		return new LocalWorkspaceStats(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as LocalWorkspaceStats);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(LocalWorkspaceStats other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (TotalWorkspaces != other.TotalWorkspaces)
		{
			return false;
		}
		if (NumberOfWorkspaceSwitches != other.NumberOfWorkspaceSwitches)
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
		if (TotalWorkspaces != 0)
		{
			num ^= TotalWorkspaces.GetHashCode();
		}
		if (NumberOfWorkspaceSwitches != 0)
		{
			num ^= NumberOfWorkspaceSwitches.GetHashCode();
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
		if (TotalWorkspaces != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(TotalWorkspaces);
		}
		if (NumberOfWorkspaceSwitches != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(NumberOfWorkspaceSwitches);
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
		if (TotalWorkspaces != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(TotalWorkspaces);
		}
		if (NumberOfWorkspaceSwitches != 0)
		{
			num += 1 + CodedOutputStream.ComputeInt32Size(NumberOfWorkspaceSwitches);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(LocalWorkspaceStats other)
	{
		if (other != null)
		{
			if (other.TotalWorkspaces != 0)
			{
				TotalWorkspaces = other.TotalWorkspaces;
			}
			if (other.NumberOfWorkspaceSwitches != 0)
			{
				NumberOfWorkspaceSwitches = other.NumberOfWorkspaceSwitches;
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
				TotalWorkspaces = input.ReadInt32();
				break;
			case 16u:
				NumberOfWorkspaceSwitches = input.ReadInt32();
				break;
			}
		}
	}
}
