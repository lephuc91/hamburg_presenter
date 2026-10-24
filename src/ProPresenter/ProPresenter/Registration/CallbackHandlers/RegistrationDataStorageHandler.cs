using System;
using System.IO.Abstractions;
using System.Threading;
using Google.Protobuf;
using Pro.Common.ErrorReporting;
using Pro.Common.Logging;
using Pro.CoreApplication.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.DO.Registration.Model;
using ProPresenter.DO.Settings;

namespace ProPresenter.Registration.CallbackHandlers;

public class RegistrationDataStorageHandler : IRegistrationCallbackHandler
{
	private readonly string _filename;

	private readonly ILogger _logger;

	private readonly IFileSystem _fileSystem;

	private readonly IApp _app;

	private readonly IErrorReporter _errorReporter;

	private readonly ReaderWriterLockSlim _fileLock;

	public RegistrationDataStorageHandler(string filename, ILogger logger, IFileSystem fileSystem, IApp app, IErrorReporter errorReporter)
	{
		_filename = filename;
		_logger = logger;
		_fileSystem = fileSystem;
		_app = app;
		_errorReporter = errorReporter;
		_fileLock = new ReaderWriterLockSlim();
	}

	public bool HandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender)
	{
		switch (responseCallback.CallbackCase)
		{
		case Callback.CallbackOneofCase.ReadRegistrationData:
			requestSender.Send(new Request
			{
				RegistrationData = new RegistrationData
				{
					Data = LoadStoredData(),
					Channel = ToProtoUpdateChannel(_app.UpdateChannel)
				}
			});
			return true;
		case Callback.CallbackOneofCase.WriteRegistrationData:
			WriteStoredData(responseCallback.WriteRegistrationData.Data);
			return true;
		default:
			return false;
		}
	}

	private ByteString LoadStoredData()
	{
		_fileLock.EnterReadLock();
		try
		{
			if (_fileSystem.File.Exists(GetUpdatingFileName(_filename)))
			{
				return GetFileContent(GetNewFileName(_filename));
			}
			return GetFileContent(_filename);
		}
		finally
		{
			_fileLock.ExitReadLock();
		}
	}

	private void WriteStoredData(ByteString data)
	{
		_fileLock.EnterWriteLock();
		try
		{
			string newFileName = GetNewFileName(_filename);
			string updatingFileName = GetUpdatingFileName(_filename);
			if (_fileSystem.File.Exists(updatingFileName) && _fileSystem.File.Exists(newFileName))
			{
				_fileSystem.File.Copy(newFileName, _filename, overwrite: true);
				_fileSystem.File.Delete(updatingFileName);
			}
			_fileSystem.File.WriteAllText(newFileName, data.ToBase64());
			_fileSystem.File.WriteAllBytes(updatingFileName, Array.Empty<byte>());
			_fileSystem.File.Copy(newFileName, _filename, overwrite: true);
			_fileSystem.File.Delete(updatingFileName);
		}
		catch (Exception ex)
		{
			_logger.Error("Failed to write new registration data: {0}", ex);
		}
		finally
		{
			_fileLock.ExitWriteLock();
		}
	}

	private static Pro.SerializationInterop.RVProtoData.Registration.UpdateChannel ToProtoUpdateChannel(ProPresenter.DO.Registration.Model.UpdateChannel updateChannel)
	{
		if (updateChannel == ProPresenter.DO.Registration.Model.UpdateChannel.Beta)
		{
			return Pro.SerializationInterop.RVProtoData.Registration.UpdateChannel.Beta;
		}
		return Pro.SerializationInterop.RVProtoData.Registration.UpdateChannel.Production;
	}

	private ByteString GetFileContent(string fileName)
	{
		if (!_fileSystem.File.Exists(fileName))
		{
			return ByteString.Empty;
		}
		string text;
		try
		{
			text = _fileSystem.File.ReadAllText(fileName);
		}
		catch (Exception ex)
		{
			_logger.Error("Unable to read file content from file {1}: {0}", ex, fileName);
			return ByteString.Empty;
		}
		try
		{
			return ByteString.FromBase64(text ?? string.Empty);
		}
		catch (Exception e)
		{
			_errorReporter.Error(e, "Unable to decode data {0}", text);
			return ByteString.Empty;
		}
	}

	private static string GetUpdatingFileName(string fileName)
	{
		return fileName + ".updating";
	}

	private static string GetNewFileName(string fileName)
	{
		return fileName + ".new";
	}
}
