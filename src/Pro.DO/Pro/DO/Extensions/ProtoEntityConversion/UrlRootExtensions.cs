using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Extensions.ProtoEntityConversion;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(Url.Types.LocalRelativePath.Types.Root), typeof(URL.Types.LocalRelativePath.Types.Root), SourceToDestinationMethodName = "ToProtoUrlRoot", SourceDefaultValue = "Unknown", DestinationToSourceMethodName = "ToEntityUrlRoot", DestinationDefaultValue = "Unknown")]
public static class UrlRootExtensions
{
	public static URL.Types.LocalRelativePath.Types.Root ToProtoUrlRoot(this Url.Types.LocalRelativePath.Types.Root source)
	{
		return source switch
		{
			Url.Types.LocalRelativePath.Types.Root.Unknown => URL.Types.LocalRelativePath.Types.Root.Unknown, 
			Url.Types.LocalRelativePath.Types.Root.BootVolume => URL.Types.LocalRelativePath.Types.Root.BootVolume, 
			Url.Types.LocalRelativePath.Types.Root.UserHome => URL.Types.LocalRelativePath.Types.Root.UserHome, 
			Url.Types.LocalRelativePath.Types.Root.UserDocuments => URL.Types.LocalRelativePath.Types.Root.UserDocuments, 
			Url.Types.LocalRelativePath.Types.Root.UserDownloads => URL.Types.LocalRelativePath.Types.Root.UserDownloads, 
			Url.Types.LocalRelativePath.Types.Root.UserMusic => URL.Types.LocalRelativePath.Types.Root.UserMusic, 
			Url.Types.LocalRelativePath.Types.Root.UserPictures => URL.Types.LocalRelativePath.Types.Root.UserPictures, 
			Url.Types.LocalRelativePath.Types.Root.UserVideos => URL.Types.LocalRelativePath.Types.Root.UserVideos, 
			Url.Types.LocalRelativePath.Types.Root.UserAppSupport => URL.Types.LocalRelativePath.Types.Root.UserAppSupport, 
			Url.Types.LocalRelativePath.Types.Root.Shared => URL.Types.LocalRelativePath.Types.Root.Shared, 
			Url.Types.LocalRelativePath.Types.Root.Show => URL.Types.LocalRelativePath.Types.Root.Show, 
			Url.Types.LocalRelativePath.Types.Root.UserDesktop => URL.Types.LocalRelativePath.Types.Root.UserDesktop, 
			Url.Types.LocalRelativePath.Types.Root.CurrentResource => URL.Types.LocalRelativePath.Types.Root.CurrentResource, 
			_ => URL.Types.LocalRelativePath.Types.Root.Unknown, 
		};
	}

	public static Url.Types.LocalRelativePath.Types.Root ToEntityUrlRoot(this URL.Types.LocalRelativePath.Types.Root source)
	{
		return source switch
		{
			URL.Types.LocalRelativePath.Types.Root.Unknown => Url.Types.LocalRelativePath.Types.Root.Unknown, 
			URL.Types.LocalRelativePath.Types.Root.BootVolume => Url.Types.LocalRelativePath.Types.Root.BootVolume, 
			URL.Types.LocalRelativePath.Types.Root.UserHome => Url.Types.LocalRelativePath.Types.Root.UserHome, 
			URL.Types.LocalRelativePath.Types.Root.UserDocuments => Url.Types.LocalRelativePath.Types.Root.UserDocuments, 
			URL.Types.LocalRelativePath.Types.Root.UserDownloads => Url.Types.LocalRelativePath.Types.Root.UserDownloads, 
			URL.Types.LocalRelativePath.Types.Root.UserMusic => Url.Types.LocalRelativePath.Types.Root.UserMusic, 
			URL.Types.LocalRelativePath.Types.Root.UserPictures => Url.Types.LocalRelativePath.Types.Root.UserPictures, 
			URL.Types.LocalRelativePath.Types.Root.UserVideos => Url.Types.LocalRelativePath.Types.Root.UserVideos, 
			URL.Types.LocalRelativePath.Types.Root.UserDesktop => Url.Types.LocalRelativePath.Types.Root.UserDesktop, 
			URL.Types.LocalRelativePath.Types.Root.UserAppSupport => Url.Types.LocalRelativePath.Types.Root.UserAppSupport, 
			URL.Types.LocalRelativePath.Types.Root.Shared => Url.Types.LocalRelativePath.Types.Root.Shared, 
			URL.Types.LocalRelativePath.Types.Root.Show => Url.Types.LocalRelativePath.Types.Root.Show, 
			URL.Types.LocalRelativePath.Types.Root.CurrentResource => Url.Types.LocalRelativePath.Types.Root.CurrentResource, 
			_ => Url.Types.LocalRelativePath.Types.Root.Unknown, 
		};
	}
}
