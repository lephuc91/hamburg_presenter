using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Windows.Input;
using Pro.Common.SourceGenerator.Attributes;

namespace Pro.Common.Utility;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class KeyPressService : IDisposable
{
	private const double DOUBLE_PRESS_THRESHOLD_IN_MS = 300.0;

	private const double HELD_DOWN_THRESHOLD_IN_MS = 100.0;

	private readonly Dictionary<Key, DateTime> _keyHistory = new Dictionary<Key, DateTime>();

	private readonly Dictionary<Key, Timer> _keyTimers = new Dictionary<Key, Timer>();

	private readonly Key[] _registeredKeys;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public event EventHandler<KeyEventArgs>? OnKeyDoublePressed;

	public event EventHandler<KeyEventArgs>? OnKeyHeldDown;

	public event EventHandler<KeyEventArgs>? OnKeyReleased;

	public KeyPressService(Key[] registeredKeys)
	{
		_registeredKeys = registeredKeys;
	}

	public void OnKeyDown(KeyEventArgs e)
	{
		CheckOnKeyEvent(e);
	}

	public void OnKeyUp(KeyEventArgs e)
	{
		CheckOnKeyEvent(e);
	}

	private void CheckOnKeyEvent(KeyEventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		if (_registeredKeys == null || !_registeredKeys.Contains(e.Key))
		{
			return;
		}
		if (e.IsDown && !e.IsRepeat)
		{
			DateTime now = DateTime.Now;
			if (_keyHistory.TryGetValue(e.Key, out var value))
			{
				_keyTimers[e.Key].Stop();
				if ((now - value).TotalMilliseconds <= 300.0)
				{
					this.OnKeyDoublePressed?.Invoke(this, e);
				}
			}
			else
			{
				InitializeKey(e);
			}
			_keyHistory[e.Key] = now;
			_keyTimers[e.Key].Start();
		}
		else if (e.IsUp)
		{
			if (_keyTimers.TryGetValue(e.Key, out Timer value2))
			{
				value2.Stop();
			}
			this.OnKeyReleased?.Invoke(this, e);
		}
	}

	private void InitializeKey(KeyEventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		if (!_keyHistory.ContainsKey(e.Key))
		{
			_keyHistory.Add(e.Key, DateTime.Now);
		}
		if (!_keyTimers.ContainsKey(e.Key))
		{
			_keyTimers.Add(e.Key, new Timer());
			_keyTimers[e.Key].Interval = 100.0;
			_keyTimers[e.Key].AutoReset = false;
			_keyTimers[e.Key].Elapsed += delegate
			{
				this.OnKeyHeldDown?.Invoke(this, e);
			};
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		foreach (KeyValuePair<Key, Timer> keyTimer in _keyTimers)
		{
			keyTimer.Value?.Stop();
			keyTimer.Value?.Close();
			keyTimer.Value?.Dispose();
		}
	}
}
