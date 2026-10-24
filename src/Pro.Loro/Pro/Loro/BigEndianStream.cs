using System;
using System.IO;

namespace Pro.Loro;

internal class BigEndianStream
{
	private Stream stream;

	public long Position
	{
		get
		{
			return stream.Position;
		}
		set
		{
			stream.Position = value;
		}
	}

	public BigEndianStream(Stream stream)
	{
		this.stream = stream;
	}

	public bool HasRemaining()
	{
		return stream.Length - stream.Position > 0;
	}

	public void WriteBytes(byte[] value)
	{
		stream.Write(value, 0, value.Length);
	}

	public void WriteByte(byte value)
	{
		stream.WriteByte(value);
	}

	public void WriteUShort(ushort value)
	{
		stream.WriteByte((byte)(value >> 8));
		stream.WriteByte((byte)value);
	}

	public void WriteUInt(uint value)
	{
		stream.WriteByte((byte)(value >> 24));
		stream.WriteByte((byte)(value >> 16));
		stream.WriteByte((byte)(value >> 8));
		stream.WriteByte((byte)value);
	}

	public void WriteULong(ulong value)
	{
		WriteUInt((uint)(value >> 32));
		WriteUInt((uint)value);
	}

	public void WriteSByte(sbyte value)
	{
		stream.WriteByte((byte)value);
	}

	public void WriteShort(short value)
	{
		WriteUShort((ushort)value);
	}

	public void WriteInt(int value)
	{
		WriteUInt((uint)value);
	}

	public unsafe void WriteFloat(float value)
	{
		WriteInt(*(int*)(&value));
	}

	public void WriteLong(long value)
	{
		WriteULong((ulong)value);
	}

	public void WriteDouble(double value)
	{
		WriteLong(BitConverter.DoubleToInt64Bits(value));
	}

	public byte[] ReadBytes(int length)
	{
		CheckRemaining(length);
		byte[] array = new byte[length];
		stream.Read(array, 0, length);
		return array;
	}

	public byte ReadByte()
	{
		CheckRemaining(1);
		return Convert.ToByte(stream.ReadByte());
	}

	public ushort ReadUShort()
	{
		CheckRemaining(2);
		return (ushort)((stream.ReadByte() << 8) | stream.ReadByte());
	}

	public uint ReadUInt()
	{
		CheckRemaining(4);
		return (uint)((stream.ReadByte() << 24) | (stream.ReadByte() << 16) | (stream.ReadByte() << 8) | stream.ReadByte());
	}

	public ulong ReadULong()
	{
		return ((ulong)ReadUInt() << 32) | ReadUInt();
	}

	public sbyte ReadSByte()
	{
		return (sbyte)ReadByte();
	}

	public short ReadShort()
	{
		return (short)ReadUShort();
	}

	public int ReadInt()
	{
		return (int)ReadUInt();
	}

	public unsafe float ReadFloat()
	{
		int num = ReadInt();
		return *(float*)(&num);
	}

	public long ReadLong()
	{
		return (long)ReadULong();
	}

	public double ReadDouble()
	{
		return BitConverter.Int64BitsToDouble(ReadLong());
	}

	private void CheckRemaining(int length)
	{
		if (stream.Length - stream.Position < length)
		{
			throw new StreamUnderflowException();
		}
	}
}
