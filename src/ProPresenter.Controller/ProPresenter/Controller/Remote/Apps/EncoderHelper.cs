using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;

namespace ProPresenter.Controller.Remote.Apps;

public static class EncoderHelper
{
	public static string GetEncodedName(this IDocumentCue documentCue, Arrangement? arrangement = null)
	{
		if (documentCue == null)
		{
			return string.Empty;
		}
		IDocumentAction documentAction = documentCue.DocumentAction;
		string text = documentAction?.Name ?? string.Empty;
		IArrangement arrangement2 = arrangement ?? documentAction?.ActiveArrangement;
		if (!string.IsNullOrWhiteSpace(arrangement2?.Name))
		{
			text = text + " - [" + arrangement2.Name + "]";
		}
		return text;
	}
}
