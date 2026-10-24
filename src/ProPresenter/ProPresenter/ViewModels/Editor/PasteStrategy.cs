using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Nullability;
using Pro.DO.Storage;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Media;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;
using ProPresenter.DO.Slide.Custom.Elements.Shapes;
using ProPresenter.DO.Slide.Links;
using ProPresenter.UI;

namespace ProPresenter.ViewModels.Editor;

public class PasteStrategy : IPasteStrategy
{
	[CompilerGenerated]
	private sealed class _003CGetClipboardImage_003Ed__9 : IEnumerable<(SlideElementBase Element, RelativePath? MediaPath)>, IEnumerable, IEnumerator<(SlideElementBase Element, RelativePath? MediaPath)>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private (SlideElementBase Element, RelativePath? MediaPath) _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public PasteStrategy _003C_003E4__this;

		private string containerId;

		public string _003C_003E3__containerId;

		(SlideElementBase Element, RelativePath? MediaPath) IEnumerator<(SlideElementBase, RelativePath)>.Current
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
		public _003CGetClipboardImage_003Ed__9(int _003C_003E1__state)
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
			int num = _003C_003E1__state;
			PasteStrategy pasteStrategy = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
			{
				_003C_003E1__state = -1;
				string image = pasteStrategy._clipboardProvider.GetImage();
				if (image.NullableIsNullOrEmpty())
				{
					return false;
				}
				_003C_003E2__current = (Element: new RectangleShape(pasteStrategy._factoryProvider, containerId)
				{
					Fill = new MediaFill(pasteStrategy._factoryProvider.MediaFactory, containerId)
					{
						Media = (pasteStrategy._factoryProvider.MediaFactory.CreateEmptyFileMedia(new RelativePath(image), containerId, null) as VisualMedia)
					}
				}, MediaPath: new RelativePath(image));
				_003C_003E1__state = 1;
				return true;
			}
			case 1:
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
		IEnumerator<(SlideElementBase Element, RelativePath? MediaPath)> IEnumerable<(SlideElementBase, RelativePath)>.GetEnumerator()
		{
			_003CGetClipboardImage_003Ed__9 _003CGetClipboardImage_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CGetClipboardImage_003Ed__ = this;
			}
			else
			{
				_003CGetClipboardImage_003Ed__ = new _003CGetClipboardImage_003Ed__9(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			_003CGetClipboardImage_003Ed__.containerId = _003C_003E3__containerId;
			return _003CGetClipboardImage_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<(SlideElementBase, RelativePath)>)this).GetEnumerator();
		}
	}

	private readonly IClipboardProvider _clipboardProvider;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	public EditMode EditMode { get; set; }

	public PasteStrategy(IClipboardProvider clipboardProvider, IProPresenterDOFactoryProvider factoryProvider)
	{
		_clipboardProvider = clipboardProvider;
		_factoryProvider = factoryProvider;
	}

	public bool CanPasteElements()
	{
		if (!_clipboardProvider.ContainsData<SlideElementBase>() || !_clipboardProvider.GetData<SlideElementBase>().CloneItems().Any(IsPasteable))
		{
			return _clipboardProvider.ContainsImage();
		}
		return true;
	}

	public IEnumerable<(SlideElementBase Element, RelativePath? MediaPath)> GetPastableItems(string containerId)
	{
		(SlideElementBase, RelativePath)[] array = (from x in _clipboardProvider.GetData<SlideElementBase>()?.Where(IsPasteable).CloneItems()
			select ((SlideElementBase x, RelativePath))(x: x, null)).ToArray() ?? Array.Empty<(SlideElementBase, RelativePath)>();
		if (!array.Empty())
		{
			return array;
		}
		return GetClipboardImage(containerId).ToArray();
	}

	[IteratorStateMachine(typeof(_003CGetClipboardImage_003Ed__9))]
	private IEnumerable<(SlideElementBase Element, RelativePath? MediaPath)> GetClipboardImage(string containerId)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetClipboardImage_003Ed__9(-2)
		{
			_003C_003E4__this = this,
			_003C_003E3__containerId = containerId
		};
	}

	private bool IsPasteable(SlideElementBase element)
	{
		if (!(element is ClosedBezierPath closedBezierPath) || (closedBezierPath.FillLink.LinkedObject == null && closedBezierPath.TextLink.LinkedObject == null))
		{
			return true;
		}
		switch (EditMode)
		{
		case EditMode.CCLITemplate:
			return true;
		case EditMode.Presentation:
		case EditMode.Stage:
		case EditMode.Prop:
		case EditMode.Template:
			return !IsCCLILinked(closedBezierPath.TextLink.LinkedObject);
		case EditMode.Mask:
			if (!closedBezierPath.TextLink.IsEnabled)
			{
				return !closedBezierPath.FillLink.IsEnabled;
			}
			return false;
		default:
			throw new Exception("Unknown edit mode");
		}
	}

	private static bool IsCCLILinked(ILinkedTextObject? linkedObject)
	{
		if (linkedObject == null)
		{
			return false;
		}
		return linkedObject.LinkedTextType == LinkedTextType.CCLITemplate;
	}

	public bool CanPasteSlides<I>(Func<I, IEnumerable<SlideElementBase>> convert, Func<I, bool>? isPasteable = null) where I : ICloneable<I>
	{
		return ClipboardManagerHelper.GetPasteableItems(isPasteable).AnyAndAll((I slide) => convert(slide).All(IsPasteable));
	}

	public IEnumerable<I> PasteSlides<T, I>(T collection, int index, Func<I, bool>? isPasteable = null) where T : ICutPasteCollection<I> where I : ICloneable<I>
	{
		return ClipboardManagerHelper.PasteIntoCollection(collection, index, isPasteable);
	}
}
