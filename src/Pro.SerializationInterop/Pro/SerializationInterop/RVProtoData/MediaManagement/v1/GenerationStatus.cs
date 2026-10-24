using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaManagement.v1;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class GenerationStatus : IMessage<GenerationStatus>, IMessage, IEquatable<GenerationStatus>, IDeepCloneable<GenerationStatus>
{
	public enum StatusOneofCase
	{
		None,
		Idle,
		Processing,
		Paused
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Idle : IMessage<Idle>, IMessage, IEquatable<Idle>, IDeepCloneable<Idle>
		{
			private static readonly MessageParser<Idle> _parser = new MessageParser<Idle>(() => new Idle());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Idle> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => GenerationStatus.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Idle()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Idle(Idle other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Idle Clone()
			{
				return new Idle(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Idle);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Idle other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				return object.Equals(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override int GetHashCode()
			{
				int num = 1;
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
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Idle other)
			{
				if (other != null)
				{
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
					_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Processing : IMessage<Processing>, IMessage, IEquatable<Processing>, IDeepCloneable<Processing>
		{
			private static readonly MessageParser<Processing> _parser = new MessageParser<Processing>(() => new Processing());

			private UnknownFieldSet _unknownFields;

			public const int CountFieldNumber = 1;

			private uint count_;

			public const int TotalFieldNumber = 2;

			private uint total_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Processing> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => GenerationStatus.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint Count
			{
				get
				{
					return count_;
				}
				set
				{
					count_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public uint Total
			{
				get
				{
					return total_;
				}
				set
				{
					total_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Processing()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Processing(Processing other)
				: this()
			{
				count_ = other.count_;
				total_ = other.total_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Processing Clone()
			{
				return new Processing(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Processing);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Processing other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Count != other.Count)
				{
					return false;
				}
				if (Total != other.Total)
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
				if (Count != 0)
				{
					num ^= Count.GetHashCode();
				}
				if (Total != 0)
				{
					num ^= Total.GetHashCode();
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
				if (Count != 0)
				{
					output.WriteRawTag(8);
					output.WriteUInt32(Count);
				}
				if (Total != 0)
				{
					output.WriteRawTag(16);
					output.WriteUInt32(Total);
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
				if (Count != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(Count);
				}
				if (Total != 0)
				{
					num += 1 + CodedOutputStream.ComputeUInt32Size(Total);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Processing other)
			{
				if (other != null)
				{
					if (other.Count != 0)
					{
						Count = other.Count;
					}
					if (other.Total != 0)
					{
						Total = other.Total;
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
						Count = input.ReadUInt32();
						break;
					case 16u:
						Total = input.ReadUInt32();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Paused : IMessage<Paused>, IMessage, IEquatable<Paused>, IDeepCloneable<Paused>
		{
			private static readonly MessageParser<Paused> _parser = new MessageParser<Paused>(() => new Paused());

			private UnknownFieldSet _unknownFields;

			public const int UntilTimeUtcFieldNumber = 1;

			private ulong untilTimeUtc_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Paused> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => GenerationStatus.Descriptor.NestedTypes[2];

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
			public Paused()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Paused(Paused other)
				: this()
			{
				untilTimeUtc_ = other.untilTimeUtc_;
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
						UntilTimeUtc = input.ReadUInt64();
					}
				}
			}
		}
	}

	private static readonly MessageParser<GenerationStatus> _parser = new MessageParser<GenerationStatus>(() => new GenerationStatus());

	private UnknownFieldSet _unknownFields;

	public const int IdleFieldNumber = 1;

	public const int ProcessingFieldNumber = 2;

	public const int PausedFieldNumber = 3;

	private object status_;

	private StatusOneofCase statusCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<GenerationStatus> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V1HelperCommonReflection.Descriptor.MessageTypes[6];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Idle Idle
	{
		get
		{
			if (statusCase_ != StatusOneofCase.Idle)
			{
				return null;
			}
			return (Types.Idle)status_;
		}
		set
		{
			status_ = value;
			statusCase_ = ((value != null) ? StatusOneofCase.Idle : StatusOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Processing Processing
	{
		get
		{
			if (statusCase_ != StatusOneofCase.Processing)
			{
				return null;
			}
			return (Types.Processing)status_;
		}
		set
		{
			status_ = value;
			statusCase_ = ((value != null) ? StatusOneofCase.Processing : StatusOneofCase.None);
		}
	}

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
	public GenerationStatus()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public GenerationStatus(GenerationStatus other)
		: this()
	{
		switch (other.StatusCase)
		{
		case StatusOneofCase.Idle:
			Idle = other.Idle.Clone();
			break;
		case StatusOneofCase.Processing:
			Processing = other.Processing.Clone();
			break;
		case StatusOneofCase.Paused:
			Paused = other.Paused.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public GenerationStatus Clone()
	{
		return new GenerationStatus(this);
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
		return Equals(other as GenerationStatus);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(GenerationStatus other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Idle, other.Idle))
		{
			return false;
		}
		if (!object.Equals(Processing, other.Processing))
		{
			return false;
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
		if (statusCase_ == StatusOneofCase.Idle)
		{
			num ^= Idle.GetHashCode();
		}
		if (statusCase_ == StatusOneofCase.Processing)
		{
			num ^= Processing.GetHashCode();
		}
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
		if (statusCase_ == StatusOneofCase.Idle)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Idle);
		}
		if (statusCase_ == StatusOneofCase.Processing)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Processing);
		}
		if (statusCase_ == StatusOneofCase.Paused)
		{
			output.WriteRawTag(26);
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
		if (statusCase_ == StatusOneofCase.Idle)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Idle);
		}
		if (statusCase_ == StatusOneofCase.Processing)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Processing);
		}
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
	public void MergeFrom(GenerationStatus other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.StatusCase)
		{
		case StatusOneofCase.Idle:
			if (Idle == null)
			{
				Idle = new Types.Idle();
			}
			Idle.MergeFrom(other.Idle);
			break;
		case StatusOneofCase.Processing:
			if (Processing == null)
			{
				Processing = new Types.Processing();
			}
			Processing.MergeFrom(other.Processing);
			break;
		case StatusOneofCase.Paused:
			if (Paused == null)
			{
				Paused = new Types.Paused();
			}
			Paused.MergeFrom(other.Paused);
			break;
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
			{
				Types.Idle idle = new Types.Idle();
				if (statusCase_ == StatusOneofCase.Idle)
				{
					idle.MergeFrom(Idle);
				}
				input.ReadMessage(idle);
				Idle = idle;
				break;
			}
			case 18u:
			{
				Types.Processing processing = new Types.Processing();
				if (statusCase_ == StatusOneofCase.Processing)
				{
					processing.MergeFrom(Processing);
				}
				input.ReadMessage(processing);
				Processing = processing;
				break;
			}
			case 26u:
			{
				Types.Paused paused = new Types.Paused();
				if (statusCase_ == StatusOneofCase.Paused)
				{
					paused.MergeFrom(Paused);
				}
				input.ReadMessage(paused);
				Paused = paused;
				break;
			}
			}
		}
	}
}
