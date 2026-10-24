using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Editor;

namespace ProPresenter.DO.Slide.Custom.Elements;

public static class ElementOrdonnance
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public IEnumerable<Vector2<double>> values;

		internal bool _003CDistributeValues_003Eb__0(Vector2<double> value)
		{
			return value.X == values.Min((Vector2<double> v) => v.X);
		}

		internal bool _003CDistributeValues_003Eb__1(Vector2<double> value)
		{
			return value.Y == values.Min((Vector2<double> v) => v.Y);
		}

		internal bool _003CDistributeValues_003Eb__2(Vector2<double> value)
		{
			return value.X == values.Max((Vector2<double> v) => v.X);
		}

		internal bool _003CDistributeValues_003Eb__3(Vector2<double> value)
		{
			return value.Y == values.Max((Vector2<double> v) => v.Y);
		}
	}

	[CompilerGenerated]
	private sealed class _003CDistributeValues_003Ed__7 : IEnumerable<Vector2<double>>, IEnumerable, IEnumerator<Vector2<double>>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private Vector2<double> _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<Vector2<double>> values;

		public IEnumerable<Vector2<double>> _003C_003E3__values;

		private bool orientHorizontally;

		public bool _003C_003E3__orientHorizontally;

		private _003C_003Ec__DisplayClass7_0 _003C_003E8__1;

		private Vector2<double> _003ClowestPoint_003E5__2;

		private Vector2<double> _003Cincrement_003E5__3;

		private int _003Ci_003E5__4;

		Vector2<double> IEnumerator<Vector2<double>>.Current
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
		public _003CDistributeValues_003Ed__7(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E8__1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
			{
				_003C_003E1__state = -1;
				_003C_003E8__1 = new _003C_003Ec__DisplayClass7_0();
				_003C_003E8__1.values = values;
				_003ClowestPoint_003E5__2 = (orientHorizontally ? _003C_003E8__1.values.First((Vector2<double> value) => value.X == _003C_003E8__1.values.Min((Vector2<double> v) => v.X)) : _003C_003E8__1.values.First((Vector2<double> value) => value.Y == _003C_003E8__1.values.Min((Vector2<double> v) => v.Y)));
				Vector2<double> vector = (orientHorizontally ? _003C_003E8__1.values.First((Vector2<double> value) => value.X == _003C_003E8__1.values.Max((Vector2<double> v) => v.X)) : _003C_003E8__1.values.First((Vector2<double> value) => value.Y == _003C_003E8__1.values.Max((Vector2<double> v) => v.Y)));
				_003Cincrement_003E5__3 = (vector - _003ClowestPoint_003E5__2) / (_003C_003E8__1.values.Count() - 1);
				_003Ci_003E5__4 = 0;
				break;
			}
			case 1:
				_003C_003E1__state = -1;
				_003Ci_003E5__4++;
				break;
			}
			if (_003Ci_003E5__4 < _003C_003E8__1.values.Count())
			{
				_003C_003E2__current = _003ClowestPoint_003E5__2 + _003Cincrement_003E5__3 * _003Ci_003E5__4;
				_003C_003E1__state = 1;
				return true;
			}
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
		IEnumerator<Vector2<double>> IEnumerable<Vector2<double>>.GetEnumerator()
		{
			_003CDistributeValues_003Ed__7 _003CDistributeValues_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CDistributeValues_003Ed__ = this;
			}
			else
			{
				_003CDistributeValues_003Ed__ = new _003CDistributeValues_003Ed__7(0);
			}
			_003CDistributeValues_003Ed__.values = _003C_003E3__values;
			_003CDistributeValues_003Ed__.orientHorizontally = _003C_003E3__orientHorizontally;
			return _003CDistributeValues_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Vector2<double>>)this).GetEnumerator();
		}
	}

	public static void AlignElement(ICanvasElement element, AlignmentType alignmentType)
	{
		AlignElement(element, element.CanvasParent?.SnapBounds ?? default(Rect<double>), alignmentType);
	}

	public static void AlignElements(IEnumerable<ICanvasElement> selectedElements, AlignmentType alignmentType)
	{
		Rect<double> selectedRegion = selectedElements.Select((ICanvasElement x) => x.SnapBounds).GetBoundingBox();
		selectedElements.ForEach(delegate(ICanvasElement e)
		{
			AlignElement(e, selectedRegion, alignmentType);
		});
	}

	private static void AlignElement(ICanvasElement element, Rect<double> region, AlignmentType alignmentType)
	{
		switch (alignmentType)
		{
		case AlignmentType.Top:
			element.Position += new Vector2<double>(0.0, region.Top - element.SnapBounds.Top);
			break;
		case AlignmentType.Middle:
			element.Position += new Vector2<double>(0.0, region.Center.Y - element.SnapBounds.Center.Y);
			break;
		case AlignmentType.Bottom:
			element.Position += new Vector2<double>(0.0, region.Bottom - element.SnapBounds.Bottom);
			break;
		case AlignmentType.Left:
			element.Position += new Vector2<double>(region.Left - element.SnapBounds.Left, 0.0);
			break;
		case AlignmentType.Center:
			element.Position += new Vector2<double>(region.Center.X - element.SnapBounds.Center.X, 0.0);
			break;
		case AlignmentType.Right:
			element.Position += new Vector2<double>(region.Right - element.SnapBounds.Right, 0.0);
			break;
		}
	}

	private static void NormalizeZOrder(IEnumerable<ICanvasElement> sourceCollection)
	{
		ICanvasElement[] array = sourceCollection.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].ZOrder = i;
		}
	}

	public static void ChangeElementZOrder(IEnumerable<ICanvasElement> sourceCollection, IEnumerable<ICanvasElement> selectedElements, int targetZOrder)
	{
		IOrderedEnumerable<ICanvasElement> source = from e in sourceCollection.Except(selectedElements)
			orderby e.ZOrder
			select e;
		ICanvasElement[] first = source.Where((ICanvasElement e) => e.ZOrder < targetZOrder).ToArray();
		ICanvasElement[] second = selectedElements.OrderBy((ICanvasElement e) => e.ZOrder).ToArray();
		ICanvasElement[] second2 = source.Where((ICanvasElement e) => e.ZOrder >= targetZOrder).ToArray();
		NormalizeZOrder(first.Concat(second).Concat(second2));
	}

	public static void ChangeElementZOrder(IEnumerable<ICanvasElement> sourceCollection, IEnumerable<ICanvasElement> selectedElements, ZOrderDirection direction)
	{
		if (!selectedElements.Any())
		{
			return;
		}
		int num = 0;
		ICanvasElement[] source;
		Func<ICanvasElement[]> func;
		if ((direction == ZOrderDirection.Forward || direction == ZOrderDirection.Front) ? true : false)
		{
			source = selectedElements.OrderBy((ICanvasElement e) => e.ZOrder).ToArray();
			func = () => sourceCollection.OrderBy((ICanvasElement e) => e.ZOrder).ToArray();
			num = 1;
		}
		else
		{
			func = () => sourceCollection.OrderByDescending((ICanvasElement e) => e.ZOrder).ToArray();
			source = selectedElements.OrderByDescending((ICanvasElement e) => e.ZOrder).ToArray();
			num = -1;
		}
		ICanvasElement[] allOrdered = func();
		ICanvasElement[][] array = source.ContiguousGroups((ICanvasElement e, ICanvasElement n) => allOrdered.IndexOf(e) + 1 == allOrdered.IndexOf(n)).ToArray();
		ICanvasElement[][] array2 = array;
		foreach (ICanvasElement[] array3 in array2)
		{
			ICanvasElement canvasElement = array3.Last();
			if (canvasElement == allOrdered.Last())
			{
				continue;
			}
			int num2 = ((direction == ZOrderDirection.Front || direction == ZOrderDirection.Back) ? (allOrdered.Length - 1) : (allOrdered.IndexOf(canvasElement) + 1));
			ICanvasElement targetElement = allOrdered[num2];
			ICanvasElement[] second = (from e in allOrdered.Skip(num2 + 1)
				where e.ZOrder != (targetElement?.ZOrder ?? 0)
				select e).ToArray();
			int num3 = num;
			foreach (ICanvasElement item in array3.Concat(second))
			{
				item.ZOrder = (targetElement?.ZOrder ?? 0) + num3;
				num3 += num;
			}
			if (array3 != array.Last())
			{
				allOrdered = func();
			}
		}
	}

	public static void DistributeElements(IEnumerable<ICanvasElement> selectedElements, DistributionType distributionType)
	{
		bool flag = distributionType != DistributionType.Vertically;
		ICanvasElement[] array = (flag ? selectedElements.OrderBy((ICanvasElement e) => e.SnapBounds.Center.X) : selectedElements.OrderBy((ICanvasElement e) => e.SnapBounds.Center.Y)).ToArray();
		Vector2<double>[] array2 = DistributeValues(array.Select((ICanvasElement e) => e.SnapBounds.Center), flag).ToArray();
		for (int i = 0; i < array2.Length; i++)
		{
			ICanvasElement canvasElement = array[i];
			Vector2<double> vector = array2[i] - canvasElement.SnapBounds.Center;
			canvasElement.Position = new Vector2<double>((distributionType == DistributionType.Vertically) ? canvasElement.Position.X : (canvasElement.Position.X + vector.X), (distributionType == DistributionType.Horizontally) ? canvasElement.Position.Y : (canvasElement.Position.Y + vector.Y));
		}
	}

	[IteratorStateMachine(typeof(_003CDistributeValues_003Ed__7))]
	private static IEnumerable<Vector2<double>> DistributeValues(IEnumerable<Vector2<double>> values, bool orientHorizontally)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDistributeValues_003Ed__7(-2)
		{
			_003C_003E3__values = values,
			_003C_003E3__orientHorizontally = orientHorizontally
		};
	}
}
