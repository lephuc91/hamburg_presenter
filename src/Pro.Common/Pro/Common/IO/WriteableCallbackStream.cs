using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Pro.Common.IO;

public class WriteableCallbackStream : Stream
{
	private Action<string> _writeCallback;

	private Action? _flushCallback;

	public override bool CanRead => false;

	public override bool CanSeek => false;

	public override bool CanWrite => _writeCallback != null;

	public override long Length => 0L;

	public override long Position
	{
		get
		{
			return 0L;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public WriteableCallbackStream(Action<string> writeCallback, Action? flushCallback = null)
	{
		_writeCallback = writeCallback;
		_flushCallback = flushCallback;
	}

	public override void Flush()
	{
		_flushCallback?.Invoke();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		throw new NotSupportedException();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotSupportedException();
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException();
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		_writeCallback?.Invoke(Encoding.UTF8.GetString(buffer.Skip(offset).Take(count).ToArray()));
	}
}
