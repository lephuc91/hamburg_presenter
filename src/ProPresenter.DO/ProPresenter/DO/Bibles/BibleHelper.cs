using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using Pro.Common.Collections;
using Pro.Common.Integers;
using Pro.Common.Mathematics;
using Pro.Common.Strings;
using Pro.Common.Utility;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;

namespace ProPresenter.DO.Bibles;

public static class BibleHelper
{
	[CompilerGenerated]
	private sealed class _003CBuildBookNameVariations_003Ed__12 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private string _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private string bookName;

		public string _003C_003E3__bookName;

		private string _003Cprefix_003E5__2;

		private string _003Cname_003E5__3;

		private IEnumerator<string> _003C_003E7__wrap3;

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
		public _003CBuildBookNameVariations_003Ed__12(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			switch (_003C_003E1__state)
			{
			case -3:
			case 2:
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
				break;
			case -4:
			case 3:
				try
				{
				}
				finally
				{
					_003C_003Em__Finally2();
				}
				break;
			}
			_003Cprefix_003E5__2 = null;
			_003Cname_003E5__3 = null;
			_003C_003E7__wrap3 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int value;
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E2__current = bookName;
					_003C_003E1__state = 1;
					return true;
				case 1:
				{
					_003C_003E1__state = -1;
					string[] array = bookName.Split(new char[0], 2);
					if (array.Length != 2)
					{
						break;
					}
					_003Cprefix_003E5__2 = array[0].Trim();
					_003Cname_003E5__3 = array[1].Trim();
					value = 0;
					if (RomanNumeral.ParseRomanNumeral(_003Cprefix_003E5__2, out value))
					{
						_003C_003E7__wrap3 = BuildNumberVariations(value, _003Cname_003E5__3).GetEnumerator();
						_003C_003E1__state = -3;
						goto IL_00e1;
					}
					goto IL_00fb;
				}
				case 2:
					_003C_003E1__state = -3;
					goto IL_00e1;
				case 3:
					{
						_003C_003E1__state = -4;
						goto IL_0153;
					}
					IL_016d:
					_003Cprefix_003E5__2 = null;
					_003Cname_003E5__3 = null;
					break;
					IL_0153:
					if (_003C_003E7__wrap3.MoveNext())
					{
						string current = _003C_003E7__wrap3.Current;
						_003C_003E2__current = current;
						_003C_003E1__state = 3;
						return true;
					}
					_003C_003Em__Finally2();
					_003C_003E7__wrap3 = null;
					goto IL_016d;
					IL_00e1:
					if (_003C_003E7__wrap3.MoveNext())
					{
						string current2 = _003C_003E7__wrap3.Current;
						_003C_003E2__current = current2;
						_003C_003E1__state = 2;
						return true;
					}
					_003C_003Em__Finally1();
					_003C_003E7__wrap3 = null;
					goto IL_00fb;
					IL_00fb:
					if (ParseNumber(_003Cprefix_003E5__2, out value))
					{
						_003C_003E7__wrap3 = BuildNumberVariations(value, _003Cname_003E5__3).GetEnumerator();
						_003C_003E1__state = -4;
						goto IL_0153;
					}
					goto IL_016d;
				}
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
			if (_003C_003E7__wrap3 != null)
			{
				_003C_003E7__wrap3.Dispose();
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

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<string> IEnumerable<string>.GetEnumerator()
		{
			_003CBuildBookNameVariations_003Ed__12 _003CBuildBookNameVariations_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CBuildBookNameVariations_003Ed__ = this;
			}
			else
			{
				_003CBuildBookNameVariations_003Ed__ = new _003CBuildBookNameVariations_003Ed__12(0);
			}
			_003CBuildBookNameVariations_003Ed__.bookName = _003C_003E3__bookName;
			return _003CBuildBookNameVariations_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<string>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003CBuildNumberVariations_003Ed__2 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private string _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private int number;

		public int _003C_003E3__number;

		private string name;

		public string _003C_003E3__name;

		private string _003Cordinal_003E5__2;

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
		public _003CBuildNumberVariations_003Ed__2(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Cordinal_003E5__2 = null;
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
				_003Cordinal_003E5__2 = number + number.GetOrdinal();
				_003C_003E2__current = _003Cordinal_003E5__2 + name;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003C_003E2__current = _003Cordinal_003E5__2 + "." + name;
				_003C_003E1__state = 2;
				return true;
			case 2:
				_003C_003E1__state = -1;
				_003C_003E2__current = _003Cordinal_003E5__2 + " " + name;
				_003C_003E1__state = 3;
				return true;
			case 3:
				_003C_003E1__state = -1;
				_003C_003E2__current = _003Cordinal_003E5__2 + ". " + name;
				_003C_003E1__state = 4;
				return true;
			case 4:
				_003C_003E1__state = -1;
				_003C_003E2__current = number + name;
				_003C_003E1__state = 5;
				return true;
			case 5:
				_003C_003E1__state = -1;
				_003C_003E2__current = number + "." + name;
				_003C_003E1__state = 6;
				return true;
			case 6:
				_003C_003E1__state = -1;
				_003C_003E2__current = number + " " + name;
				_003C_003E1__state = 7;
				return true;
			case 7:
				_003C_003E1__state = -1;
				_003C_003E2__current = number + ". " + name;
				_003C_003E1__state = 8;
				return true;
			case 8:
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
		IEnumerator<string> IEnumerable<string>.GetEnumerator()
		{
			_003CBuildNumberVariations_003Ed__2 _003CBuildNumberVariations_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CBuildNumberVariations_003Ed__ = this;
			}
			else
			{
				_003CBuildNumberVariations_003Ed__ = new _003CBuildNumberVariations_003Ed__2(0);
			}
			_003CBuildNumberVariations_003Ed__.number = _003C_003E3__number;
			_003CBuildNumberVariations_003Ed__.name = _003C_003E3__name;
			return _003CBuildNumberVariations_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<string>)this).GetEnumerator();
		}
	}

	private const string BookPattern = "(.+)";

	[GeneratedRegex("^[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*([0-9]+)[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*([0-9]*)[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*([0-9]*)[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*([0-9]*)[\\,\\<\\.\\>\\?\\/\\|\\\\\\'\\\"\\[\\{\\]\\}\\;\\:\\+\\-_\\=\\s\\*\\(\\)\\&\\^\\%\\$\\#\\@\\!\\~\\`]*(.+)$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex MatchRegex()
	{
		return _003CRegexGenerator_g_003EFE05DB3051E1C1364D8A030A87CE4EBDC5F1DD290025A2F65F21502626D728928__MatchRegex_0.Instance;
	}

	[IteratorStateMachine(typeof(_003CBuildNumberVariations_003Ed__2))]
	public static IEnumerable<string> BuildNumberVariations(int number, string name)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CBuildNumberVariations_003Ed__2(-2)
		{
			_003C_003E3__number = number,
			_003C_003E3__name = name
		};
	}

	public static Book? MatchBook(BibleBase bible, string bookName)
	{
		bookName = bookName.FoldDiacritics();
		return (bible.Books?.ToDictionary((Book b) => b.Name.FoldDiacritics()))?.FirstOrDefaultBy(matchesNameExactly, (KeyValuePair<string, Book> kv) => matchesVariant(kv, BuildBookNameVariations(bookName))).Value;
		bool matchesNameExactly(KeyValuePair<string, Book> kv)
		{
			return string.Equals(kv.Key, bookName, StringComparison.OrdinalIgnoreCase);
		}
		static bool matchesVariant(KeyValuePair<string, Book> kv, IEnumerable<string> targetVariations)
		{
			foreach (string item in BuildBookNameVariations(kv.Key))
			{
				foreach (string targetVariation in targetVariations)
				{
					if (item.StartsWith(targetVariation, StringComparison.OrdinalIgnoreCase))
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	public static AttributeRange[] GetAttributeRanges(IEnumerable<VerseContent> contents, bool includeVerseNumbers, bool includeWordsOfJesus, bool combine)
	{
		List<AttributeRange> list = new List<AttributeRange>();
		int num = 0;
		foreach (VerseContent content in contents)
		{
			int num2 = (includeVerseNumbers ? BuildVerseNumber(content.Key.Verse).Length : 0);
			if (includeVerseNumbers)
			{
				list.Add(new AttributeRange(AttributeType.Superscript, new Pro.Text.Range(num, num2 + num)));
			}
			AttributeRange[] attributeRanges = content.Content.AttributeRanges;
			foreach (AttributeRange attributeRange in attributeRanges)
			{
				if (attributeRange.Type != 0 || includeWordsOfJesus)
				{
					list.Add(new AttributeRange(attributeRange.Type, new Pro.Text.Range(((attributeRange.Range.Start != 0) ? (attributeRange.Range.Start + num2) : 0) + num, attributeRange.Range.End + num2 + num)));
				}
			}
			num += (combine ? content.Content.Text.Length : 0) + num2;
		}
		return list.ToArray();
	}

	public static string BuildVerseNumber(Verse verse)
	{
		if (verse.StartNumber != verse.EndNumber)
		{
			return $"{verse.StartNumber}-{verse.EndNumber}";
		}
		return verse.StartNumber.ToString();
	}

	public static BibleReference NavigateBibleVerse(BibleBase bible, BibleReference reference, bool isForward)
	{
		if (!reference.IsValid)
		{
			return BibleReference.Invalid;
		}
		int num = (isForward ? 1 : (-1));
		int num2 = reference.VerseNumber + num;
		Book book = bible.Books[reference.BookIndex];
		Chapter chapter = book.GetChapter(reference.ChapterNumber);
		if ((object)chapter != null && num2 >= chapter.FirstVerseNumber && num2 <= chapter.LastVerseNumber)
		{
			Verse verse = chapter.GetVerse(num2);
			if ((object)verse == null)
			{
				BibleReference reference2 = new BibleReference(reference.BookIndex, reference.BookKey, reference.BookName, reference.ChapterNumber, num2);
				return NavigateBibleVerse(bible, reference2, isForward);
			}
			return new BibleReference(reference.BookIndex, reference.BookKey, book.Name, reference.ChapterNumber, isForward ? verse.EndNumber : verse.StartNumber);
		}
		int nextChapterNumber = reference.ChapterNumber + num;
		if (nextChapterNumber >= book.FirstChapterNumber && nextChapterNumber <= book.LastChapterNumber)
		{
			Chapter chapter2 = book.Chapters.First((Chapter c) => c.Number == nextChapterNumber);
			return new BibleReference(reference.BookIndex, reference.BookKey, book.Name, nextChapterNumber, isForward ? chapter2.FirstVerseNumber : chapter2.LastVerse.StartNumber);
		}
		return BibleReference.Invalid;
	}

	public static bool ParseReferenceText(BibleBase bible, string text, out BibleReference startReference, out BibleReference endReference)
	{
		bool result = false;
		startReference = default(BibleReference);
		endReference = default(BibleReference);
		if (bible == null || bible.Books == null)
		{
			return result;
		}
		text = text.FoldDiacritics();
		Match match = MatchRegex().Match(text.Inverse());
		if (match.Success)
		{
			IEnumerable<string> source = from g in (from g in match.Groups.Cast<System.Text.RegularExpressions.Group>().Skip(1)
					orderby g.Index
					select g).Reverse()
				select g.Value.Inverse();
			int result2;
			int[] array = (from g in source.Skip(1)
				where !string.IsNullOrWhiteSpace(g)
				select int.TryParse(g, out result2) ? result2 : 0).ToArray();
			string text2 = source.First().Trim();
			if (!string.IsNullOrEmpty(text2))
			{
				Book book = MatchBook(bible, text2);
				if ((object)book != null)
				{
					switch (array.Length)
					{
					case 4:
						startReference = new BibleReference(book.Index, book.Key, book.Name, Math.Min(array[0], array[2]), array[1]);
						endReference = new BibleReference(book.Index, book.Key, book.Name, Math.Max(array[0], array[2]), array[3]);
						break;
					case 3:
						startReference = new BibleReference(book.Index, book.Key, book.Name, array[0], Math.Min(array[1], array[2]));
						endReference = new BibleReference(book.Index, book.Key, book.Name, array[0], Math.Max(array[1], array[2]));
						break;
					case 2:
						startReference = new BibleReference(book.Index, book.Key, book.Name, array[0], array[1]);
						endReference = new BibleReference(book.Index, book.Key, book.Name, array[0], array[1]);
						break;
					case 1:
					{
						int verseNumber = 1;
						Chapter chapter = book.GetChapter(array[0]);
						if ((object)chapter != null)
						{
							verseNumber = chapter.LastVerseNumber;
						}
						startReference = new BibleReference(book.Index, book.Key, book.Name, array[0], 1);
						endReference = new BibleReference(book.Index, book.Key, book.Name, array[0], verseNumber);
						break;
					}
					}
					result = true;
				}
			}
		}
		else
		{
			Book book2 = bible.Books.FirstOrDefault((Book b) => b.Name.Equals(text, StringComparison.InvariantCultureIgnoreCase));
			if ((object)book2 != null)
			{
				startReference = new BibleReference(book2.Index, book2.Key, book2.Name, book2.FirstChapterNumber, 1);
				endReference = new BibleReference(book2.Index, book2.Key, book2.Name, book2.LastChapterNumber, book2.LastChapter.LastVerseNumber);
				result = true;
			}
		}
		return result;
	}

	public static string GetReferenceText(BibleBase bible, BibleReference startReference, BibleReference endReference)
	{
		string result = string.Empty;
		if (bible != null && bible.Books != null && bible.Books.Any())
		{
			string text = bible.GetBook(startReference)?.Name;
			if (string.IsNullOrEmpty(text))
			{
				return string.Empty;
			}
			if (startReference.ChapterNumber != endReference.ChapterNumber)
			{
				result = text + " " + startReference.ChapterNumber + ":" + startReference.VerseNumber + "-" + endReference.ChapterNumber + ":" + endReference.VerseNumber;
			}
			else if (startReference.VerseNumber != endReference.VerseNumber)
			{
				result = text + " " + startReference.ChapterNumber + ":" + startReference.VerseNumber + "-" + endReference.VerseNumber;
			}
			else if (startReference.IsValid)
			{
				result = text + " " + startReference.ChapterNumber + ":" + startReference.VerseNumber;
			}
		}
		return result;
	}

	public static BibleReference ToStartReference(this Pro.SerializationInterop.RVProtoData.Presentation.Types.BibleReference? protoBibleReference)
	{
		if (protoBibleReference == null)
		{
			return BibleReference.Invalid;
		}
		return new BibleReference((int)protoBibleReference.BookIndex, protoBibleReference.BookKey, protoBibleReference.BookName, protoBibleReference.ChapterRange?.Start ?? 0, protoBibleReference.VerseRange?.Start ?? 0);
	}

	public static BibleReference ToEndReference(this Pro.SerializationInterop.RVProtoData.Presentation.Types.BibleReference? protoBibleReference)
	{
		if (protoBibleReference == null)
		{
			return BibleReference.Invalid;
		}
		return new BibleReference((int)protoBibleReference.BookIndex, protoBibleReference.BookKey, protoBibleReference.BookName, protoBibleReference.ChapterRange?.End ?? 0, protoBibleReference.VerseRange?.End ?? 0);
	}

	public static bool IsBible(this Pro.SerializationInterop.RVProtoData.Presentation data)
	{
		Pro.SerializationInterop.RVProtoData.Presentation.Types.BibleReference bibleReference = data.BibleReference;
		if (bibleReference != null)
		{
			BibleReference bibleReference2 = bibleReference.ToStartReference();
			BibleReference bibleReference3 = bibleReference.ToEndReference();
			if (bibleReference2.IsValid)
			{
				return bibleReference3.IsValid;
			}
			return false;
		}
		return false;
	}

	[IteratorStateMachine(typeof(_003CBuildBookNameVariations_003Ed__12))]
	private static IEnumerable<string> BuildBookNameVariations(string bookName)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CBuildBookNameVariations_003Ed__12(-2)
		{
			_003C_003E3__bookName = bookName
		};
	}

	private static bool ParseNumber(string data, out int value)
	{
		Match match = RegexFilters.HasNumbers.Match(data);
		if (!match.Success || !int.TryParse(match.Value, out value))
		{
			value = 0;
		}
		return match.Success;
	}

	public static BibleReference ValidateBibleReference(BibleBase bible, BibleReference reference)
	{
		Book book = bible.GetBook(reference);
		if ((object)book == null)
		{
			return BibleReference.Invalid;
		}
		Chapter chapter = book.GetChapter(reference.ChapterNumber.Clamp(book.FirstChapterNumber, book.LastChapterNumber)) ?? book.FirstChapter;
		int verseNumber = reference.VerseNumber.Clamp(chapter.FirstVerseNumber, chapter.LastVerseNumber);
		return new BibleReference(book.Index, book.Key, book.Name, chapter.Number, verseNumber);
	}

	public static BibleTranslationCollection? GetTranslationsFromProto(Pro.SerializationInterop.RVProtoData.Presentation.Types.BibleReference protoBibleReference)
	{
		if (protoBibleReference == null)
		{
			return null;
		}
		return new BibleTranslationCollection(new List<BibleTranslation>
		{
			new BibleTranslation(protoBibleReference.TranslationInternalAbbreviation)
		});
	}
}
