using System;
using Pro.Common.SourceGenerator.Attributes;
using Pro.SerializationInterop.RVProtoData.Service.Document;

namespace Pro.CoreApplication.Document;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(DocumentType), typeof(Pro.SerializationInterop.RVProtoData.Service.Document.Document.Types.Kind), SourceToDestinationMethodName = "ToProto", DestinationToSourceMethodName = "ToDomain", ExcludeSourceNames = new string[] { "Transition", "Effect" })]
public static class DocumentTypeExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Service.Document.Document.Types.Kind ToProto(this DocumentType source)
	{
		return source switch
		{
			DocumentType.Presentation => Pro.SerializationInterop.RVProtoData.Service.Document.Document.Types.Kind.Presentation, 
			DocumentType.Theme => Pro.SerializationInterop.RVProtoData.Service.Document.Document.Types.Kind.Theme, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static DocumentType ToDomain(this Pro.SerializationInterop.RVProtoData.Service.Document.Document.Types.Kind source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Service.Document.Document.Types.Kind.Presentation => DocumentType.Presentation, 
			Pro.SerializationInterop.RVProtoData.Service.Document.Document.Types.Kind.Theme => DocumentType.Theme, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}
}
