using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Common.IO;

public class LengthCapTextWriter : TextWriter
{
	private readonly TextWriter _decoratedWriter;

	private readonly int _maximumMessageLength;

	public override string NewLine
	{
		get
		{
			return _decoratedWriter.NewLine;
		}
		[param: AllowNull]
		set
		{
			_decoratedWriter.NewLine = value;
		}
	}

	public override Encoding Encoding => _decoratedWriter.Encoding;

	public LengthCapTextWriter(TextWriter decoratedWriter, int maximumMessageLength = 1000)
	{
		_decoratedWriter = decoratedWriter;
		_maximumMessageLength = maximumMessageLength;
	}

	public override void Write(char value)
	{
		_decoratedWriter.Write(value);
	}

	public override void Write(string? value)
	{
		_decoratedWriter.Write(Truncate(value));
	}

	public override void Write(char[] buffer, int index, int count)
	{
		_decoratedWriter.Write(buffer, index, count);
	}

	public override void WriteLine()
	{
		_decoratedWriter.WriteLine();
	}

	public override void WriteLine(char value)
	{
		_decoratedWriter.WriteLine(value);
	}

	public override void WriteLine(string? value)
	{
		_decoratedWriter.WriteLine(Truncate(value));
	}

	public override void WriteLine(char[] buffer, int index, int count)
	{
		_decoratedWriter.WriteLine(buffer, index, count);
	}

	public override Task WriteAsync(char value)
	{
		return _decoratedWriter.WriteAsync(value);
	}

	public override Task WriteAsync(string? value)
	{
		return _decoratedWriter.WriteAsync(Truncate(value));
	}

	public override Task WriteAsync(char[] buffer, int index, int count)
	{
		return _decoratedWriter.WriteAsync(buffer, index, count);
	}

	public override Task WriteLineAsync()
	{
		return _decoratedWriter.WriteLineAsync();
	}

	public override Task WriteLineAsync(char value)
	{
		return _decoratedWriter.WriteLineAsync(value);
	}

	public override Task WriteLineAsync(string? value)
	{
		return _decoratedWriter.WriteLineAsync(Truncate(value));
	}

	public override Task WriteLineAsync(char[] buffer, int index, int count)
	{
		return _decoratedWriter.WriteLineAsync(buffer, index, count);
	}

	public override void Flush()
	{
		_decoratedWriter.Flush();
	}

	public override Task FlushAsync()
	{
		return _decoratedWriter.FlushAsync();
	}

	public override void Close()
	{
		_decoratedWriter.Close();
	}

	private string? Truncate(string? value)
	{
		return value?.Substring(0, Math.Min(_maximumMessageLength, value.Length));
	}
}
