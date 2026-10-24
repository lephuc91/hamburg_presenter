using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Preroll_Response : IMessage<API_v1_Preroll_Response>, IMessage, IEquatable<API_v1_Preroll_Response>, IDeepCloneable<API_v1_Preroll_Response>
{
	public enum ResponseOneofCase
	{
		None = 0,
		PrerollReady = 1,
		ActivatePrerollItem = 3,
		CancelPrerollItem = 4
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class PrerollReady : IMessage<PrerollReady>, IMessage, IEquatable<PrerollReady>, IDeepCloneable<PrerollReady>
		{
			private static readonly MessageParser<PrerollReady> _parser = new MessageParser<PrerollReady>(() => new PrerollReady());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private ulong id_;

			public const int LatencyFieldNumber = 2;

			private ulong latency_;

			public const int TimeFieldNumber = 3;

			private ulong time_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<PrerollReady> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Preroll_Response.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ulong Id
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
			public ulong Latency
			{
				get
				{
					return latency_;
				}
				set
				{
					latency_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ulong Time
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
			public PrerollReady()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PrerollReady(PrerollReady other)
				: this()
			{
				id_ = other.id_;
				latency_ = other.latency_;
				time_ = other.time_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PrerollReady Clone()
			{
				return new PrerollReady(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as PrerollReady);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(PrerollReady other)
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
				if (Latency != other.Latency)
				{
					return false;
				}
				if (Time != other.Time)
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
				if (Id != 0L)
				{
					num ^= Id.GetHashCode();
				}
				if (Latency != 0L)
				{
					num ^= Latency.GetHashCode();
				}
				if (Time != 0L)
				{
					num ^= Time.GetHashCode();
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
				if (Id != 0L)
				{
					output.WriteRawTag(8);
					output.WriteUInt64(Id);
				}
				if (Latency != 0L)
				{
					output.WriteRawTag(16);
					output.WriteUInt64(Latency);
				}
				if (Time != 0L)
				{
					output.WriteRawTag(24);
					output.WriteUInt64(Time);
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
				if (Id != 0L)
				{
					num += 1 + CodedOutputStream.ComputeUInt64Size(Id);
				}
				if (Latency != 0L)
				{
					num += 1 + CodedOutputStream.ComputeUInt64Size(Latency);
				}
				if (Time != 0L)
				{
					num += 1 + CodedOutputStream.ComputeUInt64Size(Time);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(PrerollReady other)
			{
				if (other != null)
				{
					if (other.Id != 0L)
					{
						Id = other.Id;
					}
					if (other.Latency != 0L)
					{
						Latency = other.Latency;
					}
					if (other.Time != 0L)
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
					switch (num)
					{
					default:
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						break;
					case 8u:
						Id = input.ReadUInt64();
						break;
					case 16u:
						Latency = input.ReadUInt64();
						break;
					case 24u:
						Time = input.ReadUInt64();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class ActivatePrerollItem : IMessage<ActivatePrerollItem>, IMessage, IEquatable<ActivatePrerollItem>, IDeepCloneable<ActivatePrerollItem>
		{
			private static readonly MessageParser<ActivatePrerollItem> _parser = new MessageParser<ActivatePrerollItem>(() => new ActivatePrerollItem());

			private UnknownFieldSet _unknownFields;

			public const int SuccessFieldNumber = 1;

			private bool success_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ActivatePrerollItem> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Preroll_Response.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Success
			{
				get
				{
					return success_;
				}
				set
				{
					success_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActivatePrerollItem()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActivatePrerollItem(ActivatePrerollItem other)
				: this()
			{
				success_ = other.success_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ActivatePrerollItem Clone()
			{
				return new ActivatePrerollItem(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ActivatePrerollItem);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ActivatePrerollItem other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Success != other.Success)
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
				if (Success)
				{
					num ^= Success.GetHashCode();
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
				if (Success)
				{
					output.WriteRawTag(8);
					output.WriteBool(Success);
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
				if (Success)
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
			public void MergeFrom(ActivatePrerollItem other)
			{
				if (other != null)
				{
					if (other.Success)
					{
						Success = other.Success;
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
						Success = input.ReadBool();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class CancelPrerollItem : IMessage<CancelPrerollItem>, IMessage, IEquatable<CancelPrerollItem>, IDeepCloneable<CancelPrerollItem>
		{
			private static readonly MessageParser<CancelPrerollItem> _parser = new MessageParser<CancelPrerollItem>(() => new CancelPrerollItem());

			private UnknownFieldSet _unknownFields;

			public const int SuccessFieldNumber = 1;

			private bool success_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<CancelPrerollItem> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Preroll_Response.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Success
			{
				get
				{
					return success_;
				}
				set
				{
					success_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CancelPrerollItem()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CancelPrerollItem(CancelPrerollItem other)
				: this()
			{
				success_ = other.success_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CancelPrerollItem Clone()
			{
				return new CancelPrerollItem(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as CancelPrerollItem);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(CancelPrerollItem other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Success != other.Success)
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
				if (Success)
				{
					num ^= Success.GetHashCode();
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
				if (Success)
				{
					output.WriteRawTag(8);
					output.WriteBool(Success);
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
				if (Success)
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
			public void MergeFrom(CancelPrerollItem other)
			{
				if (other != null)
				{
					if (other.Success)
					{
						Success = other.Success;
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
						Success = input.ReadBool();
					}
				}
			}
		}
	}

	private static readonly MessageParser<API_v1_Preroll_Response> _parser = new MessageParser<API_v1_Preroll_Response>(() => new API_v1_Preroll_Response());

	private UnknownFieldSet _unknownFields;

	public const int PrerollReadyFieldNumber = 1;

	public const int ActivatePrerollItemFieldNumber = 3;

	public const int CancelPrerollItemFieldNumber = 4;

	private object response_;

	private ResponseOneofCase responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Preroll_Response> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1PrerollReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.PrerollReady PrerollReady
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.PrerollReady)
			{
				return null;
			}
			return (Types.PrerollReady)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.PrerollReady : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.ActivatePrerollItem ActivatePrerollItem
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.ActivatePrerollItem)
			{
				return null;
			}
			return (Types.ActivatePrerollItem)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.ActivatePrerollItem : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.CancelPrerollItem CancelPrerollItem
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.CancelPrerollItem)
			{
				return null;
			}
			return (Types.CancelPrerollItem)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.CancelPrerollItem : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResponseOneofCase ResponseCase => responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Preroll_Response()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Preroll_Response(API_v1_Preroll_Response other)
		: this()
	{
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.PrerollReady:
			PrerollReady = other.PrerollReady.Clone();
			break;
		case ResponseOneofCase.ActivatePrerollItem:
			ActivatePrerollItem = other.ActivatePrerollItem.Clone();
			break;
		case ResponseOneofCase.CancelPrerollItem:
			CancelPrerollItem = other.CancelPrerollItem.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Preroll_Response Clone()
	{
		return new API_v1_Preroll_Response(this);
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
		return Equals(other as API_v1_Preroll_Response);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Preroll_Response other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(PrerollReady, other.PrerollReady))
		{
			return false;
		}
		if (!object.Equals(ActivatePrerollItem, other.ActivatePrerollItem))
		{
			return false;
		}
		if (!object.Equals(CancelPrerollItem, other.CancelPrerollItem))
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
		if (responseCase_ == ResponseOneofCase.PrerollReady)
		{
			num ^= PrerollReady.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.ActivatePrerollItem)
		{
			num ^= ActivatePrerollItem.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.CancelPrerollItem)
		{
			num ^= CancelPrerollItem.GetHashCode();
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
		if (responseCase_ == ResponseOneofCase.PrerollReady)
		{
			output.WriteRawTag(10);
			output.WriteMessage(PrerollReady);
		}
		if (responseCase_ == ResponseOneofCase.ActivatePrerollItem)
		{
			output.WriteRawTag(26);
			output.WriteMessage(ActivatePrerollItem);
		}
		if (responseCase_ == ResponseOneofCase.CancelPrerollItem)
		{
			output.WriteRawTag(34);
			output.WriteMessage(CancelPrerollItem);
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
		if (responseCase_ == ResponseOneofCase.PrerollReady)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PrerollReady);
		}
		if (responseCase_ == ResponseOneofCase.ActivatePrerollItem)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ActivatePrerollItem);
		}
		if (responseCase_ == ResponseOneofCase.CancelPrerollItem)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CancelPrerollItem);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Preroll_Response other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.PrerollReady:
			if (PrerollReady == null)
			{
				PrerollReady = new Types.PrerollReady();
			}
			PrerollReady.MergeFrom(other.PrerollReady);
			break;
		case ResponseOneofCase.ActivatePrerollItem:
			if (ActivatePrerollItem == null)
			{
				ActivatePrerollItem = new Types.ActivatePrerollItem();
			}
			ActivatePrerollItem.MergeFrom(other.ActivatePrerollItem);
			break;
		case ResponseOneofCase.CancelPrerollItem:
			if (CancelPrerollItem == null)
			{
				CancelPrerollItem = new Types.CancelPrerollItem();
			}
			CancelPrerollItem.MergeFrom(other.CancelPrerollItem);
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
				Types.PrerollReady prerollReady = new Types.PrerollReady();
				if (responseCase_ == ResponseOneofCase.PrerollReady)
				{
					prerollReady.MergeFrom(PrerollReady);
				}
				input.ReadMessage(prerollReady);
				PrerollReady = prerollReady;
				break;
			}
			case 26u:
			{
				Types.ActivatePrerollItem activatePrerollItem = new Types.ActivatePrerollItem();
				if (responseCase_ == ResponseOneofCase.ActivatePrerollItem)
				{
					activatePrerollItem.MergeFrom(ActivatePrerollItem);
				}
				input.ReadMessage(activatePrerollItem);
				ActivatePrerollItem = activatePrerollItem;
				break;
			}
			case 34u:
			{
				Types.CancelPrerollItem cancelPrerollItem = new Types.CancelPrerollItem();
				if (responseCase_ == ResponseOneofCase.CancelPrerollItem)
				{
					cancelPrerollItem.MergeFrom(CancelPrerollItem);
				}
				input.ReadMessage(cancelPrerollItem);
				CancelPrerollItem = cancelPrerollItem;
				break;
			}
			}
		}
	}
}
