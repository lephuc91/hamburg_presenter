using System;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Storage;

public static class SearchRootTypeExtensions
{
	public static URL.Types.LocalRelativePath.Types.Root ToProtoLocalRoot(this SearchRootType searchRootType)
	{
		return searchRootType switch
		{
			SearchRootType.BootVolume => URL.Types.LocalRelativePath.Types.Root.BootVolume, 
			SearchRootType.Home => URL.Types.LocalRelativePath.Types.Root.UserHome, 
			SearchRootType.Documents => URL.Types.LocalRelativePath.Types.Root.UserDocuments, 
			SearchRootType.Downloads => URL.Types.LocalRelativePath.Types.Root.UserDownloads, 
			SearchRootType.Music => URL.Types.LocalRelativePath.Types.Root.UserMusic, 
			SearchRootType.Pictures => URL.Types.LocalRelativePath.Types.Root.UserPictures, 
			SearchRootType.Videos => URL.Types.LocalRelativePath.Types.Root.UserVideos, 
			SearchRootType.Desktop => URL.Types.LocalRelativePath.Types.Root.UserDesktop, 
			SearchRootType.AppData => URL.Types.LocalRelativePath.Types.Root.UserAppSupport, 
			SearchRootType.ProgramData => URL.Types.LocalRelativePath.Types.Root.Shared, 
			SearchRootType.Show => URL.Types.LocalRelativePath.Types.Root.Show, 
			SearchRootType.OtherVolumes => URL.Types.LocalRelativePath.Types.Root.Unknown, 
			_ => throw new NotSupportedException(), 
		};
	}
}
