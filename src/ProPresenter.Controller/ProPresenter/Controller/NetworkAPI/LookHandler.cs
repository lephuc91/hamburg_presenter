using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Google.Protobuf.Collections;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Looks;
using ProPresenter.DO.Masks;
using ProPresenter.DO.Themes;

namespace ProPresenter.Controller.NetworkAPI;

public static class LookHandler
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public uint index;
	}

	[CompilerGenerated]
	private sealed class _003CScreens_003Ed__13 : IEnumerable<API_v1_Screen>, IEnumerable, IEnumerator<API_v1_Screen>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private API_v1_Screen _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<ScreenLook> screenLooks;

		public IEnumerable<ScreenLook> _003C_003E3__screenLooks;

		private IEnumerator<ScreenLook> _003C_003E7__wrap1;

		API_v1_Screen IEnumerator<API_v1_Screen>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CScreens_003Ed__13(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E7__wrap1 = screenLooks.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				if (_003C_003E7__wrap1.MoveNext())
				{
					ScreenLook current = _003C_003E7__wrap1.Current;
					_003C_003E2__current = Screen(current);
					_003C_003E1__state = 1;
					return true;
				}
				_003C_003Em__Finally1();
				_003C_003E7__wrap1 = null;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			if (_003C_003E7__wrap1 != null)
			{
				_003C_003E7__wrap1.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<API_v1_Screen> IEnumerable<API_v1_Screen>.GetEnumerator()
		{
			_003CScreens_003Ed__13 _003CScreens_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CScreens_003Ed__ = this;
			}
			else
			{
				_003CScreens_003Ed__ = new _003CScreens_003Ed__13(0);
			}
			_003CScreens_003Ed__.screenLooks = _003C_003E3__screenLooks;
			return _003CScreens_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<API_v1_Screen>)this).GetEnumerator();
		}
	}

	internal static NetworkAPI_v1? Handle(IAudienceLookCollection looks, LiveAudienceLook liveLook, ITriggering triggering, IUiDispatcher dispatcher, API_v1_Looks_Request request, IThemeCollection themes, IMaskCollection masks)
	{
		if (request != null)
		{
			if (request.Looks != null)
			{
				return GetLooks(looks);
			}
			if (request.CreateLook != null)
			{
				return CreateLook(looks, dispatcher, request.CreateLook, themes, masks);
			}
			if (request.GetCurrentLook != null)
			{
				return GetCurrentLook(looks, liveLook);
			}
			if (request.PutCurrentLook != null)
			{
				return PutCurrentLook(looks, liveLook, dispatcher, request.PutCurrentLook, themes, masks);
			}
			if (request.GetLook != null)
			{
				return GetLook(looks, request.GetLook);
			}
			if (request.PutLook != null)
			{
				return PutLook(looks, dispatcher, request.PutLook, themes, masks);
			}
			if (request.DeleteLook != null)
			{
				return DeleteLook(looks, dispatcher, request.DeleteLook);
			}
			if (request.TriggerLook != null)
			{
				return TriggerLook(looks, triggering, request.TriggerLook);
			}
		}
		return null;
	}

	private static NetworkAPI_v1 GetLooks(IEnumerable<AudienceLook> looks)
	{
		return UpdateLooks(looks);
	}

	public static NetworkAPI_v1 UpdateLooks(IEnumerable<AudienceLook> looks)
	{
		_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass2_0();
		CS_0024_003C_003E8__locals2.index = 0u;
		NetworkAPI_v1 networkAPI_v = new NetworkAPI_v1();
		networkAPI_v.StreamingAction("/v1/looks").LooksResponse().Looks(getLooks(looks));
		return networkAPI_v;
		[IteratorStateMachine(typeof(_003C_003Ec__DisplayClass2_0._003C_003CUpdateLooks_003Eg__getLooks_007C0_003Ed))]
		IEnumerable<API_v1_Look> getLooks(IEnumerable<AudienceLook> looks)
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003C_003Ec__DisplayClass2_0._003C_003CUpdateLooks_003Eg__getLooks_007C0_003Ed(-2)
			{
				_003C_003E4__this = CS_0024_003C_003E8__locals2,
				_003C_003E3__looks = looks
			};
		}
	}

	private static NetworkAPI_v1 CreateLook(IAudienceLookCollection looks, IUiDispatcher dispatcher, API_v1_Looks_Request.Types.CreateLook request, IThemeCollection themes, IMaskCollection masks)
	{
		NetworkAPI_v1 networkAPI_v = new NetworkAPI_v1();
		AudienceLook audienceLook2 = dispatcher.Invoke(delegate
		{
			AudienceLook audienceLook = looks.Add(request.Look.Id.Name);
			UpdateLook(audienceLook, request.Look.Id.Name, request.Look.Screens, themes, masks);
			return audienceLook;
		});
		if (audienceLook2 != null)
		{
			networkAPI_v.Action().LooksResponse().CreateLook = new API_v1_Looks_Response.Types.CreateLook
			{
				Look = Look(new Identification(audienceLook2.ID, audienceLook2.Name, (uint)(looks.Count - 1)), Screens(audienceLook2.ScreenLooks))
			};
		}
		else
		{
			networkAPI_v.Action().InternalError();
		}
		return networkAPI_v;
	}

	private static NetworkAPI_v1 GetCurrentLook(IEnumerable<AudienceLook> looks, LiveAudienceLook liveLook)
	{
		NetworkAPI_v1 networkAPI_v = new NetworkAPI_v1();
		networkAPI_v.Action().LooksResponse().GetCurrentLook = new API_v1_Looks_Response.Types.GetCurrentLook
		{
			Look = Look(liveLook, looks)
		};
		networkAPI_v.Action().UpdateIdentifier = "/v1/look/current";
		return networkAPI_v;
	}

	internal static NetworkAPI_v1 CurrentLookUpdated(API_v1_Look currentLook)
	{
		NetworkAPI_v1 networkAPI_v = new NetworkAPI_v1();
		networkAPI_v.Action().LooksResponse().GetCurrentLook = new API_v1_Looks_Response.Types.GetCurrentLook
		{
			Look = currentLook
		};
		networkAPI_v.Action().UpdateIdentifier = "/v1/look/current";
		return networkAPI_v;
	}

	private static NetworkAPI_v1 PutCurrentLook(IEnumerable<AudienceLook> looks, LiveAudienceLook liveLook, IUiDispatcher dispatcher, API_v1_Looks_Request.Types.PutCurrentLook lookUpdate, IThemeCollection themes, IMaskCollection masks)
	{
		NetworkAPI_v1 networkAPI_v = new NetworkAPI_v1();
		dispatcher.Invoke(delegate
		{
			UpdateLook(liveLook.Live, lookUpdate.Look.Id.Name, lookUpdate.Look.Screens, themes, masks);
		});
		networkAPI_v.Action().LooksResponse().PutCurrentLook = new API_v1_Looks_Response.Types.PutCurrentLook
		{
			Look = Look(liveLook, looks)
		};
		return networkAPI_v;
	}

	private static NetworkAPI_v1 GetLook(IEnumerable<AudienceLook> looks, API_v1_Looks_Request.Types.GetLook id)
	{
		NetworkAPI_v1 networkAPI_v = new NetworkAPI_v1();
		if (Common.TryFindItem(looks, id.Id, out ItemPacket<AudienceLook> packet))
		{
			networkAPI_v.Action().LooksResponse().GetLook = new API_v1_Looks_Response.Types.GetLook
			{
				Look = Look(packet, Screens(packet.Item.ScreenLooks))
			};
		}
		else
		{
			networkAPI_v.Action().NotFound();
		}
		return networkAPI_v;
	}

	private static NetworkAPI_v1 PutLook(IEnumerable<AudienceLook> looks, IUiDispatcher dispatcher, API_v1_Looks_Request.Types.PutLook lookUpdate, IThemeCollection themes, IMaskCollection masks)
	{
		NetworkAPI_v1 networkAPI_v = new NetworkAPI_v1();
		if (Common.TryFindItem(looks, lookUpdate.Id, out ItemPacket<AudienceLook> packet))
		{
			dispatcher.Invoke(delegate
			{
				UpdateLook(packet.Item, lookUpdate.Look.Id.Name, lookUpdate.Look.Screens, themes, masks);
			});
			networkAPI_v.Action().LooksResponse().PutLook = new API_v1_Looks_Response.Types.PutLook
			{
				Look = Look(new Identification(packet.ID, packet.Item.Name, packet.Index), Screens(packet.Item.ScreenLooks))
			};
		}
		else
		{
			networkAPI_v.Action().NotFound();
		}
		return networkAPI_v;
	}

	private static NetworkAPI_v1 DeleteLook(IAudienceLookCollection looks, IUiDispatcher dispatcher, API_v1_Looks_Request.Types.DeleteLook request)
	{
		NetworkAPI_v1 networkAPI_v = new NetworkAPI_v1();
		if (Common.TryFindItem(looks, request.Id, out ItemPacket<AudienceLook> packet))
		{
			dispatcher.Invoke(delegate
			{
				looks.Remove(packet.Item);
			});
			networkAPI_v.Action().LooksResponse().DeleteLook = new API_v1_Looks_Response.Types.DeleteLook();
		}
		else
		{
			networkAPI_v.Action().NotFound();
		}
		return networkAPI_v;
	}

	private static NetworkAPI_v1 TriggerLook(IAudienceLookCollection looks, ITriggering triggering, API_v1_Looks_Request.Types.TriggerLook request)
	{
		NetworkAPI_v1 networkAPI_v = new NetworkAPI_v1();
		if (Common.TryFindItem(looks, request.Id, out ItemPacket<AudienceLook> packet))
		{
			triggering.TriggerAudienceLook(packet.Item);
			networkAPI_v.Action().LooksResponse().TriggerLook = new API_v1_Looks_Response.Types.TriggerLook();
		}
		else
		{
			networkAPI_v.Action().NotFound();
		}
		return networkAPI_v;
	}

	private static API_v1_Looks_Response LooksResponse(this NetworkAPI_v1.Types.Action action)
	{
		return action.LooksResponse ?? (action.LooksResponse = new API_v1_Looks_Response());
	}

	private static API_v1_Looks_Response.Types.Looks Looks(this API_v1_Looks_Response response, IEnumerable<API_v1_Look> looks)
	{
		API_v1_Looks_Response.Types.Looks obj = new API_v1_Looks_Response.Types.Looks
		{
			Looks_ = { looks }
		};
		API_v1_Looks_Response.Types.Looks result = obj;
		response.Looks = obj;
		return result;
	}

	[IteratorStateMachine(typeof(_003CScreens_003Ed__13))]
	private static IEnumerable<API_v1_Screen> Screens(IEnumerable<ScreenLook> screenLooks)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CScreens_003Ed__13(-2)
		{
			_003C_003E3__screenLooks = screenLooks
		};
	}

	internal static API_v1_Look Look(LiveAudienceLook liveLook, IEnumerable<AudienceLook> looks)
	{
		return Look(new Identification(liveLook.Live.ID, liveLook.Live.Name, FindIndex(liveLook, looks)), Screens(liveLook.Live.ScreenLooks));
	}

	private static uint FindIndex(LiveAudienceLook liveLook, IEnumerable<AudienceLook> looks)
	{
		int num = looks.FindIndex((AudienceLook look) => liveLook.IsLive(look));
		if (num < 0)
		{
			num = looks.Count();
		}
		return (uint)num;
	}

	private static API_v1_Look Look(Identification id, IEnumerable<API_v1_Screen> screens)
	{
		return new API_v1_Look
		{
			Id = Common.ID(id),
			Screens = { screens }
		};
	}

	private static API_v1_Screen Screen(ScreenLook screenLook)
	{
		return new API_v1_Screen
		{
			VideoInput = screenLook.LiveVideoEnabled,
			Media = screenLook.BackgroundEnabled,
			Slide = screenLook.ForegroundEnabled,
			Announcements = screenLook.AnnouncementEnabled,
			Props = screenLook.PropsEnabled,
			Messages = screenLook.MessagesEnabled,
			Presentation = (screenLook.TemplateId?.ToString() ?? ""),
			Mask = (screenLook.MaskId?.ToString() ?? "")
		};
	}

	private static void UpdateLook(AudienceLook look, string name, RepeatedField<API_v1_Screen> screens, IThemeCollection themes, IMaskCollection masks)
	{
		look.Name = name;
		int num = 0;
		foreach (ScreenLook screenLook in look.ScreenLooks)
		{
			if (num < screens.Count)
			{
				UpdateScreenLook(screenLook, screens[num++], themes, masks);
				continue;
			}
			break;
		}
	}

	private static void UpdateScreenLook(ScreenLook screenLook, API_v1_Screen protoScreen, IThemeCollection themes, IMaskCollection masks)
	{
		screenLook.LiveVideoEnabled = protoScreen.VideoInput;
		screenLook.BackgroundEnabled = protoScreen.Media;
		screenLook.ForegroundEnabled = protoScreen.Slide;
		screenLook.AnnouncementEnabled = protoScreen.Announcements;
		screenLook.PropsEnabled = protoScreen.Props;
		screenLook.MessagesEnabled = protoScreen.Messages;
		Guid result;
		if (string.IsNullOrEmpty(protoScreen.Presentation))
		{
			screenLook.UpdateTemplate(null);
		}
		else if (Guid.TryParse(protoScreen.Presentation, out result))
		{
			TemplateSlide templateSlide = themes.FindTemplate(result, "", useDefault: false);
			if (templateSlide != null)
			{
				screenLook.UpdateTemplate(templateSlide);
			}
		}
		Guid id;
		if (string.IsNullOrEmpty(protoScreen.Mask))
		{
			screenLook.MaskId = null;
		}
		else if (Guid.TryParse(protoScreen.Mask, out id))
		{
			SlideCue slideCue = masks.FirstOrDefaultOf((SlideCue m) => m.ID == id);
			if (slideCue != null)
			{
				screenLook.MaskId = slideCue.ID;
			}
		}
	}
}
