using ProPresenter.DO.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages.Import;

namespace ProPresenter.ViewModels.Settings.Pages.Import;

public static class ImportDurationTypeInternalExtensions
{
	public static ImportDurationType ToImportDurationType(this ImportDurationTypeInternal importDurationType)
	{
		return importDurationType switch
		{
			ImportDurationTypeInternal.None => ImportDurationType.None, 
			ImportDurationTypeInternal.Time => ImportDurationType.Time, 
			ImportDurationTypeInternal.Random => ImportDurationType.Random, 
			_ => ImportDurationType.None, 
		};
	}

	public static ImportDurationTypeInternal ToImportDurationTypeInternal(this ImportDurationType importDurationType)
	{
		return importDurationType switch
		{
			ImportDurationType.None => ImportDurationTypeInternal.None, 
			ImportDurationType.Time => ImportDurationTypeInternal.Time, 
			ImportDurationType.Random => ImportDurationTypeInternal.Random, 
			_ => ImportDurationTypeInternal.None, 
		};
	}
}
