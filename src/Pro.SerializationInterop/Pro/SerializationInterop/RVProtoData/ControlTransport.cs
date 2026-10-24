using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ControlTransport : IMessage<ControlTransport>, IMessage, IEquatable<ControlTransport>, IDeepCloneable<ControlTransport>
{
	public enum ControlTypeOneofCase
	{
		None,
		Play,
		Pause,
		Rewind,
		Fastforward,
		SkipBack,
		SkipForward,
		StepBack,
		StepForward,
		GoToStart,
		GoToEnd,
		JumpToTime,
		JumpToPercent,
		MarkIn,
		MarkOut,
		SetScaleMode,
		SetFlippedMode,
		SetPlayRate,
		SetRotation,
		TogglePlayback,
		SetEffects,
		UpdateEffect,
		BeginScrub,
		EndScrub,
		ScrubToTime,
		ScrubToPercent,
		SetAudioFade,
		SetAudioProperties,
		SetAlphaType
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PlayControlType : IMessage<PlayControlType>, IMessage, IEquatable<PlayControlType>, IDeepCloneable<PlayControlType>
		{
			private static readonly MessageParser<PlayControlType> _parser = new MessageParser<PlayControlType>(() => new PlayControlType());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PlayControlType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ControlTransport.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlayControlType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlayControlType(PlayControlType other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PlayControlType Clone()
			{
				return new PlayControlType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PlayControlType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PlayControlType other)
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
			public void MergeFrom(PlayControlType other)
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
		public sealed class PauseControlType : IMessage<PauseControlType>, IMessage, IEquatable<PauseControlType>, IDeepCloneable<PauseControlType>
		{
			private static readonly MessageParser<PauseControlType> _parser = new MessageParser<PauseControlType>(() => new PauseControlType());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PauseControlType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ControlTransport.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PauseControlType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PauseControlType(PauseControlType other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PauseControlType Clone()
			{
				return new PauseControlType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PauseControlType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PauseControlType other)
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
			public void MergeFrom(PauseControlType other)
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
		public sealed class RewindControlType : IMessage<RewindControlType>, IMessage, IEquatable<RewindControlType>, IDeepCloneable<RewindControlType>
		{
			private static readonly MessageParser<RewindControlType> _parser = new MessageParser<RewindControlType>(() => new RewindControlType());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<RewindControlType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ControlTransport.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RewindControlType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RewindControlType(RewindControlType other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RewindControlType Clone()
			{
				return new RewindControlType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as RewindControlType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(RewindControlType other)
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
			public void MergeFrom(RewindControlType other)
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
		public sealed class FastForwardControlType : IMessage<FastForwardControlType>, IMessage, IEquatable<FastForwardControlType>, IDeepCloneable<FastForwardControlType>
		{
			private static readonly MessageParser<FastForwardControlType> _parser = new MessageParser<FastForwardControlType>(() => new FastForwardControlType());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<FastForwardControlType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ControlTransport.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FastForwardControlType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FastForwardControlType(FastForwardControlType other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public FastForwardControlType Clone()
			{
				return new FastForwardControlType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as FastForwardControlType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(FastForwardControlType other)
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
			public void MergeFrom(FastForwardControlType other)
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
		public sealed class SkipBackControlType : IMessage<SkipBackControlType>, IMessage, IEquatable<SkipBackControlType>, IDeepCloneable<SkipBackControlType>
		{
			private static readonly MessageParser<SkipBackControlType> _parser = new MessageParser<SkipBackControlType>(() => new SkipBackControlType());

			private UnknownFieldSet _unknownFields;

			public const int OffsetFieldNumber = 1;

			private double offset_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SkipBackControlType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ControlTransport.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Offset
			{
				get
				{
					return offset_;
				}
				set
				{
					offset_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SkipBackControlType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SkipBackControlType(SkipBackControlType other)
				: this()
			{
				offset_ = other.offset_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SkipBackControlType Clone()
			{
				return new SkipBackControlType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as SkipBackControlType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(SkipBackControlType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Offset, other.Offset))
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
				if (Offset != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Offset);
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
				if (Offset != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(Offset);
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
				if (Offset != 0.0)
				{
					num += 9;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(SkipBackControlType other)
			{
				if (other != null)
				{
					if (other.Offset != 0.0)
					{
						Offset = other.Offset;
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
					if (num != 9)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Offset = input.ReadDouble();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class SkipForwardControlType : IMessage<SkipForwardControlType>, IMessage, IEquatable<SkipForwardControlType>, IDeepCloneable<SkipForwardControlType>
		{
			private static readonly MessageParser<SkipForwardControlType> _parser = new MessageParser<SkipForwardControlType>(() => new SkipForwardControlType());

			private UnknownFieldSet _unknownFields;

			public const int OffsetFieldNumber = 1;

			private double offset_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SkipForwardControlType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ControlTransport.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Offset
			{
				get
				{
					return offset_;
				}
				set
				{
					offset_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SkipForwardControlType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SkipForwardControlType(SkipForwardControlType other)
				: this()
			{
				offset_ = other.offset_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SkipForwardControlType Clone()
			{
				return new SkipForwardControlType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as SkipForwardControlType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(SkipForwardControlType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Offset, other.Offset))
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
				if (Offset != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Offset);
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
				if (Offset != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(Offset);
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
				if (Offset != 0.0)
				{
					num += 9;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(SkipForwardControlType other)
			{
				if (other != null)
				{
					if (other.Offset != 0.0)
					{
						Offset = other.Offset;
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
					if (num != 9)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Offset = input.ReadDouble();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class StepBackControlType : IMessage<StepBackControlType>, IMessage, IEquatable<StepBackControlType>, IDeepCloneable<StepBackControlType>
		{
			private static readonly MessageParser<StepBackControlType> _parser = new MessageParser<StepBackControlType>(() => new StepBackControlType());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<StepBackControlType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ControlTransport.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public StepBackControlType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public StepBackControlType(StepBackControlType other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public StepBackControlType Clone()
			{
				return new StepBackControlType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as StepBackControlType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(StepBackControlType other)
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
			public void MergeFrom(StepBackControlType other)
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
		public sealed class StepForwardControlType : IMessage<StepForwardControlType>, IMessage, IEquatable<StepForwardControlType>, IDeepCloneable<StepForwardControlType>
		{
			private static readonly MessageParser<StepForwardControlType> _parser = new MessageParser<StepForwardControlType>(() => new StepForwardControlType());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<StepForwardControlType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ControlTransport.Descriptor.NestedTypes[7];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public StepForwardControlType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public StepForwardControlType(StepForwardControlType other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public StepForwardControlType Clone()
			{
				return new StepForwardControlType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as StepForwardControlType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(StepForwardControlType other)
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
			public void MergeFrom(StepForwardControlType other)
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
		public sealed class GoToStartControlType : IMessage<GoToStartControlType>, IMessage, IEquatable<GoToStartControlType>, IDeepCloneable<GoToStartControlType>
		{
			private static readonly MessageParser<GoToStartControlType> _parser = new MessageParser<GoToStartControlType>(() => new GoToStartControlType());

			private UnknownFieldSet _unknownFields;

			public const int OffsetFieldNumber = 1;

			private double offset_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GoToStartControlType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ControlTransport.Descriptor.NestedTypes[8];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Offset
			{
				get
				{
					return offset_;
				}
				set
				{
					offset_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GoToStartControlType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GoToStartControlType(GoToStartControlType other)
				: this()
			{
				offset_ = other.offset_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GoToStartControlType Clone()
			{
				return new GoToStartControlType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GoToStartControlType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GoToStartControlType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Offset, other.Offset))
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
				if (Offset != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Offset);
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
				if (Offset != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(Offset);
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
				if (Offset != 0.0)
				{
					num += 9;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GoToStartControlType other)
			{
				if (other != null)
				{
					if (other.Offset != 0.0)
					{
						Offset = other.Offset;
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
					if (num != 9)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Offset = input.ReadDouble();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GoToEndControlType : IMessage<GoToEndControlType>, IMessage, IEquatable<GoToEndControlType>, IDeepCloneable<GoToEndControlType>
		{
			private static readonly MessageParser<GoToEndControlType> _parser = new MessageParser<GoToEndControlType>(() => new GoToEndControlType());

			private UnknownFieldSet _unknownFields;

			public const int OffsetFieldNumber = 1;

			private double offset_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GoToEndControlType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ControlTransport.Descriptor.NestedTypes[9];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Offset
			{
				get
				{
					return offset_;
				}
				set
				{
					offset_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GoToEndControlType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GoToEndControlType(GoToEndControlType other)
				: this()
			{
				offset_ = other.offset_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GoToEndControlType Clone()
			{
				return new GoToEndControlType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GoToEndControlType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GoToEndControlType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Offset, other.Offset))
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
				if (Offset != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Offset);
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
				if (Offset != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(Offset);
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
				if (Offset != 0.0)
				{
					num += 9;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GoToEndControlType other)
			{
				if (other != null)
				{
					if (other.Offset != 0.0)
					{
						Offset = other.Offset;
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
					if (num != 9)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Offset = input.ReadDouble();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class JumpToTimeControlType : IMessage<JumpToTimeControlType>, IMessage, IEquatable<JumpToTimeControlType>, IDeepCloneable<JumpToTimeControlType>
		{
			private static readonly MessageParser<JumpToTimeControlType> _parser = new MessageParser<JumpToTimeControlType>(() => new JumpToTimeControlType());

			private UnknownFieldSet _unknownFields;

			public const int TimeFieldNumber = 1;

			private double time_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<JumpToTimeControlType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ControlTransport.Descriptor.NestedTypes[10];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Time
			{
				get
				{
					return time_;
				}
				set
				{
					time_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public JumpToTimeControlType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public JumpToTimeControlType(JumpToTimeControlType other)
				: this()
			{
				time_ = other.time_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public JumpToTimeControlType Clone()
			{
				return new JumpToTimeControlType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as JumpToTimeControlType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(JumpToTimeControlType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Time, other.Time))
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
				if (Time != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Time);
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
				if (Time != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(Time);
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
				if (Time != 0.0)
				{
					num += 9;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(JumpToTimeControlType other)
			{
				if (other != null)
				{
					if (other.Time != 0.0)
					{
						Time = other.Time;
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
					if (num != 9)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Time = input.ReadDouble();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class JumpToPercentControlType : IMessage<JumpToPercentControlType>, IMessage, IEquatable<JumpToPercentControlType>, IDeepCloneable<JumpToPercentControlType>
		{
			private static readonly MessageParser<JumpToPercentControlType> _parser = new MessageParser<JumpToPercentControlType>(() => new JumpToPercentControlType());

			private UnknownFieldSet _unknownFields;

			public const int PercentFieldNumber = 1;

			private double percent_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<JumpToPercentControlType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ControlTransport.Descriptor.NestedTypes[11];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Percent
			{
				get
				{
					return percent_;
				}
				set
				{
					percent_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public JumpToPercentControlType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public JumpToPercentControlType(JumpToPercentControlType other)
				: this()
			{
				percent_ = other.percent_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public JumpToPercentControlType Clone()
			{
				return new JumpToPercentControlType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as JumpToPercentControlType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(JumpToPercentControlType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Percent, other.Percent))
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
				if (Percent != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Percent);
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
				if (Percent != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(Percent);
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
				if (Percent != 0.0)
				{
					num += 9;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(JumpToPercentControlType other)
			{
				if (other != null)
				{
					if (other.Percent != 0.0)
					{
						Percent = other.Percent;
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
					if (num != 9)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Percent = input.ReadDouble();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class MarkInPointControlType : IMessage<MarkInPointControlType>, IMessage, IEquatable<MarkInPointControlType>, IDeepCloneable<MarkInPointControlType>
		{
			private static readonly MessageParser<MarkInPointControlType> _parser = new MessageParser<MarkInPointControlType>(() => new MarkInPointControlType());

			private UnknownFieldSet _unknownFields;

			public const int TimeFieldNumber = 1;

			private double time_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<MarkInPointControlType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ControlTransport.Descriptor.NestedTypes[12];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Time
			{
				get
				{
					return time_;
				}
				set
				{
					time_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MarkInPointControlType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MarkInPointControlType(MarkInPointControlType other)
				: this()
			{
				time_ = other.time_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MarkInPointControlType Clone()
			{
				return new MarkInPointControlType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as MarkInPointControlType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(MarkInPointControlType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Time, other.Time))
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
				if (Time != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Time);
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
				if (Time != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(Time);
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
				if (Time != 0.0)
				{
					num += 9;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(MarkInPointControlType other)
			{
				if (other != null)
				{
					if (other.Time != 0.0)
					{
						Time = other.Time;
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
					if (num != 9)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Time = input.ReadDouble();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class MarkOutPointControlType : IMessage<MarkOutPointControlType>, IMessage, IEquatable<MarkOutPointControlType>, IDeepCloneable<MarkOutPointControlType>
		{
			private static readonly MessageParser<MarkOutPointControlType> _parser = new MessageParser<MarkOutPointControlType>(() => new MarkOutPointControlType());

			private UnknownFieldSet _unknownFields;

			public const int TimeFieldNumber = 1;

			private double time_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<MarkOutPointControlType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ControlTransport.Descriptor.NestedTypes[13];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Time
			{
				get
				{
					return time_;
				}
				set
				{
					time_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MarkOutPointControlType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MarkOutPointControlType(MarkOutPointControlType other)
				: this()
			{
				time_ = other.time_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MarkOutPointControlType Clone()
			{
				return new MarkOutPointControlType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as MarkOutPointControlType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(MarkOutPointControlType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Time, other.Time))
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
				if (Time != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Time);
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
				if (Time != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(Time);
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
				if (Time != 0.0)
				{
					num += 9;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(MarkOutPointControlType other)
			{
				if (other != null)
				{
					if (other.Time != 0.0)
					{
						Time = other.Time;
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
					if (num != 9)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Time = input.ReadDouble();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class SetScaleModeControlType : IMessage<SetScaleModeControlType>, IMessage, IEquatable<SetScaleModeControlType>, IDeepCloneable<SetScaleModeControlType>
		{
			private static readonly MessageParser<SetScaleModeControlType> _parser = new MessageParser<SetScaleModeControlType>(() => new SetScaleModeControlType());

			private UnknownFieldSet _unknownFields;

			public const int ModeFieldNumber = 1;

			private Media.Types.ScaleBehavior mode_;

			public const int IsBlurredFieldNumber = 3;

			private bool isBlurred_;

			public const int AlignmentFieldNumber = 2;

			private Media.Types.ScaleAlignment alignment_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SetScaleModeControlType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ControlTransport.Descriptor.NestedTypes[14];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Media.Types.ScaleBehavior Mode
			{
				get
				{
					return mode_;
				}
				set
				{
					mode_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool IsBlurred
			{
				get
				{
					return isBlurred_;
				}
				set
				{
					isBlurred_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Media.Types.ScaleAlignment Alignment
			{
				get
				{
					return alignment_;
				}
				set
				{
					alignment_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetScaleModeControlType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetScaleModeControlType(SetScaleModeControlType other)
				: this()
			{
				mode_ = other.mode_;
				isBlurred_ = other.isBlurred_;
				alignment_ = other.alignment_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetScaleModeControlType Clone()
			{
				return new SetScaleModeControlType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as SetScaleModeControlType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(SetScaleModeControlType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Mode != other.Mode)
				{
					return false;
				}
				if (IsBlurred != other.IsBlurred)
				{
					return false;
				}
				if (Alignment != other.Alignment)
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
				if (Mode != 0)
				{
					num ^= Mode.GetHashCode();
				}
				if (IsBlurred)
				{
					num ^= IsBlurred.GetHashCode();
				}
				if (Alignment != 0)
				{
					num ^= Alignment.GetHashCode();
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
				if (Mode != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Mode);
				}
				if (Alignment != 0)
				{
					output.WriteRawTag(16);
					output.WriteEnum((int)Alignment);
				}
				if (IsBlurred)
				{
					output.WriteRawTag(24);
					output.WriteBool(IsBlurred);
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
				if (Mode != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Mode);
				}
				if (IsBlurred)
				{
					num += 2;
				}
				if (Alignment != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Alignment);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(SetScaleModeControlType other)
			{
				if (other != null)
				{
					if (other.Mode != 0)
					{
						Mode = other.Mode;
					}
					if (other.IsBlurred)
					{
						IsBlurred = other.IsBlurred;
					}
					if (other.Alignment != 0)
					{
						Alignment = other.Alignment;
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
						Mode = (Media.Types.ScaleBehavior)input.ReadEnum();
						break;
					case 16u:
						Alignment = (Media.Types.ScaleAlignment)input.ReadEnum();
						break;
					case 24u:
						IsBlurred = input.ReadBool();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class SetFlippedModeControlType : IMessage<SetFlippedModeControlType>, IMessage, IEquatable<SetFlippedModeControlType>, IDeepCloneable<SetFlippedModeControlType>
		{
			private static readonly MessageParser<SetFlippedModeControlType> _parser = new MessageParser<SetFlippedModeControlType>(() => new SetFlippedModeControlType());

			private UnknownFieldSet _unknownFields;

			public const int HorizontalFieldNumber = 1;

			private bool horizontal_;

			public const int VerticalFieldNumber = 2;

			private bool vertical_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SetFlippedModeControlType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ControlTransport.Descriptor.NestedTypes[15];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Horizontal
			{
				get
				{
					return horizontal_;
				}
				set
				{
					horizontal_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Vertical
			{
				get
				{
					return vertical_;
				}
				set
				{
					vertical_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetFlippedModeControlType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetFlippedModeControlType(SetFlippedModeControlType other)
				: this()
			{
				horizontal_ = other.horizontal_;
				vertical_ = other.vertical_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetFlippedModeControlType Clone()
			{
				return new SetFlippedModeControlType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as SetFlippedModeControlType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(SetFlippedModeControlType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Horizontal != other.Horizontal)
				{
					return false;
				}
				if (Vertical != other.Vertical)
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
				if (Horizontal)
				{
					num ^= Horizontal.GetHashCode();
				}
				if (Vertical)
				{
					num ^= Vertical.GetHashCode();
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
				if (Horizontal)
				{
					output.WriteRawTag(8);
					output.WriteBool(Horizontal);
				}
				if (Vertical)
				{
					output.WriteRawTag(16);
					output.WriteBool(Vertical);
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
				if (Horizontal)
				{
					num += 2;
				}
				if (Vertical)
				{
					num += 2;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(SetFlippedModeControlType other)
			{
				if (other != null)
				{
					if (other.Horizontal)
					{
						Horizontal = other.Horizontal;
					}
					if (other.Vertical)
					{
						Vertical = other.Vertical;
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
						Horizontal = input.ReadBool();
						break;
					case 16u:
						Vertical = input.ReadBool();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class SetPlayRateControlType : IMessage<SetPlayRateControlType>, IMessage, IEquatable<SetPlayRateControlType>, IDeepCloneable<SetPlayRateControlType>
		{
			private static readonly MessageParser<SetPlayRateControlType> _parser = new MessageParser<SetPlayRateControlType>(() => new SetPlayRateControlType());

			private UnknownFieldSet _unknownFields;

			public const int PlayRateFieldNumber = 1;

			private double playRate_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SetPlayRateControlType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ControlTransport.Descriptor.NestedTypes[16];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double PlayRate
			{
				get
				{
					return playRate_;
				}
				set
				{
					playRate_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetPlayRateControlType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetPlayRateControlType(SetPlayRateControlType other)
				: this()
			{
				playRate_ = other.playRate_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetPlayRateControlType Clone()
			{
				return new SetPlayRateControlType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as SetPlayRateControlType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(SetPlayRateControlType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(PlayRate, other.PlayRate))
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
				if (PlayRate != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(PlayRate);
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
				if (PlayRate != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(PlayRate);
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
				if (PlayRate != 0.0)
				{
					num += 9;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(SetPlayRateControlType other)
			{
				if (other != null)
				{
					if (other.PlayRate != 0.0)
					{
						PlayRate = other.PlayRate;
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
					if (num != 9)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						PlayRate = input.ReadDouble();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class SetNativeRotationControlType : IMessage<SetNativeRotationControlType>, IMessage, IEquatable<SetNativeRotationControlType>, IDeepCloneable<SetNativeRotationControlType>
		{
			private static readonly MessageParser<SetNativeRotationControlType> _parser = new MessageParser<SetNativeRotationControlType>(() => new SetNativeRotationControlType());

			private UnknownFieldSet _unknownFields;

			public const int RotationFieldNumber = 1;

			private Media.Types.DrawingProperties.Types.NativeRotationType rotation_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SetNativeRotationControlType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ControlTransport.Descriptor.NestedTypes[17];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Media.Types.DrawingProperties.Types.NativeRotationType Rotation
			{
				get
				{
					return rotation_;
				}
				set
				{
					rotation_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetNativeRotationControlType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetNativeRotationControlType(SetNativeRotationControlType other)
				: this()
			{
				rotation_ = other.rotation_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetNativeRotationControlType Clone()
			{
				return new SetNativeRotationControlType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as SetNativeRotationControlType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(SetNativeRotationControlType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Rotation != other.Rotation)
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
				if (Rotation != 0)
				{
					num ^= Rotation.GetHashCode();
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
				if (Rotation != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Rotation);
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
				if (Rotation != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Rotation);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(SetNativeRotationControlType other)
			{
				if (other != null)
				{
					if (other.Rotation != 0)
					{
						Rotation = other.Rotation;
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
						Rotation = (Media.Types.DrawingProperties.Types.NativeRotationType)input.ReadEnum();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class SetAlphaTypeControlType : IMessage<SetAlphaTypeControlType>, IMessage, IEquatable<SetAlphaTypeControlType>, IDeepCloneable<SetAlphaTypeControlType>
		{
			private static readonly MessageParser<SetAlphaTypeControlType> _parser = new MessageParser<SetAlphaTypeControlType>(() => new SetAlphaTypeControlType());

			private UnknownFieldSet _unknownFields;

			public const int AlphaTypeFieldNumber = 1;

			private AlphaType alphaType_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SetAlphaTypeControlType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ControlTransport.Descriptor.NestedTypes[18];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AlphaType AlphaType
			{
				get
				{
					return alphaType_;
				}
				set
				{
					alphaType_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetAlphaTypeControlType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetAlphaTypeControlType(SetAlphaTypeControlType other)
				: this()
			{
				alphaType_ = other.alphaType_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetAlphaTypeControlType Clone()
			{
				return new SetAlphaTypeControlType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as SetAlphaTypeControlType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(SetAlphaTypeControlType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (AlphaType != other.AlphaType)
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
				if (AlphaType != 0)
				{
					num ^= AlphaType.GetHashCode();
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
				if (AlphaType != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)AlphaType);
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
				if (AlphaType != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)AlphaType);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(SetAlphaTypeControlType other)
			{
				if (other != null)
				{
					if (other.AlphaType != 0)
					{
						AlphaType = other.AlphaType;
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
						AlphaType = (AlphaType)input.ReadEnum();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class TogglePlaybackControlType : IMessage<TogglePlaybackControlType>, IMessage, IEquatable<TogglePlaybackControlType>, IDeepCloneable<TogglePlaybackControlType>
		{
			private static readonly MessageParser<TogglePlaybackControlType> _parser = new MessageParser<TogglePlaybackControlType>(() => new TogglePlaybackControlType());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TogglePlaybackControlType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ControlTransport.Descriptor.NestedTypes[19];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TogglePlaybackControlType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TogglePlaybackControlType(TogglePlaybackControlType other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TogglePlaybackControlType Clone()
			{
				return new TogglePlaybackControlType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TogglePlaybackControlType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TogglePlaybackControlType other)
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
			public void MergeFrom(TogglePlaybackControlType other)
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
		public sealed class SetEffectsControlType : IMessage<SetEffectsControlType>, IMessage, IEquatable<SetEffectsControlType>, IDeepCloneable<SetEffectsControlType>
		{
			private static readonly MessageParser<SetEffectsControlType> _parser = new MessageParser<SetEffectsControlType>(() => new SetEffectsControlType());

			private UnknownFieldSet _unknownFields;

			public const int EffectsFieldNumber = 1;

			private static readonly FieldCodec<Effect> _repeated_effects_codec = FieldCodec.ForMessage(10u, Effect.Parser);

			private readonly RepeatedField<Effect> effects_ = new RepeatedField<Effect>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SetEffectsControlType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ControlTransport.Descriptor.NestedTypes[20];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<Effect> Effects => effects_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetEffectsControlType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetEffectsControlType(SetEffectsControlType other)
				: this()
			{
				effects_ = other.effects_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetEffectsControlType Clone()
			{
				return new SetEffectsControlType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as SetEffectsControlType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(SetEffectsControlType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!effects_.Equals(other.effects_))
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
				num ^= effects_.GetHashCode();
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
				effects_.WriteTo(output, _repeated_effects_codec);
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
				num += effects_.CalculateSize(_repeated_effects_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(SetEffectsControlType other)
			{
				if (other != null)
				{
					effects_.Add(other.effects_);
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
					if (num != 10)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						effects_.AddEntriesFrom(input, _repeated_effects_codec);
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class UpdateEffectControlType : IMessage<UpdateEffectControlType>, IMessage, IEquatable<UpdateEffectControlType>, IDeepCloneable<UpdateEffectControlType>
		{
			private static readonly MessageParser<UpdateEffectControlType> _parser = new MessageParser<UpdateEffectControlType>(() => new UpdateEffectControlType());

			private UnknownFieldSet _unknownFields;

			public const int EffectFieldNumber = 1;

			private Effect effect_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<UpdateEffectControlType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ControlTransport.Descriptor.NestedTypes[21];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Effect Effect
			{
				get
				{
					return effect_;
				}
				set
				{
					effect_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UpdateEffectControlType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UpdateEffectControlType(UpdateEffectControlType other)
				: this()
			{
				effect_ = ((other.effect_ != null) ? other.effect_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UpdateEffectControlType Clone()
			{
				return new UpdateEffectControlType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as UpdateEffectControlType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(UpdateEffectControlType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Effect, other.Effect))
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
				if (effect_ != null)
				{
					num ^= Effect.GetHashCode();
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
				if (effect_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Effect);
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
				if (effect_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Effect);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(UpdateEffectControlType other)
			{
				if (other == null)
				{
					return;
				}
				if (other.effect_ != null)
				{
					if (effect_ == null)
					{
						Effect = new Effect();
					}
					Effect.MergeFrom(other.Effect);
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
					if (effect_ == null)
					{
						Effect = new Effect();
					}
					input.ReadMessage(Effect);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class BeginScrubControlType : IMessage<BeginScrubControlType>, IMessage, IEquatable<BeginScrubControlType>, IDeepCloneable<BeginScrubControlType>
		{
			private static readonly MessageParser<BeginScrubControlType> _parser = new MessageParser<BeginScrubControlType>(() => new BeginScrubControlType());

			private UnknownFieldSet _unknownFields;

			public const int TimeFieldNumber = 1;

			private double time_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<BeginScrubControlType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ControlTransport.Descriptor.NestedTypes[22];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Time
			{
				get
				{
					return time_;
				}
				set
				{
					time_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BeginScrubControlType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BeginScrubControlType(BeginScrubControlType other)
				: this()
			{
				time_ = other.time_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public BeginScrubControlType Clone()
			{
				return new BeginScrubControlType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as BeginScrubControlType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(BeginScrubControlType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Time, other.Time))
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
				if (Time != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Time);
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
				if (Time != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(Time);
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
				if (Time != 0.0)
				{
					num += 9;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(BeginScrubControlType other)
			{
				if (other != null)
				{
					if (other.Time != 0.0)
					{
						Time = other.Time;
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
					if (num != 9)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Time = input.ReadDouble();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class EndScrubControlType : IMessage<EndScrubControlType>, IMessage, IEquatable<EndScrubControlType>, IDeepCloneable<EndScrubControlType>
		{
			private static readonly MessageParser<EndScrubControlType> _parser = new MessageParser<EndScrubControlType>(() => new EndScrubControlType());

			private UnknownFieldSet _unknownFields;

			public const int TimeFieldNumber = 1;

			private double time_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<EndScrubControlType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ControlTransport.Descriptor.NestedTypes[23];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Time
			{
				get
				{
					return time_;
				}
				set
				{
					time_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EndScrubControlType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EndScrubControlType(EndScrubControlType other)
				: this()
			{
				time_ = other.time_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public EndScrubControlType Clone()
			{
				return new EndScrubControlType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as EndScrubControlType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(EndScrubControlType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Time, other.Time))
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
				if (Time != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Time);
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
				if (Time != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(Time);
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
				if (Time != 0.0)
				{
					num += 9;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(EndScrubControlType other)
			{
				if (other != null)
				{
					if (other.Time != 0.0)
					{
						Time = other.Time;
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
					if (num != 9)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Time = input.ReadDouble();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ScrubToTimeControlType : IMessage<ScrubToTimeControlType>, IMessage, IEquatable<ScrubToTimeControlType>, IDeepCloneable<ScrubToTimeControlType>
		{
			private static readonly MessageParser<ScrubToTimeControlType> _parser = new MessageParser<ScrubToTimeControlType>(() => new ScrubToTimeControlType());

			private UnknownFieldSet _unknownFields;

			public const int TimeFieldNumber = 1;

			private double time_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ScrubToTimeControlType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ControlTransport.Descriptor.NestedTypes[24];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Time
			{
				get
				{
					return time_;
				}
				set
				{
					time_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ScrubToTimeControlType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ScrubToTimeControlType(ScrubToTimeControlType other)
				: this()
			{
				time_ = other.time_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ScrubToTimeControlType Clone()
			{
				return new ScrubToTimeControlType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ScrubToTimeControlType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ScrubToTimeControlType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Time, other.Time))
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
				if (Time != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Time);
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
				if (Time != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(Time);
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
				if (Time != 0.0)
				{
					num += 9;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(ScrubToTimeControlType other)
			{
				if (other != null)
				{
					if (other.Time != 0.0)
					{
						Time = other.Time;
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
					if (num != 9)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Time = input.ReadDouble();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ScrubToPercentControlType : IMessage<ScrubToPercentControlType>, IMessage, IEquatable<ScrubToPercentControlType>, IDeepCloneable<ScrubToPercentControlType>
		{
			private static readonly MessageParser<ScrubToPercentControlType> _parser = new MessageParser<ScrubToPercentControlType>(() => new ScrubToPercentControlType());

			private UnknownFieldSet _unknownFields;

			public const int PercentFieldNumber = 1;

			private double percent_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ScrubToPercentControlType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ControlTransport.Descriptor.NestedTypes[25];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Percent
			{
				get
				{
					return percent_;
				}
				set
				{
					percent_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ScrubToPercentControlType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ScrubToPercentControlType(ScrubToPercentControlType other)
				: this()
			{
				percent_ = other.percent_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ScrubToPercentControlType Clone()
			{
				return new ScrubToPercentControlType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ScrubToPercentControlType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ScrubToPercentControlType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Percent, other.Percent))
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
				if (Percent != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Percent);
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
				if (Percent != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(Percent);
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
				if (Percent != 0.0)
				{
					num += 9;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(ScrubToPercentControlType other)
			{
				if (other != null)
				{
					if (other.Percent != 0.0)
					{
						Percent = other.Percent;
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
					if (num != 9)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Percent = input.ReadDouble();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class SetAudioFadeType : IMessage<SetAudioFadeType>, IMessage, IEquatable<SetAudioFadeType>, IDeepCloneable<SetAudioFadeType>
		{
			private static readonly MessageParser<SetAudioFadeType> _parser = new MessageParser<SetAudioFadeType>(() => new SetAudioFadeType());

			private UnknownFieldSet _unknownFields;

			public const int FadeInDurationFieldNumber = 1;

			private double fadeInDuration_;

			public const int FadeOutDurationFieldNumber = 2;

			private double fadeOutDuration_;

			public const int ShouldFadeInFieldNumber = 3;

			private bool shouldFadeIn_;

			public const int ShouldFadeOutFieldNumber = 4;

			private bool shouldFadeOut_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SetAudioFadeType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ControlTransport.Descriptor.NestedTypes[26];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double FadeInDuration
			{
				get
				{
					return fadeInDuration_;
				}
				set
				{
					fadeInDuration_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double FadeOutDuration
			{
				get
				{
					return fadeOutDuration_;
				}
				set
				{
					fadeOutDuration_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool ShouldFadeIn
			{
				get
				{
					return shouldFadeIn_;
				}
				set
				{
					shouldFadeIn_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool ShouldFadeOut
			{
				get
				{
					return shouldFadeOut_;
				}
				set
				{
					shouldFadeOut_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetAudioFadeType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetAudioFadeType(SetAudioFadeType other)
				: this()
			{
				fadeInDuration_ = other.fadeInDuration_;
				fadeOutDuration_ = other.fadeOutDuration_;
				shouldFadeIn_ = other.shouldFadeIn_;
				shouldFadeOut_ = other.shouldFadeOut_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetAudioFadeType Clone()
			{
				return new SetAudioFadeType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as SetAudioFadeType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(SetAudioFadeType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(FadeInDuration, other.FadeInDuration))
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(FadeOutDuration, other.FadeOutDuration))
				{
					return false;
				}
				if (ShouldFadeIn != other.ShouldFadeIn)
				{
					return false;
				}
				if (ShouldFadeOut != other.ShouldFadeOut)
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
				if (FadeInDuration != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(FadeInDuration);
				}
				if (FadeOutDuration != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(FadeOutDuration);
				}
				if (ShouldFadeIn)
				{
					num ^= ShouldFadeIn.GetHashCode();
				}
				if (ShouldFadeOut)
				{
					num ^= ShouldFadeOut.GetHashCode();
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
				if (FadeInDuration != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(FadeInDuration);
				}
				if (FadeOutDuration != 0.0)
				{
					output.WriteRawTag(17);
					output.WriteDouble(FadeOutDuration);
				}
				if (ShouldFadeIn)
				{
					output.WriteRawTag(24);
					output.WriteBool(ShouldFadeIn);
				}
				if (ShouldFadeOut)
				{
					output.WriteRawTag(32);
					output.WriteBool(ShouldFadeOut);
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
				if (FadeInDuration != 0.0)
				{
					num += 9;
				}
				if (FadeOutDuration != 0.0)
				{
					num += 9;
				}
				if (ShouldFadeIn)
				{
					num += 2;
				}
				if (ShouldFadeOut)
				{
					num += 2;
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(SetAudioFadeType other)
			{
				if (other != null)
				{
					if (other.FadeInDuration != 0.0)
					{
						FadeInDuration = other.FadeInDuration;
					}
					if (other.FadeOutDuration != 0.0)
					{
						FadeOutDuration = other.FadeOutDuration;
					}
					if (other.ShouldFadeIn)
					{
						ShouldFadeIn = other.ShouldFadeIn;
					}
					if (other.ShouldFadeOut)
					{
						ShouldFadeOut = other.ShouldFadeOut;
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
					case 9u:
						FadeInDuration = input.ReadDouble();
						break;
					case 17u:
						FadeOutDuration = input.ReadDouble();
						break;
					case 24u:
						ShouldFadeIn = input.ReadBool();
						break;
					case 32u:
						ShouldFadeOut = input.ReadBool();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class SetAudioPropertiesType : IMessage<SetAudioPropertiesType>, IMessage, IEquatable<SetAudioPropertiesType>, IDeepCloneable<SetAudioPropertiesType>
		{
			private static readonly MessageParser<SetAudioPropertiesType> _parser = new MessageParser<SetAudioPropertiesType>(() => new SetAudioPropertiesType());

			private UnknownFieldSet _unknownFields;

			public const int AudioPropertiesFieldNumber = 1;

			private Media.Types.AudioProperties audioProperties_;

			public const int SoloFieldNumber = 2;

			private static readonly FieldCodec<bool> _repeated_solo_codec = FieldCodec.ForBool(18u);

			private readonly RepeatedField<bool> solo_ = new RepeatedField<bool>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SetAudioPropertiesType> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ControlTransport.Descriptor.NestedTypes[27];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Media.Types.AudioProperties AudioProperties
			{
				get
				{
					return audioProperties_;
				}
				set
				{
					audioProperties_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<bool> Solo => solo_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetAudioPropertiesType()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetAudioPropertiesType(SetAudioPropertiesType other)
				: this()
			{
				audioProperties_ = ((other.audioProperties_ != null) ? other.audioProperties_.Clone() : null);
				solo_ = other.solo_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetAudioPropertiesType Clone()
			{
				return new SetAudioPropertiesType(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as SetAudioPropertiesType);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(SetAudioPropertiesType other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(AudioProperties, other.AudioProperties))
				{
					return false;
				}
				if (!solo_.Equals(other.solo_))
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
				if (audioProperties_ != null)
				{
					num ^= AudioProperties.GetHashCode();
				}
				num ^= solo_.GetHashCode();
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
				if (audioProperties_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(AudioProperties);
				}
				solo_.WriteTo(output, _repeated_solo_codec);
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
				if (audioProperties_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(AudioProperties);
				}
				num += solo_.CalculateSize(_repeated_solo_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(SetAudioPropertiesType other)
			{
				if (other == null)
				{
					return;
				}
				if (other.audioProperties_ != null)
				{
					if (audioProperties_ == null)
					{
						AudioProperties = new Media.Types.AudioProperties();
					}
					AudioProperties.MergeFrom(other.AudioProperties);
				}
				solo_.Add(other.solo_);
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
						if (audioProperties_ == null)
						{
							AudioProperties = new Media.Types.AudioProperties();
						}
						input.ReadMessage(AudioProperties);
						break;
					case 16u:
					case 18u:
						solo_.AddEntriesFrom(input, _repeated_solo_codec);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<ControlTransport> _parser = new MessageParser<ControlTransport>(() => new ControlTransport());

	private UnknownFieldSet _unknownFields;

	public const int PlayFieldNumber = 1;

	public const int PauseFieldNumber = 2;

	public const int RewindFieldNumber = 3;

	public const int FastforwardFieldNumber = 4;

	public const int SkipBackFieldNumber = 5;

	public const int SkipForwardFieldNumber = 6;

	public const int StepBackFieldNumber = 7;

	public const int StepForwardFieldNumber = 8;

	public const int GoToStartFieldNumber = 9;

	public const int GoToEndFieldNumber = 10;

	public const int JumpToTimeFieldNumber = 11;

	public const int JumpToPercentFieldNumber = 12;

	public const int MarkInFieldNumber = 13;

	public const int MarkOutFieldNumber = 14;

	public const int SetScaleModeFieldNumber = 15;

	public const int SetFlippedModeFieldNumber = 16;

	public const int SetPlayRateFieldNumber = 17;

	public const int SetRotationFieldNumber = 18;

	public const int TogglePlaybackFieldNumber = 19;

	public const int SetEffectsFieldNumber = 20;

	public const int UpdateEffectFieldNumber = 21;

	public const int BeginScrubFieldNumber = 22;

	public const int EndScrubFieldNumber = 23;

	public const int ScrubToTimeFieldNumber = 24;

	public const int ScrubToPercentFieldNumber = 25;

	public const int SetAudioFadeFieldNumber = 26;

	public const int SetAudioPropertiesFieldNumber = 27;

	public const int SetAlphaTypeFieldNumber = 28;

	private object controlType_;

	private ControlTypeOneofCase controlTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ControlTransport> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PlayControlType Play
	{
		get
		{
			if (controlTypeCase_ != ControlTypeOneofCase.Play)
			{
				return null;
			}
			return (Types.PlayControlType)controlType_;
		}
		set
		{
			controlType_ = value;
			controlTypeCase_ = ((value != null) ? ControlTypeOneofCase.Play : ControlTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PauseControlType Pause
	{
		get
		{
			if (controlTypeCase_ != ControlTypeOneofCase.Pause)
			{
				return null;
			}
			return (Types.PauseControlType)controlType_;
		}
		set
		{
			controlType_ = value;
			controlTypeCase_ = ((value != null) ? ControlTypeOneofCase.Pause : ControlTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.RewindControlType Rewind
	{
		get
		{
			if (controlTypeCase_ != ControlTypeOneofCase.Rewind)
			{
				return null;
			}
			return (Types.RewindControlType)controlType_;
		}
		set
		{
			controlType_ = value;
			controlTypeCase_ = ((value != null) ? ControlTypeOneofCase.Rewind : ControlTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.FastForwardControlType Fastforward
	{
		get
		{
			if (controlTypeCase_ != ControlTypeOneofCase.Fastforward)
			{
				return null;
			}
			return (Types.FastForwardControlType)controlType_;
		}
		set
		{
			controlType_ = value;
			controlTypeCase_ = ((value != null) ? ControlTypeOneofCase.Fastforward : ControlTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SkipBackControlType SkipBack
	{
		get
		{
			if (controlTypeCase_ != ControlTypeOneofCase.SkipBack)
			{
				return null;
			}
			return (Types.SkipBackControlType)controlType_;
		}
		set
		{
			controlType_ = value;
			controlTypeCase_ = ((value != null) ? ControlTypeOneofCase.SkipBack : ControlTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SkipForwardControlType SkipForward
	{
		get
		{
			if (controlTypeCase_ != ControlTypeOneofCase.SkipForward)
			{
				return null;
			}
			return (Types.SkipForwardControlType)controlType_;
		}
		set
		{
			controlType_ = value;
			controlTypeCase_ = ((value != null) ? ControlTypeOneofCase.SkipForward : ControlTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.StepBackControlType StepBack
	{
		get
		{
			if (controlTypeCase_ != ControlTypeOneofCase.StepBack)
			{
				return null;
			}
			return (Types.StepBackControlType)controlType_;
		}
		set
		{
			controlType_ = value;
			controlTypeCase_ = ((value != null) ? ControlTypeOneofCase.StepBack : ControlTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.StepForwardControlType StepForward
	{
		get
		{
			if (controlTypeCase_ != ControlTypeOneofCase.StepForward)
			{
				return null;
			}
			return (Types.StepForwardControlType)controlType_;
		}
		set
		{
			controlType_ = value;
			controlTypeCase_ = ((value != null) ? ControlTypeOneofCase.StepForward : ControlTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GoToStartControlType GoToStart
	{
		get
		{
			if (controlTypeCase_ != ControlTypeOneofCase.GoToStart)
			{
				return null;
			}
			return (Types.GoToStartControlType)controlType_;
		}
		set
		{
			controlType_ = value;
			controlTypeCase_ = ((value != null) ? ControlTypeOneofCase.GoToStart : ControlTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GoToEndControlType GoToEnd
	{
		get
		{
			if (controlTypeCase_ != ControlTypeOneofCase.GoToEnd)
			{
				return null;
			}
			return (Types.GoToEndControlType)controlType_;
		}
		set
		{
			controlType_ = value;
			controlTypeCase_ = ((value != null) ? ControlTypeOneofCase.GoToEnd : ControlTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.JumpToTimeControlType JumpToTime
	{
		get
		{
			if (controlTypeCase_ != ControlTypeOneofCase.JumpToTime)
			{
				return null;
			}
			return (Types.JumpToTimeControlType)controlType_;
		}
		set
		{
			controlType_ = value;
			controlTypeCase_ = ((value != null) ? ControlTypeOneofCase.JumpToTime : ControlTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.JumpToPercentControlType JumpToPercent
	{
		get
		{
			if (controlTypeCase_ != ControlTypeOneofCase.JumpToPercent)
			{
				return null;
			}
			return (Types.JumpToPercentControlType)controlType_;
		}
		set
		{
			controlType_ = value;
			controlTypeCase_ = ((value != null) ? ControlTypeOneofCase.JumpToPercent : ControlTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.MarkInPointControlType MarkIn
	{
		get
		{
			if (controlTypeCase_ != ControlTypeOneofCase.MarkIn)
			{
				return null;
			}
			return (Types.MarkInPointControlType)controlType_;
		}
		set
		{
			controlType_ = value;
			controlTypeCase_ = ((value != null) ? ControlTypeOneofCase.MarkIn : ControlTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.MarkOutPointControlType MarkOut
	{
		get
		{
			if (controlTypeCase_ != ControlTypeOneofCase.MarkOut)
			{
				return null;
			}
			return (Types.MarkOutPointControlType)controlType_;
		}
		set
		{
			controlType_ = value;
			controlTypeCase_ = ((value != null) ? ControlTypeOneofCase.MarkOut : ControlTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SetScaleModeControlType SetScaleMode
	{
		get
		{
			if (controlTypeCase_ != ControlTypeOneofCase.SetScaleMode)
			{
				return null;
			}
			return (Types.SetScaleModeControlType)controlType_;
		}
		set
		{
			controlType_ = value;
			controlTypeCase_ = ((value != null) ? ControlTypeOneofCase.SetScaleMode : ControlTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SetFlippedModeControlType SetFlippedMode
	{
		get
		{
			if (controlTypeCase_ != ControlTypeOneofCase.SetFlippedMode)
			{
				return null;
			}
			return (Types.SetFlippedModeControlType)controlType_;
		}
		set
		{
			controlType_ = value;
			controlTypeCase_ = ((value != null) ? ControlTypeOneofCase.SetFlippedMode : ControlTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SetPlayRateControlType SetPlayRate
	{
		get
		{
			if (controlTypeCase_ != ControlTypeOneofCase.SetPlayRate)
			{
				return null;
			}
			return (Types.SetPlayRateControlType)controlType_;
		}
		set
		{
			controlType_ = value;
			controlTypeCase_ = ((value != null) ? ControlTypeOneofCase.SetPlayRate : ControlTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SetNativeRotationControlType SetRotation
	{
		get
		{
			if (controlTypeCase_ != ControlTypeOneofCase.SetRotation)
			{
				return null;
			}
			return (Types.SetNativeRotationControlType)controlType_;
		}
		set
		{
			controlType_ = value;
			controlTypeCase_ = ((value != null) ? ControlTypeOneofCase.SetRotation : ControlTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TogglePlaybackControlType TogglePlayback
	{
		get
		{
			if (controlTypeCase_ != ControlTypeOneofCase.TogglePlayback)
			{
				return null;
			}
			return (Types.TogglePlaybackControlType)controlType_;
		}
		set
		{
			controlType_ = value;
			controlTypeCase_ = ((value != null) ? ControlTypeOneofCase.TogglePlayback : ControlTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SetEffectsControlType SetEffects
	{
		get
		{
			if (controlTypeCase_ != ControlTypeOneofCase.SetEffects)
			{
				return null;
			}
			return (Types.SetEffectsControlType)controlType_;
		}
		set
		{
			controlType_ = value;
			controlTypeCase_ = ((value != null) ? ControlTypeOneofCase.SetEffects : ControlTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.UpdateEffectControlType UpdateEffect
	{
		get
		{
			if (controlTypeCase_ != ControlTypeOneofCase.UpdateEffect)
			{
				return null;
			}
			return (Types.UpdateEffectControlType)controlType_;
		}
		set
		{
			controlType_ = value;
			controlTypeCase_ = ((value != null) ? ControlTypeOneofCase.UpdateEffect : ControlTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.BeginScrubControlType BeginScrub
	{
		get
		{
			if (controlTypeCase_ != ControlTypeOneofCase.BeginScrub)
			{
				return null;
			}
			return (Types.BeginScrubControlType)controlType_;
		}
		set
		{
			controlType_ = value;
			controlTypeCase_ = ((value != null) ? ControlTypeOneofCase.BeginScrub : ControlTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.EndScrubControlType EndScrub
	{
		get
		{
			if (controlTypeCase_ != ControlTypeOneofCase.EndScrub)
			{
				return null;
			}
			return (Types.EndScrubControlType)controlType_;
		}
		set
		{
			controlType_ = value;
			controlTypeCase_ = ((value != null) ? ControlTypeOneofCase.EndScrub : ControlTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ScrubToTimeControlType ScrubToTime
	{
		get
		{
			if (controlTypeCase_ != ControlTypeOneofCase.ScrubToTime)
			{
				return null;
			}
			return (Types.ScrubToTimeControlType)controlType_;
		}
		set
		{
			controlType_ = value;
			controlTypeCase_ = ((value != null) ? ControlTypeOneofCase.ScrubToTime : ControlTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ScrubToPercentControlType ScrubToPercent
	{
		get
		{
			if (controlTypeCase_ != ControlTypeOneofCase.ScrubToPercent)
			{
				return null;
			}
			return (Types.ScrubToPercentControlType)controlType_;
		}
		set
		{
			controlType_ = value;
			controlTypeCase_ = ((value != null) ? ControlTypeOneofCase.ScrubToPercent : ControlTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SetAudioFadeType SetAudioFade
	{
		get
		{
			if (controlTypeCase_ != ControlTypeOneofCase.SetAudioFade)
			{
				return null;
			}
			return (Types.SetAudioFadeType)controlType_;
		}
		set
		{
			controlType_ = value;
			controlTypeCase_ = ((value != null) ? ControlTypeOneofCase.SetAudioFade : ControlTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SetAudioPropertiesType SetAudioProperties
	{
		get
		{
			if (controlTypeCase_ != ControlTypeOneofCase.SetAudioProperties)
			{
				return null;
			}
			return (Types.SetAudioPropertiesType)controlType_;
		}
		set
		{
			controlType_ = value;
			controlTypeCase_ = ((value != null) ? ControlTypeOneofCase.SetAudioProperties : ControlTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SetAlphaTypeControlType SetAlphaType
	{
		get
		{
			if (controlTypeCase_ != ControlTypeOneofCase.SetAlphaType)
			{
				return null;
			}
			return (Types.SetAlphaTypeControlType)controlType_;
		}
		set
		{
			controlType_ = value;
			controlTypeCase_ = ((value != null) ? ControlTypeOneofCase.SetAlphaType : ControlTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ControlTypeOneofCase ControlTypeCase => controlTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ControlTransport()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ControlTransport(ControlTransport other)
		: this()
	{
		switch (other.ControlTypeCase)
		{
		case ControlTypeOneofCase.Play:
			Play = other.Play.Clone();
			break;
		case ControlTypeOneofCase.Pause:
			Pause = other.Pause.Clone();
			break;
		case ControlTypeOneofCase.Rewind:
			Rewind = other.Rewind.Clone();
			break;
		case ControlTypeOneofCase.Fastforward:
			Fastforward = other.Fastforward.Clone();
			break;
		case ControlTypeOneofCase.SkipBack:
			SkipBack = other.SkipBack.Clone();
			break;
		case ControlTypeOneofCase.SkipForward:
			SkipForward = other.SkipForward.Clone();
			break;
		case ControlTypeOneofCase.StepBack:
			StepBack = other.StepBack.Clone();
			break;
		case ControlTypeOneofCase.StepForward:
			StepForward = other.StepForward.Clone();
			break;
		case ControlTypeOneofCase.GoToStart:
			GoToStart = other.GoToStart.Clone();
			break;
		case ControlTypeOneofCase.GoToEnd:
			GoToEnd = other.GoToEnd.Clone();
			break;
		case ControlTypeOneofCase.JumpToTime:
			JumpToTime = other.JumpToTime.Clone();
			break;
		case ControlTypeOneofCase.JumpToPercent:
			JumpToPercent = other.JumpToPercent.Clone();
			break;
		case ControlTypeOneofCase.MarkIn:
			MarkIn = other.MarkIn.Clone();
			break;
		case ControlTypeOneofCase.MarkOut:
			MarkOut = other.MarkOut.Clone();
			break;
		case ControlTypeOneofCase.SetScaleMode:
			SetScaleMode = other.SetScaleMode.Clone();
			break;
		case ControlTypeOneofCase.SetFlippedMode:
			SetFlippedMode = other.SetFlippedMode.Clone();
			break;
		case ControlTypeOneofCase.SetPlayRate:
			SetPlayRate = other.SetPlayRate.Clone();
			break;
		case ControlTypeOneofCase.SetRotation:
			SetRotation = other.SetRotation.Clone();
			break;
		case ControlTypeOneofCase.TogglePlayback:
			TogglePlayback = other.TogglePlayback.Clone();
			break;
		case ControlTypeOneofCase.SetEffects:
			SetEffects = other.SetEffects.Clone();
			break;
		case ControlTypeOneofCase.UpdateEffect:
			UpdateEffect = other.UpdateEffect.Clone();
			break;
		case ControlTypeOneofCase.BeginScrub:
			BeginScrub = other.BeginScrub.Clone();
			break;
		case ControlTypeOneofCase.EndScrub:
			EndScrub = other.EndScrub.Clone();
			break;
		case ControlTypeOneofCase.ScrubToTime:
			ScrubToTime = other.ScrubToTime.Clone();
			break;
		case ControlTypeOneofCase.ScrubToPercent:
			ScrubToPercent = other.ScrubToPercent.Clone();
			break;
		case ControlTypeOneofCase.SetAudioFade:
			SetAudioFade = other.SetAudioFade.Clone();
			break;
		case ControlTypeOneofCase.SetAudioProperties:
			SetAudioProperties = other.SetAudioProperties.Clone();
			break;
		case ControlTypeOneofCase.SetAlphaType:
			SetAlphaType = other.SetAlphaType.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ControlTransport Clone()
	{
		return new ControlTransport(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearControlType()
	{
		controlTypeCase_ = ControlTypeOneofCase.None;
		controlType_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ControlTransport);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ControlTransport other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Play, other.Play))
		{
			return false;
		}
		if (!object.Equals(Pause, other.Pause))
		{
			return false;
		}
		if (!object.Equals(Rewind, other.Rewind))
		{
			return false;
		}
		if (!object.Equals(Fastforward, other.Fastforward))
		{
			return false;
		}
		if (!object.Equals(SkipBack, other.SkipBack))
		{
			return false;
		}
		if (!object.Equals(SkipForward, other.SkipForward))
		{
			return false;
		}
		if (!object.Equals(StepBack, other.StepBack))
		{
			return false;
		}
		if (!object.Equals(StepForward, other.StepForward))
		{
			return false;
		}
		if (!object.Equals(GoToStart, other.GoToStart))
		{
			return false;
		}
		if (!object.Equals(GoToEnd, other.GoToEnd))
		{
			return false;
		}
		if (!object.Equals(JumpToTime, other.JumpToTime))
		{
			return false;
		}
		if (!object.Equals(JumpToPercent, other.JumpToPercent))
		{
			return false;
		}
		if (!object.Equals(MarkIn, other.MarkIn))
		{
			return false;
		}
		if (!object.Equals(MarkOut, other.MarkOut))
		{
			return false;
		}
		if (!object.Equals(SetScaleMode, other.SetScaleMode))
		{
			return false;
		}
		if (!object.Equals(SetFlippedMode, other.SetFlippedMode))
		{
			return false;
		}
		if (!object.Equals(SetPlayRate, other.SetPlayRate))
		{
			return false;
		}
		if (!object.Equals(SetRotation, other.SetRotation))
		{
			return false;
		}
		if (!object.Equals(TogglePlayback, other.TogglePlayback))
		{
			return false;
		}
		if (!object.Equals(SetEffects, other.SetEffects))
		{
			return false;
		}
		if (!object.Equals(UpdateEffect, other.UpdateEffect))
		{
			return false;
		}
		if (!object.Equals(BeginScrub, other.BeginScrub))
		{
			return false;
		}
		if (!object.Equals(EndScrub, other.EndScrub))
		{
			return false;
		}
		if (!object.Equals(ScrubToTime, other.ScrubToTime))
		{
			return false;
		}
		if (!object.Equals(ScrubToPercent, other.ScrubToPercent))
		{
			return false;
		}
		if (!object.Equals(SetAudioFade, other.SetAudioFade))
		{
			return false;
		}
		if (!object.Equals(SetAudioProperties, other.SetAudioProperties))
		{
			return false;
		}
		if (!object.Equals(SetAlphaType, other.SetAlphaType))
		{
			return false;
		}
		if (ControlTypeCase != other.ControlTypeCase)
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
		if (controlTypeCase_ == ControlTypeOneofCase.Play)
		{
			num ^= Play.GetHashCode();
		}
		if (controlTypeCase_ == ControlTypeOneofCase.Pause)
		{
			num ^= Pause.GetHashCode();
		}
		if (controlTypeCase_ == ControlTypeOneofCase.Rewind)
		{
			num ^= Rewind.GetHashCode();
		}
		if (controlTypeCase_ == ControlTypeOneofCase.Fastforward)
		{
			num ^= Fastforward.GetHashCode();
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SkipBack)
		{
			num ^= SkipBack.GetHashCode();
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SkipForward)
		{
			num ^= SkipForward.GetHashCode();
		}
		if (controlTypeCase_ == ControlTypeOneofCase.StepBack)
		{
			num ^= StepBack.GetHashCode();
		}
		if (controlTypeCase_ == ControlTypeOneofCase.StepForward)
		{
			num ^= StepForward.GetHashCode();
		}
		if (controlTypeCase_ == ControlTypeOneofCase.GoToStart)
		{
			num ^= GoToStart.GetHashCode();
		}
		if (controlTypeCase_ == ControlTypeOneofCase.GoToEnd)
		{
			num ^= GoToEnd.GetHashCode();
		}
		if (controlTypeCase_ == ControlTypeOneofCase.JumpToTime)
		{
			num ^= JumpToTime.GetHashCode();
		}
		if (controlTypeCase_ == ControlTypeOneofCase.JumpToPercent)
		{
			num ^= JumpToPercent.GetHashCode();
		}
		if (controlTypeCase_ == ControlTypeOneofCase.MarkIn)
		{
			num ^= MarkIn.GetHashCode();
		}
		if (controlTypeCase_ == ControlTypeOneofCase.MarkOut)
		{
			num ^= MarkOut.GetHashCode();
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SetScaleMode)
		{
			num ^= SetScaleMode.GetHashCode();
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SetFlippedMode)
		{
			num ^= SetFlippedMode.GetHashCode();
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SetPlayRate)
		{
			num ^= SetPlayRate.GetHashCode();
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SetRotation)
		{
			num ^= SetRotation.GetHashCode();
		}
		if (controlTypeCase_ == ControlTypeOneofCase.TogglePlayback)
		{
			num ^= TogglePlayback.GetHashCode();
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SetEffects)
		{
			num ^= SetEffects.GetHashCode();
		}
		if (controlTypeCase_ == ControlTypeOneofCase.UpdateEffect)
		{
			num ^= UpdateEffect.GetHashCode();
		}
		if (controlTypeCase_ == ControlTypeOneofCase.BeginScrub)
		{
			num ^= BeginScrub.GetHashCode();
		}
		if (controlTypeCase_ == ControlTypeOneofCase.EndScrub)
		{
			num ^= EndScrub.GetHashCode();
		}
		if (controlTypeCase_ == ControlTypeOneofCase.ScrubToTime)
		{
			num ^= ScrubToTime.GetHashCode();
		}
		if (controlTypeCase_ == ControlTypeOneofCase.ScrubToPercent)
		{
			num ^= ScrubToPercent.GetHashCode();
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SetAudioFade)
		{
			num ^= SetAudioFade.GetHashCode();
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SetAudioProperties)
		{
			num ^= SetAudioProperties.GetHashCode();
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SetAlphaType)
		{
			num ^= SetAlphaType.GetHashCode();
		}
		num ^= (int)controlTypeCase_;
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
		if (controlTypeCase_ == ControlTypeOneofCase.Play)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Play);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.Pause)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Pause);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.Rewind)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Rewind);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.Fastforward)
		{
			output.WriteRawTag(34);
			output.WriteMessage(Fastforward);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SkipBack)
		{
			output.WriteRawTag(42);
			output.WriteMessage(SkipBack);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SkipForward)
		{
			output.WriteRawTag(50);
			output.WriteMessage(SkipForward);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.StepBack)
		{
			output.WriteRawTag(58);
			output.WriteMessage(StepBack);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.StepForward)
		{
			output.WriteRawTag(66);
			output.WriteMessage(StepForward);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.GoToStart)
		{
			output.WriteRawTag(74);
			output.WriteMessage(GoToStart);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.GoToEnd)
		{
			output.WriteRawTag(82);
			output.WriteMessage(GoToEnd);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.JumpToTime)
		{
			output.WriteRawTag(90);
			output.WriteMessage(JumpToTime);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.JumpToPercent)
		{
			output.WriteRawTag(98);
			output.WriteMessage(JumpToPercent);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.MarkIn)
		{
			output.WriteRawTag(106);
			output.WriteMessage(MarkIn);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.MarkOut)
		{
			output.WriteRawTag(114);
			output.WriteMessage(MarkOut);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SetScaleMode)
		{
			output.WriteRawTag(122);
			output.WriteMessage(SetScaleMode);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SetFlippedMode)
		{
			output.WriteRawTag(130, 1);
			output.WriteMessage(SetFlippedMode);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SetPlayRate)
		{
			output.WriteRawTag(138, 1);
			output.WriteMessage(SetPlayRate);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SetRotation)
		{
			output.WriteRawTag(146, 1);
			output.WriteMessage(SetRotation);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.TogglePlayback)
		{
			output.WriteRawTag(154, 1);
			output.WriteMessage(TogglePlayback);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SetEffects)
		{
			output.WriteRawTag(162, 1);
			output.WriteMessage(SetEffects);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.UpdateEffect)
		{
			output.WriteRawTag(170, 1);
			output.WriteMessage(UpdateEffect);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.BeginScrub)
		{
			output.WriteRawTag(178, 1);
			output.WriteMessage(BeginScrub);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.EndScrub)
		{
			output.WriteRawTag(186, 1);
			output.WriteMessage(EndScrub);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.ScrubToTime)
		{
			output.WriteRawTag(194, 1);
			output.WriteMessage(ScrubToTime);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.ScrubToPercent)
		{
			output.WriteRawTag(202, 1);
			output.WriteMessage(ScrubToPercent);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SetAudioFade)
		{
			output.WriteRawTag(210, 1);
			output.WriteMessage(SetAudioFade);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SetAudioProperties)
		{
			output.WriteRawTag(218, 1);
			output.WriteMessage(SetAudioProperties);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SetAlphaType)
		{
			output.WriteRawTag(226, 1);
			output.WriteMessage(SetAlphaType);
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
		if (controlTypeCase_ == ControlTypeOneofCase.Play)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Play);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.Pause)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Pause);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.Rewind)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Rewind);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.Fastforward)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Fastforward);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SkipBack)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SkipBack);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SkipForward)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SkipForward);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.StepBack)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(StepBack);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.StepForward)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(StepForward);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.GoToStart)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GoToStart);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.GoToEnd)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GoToEnd);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.JumpToTime)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(JumpToTime);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.JumpToPercent)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(JumpToPercent);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.MarkIn)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(MarkIn);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.MarkOut)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(MarkOut);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SetScaleMode)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SetScaleMode);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SetFlippedMode)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(SetFlippedMode);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SetPlayRate)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(SetPlayRate);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SetRotation)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(SetRotation);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.TogglePlayback)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(TogglePlayback);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SetEffects)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(SetEffects);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.UpdateEffect)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(UpdateEffect);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.BeginScrub)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(BeginScrub);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.EndScrub)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(EndScrub);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.ScrubToTime)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ScrubToTime);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.ScrubToPercent)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ScrubToPercent);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SetAudioFade)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(SetAudioFade);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SetAudioProperties)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(SetAudioProperties);
		}
		if (controlTypeCase_ == ControlTypeOneofCase.SetAlphaType)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(SetAlphaType);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ControlTransport other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.ControlTypeCase)
		{
		case ControlTypeOneofCase.Play:
			if (Play == null)
			{
				Play = new Types.PlayControlType();
			}
			Play.MergeFrom(other.Play);
			break;
		case ControlTypeOneofCase.Pause:
			if (Pause == null)
			{
				Pause = new Types.PauseControlType();
			}
			Pause.MergeFrom(other.Pause);
			break;
		case ControlTypeOneofCase.Rewind:
			if (Rewind == null)
			{
				Rewind = new Types.RewindControlType();
			}
			Rewind.MergeFrom(other.Rewind);
			break;
		case ControlTypeOneofCase.Fastforward:
			if (Fastforward == null)
			{
				Fastforward = new Types.FastForwardControlType();
			}
			Fastforward.MergeFrom(other.Fastforward);
			break;
		case ControlTypeOneofCase.SkipBack:
			if (SkipBack == null)
			{
				SkipBack = new Types.SkipBackControlType();
			}
			SkipBack.MergeFrom(other.SkipBack);
			break;
		case ControlTypeOneofCase.SkipForward:
			if (SkipForward == null)
			{
				SkipForward = new Types.SkipForwardControlType();
			}
			SkipForward.MergeFrom(other.SkipForward);
			break;
		case ControlTypeOneofCase.StepBack:
			if (StepBack == null)
			{
				StepBack = new Types.StepBackControlType();
			}
			StepBack.MergeFrom(other.StepBack);
			break;
		case ControlTypeOneofCase.StepForward:
			if (StepForward == null)
			{
				StepForward = new Types.StepForwardControlType();
			}
			StepForward.MergeFrom(other.StepForward);
			break;
		case ControlTypeOneofCase.GoToStart:
			if (GoToStart == null)
			{
				GoToStart = new Types.GoToStartControlType();
			}
			GoToStart.MergeFrom(other.GoToStart);
			break;
		case ControlTypeOneofCase.GoToEnd:
			if (GoToEnd == null)
			{
				GoToEnd = new Types.GoToEndControlType();
			}
			GoToEnd.MergeFrom(other.GoToEnd);
			break;
		case ControlTypeOneofCase.JumpToTime:
			if (JumpToTime == null)
			{
				JumpToTime = new Types.JumpToTimeControlType();
			}
			JumpToTime.MergeFrom(other.JumpToTime);
			break;
		case ControlTypeOneofCase.JumpToPercent:
			if (JumpToPercent == null)
			{
				JumpToPercent = new Types.JumpToPercentControlType();
			}
			JumpToPercent.MergeFrom(other.JumpToPercent);
			break;
		case ControlTypeOneofCase.MarkIn:
			if (MarkIn == null)
			{
				MarkIn = new Types.MarkInPointControlType();
			}
			MarkIn.MergeFrom(other.MarkIn);
			break;
		case ControlTypeOneofCase.MarkOut:
			if (MarkOut == null)
			{
				MarkOut = new Types.MarkOutPointControlType();
			}
			MarkOut.MergeFrom(other.MarkOut);
			break;
		case ControlTypeOneofCase.SetScaleMode:
			if (SetScaleMode == null)
			{
				SetScaleMode = new Types.SetScaleModeControlType();
			}
			SetScaleMode.MergeFrom(other.SetScaleMode);
			break;
		case ControlTypeOneofCase.SetFlippedMode:
			if (SetFlippedMode == null)
			{
				SetFlippedMode = new Types.SetFlippedModeControlType();
			}
			SetFlippedMode.MergeFrom(other.SetFlippedMode);
			break;
		case ControlTypeOneofCase.SetPlayRate:
			if (SetPlayRate == null)
			{
				SetPlayRate = new Types.SetPlayRateControlType();
			}
			SetPlayRate.MergeFrom(other.SetPlayRate);
			break;
		case ControlTypeOneofCase.SetRotation:
			if (SetRotation == null)
			{
				SetRotation = new Types.SetNativeRotationControlType();
			}
			SetRotation.MergeFrom(other.SetRotation);
			break;
		case ControlTypeOneofCase.TogglePlayback:
			if (TogglePlayback == null)
			{
				TogglePlayback = new Types.TogglePlaybackControlType();
			}
			TogglePlayback.MergeFrom(other.TogglePlayback);
			break;
		case ControlTypeOneofCase.SetEffects:
			if (SetEffects == null)
			{
				SetEffects = new Types.SetEffectsControlType();
			}
			SetEffects.MergeFrom(other.SetEffects);
			break;
		case ControlTypeOneofCase.UpdateEffect:
			if (UpdateEffect == null)
			{
				UpdateEffect = new Types.UpdateEffectControlType();
			}
			UpdateEffect.MergeFrom(other.UpdateEffect);
			break;
		case ControlTypeOneofCase.BeginScrub:
			if (BeginScrub == null)
			{
				BeginScrub = new Types.BeginScrubControlType();
			}
			BeginScrub.MergeFrom(other.BeginScrub);
			break;
		case ControlTypeOneofCase.EndScrub:
			if (EndScrub == null)
			{
				EndScrub = new Types.EndScrubControlType();
			}
			EndScrub.MergeFrom(other.EndScrub);
			break;
		case ControlTypeOneofCase.ScrubToTime:
			if (ScrubToTime == null)
			{
				ScrubToTime = new Types.ScrubToTimeControlType();
			}
			ScrubToTime.MergeFrom(other.ScrubToTime);
			break;
		case ControlTypeOneofCase.ScrubToPercent:
			if (ScrubToPercent == null)
			{
				ScrubToPercent = new Types.ScrubToPercentControlType();
			}
			ScrubToPercent.MergeFrom(other.ScrubToPercent);
			break;
		case ControlTypeOneofCase.SetAudioFade:
			if (SetAudioFade == null)
			{
				SetAudioFade = new Types.SetAudioFadeType();
			}
			SetAudioFade.MergeFrom(other.SetAudioFade);
			break;
		case ControlTypeOneofCase.SetAudioProperties:
			if (SetAudioProperties == null)
			{
				SetAudioProperties = new Types.SetAudioPropertiesType();
			}
			SetAudioProperties.MergeFrom(other.SetAudioProperties);
			break;
		case ControlTypeOneofCase.SetAlphaType:
			if (SetAlphaType == null)
			{
				SetAlphaType = new Types.SetAlphaTypeControlType();
			}
			SetAlphaType.MergeFrom(other.SetAlphaType);
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
				Types.PlayControlType playControlType = new Types.PlayControlType();
				if (controlTypeCase_ == ControlTypeOneofCase.Play)
				{
					playControlType.MergeFrom(Play);
				}
				input.ReadMessage(playControlType);
				Play = playControlType;
				break;
			}
			case 18u:
			{
				Types.PauseControlType pauseControlType = new Types.PauseControlType();
				if (controlTypeCase_ == ControlTypeOneofCase.Pause)
				{
					pauseControlType.MergeFrom(Pause);
				}
				input.ReadMessage(pauseControlType);
				Pause = pauseControlType;
				break;
			}
			case 26u:
			{
				Types.RewindControlType rewindControlType = new Types.RewindControlType();
				if (controlTypeCase_ == ControlTypeOneofCase.Rewind)
				{
					rewindControlType.MergeFrom(Rewind);
				}
				input.ReadMessage(rewindControlType);
				Rewind = rewindControlType;
				break;
			}
			case 34u:
			{
				Types.FastForwardControlType fastForwardControlType = new Types.FastForwardControlType();
				if (controlTypeCase_ == ControlTypeOneofCase.Fastforward)
				{
					fastForwardControlType.MergeFrom(Fastforward);
				}
				input.ReadMessage(fastForwardControlType);
				Fastforward = fastForwardControlType;
				break;
			}
			case 42u:
			{
				Types.SkipBackControlType skipBackControlType = new Types.SkipBackControlType();
				if (controlTypeCase_ == ControlTypeOneofCase.SkipBack)
				{
					skipBackControlType.MergeFrom(SkipBack);
				}
				input.ReadMessage(skipBackControlType);
				SkipBack = skipBackControlType;
				break;
			}
			case 50u:
			{
				Types.SkipForwardControlType skipForwardControlType = new Types.SkipForwardControlType();
				if (controlTypeCase_ == ControlTypeOneofCase.SkipForward)
				{
					skipForwardControlType.MergeFrom(SkipForward);
				}
				input.ReadMessage(skipForwardControlType);
				SkipForward = skipForwardControlType;
				break;
			}
			case 58u:
			{
				Types.StepBackControlType stepBackControlType = new Types.StepBackControlType();
				if (controlTypeCase_ == ControlTypeOneofCase.StepBack)
				{
					stepBackControlType.MergeFrom(StepBack);
				}
				input.ReadMessage(stepBackControlType);
				StepBack = stepBackControlType;
				break;
			}
			case 66u:
			{
				Types.StepForwardControlType stepForwardControlType = new Types.StepForwardControlType();
				if (controlTypeCase_ == ControlTypeOneofCase.StepForward)
				{
					stepForwardControlType.MergeFrom(StepForward);
				}
				input.ReadMessage(stepForwardControlType);
				StepForward = stepForwardControlType;
				break;
			}
			case 74u:
			{
				Types.GoToStartControlType goToStartControlType = new Types.GoToStartControlType();
				if (controlTypeCase_ == ControlTypeOneofCase.GoToStart)
				{
					goToStartControlType.MergeFrom(GoToStart);
				}
				input.ReadMessage(goToStartControlType);
				GoToStart = goToStartControlType;
				break;
			}
			case 82u:
			{
				Types.GoToEndControlType goToEndControlType = new Types.GoToEndControlType();
				if (controlTypeCase_ == ControlTypeOneofCase.GoToEnd)
				{
					goToEndControlType.MergeFrom(GoToEnd);
				}
				input.ReadMessage(goToEndControlType);
				GoToEnd = goToEndControlType;
				break;
			}
			case 90u:
			{
				Types.JumpToTimeControlType jumpToTimeControlType = new Types.JumpToTimeControlType();
				if (controlTypeCase_ == ControlTypeOneofCase.JumpToTime)
				{
					jumpToTimeControlType.MergeFrom(JumpToTime);
				}
				input.ReadMessage(jumpToTimeControlType);
				JumpToTime = jumpToTimeControlType;
				break;
			}
			case 98u:
			{
				Types.JumpToPercentControlType jumpToPercentControlType = new Types.JumpToPercentControlType();
				if (controlTypeCase_ == ControlTypeOneofCase.JumpToPercent)
				{
					jumpToPercentControlType.MergeFrom(JumpToPercent);
				}
				input.ReadMessage(jumpToPercentControlType);
				JumpToPercent = jumpToPercentControlType;
				break;
			}
			case 106u:
			{
				Types.MarkInPointControlType markInPointControlType = new Types.MarkInPointControlType();
				if (controlTypeCase_ == ControlTypeOneofCase.MarkIn)
				{
					markInPointControlType.MergeFrom(MarkIn);
				}
				input.ReadMessage(markInPointControlType);
				MarkIn = markInPointControlType;
				break;
			}
			case 114u:
			{
				Types.MarkOutPointControlType markOutPointControlType = new Types.MarkOutPointControlType();
				if (controlTypeCase_ == ControlTypeOneofCase.MarkOut)
				{
					markOutPointControlType.MergeFrom(MarkOut);
				}
				input.ReadMessage(markOutPointControlType);
				MarkOut = markOutPointControlType;
				break;
			}
			case 122u:
			{
				Types.SetScaleModeControlType setScaleModeControlType = new Types.SetScaleModeControlType();
				if (controlTypeCase_ == ControlTypeOneofCase.SetScaleMode)
				{
					setScaleModeControlType.MergeFrom(SetScaleMode);
				}
				input.ReadMessage(setScaleModeControlType);
				SetScaleMode = setScaleModeControlType;
				break;
			}
			case 130u:
			{
				Types.SetFlippedModeControlType setFlippedModeControlType = new Types.SetFlippedModeControlType();
				if (controlTypeCase_ == ControlTypeOneofCase.SetFlippedMode)
				{
					setFlippedModeControlType.MergeFrom(SetFlippedMode);
				}
				input.ReadMessage(setFlippedModeControlType);
				SetFlippedMode = setFlippedModeControlType;
				break;
			}
			case 138u:
			{
				Types.SetPlayRateControlType setPlayRateControlType = new Types.SetPlayRateControlType();
				if (controlTypeCase_ == ControlTypeOneofCase.SetPlayRate)
				{
					setPlayRateControlType.MergeFrom(SetPlayRate);
				}
				input.ReadMessage(setPlayRateControlType);
				SetPlayRate = setPlayRateControlType;
				break;
			}
			case 146u:
			{
				Types.SetNativeRotationControlType setNativeRotationControlType = new Types.SetNativeRotationControlType();
				if (controlTypeCase_ == ControlTypeOneofCase.SetRotation)
				{
					setNativeRotationControlType.MergeFrom(SetRotation);
				}
				input.ReadMessage(setNativeRotationControlType);
				SetRotation = setNativeRotationControlType;
				break;
			}
			case 154u:
			{
				Types.TogglePlaybackControlType togglePlaybackControlType = new Types.TogglePlaybackControlType();
				if (controlTypeCase_ == ControlTypeOneofCase.TogglePlayback)
				{
					togglePlaybackControlType.MergeFrom(TogglePlayback);
				}
				input.ReadMessage(togglePlaybackControlType);
				TogglePlayback = togglePlaybackControlType;
				break;
			}
			case 162u:
			{
				Types.SetEffectsControlType setEffectsControlType = new Types.SetEffectsControlType();
				if (controlTypeCase_ == ControlTypeOneofCase.SetEffects)
				{
					setEffectsControlType.MergeFrom(SetEffects);
				}
				input.ReadMessage(setEffectsControlType);
				SetEffects = setEffectsControlType;
				break;
			}
			case 170u:
			{
				Types.UpdateEffectControlType updateEffectControlType = new Types.UpdateEffectControlType();
				if (controlTypeCase_ == ControlTypeOneofCase.UpdateEffect)
				{
					updateEffectControlType.MergeFrom(UpdateEffect);
				}
				input.ReadMessage(updateEffectControlType);
				UpdateEffect = updateEffectControlType;
				break;
			}
			case 178u:
			{
				Types.BeginScrubControlType beginScrubControlType = new Types.BeginScrubControlType();
				if (controlTypeCase_ == ControlTypeOneofCase.BeginScrub)
				{
					beginScrubControlType.MergeFrom(BeginScrub);
				}
				input.ReadMessage(beginScrubControlType);
				BeginScrub = beginScrubControlType;
				break;
			}
			case 186u:
			{
				Types.EndScrubControlType endScrubControlType = new Types.EndScrubControlType();
				if (controlTypeCase_ == ControlTypeOneofCase.EndScrub)
				{
					endScrubControlType.MergeFrom(EndScrub);
				}
				input.ReadMessage(endScrubControlType);
				EndScrub = endScrubControlType;
				break;
			}
			case 194u:
			{
				Types.ScrubToTimeControlType scrubToTimeControlType = new Types.ScrubToTimeControlType();
				if (controlTypeCase_ == ControlTypeOneofCase.ScrubToTime)
				{
					scrubToTimeControlType.MergeFrom(ScrubToTime);
				}
				input.ReadMessage(scrubToTimeControlType);
				ScrubToTime = scrubToTimeControlType;
				break;
			}
			case 202u:
			{
				Types.ScrubToPercentControlType scrubToPercentControlType = new Types.ScrubToPercentControlType();
				if (controlTypeCase_ == ControlTypeOneofCase.ScrubToPercent)
				{
					scrubToPercentControlType.MergeFrom(ScrubToPercent);
				}
				input.ReadMessage(scrubToPercentControlType);
				ScrubToPercent = scrubToPercentControlType;
				break;
			}
			case 210u:
			{
				Types.SetAudioFadeType setAudioFadeType = new Types.SetAudioFadeType();
				if (controlTypeCase_ == ControlTypeOneofCase.SetAudioFade)
				{
					setAudioFadeType.MergeFrom(SetAudioFade);
				}
				input.ReadMessage(setAudioFadeType);
				SetAudioFade = setAudioFadeType;
				break;
			}
			case 218u:
			{
				Types.SetAudioPropertiesType setAudioPropertiesType = new Types.SetAudioPropertiesType();
				if (controlTypeCase_ == ControlTypeOneofCase.SetAudioProperties)
				{
					setAudioPropertiesType.MergeFrom(SetAudioProperties);
				}
				input.ReadMessage(setAudioPropertiesType);
				SetAudioProperties = setAudioPropertiesType;
				break;
			}
			case 226u:
			{
				Types.SetAlphaTypeControlType setAlphaTypeControlType = new Types.SetAlphaTypeControlType();
				if (controlTypeCase_ == ControlTypeOneofCase.SetAlphaType)
				{
					setAlphaTypeControlType.MergeFrom(SetAlphaType);
				}
				input.ReadMessage(setAlphaTypeControlType);
				SetAlphaType = setAlphaTypeControlType;
				break;
			}
			}
		}
	}
}
