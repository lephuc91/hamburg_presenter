using System;
using System.Collections.Generic;
using Pro.Localization.Services;
using ProPresenter.DO.ProContent.Model.Asset;
using ProPresenter.DO.ProContent.Model.Download;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ViewModels.ProContent.Asset;

namespace ProPresenter.ViewModels.ProContent.Asset;

public static class ProContentPackAssetExtension
{
	public static IReadOnlyList<IProContentPackAssetContainsVM> ToContains(this IProContentPackAsset pack, ILocalization localization)
	{
		return pack.ToContains(localization, (string description, ProContentDownloadAssetType _) => new ProContentPackAssetContainsVM(description));
	}

	public static IReadOnlyList<IProContentPackAssetContainsDownloadEnableVM> ToContains(this IProContentPackAsset pack, ILocalization localization, IApp app)
	{
		return pack.ToContains(localization, (string description, ProContentDownloadAssetType type) => new ProContentPackAssetContainsDownloadEnableVM(description, type, app));
	}

	public static IReadOnlyList<T> ToContains<T>(this IProContentPackAsset pack, ILocalization localization, Func<string, ProContentDownloadAssetType, T> factoryMethod) where T : IProContentPackAssetContainsVM
	{
		List<T> list = new List<T>();
		AddPackageContent("PROCONTENT_DOWNLOAD_DIALOG_BACKGROUND_LOOPS_SINGULAR_title", "PROCONTENT_DOWNLOAD_DIALOG_BACKGROUND_LOOPS_PLURAL_title", pack.LoopCount, localization, list, ProContentDownloadAssetType.Loop, factoryMethod);
		AddPackageContent("PROCONTENT_DOWNLOAD_DIALOG_COUNTDOWNS_SINGULAR_title", "PROCONTENT_DOWNLOAD_DIALOG_COUNTDOWNS_PLURAL_title", pack.CountdownCount, localization, list, ProContentDownloadAssetType.Countdown, factoryMethod);
		AddPackageContent("PROCONTENT_DOWNLOAD_DIALOG_IMAGE_STILLS_SINGULAR_title", "PROCONTENT_DOWNLOAD_DIALOG_IMAGE_STILLS_PLURAL_title", pack.ImageCount, localization, list, ProContentDownloadAssetType.Image, factoryMethod);
		return list;
	}

	private static void AddPackageContent<T>(string singularIdentifier, string pluralIdentifier, int count, ILocalization localization, IList<T> contentList, ProContentDownloadAssetType filterFlag, Func<string, ProContentDownloadAssetType, T> factoryMethod) where T : IProContentPackAssetContainsVM
	{
		if (count > 0)
		{
			string key = ((count == 1) ? singularIdentifier : pluralIdentifier);
			contentList.Add(factoryMethod(localization.Get(key, new object[1] { count }), filterFlag));
		}
	}
}
