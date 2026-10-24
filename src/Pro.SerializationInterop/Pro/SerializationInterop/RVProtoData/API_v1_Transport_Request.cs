using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Transport_Request : IMessage<API_v1_Transport_Request>, IMessage, IEquatable<API_v1_Transport_Request>, IDeepCloneable<API_v1_Transport_Request>
{
	public enum RequestOneofCase
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

			public const int LayerFieldNumber = 1;

			private API_v1_LayerType layer_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Play> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Transport_Request.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_LayerType Layer
			{
				get
				{
					return layer_;
				}
				set
				{
					layer_ = value;
				}
			}

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
				layer_ = other.layer_;
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
				if (Layer != other.Layer)
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
				if (Layer != 0)
				{
					num ^= Layer.GetHashCode();
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
				if (Layer != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Layer);
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
				if (Layer != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Layer);
				}
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
					if (other.Layer != 0)
					{
						Layer = other.Layer;
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
						Layer = (API_v1_LayerType)input.ReadEnum();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Pause : IMessage<Pause>, IMessage, IEquatable<Pause>, IDeepCloneable<Pause>
		{
			private static readonly MessageParser<Pause> _parser = new MessageParser<Pause>(() => new Pause());

			private UnknownFieldSet _unknownFields;

			public const int LayerFieldNumber = 1;

			private API_v1_LayerType layer_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Pause> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Transport_Request.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_LayerType Layer
			{
				get
				{
					return layer_;
				}
				set
				{
					layer_ = value;
				}
			}

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
				layer_ = other.layer_;
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
				if (Layer != other.Layer)
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
				if (Layer != 0)
				{
					num ^= Layer.GetHashCode();
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
				if (Layer != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Layer);
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
				if (Layer != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Layer);
				}
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
					if (other.Layer != 0)
					{
						Layer = other.Layer;
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
						Layer = (API_v1_LayerType)input.ReadEnum();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class SkipBackward : IMessage<SkipBackward>, IMessage, IEquatable<SkipBackward>, IDeepCloneable<SkipBackward>
		{
			private static readonly MessageParser<SkipBackward> _parser = new MessageParser<SkipBackward>(() => new SkipBackward());

			private UnknownFieldSet _unknownFields;

			public const int LayerFieldNumber = 1;

			private API_v1_LayerType layer_;

			public const int SecondsFieldNumber = 2;

			private double seconds_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SkipBackward> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Transport_Request.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_LayerType Layer
			{
				get
				{
					return layer_;
				}
				set
				{
					layer_ = value;
				}
			}

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
			public SkipBackward()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SkipBackward(SkipBackward other)
				: this()
			{
				layer_ = other.layer_;
				seconds_ = other.seconds_;
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
				if (Layer != other.Layer)
				{
					return false;
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
				if (Layer != 0)
				{
					num ^= Layer.GetHashCode();
				}
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
				if (Layer != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Layer);
				}
				if (Seconds != 0.0)
				{
					output.WriteRawTag(17);
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
				if (Layer != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Layer);
				}
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
			public void MergeFrom(SkipBackward other)
			{
				if (other != null)
				{
					if (other.Layer != 0)
					{
						Layer = other.Layer;
					}
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
					switch (num)
					{
					default:
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						break;
					case 8u:
						Layer = (API_v1_LayerType)input.ReadEnum();
						break;
					case 17u:
						Seconds = input.ReadDouble();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class SkipForward : IMessage<SkipForward>, IMessage, IEquatable<SkipForward>, IDeepCloneable<SkipForward>
		{
			private static readonly MessageParser<SkipForward> _parser = new MessageParser<SkipForward>(() => new SkipForward());

			private UnknownFieldSet _unknownFields;

			public const int LayerFieldNumber = 1;

			private API_v1_LayerType layer_;

			public const int SecondsFieldNumber = 2;

			private double seconds_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SkipForward> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Transport_Request.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_LayerType Layer
			{
				get
				{
					return layer_;
				}
				set
				{
					layer_ = value;
				}
			}

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
			public SkipForward()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SkipForward(SkipForward other)
				: this()
			{
				layer_ = other.layer_;
				seconds_ = other.seconds_;
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
				if (Layer != other.Layer)
				{
					return false;
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
				if (Layer != 0)
				{
					num ^= Layer.GetHashCode();
				}
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
				if (Layer != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Layer);
				}
				if (Seconds != 0.0)
				{
					output.WriteRawTag(17);
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
				if (Layer != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Layer);
				}
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
			public void MergeFrom(SkipForward other)
			{
				if (other != null)
				{
					if (other.Layer != 0)
					{
						Layer = other.Layer;
					}
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
					switch (num)
					{
					default:
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						break;
					case 8u:
						Layer = (API_v1_LayerType)input.ReadEnum();
						break;
					case 17u:
						Seconds = input.ReadDouble();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GoToEnd : IMessage<GoToEnd>, IMessage, IEquatable<GoToEnd>, IDeepCloneable<GoToEnd>
		{
			private static readonly MessageParser<GoToEnd> _parser = new MessageParser<GoToEnd>(() => new GoToEnd());

			private UnknownFieldSet _unknownFields;

			public const int LayerFieldNumber = 1;

			private API_v1_LayerType layer_;

			public const int SecondsFieldNumber = 2;

			private double seconds_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GoToEnd> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Transport_Request.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_LayerType Layer
			{
				get
				{
					return layer_;
				}
				set
				{
					layer_ = value;
				}
			}

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
			public GoToEnd()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GoToEnd(GoToEnd other)
				: this()
			{
				layer_ = other.layer_;
				seconds_ = other.seconds_;
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
				if (Layer != other.Layer)
				{
					return false;
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
				if (Layer != 0)
				{
					num ^= Layer.GetHashCode();
				}
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
				if (Layer != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Layer);
				}
				if (Seconds != 0.0)
				{
					output.WriteRawTag(17);
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
				if (Layer != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Layer);
				}
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
			public void MergeFrom(GoToEnd other)
			{
				if (other != null)
				{
					if (other.Layer != 0)
					{
						Layer = other.Layer;
					}
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
					switch (num)
					{
					default:
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						break;
					case 8u:
						Layer = (API_v1_LayerType)input.ReadEnum();
						break;
					case 17u:
						Seconds = input.ReadDouble();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetTime : IMessage<GetTime>, IMessage, IEquatable<GetTime>, IDeepCloneable<GetTime>
		{
			private static readonly MessageParser<GetTime> _parser = new MessageParser<GetTime>(() => new GetTime());

			private UnknownFieldSet _unknownFields;

			public const int LayerFieldNumber = 1;

			private API_v1_LayerType layer_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetTime> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Transport_Request.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_LayerType Layer
			{
				get
				{
					return layer_;
				}
				set
				{
					layer_ = value;
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
				layer_ = other.layer_;
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
				if (Layer != other.Layer)
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
				if (Layer != 0)
				{
					num ^= Layer.GetHashCode();
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
				if (Layer != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Layer);
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
				if (Layer != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Layer);
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
					if (other.Layer != 0)
					{
						Layer = other.Layer;
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
						Layer = (API_v1_LayerType)input.ReadEnum();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PutTime : IMessage<PutTime>, IMessage, IEquatable<PutTime>, IDeepCloneable<PutTime>
		{
			private static readonly MessageParser<PutTime> _parser = new MessageParser<PutTime>(() => new PutTime());

			private UnknownFieldSet _unknownFields;

			public const int LayerFieldNumber = 1;

			private API_v1_LayerType layer_;

			public const int SecondsFieldNumber = 2;

			private double seconds_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutTime> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Transport_Request.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_LayerType Layer
			{
				get
				{
					return layer_;
				}
				set
				{
					layer_ = value;
				}
			}

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
			public PutTime()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutTime(PutTime other)
				: this()
			{
				layer_ = other.layer_;
				seconds_ = other.seconds_;
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
				if (Layer != other.Layer)
				{
					return false;
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
				if (Layer != 0)
				{
					num ^= Layer.GetHashCode();
				}
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
				if (Layer != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Layer);
				}
				if (Seconds != 0.0)
				{
					output.WriteRawTag(17);
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
				if (Layer != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Layer);
				}
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
			public void MergeFrom(PutTime other)
			{
				if (other != null)
				{
					if (other.Layer != 0)
					{
						Layer = other.Layer;
					}
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
					switch (num)
					{
					default:
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						break;
					case 8u:
						Layer = (API_v1_LayerType)input.ReadEnum();
						break;
					case 17u:
						Seconds = input.ReadDouble();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetAutoAdvance : IMessage<GetAutoAdvance>, IMessage, IEquatable<GetAutoAdvance>, IDeepCloneable<GetAutoAdvance>
		{
			private static readonly MessageParser<GetAutoAdvance> _parser = new MessageParser<GetAutoAdvance>(() => new GetAutoAdvance());

			private UnknownFieldSet _unknownFields;

			public const int LayerFieldNumber = 1;

			private API_v1_LayerType layer_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetAutoAdvance> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Transport_Request.Descriptor.NestedTypes[7];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_LayerType Layer
			{
				get
				{
					return layer_;
				}
				set
				{
					layer_ = value;
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
				layer_ = other.layer_;
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
				if (Layer != other.Layer)
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
				if (Layer != 0)
				{
					num ^= Layer.GetHashCode();
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
				if (Layer != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Layer);
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
				if (Layer != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Layer);
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
					if (other.Layer != 0)
					{
						Layer = other.Layer;
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
						Layer = (API_v1_LayerType)input.ReadEnum();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class DeleteAutoAdvance : IMessage<DeleteAutoAdvance>, IMessage, IEquatable<DeleteAutoAdvance>, IDeepCloneable<DeleteAutoAdvance>
		{
			private static readonly MessageParser<DeleteAutoAdvance> _parser = new MessageParser<DeleteAutoAdvance>(() => new DeleteAutoAdvance());

			private UnknownFieldSet _unknownFields;

			public const int LayerFieldNumber = 1;

			private API_v1_LayerType layer_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DeleteAutoAdvance> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Transport_Request.Descriptor.NestedTypes[8];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_LayerType Layer
			{
				get
				{
					return layer_;
				}
				set
				{
					layer_ = value;
				}
			}

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
				layer_ = other.layer_;
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
				if (Layer != other.Layer)
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
				if (Layer != 0)
				{
					num ^= Layer.GetHashCode();
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
				if (Layer != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Layer);
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
				if (Layer != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Layer);
				}
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
					if (other.Layer != 0)
					{
						Layer = other.Layer;
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
						Layer = (API_v1_LayerType)input.ReadEnum();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetCurrentMedia : IMessage<GetCurrentMedia>, IMessage, IEquatable<GetCurrentMedia>, IDeepCloneable<GetCurrentMedia>
		{
			private static readonly MessageParser<GetCurrentMedia> _parser = new MessageParser<GetCurrentMedia>(() => new GetCurrentMedia());

			private UnknownFieldSet _unknownFields;

			public const int LayerFieldNumber = 1;

			private API_v1_LayerType layer_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetCurrentMedia> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Transport_Request.Descriptor.NestedTypes[9];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_LayerType Layer
			{
				get
				{
					return layer_;
				}
				set
				{
					layer_ = value;
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
				layer_ = other.layer_;
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
				if (Layer != other.Layer)
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
				if (Layer != 0)
				{
					num ^= Layer.GetHashCode();
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
				if (Layer != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Layer);
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
				if (Layer != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Layer);
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
					if (other.Layer != 0)
					{
						Layer = other.Layer;
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
						Layer = (API_v1_LayerType)input.ReadEnum();
					}
				}
			}
		}
	}

	private static readonly MessageParser<API_v1_Transport_Request> _parser = new MessageParser<API_v1_Transport_Request>(() => new API_v1_Transport_Request());

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

	private object request_;

	private RequestOneofCase requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Transport_Request> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1TransportReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Play Play
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Play)
			{
				return null;
			}
			return (Types.Play)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Play : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Pause Pause
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Pause)
			{
				return null;
			}
			return (Types.Pause)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Pause : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SkipBackward SkipBackward
	{
		get
		{
			if (requestCase_ != RequestOneofCase.SkipBackward)
			{
				return null;
			}
			return (Types.SkipBackward)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.SkipBackward : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SkipForward SkipForward
	{
		get
		{
			if (requestCase_ != RequestOneofCase.SkipForward)
			{
				return null;
			}
			return (Types.SkipForward)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.SkipForward : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GoToEnd GoToEnd
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GoToEnd)
			{
				return null;
			}
			return (Types.GoToEnd)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GoToEnd : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetTime GetTime
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetTime)
			{
				return null;
			}
			return (Types.GetTime)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetTime : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutTime PutTime
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PutTime)
			{
				return null;
			}
			return (Types.PutTime)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PutTime : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetAutoAdvance GetAutoAdvance
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetAutoAdvance)
			{
				return null;
			}
			return (Types.GetAutoAdvance)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetAutoAdvance : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DeleteAutoAdvance DeleteAutoAdvance
	{
		get
		{
			if (requestCase_ != RequestOneofCase.DeleteAutoAdvance)
			{
				return null;
			}
			return (Types.DeleteAutoAdvance)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.DeleteAutoAdvance : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetCurrentMedia GetCurrentMedia
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetCurrentMedia)
			{
				return null;
			}
			return (Types.GetCurrentMedia)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetCurrentMedia : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestOneofCase RequestCase => requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Transport_Request()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Transport_Request(API_v1_Transport_Request other)
		: this()
	{
		switch (other.RequestCase)
		{
		case RequestOneofCase.Play:
			Play = other.Play.Clone();
			break;
		case RequestOneofCase.Pause:
			Pause = other.Pause.Clone();
			break;
		case RequestOneofCase.SkipBackward:
			SkipBackward = other.SkipBackward.Clone();
			break;
		case RequestOneofCase.SkipForward:
			SkipForward = other.SkipForward.Clone();
			break;
		case RequestOneofCase.GoToEnd:
			GoToEnd = other.GoToEnd.Clone();
			break;
		case RequestOneofCase.GetTime:
			GetTime = other.GetTime.Clone();
			break;
		case RequestOneofCase.PutTime:
			PutTime = other.PutTime.Clone();
			break;
		case RequestOneofCase.GetAutoAdvance:
			GetAutoAdvance = other.GetAutoAdvance.Clone();
			break;
		case RequestOneofCase.DeleteAutoAdvance:
			DeleteAutoAdvance = other.DeleteAutoAdvance.Clone();
			break;
		case RequestOneofCase.GetCurrentMedia:
			GetCurrentMedia = other.GetCurrentMedia.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Transport_Request Clone()
	{
		return new API_v1_Transport_Request(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearRequest()
	{
		requestCase_ = RequestOneofCase.None;
		request_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as API_v1_Transport_Request);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Transport_Request other)
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
		if (RequestCase != other.RequestCase)
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
		if (requestCase_ == RequestOneofCase.Play)
		{
			num ^= Play.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Pause)
		{
			num ^= Pause.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.SkipBackward)
		{
			num ^= SkipBackward.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.SkipForward)
		{
			num ^= SkipForward.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GoToEnd)
		{
			num ^= GoToEnd.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetTime)
		{
			num ^= GetTime.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PutTime)
		{
			num ^= PutTime.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetAutoAdvance)
		{
			num ^= GetAutoAdvance.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.DeleteAutoAdvance)
		{
			num ^= DeleteAutoAdvance.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetCurrentMedia)
		{
			num ^= GetCurrentMedia.GetHashCode();
		}
		num ^= (int)requestCase_;
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
		if (requestCase_ == RequestOneofCase.Play)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Play);
		}
		if (requestCase_ == RequestOneofCase.Pause)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Pause);
		}
		if (requestCase_ == RequestOneofCase.SkipBackward)
		{
			output.WriteRawTag(26);
			output.WriteMessage(SkipBackward);
		}
		if (requestCase_ == RequestOneofCase.SkipForward)
		{
			output.WriteRawTag(34);
			output.WriteMessage(SkipForward);
		}
		if (requestCase_ == RequestOneofCase.GoToEnd)
		{
			output.WriteRawTag(42);
			output.WriteMessage(GoToEnd);
		}
		if (requestCase_ == RequestOneofCase.GetTime)
		{
			output.WriteRawTag(50);
			output.WriteMessage(GetTime);
		}
		if (requestCase_ == RequestOneofCase.PutTime)
		{
			output.WriteRawTag(58);
			output.WriteMessage(PutTime);
		}
		if (requestCase_ == RequestOneofCase.GetAutoAdvance)
		{
			output.WriteRawTag(66);
			output.WriteMessage(GetAutoAdvance);
		}
		if (requestCase_ == RequestOneofCase.DeleteAutoAdvance)
		{
			output.WriteRawTag(74);
			output.WriteMessage(DeleteAutoAdvance);
		}
		if (requestCase_ == RequestOneofCase.GetCurrentMedia)
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
		if (requestCase_ == RequestOneofCase.Play)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Play);
		}
		if (requestCase_ == RequestOneofCase.Pause)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Pause);
		}
		if (requestCase_ == RequestOneofCase.SkipBackward)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SkipBackward);
		}
		if (requestCase_ == RequestOneofCase.SkipForward)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SkipForward);
		}
		if (requestCase_ == RequestOneofCase.GoToEnd)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GoToEnd);
		}
		if (requestCase_ == RequestOneofCase.GetTime)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetTime);
		}
		if (requestCase_ == RequestOneofCase.PutTime)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutTime);
		}
		if (requestCase_ == RequestOneofCase.GetAutoAdvance)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetAutoAdvance);
		}
		if (requestCase_ == RequestOneofCase.DeleteAutoAdvance)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DeleteAutoAdvance);
		}
		if (requestCase_ == RequestOneofCase.GetCurrentMedia)
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
	public void MergeFrom(API_v1_Transport_Request other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.RequestCase)
		{
		case RequestOneofCase.Play:
			if (Play == null)
			{
				Play = new Types.Play();
			}
			Play.MergeFrom(other.Play);
			break;
		case RequestOneofCase.Pause:
			if (Pause == null)
			{
				Pause = new Types.Pause();
			}
			Pause.MergeFrom(other.Pause);
			break;
		case RequestOneofCase.SkipBackward:
			if (SkipBackward == null)
			{
				SkipBackward = new Types.SkipBackward();
			}
			SkipBackward.MergeFrom(other.SkipBackward);
			break;
		case RequestOneofCase.SkipForward:
			if (SkipForward == null)
			{
				SkipForward = new Types.SkipForward();
			}
			SkipForward.MergeFrom(other.SkipForward);
			break;
		case RequestOneofCase.GoToEnd:
			if (GoToEnd == null)
			{
				GoToEnd = new Types.GoToEnd();
			}
			GoToEnd.MergeFrom(other.GoToEnd);
			break;
		case RequestOneofCase.GetTime:
			if (GetTime == null)
			{
				GetTime = new Types.GetTime();
			}
			GetTime.MergeFrom(other.GetTime);
			break;
		case RequestOneofCase.PutTime:
			if (PutTime == null)
			{
				PutTime = new Types.PutTime();
			}
			PutTime.MergeFrom(other.PutTime);
			break;
		case RequestOneofCase.GetAutoAdvance:
			if (GetAutoAdvance == null)
			{
				GetAutoAdvance = new Types.GetAutoAdvance();
			}
			GetAutoAdvance.MergeFrom(other.GetAutoAdvance);
			break;
		case RequestOneofCase.DeleteAutoAdvance:
			if (DeleteAutoAdvance == null)
			{
				DeleteAutoAdvance = new Types.DeleteAutoAdvance();
			}
			DeleteAutoAdvance.MergeFrom(other.DeleteAutoAdvance);
			break;
		case RequestOneofCase.GetCurrentMedia:
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
				if (requestCase_ == RequestOneofCase.Play)
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
				if (requestCase_ == RequestOneofCase.Pause)
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
				if (requestCase_ == RequestOneofCase.SkipBackward)
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
				if (requestCase_ == RequestOneofCase.SkipForward)
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
				if (requestCase_ == RequestOneofCase.GoToEnd)
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
				if (requestCase_ == RequestOneofCase.GetTime)
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
				if (requestCase_ == RequestOneofCase.PutTime)
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
				if (requestCase_ == RequestOneofCase.GetAutoAdvance)
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
				if (requestCase_ == RequestOneofCase.DeleteAutoAdvance)
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
				if (requestCase_ == RequestOneofCase.GetCurrentMedia)
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
