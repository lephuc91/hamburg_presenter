using System.IO.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using Pro.DO.Storage;
using ProPresenter.DO.Looks;
using ProPresenter.DO.Masks;
using ProPresenter.DO.Media;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.DO.CloudOnboarding;

public sealed class MediaFileProvider : IMediaFileProvider
{
	private readonly IProPresenterResourceService _resourceService;

	private readonly IAudienceLookCollection _looks;

	private readonly IFileSystem _fileSystem;

	private readonly IMaskCollection _masks;

	public MediaFileProvider(IProPresenterResourceService resourceService, IOutputConfiguration outputConfiguration, IFileSystem fileSystem, IMaskCollection masks)
	{
		_resourceService = resourceService;
		_looks = outputConfiguration.AudienceLooks;
		_fileSystem = fileSystem;
		_masks = masks;
	}

	public Task<long> GetUnmanagedMediaBytesAsync()
	{
		return Task.Run(() => (from file in MediaHelper.GetAllMediaFiles(_resourceService, _looks, _masks)
			select new RelativePath(file) into relPath
			where _fileSystem.File.Exists(relPath) && !IsManagedFile(relPath)
			select relPath).Sum((RelativePath relPath) => _fileSystem.FileInfo.New(relPath).Length));
	}

	private static bool IsManagedFile(string filePath)
	{
		return filePath.Replace("//", "/").Contains(CommonPaths.MediaAssets);
	}

	public bool HasUnmanagedMedia()
	{
		foreach (string allMediaFile in MediaHelper.GetAllMediaFiles(_resourceService, _looks, _masks))
		{
			RelativePath relativePath = new RelativePath(allMediaFile);
			if (_fileSystem.File.Exists(relativePath) && !IsManagedFile(relativePath))
			{
				return true;
			}
		}
		return false;
	}
}
