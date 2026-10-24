using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v1;

namespace Pro.SerializationInterop.RVProtoData.MediaService.v1;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class RequestEnvelope : IMessage<RequestEnvelope>, IMessage, IEquatable<RequestEnvelope>, IDeepCloneable<RequestEnvelope>
{
	public enum RequestOneofCase
	{
		None,
		ChangeShowDirectory,
		GetMediaReference,
		AddMediaReference,
		DuplicateMediaReference,
		ApplyTransformation,
		RemoveMediaReference,
		TriggerMediaReference,
		Ping,
		UpdateWorkspaces,
		PauseGeneration,
		ResumeGeneration
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class GetMediaReference : IMessage<GetMediaReference>, IMessage, IEquatable<GetMediaReference>, IDeepCloneable<GetMediaReference>
		{
			private static readonly MessageParser<GetMediaReference> _parser = new MessageParser<GetMediaReference>(() => new GetMediaReference());

			private UnknownFieldSet _unknownFields;

			public const int UuidFieldNumber = 1;

			private string uuid_ = "";

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetMediaReference> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => RequestEnvelope.Descriptor.NestedTypes[0];

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
			public GetMediaReference()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetMediaReference(GetMediaReference other)
				: this()
			{
				uuid_ = other.uuid_;
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetMediaReference Clone()
			{
				return new GetMediaReference(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetMediaReference);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetMediaReference other)
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
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetMediaReference other)
			{
				if (other != null)
				{
					if (other.Uuid.Length != 0)
					{
						Uuid = other.Uuid;
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
						Uuid = input.ReadString();
					}
				}
			}
		}
	}

	private static readonly MessageParser<RequestEnvelope> _parser = new MessageParser<RequestEnvelope>(() => new RequestEnvelope());

	private UnknownFieldSet _unknownFields;

	public const int ChangeShowDirectoryFieldNumber = 1;

	public const int GetMediaReferenceFieldNumber = 2;

	public const int AddMediaReferenceFieldNumber = 3;

	public const int DuplicateMediaReferenceFieldNumber = 4;

	public const int ApplyTransformationFieldNumber = 5;

	public const int RemoveMediaReferenceFieldNumber = 6;

	public const int TriggerMediaReferenceFieldNumber = 7;

	public const int PingFieldNumber = 8;

	public const int UpdateWorkspacesFieldNumber = 9;

	public const int PauseGenerationFieldNumber = 10;

	public const int ResumeGenerationFieldNumber = 11;

	private object request_;

