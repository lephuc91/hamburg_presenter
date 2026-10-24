using Pro.SerializationInterop.RVProtoData.Analytics.Create;

namespace ProPresenter.DO.Analytics;

public static class LibraryCreateSourceExtensions
{
	public static Library.Types.Source ToProto(this LibraryCreateSource source)
	{
		return source switch
		{
			LibraryCreateSource.ApplicationMenu => Library.Types.Source.ApplicationMenu, 
			LibraryCreateSource.OutlineAddButton => Library.Types.Source.LibraryOutlineAddButton, 
			_ => Library.Types.Source.Unknown, 
		};
	}
}
