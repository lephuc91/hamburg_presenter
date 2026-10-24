using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Pro.Common.Collections;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO.Media;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller.NetworkAPI;

public static class TransportHandler
{
	[CompilerGenerated]
	private sealed class _003CCurrentLayerTimes_003Ed__1 : IEnumerable<(ProLayerIndex, double)>, IEnumerable, IEnumerator<(ProLayerIndex, double)>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private (ProLayerIndex, double) _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private ITriggering triggering;

		public ITriggering _003C_003E3__triggering;

		(ProLayerIndex, double) IEnumerator<(ProLayerIndex, double)>.Current
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
		public _003CCurrentLayerTimes_003Ed__1(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = LayerTime(triggering, ProLayerIndex.PresentationBackground);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003C_003E2__current = LayerTime(triggering, ProLayerIndex.AnnouncementsBackground);
				_003C_003E1__state = 2;
				return true;
			case 2:
				_003C_003E1__state = -1;
				_003C_003E2__current = LayerTime(triggering, ProLayerIndex.Music);
				_003C_003E1__state = 3;
				return true;
			case 3:
				_003C_003E1__state = -1;
				return false;
			}
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
		IEnumerator<(ProLayerIndex, double)> IEnumerable<(ProLayerIndex, double)>.GetEnumerator()
		{
			_003CCurrentLayerTimes_003Ed__1 _003CCurrentLayerTimes_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CCurrentLayerTimes_003Ed__ = this;
			}
			else
			{
				_003CCurrentLayerTimes_003Ed__ = new _003CCurrentLayerTimes_003Ed__1(0);
			}
			_003CCurrentLayerTimes_003Ed__.triggering = _003C_003E3__triggering;
			return _003CCurrentLayerTimes_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<(ProLayerIndex, double)>)this).GetEnumerator();
		}
	}

	internal static NetworkAPI_v1 Handle(IAPIv1Service service, API_v1_Transport_Request request)
	{
		if (request != null)
		{
			API_v1_Transport_Request.Types.Play play = request.Play;
			if (play != null)
			{
				return Play(service.Triggering, play.Layer);
			}
			API_v1_Transport_Request.Types.Pause pause = request.Pause;
			if (pause != null)
			{
				return Pause(service.Triggering, pause.Layer);
			}
			API_v1_Transport_Request.Types.SkipBackward skipBackward = request.SkipBackward;
			if (skipBackward != null)
			{
				return SkipBackward(service.Triggering, skipBackward.Layer, skipBackward.Seconds);
			}
			API_v1_Transport_Request.Types.SkipForward skipForward = request.SkipForward;
			if (skipForward != null)
			{
				return SkipForward(service.Triggering, skipForward.Layer, skipForward.Seconds);
			}
			API_v1_Transport_Request.Types.GoToEnd goToEnd = request.GoToEnd;
			if (goToEnd != null)
			{
				return GoToEnd(service.Triggering, goToEnd.Layer, goToEnd.Seconds);
			}
			API_v1_Transport_Request.Types.GetTime getTime = request.GetTime;
			if (getTime != null)
			{
				return GetTime(service.Triggering, getTime.Layer);
			}
			API_v1_Transport_Request.Types.PutTime putTime = request.PutTime;
			if (putTime != null)
			{
				return UpdateTime(service.Triggering, putTime.Layer, putTime.Seconds);
			}
			API_v1_Transport_Request.Types.GetAutoAdvance getAutoAdvance = request.GetAutoAdvance;
			if (getAutoAdvance != null)
			{
				return GetAutoAdvance(service.Triggering, getAutoAdvance.Layer);
			}
			API_v1_Transport_Request.Types.DeleteAutoAdvance deleteAutoAdvance = request.DeleteAutoAdvance;
			if (deleteAutoAdvance != null)
			{
				return DeleteAutoAdvance(service.Triggering, deleteAutoAdvance.Layer);
			}
			API_v1_Transport_Request.Types.GetCurrentMedia getCurrentMedia = request.GetCurrentMedia;
			if (getCurrentMedia != null)
			{
				return GetCurrentMedia(service.Triggering, getCurrentMedia.Layer);
			}
		}
		global::_003CPrivateImplementationDetails_003E.ThrowSwitchExpressionException(request);
		NetworkAPI_v1 result = default(NetworkAPI_v1);
		return result;
	}

	[IteratorStateMachine(typeof(_003CCurrentLayerTimes_003Ed__1))]
	public static IEnumerable<(ProLayerIndex, double)> CurrentLayerTimes(ITriggering triggering)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CCurrentLayerTimes_003Ed__1(-2)
		{
			_003C_003E3__triggering = triggering
		};
	}

	private static NetworkAPI_v1 GetCurrentMedia(ITriggering triggering, API_v1_LayerType layer)
	{
		ProLayerIndex proLayerIndex = layer.ToProLayerIndex();
		TransportStatusEntry status = triggering.TransportStatus.GetStatus(proLayerIndex);
		return BuildCurrentMedia(status?.Media, status?.IsPlaying ?? false, proLayerIndex);
	}

	internal static IEnumerable<NetworkAPI_v1> MediaUpdated(MediaBase? media, bool isPlaying, ProLayerIndex layerIndex)
	{
		return BuildCurrentMedia(media, isPlaying, layerIndex)?.ToEnumerable() ?? Enumerable.Empty<NetworkAPI_v1>();
	}

	private static NetworkAPI_v1 BuildCurrentMedia(MediaBase? media, bool isPlaying, ProLayerIndex layerIndex)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			string text = GetLayerPathString(layerIndex) + "/current";
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			int num;
			object obj;
			if (media is FileMediaBase fileMediaBase)
			{
				if (fileMediaBase != null)
				{
					num = (fileMediaBase.MetadataLoaded ? 1 : 0);
					if (num != 0)
					{
						obj = (media as FileMediaBase)?.SourceFile.Filename ?? string.Empty;
						goto IL_006e;
					}
				}
				else
				{
					num = 0;
				}
			}
			else
			{
				num = 0;
			}
			obj = string.Empty;
			goto IL_006e;
			IL_006e:
			string name = (string)obj;
			string artist = ((num == 0) ? string.Empty : ((media as FileMediaBase)?.Metadata.Artist ?? string.Empty));
			double duration = ((num == 0) ? 0.0 : ((media as FileMediaBase)?.Metadata.Duration.TotalSeconds ?? 0.0));
			UUID uUID = media?.ID.ToUUID();
			v1.StreamingAction(text).TransportResponse().GetCurrentMedia = new API_v1_Transport_Response.Types.GetCurrentMedia
			{
				AudioOnly = (media is AudioMedia),
				Artist = artist,
				Duration = duration,
				IsPlaying = isPlaying,
				Uuid = (uUID?.String ?? string.Empty),
				Name = name
			};
		});
	}

	private static NetworkAPI_v1 DeleteAutoAdvance(ITriggering triggering, API_v1_LayerType layer)
	{
		triggering.CancelAutoAdvance(layer.ToProLayerIndex(foreground: true));
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().TransportResponse().PutTime = new API_v1_Transport_Response.Types.PutTime();
		});
	}

	private static NetworkAPI_v1 GetAutoAdvance(ITriggering triggering, API_v1_LayerType layer)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().TransportResponse().GetAutoAdvance = new API_v1_Transport_Response.Types.GetAutoAdvance
			{
				AutoAdvance = triggering.GetAutoAdvance(layer.ToProLayerIndex(foreground: true))
			};
		});
	}

	private static NetworkAPI_v1 UpdateTime(ITriggering triggering, API_v1_LayerType layer, double seconds)
	{
		triggering.SkipToTime(layer.ToProLayerIndex(), (int)seconds);
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().TransportResponse().PutTime = new API_v1_Transport_Response.Types.PutTime();
		});
	}

	private static NetworkAPI_v1 GetTime(ITriggering triggering, API_v1_LayerType layer)
	{
		return LayerCurrentTimeUpdate(LayerTime(triggering, layer.ToProLayerIndex()));
	}

	private static NetworkAPI_v1 GoToEnd(ITriggering triggering, API_v1_LayerType layer, double seconds)
	{
		ProLayerIndex proLayerIndex = layer.ToProLayerIndex();
		TransportStatusEntry status = triggering.TransportStatus.GetStatus(proLayerIndex);
		if ((object)status != null)
		{
			double num = status.Elapsed + status.Remaining;
			triggering.SkipToTime(proLayerIndex, (int)(num - seconds));
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().TransportResponse().GoToEnd = new API_v1_Transport_Response.Types.GoToEnd();
		});
	}

	private static NetworkAPI_v1 SkipForward(ITriggering triggering, API_v1_LayerType layer, double seconds)
	{
		ProLayerIndex proLayerIndex = layer.ToProLayerIndex();
		TransportStatusEntry status = triggering.TransportStatus.GetStatus(proLayerIndex);
		if ((object)status != null)
		{
			triggering.SkipToTime(proLayerIndex, (int)(status.Elapsed + seconds));
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().TransportResponse().SkipForward = new API_v1_Transport_Response.Types.SkipForward();
		});
	}

	private static NetworkAPI_v1 SkipBackward(ITriggering triggering, API_v1_LayerType layer, double seconds)
	{
		ProLayerIndex proLayerIndex = layer.ToProLayerIndex();
		TransportStatusEntry status = triggering.TransportStatus.GetStatus(proLayerIndex);
		if ((object)status != null)
		{
			triggering.SkipToTime(proLayerIndex, (int)(status.Elapsed - seconds));
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().TransportResponse().SkipBackward = new API_v1_Transport_Response.Types.SkipBackward();
		});
	}

	private static NetworkAPI_v1 Pause(ITriggering triggering, API_v1_LayerType layer)
	{
		triggering.Pause(layer.ToProLayerIndex());
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().TransportResponse().Pause = new API_v1_Transport_Response.Types.Pause();
		});
	}

	private static NetworkAPI_v1 Play(ITriggering triggering, API_v1_LayerType layer)
	{
		triggering.Play(layer.ToProLayerIndex());
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().TransportResponse().Play = new API_v1_Transport_Response.Types.Play();
		});
	}

	private static API_v1_Transport_Response TransportResponse(this NetworkAPI_v1.Types.Action action)
	{
		return action.TransportResponse = new API_v1_Transport_Response();
	}

	private static (ProLayerIndex, double) LayerTime(ITriggering triggering, ProLayerIndex layerIndex)
	{
		return (layerIndex, triggering.TransportStatus.GetStatus(layerIndex)?.Elapsed ?? 0.0);
	}

	internal static NetworkAPI_v1 LayerCurrentTimeUpdate((ProLayerIndex, double) x)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction(GetLayerPathString(x.Item1) + "/time").TransportResponse().GetTime = new API_v1_Transport_Response.Types.GetTime
			{
				Seconds = x.Item2
			};
		});
	}

	private static ProLayerIndex ToProLayerIndex(this API_v1_LayerType layer, bool foreground = false)
	{
		return layer switch
		{
			API_v1_LayerType.Slide => (!foreground) ? ProLayerIndex.PresentationBackground : ProLayerIndex.PresentationForeground, 
			API_v1_LayerType.Announcements => foreground ? ProLayerIndex.AnnouncementsForeground : ProLayerIndex.AnnouncementsBackground, 
			API_v1_LayerType.Audio => ProLayerIndex.Music, 
			_ => ProLayerIndex.Invalid, 
		};
	}

	private static string GetLayerPathString(ProLayerIndex layer)
	{
		return layer switch
		{
			ProLayerIndex.PresentationBackground => "v1/transport/presentation", 
			ProLayerIndex.AnnouncementsBackground => "v1/transport/announcement", 
			ProLayerIndex.Music => "v1/transport/audio", 
			_ => string.Empty, 
		};
	}
}
