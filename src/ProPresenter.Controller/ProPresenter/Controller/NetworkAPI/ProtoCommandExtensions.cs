using System;
using System.Collections.Generic;
using System.Linq;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Messages;

namespace ProPresenter.Controller.NetworkAPI;

public static class ProtoCommandExtensions
{
	public static Pro.SerializationInterop.RVProtoData.NetworkAPI Build(Action<Pro.SerializationInterop.RVProtoData.NetworkAPI> action)
	{
		Pro.SerializationInterop.RVProtoData.NetworkAPI networkAPI = new Pro.SerializationInterop.RVProtoData.NetworkAPI();
		action(networkAPI);
		return networkAPI;
	}

	public static void Transport(this Pro.SerializationInterop.RVProtoData.NetworkAPI command, Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.TransportActionOneofCase transportType, Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.Types.TransportLayer layerType, int seconds = 0)
	{
		command.Action = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action
		{
			Transport = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport()
		};
		command.Action.Transport.Layer = layerType;
		switch (transportType)
		{
		case Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.TransportActionOneofCase.Play:
			command.Action.Transport.Play = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.Types.Play();
			break;
		case Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.TransportActionOneofCase.Pause:
			command.Action.Transport.Pause = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.Types.Pause();
			break;
		case Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.TransportActionOneofCase.SkipBackward:
			command.Action.Transport.SkipBackward = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.Types.SkipBackward
			{
				Seconds = seconds
			};
			break;
		case Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.TransportActionOneofCase.SkipForward:
			command.Action.Transport.SkipForward = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.Types.SkipForward
			{
				Seconds = seconds
			};
			break;
		case Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.TransportActionOneofCase.GoToEnd:
			command.Action.Transport.GoToEnd = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Transport.Types.GoToEnd
			{
				SecondsToEnd = seconds
			};
			break;
		}
	}

	public static void ClearLayer(this Pro.SerializationInterop.RVProtoData.NetworkAPI command, Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Clear.Types.Layer layerType)
	{
		command.Action = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action
		{
			Clear = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Clear
			{
				Layer = layerType
			}
		};
	}

	public static void ClearGroup(this Pro.SerializationInterop.RVProtoData.NetworkAPI command, string name)
	{
		command.Action = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action
		{
			Clear = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Clear
			{
				GroupIdentifier = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.IndexOrNameIdentifier
				{
					Name = name
				}
			}
		};
	}

	public static void ClearGroup(this Pro.SerializationInterop.RVProtoData.NetworkAPI command, int index)
	{
		command.Action = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action
		{
			Clear = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Clear
			{
				GroupIdentifier = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.IndexOrNameIdentifier
				{
					Index = index
				}
			}
		};
	}

	public static void Look(this Pro.SerializationInterop.RVProtoData.NetworkAPI command, int index)
	{
		command.Action = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action
		{
			Look = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Look
			{
				Identifier = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.IndexOrNameIdentifier
				{
					Index = index
				}
			}
		};
	}

	public static void Macro(this Pro.SerializationInterop.RVProtoData.NetworkAPI command, int index)
	{
		command.Action = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action
		{
			Macro = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Macro
			{
				Identifier = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.IndexOrNameIdentifier
				{
					Index = index
				}
			}
		};
	}

	public static void ClearMessage(this Pro.SerializationInterop.RVProtoData.NetworkAPI command, int index)
	{
		command.Action = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action
		{
			Message = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Message
			{
				Clear = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Message.Types.ClearMessage
				{
					Identifier = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.IndexOrNameIdentifier
					{
						Index = index
					}
				}
			}
		};
	}

	public static void TriggerMessage(this Pro.SerializationInterop.RVProtoData.NetworkAPI command, int index, MessageTokenCollection tokens, int clientId)
	{
		command.Action = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action
		{
			TwoStepTrigger = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_TwoStepTrigger
			{
				Id = (ulong)clientId,
				Message = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Message.Types.TriggerMessage
				{
					Identifier = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.IndexOrNameIdentifier
					{
						Index = index
					}
				}
			}
		};
		command.Action.TwoStepTrigger.Message.TokenValues.AddRange(tokens.SerializeTokenValues());
	}

