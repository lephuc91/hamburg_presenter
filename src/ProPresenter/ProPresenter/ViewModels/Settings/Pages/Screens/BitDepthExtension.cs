using Pro.Common.SourceGenerator.Attributes;
using ProPresenter.DO.Settings.AppSettings;
using ProPresenter.UI.ViewModels.Settings.Pages.Screens;

namespace ProPresenter.ViewModels.Settings.Pages.Screens;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(BitDepths), typeof(BitDepth), DestinationDefaultValue = "Normal", SourceToDestinationMethodName = "ToDo", SourceDefaultValue = "Normal", DestinationToSourceMethodName = "ToUi")]
public static class BitDepthExtension
{
	public static BitDepth ToDo(this BitDepths source)
	{
		return source switch
		{
			BitDepths.Normal => BitDepth.Normal, 
			BitDepths.Enhanced => BitDepth.Enhanced, 
			_ => BitDepth.Normal, 
		};
	}

	public static BitDepths ToUi(this BitDepth source)
	{
		return source switch
		{
			BitDepth.Normal => BitDepths.Normal, 
			BitDepth.Enhanced => BitDepths.Enhanced, 
			_ => BitDepths.Normal, 
		};
	}
}
