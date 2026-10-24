using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Events;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Presentation;

namespace ProPresenter.Controller.NetworkAPI;

internal static class StageHandler
{
	[CompilerGenerated]
	private sealed class _003C_003CUpdateLayoutMap_003Eg__serialize_007C6_1_003Ed : IEnumerable<API_v1_StageLayoutMap.Types.Entry>, IEnumerable, IEnumerator<API_v1_StageLayoutMap.Types.Entry>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private API_v1_StageLayoutMap.Types.Entry _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private StageScreenLayoutMap map;

		public StageScreenLayoutMap _003C_003E3__map;

		private uint _003Cindex_003E5__2;

		private KeyValuePair<ScreenArrangementBase, SlideCue>[] _003C_003E7__wrap2;

		private int _003C_003E7__wrap3;

		API_v1_StageLayoutMap.Types.Entry IEnumerator<API_v1_StageLayoutMap.Types.Entry>.Current
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
		public _003C_003CUpdateLayoutMap_003Eg__serialize_007C6_1_003Ed(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E7__wrap2 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
				_003Cindex_003E5__2++;
				goto IL_00b8;
			}
			_003C_003E1__state = -1;
			_003Cindex_003E5__2 = 0u;
			_003C_003E7__wrap2 = map.ToArray();
			_003C_003E7__wrap3 = 0;
			goto IL_00c6;
			IL_00b8:
			_003C_003E7__wrap3++;
			goto IL_00c6;
			IL_00c6:
			if (_003C_003E7__wrap3 < _003C_003E7__wrap2.Length)
			{
				KeyValuePair<ScreenArrangementBase, SlideCue> keyValuePair = _003C_003E7__wrap2[_003C_003E7__wrap3];
				var (screenArrangementBase2, slideCue2) = (KeyValuePair<ScreenArrangementBase, SlideCue>)(ref keyValuePair);
				if (screenArrangementBase2 != null && slideCue2 != null)
				{
					_003C_003E2__current = new API_v1_StageLayoutMap.Types.Entry
					{
						Screen = Common.ID(screenArrangementBase2, _003Cindex_003E5__2),
						Layout = Common.ID(slideCue2, _003Cindex_003E5__2)
					};
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_00b8;
			}
			_003C_003E7__wrap2 = null;
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<API_v1_StageLayoutMap.Types.Entry> IEnumerable<API_v1_StageLayoutMap.Types.Entry>.GetEnumerator()
		{
			_003C_003CUpdateLayoutMap_003Eg__serialize_007C6_1_003Ed _003C_003CUpdateLayoutMap_003Eg__serialize_007C6_1_003Ed;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003C_003CUpdateLayoutMap_003Eg__serialize_007C6_1_003Ed = this;
			}
			else
			{
				_003C_003CUpdateLayoutMap_003Eg__serialize_007C6_1_003Ed = new _003C_003CUpdateLayoutMap_003Eg__serialize_007C6_1_003Ed(0);
			}
			_003C_003CUpdateLayoutMap_003Eg__serialize_007C6_1_003Ed.map = _003C_003E3__map;
			return _003C_003CUpdateLayoutMap_003Eg__serialize_007C6_1_003Ed;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<API_v1_StageLayoutMap.Types.Entry>)this).GetEnumerator();
		}
	}

	internal static NetworkAPI_v1 Handle(IAPIv1Service service, API_v1_Stage_Request request)
	{
		if (request != null)
		{
			if (request.GetMessage != null)
			{
				return GetMessage();
			}
			API_v1_Stage_Request.Types.PutMessage putMessage = request.PutMessage;
			if (putMessage != null)
			{
				return PutMessage(service.Triggering, putMessage.Message);
			}
			if (request.DeleteMessage != null)
			{
				return DeleteMessage(service.Triggering);
			}
			if (request.GetLayoutMap != null)
			{
				return GetLayoutMap(service.ScreenLayoutMap);
			}
			API_v1_Stage_Request.Types.SetLayoutMap setLayoutMap = request.SetLayoutMap;
			if (setLayoutMap != null)
			{
				return SetLayoutMap(service.ScreenLayoutMap, service.StageScreens, service.StageLayouts, service.Dependencies.UiDispatcher, setLayoutMap.Map.Entries);
			}
			if (request.GetScreens != null)
			{
				return GetScreens(service.StageScreens);
			}
			API_v1_Stage_Request.Types.GetScreenLayout getScreenLayout = request.GetScreenLayout;
			if (getScreenLayout != null)
			{
				return GetScreenLayout(service.ScreenLayoutMap, service.StageLayouts, getScreenLayout.Id);
			}
			API_v1_Stage_Request.Types.SetScreenLayout setScreenLayout = request.SetScreenLayout;
			if (setScreenLayout != null)
			{
				return SetScreenLayout(service.ScreenLayoutMap, service.StageScreens, service.StageLayouts, service.Dependencies.UiDispatcher, setScreenLayout.Id, setScreenLayout.Layout);
			}
			if (request.GetLayouts != null)
			{
				return GetLayouts(service.StageLayouts);
			}
			API_v1_Stage_Request.Types.DeleteLayout deleteLayout = request.DeleteLayout;
			if (deleteLayout != null)
			{
				return DeleteLayout(service.StageLayouts, service.Dependencies.UiDispatcher, deleteLayout.Id);
			}
			API_v1_Stage_Request.Types.GetLayoutThumbnail getLayoutThumbnail = request.GetLayoutThumbnail;
			if (getLayoutThumbnail != null)
			{
				return GetLayoutThumbnail(service.StageLayouts, getLayoutThumbnail.Id, getLayoutThumbnail.Quality);
			}
		}
		global::_003CPrivateImplementationDetails_003E.ThrowSwitchExpressionException(request);
		NetworkAPI_v1 result = default(NetworkAPI_v1);
		return result;
	}

	private static NetworkAPI_v1 GetMessage()
	{
		NetworkAPI_v1 v2 = Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().InternalError();
		});
		StageMessageStateRequest.Publish(delegate(StageMessageState s)
		{
			if ((object)s != null)
			{
				v2 = GetMessage(s);
			}
		});
		return v2;
	}

	internal static NetworkAPI_v1 GetMessage(StageMessageState state)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction("v1/stage/message").StageResponse().GetMessage = new API_v1_Stage_Response.Types.GetMessage
			{
				Message = (state.IsShowing ? state.Message : string.Empty)
			};
		});
	}

	private static NetworkAPI_v1 PutMessage(ITriggering triggering, string message)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			triggering.SendStageMessage(message);
			v1.Action().StageResponse().PutMessage = new API_v1_Stage_Response.Types.PutMessage();
		});
	}

	private static NetworkAPI_v1 DeleteMessage(ITriggering triggering)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			triggering.HideStageMessage();
			v1.Action().StageResponse().DeleteMessage = new API_v1_Stage_Response.Types.DeleteMessage();
		});
	}

	internal static NetworkAPI_v1 GetLayoutMap(StageScreenLayoutMap screenLayoutMap)
	{
		return UpdateLayoutMap(screenLayoutMap);
	}

	internal static NetworkAPI_v1 UpdateLayoutMap(StageScreenLayoutMap screenLayoutMap)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction("/v1/stage/layout_map").StageResponse().GetLayoutMap = new API_v1_Stage_Response.Types.GetLayoutMap
			{
				Map = new API_v1_StageLayoutMap
				{
					Entries = { serialize(screenLayoutMap) }
				}
			};
		});
		[IteratorStateMachine(typeof(_003C_003CUpdateLayoutMap_003Eg__serialize_007C6_1_003Ed))]
		static IEnumerable<API_v1_StageLayoutMap.Types.Entry> serialize(StageScreenLayoutMap map)
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003C_003CUpdateLayoutMap_003Eg__serialize_007C6_1_003Ed(-2)
			{
				_003C_003E3__map = map
			};
		}
	}

	private static NetworkAPI_v1 SetLayoutMap(StageScreenLayoutMap screenLayoutMap, ScreenArrangementCollectionBase screens, StagePresentation layouts, IUiDispatcher dispatcher, IEnumerable<API_v1_StageLayoutMap.Types.Entry> entries)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			foreach (var item2 in entries.Enumerate())
			{
				API_v1_StageLayoutMap.Types.Entry item = item2.Item1;
				if (!Common.TryFindItem(screens, item.Screen, out ItemPacket<ScreenArrangementBase> screen) || !Common.TryFindItem(layouts.DefaultArrangement.ArrangedCues.Select((ArrangedCue c) => c.Source), item.Layout, out ItemPacket<SlideCue> layout))
				{
					v1.Action().NotFound();
					return;
				}
				dispatcher.Invoke(delegate
				{
					screenLayoutMap.AssignScreen(screen.Item, layout.Item);
				});
			}
			v1.Action().StageResponse().SetLayoutMap = new API_v1_Stage_Response.Types.SetLayoutMap();
		});
	}

	private static NetworkAPI_v1 GetScreens(ScreenArrangementCollectionBase screens)
	{
		return UpdateScreens(screens);
	}

	public static NetworkAPI_v1 UpdateScreens(ScreenArrangementCollectionBase screens)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction("/v1/stage/screens").StageResponse().GetScreens = new API_v1_Stage_Response.Types.GetScreens
			{
				Screens = { screens.ToIdentifiers() }
			};
		});
	}

	private static NetworkAPI_v1 GetScreenLayout(StageScreenLayoutMap screenLayoutMap, StagePresentation layouts, string id)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(screenLayoutMap.Keys, id, out ItemPacket<ScreenArrangementBase> packet))
			{
				SlideCue slideCue = screenLayoutMap[packet.Item];
				IEnumerable<SlideCue> source = layouts.DefaultArrangement.ArrangedCues.Select((ArrangedCue c) => c.Source);
				if (source.Contains(slideCue))
				{
					v1.Action().StageResponse().GetScreenLayout = new API_v1_Stage_Response.Types.GetScreenLayout
					{
						Id = Common.ID(slideCue, (uint)source.IndexOf(slideCue))
					};
				}
				else
				{
					v1.Action().NotFound();
				}
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static NetworkAPI_v1 SetScreenLayout(StageScreenLayoutMap screenLayoutMap, ScreenArrangementCollectionBase screens, StagePresentation layouts, IUiDispatcher dispatcher, string screenID, string layoutID)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(screens, screenID, out ItemPacket<ScreenArrangementBase> screen) && Common.TryFindItem(layouts.DefaultArrangement.ArrangedCues.Select((ArrangedCue c) => c.Source), layoutID, out ItemPacket<SlideCue> layout))
			{
				dispatcher.Invoke(delegate
				{
					screenLayoutMap.AssignScreen(screen.Item, layout.Item);
				});
				v1.Action().StageResponse().SetScreenLayout = new API_v1_Stage_Response.Types.SetScreenLayout();
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static NetworkAPI_v1 GetLayouts(StagePresentation layouts)
	{
		return UpdateLayouts(layouts);
	}

	public static NetworkAPI_v1 UpdateLayouts(StagePresentation layouts)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction("/v1/stage/layouts").StageResponse().GetLayouts = new API_v1_Stage_Response.Types.GetLayouts
			{
				Layouts = { from id in layouts.DefaultArrangement.ArrangedCues.Select((ArrangedCue c) => c.Source).ToIdentifiers()
					select new API_v1_Stage_Response.Types.GetLayouts.Types.Layout
					{
						Id = id
					} }
			};
		});
	}

	private static NetworkAPI_v1 DeleteLayout(StagePresentation stageLayouts, IUiDispatcher dispatcher, string id)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(stageLayouts.DefaultArrangement.ArrangedCues.Select((ArrangedCue c) => c.Source), id, out ItemPacket<SlideCue> packet))
			{
				dispatcher.Invoke(delegate
				{
					stageLayouts.RemoveCue(packet.Item);
				});
				v1.Action().StageResponse().DeleteLayout = new API_v1_Stage_Response.Types.DeleteLayout();
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static NetworkAPI_v1 GetLayoutThumbnail(StagePresentation stageLayouts, string id, int quality)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(stageLayouts.DefaultArrangement.ArrangedCues.Select((ArrangedCue c) => c.Source), id, out ItemPacket<SlideCue> packet))
			{
				SlideCue item = packet.Item;
				v1.Action().StageResponse().GetLayoutThumbnail = new API_v1_Stage_Response.Types.GetLayoutThumbnail
				{
					Data = item.GetThumbnail(stageLayouts.UseBackgroundColor ? stageLayouts.BackgroundColor : default(System.Windows.Media.Color), quality)
				};
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static API_v1_Stage_Response StageResponse(this NetworkAPI_v1.Types.Action action)
	{
		return action.StageResponse = new API_v1_Stage_Response();
	}
}
