using System;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Cues.PCO;
using ProPresenter.DO.Librarian;
using ProPresenter.UI.ViewModels.Library.Cue;

namespace ProPresenter.ViewModels.Library.Cue;

public class ProPresenterCueVMFactory(ILibraryCollection libraries) : IProPresenterCueVMFactory
{
	public IProPresenterCueVM Create(ProPresenterCue cue)
	{
		if (!(cue is DocumentCue documentCue))
		{
			if (!(cue is PCOCueBase pcoCue))
			{
				if (!(cue is MediaCue media))
				{
					if (!(cue is PlaceholderCue placeholderCue))
					{
						if (cue is HeaderCue headerCue)
						{
							return new HeaderCueVM(headerCue);
						}
						throw new NotSupportedException($"Cue type {cue.Type} is not supported by the factory.");
					}
					return new PlaceholderCueVM(placeholderCue, libraries);
				}
				return new MediaCueVM(media);
			}
			return new PcoCueVM(pcoCue, libraries);
		}
		return new DocumentCueVM(documentCue, libraries);
	}
}
