using System;
using System.IO;
using System.Linq;
using System.Threading;
using Google.Protobuf;
using Pro.Common.FileSystem;
using Pro.DO.Utility;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Bibles;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Librarian;

public class PresentationLoadData : IPresentationLoadData
{
	private readonly IPresentationMetadataCache _metadataCache;

	private readonly ReaderWriterLockSlim _protoDataLock = new ReaderWriterLockSlim();

	private string? _filename;

	private bool _isFileParsed;

	private Pro.SerializationInterop.RVProtoData.Presentation? _protoData;

	private PresentationMetadata? _presentationMetadata;

	public string? Filename
	{
		get
		{
			return _filename;
		}
		set
		{
			if (_filename != value)
			{
				if (_filename != null)
				{
					_isFileParsed = false;
					_protoData = null;
				}
				_filename = value;
			}
		}
	}

	public Pro.SerializationInterop.RVProtoData.Presentation? ProtoData
	{
		get
		{
			_protoDataLock.EnterUpgradeableReadLock();
			try
			{
				if (!_isFileParsed && _filename != null)
				{
					_protoDataLock.EnterWriteLock();
					try
					{
						ProtoHelper.TryReadFile<Pro.SerializationInterop.RVProtoData.Presentation>(_filename, out _protoData);
						_isFileParsed = true;
						if (_protoData != null)
						{
							_protoData.Name = Path.GetFileNameWithoutExtension(_filename);
						}
					}
					finally
					{
						_protoDataLock.ExitWriteLock();
					}
				}
				return _protoData;
			}
			finally
			{
				_protoDataLock.ExitUpgradeableReadLock();
			}
		}
	}

	public Guid? PresentationID => _presentationMetadata?.ID;

	public PresentationType PresentationType => _presentationMetadata?.Type ?? PresentationType.Standard;

	public OutputDestination? PresentationDestination => _presentationMetadata?.Destination;

	public string? PresentationActiveArrangementName => _presentationMetadata?.ActiveArrangementName;

	public DateTime? PresentationLastUsed => _presentationMetadata?.LastUsed;

	public DateTime? PresentationLastModified => _presentationMetadata?.LastModified;

	public byte[]? CopyrightInfoData => _presentationMetadata?.CopyrightInfoData;

	public PresentationLoadData(IPresentationMetadataCache metadataCache, Pro.SerializationInterop.RVProtoData.Presentation protoData)
	{
		_metadataCache = metadataCache;
		_protoData = protoData;
		_isFileParsed = true;
		ReadMetadata(protoData);
	}

	public PresentationLoadData(IPresentationMetadataCache metadataCache, string filename)
	{
		_metadataCache = metadataCache;
		_filename = filename;
		if (!_metadataCache.TryGetCachedMetadata(filename, out _presentationMetadata))
		{
			if (ProtoData != null)
			{
				ReadMetadata(ProtoData);
			}
			if (_presentationMetadata != null)
			{
				_metadataCache.CacheMetadata(filename, _presentationMetadata);
			}
		}
	}

	private void ReadMetadata(Pro.SerializationInterop.RVProtoData.Presentation protoData)
	{
		if (protoData != null)
		{
			PresentationType type = ((protoData.MultiTracksLicensing != null) ? PresentationType.MultiTracks : (protoData.IsBible() ? PresentationType.Bible : PresentationType.Standard));
			_presentationMetadata = new PresentationMetadata(protoData.Uuid?.ToGuid() ?? Guid.NewGuid(), type, protoData.ContentDestination.ToDestination(), protoData.Arrangements?.FirstOrDefault((Pro.SerializationInterop.RVProtoData.Presentation.Types.Arrangement a) => a?.Uuid?.String == protoData.SelectedArrangement?.String)?.Name, protoData.LastDateUsed?.ToDateTime(), protoData.LastModifiedDate?.ToDateTime() ?? DateTime.Now, protoData.Ccli?.ToByteArray() ?? Array.Empty<byte>());
		}
		else
		{
			_presentationMetadata = new PresentationMetadata(Guid.NewGuid(), PresentationType.Standard, OutputDestination.Presentation, null, null, DateTime.Now, Array.Empty<byte>());
		}
	}

	public FileIOResult WriteProtoData(string filename)
	{
		if (ProtoData != null)
		{
			FileIOResult fileIOResult = ProtoHelper.WriteFile(filename, ProtoData);
			if (!fileIOResult)
			{
				return fileIOResult;
			}
			if (_presentationMetadata != null)
			{
				_metadataCache.CacheMetadata(filename, _presentationMetadata);
			}
			Filename = filename;
		}
		return FileIOResult.Success();
	}

	public void UpdateProtoData(Pro.SerializationInterop.RVProtoData.Presentation protoData)
	{
		_protoData = protoData;
		_isFileParsed = true;
		ReadMetadata(protoData);
	}
}
