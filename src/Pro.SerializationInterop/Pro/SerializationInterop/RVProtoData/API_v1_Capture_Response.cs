using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Capture_Response : IMessage<API_v1_Capture_Response>, IMessage, IEquatable<API_v1_Capture_Response>, IDeepCloneable<API_v1_Capture_Response>
{
	public enum ResponseOneofCase
	{
		None,
		GetStatus,
		Operation,
		GetSettings,
		SetSettings,
		GetEncodings
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetStatus : IMessage<GetStatus>, IMessage, IEquatable<GetStatus>, IDeepCloneable<GetStatus>
		{
			private static readonly MessageParser<GetStatus> _parser = new MessageParser<GetStatus>(() => new GetStatus());

			private UnknownFieldSet _unknownFields;

			public const int StatusFieldNumber = 1;

			private API_v1_CaptureStatus status_;

			public const int CaptureTimeFieldNumber = 2;

			private string captureTime_ = "";

			public const int StatusTextFieldNumber = 3;

			private string statusText_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetStatus> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Capture_Response.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_CaptureStatus Status
			{
				get
				{
					return status_;
				}
				set
				{
					status_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string CaptureTime
			{
				get
				{
					return captureTime_;
				}
				set
				{
					captureTime_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string StatusText
			{
				get
				{
					return statusText_;
				}
				set
				{
					statusText_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetStatus()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetStatus(GetStatus other)
				: this()
			{
				status_ = other.status_;
				captureTime_ = other.captureTime_;
				statusText_ = other.statusText_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetStatus Clone()
			{
				return new GetStatus(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetStatus);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetStatus other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Status != other.Status)
				{
					return false;
				}
				if (CaptureTime != other.CaptureTime)
				{
					return false;
				}
				if (StatusText != other.StatusText)
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
				if (Status != 0)
				{
					num ^= Status.GetHashCode();
				}
				if (CaptureTime.Length != 0)
				{
					num ^= CaptureTime.GetHashCode();
				}
				if (StatusText.Length != 0)
				{
					num ^= StatusText.GetHashCode();
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
				if (Status != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Status);
				}
				if (CaptureTime.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(CaptureTime);
				}
				if (StatusText.Length != 0)
				{
					output.WriteRawTag(26);
					output.WriteString(StatusText);
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
				if (Status != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Status);
				}
				if (CaptureTime.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(CaptureTime);
				}
				if (StatusText.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(StatusText);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetStatus other)
			{
				if (other != null)
				{
					if (other.Status != 0)
					{
						Status = other.Status;
					}
					if (other.CaptureTime.Length != 0)
					{
						CaptureTime = other.CaptureTime;
					}
					if (other.StatusText.Length != 0)
					{
						StatusText = other.StatusText;
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
						Status = (API_v1_CaptureStatus)input.ReadEnum();
						break;
					case 18u:
						CaptureTime = input.ReadString();
						break;
					case 26u:
						StatusText = input.ReadString();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Operation : IMessage<Operation>, IMessage, IEquatable<Operation>, IDeepCloneable<Operation>
		{
			private static readonly MessageParser<Operation> _parser = new MessageParser<Operation>(() => new Operation());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Operation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Capture_Response.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Operation()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Operation(Operation other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Operation Clone()
			{
				return new Operation(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Operation);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Operation other)
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
			public void MergeFrom(Operation other)
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
		public sealed class GetSettings : IMessage<GetSettings>, IMessage, IEquatable<GetSettings>, IDeepCloneable<GetSettings>
		{
			private static readonly MessageParser<GetSettings> _parser = new MessageParser<GetSettings>(() => new GetSettings());

			private UnknownFieldSet _unknownFields;

			public const int SettingsFieldNumber = 1;

			private API_v1_CaptureSettings settings_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetSettings> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Capture_Response.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_CaptureSettings Settings
			{
				get
				{
					return settings_;
				}
				set
				{
					settings_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetSettings()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetSettings(GetSettings other)
				: this()
			{
				settings_ = ((other.settings_ != null) ? other.settings_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetSettings Clone()
			{
				return new GetSettings(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetSettings);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetSettings other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Settings, other.Settings))
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
				if (settings_ != null)
				{
					num ^= Settings.GetHashCode();
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
				if (settings_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Settings);
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
				if (settings_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Settings);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetSettings other)
			{
				if (other == null)
				{
					return;
				}
				if (other.settings_ != null)
				{
					if (settings_ == null)
					{
						Settings = new API_v1_CaptureSettings();
					}
					Settings.MergeFrom(other.Settings);
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
					if (settings_ == null)
					{
						Settings = new API_v1_CaptureSettings();
					}
					input.ReadMessage(Settings);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class SetSettings : IMessage<SetSettings>, IMessage, IEquatable<SetSettings>, IDeepCloneable<SetSettings>
		{
			private static readonly MessageParser<SetSettings> _parser = new MessageParser<SetSettings>(() => new SetSettings());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SetSettings> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Capture_Response.Descriptor.NestedTypes[3];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetSettings()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetSettings(SetSettings other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetSettings Clone()
			{
				return new SetSettings(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as SetSettings);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(SetSettings other)
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
			public void MergeFrom(SetSettings other)
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
		public sealed class Encodings : IMessage<Encodings>, IMessage, IEquatable<Encodings>, IDeepCloneable<Encodings>
		{
			private static readonly MessageParser<Encodings> _parser = new MessageParser<Encodings>(() => new Encodings());

			private UnknownFieldSet _unknownFields;

			public const int Encodings_FieldNumber = 1;

			private static readonly FieldCodec<string> _repeated_encodings_codec = FieldCodec.ForString(10u);

			private readonly RepeatedField<string> encodings_ = new RepeatedField<string>();

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Encodings> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Capture_Response.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RepeatedField<string> Encodings_ => encodings_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Encodings()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Encodings(Encodings other)
				: this()
			{
				encodings_ = other.encodings_.Clone();
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Encodings Clone()
			{
				return new Encodings(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Encodings);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Encodings other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!encodings_.Equals(other.encodings_))
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
				num ^= encodings_.GetHashCode();
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
				encodings_.WriteTo(output, _repeated_encodings_codec);
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
				num += encodings_.CalculateSize(_repeated_encodings_codec);
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Encodings other)
			{
				if (other != null)
				{
					encodings_.Add(other.encodings_);
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
						encodings_.AddEntriesFrom(input, _repeated_encodings_codec);
					}
				}
			}
		}
	}

	private static readonly MessageParser<API_v1_Capture_Response> _parser = new MessageParser<API_v1_Capture_Response>(() => new API_v1_Capture_Response());

	private UnknownFieldSet _unknownFields;

	public const int GetStatusFieldNumber = 1;

	public const int OperationFieldNumber = 2;

	public const int GetSettingsFieldNumber = 3;

	public const int SetSettingsFieldNumber = 4;

	public const int GetEncodingsFieldNumber = 5;

	private object response_;

	private ResponseOneofCase responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Capture_Response> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1CaptureReflection.Descriptor.MessageTypes[6];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetStatus GetStatus
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetStatus)
			{
				return null;
			}
			return (Types.GetStatus)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetStatus : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Operation Operation
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.Operation)
			{
				return null;
			}
			return (Types.Operation)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.Operation : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetSettings GetSettings
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetSettings)
			{
				return null;
			}
			return (Types.GetSettings)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetSettings : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SetSettings SetSettings
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.SetSettings)
			{
				return null;
			}
			return (Types.SetSettings)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.SetSettings : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Encodings GetEncodings
	{
		get
		{
			if (responseCase_ != ResponseOneofCase.GetEncodings)
			{
				return null;
			}
			return (Types.Encodings)response_;
		}
		set
		{
			response_ = value;
			responseCase_ = ((value != null) ? ResponseOneofCase.GetEncodings : ResponseOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResponseOneofCase ResponseCase => responseCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Capture_Response()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Capture_Response(API_v1_Capture_Response other)
		: this()
	{
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.GetStatus:
			GetStatus = other.GetStatus.Clone();
			break;
		case ResponseOneofCase.Operation:
			Operation = other.Operation.Clone();
			break;
		case ResponseOneofCase.GetSettings:
			GetSettings = other.GetSettings.Clone();
			break;
		case ResponseOneofCase.SetSettings:
			SetSettings = other.SetSettings.Clone();
			break;
		case ResponseOneofCase.GetEncodings:
			GetEncodings = other.GetEncodings.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Capture_Response Clone()
	{
		return new API_v1_Capture_Response(this);
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
		return Equals(other as API_v1_Capture_Response);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Capture_Response other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(GetStatus, other.GetStatus))
		{
			return false;
		}
		if (!object.Equals(Operation, other.Operation))
		{
			return false;
		}
		if (!object.Equals(GetSettings, other.GetSettings))
		{
			return false;
		}
		if (!object.Equals(SetSettings, other.SetSettings))
		{
			return false;
		}
		if (!object.Equals(GetEncodings, other.GetEncodings))
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
		if (responseCase_ == ResponseOneofCase.GetStatus)
		{
			num ^= GetStatus.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.Operation)
		{
			num ^= Operation.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetSettings)
		{
			num ^= GetSettings.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.SetSettings)
		{
			num ^= SetSettings.GetHashCode();
		}
		if (responseCase_ == ResponseOneofCase.GetEncodings)
		{
			num ^= GetEncodings.GetHashCode();
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
		if (responseCase_ == ResponseOneofCase.GetStatus)
		{
			output.WriteRawTag(10);
			output.WriteMessage(GetStatus);
		}
		if (responseCase_ == ResponseOneofCase.Operation)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Operation);
		}
		if (responseCase_ == ResponseOneofCase.GetSettings)
		{
			output.WriteRawTag(26);
			output.WriteMessage(GetSettings);
		}
		if (responseCase_ == ResponseOneofCase.SetSettings)
		{
			output.WriteRawTag(34);
			output.WriteMessage(SetSettings);
		}
		if (responseCase_ == ResponseOneofCase.GetEncodings)
		{
			output.WriteRawTag(42);
			output.WriteMessage(GetEncodings);
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
		if (responseCase_ == ResponseOneofCase.GetStatus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetStatus);
		}
		if (responseCase_ == ResponseOneofCase.Operation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Operation);
		}
		if (responseCase_ == ResponseOneofCase.GetSettings)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetSettings);
		}
		if (responseCase_ == ResponseOneofCase.SetSettings)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SetSettings);
		}
		if (responseCase_ == ResponseOneofCase.GetEncodings)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetEncodings);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(API_v1_Capture_Response other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.ResponseCase)
		{
		case ResponseOneofCase.GetStatus:
			if (GetStatus == null)
			{
				GetStatus = new Types.GetStatus();
			}
			GetStatus.MergeFrom(other.GetStatus);
			break;
		case ResponseOneofCase.Operation:
			if (Operation == null)
			{
				Operation = new Types.Operation();
			}
			Operation.MergeFrom(other.Operation);
			break;
		case ResponseOneofCase.GetSettings:
			if (GetSettings == null)
			{
				GetSettings = new Types.GetSettings();
			}
			GetSettings.MergeFrom(other.GetSettings);
			break;
		case ResponseOneofCase.SetSettings:
			if (SetSettings == null)
			{
				SetSettings = new Types.SetSettings();
			}
			SetSettings.MergeFrom(other.SetSettings);
			break;
		case ResponseOneofCase.GetEncodings:
			if (GetEncodings == null)
			{
				GetEncodings = new Types.Encodings();
			}
			GetEncodings.MergeFrom(other.GetEncodings);
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
				Types.GetStatus getStatus = new Types.GetStatus();
				if (responseCase_ == ResponseOneofCase.GetStatus)
				{
					getStatus.MergeFrom(GetStatus);
				}
				input.ReadMessage(getStatus);
				GetStatus = getStatus;
				break;
			}
			case 18u:
			{
				Types.Operation operation = new Types.Operation();
				if (responseCase_ == ResponseOneofCase.Operation)
				{
					operation.MergeFrom(Operation);
				}
				input.ReadMessage(operation);
				Operation = operation;
				break;
			}
			case 26u:
			{
				Types.GetSettings getSettings = new Types.GetSettings();
				if (responseCase_ == ResponseOneofCase.GetSettings)
				{
					getSettings.MergeFrom(GetSettings);
				}
				input.ReadMessage(getSettings);
				GetSettings = getSettings;
				break;
			}
			case 34u:
			{
				Types.SetSettings setSettings = new Types.SetSettings();
				if (responseCase_ == ResponseOneofCase.SetSettings)
				{
					setSettings.MergeFrom(SetSettings);
				}
				input.ReadMessage(setSettings);
				SetSettings = setSettings;
				break;
			}
			case 42u:
			{
				Types.Encodings encodings = new Types.Encodings();
				if (responseCase_ == ResponseOneofCase.GetEncodings)
				{
					encodings.MergeFrom(GetEncodings);
				}
				input.ReadMessage(encodings);
				GetEncodings = encodings;
				break;
			}
			}
		}
	}
}
