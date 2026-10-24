using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class UserWorkspaceTreeModification : IMessage<UserWorkspaceTreeModification>, IMessage, IEquatable<UserWorkspaceTreeModification>, IDeepCloneable<UserWorkspaceTreeModification>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Bucket
		{
			[OriginalName("OTHER")]
			Other,
			[OriginalName("LIBRARIES")]
			Libraries,
			[OriginalName("THEMES")]
			Themes,
			[OriginalName("PLAYLISTS")]
			Playlists,
			[OriginalName("PLAYLIST_TEMPLATES")]
			PlaylistTemplates,
			[OriginalName("CONFIGURATION")]
			Configuration,
			[OriginalName("MEDIA")]
			Media,
			[OriginalName("PRESETS")]
			Presets,
			[OriginalName("DOWNLOADS")]
			Downloads
		}

		public enum Operation
		{
			[OriginalName("MODIFIED")]
			Modified,
			[OriginalName("CREATED")]
			Created,
			[OriginalName("RENAMED")]
			Renamed,
			[OriginalName("REMOVED")]
			Removed
		}
	}

	private static readonly MessageParser<UserWorkspaceTreeModification> _parser = new MessageParser<UserWorkspaceTreeModification>(() => new UserWorkspaceTreeModification());

	private UnknownFieldSet _unknownFields;

	public const int BucketFieldNumber = 1;

	private Types.Bucket bucket_;

	public const int OperationFieldNumber = 2;

	private Types.Operation operation_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<UserWorkspaceTreeModification> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsTrackedEventsReflection.Descriptor.MessageTypes[40];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Bucket Bucket
	{
		get
		{
			return bucket_;
		}
		set
		{
			bucket_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Operation Operation
	{
		get
		{
			return operation_;
		}
		set
		{
			operation_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UserWorkspaceTreeModification()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UserWorkspaceTreeModification(UserWorkspaceTreeModification other)
		: this()
	{
		bucket_ = other.bucket_;
		operation_ = other.operation_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UserWorkspaceTreeModification Clone()
	{
		return new UserWorkspaceTreeModification(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as UserWorkspaceTreeModification);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(UserWorkspaceTreeModification other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Bucket != other.Bucket)
		{
			return false;
		}
		if (Operation != other.Operation)
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
		if (Bucket != 0)
		{
			num ^= Bucket.GetHashCode();
		}
		if (Operation != 0)
		{
			num ^= Operation.GetHashCode();
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
		if (Bucket != 0)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Bucket);
		}
		if (Operation != 0)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)Operation);
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
		if (Bucket != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Bucket);
		}
		if (Operation != 0)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Operation);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(UserWorkspaceTreeModification other)
	{
		if (other != null)
		{
			if (other.Bucket != 0)
			{
				Bucket = other.Bucket;
			}
			if (other.Operation != 0)
			{
				Operation = other.Operation;
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
				Bucket = (Types.Bucket)input.ReadEnum();
				break;
			case 16u:
				Operation = (Types.Operation)input.ReadEnum();
				break;
			}
		}
	}
}
