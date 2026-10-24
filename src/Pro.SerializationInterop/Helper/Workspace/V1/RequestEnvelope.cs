using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v1;

namespace Helper.Workspace.V1;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class RequestEnvelope : IMessage<RequestEnvelope>, IMessage, IEquatable<RequestEnvelope>, IDeepCloneable<RequestEnvelope>
{
	public enum RequestOneofCase
	{
		None = 0,
		Start = 2,
		ChangeShowDirectory = 3,
		Add = 4,
		Duplicate = 5,
		Apply = 6,
		Remove = 7,
		Trigger = 8,
		Ping = 9,
		UpdateWorkspaces = 10,
		PauseGeneration = 11,
		ResumeGeneration = 12,
		GetState = 13
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Start : IMessage<Start>, IMessage, IEquatable<Start>, IDeepCloneable<Start>
		{
			private static readonly MessageParser<Start> _parser = new MessageParser<Start>(() => new Start());

			private UnknownFieldSet _unknownFields;

			public const int ProductInfoFieldNumber = 1;

			private ProductInformation productInfo_;

			public const int ShowDirectoryFieldNumber = 2;

			private string showDirectory_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Start> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => RequestEnvelope.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ProductInformation ProductInfo
			{
				get
				{
					return productInfo_;
				}
				set
				{
					productInfo_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string ShowDirectory
			{
				get
				{
					return showDirectory_;
				}
				set
				{
					showDirectory_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Start()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Start(Start other)
				: this()
			{
				productInfo_ = ((other.productInfo_ != null) ? other.productInfo_.Clone() : null);
				showDirectory_ = other.showDirectory_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Start Clone()
			{
				return new Start(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Start);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Start other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(ProductInfo, other.ProductInfo))
				{
					return false;
				}
				if (ShowDirectory != other.ShowDirectory)
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
				if (productInfo_ != null)
				{
					num ^= ProductInfo.GetHashCode();
				}
				if (ShowDirectory.Length != 0)
				{
					num ^= ShowDirectory.GetHashCode();
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
				if (productInfo_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(ProductInfo);
				}
				if (ShowDirectory.Length != 0)
				{
					output.WriteRawTag(18);
					output.WriteString(ShowDirectory);
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
				if (productInfo_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(ProductInfo);
				}
				if (ShowDirectory.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(ShowDirectory);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Start other)
			{
				if (other == null)
				{
					return;
				}
				if (other.productInfo_ != null)
				{
					if (productInfo_ == null)
					{
						ProductInfo = new ProductInformation();
					}
					ProductInfo.MergeFrom(other.ProductInfo);
				}
				if (other.ShowDirectory.Length != 0)
				{
					ShowDirectory = other.ShowDirectory;
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
						if (productInfo_ == null)
						{
							ProductInfo = new ProductInformation();
						}
						input.ReadMessage(ProductInfo);
						break;
					case 18u:
						ShowDirectory = input.ReadString();
						break;
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Header : IMessage<Header>, IMessage, IEquatable<Header>, IDeepCloneable<Header>
		{
			private static readonly MessageParser<Header> _parser = new MessageParser<Header>(() => new Header());

			private UnknownFieldSet _unknownFields;

			public const int IdFieldNumber = 1;

			private string id_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Header> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => RequestEnvelope.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string Id
			{
				get
				{
					return id_;
				}
				set
				{
					id_ = ProtoPreconditions.CheckNotNull(value, "value");
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Header()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Header(Header other)
				: this()
			{
				id_ = other.id_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Header Clone()
			{
				return new Header(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Header);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Header other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (Id != other.Id)
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
				if (Id.Length != 0)
				{
					num ^= Id.GetHashCode();
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
				if (Id.Length != 0)
				{
					output.WriteRawTag(10);
					output.WriteString(Id);
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
				if (Id.Length != 0)
				{
					num += 1 + CodedOutputStream.ComputeStringSize(Id);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Header other)
			{
				if (other != null)
				{
					if (other.Id.Length != 0)
					{
						Id = other.Id;
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
						Id = input.ReadString();
					}
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetState : IMessage<GetState>, IMessage, IEquatable<GetState>, IDeepCloneable<GetState>
		{
			private static readonly MessageParser<GetState> _parser = new MessageParser<GetState>(() => new GetState());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetState> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => RequestEnvelope.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetState()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetState(GetState other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetState Clone()
			{
				return new GetState(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetState);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetState other)
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
			public void MergeFrom(GetState other)
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

	private static readonly MessageParser<RequestEnvelope> _parser = new MessageParser<RequestEnvelope>(() => new RequestEnvelope());

	private UnknownFieldSet _unknownFields;

	public const int HeaderFieldNumber = 1;

	private Types.Header header_;

	public const int StartFieldNumber = 2;

	public const int ChangeShowDirectoryFieldNumber = 3;

	public const int AddFieldNumber = 4;

	public const int DuplicateFieldNumber = 5;

	public const int ApplyFieldNumber = 6;

	public const int RemoveFieldNumber = 7;

	public const int TriggerFieldNumber = 8;

	public const int PingFieldNumber = 9;

	public const int UpdateWorkspacesFieldNumber = 10;

	public const int PauseGenerationFieldNumber = 11;

	public const int ResumeGenerationFieldNumber = 12;

	public const int GetStateFieldNumber = 13;

	private object request_;

	private RequestOneofCase requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<RequestEnvelope> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V1HelperWorkspaceReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Header Header
	{
		get
		{
			return header_;
		}
		set
		{
			header_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Start Start
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Start)
			{
				return null;
			}
			return (Types.Start)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Start : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ChangeShowDirectory ChangeShowDirectory
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ChangeShowDirectory)
			{
				return null;
			}
			return (ChangeShowDirectory)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ChangeShowDirectory : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AddMediaReference Add
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Add)
			{
				return null;
			}
			return (AddMediaReference)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Add : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DuplicateMediaReference Duplicate
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Duplicate)
			{
				return null;
			}
			return (DuplicateMediaReference)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Duplicate : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ApplyTransformation Apply
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Apply)
			{
				return null;
			}
			return (ApplyTransformation)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Apply : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RemoveMediaReferences Remove
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Remove)
			{
				return null;
			}
			return (RemoveMediaReferences)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Remove : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TriggerMediaReference Trigger
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Trigger)
			{
				return null;
			}
			return (TriggerMediaReference)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Trigger : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Ping Ping
	{
		get
		{
			if (requestCase_ != RequestOneofCase.Ping)
			{
				return null;
			}
			return (Ping)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.Ping : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UpdateWorkspaces UpdateWorkspaces
	{
		get
		{
			if (requestCase_ != RequestOneofCase.UpdateWorkspaces)
			{
				return null;
			}
			return (UpdateWorkspaces)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.UpdateWorkspaces : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public PauseGeneration PauseGeneration
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PauseGeneration)
			{
				return null;
			}
			return (PauseGeneration)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PauseGeneration : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResumeGeneration ResumeGeneration
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ResumeGeneration)
			{
				return null;
			}
			return (ResumeGeneration)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ResumeGeneration : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.GetState GetState
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetState)
			{
				return null;
			}
			return (Types.GetState)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetState : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestOneofCase RequestCase => requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestEnvelope()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestEnvelope(RequestEnvelope other)
		: this()
	{
		header_ = ((other.header_ != null) ? other.header_.Clone() : null);
		switch (other.RequestCase)
		{
		case RequestOneofCase.Start:
			Start = other.Start.Clone();
			break;
		case RequestOneofCase.ChangeShowDirectory:
			ChangeShowDirectory = other.ChangeShowDirectory.Clone();
			break;
		case RequestOneofCase.Add:
			Add = other.Add.Clone();
			break;
		case RequestOneofCase.Duplicate:
			Duplicate = other.Duplicate.Clone();
			break;
		case RequestOneofCase.Apply:
			Apply = other.Apply.Clone();
			break;
		case RequestOneofCase.Remove:
			Remove = other.Remove.Clone();
			break;
		case RequestOneofCase.Trigger:
			Trigger = other.Trigger.Clone();
			break;
		case RequestOneofCase.Ping:
			Ping = other.Ping.Clone();
			break;
		case RequestOneofCase.UpdateWorkspaces:
			UpdateWorkspaces = other.UpdateWorkspaces.Clone();
			break;
		case RequestOneofCase.PauseGeneration:
			PauseGeneration = other.PauseGeneration.Clone();
			break;
		case RequestOneofCase.ResumeGeneration:
			ResumeGeneration = other.ResumeGeneration.Clone();
			break;
		case RequestOneofCase.GetState:
			GetState = other.GetState.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestEnvelope Clone()
	{
		return new RequestEnvelope(this);
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
		return Equals(other as RequestEnvelope);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(RequestEnvelope other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Header, other.Header))
		{
			return false;
		}
		if (!object.Equals(Start, other.Start))
		{
			return false;
		}
		if (!object.Equals(ChangeShowDirectory, other.ChangeShowDirectory))
		{
			return false;
		}
		if (!object.Equals(Add, other.Add))
		{
			return false;
		}
		if (!object.Equals(Duplicate, other.Duplicate))
		{
			return false;
		}
		if (!object.Equals(Apply, other.Apply))
		{
			return false;
		}
		if (!object.Equals(Remove, other.Remove))
		{
			return false;
		}
		if (!object.Equals(Trigger, other.Trigger))
		{
			return false;
		}
		if (!object.Equals(Ping, other.Ping))
		{
			return false;
		}
		if (!object.Equals(UpdateWorkspaces, other.UpdateWorkspaces))
		{
			return false;
		}
		if (!object.Equals(PauseGeneration, other.PauseGeneration))
		{
			return false;
		}
		if (!object.Equals(ResumeGeneration, other.ResumeGeneration))
		{
			return false;
		}
		if (!object.Equals(GetState, other.GetState))
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
		if (header_ != null)
		{
			num ^= Header.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Start)
		{
			num ^= Start.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ChangeShowDirectory)
		{
			num ^= ChangeShowDirectory.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Add)
		{
			num ^= Add.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Duplicate)
		{
			num ^= Duplicate.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Apply)
		{
			num ^= Apply.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Remove)
		{
			num ^= Remove.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Trigger)
		{
			num ^= Trigger.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.Ping)
		{
			num ^= Ping.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.UpdateWorkspaces)
		{
			num ^= UpdateWorkspaces.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.PauseGeneration)
		{
			num ^= PauseGeneration.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ResumeGeneration)
		{
			num ^= ResumeGeneration.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetState)
		{
			num ^= GetState.GetHashCode();
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
		if (header_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Header);
		}
		if (requestCase_ == RequestOneofCase.Start)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Start);
		}
		if (requestCase_ == RequestOneofCase.ChangeShowDirectory)
		{
			output.WriteRawTag(26);
			output.WriteMessage(ChangeShowDirectory);
		}
		if (requestCase_ == RequestOneofCase.Add)
		{
			output.WriteRawTag(34);
			output.WriteMessage(Add);
		}
		if (requestCase_ == RequestOneofCase.Duplicate)
		{
			output.WriteRawTag(42);
			output.WriteMessage(Duplicate);
		}
		if (requestCase_ == RequestOneofCase.Apply)
		{
			output.WriteRawTag(50);
			output.WriteMessage(Apply);
		}
		if (requestCase_ == RequestOneofCase.Remove)
		{
			output.WriteRawTag(58);
			output.WriteMessage(Remove);
		}
		if (requestCase_ == RequestOneofCase.Trigger)
		{
			output.WriteRawTag(66);
			output.WriteMessage(Trigger);
		}
		if (requestCase_ == RequestOneofCase.Ping)
		{
			output.WriteRawTag(74);
			output.WriteMessage(Ping);
		}
		if (requestCase_ == RequestOneofCase.UpdateWorkspaces)
		{
			output.WriteRawTag(82);
			output.WriteMessage(UpdateWorkspaces);
		}
		if (requestCase_ == RequestOneofCase.PauseGeneration)
		{
			output.WriteRawTag(90);
			output.WriteMessage(PauseGeneration);
		}
		if (requestCase_ == RequestOneofCase.ResumeGeneration)
		{
			output.WriteRawTag(98);
			output.WriteMessage(ResumeGeneration);
		}
		if (requestCase_ == RequestOneofCase.GetState)
		{
			output.WriteRawTag(106);
			output.WriteMessage(GetState);
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
		if (header_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Header);
		}
		if (requestCase_ == RequestOneofCase.Start)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Start);
		}
		if (requestCase_ == RequestOneofCase.ChangeShowDirectory)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ChangeShowDirectory);
		}
		if (requestCase_ == RequestOneofCase.Add)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Add);
		}
		if (requestCase_ == RequestOneofCase.Duplicate)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Duplicate);
		}
		if (requestCase_ == RequestOneofCase.Apply)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Apply);
		}
		if (requestCase_ == RequestOneofCase.Remove)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Remove);
		}
		if (requestCase_ == RequestOneofCase.Trigger)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Trigger);
		}
		if (requestCase_ == RequestOneofCase.Ping)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Ping);
		}
		if (requestCase_ == RequestOneofCase.UpdateWorkspaces)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(UpdateWorkspaces);
		}
		if (requestCase_ == RequestOneofCase.PauseGeneration)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PauseGeneration);
		}
		if (requestCase_ == RequestOneofCase.ResumeGeneration)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ResumeGeneration);
		}
		if (requestCase_ == RequestOneofCase.GetState)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetState);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(RequestEnvelope other)
	{
		if (other == null)
		{
			return;
		}
		if (other.header_ != null)
		{
			if (header_ == null)
			{
				Header = new Types.Header();
			}
			Header.MergeFrom(other.Header);
		}
		switch (other.RequestCase)
		{
		case RequestOneofCase.Start:
			if (Start == null)
			{
				Start = new Types.Start();
			}
			Start.MergeFrom(other.Start);
			break;
		case RequestOneofCase.ChangeShowDirectory:
			if (ChangeShowDirectory == null)
			{
				ChangeShowDirectory = new ChangeShowDirectory();
			}
			ChangeShowDirectory.MergeFrom(other.ChangeShowDirectory);
			break;
		case RequestOneofCase.Add:
			if (Add == null)
			{
				Add = new AddMediaReference();
			}
			Add.MergeFrom(other.Add);
			break;
		case RequestOneofCase.Duplicate:
			if (Duplicate == null)
			{
				Duplicate = new DuplicateMediaReference();
			}
			Duplicate.MergeFrom(other.Duplicate);
			break;
		case RequestOneofCase.Apply:
			if (Apply == null)
			{
				Apply = new ApplyTransformation();
			}
			Apply.MergeFrom(other.Apply);
			break;
		case RequestOneofCase.Remove:
			if (Remove == null)
			{
				Remove = new RemoveMediaReferences();
			}
			Remove.MergeFrom(other.Remove);
			break;
		case RequestOneofCase.Trigger:
			if (Trigger == null)
			{
				Trigger = new TriggerMediaReference();
			}
			Trigger.MergeFrom(other.Trigger);
			break;
		case RequestOneofCase.Ping:
			if (Ping == null)
			{
				Ping = new Ping();
			}
			Ping.MergeFrom(other.Ping);
			break;
		case RequestOneofCase.UpdateWorkspaces:
			if (UpdateWorkspaces == null)
			{
				UpdateWorkspaces = new UpdateWorkspaces();
			}
			UpdateWorkspaces.MergeFrom(other.UpdateWorkspaces);
			break;
		case RequestOneofCase.PauseGeneration:
			if (PauseGeneration == null)
			{
				PauseGeneration = new PauseGeneration();
			}
			PauseGeneration.MergeFrom(other.PauseGeneration);
			break;
		case RequestOneofCase.ResumeGeneration:
			if (ResumeGeneration == null)
			{
				ResumeGeneration = new ResumeGeneration();
			}
			ResumeGeneration.MergeFrom(other.ResumeGeneration);
			break;
		case RequestOneofCase.GetState:
			if (GetState == null)
			{
				GetState = new Types.GetState();
			}
			GetState.MergeFrom(other.GetState);
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
				if (header_ == null)
				{
					Header = new Types.Header();
				}
				input.ReadMessage(Header);
				break;
			case 18u:
			{
				Types.Start start = new Types.Start();
				if (requestCase_ == RequestOneofCase.Start)
				{
					start.MergeFrom(Start);
				}
				input.ReadMessage(start);
				Start = start;
				break;
			}
			case 26u:
			{
				ChangeShowDirectory changeShowDirectory = new ChangeShowDirectory();
				if (requestCase_ == RequestOneofCase.ChangeShowDirectory)
				{
					changeShowDirectory.MergeFrom(ChangeShowDirectory);
				}
				input.ReadMessage(changeShowDirectory);
				ChangeShowDirectory = changeShowDirectory;
				break;
			}
			case 34u:
			{
				AddMediaReference addMediaReference = new AddMediaReference();
				if (requestCase_ == RequestOneofCase.Add)
				{
					addMediaReference.MergeFrom(Add);
				}
				input.ReadMessage(addMediaReference);
				Add = addMediaReference;
				break;
			}
			case 42u:
			{
				DuplicateMediaReference duplicateMediaReference = new DuplicateMediaReference();
				if (requestCase_ == RequestOneofCase.Duplicate)
				{
					duplicateMediaReference.MergeFrom(Duplicate);
				}
				input.ReadMessage(duplicateMediaReference);
				Duplicate = duplicateMediaReference;
				break;
			}
			case 50u:
			{
				ApplyTransformation applyTransformation = new ApplyTransformation();
				if (requestCase_ == RequestOneofCase.Apply)
				{
					applyTransformation.MergeFrom(Apply);
				}
				input.ReadMessage(applyTransformation);
				Apply = applyTransformation;
				break;
			}
			case 58u:
			{
				RemoveMediaReferences removeMediaReferences = new RemoveMediaReferences();
				if (requestCase_ == RequestOneofCase.Remove)
				{
					removeMediaReferences.MergeFrom(Remove);
				}
				input.ReadMessage(removeMediaReferences);
				Remove = removeMediaReferences;
				break;
			}
			case 66u:
			{
				TriggerMediaReference triggerMediaReference = new TriggerMediaReference();
				if (requestCase_ == RequestOneofCase.Trigger)
				{
					triggerMediaReference.MergeFrom(Trigger);
				}
				input.ReadMessage(triggerMediaReference);
				Trigger = triggerMediaReference;
				break;
			}
			case 74u:
			{
				Ping ping = new Ping();
				if (requestCase_ == RequestOneofCase.Ping)
				{
					ping.MergeFrom(Ping);
				}
				input.ReadMessage(ping);
				Ping = ping;
				break;
			}
			case 82u:
			{
				UpdateWorkspaces updateWorkspaces = new UpdateWorkspaces();
				if (requestCase_ == RequestOneofCase.UpdateWorkspaces)
				{
					updateWorkspaces.MergeFrom(UpdateWorkspaces);
				}
				input.ReadMessage(updateWorkspaces);
				UpdateWorkspaces = updateWorkspaces;
				break;
			}
			case 90u:
			{
				PauseGeneration pauseGeneration = new PauseGeneration();
				if (requestCase_ == RequestOneofCase.PauseGeneration)
				{
					pauseGeneration.MergeFrom(PauseGeneration);
				}
				input.ReadMessage(pauseGeneration);
				PauseGeneration = pauseGeneration;
				break;
			}
			case 98u:
			{
				ResumeGeneration resumeGeneration = new ResumeGeneration();
				if (requestCase_ == RequestOneofCase.ResumeGeneration)
				{
					resumeGeneration.MergeFrom(ResumeGeneration);
				}
				input.ReadMessage(resumeGeneration);
				ResumeGeneration = resumeGeneration;
				break;
			}
			case 106u:
			{
				Types.GetState getState = new Types.GetState();
				if (requestCase_ == RequestOneofCase.GetState)
				{
					getState.MergeFrom(GetState);
				}
				input.ReadMessage(getState);
				GetState = getState;
				break;
			}
			}
		}
	}
}
