using System;
using System.IO.Abstractions;
using Google.Protobuf;
using Pro.Common.ErrorReporting;
using Pro.Common.Logging;
using Pro.CoreApplication.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.DO.Settings;

namespace ProPresenter.Registration.CallbackHandlers.Notifications;

public class NotificationDataStoreHandler : IRegistrationCallbackHandler
{
	private readonly string _filename;

	private readonly ILogger _logger;

	private readonly IFileSystem _fileSystem;

	private readonly IErrorReporter _errorReporter;

	public NotificationDataStoreHandler(string filename, ILogger logger, IFileSystem fileSystem, IApp app, IErrorReporter errorReporter)
	{
		_filename = filename;
		_logger = logger;
		_fileSystem = fileSystem;
		_errorReporter = errorReporter;
	}

	public bool HandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender)
	{
		switch (responseCallback.CallbackCase)
		{
		case Callback.CallbackOneofCase.ReadNotificationData:
			requestSender.Send(new Request
			{
				NotificationData = new NotificationData
				{
					Data = LoadNotificationData()
				}
			});
			return true;
		case Callback.CallbackOneofCase.WriteNotificationData:
			WriteNotificationData(responseCallback.WriteNotificationData.Data);
			return true;
		default:
			return false;
		}
	}

	private ByteString LoadNotificationData()
	{
		if (!_fileSystem.File.Exists(_filename))
		{
			return ByteString.Empty;
		}
		byte[] array;
		try
		{
			array = _fileSystem.File.ReadAllBytes(_filename);
		}
		catch (Exception ex)
		{
			_logger.Error("Unable to read file content from file {1}: {0}", ex, _filename);
			return ByteString.Empty;
		}
		try
		{
			return ByteString.CopyFrom(array);
		}
		catch (Exception e)
		{
			_errorReporter.Error(e, "Unable to decode data {0}", array);
			return ByteString.Empty;
		}
	}

	private void WriteNotificationData(ByteString data)
	{
		try
		{
			_fileSystem.File.WriteAllBytes(_filename, data.ToByteArray());
		}
		catch (Exception ex)
		{
			_logger.Error("Failed to write new notification data: {0}", ex);
		}
	}
}
