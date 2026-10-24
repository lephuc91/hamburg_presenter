using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Google.Protobuf.Collections;
using Pro.Common.Nullability;
using Pro.Common.Utility;
using Pro.DO.Label;
using Pro.DO.Storage;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Events;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Slide.Custom;

namespace ProPresenter.Controller.NetworkAPI;

internal static class PresentationHandler
{
	private sealed record FindLibraryAndDocumentResult(ILibrary Library, DocumentCue Document);

	[CompilerGenerated]
	private sealed class _003CSerializeToSlideGroup_003Ed__49 : IEnumerable<API_v1_Presentation.Types.SlideGroup>, IEnumerable, IEnumerator<API_v1_Presentation.Types.SlideGroup>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private API_v1_Presentation.Types.SlideGroup _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IPresentation presentation;

		public IPresentation _003C_003E3__presentation;

		private IAPIv1Service service;

		public IAPIv1Service _003C_003E3__service;

		private IEnumerator<CueGroup> _003C_003E7__wrap1;

		API_v1_Presentation.Types.SlideGroup IEnumerator<API_v1_Presentation.Types.SlideGroup>.Current
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
		public _003CSerializeToSlideGroup_003Ed__49(int _003C_003E1__state)
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
					_003C_003E7__wrap1 = presentation.DefaultArrangement.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				if (_003C_003E7__wrap1.MoveNext())
				{
					CueGroup current = _003C_003E7__wrap1.Current;
					API_v1_Presentation.Types.SlideGroup obj = new API_v1_Presentation.Types.SlideGroup
					{
						Name = current.Label.Text,
						Uuid = current.ID.ToString()
					};
					System.Windows.Media.Color? color = current.Label.Color;
					obj.Color = (color.HasValue ? color.GetValueOrDefault().ToProtoColor() : null);
					obj.Slides.Add(current.Cues.Serialize(service));
					_003C_003E2__current = obj;
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
		IEnumerator<API_v1_Presentation.Types.SlideGroup> IEnumerable<API_v1_Presentation.Types.SlideGroup>.GetEnumerator()
		{
			_003CSerializeToSlideGroup_003Ed__49 _003CSerializeToSlideGroup_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CSerializeToSlideGroup_003Ed__ = this;
			}
			else
			{
				_003CSerializeToSlideGroup_003Ed__ = new _003CSerializeToSlideGroup_003Ed__49(0);
			}
			_003CSerializeToSlideGroup_003Ed__.presentation = _003C_003E3__presentation;
			_003CSerializeToSlideGroup_003Ed__.service = _003C_003E3__service;
			return _003CSerializeToSlideGroup_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<API_v1_Presentation.Types.SlideGroup>)this).GetEnumerator();
		}
	}

	internal static NetworkAPI_v1? Handle(IAPIv1Service service, API_v1_Presentation_Request request)
	{
		if (request != null)
		{
			if (request.Active != null)
			{
				return ActivePresentation(service);
			}
			if (request.SlideIndex != null)
			{
				return SlideIndex(service);
			}
			API_v1_Presentation_Request.Types.ChordChart chordChart = request.ChordChart;
			if (chordChart != null)
			{
				return GetChordChart(service, chordChart.Quality);
			}
			if (request.ChordChartUpdates != null)
			{
				return UpdateChordChart();
			}
			API_v1_Presentation_Request.Types.Presentation presentation = request.Presentation;
			if (presentation != null)
			{
				return Presentation(service, presentation.Uuid.ToGuid());
			}
			API_v1_Presentation_Request.Types.TimelineOperation timelineOperation = request.TimelineOperation;
			if (timelineOperation != null)
			{
				return TimelineOperation(service, timelineOperation.Uuid.ToGuid(), timelineOperation.Operation);
			}
			API_v1_Presentation_Request.Types.ActivePresentationTimelineOperation activePresentationTimelineOperation = request.ActivePresentationTimelineOperation;
			if (activePresentationTimelineOperation != null)
			{
				return ActiveTimeline(service, activePresentationTimelineOperation.Operation);
			}
			API_v1_Presentation_Request.Types.FocusedPresentationTimelineOperation focusedPresentationTimelineOperation = request.FocusedPresentationTimelineOperation;
			if (focusedPresentationTimelineOperation != null)
			{
				return FocusedTimeline(service, focusedPresentationTimelineOperation.Operation);
			}
			if (request.ActivePresentationTimelineStatus != null)
			{
				return ActivePresentationTimelineStatus(service);
			}
			if (request.FocusedPresentationTimelineStatus != null)
			{
				return FocusedTimelineStatus(service);
			}
			API_v1_Presentation_Request.Types.Thumbnail thumbnail = request.Thumbnail;
			if (thumbnail != null)
			{
				return GetThumbnail(service, thumbnail.Uuid.ToGuid(), thumbnail.CueIndex, thumbnail.Quality, thumbnail.ContentType);
			}
			if (request.Focused != null)
			{
				return FocusedPresentation(service);
			}
			API_v1_Presentation_Request.Types.TriggerMessage trigger = request.Trigger;
			if (trigger != null)
			{
				return Trigger(service, trigger);
			}
			API_v1_Presentation_Request.Types.FocusMessage focus = request.Focus;
			if (focus != null)
			{
				return FocusPresentation(service, focus);
			}
		}
		return null;
	}

	private static NetworkAPI_v1 Trigger(IAPIv1Service service, API_v1_Presentation_Request.Types.TriggerMessage triggerMessage)
	{
		switch (triggerMessage.PresentationCase)
		{
		case API_v1_Presentation_Request.Types.TriggerMessage.PresentationOneofCase.Focused:
			return TriggerFocused(service, triggerMessage);
		case API_v1_Presentation_Request.Types.TriggerMessage.PresentationOneofCase.Active:
			return TriggerActive(service, triggerMessage);
		case API_v1_Presentation_Request.Types.TriggerMessage.PresentationOneofCase.Uuid:
		{
			if (Guid.TryParse(triggerMessage.Uuid, out var result))
			{
				return TriggerUuid(service, result, triggerMessage);
			}
			break;
		}
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().NotFound();
		});
	}

	private static NetworkAPI_v1 TriggerActive(IAPIv1Service service, API_v1_Presentation_Request.Types.TriggerMessage triggerMessage)
	{
		Guid? guid = service.ActivePresentationSlideInfo?.Slide.Source.ParentPresentation?.ID;
		return TriggerUuid(service, guid, triggerMessage);
	}

	private static NetworkAPI_v1 TriggerFocused(IAPIv1Service service, API_v1_Presentation_Request.Types.TriggerMessage triggerMessage)
	{
		Guid? guid = service.Triggering.ActivePlaylistItem?.ID;
		if (service.Triggering.ActivePlaylistItem is IDocumentCue documentCue)
		{
			guid = documentCue.DocumentAction?.Presentation?.ID;
		}
		return TriggerUuid(service, guid, triggerMessage);
	}

	private static NetworkAPI_v1 TriggerUuid(IAPIv1Service service, Guid? guid, API_v1_Presentation_Request.Types.TriggerMessage triggerMessage)
	{
		if (!guid.HasValue)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().NotFound();
			});
		}
		switch (triggerMessage.CueCase)
		{
		case API_v1_Presentation_Request.Types.TriggerMessage.CueOneofCase.Next:
			return TriggerCue(service, guid.Value, ProximalSlideIndex(service, guid.Value, 1), Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().PresentationResponse().Trigger = new API_v1_Presentation_Response.Types.EmptyMessage();
			}));
		case API_v1_Presentation_Request.Types.TriggerMessage.CueOneofCase.Previous:
			return TriggerCue(service, guid.Value, ProximalSlideIndex(service, guid.Value, -1), Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().PresentationResponse().Trigger = new API_v1_Presentation_Response.Types.EmptyMessage();
			}));
		case API_v1_Presentation_Request.Types.TriggerMessage.CueOneofCase.Index:
			if (triggerMessage.Index.HasValue)
			{
				return TriggerCue(service, guid.Value, triggerMessage.Index.Value, Common.Build(delegate(NetworkAPI_v1 v1)
				{
					v1.Action().PresentationResponse().Trigger = new API_v1_Presentation_Response.Types.EmptyMessage();
				}));
			}
			break;
		case API_v1_Presentation_Request.Types.TriggerMessage.CueOneofCase.Group:
			return TriggerGroup(service, guid.Value, triggerMessage.Group);
		case API_v1_Presentation_Request.Types.TriggerMessage.CueOneofCase.None:
		case API_v1_Presentation_Request.Types.TriggerMessage.CueOneofCase.First:
			return TriggerPresentation(service, guid.Value);
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().NotFound();
		});
	}

	private static uint? ProximalSlideIndex(IAPIv1Service s, Guid id, int inc)
	{
		IPresentation presentation = s.ActivePresentationSlideInfo?.Slide.Source.ParentPresentation;
		IPresentation presentation2 = s.ActiveAnnouncementsSlideInfo?.Slide.Source.ParentPresentation;
		if (presentation == null || presentation.Destination != 0)
		{
			presentation = null;
		}
		if (presentation2 == null || presentation2.Destination != OutputDestination.Announcement)
		{
			presentation2 = null;
		}
		Guid value = id;
		Guid? obj = presentation?.ID;
		IPresentation presentation3;
		int? num;
		if (!(value == obj))
		{
			value = id;
			Guid? obj2 = presentation2?.ID;
			(num, presentation3) = ((value == obj2) ? (s.ActiveAnnouncementsSlideInfo?.Index, presentation2) : (null, null));
		}
		else
		{
			int? obj3 = s.ActivePresentationSlideInfo?.Index;
			IPresentation presentation4 = presentation;
			presentation3 = presentation4;
			num = obj3;
		}
		if (num.HasValue)
		{
			int num2 = (presentation3?.ActiveArrangement ?? presentation3?.DefaultArrangement)?.ArrangedCues.Count() ?? 0;
			if (inc == 1)
			{
				DocumentCue documentCue = s.Libraries.FindDocument(id);
				if (documentCue != null)
				{
					IDocumentAction documentAction = documentCue.DocumentAction;
					if (documentAction != null)
					{
						ArrangedCue arrangedCue = documentAction.ActiveArrangement?.ArrangedCues.ElementAtOrDefault(num.Value);
						if (arrangedCue != null && arrangedCue.BuildPosition < arrangedCue.BuildCount)
						{
							inc = 0;
						}
					}
				}
			}
			num += inc;
			if (num == num2)
			{
				return null;
			}
			if (num == -1)
			{
				return null;
			}
		}
		else
		{
			if (inc == -1)
			{
				DocumentCue documentCue = s.Libraries.FindDocument(id);
				if (documentCue != null)
				{
					IDocumentAction documentAction2 = documentCue.DocumentAction;
					if (documentAction2 != null)
					{
						IArrangement? activeArrangement = documentAction2.ActiveArrangement;
						int? obj4;
						if (activeArrangement == null || !(activeArrangement.ArrangedCues?.Count < 1))
						{
							IArrangement? activeArrangement2 = documentAction2.ActiveArrangement;
							obj4 = ((activeArrangement2 == null) ? ((int?)null) : (activeArrangement2.ArrangedCues?.Count - 1));
						}
						else
						{
							obj4 = 0;
						}
						num = obj4;
						goto IL_032e;
					}
				}
			}
			num = 0;
		}
		goto IL_032e;
		IL_032e:
		return (uint)new int?(Math.Max(0, num.Value)).Value;
	}

	private static NetworkAPI_v1 TriggerPresentation(IAPIv1Service service, Guid id)
	{
		return TriggerCue(service, id, 0u, Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().PresentationResponse().Trigger = new API_v1_Presentation_Response.Types.EmptyMessage();
		}));
	}

	private static NetworkAPI_v1 TriggerCue(IAPIv1Service service, Guid id, uint? index, NetworkAPI_v1 successResponse)
	{
		if (!index.HasValue)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().NotFound();
			});
		}
		DocumentCue document = service.Libraries.FindDocument(id);
		if (document != null)
		{
			IDocumentAction documentAction = document.DocumentAction;
			if (documentAction != null)
			{
				ArrangedCue slide = documentAction.ActiveArrangement?.ArrangedCues.ElementAtOrDefault((int)index.Value);
				if (slide != null)
				{
					IPresentation? presentation = documentAction.Presentation;
					if (presentation != null && presentation.IsAvailable)
					{
						service.Dependencies.UiDispatcher.Invoke(delegate
						{
							service.Triggering.TriggerSlide(slide, new SlideTriggerOptions(overrideEnable: false, suppressGoToNext: false, null, null, document));
						});
						return successResponse;
					}
					return Common.Build(delegate(NetworkAPI_v1 v1)
					{
						v1.Action().Unauthorized();
					});
				}
			}
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().NotFound();
		});
	}

	private static NetworkAPI_v1 TriggerGroup(IAPIv1Service service, Guid id, string groupId)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (Common.TryFindItem(service.Groups, groupId, out ItemPacket<GroupLabel> packet))
			{
				DocumentCue documentCue = service.Libraries.FindDocument(id);
				if (documentCue != null)
				{
					IDocumentAction documentAction = documentCue.DocumentAction;
					if (documentAction != null)
					{
						IArrangement activeArrangement = documentAction.ActiveArrangement;
						if (activeArrangement != null)
						{
							ArrangedCue cue = activeArrangement.ArrangedCues.FirstOrDefault((ArrangedCue c) => c.GroupLabel?.MasterLabel == packet.Item);
							if (cue != null)
							{
								service.Dependencies.UiDispatcher.Invoke(delegate
								{
									service.Triggering.TriggerSlide(cue);
								});
							}
						}
					}
				}
				v1.Action().PresentationResponse().Trigger = new API_v1_Presentation_Response.Types.EmptyMessage();
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static NetworkAPI_v1 FocusPresentation(IAPIv1Service service, API_v1_Presentation_Request.Types.FocusMessage focusMessage)
	{
		return focusMessage.PresentationCase switch
		{
			API_v1_Presentation_Request.Types.FocusMessage.PresentationOneofCase.None => FocusClear(service), 
			API_v1_Presentation_Request.Types.FocusMessage.PresentationOneofCase.Active => FocusActive(service), 
			API_v1_Presentation_Request.Types.FocusMessage.PresentationOneofCase.Uuid => FocusUuid(service, focusMessage.Uuid), 
			API_v1_Presentation_Request.Types.FocusMessage.PresentationOneofCase.Next => FocusNextPresentation(service), 
			API_v1_Presentation_Request.Types.FocusMessage.PresentationOneofCase.Previous => FocusPreviousPresentation(service), 
			_ => Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().NotFound();
			}), 
		};
	}

	private static NetworkAPI_v1 FocusActive(IAPIv1Service service)
	{
		Guid? guid = service.ActivePresentationSlideInfo?.Slide.Source?.ParentPresentation?.ID;
		if (!guid.HasValue)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().NotFound();
			});
		}
		return Focus(service, guid.Value);
	}

	private static NetworkAPI_v1 FocusUuid(IAPIv1Service service, string uuid)
	{
		if (!Guid.TryParse(uuid, out var result))
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().NotFound();
			});
		}
		return Focus(service, result);
	}

	private static NetworkAPI_v1 FocusClear(IAPIv1Service service)
	{
		service.Dependencies.UiDispatcher.Invoke(delegate
		{
			service.Triggering.ActivePlaylistItem = null;
		});
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().PresentationResponse().Focus = new API_v1_Presentation_Response.Types.EmptyMessage();
		});
	}

	private static NetworkAPI_v1 FocusNextPresentation(IAPIv1Service service)
	{
		Guid? guid = service.Triggering.ActivePlaylistItem?.ID;
		if (!guid.HasValue)
		{
			return FocusClear(service);
		}
		if (!FocusNextPresentation(service, guid.Value))
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().NotFound();
			});
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().PresentationResponse().Focus = new API_v1_Presentation_Response.Types.EmptyMessage();
		});
	}

	private static NetworkAPI_v1 FocusPreviousPresentation(IAPIv1Service service)
	{
		Guid? guid = service.Triggering.ActivePlaylistItem?.ID;
		if (!guid.HasValue)
		{
			return FocusClear(service);
		}
		if (!FocusPreviousPresentation(service, guid.Value))
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().NotFound();
			});
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().PresentationResponse().Focus = new API_v1_Presentation_Response.Types.EmptyMessage();
		});
	}

	private static NetworkAPI_v1 Focus(IAPIv1Service service, Guid id)
	{
		FindLibraryAndDocumentResult findLibraryAndDocumentResult = service.Libraries.FindLibraryAndDocument(id);
		if (findLibraryAndDocumentResult != null)
		{
			var (library2, documentCue2) = findLibraryAndDocumentResult;
			documentCue2.DocumentAction.Presentation.ThrowWhenNull("documentCue.DocumentAction.Presentation");
			service.Dependencies.UiDispatcher.Invoke(delegate
			{
				documentCue2.DocumentAction.Presentation.EnsureLoaded();
				service.Triggering.ActiveLibrary = library2;
				service.Triggering.ActivePlaylistItem = documentCue2;
			});
		}
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().PresentationResponse().Focus = new API_v1_Presentation_Response.Types.EmptyMessage();
		});
	}

	private static NetworkAPI_v1 ActivePresentation(IAPIv1Service service)
	{
		return UpdateCurrentPresentation(service);
	}

	private static bool FocusPreviousPresentation(IAPIv1Service service, Guid id)
	{
		FindLibraryAndDocumentResult findLibraryAndDocumentResult = service.Libraries.FindLibraryAndDocument(id);
		if (findLibraryAndDocumentResult == null)
		{
			return false;
		}
		findLibraryAndDocumentResult.Deconstruct(out ILibrary Library, out DocumentCue Document);
		ILibrary library = Library;
		DocumentCue item = Document;
		int num = library.SortedItems.IndexOf(item);
		DocumentCue previous;
		if (num <= 0)
		{
			int num2 = service.Libraries.IndexOf(library);
			if (num2 <= 0)
			{
				return false;
			}
			library = service.Libraries.ElementAtOrDefault(num2 - 1);
			previous = library?.SortedItems.LastOrDefault();
		}
		else
		{
			previous = library.SortedItems.Reverse().Skip(library.SortedItems.Count - num).FirstOrDefault((DocumentCue s) => s.IsEnabled);
		}
		if (previous != null)
		{
			previous.DocumentAction.Presentation.ThrowWhenNull("previous.DocumentAction.Presentation");
			service.Dependencies.UiDispatcher.Invoke(delegate
			{
				previous.DocumentAction.Presentation.EnsureLoaded();
				service.Triggering.ActiveLibrary = library;
				service.Triggering.ActivePlaylistItem = previous;
			});
		}
		return previous != null;
	}

	private static bool FocusNextPresentation(IAPIv1Service service, Guid id)
	{
		FindLibraryAndDocumentResult findLibraryAndDocumentResult = service.Libraries.FindLibraryAndDocument(id);
		if (findLibraryAndDocumentResult == null)
		{
			return false;
		}
		findLibraryAndDocumentResult.Deconstruct(out ILibrary Library, out DocumentCue Document);
		ILibrary library = Library;
		DocumentCue item = Document;
		int num = library.SortedItems.IndexOf(item);
		DocumentCue next;
		if (num >= library.SortedItems.Count - 1)
		{
			int num2 = service.Libraries.IndexOf(library);
			if (num2 < 0 || num2 >= service.Libraries.Count - 1)
			{
				return false;
			}
			library = service.Libraries.ElementAtOrDefault(num2 + 1);
			next = library?.SortedItems.FirstOrDefault();
		}
		else
		{
			next = library.SortedItems.Skip(num + 1).FirstOrDefault((DocumentCue s) => s.IsEnabled);
		}
		if (next != null)
		{
			next.DocumentAction.Presentation.ThrowWhenNull("next.DocumentAction.Presentation");
			service.Dependencies.UiDispatcher.Invoke(delegate
			{
				next.DocumentAction.Presentation.EnsureLoaded();
				service.Triggering.ActiveLibrary = library;
				service.Triggering.ActivePlaylistItem = next;
			});
		}
		return next != null;
	}

	private static NetworkAPI_v1 Presentation(IAPIv1Service service, Guid id)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			DocumentCue documentCue = service.Libraries.FindDocument(id);
			if (documentCue != null)
			{
				IDocumentAction documentAction = documentCue.DocumentAction;
				if (documentAction != null)
				{
					documentAction.Presentation.ThrowWhenNull("action.Presentation");
					if (documentAction.Presentation.IsAvailable)
					{
						v1.Action().PresentationResponse().Presentation = new API_v1_Presentation_Response.Types.Presentation
						{
							Presentation_ = documentAction.Presentation.ToAPIv1Presentation(service)
						};
					}
					else
					{
						v1.Action().Unauthorized();
					}
					return;
				}
			}
			v1.Action().NotFound();
		});
	}

	private static NetworkAPI_v1 FocusedPresentation(IAPIv1Service service)
	{
		return UpdateFocusedPresentation(service);
	}

	internal static NetworkAPI_v1 UpdateFocusedPresentation(IAPIv1Service service)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (service.Triggering.ActivePlaylistItem is IDocumentCue { DocumentAction: not null } documentCue)
			{
				IPresentation presentation = documentCue.DocumentAction.Presentation;
				if (presentation != null && presentation.IsAvailable)
				{
					v1.StreamingAction("/v1/presentation/focused").PresentationResponse().Focused = new API_v1_Presentation_Response.Types.Focused
					{
						Id = Common.ID(presentation.ID, presentation.Name, 0u)
					};
				}
				else
				{
					v1.StreamingAction("/v1/presentation/focused").Unauthorized();
				}
			}
			else
			{
				v1.StreamingAction("/v1/presentation/focused").NotFound();
			}
		});
	}

	internal static NetworkAPI_v1 UpdateCurrentPresentation(IAPIv1Service service, IPresentation? presentation = null)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			presentation = service.ActivePresentationSlideInfo?.Slide.Source.ParentPresentation;
			API_v1_Presentation_Response aPI_v1_Presentation_Response = v1.StreamingAction("/v1/presentation/active").PresentationResponse();
			API_v1_Presentation_Response.Types.Active active = new API_v1_Presentation_Response.Types.Active();
			IPresentation? presentation2 = presentation;
			active.Presentation = ((presentation2 != null) ? presentation2.ToAPIv1Presentation(service) : null);
			aPI_v1_Presentation_Response.Active = active;
		});
	}

	private static NetworkAPI_v1 SlideIndex(IAPIv1Service service)
	{
		return UpdateSlideIndex(service, service.ActivePresentationSlideInfo);
	}

	internal static NetworkAPI_v1 UpdateSlideIndex(IAPIv1Service service, APIv1Service.SlideIndex? presentation = null)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			API_v1_Presentation_Response aPI_v1_Presentation_Response = v1.StreamingAction("/v1/presentation/slide_index").PresentationResponse();
			API_v1_Presentation_Response.Types.SlideIndex slideIndex = new API_v1_Presentation_Response.Types.SlideIndex();
			APIv1Service.SlideIndex? slideIndex2 = presentation;
			slideIndex.PresentationIndex = (((object)slideIndex2 != null) ? slideIndex2.ToAPIv1SlideIndex() : null);
			aPI_v1_Presentation_Response.SlideIndex = slideIndex;
		});
	}

	private static NetworkAPI_v1 GetChordChart(IAPIv1Service service, int quality)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			NetworkAPI_v1.Types.Action action = v1.Action();
			RelativePath relativePath = (service.ActivePresentationSlideInfo?.Slide.Source.SlideAction?.Slide as CustomSlide)?.ChordChart;
			if (relativePath != null)
			{
				BitmapSource bitmapSource = ImageHelper.LoadImage(relativePath);
				if (bitmapSource != null)
				{
					action.PresentationResponse().ChordChart = new API_v1_Presentation_Response.Types.ChordChart
					{
						ChordChart_ = bitmapSource.ScaleBitmap(quality)
					};
				}
			}
		});
	}

	internal static NetworkAPI_v1 UpdateChordChart()
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.StreamingAction("/v1/presentation/chord_chart/updates");
		});
	}

	private static NetworkAPI_v1 TimelineOperation(IAPIv1Service service, Guid id, API_v1_TimelineOperation operation)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			DocumentCue documentCue = service.Libraries.FindDocument(id);
			if (documentCue != null)
			{
				IDocumentAction documentAction = documentCue.DocumentAction;
				if (documentAction != null)
				{
					IPresentation presentation = documentAction.Presentation;
					if (presentation != null && presentation.PresentationTimeline != null)
					{
						if (documentCue.DocumentAction.Presentation.IsAvailable)
						{
							ExecuteTimeline(service, operation, documentCue);
							v1.Action().PresentationResponse().TimelineOperation = new API_v1_Presentation_Response.Types.TimelineOperation();
						}
						else
						{
							v1.Action().Unauthorized();
						}
						return;
					}
				}
			}
			v1.Action().NotFound();
		});
	}

	private static NetworkAPI_v1 ActiveTimeline(IAPIv1Service service, API_v1_TimelineOperation operation)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (service.Triggering.ActivePresentationParent is IDocumentCue documentCue)
			{
				IDocumentAction documentAction = documentCue.DocumentAction;
				if (documentAction != null)
				{
					IPresentation presentation = documentAction.Presentation;
					if (presentation != null && presentation.PresentationTimeline != null)
					{
						ExecuteTimeline(service, operation, documentCue);
						v1.Action().PresentationResponse().TimelineOperation = new API_v1_Presentation_Response.Types.TimelineOperation();
						return;
					}
				}
			}
			v1.Action().NotFound();
		});
	}

	private static NetworkAPI_v1 FocusedTimeline(IAPIv1Service service, API_v1_TimelineOperation operation)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (service.Triggering.ActivePlaylistItem is IDocumentCue documentCue)
			{
				IDocumentAction documentAction = documentCue.DocumentAction;
				if (documentAction != null)
				{
					IPresentation presentation = documentAction.Presentation;
					if (presentation != null && presentation.PresentationTimeline != null)
					{
						if (documentCue.DocumentAction.Presentation.IsAvailable)
						{
							ExecuteTimeline(service, operation, documentCue);
							v1.Action().PresentationResponse().TimelineOperation = new API_v1_Presentation_Response.Types.TimelineOperation();
						}
						else
						{
							v1.Action().Unauthorized();
						}
						return;
					}
				}
			}
			v1.Action().NotFound();
		});
	}

	private static void ExecuteTimeline(IAPIv1Service service, API_v1_TimelineOperation operation, IDocumentCue document)
	{
		switch (operation)
		{
		case API_v1_TimelineOperation.Play:
			service.Dependencies.UiDispatcher.Invoke(delegate
			{
				service.Dependencies.TimelineManager.Play(document, null);
			});
			break;
		case API_v1_TimelineOperation.Pause:
			service.Dependencies.UiDispatcher.Invoke(delegate
			{
				service.Dependencies.TimelineManager.Pause(document);
			});
			break;
		case API_v1_TimelineOperation.Rewind:
			service.Dependencies.UiDispatcher.Invoke(delegate
			{
				service.Dependencies.TimelineManager.Reset(document);
			});
			break;
		}
	}

	public static NetworkAPI_v1 FocusedTimelineStatus(IAPIv1Service service)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (service.Triggering.ActivePlaylistItem is IDocumentCue documentCue)
			{
				IDocumentAction documentAction = documentCue.DocumentAction;
				if (documentAction != null && documentAction.Destination == OutputDestination.Presentation)
				{
					IPresentation presentation = documentAction.Presentation;
					if (presentation != null && presentation.PresentationTimeline != null)
					{
						var (isRunning, _, timeSlice) = service.Dependencies.TimelineManager.GetInfo(documentCue);
						v1.StreamingAction("/v1/presentation/focused/timeline").PresentationResponse().FocusedPresentationTimelineStatus = new API_v1_Presentation_Response.Types.FocusedPresentationTimelineStatus
						{
							CurrentTime = timeSlice.TotalSeconds,
							IsRunning = isRunning
						};
						return;
					}
				}
			}
			v1.StreamingAction("/v1/presentation/focused/timeline").NotFound();
		});
	}

	private static NetworkAPI_v1 GetThumbnail(IAPIv1Service service, Guid id, uint index, int quality, API_v1_ContentType contentType)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			DocumentCue documentCue = service.Libraries.FindDocument(id);
			if (documentCue != null)
			{
				IDocumentAction documentAction = documentCue.DocumentAction;
				if (documentAction != null)
				{
					ArrangedCue arrangedCue = documentAction.ActiveArrangement?.ArrangedCues.ElementAtOrDefault((int)index);
					if (arrangedCue != null)
					{
						documentAction.Presentation.ThrowWhenNull("action.Presentation");
						if (documentAction.Presentation.IsAvailable)
						{
							v1.Action().PresentationResponse().Thumbnail = new API_v1_Presentation_Response.Types.Thumbnail
							{
								ContentType = contentType,
								Data = arrangedCue.Source.GetThumbnail(documentAction.Presentation.UseBackgroundColor ? documentAction.Presentation.BackgroundColor : default(System.Windows.Media.Color), quality, contentType)
							};
						}
						else
						{
							v1.Action().Unauthorized();
						}
						return;
					}
				}
			}
			v1.Action().NotFound();
		});
	}

	internal static NetworkAPI_v1? Handle(IAPIv1Service service, API_v1_Announcement_Request request)
	{
		if (request != null)
		{
			if (request.Active != null)
			{
				return ActiveAnnouncement(service);
			}
			if (request.SlideIndex != null)
			{
				return AnnnouncementSlideIndex(service);
			}
			if (request.ActiveFocus != null)
			{
				return ActiveAnnouncementFocus(service);
			}
			API_v1_Announcement_Request.Types.ActiveIndexTrigger activeIndexTrigger = request.ActiveIndexTrigger;
			if (activeIndexTrigger != null)
			{
				return ActiveAnnouncementIndexTrigger(service, activeIndexTrigger.Index);
			}
			if (request.ActiveNextTrigger != null)
			{
				return ActiveAnnouncementNextTrigger(service);
			}
			if (request.ActivePreviousTrigger != null)
			{
				return ActiveAnnouncementPreviousTrigger(service);
			}
			if (request.ActiveTrigger != null)
			{
				return ActiveAnnouncementTrigger(service);
			}
			API_v1_Announcement_Request.Types.ActiveTimelineOperation activeTimelineOperation = request.ActiveTimelineOperation;
			if (activeTimelineOperation != null)
			{
				return ActiveAnnouncementTimeline(service, activeTimelineOperation.Operation);
			}
			if (request.ActiveTimelineStatus != null)
			{
				return ActiveAnnouncementTimelineStatus(service);
			}
		}
		return null;
	}

	private static NetworkAPI_v1 ActiveAnnouncementFocus(IAPIv1Service service)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			Guid? guid = service.ActiveAnnouncementsSlideInfo?.Slide.Source?.ParentPresentation?.ID;
			if (guid.HasValue)
			{
				Focus(service, guid.Value);
				v1.Action().AnnouncementResponse().ActiveFocus = new API_v1_Announcement_Response.Types.ActiveFocus();
			}
			else
			{
				v1.Action().NotFound();
			}
		});
	}

	private static NetworkAPI_v1 ActiveAnnouncementIndexTrigger(IAPIv1Service service, uint index)
	{
		Guid? guid = service.ActiveAnnouncementsSlideInfo?.Slide.Source?.ParentPresentation?.ID;
		if (!guid.HasValue)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().NotFound();
			});
		}
		return TriggerCue(service, guid.Value, index, Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().AnnouncementResponse().ActiveIndexTrigger = new API_v1_Announcement_Response.Types.ActiveIndexTrigger();
		}));
	}

	private static NetworkAPI_v1 ActiveAnnouncementNextTrigger(IAPIv1Service service)
	{
		Guid? guid = service.ActiveAnnouncementsSlideInfo?.Slide.Source?.ParentPresentation?.ID;
		if (!guid.HasValue)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().NotFound();
			});
		}
		return TriggerCue(service, guid.Value, ProximalSlideIndex(service, guid.Value, 1), Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().AnnouncementResponse().ActiveNextTrigger = new API_v1_Announcement_Response.Types.ActiveNextTrigger();
		}));
	}

	private static NetworkAPI_v1 ActiveAnnouncementPreviousTrigger(IAPIv1Service service)
	{
		Guid? guid = service.ActiveAnnouncementsSlideInfo?.Slide.Source?.ParentPresentation?.ID;
		if (!guid.HasValue)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().NotFound();
			});
		}
		return TriggerCue(service, guid.Value, ProximalSlideIndex(service, guid.Value, -1), Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().AnnouncementResponse().ActivePreviousTrigger = new API_v1_Announcement_Response.Types.ActivePreviousTrigger();
		}));
	}

	private static NetworkAPI_v1 ActiveAnnouncementTrigger(IAPIv1Service service)
	{
		Guid? guid = service.ActiveAnnouncementsSlideInfo?.Slide.Source?.ParentPresentation?.ID;
		if (!guid.HasValue)
		{
			return Common.Build(delegate(NetworkAPI_v1 v1)
			{
				v1.Action().NotFound();
			});
		}
		return TriggerCue(service, guid.Value, 0u, Common.Build(delegate(NetworkAPI_v1 v1)
		{
			v1.Action().AnnouncementResponse().ActiveTrigger = new API_v1_Announcement_Response.Types.ActiveTrigger();
		}));
	}

	private static NetworkAPI_v1? ActiveAnnouncement(IAPIv1Service service)
	{
		return UpdateActiveAnnouncement(service);
	}

	internal static NetworkAPI_v1? UpdateActiveAnnouncement(IAPIv1Service service, IPresentation? announcements = null)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (announcements == null)
			{
				announcements = ((!(service.ActiveAnnouncementsSlideInfo != null)) ? service.LastAnnouncementsSlideInfo?.Slide.Source.ParentPresentation : service.ActiveAnnouncementsSlideInfo?.Slide.Source.ParentPresentation);
			}
			API_v1_Announcement_Response aPI_v1_Announcement_Response = v1.StreamingAction("/v1/announcement/active").AnnouncementResponse();
			API_v1_Announcement_Response.Types.Active active = new API_v1_Announcement_Response.Types.Active();
			IPresentation? presentation = announcements;
			active.Announcement = ((presentation != null) ? presentation.ToAPIv1Presentation(service) : null);
			aPI_v1_Announcement_Response.Active = active;
		});
	}

	private static NetworkAPI_v1 ActiveAnnouncementTimeline(IAPIv1Service service, API_v1_TimelineOperation operation)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (service.Triggering.ActiveAnnouncementParent is IDocumentCue documentCue)
			{
				IDocumentAction documentAction = documentCue.DocumentAction;
				if (documentAction != null)
				{
					IPresentation presentation = documentAction.Presentation;
					if (presentation != null && presentation.PresentationTimeline != null)
					{
						ExecuteTimeline(service, operation, documentCue);
						v1.Action().AnnouncementResponse().ActiveTimelineOperation = new API_v1_Announcement_Response.Types.ActiveTimelineOperation();
						return;
					}
				}
			}
			v1.Action().NotFound();
		});
	}

	public static NetworkAPI_v1 ActiveAnnouncementTimelineStatus(IAPIv1Service service)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (service.Triggering.ActiveAnnouncementParent is IDocumentCue documentCue)
			{
				IDocumentAction documentAction = documentCue.DocumentAction;
				if (documentAction != null)
				{
					IPresentation presentation = documentAction.Presentation;
					if (presentation != null && presentation.PresentationTimeline != null)
					{
						var (isRunning, _, timeSlice) = service.Dependencies.TimelineManager.GetInfo(documentCue);
						v1.StreamingAction("/v1/announcement/active/timeline").AnnouncementResponse().ActiveTimelineStatus = new API_v1_Announcement_Response.Types.ActiveTimelineStatus
						{
							CurrentTime = timeSlice.TotalSeconds,
							IsRunning = isRunning
						};
						return;
					}
				}
			}
			v1.StreamingAction("/v1/announcement/active/timeline").NotFound();
		});
	}

	public static NetworkAPI_v1 ActivePresentationTimelineStatus(IAPIv1Service service)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if (service.Triggering.ActivePresentationParent is IDocumentCue documentCue)
			{
				IDocumentAction documentAction = documentCue.DocumentAction;
				if (documentAction != null)
				{
					IPresentation presentation = documentAction.Presentation;
					if (presentation != null && presentation.Destination == OutputDestination.Presentation)
					{
						var (isRunning, _, timeSlice) = service.Dependencies.TimelineManager.GetInfo(documentCue);
						v1.StreamingAction("/v1/presentation/active/timeline").PresentationResponse().ActivePresentationTimelineStatus = new API_v1_Presentation_Response.Types.ActivePresentationTimelineStatus
						{
							CurrentTime = timeSlice.TotalSeconds,
							IsRunning = isRunning
						};
						return;
					}
				}
			}
			v1.StreamingAction("/v1/presentation/active/timeline").NotFound();
		});
	}

	private static NetworkAPI_v1 AnnnouncementSlideIndex(IAPIv1Service service)
	{
		return UpdateAnnouncementSlideIndex(service);
	}

	internal static NetworkAPI_v1 UpdateAnnouncementSlideIndex(IAPIv1Service service, APIv1Service.SlideIndex? announcements = null)
	{
		return Common.Build(delegate(NetworkAPI_v1 v1)
		{
			if ((object)announcements == null)
			{
				announcements = service.ActiveAnnouncementsSlideInfo;
			}
			API_v1_Announcement_Response aPI_v1_Announcement_Response = v1.StreamingAction("/v1/announcement/slide_index").AnnouncementResponse();
			API_v1_Announcement_Response.Types.SlideIndex slideIndex = new API_v1_Announcement_Response.Types.SlideIndex();
			APIv1Service.SlideIndex? slideIndex2 = announcements;
			slideIndex.AnnouncementIndex = (((object)slideIndex2 != null) ? slideIndex2.ToAPIv1SlideIndex() : null);
			aPI_v1_Announcement_Response.SlideIndex = slideIndex;
		});
	}

	private static API_v1_Presentation_Response PresentationResponse(this NetworkAPI_v1.Types.Action action)
	{
		return action.PresentationResponse ?? (action.PresentationResponse = new API_v1_Presentation_Response());
	}

	private static API_v1_Announcement_Response AnnouncementResponse(this NetworkAPI_v1.Types.Action action)
	{
		return action.AnnouncementResponse ?? (action.AnnouncementResponse = new API_v1_Announcement_Response());
	}

	private static API_v1_Presentation ToAPIv1Presentation(this IPresentation presentation, IAPIv1Service service)
	{
		API_v1_Presentation obj = new API_v1_Presentation
		{
			Arrangements = { (IEnumerable<API_v1_Presentation.Types.Arrangement>)presentation.SerializeArrangementsToAPI() },
			Id = Common.ID(presentation.ID, presentation.Name, 0u),
			Destination = presentation.Destination.ToAPIProtoDestination()
		};
		RepeatedField<API_v1_Presentation.Types.SlideGroup> groups = obj.Groups;
		IEnumerable<API_v1_Presentation.Types.SlideGroup> values;
		if (!presentation.IsAvailable)
		{
			IEnumerable<API_v1_Presentation.Types.SlideGroup> enumerable = Array.Empty<API_v1_Presentation.Types.SlideGroup>();
			values = enumerable;
		}
		else
		{
			values = presentation.SerializeToSlideGroup(service);
		}
		groups.Add(values);
		obj.HasTimeline = presentation.PresentationTimeline.Any();
		obj.PresentationPath = presentation.SourceFile?.FullPath ?? string.Empty;
		obj.IsAuthorized = presentation.IsAvailable;
		obj.Type = "standard";
		API_v1_Presentation aPI_v1_Presentation = obj;
		string currentArrangement = presentation.ActiveArrangement?.ID.ToString() ?? presentation.DefaultArrangement.ID.ToString();
		aPI_v1_Presentation.CurrentArrangement = currentArrangement;
		aPI_v1_Presentation.TotalCues = (uint)presentation.DefaultArrangement.ArrangedCues.Count;
		if (presentation is MultiTracksPresentation)
		{
			aPI_v1_Presentation.Type = "multitracks";
			if (!presentation.IsAvailable)
			{
				foreach (API_v1_Presentation.Types.SlideGroup group in aPI_v1_Presentation.Groups)
				{
					foreach (API_v1_Presentation.Types.SlideGroup.Types.Slide slide in group.Slides)
					{
						slide.Text = string.Empty;
						slide.Notes = string.Empty;
					}
				}
			}
		}
		return aPI_v1_Presentation;
	}

	[IteratorStateMachine(typeof(_003CSerializeToSlideGroup_003Ed__49))]
	private static IEnumerable<API_v1_Presentation.Types.SlideGroup> SerializeToSlideGroup(this IPresentation presentation, IAPIv1Service service)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CSerializeToSlideGroup_003Ed__49(-2)
		{
			_003C_003E3__presentation = presentation,
			_003C_003E3__service = service
		};
	}

	private static IReadOnlyList<API_v1_Presentation.Types.Arrangement> SerializeArrangementsToAPI(this IPresentation presentation)
	{
		List<API_v1_Presentation.Types.Arrangement> list = new List<API_v1_Presentation.Types.Arrangement>();
		uint num = 0u;
		foreach (IArrangement arrangement2 in presentation.Arrangements)
		{
			API_v1_Presentation.Types.Arrangement arrangement = new API_v1_Presentation.Types.Arrangement
			{
				Id = new API_v1_Identifier
				{
					Uuid = arrangement2.ID.ToString(),
					Name = arrangement2.Name,
					Index = num++
				}
			};
			List<string> values = arrangement2.Select((CueGroup cueGroup) => cueGroup.ID.ToString()).ToList();
			arrangement.Groups.Add(values);
			arrangement.TotalCues = (uint)arrangement2.ArrangedCues.Count;
			list.Add(arrangement);
		}
		if (presentation.ActiveArrangement == null)
		{
			list.Add(new API_v1_Presentation.Types.Arrangement
			{
				Id = new API_v1_Identifier
				{
					Uuid = presentation.DefaultArrangement.ID.ToString(),
					Name = presentation.DefaultArrangement.Name,
					Index = (uint)list.Count
				}
			});
		}
		return list.ToArray();
	}

	private static API_v1_SlideIndex? ToAPIv1SlideIndex(this APIv1Service.SlideIndex slide)
	{
		IPresentation parentPresentation = slide.Slide.Source.ParentPresentation;
		if (parentPresentation == null)
		{
			return null;
		}
		ProPresenterCue playlistCue = null;
		if (parentPresentation.Destination == OutputDestination.Presentation)
		{
			LibraryPlaylistActivePresentationRequest.Publish(delegate(Playlist<ProPresenterCue>? p, ProPresenterCue? i)
			{
				playlistCue = i;
			});
		}
		else
		{
			LibraryPlaylistActiveAnnouncementRequest.Publish(delegate(Playlist<ProPresenterCue>? p, ProPresenterCue? i)
			{
				playlistCue = i;
			});
		}
		object obj;
		if (playlistCue is IDocumentCue documentCue)
		{
			IDocumentAction documentAction = documentCue.DocumentAction;
			if (documentAction != null)
			{
				IArrangement activeArrangement = documentAction.ActiveArrangement;
				if (activeArrangement != null)
				{
					obj = activeArrangement;
					goto IL_008b;
				}
			}
		}
		obj = parentPresentation.ActiveArrangement ?? parentPresentation.DefaultArrangement;
		goto IL_008b;
		IL_008b:
		uint index = (uint)slide.Index;
		uint count = (uint)((IArrangement)obj).ArrangedCues.Count;
		uint remainingCues = ((index < count) ? (count - index - 1) : 0u);
		return new API_v1_SlideIndex
		{
			PresentationId = Common.ID(parentPresentation.ID, parentPresentation.Name, 0u),
			Index = index,
			TotalCues = count,
			RemainingCues = remainingCues
		};
	}

	private static IEnumerable<API_v1_Presentation.Types.SlideGroup.Types.Slide> Serialize(this IEnumerable<SlideCue> cues, IAPIv1Service service)
	{
		return service.Dependencies.PresentationHandlerOperationService.Serialize(cues);
	}

	private static DocumentCue? FindDocument(this IEnumerable<ILibrary> libraries, Guid id)
	{
		return libraries.SelectMany((ILibrary l) => l).FirstOrDefault(delegate(DocumentCue d)
		{
			IPresentation presentation = d.DocumentAction?.Presentation;
			return presentation != null && presentation.ID == id;
		});
	}

	private static FindLibraryAndDocumentResult? FindLibraryAndDocument(this IEnumerable<ILibrary> libraries, Guid id)
	{
		foreach (ILibrary library in libraries)
		{
			foreach (DocumentCue item in library)
			{
				IPresentation presentation = item.DocumentAction?.Presentation;
				if (presentation != null && presentation.ID == id)
				{
					return new FindLibraryAndDocumentResult(library, item);
				}
			}
		}
		return null;
	}
}
