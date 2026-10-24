using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class API_v1_Capture_Request : IMessage<API_v1_Capture_Request>, IMessage, IEquatable<API_v1_Capture_Request>, IDeepCloneable<API_v1_Capture_Request>
{
	public enum RequestOneofCase
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
		public sealed class Status : IMessage<Status>, IMessage, IEquatable<Status>, IDeepCloneable<Status>
		{
			private static readonly MessageParser<Status> _parser = new MessageParser<Status>(() => new Status());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Status> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Capture_Request.Descriptor.NestedTypes[0];

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

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Operation : IMessage<Operation>, IMessage, IEquatable<Operation>, IDeepCloneable<Operation>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum CaptureOperation
				{
					[OriginalName("start")]
					Start,
					[OriginalName("stop")]
					Stop
				}
			}

			private static readonly MessageParser<Operation> _parser = new MessageParser<Operation>(() => new Operation());

			private UnknownFieldSet _unknownFields;

			public const int Operation_FieldNumber = 1;

			private Types.CaptureOperation operation_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Operation> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Capture_Request.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.CaptureOperation Operation_
			{
				get
				{
					return operation_;
				}
				set
				{
					operation_ = value;
				}
			}

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
				operation_ = other.operation_;
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
				if (Operation_ != other.Operation_)
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
				if (Operation_ != 0)
				{
					num ^= Operation_.GetHashCode();
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
				if (Operation_ != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Operation_);
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
				if (Operation_ != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Operation_);
				}
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
					if (other.Operation_ != 0)
					{
						Operation_ = other.Operation_;
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
						Operation_ = (Types.CaptureOperation)input.ReadEnum();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetSettings : IMessage<GetSettings>, IMessage, IEquatable<GetSettings>, IDeepCloneable<GetSettings>
		{
			private static readonly MessageParser<GetSettings> _parser = new MessageParser<GetSettings>(() => new GetSettings());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetSettings> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Capture_Request.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

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
			public void MergeFrom(GetSettings other)
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
		public sealed class SetSettings : IMessage<SetSettings>, IMessage, IEquatable<SetSettings>, IDeepCloneable<SetSettings>
		{
			private static readonly MessageParser<SetSettings> _parser = new MessageParser<SetSettings>(() => new SetSettings());

			private UnknownFieldSet _unknownFields;

			public const int SettingsFieldNumber = 1;

			private API_v1_CaptureSettings settings_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<SetSettings> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Capture_Request.Descriptor.NestedTypes[3];

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
			public SetSettings()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public SetSettings(SetSettings other)
				: this()
			{
				settings_ = ((other.settings_ != null) ? other.settings_.Clone() : null);
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
			public void MergeFrom(SetSettings other)
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
		public sealed class Encodings : IMessage<Encodings>, IMessage, IEquatable<Encodings>, IDeepCloneable<Encodings>
		{
			private static readonly MessageParser<Encodings> _parser = new MessageParser<Encodings>(() => new Encodings());

			private UnknownFieldSet _unknownFields;

			public const int TypeFieldNumber = 1;

			private API_v1_CaptureDestination type_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Encodings> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => API_v1_Capture_Request.Descriptor.NestedTypes[4];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_CaptureDestination Type
			{
				get
				{
					return type_;
				}
				set
				{
					type_ = value;
				}
			}

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
				type_ = other.type_;
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
				if (Type != other.Type)
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
				if (Type != 0)
				{
					num ^= Type.GetHashCode();
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
				if (Type != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Type);
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
				if (Type != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Type);
				}
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
					if (other.Type != 0)
					{
						Type = other.Type;
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
						Type = (API_v1_CaptureDestination)input.ReadEnum();
					}
				}
			}
		}
	}

	private static readonly MessageParser<API_v1_Capture_Request> _parser = new MessageParser<API_v1_Capture_Request>(() => new API_v1_Capture_Request());

	private UnknownFieldSet _unknownFields;

	public const int GetStatusFieldNumber = 1;

	public const int OperationFieldNumber = 2;

	public const int GetSettingsFieldNumber = 3;

	public const int SetSettingsFieldNumber = 4;

	public const int GetEncodingsFieldNumber = 5;

	private object request_;

	private RequestOneofCase requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<API_v1_Capture_Request> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1CaptureReflection.Descriptor.MessageTypes[5];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Status GetStatus
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetStatus)
			{
				return null;
			}
			return (Types.Status)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetStatus : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Operation Operation
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Operation)
			{
				return null;
			}
			return (Types.Operation)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Operation : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetSettings GetSettings
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetSettings)
			{
				return null;
			}
			return (Types.GetSettings)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetSettings : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.SetSettings SetSettings
	{
		get
		{
			if (requestCase_ != RequestOneofCase.SetSettings)
			{
				return null;
			}
			return (Types.SetSettings)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.SetSettings : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Encodings GetEncodings
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetEncodings)
			{
				return null;
			}
			return (Types.Encodings)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetEncodings : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestOneofCase RequestCase => requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Capture_Request()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Capture_Request(API_v1_Capture_Request other)
		: this()
	{
		switch (other.RequestCase)
		{
		case RequestOneofCase.GetStatus:
			GetStatus = other.GetStatus.Clone();
			break;
		case RequestOneofCase.Operation:
			Operation = other.Operation.Clone();
			break;
		case RequestOneofCase.GetSettings:
			GetSettings = other.GetSettings.Clone();
			break;
		case RequestOneofCase.SetSettings:
			SetSettings = other.SetSettings.Clone();
			break;
		case RequestOneofCase.GetEncodings:
			GetEncodings = other.GetEncodings.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public API_v1_Capture_Request Clone()
	{
		return new API_v1_Capture_Request(this);
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
		return Equals(other as API_v1_Capture_Request);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(API_v1_Capture_Request other)
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
		if (requestCase_ == RequestOneofCase.GetStatus)
		{
			num ^= GetStatus.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Operation)
		{
			num ^= Operation.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetSettings)
		{
			num ^= GetSettings.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.SetSettings)
		{
			num ^= SetSettings.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetEncodings)
		{
			num ^= GetEncodings.GetHashCode();
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
		if (requestCase_ == RequestOneofCase.GetStatus)
		{
			output.WriteRawTag(10);
			output.WriteMessage(GetStatus);
		}
		if (requestCase_ == RequestOneofCase.Operation)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Operation);
		}
		if (requestCase_ == RequestOneofCase.GetSettings)
		{
			output.WriteRawTag(26);
			output.WriteMessage(GetSettings);
		}
		if (requestCase_ == RequestOneofCase.SetSettings)
		{
			output.WriteRawTag(34);
			output.WriteMessage(SetSettings);
		}
		if (requestCase_ == RequestOneofCase.GetEncodings)
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
		if (requestCase_ == RequestOneofCase.GetStatus)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetStatus);
		}
		if (requestCase_ == RequestOneofCase.Operation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Operation);
		}
		if (requestCase_ == RequestOneofCase.GetSettings)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetSettings);
		}
		if (requestCase_ == RequestOneofCase.SetSettings)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(SetSettings);
		}
		if (requestCase_ == RequestOneofCase.GetEncodings)
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
	public void MergeFrom(API_v1_Capture_Request other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.RequestCase)
		{
		case RequestOneofCase.GetStatus:
			if (GetStatus == null)
			{
				GetStatus = new Types.Status();
			}
			GetStatus.MergeFrom(other.GetStatus);
			break;
		case RequestOneofCase.Operation:
			if (Operation == null)
			{
				Operation = new Types.Operation();
			}
			Operation.MergeFrom(other.Operation);
			break;
		case RequestOneofCase.GetSettings:
			if (GetSettings == null)
			{
				GetSettings = new Types.GetSettings();
			}
			GetSettings.MergeFrom(other.GetSettings);
			break;
		case RequestOneofCase.SetSettings:
			if (SetSettings == null)
			{
				SetSettings = new Types.SetSettings();
			}
			SetSettings.MergeFrom(other.SetSettings);
			break;
		case RequestOneofCase.GetEncodings:
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
				Types.Status status = new Types.Status();
				if (requestCase_ == RequestOneofCase.GetStatus)
				{
					status.MergeFrom(GetStatus);
				}
				input.ReadMessage(status);
				GetStatus = status;
				break;
			}
			case 18u:
			{
				Types.Operation operation = new Types.Operation();
				if (requestCase_ == RequestOneofCase.Operation)
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
				if (requestCase_ == RequestOneofCase.GetSettings)
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
				if (requestCase_ == RequestOneofCase.SetSettings)
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
				if (requestCase_ == RequestOneofCase.GetEncodings)
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
