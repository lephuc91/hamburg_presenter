using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Google.Protobuf;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.Reflection;
using Pro.Common.Utility;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.Serialization.Utility;

public static class ProtoHelper
{
	private sealed class WriteAvoidingFileStream : Stream
	{
		private readonly FileStream _fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

		private byte[] _readBuffer = new byte[512];

		public bool HadChangedBytes { get; private set; }

		public override bool CanSeek => _fileStream.CanSeek;

		public override bool CanRead => _fileStream.CanRead;

		public override bool CanWrite => _fileStream.CanWrite;

		public override long Length => _fileStream.Length;

		public override long Position
		{
			get
			{
				return _fileStream.Position;
			}
			set
			{
				_fileStream.Position = value;
			}
		}

		public WriteAvoidingFileStream(string filePath)
		{
		}

		protected override void Dispose(bool disposing)
		{
			if (_fileStream.Length != _fileStream.Position)
			{
				_fileStream.SetLength(_fileStream.Position);
			}
			if (disposing)
			{
				_fileStream.Dispose();
			}
			base.Dispose(disposing);
		}

		public override ValueTask DisposeAsync()
		{
			if (_fileStream.Length != _fileStream.Position)
			{
				_fileStream.SetLength(_fileStream.Position);
			}
			return _fileStream.DisposeAsync();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return _fileStream.Read(buffer, offset, count);
		}

		public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			return _fileStream.ReadAsync(buffer, offset, count, cancellationToken);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			if (HadChangedBytes)
			{
				_fileStream.Write(buffer, offset, count);
				return;
			}
			long position = _fileStream.Position;
			if (count > _readBuffer.Length)
			{
				_readBuffer = new byte[count];
			}
			int length = _fileStream.Read(_readBuffer, 0, count);
			if (!MemoryExtensions.SequenceEqual<byte>(new ReadOnlySpan<byte>(_readBuffer, 0, length), new ReadOnlySpan<byte>(buffer, offset, count)))
			{
				_fileStream.Position = position;
				_fileStream.Write(buffer, offset, count);
				HadChangedBytes = true;
			}
		}

		public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			if (HadChangedBytes)
			{
				await _fileStream.WriteAsync(buffer, offset, count, cancellationToken);
				return;
			}
			long initialPosition = _fileStream.Position;
			if (count > _readBuffer.Length)
			{
				_readBuffer = new byte[count];
			}
			int length = await _fileStream.ReadAsync(_readBuffer, 0, count, cancellationToken);
			if (!MemoryExtensions.SequenceEqual<byte>(new ReadOnlySpan<byte>(_readBuffer, 0, length), new ReadOnlySpan<byte>(buffer, offset, count)))
			{
				_fileStream.Position = initialPosition;
				await _fileStream.WriteAsync(buffer, offset, count, cancellationToken);
				HadChangedBytes = true;
			}
		}

		public override void Flush()
		{
			_fileStream.Flush();
		}

		public override Task FlushAsync(CancellationToken cancellationToken)
		{
			return _fileStream.FlushAsync(cancellationToken);
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return _fileStream.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
			if (_fileStream.Length != value)
			{
				_fileStream.SetLength(value);
			}
		}
	}

	public static bool IsProtoMessage(this Type type)
	{
		return typeof(IMessage).IsAssignableFrom(type);
	}

	public static ByteString ToByteString(this byte[] bytes)
	{
		return ByteString.CopyFrom(bytes);
	}

	public static ByteString ToByteString(this BitmapSource bitmapSource, API_v1_ContentType contentType = API_v1_ContentType.Png)
	{
		if (contentType != 0 && contentType == API_v1_ContentType.Jpeg)
		{
			JpegBitmapEncoder jpegBitmapEncoder = new JpegBitmapEncoder();
			using MemoryStream memoryStream = new MemoryStream();
			jpegBitmapEncoder.Frames.Add(BitmapFrame.Create(bitmapSource));
			jpegBitmapEncoder.Save(memoryStream);
			return memoryStream.ToArray().ToByteString();
		}
		PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
		using MemoryStream memoryStream2 = new MemoryStream();
		pngBitmapEncoder.Frames.Add(BitmapFrame.Create(bitmapSource));
		pngBitmapEncoder.Save(memoryStream2);
		return memoryStream2.ToArray().ToByteString();
	}

	public static BitmapSource? ToBitmapSource(this ByteString byteString)
	{
		byte[] array = byteString.ToByteArray();
		if (array.Length == 0)
		{
			return null;
		}
		return array.ToBitmapSource();
	}

	public static BitmapSource? ToBitmapSource(this string imageData)
	{
		if (string.IsNullOrEmpty(imageData))
		{
			return null;
		}
		byte[] array = Convert.FromBase64String(imageData);
		if (array.Length == 0)
		{
			return null;
		}
		return array.ToBitmapSource();
	}

	public static string EncodeBase64(this IMessage message)
	{
		using MemoryStream memoryStream = new MemoryStream();
		message.WriteTo(memoryStream);
		return Convert.ToBase64String(memoryStream.ToArray());
	}

	public static IMessage DecodeBase64(this Type messageType, string encodedMessage)
	{
		IMessage obj = (IMessage)messageType.Construct();
		obj.MergeFrom(Convert.FromBase64String(encodedMessage));
		return obj;
	}

	public static T DecodeBase64<T>(string encodedMessage) where T : IMessage
	{
		return (T)typeof(T).DecodeBase64(encodedMessage);
	}

	public static FileIOResult TryReadFile<K>(string fullPath, out K? data) where K : IMessage<K>, new()
	{
		FileIOResult fileIOResult = FileHelper.WaitForFileAccess(fullPath, enforceFileExists: true, null, FileAccess.Read);
		if (!fileIOResult)
		{
			data = default(K);
			Log.Warning($"Failed to gain read access to file [{fullPath}]");
			return fileIOResult;
		}
		data = default(K);
		K val = new K();
		try
		{
			using FileStream fileStream = File.OpenRead(fullPath);
			if (fileStream.Length == 0L)
			{
				return FileIOResult.Failure(fullPath, IOResult.Error);
			}
			val.MergeFrom(fileStream);
			data = val;
			Log.Info($"Opened [{fullPath}]");
			return FileIOResult.Success();
		}
		catch (Exception e)
		{
			Log.Error($"Unable to read data from file [{fullPath}]");
			return FileIOResult.Exception(fullPath, e);
		}
	}

	public static FileIOResult WriteFile<K>(string fullPath, K? data) where K : IMessage
	{
		FileIOResult fileIOResult = FileHelper.WaitForFileAccess(fullPath, enforceFileExists: false, null);
		if (!fileIOResult)
		{
			Log.Warning("Failed to gain write access to file [" + fullPath + "]");
			return fileIOResult;
		}
		if (data == null)
		{
			return FileIOResult.Success();
		}
		try
		{
			using WriteAvoidingFileStream output = new WriteAvoidingFileStream(fullPath);
			data.WriteTo(output);
			return FileIOResult.Success();
		}
		catch (Exception e)
		{
			Log.Error("Unable to write data to file [" + fullPath + "]");
			return FileIOResult.Exception(fullPath, e);
		}
	}
}
