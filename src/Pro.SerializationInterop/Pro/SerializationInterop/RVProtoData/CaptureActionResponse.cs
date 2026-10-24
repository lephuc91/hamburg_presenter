using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class CaptureActionResponse : IMessage<CaptureActionResponse>, IMessage, IEquatable<CaptureActionResponse>, IDeepCloneable<CaptureActionResponse>
{
	public enum ResponseTypeOneofCase
	{
		None,
		StartResi,
		StopCapture,
		CancelCaptureAction
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class CancelCaptureAction : IMessage<CancelCaptureAction>, IMessage, IEquatable<CancelCaptureAction>, IDeepCloneable<CancelCaptureAction>
		{
			private static readonly MessageParser<CancelCaptureAction> _parser = new MessageParser<CancelCaptureAction>(() => new CancelCaptureAction());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<CancelCaptureAction> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => CaptureActionResponse.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CancelCaptureAction()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CancelCaptureAction(CancelCaptureAction other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public CancelCaptureAction Clone()
			{
				return new CancelCaptureAction(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as CancelCaptureAction);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(CancelCaptureAction other)
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
			public void MergeFrom(CancelCaptureAction other)
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
		public sealed class StartResi : IMessage<StartResi>, IMessage, IEquatable<StartResi>, IDeepCloneable<StartResi>
		{
			private static readonly MessageParser<StartResi> _parser = new MessageParser<StartResi>(() => new StartResi());

			private UnknownFieldSet _unknownFields;

			public const int EventNameFieldNumber = 1;

			private string eventName_ = "";

			public const int EventDescriptionFieldNumber = 2;

			private string eventDescription_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<StartResi> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => CaptureActionResponse.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string EventName
			{
				get
				{
					return eventName_;
				}
				set
				{
					eventName_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string EventDescription
			{
				get
				{
					return eventDescription_;
				}
				set
				{
					eventDescription_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

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
				eventName_ = other.eventName_;
				eventDescription_ = other.eventDescription_;
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
				if (EventName != other.EventName)
				{
					return false;
				}
				if (EventDescription != other.EventDescription)
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
				if (EventName.Length != 0)
				{
					num ^= EventName.GetHashCode();
				}
				if (EventDescription.Length != 0)
				{
					num ^= EventDescription.GetHashCode();
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
				if (EventName.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(EventName);
				}
				if (EventDescription.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(EventDescription);
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
				if (EventName.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(EventName);
				}
				if (EventDescription.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(EventDescription);
				}
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
					if (other.EventName.Length != 0)
					{
						EventName = other.EventName;
					}
					if (other.EventDescription.Length != 0)
					{
						EventDescription = other.EventDescription;
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
						EventName = input.ReadString();
						break;
					case 18u:
						EventDescription = input.ReadString();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class StopCapture : IMessage<StopCapture>, IMessage, IEquatable<StopCapture>, IDeepCloneable<StopCapture>
		{
			private static readonly MessageParser<StopCapture> _parser = new MessageParser<StopCapture>(() => new StopCapture());

			private UnknownFieldSet _unknownFields;

			public const int StopCapture_FieldNumber = 1;

			private bool stopCapture_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<StopCapture> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => CaptureActionResponse.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool StopCapture_
			{
				get
				{
					return stopCapture_;
				}
				set
				{
					stopCapture_ = value;
				}
			}

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
				stopCapture_ = other.stopCapture_;
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
				if (StopCapture_ != other.StopCapture_)
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
				if (StopCapture_)
				{
					num ^= StopCapture_.GetHashCode();
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
				if (StopCapture_)
				{
					output.WriteRawTag(8);
					output.WriteBool(StopCapture_);
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
				if (StopCapture_)
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
			public void MergeFrom(StopCapture other)
			{
				if (other != null)
				{
					if (other.StopCapture_)
					{
						StopCapture_ = other.StopCapture_;
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
						StopCapture_ = input.ReadBool();
					}
				}
			}
		}
	}

	private static readonly MessageParser<CaptureActionResponse> _parser = new MessageParser<CaptureActionResponse>(() => new CaptureActionResponse());

	private UnknownFieldSet _unknownFields;

	public const int StartResiFieldNumber = 1;

	public const int StopCaptureFieldNumber = 2;

	public const int CancelCaptureActionFieldNumber = 3;

	private object responseType_;

	private ResponseTypeOneofCase responseTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<CaptureActionResponse> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreReflection.Descriptor.MessageTypes[13];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.StartResi StartResi
	{
		get
		{
			if (responseTypeCase_ != ResponseTypeOneofCase.StartResi)
			{
				return null;
			}
			return (Types.StartResi)responseType_;
		}
		set
		{
			responseType_ = value;
			responseTypeCase_ = ((value != null) ? ResponseTypeOneofCase.StartResi : ResponseTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.StopCapture StopCapture
	{
		get
		{
			if (responseTypeCase_ != ResponseTypeOneofCase.StopCapture)
			{
				return null;
			}
			return (Types.StopCapture)responseType_;
		}
		set
		{
			responseType_ = value;
			responseTypeCase_ = ((value != null) ? ResponseTypeOneofCase.StopCapture : ResponseTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.CancelCaptureAction CancelCaptureAction
	{
		get
		{
			if (responseTypeCase_ != ResponseTypeOneofCase.CancelCaptureAction)
			{
				return null;
			}
			return (Types.CancelCaptureAction)responseType_;
		}
		set
		{
			responseType_ = value;
			responseTypeCase_ = ((value != null) ? ResponseTypeOneofCase.CancelCaptureAction : ResponseTypeOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResponseTypeOneofCase ResponseTypeCase => responseTypeCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CaptureActionResponse()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CaptureActionResponse(CaptureActionResponse other)
		: this()
	{
		switch (other.ResponseTypeCase)
		{
		case ResponseTypeOneofCase.StartResi:
			StartResi = other.StartResi.Clone();
			break;
		case ResponseTypeOneofCase.StopCapture:
			StopCapture = other.StopCapture.Clone();
			break;
		case ResponseTypeOneofCase.CancelCaptureAction:
			CancelCaptureAction = other.CancelCaptureAction.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CaptureActionResponse Clone()
	{
		return new CaptureActionResponse(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearResponseType()
	{
		responseTypeCase_ = ResponseTypeOneofCase.None;
		responseType_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as CaptureActionResponse);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(CaptureActionResponse other)
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
		if (!object.Equals(CancelCaptureAction, other.CancelCaptureAction))
		{
			return false;
		}
		if (ResponseTypeCase != other.ResponseTypeCase)
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
		if (responseTypeCase_ == ResponseTypeOneofCase.StartResi)
		{
			num ^= StartResi.GetHashCode();
		}
		if (responseTypeCase_ == ResponseTypeOneofCase.StopCapture)
		{
			num ^= StopCapture.GetHashCode();
		}
		if (responseTypeCase_ == ResponseTypeOneofCase.CancelCaptureAction)
		{
			num ^= CancelCaptureAction.GetHashCode();
		}
		num ^= (int)responseTypeCase_;
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
		if (responseTypeCase_ == ResponseTypeOneofCase.StartResi)
		{
			output.WriteRawTag(10);
			output.WriteMessage(StartResi);
		}
		if (responseTypeCase_ == ResponseTypeOneofCase.StopCapture)
		{
			output.WriteRawTag(18);
			output.WriteMessage(StopCapture);
		}
		if (responseTypeCase_ == ResponseTypeOneofCase.CancelCaptureAction)
		{
			output.WriteRawTag(26);
			output.WriteMessage(CancelCaptureAction);
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
		if (responseTypeCase_ == ResponseTypeOneofCase.StartResi)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(StartResi);
		}
		if (responseTypeCase_ == ResponseTypeOneofCase.StopCapture)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(StopCapture);
		}
		if (responseTypeCase_ == ResponseTypeOneofCase.CancelCaptureAction)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(CancelCaptureAction);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(CaptureActionResponse other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.ResponseTypeCase)
		{
		case ResponseTypeOneofCase.StartResi:
			if (StartResi == null)
			{
				StartResi = new Types.StartResi();
			}
			StartResi.MergeFrom(other.StartResi);
			break;
		case ResponseTypeOneofCase.StopCapture:
			if (StopCapture == null)
			{
				StopCapture = new Types.StopCapture();
			}
			StopCapture.MergeFrom(other.StopCapture);
			break;
		case ResponseTypeOneofCase.CancelCaptureAction:
			if (CancelCaptureAction == null)
			{
				CancelCaptureAction = new Types.CancelCaptureAction();
			}
			CancelCaptureAction.MergeFrom(other.CancelCaptureAction);
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
				if (responseTypeCase_ == ResponseTypeOneofCase.StartResi)
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
				if (responseTypeCase_ == ResponseTypeOneofCase.StopCapture)
				{
					stopCapture.MergeFrom(StopCapture);
				}
				input.ReadMessage(stopCapture);
				StopCapture = stopCapture;
				break;
			}
			case 26u:
			{
				Types.CancelCaptureAction cancelCaptureAction = new Types.CancelCaptureAction();
				if (responseTypeCase_ == ResponseTypeOneofCase.CancelCaptureAction)
				{
					cancelCaptureAction.MergeFrom(CancelCaptureAction);
				}
				input.ReadMessage(cancelCaptureAction);
				CancelCaptureAction = cancelCaptureAction;
				break;
			}
			}
		}
	}
}
