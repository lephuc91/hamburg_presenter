using System;
using System.Runtime.InteropServices;
using System.Windows;

namespace Pro.Common.Utility;

public static class ClipboardManager
{
	private const string ProPresenterPlaceholder = "ProPresenterClipboardData";

	private static object? _data;

	public static bool ContainsData<T>()
	{
		try
		{
			IDataObject dataObject = Clipboard.GetDataObject();
			if (_data == null || dataObject == null || !dataObject.GetDataPresent("ProPresenterClipboardData"))
			{
				_data = null;
				return false;
			}
			return _data is T;
		}
		catch (Exception ex) when (((ex is COMException || ex is ExternalException) ? 1 : 0) != 0)
		{
			return false;
		}
	}

	public static T? GetData<T>()
	{
		if (_data == null)
		{
			return default(T);
		}
		try
		{
			IDataObject dataObject = Clipboard.GetDataObject();
			if (dataObject != null && dataObject.GetDataPresent("ProPresenterClipboardData"))
			{
				return (_data is T val) ? val : default(T);
			}
			_data = null;
			return default(T);
		}
		catch (Exception ex) when (((ex is COMException || ex is ExternalException) ? 1 : 0) != 0)
		{
			return default(T);
		}
	}

	public static void SetData<T>(T value)
	{
		_data = value;
		try
		{
			Clipboard.SetDataObject(new DataObject("ProPresenterClipboardData", string.Empty, autoConvert: false), copy: false);
		}
		catch (Exception ex) when (((ex is COMException || ex is ExternalException) ? 1 : 0) != 0)
		{
			_data = null;
		}
	}
}
