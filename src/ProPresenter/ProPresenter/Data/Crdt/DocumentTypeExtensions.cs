using System;
using Pro.Common.SourceGenerator.Attributes;
using Pro.CoreApplication.Document;
using Pro.Entity.Persistence;

namespace ProPresenter.Data.Crdt;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(Pro.Entity.Persistence.DocumentType), typeof(Pro.CoreApplication.Document.DocumentType), SourceToDestinationMethodName = "ToApplicationDocumentType", DestinationToSourceMethodName = "ToEntityDocumentType")]
internal static class DocumentTypeExtensions
{
	public static Pro.CoreApplication.Document.DocumentType ToApplicationDocumentType(this Pro.Entity.Persistence.DocumentType source)
	{
		return source switch
		{
			Pro.Entity.Persistence.DocumentType.Presentation => Pro.CoreApplication.Document.DocumentType.Presentation, 
			Pro.Entity.Persistence.DocumentType.Theme => Pro.CoreApplication.Document.DocumentType.Theme, 
			Pro.Entity.Persistence.DocumentType.Effect => Pro.CoreApplication.Document.DocumentType.Effect, 
			Pro.Entity.Persistence.DocumentType.Transition => Pro.CoreApplication.Document.DocumentType.Transition, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static Pro.Entity.Persistence.DocumentType ToEntityDocumentType(this Pro.CoreApplication.Document.DocumentType source)
	{
		return source switch
		{
			Pro.CoreApplication.Document.DocumentType.Presentation => Pro.Entity.Persistence.DocumentType.Presentation, 
			Pro.CoreApplication.Document.DocumentType.Theme => Pro.Entity.Persistence.DocumentType.Theme, 
			Pro.CoreApplication.Document.DocumentType.Transition => Pro.Entity.Persistence.DocumentType.Transition, 
			Pro.CoreApplication.Document.DocumentType.Effect => Pro.Entity.Persistence.DocumentType.Effect, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}
}
