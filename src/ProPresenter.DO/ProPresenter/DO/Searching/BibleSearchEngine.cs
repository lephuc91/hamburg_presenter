using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Pro.Common.Collections;
using Pro.Common.Logging;
using Pro.Common.Strings;
using Pro.Search;
using Pro.Text;
using ProPresenter.DO.Bibles;

namespace ProPresenter.DO.Searching;

public class BibleSearchEngine : SearchEngine
{
	[CompilerGenerated]
	private sealed class _003C_003CIndex_003Eg__GetFieldIDs_007C12_0_003Ed : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private string _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public BibleSearchEngine _003C_003E4__this;

		private Book[] _003C_003E7__wrap1;

		private int _003C_003E7__wrap2;

		private Book _003Cbook_003E5__4;

		private Chapter[] _003C_003E7__wrap4;

		private int _003C_003E7__wrap5;

		private Chapter _003Cchapter_003E5__7;

		private Verse[] _003C_003E7__wrap7;

		private int _003C_003E7__wrap8;

		string IEnumerator<string>.Current
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
		public _003C_003CIndex_003Eg__GetFieldIDs_007C12_0_003Ed(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E7__wrap1 = null;
			_003Cbook_003E5__4 = null;
			_003C_003E7__wrap4 = null;
			_003Cchapter_003E5__7 = null;
			_003C_003E7__wrap7 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			BibleSearchEngine bibleSearchEngine = _003C_003E4__this;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
				_003C_003E7__wrap8++;
				goto IL_0130;
			}
			_003C_003E1__state = -1;
			_003C_003E7__wrap1 = bibleSearchEngine._bible.Books;
			_003C_003E7__wrap2 = 0;
			goto IL_018e;
			IL_018e:
			if (_003C_003E7__wrap2 < _003C_003E7__wrap1.Length)
			{
				_003Cbook_003E5__4 = _003C_003E7__wrap1[_003C_003E7__wrap2];
				_003C_003E7__wrap4 = _003Cbook_003E5__4.Chapters;
				_003C_003E7__wrap5 = 0;
				goto IL_015f;
			}
			_003C_003E7__wrap1 = null;
			return false;
			IL_0130:
			if (_003C_003E7__wrap8 < _003C_003E7__wrap7.Length)
			{
				Verse verse = _003C_003E7__wrap7[_003C_003E7__wrap8];
				global::_003C_003Ey__InlineArray3<object> buffer = default(global::_003C_003Ey__InlineArray3<object>);
				global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray3<object>, object>(ref buffer, 0) = _003Cbook_003E5__4.Index;
				global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray3<object>, object>(ref buffer, 1) = _003Cchapter_003E5__7.Number;
				global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray3<object>, object>(ref buffer, 2) = verse.StartNumber;
				_003C_003E2__current = string.Join("|", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray3<object>, object>(in buffer, 3));
				_003C_003E1__state = 1;
				return true;
			}
			_003C_003E7__wrap7 = null;
			_003Cchapter_003E5__7 = null;
			_003C_003E7__wrap5++;
			goto IL_015f;
			IL_015f:
			if (_003C_003E7__wrap5 < _003C_003E7__wrap4.Length)
			{
				_003Cchapter_003E5__7 = _003C_003E7__wrap4[_003C_003E7__wrap5];
				_003C_003E7__wrap7 = _003Cchapter_003E5__7.Verses;
				_003C_003E7__wrap8 = 0;
				goto IL_0130;
			}
			_003C_003E7__wrap4 = null;
			_003Cbook_003E5__4 = null;
			_003C_003E7__wrap2++;
			goto IL_018e;
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
		IEnumerator<string> IEnumerable<string>.GetEnumerator()
		{
			_003C_003CIndex_003Eg__GetFieldIDs_007C12_0_003Ed result;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				result = this;
			}
			else
			{
				result = new _003C_003CIndex_003Eg__GetFieldIDs_007C12_0_003Ed(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			return result;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<string>)this).GetEnumerator();
		}
	}

	private const int MaxSearchResults = 125;

	private static readonly IndexField[] IndexFields = new IndexField[1]
	{
		new IndexField("VerseContent", 1.0, MatchType.TermExactAny | MatchType.PhraseExact | MatchType.TermWildcardAll)
	};

	private readonly BibleBase _bible;

	public string Abbreviation => _bible.TrackingAbbreviation;

	protected override int IndexVersion => -1;

	public BibleSearchEngine(BibleBase bible)
		: base(bible.SearchIndexPath, IndexFields, AnalyzerType.Simple)
	{
		base.MaxResults = 125;
		_bible = bible;
	}

	public static void IndexBible(BibleBase bible)
	{
		new BibleSearchEngine(bible).Index();
	}

	public IEnumerable<SearchResult> Search(string queryText)
	{
		return (from s in Search(queryText, (string t) => ParseResult(t, queryText))
			select s.Item).NonNull();
	}

	private SearchResult? ParseResult(string fieldID, string queryText)
	{
		(Book, Chapter, Verse)? tuple = ParseData(fieldID);
		if (!tuple.HasValue)
		{
			return null;
		}
		(Book, Chapter, Verse) value = tuple.Value;
		Book item = value.Item1;
		Chapter item2 = value.Item2;
		Verse item3 = value.Item3;
		VerseContent verseContent = _bible.GetVerseContent(item, item2, item3);
		Pro.Text.Range[] keywordRange = (from i in verseContent.Content.Text.AllIndicesOf(queryText, StringComparison.OrdinalIgnoreCase)
			select new Pro.Text.Range(i, i + queryText.Length - 1)).ToArray();
		string passageText = $"{item.Name} {item2.Number}:{item3.StartNumber}";
		return new SearchResult(verseContent, keywordRange, passageText);
	}

	private (Book book, Chapter chapter, Verse verse)? ParseData(string s)
	{
		string[] array = s.Split('|');
		if (array.Length != 3 || !int.TryParse(array[0], out var result) || !int.TryParse(array[1], out var result2) || !int.TryParse(array[2], out var result3))
		{
			Log.Warning("Unknown key in the bible index - {0} in bible - {1} [{2}]", s, _bible.Name, _bible.TrackingAbbreviation);
			return null;
		}
		Book book = _bible.Books.ElementAtOrDefault(result);
		if ((object)book == null)
		{
			Log.Warning("Bad key in the bible index - {0} book index out of range in bible - {1} [{2}]", s, _bible.Name, _bible.TrackingAbbreviation);
			return null;
		}
		Chapter chapter = book.GetChapter(result2);
		if ((object)chapter == null)
		{
			Log.Warning("Bad key in the bible index - {0} chapter index out of range in bible - {1} [{2}]", s, _bible.Name, _bible.TrackingAbbreviation);
			return null;
		}
		Verse verse = chapter.GetVerse(result3);
		if ((object)verse == null)
		{
			Log.Warning("Bad key in the bible index - {0} verse index out of range in bible - {1} [{2}]", s, _bible.Name, _bible.TrackingAbbreviation);
			return null;
		}
		return (book, chapter, verse);
	}

	private void Index()
	{
		IndexRange(GetFieldIDs(), delegate(string fieldID, string fieldName)
		{
			(Book, Chapter, Verse)? tuple = ParseData(fieldID);
			if (!tuple.HasValue)
			{
				return string.Empty;
			}
			var (book, chapter, verse) = tuple.Value;
			return _bible.GetVerseContent(book, chapter, verse).Content.Text;
		});
		[IteratorStateMachine(typeof(_003C_003CIndex_003Eg__GetFieldIDs_007C12_0_003Ed))]
		IEnumerable<string> GetFieldIDs()
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003C_003CIndex_003Eg__GetFieldIDs_007C12_0_003Ed(-2)
			{
				_003C_003E4__this = this
			};
		}
	}
}
