using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Helper.Workspace.V2;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class SyncStatus : IMessage<SyncStatus>, IMessage, IEquatable<SyncStatus>, IDeepCloneable<SyncStatus>
{
	public enum StatusOneofCase
	{
		None,
		Paused
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Paused : IMessage<Paused>, IMessage, IEquatable<Paused>, IDeepCloneable<Paused>
		{
			private static readonly MessageParser<Paused> _parser = new MessageParser<Paused>(() => new Paused());

			private UnknownFieldSet _unknownFields;

			public const int UntilTimeUtcFieldNumber = 1;

			private ulong untilTimeUtc_;

			public const int AtTimeUtcFieldNumber = 2;

			private ulong atTimeUtc_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Paused> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => SyncStatus.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ulong UntilTimeUtc
			{
				get
				{
					return untilTimeUtc_;
				}
				set
				{
					untilTimeUtc_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ulong AtTimeUtc
			{
				get
				{
					return atTimeUtc_;
				}
				set
				{
					atTimeUtc_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Paused()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Paused(Paused other)
				: this()
			{
				untilTimeUtc_ = other.untilTimeUtc_;
				atTimeUtc_ = other.atTimeUtc_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Paused Clone()
			{
				return new Paused(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Paused);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Paused other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (UntilTimeUtc != other.UntilTimeUtc)
				{
					return false;
				}
				if (AtTimeUtc != other.AtTimeUtc)
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
				if (UntilTimeUtc != 0L)
				{
					num ^= UntilTimeUtc.GetHashCode();
				}
				if (AtTimeUtc != 0L)
				{
					num ^= AtTimeUtc.GetHashCode();
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
				if (UntilTimeUtc != 0L)
				{
					output.WriteRawTag(8);
					output.WriteUInt64(UntilTimeUtc);
				}
				if (AtTimeUtc != 0L)
				{
					output.WriteRawTag(16);
					output.WriteUInt64(AtTimeUtc);
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
				if (UntilTimeUtc != 0L)
				{
					num += 1 + CodedOutputStream.ComputeUInt64Size(UntilTimeUtc);
				}
				if (AtTimeUtc != 0L)
				{
					num += 1 + CodedOutputStream.ComputeUInt64Size(AtTimeUtc);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Paused other)
			{
				if (other != null)
				{
					if (other.UntilTimeUtc != 0L)
					{
						UntilTimeUtc = other.UntilTimeUtc;
					}
					if (other.AtTimeUtc != 0L)
					{
						AtTimeUtc = other.AtTimeUtc;
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
						UntilTimeUtc = input.ReadUInt64();
						break;
					case 16u:
						AtTimeUtc = input.ReadUInt64();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<SyncStatus> _parser = new MessageParser<SyncStatus>(() => new SyncStatus());

	private UnknownFieldSet _unknownFields;

	public const int PausedFieldNumber = 1;

	private object status_;

	private StatusOneofCase statusCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<SyncStatus> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V2HelperWorkspaceReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Paused Paused
	{
		get
		{
			if (statusCase_ != StatusOneofCase.Paused)
			{
				return null;
			}
			return (Types.Paused)status_;
		}
		set
		{
			status_ = value;
			statusCase_ = ((value != null) ? StatusOneofCase.Paused : StatusOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public StatusOneofCase StatusCase => statusCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SyncStatus()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SyncStatus(SyncStatus other)
		: this()
	{
		if (other.StatusCase == StatusOneofCase.Paused)
		{
			Paused = other.Paused.Clone();
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public SyncStatus Clone()
	{
		return new SyncStatus(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearStatus()
	{
		statusCase_ = StatusOneofCase.None;
		status_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as SyncStatus);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(SyncStatus other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Paused, other.Paused))
		{
			return false;
		}
		if (StatusCase != other.StatusCase)
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
		if (statusCase_ == StatusOneofCase.Paused)
		{
			num ^= Paused.GetHashCode();
		}
		num ^= (int)statusCase_;
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
		if (statusCase_ == StatusOneofCase.Paused)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Paused);
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
		if (statusCase_ == StatusOneofCase.Paused)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Paused);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(SyncStatus other)
	{
		if (other == null)
		{
			return;
		}
		if (other.StatusCase == StatusOneofCase.Paused)
		{
			if (Paused == null)
			{
				Paused = new Types.Paused();
			}
			Paused.MergeFrom(other.Paused);
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
			if (num != 10)
			{
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				continue;
			}
			Types.Paused paused = new Types.Paused();
			if (statusCase_ == StatusOneofCase.Paused)
			{
				paused.MergeFrom(Paused);
			}
			input.ReadMessage(paused);
			Paused = paused;
		}
	}
}
