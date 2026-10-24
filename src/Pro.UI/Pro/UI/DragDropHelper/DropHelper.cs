using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Windows;
using Pro.Common.Components;

namespace Pro.UI.DragDropHelper;

public static class DropHelper
{
	[CompilerGenerated]
	private sealed class _003CReadFileNames_003Ed__4 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private string _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private Stream fileDescriptorStream;

		public Stream _003C_003E3__fileDescriptorStream;

		private BinaryReader _003Creader_003E5__2;

		private uint _003Ccount_003E5__3;

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
		public _003CReadFileNames_003Ed__4(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Creader_003E5__2 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003Creader_003E5__2 = new BinaryReader(fileDescriptorStream);
				_003Ccount_003E5__3 = _003Creader_003E5__2.ReadUInt32();
				break;
			case 1:
				_003C_003E1__state = -1;
				_003Ccount_003E5__3--;
				break;
			}
			if (_003Ccount_003E5__3 != 0)
			{
				FileDescriptor fileDescriptor = new FileDescriptor(_003Creader_003E5__2);
				_003C_003E2__current = fileDescriptor.FileName;
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
		IEnumerator<string> IEnumerable<string>.GetEnumerator()
		{
			_003CReadFileNames_003Ed__4 _003CReadFileNames_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CReadFileNames_003Ed__ = this;
			}
			else
			{
				_003CReadFileNames_003Ed__ = new _003CReadFileNames_003Ed__4(0);
			}
			_003CReadFileNames_003Ed__.fileDescriptorStream = _003C_003E3__fileDescriptorStream;
			return _003CReadFileNames_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<string>)this).GetEnumerator();
		}
	}

	private const string InnerData = "_innerData";

	private const string GetDataFromHGLOBAL = "GetDataFromHGLOBAL";

	private const string FileContents = "FileContents";

	public static MemoryStream? GetFileContents(this System.Windows.IDataObject data, int index)
	{
		System.Runtime.InteropServices.ComTypes.IDataObject obj = (System.Runtime.InteropServices.ComTypes.IDataObject)data;
		DataFormat dataFormat = DataFormats.GetDataFormat("FileContents");
		if (dataFormat == null)
		{
			throw new InvalidOperationException("Failed to get the format");
		}
		FORMATETC format = new FORMATETC
		{
			cfFormat = (short)dataFormat.Id,
			dwAspect = DVASPECT.DVASPECT_CONTENT,
			lindex = index,
			tymed = (TYMED.TYMED_HGLOBAL | TYMED.TYMED_ISTREAM)
		};
		obj.GetData(ref format, out var medium);
		return medium.tymed switch
		{
			TYMED.TYMED_HGLOBAL => GetFileContentFromHGlobal(data, medium), 
			TYMED.TYMED_ISTREAM => GetFileContentFromIStream(medium), 
			_ => throw new NotSupportedException(), 
		};
	}

	[IteratorStateMachine(typeof(_003CReadFileNames_003Ed__4))]
	public static IEnumerable<string> ReadFileNames(this Stream fileDescriptorStream)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CReadFileNames_003Ed__4(-2)
		{
			_003C_003E3__fileDescriptorStream = fileDescriptorStream
		};
	}

	private static MemoryStream GetFileContentFromIStream(STGMEDIUM medium)
	{
		IStream obj = (IStream)Marshal.GetObjectForIUnknown(medium.unionmember);
		Marshal.Release(medium.unionmember);
		obj.Stat(out var pstatstg, 0);
		byte[] array = new byte[(int)pstatstg.cbSize];
		obj.Read(array, array.Length, IntPtr.Zero);
		return new MemoryStream(array);
	}

	private static MemoryStream? GetFileContentFromHGlobal(System.Windows.IDataObject data, STGMEDIUM medium)
	{
		System.Windows.IDataObject dataObject = (System.Windows.IDataObject)(data.GetType().GetField("_innerData", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(data));
		return (MemoryStream)((dataObject?.GetType().GetMethod("GetDataFromHGLOBAL", BindingFlags.Instance | BindingFlags.NonPublic))?.Invoke(dataObject, new object[2] { "FileContents", medium.unionmember }));
	}

	public static void DoDropData<I, T>(DraggedItems<I> source, IDragDropCollection<T>? destination, Func<IEnumerable<I>, IEnumerable<T>>? convert, int dropIndex, DragEventArgs e, out IEnumerable<T> items, Func<IDragDropCollection<I>?, bool>? canDragFrom = null)
	{
		bool flag = e.Effects.HasFlag(DragDropEffects.Copy);
		if (source.SourceCollection != destination)
		{
			items = convert?.Invoke(source.Items) ?? source.Items.OfType<T>();
			if ((canDragFrom == null || canDragFrom(source.SourceCollection)) && !flag)
			{
				source.SourceCollection?.DraggedFrom(source.Items);
			}
			destination?.DroppedInto(SortItems(items, destination), dropIndex, flag);
		}
		else
		{
			items = source.Items.Cast<T>();
			if (flag)
			{
				destination?.DroppedInto(items, dropIndex, isCopy: true);
			}
			else
			{
				destination?.MoveTo(items, dropIndex);
			}
		}
	}

	private static IEnumerable<T> SortItems<T>(IEnumerable<T> items, IDragDropCollection<T> destination)
	{
		return items.AsEnumerable().OrderBy(destination.IndexOf);
	}
}
