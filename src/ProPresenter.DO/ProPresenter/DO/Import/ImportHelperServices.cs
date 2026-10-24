using System;
using System.IO.Abstractions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.Import;

public class ImportHelperServices : IImportHelperServices
{
	public void RelinkThemeAssets(string themeFile, string themeFolder, string assetsFolder, Action<Pro.SerializationInterop.RVProtoData.Media>? copyMediaCallback = null)
	{
		themeFile.RelinkThemeAssets(themeFolder, assetsFolder, copyMediaCallback);
	}

	public void ImportThemeAssets(string themeFile, string assetsFolder, IFileSystem fileSystem, IMediaFactory mediaFactory, string containerId)
	{
		themeFile.ImportThemeAssets(assetsFolder, fileSystem, mediaFactory, containerId);
	}

	public void RelinkThemeAssets(Template.Types.Document templateDocument, string assetsFolder, Action<Pro.SerializationInterop.RVProtoData.Media>? copyMediaCallback = null)
	{
		ImportHelper.RelinkThemeAssets(templateDocument, assetsFolder, copyMediaCallback);
	}
}
