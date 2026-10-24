using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Strings;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Actions.PCO;

public static class PCOHelper
{
	private const string Format = "{0} 1";

	public static bool SequenceFullyMatchesArrangement(this IArrangement arrangement, string[] sequence)
	{
		IEnumerable<string> source = arrangement.Select((CueGroup a) => a.Label?.Text);
		for (int i = 0; i < sequence.Length; i++)
		{
			string text = source.ElementAtOrDefault(i);
			string text2 = sequence.ElementAtOrDefault(i);
			if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(text2) || !IsGroupNameMatch(text, text2))
			{
				return false;
			}
		}
		return true;
	}

	public static IArrangement? BuildArrangement(this IPresentation presentation, string[] sequence, string arrangementName)
	{
		CueGroup[] array = sequence.Select((string s) => presentation.ArrangementGroups.FirstOrDefault((CueGroup g) => IsGroupNameMatch(g.Label?.Text ?? string.Empty, s))).NotNull().ToArray();
		if (array.Length == 0)
		{
			return null;
		}
		string[] resolvedNames = array.Select((CueGroup g) => g.Label?.Text).ToArray();
		IArrangement arrangement = presentation.Arrangements.FirstOrDefault((IArrangement a) => a.Count == resolvedNames.Length && a.Select((CueGroup g) => g.Label?.Text).SequenceEqual(resolvedNames));
		if (arrangement != null)
		{
			return arrangement;
		}
		IArrangement arrangement2 = presentation.Arrangements.AddArrangement(arrangementName.DuplicateName(presentation.Arrangements, (IArrangement a) => a.Name));
		arrangement2.Clear();
		array.ForEach(arrangement2.AddArrangementGroup);
		return arrangement2;
	}

	private static bool IsGroupNameMatch(string? groupName, string sequenceName)
	{
		if (!(groupName == sequenceName))
		{
			return groupName == $"{sequenceName} 1";
		}
		return true;
	}
}
