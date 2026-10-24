using System;
using System.Text;
using System.Windows.Input;
using System.Windows.Interop;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.Common.Win32;

namespace Pro.Text;

public class TextComposition : ITextComposition
{
	private class IMEContext : DisposableBase
	{
		private readonly nint _hwnd;

		public nint Context { get; }

		public IMEContext(nint hwnd)
		{
			Context = WindowsFunctions.ImmGetContext(_hwnd = hwnd);
		}

		protected override void OnDispose(bool disposeObjects)
		{
			WindowsFunctions.ImmReleaseContext(_hwnd, Context);
		}
	}

	private readonly Func<Vector2<double>> _getPosition;

	private readonly nint _hwnd;

	private bool _systemCaret;

	private LANG _languageCodeId;

	public event Action? Started;

	public event Action<string>? Updated;

	public event Action<string?>? Complete;

	public TextComposition(Func<Vector2<double>> getPosition, nint hwnd)
	{
		_getPosition = getPosition;
		_hwnd = hwnd;
		HwndSource.FromHwnd(_hwnd).AddHook(OnHook);
	}

	public void SetFocus()
	{
		WindowsFunctions.SetFocus(IntPtr.Zero);
		WindowsFunctions.SetFocus(_hwnd);
	}

	public void Cancel()
	{
		SetFocus();
	}

	private void OnStarted()
	{
		this.Started?.Invoke();
	}

	private void OnUpdated(string text)
	{
		this.Updated?.Invoke(text);
	}

	private void OnComplete(string? text)
	{
		this.Complete?.Invoke(text);
	}

	private nint OnHook(nint hwnd, int msg, nint wParam, nint lParam, ref bool handled)
	{
		handled = false;
		switch ((WM)msg)
		{
		case WM.IMESETCONTEXT:
			OnIMESetContext(hwnd, (uint)msg, wParam, lParam);
			handled = true;
			break;
		case WM.IMESTARTCOMPOSITION:
			OnStarted();
			CreateImeWindow(hwnd);
			MoveImeWindow(hwnd);
			handled = true;
			break;
		case WM.IMECOMPOSITION:
			OnIMEComposition(hwnd, (uint)lParam);
			handled = true;
			break;
		case WM.IMEENDCOMPOSITION:
			OnIMEEndComposition();
			handled = true;
			break;
		}
		if (!handled)
		{
			return new IntPtr(1);
		}
		return IntPtr.Zero;
	}

	private void OnIMEComposition(nint hwnd, uint lParam)
	{
		IMEContext himc = new IMEContext(hwnd);
		try
		{
			string text3;
			if (getText(GCS.RESULTSTR, out var text2))
			{
				OnComplete(text2);
			}
			else if (getText(GCS.COMPSTR, out text3))
			{
				OnUpdated(text3);
			}
			else
			{
				Cancel();
			}
		}
		finally
		{
			if (himc != null)
			{
				((IDisposable)himc).Dispose();
			}
		}
		bool getText(GCS param, out string text)
		{
			text = string.Empty;
			if (!IsParam(lParam, (uint)param))
			{
				return false;
			}
			uint num = WindowsFunctions.ImmGetCompositionString(himc.Context, param, null, 0u);
			if (num == 0)
			{
				return false;
			}
			byte[] array = new byte[num];
			WindowsFunctions.ImmGetCompositionString(himc.Context, param, array, num);
			text = Encoding.Unicode.GetString(array);
			return true;
		}
	}

	private static bool IsParam(uint lParam, uint param)
	{
		return (lParam & param) == param;
	}

	private void OnIMEEndComposition()
	{
		OnComplete(null);
		DestroyImeWindow();
	}

	private void OnIMESetContext(nint hwnd, uint msg, nint wParam, nint lParam)
	{
		OnStarted();
		WindowsFunctions.DefWindowProc(hwnd, msg, wParam, (nint)(((IntPtr)lParam).ToInt64() & 0x7FFFFFFF));
		CreateImeWindow(hwnd);
		MoveImeWindow(hwnd);
	}

	private void CreateImeWindow(nint hwnd)
	{
		_languageCodeId = (LANG)(InputLanguageManager.Current.CurrentInputLanguage.KeyboardLayoutId & 0x3FF);
		if (_languageCodeId.IsAnyOf(LANG.JAPANESE, LANG.CHINESE) && !_systemCaret)
		{
			_systemCaret = WindowsFunctions.CreateCaret(hwnd, IntPtr.Zero, 1, 1);
		}
	}

	private void MoveImeWindow(nint hwnd)
	{
		using IMEContext iMEContext = new IMEContext(hwnd);
		WindowsFunctions.GetDpiForMonitor(WindowsFunctions.MonitorFromWindow(hwnd, MONITOR.DEFAULTTOPRIMARY), MDT.EFFECTIVE_DPI, out var dpiX, out var dpiY);
		Vector2<double> scale = new Vector2<double>(dpiX, dpiY) / 96.0;
		Vector2<int> vector = _getPosition().ComponentwiseProduct(scale).Cast<int>();
		CANDIDATEFORM lpCandidateForm = new CANDIDATEFORM(0u, CFS.CANDIDATEPOS, vector, default(RECT));
		WindowsFunctions.ImmSetCandidateWindow(iMEContext.Context, ref lpCandidateForm);
		if (_systemCaret)
		{
			WindowsFunctions.SetCaretPos(vector.X, vector.Y);
		}
		if (_languageCodeId == LANG.KOREAN)
		{
			vector.Y++;
		}
		CANDIDATEFORM lpCandidateForm2 = new CANDIDATEFORM(0u, CFS.EXCLUDE, vector, new RECT
		{
			Left = vector.X,
			Top = vector.Y,
			Right = vector.X,
			Bottom = vector.Y + 1
		});
		WindowsFunctions.ImmSetCandidateWindow(iMEContext.Context, ref lpCandidateForm2);
	}

	private void DestroyImeWindow()
	{
		if (_systemCaret)
		{
			WindowsFunctions.DestroyCaret();
			_systemCaret = false;
		}
	}
}
