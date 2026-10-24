using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.MediaManagement;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class BootstrappingComplete : IMessage<BootstrappingComplete>, IMessage, IEquatable<BootstrappingComplete>, IDeepCloneable<BootstrappingComplete>
{
	public enum StateOneofCase
	{
		None,
		Success,
		Failure
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Success : IMessage<Success>, IMessage, IEquatable<Success>, IDeepCloneable<Success>
		{
			private static readonly MessageParser<Success> _parser = new MessageParser<Success>(() => new Success());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Success> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => BootstrappingComplete.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Success()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Success(Success other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Success Clone()
			{
				return new Success(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Success);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Success other)
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
			public void MergeFrom(Success other)
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
		public sealed class Failure : IMessage<Failure>, IMessage, IEquatable<Failure>, IDeepCloneable<Failure>
		{
			private static readonly MessageParser<Failure> _parser = new MessageParser<Failure>(() => new Failure());

			private UnknownFieldSet _unknownFields;

			public const int ErrorFieldNumber = 1;

			private string error_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Failure> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => BootstrappingComplete.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Error
			{
				get
				{
					return error_;
				}
				set
				{
					error_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Failure()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Failure(Failure other)
				: this()
			{
				error_ = other.error_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Failure Clone()
			{
				return new Failure(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Failure);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Failure other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Error != other.Error)
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
				if (Error.Length != 0)
				{
					num ^= Error.GetHashCode();
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
				if (Error.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Error);
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
				if (Error.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Error);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Failure other)
			{
				if (other != null)
				{
					if (other.Error.Length != 0)
					{
						Error = other.Error;
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
						Error = input.ReadString();
					}
				}
			}
		}
	}

	private static readonly MessageParser<BootstrappingComplete> _parser = new MessageParser<BootstrappingComplete>(() => new BootstrappingComplete());

	private UnknownFieldSet _unknownFields;

	public const int SuccessFieldNumber = 1;

	public const int FailureFieldNumber = 2;

	private object state_;

	private StateOneofCase stateCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<BootstrappingComplete> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AnalyticsMediaManagementReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Success Success
	{
		get
		{
			if (stateCase_ != StateOneofCase.Success)
			{
				return null;
			}
			return (Types.Success)state_;
		}
		set
		{
			state_ = value;
			stateCase_ = ((value != null) ? StateOneofCase.Success : StateOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Failure Failure
	{
		get
		{
			if (stateCase_ != StateOneofCase.Failure)
			{
				return null;
			}
			return (Types.Failure)state_;
		}
		set
		{
			state_ = value;
			stateCase_ = ((value != null) ? StateOneofCase.Failure : StateOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public StateOneofCase StateCase => stateCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BootstrappingComplete()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BootstrappingComplete(BootstrappingComplete other)
		: this()
	{
		switch (other.StateCase)
		{
		case StateOneofCase.Success:
			Success = other.Success.Clone();
			break;
		case StateOneofCase.Failure:
			Failure = other.Failure.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public BootstrappingComplete Clone()
	{
		return new BootstrappingComplete(this);
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
		return Equals(other as BootstrappingComplete);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(BootstrappingComplete other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Success, other.Success))
		{
			return false;
		}
		if (!object.Equals(Failure, other.Failure))
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
		if (stateCase_ == StateOneofCase.Success)
		{
			num ^= Success.GetHashCode();
		}
		if (stateCase_ == StateOneofCase.Failure)
		{
			num ^= Failure.GetHashCode();
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
		if (stateCase_ == StateOneofCase.Success)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Success);
		}
		if (stateCase_ == StateOneofCase.Failure)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Failure);
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
		if (stateCase_ == StateOneofCase.Success)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Success);
		}
		if (stateCase_ == StateOneofCase.Failure)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Failure);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(BootstrappingComplete other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.StateCase)
		{
		case StateOneofCase.Success:
			if (Success == null)
			{
				Success = new Types.Success();
			}
			Success.MergeFrom(other.Success);
			break;
		case StateOneofCase.Failure:
			if (Failure == null)
			{
				Failure = new Types.Failure();
			}
			Failure.MergeFrom(other.Failure);
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
				Types.Success success = new Types.Success();
				if (stateCase_ == StateOneofCase.Success)
				{
					success.MergeFrom(Success);
				}
				input.ReadMessage(success);
				Success = success;
				break;
			}
			case 18u:
			{
				Types.Failure failure = new Types.Failure();
				if (stateCase_ == StateOneofCase.Failure)
				{
					failure.MergeFrom(Failure);
				}
				input.ReadMessage(failure);
				Failure = failure;
				break;
			}
			}
		}
	}
}
