using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class CreationOption : IMessage<CreationOption>, IMessage, IEquatable<CreationOption>, IDeepCloneable<CreationOption>
{
	public enum SocketOneofCase
	{
		None = 0,
		Name = 2
	}

	public enum TimeoutOneofCase
	{
		None = 0,
		Seconds = 3
	}

	private static readonly MessageParser<CreationOption> _parser = new MessageParser<CreationOption>(() => new CreationOption());

	private UnknownFieldSet _unknownFields;

	private int _hasBits0;

	public const int ShowDirectoryFieldNumber = 1;

	private string showDirectory_ = "";

	public const int NameFieldNumber = 2;

	public const int SecondsFieldNumber = 3;

	public const int PreferencesFieldNumber = 4;

	private Preferences preferences_;

	public const int WorkspaceIdFieldNumber = 5;

	private static readonly string WorkspaceIdDefaultValue = "";

	private string workspaceId_;

	public const int PeerIdFieldNumber = 6;

	private static readonly ulong PeerIdDefaultValue = 0uL;

	private ulong peerId_;

	private object socket_;

	private SocketOneofCase socketCase_;

	private object timeout_;

	private TimeoutOneofCase timeoutCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<CreationOption> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V2HelperCommonReflection.Descriptor.MessageTypes[5];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string ShowDirectory
	{
		get
		{
			return showDirectory_;
		}
		set
		{
			showDirectory_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Name
	{
		get
		{
			if (!HasName)
			{
				return "";
			}
			return (string)socket_;
		}
		set
		{
			socket_ = ProtoPreconditions.CheckNotNull(value, "value");
			socketCase_ = SocketOneofCase.Name;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasName => socketCase_ == SocketOneofCase.Name;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint Seconds
	{
		get
		{
			if (!HasSeconds)
			{
				return 0u;
			}
			return (uint)timeout_;
		}
		set
		{
			timeout_ = value;
			timeoutCase_ = TimeoutOneofCase.Seconds;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasSeconds => timeoutCase_ == TimeoutOneofCase.Seconds;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Preferences Preferences
	{
		get
		{
			return preferences_;
		}
		set
		{
			preferences_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string WorkspaceId
	{
		get
		{
			return workspaceId_ ?? WorkspaceIdDefaultValue;
		}
		set
		{
			workspaceId_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasWorkspaceId => workspaceId_ != null;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ulong PeerId
	{
		get
		{
			if ((_hasBits0 & 1) != 0)
			{
				return peerId_;
			}
			return PeerIdDefaultValue;
		}
		set
		{
			_hasBits0 |= 1;
			peerId_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasPeerId => (_hasBits0 & 1) != 0;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SocketOneofCase SocketCase => socketCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TimeoutOneofCase TimeoutCase => timeoutCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CreationOption()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CreationOption(CreationOption other)
		: this()
	{
		_hasBits0 = other._hasBits0;
		showDirectory_ = other.showDirectory_;
		preferences_ = ((other.preferences_ != null) ? other.preferences_.Clone() : null);
		workspaceId_ = other.workspaceId_;
		peerId_ = other.peerId_;
		if (other.SocketCase == SocketOneofCase.Name)
		{
			Name = other.Name;
		}
		if (other.TimeoutCase == TimeoutOneofCase.Seconds)
		{
			Seconds = other.Seconds;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CreationOption Clone()
	{
		return new CreationOption(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearName()
	{
		if (HasName)
		{
			ClearSocket();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearSeconds()
	{
		if (HasSeconds)
		{
			ClearTimeout();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearWorkspaceId()
	{
		workspaceId_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearPeerId()
	{
		_hasBits0 &= -2;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearSocket()
	{
		socketCase_ = SocketOneofCase.None;
		socket_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearTimeout()
	{
		timeoutCase_ = TimeoutOneofCase.None;
		timeout_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as CreationOption);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(CreationOption other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (ShowDirectory != other.ShowDirectory)
		{
			return false;
		}
		if (Name != other.Name)
		{
			return false;
		}
		if (Seconds != other.Seconds)
		{
			return false;
		}
		if (!object.Equals(Preferences, other.Preferences))
		{
			return false;
		}
		if (WorkspaceId != other.WorkspaceId)
		{
			return false;
		}
		if (PeerId != other.PeerId)
		{
			return false;
		}
		if (SocketCase != other.SocketCase)
		{
			return false;
		}
		if (TimeoutCase != other.TimeoutCase)
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
		if (ShowDirectory.Length != 0)
		{
			num ^= ShowDirectory.GetHashCode();
		}
		if (HasName)
		{
			num ^= Name.GetHashCode();
		}
		if (HasSeconds)
		{
			num ^= Seconds.GetHashCode();
		}
		if (preferences_ != null)
		{
			num ^= Preferences.GetHashCode();
		}
		if (HasWorkspaceId)
		{
			num ^= WorkspaceId.GetHashCode();
		}
		if (HasPeerId)
		{
			num ^= PeerId.GetHashCode();
		}
		num ^= (int)socketCase_;
		num ^= (int)timeoutCase_;
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
		if (ShowDirectory.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(ShowDirectory);
		}
		if (HasName)
		{
			output.WriteRawTag(18);
			output.WriteString(Name);
		}
		if (HasSeconds)
		{
			output.WriteRawTag(24);
			output.WriteUInt32(Seconds);
		}
		if (preferences_ != null)
		{
			output.WriteRawTag(34);
			output.WriteMessage(Preferences);
		}
		if (HasWorkspaceId)
		{
			output.WriteRawTag(42);
			output.WriteString(WorkspaceId);
		}
		if (HasPeerId)
		{
			output.WriteRawTag(48);
			output.WriteUInt64(PeerId);
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
		if (ShowDirectory.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(ShowDirectory);
		}
		if (HasName)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Name);
		}
		if (HasSeconds)
		{
			num += 1 + CodedOutputStream.ComputeUInt32Size(Seconds);
		}
		if (preferences_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Preferences);
		}
		if (HasWorkspaceId)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(WorkspaceId);
		}
		if (HasPeerId)
		{
			num += 1 + CodedOutputStream.ComputeUInt64Size(PeerId);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(CreationOption other)
	{
		if (other == null)
		{
			return;
		}
		if (other.ShowDirectory.Length != 0)
		{
			ShowDirectory = other.ShowDirectory;
		}
		if (other.preferences_ != null)
		{
			if (preferences_ == null)
			{
				Preferences = new Preferences();
			}
			Preferences.MergeFrom(other.Preferences);
		}
		if (other.HasWorkspaceId)
		{
			WorkspaceId = other.WorkspaceId;
		}
		if (other.HasPeerId)
		{
			PeerId = other.PeerId;
		}
		if (other.SocketCase == SocketOneofCase.Name)
		{
			Name = other.Name;
		}
		if (other.TimeoutCase == TimeoutOneofCase.Seconds)
		{
			Seconds = other.Seconds;
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
				ShowDirectory = input.ReadString();
				break;
			case 18u:
				Name = input.ReadString();
				break;
			case 24u:
				Seconds = input.ReadUInt32();
				break;
			case 34u:
				if (preferences_ == null)
				{
					Preferences = new Preferences();
				}
				input.ReadMessage(Preferences);
				break;
			case 42u:
				WorkspaceId = input.ReadString();
				break;
			case 48u:
				PeerId = input.ReadUInt64();
				break;
			}
		}
	}
}
