using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Mathematics;

namespace Pro.UI.Utility;

public class SpellErrorIndicator : Adorner
{
	[CompilerGenerated]
	private sealed class _003CGenerateLineGeometries_003Ed__4 : IEnumerable<LineGeometry>, IEnumerable, IEnumerator<LineGeometry>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private LineGeometry _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private LineSegment<double> line;

		public LineSegment<double> _003C_003E3__line;

		private double _003Cx_003E5__2;

		private Vector2<double> _003Cend_003E5__3;

		LineGeometry IEnumerator<LineGeometry>.Current
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
		public _003CGenerateLineGeometries_003Ed__4(int _003C_003E1__state)
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
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003Cx_003E5__2 = line.A.X;
				break;
			case 1:
			{
				_003C_003E1__state = -1;
				Vector2<double> vector = _003Cend_003E5__3;
				_003Cend_003E5__3 = vector + new Vector2<double>(4.0);
				_003C_003E2__current = new LineGeometry(vector, _003Cend_003E5__3);
				_003C_003E1__state = 2;
				return true;
			}
			case 2:
				_003C_003E1__state = -1;
				_003Cx_003E5__2 += 8.0;
				break;
			}
			if (_003Cx_003E5__2 <= line.B.X)
			{
				Vector2<double> vector = new Vector2<double>(_003Cx_003E5__2, line.A.Y + 4.0);
				_003Cend_003E5__3 = vector + new Vector2<double>(4.0, -4.0);
				_003C_003E2__current = new LineGeometry(vector, _003Cend_003E5__3);
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
		IEnumerator<LineGeometry> IEnumerable<LineGeometry>.GetEnumerator()
		{
			_003CGenerateLineGeometries_003Ed__4 _003CGenerateLineGeometries_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CGenerateLineGeometries_003Ed__ = this;
			}
			else
			{
				_003CGenerateLineGeometries_003Ed__ = new _003CGenerateLineGeometries_003Ed__4(0);
			}
			_003CGenerateLineGeometries_003Ed__.line = _003C_003E3__line;
			return _003CGenerateLineGeometries_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<LineGeometry>)this).GetEnumerator();
		}
	}

	private const double BlockSize = 4.0;

	private readonly GeometryGroup _lineGeometry = new GeometryGroup();

	public SpellErrorIndicator(UIElement adornedElement, IEnumerable<LineSegment<double>> lines)
		: base(adornedElement)
	{
		base.IsHitTestVisible = false;
		foreach (LineSegment<double> line in lines)
		{
			GenerateLineGeometries(line).ForEach(_lineGeometry.Children.Add);
		}
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		base.OnRender(drawingContext);
		drawingContext.DrawGeometry(null, new Pen(Brushes.Red, 1.0), _lineGeometry);
	}

	[IteratorStateMachine(typeof(_003CGenerateLineGeometries_003Ed__4))]
	private IEnumerable<LineGeometry> GenerateLineGeometries(LineSegment<double> line)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGenerateLineGeometries_003Ed__4(-2)
		{
			_003C_003E3__line = line
		};
	}
}
