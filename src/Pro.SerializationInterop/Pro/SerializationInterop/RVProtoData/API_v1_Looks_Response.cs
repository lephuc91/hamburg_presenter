using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Looks_Response : IMessage<API_v1_Looks_Response>, IMessage, IEquatable<API_v1_Looks_Response>, IDeepCloneable<API_v1_Looks_Response>
{
	public enum ResponseOneofCase
	{
		None,
		Looks,
		CreateLook,
		GetCurrentLook,
		PutCurrentLook,
		GetLook,
		PutLook,
		DeleteLook,
		TriggerLook
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Looks : IMessage<Looks>, IMessage, IEquatable<Looks>, IDeepCloneable<Looks>
		{
			private static readonly MessageParser<Looks> _parser = new MessageParser<Looks>(() => new Looks());

			private UnknownFieldSet _unknownFields;

			public const int Looks_FieldNumber = 1;

			private static readonly FieldCodec<API_v1_Look> _repeated_looks_codec = FieldCodec.ForMessage(10u, API_v1_Look.Parser);

			private readonly RepeatedField<API_v1_Look> looks_ = new RepeatedField<API_v1_Look>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Looks> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Looks_Response.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<API_v1_Look> Looks_ => looks_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Looks()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Looks(Looks other)
				: this()
			{
				looks_ = other.looks_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Looks Clone()
			{
				return new Looks(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Looks);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Looks other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!looks_.Equals(other.looks_))
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
				num ^= looks_.GetHashCode();
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
				looks_.WriteTo(output, _repeated_looks_codec);
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
				num += looks_.CalculateSize(_repeated_looks_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Looks other)
			{
				if (other != null)
				{
					looks_.Add(other.looks_);
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
						looks_.AddEntriesFrom(input, _repeated_looks_codec);
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class CreateLook : IMessage<CreateLook>, IMessage, IEquatable<CreateLook>, IDeepCloneable<CreateLook>
		{
			private static readonly MessageParser<CreateLook> _parser = new MessageParser<CreateLook>(() => new CreateLook());

			private UnknownFieldSet _unknownFields;

			public const int LookFieldNumber = 1;

			private API_v1_Look look_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<CreateLook> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Looks_Response.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Look Look
			{
				get
				{
					return look_;
				}
				set
				{
					look_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CreateLook()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CreateLook(CreateLook other)
				: this()
			{
				look_ = ((other.look_ != null) ? other.look_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CreateLook Clone()
			{
				return new CreateLook(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as CreateLook);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(CreateLook other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Look, other.Look))
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
				if (look_ != null)
				{
					num ^= Look.GetHashCode();
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
				if (look_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Look);
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
				if (look_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Look);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(CreateLook other)
			{
				if (other == null)
				{
					return;
				}
				if (other.look_ != null)
				{
					if (look_ == null)
					{
						Look = new API_v1_Look();
					}
					Look.MergeFrom(other.Look);
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
					if (look_ == null)
					{
						Look = new API_v1_Look();
					}
					input.ReadMessage(Look);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetCurrentLook : IMessage<GetCurrentLook>, IMessage, IEquatable<GetCurrentLook>, IDeepCloneable<GetCurrentLook>
		{
			private static readonly MessageParser<GetCurrentLook> _parser = new MessageParser<GetCurrentLook>(() => new GetCurrentLook());

			private UnknownFieldSet _unknownFields;

			public const int LookFieldNumber = 1;

			private API_v1_Look look_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetCurrentLook> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Looks_Response.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Look Look
			{
				get
				{
					return look_;
				}
				set
				{
					look_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetCurrentLook()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetCurrentLook(GetCurrentLook other)
				: this()
			{
				look_ = ((other.look_ != null) ? other.look_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetCurrentLook Clone()
			{
				return new GetCurrentLook(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetCurrentLook);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetCurrentLook other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Look, other.Look))
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
				if (look_ != null)
				{
					num ^= Look.GetHashCode();
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
				if (look_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Look);
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
				if (look_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Look);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetCurrentLook other)
			{
				if (other == null)
				{
					return;
				}
				if (other.look_ != null)
				{
					if (look_ == null)
					{
						Look = new API_v1_Look();
					}
					Look.MergeFrom(other.Look);
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
					if (look_ == null)
					{
						Look = new API_v1_Look();
					}
					input.ReadMessage(Look);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PutCurrentLook : IMessage<PutCurrentLook>, IMessage, IEquatable<PutCurrentLook>, IDeepCloneable<PutCurrentLook>
		{
			private static readonly MessageParser<PutCurrentLook> _parser = new MessageParser<PutCurrentLook>(() => new PutCurrentLook());

			private UnknownFieldSet _unknownFields;

			public const int LookFieldNumber = 1;

			private API_v1_Look look_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutCurrentLook> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Looks_Response.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Look Look
			{
				get
				{
					return look_;
				}
				set
				{
					look_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutCurrentLook()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutCurrentLook(PutCurrentLook other)
				: this()
			{
				look_ = ((other.look_ != null) ? other.look_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutCurrentLook Clone()
			{
				return new PutCurrentLook(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PutCurrentLook);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PutCurrentLook other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Look, other.Look))
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
				if (look_ != null)
				{
					num ^= Look.GetHashCode();
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
				if (look_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Look);
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
				if (look_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Look);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PutCurrentLook other)
			{
				if (other == null)
				{
					return;
				}
				if (other.look_ != null)
				{
					if (look_ == null)
					{
						Look = new API_v1_Look();
					}
					Look.MergeFrom(other.Look);
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
					if (look_ == null)
					{
						Look = new API_v1_Look();
					}
					input.ReadMessage(Look);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetLook : IMessage<GetLook>, IMessage, IEquatable<GetLook>, IDeepCloneable<GetLook>
		{
			private static readonly MessageParser<GetLook> _parser = new MessageParser<GetLook>(() => new GetLook());

			private UnknownFieldSet _unknownFields;

			public const int LookFieldNumber = 1;

			private API_v1_Look look_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetLook> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Looks_Response.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Look Look
			{
				get
				{
					return look_;
				}
				set
				{
					look_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetLook()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetLook(GetLook other)
				: this()
			{
				look_ = ((other.look_ != null) ? other.look_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetLook Clone()
			{
				return new GetLook(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetLook);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetLook other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Look, other.Look))
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
				if (look_ != null)
				{
					num ^= Look.GetHashCode();
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
				if (look_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Look);
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
				if (look_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Look);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetLook other)
			{
				if (other == null)
				{
					return;
				}
				if (other.look_ != null)
				{
					if (look_ == null)
					{
						Look = new API_v1_Look();
					}
					Look.MergeFrom(other.Look);
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
					if (look_ == null)
					{
						Look = new API_v1_Look();
					}
					input.ReadMessage(Look);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PutLook : IMessage<PutLook>, IMessage, IEquatable<PutLook>, IDeepCloneable<PutLook>
		{
			private static readonly MessageParser<PutLook> _parser = new MessageParser<PutLook>(() => new PutLook());

			private UnknownFieldSet _unknownFields;

			public const int LookFieldNumber = 1;

			private API_v1_Look look_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutLook> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Looks_Response.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Look Look
			{
				get
				{
					return look_;
				}
				set
				{
					look_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutLook()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutLook(PutLook other)
				: this()
			{
				look_ = ((other.look_ != null) ? other.look_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutLook Clone()
			{
				return new PutLook(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PutLook);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PutLook other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Look, other.Look))
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
				if (look_ != null)
				{
					num ^= Look.GetHashCode();
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
				if (look_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Look);
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
				if (look_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Look);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PutLook other)
			{
				if (other == null)
				{
					return;
				}
				if (other.look_ != null)
				{
					if (look_ == null)
					{
						Look = new API_v1_Look();
					}
					Look.MergeFrom(other.Look);
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
					if (look_ == null)
					{
						Look = new API_v1_Look();
					}
					input.ReadMessage(Look);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class DeleteLook : IMessage<DeleteLook>, IMessage, IEquatable<DeleteLook>, IDeepCloneable<DeleteLook>
		{
			private static readonly MessageParser<DeleteLook> _parser = new MessageParser<DeleteLook>(() => new DeleteLook());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DeleteLook> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Looks_Response.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteLook()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteLook(DeleteLook other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteLook Clone()
			{
				return new DeleteLook(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as DeleteLook);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(DeleteLook other)
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
			public void MergeFrom(DeleteLook other)
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
		public sealed class TriggerLook : IMessage<TriggerLook>, IMessage, IEquatable<TriggerLook>, IDeepCloneable<TriggerLook>
		{
			private static readonly MessageParser<TriggerLook> _parser = new MessageParser<TriggerLook>(() => new TriggerLook());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TriggerLook> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Looks_Response.Descriptor.NestedTypes[7];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerLook()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerLook(TriggerLook other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerLook Clone()
			{
				return new TriggerLook(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TriggerLook);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TriggerLook other)
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
			public void MergeFrom(TriggerLook other)
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
	}

	private static readonly MessageParser<API_v1_Looks_Response> _parser = new MessageParser<API_v1_Looks_Response>(() => new API_v1_Looks_Response());

	private UnknownFieldSet _unknownFields;

	public const int LooksFieldNumber = 1;

	public const int CreateLookFieldNumber = 2;

	public const int GetCurrentLookFieldNumber = 3;

	public const int PutCurrentLookFieldNumber = 4;

	public const int GetLookFieldNumber = 5;

	public const int PutLookFieldNumber = 6;

	public const int DeleteLookFieldNumber = 7;

	public const int TriggerLookFieldNumber = 8;

	private object response_;

	private ResponseOneofCase responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Looks_Response> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1LooksReflection.Descriptor.MessageTypes[3];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Looks Looks
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Looks)
			{
				return null;
			}
			return (Types.Looks)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Looks : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.CreateLook CreateLook
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.CreateLook)
			{
				return null;
			}
			return (Types.CreateLook)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.CreateLook : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetCurrentLook GetCurrentLook
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetCurrentLook)
			{
				return null;
			}
			return (Types.GetCurrentLook)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetCurrentLook : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutCurrentLook PutCurrentLook
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PutCurrentLook)
			{
				return null;
			}
			return (Types.PutCurrentLook)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PutCurrentLook : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetLook GetLook
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetLook)
			{
				return null;
			}
			return (Types.GetLook)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetLook : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutLook PutLook
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PutLook)
			{
				return null;
			}
			return (Types.PutLook)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PutLook : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DeleteLook DeleteLook
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.DeleteLook)
			{
				return null;
			}
			return (Types.DeleteLook)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.DeleteLook : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TriggerLook TriggerLook
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.TriggerLook)
			{
				return null;
			}
			return (Types.TriggerLook)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.TriggerLook : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResponseOneofCase ResponseCase => responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Looks_Response()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Looks_Response(API_v1_Looks_Response other)
		: this()
	{
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.Looks:
			Looks = other.Looks.Clone();
			break;
		case ResponseOneofCase.CreateLook:
			CreateLook = other.CreateLook.Clone();
			break;
		case ResponseOneofCase.GetCurrentLook:
			GetCurrentLook = other.GetCurrentLook.Clone();
			break;
		case ResponseOneofCase.PutCurrentLook:
			PutCurrentLook = other.PutCurrentLook.Clone();
			break;
		case ResponseOneofCase.GetLook:
			GetLook = other.GetLook.Clone();
			break;
		case ResponseOneofCase.PutLook:
			PutLook = other.PutLook.Clone();
			break;
		case ResponseOneofCase.DeleteLook:
			DeleteLook = other.DeleteLook.Clone();
			break;
		case ResponseOneofCase.TriggerLook:
			TriggerLook = other.TriggerLook.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Looks_Response Clone()
	{
		return new API_v1_Looks_Response(this);
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
		return Equals(other as API_v1_Looks_Response);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Looks_Response other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Looks, other.Looks))
		{
			return false;
		}
		if (!object.Equals(CreateLook, other.CreateLook))
		{
			return false;
		}
		if (!object.Equals(GetCurrentLook, other.GetCurrentLook))
		{
			return false;
		}
		if (!object.Equals(PutCurrentLook, other.PutCurrentLook))
		{
			return false;
		}
		if (!object.Equals(GetLook, other.GetLook))
		{
			return false;
		}
		if (!object.Equals(PutLook, other.PutLook))
		{
			return false;
		}
		if (!object.Equals(DeleteLook, other.DeleteLook))
		{
			return false;
		}
		if (!object.Equals(TriggerLook, other.TriggerLook))
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
		if (responseCase_ == ResponseOneofCase.Looks)
		{
			num ^= Looks.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.CreateLook)
		{
			num ^= CreateLook.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetCurrentLook)
		{
			num ^= GetCurrentLook.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PutCurrentLook)
		{
			num ^= PutCurrentLook.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetLook)
		{
			num ^= GetLook.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PutLook)
		{
			num ^= PutLook.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.DeleteLook)
		{
			num ^= DeleteLook.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.TriggerLook)
		{
			num ^= TriggerLook.GetHashCode();
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
		if (responseCase_ == ResponseOneofCase.Looks)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Looks);
		}
		if (responseCase_ == ResponseOneofCase.CreateLook)
		{
			output.WriteRawTag(18);
			output.WriteMessage(CreateLook);
		}
		if (responseCase_ == ResponseOneofCase.GetCurrentLook)
		{
			output.WriteRawTag(26);
			output.WriteMessage(GetCurrentLook);
		}
		if (responseCase_ == ResponseOneofCase.PutCurrentLook)
		{
			output.WriteRawTag(34);
			output.WriteMessage(PutCurrentLook);
		}
		if (responseCase_ == ResponseOneofCase.GetLook)
		{
			output.WriteRawTag(42);
			output.WriteMessage(GetLook);
		}
		if (responseCase_ == ResponseOneofCase.PutLook)
		{
			output.WriteRawTag(50);
			output.WriteMessage(PutLook);
		}
		if (responseCase_ == ResponseOneofCase.DeleteLook)
		{
			output.WriteRawTag(58);
			output.WriteMessage(DeleteLook);
		}
		if (responseCase_ == ResponseOneofCase.TriggerLook)
		{
			output.WriteRawTag(66);
			output.WriteMessage(TriggerLook);
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
		if (responseCase_ == ResponseOneofCase.Looks)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Looks);
		}
		if (responseCase_ == ResponseOneofCase.CreateLook)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CreateLook);
		}
		if (responseCase_ == ResponseOneofCase.GetCurrentLook)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetCurrentLook);
		}
		if (responseCase_ == ResponseOneofCase.PutCurrentLook)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutCurrentLook);
		}
		if (responseCase_ == ResponseOneofCase.GetLook)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetLook);
		}
		if (responseCase_ == ResponseOneofCase.PutLook)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutLook);
		}
		if (responseCase_ == ResponseOneofCase.DeleteLook)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DeleteLook);
		}
		if (responseCase_ == ResponseOneofCase.TriggerLook)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TriggerLook);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Looks_Response other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.Looks:
			if (Looks == null)
			{
				Looks = new Types.Looks();
			}
			Looks.MergeFrom(other.Looks);
			break;
		case ResponseOneofCase.CreateLook:
			if (CreateLook == null)
			{
				CreateLook = new Types.CreateLook();
			}
			CreateLook.MergeFrom(other.CreateLook);
			break;
		case ResponseOneofCase.GetCurrentLook:
			if (GetCurrentLook == null)
			{
				GetCurrentLook = new Types.GetCurrentLook();
			}
			GetCurrentLook.MergeFrom(other.GetCurrentLook);
			break;
		case ResponseOneofCase.PutCurrentLook:
			if (PutCurrentLook == null)
			{
				PutCurrentLook = new Types.PutCurrentLook();
			}
			PutCurrentLook.MergeFrom(other.PutCurrentLook);
			break;
		case ResponseOneofCase.GetLook:
			if (GetLook == null)
			{
				GetLook = new Types.GetLook();
			}
			GetLook.MergeFrom(other.GetLook);
			break;
		case ResponseOneofCase.PutLook:
			if (PutLook == null)
			{
				PutLook = new Types.PutLook();
			}
			PutLook.MergeFrom(other.PutLook);
			break;
		case ResponseOneofCase.DeleteLook:
			if (DeleteLook == null)
			{
				DeleteLook = new Types.DeleteLook();
			}
			DeleteLook.MergeFrom(other.DeleteLook);
			break;
		case ResponseOneofCase.TriggerLook:
			if (TriggerLook == null)
			{
				TriggerLook = new Types.TriggerLook();
			}
			TriggerLook.MergeFrom(other.TriggerLook);
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
				Types.Looks looks = new Types.Looks();
				if (responseCase_ == ResponseOneofCase.Looks)
				{
					looks.MergeFrom(Looks);
				}
				input.ReadMessage(looks);
				Looks = looks;
				break;
			}
			case 18u:
			{
				Types.CreateLook createLook = new Types.CreateLook();
				if (responseCase_ == ResponseOneofCase.CreateLook)
				{
					createLook.MergeFrom(CreateLook);
				}
				input.ReadMessage(createLook);
				CreateLook = createLook;
				break;
			}
			case 26u:
			{
				Types.GetCurrentLook getCurrentLook = new Types.GetCurrentLook();
				if (responseCase_ == ResponseOneofCase.GetCurrentLook)
				{
					getCurrentLook.MergeFrom(GetCurrentLook);
				}
				input.ReadMessage(getCurrentLook);
				GetCurrentLook = getCurrentLook;
				break;
			}
			case 34u:
			{
				Types.PutCurrentLook putCurrentLook = new Types.PutCurrentLook();
				if (responseCase_ == ResponseOneofCase.PutCurrentLook)
				{
					putCurrentLook.MergeFrom(PutCurrentLook);
				}
				input.ReadMessage(putCurrentLook);
				PutCurrentLook = putCurrentLook;
				break;
			}
			case 42u:
			{
				Types.GetLook getLook = new Types.GetLook();
				if (responseCase_ == ResponseOneofCase.GetLook)
				{
					getLook.MergeFrom(GetLook);
				}
				input.ReadMessage(getLook);
				GetLook = getLook;
				break;
			}
			case 50u:
			{
				Types.PutLook putLook = new Types.PutLook();
				if (responseCase_ == ResponseOneofCase.PutLook)
				{
					putLook.MergeFrom(PutLook);
				}
				input.ReadMessage(putLook);
				PutLook = putLook;
				break;
			}
			case 58u:
			{
				Types.DeleteLook deleteLook = new Types.DeleteLook();
				if (responseCase_ == ResponseOneofCase.DeleteLook)
				{
					deleteLook.MergeFrom(DeleteLook);
				}
				input.ReadMessage(deleteLook);
				DeleteLook = deleteLook;
				break;
			}
			case 66u:
			{
				Types.TriggerLook triggerLook = new Types.TriggerLook();
				if (responseCase_ == ResponseOneofCase.TriggerLook)
				{
					triggerLook.MergeFrom(TriggerLook);
				}
				input.ReadMessage(triggerLook);
				TriggerLook = triggerLook;
				break;
			}
			}
		}
	}
}
