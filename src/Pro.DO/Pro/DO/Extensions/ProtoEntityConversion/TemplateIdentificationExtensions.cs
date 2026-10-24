using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Extensions.ProtoEntityConversion;

public static class TemplateIdentificationExtensions
{
	public static TemplateIdentification ToProto(this ITemplateIdentification templateIdentification)
	{
		TemplateIdentification templateIdentification2 = new TemplateIdentification
		{
			Name = templateIdentification.Name.Value,
			SlideIndex = templateIdentification.SlideIndex.Value,
			SlideName = templateIdentification.SlideName.Value,
			SlideUuid = templateIdentification.SlideUuid.Value.ToUUID()
		};
		if (templateIdentification.Uuid.Value.HasValue)
		{
			templateIdentification2.Uuid = templateIdentification.Uuid.Value?.ToUUID();
		}
		return templateIdentification2;
	}

	public static ITemplateIdentification ToEntity(this TemplateIdentification protoTemplateIdentification, IEntityFactory entityFactory)
	{
		ITemplateIdentification templateIdentification = entityFactory.Create<ITemplateIdentification>();
		templateIdentification.Name.Set(protoTemplateIdentification.Name);
		templateIdentification.SlideIndex.Set(protoTemplateIdentification.SlideIndex);
		templateIdentification.SlideName.Set(protoTemplateIdentification.SlideName);
		templateIdentification.SlideUuid.Set(protoTemplateIdentification.SlideUuid.ToGuid());
		templateIdentification.Uuid.Set(protoTemplateIdentification.Uuid?.ToGuid());
		return templateIdentification;
	}
}
