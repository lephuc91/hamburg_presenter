using System;

namespace ProPresenter.DO.Themes;

public class RecentlyAppliedTemplateSlideModel
{
	public Guid TemplateSlideId { get; }

	public DateTime AppliedDateTime { get; }

	public RecentlyAppliedTemplateSlideModel(Guid templateSlideID, DateTime appliedDateTime)
	{
		TemplateSlideId = templateSlideID;
		AppliedDateTime = appliedDateTime;
	}
}
