using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaManagement.v1;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class MediaReference : IMessage<MediaReference>, IMessage, IEquatable<MediaReference>, IDeepCloneable<MediaReference>
{
	public enum StateOneofCase
	{
		None = 0,
		Success = 2,
		Error = 3,
		Progress = 4,
		Deleted = 5
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Progress : IMessage<Progress>, IMessage, IEquatable<Progress>, IDeepCloneable<Progress>
		{
			private static readonly MessageParser<Progress> _parser = new MessageParser<Progress>(() => new Progress());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Progress> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => MediaReference.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Progress()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Progress(Progress other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Progress Clone()
			{
				return new Progress(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Progress);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Progress other)
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
			public void MergeFrom(Progress other)
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
		public sealed class Deleted : IMessage<Deleted>, IMessage, IEquatable<Deleted>, IDeepCloneable<Deleted>
		{
			private static readonly MessageParser<Deleted> _parser = new MessageParser<Deleted>(() => new Deleted());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Deleted> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => MediaReference.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Deleted()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Deleted(Deleted other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Deleted Clone()
			{
				return new Deleted(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Deleted);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Deleted other)
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
			public void MergeFrom(Deleted other)
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
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				public enum ErrorCode
				{
					[OriginalName("INTERNAL_ERROR")]
					InternalError,
					[OriginalName("SNAPSHOT_FAILED_ERROR")]
					SnapshotFailedError
				}
			}

			private static readonly MessageParser<Error> _parser = new MessageParser<Error>(() => new Error());

			private UnknownFieldSet _unknownFields;

			public const int CodeFieldNumber = 1;

			private Types.ErrorCode code_;

			public const int DescriptionFieldNumber = 2;

			private string description_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Error> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => MediaReference.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.ErrorCode Code
			{
				get
				{
					return code_;
				}
				set
				{
					code_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Description
			{
				get
				{
					return description_;
				}
				set
				{
					description_ = ProtoPreconditions.CheckNotNull(value, "value");
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
				code_ = other.code_;
				description_ = other.description_;
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
				if (Code != other.Code)
				{
					return false;
				}
				if (Description != other.Description)
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
				if (Code != 0)
				{
					num ^= Code.GetHashCode();
				}
				if (Description.Length != 0)
				{
					num ^= Description.GetHashCode();
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
				if (Code != 0)
				{
					output.WriteRawTag(8);
					output.WriteEnum((int)Code);
				}
				if (Description.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(Description);
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
				if (Code != 0)
				{
					num += 1 + CodedOutputStream.ComputeEnumSize((int)Code);
				}
				if (Description.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Description);
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
				if (other != null)
				{
					if (other.Code != 0)
					{
						Code = other.Code;
					}
					if (other.Description.Length != 0)
					{
						Description = other.Description;
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
						Code = (Types.ErrorCode)input.ReadEnum();
						break;
					case 18u:
						Description = input.ReadString();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<MediaReference> _parser = new MessageParser<MediaReference>(() => new MediaReference());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private string uuid_ = "";

	public const int SuccessFieldNumber = 2;

	public const int ErrorFieldNumber = 3;

	public const int ProgressFieldNumber = 4;

	public const int DeletedFieldNumber = 5;

	private object state_;

	private StateOneofCase stateCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<MediaReference> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V1HelperCommonReflection.Descriptor.MessageTypes[5];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Uuid
	{
		get
		{
			return uuid_;
		}
		set
		{
			uuid_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaReferenceInfo Success
	{
		get
		{
			if (stateCase_ != StateOneofCase.Success)
			{
				return null;
			}
			return (MediaReferenceInfo)state_;
		}
		set
		{
			state_ = value;
			stateCase_ = ((value != null) ? StateOneofCase.Success : StateOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Error Error
	{
		get
		{
			if (stateCase_ != StateOneofCase.Error)
			{
				return null;
			}
			return (Types.Error)state_;
		}
		set
		{
			state_ = value;
			stateCase_ = ((value != null) ? StateOneofCase.Error : StateOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Progress Progress
	{
		get
		{
			if (stateCase_ != StateOneofCase.Progress)
			{
				return null;
			}
			return (Types.Progress)state_;
		}
		set
		{
			state_ = value;
			stateCase_ = ((value != null) ? StateOneofCase.Progress : StateOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Deleted Deleted
	{
		get
		{
			if (stateCase_ != StateOneofCase.Deleted)
			{
				return null;
			}
			return (Types.Deleted)state_;
		}
		set
		{
			state_ = value;
			stateCase_ = ((value != null) ? StateOneofCase.Deleted : StateOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public StateOneofCase StateCase => stateCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaReference()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaReference(MediaReference other)
		: this()
	{
		uuid_ = other.uuid_;
		switch (other.StateCase)
		{
		case StateOneofCase.Success:
			Success = other.Success.Clone();
			break;
		case StateOneofCase.Error:
			Error = other.Error.Clone();
			break;
		case StateOneofCase.Progress:
			Progress = other.Progress.Clone();
			break;
		case StateOneofCase.Deleted:
			Deleted = other.Deleted.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MediaReference Clone()
	{
		return new MediaReference(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearState()
	{
		stateCase_ = StateOneofCase.None;
		state_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as MediaReference);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(MediaReference other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Uuid != other.Uuid)
		{
			return false;
		}
		if (!object.Equals(Success, other.Success))
		{
			return false;
		}
		if (!object.Equals(Error, other.Error))
		{
			return false;
		}
		if (!object.Equals(Progress, other.Progress))
		{
			return false;
		}
		if (!object.Equals(Deleted, other.Deleted))
		{
			return false;
		}
		if (StateCase != other.StateCase)
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
		if (Uuid.Length != 0)
		{
			num ^= Uuid.GetHashCode();
		}
		if (stateCase_ == StateOneofCase.Success)
		{
			num ^= Success.GetHashCode();
		}
		if (stateCase_ == StateOneofCase.Error)
		{
			num ^= Error.GetHashCode();
		}
		if (stateCase_ == StateOneofCase.Progress)
		{
			num ^= Progress.GetHashCode();
		}
		if (stateCase_ == StateOneofCase.Deleted)
		{
			num ^= Deleted.GetHashCode();
		}
		num ^= (int)stateCase_;
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
		if (Uuid.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(Uuid);
		}
		if (stateCase_ == StateOneofCase.Success)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Success);
		}
		if (stateCase_ == StateOneofCase.Error)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Error);
		}
		if (stateCase_ == StateOneofCase.Progress)
		{
			output.WriteRawTag(34);
			output.WriteMessage(Progress);
		}
		if (stateCase_ == StateOneofCase.Deleted)
		{
			output.WriteRawTag(42);
			output.WriteMessage(Deleted);
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
		if (Uuid.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Uuid);
		}
		if (stateCase_ == StateOneofCase.Success)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Success);
		}
		if (stateCase_ == StateOneofCase.Error)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Error);
		}
		if (stateCase_ == StateOneofCase.Progress)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Progress);
		}
		if (stateCase_ == StateOneofCase.Deleted)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Deleted);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(MediaReference other)
	{
		if (other == null)
		{
			return;
		}
		if (other.Uuid.Length != 0)
		{
			Uuid = other.Uuid;
		}
		switch (other.StateCase)
		{
		case StateOneofCase.Success:
			if (Success == null)
			{
				Success = new MediaReferenceInfo();
			}
			Success.MergeFrom(other.Success);
			break;
		case StateOneofCase.Error:
			if (Error == null)
			{
				Error = new Types.Error();
			}
			Error.MergeFrom(other.Error);
			break;
		case StateOneofCase.Progress:
			if (Progress == null)
			{
				Progress = new Types.Progress();
			}
			Progress.MergeFrom(other.Progress);
			break;
		case StateOneofCase.Deleted:
			if (Deleted == null)
			{
				Deleted = new Types.Deleted();
			}
			Deleted.MergeFrom(other.Deleted);
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
				Uuid = input.ReadString();
				break;
			case 18u:
			{
				MediaReferenceInfo mediaReferenceInfo = new MediaReferenceInfo();
				if (stateCase_ == StateOneofCase.Success)
				{
					mediaReferenceInfo.MergeFrom(Success);
				}
				input.ReadMessage(mediaReferenceInfo);
				Success = mediaReferenceInfo;
				break;
			}
			case 26u:
			{
				Types.Error error = new Types.Error();
				if (stateCase_ == StateOneofCase.Error)
				{
					error.MergeFrom(Error);
				}
				input.ReadMessage(error);
				Error = error;
				break;
			}
			case 34u:
			{
				Types.Progress progress = new Types.Progress();
				if (stateCase_ == StateOneofCase.Progress)
				{
					progress.MergeFrom(Progress);
				}
				input.ReadMessage(progress);
				Progress = progress;
				break;
			}
			case 42u:
			{
				Types.Deleted deleted = new Types.Deleted();
				if (stateCase_ == StateOneofCase.Deleted)
				{
					deleted.MergeFrom(Deleted);
				}
				input.ReadMessage(deleted);
				Deleted = deleted;
				break;
			}
			}
		}
	}
}