	private RequestOneofCase requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<RequestEnvelope> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V1MediaReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

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
	public Types.GetMediaReference GetMediaReference
	{
		get
		{
			if (requestCase_ != RequestOneofCase.GetMediaReference)
			{
				return null;
			}
			return (Types.GetMediaReference)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.GetMediaReference : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AddMediaReference AddMediaReference
	{
		get
		{
			if (requestCase_ != RequestOneofCase.AddMediaReference)
			{
				return null;
			}
			return (AddMediaReference)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.AddMediaReference : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public DuplicateMediaReference DuplicateMediaReference
	{
		get
		{
			if (requestCase_ != RequestOneofCase.DuplicateMediaReference)
			{
				return null;
			}
			return (DuplicateMediaReference)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.DuplicateMediaReference : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ApplyTransformation ApplyTransformation
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ApplyTransformation)
			{
				return null;
			}
			return (ApplyTransformation)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ApplyTransformation : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RemoveMediaReferences RemoveMediaReference
	{
		get
		{
			if (requestCase_ != RequestOneofCase.RemoveMediaReference)
			{
				return null;
			}
			return (RemoveMediaReferences)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.RemoveMediaReference : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public TriggerMediaReference TriggerMediaReference
	{
		get
		{
			if (requestCase_ != RequestOneofCase.TriggerMediaReference)
			{
				return null;
			}
			return (TriggerMediaReference)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.TriggerMediaReference : RequestOneofCase.None);
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
		switch (other.RequestCase)
		{
		case RequestOneofCase.ChangeShowDirectory:
			ChangeShowDirectory = other.ChangeShowDirectory.Clone();
			break;
		case RequestOneofCase.GetMediaReference:
			GetMediaReference = other.GetMediaReference.Clone();
			break;
		case RequestOneofCase.AddMediaReference:
			AddMediaReference = other.AddMediaReference.Clone();
			break;
		case RequestOneofCase.DuplicateMediaReference:
			DuplicateMediaReference = other.DuplicateMediaReference.Clone();
			break;
		case RequestOneofCase.ApplyTransformation:
			ApplyTransformation = other.ApplyTransformation.Clone();
			break;
		case RequestOneofCase.RemoveMediaReference:
			RemoveMediaReference = other.RemoveMediaReference.Clone();
			break;
		case RequestOneofCase.TriggerMediaReference:
			TriggerMediaReference = other.TriggerMediaReference.Clone();
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
		if (!object.Equals(ChangeShowDirectory, other.ChangeShowDirectory))
		{
			return false;
		}
		if (!object.Equals(GetMediaReference, other.GetMediaReference))
		{
			return false;
		}
		if (!object.Equals(AddMediaReference, other.AddMediaReference))
		{
			return false;
		}
		if (!object.Equals(DuplicateMediaReference, other.DuplicateMediaReference))
		{
			return false;
		}
		if (!object.Equals(ApplyTransformation, other.ApplyTransformation))
		{
			return false;
		}
		if (!object.Equals(RemoveMediaReference, other.RemoveMediaReference))
		{
			return false;
		}
		if (!object.Equals(TriggerMediaReference, other.TriggerMediaReference))
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
		if (requestCase_ == RequestOneofCase.ChangeShowDirectory)
		{
			num ^= ChangeShowDirectory.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.GetMediaReference)
		{
			num ^= GetMediaReference.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.AddMediaReference)
		{
			num ^= AddMediaReference.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.DuplicateMediaReference)
		{
			num ^= DuplicateMediaReference.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ApplyTransformation)
		{
			num ^= ApplyTransformation.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.RemoveMediaReference)
		{
			num ^= RemoveMediaReference.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.TriggerMediaReference)
		{
			num ^= TriggerMediaReference.GetHashCode();
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
		if (requestCase_ == RequestOneofCase.ChangeShowDirectory)
		{
			output.WriteRawTag(10);
			output.WriteMessage(ChangeShowDirectory);
		}
		if (requestCase_ == RequestOneofCase.GetMediaReference)
		{
			output.WriteRawTag(18);
			output.WriteMessage(GetMediaReference);
		}
		if (requestCase_ == RequestOneofCase.AddMediaReference)
		{
			output.WriteRawTag(26);
			output.WriteMessage(AddMediaReference);
		}
		if (requestCase_ == RequestOneofCase.DuplicateMediaReference)
		{
			output.WriteRawTag(34);
			output.WriteMessage(DuplicateMediaReference);
		}
		if (requestCase_ == RequestOneofCase.ApplyTransformation)
		{
			output.WriteRawTag(42);
			output.WriteMessage(ApplyTransformation);
		}
		if (requestCase_ == RequestOneofCase.RemoveMediaReference)
		{
			output.WriteRawTag(50);
			output.WriteMessage(RemoveMediaReference);
		}
		if (requestCase_ == RequestOneofCase.TriggerMediaReference)
		{
			output.WriteRawTag(58);
			output.WriteMessage(TriggerMediaReference);
		}
		if (requestCase_ == RequestOneofCase.Ping)
		{
			output.WriteRawTag(66);
			output.WriteMessage(Ping);
		}
		if (requestCase_ == RequestOneofCase.UpdateWorkspaces)
		{
			output.WriteRawTag(74);
			output.WriteMessage(UpdateWorkspaces);
		}
		if (requestCase_ == RequestOneofCase.PauseGeneration)
		{
			output.WriteRawTag(82);
			output.WriteMessage(PauseGeneration);
		}
		if (requestCase_ == RequestOneofCase.ResumeGeneration)
		{
			output.WriteRawTag(90);
			output.WriteMessage(ResumeGeneration);
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
		if (requestCase_ == RequestOneofCase.ChangeShowDirectory)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ChangeShowDirectory);
		}
		if (requestCase_ == RequestOneofCase.GetMediaReference)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(GetMediaReference);
		}
		if (requestCase_ == RequestOneofCase.AddMediaReference)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(AddMediaReference);
		}
		if (requestCase_ == RequestOneofCase.DuplicateMediaReference)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(DuplicateMediaReference);
		}
		if (requestCase_ == RequestOneofCase.ApplyTransformation)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ApplyTransformation);
		}
		if (requestCase_ == RequestOneofCase.RemoveMediaReference)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(RemoveMediaReference);
		}
		if (requestCase_ == RequestOneofCase.TriggerMediaReference)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(TriggerMediaReference);
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
		switch (other.RequestCase)
		{
		case RequestOneofCase.ChangeShowDirectory:
			if (ChangeShowDirectory == null)
			{
				ChangeShowDirectory = new ChangeShowDirectory();
			}
			ChangeShowDirectory.MergeFrom(other.ChangeShowDirectory);
			break;
		case RequestOneofCase.GetMediaReference:
			if (GetMediaReference == null)
			{
				GetMediaReference = new Types.GetMediaReference();
			}
			GetMediaReference.MergeFrom(other.GetMediaReference);
			break;
		case RequestOneofCase.AddMediaReference:
			if (AddMediaReference == null)
			{
				AddMediaReference = new AddMediaReference();
			}
			AddMediaReference.MergeFrom(other.AddMediaReference);
			break;
		case RequestOneofCase.DuplicateMediaReference:
			if (DuplicateMediaReference == null)
			{
				DuplicateMediaReference = new DuplicateMediaReference();
			}
			DuplicateMediaReference.MergeFrom(other.DuplicateMediaReference);
			break;
		case RequestOneofCase.ApplyTransformation:
			if (ApplyTransformation == null)
			{
				ApplyTransformation = new ApplyTransformation();
			}
			ApplyTransformation.MergeFrom(other.ApplyTransformation);
			break;
		case RequestOneofCase.RemoveMediaReference:
			if (RemoveMediaReference == null)
			{
				RemoveMediaReference = new RemoveMediaReferences();
			}
			RemoveMediaReference.MergeFrom(other.RemoveMediaReference);
			break;
		case RequestOneofCase.TriggerMediaReference:
			if (TriggerMediaReference == null)
			{
				TriggerMediaReference = new TriggerMediaReference();
			}
			TriggerMediaReference.MergeFrom(other.TriggerMediaReference);
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
				ChangeShowDirectory changeShowDirectory = new ChangeShowDirectory();
				if (requestCase_ == RequestOneofCase.ChangeShowDirectory)
				{
					changeShowDirectory.MergeFrom(ChangeShowDirectory);
				}
				input.ReadMessage(changeShowDirectory);
				ChangeShowDirectory = changeShowDirectory;
				break;
			}
			case 18u:
			{
				Types.GetMediaReference getMediaReference = new Types.GetMediaReference();
				if (requestCase_ == RequestOneofCase.GetMediaReference)
				{
					getMediaReference.MergeFrom(GetMediaReference);
				}
				input.ReadMessage(getMediaReference);
				GetMediaReference = getMediaReference;
				break;
			}
			case 26u:
			{
				AddMediaReference addMediaReference = new AddMediaReference();
				if (requestCase_ == RequestOneofCase.AddMediaReference)
				{
					addMediaReference.MergeFrom(AddMediaReference);
				}
				input.ReadMessage(addMediaReference);
				AddMediaReference = addMediaReference;
				break;
			}
			case 34u:
			{
				DuplicateMediaReference duplicateMediaReference = new DuplicateMediaReference();
				if (requestCase_ == RequestOneofCase.DuplicateMediaReference)
				{
					duplicateMediaReference.MergeFrom(DuplicateMediaReference);
				}
				input.ReadMessage(duplicateMediaReference);
				DuplicateMediaReference = duplicateMediaReference;
				break;
			}
			case 42u:
			{
				ApplyTransformation applyTransformation = new ApplyTransformation();
				if (requestCase_ == RequestOneofCase.ApplyTransformation)
				{
					applyTransformation.MergeFrom(ApplyTransformation);
				}
				input.ReadMessage(applyTransformation);
				ApplyTransformation = applyTransformation;
				break;
			}
			case 50u:
			{
				RemoveMediaReferences removeMediaReferences = new RemoveMediaReferences();
				if (requestCase_ == RequestOneofCase.RemoveMediaReference)
				{
					removeMediaReferences.MergeFrom(RemoveMediaReference);
				}
				input.ReadMessage(removeMediaReferences);
				RemoveMediaReference = removeMediaReferences;
				break;
			}
			case 58u:
			{
				TriggerMediaReference triggerMediaReference = new TriggerMediaReference();
				if (requestCase_ == RequestOneofCase.TriggerMediaReference)
				{
					triggerMediaReference.MergeFrom(TriggerMediaReference);
				}
				input.ReadMessage(triggerMediaReference);
				TriggerMediaReference = triggerMediaReference;
				break;
			}
			case 66u:
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
			case 74u:
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
			case 82u:
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
			case 90u:
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
			}
		}
	}
}
