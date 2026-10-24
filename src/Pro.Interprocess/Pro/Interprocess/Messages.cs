using System;
using System.Collections.Generic;
using Pro.Common.Operations;
using Pro.Common.Win32;

namespace Pro.Interprocess;

public class Messages<T> : IMessages<T> where T : Enum
{
	private const string MessagePrefix = "RVPRO_WM_";

	private static readonly nint HWND_BROADCAST = 65535;

	private readonly Dictionary<T, int> _callMap = new Dictionary<T, int>();

	private readonly Dictionary<int, List<Action>> _handlerMap = new Dictionary<int, List<Action>>();

	public void RegisterHandler(T message, Action handler)
	{
		EnsureMessageRegistered(message);
		if (!_handlerMap.TryGetValue(_callMap[message], out List<Action> value))
		{
			value = new List<Action>();
			_handlerMap[_callMap[message]] = value;
		}
		value.Add(handler);
	}

	public void SendMessage(T message)
	{
		EnsureMessageRegistered(message);
		WindowsFunctions.PostMessage(HWND_BROADCAST, _callMap[message], IntPtr.Zero, IntPtr.Zero);
	}

	private void EnsureMessageRegistered(T message)
	{
		if (!_callMap.ContainsKey(message))
		{
			_callMap.Add(message, WindowsFunctions.RegisterWindowMessageW("RVPRO_WM_" + message.Cast<ulong, T>()));
		}
	}

	public bool TryHandleMessage(int messageID)
	{
		if (_handlerMap.TryGetValue(messageID, out List<Action> value))
		{
			foreach (Action item in value)
			{
				item?.Invoke();
			}
			return true;
		}
		return false;
	}
}
