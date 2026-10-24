using System.IO;
using System.IO.Abstractions;
using System.Threading.Tasks;
using Pro.Common.HTTP;
using Pro.Common.Utility.Zip;
using ProPresenter.Controller.NetworkAPI;
using ProPresenter.DO.Web;
using ProPresenter.Utility;
using RestSharp;

namespace ProPresenter.ViewModels.Settings.Pages.Inputs;

public class AirCastPluginDownload : IAirCastPluginDownload
{
	private readonly IAirCastConfiguration _configuration;

	private readonly IWebSourceProvider _webSourceProvider;

	private readonly IFileSystem _fileSystem;

	private readonly IInstallFileExecutor _installFileExecutor;

	private readonly IRestClientFactory _restClientFactory;

	private readonly IAirCastPrompt _downloadPrompt;

	private readonly IZipService _zipService;

	public AirCastPluginDownload(IAirCastConfiguration configuration, IWebSourceProvider webSourceProvider, IFileSystem fileSystem, IInstallFileExecutor installFileExecutor, IRestClientFactory restClientFactory, IAirCastPrompt downloadPrompt, IZipService zipService)
	{
		_configuration = configuration;
		_webSourceProvider = webSourceProvider;
		_fileSystem = fileSystem;
		_installFileExecutor = installFileExecutor;
		_restClientFactory = restClientFactory;
		_downloadPrompt = downloadPrompt;
		_zipService = zipService;
	}

	public async Task<bool> CheckAvailabilityAsync()
	{
		if (!_configuration.PluginExists)
		{
			if (_downloadPrompt.ShowConfirmDownload())
			{
				return await DoCheckAvailabilityAsync();
			}
			return false;
		}
		return _configuration.PluginExists;
	}

	private async Task<bool> DoCheckAvailabilityAsync()
	{
		if (!(await DownloadAndInstallAsync()) && _downloadPrompt.ShowDownloadFailed())
		{
			return await DoCheckAvailabilityAsync();
		}
		return _configuration.PluginExists;
	}

	private async Task<bool> DownloadAndInstallAsync()
	{
		string text = _fileSystem.Path.Combine(_fileSystem.Path.GetTempPath(), "AirCast");
		_fileSystem.Directory.CreateDirectory(text);
		string downloadDest = _fileSystem.Path.Combine(text, _fileSystem.Path.GetRandomFileName());
		if (await DoDownloadAsync(downloadDest))
		{
			await DoInstallAsync(downloadDest);
			return true;
		}
		return false;
	}

	private async Task<bool> DoDownloadAsync(string downloadDest)
	{
		RestRequest request = new RestRequest(_webSourceProvider.GenerateLink(ResourceType.AirCastDownload));
		IRestClient restClient = _restClientFactory.Get();
		try
		{
			using FileSystemStream file = _fileSystem.File.OpenWrite(downloadDest);
			using Stream responseStream = await restClient.DownloadStreamAsync(request);
			if (responseStream != null)
			{
				await responseStream.CopyToAsync(file);
				return true;
			}
			return false;
		}
		catch
		{
			return false;
		}
	}

	private async Task DoInstallAsync(string source)
	{
		IFileInfo fileInfo = _fileSystem.FileInfo.New(_configuration.PluginPath);
		string path = _fileSystem.FileInfo.New(source)?.Directory?.FullName ?? string.Empty;
		string text = _fileSystem.Path.Combine(path, _fileSystem.Path.GetRandomFileName());
		_fileSystem.Directory.CreateDirectory(text);
		_zipService.UnzipFile(source, text);
		await _installFileExecutor.DoInstallAsync(text, fileInfo.Directory?.FullName ?? string.Empty);
		_configuration.NotifyPluginInstalled();
	}
}
