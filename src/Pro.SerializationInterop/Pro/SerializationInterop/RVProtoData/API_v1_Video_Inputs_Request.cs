using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Video_Inputs_Request : IMessage<API_v1_Video_Inputs_Request>, IMessage, IEquatable<API_v1_Video_Inputs_Request>, IDeepCloneable<API_v1_Video_Inputs_Request>
{
	public enum RequestOneofCase
	{
		None,
		GetAll,
		Trigger
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetAll : IMessage<GetAll>, IMessage, IEquatable<GetAll>, IDeepCloneable<GetAll>
		{
			private static readonly MessageParser<GetAll> _parser = new MessageParser<GetAll>(() => new GetAll());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetAll> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Video_Inputs_Request.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetAll()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetAll(GetAll other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetAll Clone()
			{
				return new GetAll(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetAll);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetAll other)
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
			public void MergeFrom(GetAll other)
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
		public sealed class Trigger : IMessage<Trigger>, IMessage, IEquatable<Trigger>, IDeepCloneable<Trigger>
		{
			private static readonly MessageParser<Trigger> _parser = new MessageParser<Trigger>(() => new Trigger());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Trigger> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Video_Inputs_Request.Descriptor.NestedTypes[1];

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
			public Trigger()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Trigger(Trigger other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Trigger Clone()
			{
				return new Trigger(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Trigger);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Trigger other)
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
			public void MergeFrom(Trigger other)
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

	private static readonly MessageParser<API_v1_Video_Inputs_Request> _parser = new MessageParser<API_v1_Video_Inputs_Request>(() => new API_v1_Video_Inputs_Request());

	private UnknownFieldSet _unknownFields;

	public const int GetAllFieldNumber = 1;

	public const int TriggerFieldNumber = 2;

	private object request_;

	private RequestOneofCase requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Video_Inputs_Request> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1VideoInputsReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetAll GetAll
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetAll)
			{
				return null;
			}
			return (Types.GetAll)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetAll : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Trigger Trigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Trigger)
			{
				return null;
			}
			return (Types.Trigger)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Trigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestOneofCase RequestCase => requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Video_Inputs_Request()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Video_Inputs_Request(API_v1_Video_Inputs_Request other)
		: this()
	{
		switch (other.RequestCase)
		{
		case RequestOneofCase.GetAll:
			GetAll = other.GetAll.Clone();
			break;
		case RequestOneofCase.Trigger:
			Trigger = other.Trigger.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Video_Inputs_Request Clone()
	{
		return new API_v1_Video_Inputs_Request(this);
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
		return Equals(other as API_v1_Video_Inputs_Request);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Video_Inputs_Request other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(GetAll, other.GetAll))
		{
			return false;
		}
		if (!object.Equals(Trigger, other.Trigger))
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
		if (requestCase_ == RequestOneofCase.GetAll)
		{
			num ^= GetAll.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Trigger)
		{
			num ^= Trigger.GetHashCode();
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
		if (requestCase_ == RequestOneofCase.GetAll)
		{
			output.WriteRawTag(10);
			output.WriteMessage(GetAll);
		}
		if (requestCase_ == RequestOneofCase.Trigger)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Trigger);
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
		if (requestCase_ == RequestOneofCase.GetAll)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetAll);
		}
		if (requestCase_ == RequestOneofCase.Trigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Trigger);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Video_Inputs_Request other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.RequestCase)
		{
		case RequestOneofCase.GetAll:
			if (GetAll == null)
			{
				GetAll = new Types.GetAll();
			}
			GetAll.MergeFrom(other.GetAll);
			break;
		case RequestOneofCase.Trigger:
			if (Trigger == null)
			{
				Trigger = new Types.Trigger();
			}
			Trigger.MergeFrom(other.Trigger);
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
				Types.GetAll getAll = new Types.GetAll();
				if (requestCase_ == RequestOneofCase.GetAll)
				{
					getAll.MergeFrom(GetAll);
				}
				input.ReadMessage(getAll);
				GetAll = getAll;
				break;
			}
			case 18u:
			{
				Types.Trigger trigger = new Types.Trigger();
				if (requestCase_ == RequestOneofCase.Trigger)
				{
					trigger.MergeFrom(Trigger);
				}
				input.ReadMessage(trigger);
				Trigger = trigger;
				break;
			}
			}
		}
	}
}
