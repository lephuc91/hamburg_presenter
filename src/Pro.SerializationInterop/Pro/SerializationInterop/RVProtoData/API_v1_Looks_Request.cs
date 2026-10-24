using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Looks_Request : IMessage<API_v1_Looks_Request>, IMessage, IEquatable<API_v1_Looks_Request>, IDeepCloneable<API_v1_Looks_Request>
{
	public enum RequestOneofCase
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

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Looks> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Looks_Request.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(Looks other)
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
			public static MessageDescriptor Descriptor => API_v1_Looks_Request.Descriptor.NestedTypes[1];

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

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetCurrentLook> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Looks_Request.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(GetCurrentLook other)
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
			public static MessageDescriptor Descriptor => API_v1_Looks_Request.Descriptor.NestedTypes[3];

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

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetLook> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Looks_Request.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
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
				id_ = other.id_;
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
				if (Id != other.Id)
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
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
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
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
					if (num != 10)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Id = input.ReadString();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PutLook : IMessage<PutLook>, IMessage, IEquatable<PutLook>, IDeepCloneable<PutLook>
		{
			private static readonly MessageParser<PutLook> _parser = new MessageParser<PutLook>(() => new PutLook());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int LookFieldNumber = 2;

			private API_v1_Look look_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutLook> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Looks_Request.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

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
				id_ = other.id_;
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
				if (Id != other.Id)
				{
					return false;
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
				}
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
				}
				if (look_ != null)
				{
					output.WriteRawTag(18);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
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
				if (other.Id.Length != 0)
				{
					Id = other.Id;
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
					switch (num)
					{
					default:
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						break;
					case 10u:
						Id = input.ReadString();
						break;
					case 18u:
						if (look_ == null)
						{
							Look = new API_v1_Look();
						}
						input.ReadMessage(Look);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class DeleteLook : IMessage<DeleteLook>, IMessage, IEquatable<DeleteLook>, IDeepCloneable<DeleteLook>
		{
			private static readonly MessageParser<DeleteLook> _parser = new MessageParser<DeleteLook>(() => new DeleteLook());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DeleteLook> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Looks_Request.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

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
				id_ = other.id_;
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
				if (Id != other.Id)
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
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
					if (other.Id.Length != 0)
					{
						Id = other.Id;
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
					if (num != 10)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Id = input.ReadString();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class TriggerLook : IMessage<TriggerLook>, IMessage, IEquatable<TriggerLook>, IDeepCloneable<TriggerLook>
		{
			private static readonly MessageParser<TriggerLook> _parser = new MessageParser<TriggerLook>(() => new TriggerLook());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TriggerLook> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Looks_Request.Descriptor.NestedTypes[7];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

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
				id_ = other.id_;
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
				if (Id != other.Id)
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
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
					if (other.Id.Length != 0)
					{
						Id = other.Id;
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
					if (num != 10)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
					}
					else
					{
						Id = input.ReadString();
					}
				}
			}
		}
	}

	private static readonly MessageParser<API_v1_Looks_Request> _parser = new MessageParser<API_v1_Looks_Request>(() => new API_v1_Looks_Request());

	private UnknownFieldSet _unknownFields;

	public const int LooksFieldNumber = 1;

	public const int CreateLookFieldNumber = 2;

	public const int GetCurrentLookFieldNumber = 3;

	public const int PutCurrentLookFieldNumber = 4;

	public const int GetLookFieldNumber = 5;

	public const int PutLookFieldNumber = 6;

	public const int DeleteLookFieldNumber = 7;

	public const int TriggerLookFieldNumber = 8;

	private object request_;

	private RequestOneofCase requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Looks_Request> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1LooksReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Looks Looks
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Looks)
			{
				return null;
			}
			return (Types.Looks)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Looks : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.CreateLook CreateLook
	{
		get
		{
			if (requestCase_ != RequestOneofCase.CreateLook)
			{
				return null;
			}
			return (Types.CreateLook)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.CreateLook : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetCurrentLook GetCurrentLook
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetCurrentLook)
			{
				return null;
			}
			return (Types.GetCurrentLook)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetCurrentLook : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutCurrentLook PutCurrentLook
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PutCurrentLook)
			{
				return null;
			}
			return (Types.PutCurrentLook)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PutCurrentLook : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetLook GetLook
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetLook)
			{
				return null;
			}
			return (Types.GetLook)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetLook : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutLook PutLook
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PutLook)
			{
				return null;
			}
			return (Types.PutLook)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PutLook : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DeleteLook DeleteLook
	{
		get
		{
			if (requestCase_ != RequestOneofCase.DeleteLook)
			{
				return null;
			}
			return (Types.DeleteLook)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.DeleteLook : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TriggerLook TriggerLook
	{
		get
		{
			if (requestCase_ != RequestOneofCase.TriggerLook)
			{
				return null;
			}
			return (Types.TriggerLook)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.TriggerLook : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestOneofCase RequestCase => requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Looks_Request()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Looks_Request(API_v1_Looks_Request other)
		: this()
	{
		switch (other.RequestCase)
		{
		case RequestOneofCase.Looks:
			Looks = other.Looks.Clone();
			break;
		case RequestOneofCase.CreateLook:
			CreateLook = other.CreateLook.Clone();
			break;
		case RequestOneofCase.GetCurrentLook:
			GetCurrentLook = other.GetCurrentLook.Clone();
			break;
		case RequestOneofCase.PutCurrentLook:
			PutCurrentLook = other.PutCurrentLook.Clone();
			break;
		case RequestOneofCase.GetLook:
			GetLook = other.GetLook.Clone();
			break;
		case RequestOneofCase.PutLook:
			PutLook = other.PutLook.Clone();
			break;
		case RequestOneofCase.DeleteLook:
			DeleteLook = other.DeleteLook.Clone();
			break;
		case RequestOneofCase.TriggerLook:
			TriggerLook = other.TriggerLook.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Looks_Request Clone()
	{
		return new API_v1_Looks_Request(this);
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
		return Equals(other as API_v1_Looks_Request);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Looks_Request other)
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
		if (requestCase_ == RequestOneofCase.Looks)
		{
			num ^= Looks.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.CreateLook)
		{
			num ^= CreateLook.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetCurrentLook)
		{
			num ^= GetCurrentLook.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PutCurrentLook)
		{
			num ^= PutCurrentLook.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetLook)
		{
			num ^= GetLook.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PutLook)
		{
			num ^= PutLook.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.DeleteLook)
		{
			num ^= DeleteLook.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.TriggerLook)
		{
			num ^= TriggerLook.GetHashCode();
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
		if (requestCase_ == RequestOneofCase.Looks)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Looks);
		}
		if (requestCase_ == RequestOneofCase.CreateLook)
		{
			output.WriteRawTag(18);
			output.WriteMessage(CreateLook);
		}
		if (requestCase_ == RequestOneofCase.GetCurrentLook)
		{
			output.WriteRawTag(26);
			output.WriteMessage(GetCurrentLook);
		}
		if (requestCase_ == RequestOneofCase.PutCurrentLook)
		{
			output.WriteRawTag(34);
			output.WriteMessage(PutCurrentLook);
		}
		if (requestCase_ == RequestOneofCase.GetLook)
		{
			output.WriteRawTag(42);
			output.WriteMessage(GetLook);
		}
		if (requestCase_ == RequestOneofCase.PutLook)
		{
			output.WriteRawTag(50);
			output.WriteMessage(PutLook);
		}
		if (requestCase_ == RequestOneofCase.DeleteLook)
		{
			output.WriteRawTag(58);
			output.WriteMessage(DeleteLook);
		}
		if (requestCase_ == RequestOneofCase.TriggerLook)
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
		if (requestCase_ == RequestOneofCase.Looks)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Looks);
		}
		if (requestCase_ == RequestOneofCase.CreateLook)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CreateLook);
		}
		if (requestCase_ == RequestOneofCase.GetCurrentLook)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetCurrentLook);
		}
		if (requestCase_ == RequestOneofCase.PutCurrentLook)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutCurrentLook);
		}
		if (requestCase_ == RequestOneofCase.GetLook)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetLook);
		}
		if (requestCase_ == RequestOneofCase.PutLook)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutLook);
		}
		if (requestCase_ == RequestOneofCase.DeleteLook)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DeleteLook);
		}
		if (requestCase_ == RequestOneofCase.TriggerLook)
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
	public void MergeFrom(API_v1_Looks_Request other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.RequestCase)
		{
		case RequestOneofCase.Looks:
			if (Looks == null)
			{
				Looks = new Types.Looks();
			}
			Looks.MergeFrom(other.Looks);
			break;
		case RequestOneofCase.CreateLook:
			if (CreateLook == null)
			{
				CreateLook = new Types.CreateLook();
			}
			CreateLook.MergeFrom(other.CreateLook);
			break;
		case RequestOneofCase.GetCurrentLook:
			if (GetCurrentLook == null)
			{
				GetCurrentLook = new Types.GetCurrentLook();
			}
			GetCurrentLook.MergeFrom(other.GetCurrentLook);
			break;
		case RequestOneofCase.PutCurrentLook:
			if (PutCurrentLook == null)
			{
				PutCurrentLook = new Types.PutCurrentLook();
			}
			PutCurrentLook.MergeFrom(other.PutCurrentLook);
			break;
		case RequestOneofCase.GetLook:
			if (GetLook == null)
			{
				GetLook = new Types.GetLook();
			}
			GetLook.MergeFrom(other.GetLook);
			break;
		case RequestOneofCase.PutLook:
			if (PutLook == null)
			{
				PutLook = new Types.PutLook();
			}
			PutLook.MergeFrom(other.PutLook);
			break;
		case RequestOneofCase.DeleteLook:
			if (DeleteLook == null)
			{
				DeleteLook = new Types.DeleteLook();
			}
			DeleteLook.MergeFrom(other.DeleteLook);
			break;
		case RequestOneofCase.TriggerLook:
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
				if (requestCase_ == RequestOneofCase.Looks)
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
				if (requestCase_ == RequestOneofCase.CreateLook)
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
				if (requestCase_ == RequestOneofCase.GetCurrentLook)
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
				if (requestCase_ == RequestOneofCase.PutCurrentLook)
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
				if (requestCase_ == RequestOneofCase.GetLook)
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
				if (requestCase_ == RequestOneofCase.PutLook)
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
				if (requestCase_ == RequestOneofCase.DeleteLook)
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
				if (requestCase_ == RequestOneofCase.TriggerLook)
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
