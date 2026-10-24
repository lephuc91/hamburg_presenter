using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Pro.SerializationInterop.RVProtoData.Service.Workspace.Remote;

namespace Pro.SerializationInterop.RVProtoData.Service.Workspace.Call;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class OpenRemote : IMessage<OpenRemote>, IMessage, IEquatable<OpenRemote>, IDeepCloneable<OpenRemote>
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

					public const int WorkspaceFieldNumber = 1;

					private Pro.SerializationInterop.RVProtoData.Service.Workspace.Remote.Workspace workspace_;

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
					public Pro.SerializationInterop.RVProtoData.Service.Workspace.Remote.Workspace Workspace
					{
						get
						{
							return workspace_;
						}
						set
						{
							workspace_ = value;
						}
					}

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
						workspace_ = ((other.workspace_ != null) ? other.workspace_.Clone() : null);
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
						if (!object.Equals(Workspace, other.Workspace))
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
						if (workspace_ != null)
						{
							num ^= Workspace.GetHashCode();
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
						if (workspace_ != null)
						{
							output.WriteRawTag(10);
							output.WriteMessage(Workspace);
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
						if (workspace_ != null)
						{
							num += 1 + CodedOutputStream.ComputeMessageSize(Workspace);
						}
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
						if (other == null)
						{
							return;
						}
						if (other.workspace_ != null)
						{
							if (workspace_ == null)
							{
								Workspace = new Pro.SerializationInterop.RVProtoData.Service.Workspace.Remote.Workspace();
							}
							Workspace.MergeFrom(other.Workspace);
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
							if (workspace_ == null)
							{
								Workspace = new Pro.SerializationInterop.RVProtoData.Service.Workspace.Remote.Workspace();
							}
							input.ReadMessage(Workspace);
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
			public static MessageDescriptor Descriptor => OpenRemote.Descriptor.NestedTypes[0];

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

	private static readonly MessageParser<OpenRemote> _parser = new MessageParser<OpenRemote>(() => new OpenRemote());

	private UnknownFieldSet _unknownFields;

	public const int UuidFieldNumber = 1;

	private string uuid_ = "";

	public const int PathFieldNumber = 2;

	private string path_ = "";

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<OpenRemote> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => WorkspaceCallsReflection.Descriptor.MessageTypes[2];

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
	public string Path
	{
		get
		{
			return path_;
		}
		set
		{
			path_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public OpenRemote()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public OpenRemote(OpenRemote other)
		: this()
	{
		uuid_ = other.uuid_;
		path_ = other.path_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public OpenRemote Clone()
	{
		return new OpenRemote(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as OpenRemote);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(OpenRemote other)
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
		if (Path != other.Path)
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
		if (Path.Length != 0)
		{
			num ^= Path.GetHashCode();
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
		if (Uuid.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(Uuid);
		}
		if (Path.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(Path);
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
		if (Path.Length != 0)
		{
			num += 1 + CodedOutputStream.ComputeStringSize(Path);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(OpenRemote other)
	{
		if (other != null)
		{
			if (other.Uuid.Length != 0)
			{
				Uuid = other.Uuid;
			}
			if (other.Path.Length != 0)
			{
				Path = other.Path;
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
				Uuid = input.ReadString();
				break;
			case 18u:
				Path = input.ReadString();
				break;
			}
		}
	}
}
