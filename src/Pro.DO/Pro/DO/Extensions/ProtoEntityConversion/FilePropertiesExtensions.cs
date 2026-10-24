using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Extensions.ProtoEntityConversion;

public static class FilePropertiesExtensions
{
	public static FileProperties ToProto(this IFileProperties source)
	{
		return new FileProperties
		{
			LocalUrl = source.LocalUrl.Value.ToProtoUrl(),
			RemoteProperties = new FileProperties.Types.RemoteProperties
			{
				Procontent = new FileProperties.Types.RemoteProperties.Types.ProContent
				{
					DownloadIdentifier = source.RemoteProperties.Value.Procontent.Value.DownloadIdentifier.Value
				}
			}
		};
	}

	public static IFileProperties ToEntity(this FileProperties source, IEntityFactory entityFactory)
	{
		IFileProperties fileProperties = entityFactory.Create<IFileProperties>();
		fileProperties.LocalUrl.Set(source.LocalUrl.ToEntityUrl());
		fileProperties.RemoteProperties.Value.Procontent.Value.DownloadIdentifier.Set(source.RemoteProperties.Procontent.DownloadIdentifier);
		return fileProperties;
	}
}
