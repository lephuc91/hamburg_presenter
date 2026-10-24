using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

namespace Pro.SerializationInterop.RVProtoData.MediaService.v2;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ResponseEnvelope : IMessage<ResponseEnvelope>, IMessage, IEquatable<ResponseEnvelope>, IDeepCloneable<ResponseEnvelope>
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
		public sealed class ChangeShowDirectoryResponse : IMessage<ChangeShowDirectoryResponse>, IMessage, IEquatable<ChangeShowDirectoryResponse>, IDeepCloneable<ChangeShowDirectoryResponse>
		{
			private static readonly MessageParser<ChangeShowDirectoryResponse> _parser = new MessageParser<ChangeShowDirectoryResponse>(() => new ChangeShowDirectoryResponse());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<ChangeShowDirectoryResponse> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ResponseEnvelope.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ChangeShowDirectoryResponse()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ChangeShowDirectoryResponse(ChangeShowDirectoryResponse other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ChangeShowDirectoryResponse Clone()
			{
				return new ChangeShowDirectoryResponse(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as ChangeShowDirectoryResponse);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(ChangeShowDirectoryResponse other)
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
			public void MergeFrom(ChangeShowDirectoryResponse other)
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
		public sealed class GetMediaReferenceResponse : IMessage<GetMediaReferenceResponse>, IMessage, IEquatable<GetMediaReferenceResponse>, IDeepCloneable<GetMediaReferenceResponse>
		{
			private static readonly MessageParser<GetMediaReferenceResponse> _parser = new MessageParser<GetMediaReferenceResponse>(() => new GetMediaReferenceResponse());

			private UnknownFieldSet _unknownFields;

			public const int StateFieldNumber = 1;

			private MediaReference state_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<GetMediaReferenceResponse> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ResponseEnvelope.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MediaReference State
			{
				get
				{
					return state_;
				}
				set
				{
					state_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetMediaReferenceResponse()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetMediaReferenceResponse(GetMediaReferenceResponse other)
				: this()
			{
				state_ = ((other.state_ != null) ? other.state_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetMediaReferenceResponse Clone()
			{
				return new GetMediaReferenceResponse(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as GetMediaReferenceResponse);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(GetMediaReferenceResponse other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(State, other.State))
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
				if (state_ != null)
				{
					num ^= State.GetHashCode();
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
				if (state_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(State);
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
				if (state_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(State);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(GetMediaReferenceResponse other)
			{
				if (other == null)
				{
					return;
				}
				if (other.state_ != null)
				{
					if (state_ == null)
					{
						State = new MediaReference();
					}
					State.MergeFrom(other.State);
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
					if (state_ == null)
					{
						State = new MediaReference();
					}
					input.ReadMessage(State);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Response : IMessage<Response>, IMessage, IEquatable<Response>, IDeepCloneable<Response>
		{
			public enum ResponseOneofCase
			{
				None,
				Change,
				Get,
				Add,
				Duplicate,
				Apply,
				Remove,
				Trigger,
				Pong,
				Update,
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

			private static readonly MessageParser<Response> _parser = new MessageParser<Response>(() => new Response());

			private UnknownFieldSet _unknownFields;

			public const int ChangeFieldNumber = 1;

			public const int GetFieldNumber = 2;

			public const int AddFieldNumber = 3;

			public const int DuplicateFieldNumber = 4;

			public const int ApplyFieldNumber = 5;

			public const int RemoveFieldNumber = 6;

			public const int TriggerFieldNumber = 7;

			public const int PongFieldNumber = 8;

			public const int UpdateFieldNumber = 9;

			public const int PauseSyncFieldNumber = 10;

			public const int ResumeSyncFieldNumber = 11;

			public const int UpdatePrefsFieldNumber = 12;

			public const int UpdateSmartPlaylistsFieldNumber = 13;

			public const int AddProContentReferenceFieldNumber = 14;

			public const int MarkAsCloudFieldNumber = 15;

			public const int MarkAsLocalFieldNumber = 16;

			public const int RemoveContainerFieldNumber = 17;

			public const int ImportUnmanagedMediaFieldNumber = 18;

			private object response_;

			private ResponseOneofCase responseCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Response> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ResponseEnvelope.Descriptor.NestedTypes[2];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ChangeShowDirectoryResponse Change
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.Change)
					{
						return null;
					}
					return (ChangeShowDirectoryResponse)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.Change : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public GetMediaReferenceResponse Get
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.Get)
					{
						return null;
					}
					return (GetMediaReferenceResponse)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.Get : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AddMediaReferenceResponse Add
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.Add)
					{
						return null;
					}
					return (AddMediaReferenceResponse)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.Add : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public DuplicateMediaReferenceResponse Duplicate
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.Duplicate)
					{
						return null;
					}
					return (DuplicateMediaReferenceResponse)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.Duplicate : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ApplyTransformationResponse Apply
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.Apply)
					{
						return null;
					}
					return (ApplyTransformationResponse)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.Apply : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RemoveMediaReferenceResponse Remove
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.Remove)
					{
						return null;
					}
					return (RemoveMediaReferenceResponse)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.Remove : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public TriggerMediaReferenceResponse Trigger
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.Trigger)
					{
						return null;
					}
					return (TriggerMediaReferenceResponse)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.Trigger : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Pong Pong
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.Pong)
					{
						return null;
					}
					return (Pong)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.Pong : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UpdateWorkspacesResponse Update
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.Update)
					{
						return null;
					}
					return (UpdateWorkspacesResponse)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.Update : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public PauseSyncResponse PauseSync
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.PauseSync)
					{
						return null;
					}
					return (PauseSyncResponse)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.PauseSync : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ResumeSyncResponse ResumeSync
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.ResumeSync)
					{
						return null;
					}
					return (ResumeSyncResponse)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.ResumeSync : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UpdatePrefsResponse UpdatePrefs
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.UpdatePrefs)
					{
						return null;
					}
					return (UpdatePrefsResponse)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.UpdatePrefs : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public UpdateSmartPlaylistsResponse UpdateSmartPlaylists
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.UpdateSmartPlaylists)
					{
						return null;
					}
					return (UpdateSmartPlaylistsResponse)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.UpdateSmartPlaylists : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public AddProContentReferenceResponse AddProContentReference
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.AddProContentReference)
					{
						return null;
					}
					return (AddProContentReferenceResponse)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.AddProContentReference : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MarkWorkspaceAsCloudResponse MarkAsCloud
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.MarkAsCloud)
					{
						return null;
					}
					return (MarkWorkspaceAsCloudResponse)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.MarkAsCloud : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public MarkWorkspaceAsLocalResponse MarkAsLocal
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.MarkAsLocal)
					{
						return null;
					}
					return (MarkWorkspaceAsLocalResponse)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.MarkAsLocal : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RemoveContainerResponse RemoveContainer
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.RemoveContainer)
					{
						return null;
					}
					return (RemoveContainerResponse)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.RemoveContainer : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ImportUnmanagedMediaResponse ImportUnmanagedMedia
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.ImportUnmanagedMedia)
					{
						return null;
					}
					return (ImportUnmanagedMediaResponse)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.ImportUnmanagedMedia : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ResponseOneofCase ResponseCase => responseCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Response()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Response(Response other)
				: this()
			{
				switch (other.ResponseCase)
				{
				case ResponseOneofCase.Change:
					Change = other.Change.Clone();
					break;
				case ResponseOneofCase.Get:
					Get = other.Get.Clone();
					break;
				case ResponseOneofCase.Add:
					Add = other.Add.Clone();
					break;
				case ResponseOneofCase.Duplicate:
					Duplicate = other.Duplicate.Clone();
					break;
				case ResponseOneofCase.Apply:
					Apply = other.Apply.Clone();
					break;
				case ResponseOneofCase.Remove:
					Remove = other.Remove.Clone();
					break;
				case ResponseOneofCase.Trigger:
					Trigger = other.Trigger.Clone();
					break;
				case ResponseOneofCase.Pong:
					Pong = other.Pong.Clone();
					break;
				case ResponseOneofCase.Update:
					Update = other.Update.Clone();
					break;
				case ResponseOneofCase.PauseSync:
					PauseSync = other.PauseSync.Clone();
					break;
				case ResponseOneofCase.ResumeSync:
					ResumeSync = other.ResumeSync.Clone();
					break;
				case ResponseOneofCase.UpdatePrefs:
					UpdatePrefs = other.UpdatePrefs.Clone();
					break;
				case ResponseOneofCase.UpdateSmartPlaylists:
					UpdateSmartPlaylists = other.UpdateSmartPlaylists.Clone();
					break;
				case ResponseOneofCase.AddProContentReference:
					AddProContentReference = other.AddProContentReference.Clone();
					break;
				case ResponseOneofCase.MarkAsCloud:
					MarkAsCloud = other.MarkAsCloud.Clone();
					break;
				case ResponseOneofCase.MarkAsLocal:
					MarkAsLocal = other.MarkAsLocal.Clone();
					break;
				case ResponseOneofCase.RemoveContainer:
					RemoveContainer = other.RemoveContainer.Clone();
					break;
				case ResponseOneofCase.ImportUnmanagedMedia:
					ImportUnmanagedMedia = other.ImportUnmanagedMedia.Clone();
					break;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Response Clone()
			{
				return new Response(this);
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
				return Equals(other as Response);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Response other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Change, other.Change))
				{
					return false;
				}
				if (!object.Equals(Get, other.Get))
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
				if (!object.Equals(Pong, other.Pong))
				{
					return false;
				}
				if (!object.Equals(Update, other.Update))
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
				if (responseCase_ == ResponseOneofCase.Change)
				{
					num ^= Change.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.Get)
				{
					num ^= Get.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.Add)
				{
					num ^= Add.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.Duplicate)
				{
					num ^= Duplicate.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.Apply)
				{
					num ^= Apply.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.Remove)
				{
					num ^= Remove.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.Trigger)
				{
					num ^= Trigger.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.Pong)
				{
					num ^= Pong.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.Update)
				{
					num ^= Update.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.PauseSync)
				{
					num ^= PauseSync.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.ResumeSync)
				{
					num ^= ResumeSync.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.UpdatePrefs)
				{
					num ^= UpdatePrefs.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.UpdateSmartPlaylists)
				{
					num ^= UpdateSmartPlaylists.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.AddProContentReference)
				{
					num ^= AddProContentReference.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.MarkAsCloud)
				{
					num ^= MarkAsCloud.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.MarkAsLocal)
				{
					num ^= MarkAsLocal.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.RemoveContainer)
				{
					num ^= RemoveContainer.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.ImportUnmanagedMedia)
				{
					num ^= ImportUnmanagedMedia.GetHashCode();
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
				if (responseCase_ == ResponseOneofCase.Change)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Change);
				}
				if (responseCase_ == ResponseOneofCase.Get)
				{
					output.WriteRawTag(18);
					output.WriteMessage(Get);
				}
				if (responseCase_ == ResponseOneofCase.Add)
				{
					output.WriteRawTag(26);
					output.WriteMessage(Add);
				}
				if (responseCase_ == ResponseOneofCase.Duplicate)
				{
					output.WriteRawTag(34);
					output.WriteMessage(Duplicate);
				}
				if (responseCase_ == ResponseOneofCase.Apply)
				{
					output.WriteRawTag(42);
					output.WriteMessage(Apply);
				}
				if (responseCase_ == ResponseOneofCase.Remove)
				{
					output.WriteRawTag(50);
					output.WriteMessage(Remove);
				}
				if (responseCase_ == ResponseOneofCase.Trigger)
				{
					output.WriteRawTag(58);
					output.WriteMessage(Trigger);
				}
				if (responseCase_ == ResponseOneofCase.Pong)
				{
					output.WriteRawTag(66);
					output.WriteMessage(Pong);
				}
				if (responseCase_ == ResponseOneofCase.Update)
				{
					output.WriteRawTag(74);
					output.WriteMessage(Update);
				}
				if (responseCase_ == ResponseOneofCase.PauseSync)
				{
					output.WriteRawTag(82);
					output.WriteMessage(PauseSync);
				}
				if (responseCase_ == ResponseOneofCase.ResumeSync)
				{
					output.WriteRawTag(90);
					output.WriteMessage(ResumeSync);
				}
				if (responseCase_ == ResponseOneofCase.UpdatePrefs)
				{
					output.WriteRawTag(98);
					output.WriteMessage(UpdatePrefs);
				}
				if (responseCase_ == ResponseOneofCase.UpdateSmartPlaylists)
				{
					output.WriteRawTag(106);
					output.WriteMessage(UpdateSmartPlaylists);
				}
				if (responseCase_ == ResponseOneofCase.AddProContentReference)
				{
					output.WriteRawTag(114);
					output.WriteMessage(AddProContentReference);
				}
				if (responseCase_ == ResponseOneofCase.MarkAsCloud)
				{
					output.WriteRawTag(122);
					output.WriteMessage(MarkAsCloud);
				}
				if (responseCase_ == ResponseOneofCase.MarkAsLocal)
				{
					output.WriteRawTag(130, 1);
					output.WriteMessage(MarkAsLocal);
				}
				if (responseCase_ == ResponseOneofCase.RemoveContainer)
				{
					output.WriteRawTag(138, 1);
					output.WriteMessage(RemoveContainer);
				}
				if (responseCase_ == ResponseOneofCase.ImportUnmanagedMedia)
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
				if (responseCase_ == ResponseOneofCase.Change)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Change);
				}
				if (responseCase_ == ResponseOneofCase.Get)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Get);
				}
				if (responseCase_ == ResponseOneofCase.Add)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Add);
				}
				if (responseCase_ == ResponseOneofCase.Duplicate)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Duplicate);
				}
				if (responseCase_ == ResponseOneofCase.Apply)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Apply);
				}
				if (responseCase_ == ResponseOneofCase.Remove)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Remove);
				}
				if (responseCase_ == ResponseOneofCase.Trigger)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Trigger);
				}
				if (responseCase_ == ResponseOneofCase.Pong)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Pong);
				}
				if (responseCase_ == ResponseOneofCase.Update)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Update);
				}
				if (responseCase_ == ResponseOneofCase.PauseSync)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(PauseSync);
				}
				if (responseCase_ == ResponseOneofCase.ResumeSync)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(ResumeSync);
				}
				if (responseCase_ == ResponseOneofCase.UpdatePrefs)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(UpdatePrefs);
				}
				if (responseCase_ == ResponseOneofCase.UpdateSmartPlaylists)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(UpdateSmartPlaylists);
				}
				if (responseCase_ == ResponseOneofCase.AddProContentReference)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(AddProContentReference);
				}
				if (responseCase_ == ResponseOneofCase.MarkAsCloud)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(MarkAsCloud);
				}
				if (responseCase_ == ResponseOneofCase.MarkAsLocal)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(MarkAsLocal);
				}
				if (responseCase_ == ResponseOneofCase.RemoveContainer)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(RemoveContainer);
				}
				if (responseCase_ == ResponseOneofCase.ImportUnmanagedMedia)
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
			public void MergeFrom(Response other)
			{
				if (other == null)
				{
					return;
				}
				switch (other.ResponseCase)
				{
				case ResponseOneofCase.Change:
					if (Change == null)
					{
						Change = new ChangeShowDirectoryResponse();
					}
					Change.MergeFrom(other.Change);
					break;
				case ResponseOneofCase.Get:
					if (Get == null)
					{
						Get = new GetMediaReferenceResponse();
					}
					Get.MergeFrom(other.Get);
					break;
				case ResponseOneofCase.Add:
					if (Add == null)
					{
						Add = new AddMediaReferenceResponse();
					}
					Add.MergeFrom(other.Add);
					break;
				case ResponseOneofCase.Duplicate:
					if (Duplicate == null)
					{
						Duplicate = new DuplicateMediaReferenceResponse();
					}
					Duplicate.MergeFrom(other.Duplicate);
					break;
				case ResponseOneofCase.Apply:
					if (Apply == null)
					{
						Apply = new ApplyTransformationResponse();
					}
					Apply.MergeFrom(other.Apply);
					break;
				case ResponseOneofCase.Remove:
					if (Remove == null)
					{
						Remove = new RemoveMediaReferenceResponse();
					}
					Remove.MergeFrom(other.Remove);
					break;
				case ResponseOneofCase.Trigger:
					if (Trigger == null)
					{
						Trigger = new TriggerMediaReferenceResponse();
					}
					Trigger.MergeFrom(other.Trigger);
					break;
				case ResponseOneofCase.Pong:
					if (Pong == null)
					{
						Pong = new Pong();
					}
					Pong.MergeFrom(other.Pong);
					break;
				case ResponseOneofCase.Update:
					if (Update == null)
					{
						Update = new UpdateWorkspacesResponse();
					}
					Update.MergeFrom(other.Update);
					break;
				case ResponseOneofCase.PauseSync:
					if (PauseSync == null)
					{
						PauseSync = new PauseSyncResponse();
					}
					PauseSync.MergeFrom(other.PauseSync);
					break;
				case ResponseOneofCase.ResumeSync:
					if (ResumeSync == null)
					{
						ResumeSync = new ResumeSyncResponse();
					}
					ResumeSync.MergeFrom(other.ResumeSync);
					break;
				case ResponseOneofCase.UpdatePrefs:
					if (UpdatePrefs == null)
					{
						UpdatePrefs = new UpdatePrefsResponse();
					}
					UpdatePrefs.MergeFrom(other.UpdatePrefs);
					break;
				case ResponseOneofCase.UpdateSmartPlaylists:
					if (UpdateSmartPlaylists == null)
					{
						UpdateSmartPlaylists = new UpdateSmartPlaylistsResponse();
					}
					UpdateSmartPlaylists.MergeFrom(other.UpdateSmartPlaylists);
					break;
				case ResponseOneofCase.AddProContentReference:
					if (AddProContentReference == null)
					{
						AddProContentReference = new AddProContentReferenceResponse();
					}
					AddProContentReference.MergeFrom(other.AddProContentReference);
					break;
				case ResponseOneofCase.MarkAsCloud:
					if (MarkAsCloud == null)
					{
						MarkAsCloud = new MarkWorkspaceAsCloudResponse();
					}
					MarkAsCloud.MergeFrom(other.MarkAsCloud);
					break;
				case ResponseOneofCase.MarkAsLocal:
					if (MarkAsLocal == null)
					{
						MarkAsLocal = new MarkWorkspaceAsLocalResponse();
					}
					MarkAsLocal.MergeFrom(other.MarkAsLocal);
					break;
				case ResponseOneofCase.RemoveContainer:
					if (RemoveContainer == null)
					{
						RemoveContainer = new RemoveContainerResponse();
					}
					RemoveContainer.MergeFrom(other.RemoveContainer);
					break;
				case ResponseOneofCase.ImportUnmanagedMedia:
					if (ImportUnmanagedMedia == null)
					{
						ImportUnmanagedMedia = new ImportUnmanagedMediaResponse();
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
						ChangeShowDirectoryResponse changeShowDirectoryResponse = new ChangeShowDirectoryResponse();
						if (responseCase_ == ResponseOneofCase.Change)
						{
							changeShowDirectoryResponse.MergeFrom(Change);
						}
						input.ReadMessage(changeShowDirectoryResponse);
						Change = changeShowDirectoryResponse;
						break;
					}
					case 18u:
					{
						GetMediaReferenceResponse getMediaReferenceResponse = new GetMediaReferenceResponse();
						if (responseCase_ == ResponseOneofCase.Get)
						{
							getMediaReferenceResponse.MergeFrom(Get);
						}
						input.ReadMessage(getMediaReferenceResponse);
						Get = getMediaReferenceResponse;
						break;
					}
					case 26u:
					{
						AddMediaReferenceResponse addMediaReferenceResponse = new AddMediaReferenceResponse();
						if (responseCase_ == ResponseOneofCase.Add)
						{
							addMediaReferenceResponse.MergeFrom(Add);
						}
						input.ReadMessage(addMediaReferenceResponse);
						Add = addMediaReferenceResponse;
						break;
					}
					case 34u:
					{
						DuplicateMediaReferenceResponse duplicateMediaReferenceResponse = new DuplicateMediaReferenceResponse();
						if (responseCase_ == ResponseOneofCase.Duplicate)
						{
							duplicateMediaReferenceResponse.MergeFrom(Duplicate);
						}
						input.ReadMessage(duplicateMediaReferenceResponse);
						Duplicate = duplicateMediaReferenceResponse;
						break;
					}
					case 42u:
					{
						ApplyTransformationResponse applyTransformationResponse = new ApplyTransformationResponse();
						if (responseCase_ == ResponseOneofCase.Apply)
						{
							applyTransformationResponse.MergeFrom(Apply);
						}
						input.ReadMessage(applyTransformationResponse);
						Apply = applyTransformationResponse;
						break;
					}
					case 50u:
					{
						RemoveMediaReferenceResponse removeMediaReferenceResponse = new RemoveMediaReferenceResponse();
						if (responseCase_ == ResponseOneofCase.Remove)
						{
							removeMediaReferenceResponse.MergeFrom(Remove);
						}
						input.ReadMessage(removeMediaReferenceResponse);
						Remove = removeMediaReferenceResponse;
						break;
					}
					case 58u:
					{
						TriggerMediaReferenceResponse triggerMediaReferenceResponse = new TriggerMediaReferenceResponse();
						if (responseCase_ == ResponseOneofCase.Trigger)
						{
							triggerMediaReferenceResponse.MergeFrom(Trigger);
						}
						input.ReadMessage(triggerMediaReferenceResponse);
						Trigger = triggerMediaReferenceResponse;
						break;
					}
					case 66u:
					{
						Pong pong = new Pong();
						if (responseCase_ == ResponseOneofCase.Pong)
						{
							pong.MergeFrom(Pong);
						}
						input.ReadMessage(pong);
						Pong = pong;
						break;
					}
					case 74u:
					{
						UpdateWorkspacesResponse updateWorkspacesResponse = new UpdateWorkspacesResponse();
						if (responseCase_ == ResponseOneofCase.Update)
						{
							updateWorkspacesResponse.MergeFrom(Update);
						}
						input.ReadMessage(updateWorkspacesResponse);
						Update = updateWorkspacesResponse;
						break;
					}
					case 82u:
					{
						PauseSyncResponse pauseSyncResponse = new PauseSyncResponse();
						if (responseCase_ == ResponseOneofCase.PauseSync)
						{
							pauseSyncResponse.MergeFrom(PauseSync);
						}
						input.ReadMessage(pauseSyncResponse);
						PauseSync = pauseSyncResponse;
						break;
					}
					case 90u:
					{
						ResumeSyncResponse resumeSyncResponse = new ResumeSyncResponse();
						if (responseCase_ == ResponseOneofCase.ResumeSync)
						{
							resumeSyncResponse.MergeFrom(ResumeSync);
						}
						input.ReadMessage(resumeSyncResponse);
						ResumeSync = resumeSyncResponse;
						break;
					}
					case 98u:
					{
						UpdatePrefsResponse updatePrefsResponse = new UpdatePrefsResponse();
						if (responseCase_ == ResponseOneofCase.UpdatePrefs)
						{
							updatePrefsResponse.MergeFrom(UpdatePrefs);
						}
						input.ReadMessage(updatePrefsResponse);
						UpdatePrefs = updatePrefsResponse;
						break;
					}
					case 106u:
					{
						UpdateSmartPlaylistsResponse updateSmartPlaylistsResponse = new UpdateSmartPlaylistsResponse();
						if (responseCase_ == ResponseOneofCase.UpdateSmartPlaylists)
						{
							updateSmartPlaylistsResponse.MergeFrom(UpdateSmartPlaylists);
						}
						input.ReadMessage(updateSmartPlaylistsResponse);
						UpdateSmartPlaylists = updateSmartPlaylistsResponse;
						break;
					}
					case 114u:
					{
						AddProContentReferenceResponse addProContentReferenceResponse = new AddProContentReferenceResponse();
						if (responseCase_ == ResponseOneofCase.AddProContentReference)
						{
							addProContentReferenceResponse.MergeFrom(AddProContentReference);
						}
						input.ReadMessage(addProContentReferenceResponse);
						AddProContentReference = addProContentReferenceResponse;
						break;
					}
					case 122u:
					{
						MarkWorkspaceAsCloudResponse markWorkspaceAsCloudResponse = new MarkWorkspaceAsCloudResponse();
						if (responseCase_ == ResponseOneofCase.MarkAsCloud)
						{
							markWorkspaceAsCloudResponse.MergeFrom(MarkAsCloud);
						}
						input.ReadMessage(markWorkspaceAsCloudResponse);
						MarkAsCloud = markWorkspaceAsCloudResponse;
						break;
					}
					case 130u:
					{
						MarkWorkspaceAsLocalResponse markWorkspaceAsLocalResponse = new MarkWorkspaceAsLocalResponse();
						if (responseCase_ == ResponseOneofCase.MarkAsLocal)
						{
							markWorkspaceAsLocalResponse.MergeFrom(MarkAsLocal);
						}
						input.ReadMessage(markWorkspaceAsLocalResponse);
						MarkAsLocal = markWorkspaceAsLocalResponse;
						break;
					}
					case 138u:
					{
						RemoveContainerResponse removeContainerResponse = new RemoveContainerResponse();
						if (responseCase_ == ResponseOneofCase.RemoveContainer)
						{
							removeContainerResponse.MergeFrom(RemoveContainer);
						}
						input.ReadMessage(removeContainerResponse);
						RemoveContainer = removeContainerResponse;
						break;
					}
					case 146u:
					{
						ImportUnmanagedMediaResponse importUnmanagedMediaResponse = new ImportUnmanagedMediaResponse();
						if (responseCase_ == ResponseOneofCase.ImportUnmanagedMedia)
						{
							importUnmanagedMediaResponse.MergeFrom(ImportUnmanagedMedia);
						}
						input.ReadMessage(importUnmanagedMediaResponse);
						ImportUnmanagedMedia = importUnmanagedMediaResponse;
						break;
					}
					}
				}
			}
		}
	}

	private static readonly MessageParser<ResponseEnvelope> _parser = new MessageParser<ResponseEnvelope>(() => new ResponseEnvelope());

	private UnknownFieldSet _unknownFields;

	public const int OkFieldNumber = 1;

	public const int ErrorFieldNumber = 2;

	private object result_;

	private ResultOneofCase resultCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ResponseEnvelope> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V2MediaReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Response Ok
	{
		get
		{
			if (resultCase_ != ResultOneofCase.Ok)
			{
				return null;
			}
			return (Types.Response)result_;
		}
		set
		{
			result_ = value;
			resultCase_ = ((value != null) ? ResultOneofCase.Ok : ResultOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RequestError Error
	{
		get
		{
			if (resultCase_ != ResultOneofCase.Error)
			{
				return null;
			}
			return (RequestError)result_;
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
	public ResponseEnvelope()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResponseEnvelope(ResponseEnvelope other)
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
	public ResponseEnvelope Clone()
	{
		return new ResponseEnvelope(this);
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
		return Equals(other as ResponseEnvelope);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ResponseEnvelope other)
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
	public void MergeFrom(ResponseEnvelope other)
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
				Ok = new Types.Response();
			}
			Ok.MergeFrom(other.Ok);
			break;
		case ResultOneofCase.Error:
			if (Error == null)
			{
				Error = new RequestError();
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
				Types.Response response = new Types.Response();
				if (resultCase_ == ResultOneofCase.Ok)
				{
					response.MergeFrom(Ok);
				}
				input.ReadMessage(response);
				Ok = response;
				break;
			}
			case 18u:
			{
				RequestError requestError = new RequestError();
				if (resultCase_ == ResultOneofCase.Error)
				{
					requestError.MergeFrom(Error);
				}
				input.ReadMessage(requestError);
				Error = requestError;
				break;
			}
			}
		}
	}
}