	public static void ClearProp(this Pro.SerializationInterop.RVProtoData.NetworkAPI command, int index)
	{
		command.Action = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action
		{
			Prop = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Prop
			{
				Clear = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Prop.Types.ClearProp
				{
					Identifier = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.IndexOrNameIdentifier
					{
						Index = index
					}
				}
			}
		};
	}

	public static void TriggerProp(this Pro.SerializationInterop.RVProtoData.NetworkAPI command, int index, int clientId)
	{
		command.Action = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action
		{
			TwoStepTrigger = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_TwoStepTrigger
			{
				Id = (ulong)clientId,
				Prop = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Prop.Types.TriggerProp
				{
					Identifier = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.IndexOrNameIdentifier
					{
						Index = index
					}
				}
			}
		};
	}

	public static void ChangeStageLayout(this Pro.SerializationInterop.RVProtoData.NetworkAPI command, IEnumerable<(int, int)> _assignments)
	{
		command.Action = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action
		{
			Stage = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Stage
			{
				Layouts = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Stage.Types.StageLayouts()
			}
		};
		foreach (var (index, index2) in _assignments)
		{
			command.Action.Stage.Layouts.Layouts.Add(new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.IndexOrNameIdentifierPair
			{
				Key = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.IndexOrNameIdentifier
				{
					Index = index
				},
				Value = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.IndexOrNameIdentifier
				{
					Index = index2
				}
			});
		}
	}

	public static void HideStageMessage(this Pro.SerializationInterop.RVProtoData.NetworkAPI command)
	{
		command.Action = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action
		{
			Stage = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Stage
			{
				Message = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Stage.Types.StageMessage
				{
					HideMessage = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Stage.Types.StageMessage.Types.HideMessage()
				}
			}
		};
	}

	public static void ShowStageMessage(this Pro.SerializationInterop.RVProtoData.NetworkAPI command, string message)
	{
		command.Action = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action
		{
			Stage = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Stage
			{
				Message = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Stage.Types.StageMessage
				{
					ShowMessage = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Stage.Types.StageMessage.Types.ShowMessage
					{
						Message = (message ?? string.Empty)
					}
				}
			}
		};
	}

	public static void ConfigureTimer(this Pro.SerializationInterop.RVProtoData.NetworkAPI command, int index, Timer.Types.Configuration? configuration)
	{
		command.Action = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action
		{
			Timer = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Timer
			{
				Configure = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Timer.Types.ConfigureTimer
				{
					Identifier = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.IndexOrNameIdentifier
					{
						Index = index
					},
					Configuration = configuration
				}
			}
		};
	}

	public static void ResetTimer(this Pro.SerializationInterop.RVProtoData.NetworkAPI command, int index)
	{
		command.Action = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action
		{
			Timer = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Timer
			{
				Reset = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Timer.Types.ResetTimer
				{
					Identifier = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.IndexOrNameIdentifier
					{
						Index = index
					}
				}
			}
		};
	}

	public static void StartTimer(this Pro.SerializationInterop.RVProtoData.NetworkAPI command, int index)
	{
		command.Action = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action
		{
			Timer = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Timer
			{
				Start = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Timer.Types.StartTimer
				{
					Identifier = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.IndexOrNameIdentifier
					{
						Index = index
					}
				}
			}
		};
	}

	public static void StopTimer(this Pro.SerializationInterop.RVProtoData.NetworkAPI command, int index)
	{
		command.Action = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action
		{
			Timer = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Timer
			{
				Stop = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Timer.Types.StopTimer
				{
					Identifier = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.IndexOrNameIdentifier
					{
						Index = index
					}
				}
			}
		};
	}

	public static void AudioTrigger(this Pro.SerializationInterop.RVProtoData.NetworkAPI command, int[] path, int clientId)
	{
		command.Action = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action
		{
			TwoStepTrigger = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_TwoStepTrigger
			{
				Id = (ulong)clientId,
				Audio = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Trigger.Types.Audio()
			}
		};
		command.Action.TwoStepTrigger.Audio.IndexPathComponents.AddRange(path.Select((int p) => new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.IndexOrNameIdentifier
		{
			Index = p
		}));
	}

