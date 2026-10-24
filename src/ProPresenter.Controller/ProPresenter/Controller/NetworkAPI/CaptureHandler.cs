using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Google.Protobuf.Collections;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.DO.Audio;
using Pro.DO.Storage;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Capture;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Resi;

namespace ProPresenter.Controller.NetworkAPI;

public static class CaptureHandler
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public AudioMap<Bus, StreamAudioChannel> map;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_1
	{
		public Bus input;

		public _003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals1;

		internal bool _003CSerialize_003Eb__0(StreamAudioChannel o)
		{
			return CS_0024_003C_003E8__locals1.map.IsMapped(input, o);
		}
	}

	[CompilerGenerated]
	private sealed class _003CSerialize_003Ed__4 : IEnumerable<API_v1_AudioRouting>, IEnumerable, IEnumerator<API_v1_AudioRouting>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private API_v1_AudioRouting _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private AudioMap<Bus, StreamAudioChannel> map;

		public AudioMap<Bus, StreamAudioChannel> _003C_003E3__map;

		private _003C_003Ec__DisplayClass4_0 _003C_003E8__1;

		private IEnumerator<Bus> _003C_003E7__wrap1;

		API_v1_AudioRouting IEnumerator<API_v1_AudioRouting>.Current
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
		public _003CSerialize_003Ed__4(int _003C_003E1__state)
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
			_003C_003E8__1 = null;
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
					_003C_003E8__1 = new _003C_003Ec__DisplayClass4_0();
					_003C_003E8__1.map = map;
					_003C_003E7__wrap1 = _003C_003E8__1.map.InputSet.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				if (_003C_003E7__wrap1.MoveNext())
				{
					_003C_003Ec__DisplayClass4_1 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass4_1
					{
						CS_0024_003C_003E8__locals1 = _003C_003E8__1,
						input = _003C_003E7__wrap1.Current
					};
					_003C_003E2__current = new API_v1_AudioRouting
					{
						Map = { from o in CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.map.OutputSet
							where CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals1.map.IsMapped(CS_0024_003C_003E8__locals3.input, o)
							select (uint)o.Index }
					};
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
		IEnumerator<API_v1_AudioRouting> IEnumerable<API_v1_AudioRouting>.GetEnumerator()
		{
			_003CSerialize_003Ed__4 _003CSerialize_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CSerialize_003Ed__ = this;
			}
			else
			{
				_003CSerialize_003Ed__ = new _003CSerialize_003Ed__4(0);
			}
			_003CSerialize_003Ed__.map = _003C_003E3__map;
			return _003CSerialize_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<API_v1_AudioRouting>)this).GetEnumerator();
		}
	}

	internal static NetworkAPI_v1 Handle(ICaptureService capture, IResiService resi, IUiDispatcher dispatcher, API_v1_Capture_Request request)
	{
		if (request != null)
		{
			if (request.GetStatus != null)
			{
				return GetStatus(capture.State, capture.CaptureTimeLapse, capture.StatusText);
			}
			API_v1_Capture_Request.Types.Operation operation = request.Operation;
			if (operation != null)
			{
				return Operation(capture, operation.Operation_, dispatcher);
			}
			if (request.GetSettings != null)
			{
				return GetSettings(capture, resi);
			}
			API_v1_Capture_Request.Types.SetSettings setSettings = request.SetSettings;
			if (setSettings != null)
			{
				return SetSettings(setSettings.Settings, capture, resi, dispatcher);
			}
			API_v1_Capture_Request.Types.Encodings getEncodings = request.GetEncodings;
			if (getEncodings != null)
			{
				return GetEncodings(capture, getEncodings.Type);
			}
		}
		global::_003CPrivateImplementationDetails_003E.ThrowSwitchExpressionException(request);
		NetworkAPI_v1 result = default(NetworkAPI_v1);
		return result;
	}

	internal static NetworkAPI_v1 GetStatus(State state, string captureTime, string status_text)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction("/v1/capture/status").CaptureResponse().GetStatus = new API_v1_Capture_Response.Types.GetStatus
			{
				Status = state.ToProto(),
				CaptureTime = captureTime,
				StatusText = (status_text ?? "")
			};
		});
	}

	private static NetworkAPI_v1 Operation(ICaptureService capture, API_v1_Capture_Request.Types.Operation.Types.CaptureOperation operation, IUiDispatcher dispatcher)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			switch (operation)
			{
			case API_v1_Capture_Request.Types.Operation.Types.CaptureOperation.Start:
				if (!capture.CanStartCapture())
				{
					v1.Action().InternalError();
					return;
				}
				dispatcher.Invoke(capture.StartScreenCapture);
				break;
			case API_v1_Capture_Request.Types.Operation.Types.CaptureOperation.Stop:
				if (!capture.CanStopCapture())
				{
					v1.Action().InternalError();
					return;
				}
				dispatcher.Invoke(capture.StopScreenCapture);
				break;
			}
			v1.Action().CaptureResponse().Operation = new API_v1_Capture_Response.Types.Operation();
		});
	}

	private static NetworkAPI_v1 GetSettings(ICaptureService capture, IResiService resi)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			API_v1_Capture_Response.Types.GetSettings getSettings2 = (v1.Action().CaptureResponse().GetSettings = new API_v1_Capture_Response.Types.GetSettings());
			API_v1_CaptureSettings obj = new API_v1_CaptureSettings
			{
				Source = (capture.Stream?.ScreenID.ToUUID() ?? null)
			};
			RepeatedField<API_v1_AudioRouting> audioRouting = obj.AudioRouting;
			IStream? stream = capture.Stream;
			audioRouting.Add((stream != null) ? stream.AudioOutputMap.Serialize() : null);
			API_v1_CaptureSettings aPI_v1_CaptureSettings = obj;
			getSettings2.Settings = obj;
			API_v1_CaptureSettings aPI_v1_CaptureSettings2 = aPI_v1_CaptureSettings;
			IStream? stream2 = capture.Stream;
			API_v1_DiskCapture aPI_v1_DiskCapture = ((stream2 != null) ? stream2.ToDiskCapture() : null);
			if (aPI_v1_DiskCapture != null)
			{
				aPI_v1_CaptureSettings2.Disk = aPI_v1_DiskCapture;
			}
			else
			{
				IStream? stream3 = capture.Stream;
				API_v1_RTMPCapture aPI_v1_RTMPCapture = ((stream3 != null) ? stream3.ToRTMP() : null);
				if (aPI_v1_RTMPCapture != null)
				{
					aPI_v1_CaptureSettings2.Rtmp = aPI_v1_RTMPCapture;
				}
				else
				{
					IStream? stream4 = capture.Stream;
					API_v1_ResiCapture aPI_v1_ResiCapture = ((stream4 != null) ? stream4.ToResi(resi) : null);
					if (aPI_v1_ResiCapture != null)
					{
						aPI_v1_CaptureSettings2.Resi = aPI_v1_ResiCapture;
					}
				}
			}
		});
	}

	[IteratorStateMachine(typeof(_003CSerialize_003Ed__4))]
	private static IEnumerable<API_v1_AudioRouting> Serialize(this AudioMap<Bus, StreamAudioChannel> map)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CSerialize_003Ed__4(-2)
		{
			_003C_003E3__map = map
		};
	}

	private static API_v1_DiskCapture? ToDiskCapture(this IStream stream)
	{
		DiskDestination diskDestination = stream.FirstOrDefaultOf<DiskDestination>();
		if (diskDestination == null)
		{
			return null;
		}
		return new API_v1_DiskCapture
		{
			Codec = stream.Encoder.Codec.ToResponseString(),
			FileLocation = diskDestination.Location,
			FrameRate = stream.Encoder.Encoding.FrameRate.ToFloat(),
			Resolution = new API_v1_Size
			{
				Width = stream.Encoder.Encoding.VideoWidth,
				Height = stream.Encoder.Encoding.VideoHeight
			}
		};
	}

	private static API_v1_RTMPCapture? ToRTMP(this IStream stream)
	{
		RtmpDestination rtmpDestination = stream.FirstOrDefaultOf<RtmpDestination>();
		if (rtmpDestination == null)
		{
			return null;
		}
		API_v1_RTMPCapture obj = new API_v1_RTMPCapture
		{
			Encoding = stream.Encoder.Codec.ToResponseString(),
			SaveLocal = stream.AnyOf<DiskDestination>()
		};
		DiskDestination diskDestination = stream.FirstOrDefaultOf<DiskDestination>();
		obj.FileLocation = ((diskDestination != null) ? ((string)diskDestination.Location) : string.Empty);
		obj.Key = rtmpDestination.Key ?? string.Empty;
		obj.Server = rtmpDestination.Address ?? string.Empty;
		return obj;
	}

	private static API_v1_ResiCapture? ToResi(this IStream stream, IResiService resiService)
	{
		ResiDestination resi = stream.FirstOrDefaultOf<ResiDestination>();
		if (resi == null)
		{
			return null;
		}
		return new API_v1_ResiCapture
		{
			DestinationGroup = (resiService.ResiDestinationGroups.FirstOrDefault((IDestinationGroup g) => g.ID == resi.Group)?.Name ?? string.Empty),
			Encoding = stream.Encoder.Codec.ToResponseString(),
			EventName = (resiService.EventName ?? string.Empty),
			EventDescription = (resiService.SocialDescription ?? string.Empty)
		};
	}

	private static NetworkAPI_v1 SetSettings(API_v1_CaptureSettings settings, ICaptureService capture, IResiService resiService, IUiDispatcher dispatcher)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			IStream stream = capture.Stream;
			if (stream == null)
			{
				v1.Action().InternalError();
			}
			else
			{
				Guid screenID = settings.Source.ToGuid();
				if (capture.AudienceScreens.Union(capture.StageScreens).Any((ScreenArrangementBase s) => s.ID == screenID))
				{
					dispatcher.Invoke(() => stream.ScreenID = screenID);
					dispatcher.Invoke(delegate
					{
						stream.AudioOutputMap.Deserialize(settings.AudioRouting.ToMap(), isCustomMap: true, inputToOutput: true);
					});
					dispatcher.Invoke(delegate
					{
						IStream stream2 = stream;
						stream2.DestinationType = settings.DestinationCase switch
						{
							API_v1_CaptureSettings.DestinationOneofCase.Rtmp => DestinationType.RTMP, 
							API_v1_CaptureSettings.DestinationOneofCase.Resi => DestinationType.Resi, 
							API_v1_CaptureSettings.DestinationOneofCase.Disk => DestinationType.Disk, 
							_ => throw new NotSupportedException(), 
						};
						if (settings != null)
						{
							API_v1_DiskCapture disk = settings.Disk;
							if (disk == null)
							{
								API_v1_RTMPCapture rtmp = settings.Rtmp;
								if (rtmp == null)
								{
									API_v1_ResiCapture resi = settings.Resi;
									if (resi != null)
									{
										stream.Encoder.Codec = resi.Encoding.FromString();
										resiService.EventName = resi.EventName;
										resiService.SocialDescription = resi.EventDescription;
										stream.Clear();
										stream.AddDestination(new ResiDestination
										{
											Group = (resiService.ResiDestinationGroups.FirstOrDefault((IDestinationGroup g) => g.Name == resi.DestinationGroup)?.ID ?? default(Guid))
										});
									}
								}
								else
								{
									stream.Encoder.Codec = rtmp.Encoding.FromString();
									stream.Clear();
									stream.AddDestination(new RtmpDestination
									{
										Address = rtmp.Server,
										Key = rtmp.Key
									});
									if (rtmp.SaveLocal)
									{
										stream.AddDestination(new DiskDestination
										{
											Location = new RelativePath(rtmp.FileLocation)
										});
									}
								}
							}
							else
							{
								stream.Encoder.Codec = disk.Codec.FromString();
								uint width = disk.Resolution.Width;
								uint height = disk.Resolution.Height;
								FrameRate frameRate = ((float)disk.FrameRate).ToFrameRate();
								uint videoBitrate = stream.Encoder.Encoding.VideoBitrate;
								uint audioBitrate = stream.Encoder.Encoding.AudioBitrate;
								bool isInterlaced = stream.Encoder.Encoding.IsInterlaced;
								stream.Encoder.Encoding = new Encoder(width, height, frameRate, videoBitrate, audioBitrate, isInterlaced);
								stream.Clear();
								stream.AddDestination(new DiskDestination
								{
									Location = new RelativePath(disk.FileLocation)
								});
							}
						}
					});
					v1.Action().CaptureResponse().SetSettings = new API_v1_Capture_Response.Types.SetSettings();
				}
				else
				{
					v1.Action().NotFound();
				}
			}
		});
	}

	private static IEnumerable<DigitalAudio.Types.Device.Types.Map> ToMap(this IEnumerable<API_v1_AudioRouting> routing)
	{
		uint index = 0u;
		return routing.Select((API_v1_AudioRouting i) => new DigitalAudio.Types.Device.Types.Map
		{
			ChannelIndex = index++,
			MappedIndices = { (IEnumerable<uint>)i.Map }
		});
	}

	private static NetworkAPI_v1 GetEncodings(ICaptureService capture, API_v1_CaptureDestination destination)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().CaptureResponse().GetEncodings = new API_v1_Capture_Response.Types.Encodings
			{
				Encodings_ = { (IEnumerable<string>)(from v in (from c in capture.GetAvailableCodecs(destination.ToDestination())
						select c.ToResponseString()).NonNull()
					orderby v
					select v) }
			};
		});
	}

	private static DestinationType ToDestination(this API_v1_CaptureDestination proto)
	{
		return proto switch
		{
			API_v1_CaptureDestination.Disk => DestinationType.Disk, 
			API_v1_CaptureDestination.Rtmp => DestinationType.RTMP, 
			API_v1_CaptureDestination.Resi => DestinationType.Resi, 
			_ => throw new NotSupportedException(), 
		};
	}

	private static string ToResponseString(this Codec codec)
	{
		switch (codec)
		{
		case Codec.H264:
		case Codec.H264Software:
			return "h_264";
		case Codec.H265:
		case Codec.H265Software:
			return "h_265";
		case Codec.ProRes422Proxy:
			return "prores_422_proxy";
		case Codec.ProRes422LT:
			return "prores_422_lt";
		case Codec.ProRes422:
			return "prores_422";
		case Codec.ProRes422HQ:
			return "prores_422_hq";
		case Codec.ProRes4444:
			return "prores_4444";
		case Codec.ProRes4444XQ:
			return "prores_4444_xq";
		case Codec.HAP:
			return "hap";
		case Codec.HAPAlpha:
			return "hap_alpha";
		case Codec.HAPQ:
		case Codec.HAPQAlpha:
			return "hap_q";
		default:
			return string.Empty;
		}
	}

	private static Codec FromString(this string codec)
	{
		return codec switch
		{
			"h_264" => Codec.H264, 
			"h_265" => Codec.H265, 
			"prores_422_proxy" => Codec.ProRes422Proxy, 
			"prores_422_lt" => Codec.ProRes422LT, 
			"prores_422" => Codec.ProRes422, 
			"prores_422_hq" => Codec.ProRes422HQ, 
			"prores_4444" => Codec.ProRes4444, 
			"prores_4444_xq" => Codec.ProRes4444XQ, 
			"hap" => Codec.HAP, 
			"hap_alpha" => Codec.HAPAlpha, 
			"hap_q" => Codec.HAPQ, 
			_ => Codec.Automatic, 
		};
	}

	private static API_v1_CaptureStatus ToProto(this State state)
	{
		return state switch
		{
			State.Active => API_v1_CaptureStatus.Active, 
			State.Inactive => API_v1_CaptureStatus.Inactive, 
			State.Caution => API_v1_CaptureStatus.Caution, 
			State.Error => API_v1_CaptureStatus.Error, 
			_ => throw new NotImplementedException(), 
		};
	}

	private static API_v1_Capture_Response CaptureResponse(this NetworkAPI_v1.Types.Action action)
	{
		return action.CaptureResponse = new API_v1_Capture_Response();
	}
}
