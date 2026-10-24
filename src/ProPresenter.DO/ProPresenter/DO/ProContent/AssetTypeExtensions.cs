using System;
using Pro.Common.SourceGenerator.Attributes;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v2;
using ProPresenter.DO.ProContent.Consumer.Model.Download;
using ProPresenter.DO.ProContent.Model.Download;

namespace ProPresenter.DO.ProContent;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(AssetType), typeof(ProContentDownloadDetails.Types.AssetType), SourceToDestinationMethodName = "ToProtoAssetType", DestinationToSourceMethodName = "ToAssetType", ExcludeDestinationNames = new string[] { "Unspecified" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(AssetType), typeof(ProContentDownloadAssetType), SourceToDestinationMethodName = "ToDownloadAssetType", DestinationToSourceMethodName = "ToAssetType")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(ProContentDownloadDetails.Types.AssetType), typeof(ProContentDownloadAssetType), SourceToDestinationMethodName = "ToDownloadAssetType", DestinationToSourceMethodName = "ToProtoAssetType", ExcludeSourceNames = new string[] { "Unspecified" })]
public static class AssetTypeExtensions
{
	public static ProContentDownloadDetails.Types.AssetType ToProtoAssetType(this AssetType source)
	{
		return source switch
		{
			AssetType.Loop => ProContentDownloadDetails.Types.AssetType.Loop, 
			AssetType.Countdown => ProContentDownloadDetails.Types.AssetType.Countdown, 
			AssetType.Image => ProContentDownloadDetails.Types.AssetType.Image, 
			AssetType.MotionTitle => ProContentDownloadDetails.Types.AssetType.MotionTitle, 
			AssetType.Pack => ProContentDownloadDetails.Types.AssetType.Pack, 
			AssetType.Theme => ProContentDownloadDetails.Types.AssetType.Theme, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static AssetType ToAssetType(this ProContentDownloadDetails.Types.AssetType source)
	{
		return source switch
		{
			ProContentDownloadDetails.Types.AssetType.Loop => AssetType.Loop, 
			ProContentDownloadDetails.Types.AssetType.Countdown => AssetType.Countdown, 
			ProContentDownloadDetails.Types.AssetType.Image => AssetType.Image, 
			ProContentDownloadDetails.Types.AssetType.MotionTitle => AssetType.MotionTitle, 
			ProContentDownloadDetails.Types.AssetType.Pack => AssetType.Pack, 
			ProContentDownloadDetails.Types.AssetType.Theme => AssetType.Theme, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static ProContentDownloadAssetType ToDownloadAssetType(this AssetType source)
	{
		return source switch
		{
			AssetType.Loop => ProContentDownloadAssetType.Loop, 
			AssetType.Countdown => ProContentDownloadAssetType.Countdown, 
			AssetType.Image => ProContentDownloadAssetType.Image, 
			AssetType.MotionTitle => ProContentDownloadAssetType.MotionTitle, 
			AssetType.Pack => ProContentDownloadAssetType.Pack, 
			AssetType.Theme => ProContentDownloadAssetType.Theme, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static AssetType ToAssetType(this ProContentDownloadAssetType source)
	{
		return source switch
		{
			ProContentDownloadAssetType.Loop => AssetType.Loop, 
			ProContentDownloadAssetType.Countdown => AssetType.Countdown, 
			ProContentDownloadAssetType.Image => AssetType.Image, 
			ProContentDownloadAssetType.MotionTitle => AssetType.MotionTitle, 
			ProContentDownloadAssetType.Pack => AssetType.Pack, 
			ProContentDownloadAssetType.Theme => AssetType.Theme, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static ProContentDownloadAssetType ToDownloadAssetType(this ProContentDownloadDetails.Types.AssetType source)
	{
		return source switch
		{
			ProContentDownloadDetails.Types.AssetType.Loop => ProContentDownloadAssetType.Loop, 
			ProContentDownloadDetails.Types.AssetType.Countdown => ProContentDownloadAssetType.Countdown, 
			ProContentDownloadDetails.Types.AssetType.Image => ProContentDownloadAssetType.Image, 
			ProContentDownloadDetails.Types.AssetType.MotionTitle => ProContentDownloadAssetType.MotionTitle, 
			ProContentDownloadDetails.Types.AssetType.Pack => ProContentDownloadAssetType.Pack, 
			ProContentDownloadDetails.Types.AssetType.Theme => ProContentDownloadAssetType.Theme, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static ProContentDownloadDetails.Types.AssetType ToProtoAssetType(this ProContentDownloadAssetType source)
	{
		return source switch
		{
			ProContentDownloadAssetType.Loop => ProContentDownloadDetails.Types.AssetType.Loop, 
			ProContentDownloadAssetType.Countdown => ProContentDownloadDetails.Types.AssetType.Countdown, 
			ProContentDownloadAssetType.Image => ProContentDownloadDetails.Types.AssetType.Image, 
			ProContentDownloadAssetType.MotionTitle => ProContentDownloadDetails.Types.AssetType.MotionTitle, 
			ProContentDownloadAssetType.Pack => ProContentDownloadDetails.Types.AssetType.Pack, 
			ProContentDownloadAssetType.Theme => ProContentDownloadDetails.Types.AssetType.Theme, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}
}
