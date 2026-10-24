using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Pro.Common.Components;
using Pro.Common.Logging;
using Pro.Common.Nullability;

namespace ProPresenter.DO.Bibles;

public abstract class BibleBase : NotifyPropertyChangedDisposableBase
{
	[CompilerGenerated]
	private sealed class _003CGetVerseContentRange_003Ed__28 : IEnumerable<VerseContent>, IEnumerable, IEnumerator<VerseContent>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private VerseContent _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private BibleReference start;

		public BibleReference _003C_003E3__start;

		private BibleReference end;

		public BibleReference _003C_003E3__end;

		public BibleBase _003C_003E4__this;

		private Book _003Cbook_003E5__2;

		private int _003CchapterNumber_003E5__3;

		private Verse _003Cverse_003E5__4;

		VerseContent IEnumerator<VerseContent>.Current
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
		public _003CGetVerseContentRange_003Ed__28(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Cbook_003E5__2 = null;
			_003Cverse_003E5__4 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			BibleBase bibleBase = _003C_003E4__this;
			int num2;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
				if (_003CchapterNumber_003E5__3 < end.ChapterNumber || _003Cverse_003E5__4.EndNumber < end.VerseNumber)
				{
					num2 = _003Cverse_003E5__4.EndNumber + 1;
					goto IL_0177;
				}
				goto IL_01b2;
			}
			_003C_003E1__state = -1;
			if (start.BookIndex != end.BookIndex || start.BookKey != end.BookKey)
			{
				throw new NotSupportedException("References can not span books");
			}
			_003Cbook_003E5__2 = bibleBase.GetBook(start);
			if ((object)_003Cbook_003E5__2 == null)
			{
				return false;
			}
			_003CchapterNumber_003E5__3 = start.ChapterNumber;
			num2 = start.VerseNumber;
			goto IL_0189;
			IL_0177:
			_003Cverse_003E5__4 = null;
			goto IL_0189;
			IL_0189:
			Chapter chapter;
			while (_003CchapterNumber_003E5__3 <= end.ChapterNumber && _003CchapterNumber_003E5__3 <= _003Cbook_003E5__2.LastChapterNumber)
			{
				chapter = _003Cbook_003E5__2.GetChapter(_003CchapterNumber_003E5__3);
				if ((object)chapter == null)
				{
					_003CchapterNumber_003E5__3 = 1;
					num2 = 1;
					continue;
				}
				goto IL_00b7;
			}
			goto IL_01b2;
			IL_01b2:
			return false;
			IL_00b7:
			_003Cverse_003E5__4 = chapter.GetVerse(num2);
			if ((object)_003Cverse_003E5__4 != null)
			{
				_003C_003E2__current = bibleBase.GetVerseContent(_003Cbook_003E5__2, chapter, _003Cverse_003E5__4);
				_003C_003E1__state = 1;
				return true;
			}
			if (num2 > chapter.LastVerseNumber)
			{
				_003CchapterNumber_003E5__3++;
				num2 = 1;
			}
			else
			{
				num2++;
				if (_003CchapterNumber_003E5__3 >= end.ChapterNumber && num2 > end.VerseNumber)
				{
					goto IL_01b2;
				}
			}
			goto IL_0177;
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
		IEnumerator<VerseContent> IEnumerable<VerseContent>.GetEnumerator()
		{
			_003CGetVerseContentRange_003Ed__28 _003CGetVerseContentRange_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CGetVerseContentRange_003Ed__ = this;
			}
			else
			{
				_003CGetVerseContentRange_003Ed__ = new _003CGetVerseContentRange_003Ed__28(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			_003CGetVerseContentRange_003Ed__.start = _003C_003E3__start;
			_003CGetVerseContentRange_003Ed__.end = _003C_003E3__end;
			return _003CGetVerseContentRange_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<VerseContent>)this).GetEnumerator();
		}
	}

	private Book[]? _books;

	private readonly VerseCache _verseCache;

	public abstract BibleFormat Format { get; }

	public abstract string Name { get; }

	public abstract string TrackingAbbreviation { get; }

	public abstract string DisplayAbbreviation { get; }

	public abstract string Version { get; }

	public abstract string Revision { get; }

	public abstract string Copyright { get; }

	public string SearchIndexPath { get; }

	public Book[] Books
	{
		get
		{
			if (_books == null)
			{
				try
				{
					_books = OnLoadBooks();
				}
				catch
				{
					_books = Array.Empty<Book>();
					Log.Error("Failed to load books for the {0} Bible", Name);
				}
			}
			return _books;
		}
	}

	protected BibleBase(string searchIndexPath)
	{
		_verseCache = new VerseCache(this);
		SearchIndexPath = searchIndexPath;
	}

	protected override void OnDispose(bool disposeObjects)
	{
	}

	protected abstract Book[] OnLoadBooks();

	protected internal abstract Content? LoadVerse(Book book, Chapter chapter, Verse verse);

	protected void CacheVerseContent(Book book, Chapter chapter, Verse verse, Content content)
	{
		_verseCache.Set(new VerseKey(book, chapter, verse), content);
	}

	public Book? GetBook(BibleReference reference)
	{
		return Books.FirstOrDefault((Book b) => b.Key == reference.BookKey) ?? Books.FirstOrDefault((Book b) => b.Name == reference.BookName);
	}

	public VerseContent GetVerseContent(Book book, Chapter chapter, Verse verse)
	{
		VerseKey verseKey = new VerseKey(book, chapter, verse);
		Content content = _verseCache.Get(verseKey);
		content.ThrowWhenNull("cachedContent");
		return new VerseContent(verseKey, content);
	}

	[IteratorStateMachine(typeof(_003CGetVerseContentRange_003Ed__28))]
	public IEnumerable<VerseContent> GetVerseContentRange(BibleReference start, BibleReference end)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetVerseContentRange_003Ed__28(-2)
		{
			_003C_003E4__this = this,
			_003C_003E3__start = start,
			_003C_003E3__end = end
		};
	}
}
