using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Text;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.DO.Presentation;

public static class PresentationExtensions
{
	public static IEnumerable<ClosedBezierPath> GetAllTextElements(this IPresentation presentation)
	{
		return (from cue in presentation.ArrangementGroups.SelectMany((CueGroup @group) => @group.Cues)
			where cue.SlideAction?.Slide is CustomSlide
			select cue).SelectMany((SlideCue cue) => ((CustomSlide)cue.SlideAction.Slide).Elements).OfType<ClosedBezierPath>();
	}

	public static IEnumerable<RunSettings> GetAllRunSettings(this ClosedBezierPath textElement)
	{
		object obj;
		if (textElement == null)
		{
			obj = null;
		}
		else
		{
			TextDocument text = textElement.Text;
			obj = (((object)text != null) ? (from run in text.GetAllRuns()
				where run.Settings != null
				select run.Settings) : null);
		}
		if (obj == null)
		{
			obj = Array.Empty<RunSettings>();
		}
		return (IEnumerable<RunSettings>)obj;
	}

	private static IEnumerable<RunBase> GetAllRuns(this TextDocument textDocument)
	{
		List<RunBase> runs = new List<RunBase>();
		textDocument.IterateAllRuns(delegate(Pro.Text.Range range, RunBase run)
		{
			runs.Add(run);
		});
		return runs;
	}
}
