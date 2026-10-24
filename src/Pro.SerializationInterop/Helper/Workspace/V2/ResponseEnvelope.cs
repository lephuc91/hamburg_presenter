using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

namespace Helper.Workspace.V2;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ResponseEnvelope : IMessage<ResponseEnvelope>, IMessage, IEquatable<ResponseEnvelope>, IDeepCloneable<ResponseEnvelope>
{
	public enum ResultOneofCase
	{
		None = 0,
		Ok = 2,
		Error = 3
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
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
			public static MessageDescriptor Descriptor => ResponseEnvelope.Descriptor.NestedTypes[0];

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
		public sealed class Response : IMessage<Response>, IMessage, IEquatable<Response>, IDeepCloneable<Response>
		{
			public enum ResponseOneofCase
			{
				None = 0,
				Start = 1,
				ChangeShowDirectory = 2,
				Add = 3,
				Duplicate = 4,
				Apply = 5,
				Remove = 6,
				Trigger = 7,
				Pong = 8,
				UpdateWorkspaces = 9,
				PauseSync = 11,
				ResumeSync = 12,
				UpdatePrefs = 13,
				UpdateSmartPlaylists = 14,
				AddProContentReference = 15,
				MarkAsCloud = 16,
				MarkAsLocal = 17,
				RemoveContainer = 18,
				UpdateWebToken = 19,
				ImportUnmanagedMedia = 20
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class StartResponse : IMessage<StartResponse>, IMessage, IEquatable<StartResponse>, IDeepCloneable<StartResponse>
				{
					private static readonly MessageParser<StartResponse> _parser = new MessageParser<StartResponse>(() => new StartResponse());

					private UnknownFieldSet _unknownFields;

					public const int MediaReferencesFieldNumber = 1;

					private static readonly FieldCodec<MediaReference> _repeated_mediaReferences_codec = FieldCodec.ForMessage(10u, MediaReference.Parser);

					private readonly RepeatedField<MediaReference> mediaReferences_ = new RepeatedField<MediaReference>();

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<StartResponse> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Response.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RepeatedField<MediaReference> MediaReferences => mediaReferences_;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public StartResponse()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public StartResponse(StartResponse other)
						: this()
					{
						mediaReferences_ = other.mediaReferences_.Clone();
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public StartResponse Clone()
					{
						return new StartResponse(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as StartResponse);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(StartResponse other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (!mediaReferences_.Equals(other.mediaReferences_))
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
						num ^= mediaReferences_.GetHashCode();
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
						mediaReferences_.WriteTo(output, _repeated_mediaReferences_codec);
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
						num += mediaReferences_.CalculateSize(_repeated_mediaReferences_codec);
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(StartResponse other)
					{
						if (other != null)
						{
							mediaReferences_.Add(other.mediaReferences_);
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
								mediaReferences_.AddEntriesFrom(input, _repeated_mediaReferences_codec);
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class ChangeShowDirectoryResponse : IMessage<ChangeShowDirectoryResponse>, IMessage, IEquatable<ChangeShowDirectoryResponse>, IDeepCloneable<ChangeShowDirectoryResponse>
				{
					private static readonly MessageParser<ChangeShowDirectoryResponse> _parser = new MessageParser<ChangeShowDirectoryResponse>(() => new ChangeShowDirectoryResponse());

					private UnknownFieldSet _unknownFields;

					public const int MediaReferencesFieldNumber = 1;

					private static readonly FieldCodec<MediaReference> _repeated_mediaReferences_codec = FieldCodec.ForMessage(10u, MediaReference.Parser);

					private readonly RepeatedField<MediaReference> mediaReferences_ = new RepeatedField<MediaReference>();

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<ChangeShowDirectoryResponse> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Response.Descriptor.NestedTypes[1];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public RepeatedField<MediaReference> MediaReferences => mediaReferences_;

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
						mediaReferences_ = other.mediaReferences_.Clone();
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
						if (!mediaReferences_.Equals(other.mediaReferences_))
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
						num ^= mediaReferences_.GetHashCode();
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
						mediaReferences_.WriteTo(output, _repeated_mediaReferences_codec);
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
						num += mediaReferences_.CalculateSize(_repeated_mediaReferences_codec);
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
							mediaReferences_.Add(other.mediaReferences_);
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
								mediaReferences_.AddEntriesFrom(input, _repeated_mediaReferences_codec);
							}
						}
					}
				}

				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class UpdateWebTokenResponse : IMessage<UpdateWebTokenResponse>, IMessage, IEquatable<UpdateWebTokenResponse>, IDeepCloneable<UpdateWebTokenResponse>
				{
					private static readonly MessageParser<UpdateWebTokenResponse> _parser = new MessageParser<UpdateWebTokenResponse>(() => new UpdateWebTokenResponse());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<UpdateWebTokenResponse> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Response.Descriptor.NestedTypes[2];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public UpdateWebTokenResponse()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public UpdateWebTokenResponse(UpdateWebTokenResponse other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public UpdateWebTokenResponse Clone()
					{
						return new UpdateWebTokenResponse(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as UpdateWebTokenResponse);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(UpdateWebTokenResponse other)
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
					public void MergeFrom(UpdateWebTokenResponse other)
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

			private static readonly MessageParser<Response> _parser = new MessageParser<Response>(() => new Response());

			private UnknownFieldSet _unknownFields;

			public const int StartFieldNumber = 1;

			public const int ChangeShowDirectoryFieldNumber = 2;

			public const int AddFieldNumber = 3;

			public const int DuplicateFieldNumber = 4;

			public const int ApplyFieldNumber = 5;

			public const int RemoveFieldNumber = 6;

			public const int TriggerFieldNumber = 7;

			public const int PongFieldNumber = 8;

			public const int UpdateWorkspacesFieldNumber = 9;

			public const int PauseSyncFieldNumber = 11;

			public const int ResumeSyncFieldNumber = 12;

			public const int UpdatePrefsFieldNumber = 13;

			public const int UpdateSmartPlaylistsFieldNumber = 14;

			public const int AddProContentReferenceFieldNumber = 15;

			public const int MarkAsCloudFieldNumber = 16;

			public const int MarkAsLocalFieldNumber = 17;

			public const int RemoveContainerFieldNumber = 18;

			public const int UpdateWebTokenFieldNumber = 19;

			public const int ImportUnmanagedMediaFieldNumber = 20;

			private object response_;

			private ResponseOneofCase responseCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Response> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ResponseEnvelope.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.StartResponse Start
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.Start)
					{
						return null;
					}
					return (Types.StartResponse)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.Start : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.ChangeShowDirectoryResponse ChangeShowDirectory
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.ChangeShowDirectory)
					{
						return null;
					}
					return (Types.ChangeShowDirectoryResponse)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.ChangeShowDirectory : ResponseOneofCase.None);
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
			public UpdateWorkspacesResponse UpdateWorkspaces
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.UpdateWorkspaces)
					{
						return null;
					}
					return (UpdateWorkspacesResponse)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.UpdateWorkspaces : ResponseOneofCase.None);
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
			public Types.UpdateWebTokenResponse UpdateWebToken
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.UpdateWebToken)
					{
						return null;
					}
					return (Types.UpdateWebTokenResponse)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.UpdateWebToken : ResponseOneofCase.None);
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
				case ResponseOneofCase.Start:
					Start = other.Start.Clone();
					break;
				case ResponseOneofCase.ChangeShowDirectory:
					ChangeShowDirectory = other.ChangeShowDirectory.Clone();
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
				case ResponseOneofCase.UpdateWorkspaces:
					UpdateWorkspaces = other.UpdateWorkspaces.Clone();
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
				case ResponseOneofCase.UpdateWebToken:
					UpdateWebToken = other.UpdateWebToken.Clone();
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
				if (!object.Equals(Pong, other.Pong))
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
				if (!object.Equals(UpdateWebToken, other.UpdateWebToken))
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
				if (responseCase_ == ResponseOneofCase.Start)
				{
					num ^= Start.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.ChangeShowDirectory)
				{
					num ^= ChangeShowDirectory.GetHashCode();
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
				if (responseCase_ == ResponseOneofCase.UpdateWorkspaces)
				{
					num ^= UpdateWorkspaces.GetHashCode();
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
				if (responseCase_ == ResponseOneofCase.UpdateWebToken)
				{
					num ^= UpdateWebToken.GetHashCode();
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
				if (responseCase_ == ResponseOneofCase.Start)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Start);
				}
				if (responseCase_ == ResponseOneofCase.ChangeShowDirectory)
				{
					output.WriteRawTag(18);
					output.WriteMessage(ChangeShowDirectory);
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
				if (responseCase_ == ResponseOneofCase.UpdateWorkspaces)
				{
					output.WriteRawTag(74);
					output.WriteMessage(UpdateWorkspaces);
				}
				if (responseCase_ == ResponseOneofCase.PauseSync)
				{
					output.WriteRawTag(90);
					output.WriteMessage(PauseSync);
				}
				if (responseCase_ == ResponseOneofCase.ResumeSync)
				{
					output.WriteRawTag(98);
					output.WriteMessage(ResumeSync);
				}
				if (responseCase_ == ResponseOneofCase.UpdatePrefs)
				{
					output.WriteRawTag(106);
					output.WriteMessage(UpdatePrefs);
				}
				if (responseCase_ == ResponseOneofCase.UpdateSmartPlaylists)
				{
					output.WriteRawTag(114);
					output.WriteMessage(UpdateSmartPlaylists);
				}
				if (responseCase_ == ResponseOneofCase.AddProContentReference)
				{
					output.WriteRawTag(122);
					output.WriteMessage(AddProContentReference);
				}
				if (responseCase_ == ResponseOneofCase.MarkAsCloud)
				{
					output.WriteRawTag(130, 1);
					output.WriteMessage(MarkAsCloud);
				}
				if (responseCase_ == ResponseOneofCase.MarkAsLocal)
				{
					output.WriteRawTag(138, 1);
					output.WriteMessage(MarkAsLocal);
				}
				if (responseCase_ == ResponseOneofCase.RemoveContainer)
				{
					output.WriteRawTag(146, 1);
					output.WriteMessage(RemoveContainer);
				}
				if (responseCase_ == ResponseOneofCase.UpdateWebToken)
				{
					output.WriteRawTag(154, 1);
					output.WriteMessage(UpdateWebToken);
				}
				if (responseCase_ == ResponseOneofCase.ImportUnmanagedMedia)
				{
					output.WriteRawTag(162, 1);
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
				if (responseCase_ == ResponseOneofCase.Start)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Start);
				}
				if (responseCase_ == ResponseOneofCase.ChangeShowDirectory)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(ChangeShowDirectory);
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
				if (responseCase_ == ResponseOneofCase.UpdateWorkspaces)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(UpdateWorkspaces);
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
					num += 2 + CodedOutputStream.ComputeMessageSize(MarkAsCloud);
				}
				if (responseCase_ == ResponseOneofCase.MarkAsLocal)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(MarkAsLocal);
				}
				if (responseCase_ == ResponseOneofCase.RemoveContainer)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(RemoveContainer);
				}
				if (responseCase_ == ResponseOneofCase.UpdateWebToken)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(UpdateWebToken);
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
				case ResponseOneofCase.Start:
					if (Start == null)
					{
						Start = new Types.StartResponse();
					}
					Start.MergeFrom(other.Start);
					break;
				case ResponseOneofCase.ChangeShowDirectory:
					if (ChangeShowDirectory == null)
					{
						ChangeShowDirectory = new Types.ChangeShowDirectoryResponse();
					}
					ChangeShowDirectory.MergeFrom(other.ChangeShowDirectory);
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
				case ResponseOneofCase.UpdateWorkspaces:
					if (UpdateWorkspaces == null)
					{
						UpdateWorkspaces = new UpdateWorkspacesResponse();
					}
					UpdateWorkspaces.MergeFrom(other.UpdateWorkspaces);
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
				case ResponseOneofCase.UpdateWebToken:
					if (UpdateWebToken == null)
					{
						UpdateWebToken = new Types.UpdateWebTokenResponse();
					}
					UpdateWebToken.MergeFrom(other.UpdateWebToken);
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
						Types.StartResponse startResponse = new Types.StartResponse();
						if (responseCase_ == ResponseOneofCase.Start)
						{
							startResponse.MergeFrom(Start);
						}
						input.ReadMessage(startResponse);
						Start = startResponse;
						break;
					}
					case 18u:
					{
						Types.ChangeShowDirectoryResponse changeShowDirectoryResponse = new Types.ChangeShowDirectoryResponse();
						if (responseCase_ == ResponseOneofCase.ChangeShowDirectory)
						{
							changeShowDirectoryResponse.MergeFrom(ChangeShowDirectory);
						}
						input.ReadMessage(changeShowDirectoryResponse);
						ChangeShowDirectory = changeShowDirectoryResponse;
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
						if (responseCase_ == ResponseOneofCase.UpdateWorkspaces)
						{
							updateWorkspacesResponse.MergeFrom(UpdateWorkspaces);
						}
						input.ReadMessage(updateWorkspacesResponse);
						UpdateWorkspaces = updateWorkspacesResponse;
						break;
					}
					case 90u:
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
					case 98u:
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
					case 106u:
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
					case 114u:
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
					case 122u:
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
					case 130u:
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
					case 138u:
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
					case 146u:
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
					case 154u:
					{
						Types.UpdateWebTokenResponse updateWebTokenResponse = new Types.UpdateWebTokenResponse();
						if (responseCase_ == ResponseOneofCase.UpdateWebToken)
						{
							updateWebTokenResponse.MergeFrom(UpdateWebToken);
						}
						input.ReadMessage(updateWebTokenResponse);
						UpdateWebToken = updateWebTokenResponse;
						break;
					}
					case 162u:
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

	public const int HeaderFieldNumber = 1;

	private Types.Header header_;

	public const int OkFieldNumber = 2;

	public const int ErrorFieldNumber = 3;

	private object result_;

	private ResultOneofCase resultCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ResponseEnvelope> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => V2HelperWorkspaceReflection.Descriptor.MessageTypes[3];

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
		header_ = ((other.header_ != null) ? other.header_.Clone() : null);
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
		if (!object.Equals(Header, other.Header))
		{
			return false;
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
		if (header_ != null)
		{
			num ^= Header.GetHashCode();
		}
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
		if (header_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Header);
		}
		if (resultCase_ == ResultOneofCase.Ok)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Ok);
		}
		if (resultCase_ == ResultOneofCase.Error)
		{
			output.WriteRawTag(26);
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
		if (header_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Header);
		}
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
		if (other.header_ != null)
		{
			if (header_ == null)
			{
				Header = new Types.Header();
			}
			Header.MergeFrom(other.Header);
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
				if (header_ == null)
				{
					Header = new Types.Header();
				}
				input.ReadMessage(Header);
				break;
			case 18u:
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
			case 26u:
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
