using Pro.SerializationInterop.RVProtoData.Analytics.Create;

namespace ProPresenter.DO.Analytics;

public static class PresentationCreateSourceExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Analytics.Create.Presentation.Types.Source ToProto(this PresentationCreateSource source)
	{
		return source switch
		{
			PresentationCreateSource.ApplicationMenu => Pro.SerializationInterop.RVProtoData.Analytics.Create.Presentation.Types.Source.ApplicationMenu, 
			PresentationCreateSource.OutlineAddButton => Pro.SerializationInterop.RVProtoData.Analytics.Create.Presentation.Types.Source.LibraryOutlineAddButton, 
			PresentationCreateSource.DetailAddButton => Pro.SerializationInterop.RVProtoData.Analytics.Create.Presentation.Types.Source.DetailAddButton, 
			PresentationCreateSource.UnlinkedHeader => Pro.SerializationInterop.RVProtoData.Analytics.Create.Presentation.Types.Source.UnlinkedHeader, 
			_ => Pro.SerializationInterop.RVProtoData.Analytics.Create.Presentation.Types.Source.Unknown, 
		};
	}
}
