using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Common.Nullability;
using Pro.DO.Label;
using Pro.DO.Triggering;
using Pro.Text;
using Pro.Text.Fills;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Media;
using ProPresenter.DO.PCO;
using ProPresenter.DO.PCO.Items;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;

namespace ProPresenter.DO.Presentation;

public static class PresentationHelper
{
	[CompilerGenerated]
	private sealed class _003CFindMedia_003Ed__15 : IEnumerable<MediaBase>, IEnumerable, IEnumerator<MediaBase>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private MediaBase _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IPresentation presentation;

		public IPresentation _003C_003E3__presentation;

		private IEnumerable<SlideCue> _003CslideCues_003E5__2;

		private IEnumerator<ITimelineItem> _003C_003E7__wrap2;

		private IEnumerator<IAction> _003C_003E7__wrap3;

		private SlideAction _003CslideAction_003E5__5;

		private IEnumerator<VisualMedia> _003C_003E7__wrap5;

		private IEnumerator<ITextFillMedia> _003C_003E7__wrap6;

		MediaBase IEnumerator<MediaBase>.Current
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
		public _003CFindMedia_003Ed__15(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			switch (num)
			{
			case -3:
			case 1:
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
				break;
			case -6:
			case -5:
			case -4:
			case 2:
			case 3:
			case 4:
				try
				{
					switch (num)
					{
					case -5:
					case 3:
						try
						{
						}
						finally
						{
							_003C_003Em__Finally3();
						}
						break;
					case -6:
					case 4:
						try
						{
						}
						finally
						{
							_003C_003Em__Finally4();
						}
						break;
					}
				}
				finally
				{
					_003C_003Em__Finally2();
				}
				break;
			}
			_003CslideCues_003E5__2 = null;
			_003C_003E7__wrap2 = null;
			_003C_003E7__wrap3 = null;
			_003CslideAction_003E5__5 = null;
			_003C_003E7__wrap5 = null;
			_003C_003E7__wrap6 = null;
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
				{
					_003C_003E1__state = -1;
					_003CslideCues_003E5__2 = presentation?.ArrangementGroups.SelectMany((CueGroup g) => g.Cues) ?? Array.Empty<SlideCue>();
					IEnumerable<ITimelineItem> enumerable = presentation?.PresentationTimeline.Select((TimelineItemInfo i) => i.Item) ?? Array.Empty<ITimelineItem>();
					_003C_003E7__wrap2 = enumerable.GetEnumerator();
					_003C_003E1__state = -3;
					goto IL_0100;
				}
				case 1:
					_003C_003E1__state = -3;
					goto IL_0100;
				case 2:
					_003C_003E1__state = -4;
					goto IL_02db;
				case 3:
					_003C_003E1__state = -5;
					goto IL_022a;
				case 4:
					{
						_003C_003E1__state = -6;
						goto IL_02ba;
					}
					IL_0100:
					while (_003C_003E7__wrap2.MoveNext())
					{
						if (_003C_003E7__wrap2.Current is MediaAction mediaAction)
						{
							_003C_003E2__current = mediaAction.Media;
							_003C_003E1__state = 1;
							return true;
						}
					}
					_003C_003Em__Finally1();
					_003C_003E7__wrap2 = null;
					_003C_003E7__wrap3 = _003CslideCues_003E5__2.SelectMany((SlideCue s) => s.Actions).GetEnumerator();
					_003C_003E1__state = -4;
					goto IL_02db;
					IL_02d4:
					_003CslideAction_003E5__5 = null;
					goto IL_02db;
					IL_022a:
					if (_003C_003E7__wrap5.MoveNext())
					{
						VisualMedia current = _003C_003E7__wrap5.Current;
						_003C_003E2__current = current;
						_003C_003E1__state = 3;
						return true;
					}
					_003C_003Em__Finally3();
					_003C_003E7__wrap5 = null;
					_003C_003E7__wrap6 = (from f in _003CslideAction_003E5__5.FindTextMedia()
						select f.mediaFill.Media).NonNull().GetEnumerator();
					_003C_003E1__state = -6;
					goto IL_02ba;
					IL_02db:
					if (_003C_003E7__wrap3.MoveNext())
					{
						IAction current2 = _003C_003E7__wrap3.Current;
						if (current2 is MediaAction mediaAction2)
						{
							_003C_003E2__current = mediaAction2.Media;
							_003C_003E1__state = 2;
							return true;
						}
						_003CslideAction_003E5__5 = current2 as SlideAction;
						if (_003CslideAction_003E5__5 != null)
						{
							_003C_003E7__wrap5 = (from f in _003CslideAction_003E5__5.FindMedia()
								select f.mediaFill.Media).NonNull().GetEnumerator();
							_003C_003E1__state = -5;
							goto IL_022a;
						}
						goto IL_02d4;
					}
					_003C_003Em__Finally2();
					_003C_003E7__wrap3 = null;
					return false;
					IL_02ba:
					if (_003C_003E7__wrap6.MoveNext())
					{
						ITextFillMedia current3 = _003C_003E7__wrap6.Current;
						_003C_003E2__current = (MediaBase)current3;
						_003C_003E1__state = 4;
						return true;
					}
					_003C_003Em__Finally4();
					_003C_003E7__wrap6 = null;
					goto IL_02d4;
				}
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
			if (_003C_003E7__wrap2 != null)
			{
				_003C_003E7__wrap2.Dispose();
			}
		}

		private void _003C_003Em__Finally2()
		{
			_003C_003E1__state = -1;
			if (_003C_003E7__wrap3 != null)
			{
				_003C_003E7__wrap3.Dispose();
			}
		}

		private void _003C_003Em__Finally3()
		{
			_003C_003E1__state = -4;
			if (_003C_003E7__wrap5 != null)
			{
				_003C_003E7__wrap5.Dispose();
			}
		}

		private void _003C_003Em__Finally4()
		{
			_003C_003E1__state = -4;
			if (_003C_003E7__wrap6 != null)
			{
				_003C_003E7__wrap6.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<MediaBase> IEnumerable<MediaBase>.GetEnumerator()
		{
			_003CFindMedia_003Ed__15 _003CFindMedia_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CFindMedia_003Ed__ = this;
			}
			else
			{
				_003CFindMedia_003Ed__ = new _003CFindMedia_003Ed__15(0);
			}
			_003CFindMedia_003Ed__.presentation = _003C_003E3__presentation;
			return _003CFindMedia_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<MediaBase>)this).GetEnumerator();
		}
	}

	private const double MinimumMatchScore = 0.4;

	private const double NameExactMatchWeight = 0.55;

	private const double NameEquivalentMatchWeight = 0.35;

	private const double NamePartialMatchWeight = 0.25;

	private const double TitleExactMatchWeight = 0.3;

	private const double TitlePartialMatchWeight = 0.15;

	private const double ArtistExactMatchWeight = 0.1;

	private const double ArtistPartialMatchWeight = 0.05;

	private const double AuthorExactMatchWeight = 0.2;

	private const double AuthorPartialMatchWeight = 0.1;

	private const double CCLINumberMatchWeight = 1.0;

	private const double CopyrightYearMatchWeight = 0.1;

	public static IPresentation? FindMatchToItem(PCOItem? item, double minimumMatchScore = 0.4)
	{
		return FindMatchToItem(DataVault.LibraryCollection.SelectMany((ILibrary l) => l.Select((DocumentCue c) => c.DocumentAction.Presentation)).NonNull(), item, minimumMatchScore);
	}

	public static IPresentation? FindMatchToItem(IEnumerable<IPresentation> presentations, PCOItem? item, double minimumMatchScore = 0.4)
	{
		return (from kvp in presentations.ToDictionary((IPresentation p) => p, (IPresentation p) => MatchToSong(p, item))
			where kvp.Value >= minimumMatchScore
			orderby kvp.Value
			select kvp.Key).LastOrDefault();
	}

	public static void FindMedia(this IPresentation presentation, Action<string> callback, bool includeMedia = true)
	{
		if (presentation == null)
		{
			return;
		}
		callback(presentation.SourceFile);
		if (!includeMedia)
		{
			return;
		}
		foreach (MediaBase item in presentation.FindMedia())
		{
			item.FindMedia(callback);
		}
		foreach (CustomSlide item2 in from s in (from a in presentation.ArrangementGroups.SelectMany((CueGroup g) => g.Cues).OfType<SlideCue>()
				select a.SlideAction?.Slide).OfType<CustomSlide>()
			where s?.ChordChart?.IsValid == true
			select s)
		{
			callback(item2.ChordChart);
		}
	}

	[IteratorStateMachine(typeof(_003CFindMedia_003Ed__15))]
	public static IEnumerable<MediaBase> FindMedia(this IPresentation presentation)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CFindMedia_003Ed__15(-2)
		{
			_003C_003E3__presentation = presentation
		};
	}

	private static double MatchToSong(IPresentation presentation, PCOItem? item)
	{
		double num = 0.0;
		if (presentation == null)
		{
			return num;
		}
		if (item is PCOPlanSong { Song: not null } pCOPlanSong)
		{
			num += ScoreByName(presentation.Name, pCOPlanSong.Song.Title);
			num += ScoreByTitle(presentation.CCLIInfo.Title, pCOPlanSong.Song.Title);
			num += ScoreByArtist(presentation.CCLIInfo.Artist, pCOPlanSong.Song.Author);
			num += ScoreByAuthor(presentation.CCLIInfo.Author, pCOPlanSong.Song.Author);
			num += ScoreByCCLINumber(presentation.CCLIInfo.SongNumber, pCOPlanSong.Song.CCLI.ToString());
			num += ScoreByCopyrightYear(presentation.CCLIInfo.Copyright, pCOPlanSong.Song.Copyright);
		}
		else if (item is PCOPlanItem pCOPlanItem)
		{
			num += ScoreByName(presentation.Name, pCOPlanItem.Name);
		}
		return num;
	}

	private static double ScoreByName(string name1, string? name2)
	{
		if (string.IsNullOrEmpty(name1) || name2.NullableIsNullOrEmpty())
		{
			return 0.0;
		}
		if (name1 == name2)
		{
			return 0.55;
		}
		if (string.Compare(name1, name2, ignoreCase: true, CultureInfo.CurrentCulture) == 0)
		{
			return 0.35;
		}
		if (name1.Contains(name2))
		{
			return 0.25;
		}
		return 0.0;
	}

	private static double ScoreByTitle(string title1, string? title2)
	{
		if (string.IsNullOrEmpty(title1) || title2.NullableIsNullOrEmpty())
		{
			return 0.0;
		}
		if (title1 == title2)
		{
			return 0.3;
		}
		if (title1.Contains(title2))
		{
			return 0.15;
		}
		return 0.0;
	}

	private static double ScoreByArtist(string artist1, string? artist2)
	{
		if (string.IsNullOrEmpty(artist1) || artist2.NullableIsNullOrEmpty())
		{
			return 0.0;
		}
		if (artist1 == artist2)
		{
			return 0.1;
		}
		if (artist1.Contains(artist2))
		{
			return 0.05;
		}
		return 0.0;
	}

	private static double ScoreByAuthor(string author1, string? author2)
	{
		if (string.IsNullOrEmpty(author1) || author2.NullableIsNullOrEmpty())
		{
			return 0.0;
		}
		if (author1 == author2)
		{
			return 0.2;
		}
		if (author1.Contains(author2))
		{
			return 0.1;
		}
		return 0.0;
	}

	private static double ScoreByCCLINumber(string songNumber1, string songNumber2)
	{
		if (string.IsNullOrEmpty(songNumber1) || string.IsNullOrEmpty(songNumber2))
		{
			return 0.0;
		}
		if (songNumber1 == songNumber2)
		{
			return 1.0;
		}
		return 0.0;
	}

	private static double ScoreByCopyrightYear(string year1, string? year2)
	{
		if (string.IsNullOrEmpty(year1) || year2.NullableIsNullOrEmpty())
		{
			return 0.0;
		}
		if (year1 == year2)
		{
			return 0.1;
		}
		return 0.0;
	}

	public static IEnumerable<SlidesCopyData> GetSlidesData(this IEnumerable<ArrangedCue> arrangedCues, ICopyPresentationIdentifier copySourceIdentifier, IArrangement arrangement)
	{
		List<SlidesCopyData> list = new List<SlidesCopyData>();
		IGrouping<CueGroup, ArrangedCue>[] array = (from a in arrangedCues
			group a by a.Group).ToArray();
		foreach (IGrouping<CueGroup, ArrangedCue> obj in array)
		{
			GroupLabel label = obj.Key.Label;
			IEnumerable<SlideCue> slides = obj.Select((ArrangedCue a) => a.Source);
			bool createGroup = obj.Any((ArrangedCue a) => a.IsGroupHead);
			list.Add(new SlidesCopyData(label, slides, createGroup, arrangement?.ID, arrangement?.Name, copySourceIdentifier));
		}
		return list;
	}

	public static IEnumerable<SlidesCopyData> GetSlidesData(this IEnumerable<SlideCue> slides, ICopyPresentationIdentifier? copySourceIdentifier = null)
	{
		return new SlidesCopyData(new GroupLabel(), slides, createGroup: false, null, null, copySourceIdentifier).ToEnumerable();
	}

	public static int FindSlideNewIndex(IArrangement targetArrangement, IEnumerable<ArrangedCue> movedSlides, ArrangedCue movedSlide, ArrangedCue targetSlide, bool beforeTargetSlide)
	{
		if (targetSlide == null || !movedSlides.Contains(movedSlide))
		{
			return -1;
		}
		IImmutableObservableCollection<ArrangedCue> arrangedCues = targetArrangement.ArrangedCues;
		int num = arrangedCues.IndexOf(targetSlide);
		int num2 = movedSlides.IndexOf(movedSlide) + 1;
		int num3 = num2;
		int num4 = movedSlides.Count() - num2;
		return (num + (beforeTargetSlide ? (-(num4 + 1)) : num3)).Clamp(0, arrangedCues.Count - 1);
	}
}
