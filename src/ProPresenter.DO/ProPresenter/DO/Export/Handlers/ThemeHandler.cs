using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.FeatureFlag;
using ProPresenter.DO.Export.Requests;
using ProPresenter.DO.Media;
using ProPresenter.DO.Media.Properties.File;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.Export.Handlers;

public class ThemeHandler : IRequestHandler
{
	private readonly IFileSystem _fileSystem;

	private readonly IFileService _fileService;

	private readonly IFlagService _flagService;

	public ThemeHandler(IFileSystem fileSystem, IFileService fileService, IFlagService flagService)
	{
		_fileSystem = fileSystem;
		_fileService = fileService;
		_flagService = flagService;
	}

	public bool CanHandle(IExportRequest request)
	{
		return request is ThemeExportRequest;
	}

	public void Handle(IExportProcess process, IExportRequest request, UpdateStatusDelegate updateStatus, ResolveConflictDelegate resolveConflict)
	{
		string tempDirectory = ExportHelper.GetTempDirectory();
		if (request is ThemeExportRequest themeExportRequest)
		{
			foreach (Theme theme in themeExportRequest.Themes)
			{
				if (process.ExportCanceled)
				{
					return;
				}
				request.CurrentItemName = theme.Name;
				updateStatus(request);
				string themeDir = _fileSystem.Path.Combine(CommonPaths.Themes, theme.Path);
				string text = _fileSystem.Path.Combine(tempDirectory, theme.Name);
				string path = _fileSystem.Path.Combine(text, "Assets");
				if ((bool)_fileService.WaitForFileAccess(themeDir, enforceFileExists: false, null))
				{
					_fileService.CopyFiles(themeDir, text, overwrite: true);
				}
				if (!_flagService.IsFlagEnabled(Flag.Cloud))
				{
					continue;
				}
				foreach (TemplateSlide item in theme)
				{
					List<string> list = new List<string>();
					FileMediaBase fileMediaBase = item.MediaAction?.FileMedia;
					if (!(fileMediaBase?.File.RemoteProperties is ProContentFileProperties))
					{
						list.Add(fileMediaBase?.SourceFile?.FullPath);
					}
					list.AddRange(from x in CustomSlide.GetTrackedMediaFromElements(item.Slide.Elements).OfType<FileMediaBase>()
						where !(x.File.RemoteProperties is ProContentFileProperties)
						select x.SourceFile?.FullPath);
					foreach (string item2 in (from x in list.NotNull()
						where !x.Contains(themeDir) && _fileSystem.File.Exists(x)
						select x).Distinct())
					{
						_fileSystem.File.Copy(item2, _fileSystem.Path.Combine(path, _fileSystem.Path.GetFileName(item2)));
					}
				}
			}
		}
		_fileSystem.File.Delete(process.Destination);
		_fileService.ZipFolder(tempDirectory, process.Destination);
	}
}
