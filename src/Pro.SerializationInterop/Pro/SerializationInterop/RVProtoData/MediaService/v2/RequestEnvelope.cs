using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

namespace Pro.SerializationInterop.RVProtoData.MediaService.v2;

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
		PauseSync,
		ResumeSync,
		UpdatePrefs,
		UpdateSmartPlaylists,
		AddProContentReference,
		MarkAsCloud,
		MarkAsLocal,
		RemoveContainer,
		ImportUnmanagedMedia
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

			public const int IdFieldNumber = 1;

			private ReferenceIdentifier id_;

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
			public GetMediaReference()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetMediaReference(GetMediaReference other)
				: this()
			{
				id_ = ((other.id_ != null) ? other.id_.Clone() : null);
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
				if (!object.Equals(Id, other.Id))
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
					if (id_ == null)
					{
						Id = new ReferenceIdentifier();
					}
					input.ReadMessage(Id);
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

	public const int PauseSyncFieldNumber = 10;

	public const int ResumeSyncFieldNumber = 11;

	public const int UpdatePrefsFieldNumber = 12;

	public const int UpdateSmartPlaylistsFieldNumber = 13;

	public const int AddProContentReferenceFieldNumber = 14;

	public const int MarkAsCloudFieldNumber = 15;

	public const int MarkAsLocalFieldNumber = 16;

	public const int RemoveContainerFieldNumber = 17;

	public const int ImportUnmanagedMediaFieldNumber = 18;

	private object request_;

	private RequestOneofCase requestCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<RequestEnvelope> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V2MediaReflection.Descriptor.MessageTypes[1];

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
	public PauseSync PauseSync
	{
		get
		{
			if (requestCase_ != RequestOneofCase.PauseSync)
			{
				return null;
			}
			return (PauseSync)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.PauseSync : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResumeSync ResumeSync
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ResumeSync)
			{
				return null;
			}
			return (ResumeSync)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ResumeSync : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UpdatePrefs UpdatePrefs
	{
		get
		{
			if (requestCase_ != RequestOneofCase.UpdatePrefs)
			{
				return null;
			}
			return (UpdatePrefs)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.UpdatePrefs : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public UpdateSmartPlaylists UpdateSmartPlaylists
	{
		get
		{
			if (requestCase_ != RequestOneofCase.UpdateSmartPlaylists)
			{
				return null;
			}
			return (UpdateSmartPlaylists)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.UpdateSmartPlaylists : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AddProContentReference AddProContentReference
	{
		get
		{
			if (requestCase_ != RequestOneofCase.AddProContentReference)
			{
				return null;
			}
			return (AddProContentReference)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.AddProContentReference : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MarkWorkspaceAsCloud MarkAsCloud
	{
		get
		{
			if (requestCase_ != RequestOneofCase.MarkAsCloud)
			{
				return null;
			}
			return (MarkWorkspaceAsCloud)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.MarkAsCloud : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MarkWorkspaceAsLocal MarkAsLocal
	{
		get
		{
			if (requestCase_ != RequestOneofCase.MarkAsLocal)
			{
				return null;
			}
			return (MarkWorkspaceAsLocal)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.MarkAsLocal : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RemoveContainer RemoveContainer
	{
		get
		{
			if (requestCase_ != RequestOneofCase.RemoveContainer)
			{
				return null;
			}
			return (RemoveContainer)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.RemoveContainer : RequestOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ImportUnmanagedMedia ImportUnmanagedMedia
	{
		get
		{
			if (requestCase_ != RequestOneofCase.ImportUnmanagedMedia)
			{
				return null;
			}
			return (ImportUnmanagedMedia)request_;
		}
		set
		{
			request_ = value;
			requestCase_ = ((value != null) ? RequestOneofCase.ImportUnmanagedMedia : RequestOneofCase.None);
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
		case RequestOneofCase.PauseSync:
			PauseSync = other.PauseSync.Clone();
			break;
		case RequestOneofCase.ResumeSync:
			ResumeSync = other.ResumeSync.Clone();
			break;
		case RequestOneofCase.UpdatePrefs:
			UpdatePrefs = other.UpdatePrefs.Clone();
			break;
		case RequestOneofCase.UpdateSmartPlaylists:
			UpdateSmartPlaylists = other.UpdateSmartPlaylists.Clone();
			break;
		case RequestOneofCase.AddProContentReference:
			AddProContentReference = other.AddProContentReference.Clone();
			break;
		case RequestOneofCase.MarkAsCloud:
			MarkAsCloud = other.MarkAsCloud.Clone();
			break;
		case RequestOneofCase.MarkAsLocal:
			MarkAsLocal = other.MarkAsLocal.Clone();
			break;
		case RequestOneofCase.RemoveContainer:
			RemoveContainer = other.RemoveContainer.Clone();
			break;
		case RequestOneofCase.ImportUnmanagedMedia:
			ImportUnmanagedMedia = other.ImportUnmanagedMedia.Clone();
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
		if (!object.Equals(PauseSync, other.PauseSync))
		{
			return false;
		}
		if (!object.Equals(ResumeSync, other.ResumeSync))
		{
			return false;
		}
		if (!object.Equals(UpdatePrefs, other.UpdatePrefs))
		{
			return false;
		}
		if (!object.Equals(UpdateSmartPlaylists, other.UpdateSmartPlaylists))
		{
			return false;
		}
		if (!object.Equals(AddProContentReference, other.AddProContentReference))
		{
			return false;
		}
		if (!object.Equals(MarkAsCloud, other.MarkAsCloud))
		{
			return false;
		}
		if (!object.Equals(MarkAsLocal, other.MarkAsLocal))
		{
			return false;
		}
		if (!object.Equals(RemoveContainer, other.RemoveContainer))
		{
			return false;
		}
		if (!object.Equals(ImportUnmanagedMedia, other.ImportUnmanagedMedia))
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
		if (requestCase_ == RequestOneofCase.PauseSync)
		{
			num ^= PauseSync.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ResumeSync)
		{
			num ^= ResumeSync.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.UpdatePrefs)
		{
			num ^= UpdatePrefs.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.UpdateSmartPlaylists)
		{
			num ^= UpdateSmartPlaylists.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.AddProContentReference)
		{
			num ^= AddProContentReference.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.MarkAsCloud)
		{
			num ^= MarkAsCloud.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.MarkAsLocal)
		{
			num ^= MarkAsLocal.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.RemoveContainer)
		{
			num ^= RemoveContainer.GetHashCode();
		}
		if (requestCase_ == RequestOneofCase.ImportUnmanagedMedia)
		{
			num ^= ImportUnmanagedMedia.GetHashCode();
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
		if (requestCase_ == RequestOneofCase.PauseSync)
		{
			output.WriteRawTag(82);
			output.WriteMessage(PauseSync);
		}
		if (requestCase_ == RequestOneofCase.ResumeSync)
		{
			output.WriteRawTag(90);
			output.WriteMessage(ResumeSync);
		}
		if (requestCase_ == RequestOneofCase.UpdatePrefs)
		{
			output.WriteRawTag(98);
			output.WriteMessage(UpdatePrefs);
		}
		if (requestCase_ == RequestOneofCase.UpdateSmartPlaylists)
		{
			output.WriteRawTag(106);
			output.WriteMessage(UpdateSmartPlaylists);
		}
		if (requestCase_ == RequestOneofCase.AddProContentReference)
		{
			output.WriteRawTag(114);
			output.WriteMessage(AddProContentReference);
		}
		if (requestCase_ == RequestOneofCase.MarkAsCloud)
		{
			output.WriteRawTag(122);
			output.WriteMessage(MarkAsCloud);
		}
		if (requestCase_ == RequestOneofCase.MarkAsLocal)
		{
			output.WriteRawTag(130, 1);
			output.WriteMessage(MarkAsLocal);
		}
		if (requestCase_ == RequestOneofCase.RemoveContainer)
		{
			output.WriteRawTag(138, 1);
			output.WriteMessage(RemoveContainer);
		}
		if (requestCase_ == RequestOneofCase.ImportUnmanagedMedia)
		{
			output.WriteRawTag(146, 1);
			output.WriteMessage(ImportUnmanagedMedia);
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
		if (requestCase_ == RequestOneofCase.PauseSync)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(PauseSync);
		}
		if (requestCase_ == RequestOneofCase.ResumeSync)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(ResumeSync);
		}
		if (requestCase_ == RequestOneofCase.UpdatePrefs)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(UpdatePrefs);
		}
		if (requestCase_ == RequestOneofCase.UpdateSmartPlaylists)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(UpdateSmartPlaylists);
		}
		if (requestCase_ == RequestOneofCase.AddProContentReference)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(AddProContentReference);
		}
		if (requestCase_ == RequestOneofCase.MarkAsCloud)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(MarkAsCloud);
		}
		if (requestCase_ == RequestOneofCase.MarkAsLocal)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(MarkAsLocal);
		}
		if (requestCase_ == RequestOneofCase.RemoveContainer)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(RemoveContainer);
		}
		if (requestCase_ == RequestOneofCase.ImportUnmanagedMedia)
		{
			num += 2 + CodedOutputStream.ComputeMessageSize(ImportUnmanagedMedia);
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
		case RequestOneofCase.PauseSync:
			if (PauseSync == null)
			{
				PauseSync = new PauseSync();
			}
			PauseSync.MergeFrom(other.PauseSync);
			break;
		case RequestOneofCase.ResumeSync:
			if (ResumeSync == null)
			{
				ResumeSync = new ResumeSync();
			}
			ResumeSync.MergeFrom(other.ResumeSync);
			break;
		case RequestOneofCase.UpdatePrefs:
			if (UpdatePrefs == null)
			{
				UpdatePrefs = new UpdatePrefs();
			}
			UpdatePrefs.MergeFrom(other.UpdatePrefs);
			break;
		case RequestOneofCase.UpdateSmartPlaylists:
			if (UpdateSmartPlaylists == null)
			{
				UpdateSmartPlaylists = new UpdateSmartPlaylists();
			}
			UpdateSmartPlaylists.MergeFrom(other.UpdateSmartPlaylists);
			break;
		case RequestOneofCase.AddProContentReference:
			if (AddProContentReference == null)
			{
				AddProContentReference = new AddProContentReference();
			}
			AddProContentReference.MergeFrom(other.AddProContentReference);
			break;
		case RequestOneofCase.MarkAsCloud:
			if (MarkAsCloud == null)
			{
				MarkAsCloud = new MarkWorkspaceAsCloud();
			}
			MarkAsCloud.MergeFrom(other.MarkAsCloud);
			break;
		case RequestOneofCase.MarkAsLocal:
			if (MarkAsLocal == null)
			{
				MarkAsLocal = new MarkWorkspaceAsLocal();
			}
			MarkAsLocal.MergeFrom(other.MarkAsLocal);
			break;
		case RequestOneofCase.RemoveContainer:
			if (RemoveContainer == null)
			{
				RemoveContainer = new RemoveContainer();
			}
			RemoveContainer.MergeFrom(other.RemoveContainer);
			break;
		case RequestOneofCase.ImportUnmanagedMedia:
			if (ImportUnmanagedMedia == null)
			{
				ImportUnmanagedMedia = new ImportUnmanagedMedia();
			}
			ImportUnmanagedMedia.MergeFrom(other.ImportUnmanagedMedia);
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
				PauseSync pauseSync = new PauseSync();
				if (requestCase_ == RequestOneofCase.PauseSync)
				{
					pauseSync.MergeFrom(PauseSync);
				}
				input.ReadMessage(pauseSync);
				PauseSync = pauseSync;
				break;
			}
			case 90u:
			{
				ResumeSync resumeSync = new ResumeSync();
				if (requestCase_ == RequestOneofCase.ResumeSync)
				{
					resumeSync.MergeFrom(ResumeSync);
				}
				input.ReadMessage(resumeSync);
				ResumeSync = resumeSync;
				break;
			}
			case 98u:
			{
				UpdatePrefs updatePrefs = new UpdatePrefs();
				if (requestCase_ == RequestOneofCase.UpdatePrefs)
				{
					updatePrefs.MergeFrom(UpdatePrefs);
				}
				input.ReadMessage(updatePrefs);
				UpdatePrefs = updatePrefs;
				break;
			}
			case 106u:
			{
				UpdateSmartPlaylists updateSmartPlaylists = new UpdateSmartPlaylists();
				if (requestCase_ == RequestOneofCase.UpdateSmartPlaylists)
				{
					updateSmartPlaylists.MergeFrom(UpdateSmartPlaylists);
				}
				input.ReadMessage(updateSmartPlaylists);
				UpdateSmartPlaylists = updateSmartPlaylists;
				break;
			}
			case 114u:
			{
				AddProContentReference addProContentReference = new AddProContentReference();
				if (requestCase_ == RequestOneofCase.AddProContentReference)
				{
					addProContentReference.MergeFrom(AddProContentReference);
				}
				input.ReadMessage(addProContentReference);
				AddProContentReference = addProContentReference;
				break;
			}
			case 122u:
			{
				MarkWorkspaceAsCloud markWorkspaceAsCloud = new MarkWorkspaceAsCloud();
				if (requestCase_ == RequestOneofCase.MarkAsCloud)
				{
					markWorkspaceAsCloud.MergeFrom(MarkAsCloud);
				}
				input.ReadMessage(markWorkspaceAsCloud);
				MarkAsCloud = markWorkspaceAsCloud;
				break;
			}
			case 130u:
			{
				MarkWorkspaceAsLocal markWorkspaceAsLocal = new MarkWorkspaceAsLocal();
				if (requestCase_ == RequestOneofCase.MarkAsLocal)
				{
					markWorkspaceAsLocal.MergeFrom(MarkAsLocal);
				}
				input.ReadMessage(markWorkspaceAsLocal);
				MarkAsLocal = markWorkspaceAsLocal;
				break;
			}
			case 138u:
			{
				RemoveContainer removeContainer = new RemoveContainer();
				if (requestCase_ == RequestOneofCase.RemoveContainer)
				{
					removeContainer.MergeFrom(RemoveContainer);
				}
				input.ReadMessage(removeContainer);
				RemoveContainer = removeContainer;
				break;
			}
			case 146u:
			{
				ImportUnmanagedMedia importUnmanagedMedia = new ImportUnmanagedMedia();
				if (requestCase_ == RequestOneofCase.ImportUnmanagedMedia)
				{
					importUnmanagedMedia.MergeFrom(ImportUnmanagedMedia);
				}
				input.ReadMessage(importUnmanagedMedia);
				ImportUnmanagedMedia = importUnmanagedMedia;
				break;
			}
			}
		}
	}
}
