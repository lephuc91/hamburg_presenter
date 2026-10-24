using System;
using System.IO;
using System.Text;
using System.Windows;
using Pro.Common.Win32;

namespace Pro.UI.DragDropHelper;

public class FileDescriptor
{
	public int Flags { get; }

	public Guid ClassId { get; }

	public Size Size { get; }

	public POINT Point { get; }

	public FileAttributes FileAttributes { get; }

	public DateTime CreationTime { get; }

	public DateTime LastAccessTime { get; }

	public DateTime LastWriteTime { get; }

	public long FileSize { get; }

	public string FileName { get; }

	public FileDescriptor(BinaryReader reader)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		Flags = (int)reader.ReadUInt32();
		ClassId = new Guid(reader.ReadBytes(16));
		Size = new Size((double)reader.ReadInt32(), (double)reader.ReadInt32());
		Point = new POINT
		{
			X = reader.ReadInt32(),
			Y = reader.ReadInt32()
		};
		FileAttributes = (FileAttributes)reader.ReadUInt32();
		CreationTime = new DateTime(1601, 1, 1).AddTicks(reader.ReadInt64());
		LastAccessTime = new DateTime(1601, 1, 1).AddTicks(reader.ReadInt64());
		LastWriteTime = new DateTime(1601, 1, 1).AddTicks(reader.ReadInt64());
		FileSize = reader.ReadInt64();
		byte[] array = reader.ReadBytes(520);
		int i;
		for (i = 0; i < array.Length && (array[i] != 0 || array[i + 1] != 0); i += 2)
		{
		}
		FileName = Encoding.Unicode.GetString(array, 0, i);
	}
}
