using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Nullability;
using Pro.Text;
using Pro.Text.Fills;
using Pro.Text.Reversibility;
using ProPresenter.DO.Media;

namespace ProPresenter.UI.SlideEditor.Inspectors;

internal static class TextFillUtility
{
	public static void ChangeFill<T>(Func<IReadOnlyList<TextDocument>> activeDocuments, T newFill, UndoActionTypes undoActionType, ApplyRunSettingsDelegate? applyRunSettingsProvider, ApplyParagraphSettingsDelegate? applyParagraphSettingsProvider, Action<T> setCurrentValueCallback) where T : TextFillBase
	{
		if (applyRunSettingsProvider != null)
		{
			applyParagraphSettingsProvider?.Invoke(delegate(ParagraphSettings p, RunSettings r, RangeSelectionType t)
			{
				if (t == RangeSelectionType.Document && p.BulletColor == r.Fill.PrimaryColor)
				{
					p.BulletColor = newFill.PrimaryColor;
				}
			}, undoActionType, autoFinalize: false);
			Dictionary<string, int> mediaIdsAndCounts = new Dictionary<string, int>();
			IReadOnlyList<TextDocument> source = activeDocuments();
			TextDocument firstDocument = source.FirstOrDefault();
			source.ForEach(delegate(TextDocument x)
			{
				x.IterateAllRuns(delegate(Pro.Text.Range range, RunBase run)
				{
					if (run.Settings.Fill is MediaTextFill { Media: ITrackedMedia { ID: var iD } })
					{
						string key = iD.ToString();
						if (mediaIdsAndCounts.ContainsKey(key))
						{
							mediaIdsAndCounts[key]++;
						}
						else
						{
							mediaIdsAndCounts[key] = 1;
						}
					}
				});
			});
			Dictionary<string, ITrackedMedia> possibleCandidatesToRemove = new Dictionary<string, ITrackedMedia>();
			Dictionary<TextDocument, MediaTextFill> clonedFills = new Dictionary<TextDocument, MediaTextFill>();
			applyRunSettingsProvider(delegate(RunSettings settings, RangeSelectionType type, TextDocument? document)
			{
				document.ThrowWhenNull("document");
				if (settings.Fill is MediaTextFill { Media: ITrackedMedia { ID: var iD2 } media2 })
				{
					string key2 = iD2.ToString();
					mediaIdsAndCounts[key2]--;
					if (!possibleCandidatesToRemove.ContainsKey(key2))
					{
						possibleCandidatesToRemove.Add(key2, media2);
					}
					if (document != firstDocument)
					{
						if (!clonedFills.ContainsKey(document))
						{
							MediaTextFill mediaTextFill3 = (MediaTextFill)newFill.Clone();
							clonedFills.Add(document, mediaTextFill3);
							settings.Fill = mediaTextFill3;
							(mediaTextFill3.Media as ITrackedMedia)?.AddToMediaServiceAndApplyTransform(userInitiated: true);
						}
						else
						{
							settings.Fill = clonedFills[document];
						}
					}
					else
					{
						settings.Fill = newFill;
					}
				}
				else
				{
					settings.Fill = newFill;
				}
			}, undoActionType, autoFinalize: true);
			(from x in mediaIdsAndCounts
				where x.Value == 0
				select possibleCandidatesToRemove[x.Key]).ToArray().ForEach(delegate(ITrackedMedia x)
			{
				x.RemoveFromMediaService(deleteAssets: false);
			});
		}
		else
		{
			setCurrentValueCallback?.Invoke(newFill);
		}
	}
}
