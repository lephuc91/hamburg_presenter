using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.DO.Registration.State.Bible;

namespace ProPresenter.Registration.CallbackHandlers.State.Extensions.Bible;

public static class MetadataExtension
{
	public static Metadata ToMetadata(this Pro.SerializationInterop.RVProtoData.Registration.Bible bible)
	{
		return new Metadata(bible.Id, bible.Name, bible.Language, bible.Publisher, bible.Copyright, bible.DisplayAbbreviation, bible.InternalAbbreviation, bible.Version, bible.Info?.DownloadLink);
	}
}
