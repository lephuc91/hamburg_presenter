using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Macro_Response : IMessage<API_v1_Macro_Response>, IMessage, IEquatable<API_v1_Macro_Response>, IDeepCloneable<API_v1_Macro_Response>
{
	public enum ResponseOneofCase
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

			public const int Macros_FieldNumber = 1;

			private static readonly FieldCodec<API_v1_Macro> _repeated_macros_codec = FieldCodec.ForMessage(10u, API_v1_Macro.Parser);

			private readonly RepeatedField<API_v1_Macro> macros_ = new RepeatedField<API_v1_Macro>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Macros> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Macro_Response.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<API_v1_Macro> Macros_ => macros_;

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
				macros_ = other.macros_.Clone();
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
				if (!macros_.Equals(other.macros_))
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
				num ^= macros_.GetHashCode();
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
				macros_.WriteTo(output, _repeated_macros_codec);
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
				num += macros_.CalculateSize(_repeated_macros_codec);
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
					macros_.Add(other.macros_);
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
						macros_.AddEntriesFrom(input, _repeated_macros_codec);
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetMacro : IMessage<GetMacro>, IMessage, IEquatable<GetMacro>, IDeepCloneable<GetMacro>
		{
			private static readonly MessageParser<GetMacro> _parser = new MessageParser<GetMacro>(() => new GetMacro());

			private UnknownFieldSet _unknownFields;

			public const int MacroFieldNumber = 1;

			private API_v1_Macro macro_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetMacro> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Macro_Response.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Macro Macro
			{
				get
				{
					return macro_;
				}
				set
				{
					macro_ = value;
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
				macro_ = ((other.macro_ != null) ? other.macro_.Clone() : null);
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
				if (!object.Equals(Macro, other.Macro))
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
				if (macro_ != null)
				{
					num ^= Macro.GetHashCode();
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
				if (macro_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Macro);
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
				if (macro_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Macro);
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
				if (other == null)
				{
					return;
				}
				if (other.macro_ != null)
				{
					if (macro_ == null)
					{
						Macro = new API_v1_Macro();
					}
					Macro.MergeFrom(other.Macro);
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
					if (macro_ == null)
					{
						Macro = new API_v1_Macro();
					}
					input.ReadMessage(Macro);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PutMacro : IMessage<PutMacro>, IMessage, IEquatable<PutMacro>, IDeepCloneable<PutMacro>
		{
			private static readonly MessageParser<PutMacro> _parser = new MessageParser<PutMacro>(() => new PutMacro());

			private UnknownFieldSet _unknownFields;

			public const int MacroFieldNumber = 1;

			private API_v1_Macro macro_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutMacro> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Macro_Response.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Macro Macro
			{
				get
				{
					return macro_;
				}
				set
				{
					macro_ = value;
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
				macro_ = ((other.macro_ != null) ? other.macro_.Clone() : null);
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
				if (!object.Equals(Macro, other.Macro))
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
				if (macro_ != null)
				{
					num ^= Macro.GetHashCode();
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
				if (macro_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Macro);
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
				if (macro_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Macro);
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
				if (other.macro_ != null)
				{
					if (macro_ == null)
					{
						Macro = new API_v1_Macro();
					}
					Macro.MergeFrom(other.Macro);
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
					if (macro_ == null)
					{
						Macro = new API_v1_Macro();
					}
					input.ReadMessage(Macro);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class DeleteMacro : IMessage<DeleteMacro>, IMessage, IEquatable<DeleteMacro>, IDeepCloneable<DeleteMacro>
		{
			private static readonly MessageParser<DeleteMacro> _parser = new MessageParser<DeleteMacro>(() => new DeleteMacro());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DeleteMacro> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Macro_Response.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(DeleteMacro other)
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
		public sealed class TriggerMacro : IMessage<TriggerMacro>, IMessage, IEquatable<TriggerMacro>, IDeepCloneable<TriggerMacro>
		{
			private static readonly MessageParser<TriggerMacro> _parser = new MessageParser<TriggerMacro>(() => new TriggerMacro());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TriggerMacro> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Macro_Response.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(TriggerMacro other)
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
		public sealed class MacroCollections : IMessage<MacroCollections>, IMessage, IEquatable<MacroCollections>, IDeepCloneable<MacroCollections>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Collections : IMessage<Collections>, IMessage, IEquatable<Collections>, IDeepCloneable<Collections>
				{
					private static readonly MessageParser<Collections> _parser = new MessageParser<Collections>(() => new Collections());

					private UnknownFieldSet _unknownFields;

					public const int Collections_FieldNumber = 1;

					private static readonly FieldCodec<API_v1_Macro_Collection> _repeated_collections_codec = FieldCodec.ForMessage(10u, API_v1_Macro_Collection.Parser);

					private readonly RepeatedField<API_v1_Macro_Collection> collections_ = new RepeatedField<API_v1_Macro_Collection>();

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Collections> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => MacroCollections.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RepeatedField<API_v1_Macro_Collection> Collections_ => collections_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Collections()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Collections(Collections other)
						: this()
					{
						collections_ = other.collections_.Clone();
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Collections Clone()
					{
						return new Collections(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Collections);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Collections other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!collections_.Equals(other.collections_))
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
						num ^= collections_.GetHashCode();
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
						collections_.WriteTo(output, _repeated_collections_codec);
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
						num += collections_.CalculateSize(_repeated_collections_codec);
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(Collections other)
					{
						if (other != null)
						{
							collections_.Add(other.collections_);
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
								collections_.AddEntriesFrom(input, _repeated_collections_codec);
							}
						}
					}
				}
			}

			private static readonly MessageParser<MacroCollections> _parser = new MessageParser<MacroCollections>(() => new MacroCollections());

			private UnknownFieldSet _unknownFields;

			public const int MacroCollections_FieldNumber = 1;

			private Types.Collections macroCollections_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<MacroCollections> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Macro_Response.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Collections MacroCollections_
			{
				get
				{
					return macroCollections_;
				}
				set
				{
					macroCollections_ = value;
				}
			}

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
				macroCollections_ = ((other.macroCollections_ != null) ? other.macroCollections_.Clone() : null);
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
				if (!object.Equals(MacroCollections_, other.MacroCollections_))
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
				if (macroCollections_ != null)
				{
					num ^= MacroCollections_.GetHashCode();
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
				if (macroCollections_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(MacroCollections_);
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
				if (macroCollections_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(MacroCollections_);
				}
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
				if (other == null)
				{
					return;
				}
				if (other.macroCollections_ != null)
				{
					if (macroCollections_ == null)
					{
						MacroCollections_ = new Types.Collections();
					}
					MacroCollections_.MergeFrom(other.MacroCollections_);
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
					if (macroCollections_ == null)
					{
						MacroCollections_ = new Types.Collections();
					}
					input.ReadMessage(MacroCollections_);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetMacroCollection : IMessage<GetMacroCollection>, IMessage, IEquatable<GetMacroCollection>, IDeepCloneable<GetMacroCollection>
		{
			private static readonly MessageParser<GetMacroCollection> _parser = new MessageParser<GetMacroCollection>(() => new GetMacroCollection());

			private UnknownFieldSet _unknownFields;

			public const int MacroCollectionFieldNumber = 1;

			private API_v1_Macro_Collection macroCollection_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetMacroCollection> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Macro_Response.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Macro_Collection MacroCollection
			{
				get
				{
					return macroCollection_;
				}
				set
				{
					macroCollection_ = value;
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
				macroCollection_ = ((other.macroCollection_ != null) ? other.macroCollection_.Clone() : null);
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
				if (!object.Equals(MacroCollection, other.MacroCollection))
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
				if (macroCollection_ != null)
				{
					num ^= MacroCollection.GetHashCode();
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
				if (macroCollection_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(MacroCollection);
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
				if (macroCollection_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(MacroCollection);
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
				if (other == null)
				{
					return;
				}
				if (other.macroCollection_ != null)
				{
					if (macroCollection_ == null)
					{
						MacroCollection = new API_v1_Macro_Collection();
					}
					MacroCollection.MergeFrom(other.MacroCollection);
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
					if (macroCollection_ == null)
					{
						MacroCollection = new API_v1_Macro_Collection();
					}
					input.ReadMessage(MacroCollection);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PostMacroCollections : IMessage<PostMacroCollections>, IMessage, IEquatable<PostMacroCollections>, IDeepCloneable<PostMacroCollections>
		{
			private static readonly MessageParser<PostMacroCollections> _parser = new MessageParser<PostMacroCollections>(() => new PostMacroCollections());

			private UnknownFieldSet _unknownFields;

			public const int MacroCollectionFieldNumber = 1;

			private API_v1_Macro_Collection macroCollection_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PostMacroCollections> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Macro_Response.Descriptor.NestedTypes[7];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Macro_Collection MacroCollection
			{
				get
				{
					return macroCollection_;
				}
				set
				{
					macroCollection_ = value;
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
				macroCollection_ = ((other.macroCollection_ != null) ? other.macroCollection_.Clone() : null);
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
				if (!object.Equals(MacroCollection, other.MacroCollection))
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
				if (macroCollection_ != null)
				{
					num ^= MacroCollection.GetHashCode();
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
				if (macroCollection_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(MacroCollection);
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
				if (macroCollection_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(MacroCollection);
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
				if (other == null)
				{
					return;
				}
				if (other.macroCollection_ != null)
				{
					if (macroCollection_ == null)
					{
						MacroCollection = new API_v1_Macro_Collection();
					}
					MacroCollection.MergeFrom(other.MacroCollection);
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
					if (macroCollection_ == null)
					{
						MacroCollection = new API_v1_Macro_Collection();
					}
					input.ReadMessage(MacroCollection);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PutMacroCollection : IMessage<PutMacroCollection>, IMessage, IEquatable<PutMacroCollection>, IDeepCloneable<PutMacroCollection>
		{
			private static readonly MessageParser<PutMacroCollection> _parser = new MessageParser<PutMacroCollection>(() => new PutMacroCollection());

			private UnknownFieldSet _unknownFields;

			public const int MacroCollectionFieldNumber = 1;

			private API_v1_Macro_Collection macroCollection_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutMacroCollection> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Macro_Response.Descriptor.NestedTypes[8];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Macro_Collection MacroCollection
			{
				get
				{
					return macroCollection_;
				}
				set
				{
					macroCollection_ = value;
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
				macroCollection_ = ((other.macroCollection_ != null) ? other.macroCollection_.Clone() : null);
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
				if (!object.Equals(MacroCollection, other.MacroCollection))
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
				if (macroCollection_ != null)
				{
					num ^= MacroCollection.GetHashCode();
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
				if (macroCollection_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(MacroCollection);
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
				if (macroCollection_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(MacroCollection);
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
				if (other.macroCollection_ != null)
				{
					if (macroCollection_ == null)
					{
						MacroCollection = new API_v1_Macro_Collection();
					}
					MacroCollection.MergeFrom(other.MacroCollection);
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
					if (macroCollection_ == null)
					{
						MacroCollection = new API_v1_Macro_Collection();
					}
					input.ReadMessage(MacroCollection);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class DeleteMacroCollection : IMessage<DeleteMacroCollection>, IMessage, IEquatable<DeleteMacroCollection>, IDeepCloneable<DeleteMacroCollection>
		{
			private static readonly MessageParser<DeleteMacroCollection> _parser = new MessageParser<DeleteMacroCollection>(() => new DeleteMacroCollection());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DeleteMacroCollection> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Macro_Response.Descriptor.NestedTypes[9];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(DeleteMacroCollection other)
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
		public sealed class MacroIcon : IMessage<MacroIcon>, IMessage, IEquatable<MacroIcon>, IDeepCloneable<MacroIcon>
		{
			private static readonly MessageParser<MacroIcon> _parser = new MessageParser<MacroIcon>(() => new MacroIcon());

			private UnknownFieldSet _unknownFields;

			public const int ContentTypeFieldNumber = 1;

			private string contentType_ = "";

			public const int IconFieldNumber = 2;

			private ByteString icon_ = ByteString.Empty;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<MacroIcon> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Macro_Response.Descriptor.NestedTypes[10];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public MacroIcon()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MacroIcon(MacroIcon other)
				: this()
			{
				contentType_ = other.contentType_;
				icon_ = other.icon_;
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
				if (ContentType.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(ContentType);
				}
				if (Icon.Length != 0)
				{
					output.WriteRawTag(18);
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
			public void MergeFrom(MacroIcon other)
			{
				if (other != null)
				{
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
						ContentType = input.ReadString();
						break;
					case 18u:
						Icon = input.ReadBytes();
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

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutMacroIcon> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Macro_Response.Descriptor.NestedTypes[11];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(PutMacroIcon other)
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

	private static readonly MessageParser<API_v1_Macro_Response> _parser = new MessageParser<API_v1_Macro_Response>(() => new API_v1_Macro_Response());

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

	private object response_;

	private ResponseOneofCase responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Macro_Response> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1MacroReflection.Descriptor.MessageTypes[4];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Macros Macros
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Macros)
			{
				return null;
			}
			return (Types.Macros)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Macros : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetMacro GetMacro
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetMacro)
			{
				return null;
			}
			return (Types.GetMacro)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetMacro : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutMacro PutMacro
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PutMacro)
			{
				return null;
			}
			return (Types.PutMacro)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PutMacro : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DeleteMacro DeleteMacro
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.DeleteMacro)
			{
				return null;
			}
			return (Types.DeleteMacro)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.DeleteMacro : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TriggerMacro TriggerMacro
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.TriggerMacro)
			{
				return null;
			}
			return (Types.TriggerMacro)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.TriggerMacro : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.MacroCollections MacroCollections
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.MacroCollections)
			{
				return null;
			}
			return (Types.MacroCollections)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.MacroCollections : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetMacroCollection GetMacroCollection
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetMacroCollection)
			{
				return null;
			}
			return (Types.GetMacroCollection)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetMacroCollection : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PostMacroCollections PostMacroCollections
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PostMacroCollections)
			{
				return null;
			}
			return (Types.PostMacroCollections)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PostMacroCollections : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutMacroCollection PutMacroCollection
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PutMacroCollection)
			{
				return null;
			}
			return (Types.PutMacroCollection)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PutMacroCollection : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DeleteMacroCollection DeleteMacroCollection
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.DeleteMacroCollection)
			{
				return null;
			}
			return (Types.DeleteMacroCollection)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.DeleteMacroCollection : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.MacroIcon MacroIcon
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.MacroIcon)
			{
				return null;
			}
			return (Types.MacroIcon)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.MacroIcon : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutMacroIcon PutMacroIcon
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PutMacroIcon)
			{
				return null;
			}
			return (Types.PutMacroIcon)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PutMacroIcon : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResponseOneofCase ResponseCase => responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Macro_Response()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Macro_Response(API_v1_Macro_Response other)
		: this()
	{
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.Macros:
			Macros = other.Macros.Clone();
			break;
		case ResponseOneofCase.GetMacro:
			GetMacro = other.GetMacro.Clone();
			break;
		case ResponseOneofCase.PutMacro:
			PutMacro = other.PutMacro.Clone();
			break;
		case ResponseOneofCase.DeleteMacro:
			DeleteMacro = other.DeleteMacro.Clone();
			break;
		case ResponseOneofCase.TriggerMacro:
			TriggerMacro = other.TriggerMacro.Clone();
			break;
		case ResponseOneofCase.MacroCollections:
			MacroCollections = other.MacroCollections.Clone();
			break;
		case ResponseOneofCase.GetMacroCollection:
			GetMacroCollection = other.GetMacroCollection.Clone();
			break;
		case ResponseOneofCase.PostMacroCollections:
			PostMacroCollections = other.PostMacroCollections.Clone();
			break;
		case ResponseOneofCase.PutMacroCollection:
			PutMacroCollection = other.PutMacroCollection.Clone();
			break;
		case ResponseOneofCase.DeleteMacroCollection:
			DeleteMacroCollection = other.DeleteMacroCollection.Clone();
			break;
		case ResponseOneofCase.MacroIcon:
			MacroIcon = other.MacroIcon.Clone();
			break;
		case ResponseOneofCase.PutMacroIcon:
			PutMacroIcon = other.PutMacroIcon.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Macro_Response Clone()
	{
		return new API_v1_Macro_Response(this);
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
		return Equals(other as API_v1_Macro_Response);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Macro_Response other)
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
		if (responseCase_ == ResponseOneofCase.Macros)
		{
			num ^= Macros.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetMacro)
		{
			num ^= GetMacro.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PutMacro)
		{
			num ^= PutMacro.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.DeleteMacro)
		{
			num ^= DeleteMacro.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.TriggerMacro)
		{
			num ^= TriggerMacro.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.MacroCollections)
		{
			num ^= MacroCollections.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetMacroCollection)
		{
			num ^= GetMacroCollection.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PostMacroCollections)
		{
			num ^= PostMacroCollections.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PutMacroCollection)
		{
			num ^= PutMacroCollection.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.DeleteMacroCollection)
		{
			num ^= DeleteMacroCollection.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.MacroIcon)
		{
			num ^= MacroIcon.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PutMacroIcon)
		{
			num ^= PutMacroIcon.GetHashCode();
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
		if (responseCase_ == ResponseOneofCase.Macros)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Macros);
		}
		if (responseCase_ == ResponseOneofCase.GetMacro)
		{
			output.WriteRawTag(18);
			output.WriteMessage(GetMacro);
		}
		if (responseCase_ == ResponseOneofCase.PutMacro)
		{
			output.WriteRawTag(26);
			output.WriteMessage(PutMacro);
		}
		if (responseCase_ == ResponseOneofCase.DeleteMacro)
		{
			output.WriteRawTag(34);
			output.WriteMessage(DeleteMacro);
		}
		if (responseCase_ == ResponseOneofCase.TriggerMacro)
		{
			output.WriteRawTag(42);
			output.WriteMessage(TriggerMacro);
		}
		if (responseCase_ == ResponseOneofCase.MacroCollections)
		{
			output.WriteRawTag(50);
			output.WriteMessage(MacroCollections);
		}
		if (responseCase_ == ResponseOneofCase.GetMacroCollection)
		{
			output.WriteRawTag(58);
			output.WriteMessage(GetMacroCollection);
		}
		if (responseCase_ == ResponseOneofCase.PostMacroCollections)
		{
			output.WriteRawTag(66);
			output.WriteMessage(PostMacroCollections);
		}
		if (responseCase_ == ResponseOneofCase.PutMacroCollection)
		{
			output.WriteRawTag(74);
			output.WriteMessage(PutMacroCollection);
		}
		if (responseCase_ == ResponseOneofCase.DeleteMacroCollection)
		{
			output.WriteRawTag(82);
			output.WriteMessage(DeleteMacroCollection);
		}
		if (responseCase_ == ResponseOneofCase.MacroIcon)
		{
			output.WriteRawTag(90);
			output.WriteMessage(MacroIcon);
		}
		if (responseCase_ == ResponseOneofCase.PutMacroIcon)
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
		if (responseCase_ == ResponseOneofCase.Macros)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Macros);
		}
		if (responseCase_ == ResponseOneofCase.GetMacro)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetMacro);
		}
		if (responseCase_ == ResponseOneofCase.PutMacro)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutMacro);
		}
		if (responseCase_ == ResponseOneofCase.DeleteMacro)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DeleteMacro);
		}
		if (responseCase_ == ResponseOneofCase.TriggerMacro)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TriggerMacro);
		}
		if (responseCase_ == ResponseOneofCase.MacroCollections)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(MacroCollections);
		}
		if (responseCase_ == ResponseOneofCase.GetMacroCollection)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetMacroCollection);
		}
		if (responseCase_ == ResponseOneofCase.PostMacroCollections)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PostMacroCollections);
		}
		if (responseCase_ == ResponseOneofCase.PutMacroCollection)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutMacroCollection);
		}
		if (responseCase_ == ResponseOneofCase.DeleteMacroCollection)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DeleteMacroCollection);
		}
		if (responseCase_ == ResponseOneofCase.MacroIcon)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(MacroIcon);
		}
		if (responseCase_ == ResponseOneofCase.PutMacroIcon)
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
	public void MergeFrom(API_v1_Macro_Response other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.Macros:
			if (Macros == null)
			{
				Macros = new Types.Macros();
			}
			Macros.MergeFrom(other.Macros);
			break;
		case ResponseOneofCase.GetMacro:
			if (GetMacro == null)
			{
				GetMacro = new Types.GetMacro();
			}
			GetMacro.MergeFrom(other.GetMacro);
			break;
		case ResponseOneofCase.PutMacro:
			if (PutMacro == null)
			{
				PutMacro = new Types.PutMacro();
			}
			PutMacro.MergeFrom(other.PutMacro);
			break;
		case ResponseOneofCase.DeleteMacro:
			if (DeleteMacro == null)
			{
				DeleteMacro = new Types.DeleteMacro();
			}
			DeleteMacro.MergeFrom(other.DeleteMacro);
			break;
		case ResponseOneofCase.TriggerMacro:
			if (TriggerMacro == null)
			{
				TriggerMacro = new Types.TriggerMacro();
			}
			TriggerMacro.MergeFrom(other.TriggerMacro);
			break;
		case ResponseOneofCase.MacroCollections:
			if (MacroCollections == null)
			{
				MacroCollections = new Types.MacroCollections();
			}
			MacroCollections.MergeFrom(other.MacroCollections);
			break;
		case ResponseOneofCase.GetMacroCollection:
			if (GetMacroCollection == null)
			{
				GetMacroCollection = new Types.GetMacroCollection();
			}
			GetMacroCollection.MergeFrom(other.GetMacroCollection);
			break;
		case ResponseOneofCase.PostMacroCollections:
			if (PostMacroCollections == null)
			{
				PostMacroCollections = new Types.PostMacroCollections();
			}
			PostMacroCollections.MergeFrom(other.PostMacroCollections);
			break;
		case ResponseOneofCase.PutMacroCollection:
			if (PutMacroCollection == null)
			{
				PutMacroCollection = new Types.PutMacroCollection();
			}
			PutMacroCollection.MergeFrom(other.PutMacroCollection);
			break;
		case ResponseOneofCase.DeleteMacroCollection:
			if (DeleteMacroCollection == null)
			{
				DeleteMacroCollection = new Types.DeleteMacroCollection();
			}
			DeleteMacroCollection.MergeFrom(other.DeleteMacroCollection);
			break;
		case ResponseOneofCase.MacroIcon:
			if (MacroIcon == null)
			{
				MacroIcon = new Types.MacroIcon();
			}
			MacroIcon.MergeFrom(other.MacroIcon);
			break;
		case ResponseOneofCase.PutMacroIcon:
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
				if (responseCase_ == ResponseOneofCase.Macros)
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
				if (responseCase_ == ResponseOneofCase.GetMacro)
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
				if (responseCase_ == ResponseOneofCase.PutMacro)
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
				if (responseCase_ == ResponseOneofCase.DeleteMacro)
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
				if (responseCase_ == ResponseOneofCase.TriggerMacro)
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
				if (responseCase_ == ResponseOneofCase.MacroCollections)
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
				if (responseCase_ == ResponseOneofCase.GetMacroCollection)
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
				if (responseCase_ == ResponseOneofCase.PostMacroCollections)
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
				if (responseCase_ == ResponseOneofCase.PutMacroCollection)
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
				if (responseCase_ == ResponseOneofCase.DeleteMacroCollection)
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
				if (responseCase_ == ResponseOneofCase.MacroIcon)
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
				if (responseCase_ == ResponseOneofCase.PutMacroIcon)
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
