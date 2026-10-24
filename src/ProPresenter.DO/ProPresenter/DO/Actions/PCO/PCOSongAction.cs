using System.Linq;
using Pro.DO.Triggering;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.PCO;
using ProPresenter.DO.PCO.Items;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Actions.PCO;

public class PCOSongAction : PCOActionBase
{
	private readonly IStoredPcoOptions _storedPcoOptions;

	public override ActionType ActionType => ActionType.Document;

	public PCOSongAction(IApp app, IStoredPcoOptions storedPcoOptions)
		: base(app)
	{
		_storedPcoOptions = storedPcoOptions;
	}

	public override void LinkDocument(IPresentation document, PCOItem? updatedPlanItem)
	{
		base.LinkDocument(document, updatedPlanItem);
		if (!(updatedPlanItem is PCOPlanSong pCOPlanSong))
		{
			return;
		}
		string[] sequence = pCOPlanSong.Arrangement?.Sequence;
		string[] array = sequence;
		if (array != null && array.Any())
		{
			IArrangement arrangement = document.Arrangements.FirstOrDefault((IArrangement a) => a.SequenceFullyMatchesArrangement(sequence));
			if (_storedPcoOptions.ArrangementFromSequences && arrangement == null)
			{
				string text = (pCOPlanSong.Arrangement.IsCustom ? pCOPlanSong.Arrangement.Name : (pCOPlanSong.Arrangement.Name + " (PCO)"));
				arrangement = document.BuildArrangement(sequence, text ?? string.Empty);
			}
			if (arrangement != null && base.DocumentAction != null)
			{
				base.DocumentAction.ActiveArrangement = arrangement;
			}
		}
	}
}
