using System;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Extensions.ProtoEntityConversion;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(Url.Types.Platform), typeof(URL.Types.Platform), SourceToDestinationMethodName = "ToProto", SourceDefaultValue = "Unknown", DestinationToSourceMethodName = "ToEntity", DestinationDefaultValue = "Unknown")]
public static class UrlExtensions
{
	public static URL ToProtoUrl(this Url source)
	{
		URL uRL = new URL
		{
			Platform = source.Platform.ToProto()
		};
		ToProto(source.Storage, uRL);
		ToProto(source.RelativeFilePath, uRL);
		return uRL;
	}

	public static Url ToEntityUrl(this URL source)
	{
		return new Url(source.Platform.ToEntity(), GetEntityStorage(source), GetEntityRelativeFilePath(source));
	}

	private static void ToProto(Url.Types.Storage source, URL url)
	{
		if (!(source is Url.Types.Storage.AbsoluteString absoluteString))
		{
			if (!(source is Url.Types.Storage.RelativePath relativePath))
			{
				throw new NotSupportedException();
			}
			url.RelativePath = relativePath._RelativePath;
		}
		else
		{
			url.AbsoluteString = absoluteString._AbsoluteString;
		}
	}

	private static void ToProto(Url.Types.RelativeFilePath source, URL url)
	{
		if (!(source is Url.Types.RelativeFilePath.Local local))
		{
			if (!(source is Url.Types.RelativeFilePath.External external))
			{
				throw new NotSupportedException();
			}
			url.External = new URL.Types.ExternalRelativePath
			{
				Macos = new URL.Types.ExternalRelativePath.Types.MacOSExternalVolume
				{
					VolumeName = external._External.Macos.VolumeName
				},
				Win32 = new URL.Types.ExternalRelativePath.Types.Win32ExternalVolume
				{
					DriveLetter = external._External.Win32.DriveLetter,
					VolumeName = external._External.Win32.VolumeName,
					NetworkShare = external._External.Win32.NetworkShare
				},
				Path = external._External.Path
			};
		}
		else
		{
			url.Local = new URL.Types.LocalRelativePath
			{
				Root = local._Local.Root.ToProtoUrlRoot(),
				Path = local._Local.Path
			};
		}
	}

	private static Url.Types.Storage GetEntityStorage(URL source)
	{
		return source.StorageCase switch
		{
			URL.StorageOneofCase.AbsoluteString => new Url.Types.Storage.AbsoluteString(source.AbsoluteString), 
			URL.StorageOneofCase.RelativePath => new Url.Types.Storage.RelativePath(source.RelativePath), 
			_ => throw new NotSupportedException(), 
		};
	}

	private static Url.Types.RelativeFilePath GetEntityRelativeFilePath(URL source)
	{
		return source.RelativeFilePathCase switch
		{
			URL.RelativeFilePathOneofCase.Local => new Url.Types.RelativeFilePath.Local(new Url.Types.LocalRelativePath(source.Local.Root.ToEntityUrlRoot(), source.Local.Path)), 
			URL.RelativeFilePathOneofCase.External => new Url.Types.RelativeFilePath.External(new Url.Types.ExternalRelativePath(new Url.Types.ExternalRelativePath.Types.MacOsExternalVolume(source.External.Macos.VolumeName), new Url.Types.ExternalRelativePath.Types.Win32ExternalVolume(source.External.Win32.DriveLetter, source.External.Win32.VolumeName, source.External.Win32.NetworkShare), source.External.Path)), 
			_ => throw new NotSupportedException(), 
		};
	}

	public static URL.Types.Platform ToProto(this Url.Types.Platform source)
	{
		return source switch
		{
			Url.Types.Platform.Unknown => URL.Types.Platform.Unknown, 
			Url.Types.Platform.Macos => URL.Types.Platform.Macos, 
			Url.Types.Platform.Win32 => URL.Types.Platform.Win32, 
			Url.Types.Platform.Web => URL.Types.Platform.Web, 
			_ => URL.Types.Platform.Unknown, 
		};
	}

	public static Url.Types.Platform ToEntity(this URL.Types.Platform source)
	{
		return source switch
		{
			URL.Types.Platform.Unknown => Url.Types.Platform.Unknown, 
			URL.Types.Platform.Macos => Url.Types.Platform.Macos, 
			URL.Types.Platform.Win32 => Url.Types.Platform.Win32, 
			URL.Types.Platform.Web => Url.Types.Platform.Web, 
			_ => Url.Types.Platform.Unknown, 
		};
	}
}
