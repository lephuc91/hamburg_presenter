using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Win32;

namespace Pro.Interprocess;

public class SharedData<T> : DisposableBase, ISharedData<T> where T : notnull
{
	private sealed class MapFile
	{
		public nint Handle { get; }

		public nint Buffer { get; }

		public MapFile(nint handle, nint buffer)
		{
			Handle = handle;
			Buffer = buffer;
		}
	}

	private static readonly nint INVALID_HANDLE_VALUE = new IntPtr(-1);

	private const int BufferSize = 4096;

	private const string PathFormat = "Local\\RVPRO_DATA_{0}";

	private const int HeaderSize = 4;

	private readonly Dictionary<T, MapFile> _files = new Dictionary<T, MapFile>();

	protected override void OnDispose(bool disposeObjects)
	{
		_files.Values.ForEach(CloseFile);
	}

	public void Register(T key)
	{
		if (!_files.ContainsKey(key))
		{
			nint num = WindowsFunctions.CreateFileMappingW(INVALID_HANDLE_VALUE, IntPtr.Zero, PAGE.READWRITE, 0u, 4096u, $"Local\\RVPRO_DATA_{key}");
			if (num == IntPtr.Zero)
			{
				throw new Exception("Failed to register data key (file creation failed)");
			}
			nint num2 = WindowsFunctions.MapViewOfFile(num, FILE_MAP.ALL_ACCESS, 0u, 0u, 4096);
			if (num2 == IntPtr.Zero)
			{
				throw new Exception("Failed to register data key (buffer creation failed)");
			}
			_files.Add(key, new MapFile(num, num2));
		}
	}

	public void SendData(T key, string data)
	{
		if (!_files.TryGetValue(key, out MapFile value))
		{
			throw new Exception("Data key is not registered");
		}
		byte[] bytes = BitConverter.GetBytes(data.Length);
		byte[] bytes2 = Encoding.UTF8.GetBytes(data);
		if (bytes.Length != 4)
		{
			throw new InvalidProgramException();
		}
		if (bytes2.Length > 4092)
		{
			throw new InvalidOperationException();
		}
		Marshal.Copy(bytes, 0, value.Buffer, bytes.Length);
		Marshal.Copy(bytes2, 0, IntPtr.Add(value.Buffer, bytes.Length), bytes2.Length);
	}

	public string ReadData(T key)
	{
		if (!_files.TryGetValue(key, out MapFile value))
		{
			throw new Exception("Data key is not registered");
		}
		byte[] array = new byte[4];
		Marshal.Copy(value.Buffer, array, 0, array.Length);
		int num = BitConverter.ToInt32(array, 0);
		if (num <= 0 || num > 4092)
		{
			return string.Empty;
		}
		byte[] array2 = new byte[num];
		Marshal.Copy(IntPtr.Add(value.Buffer, array.Length), array2, 0, num);
		return Encoding.UTF8.GetString(array2);
	}

	private void CloseFile(MapFile file)
	{
		WindowsFunctions.UnmapViewOfFile(file.Buffer);
		WindowsFunctions.CloseHandle(file.Handle);
	}
}
