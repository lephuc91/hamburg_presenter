using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class PropPauseRequest : IMessage<PropPauseRequest>, IMessage, IEquatable<PropPauseRequest>, IDeepCloneable<PropPauseRequest>
{
	public enum RequestTypeOneofCase
	{
		None = 0,
		Pause = 2,
		Resume = 3,
		Status = 4
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
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
			public static MessageDescriptor Descriptor => PropPauseRequest.Descriptor.NestedTypes[0];

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
		public sealed class Resume : IMessage<Resume>, IMessage, IEquatable<Resume>, IDeepCloneable<Resume>
		{
			private static readonly MessageParser<Resume> _parser = new MessageParser<Resume>(() => new Resume());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Resume> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => PropPauseRequest.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Resume()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Resume(Resume other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Resume Clone()
			{
				return new Resume(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Resume);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Resume other)
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
			public void MergeFrom(Resume other)
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
		public sealed class Status : IMessage<Status>, IMessage, IEquatable<Status>, IDeepCloneable<Status>
		{
			private static readonly MessageParser<Status> _parser = new MessageParser<Status>(() => new Status());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Status> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => PropPauseRequest.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Status()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Status(Status other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Status Clone()
			{
				return new Status(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Status);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Status other)
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
			public void MergeFrom(Status other)
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

	private static readonly MessageParser<PropPauseRequest> _parser = new MessageParser<PropPauseRequest>(() => new PropPauseRequest());

	private UnknownFieldSet _unknownFields;

	public const int PropIdFieldNumber = 1;

	private UUID propId_;

	public const int PauseFieldNumber = 2;

	public const int ResumeFieldNumber = 3;

	public const int StatusFieldNumber = 4;

	private object requestType_;

	private RequestTypeOneofCase requestTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<PropPauseRequest> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[15];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UUID PropId
	{
		get
		{
			return propId_;
		}
		set
		{
			propId_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Pause Pause
	{
		get
		{
			if (requestTypeCase_ != RequestTypeOneofCase.Pause)
			{
				return null;
			}
			return (Types.Pause)requestType_;
		}
		set
		{
			requestType_ = value;
			requestTypeCase_ = ((value != null) ? RequestTypeOneofCase.Pause : RequestTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Resume Resume
	{
		get
		{
			if (requestTypeCase_ != RequestTypeOneofCase.Resume)
			{
				return null;
			}
			return (Types.Resume)requestType_;
		}
		set
		{
			requestType_ = value;
			requestTypeCase_ = ((value != null) ? RequestTypeOneofCase.Resume : RequestTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Status Status
	{
		get
		{
			if (requestTypeCase_ != RequestTypeOneofCase.Status)
			{
				return null;
			}
			return (Types.Status)requestType_;
		}
		set
		{
			requestType_ = value;
			requestTypeCase_ = ((value != null) ? RequestTypeOneofCase.Status : RequestTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestTypeOneofCase RequestTypeCase => requestTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PropPauseRequest()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PropPauseRequest(PropPauseRequest other)
		: this()
	{
		propId_ = ((other.propId_ != null) ? other.propId_.Clone() : null);
		switch (other.RequestTypeCase)
		{
		case RequestTypeOneofCase.Pause:
			Pause = other.Pause.Clone();
			break;
		case RequestTypeOneofCase.Resume:
			Resume = other.Resume.Clone();
			break;
		case RequestTypeOneofCase.Status:
			Status = other.Status.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PropPauseRequest Clone()
	{
		return new PropPauseRequest(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearRequestType()
	{
		requestTypeCase_ = RequestTypeOneofCase.None;
		requestType_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as PropPauseRequest);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(PropPauseRequest other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(PropId, other.PropId))
		{
			return false;
		}
		if (!object.Equals(Pause, other.Pause))
		{
			return false;
		}
		if (!object.Equals(Resume, other.Resume))
		{
			return false;
		}
		if (!object.Equals(Status, other.Status))
		{
			return false;
		}
		if (RequestTypeCase != other.RequestTypeCase)
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
		if (propId_ != null)
		{
			num ^= PropId.GetHashCode();
		}
		if (requestTypeCase_ == RequestTypeOneofCase.Pause)
		{
			num ^= Pause.GetHashCode();
		}
		if (requestTypeCase_ == RequestTypeOneofCase.Resume)
		{
			num ^= Resume.GetHashCode();
		}
		if (requestTypeCase_ == RequestTypeOneofCase.Status)
		{
			num ^= Status.GetHashCode();
		}
		num ^= (int)requestTypeCase_;
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
		if (propId_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(PropId);
		}
		if (requestTypeCase_ == RequestTypeOneofCase.Pause)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Pause);
		}
		if (requestTypeCase_ == RequestTypeOneofCase.Resume)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Resume);
		}
		if (requestTypeCase_ == RequestTypeOneofCase.Status)
		{
			output.WriteRawTag(34);
			output.WriteMessage(Status);
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
		if (propId_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PropId);
		}
		if (requestTypeCase_ == RequestTypeOneofCase.Pause)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Pause);
		}
		if (requestTypeCase_ == RequestTypeOneofCase.Resume)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Resume);
		}
		if (requestTypeCase_ == RequestTypeOneofCase.Status)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Status);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(PropPauseRequest other)
	{
		if (other == null)
		{
			return;
		}
		if (other.propId_ != null)
		{
			if (propId_ == null)
			{
				PropId = new UUID();
			}
			PropId.MergeFrom(other.PropId);
		}
		switch (other.RequestTypeCase)
		{
		case RequestTypeOneofCase.Pause:
			if (Pause == null)
			{
				Pause = new Types.Pause();
			}
			Pause.MergeFrom(other.Pause);
			break;
		case RequestTypeOneofCase.Resume:
			if (Resume == null)
			{
				Resume = new Types.Resume();
			}
			Resume.MergeFrom(other.Resume);
			break;
		case RequestTypeOneofCase.Status:
			if (Status == null)
			{
				Status = new Types.Status();
			}
			Status.MergeFrom(other.Status);
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
				if (propId_ == null)
				{
					PropId = new UUID();
				}
				input.ReadMessage(PropId);
				break;
			case 18u:
			{
				Types.Pause pause = new Types.Pause();
				if (requestTypeCase_ == RequestTypeOneofCase.Pause)
				{
					pause.MergeFrom(Pause);
				}
				input.ReadMessage(pause);
				Pause = pause;
				break;
			}
			case 26u:
			{
				Types.Resume resume = new Types.Resume();
				if (requestTypeCase_ == RequestTypeOneofCase.Resume)
				{
					resume.MergeFrom(Resume);
				}
				input.ReadMessage(resume);
				Resume = resume;
				break;
			}
			case 34u:
			{
				Types.Status status = new Types.Status();
				if (requestTypeCase_ == RequestTypeOneofCase.Status)
				{
					status.MergeFrom(Status);
				}
				input.ReadMessage(status);
				Status = status;
				break;
			}
			}
		}
	}
}
