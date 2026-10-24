using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;
using Pro.Common.Components.Reversibility;
using Pro.Common.Logging;
using Pro.Common.Nullability;
using Pro.Common.ObjectBinding;
using Pro.Common.Strings;
using Pro.Common.Utility;
using Pro.DO.Storage;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text.RTF;

namespace ProPresenter.DO.Slide.Links;

public class FileFeedLinkedObject : LinkedTextObjectBase
{
	[CompilerGenerated]
	private sealed class _003C_003CTryReadFile_003Eg__readPlainTextFile_007C24_1_003Ed : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private string _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private string path;

		public string _003C_003E3__path;

		private StreamReader _003Cstream_003E5__2;

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
		public _003C_003CTryReadFile_003Eg__readPlainTextFile_007C24_1_003Ed(int _003C_003E1__state)
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
			_003Cstream_003E5__2 = null;
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
					_003Cstream_003E5__2 = new StreamReader(path);
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				while (_003Cstream_003E5__2.Peek() >= 0)
				{
					string text = _003Cstream_003E5__2.ReadLine();
					if (text != null)
					{
						_003C_003E2__current = text;
						_003C_003E1__state = 1;
						return true;
					}
				}
				_003C_003Em__Finally1();
				_003Cstream_003E5__2 = null;
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
			if (_003Cstream_003E5__2 != null)
			{
				((IDisposable)_003Cstream_003E5__2).Dispose();
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
			_003C_003CTryReadFile_003Eg__readPlainTextFile_007C24_1_003Ed _003C_003CTryReadFile_003Eg__readPlainTextFile_007C24_1_003Ed;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003C_003CTryReadFile_003Eg__readPlainTextFile_007C24_1_003Ed = this;
			}
			else
			{
				_003C_003CTryReadFile_003Eg__readPlainTextFile_007C24_1_003Ed = new _003C_003CTryReadFile_003Eg__readPlainTextFile_007C24_1_003Ed(0);
			}
			_003C_003CTryReadFile_003Eg__readPlainTextFile_007C24_1_003Ed.path = _003C_003E3__path;
			return _003C_003CTryReadFile_003Eg__readPlainTextFile_007C24_1_003Ed;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<string>)this).GetEnumerator();
		}
	}

	private RelativePath _fileSource = new RelativePath();

	private string? _overrideDisplayText;

	public override LinkedTextType LinkedTextType => LinkedTextType.FileFeed;

	public override FormattingType FormattingType => FormattingType.None;

	public override string DisplayText => (string.IsNullOrEmpty(_overrideDisplayText) ? LocalizedStrings.Get("TEXT_LINK_TEXT_TICKER_FILE_SOURCE_title") : _overrideDisplayText) ?? string.Empty;

	public string DisplayFileTextForLinkedObject
	{
		get
		{
			if (!string.IsNullOrEmpty(SourceFile.Name))
			{
				return LocalizedStrings.Get("TEXT_LINK_FILE_FEED_title") + " " + SourceFile.Name;
			}
			return LocalizedStrings.Get("TEXT_LINK_FILE_FEED_title");
		}
	}

	public bool IsValid => SourceFile?.IsValid ?? false;

	public RelativePath SourceFile
	{
		get
		{
			return _fileSource;
		}
		set
		{
			SetValue("SourceFile", ref _fileSource, value, OnSourceFileChanged);
		}
	}

	public static ObjectBinder<FileFeedLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IFileFeed> CreateBinder(FileFeedLinkedObject left, ISlide.Types.IElement.Types.IDataLink.Types.IFileFeed right)
	{
		ObjectBinder<FileFeedLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IFileFeed> objectBinder = new ObjectBinder<FileFeedLinkedObject, ISlide.Types.IElement.Types.IDataLink.Types.IFileFeed>(left, right);
		objectBinder.Bind((FileFeedLinkedObject l) => l.WhenPropertyChanges("SourceFile"), (ISlide.Types.IElement.Types.IDataLink.Types.IFileFeed r) => r.Url.WhenValueChanges, delegate(FileFeedLinkedObject l, ISlide.Types.IElement.Types.IDataLink.Types.IFileFeed r)
		{
			r.Url.Set(RelativePath.Create(l.SourceFile));
		}, delegate(ISlide.Types.IElement.Types.IDataLink.Types.IFileFeed r, FileFeedLinkedObject l)
		{
			l.SourceFile = RelativePath.Create(r.Url.Value, out URL _);
		});
		return objectBinder;
	}

	public override bool RenderEquals([NotNullWhen(true)] ILinkedTextObject? other)
	{
		if (other is FileFeedLinkedObject fileFeedLinkedObject)
		{
			return _fileSource == fileFeedLinkedObject._fileSource;
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(_fileSource);
	}

	public override string GetText(ILinkData? linkData)
	{
		if (linkData != null)
		{
			return TryReadFile(SourceFile);
		}
		return DisplayText;
	}

	public string GetFileText()
	{
		return TryReadFile(SourceFile);
	}

	public override ILinkedTextObject Clone()
	{
		return new FileFeedLinkedObject
		{
			_fileSource = _fileSource.Clone()
		};
	}

	public override void Serialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink)
	{
		dataLink.FileFeed = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.FileFeed
		{
			Url = SourceFile?.Serialize()
		};
	}

	public static FileFeedLinkedObject Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.FileFeed fileType)
	{
		return new FileFeedLinkedObject
		{
			SourceFile = new RelativePath(fileType.Url)
		};
	}

	private void OnSourceFileChanged(RelativePath o, RelativePath n)
	{
		base.UndoStack?.Commit(UndoActionTypes.TickerSourceFilePath.ToAction(), this, "SourceFile", o, n, null, null, autoFinalize: true);
		_overrideDisplayText = ((n?.Filename).NullableIsNullOrEmpty() ? string.Empty : (LocalizedStrings.Get("TEXT_LINK_TEXT_TICKER_FILE_SOURCE_title") + " " + n.Filename));
		OnPropertyChanged("DisplayText");
		OnPropertyChanged("IsValid");
	}

	private static string TryReadFile(RelativePath source)
	{
		try
		{
			if (source.IsValid)
			{
				return string.Join(Environment.NewLine, readFile(source));
			}
		}
		catch
		{
			Log.Error("Could not read file: " + source.Filename);
		}
		return string.Empty;
		static IEnumerable<string> readFile(string path)
		{
			if (!(new FileInfo(path).Extension == ".rtf"))
			{
				return readPlainTextFile(path);
			}
			return readRtfFile(path);
		}
		[IteratorStateMachine(typeof(_003C_003CTryReadFile_003Eg__readPlainTextFile_007C24_1_003Ed))]
		static IEnumerable<string> readPlainTextFile(string path)
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003C_003CTryReadFile_003Eg__readPlainTextFile_007C24_1_003Ed(-2)
			{
				_003C_003E3__path = path
			};
		}
		static IEnumerable<string> readRtfFile(string path)
		{
			string rtfData = File.ReadAllText(path);
			return new PlainTextReader().ReadText(rtfData).Split(LineBreaks.All, StringSplitOptions.None);
		}
	}
}
