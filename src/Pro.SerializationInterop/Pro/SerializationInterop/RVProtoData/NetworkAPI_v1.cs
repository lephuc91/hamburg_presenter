using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class NetworkAPI_v1 : IMessage<NetworkAPI_v1>, IMessage, IEquatable<NetworkAPI_v1>, IDeepCloneable<NetworkAPI_v1>
{
	public enum CommandOneofCase
	{
		None,
		Action
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Action : IMessage<Action>, IMessage, IEquatable<Action>, IDeepCloneable<Action>
		{
			public enum RequestOneofCase
			{
				None,
				AudioRequest,
				CaptureRequest,
				ClearingRequest,
				GroupsRequest,
				LinkRequest,
				LibraryRequest,
				LooksRequest,
				MacroRequest,
				MasksRequest,
				MediaRequest,
				MessageRequest,
				MiscellaneousRequest,
				PlaylistRequest,
				PrerollRequest,
				PresentationRequest,
				PropRequest,
				StageRequest,
				StatusRequest,
				ThemeRequest,
				TimerRequest,
				TransportRequest,
				TriggerRequest,
				VideoInputsRequest,
				AnnouncementRequest
			}

			public enum ResponseOneofCase
			{
				None = 0,
				AudioResponse = 101,
				CaptureResponse = 102,
				ClearingResponse = 103,
				GroupsResponse = 104,
				LinkResponse = 105,
				LibraryResponse = 106,
				LooksResponse = 107,
				MacroResponse = 108,
				MasksResponse = 109,
				MediaResponse = 110,
				MessageResponse = 111,
				MiscellaneousResponse = 112,
				PlaylistResponse = 113,
				PrerollResponse = 114,
				PresentationResponse = 115,
				PropResponse = 116,
				StageResponse = 117,
				StatusResponse = 118,
				ThemeResponse = 119,
				TimerResponse = 120,
				TransportResponse = 121,
				TriggerResponse = 122,
				VideoInputsResponse = 123,
				AnnouncementResponse = 124,
				ErrorResponse = 200
			}

			public enum StreamingUpdateIdentifierOneofCase
			{
				None = 0,
				UpdateIdentifier = 201
			}

			private static readonly MessageParser<Action> _parser = new MessageParser<Action>(() => new Action());

			private UnknownFieldSet _unknownFields;

			public const int AudioRequestFieldNumber = 1;

			public const int CaptureRequestFieldNumber = 2;

			public const int ClearingRequestFieldNumber = 3;

			public const int GroupsRequestFieldNumber = 4;

			public const int LinkRequestFieldNumber = 5;

			public const int LibraryRequestFieldNumber = 6;

			public const int LooksRequestFieldNumber = 7;

			public const int MacroRequestFieldNumber = 8;

			public const int MasksRequestFieldNumber = 9;

			public const int MediaRequestFieldNumber = 10;

			public const int MessageRequestFieldNumber = 11;

			public const int MiscellaneousRequestFieldNumber = 12;

			public const int PlaylistRequestFieldNumber = 13;

			public const int PrerollRequestFieldNumber = 14;

			public const int PresentationRequestFieldNumber = 15;

			public const int PropRequestFieldNumber = 16;

			public const int StageRequestFieldNumber = 17;

			public const int StatusRequestFieldNumber = 18;

			public const int ThemeRequestFieldNumber = 19;

			public const int TimerRequestFieldNumber = 20;

			public const int TransportRequestFieldNumber = 21;

			public const int TriggerRequestFieldNumber = 22;

			public const int VideoInputsRequestFieldNumber = 23;

			public const int AnnouncementRequestFieldNumber = 24;

			public const int AudioResponseFieldNumber = 101;

			public const int CaptureResponseFieldNumber = 102;

			public const int ClearingResponseFieldNumber = 103;

			public const int GroupsResponseFieldNumber = 104;

			public const int LinkResponseFieldNumber = 105;

			public const int LibraryResponseFieldNumber = 106;

			public const int LooksResponseFieldNumber = 107;

			public const int MacroResponseFieldNumber = 108;

			public const int MasksResponseFieldNumber = 109;

			public const int MediaResponseFieldNumber = 110;

			public const int MessageResponseFieldNumber = 111;

			public const int MiscellaneousResponseFieldNumber = 112;

			public const int PlaylistResponseFieldNumber = 113;

			public const int PrerollResponseFieldNumber = 114;

			public const int PresentationResponseFieldNumber = 115;

			public const int PropResponseFieldNumber = 116;

			public const int StageResponseFieldNumber = 117;

			public const int StatusResponseFieldNumber = 118;

			public const int ThemeResponseFieldNumber = 119;

			public const int TimerResponseFieldNumber = 120;

			public const int TransportResponseFieldNumber = 121;

			public const int TriggerResponseFieldNumber = 122;

			public const int VideoInputsResponseFieldNumber = 123;

			public const int AnnouncementResponseFieldNumber = 124;

			public const int ErrorResponseFieldNumber = 200;

			public const int UpdateIdentifierFieldNumber = 201;

			private object request_;

			private RequestOneofCase requestCase_;

			private object response_;

			private ResponseOneofCase responseCase_;

			private object streamingUpdateIdentifier_;

			private StreamingUpdateIdentifierOneofCase streamingUpdateIdentifierCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Action> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => NetworkAPI_v1.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Audio_Request AudioRequest
			{
				get
				{
					if (requestCase_ != RequestOneofCase.AudioRequest)
					{
						return null;
					}
					return (API_v1_Audio_Request)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.AudioRequest : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Capture_Request CaptureRequest
			{
				get
				{
					if (requestCase_ != RequestOneofCase.CaptureRequest)
					{
						return null;
					}
					return (API_v1_Capture_Request)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.CaptureRequest : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Clear_Request ClearingRequest
			{
				get
				{
					if (requestCase_ != RequestOneofCase.ClearingRequest)
					{
						return null;
					}
					return (API_v1_Clear_Request)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.ClearingRequest : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Groups_Request GroupsRequest
			{
				get
				{
					if (requestCase_ != RequestOneofCase.GroupsRequest)
					{
						return null;
					}
					return (API_v1_Groups_Request)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.GroupsRequest : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Link_Request LinkRequest
			{
				get
				{
					if (requestCase_ != RequestOneofCase.LinkRequest)
					{
						return null;
					}
					return (API_v1_Link_Request)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.LinkRequest : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Library_Request LibraryRequest
			{
				get
				{
					if (requestCase_ != RequestOneofCase.LibraryRequest)
					{
						return null;
					}
					return (API_v1_Library_Request)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.LibraryRequest : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Looks_Request LooksRequest
			{
				get
				{
					if (requestCase_ != RequestOneofCase.LooksRequest)
					{
						return null;
					}
					return (API_v1_Looks_Request)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.LooksRequest : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Macro_Request MacroRequest
			{
				get
				{
					if (requestCase_ != RequestOneofCase.MacroRequest)
					{
						return null;
					}
					return (API_v1_Macro_Request)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.MacroRequest : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Masks_Request MasksRequest
			{
				get
				{
					if (requestCase_ != RequestOneofCase.MasksRequest)
					{
						return null;
					}
					return (API_v1_Masks_Request)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.MasksRequest : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Media_Request MediaRequest
			{
				get
				{
					if (requestCase_ != RequestOneofCase.MediaRequest)
					{
						return null;
					}
					return (API_v1_Media_Request)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.MediaRequest : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Message_Request MessageRequest
			{
				get
				{
					if (requestCase_ != RequestOneofCase.MessageRequest)
					{
						return null;
					}
					return (API_v1_Message_Request)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.MessageRequest : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Miscellaneous_Request MiscellaneousRequest
			{
				get
				{
					if (requestCase_ != RequestOneofCase.MiscellaneousRequest)
					{
						return null;
					}
					return (API_v1_Miscellaneous_Request)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.MiscellaneousRequest : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Playlist_Request PlaylistRequest
			{
				get
				{
					if (requestCase_ != RequestOneofCase.PlaylistRequest)
					{
						return null;
					}
					return (API_v1_Playlist_Request)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.PlaylistRequest : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Preroll_Request PrerollRequest
			{
				get
				{
					if (requestCase_ != RequestOneofCase.PrerollRequest)
					{
						return null;
					}
					return (API_v1_Preroll_Request)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.PrerollRequest : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Presentation_Request PresentationRequest
			{
				get
				{
					if (requestCase_ != RequestOneofCase.PresentationRequest)
					{
						return null;
					}
					return (API_v1_Presentation_Request)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.PresentationRequest : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Prop_Request PropRequest
			{
				get
				{
					if (requestCase_ != RequestOneofCase.PropRequest)
					{
						return null;
					}
					return (API_v1_Prop_Request)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.PropRequest : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Stage_Request StageRequest
			{
				get
				{
					if (requestCase_ != RequestOneofCase.StageRequest)
					{
						return null;
					}
					return (API_v1_Stage_Request)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.StageRequest : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Status_Request StatusRequest
			{
				get
				{
					if (requestCase_ != RequestOneofCase.StatusRequest)
					{
						return null;
					}
					return (API_v1_Status_Request)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.StatusRequest : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Theme_Request ThemeRequest
			{
				get
				{
					if (requestCase_ != RequestOneofCase.ThemeRequest)
					{
						return null;
					}
					return (API_v1_Theme_Request)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.ThemeRequest : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Timer_Request TimerRequest
			{
				get
				{
					if (requestCase_ != RequestOneofCase.TimerRequest)
					{
						return null;
					}
					return (API_v1_Timer_Request)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.TimerRequest : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Transport_Request TransportRequest
			{
				get
				{
					if (requestCase_ != RequestOneofCase.TransportRequest)
					{
						return null;
					}
					return (API_v1_Transport_Request)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.TransportRequest : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Trigger_Request TriggerRequest
			{
				get
				{
					if (requestCase_ != RequestOneofCase.TriggerRequest)
					{
						return null;
					}
					return (API_v1_Trigger_Request)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.TriggerRequest : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Video_Inputs_Request VideoInputsRequest
			{
				get
				{
					if (requestCase_ != RequestOneofCase.VideoInputsRequest)
					{
						return null;
					}
					return (API_v1_Video_Inputs_Request)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.VideoInputsRequest : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Announcement_Request AnnouncementRequest
			{
				get
				{
					if (requestCase_ != RequestOneofCase.AnnouncementRequest)
					{
						return null;
					}
					return (API_v1_Announcement_Request)request_;
				}
				set
				{
					request_ = value;
					requestCase_ = ((value != null) ? RequestOneofCase.AnnouncementRequest : RequestOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Audio_Response AudioResponse
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.AudioResponse)
					{
						return null;
					}
					return (API_v1_Audio_Response)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.AudioResponse : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Capture_Response CaptureResponse
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.CaptureResponse)
					{
						return null;
					}
					return (API_v1_Capture_Response)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.CaptureResponse : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Clear_Response ClearingResponse
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.ClearingResponse)
					{
						return null;
					}
					return (API_v1_Clear_Response)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.ClearingResponse : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Groups_Response GroupsResponse
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.GroupsResponse)
					{
						return null;
					}
					return (API_v1_Groups_Response)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.GroupsResponse : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Link_Response LinkResponse
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.LinkResponse)
					{
						return null;
					}
					return (API_v1_Link_Response)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.LinkResponse : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Library_Response LibraryResponse
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.LibraryResponse)
					{
						return null;
					}
					return (API_v1_Library_Response)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.LibraryResponse : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Looks_Response LooksResponse
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.LooksResponse)
					{
						return null;
					}
					return (API_v1_Looks_Response)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.LooksResponse : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Macro_Response MacroResponse
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.MacroResponse)
					{
						return null;
					}
					return (API_v1_Macro_Response)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.MacroResponse : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Masks_Response MasksResponse
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.MasksResponse)
					{
						return null;
					}
					return (API_v1_Masks_Response)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.MasksResponse : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Media_Response MediaResponse
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.MediaResponse)
					{
						return null;
					}
					return (API_v1_Media_Response)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.MediaResponse : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Message_Response MessageResponse
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.MessageResponse)
					{
						return null;
					}
					return (API_v1_Message_Response)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.MessageResponse : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Miscellaneous_Response MiscellaneousResponse
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.MiscellaneousResponse)
					{
						return null;
					}
					return (API_v1_Miscellaneous_Response)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.MiscellaneousResponse : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Playlist_Response PlaylistResponse
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.PlaylistResponse)
					{
						return null;
					}
					return (API_v1_Playlist_Response)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.PlaylistResponse : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Preroll_Response PrerollResponse
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.PrerollResponse)
					{
						return null;
					}
					return (API_v1_Preroll_Response)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.PrerollResponse : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Presentation_Response PresentationResponse
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.PresentationResponse)
					{
						return null;
					}
					return (API_v1_Presentation_Response)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.PresentationResponse : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Prop_Response PropResponse
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.PropResponse)
					{
						return null;
					}
					return (API_v1_Prop_Response)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.PropResponse : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Stage_Response StageResponse
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.StageResponse)
					{
						return null;
					}
					return (API_v1_Stage_Response)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.StageResponse : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Status_Response StatusResponse
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.StatusResponse)
					{
						return null;
					}
					return (API_v1_Status_Response)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.StatusResponse : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Theme_Response ThemeResponse
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.ThemeResponse)
					{
						return null;
					}
					return (API_v1_Theme_Response)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.ThemeResponse : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Timer_Response TimerResponse
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.TimerResponse)
					{
						return null;
					}
					return (API_v1_Timer_Response)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.TimerResponse : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Transport_Response TransportResponse
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.TransportResponse)
					{
						return null;
					}
					return (API_v1_Transport_Response)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.TransportResponse : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Trigger_Response TriggerResponse
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.TriggerResponse)
					{
						return null;
					}
					return (API_v1_Trigger_Response)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.TriggerResponse : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Video_Inputs_Response VideoInputsResponse
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.VideoInputsResponse)
					{
						return null;
					}
					return (API_v1_Video_Inputs_Response)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.VideoInputsResponse : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Announcement_Response AnnouncementResponse
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.AnnouncementResponse)
					{
						return null;
					}
					return (API_v1_Announcement_Response)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.AnnouncementResponse : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public API_v1_Error_Response ErrorResponse
			{
				get
				{
					if (responseCase_ != ResponseOneofCase.ErrorResponse)
					{
						return null;
					}
					return (API_v1_Error_Response)response_;
				}
				set
				{
					response_ = value;
					responseCase_ = ((value != null) ? ResponseOneofCase.ErrorResponse : ResponseOneofCase.None);
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public string UpdateIdentifier
			{
				get
				{
					if (!HasUpdateIdentifier)
					{
						return "";
					}
					return (string)streamingUpdateIdentifier_;
				}
				set
				{
					streamingUpdateIdentifier_ = ProtoPreconditions.CheckNotNull(value, "value");
					streamingUpdateIdentifierCase_ = StreamingUpdateIdentifierOneofCase.UpdateIdentifier;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool HasUpdateIdentifier => streamingUpdateIdentifierCase_ == StreamingUpdateIdentifierOneofCase.UpdateIdentifier;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RequestOneofCase RequestCase => requestCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public ResponseOneofCase ResponseCase => responseCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public StreamingUpdateIdentifierOneofCase StreamingUpdateIdentifierCase => streamingUpdateIdentifierCase_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Action()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Action(Action other)
				: this()
			{
				switch (other.RequestCase)
				{
				case RequestOneofCase.AudioRequest:
					AudioRequest = other.AudioRequest.Clone();
					break;
				case RequestOneofCase.CaptureRequest:
					CaptureRequest = other.CaptureRequest.Clone();
					break;
				case RequestOneofCase.ClearingRequest:
					ClearingRequest = other.ClearingRequest.Clone();
					break;
				case RequestOneofCase.GroupsRequest:
					GroupsRequest = other.GroupsRequest.Clone();
					break;
				case RequestOneofCase.LinkRequest:
					LinkRequest = other.LinkRequest.Clone();
					break;
				case RequestOneofCase.LibraryRequest:
					LibraryRequest = other.LibraryRequest.Clone();
					break;
				case RequestOneofCase.LooksRequest:
					LooksRequest = other.LooksRequest.Clone();
					break;
				case RequestOneofCase.MacroRequest:
					MacroRequest = other.MacroRequest.Clone();
					break;
				case RequestOneofCase.MasksRequest:
					MasksRequest = other.MasksRequest.Clone();
					break;
				case RequestOneofCase.MediaRequest:
					MediaRequest = other.MediaRequest.Clone();
					break;
				case RequestOneofCase.MessageRequest:
					MessageRequest = other.MessageRequest.Clone();
					break;
				case RequestOneofCase.MiscellaneousRequest:
					MiscellaneousRequest = other.MiscellaneousRequest.Clone();
					break;
				case RequestOneofCase.PlaylistRequest:
					PlaylistRequest = other.PlaylistRequest.Clone();
					break;
				case RequestOneofCase.PrerollRequest:
					PrerollRequest = other.PrerollRequest.Clone();
					break;
				case RequestOneofCase.PresentationRequest:
					PresentationRequest = other.PresentationRequest.Clone();
					break;
				case RequestOneofCase.PropRequest:
					PropRequest = other.PropRequest.Clone();
					break;
				case RequestOneofCase.StageRequest:
					StageRequest = other.StageRequest.Clone();
					break;
				case RequestOneofCase.StatusRequest:
					StatusRequest = other.StatusRequest.Clone();
					break;
				case RequestOneofCase.ThemeRequest:
					ThemeRequest = other.ThemeRequest.Clone();
					break;
				case RequestOneofCase.TimerRequest:
					TimerRequest = other.TimerRequest.Clone();
					break;
				case RequestOneofCase.TransportRequest:
					TransportRequest = other.TransportRequest.Clone();
					break;
				case RequestOneofCase.TriggerRequest:
					TriggerRequest = other.TriggerRequest.Clone();
					break;
				case RequestOneofCase.VideoInputsRequest:
					VideoInputsRequest = other.VideoInputsRequest.Clone();
					break;
				case RequestOneofCase.AnnouncementRequest:
					AnnouncementRequest = other.AnnouncementRequest.Clone();
					break;
				}
				switch (other.ResponseCase)
				{
				case ResponseOneofCase.AudioResponse:
					AudioResponse = other.AudioResponse.Clone();
					break;
				case ResponseOneofCase.CaptureResponse:
					CaptureResponse = other.CaptureResponse.Clone();
					break;
				case ResponseOneofCase.ClearingResponse:
					ClearingResponse = other.ClearingResponse.Clone();
					break;
				case ResponseOneofCase.GroupsResponse:
					GroupsResponse = other.GroupsResponse.Clone();
					break;
				case ResponseOneofCase.LinkResponse:
					LinkResponse = other.LinkResponse.Clone();
					break;
				case ResponseOneofCase.LibraryResponse:
					LibraryResponse = other.LibraryResponse.Clone();
					break;
				case ResponseOneofCase.LooksResponse:
					LooksResponse = other.LooksResponse.Clone();
					break;
				case ResponseOneofCase.MacroResponse:
					MacroResponse = other.MacroResponse.Clone();
					break;
				case ResponseOneofCase.MasksResponse:
					MasksResponse = other.MasksResponse.Clone();
					break;
				case ResponseOneofCase.MediaResponse:
					MediaResponse = other.MediaResponse.Clone();
					break;
				case ResponseOneofCase.MessageResponse:
					MessageResponse = other.MessageResponse.Clone();
					break;
				case ResponseOneofCase.MiscellaneousResponse:
					MiscellaneousResponse = other.MiscellaneousResponse.Clone();
					break;
				case ResponseOneofCase.PlaylistResponse:
					PlaylistResponse = other.PlaylistResponse.Clone();
					break;
				case ResponseOneofCase.PrerollResponse:
					PrerollResponse = other.PrerollResponse.Clone();
					break;
				case ResponseOneofCase.PresentationResponse:
					PresentationResponse = other.PresentationResponse.Clone();
					break;
				case ResponseOneofCase.PropResponse:
					PropResponse = other.PropResponse.Clone();
					break;
				case ResponseOneofCase.StageResponse:
					StageResponse = other.StageResponse.Clone();
					break;
				case ResponseOneofCase.StatusResponse:
					StatusResponse = other.StatusResponse.Clone();
					break;
				case ResponseOneofCase.ThemeResponse:
					ThemeResponse = other.ThemeResponse.Clone();
					break;
				case ResponseOneofCase.TimerResponse:
					TimerResponse = other.TimerResponse.Clone();
					break;
				case ResponseOneofCase.TransportResponse:
					TransportResponse = other.TransportResponse.Clone();
					break;
				case ResponseOneofCase.TriggerResponse:
					TriggerResponse = other.TriggerResponse.Clone();
					break;
				case ResponseOneofCase.VideoInputsResponse:
					VideoInputsResponse = other.VideoInputsResponse.Clone();
					break;
				case ResponseOneofCase.AnnouncementResponse:
					AnnouncementResponse = other.AnnouncementResponse.Clone();
					break;
				case ResponseOneofCase.ErrorResponse:
					ErrorResponse = other.ErrorResponse.Clone();
					break;
				}
				if (other.StreamingUpdateIdentifierCase == StreamingUpdateIdentifierOneofCase.UpdateIdentifier)
				{
					UpdateIdentifier = other.UpdateIdentifier;
				}
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Action Clone()
			{
				return new Action(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearUpdateIdentifier()
			{
				if (HasUpdateIdentifier)
				{
					ClearStreamingUpdateIdentifier();
				}
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
			public void ClearResponse()
			{
				responseCase_ = ResponseOneofCase.None;
				response_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void ClearStreamingUpdateIdentifier()
			{
				streamingUpdateIdentifierCase_ = StreamingUpdateIdentifierOneofCase.None;
				streamingUpdateIdentifier_ = null;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Action);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Action other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(AudioRequest, other.AudioRequest))
				{
					return false;
				}
				if (!object.Equals(CaptureRequest, other.CaptureRequest))
				{
					return false;
				}
				if (!object.Equals(ClearingRequest, other.ClearingRequest))
				{
					return false;
				}
				if (!object.Equals(GroupsRequest, other.GroupsRequest))
				{
					return false;
				}
				if (!object.Equals(LinkRequest, other.LinkRequest))
				{
					return false;
				}
				if (!object.Equals(LibraryRequest, other.LibraryRequest))
				{
					return false;
				}
				if (!object.Equals(LooksRequest, other.LooksRequest))
				{
					return false;
				}
				if (!object.Equals(MacroRequest, other.MacroRequest))
				{
					return false;
				}
				if (!object.Equals(MasksRequest, other.MasksRequest))
				{
					return false;
				}
				if (!object.Equals(MediaRequest, other.MediaRequest))
				{
					return false;
				}
				if (!object.Equals(MessageRequest, other.MessageRequest))
				{
					return false;
				}
				if (!object.Equals(MiscellaneousRequest, other.MiscellaneousRequest))
				{
					return false;
				}
				if (!object.Equals(PlaylistRequest, other.PlaylistRequest))
				{
					return false;
				}
				if (!object.Equals(PrerollRequest, other.PrerollRequest))
				{
					return false;
				}
				if (!object.Equals(PresentationRequest, other.PresentationRequest))
				{
					return false;
				}
				if (!object.Equals(PropRequest, other.PropRequest))
				{
					return false;
				}
				if (!object.Equals(StageRequest, other.StageRequest))
				{
					return false;
				}
				if (!object.Equals(StatusRequest, other.StatusRequest))
				{
					return false;
				}
				if (!object.Equals(ThemeRequest, other.ThemeRequest))
				{
					return false;
				}
				if (!object.Equals(TimerRequest, other.TimerRequest))
				{
					return false;
				}
				if (!object.Equals(TransportRequest, other.TransportRequest))
				{
					return false;
				}
				if (!object.Equals(TriggerRequest, other.TriggerRequest))
				{
					return false;
				}
				if (!object.Equals(VideoInputsRequest, other.VideoInputsRequest))
				{
					return false;
				}
				if (!object.Equals(AnnouncementRequest, other.AnnouncementRequest))
				{
					return false;
				}
				if (!object.Equals(AudioResponse, other.AudioResponse))
				{
					return false;
				}
				if (!object.Equals(CaptureResponse, other.CaptureResponse))
				{
					return false;
				}
				if (!object.Equals(ClearingResponse, other.ClearingResponse))
				{
					return false;
				}
				if (!object.Equals(GroupsResponse, other.GroupsResponse))
				{
					return false;
				}
				if (!object.Equals(LinkResponse, other.LinkResponse))
				{
					return false;
				}
				if (!object.Equals(LibraryResponse, other.LibraryResponse))
				{
					return false;
				}
				if (!object.Equals(LooksResponse, other.LooksResponse))
				{
					return false;
				}
				if (!object.Equals(MacroResponse, other.MacroResponse))
				{
					return false;
				}
				if (!object.Equals(MasksResponse, other.MasksResponse))
				{
					return false;
				}
				if (!object.Equals(MediaResponse, other.MediaResponse))
				{
					return false;
				}
				if (!object.Equals(MessageResponse, other.MessageResponse))
				{
					return false;
				}
				if (!object.Equals(MiscellaneousResponse, other.MiscellaneousResponse))
				{
					return false;
				}
				if (!object.Equals(PlaylistResponse, other.PlaylistResponse))
				{
					return false;
				}
				if (!object.Equals(PrerollResponse, other.PrerollResponse))
				{
					return false;
				}
				if (!object.Equals(PresentationResponse, other.PresentationResponse))
				{
					return false;
				}
				if (!object.Equals(PropResponse, other.PropResponse))
				{
					return false;
				}
				if (!object.Equals(StageResponse, other.StageResponse))
				{
					return false;
				}
				if (!object.Equals(StatusResponse, other.StatusResponse))
				{
					return false;
				}
				if (!object.Equals(ThemeResponse, other.ThemeResponse))
				{
					return false;
				}
				if (!object.Equals(TimerResponse, other.TimerResponse))
				{
					return false;
				}
				if (!object.Equals(TransportResponse, other.TransportResponse))
				{
					return false;
				}
				if (!object.Equals(TriggerResponse, other.TriggerResponse))
				{
					return false;
				}
				if (!object.Equals(VideoInputsResponse, other.VideoInputsResponse))
				{
					return false;
				}
				if (!object.Equals(AnnouncementResponse, other.AnnouncementResponse))
				{
					return false;
				}
				if (!object.Equals(ErrorResponse, other.ErrorResponse))
				{
					return false;
				}
				if (UpdateIdentifier != other.UpdateIdentifier)
				{
					return false;
				}
				if (RequestCase != other.RequestCase)
				{
					return false;
				}
				if (ResponseCase != other.ResponseCase)
				{
					return false;
				}
				if (StreamingUpdateIdentifierCase != other.StreamingUpdateIdentifierCase)
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
				if (requestCase_ == RequestOneofCase.AudioRequest)
				{
					num ^= AudioRequest.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.CaptureRequest)
				{
					num ^= CaptureRequest.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.ClearingRequest)
				{
					num ^= ClearingRequest.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.GroupsRequest)
				{
					num ^= GroupsRequest.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.LinkRequest)
				{
					num ^= LinkRequest.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.LibraryRequest)
				{
					num ^= LibraryRequest.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.LooksRequest)
				{
					num ^= LooksRequest.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.MacroRequest)
				{
					num ^= MacroRequest.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.MasksRequest)
				{
					num ^= MasksRequest.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.MediaRequest)
				{
					num ^= MediaRequest.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.MessageRequest)
				{
					num ^= MessageRequest.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.MiscellaneousRequest)
				{
					num ^= MiscellaneousRequest.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.PlaylistRequest)
				{
					num ^= PlaylistRequest.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.PrerollRequest)
				{
					num ^= PrerollRequest.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.PresentationRequest)
				{
					num ^= PresentationRequest.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.PropRequest)
				{
					num ^= PropRequest.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.StageRequest)
				{
					num ^= StageRequest.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.StatusRequest)
				{
					num ^= StatusRequest.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.ThemeRequest)
				{
					num ^= ThemeRequest.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.TimerRequest)
				{
					num ^= TimerRequest.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.TransportRequest)
				{
					num ^= TransportRequest.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.TriggerRequest)
				{
					num ^= TriggerRequest.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.VideoInputsRequest)
				{
					num ^= VideoInputsRequest.GetHashCode();
				}
				if (requestCase_ == RequestOneofCase.AnnouncementRequest)
				{
					num ^= AnnouncementRequest.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.AudioResponse)
				{
					num ^= AudioResponse.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.CaptureResponse)
				{
					num ^= CaptureResponse.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.ClearingResponse)
				{
					num ^= ClearingResponse.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.GroupsResponse)
				{
					num ^= GroupsResponse.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.LinkResponse)
				{
					num ^= LinkResponse.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.LibraryResponse)
				{
					num ^= LibraryResponse.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.LooksResponse)
				{
					num ^= LooksResponse.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.MacroResponse)
				{
					num ^= MacroResponse.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.MasksResponse)
				{
					num ^= MasksResponse.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.MediaResponse)
				{
					num ^= MediaResponse.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.MessageResponse)
				{
					num ^= MessageResponse.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.MiscellaneousResponse)
				{
					num ^= MiscellaneousResponse.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.PlaylistResponse)
				{
					num ^= PlaylistResponse.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.PrerollResponse)
				{
					num ^= PrerollResponse.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.PresentationResponse)
				{
					num ^= PresentationResponse.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.PropResponse)
				{
					num ^= PropResponse.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.StageResponse)
				{
					num ^= StageResponse.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.StatusResponse)
				{
					num ^= StatusResponse.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.ThemeResponse)
				{
					num ^= ThemeResponse.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.TimerResponse)
				{
					num ^= TimerResponse.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.TransportResponse)
				{
					num ^= TransportResponse.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.TriggerResponse)
				{
					num ^= TriggerResponse.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.VideoInputsResponse)
				{
					num ^= VideoInputsResponse.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.AnnouncementResponse)
				{
					num ^= AnnouncementResponse.GetHashCode();
				}
				if (responseCase_ == ResponseOneofCase.ErrorResponse)
				{
					num ^= ErrorResponse.GetHashCode();
				}
				if (HasUpdateIdentifier)
				{
					num ^= UpdateIdentifier.GetHashCode();
				}
				num ^= (int)requestCase_;
				num ^= (int)responseCase_;
				num ^= (int)streamingUpdateIdentifierCase_;
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
				if (requestCase_ == RequestOneofCase.AudioRequest)
				{
					output.WriteRawTag(10);
					output.WriteMessage(AudioRequest);
				}
				if (requestCase_ == RequestOneofCase.CaptureRequest)
				{
					output.WriteRawTag(18);
					output.WriteMessage(CaptureRequest);
				}
				if (requestCase_ == RequestOneofCase.ClearingRequest)
				{
					output.WriteRawTag(26);
					output.WriteMessage(ClearingRequest);
				}
				if (requestCase_ == RequestOneofCase.GroupsRequest)
				{
					output.WriteRawTag(34);
					output.WriteMessage(GroupsRequest);
				}
				if (requestCase_ == RequestOneofCase.LinkRequest)
				{
					output.WriteRawTag(42);
					output.WriteMessage(LinkRequest);
				}
				if (requestCase_ == RequestOneofCase.LibraryRequest)
				{
					output.WriteRawTag(50);
					output.WriteMessage(LibraryRequest);
				}
				if (requestCase_ == RequestOneofCase.LooksRequest)
				{
					output.WriteRawTag(58);
					output.WriteMessage(LooksRequest);
				}
				if (requestCase_ == RequestOneofCase.MacroRequest)
				{
					output.WriteRawTag(66);
					output.WriteMessage(MacroRequest);
				}
				if (requestCase_ == RequestOneofCase.MasksRequest)
				{
					output.WriteRawTag(74);
					output.WriteMessage(MasksRequest);
				}
				if (requestCase_ == RequestOneofCase.MediaRequest)
				{
					output.WriteRawTag(82);
					output.WriteMessage(MediaRequest);
				}
				if (requestCase_ == RequestOneofCase.MessageRequest)
				{
					output.WriteRawTag(90);
					output.WriteMessage(MessageRequest);
				}
				if (requestCase_ == RequestOneofCase.MiscellaneousRequest)
				{
					output.WriteRawTag(98);
					output.WriteMessage(MiscellaneousRequest);
				}
				if (requestCase_ == RequestOneofCase.PlaylistRequest)
				{
					output.WriteRawTag(106);
					output.WriteMessage(PlaylistRequest);
				}
				if (requestCase_ == RequestOneofCase.PrerollRequest)
				{
					output.WriteRawTag(114);
					output.WriteMessage(PrerollRequest);
				}
				if (requestCase_ == RequestOneofCase.PresentationRequest)
				{
					output.WriteRawTag(122);
					output.WriteMessage(PresentationRequest);
				}
				if (requestCase_ == RequestOneofCase.PropRequest)
				{
					output.WriteRawTag(130, 1);
					output.WriteMessage(PropRequest);
				}
				if (requestCase_ == RequestOneofCase.StageRequest)
				{
					output.WriteRawTag(138, 1);
					output.WriteMessage(StageRequest);
				}
				if (requestCase_ == RequestOneofCase.StatusRequest)
				{
					output.WriteRawTag(146, 1);
					output.WriteMessage(StatusRequest);
				}
				if (requestCase_ == RequestOneofCase.ThemeRequest)
				{
					output.WriteRawTag(154, 1);
					output.WriteMessage(ThemeRequest);
				}
				if (requestCase_ == RequestOneofCase.TimerRequest)
				{
					output.WriteRawTag(162, 1);
					output.WriteMessage(TimerRequest);
				}
				if (requestCase_ == RequestOneofCase.TransportRequest)
				{
					output.WriteRawTag(170, 1);
					output.WriteMessage(TransportRequest);
				}
				if (requestCase_ == RequestOneofCase.TriggerRequest)
				{
					output.WriteRawTag(178, 1);
					output.WriteMessage(TriggerRequest);
				}
				if (requestCase_ == RequestOneofCase.VideoInputsRequest)
				{
					output.WriteRawTag(186, 1);
					output.WriteMessage(VideoInputsRequest);
				}
				if (requestCase_ == RequestOneofCase.AnnouncementRequest)
				{
					output.WriteRawTag(194, 1);
					output.WriteMessage(AnnouncementRequest);
				}
				if (responseCase_ == ResponseOneofCase.AudioResponse)
				{
					output.WriteRawTag(170, 6);
					output.WriteMessage(AudioResponse);
				}
				if (responseCase_ == ResponseOneofCase.CaptureResponse)
				{
					output.WriteRawTag(178, 6);
					output.WriteMessage(CaptureResponse);
				}
				if (responseCase_ == ResponseOneofCase.ClearingResponse)
				{
					output.WriteRawTag(186, 6);
					output.WriteMessage(ClearingResponse);
				}
				if (responseCase_ == ResponseOneofCase.GroupsResponse)
				{
					output.WriteRawTag(194, 6);
					output.WriteMessage(GroupsResponse);
				}
				if (responseCase_ == ResponseOneofCase.LinkResponse)
				{
					output.WriteRawTag(202, 6);
					output.WriteMessage(LinkResponse);
				}
				if (responseCase_ == ResponseOneofCase.LibraryResponse)
				{
					output.WriteRawTag(210, 6);
					output.WriteMessage(LibraryResponse);
				}
				if (responseCase_ == ResponseOneofCase.LooksResponse)
				{
					output.WriteRawTag(218, 6);
					output.WriteMessage(LooksResponse);
				}
				if (responseCase_ == ResponseOneofCase.MacroResponse)
				{
					output.WriteRawTag(226, 6);
					output.WriteMessage(MacroResponse);
				}
				if (responseCase_ == ResponseOneofCase.MasksResponse)
				{
					output.WriteRawTag(234, 6);
					output.WriteMessage(MasksResponse);
				}
				if (responseCase_ == ResponseOneofCase.MediaResponse)
				{
					output.WriteRawTag(242, 6);
					output.WriteMessage(MediaResponse);
				}
				if (responseCase_ == ResponseOneofCase.MessageResponse)
				{
					output.WriteRawTag(250, 6);
					output.WriteMessage(MessageResponse);
				}
				if (responseCase_ == ResponseOneofCase.MiscellaneousResponse)
				{
					output.WriteRawTag(130, 7);
					output.WriteMessage(MiscellaneousResponse);
				}
				if (responseCase_ == ResponseOneofCase.PlaylistResponse)
				{
					output.WriteRawTag(138, 7);
					output.WriteMessage(PlaylistResponse);
				}
				if (responseCase_ == ResponseOneofCase.PrerollResponse)
				{
					output.WriteRawTag(146, 7);
					output.WriteMessage(PrerollResponse);
				}
				if (responseCase_ == ResponseOneofCase.PresentationResponse)
				{
					output.WriteRawTag(154, 7);
					output.WriteMessage(PresentationResponse);
				}
				if (responseCase_ == ResponseOneofCase.PropResponse)
				{
					output.WriteRawTag(162, 7);
					output.WriteMessage(PropResponse);
				}
				if (responseCase_ == ResponseOneofCase.StageResponse)
				{
					output.WriteRawTag(170, 7);
					output.WriteMessage(StageResponse);
				}
				if (responseCase_ == ResponseOneofCase.StatusResponse)
				{
					output.WriteRawTag(178, 7);
					output.WriteMessage(StatusResponse);
				}
				if (responseCase_ == ResponseOneofCase.ThemeResponse)
				{
					output.WriteRawTag(186, 7);
					output.WriteMessage(ThemeResponse);
				}
				if (responseCase_ == ResponseOneofCase.TimerResponse)
				{
					output.WriteRawTag(194, 7);
					output.WriteMessage(TimerResponse);
				}
				if (responseCase_ == ResponseOneofCase.TransportResponse)
				{
					output.WriteRawTag(202, 7);
					output.WriteMessage(TransportResponse);
				}
				if (responseCase_ == ResponseOneofCase.TriggerResponse)
				{
					output.WriteRawTag(210, 7);
					output.WriteMessage(TriggerResponse);
				}
				if (responseCase_ == ResponseOneofCase.VideoInputsResponse)
				{
					output.WriteRawTag(218, 7);
					output.WriteMessage(VideoInputsResponse);
				}
				if (responseCase_ == ResponseOneofCase.AnnouncementResponse)
				{
					output.WriteRawTag(226, 7);
					output.WriteMessage(AnnouncementResponse);
				}
				if (responseCase_ == ResponseOneofCase.ErrorResponse)
				{
					output.WriteRawTag(194, 12);
					output.WriteMessage(ErrorResponse);
				}
				if (HasUpdateIdentifier)
				{
					output.WriteRawTag(202, 12);
					output.WriteString(UpdateIdentifier);
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
				if (requestCase_ == RequestOneofCase.AudioRequest)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(AudioRequest);
				}
				if (requestCase_ == RequestOneofCase.CaptureRequest)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(CaptureRequest);
				}
				if (requestCase_ == RequestOneofCase.ClearingRequest)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(ClearingRequest);
				}
				if (requestCase_ == RequestOneofCase.GroupsRequest)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(GroupsRequest);
				}
				if (requestCase_ == RequestOneofCase.LinkRequest)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(LinkRequest);
				}
				if (requestCase_ == RequestOneofCase.LibraryRequest)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(LibraryRequest);
				}
				if (requestCase_ == RequestOneofCase.LooksRequest)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(LooksRequest);
				}
				if (requestCase_ == RequestOneofCase.MacroRequest)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(MacroRequest);
				}
				if (requestCase_ == RequestOneofCase.MasksRequest)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(MasksRequest);
				}
				if (requestCase_ == RequestOneofCase.MediaRequest)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(MediaRequest);
				}
				if (requestCase_ == RequestOneofCase.MessageRequest)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(MessageRequest);
				}
				if (requestCase_ == RequestOneofCase.MiscellaneousRequest)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(MiscellaneousRequest);
				}
				if (requestCase_ == RequestOneofCase.PlaylistRequest)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(PlaylistRequest);
				}
				if (requestCase_ == RequestOneofCase.PrerollRequest)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(PrerollRequest);
				}
				if (requestCase_ == RequestOneofCase.PresentationRequest)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(PresentationRequest);
				}
				if (requestCase_ == RequestOneofCase.PropRequest)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(PropRequest);
				}
				if (requestCase_ == RequestOneofCase.StageRequest)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(StageRequest);
				}
				if (requestCase_ == RequestOneofCase.StatusRequest)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(StatusRequest);
				}
				if (requestCase_ == RequestOneofCase.ThemeRequest)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(ThemeRequest);
				}
				if (requestCase_ == RequestOneofCase.TimerRequest)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(TimerRequest);
				}
				if (requestCase_ == RequestOneofCase.TransportRequest)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(TransportRequest);
				}
				if (requestCase_ == RequestOneofCase.TriggerRequest)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(TriggerRequest);
				}
				if (requestCase_ == RequestOneofCase.VideoInputsRequest)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(VideoInputsRequest);
				}
				if (requestCase_ == RequestOneofCase.AnnouncementRequest)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(AnnouncementRequest);
				}
				if (responseCase_ == ResponseOneofCase.AudioResponse)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(AudioResponse);
				}
				if (responseCase_ == ResponseOneofCase.CaptureResponse)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(CaptureResponse);
				}
				if (responseCase_ == ResponseOneofCase.ClearingResponse)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(ClearingResponse);
				}
				if (responseCase_ == ResponseOneofCase.GroupsResponse)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(GroupsResponse);
				}
				if (responseCase_ == ResponseOneofCase.LinkResponse)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(LinkResponse);
				}
				if (responseCase_ == ResponseOneofCase.LibraryResponse)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(LibraryResponse);
				}
				if (responseCase_ == ResponseOneofCase.LooksResponse)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(LooksResponse);
				}
				if (responseCase_ == ResponseOneofCase.MacroResponse)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(MacroResponse);
				}
				if (responseCase_ == ResponseOneofCase.MasksResponse)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(MasksResponse);
				}
				if (responseCase_ == ResponseOneofCase.MediaResponse)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(MediaResponse);
				}
				if (responseCase_ == ResponseOneofCase.MessageResponse)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(MessageResponse);
				}
				if (responseCase_ == ResponseOneofCase.MiscellaneousResponse)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(MiscellaneousResponse);
				}
				if (responseCase_ == ResponseOneofCase.PlaylistResponse)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(PlaylistResponse);
				}
				if (responseCase_ == ResponseOneofCase.PrerollResponse)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(PrerollResponse);
				}
				if (responseCase_ == ResponseOneofCase.PresentationResponse)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(PresentationResponse);
				}
				if (responseCase_ == ResponseOneofCase.PropResponse)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(PropResponse);
				}
				if (responseCase_ == ResponseOneofCase.StageResponse)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(StageResponse);
				}
				if (responseCase_ == ResponseOneofCase.StatusResponse)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(StatusResponse);
				}
				if (responseCase_ == ResponseOneofCase.ThemeResponse)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(ThemeResponse);
				}
				if (responseCase_ == ResponseOneofCase.TimerResponse)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(TimerResponse);
				}
				if (responseCase_ == ResponseOneofCase.TransportResponse)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(TransportResponse);
				}
				if (responseCase_ == ResponseOneofCase.TriggerResponse)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(TriggerResponse);
				}
				if (responseCase_ == ResponseOneofCase.VideoInputsResponse)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(VideoInputsResponse);
				}
				if (responseCase_ == ResponseOneofCase.AnnouncementResponse)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(AnnouncementResponse);
				}
				if (responseCase_ == ResponseOneofCase.ErrorResponse)
				{
					num += 2 + CodedOutputStream.ComputeMessageSize(ErrorResponse);
				}
				if (HasUpdateIdentifier)
				{
					num += 2 + CodedOutputStream.ComputeStringSize(UpdateIdentifier);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Action other)
			{
				if (other == null)
				{
					return;
				}
				switch (other.RequestCase)
				{
				case RequestOneofCase.AudioRequest:
					if (AudioRequest == null)
					{
						AudioRequest = new API_v1_Audio_Request();
					}
					AudioRequest.MergeFrom(other.AudioRequest);
					break;
				case RequestOneofCase.CaptureRequest:
					if (CaptureRequest == null)
					{
						CaptureRequest = new API_v1_Capture_Request();
					}
					CaptureRequest.MergeFrom(other.CaptureRequest);
					break;
				case RequestOneofCase.ClearingRequest:
					if (ClearingRequest == null)
					{
						ClearingRequest = new API_v1_Clear_Request();
					}
					ClearingRequest.MergeFrom(other.ClearingRequest);
					break;
				case RequestOneofCase.GroupsRequest:
					if (GroupsRequest == null)
					{
						GroupsRequest = new API_v1_Groups_Request();
					}
					GroupsRequest.MergeFrom(other.GroupsRequest);
					break;
				case RequestOneofCase.LinkRequest:
					if (LinkRequest == null)
					{
						LinkRequest = new API_v1_Link_Request();
					}
					LinkRequest.MergeFrom(other.LinkRequest);
					break;
				case RequestOneofCase.LibraryRequest:
					if (LibraryRequest == null)
					{
						LibraryRequest = new API_v1_Library_Request();
					}
					LibraryRequest.MergeFrom(other.LibraryRequest);
					break;
				case RequestOneofCase.LooksRequest:
					if (LooksRequest == null)
					{
						LooksRequest = new API_v1_Looks_Request();
					}
					LooksRequest.MergeFrom(other.LooksRequest);
					break;
				case RequestOneofCase.MacroRequest:
					if (MacroRequest == null)
					{
						MacroRequest = new API_v1_Macro_Request();
					}
					MacroRequest.MergeFrom(other.MacroRequest);
					break;
				case RequestOneofCase.MasksRequest:
					if (MasksRequest == null)
					{
						MasksRequest = new API_v1_Masks_Request();
					}
					MasksRequest.MergeFrom(other.MasksRequest);
					break;
				case RequestOneofCase.MediaRequest:
					if (MediaRequest == null)
					{
						MediaRequest = new API_v1_Media_Request();
					}
					MediaRequest.MergeFrom(other.MediaRequest);
					break;
				case RequestOneofCase.MessageRequest:
					if (MessageRequest == null)
					{
						MessageRequest = new API_v1_Message_Request();
					}
					MessageRequest.MergeFrom(other.MessageRequest);
					break;
				case RequestOneofCase.MiscellaneousRequest:
					if (MiscellaneousRequest == null)
					{
						MiscellaneousRequest = new API_v1_Miscellaneous_Request();
					}
					MiscellaneousRequest.MergeFrom(other.MiscellaneousRequest);
					break;
				case RequestOneofCase.PlaylistRequest:
					if (PlaylistRequest == null)
					{
						PlaylistRequest = new API_v1_Playlist_Request();
					}
					PlaylistRequest.MergeFrom(other.PlaylistRequest);
					break;
				case RequestOneofCase.PrerollRequest:
					if (PrerollRequest == null)
					{
						PrerollRequest = new API_v1_Preroll_Request();
					}
					PrerollRequest.MergeFrom(other.PrerollRequest);
					break;
				case RequestOneofCase.PresentationRequest:
					if (PresentationRequest == null)
					{
						PresentationRequest = new API_v1_Presentation_Request();
					}
					PresentationRequest.MergeFrom(other.PresentationRequest);
					break;
				case RequestOneofCase.PropRequest:
					if (PropRequest == null)
					{
						PropRequest = new API_v1_Prop_Request();
					}
					PropRequest.MergeFrom(other.PropRequest);
					break;
				case RequestOneofCase.StageRequest:
					if (StageRequest == null)
					{
						StageRequest = new API_v1_Stage_Request();
					}
					StageRequest.MergeFrom(other.StageRequest);
					break;
				case RequestOneofCase.StatusRequest:
					if (StatusRequest == null)
					{
						StatusRequest = new API_v1_Status_Request();
					}
					StatusRequest.MergeFrom(other.StatusRequest);
					break;
				case RequestOneofCase.ThemeRequest:
					if (ThemeRequest == null)
					{
						ThemeRequest = new API_v1_Theme_Request();
					}
					ThemeRequest.MergeFrom(other.ThemeRequest);
					break;
				case RequestOneofCase.TimerRequest:
					if (TimerRequest == null)
					{
						TimerRequest = new API_v1_Timer_Request();
					}
					TimerRequest.MergeFrom(other.TimerRequest);
					break;
				case RequestOneofCase.TransportRequest:
					if (TransportRequest == null)
					{
						TransportRequest = new API_v1_Transport_Request();
					}
					TransportRequest.MergeFrom(other.TransportRequest);
					break;
				case RequestOneofCase.TriggerRequest:
					if (TriggerRequest == null)
					{
						TriggerRequest = new API_v1_Trigger_Request();
					}
					TriggerRequest.MergeFrom(other.TriggerRequest);
					break;
				case RequestOneofCase.VideoInputsRequest:
					if (VideoInputsRequest == null)
					{
						VideoInputsRequest = new API_v1_Video_Inputs_Request();
					}
					VideoInputsRequest.MergeFrom(other.VideoInputsRequest);
					break;
				case RequestOneofCase.AnnouncementRequest:
					if (AnnouncementRequest == null)
					{
						AnnouncementRequest = new API_v1_Announcement_Request();
					}
					AnnouncementRequest.MergeFrom(other.AnnouncementRequest);
					break;
				}
				switch (other.ResponseCase)
				{
				case ResponseOneofCase.AudioResponse:
					if (AudioResponse == null)
					{
						AudioResponse = new API_v1_Audio_Response();
					}
					AudioResponse.MergeFrom(other.AudioResponse);
					break;
				case ResponseOneofCase.CaptureResponse:
					if (CaptureResponse == null)
					{
						CaptureResponse = new API_v1_Capture_Response();
					}
					CaptureResponse.MergeFrom(other.CaptureResponse);
					break;
				case ResponseOneofCase.ClearingResponse:
					if (ClearingResponse == null)
					{
						ClearingResponse = new API_v1_Clear_Response();
					}
					ClearingResponse.MergeFrom(other.ClearingResponse);
					break;
				case ResponseOneofCase.GroupsResponse:
					if (GroupsResponse == null)
					{
						GroupsResponse = new API_v1_Groups_Response();
					}
					GroupsResponse.MergeFrom(other.GroupsResponse);
					break;
				case ResponseOneofCase.LinkResponse:
					if (LinkResponse == null)
					{
						LinkResponse = new API_v1_Link_Response();
					}
					LinkResponse.MergeFrom(other.LinkResponse);
					break;
				case ResponseOneofCase.LibraryResponse:
					if (LibraryResponse == null)
					{
						LibraryResponse = new API_v1_Library_Response();
					}
					LibraryResponse.MergeFrom(other.LibraryResponse);
					break;
				case ResponseOneofCase.LooksResponse:
					if (LooksResponse == null)
					{
						LooksResponse = new API_v1_Looks_Response();
					}
					LooksResponse.MergeFrom(other.LooksResponse);
					break;
				case ResponseOneofCase.MacroResponse:
					if (MacroResponse == null)
					{
						MacroResponse = new API_v1_Macro_Response();
					}
					MacroResponse.MergeFrom(other.MacroResponse);
					break;
				case ResponseOneofCase.MasksResponse:
					if (MasksResponse == null)
					{
						MasksResponse = new API_v1_Masks_Response();
					}
					MasksResponse.MergeFrom(other.MasksResponse);
					break;
				case ResponseOneofCase.MediaResponse:
					if (MediaResponse == null)
					{
						MediaResponse = new API_v1_Media_Response();
					}
					MediaResponse.MergeFrom(other.MediaResponse);
					break;
				case ResponseOneofCase.MessageResponse:
					if (MessageResponse == null)
					{
						MessageResponse = new API_v1_Message_Response();
					}
					MessageResponse.MergeFrom(other.MessageResponse);
					break;
				case ResponseOneofCase.MiscellaneousResponse:
					if (MiscellaneousResponse == null)
					{
						MiscellaneousResponse = new API_v1_Miscellaneous_Response();
					}
					MiscellaneousResponse.MergeFrom(other.MiscellaneousResponse);
					break;
				case ResponseOneofCase.PlaylistResponse:
					if (PlaylistResponse == null)
					{
						PlaylistResponse = new API_v1_Playlist_Response();
					}
					PlaylistResponse.MergeFrom(other.PlaylistResponse);
					break;
				case ResponseOneofCase.PrerollResponse:
					if (PrerollResponse == null)
					{
						PrerollResponse = new API_v1_Preroll_Response();
					}
					PrerollResponse.MergeFrom(other.PrerollResponse);
					break;
				case ResponseOneofCase.PresentationResponse:
					if (PresentationResponse == null)
					{
						PresentationResponse = new API_v1_Presentation_Response();
					}
					PresentationResponse.MergeFrom(other.PresentationResponse);
					break;
				case ResponseOneofCase.PropResponse:
					if (PropResponse == null)
					{
						PropResponse = new API_v1_Prop_Response();
					}
					PropResponse.MergeFrom(other.PropResponse);
					break;
				case ResponseOneofCase.StageResponse:
					if (StageResponse == null)
					{
						StageResponse = new API_v1_Stage_Response();
					}
					StageResponse.MergeFrom(other.StageResponse);
					break;
				case ResponseOneofCase.StatusResponse:
					if (StatusResponse == null)
					{
						StatusResponse = new API_v1_Status_Response();
					}
					StatusResponse.MergeFrom(other.StatusResponse);
					break;
				case ResponseOneofCase.ThemeResponse:
					if (ThemeResponse == null)
					{
						ThemeResponse = new API_v1_Theme_Response();
					}
					ThemeResponse.MergeFrom(other.ThemeResponse);
					break;
				case ResponseOneofCase.TimerResponse:
					if (TimerResponse == null)
					{
						TimerResponse = new API_v1_Timer_Response();
					}
					TimerResponse.MergeFrom(other.TimerResponse);
					break;
				case ResponseOneofCase.TransportResponse:
					if (TransportResponse == null)
					{
						TransportResponse = new API_v1_Transport_Response();
					}
					TransportResponse.MergeFrom(other.TransportResponse);
					break;
				case ResponseOneofCase.TriggerResponse:
					if (TriggerResponse == null)
					{
						TriggerResponse = new API_v1_Trigger_Response();
					}
					TriggerResponse.MergeFrom(other.TriggerResponse);
					break;
				case ResponseOneofCase.VideoInputsResponse:
					if (VideoInputsResponse == null)
					{
						VideoInputsResponse = new API_v1_Video_Inputs_Response();
					}
					VideoInputsResponse.MergeFrom(other.VideoInputsResponse);
					break;
				case ResponseOneofCase.AnnouncementResponse:
					if (AnnouncementResponse == null)
					{
						AnnouncementResponse = new API_v1_Announcement_Response();
					}
					AnnouncementResponse.MergeFrom(other.AnnouncementResponse);
					break;
				case ResponseOneofCase.ErrorResponse:
					if (ErrorResponse == null)
					{
						ErrorResponse = new API_v1_Error_Response();
					}
					ErrorResponse.MergeFrom(other.ErrorResponse);
					break;
				}
				if (other.StreamingUpdateIdentifierCase == StreamingUpdateIdentifierOneofCase.UpdateIdentifier)
				{
					UpdateIdentifier = other.UpdateIdentifier;
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
						API_v1_Audio_Request aPI_v1_Audio_Request = new API_v1_Audio_Request();
						if (requestCase_ == RequestOneofCase.AudioRequest)
						{
							aPI_v1_Audio_Request.MergeFrom(AudioRequest);
						}
						input.ReadMessage(aPI_v1_Audio_Request);
						AudioRequest = aPI_v1_Audio_Request;
						break;
					}
					case 18u:
					{
						API_v1_Capture_Request aPI_v1_Capture_Request = new API_v1_Capture_Request();
						if (requestCase_ == RequestOneofCase.CaptureRequest)
						{
							aPI_v1_Capture_Request.MergeFrom(CaptureRequest);
						}
						input.ReadMessage(aPI_v1_Capture_Request);
						CaptureRequest = aPI_v1_Capture_Request;
						break;
					}
					case 26u:
					{
						API_v1_Clear_Request aPI_v1_Clear_Request = new API_v1_Clear_Request();
						if (requestCase_ == RequestOneofCase.ClearingRequest)
						{
							aPI_v1_Clear_Request.MergeFrom(ClearingRequest);
						}
						input.ReadMessage(aPI_v1_Clear_Request);
						ClearingRequest = aPI_v1_Clear_Request;
						break;
					}
					case 34u:
					{
						API_v1_Groups_Request aPI_v1_Groups_Request = new API_v1_Groups_Request();
						if (requestCase_ == RequestOneofCase.GroupsRequest)
						{
							aPI_v1_Groups_Request.MergeFrom(GroupsRequest);
						}
						input.ReadMessage(aPI_v1_Groups_Request);
						GroupsRequest = aPI_v1_Groups_Request;
						break;
					}
					case 42u:
					{
						API_v1_Link_Request aPI_v1_Link_Request = new API_v1_Link_Request();
						if (requestCase_ == RequestOneofCase.LinkRequest)
						{
							aPI_v1_Link_Request.MergeFrom(LinkRequest);
						}
						input.ReadMessage(aPI_v1_Link_Request);
						LinkRequest = aPI_v1_Link_Request;
						break;
					}
					case 50u:
					{
						API_v1_Library_Request aPI_v1_Library_Request = new API_v1_Library_Request();
						if (requestCase_ == RequestOneofCase.LibraryRequest)
						{
							aPI_v1_Library_Request.MergeFrom(LibraryRequest);
						}
						input.ReadMessage(aPI_v1_Library_Request);
						LibraryRequest = aPI_v1_Library_Request;
						break;
					}
					case 58u:
					{
						API_v1_Looks_Request aPI_v1_Looks_Request = new API_v1_Looks_Request();
						if (requestCase_ == RequestOneofCase.LooksRequest)
						{
							aPI_v1_Looks_Request.MergeFrom(LooksRequest);
						}
						input.ReadMessage(aPI_v1_Looks_Request);
						LooksRequest = aPI_v1_Looks_Request;
						break;
					}
					case 66u:
					{
						API_v1_Macro_Request aPI_v1_Macro_Request = new API_v1_Macro_Request();
						if (requestCase_ == RequestOneofCase.MacroRequest)
						{
							aPI_v1_Macro_Request.MergeFrom(MacroRequest);
						}
						input.ReadMessage(aPI_v1_Macro_Request);
						MacroRequest = aPI_v1_Macro_Request;
						break;
					}
					case 74u:
					{
						API_v1_Masks_Request aPI_v1_Masks_Request = new API_v1_Masks_Request();
						if (requestCase_ == RequestOneofCase.MasksRequest)
						{
							aPI_v1_Masks_Request.MergeFrom(MasksRequest);
						}
						input.ReadMessage(aPI_v1_Masks_Request);
						MasksRequest = aPI_v1_Masks_Request;
						break;
					}
					case 82u:
					{
						API_v1_Media_Request aPI_v1_Media_Request = new API_v1_Media_Request();
						if (requestCase_ == RequestOneofCase.MediaRequest)
						{
							aPI_v1_Media_Request.MergeFrom(MediaRequest);
						}
						input.ReadMessage(aPI_v1_Media_Request);
						MediaRequest = aPI_v1_Media_Request;
						break;
					}
					case 90u:
					{
						API_v1_Message_Request aPI_v1_Message_Request = new API_v1_Message_Request();
						if (requestCase_ == RequestOneofCase.MessageRequest)
						{
							aPI_v1_Message_Request.MergeFrom(MessageRequest);
						}
						input.ReadMessage(aPI_v1_Message_Request);
						MessageRequest = aPI_v1_Message_Request;
						break;
					}
					case 98u:
					{
						API_v1_Miscellaneous_Request aPI_v1_Miscellaneous_Request = new API_v1_Miscellaneous_Request();
						if (requestCase_ == RequestOneofCase.MiscellaneousRequest)
						{
							aPI_v1_Miscellaneous_Request.MergeFrom(MiscellaneousRequest);
						}
						input.ReadMessage(aPI_v1_Miscellaneous_Request);
						MiscellaneousRequest = aPI_v1_Miscellaneous_Request;
						break;
					}
					case 106u:
					{
						API_v1_Playlist_Request aPI_v1_Playlist_Request = new API_v1_Playlist_Request();
						if (requestCase_ == RequestOneofCase.PlaylistRequest)
						{
							aPI_v1_Playlist_Request.MergeFrom(PlaylistRequest);
						}
						input.ReadMessage(aPI_v1_Playlist_Request);
						PlaylistRequest = aPI_v1_Playlist_Request;
						break;
					}
					case 114u:
					{
						API_v1_Preroll_Request aPI_v1_Preroll_Request = new API_v1_Preroll_Request();
						if (requestCase_ == RequestOneofCase.PrerollRequest)
						{
							aPI_v1_Preroll_Request.MergeFrom(PrerollRequest);
						}
						input.ReadMessage(aPI_v1_Preroll_Request);
						PrerollRequest = aPI_v1_Preroll_Request;
						break;
					}
					case 122u:
					{
						API_v1_Presentation_Request aPI_v1_Presentation_Request = new API_v1_Presentation_Request();
						if (requestCase_ == RequestOneofCase.PresentationRequest)
						{
							aPI_v1_Presentation_Request.MergeFrom(PresentationRequest);
						}
						input.ReadMessage(aPI_v1_Presentation_Request);
						PresentationRequest = aPI_v1_Presentation_Request;
						break;
					}
					case 130u:
					{
						API_v1_Prop_Request aPI_v1_Prop_Request = new API_v1_Prop_Request();
						if (requestCase_ == RequestOneofCase.PropRequest)
						{
							aPI_v1_Prop_Request.MergeFrom(PropRequest);
						}
						input.ReadMessage(aPI_v1_Prop_Request);
						PropRequest = aPI_v1_Prop_Request;
						break;
					}
					case 138u:
					{
						API_v1_Stage_Request aPI_v1_Stage_Request = new API_v1_Stage_Request();
						if (requestCase_ == RequestOneofCase.StageRequest)
						{
							aPI_v1_Stage_Request.MergeFrom(StageRequest);
						}
						input.ReadMessage(aPI_v1_Stage_Request);
						StageRequest = aPI_v1_Stage_Request;
						break;
					}
					case 146u:
					{
						API_v1_Status_Request aPI_v1_Status_Request = new API_v1_Status_Request();
						if (requestCase_ == RequestOneofCase.StatusRequest)
						{
							aPI_v1_Status_Request.MergeFrom(StatusRequest);
						}
						input.ReadMessage(aPI_v1_Status_Request);
						StatusRequest = aPI_v1_Status_Request;
						break;
					}
					case 154u:
					{
						API_v1_Theme_Request aPI_v1_Theme_Request = new API_v1_Theme_Request();
						if (requestCase_ == RequestOneofCase.ThemeRequest)
						{
							aPI_v1_Theme_Request.MergeFrom(ThemeRequest);
						}
						input.ReadMessage(aPI_v1_Theme_Request);
						ThemeRequest = aPI_v1_Theme_Request;
						break;
					}
					case 162u:
					{
						API_v1_Timer_Request aPI_v1_Timer_Request = new API_v1_Timer_Request();
						if (requestCase_ == RequestOneofCase.TimerRequest)
						{
							aPI_v1_Timer_Request.MergeFrom(TimerRequest);
						}
						input.ReadMessage(aPI_v1_Timer_Request);
						TimerRequest = aPI_v1_Timer_Request;
						break;
					}
					case 170u:
					{
						API_v1_Transport_Request aPI_v1_Transport_Request = new API_v1_Transport_Request();
						if (requestCase_ == RequestOneofCase.TransportRequest)
						{
							aPI_v1_Transport_Request.MergeFrom(TransportRequest);
						}
						input.ReadMessage(aPI_v1_Transport_Request);
						TransportRequest = aPI_v1_Transport_Request;
						break;
					}
					case 178u:
					{
						API_v1_Trigger_Request aPI_v1_Trigger_Request = new API_v1_Trigger_Request();
						if (requestCase_ == RequestOneofCase.TriggerRequest)
						{
							aPI_v1_Trigger_Request.MergeFrom(TriggerRequest);
						}
						input.ReadMessage(aPI_v1_Trigger_Request);
						TriggerRequest = aPI_v1_Trigger_Request;
						break;
					}
					case 186u:
					{
						API_v1_Video_Inputs_Request aPI_v1_Video_Inputs_Request = new API_v1_Video_Inputs_Request();
						if (requestCase_ == RequestOneofCase.VideoInputsRequest)
						{
							aPI_v1_Video_Inputs_Request.MergeFrom(VideoInputsRequest);
						}
						input.ReadMessage(aPI_v1_Video_Inputs_Request);
						VideoInputsRequest = aPI_v1_Video_Inputs_Request;
						break;
					}
					case 194u:
					{
						API_v1_Announcement_Request aPI_v1_Announcement_Request = new API_v1_Announcement_Request();
						if (requestCase_ == RequestOneofCase.AnnouncementRequest)
						{
							aPI_v1_Announcement_Request.MergeFrom(AnnouncementRequest);
						}
						input.ReadMessage(aPI_v1_Announcement_Request);
						AnnouncementRequest = aPI_v1_Announcement_Request;
						break;
					}
					case 810u:
					{
						API_v1_Audio_Response aPI_v1_Audio_Response = new API_v1_Audio_Response();
						if (responseCase_ == ResponseOneofCase.AudioResponse)
						{
							aPI_v1_Audio_Response.MergeFrom(AudioResponse);
						}
						input.ReadMessage(aPI_v1_Audio_Response);
						AudioResponse = aPI_v1_Audio_Response;
						break;
					}
					case 818u:
					{
						API_v1_Capture_Response aPI_v1_Capture_Response = new API_v1_Capture_Response();
						if (responseCase_ == ResponseOneofCase.CaptureResponse)
						{
							aPI_v1_Capture_Response.MergeFrom(CaptureResponse);
						}
						input.ReadMessage(aPI_v1_Capture_Response);
						CaptureResponse = aPI_v1_Capture_Response;
						break;
					}
					case 826u:
					{
						API_v1_Clear_Response aPI_v1_Clear_Response = new API_v1_Clear_Response();
						if (responseCase_ == ResponseOneofCase.ClearingResponse)
						{
							aPI_v1_Clear_Response.MergeFrom(ClearingResponse);
						}
						input.ReadMessage(aPI_v1_Clear_Response);
						ClearingResponse = aPI_v1_Clear_Response;
						break;
					}
					case 834u:
					{
						API_v1_Groups_Response aPI_v1_Groups_Response = new API_v1_Groups_Response();
						if (responseCase_ == ResponseOneofCase.GroupsResponse)
						{
							aPI_v1_Groups_Response.MergeFrom(GroupsResponse);
						}
						input.ReadMessage(aPI_v1_Groups_Response);
						GroupsResponse = aPI_v1_Groups_Response;
						break;
					}
					case 842u:
					{
						API_v1_Link_Response aPI_v1_Link_Response = new API_v1_Link_Response();
						if (responseCase_ == ResponseOneofCase.LinkResponse)
						{
							aPI_v1_Link_Response.MergeFrom(LinkResponse);
						}
						input.ReadMessage(aPI_v1_Link_Response);
						LinkResponse = aPI_v1_Link_Response;
						break;
					}
					case 850u:
					{
						API_v1_Library_Response aPI_v1_Library_Response = new API_v1_Library_Response();
						if (responseCase_ == ResponseOneofCase.LibraryResponse)
						{
							aPI_v1_Library_Response.MergeFrom(LibraryResponse);
						}
						input.ReadMessage(aPI_v1_Library_Response);
						LibraryResponse = aPI_v1_Library_Response;
						break;
					}
					case 858u:
					{
						API_v1_Looks_Response aPI_v1_Looks_Response = new API_v1_Looks_Response();
						if (responseCase_ == ResponseOneofCase.LooksResponse)
						{
							aPI_v1_Looks_Response.MergeFrom(LooksResponse);
						}
						input.ReadMessage(aPI_v1_Looks_Response);
						LooksResponse = aPI_v1_Looks_Response;
						break;
					}
					case 866u:
					{
						API_v1_Macro_Response aPI_v1_Macro_Response = new API_v1_Macro_Response();
						if (responseCase_ == ResponseOneofCase.MacroResponse)
						{
							aPI_v1_Macro_Response.MergeFrom(MacroResponse);
						}
						input.ReadMessage(aPI_v1_Macro_Response);
						MacroResponse = aPI_v1_Macro_Response;
						break;
					}
					case 874u:
					{
						API_v1_Masks_Response aPI_v1_Masks_Response = new API_v1_Masks_Response();
						if (responseCase_ == ResponseOneofCase.MasksResponse)
						{
							aPI_v1_Masks_Response.MergeFrom(MasksResponse);
						}
						input.ReadMessage(aPI_v1_Masks_Response);
						MasksResponse = aPI_v1_Masks_Response;
						break;
					}
					case 882u:
					{
						API_v1_Media_Response aPI_v1_Media_Response = new API_v1_Media_Response();
						if (responseCase_ == ResponseOneofCase.MediaResponse)
						{
							aPI_v1_Media_Response.MergeFrom(MediaResponse);
						}
						input.ReadMessage(aPI_v1_Media_Response);
						MediaResponse = aPI_v1_Media_Response;
						break;
					}
					case 890u:
					{
						API_v1_Message_Response aPI_v1_Message_Response = new API_v1_Message_Response();
						if (responseCase_ == ResponseOneofCase.MessageResponse)
						{
							aPI_v1_Message_Response.MergeFrom(MessageResponse);
						}
						input.ReadMessage(aPI_v1_Message_Response);
						MessageResponse = aPI_v1_Message_Response;
						break;
					}
					case 898u:
					{
						API_v1_Miscellaneous_Response aPI_v1_Miscellaneous_Response = new API_v1_Miscellaneous_Response();
						if (responseCase_ == ResponseOneofCase.MiscellaneousResponse)
						{
							aPI_v1_Miscellaneous_Response.MergeFrom(MiscellaneousResponse);
						}
						input.ReadMessage(aPI_v1_Miscellaneous_Response);
						MiscellaneousResponse = aPI_v1_Miscellaneous_Response;
						break;
					}
					case 906u:
					{
						API_v1_Playlist_Response aPI_v1_Playlist_Response = new API_v1_Playlist_Response();
						if (responseCase_ == ResponseOneofCase.PlaylistResponse)
						{
							aPI_v1_Playlist_Response.MergeFrom(PlaylistResponse);
						}
						input.ReadMessage(aPI_v1_Playlist_Response);
						PlaylistResponse = aPI_v1_Playlist_Response;
						break;
					}
					case 914u:
					{
						API_v1_Preroll_Response aPI_v1_Preroll_Response = new API_v1_Preroll_Response();
						if (responseCase_ == ResponseOneofCase.PrerollResponse)
						{
							aPI_v1_Preroll_Response.MergeFrom(PrerollResponse);
						}
						input.ReadMessage(aPI_v1_Preroll_Response);
						PrerollResponse = aPI_v1_Preroll_Response;
						break;
					}
					case 922u:
					{
						API_v1_Presentation_Response aPI_v1_Presentation_Response = new API_v1_Presentation_Response();
						if (responseCase_ == ResponseOneofCase.PresentationResponse)
						{
							aPI_v1_Presentation_Response.MergeFrom(PresentationResponse);
						}
						input.ReadMessage(aPI_v1_Presentation_Response);
						PresentationResponse = aPI_v1_Presentation_Response;
						break;
					}
					case 930u:
					{
						API_v1_Prop_Response aPI_v1_Prop_Response = new API_v1_Prop_Response();
						if (responseCase_ == ResponseOneofCase.PropResponse)
						{
							aPI_v1_Prop_Response.MergeFrom(PropResponse);
						}
						input.ReadMessage(aPI_v1_Prop_Response);
						PropResponse = aPI_v1_Prop_Response;
						break;
					}
					case 938u:
					{
						API_v1_Stage_Response aPI_v1_Stage_Response = new API_v1_Stage_Response();
						if (responseCase_ == ResponseOneofCase.StageResponse)
						{
							aPI_v1_Stage_Response.MergeFrom(StageResponse);
						}
						input.ReadMessage(aPI_v1_Stage_Response);
						StageResponse = aPI_v1_Stage_Response;
						break;
					}
					case 946u:
					{
						API_v1_Status_Response aPI_v1_Status_Response = new API_v1_Status_Response();
						if (responseCase_ == ResponseOneofCase.StatusResponse)
						{
							aPI_v1_Status_Response.MergeFrom(StatusResponse);
						}
						input.ReadMessage(aPI_v1_Status_Response);
						StatusResponse = aPI_v1_Status_Response;
						break;
					}
					case 954u:
					{
						API_v1_Theme_Response aPI_v1_Theme_Response = new API_v1_Theme_Response();
						if (responseCase_ == ResponseOneofCase.ThemeResponse)
						{
							aPI_v1_Theme_Response.MergeFrom(ThemeResponse);
						}
						input.ReadMessage(aPI_v1_Theme_Response);
						ThemeResponse = aPI_v1_Theme_Response;
						break;
					}
					case 962u:
					{
						API_v1_Timer_Response aPI_v1_Timer_Response = new API_v1_Timer_Response();
						if (responseCase_ == ResponseOneofCase.TimerResponse)
						{
							aPI_v1_Timer_Response.MergeFrom(TimerResponse);
						}
						input.ReadMessage(aPI_v1_Timer_Response);
						TimerResponse = aPI_v1_Timer_Response;
						break;
					}
					case 970u:
					{
						API_v1_Transport_Response aPI_v1_Transport_Response = new API_v1_Transport_Response();
						if (responseCase_ == ResponseOneofCase.TransportResponse)
						{
							aPI_v1_Transport_Response.MergeFrom(TransportResponse);
						}
						input.ReadMessage(aPI_v1_Transport_Response);
						TransportResponse = aPI_v1_Transport_Response;
						break;
					}
					case 978u:
					{
						API_v1_Trigger_Response aPI_v1_Trigger_Response = new API_v1_Trigger_Response();
						if (responseCase_ == ResponseOneofCase.TriggerResponse)
						{
							aPI_v1_Trigger_Response.MergeFrom(TriggerResponse);
						}
						input.ReadMessage(aPI_v1_Trigger_Response);
						TriggerResponse = aPI_v1_Trigger_Response;
						break;
					}
					case 986u:
					{
						API_v1_Video_Inputs_Response aPI_v1_Video_Inputs_Response = new API_v1_Video_Inputs_Response();
						if (responseCase_ == ResponseOneofCase.VideoInputsResponse)
						{
							aPI_v1_Video_Inputs_Response.MergeFrom(VideoInputsResponse);
						}
						input.ReadMessage(aPI_v1_Video_Inputs_Response);
						VideoInputsResponse = aPI_v1_Video_Inputs_Response;
						break;
					}
					case 994u:
					{
						API_v1_Announcement_Response aPI_v1_Announcement_Response = new API_v1_Announcement_Response();
						if (responseCase_ == ResponseOneofCase.AnnouncementResponse)
						{
							aPI_v1_Announcement_Response.MergeFrom(AnnouncementResponse);
						}
						input.ReadMessage(aPI_v1_Announcement_Response);
						AnnouncementResponse = aPI_v1_Announcement_Response;
						break;
					}
					case 1602u:
					{
						API_v1_Error_Response aPI_v1_Error_Response = new API_v1_Error_Response();
						if (responseCase_ == ResponseOneofCase.ErrorResponse)
						{
							aPI_v1_Error_Response.MergeFrom(ErrorResponse);
						}
						input.ReadMessage(aPI_v1_Error_Response);
						ErrorResponse = aPI_v1_Error_Response;
						break;
					}
					case 1610u:
						UpdateIdentifier = input.ReadString();
						break;
					}
				}
			}
		}
	}

	private static readonly MessageParser<NetworkAPI_v1> _parser = new MessageParser<NetworkAPI_v1>(() => new NetworkAPI_v1());

	private UnknownFieldSet _unknownFields;

	public const int ActionFieldNumber = 1;

	private object command_;

	private CommandOneofCase commandCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<NetworkAPI_v1> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiV1Reflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Action Action
	{
		get
		{
			if (commandCase_ != CommandOneofCase.Action)
			{
				return null;
			}
			return (Types.Action)command_;
		}
		set
		{
			command_ = value;
			commandCase_ = ((value != null) ? CommandOneofCase.Action : CommandOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public CommandOneofCase CommandCase => commandCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkAPI_v1()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkAPI_v1(NetworkAPI_v1 other)
		: this()
	{
		if (other.CommandCase == CommandOneofCase.Action)
		{
			Action = other.Action.Clone();
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public NetworkAPI_v1 Clone()
	{
		return new NetworkAPI_v1(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearCommand()
	{
		commandCase_ = CommandOneofCase.None;
		command_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as NetworkAPI_v1);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(NetworkAPI_v1 other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Action, other.Action))
		{
			return false;
		}
		if (CommandCase != other.CommandCase)
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
		if (commandCase_ == CommandOneofCase.Action)
		{
			num ^= Action.GetHashCode();
		}
		num ^= (int)commandCase_;
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
		if (commandCase_ == CommandOneofCase.Action)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Action);
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
		if (commandCase_ == CommandOneofCase.Action)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Action);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(NetworkAPI_v1 other)
	{
		if (other == null)
		{
			return;
		}
		if (other.CommandCase == CommandOneofCase.Action)
		{
			if (Action == null)
			{
				Action = new Types.Action();
			}
			Action.MergeFrom(other.Action);
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
			Types.Action action = new Types.Action();
			if (commandCase_ == CommandOneofCase.Action)
			{
				action.MergeFrom(Action);
			}
			input.ReadMessage(action);
			Action = action;
		}
	}
}