	public static void LibraryPlaylistTrigger(this Pro.SerializationInterop.RVProtoData.NetworkAPI command, int[] path, int clientId)
	{
		command.Action = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action
		{
			TwoStepTrigger = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_TwoStepTrigger
			{
				Id = (ulong)clientId,
				Presentation = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Trigger.Types.Presentation
				{
					PlaylistIndexPath = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Trigger.Types.Presentation.Types.PlaylistPresentation()
				}
			}
		};
		command.Action.TwoStepTrigger.Presentation.PlaylistIndexPath.IndexPathComponents.AddRange(path.Select((int p) => new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.IndexOrNameIdentifier
		{
			Index = p
		}));
	}

	public static void LibraryTrigger(this Pro.SerializationInterop.RVProtoData.NetworkAPI command, int library, int presentation, int slide, int clientId)
	{
		command.Action = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action
		{
			TwoStepTrigger = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_TwoStepTrigger
			{
				Id = (ulong)clientId,
				Presentation = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Trigger.Types.Presentation
				{
					LibraryIndexPath = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Trigger.Types.Presentation.Types.LibraryPresentation
					{
						LibraryComponent = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.IndexOrNameIdentifier
						{
							Index = library
						},
						PresentationComponent = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.IndexOrNameIdentifier
						{
							Index = presentation
						},
						CueComponent = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.IndexOrNameIdentifier
						{
							Index = slide
						}
					}
				}
			}
		};
	}

	public static void MediaTrigger(this Pro.SerializationInterop.RVProtoData.NetworkAPI command, int[] path, int clientId)
	{
		command.Action = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action
		{
			TwoStepTrigger = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_TwoStepTrigger
			{
				Id = (ulong)clientId,
				Media = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Trigger.Types.Media()
			}
		};
		command.Action.TwoStepTrigger.Media.IndexPathComponents.AddRange(path.Select((int p) => new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.IndexOrNameIdentifier
		{
			Index = p
		}));
	}

	public static void VideoInputTrigger(this Pro.SerializationInterop.RVProtoData.NetworkAPI command, int index, int clientId)
	{
		command.Action = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action
		{
			TwoStepTrigger = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_TwoStepTrigger
			{
				Id = (ulong)clientId,
				VideoInput = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_Trigger.Types.VideoInput
				{
					VideoInputId = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.IndexOrNameIdentifier
					{
						Index = index
					}
				}
			}
		};
	}

	public static void GroupInvite(this Pro.SerializationInterop.RVProtoData.NetworkAPI command, Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Group group, string secret, Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Group.Types.Member prospect)
	{
		command.GroupChange = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.GroupChange
		{
			Invite = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.GroupInvite
			{
				GroupInfo = group,
				Secret = secret,
				Prospect = prospect
			}
		};
	}

	public static void GroupJoin(this Pro.SerializationInterop.RVProtoData.NetworkAPI command, Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Group.Types.Member sponsor, Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Group.Types.Member prospect)
	{
		command.GroupChange = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.GroupChange
		{
			Join = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.GroupJoin
			{
				Sponsor = sponsor,
				Prospect = prospect
			}
		};
	}

	public static void GroupKick(this Pro.SerializationInterop.RVProtoData.NetworkAPI command, Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Group.Types.Member member)
	{
		command.GroupChange = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.GroupChange
		{
			Kick = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.GroupKick
			{
				Member = member
			}
		};
	}

	public static void GroupKick(this Pro.SerializationInterop.RVProtoData.NetworkAPI command)
	{
		command.GroupChange = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.GroupChange
		{
			Kick = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.GroupKick()
		};
	}

	public static void PrerollComplete(this Pro.SerializationInterop.RVProtoData.NetworkAPI command, int clientId, bool failed)
	{
		command.Action = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action
		{
			PrerollComplete = new Pro.SerializationInterop.RVProtoData.NetworkAPI.Types.Action.Types.API_PrerollComplete
			{
				Id = (ulong)clientId,
				Failed = failed
			}
		};
	}
}
