using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using Pro.Common.Mathematics;
using Pro.PPT;

namespace ProPresenter.DO.PowerPoint;

public static class PowerPointHelper
{
	[CompilerGenerated]
	private sealed class _003CGetImportData_003Ed__3 : IEnumerable<PowerPointSlideImportData>, IEnumerable, IEnumerator<PowerPointSlideImportData>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private PowerPointSlideImportData _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private string sourcePath;

		public string _003C_003E3__sourcePath;

		private Vector2<double> size;

		public Vector2<double> _003C_003E3__size;

		private IEnumerator<SlideData> _003C_003E7__wrap1;

		PowerPointSlideImportData IEnumerator<PowerPointSlideImportData>.Current
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
		public _003CGetImportData_003Ed__3(int _003C_003E1__state)
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
				int num = _003C_003E1__state;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					_003C_003E1__state = -3;
				}
				else
				{
					_003C_003E1__state = -1;
					if (!PowerPointComHelper.IsCOMAccessible())
					{
						goto IL_00a2;
					}
					_003C_003E7__wrap1 = PowerPointComHelper.GetSlideData(sourcePath, TempPPTDirectory, size).GetEnumerator();
					_003C_003E1__state = -3;
				}
				if (_003C_003E7__wrap1.MoveNext())
				{
					_003C_003E7__wrap1.Current.Deconstruct(out string Image, out string Notes);
					string imagePath = Image;
					string notes = Notes;
					_003C_003E2__current = new PowerPointSlideImportData(imagePath, notes);
					_003C_003E1__state = 1;
					return true;
				}
				_003C_003Em__Finally1();
				_003C_003E7__wrap1 = null;
				goto IL_00a2;
				IL_00a2:
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
		IEnumerator<PowerPointSlideImportData> IEnumerable<PowerPointSlideImportData>.GetEnumerator()
		{
			_003CGetImportData_003Ed__3 _003CGetImportData_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CGetImportData_003Ed__ = this;
			}
			else
			{
				_003CGetImportData_003Ed__ = new _003CGetImportData_003Ed__3(0);
			}
			_003CGetImportData_003Ed__.sourcePath = _003C_003E3__sourcePath;
			_003CGetImportData_003Ed__.size = _003C_003E3__size;
			return _003CGetImportData_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<PowerPointSlideImportData>)this).GetEnumerator();
		}
	}

	private static readonly string TempPPTDirectory;

	static PowerPointHelper()
	{
		TempPPTDirectory = Path.Combine(CommonPaths.Temp, "PowerPoint");
		Directory.CreateDirectory(TempPPTDirectory);
	}

	public static bool IsPowerPointInstalled()
	{
		return PowerPointComHelper.IsCOMAccessible();
	}

	[IteratorStateMachine(typeof(_003CGetImportData_003Ed__3))]
	public static IEnumerable<PowerPointSlideImportData> GetImportData(nint? mainWindowHandle, string sourcePath, Vector2<double> size)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetImportData_003Ed__3(-2)
		{
			_003C_003E3__sourcePath = sourcePath,
			_003C_003E3__size = size
		};
	}
}
