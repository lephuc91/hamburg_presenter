using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Prop_Response : IMessage<API_v1_Prop_Response>, IMessage, IEquatable<API_v1_Prop_Response>, IDeepCloneable<API_v1_Prop_Response>
{
	public enum ResponseOneofCase
	{
		None,
		Props,
		GetProp,
		PutProp,
		DeleteProp,
		TriggerProp,
		ClearProp,
		GetThumbnail,
		GetPropCollections,
		GetPropCollection,
		PostPropCollections,
		PutPropCollection,
		DeletePropCollection,
		PauseProp,
		ResumeProp
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Props : IMessage<Props>, IMessage, IEquatable<Props>, IDeepCloneable<Props>
		{
			private static readonly MessageParser<Props> _parser = new MessageParser<Props>(() => new Props());

			private UnknownFieldSet _unknownFields;

			public const int Props_FieldNumber = 1;

			private static readonly FieldCodec<API_v1_PropData> _repeated_props_codec = FieldCodec.ForMessage(10u, API_v1_PropData.Parser);

			private readonly RepeatedField<API_v1_PropData> props_ = new RepeatedField<API_v1_PropData>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Props> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Prop_Response.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<API_v1_PropData> Props_ => props_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Props()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Props(Props other)
				: this()
			{
				props_ = other.props_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Props Clone()
			{
				return new Props(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Props);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Props other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!props_.Equals(other.props_))
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
				num ^= props_.GetHashCode();
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
				props_.WriteTo(output, _repeated_props_codec);
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
				num += props_.CalculateSize(_repeated_props_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Props other)
			{
				if (other != null)
				{
					props_.Add(other.props_);
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
						props_.AddEntriesFrom(input, _repeated_props_codec);
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetProp : IMessage<GetProp>, IMessage, IEquatable<GetProp>, IDeepCloneable<GetProp>
		{
			private static readonly MessageParser<GetProp> _parser = new MessageParser<GetProp>(() => new GetProp());

			private UnknownFieldSet _unknownFields;

			public const int PropFieldNumber = 1;

			private API_v1_PropData prop_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetProp> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Prop_Response.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_PropData Prop
			{
				get
				{
					return prop_;
				}
				set
				{
					prop_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetProp()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetProp(GetProp other)
				: this()
			{
				prop_ = ((other.prop_ != null) ? other.prop_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetProp Clone()
			{
				return new GetProp(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetProp);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetProp other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Prop, other.Prop))
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
				if (prop_ != null)
				{
					num ^= Prop.GetHashCode();
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
				if (prop_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Prop);
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
				if (prop_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Prop);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetProp other)
			{
				if (other == null)
				{
					return;
				}
				if (other.prop_ != null)
				{
					if (prop_ == null)
					{
						Prop = new API_v1_PropData();
					}
					Prop.MergeFrom(other.Prop);
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
					if (prop_ == null)
					{
						Prop = new API_v1_PropData();
					}
					input.ReadMessage(Prop);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PutProp : IMessage<PutProp>, IMessage, IEquatable<PutProp>, IDeepCloneable<PutProp>
		{
			private static readonly MessageParser<PutProp> _parser = new MessageParser<PutProp>(() => new PutProp());

			private UnknownFieldSet _unknownFields;

			public const int PropFieldNumber = 1;

			private API_v1_PropData prop_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutProp> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Prop_Response.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_PropData Prop
			{
				get
				{
					return prop_;
				}
				set
				{
					prop_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutProp()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutProp(PutProp other)
				: this()
			{
				prop_ = ((other.prop_ != null) ? other.prop_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutProp Clone()
			{
				return new PutProp(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PutProp);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PutProp other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Prop, other.Prop))
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
				if (prop_ != null)
				{
					num ^= Prop.GetHashCode();
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
				if (prop_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Prop);
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
				if (prop_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Prop);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PutProp other)
			{
				if (other == null)
				{
					return;
				}
				if (other.prop_ != null)
				{
					if (prop_ == null)
					{
						Prop = new API_v1_PropData();
					}
					Prop.MergeFrom(other.Prop);
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
					if (prop_ == null)
					{
						Prop = new API_v1_PropData();
					}
					input.ReadMessage(Prop);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class DeleteProp : IMessage<DeleteProp>, IMessage, IEquatable<DeleteProp>, IDeepCloneable<DeleteProp>
		{
			private static readonly MessageParser<DeleteProp> _parser = new MessageParser<DeleteProp>(() => new DeleteProp());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DeleteProp> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Prop_Response.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteProp()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteProp(DeleteProp other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeleteProp Clone()
			{
				return new DeleteProp(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as DeleteProp);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(DeleteProp other)
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
			public void MergeFrom(DeleteProp other)
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
		public sealed class TriggerProp : IMessage<TriggerProp>, IMessage, IEquatable<TriggerProp>, IDeepCloneable<TriggerProp>
		{
			private static readonly MessageParser<TriggerProp> _parser = new MessageParser<TriggerProp>(() => new TriggerProp());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<TriggerProp> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Prop_Response.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerProp()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerProp(TriggerProp other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerProp Clone()
			{
				return new TriggerProp(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as TriggerProp);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(TriggerProp other)
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
			public void MergeFrom(TriggerProp other)
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
		public sealed class ClearProp : IMessage<ClearProp>, IMessage, IEquatable<ClearProp>, IDeepCloneable<ClearProp>
		{
			private static readonly MessageParser<ClearProp> _parser = new MessageParser<ClearProp>(() => new ClearProp());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ClearProp> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Prop_Response.Descriptor.NestedTypes[5];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ClearProp()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ClearProp(ClearProp other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ClearProp Clone()
			{
				return new ClearProp(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ClearProp);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ClearProp other)
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
			public void MergeFrom(ClearProp other)
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
		public sealed class PauseProp : IMessage<PauseProp>, IMessage, IEquatable<PauseProp>, IDeepCloneable<PauseProp>
		{
			private static readonly MessageParser<PauseProp> _parser = new MessageParser<PauseProp>(() => new PauseProp());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PauseProp> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Prop_Response.Descriptor.NestedTypes[6];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PauseProp()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PauseProp(PauseProp other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PauseProp Clone()
			{
				return new PauseProp(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PauseProp);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PauseProp other)
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
			public void MergeFrom(PauseProp other)
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
		public sealed class ResumeProp : IMessage<ResumeProp>, IMessage, IEquatable<ResumeProp>, IDeepCloneable<ResumeProp>
		{
			private static readonly MessageParser<ResumeProp> _parser = new MessageParser<ResumeProp>(() => new ResumeProp());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ResumeProp> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Prop_Response.Descriptor.NestedTypes[7];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ResumeProp()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ResumeProp(ResumeProp other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ResumeProp Clone()
			{
				return new ResumeProp(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ResumeProp);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ResumeProp other)
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
			public void MergeFrom(ResumeProp other)
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
		public sealed class GetThumbnail : IMessage<GetThumbnail>, IMessage, IEquatable<GetThumbnail>, IDeepCloneable<GetThumbnail>
		{
			private static readonly MessageParser<GetThumbnail> _parser = new MessageParser<GetThumbnail>(() => new GetThumbnail());

			private UnknownFieldSet _unknownFields;

			public const int DataFieldNumber = 1;

			private ByteString data_ = ByteString.Empty;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetThumbnail> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Prop_Response.Descriptor.NestedTypes[8];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ByteString Data
			{
				get
				{
					return data_;
				}
				set
				{
					data_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetThumbnail()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetThumbnail(GetThumbnail other)
				: this()
			{
				data_ = other.data_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetThumbnail Clone()
			{
				return new GetThumbnail(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetThumbnail);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetThumbnail other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Data != other.Data)
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
				if (Data.Length != 0)
				{
					num ^= Data.GetHashCode();
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
				if (Data.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteBytes(Data);
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
				if (Data.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeBytesSize(Data);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetThumbnail other)
			{
				if (other != null)
				{
					if (other.Data.Length != 0)
					{
						Data = other.Data;
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
						Data = input.ReadBytes();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetPropCollections : IMessage<GetPropCollections>, IMessage, IEquatable<GetPropCollections>, IDeepCloneable<GetPropCollections>
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

					private static readonly FieldCodec<API_v1_PropCollection> _repeated_collections_codec = FieldCodec.ForMessage(10u, API_v1_PropCollection.Parser);

					private readonly RepeatedField<API_v1_PropCollection> collections_ = new RepeatedField<API_v1_PropCollection>();

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Collections> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => GetPropCollections.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RepeatedField<API_v1_PropCollection> Collections_ => collections_;

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

			private static readonly MessageParser<GetPropCollections> _parser = new MessageParser<GetPropCollections>(() => new GetPropCollections());

			private UnknownFieldSet _unknownFields;

			public const int PropCollectionsFieldNumber = 1;

			private Types.Collections propCollections_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetPropCollections> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Prop_Response.Descriptor.NestedTypes[9];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Collections PropCollections
			{
				get
				{
					return propCollections_;
				}
				set
				{
					propCollections_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetPropCollections()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetPropCollections(GetPropCollections other)
				: this()
			{
				propCollections_ = ((other.propCollections_ != null) ? other.propCollections_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetPropCollections Clone()
			{
				return new GetPropCollections(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetPropCollections);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetPropCollections other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(PropCollections, other.PropCollections))
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
				if (propCollections_ != null)
				{
					num ^= PropCollections.GetHashCode();
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
				if (propCollections_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(PropCollections);
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
				if (propCollections_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(PropCollections);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetPropCollections other)
			{
				if (other == null)
				{
					return;
				}
				if (other.propCollections_ != null)
				{
					if (propCollections_ == null)
					{
						PropCollections = new Types.Collections();
					}
					PropCollections.MergeFrom(other.PropCollections);
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
					if (propCollections_ == null)
					{
						PropCollections = new Types.Collections();
					}
					input.ReadMessage(PropCollections);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetPropCollection : IMessage<GetPropCollection>, IMessage, IEquatable<GetPropCollection>, IDeepCloneable<GetPropCollection>
		{
			private static readonly MessageParser<GetPropCollection> _parser = new MessageParser<GetPropCollection>(() => new GetPropCollection());

			private UnknownFieldSet _unknownFields;

			public const int PropCollectionFieldNumber = 1;

			private API_v1_PropCollection propCollection_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetPropCollection> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Prop_Response.Descriptor.NestedTypes[10];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_PropCollection PropCollection
			{
				get
				{
					return propCollection_;
				}
				set
				{
					propCollection_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetPropCollection()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetPropCollection(GetPropCollection other)
				: this()
			{
				propCollection_ = ((other.propCollection_ != null) ? other.propCollection_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetPropCollection Clone()
			{
				return new GetPropCollection(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetPropCollection);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetPropCollection other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(PropCollection, other.PropCollection))
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
				if (propCollection_ != null)
				{
					num ^= PropCollection.GetHashCode();
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
				if (propCollection_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(PropCollection);
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
				if (propCollection_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(PropCollection);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetPropCollection other)
			{
				if (other == null)
				{
					return;
				}
				if (other.propCollection_ != null)
				{
					if (propCollection_ == null)
					{
						PropCollection = new API_v1_PropCollection();
					}
					PropCollection.MergeFrom(other.PropCollection);
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
					if (propCollection_ == null)
					{
						PropCollection = new API_v1_PropCollection();
					}
					input.ReadMessage(PropCollection);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PostPropCollections : IMessage<PostPropCollections>, IMessage, IEquatable<PostPropCollections>, IDeepCloneable<PostPropCollections>
		{
			private static readonly MessageParser<PostPropCollections> _parser = new MessageParser<PostPropCollections>(() => new PostPropCollections());

			private UnknownFieldSet _unknownFields;

			public const int PropCollectionFieldNumber = 1;

			private API_v1_PropCollection propCollection_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PostPropCollections> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Prop_Response.Descriptor.NestedTypes[11];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_PropCollection PropCollection
			{
				get
				{
					return propCollection_;
				}
				set
				{
					propCollection_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PostPropCollections()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PostPropCollections(PostPropCollections other)
				: this()
			{
				propCollection_ = ((other.propCollection_ != null) ? other.propCollection_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PostPropCollections Clone()
			{
				return new PostPropCollections(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PostPropCollections);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PostPropCollections other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(PropCollection, other.PropCollection))
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
				if (propCollection_ != null)
				{
					num ^= PropCollection.GetHashCode();
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
				if (propCollection_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(PropCollection);
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
				if (propCollection_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(PropCollection);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PostPropCollections other)
			{
				if (other == null)
				{
					return;
				}
				if (other.propCollection_ != null)
				{
					if (propCollection_ == null)
					{
						PropCollection = new API_v1_PropCollection();
					}
					PropCollection.MergeFrom(other.PropCollection);
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
					if (propCollection_ == null)
					{
						PropCollection = new API_v1_PropCollection();
					}
					input.ReadMessage(PropCollection);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PutPropCollection : IMessage<PutPropCollection>, IMessage, IEquatable<PutPropCollection>, IDeepCloneable<PutPropCollection>
		{
			private static readonly MessageParser<PutPropCollection> _parser = new MessageParser<PutPropCollection>(() => new PutPropCollection());

			private UnknownFieldSet _unknownFields;

			public const int PropCollectionFieldNumber = 1;

			private API_v1_PropCollection propCollection_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PutPropCollection> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Prop_Response.Descriptor.NestedTypes[12];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_PropCollection PropCollection
			{
				get
				{
					return propCollection_;
				}
				set
				{
					propCollection_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutPropCollection()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutPropCollection(PutPropCollection other)
				: this()
			{
				propCollection_ = ((other.propCollection_ != null) ? other.propCollection_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PutPropCollection Clone()
			{
				return new PutPropCollection(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PutPropCollection);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PutPropCollection other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(PropCollection, other.PropCollection))
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
				if (propCollection_ != null)
				{
					num ^= PropCollection.GetHashCode();
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
				if (propCollection_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(PropCollection);
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
				if (propCollection_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(PropCollection);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PutPropCollection other)
			{
				if (other == null)
				{
					return;
				}
				if (other.propCollection_ != null)
				{
					if (propCollection_ == null)
					{
						PropCollection = new API_v1_PropCollection();
					}
					PropCollection.MergeFrom(other.PropCollection);
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
					if (propCollection_ == null)
					{
						PropCollection = new API_v1_PropCollection();
					}
					input.ReadMessage(PropCollection);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class DeletePropCollection : IMessage<DeletePropCollection>, IMessage, IEquatable<DeletePropCollection>, IDeepCloneable<DeletePropCollection>
		{
			private static readonly MessageParser<DeletePropCollection> _parser = new MessageParser<DeletePropCollection>(() => new DeletePropCollection());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<DeletePropCollection> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Prop_Response.Descriptor.NestedTypes[13];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeletePropCollection()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeletePropCollection(DeletePropCollection other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DeletePropCollection Clone()
			{
				return new DeletePropCollection(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as DeletePropCollection);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(DeletePropCollection other)
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
			public void MergeFrom(DeletePropCollection other)
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

	private static readonly MessageParser<API_v1_Prop_Response> _parser = new MessageParser<API_v1_Prop_Response>(() => new API_v1_Prop_Response());

	private UnknownFieldSet _unknownFields;

	public const int PropsFieldNumber = 1;

	public const int GetPropFieldNumber = 2;

	public const int PutPropFieldNumber = 3;

	public const int DeletePropFieldNumber = 4;

	public const int TriggerPropFieldNumber = 5;

	public const int ClearPropFieldNumber = 6;

	public const int GetThumbnailFieldNumber = 7;

	public const int GetPropCollectionsFieldNumber = 8;

	public const int GetPropCollectionFieldNumber = 9;

	public const int PostPropCollectionsFieldNumber = 10;

	public const int PutPropCollectionFieldNumber = 11;

	public const int DeletePropCollectionFieldNumber = 12;

	public const int PausePropFieldNumber = 13;

	public const int ResumePropFieldNumber = 14;

	private object response_;

	private ResponseOneofCase responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Prop_Response> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1PropReflection.Descriptor.MessageTypes[4];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Props Props
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Props)
			{
				return null;
			}
			return (Types.Props)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Props : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetProp GetProp
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetProp)
			{
				return null;
			}
			return (Types.GetProp)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetProp : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutProp PutProp
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PutProp)
			{
				return null;
			}
			return (Types.PutProp)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PutProp : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DeleteProp DeleteProp
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.DeleteProp)
			{
				return null;
			}
			return (Types.DeleteProp)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.DeleteProp : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.TriggerProp TriggerProp
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.TriggerProp)
			{
				return null;
			}
			return (Types.TriggerProp)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.TriggerProp : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ClearProp ClearProp
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.ClearProp)
			{
				return null;
			}
			return (Types.ClearProp)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.ClearProp : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetThumbnail GetThumbnail
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetThumbnail)
			{
				return null;
			}
			return (Types.GetThumbnail)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetThumbnail : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetPropCollections GetPropCollections
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetPropCollections)
			{
				return null;
			}
			return (Types.GetPropCollections)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetPropCollections : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetPropCollection GetPropCollection
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetPropCollection)
			{
				return null;
			}
			return (Types.GetPropCollection)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetPropCollection : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PostPropCollections PostPropCollections
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PostPropCollections)
			{
				return null;
			}
			return (Types.PostPropCollections)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PostPropCollections : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PutPropCollection PutPropCollection
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PutPropCollection)
			{
				return null;
			}
			return (Types.PutPropCollection)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PutPropCollection : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.DeletePropCollection DeletePropCollection
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.DeletePropCollection)
			{
				return null;
			}
			return (Types.DeletePropCollection)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.DeletePropCollection : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PauseProp PauseProp
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PauseProp)
			{
				return null;
			}
			return (Types.PauseProp)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PauseProp : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ResumeProp ResumeProp
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.ResumeProp)
			{
				return null;
			}
			return (Types.ResumeProp)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.ResumeProp : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResponseOneofCase ResponseCase => responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Prop_Response()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Prop_Response(API_v1_Prop_Response other)
		: this()
	{
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.Props:
			Props = other.Props.Clone();
			break;
		case ResponseOneofCase.GetProp:
			GetProp = other.GetProp.Clone();
			break;
		case ResponseOneofCase.PutProp:
			PutProp = other.PutProp.Clone();
			break;
		case ResponseOneofCase.DeleteProp:
			DeleteProp = other.DeleteProp.Clone();
			break;
		case ResponseOneofCase.TriggerProp:
			TriggerProp = other.TriggerProp.Clone();
			break;
		case ResponseOneofCase.ClearProp:
			ClearProp = other.ClearProp.Clone();
			break;
		case ResponseOneofCase.GetThumbnail:
			GetThumbnail = other.GetThumbnail.Clone();
			break;
		case ResponseOneofCase.GetPropCollections:
			GetPropCollections = other.GetPropCollections.Clone();
			break;
		case ResponseOneofCase.GetPropCollection:
			GetPropCollection = other.GetPropCollection.Clone();
			break;
		case ResponseOneofCase.PostPropCollections:
			PostPropCollections = other.PostPropCollections.Clone();
			break;
		case ResponseOneofCase.PutPropCollection:
			PutPropCollection = other.PutPropCollection.Clone();
			break;
		case ResponseOneofCase.DeletePropCollection:
			DeletePropCollection = other.DeletePropCollection.Clone();
			break;
		case ResponseOneofCase.PauseProp:
			PauseProp = other.PauseProp.Clone();
			break;
		case ResponseOneofCase.ResumeProp:
			ResumeProp = other.ResumeProp.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Prop_Response Clone()
	{
		return new API_v1_Prop_Response(this);
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
		return Equals(other as API_v1_Prop_Response);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Prop_Response other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Props, other.Props))
		{
			return false;
		}
		if (!object.Equals(GetProp, other.GetProp))
		{
			return false;
		}
		if (!object.Equals(PutProp, other.PutProp))
		{
			return false;
		}
		if (!object.Equals(DeleteProp, other.DeleteProp))
		{
			return false;
		}
		if (!object.Equals(TriggerProp, other.TriggerProp))
		{
			return false;
		}
		if (!object.Equals(ClearProp, other.ClearProp))
		{
			return false;
		}
		if (!object.Equals(GetThumbnail, other.GetThumbnail))
		{
			return false;
		}
		if (!object.Equals(GetPropCollections, other.GetPropCollections))
		{
			return false;
		}
		if (!object.Equals(GetPropCollection, other.GetPropCollection))
		{
			return false;
		}
		if (!object.Equals(PostPropCollections, other.PostPropCollections))
		{
			return false;
		}
		if (!object.Equals(PutPropCollection, other.PutPropCollection))
		{
			return false;
		}
		if (!object.Equals(DeletePropCollection, other.DeletePropCollection))
		{
			return false;
		}
		if (!object.Equals(PauseProp, other.PauseProp))
		{
			return false;
		}
		if (!object.Equals(ResumeProp, other.ResumeProp))
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
		if (responseCase_ == ResponseOneofCase.Props)
		{
			num ^= Props.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetProp)
		{
			num ^= GetProp.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PutProp)
		{
			num ^= PutProp.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.DeleteProp)
		{
			num ^= DeleteProp.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.TriggerProp)
		{
			num ^= TriggerProp.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.ClearProp)
		{
			num ^= ClearProp.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetThumbnail)
		{
			num ^= GetThumbnail.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetPropCollections)
		{
			num ^= GetPropCollections.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetPropCollection)
		{
			num ^= GetPropCollection.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PostPropCollections)
		{
			num ^= PostPropCollections.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PutPropCollection)
		{
			num ^= PutPropCollection.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.DeletePropCollection)
		{
			num ^= DeletePropCollection.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.PauseProp)
		{
			num ^= PauseProp.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.ResumeProp)
		{
			num ^= ResumeProp.GetHashCode();
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
		if (responseCase_ == ResponseOneofCase.Props)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Props);
		}
		if (responseCase_ == ResponseOneofCase.GetProp)
		{
			output.WriteRawTag(18);
			output.WriteMessage(GetProp);
		}
		if (responseCase_ == ResponseOneofCase.PutProp)
		{
			output.WriteRawTag(26);
			output.WriteMessage(PutProp);
		}
		if (responseCase_ == ResponseOneofCase.DeleteProp)
		{
			output.WriteRawTag(34);
			output.WriteMessage(DeleteProp);
		}
		if (responseCase_ == ResponseOneofCase.TriggerProp)
		{
			output.WriteRawTag(42);
			output.WriteMessage(TriggerProp);
		}
		if (responseCase_ == ResponseOneofCase.ClearProp)
		{
			output.WriteRawTag(50);
			output.WriteMessage(ClearProp);
		}
		if (responseCase_ == ResponseOneofCase.GetThumbnail)
		{
			output.WriteRawTag(58);
			output.WriteMessage(GetThumbnail);
		}
		if (responseCase_ == ResponseOneofCase.GetPropCollections)
		{
			output.WriteRawTag(66);
			output.WriteMessage(GetPropCollections);
		}
		if (responseCase_ == ResponseOneofCase.GetPropCollection)
		{
			output.WriteRawTag(74);
			output.WriteMessage(GetPropCollection);
		}
		if (responseCase_ == ResponseOneofCase.PostPropCollections)
		{
			output.WriteRawTag(82);
			output.WriteMessage(PostPropCollections);
		}
		if (responseCase_ == ResponseOneofCase.PutPropCollection)
		{
			output.WriteRawTag(90);
			output.WriteMessage(PutPropCollection);
		}
		if (responseCase_ == ResponseOneofCase.DeletePropCollection)
		{
			output.WriteRawTag(98);
			output.WriteMessage(DeletePropCollection);
		}
		if (responseCase_ == ResponseOneofCase.PauseProp)
		{
			output.WriteRawTag(106);
			output.WriteMessage(PauseProp);
		}
		if (responseCase_ == ResponseOneofCase.ResumeProp)
		{
			output.WriteRawTag(114);
			output.WriteMessage(ResumeProp);
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
		if (responseCase_ == ResponseOneofCase.Props)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Props);
		}
		if (responseCase_ == ResponseOneofCase.GetProp)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetProp);
		}
		if (responseCase_ == ResponseOneofCase.PutProp)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutProp);
		}
		if (responseCase_ == ResponseOneofCase.DeleteProp)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DeleteProp);
		}
		if (responseCase_ == ResponseOneofCase.TriggerProp)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TriggerProp);
		}
		if (responseCase_ == ResponseOneofCase.ClearProp)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ClearProp);
		}
		if (responseCase_ == ResponseOneofCase.GetThumbnail)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetThumbnail);
		}
		if (responseCase_ == ResponseOneofCase.GetPropCollections)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetPropCollections);
		}
		if (responseCase_ == ResponseOneofCase.GetPropCollection)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetPropCollection);
		}
		if (responseCase_ == ResponseOneofCase.PostPropCollections)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PostPropCollections);
		}
		if (responseCase_ == ResponseOneofCase.PutPropCollection)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PutPropCollection);
		}
		if (responseCase_ == ResponseOneofCase.DeletePropCollection)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DeletePropCollection);
		}
		if (responseCase_ == ResponseOneofCase.PauseProp)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PauseProp);
		}
		if (responseCase_ == ResponseOneofCase.ResumeProp)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ResumeProp);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Prop_Response other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.Props:
			if (Props == null)
			{
				Props = new Types.Props();
			}
			Props.MergeFrom(other.Props);
			break;
		case ResponseOneofCase.GetProp:
			if (GetProp == null)
			{
				GetProp = new Types.GetProp();
			}
			GetProp.MergeFrom(other.GetProp);
			break;
		case ResponseOneofCase.PutProp:
			if (PutProp == null)
			{
				PutProp = new Types.PutProp();
			}
			PutProp.MergeFrom(other.PutProp);
			break;
		case ResponseOneofCase.DeleteProp:
			if (DeleteProp == null)
			{
				DeleteProp = new Types.DeleteProp();
			}
			DeleteProp.MergeFrom(other.DeleteProp);
			break;
		case ResponseOneofCase.TriggerProp:
			if (TriggerProp == null)
			{
				TriggerProp = new Types.TriggerProp();
			}
			TriggerProp.MergeFrom(other.TriggerProp);
			break;
		case ResponseOneofCase.ClearProp:
			if (ClearProp == null)
			{
				ClearProp = new Types.ClearProp();
			}
			ClearProp.MergeFrom(other.ClearProp);
			break;
		case ResponseOneofCase.GetThumbnail:
			if (GetThumbnail == null)
			{
				GetThumbnail = new Types.GetThumbnail();
			}
			GetThumbnail.MergeFrom(other.GetThumbnail);
			break;
		case ResponseOneofCase.GetPropCollections:
			if (GetPropCollections == null)
			{
				GetPropCollections = new Types.GetPropCollections();
			}
			GetPropCollections.MergeFrom(other.GetPropCollections);
			break;
		case ResponseOneofCase.GetPropCollection:
			if (GetPropCollection == null)
			{
				GetPropCollection = new Types.GetPropCollection();
			}
			GetPropCollection.MergeFrom(other.GetPropCollection);
			break;
		case ResponseOneofCase.PostPropCollections:
			if (PostPropCollections == null)
			{
				PostPropCollections = new Types.PostPropCollections();
			}
			PostPropCollections.MergeFrom(other.PostPropCollections);
			break;
		case ResponseOneofCase.PutPropCollection:
			if (PutPropCollection == null)
			{
				PutPropCollection = new Types.PutPropCollection();
			}
			PutPropCollection.MergeFrom(other.PutPropCollection);
			break;
		case ResponseOneofCase.DeletePropCollection:
			if (DeletePropCollection == null)
			{
				DeletePropCollection = new Types.DeletePropCollection();
			}
			DeletePropCollection.MergeFrom(other.DeletePropCollection);
			break;
		case ResponseOneofCase.PauseProp:
			if (PauseProp == null)
			{
				PauseProp = new Types.PauseProp();
			}
			PauseProp.MergeFrom(other.PauseProp);
			break;
		case ResponseOneofCase.ResumeProp:
			if (ResumeProp == null)
			{
				ResumeProp = new Types.ResumeProp();
			}
			ResumeProp.MergeFrom(other.ResumeProp);
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
				Types.Props props = new Types.Props();
				if (responseCase_ == ResponseOneofCase.Props)
				{
					props.MergeFrom(Props);
				}
				input.ReadMessage(props);
				Props = props;
				break;
			}
			case 18u:
			{
				Types.GetProp getProp = new Types.GetProp();
				if (responseCase_ == ResponseOneofCase.GetProp)
				{
					getProp.MergeFrom(GetProp);
				}
				input.ReadMessage(getProp);
				GetProp = getProp;
				break;
			}
			case 26u:
			{
				Types.PutProp putProp = new Types.PutProp();
				if (responseCase_ == ResponseOneofCase.PutProp)
				{
					putProp.MergeFrom(PutProp);
				}
				input.ReadMessage(putProp);
				PutProp = putProp;
				break;
			}
			case 34u:
			{
				Types.DeleteProp deleteProp = new Types.DeleteProp();
				if (responseCase_ == ResponseOneofCase.DeleteProp)
				{
					deleteProp.MergeFrom(DeleteProp);
				}
				input.ReadMessage(deleteProp);
				DeleteProp = deleteProp;
				break;
			}
			case 42u:
			{
				Types.TriggerProp triggerProp = new Types.TriggerProp();
				if (responseCase_ == ResponseOneofCase.TriggerProp)
				{
					triggerProp.MergeFrom(TriggerProp);
				}
				input.ReadMessage(triggerProp);
				TriggerProp = triggerProp;
				break;
			}
			case 50u:
			{
				Types.ClearProp clearProp = new Types.ClearProp();
				if (responseCase_ == ResponseOneofCase.ClearProp)
				{
					clearProp.MergeFrom(ClearProp);
				}
				input.ReadMessage(clearProp);
				ClearProp = clearProp;
				break;
			}
			case 58u:
			{
				Types.GetThumbnail getThumbnail = new Types.GetThumbnail();
				if (responseCase_ == ResponseOneofCase.GetThumbnail)
				{
					getThumbnail.MergeFrom(GetThumbnail);
				}
				input.ReadMessage(getThumbnail);
				GetThumbnail = getThumbnail;
				break;
			}
			case 66u:
			{
				Types.GetPropCollections getPropCollections = new Types.GetPropCollections();
				if (responseCase_ == ResponseOneofCase.GetPropCollections)
				{
					getPropCollections.MergeFrom(GetPropCollections);
				}
				input.ReadMessage(getPropCollections);
				GetPropCollections = getPropCollections;
				break;
			}
			case 74u:
			{
				Types.GetPropCollection getPropCollection = new Types.GetPropCollection();
				if (responseCase_ == ResponseOneofCase.GetPropCollection)
				{
					getPropCollection.MergeFrom(GetPropCollection);
				}
				input.ReadMessage(getPropCollection);
				GetPropCollection = getPropCollection;
				break;
			}
			case 82u:
			{
				Types.PostPropCollections postPropCollections = new Types.PostPropCollections();
				if (responseCase_ == ResponseOneofCase.PostPropCollections)
				{
					postPropCollections.MergeFrom(PostPropCollections);
				}
				input.ReadMessage(postPropCollections);
				PostPropCollections = postPropCollections;
				break;
			}
			case 90u:
			{
				Types.PutPropCollection putPropCollection = new Types.PutPropCollection();
				if (responseCase_ == ResponseOneofCase.PutPropCollection)
				{
					putPropCollection.MergeFrom(PutPropCollection);
				}
				input.ReadMessage(putPropCollection);
				PutPropCollection = putPropCollection;
				break;
			}
			case 98u:
			{
				Types.DeletePropCollection deletePropCollection = new Types.DeletePropCollection();
				if (responseCase_ == ResponseOneofCase.DeletePropCollection)
				{
					deletePropCollection.MergeFrom(DeletePropCollection);
				}
				input.ReadMessage(deletePropCollection);
				DeletePropCollection = deletePropCollection;
				break;
			}
			case 106u:
			{
				Types.PauseProp pauseProp = new Types.PauseProp();
				if (responseCase_ == ResponseOneofCase.PauseProp)
				{
					pauseProp.MergeFrom(PauseProp);
				}
				input.ReadMessage(pauseProp);
				PauseProp = pauseProp;
				break;
			}
			case 114u:
			{
				Types.ResumeProp resumeProp = new Types.ResumeProp();
				if (responseCase_ == ResponseOneofCase.ResumeProp)
				{
					resumeProp.MergeFrom(ResumeProp);
				}
				input.ReadMessage(resumeProp);
				ResumeProp = resumeProp;
				break;
			}
			}
		}
	}
}
