using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Management;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Pro.Common.Logging;
using Pro.DxDiagReport;

namespace Pro.Reporting;

public class SystemInfoProvider : ISystemInfoProvider
{
	private readonly IFileSystem _fileSystem;

	private readonly IDxDiagReaderFactory _dxDiagReaderFactory;

	private readonly IIdProvider _idProvider;

	private static readonly JsonWriterOptions _serializationOptions = new JsonWriterOptions
	{
		Indented = true
	};

	public SystemInfoProvider(IFileSystem fileSystem, IDxDiagReaderFactory dxDiagReaderFactory, IIdProvider idProvider)
	{
		_fileSystem = fileSystem;
		_dxDiagReaderFactory = dxDiagReaderFactory;
		_idProvider = idProvider;
	}

	public async Task<string> CreateSystemInfoFileAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		string systemInfoFileLocation = _fileSystem.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RenewedVision", "ProPresenter");
		string systemInfoFilePath = _fileSystem.Path.Combine(systemInfoFileLocation, Environment.MachineName + "-" + _idProvider.Id.ToString() + ".systeminfo");
		TaskCompletionSource<string> completionSource = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
		Thread thread = new Thread((ThreadStart)delegate
		{
			try
			{
				_fileSystem.Directory.CreateDirectory(systemInfoFileLocation);
				using (FileSystemStream utf8Json = _fileSystem.File.Open(systemInfoFilePath, FileMode.Create, FileAccess.Write))
				{
					using Utf8JsonWriter writer = new Utf8JsonWriter((Stream)utf8Json, _serializationOptions);
					IDxDiagReader dxDiagReader = _dxDiagReaderFactory.CreateRoot();
					WriteDxDiagProperties(dxDiagReader.Read(), writer, cancellationToken);
				}
				completionSource.SetResult(systemInfoFilePath);
			}
			catch (Exception exception)
			{
				completionSource.SetException(exception);
			}
		});
		thread.SetApartmentState(ApartmentState.STA);
		thread.Start();
		try
		{
			return await completionSource.Task.ConfigureAwait(continueOnCapturedContext: false);
		}
		catch (Exception exception2)
		{
			Log.Error(exception2);
			return string.Empty;
		}
	}

	public void WriteDxDiagProperties(IEnumerable<IDxDiagProperty> properties, Utf8JsonWriter writer, CancellationToken token)
	{
		writer.WriteStartObject();
		foreach (IDxDiagProperty property in properties)
		{
			if (token.IsCancellationRequested)
			{
				break;
			}
			if (!(property is IDxDiagPropertyGeneric<IEnumerable<IDxDiagProperty>> dxDiagPropertyGeneric))
			{
				if (!(property is IDxDiagPropertyGeneric<long> dxDiagPropertyGeneric2))
				{
					if (!(property is IDxDiagPropertyGeneric<ulong> dxDiagPropertyGeneric3))
					{
						if (!(property is IDxDiagPropertyGeneric<bool> dxDiagPropertyGeneric4))
						{
							if (property is IDxDiagPropertyGeneric<string> dxDiagPropertyGeneric5)
							{
								writer.WriteString(dxDiagPropertyGeneric5.Name, dxDiagPropertyGeneric5.Value);
							}
						}
						else
						{
							writer.WriteBoolean(dxDiagPropertyGeneric4.Name, dxDiagPropertyGeneric4.Value);
						}
					}
					else
					{
						writer.WriteNumber(dxDiagPropertyGeneric3.Name, dxDiagPropertyGeneric3.Value);
					}
				}
				else
				{
					writer.WriteNumber(dxDiagPropertyGeneric2.Name, dxDiagPropertyGeneric2.Value);
				}
			}
			else
			{
				writer.WritePropertyName(property.Name);
				WriteDxDiagProperties(dxDiagPropertyGeneric.Value, writer, token);
			}
		}
		writer.WriteEndObject();
	}

	public async Task<SystemData> CreateSystemDataAsync()
	{
		ManagementObjectSearcher computerSystemSearcher = new ManagementObjectSearcher("SELECT manufacturer, model, totalphysicalmemory FROM Win32_ComputerSystem");
		try
		{
			Task<ManagementObject> computerSystemTask = Task.Run(() => computerSystemSearcher.Get().Cast<ManagementObject>().FirstOrDefault());
			ManagementObjectSearcher videoControllerSearcher = new ManagementObjectSearcher("SELECT Name, AdapterRAM FROM Win32_VideoController");
			try
			{
				Task<ManagementObject> videoControllerTask = Task.Run(() => videoControllerSearcher.Get().Cast<ManagementObject>().FirstOrDefault());
				global::_003C_003Ey__InlineArray2<Task<ManagementObject>> buffer = default(global::_003C_003Ey__InlineArray2<Task<ManagementObject>>);
				global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<Task<ManagementObject>>, Task<ManagementObject>>(ref buffer, 0) = computerSystemTask;
				global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<Task<ManagementObject>>, Task<ManagementObject>>(ref buffer, 1) = videoControllerTask;
				await Task.WhenAll(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray2<Task<ManagementObject>>, Task<ManagementObject>>(in buffer, 2));
				ManagementObject computerSystem = await computerSystemTask;
				ManagementObject managementObject = await videoControllerTask;
				return new SystemData(computerSystem?["manufacturer"]?.ToString() ?? string.Empty, computerSystem?["model"]?.ToString() ?? string.Empty, GetRam(computerSystem?["totalphysicalmemory"]), managementObject?["Name"]?.ToString() ?? string.Empty, GetRam(managementObject?["AdapterRAM"]));
			}
			finally
			{
				if (videoControllerSearcher != null)
				{
					((IDisposable)videoControllerSearcher).Dispose();
				}
			}
		}
		finally
		{
			if (computerSystemSearcher != null)
			{
				((IDisposable)computerSystemSearcher).Dispose();
			}
		}
	}

	private static ulong GetRam(object? ramRepresentation)
	{
		if (!(ramRepresentation is ulong result))
		{
			if (!(ramRepresentation is int num))
			{
				if (!(ramRepresentation is uint num2))
				{
					if (ramRepresentation is long result2)
					{
						return (ulong)result2;
					}
					return 0uL;
				}
				return num2;
			}
			return (ulong)num;
		}
		return result;
	}
}
