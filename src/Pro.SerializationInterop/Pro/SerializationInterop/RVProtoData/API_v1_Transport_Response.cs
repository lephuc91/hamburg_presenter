using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Transport_Response : IMessage<API_v1_Transport_Response>, IMessage, IEquatable<API_v1_Transport_Response>, IDeepCloneable<API_v1_Transport_Response>
{
	public enum ResponseOneofCase
	{
		None,
		Play,
		Pause,
		SkipBackward,
		SkipForward,
		GoToEnd,
		GetTime,
		PutTime,
		GetAutoAdvance,
		DeleteAutoAdvance,
		GetCurrentMedia
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Play : IMessage<Play>, IMessage, IEquatable<Play>, IDeepCloneable<Play>
		{
			private static readonly MessageParser<Play> _parser = new MessageParser<Play>(() => new Play());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Play> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Transport_Response.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Play()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Play(Play other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Play Clone()
			{
				return new Play(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Play);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Play other)
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
			public void MergeFrom(Play other)
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
		public sealed class Pause : IMessage<Pause>, IMessage, IEquatable<Pause>, IDeepCloneable<Pause>
		{
			private static readonly MessageParser<Pause> _parser = new MessageParser<Pause>(() => new Pause());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Pause> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Transport_Response.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Pause()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Pause(Pause other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Pause Clone()
			{
				return new Pause(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Pause);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Pause other)
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
			public void MergeFrom(Pause other)
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
		public sealed class SkipBackward : IMessage<SkipBackward>, IMessage, IEquatable<SkipBackward>, IDeepCloneable<SkipBackward>
		{
			private static readonly MessageParser<SkipBackward> _parser = new MessageParser<SkipBackward>(() => new SkipBackward());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SkipBackward> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Transport_Response.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SkipBackward()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SkipBackward(SkipBackward other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SkipBackward Clone()
			{
				return new SkipBackward(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as SkipBackward);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(SkipBackward other)
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
			public void MergeFrom(SkipBackward other)
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
		public sealed class SkipForward : IMessage<SkipForward>, IMessage, IEquatable<SkipForward>, IDeepCloneable<SkipForward>
		{
			private static readonly MessageParser<SkipForward> _parser = new MessageParser<SkipForward>(() => new SkipForward());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SkipForward> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Transport_Response.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SkipForward()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SkipForward(SkipForward other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SkipForward Clone()
			{
				return new SkipForward(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as SkipForward);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(SkipForward other)
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
			public void MergeFrom(SkipForward other)
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
		public sealed class GoToEnd : IMessage<GoToEnd>, IMessage, IEquatable<GoToEnd>, IDeepCloneable<GoToEnd>
		{
			private static readonly MessageParser<GoToEnd> _parser = new MessageParser<GoToEnd>(() => new GoToEnd());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GoToEnd> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Transport_Response.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GoToEnd()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GoToEnd(GoToEnd other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GoToEnd Clone()
			{
				return new GoToEnd(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GoToEnd);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GoToEnd other)
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
			public void MergeFrom(GoToEnd other)
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
		public sealed class GetTime : IMessage<GetTime>, IMessage, IEquatable<GetTime>, IDeepCloneable<GetTime>
		{
			private static readonly MessageParser<GetTime> _parser = new MessageParser<GetTime>(() => new GetTime());

			private UnknownFieldSet _unknownFields;

			public const int SecondsFieldNumber = 1;

			private double seconds_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetTime> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Transport_Response.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Seconds
			{
				get
				{
					return seconds_;
				}
				set
				{
					seconds_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetTime()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetTime(GetTime other)
				: this()
			{
				seconds_ = other.seconds_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetTime Clone()
			{
				return new GetTime(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetTime);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetTime other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Seconds, other.Seconds))
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
				if (Seconds != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Seconds);
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
				if (Seconds != 0.0)
				{
					output.WriteRawTag(9);
					output.WriteDouble(Seconds);
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
				if (Seconds != 0.0)
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
			public void MergeFrom(GetTime other)
			{
				if (other != null)
				{
					if (other.Seconds != 0.0)
					{
						Seconds = other.Seconds;
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
						Seconds = input.ReadDouble();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PutTime : IMessage<PutTime>, IMessage, IEquatable<PutTime>, IDeepCloneable<PutTime>
		{
			private static readonly MessageParser<PutTime> _parser = new MessageParser<PutTime>(() => new PutTime());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutTime> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Transport_Response.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutTime()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutTime(PutTime other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutTime Clone()
			{
				return new PutTime(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PutTime);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PutTime other)
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
			public void MergeFrom(PutTime other)
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
		public sealed class GetAutoAdvance : IMessage<GetAutoAdvance>, IMessage, IEquatable<GetAutoAdvance>, IDeepCloneable<GetAutoAdvance>
		{
			private static readonly MessageParser<GetAutoAdvance> _parser = new MessageParser<GetAutoAdvance>(() => new GetAutoAdvance());

			private UnknownFieldSet _unknownFields;

			public const int AutoAdvanceFieldNumber = 1;

			private bool autoAdvance_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetAutoAdvance> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Transport_Response.Descriptor.NestedTypes[7];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool AutoAdvance
			{
				get
				{
					return autoAdvance_;
				}
				set
				{
					autoAdvance_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetAutoAdvance()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetAutoAdvance(GetAutoAdvance other)
				: this()
			{
				autoAdvance_ = other.autoAdvance_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetAutoAdvance Clone()
			{
				return new GetAutoAdvance(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetAutoAdvance);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetAutoAdvance other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (AutoAdvance != other.AutoAdvance)
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
				if (AutoAdvance)
				{
					num ^= AutoAdvance.GetHashCode();
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
				if (AutoAdvance)
				{
					output.WriteRawTag(8);
					output.WriteBool(AutoAdvance);
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
				if (AutoAdvance)
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
			public void MergeFrom(GetAutoAdvance other)
			{
				if (other != null)
				{
					if (other.AutoAdvance)
					{
						AutoAdvance = other.AutoAdvance;
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
						AutoAdvance = input.ReadBool();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class DeleteAutoAdvance : IMessage<DeleteAutoAdvance>, IMessage, IEquatable<DeleteAutoAdvance>, IDeepCloneable<DeleteAutoAdvance>
		{
			private static readonly MessageParser<DeleteAutoAdvance> _parser = new MessageParser<DeleteAutoAdvance>(() => new DeleteAutoAdvance());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DeleteAutoAdvance> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Transport_Response.Descriptor.NestedTypes[8];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteAutoAdvance()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteAutoAdvance(DeleteAutoAdvance other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteAutoAdvance Clone()
			{
				return new DeleteAutoAdvance(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as DeleteAutoAdvance);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(DeleteAutoAdvance other)
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
			public void MergeFrom(DeleteAutoAdvance other)
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
		public sealed class GetCurrentMedia : IMessage<GetCurrentMedia>, IMessage, IEquatable<GetCurrentMedia>, IDeepCloneable<GetCurrentMedia>
		{
			private static readonly MessageParser<GetCurrentMedia> _parser = new MessageParser<GetCurrentMedia>(() => new GetCurrentMedia());

			private UnknownFieldSet _unknownFields;

			public const int IsPlayingFieldNumber = 1;

			private bool isPlaying_;

			public const int UuidFieldNumber = 2;

			private string uuid_ = "";

			public const int NameFieldNumber = 3;

			private string name_ = "";

			public const int ArtistFieldNumber = 4;

			private string artist_ = "";

			public const int AudioOnlyFieldNumber = 5;

			private bool audioOnly_;

			public const int DurationFieldNumber = 6;

			private double duration_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetCurrentMedia> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Transport_Response.Descriptor.NestedTypes[9];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool IsPlaying
			{
				get
				{
					return isPlaying_;
				}
				set
				{
					isPlaying_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Uuid
			{
				get
				{
					return uuid_;
				}
				set
				{
					uuid_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Name
			{
				get
				{
					return name_;
				}
				set
				{
					name_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Artist
			{
				get
				{
					return artist_;
				}
				set
				{
					artist_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool AudioOnly
			{
				get
				{
					return audioOnly_;
				}
				set
				{
					audioOnly_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public double Duration
			{
				get
				{
					return duration_;
				}
				set
				{
					duration_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetCurrentMedia()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetCurrentMedia(GetCurrentMedia other)
				: this()
			{
				isPlaying_ = other.isPlaying_;
				uuid_ = other.uuid_;
				name_ = other.name_;
				artist_ = other.artist_;
				audioOnly_ = other.audioOnly_;
				duration_ = other.duration_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetCurrentMedia Clone()
			{
				return new GetCurrentMedia(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetCurrentMedia);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetCurrentMedia other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (IsPlaying != other.IsPlaying)
				{
					return false;
				}
				if (Uuid != other.Uuid)
				{
					return false;
				}
				if (Name != other.Name)
				{
					return false;
				}
				if (Artist != other.Artist)
				{
					return false;
				}
				if (AudioOnly != other.AudioOnly)
				{
					return false;
				}
				if (!ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Duration, other.Duration))
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
				if (IsPlaying)
				{
					num ^= IsPlaying.GetHashCode();
				}
				if (Uuid.Length != 0)
				{
					num ^= Uuid.GetHashCode();
				}
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
				}
				if (Artist.Length != 0)
				{
					num ^= Artist.GetHashCode();
				}
				if (AudioOnly)
				{
					num ^= AudioOnly.GetHashCode();
				}
				if (Duration != 0.0)
				{
					num ^= ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Duration);
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
				if (IsPlaying)
				{
					output.WriteRawTag(8);
					output.WriteBool(IsPlaying);
				}
				if (Uuid.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(Uuid);
				}
				if (Name.Length != 0)
				{
					output.WriteRawTag(26);
					output.WriteString(Name);
				}
				if (Artist.Length != 0)
				{
					output.WriteRawTag(34);
					output.WriteString(Artist);
				}
				if (AudioOnly)
				{
					output.WriteRawTag(40);
					output.WriteBool(AudioOnly);
				}
				if (Duration != 0.0)
				{
					output.WriteRawTag(49);
					output.WriteDouble(Duration);
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
				if (IsPlaying)
				{
					num += 2;
				}
				if (Uuid.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Uuid);
				}
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				if (Artist.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Artist);
				}
				if (AudioOnly)
				{
					num += 2;
				}
				if (Duration != 0.0)
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
			public void MergeFrom(GetCurrentMedia other)
			{
				if (other != null)
				{
					if (other.IsPlaying)
					{
						IsPlaying = other.IsPlaying;
					}
					if (other.Uuid.Length != 0)
					{
						Uuid = other.Uuid;
					}
					if (other.Name.Length != 0)
					{
						Name = other.Name;
					}
					if (other.Artist.Length != 0)
					{
						Artist = other.Artist;
					}
					if (other.AudioOnly)
					{
						AudioOnly = other.AudioOnly;
					}
					if (other.Duration != 0.0)
					{
						Duration = other.Duration;
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
						IsPlaying = input.ReadBool();
						break;
					case 18u:
						Uuid = input.ReadString();
						break;
					case 26u:
						Name = input.ReadString();
						break;
					case 34u:
						Artist = input.ReadString();
						break;
					case 40u:
						AudioOnly = input.ReadBool();
						break;
					case 49u:
						Duration = input.ReadDouble();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<API_v1_Transport_Response> _parser = new MessageParser<API_v1_Transport_Response>(() => new API_v1_Transport_Response());

	private UnknownFieldSet _unknownFields;

	public const int PlayFieldNumber = 1;

	public const int PauseFieldNumber = 2;

	public const int SkipBackwardFieldNumber = 3;

	public const int SkipForwardFieldNumber = 4;

	public const int GoToEndFieldNumber = 5;

	public const int GetTimeFieldNumber = 6;

	public const int PutTimeFieldNumber = 7;

	public const int GetAutoAdvanceFieldNumber = 8;

	public const int DeleteAutoAdvanceFieldNumber = 9;

	public const int GetCurrentMediaFieldNumber = 10;

	private object response_;

	private ResponseOneofCase responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Transport_Response> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1TransportReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Play Play
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Play)
			{
				return null;
			}
			return (Types.Play)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Play : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Pause Pause
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Pause)
			{
				return null;
			}
			return (Types.Pause)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Pause : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SkipBackward SkipBackward
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.SkipBackward)
			{
				return null;
			}
			return (Types.SkipBackward)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.SkipBackward : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SkipForward SkipForward
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.SkipForward)
			{
				return null;
			}
			return (Types.SkipForward)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.SkipForward : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GoToEnd GoToEnd
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GoToEnd)
			{
				return null;
			}
			return (Types.GoToEnd)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GoToEnd : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetTime GetTime
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetTime)
			{
				return null;
			}
			return (Types.GetTime)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetTime : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutTime PutTime
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PutTime)
			{
				return null;
			}
			return (Types.PutTime)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PutTime : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetAutoAdvance GetAutoAdvance
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetAutoAdvance)
			{
				return null;
			}
			return (Types.GetAutoAdvance)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetAutoAdvance : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DeleteAutoAdvance DeleteAutoAdvance
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.DeleteAutoAdvance)
			{
				return null;
			}
			return (Types.DeleteAutoAdvance)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.DeleteAutoAdvance : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetCurrentMedia GetCurrentMedia
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetCurrentMedia)
			{
				return null;
			}
			return (Types.GetCurrentMedia)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetCurrentMedia : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResponseOneofCase ResponseCase => responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Transport_Response()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Transport_Response(API_v1_Transport_Response other)
		: this()
	{
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.Play:
			Play = other.Play.Clone();
			break;
		case ResponseOneofCase.Pause:
			Pause = other.Pause.Clone();
			break;
		case ResponseOneofCase.SkipBackward:
			SkipBackward = other.SkipBackward.Clone();
			break;
		case ResponseOneofCase.SkipForward:
			SkipForward = other.SkipForward.Clone();
			break;
		case ResponseOneofCase.GoToEnd:
			GoToEnd = other.GoToEnd.Clone();
			break;
		case ResponseOneofCase.GetTime:
			GetTime = other.GetTime.Clone();
			break;
		case ResponseOneofCase.PutTime:
			PutTime = other.PutTime.Clone();
			break;
		case ResponseOneofCase.GetAutoAdvance:
			GetAutoAdvance = other.GetAutoAdvance.Clone();
			break;
		case ResponseOneofCase.DeleteAutoAdvance:
			DeleteAutoAdvance = other.DeleteAutoAdvance.Clone();
			break;
		case ResponseOneofCase.GetCurrentMedia:
			GetCurrentMedia = other.GetCurrentMedia.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Transport_Response Clone()
	{
		return new API_v1_Transport_Response(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearResponse()
	{
		responseCase_ = ResponseOneofCase.None;
		response_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_Transport_Response);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Transport_Response other)
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
		if (!object.Equals(SkipBackward, other.SkipBackward))
		{
			return false;
		}
		if (!object.Equals(SkipForward, other.SkipForward))
		{
			return false;
		}
		if (!object.Equals(GoToEnd, other.GoToEnd))
		{
			return false;
		}
		if (!object.Equals(GetTime, other.GetTime))
		{
			return false;
		}
		if (!object.Equals(PutTime, other.PutTime))
		{
			return false;
		}
		if (!object.Equals(GetAutoAdvance, other.GetAutoAdvance))
		{
			return false;
		}
		if (!object.Equals(DeleteAutoAdvance, other.DeleteAutoAdvance))
		{
			return false;
		}
		if (!object.Equals(GetCurrentMedia, other.GetCurrentMedia))
		{
			return false;
		}
		if (ResponseCase != other.ResponseCase)
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
		if (responseCase_ == ResponseOneofCase.Play)
		{
			num ^= Play.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.Pause)
		{
			num ^= Pause.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.SkipBackward)
		{
			num ^= SkipBackward.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.SkipForward)
		{
			num ^= SkipForward.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GoToEnd)
		{
			num ^= GoToEnd.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetTime)
		{
			num ^= GetTime.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PutTime)
		{
			num ^= PutTime.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetAutoAdvance)
		{
			num ^= GetAutoAdvance.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.DeleteAutoAdvance)
		{
			num ^= DeleteAutoAdvance.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetCurrentMedia)
		{
			num ^= GetCurrentMedia.GetHashCode();
		}
		num ^= (int)responseCase_;
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
		if (responseCase_ == ResponseOneofCase.Play)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Play);
		}
		if (responseCase_ == ResponseOneofCase.Pause)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Pause);
		}
		if (responseCase_ == ResponseOneofCase.SkipBackward)
		{
			output.WriteRawTag(26);
			output.WriteMessage(SkipBackward);
		}
		if (responseCase_ == ResponseOneofCase.SkipForward)
		{
			output.WriteRawTag(34);
			output.WriteMessage(SkipForward);
		}
		if (responseCase_ == ResponseOneofCase.GoToEnd)
		{
			output.WriteRawTag(42);
			output.WriteMessage(GoToEnd);
		}
		if (responseCase_ == ResponseOneofCase.GetTime)
		{
			output.WriteRawTag(50);
			output.WriteMessage(GetTime);
		}
		if (responseCase_ == ResponseOneofCase.PutTime)
		{
			output.WriteRawTag(58);
			output.WriteMessage(PutTime);
		}
		if (responseCase_ == ResponseOneofCase.GetAutoAdvance)
		{
			output.WriteRawTag(66);
			output.WriteMessage(GetAutoAdvance);
		}
		if (responseCase_ == ResponseOneofCase.DeleteAutoAdvance)
		{
			output.WriteRawTag(74);
			output.WriteMessage(DeleteAutoAdvance);
		}
		if (responseCase_ == ResponseOneofCase.GetCurrentMedia)
		{
			output.WriteRawTag(82);
			output.WriteMessage(GetCurrentMedia);
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
		if (responseCase_ == ResponseOneofCase.Play)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Play);
		}
		if (responseCase_ == ResponseOneofCase.Pause)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Pause);
		}
		if (responseCase_ == ResponseOneofCase.SkipBackward)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SkipBackward);
		}
		if (responseCase_ == ResponseOneofCase.SkipForward)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SkipForward);
		}
		if (responseCase_ == ResponseOneofCase.GoToEnd)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GoToEnd);
		}
		if (responseCase_ == ResponseOneofCase.GetTime)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetTime);
		}
		if (responseCase_ == ResponseOneofCase.PutTime)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutTime);
		}
		if (responseCase_ == ResponseOneofCase.GetAutoAdvance)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetAutoAdvance);
		}
		if (responseCase_ == ResponseOneofCase.DeleteAutoAdvance)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DeleteAutoAdvance);
		}
		if (responseCase_ == ResponseOneofCase.GetCurrentMedia)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetCurrentMedia);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Transport_Response other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.Play:
			if (Play == null)
			{
				Play = new Types.Play();
			}
			Play.MergeFrom(other.Play);
			break;
		case ResponseOneofCase.Pause:
			if (Pause == null)
			{
				Pause = new Types.Pause();
			}
			Pause.MergeFrom(other.Pause);
			break;
		case ResponseOneofCase.SkipBackward:
			if (SkipBackward == null)
			{
				SkipBackward = new Types.SkipBackward();
			}
			SkipBackward.MergeFrom(other.SkipBackward);
			break;
		case ResponseOneofCase.SkipForward:
			if (SkipForward == null)
			{
				SkipForward = new Types.SkipForward();
			}
			SkipForward.MergeFrom(other.SkipForward);
			break;
		case ResponseOneofCase.GoToEnd:
			if (GoToEnd == null)
			{
				GoToEnd = new Types.GoToEnd();
			}
			GoToEnd.MergeFrom(other.GoToEnd);
			break;
		case ResponseOneofCase.GetTime:
			if (GetTime == null)
			{
				GetTime = new Types.GetTime();
			}
			GetTime.MergeFrom(other.GetTime);
			break;
		case ResponseOneofCase.PutTime:
			if (PutTime == null)
			{
				PutTime = new Types.PutTime();
			}
			PutTime.MergeFrom(other.PutTime);
			break;
		case ResponseOneofCase.GetAutoAdvance:
			if (GetAutoAdvance == null)
			{
				GetAutoAdvance = new Types.GetAutoAdvance();
			}
			GetAutoAdvance.MergeFrom(other.GetAutoAdvance);
			break;
		case ResponseOneofCase.DeleteAutoAdvance:
			if (DeleteAutoAdvance == null)
			{
				DeleteAutoAdvance = new Types.DeleteAutoAdvance();
			}
			DeleteAutoAdvance.MergeFrom(other.DeleteAutoAdvance);
			break;
		case ResponseOneofCase.GetCurrentMedia:
			if (GetCurrentMedia == null)
			{
				GetCurrentMedia = new Types.GetCurrentMedia();
			}
			GetCurrentMedia.MergeFrom(other.GetCurrentMedia);
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
				Types.Play play = new Types.Play();
				if (responseCase_ == ResponseOneofCase.Play)
				{
					play.MergeFrom(Play);
				}
				input.ReadMessage(play);
				Play = play;
				break;
			}
			case 18u:
			{
				Types.Pause pause = new Types.Pause();
				if (responseCase_ == ResponseOneofCase.Pause)
				{
					pause.MergeFrom(Pause);
				}
				input.ReadMessage(pause);
				Pause = pause;
				break;
			}
			case 26u:
			{
				Types.SkipBackward skipBackward = new Types.SkipBackward();
				if (responseCase_ == ResponseOneofCase.SkipBackward)
				{
					skipBackward.MergeFrom(SkipBackward);
				}
				input.ReadMessage(skipBackward);
				SkipBackward = skipBackward;
				break;
			}
			case 34u:
			{
				Types.SkipForward skipForward = new Types.SkipForward();
				if (responseCase_ == ResponseOneofCase.SkipForward)
				{
					skipForward.MergeFrom(SkipForward);
				}
				input.ReadMessage(skipForward);
				SkipForward = skipForward;
				break;
			}
			case 42u:
			{
				Types.GoToEnd goToEnd = new Types.GoToEnd();
				if (responseCase_ == ResponseOneofCase.GoToEnd)
				{
					goToEnd.MergeFrom(GoToEnd);
				}
				input.ReadMessage(goToEnd);
				GoToEnd = goToEnd;
				break;
			}
			case 50u:
			{
				Types.GetTime getTime = new Types.GetTime();
				if (responseCase_ == ResponseOneofCase.GetTime)
				{
					getTime.MergeFrom(GetTime);
				}
				input.ReadMessage(getTime);
				GetTime = getTime;
				break;
			}
			case 58u:
			{
				Types.PutTime putTime = new Types.PutTime();
				if (responseCase_ == ResponseOneofCase.PutTime)
				{
					putTime.MergeFrom(PutTime);
				}
				input.ReadMessage(putTime);
				PutTime = putTime;
				break;
			}
			case 66u:
			{
				Types.GetAutoAdvance getAutoAdvance = new Types.GetAutoAdvance();
				if (responseCase_ == ResponseOneofCase.GetAutoAdvance)
				{
					getAutoAdvance.MergeFrom(GetAutoAdvance);
				}
				input.ReadMessage(getAutoAdvance);
				GetAutoAdvance = getAutoAdvance;
				break;
			}
			case 74u:
			{
				Types.DeleteAutoAdvance deleteAutoAdvance = new Types.DeleteAutoAdvance();
				if (responseCase_ == ResponseOneofCase.DeleteAutoAdvance)
				{
					deleteAutoAdvance.MergeFrom(DeleteAutoAdvance);
				}
				input.ReadMessage(deleteAutoAdvance);
				DeleteAutoAdvance = deleteAutoAdvance;
				break;
			}
			case 82u:
			{
				Types.GetCurrentMedia getCurrentMedia = new Types.GetCurrentMedia();
				if (responseCase_ == ResponseOneofCase.GetCurrentMedia)
				{
					getCurrentMedia.MergeFrom(GetCurrentMedia);
				}
				input.ReadMessage(getCurrentMedia);
				GetCurrentMedia = getCurrentMedia;
				break;
			}
			}
		}
	}
}
