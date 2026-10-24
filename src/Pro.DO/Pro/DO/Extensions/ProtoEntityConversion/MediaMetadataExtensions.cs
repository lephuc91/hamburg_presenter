using System;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Extensions.ProtoEntityConversion;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(IMedia.Types.IMetadata.Types.ColorFormat), typeof(Media.Types.Metadata.Types.ColorFormat), SourceToDestinationMethodName = "ToProto", DestinationToSourceMethodName = "ToEntity")]
public static class MediaMetadataExtensions
{
	public static Media.Types.Metadata ToProtoMediaMetadata(this IMedia.Types.IMetadata source)
	{
		Media.Types.Metadata metadata = new Media.Types.Metadata
		{
			Format = source.Format.Value,
			ColorFormat = source.ColorFormat.Value.ToProto()
		};
		if (source.ManufactureName.Value != null)
		{
			metadata.ManufactureName = source.ManufactureName.Value;
		}
		if ((object)source.ManufactureUrl.Value != null)
		{
			metadata.ManufactureUrl = source.ManufactureUrl.Value.ToProtoUrl();
		}
		if (source.Information.Value != null)
		{
			metadata.Information = source.Information.Value;
		}
		if (source.Artist.Value != null)
		{
			metadata.Artist = source.Artist.Value;
		}
		return metadata;
	}

	public static IMedia.Types.IMetadata ToEntityMediaMetadata(this Media.Types.Metadata source, IEntityFactory entityFactory)
	{
		IMedia.Types.IMetadata metadata = entityFactory.Create<IMedia.Types.IMetadata>();
		metadata.Format.Set(source.Format);
		metadata.ColorFormat.Set(source.ColorFormat.ToEntity());
		metadata.ManufactureName.Set(source.ManufactureName);
		metadata.ManufactureUrl.Set(source.ManufactureUrl?.ToEntityUrl());
		metadata.Information.Set(source.Information);
		metadata.Artist.Set(source.Artist);
		return metadata;
	}

	public static Media.Types.Metadata.Types.ColorFormat ToProto(this IMedia.Types.IMetadata.Types.ColorFormat source)
	{
		return source switch
		{
			IMedia.Types.IMetadata.Types.ColorFormat.Unknown => Media.Types.Metadata.Types.ColorFormat.Unknown, 
			IMedia.Types.IMetadata.Types.ColorFormat.Sdr => Media.Types.Metadata.Types.ColorFormat.Sdr, 
			IMedia.Types.IMetadata.Types.ColorFormat.HdrRec2100Hlg => Media.Types.Metadata.Types.ColorFormat.HdrRec2100Hlg, 
			IMedia.Types.IMetadata.Types.ColorFormat.HdrRec2100Pq => Media.Types.Metadata.Types.ColorFormat.HdrRec2100Pq, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static IMedia.Types.IMetadata.Types.ColorFormat ToEntity(this Media.Types.Metadata.Types.ColorFormat source)
	{
		return source switch
		{
			Media.Types.Metadata.Types.ColorFormat.Unknown => IMedia.Types.IMetadata.Types.ColorFormat.Unknown, 
			Media.Types.Metadata.Types.ColorFormat.Sdr => IMedia.Types.IMetadata.Types.ColorFormat.Sdr, 
			Media.Types.Metadata.Types.ColorFormat.HdrRec2100Hlg => IMedia.Types.IMetadata.Types.ColorFormat.HdrRec2100Hlg, 
			Media.Types.Metadata.Types.ColorFormat.HdrRec2100Pq => IMedia.Types.IMetadata.Types.ColorFormat.HdrRec2100Pq, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}
}
