using ProPresenter.DO.Media;
using ProPresenter.UI.ViewModels.Settings.Pages.Import;

namespace ProPresenter.ViewModels.Settings.Pages.Import;

public static class ImportLayerInternalExtensions
{
	public static ImportLayer ToImportLayer(this ImportLayerInternal importLayer)
	{
		return importLayer switch
		{
			ImportLayerInternal.Background => ImportLayer.Background, 
			ImportLayerInternal.Foreground => ImportLayer.Foreground, 
			_ => ImportLayer.Background, 
		};
	}

	public static ImportLayerInternal ToImportLayerInternal(this ImportLayer importLayer)
	{
		return importLayer switch
		{
			ImportLayer.Background => ImportLayerInternal.Background, 
			ImportLayer.Foreground => ImportLayerInternal.Foreground, 
			_ => ImportLayerInternal.Background, 
		};
	}
}
