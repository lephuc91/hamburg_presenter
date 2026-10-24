using System;
using System.IO.Abstractions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.Import;

public interface IImportHelperServices
{
	void RelinkThemeAssets(string themefile, string themeFolder, string assetsFolder, Action<Pro.SerializationInterop.RVProtoData.Media>? copyMediaCallback = null);

	void ImportThemeAssets(string themeFile, string assetsFolder, IFileSystem fileSystem, IMediaFactory mediaFactory, string containerId);

	void RelinkThemeAssets(Template.Types.Document templateDocument, string assetsFolder, Action<Pro.SerializationInterop.RVProtoData.Media>? copyMediaCallback = null);
}
