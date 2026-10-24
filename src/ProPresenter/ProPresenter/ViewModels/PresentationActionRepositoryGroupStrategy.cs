using System;
using System.Collections.Generic;
using System.Linq;
using Pro.DO.Label;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Presentation;
using ProPresenter.ViewModels.Actions;

namespace ProPresenter.ViewModels;

public class PresentationActionRepositoryGroupStrategy : IActionRepositoryGroupStrategy
{
	private readonly IEnumerable<GroupLabel> _groupLabels;

	public PresentationActionRepositoryGroupStrategy(IEnumerable<GroupLabel> groupLabels)
	{
		_groupLabels = groupLabels;
	}

	public void AssignGroup(IActionRepoContainer container, string groupName, IEnumerable<IActionRepository> repos)
	{
		if (!string.IsNullOrEmpty(groupName) && container is IDocumentCue documentCue && documentCue.DocumentAction?.Presentation is CustomPresentation customPresentation)
		{
			customPresentation.AssignGroupLabel(GetGroupLabel(_groupLabels, groupName), customPresentation.DefaultArrangement.ArrangedCues.Where((ArrangedCue a) => repos.OfType<SlideCue>().Contains(a.Source)));
		}
	}

	private static GroupLabel GetGroupLabel(IEnumerable<GroupLabel> groupLabels, string groupName)
	{
		return groupLabels?.FirstOrDefault((GroupLabel g) => g.Text.Equals(groupName, StringComparison.OrdinalIgnoreCase)) ?? new GroupLabel(groupName);
	}
}
