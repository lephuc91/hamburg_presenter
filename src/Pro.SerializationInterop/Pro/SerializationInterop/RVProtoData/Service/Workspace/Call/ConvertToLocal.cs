using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Service.Workspace.Call;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ConvertToLocal : IMessage<ConvertToLocal>, IMessage, IEquatable<ConvertToLocal>, IDeepCloneable<ConvertToLocal>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Result : IMessage<Result>, IMessage, IEquatable<Result>, IDeepCloneable<Result>
		{
			public enum ResultOneofCase
			{
				None,
				Ok,
				Error
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class Ok : IMessage<Ok>, IMessage, IEquatable<Ok>, IDeepCloneable<Ok>
				{
					private static readonly MessageParser<Ok> _parser = new MessageParser<Ok>(() => new Ok());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<Ok> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Result.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Ok()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Ok(Ok other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public Ok Clone()
					{
						return new Ok(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as Ok);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(Ok other)
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
					public void MergeFrom(Ok other)
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

			private static readonly MessageParser<Result> _parser = new MessageParser<Result>(() => new Result());

			private UnknownFieldSet _unknownFields;

			public const int OkFieldNumber = 1;

			public const int ErrorFieldNumber = 2;

			private object result_;

			private ResultOneofCase resultCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Result> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ConvertToLocal.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.Ok Ok
			{
				get
				{
					if (resultCase_ != ResultOneofCase.Ok)
					{
						return null;
					}
					return (Types.Ok)result_;
				}
				set
				{
					result_ = value;
					resultCase_ = ((value != null) ? ResultOneofCase.Ok : ResultOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Error Error
			{
				get
				{
					if (resultCase_ != ResultOneofCase.Error)
					{
						return null;
					}
					return (Error)result_;
				}
				set
				{
					result_ = value;
					resultCase_ = ((value != null) ? ResultOneofCase.Error : ResultOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ResultOneofCase ResultCase => resultCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Result()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Result(Result other)
				: this()
			{
				switch (other.ResultCase)
				{
				case ResultOneofCase.Ok:
					Ok = other.Ok.Clone();
					break;
				case ResultOneofCase.Error:
					Error = other.Error.Clone();
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Result Clone()
			{
				return new Result(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearResult()
			{
				resultCase_ = ResultOneofCase.None;
				result_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Result);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Result other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Ok, other.Ok))
				{
					return false;
				}
				if (!object.Equals(Error, other.Error))
				{
					return false;
				}
				if (ResultCase != other.ResultCase)
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
				if (resultCase_ == ResultOneofCase.Ok)
				{
					num ^= Ok.GetHashCode();
				}
				if (resultCase_ == ResultOneofCase.Error)
				{
					num ^= Error.GetHashCode();
				}
				num ^= (int)resultCase_;
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
				if (resultCase_ == ResultOneofCase.Ok)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Ok);
				}
				if (resultCase_ == ResultOneofCase.Error)
				{
					output.WriteRawTag(18);
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
				if (resultCase_ == ResultOneofCase.Ok)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Ok);
				}
				if (resultCase_ == ResultOneofCase.Error)
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
			public void MergeFrom(Result other)
			{
				if (other == null)
				{
					return;
				}
				switch (other.ResultCase)
				{
				case ResultOneofCase.Ok:
					if (Ok == null)
					{
						Ok = new Types.Ok();
					}
					Ok.MergeFrom(other.Ok);
					break;
				case ResultOneofCase.Error:
					if (Error == null)
					{
						Error = new Error();
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
						Types.Ok ok = new Types.Ok();
						if (resultCase_ == ResultOneofCase.Ok)
						{
							ok.MergeFrom(Ok);
						}
						input.ReadMessage(ok);
						Ok = ok;
						break;
					}
					case 18u:
					{
						Error error = new Error();
						if (resultCase_ == ResultOneofCase.Error)
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
	}

	private static readonly MessageParser<ConvertToLocal> _parser = new MessageParser<ConvertToLocal>(() => new ConvertToLocal());

	private UnknownFieldSet _unknownFields;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ConvertToLocal> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => WorkspaceCallsReflection.Descriptor.MessageTypes[4];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ConvertToLocal()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ConvertToLocal(ConvertToLocal other)
		: this()
	{
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ConvertToLocal Clone()
	{
		return new ConvertToLocal(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ConvertToLocal);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ConvertToLocal other)
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
	public void MergeFrom(ConvertToLocal other)
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
