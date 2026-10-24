using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AssetImported : IMessage<AssetImported>, IMessage, IEquatable<AssetImported>, IDeepCloneable<AssetImported>
{
	public enum StateOneofCase
	{
		None = 0,
		Success = 2,
		Error = 3
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		public enum Error
		{
			[OriginalName("IMPORT_RESULT_UNKNOWN_ERROR")]
			ImportResultUnknownError,
			[OriginalName("IMPORT_RESULT_INVALID_IMPORT_PATH")]
			ImportResultInvalidImportPath,
			[OriginalName("IMPORT_RESULT_READ_PERMISSION_DENIED")]
			ImportResultReadPermissionDenied,
			[OriginalName("IMPORT_RESULT_WRITE_PERMISSION_DENIED")]
			ImportResultWritePermissionDenied,
			[OriginalName("IMPORT_RESULT_FULL_STORAGE")]
			ImportResultFullStorage,
			[OriginalName("IMPORT_RESULT_READ_ONLY_FILESYSTEM")]
			ImportResultReadOnlyFilesystem
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Success : IMessage<Success>, IMessage, IEquatable<Success>, IDeepCloneable<Success>
		{
			private static readonly MessageParser<Success> _parser = new MessageParser<Success>(() => new Success());

			private UnknownFieldSet _unknownFields;

			public const int UrlFieldNumber = 1;

			private string url_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Success> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => AssetImported.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Url
			{
				get
				{
					return url_;
				}
				set
				{
					url_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

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
				url_ = other.url_;
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
				if (Url != other.Url)
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
				if (Url.Length != 0)
				{
					num ^= Url.GetHashCode();
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
				if (Url.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Url);
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
				if (Url.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Url);
				}
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
					if (other.Url.Length != 0)
					{
						Url = other.Url;
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
						Url = input.ReadString();
					}
				}
			}
		}
	}

	private static readonly MessageParser<AssetImported> _parser = new MessageParser<AssetImported>(() => new AssetImported());

	private UnknownFieldSet _unknownFields;

	public const int IdFieldNumber = 1;

	private ReferenceIdentifier id_;

	public const int SuccessFieldNumber = 2;

	public const int ErrorFieldNumber = 3;

	private object state_;

	private StateOneofCase stateCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AssetImported> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V2HelperCommonReflection.Descriptor.MessageTypes[10];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ReferenceIdentifier Id
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
	public Types.Error Error
	{
		get
		{
			if (!HasError)
			{
				return Types.Error.ImportResultUnknownError;
			}
			return (Types.Error)state_;
		}
		set
		{
			state_ = value;
			stateCase_ = StateOneofCase.Error;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasError => stateCase_ == StateOneofCase.Error;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public StateOneofCase StateCase => stateCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AssetImported()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AssetImported(AssetImported other)
		: this()
	{
		id_ = ((other.id_ != null) ? other.id_.Clone() : null);
		switch (other.StateCase)
		{
		case StateOneofCase.Success:
			Success = other.Success.Clone();
			break;
		case StateOneofCase.Error:
			Error = other.Error;
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AssetImported Clone()
	{
		return new AssetImported(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearError()
	{
		if (HasError)
		{
			ClearState();
		}
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
		return Equals(other as AssetImported);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AssetImported other)
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
		if (!object.Equals(Success, other.Success))
		{
			return false;
		}
		if (Error != other.Error)
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
		if (id_ != null)
		{
			num ^= Id.GetHashCode();
		}
		if (stateCase_ == StateOneofCase.Success)
		{
			num ^= Success.GetHashCode();
		}
		if (HasError)
		{
			num ^= Error.GetHashCode();
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
		if (id_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Id);
		}
		if (stateCase_ == StateOneofCase.Success)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Success);
		}
		if (HasError)
		{
			output.WriteRawTag(24);
			output.WriteEnum((int)Error);
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
		if (stateCase_ == StateOneofCase.Success)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Success);
		}
		if (HasError)
		{
			num += 1 + CodedOutputStream.ComputeEnumSize((int)Error);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(AssetImported other)
	{
		if (other == null)
		{
			return;
		}
		if (other.id_ != null)
		{
			if (id_ == null)
			{
				Id = new ReferenceIdentifier();
			}
			Id.MergeFrom(other.Id);
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
		case StateOneofCase.Error:
			Error = other.Error;
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
				if (id_ == null)
				{
					Id = new ReferenceIdentifier();
				}
				input.ReadMessage(Id);
				break;
			case 18u:
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
			case 24u:
				state_ = input.ReadEnum();
				stateCase_ = StateOneofCase.Error;
				break;
			}
		}
	}
}
