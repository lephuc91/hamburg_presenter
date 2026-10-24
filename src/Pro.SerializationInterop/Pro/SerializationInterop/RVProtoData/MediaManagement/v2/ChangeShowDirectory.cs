using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ChangeShowDirectory : IMessage<ChangeShowDirectory>, IMessage, IEquatable<ChangeShowDirectory>, IDeepCloneable<ChangeShowDirectory>
{
	private static readonly MessageParser<ChangeShowDirectory> _parser = new MessageParser<ChangeShowDirectory>(() => new ChangeShowDirectory());

	private UnknownFieldSet _unknownFields;

	public const int PathFieldNumber = 1;

	private string path_ = "";

	public const int WorkspaceIdFieldNumber = 2;

	private static readonly string WorkspaceIdDefaultValue = "";

	private string workspaceId_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ChangeShowDirectory> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V2HelperCommonReflection.Descriptor.MessageTypes[11];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Path
	{
		get
		{
			return path_;
		}
		set
		{
			path_ = ProtoPreconditions.CheckNotNull(value, "value");
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
	public ChangeShowDirectory()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ChangeShowDirectory(ChangeShowDirectory other)
		: this()
	{
		path_ = other.path_;
		workspaceId_ = other.workspaceId_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ChangeShowDirectory Clone()
	{
		return new ChangeShowDirectory(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearWorkspaceId()
	{
		workspaceId_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ChangeShowDirectory);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ChangeShowDirectory other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Path != other.Path)
		{
			return false;
		}
		if (WorkspaceId != other.WorkspaceId)
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
		if (Path.Length != 0)
		{
			num ^= Path.GetHashCode();
		}
		if (HasWorkspaceId)
		{
			num ^= WorkspaceId.GetHashCode();
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
		if (Path.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(Path);
		}
		if (HasWorkspaceId)
		{
			output.WriteRawTag(18);
			output.WriteString(WorkspaceId);
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
		if (Path.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Path);
		}
		if (HasWorkspaceId)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(WorkspaceId);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ChangeShowDirectory other)
	{
		if (other != null)
		{
			if (other.Path.Length != 0)
			{
				Path = other.Path;
			}
			if (other.HasWorkspaceId)
			{
				WorkspaceId = other.WorkspaceId;
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
				Path = input.ReadString();
				break;
			case 18u:
				WorkspaceId = input.ReadString();
				break;
			}
		}
	}
}
