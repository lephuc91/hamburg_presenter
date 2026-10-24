using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Macro_Request : IMessage<API_v1_Macro_Request>, IMessage, IEquatable<API_v1_Macro_Request>, IDeepCloneable<API_v1_Macro_Request>
{
	public enum RequestOneofCase
	{
		None,
		Macros,
		GetMacro,
		PutMacro,
		DeleteMacro,
		TriggerMacro,
		MacroCollections,
		GetMacroCollection,
		PostMacroCollections,
		PutMacroCollection,
		DeleteMacroCollection,
		MacroIcon,
		PutMacroIcon
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Macros : IMessage<Macros>, IMessage, IEquatable<Macros>, IDeepCloneable<Macros>
		{
			private static readonly MessageParser<Macros> _parser = new MessageParser<Macros>(() => new Macros());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Macros> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Macro_Request.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Macros()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Macros(Macros other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Macros Clone()
			{
				return new Macros(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Macros);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Macros other)
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
			public void MergeFrom(Macros other)
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
		public sealed class GetMacro : IMessage<GetMacro>, IMessage, IEquatable<GetMacro>, IDeepCloneable<GetMacro>
		{
			private static readonly MessageParser<GetMacro> _parser = new MessageParser<GetMacro>(() => new GetMacro());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetMacro> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Macro_Request.Descriptor.NestedTypes[1];

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
			public GetMacro()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetMacro(GetMacro other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetMacro Clone()
			{
				return new GetMacro(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetMacro);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetMacro other)
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
			public void MergeFrom(GetMacro other)
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
		public sealed class PutMacro : IMessage<PutMacro>, IMessage, IEquatable<PutMacro>, IDeepCloneable<PutMacro>
		{
			private static readonly MessageParser<PutMacro> _parser = new MessageParser<PutMacro>(() => new PutMacro());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int NameChangeFieldNumber = 2;

			private string nameChange_ = "";

			public const int ColorChangeFieldNumber = 3;

			private API_v1_Color colorChange_;

			public const int ImageTypeChangeFieldNumber = 4;

			private string imageTypeChange_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutMacro> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Macro_Request.Descriptor.NestedTypes[2];

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
			public string NameChange
			{
				get
				{
					return nameChange_;
				}
				set
				{
					nameChange_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Color ColorChange
			{
				get
				{
					return colorChange_;
				}
				set
				{
					colorChange_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string ImageTypeChange
			{
				get
				{
					return imageTypeChange_;
				}
				set
				{
					imageTypeChange_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutMacro()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutMacro(PutMacro other)
				: this()
			{
				id_ = other.id_;
				nameChange_ = other.nameChange_;
				colorChange_ = ((other.colorChange_ != null) ? other.colorChange_.Clone() : null);
				imageTypeChange_ = other.imageTypeChange_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutMacro Clone()
			{
				return new PutMacro(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PutMacro);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PutMacro other)
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
				if (NameChange != other.NameChange)
				{
					return false;
				}
				if (!object.Equals(ColorChange, other.ColorChange))
				{
					return false;
				}
				if (ImageTypeChange != other.ImageTypeChange)
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
				if (NameChange.Length != 0)
				{
					num ^= NameChange.GetHashCode();
				}
				if (colorChange_ != null)
				{
					num ^= ColorChange.GetHashCode();
				}
				if (ImageTypeChange.Length != 0)
				{
					num ^= ImageTypeChange.GetHashCode();
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
				if (NameChange.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(NameChange);
				}
				if (colorChange_ != null)
				{
					output.WriteRawTag(26);
					output.WriteMessage(ColorChange);
				}
				if (ImageTypeChange.Length != 0)
				{
					output.WriteRawTag(34);
					output.WriteString(ImageTypeChange);
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
				if (NameChange.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(NameChange);
				}
				if (colorChange_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(ColorChange);
				}
				if (ImageTypeChange.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(ImageTypeChange);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PutMacro other)
			{
				if (other == null)
				{
					return;
				}
				if (other.Id.Length != 0)
				{
					Id = other.Id;
				}
				if (other.NameChange.Length != 0)
				{
					NameChange = other.NameChange;
				}
				if (other.colorChange_ != null)
				{
					if (colorChange_ == null)
					{
						ColorChange = new API_v1_Color();
					}
					ColorChange.MergeFrom(other.ColorChange);
				}
				if (other.ImageTypeChange.Length != 0)
				{
					ImageTypeChange = other.ImageTypeChange;
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
						NameChange = input.ReadString();
						break;
					case 26u:
						if (colorChange_ == null)
						{
							ColorChange = new API_v1_Color();
						}
						input.ReadMessage(ColorChange);
						break;
					case 34u:
						ImageTypeChange = input.ReadString();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class DeleteMacro : IMessage<DeleteMacro>, IMessage, IEquatable<DeleteMacro>, IDeepCloneable<DeleteMacro>
		{
			private static readonly MessageParser<DeleteMacro> _parser = new MessageParser<DeleteMacro>(() => new DeleteMacro());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DeleteMacro> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Macro_Request.Descriptor.NestedTypes[3];

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
			public DeleteMacro()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteMacro(DeleteMacro other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteMacro Clone()
			{
				return new DeleteMacro(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as DeleteMacro);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(DeleteMacro other)
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
			public void MergeFrom(DeleteMacro other)
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
		public sealed class TriggerMacro : IMessage<TriggerMacro>, IMessage, IEquatable<TriggerMacro>, IDeepCloneable<TriggerMacro>
		{
			private static readonly MessageParser<TriggerMacro> _parser = new MessageParser<TriggerMacro>(() => new TriggerMacro());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TriggerMacro> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Macro_Request.Descriptor.NestedTypes[4];

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
			public TriggerMacro()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerMacro(TriggerMacro other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerMacro Clone()
			{
				return new TriggerMacro(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TriggerMacro);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TriggerMacro other)
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
			public void MergeFrom(TriggerMacro other)
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
		public sealed class MacroCollections : IMessage<MacroCollections>, IMessage, IEquatable<MacroCollections>, IDeepCloneable<MacroCollections>
		{
			private static readonly MessageParser<MacroCollections> _parser = new MessageParser<MacroCollections>(() => new MacroCollections());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<MacroCollections> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Macro_Request.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MacroCollections()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MacroCollections(MacroCollections other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MacroCollections Clone()
			{
				return new MacroCollections(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as MacroCollections);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(MacroCollections other)
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
			public void MergeFrom(MacroCollections other)
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
		public sealed class GetMacroCollection : IMessage<GetMacroCollection>, IMessage, IEquatable<GetMacroCollection>, IDeepCloneable<GetMacroCollection>
		{
			private static readonly MessageParser<GetMacroCollection> _parser = new MessageParser<GetMacroCollection>(() => new GetMacroCollection());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetMacroCollection> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Macro_Request.Descriptor.NestedTypes[6];

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
			public GetMacroCollection()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetMacroCollection(GetMacroCollection other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetMacroCollection Clone()
			{
				return new GetMacroCollection(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetMacroCollection);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetMacroCollection other)
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
			public void MergeFrom(GetMacroCollection other)
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
		public sealed class PostMacroCollections : IMessage<PostMacroCollections>, IMessage, IEquatable<PostMacroCollections>, IDeepCloneable<PostMacroCollections>
		{
			private static readonly MessageParser<PostMacroCollections> _parser = new MessageParser<PostMacroCollections>(() => new PostMacroCollections());

			private UnknownFieldSet _unknownFields;

			public const int NameFieldNumber = 1;

			private string name_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PostMacroCollections> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Macro_Request.Descriptor.NestedTypes[7];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public PostMacroCollections()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PostMacroCollections(PostMacroCollections other)
				: this()
			{
				name_ = other.name_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PostMacroCollections Clone()
			{
				return new PostMacroCollections(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PostMacroCollections);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PostMacroCollections other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Name != other.Name)
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
				if (Name.Length != 0)
				{
					num ^= Name.GetHashCode();
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
				if (Name.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Name);
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
				if (Name.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Name);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PostMacroCollections other)
			{
				if (other != null)
				{
					if (other.Name.Length != 0)
					{
						Name = other.Name;
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
						Name = input.ReadString();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PutMacroCollection : IMessage<PutMacroCollection>, IMessage, IEquatable<PutMacroCollection>, IDeepCloneable<PutMacroCollection>
		{
			private static readonly MessageParser<PutMacroCollection> _parser = new MessageParser<PutMacroCollection>(() => new PutMacroCollection());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int ChangesFieldNumber = 2;

			private API_v1_Macro_Collection changes_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutMacroCollection> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Macro_Request.Descriptor.NestedTypes[8];

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
			public API_v1_Macro_Collection Changes
			{
				get
				{
					return changes_;
				}
				set
				{
					changes_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutMacroCollection()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutMacroCollection(PutMacroCollection other)
				: this()
			{
				id_ = other.id_;
				changes_ = ((other.changes_ != null) ? other.changes_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutMacroCollection Clone()
			{
				return new PutMacroCollection(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PutMacroCollection);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PutMacroCollection other)
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
				if (!object.Equals(Changes, other.Changes))
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
				if (changes_ != null)
				{
					num ^= Changes.GetHashCode();
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
				if (changes_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Changes);
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
				if (changes_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Changes);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PutMacroCollection other)
			{
				if (other == null)
				{
					return;
				}
				if (other.Id.Length != 0)
				{
					Id = other.Id;
				}
				if (other.changes_ != null)
				{
					if (changes_ == null)
					{
						Changes = new API_v1_Macro_Collection();
					}
					Changes.MergeFrom(other.Changes);
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
						if (changes_ == null)
						{
							Changes = new API_v1_Macro_Collection();
						}
						input.ReadMessage(Changes);
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class DeleteMacroCollection : IMessage<DeleteMacroCollection>, IMessage, IEquatable<DeleteMacroCollection>, IDeepCloneable<DeleteMacroCollection>
		{
			private static readonly MessageParser<DeleteMacroCollection> _parser = new MessageParser<DeleteMacroCollection>(() => new DeleteMacroCollection());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DeleteMacroCollection> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Macro_Request.Descriptor.NestedTypes[9];

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
			public DeleteMacroCollection()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteMacroCollection(DeleteMacroCollection other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteMacroCollection Clone()
			{
				return new DeleteMacroCollection(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as DeleteMacroCollection);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(DeleteMacroCollection other)
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
			public void MergeFrom(DeleteMacroCollection other)
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
		public sealed class MacroIcon : IMessage<MacroIcon>, IMessage, IEquatable<MacroIcon>, IDeepCloneable<MacroIcon>
		{
			private static readonly MessageParser<MacroIcon> _parser = new MessageParser<MacroIcon>(() => new MacroIcon());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int QualityFieldNumber = 2;

			private int quality_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<MacroIcon> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Macro_Request.Descriptor.NestedTypes[10];

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
			public int Quality
			{
				get
				{
					return quality_;
				}
				set
				{
					quality_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MacroIcon()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MacroIcon(MacroIcon other)
				: this()
			{
				id_ = other.id_;
				quality_ = other.quality_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MacroIcon Clone()
			{
				return new MacroIcon(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as MacroIcon);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(MacroIcon other)
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
				if (Quality != other.Quality)
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
				if (Quality != 0)
				{
					num ^= Quality.GetHashCode();
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
				if (Quality != 0)
				{
					output.WriteRawTag(16);
					output.WriteInt32(Quality);
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
				if (Quality != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(Quality);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(MacroIcon other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
					}
					if (other.Quality != 0)
					{
						Quality = other.Quality;
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
						Id = input.ReadString();
						break;
					case 16u:
						Quality = input.ReadInt32();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PutMacroIcon : IMessage<PutMacroIcon>, IMessage, IEquatable<PutMacroIcon>, IDeepCloneable<PutMacroIcon>
		{
			private static readonly MessageParser<PutMacroIcon> _parser = new MessageParser<PutMacroIcon>(() => new PutMacroIcon());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			public const int ContentTypeFieldNumber = 2;

			private string contentType_ = "";

			public const int IconFieldNumber = 3;

			private ByteString icon_ = ByteString.Empty;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutMacroIcon> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Macro_Request.Descriptor.NestedTypes[11];

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
			public string ContentType
			{
				get
				{
					return contentType_;
				}
				set
				{
					contentType_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ByteString Icon
			{
				get
				{
					return icon_;
				}
				set
				{
					icon_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutMacroIcon()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutMacroIcon(PutMacroIcon other)
				: this()
			{
				id_ = other.id_;
				contentType_ = other.contentType_;
				icon_ = other.icon_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutMacroIcon Clone()
			{
				return new PutMacroIcon(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PutMacroIcon);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PutMacroIcon other)
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
				if (ContentType != other.ContentType)
				{
					return false;
				}
				if (Icon != other.Icon)
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
				if (ContentType.Length != 0)
				{
					num ^= ContentType.GetHashCode();
				}
				if (Icon.Length != 0)
				{
					num ^= Icon.GetHashCode();
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
				if (ContentType.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(ContentType);
				}
				if (Icon.Length != 0)
				{
					output.WriteRawTag(26);
					output.WriteBytes(Icon);
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
				if (ContentType.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(ContentType);
				}
				if (Icon.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeBytesSize(Icon);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PutMacroIcon other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
					}
					if (other.ContentType.Length != 0)
					{
						ContentType = other.ContentType;
					}
					if (other.Icon.Length != 0)
					{
						Icon = other.Icon;
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
						Id = input.ReadString();
						break;
					case 18u:
						ContentType = input.ReadString();
						break;
					case 26u:
						Icon = input.ReadBytes();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<API_v1_Macro_Request> _parser = new MessageParser<API_v1_Macro_Request>(() => new API_v1_Macro_Request());

	private UnknownFieldSet _unknownFields;

	public const int MacrosFieldNumber = 1;

	public const int GetMacroFieldNumber = 2;

	public const int PutMacroFieldNumber = 3;

	public const int DeleteMacroFieldNumber = 4;

	public const int TriggerMacroFieldNumber = 5;

	public const int MacroCollectionsFieldNumber = 6;

	public const int GetMacroCollectionFieldNumber = 7;

	public const int PostMacroCollectionsFieldNumber = 8;

	public const int PutMacroCollectionFieldNumber = 9;

	public const int DeleteMacroCollectionFieldNumber = 10;

	public const int MacroIconFieldNumber = 11;

	public const int PutMacroIconFieldNumber = 12;

	private object request_;

	private RequestOneofCase requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Macro_Request> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1MacroReflection.Descriptor.MessageTypes[3];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Macros Macros
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Macros)
			{
				return null;
			}
			return (Types.Macros)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Macros : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetMacro GetMacro
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetMacro)
			{
				return null;
			}
			return (Types.GetMacro)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetMacro : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutMacro PutMacro
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PutMacro)
			{
				return null;
			}
			return (Types.PutMacro)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PutMacro : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DeleteMacro DeleteMacro
	{
		get
		{
			if (requestCase_ != RequestOneofCase.DeleteMacro)
			{
				return null;
			}
			return (Types.DeleteMacro)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.DeleteMacro : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TriggerMacro TriggerMacro
	{
		get
		{
			if (requestCase_ != RequestOneofCase.TriggerMacro)
			{
				return null;
			}
			return (Types.TriggerMacro)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.TriggerMacro : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.MacroCollections MacroCollections
	{
		get
		{
			if (requestCase_ != RequestOneofCase.MacroCollections)
			{
				return null;
			}
			return (Types.MacroCollections)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.MacroCollections : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetMacroCollection GetMacroCollection
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetMacroCollection)
			{
				return null;
			}
			return (Types.GetMacroCollection)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetMacroCollection : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PostMacroCollections PostMacroCollections
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PostMacroCollections)
			{
				return null;
			}
			return (Types.PostMacroCollections)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PostMacroCollections : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutMacroCollection PutMacroCollection
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PutMacroCollection)
			{
				return null;
			}
			return (Types.PutMacroCollection)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PutMacroCollection : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DeleteMacroCollection DeleteMacroCollection
	{
		get
		{
			if (requestCase_ != RequestOneofCase.DeleteMacroCollection)
			{
				return null;
			}
			return (Types.DeleteMacroCollection)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.DeleteMacroCollection : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.MacroIcon MacroIcon
	{
		get
		{
			if (requestCase_ != RequestOneofCase.MacroIcon)
			{
				return null;
			}
			return (Types.MacroIcon)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.MacroIcon : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutMacroIcon PutMacroIcon
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PutMacroIcon)
			{
				return null;
			}
			return (Types.PutMacroIcon)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PutMacroIcon : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestOneofCase RequestCase => requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Macro_Request()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Macro_Request(API_v1_Macro_Request other)
		: this()
	{
		switch (other.RequestCase)
		{
		case RequestOneofCase.Macros:
			Macros = other.Macros.Clone();
			break;
		case RequestOneofCase.GetMacro:
			GetMacro = other.GetMacro.Clone();
			break;
		case RequestOneofCase.PutMacro:
			PutMacro = other.PutMacro.Clone();
			break;
		case RequestOneofCase.DeleteMacro:
			DeleteMacro = other.DeleteMacro.Clone();
			break;
		case RequestOneofCase.TriggerMacro:
			TriggerMacro = other.TriggerMacro.Clone();
			break;
		case RequestOneofCase.MacroCollections:
			MacroCollections = other.MacroCollections.Clone();
			break;
		case RequestOneofCase.GetMacroCollection:
			GetMacroCollection = other.GetMacroCollection.Clone();
			break;
		case RequestOneofCase.PostMacroCollections:
			PostMacroCollections = other.PostMacroCollections.Clone();
			break;
		case RequestOneofCase.PutMacroCollection:
			PutMacroCollection = other.PutMacroCollection.Clone();
			break;
		case RequestOneofCase.DeleteMacroCollection:
			DeleteMacroCollection = other.DeleteMacroCollection.Clone();
			break;
		case RequestOneofCase.MacroIcon:
			MacroIcon = other.MacroIcon.Clone();
			break;
		case RequestOneofCase.PutMacroIcon:
			PutMacroIcon = other.PutMacroIcon.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Macro_Request Clone()
	{
		return new API_v1_Macro_Request(this);
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
		return Equals(other as API_v1_Macro_Request);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Macro_Request other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Macros, other.Macros))
		{
			return false;
		}
		if (!object.Equals(GetMacro, other.GetMacro))
		{
			return false;
		}
		if (!object.Equals(PutMacro, other.PutMacro))
		{
			return false;
		}
		if (!object.Equals(DeleteMacro, other.DeleteMacro))
		{
			return false;
		}
		if (!object.Equals(TriggerMacro, other.TriggerMacro))
		{
			return false;
		}
		if (!object.Equals(MacroCollections, other.MacroCollections))
		{
			return false;
		}
		if (!object.Equals(GetMacroCollection, other.GetMacroCollection))
		{
			return false;
		}
		if (!object.Equals(PostMacroCollections, other.PostMacroCollections))
		{
			return false;
		}
		if (!object.Equals(PutMacroCollection, other.PutMacroCollection))
		{
			return false;
		}
		if (!object.Equals(DeleteMacroCollection, other.DeleteMacroCollection))
		{
			return false;
		}
		if (!object.Equals(MacroIcon, other.MacroIcon))
		{
			return false;
		}
		if (!object.Equals(PutMacroIcon, other.PutMacroIcon))
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
		if (requestCase_ == RequestOneofCase.Macros)
		{
			num ^= Macros.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetMacro)
		{
			num ^= GetMacro.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PutMacro)
		{
			num ^= PutMacro.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.DeleteMacro)
		{
			num ^= DeleteMacro.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.TriggerMacro)
		{
			num ^= TriggerMacro.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.MacroCollections)
		{
			num ^= MacroCollections.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetMacroCollection)
		{
			num ^= GetMacroCollection.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PostMacroCollections)
		{
			num ^= PostMacroCollections.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PutMacroCollection)
		{
			num ^= PutMacroCollection.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.DeleteMacroCollection)
		{
			num ^= DeleteMacroCollection.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.MacroIcon)
		{
			num ^= MacroIcon.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PutMacroIcon)
		{
			num ^= PutMacroIcon.GetHashCode();
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
		if (requestCase_ == RequestOneofCase.Macros)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Macros);
		}
		if (requestCase_ == RequestOneofCase.GetMacro)
		{
			output.WriteRawTag(18);
			output.WriteMessage(GetMacro);
		}
		if (requestCase_ == RequestOneofCase.PutMacro)
		{
			output.WriteRawTag(26);
			output.WriteMessage(PutMacro);
		}
		if (requestCase_ == RequestOneofCase.DeleteMacro)
		{
			output.WriteRawTag(34);
			output.WriteMessage(DeleteMacro);
		}
		if (requestCase_ == RequestOneofCase.TriggerMacro)
		{
			output.WriteRawTag(42);
			output.WriteMessage(TriggerMacro);
		}
		if (requestCase_ == RequestOneofCase.MacroCollections)
		{
			output.WriteRawTag(50);
			output.WriteMessage(MacroCollections);
		}
		if (requestCase_ == RequestOneofCase.GetMacroCollection)
		{
			output.WriteRawTag(58);
			output.WriteMessage(GetMacroCollection);
		}
		if (requestCase_ == RequestOneofCase.PostMacroCollections)
		{
			output.WriteRawTag(66);
			output.WriteMessage(PostMacroCollections);
		}
		if (requestCase_ == RequestOneofCase.PutMacroCollection)
		{
			output.WriteRawTag(74);
			output.WriteMessage(PutMacroCollection);
		}
		if (requestCase_ == RequestOneofCase.DeleteMacroCollection)
		{
			output.WriteRawTag(82);
			output.WriteMessage(DeleteMacroCollection);
		}
		if (requestCase_ == RequestOneofCase.MacroIcon)
		{
			output.WriteRawTag(90);
			output.WriteMessage(MacroIcon);
		}
		if (requestCase_ == RequestOneofCase.PutMacroIcon)
		{
			output.WriteRawTag(98);
			output.WriteMessage(PutMacroIcon);
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
		if (requestCase_ == RequestOneofCase.Macros)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Macros);
		}
		if (requestCase_ == RequestOneofCase.GetMacro)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetMacro);
		}
		if (requestCase_ == RequestOneofCase.PutMacro)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutMacro);
		}
		if (requestCase_ == RequestOneofCase.DeleteMacro)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DeleteMacro);
		}
		if (requestCase_ == RequestOneofCase.TriggerMacro)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TriggerMacro);
		}
		if (requestCase_ == RequestOneofCase.MacroCollections)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(MacroCollections);
		}
		if (requestCase_ == RequestOneofCase.GetMacroCollection)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetMacroCollection);
		}
		if (requestCase_ == RequestOneofCase.PostMacroCollections)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PostMacroCollections);
		}
		if (requestCase_ == RequestOneofCase.PutMacroCollection)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutMacroCollection);
		}
		if (requestCase_ == RequestOneofCase.DeleteMacroCollection)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DeleteMacroCollection);
		}
		if (requestCase_ == RequestOneofCase.MacroIcon)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(MacroIcon);
		}
		if (requestCase_ == RequestOneofCase.PutMacroIcon)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutMacroIcon);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Macro_Request other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.RequestCase)
		{
		case RequestOneofCase.Macros:
			if (Macros == null)
			{
				Macros = new Types.Macros();
			}
			Macros.MergeFrom(other.Macros);
			break;
		case RequestOneofCase.GetMacro:
			if (GetMacro == null)
			{
				GetMacro = new Types.GetMacro();
			}
			GetMacro.MergeFrom(other.GetMacro);
			break;
		case RequestOneofCase.PutMacro:
			if (PutMacro == null)
			{
				PutMacro = new Types.PutMacro();
			}
			PutMacro.MergeFrom(other.PutMacro);
			break;
		case RequestOneofCase.DeleteMacro:
			if (DeleteMacro == null)
			{
				DeleteMacro = new Types.DeleteMacro();
			}
			DeleteMacro.MergeFrom(other.DeleteMacro);
			break;
		case RequestOneofCase.TriggerMacro:
			if (TriggerMacro == null)
			{
				TriggerMacro = new Types.TriggerMacro();
			}
			TriggerMacro.MergeFrom(other.TriggerMacro);
			break;
		case RequestOneofCase.MacroCollections:
			if (MacroCollections == null)
			{
				MacroCollections = new Types.MacroCollections();
			}
			MacroCollections.MergeFrom(other.MacroCollections);
			break;
		case RequestOneofCase.GetMacroCollection:
			if (GetMacroCollection == null)
			{
				GetMacroCollection = new Types.GetMacroCollection();
			}
			GetMacroCollection.MergeFrom(other.GetMacroCollection);
			break;
		case RequestOneofCase.PostMacroCollections:
			if (PostMacroCollections == null)
			{
				PostMacroCollections = new Types.PostMacroCollections();
			}
			PostMacroCollections.MergeFrom(other.PostMacroCollections);
			break;
		case RequestOneofCase.PutMacroCollection:
			if (PutMacroCollection == null)
			{
				PutMacroCollection = new Types.PutMacroCollection();
			}
			PutMacroCollection.MergeFrom(other.PutMacroCollection);
			break;
		case RequestOneofCase.DeleteMacroCollection:
			if (DeleteMacroCollection == null)
			{
				DeleteMacroCollection = new Types.DeleteMacroCollection();
			}
			DeleteMacroCollection.MergeFrom(other.DeleteMacroCollection);
			break;
		case RequestOneofCase.MacroIcon:
			if (MacroIcon == null)
			{
				MacroIcon = new Types.MacroIcon();
			}
			MacroIcon.MergeFrom(other.MacroIcon);
			break;
		case RequestOneofCase.PutMacroIcon:
			if (PutMacroIcon == null)
			{
				PutMacroIcon = new Types.PutMacroIcon();
			}
			PutMacroIcon.MergeFrom(other.PutMacroIcon);
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
				Types.Macros macros = new Types.Macros();
				if (requestCase_ == RequestOneofCase.Macros)
				{
					macros.MergeFrom(Macros);
				}
				input.ReadMessage(macros);
				Macros = macros;
				break;
			}
			case 18u:
			{
				Types.GetMacro getMacro = new Types.GetMacro();
				if (requestCase_ == RequestOneofCase.GetMacro)
				{
					getMacro.MergeFrom(GetMacro);
				}
				input.ReadMessage(getMacro);
				GetMacro = getMacro;
				break;
			}
			case 26u:
			{
				Types.PutMacro putMacro = new Types.PutMacro();
				if (requestCase_ == RequestOneofCase.PutMacro)
				{
					putMacro.MergeFrom(PutMacro);
				}
				input.ReadMessage(putMacro);
				PutMacro = putMacro;
				break;
			}
			case 34u:
			{
				Types.DeleteMacro deleteMacro = new Types.DeleteMacro();
				if (requestCase_ == RequestOneofCase.DeleteMacro)
				{
					deleteMacro.MergeFrom(DeleteMacro);
				}
				input.ReadMessage(deleteMacro);
				DeleteMacro = deleteMacro;
				break;
			}
			case 42u:
			{
				Types.TriggerMacro triggerMacro = new Types.TriggerMacro();
				if (requestCase_ == RequestOneofCase.TriggerMacro)
				{
					triggerMacro.MergeFrom(TriggerMacro);
				}
				input.ReadMessage(triggerMacro);
				TriggerMacro = triggerMacro;
				break;
			}
			case 50u:
			{
				Types.MacroCollections macroCollections = new Types.MacroCollections();
				if (requestCase_ == RequestOneofCase.MacroCollections)
				{
					macroCollections.MergeFrom(MacroCollections);
				}
				input.ReadMessage(macroCollections);
				MacroCollections = macroCollections;
				break;
			}
			case 58u:
			{
				Types.GetMacroCollection getMacroCollection = new Types.GetMacroCollection();
				if (requestCase_ == RequestOneofCase.GetMacroCollection)
				{
					getMacroCollection.MergeFrom(GetMacroCollection);
				}
				input.ReadMessage(getMacroCollection);
				GetMacroCollection = getMacroCollection;
				break;
			}
			case 66u:
			{
				Types.PostMacroCollections postMacroCollections = new Types.PostMacroCollections();
				if (requestCase_ == RequestOneofCase.PostMacroCollections)
				{
					postMacroCollections.MergeFrom(PostMacroCollections);
				}
				input.ReadMessage(postMacroCollections);
				PostMacroCollections = postMacroCollections;
				break;
			}
			case 74u:
			{
				Types.PutMacroCollection putMacroCollection = new Types.PutMacroCollection();
				if (requestCase_ == RequestOneofCase.PutMacroCollection)
				{
					putMacroCollection.MergeFrom(PutMacroCollection);
				}
				input.ReadMessage(putMacroCollection);
				PutMacroCollection = putMacroCollection;
				break;
			}
			case 82u:
			{
				Types.DeleteMacroCollection deleteMacroCollection = new Types.DeleteMacroCollection();
				if (requestCase_ == RequestOneofCase.DeleteMacroCollection)
				{
					deleteMacroCollection.MergeFrom(DeleteMacroCollection);
				}
				input.ReadMessage(deleteMacroCollection);
				DeleteMacroCollection = deleteMacroCollection;
				break;
			}
			case 90u:
			{
				Types.MacroIcon macroIcon = new Types.MacroIcon();
				if (requestCase_ == RequestOneofCase.MacroIcon)
				{
					macroIcon.MergeFrom(MacroIcon);
				}
				input.ReadMessage(macroIcon);
				MacroIcon = macroIcon;
				break;
			}
			case 98u:
			{
				Types.PutMacroIcon putMacroIcon = new Types.PutMacroIcon();
				if (requestCase_ == RequestOneofCase.PutMacroIcon)
				{
					putMacroIcon.MergeFrom(PutMacroIcon);
				}
				input.ReadMessage(putMacroIcon);
				PutMacroIcon = putMacroIcon;
				break;
			}
			}
		}
	}
}
