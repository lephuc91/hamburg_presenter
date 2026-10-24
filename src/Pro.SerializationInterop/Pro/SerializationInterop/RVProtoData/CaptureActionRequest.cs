using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class CaptureActionRequest : IMessage<CaptureActionRequest>, IMessage, IEquatable<CaptureActionRequest>, IDeepCloneable<CaptureActionRequest>
{
	public enum RequestTypeOneofCase
	{
		None,
		StartResi,
		StopCapture,
		Error
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class StartResi : IMessage<StartResi>, IMessage, IEquatable<StartResi>, IDeepCloneable<StartResi>
		{
			private static readonly MessageParser<StartResi> _parser = new MessageParser<StartResi>(() => new StartResi());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<StartResi> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => CaptureActionRequest.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public StartResi()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public StartResi(StartResi other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public StartResi Clone()
			{
				return new StartResi(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as StartResi);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(StartResi other)
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
			public void MergeFrom(StartResi other)
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
		public sealed class StopCapture : IMessage<StopCapture>, IMessage, IEquatable<StopCapture>, IDeepCloneable<StopCapture>
		{
			private static readonly MessageParser<StopCapture> _parser = new MessageParser<StopCapture>(() => new StopCapture());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<StopCapture> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => CaptureActionRequest.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public StopCapture()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public StopCapture(StopCapture other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public StopCapture Clone()
			{
				return new StopCapture(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as StopCapture);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(StopCapture other)
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
			public void MergeFrom(StopCapture other)
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
		public sealed class Error : IMessage<Error>, IMessage, IEquatable<Error>, IDeepCloneable<Error>
		{
			private static readonly MessageParser<Error> _parser = new MessageParser<Error>(() => new Error());

			private UnknownFieldSet _unknownFields;

			public const int ErrorCodeFieldNumber = 1;

			private int errorCode_;

			public const int CaptureActionFieldNumber = 2;

			private Action.Types.CaptureType captureAction_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Error> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => CaptureActionRequest.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public int ErrorCode
			{
				get
				{
					return errorCode_;
				}
				set
				{
					errorCode_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Action.Types.CaptureType CaptureAction
			{
				get
				{
					return captureAction_;
				}
				set
				{
					captureAction_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Error()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Error(Error other)
				: this()
			{
				errorCode_ = other.errorCode_;
				captureAction_ = ((other.captureAction_ != null) ? other.captureAction_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Error Clone()
			{
				return new Error(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Error);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Error other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (ErrorCode != other.ErrorCode)
				{
					return false;
				}
				if (!object.Equals(CaptureAction, other.CaptureAction))
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
				if (ErrorCode != 0)
				{
					num ^= ErrorCode.GetHashCode();
				}
				if (captureAction_ != null)
				{
					num ^= CaptureAction.GetHashCode();
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
				if (ErrorCode != 0)
				{
					output.WriteRawTag(8);
					output.WriteInt32(ErrorCode);
				}
				if (captureAction_ != null)
				{
					output.WriteRawTag(18);
					output.WriteMessage(CaptureAction);
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
				if (ErrorCode != 0)
				{
					num += 1 + CodedOutputStream.ComputeInt32Size(ErrorCode);
				}
				if (captureAction_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(CaptureAction);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Error other)
			{
				if (other == null)
				{
					return;
				}
				if (other.ErrorCode != 0)
				{
					ErrorCode = other.ErrorCode;
				}
				if (other.captureAction_ != null)
				{
					if (captureAction_ == null)
					{
						CaptureAction = new Action.Types.CaptureType();
					}
					CaptureAction.MergeFrom(other.CaptureAction);
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
					case 8u:
						ErrorCode = input.ReadInt32();
						break;
					case 18u:
						if (captureAction_ == null)
						{
							CaptureAction = new Action.Types.CaptureType();
						}
						input.ReadMessage(CaptureAction);
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<CaptureActionRequest> _parser = new MessageParser<CaptureActionRequest>(() => new CaptureActionRequest());

	private UnknownFieldSet _unknownFields;

	public const int StartResiFieldNumber = 1;

	public const int StopCaptureFieldNumber = 2;

	public const int ErrorFieldNumber = 3;

	private object requestType_;

	private RequestTypeOneofCase requestTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<CaptureActionRequest> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[12];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.StartResi StartResi
	{
		get
		{
			if (requestTypeCase_ != RequestTypeOneofCase.StartResi)
			{
				return null;
			}
			return (Types.StartResi)requestType_;
		}
		set
		{
			requestType_ = value;
			requestTypeCase_ = ((value != null) ? RequestTypeOneofCase.StartResi : RequestTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.StopCapture StopCapture
	{
		get
		{
			if (requestTypeCase_ != RequestTypeOneofCase.StopCapture)
			{
				return null;
			}
			return (Types.StopCapture)requestType_;
		}
		set
		{
			requestType_ = value;
			requestTypeCase_ = ((value != null) ? RequestTypeOneofCase.StopCapture : RequestTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Error Error
	{
		get
		{
			if (requestTypeCase_ != RequestTypeOneofCase.Error)
			{
				return null;
			}
			return (Types.Error)requestType_;
		}
		set
		{
			requestType_ = value;
			requestTypeCase_ = ((value != null) ? RequestTypeOneofCase.Error : RequestTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestTypeOneofCase RequestTypeCase => requestTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CaptureActionRequest()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CaptureActionRequest(CaptureActionRequest other)
		: this()
	{
		switch (other.RequestTypeCase)
		{
		case RequestTypeOneofCase.StartResi:
			StartResi = other.StartResi.Clone();
			break;
		case RequestTypeOneofCase.StopCapture:
			StopCapture = other.StopCapture.Clone();
			break;
		case RequestTypeOneofCase.Error:
			Error = other.Error.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CaptureActionRequest Clone()
	{
		return new CaptureActionRequest(this);
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
		return Equals(other as CaptureActionRequest);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(CaptureActionRequest other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(StartResi, other.StartResi))
		{
			return false;
		}
		if (!object.Equals(StopCapture, other.StopCapture))
		{
			return false;
		}
		if (!object.Equals(Error, other.Error))
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
		if (requestTypeCase_ == RequestTypeOneofCase.StartResi)
		{
			num ^= StartResi.GetHashCode();
		}
		if (requestTypeCase_ == RequestTypeOneofCase.StopCapture)
		{
			num ^= StopCapture.GetHashCode();
		}
		if (requestTypeCase_ == RequestTypeOneofCase.Error)
		{
			num ^= Error.GetHashCode();
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
		if (requestTypeCase_ == RequestTypeOneofCase.StartResi)
		{
			output.WriteRawTag(10);
			output.WriteMessage(StartResi);
		}
		if (requestTypeCase_ == RequestTypeOneofCase.StopCapture)
		{
			output.WriteRawTag(18);
			output.WriteMessage(StopCapture);
		}
		if (requestTypeCase_ == RequestTypeOneofCase.Error)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Error);
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
		if (requestTypeCase_ == RequestTypeOneofCase.StartResi)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(StartResi);
		}
		if (requestTypeCase_ == RequestTypeOneofCase.StopCapture)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(StopCapture);
		}
		if (requestTypeCase_ == RequestTypeOneofCase.Error)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Error);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(CaptureActionRequest other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.RequestTypeCase)
		{
		case RequestTypeOneofCase.StartResi:
			if (StartResi == null)
			{
				StartResi = new Types.StartResi();
			}
			StartResi.MergeFrom(other.StartResi);
			break;
		case RequestTypeOneofCase.StopCapture:
			if (StopCapture == null)
			{
				StopCapture = new Types.StopCapture();
			}
			StopCapture.MergeFrom(other.StopCapture);
			break;
		case RequestTypeOneofCase.Error:
			if (Error == null)
			{
				Error = new Types.Error();
			}
			Error.MergeFrom(other.Error);
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
				Types.StartResi startResi = new Types.StartResi();
				if (requestTypeCase_ == RequestTypeOneofCase.StartResi)
				{
					startResi.MergeFrom(StartResi);
				}
				input.ReadMessage(startResi);
				StartResi = startResi;
				break;
			}
			case 18u:
			{
				Types.StopCapture stopCapture = new Types.StopCapture();
				if (requestTypeCase_ == RequestTypeOneofCase.StopCapture)
				{
					stopCapture.MergeFrom(StopCapture);
				}
				input.ReadMessage(stopCapture);
				StopCapture = stopCapture;
				break;
			}
			case 26u:
			{
				Types.Error error = new Types.Error();
				if (requestTypeCase_ == RequestTypeOneofCase.Error)
				{
					error.MergeFrom(Error);
				}
				input.ReadMessage(error);
				Error = error;
				break;
			}
			}
		}
	}
}
