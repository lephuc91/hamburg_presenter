using System.Collections.Generic;
using System.Linq;
using ProPresenter.DO;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;

namespace ProPresenter.ViewModels.Actions;

public class StageDisplayDialogVM : ActionDialogContentVM
{
	public IEnumerable<SlideCue> StageLayouts => DataVault.StagePresentation.Layouts;

	public StageDisplayDialogVM()
	{
		CueCollection cueCollection = DataVault.StagePresentation.ArrangementGroups.FirstOrDefault()?.Cues;
		if (cueCollection != null)
		{
			cueCollection.CollectionChanged += delegate
			{
				OnPropertyChanged("StageLayouts");
			};
		}
	}
}
