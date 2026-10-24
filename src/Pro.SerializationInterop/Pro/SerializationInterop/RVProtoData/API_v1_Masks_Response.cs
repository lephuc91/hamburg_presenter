using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Masks_Response : IMessage<API_v1_Masks_Response>, IMessage, IEquatable<API_v1_Masks_Response>, IDeepCloneable<API_v1_Masks_Response>
{
	public enum ResponseOneofCase
	{
		None,
		Masks,
		GetMask,
		GetThumbnail
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Masks : IMessage<Masks>, IMessage, IEquatable<Masks>, IDeepCloneable<Masks>
		{
			private static readonly MessageParser<Masks> _parser = new MessageParser<Masks>(() => new Masks());

			private UnknownFieldSet _unknownFields;

			public const int Masks_FieldNumber = 1;

			private static readonly FieldCodec<API_v1_Identifier> _repeated_masks_codec = FieldCodec.ForMessage(10u, API_v1_Identifier.Parser);

			private readonly RepeatedField<API_v1_Identifier> masks_ = new RepeatedField<API_v1_Identifier>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Masks> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Masks_Response.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<API_v1_Identifier> Masks_ => masks_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Masks()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Masks(Masks other)
				: this()
			{
				masks_ = other.masks_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Masks Clone()
			{
				return new Masks(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Masks);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Masks other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!masks_.Equals(other.masks_))
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
				num ^= masks_.GetHashCode();
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
				masks_.WriteTo(output, _repeated_masks_codec);
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
				num += masks_.CalculateSize(_repeated_masks_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Masks other)
			{
				if (other != null)
				{
					masks_.Add(other.masks_);
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
						masks_.AddEntriesFrom(input, _repeated_masks_codec);
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetMask : IMessage<GetMask>, IMessage, IEquatable<GetMask>, IDeepCloneable<GetMask>
		{
			private static readonly MessageParser<GetMask> _parser = new MessageParser<GetMask>(() => new GetMask());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private API_v1_Identifier id_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetMask> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Masks_Response.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Identifier Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetMask()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetMask(GetMask other)
				: this()
			{
				id_ = ((other.id_ != null) ? other.id_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetMask Clone()
			{
				return new GetMask(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetMask);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetMask other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Id, other.Id))
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
				if (id_ != null)
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
				if (id_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Id);
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
				if (id_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Id);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetMask other)
			{
				if (other == null)
				{
					return;
				}
				if (other.id_ != null)
				{
					if (id_ == null)
					{
						Id = new API_v1_Identifier();
					}
					Id.MergeFrom(other.Id);
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
					if (id_ == null)
					{
						Id = new API_v1_Identifier();
					}
					input.ReadMessage(Id);
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
			public static MessageDescriptor Descriptor => API_v1_Masks_Response.Descriptor.NestedTypes[2];

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
	}

	private static readonly MessageParser<API_v1_Masks_Response> _parser = new MessageParser<API_v1_Masks_Response>(() => new API_v1_Masks_Response());

	private UnknownFieldSet _unknownFields;

	public const int MasksFieldNumber = 1;

	public const int GetMaskFieldNumber = 2;

	public const int GetThumbnailFieldNumber = 3;

	private object response_;

	private ResponseOneofCase responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Masks_Response> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1MasksReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Masks Masks
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Masks)
			{
				return null;
			}
			return (Types.Masks)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Masks : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetMask GetMask
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetMask)
			{
				return null;
			}
			return (Types.GetMask)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetMask : ResponseOneofCase.None);
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
	public ResponseOneofCase ResponseCase => responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Masks_Response()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Masks_Response(API_v1_Masks_Response other)
		: this()
	{
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.Masks:
			Masks = other.Masks.Clone();
			break;
		case ResponseOneofCase.GetMask:
			GetMask = other.GetMask.Clone();
			break;
		case ResponseOneofCase.GetThumbnail:
			GetThumbnail = other.GetThumbnail.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Masks_Response Clone()
	{
		return new API_v1_Masks_Response(this);
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
		return Equals(other as API_v1_Masks_Response);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Masks_Response other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Masks, other.Masks))
		{
			return false;
		}
		if (!object.Equals(GetMask, other.GetMask))
		{
			return false;
		}
		if (!object.Equals(GetThumbnail, other.GetThumbnail))
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
		if (responseCase_ == ResponseOneofCase.Masks)
		{
			num ^= Masks.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetMask)
		{
			num ^= GetMask.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetThumbnail)
		{
			num ^= GetThumbnail.GetHashCode();
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
		if (responseCase_ == ResponseOneofCase.Masks)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Masks);
		}
		if (responseCase_ == ResponseOneofCase.GetMask)
		{
			output.WriteRawTag(18);
			output.WriteMessage(GetMask);
		}
		if (responseCase_ == ResponseOneofCase.GetThumbnail)
		{
			output.WriteRawTag(26);
			output.WriteMessage(GetThumbnail);
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
		if (responseCase_ == ResponseOneofCase.Masks)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Masks);
		}
		if (responseCase_ == ResponseOneofCase.GetMask)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetMask);
		}
		if (responseCase_ == ResponseOneofCase.GetThumbnail)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetThumbnail);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Masks_Response other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.Masks:
			if (Masks == null)
			{
				Masks = new Types.Masks();
			}
			Masks.MergeFrom(other.Masks);
			break;
		case ResponseOneofCase.GetMask:
			if (GetMask == null)
			{
				GetMask = new Types.GetMask();
			}
			GetMask.MergeFrom(other.GetMask);
			break;
		case ResponseOneofCase.GetThumbnail:
			if (GetThumbnail == null)
			{
				GetThumbnail = new Types.GetThumbnail();
			}
			GetThumbnail.MergeFrom(other.GetThumbnail);
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
				Types.Masks masks = new Types.Masks();
				if (responseCase_ == ResponseOneofCase.Masks)
				{
					masks.MergeFrom(Masks);
				}
				input.ReadMessage(masks);
				Masks = masks;
				break;
			}
			case 18u:
			{
				Types.GetMask getMask = new Types.GetMask();
				if (responseCase_ == ResponseOneofCase.GetMask)
				{
					getMask.MergeFrom(GetMask);
				}
				input.ReadMessage(getMask);
				GetMask = getMask;
				break;
			}
			case 26u:
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
			}
		}
	}
}
