using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v1;

namespace Helper.Workspace.V1;

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
				None,
				Start,
				ChangeShowDirectory,
				Add,
				Duplicate,
				Apply,
				Remove,
				Trigger,
				Pong,
				UpdateWorkspaces,
				Pause,
				Resume,
				GetState
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
				public sealed class GetStateResponse : IMessage<GetStateResponse>, IMessage, IEquatable<GetStateResponse>, IDeepCloneable<GetStateResponse>
				{
					private static readonly MessageParser<GetStateResponse> _parser = new MessageParser<GetStateResponse>(() => new GetStateResponse());

					private UnknownFieldSet _unknownFields;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<GetStateResponse> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => Response.Descriptor.NestedTypes[2];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GetStateResponse()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GetStateResponse(GetStateResponse other)
						: this()
					{
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public GetStateResponse Clone()
					{
						return new GetStateResponse(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as GetStateResponse);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(GetStateResponse other)
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
					public void MergeFrom(GetStateResponse other)
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

			public const int PauseFieldNumber = 10;

			public const int ResumeFieldNumber = 11;

			public const int GetStateFieldNumber = 12;

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
			public PauseGenerationResponse Pause
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.Pause)
					{
						return null;
					}
					return (PauseGenerationResponse)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.Pause : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ResumeGenerationResponse Resume
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.Resume)
					{
						return null;
					}
					return (ResumeGenerationResponse)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.Resume : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.GetStateResponse GetState
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.GetState)
					{
						return null;
					}
					return (Types.GetStateResponse)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.GetState : ResponseOneofCase.None);
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
				case ResponseOneofCase.Pause:
					Pause = other.Pause.Clone();
					break;
				case ResponseOneofCase.Resume:
					Resume = other.Resume.Clone();
					break;
				case ResponseOneofCase.GetState:
					GetState = other.GetState.Clone();
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
				if (!object.Equals(Pause, other.Pause))
				{
					return false;
				}
				if (!object.Equals(Resume, other.Resume))
				{
					return false;
				}
				if (!object.Equals(GetState, other.GetState))
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
				if (responseCase_ == ResponseOneofCase.Pause)
				{
					num ^= Pause.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.Resume)
				{
					num ^= Resume.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.GetState)
				{
					num ^= GetState.GetHashCode();
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
				if (responseCase_ == ResponseOneofCase.Pause)
				{
					output.WriteRawTag(82);
					output.WriteMessage(Pause);
				}
				if (responseCase_ == ResponseOneofCase.Resume)
				{
					output.WriteRawTag(90);
					output.WriteMessage(Resume);
				}
				if (responseCase_ == ResponseOneofCase.GetState)
				{
					output.WriteRawTag(98);
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
				if (responseCase_ == ResponseOneofCase.Pause)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Pause);
				}
				if (responseCase_ == ResponseOneofCase.Resume)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Resume);
				}
				if (responseCase_ == ResponseOneofCase.GetState)
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
				case ResponseOneofCase.Pause:
					if (Pause == null)
					{
						Pause = new PauseGenerationResponse();
					}
					Pause.MergeFrom(other.Pause);
					break;
				case ResponseOneofCase.Resume:
					if (Resume == null)
					{
						Resume = new ResumeGenerationResponse();
					}
					Resume.MergeFrom(other.Resume);
					break;
				case ResponseOneofCase.GetState:
					if (GetState == null)
					{
						GetState = new Types.GetStateResponse();
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
					case 82u:
					{
						PauseGenerationResponse pauseGenerationResponse = new PauseGenerationResponse();
						if (responseCase_ == ResponseOneofCase.Pause)
						{
							pauseGenerationResponse.MergeFrom(Pause);
						}
						input.ReadMessage(pauseGenerationResponse);
						Pause = pauseGenerationResponse;
						break;
					}
					case 90u:
					{
						ResumeGenerationResponse resumeGenerationResponse = new ResumeGenerationResponse();
						if (responseCase_ == ResponseOneofCase.Resume)
						{
							resumeGenerationResponse.MergeFrom(Resume);
						}
						input.ReadMessage(resumeGenerationResponse);
						Resume = resumeGenerationResponse;
						break;
					}
					case 98u:
					{
						Types.GetStateResponse getStateResponse = new Types.GetStateResponse();
						if (responseCase_ == ResponseOneofCase.GetState)
						{
							getStateResponse.MergeFrom(GetState);
						}
						input.ReadMessage(getStateResponse);
						GetState = getStateResponse;
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
	public static MessageDescriptor Descriptor => V1HelperWorkspaceReflection.Descriptor.MessageTypes[2];

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
