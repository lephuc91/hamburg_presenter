using System;
using System.Collections.Generic;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.DO.Label;
using ProPresenter.DO.Cues;

namespace ProPresenter.DO.Presentation;

public class SlidesCopyData : ICloneable<SlidesCopyData>
{
	public GroupLabel? Label { get; }

	public IEnumerable<SlideCue> Slides { get; }

	public bool CreateGroup { get; }

	public Guid? ArrangementID { get; }

	public string ArrangementName { get; }

	public ICopyPresentationIdentifier? SourceCopyIdentifier { get; }

	public SlidesCopyData(GroupLabel? label, IEnumerable<SlideCue> slides, bool createGroup, Guid? arrangementID = null, string? arrangementName = null, ICopyPresentationIdentifier? sourceCopyIdentifier = null)
	{
		Label = label;
		Slides = slides;
		CreateGroup = createGroup;
		ArrangementID = arrangementID;
		ArrangementName = arrangementName ?? string.Empty;
		SourceCopyIdentifier = sourceCopyIdentifier;
	}

	public SlidesCopyData Clone()
	{
		return new SlidesCopyData(Label?.Clone(), Slides.CloneItems(), CreateGroup, ArrangementID, ArrangementName, SourceCopyIdentifier);
	}
}
