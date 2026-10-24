using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.DO.Analytics;
using Pro.DO.Label;
using Pro.Localization;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Label;

public class SlideLabelInteractor : LabelInteractorBase
{
	private readonly ILabelPrompt _prompt;

	private readonly ISlideLabelContext _context;

	public override string SaveLabel { get; } = LocalizedStrings.Get("PRESENTATION_LABEL_DIALOG_SAVE_LABEL_label");

	public SlideLabelInteractor(ISlideLabelContext context, IEnumerable<ILabel> presets, ILabelPrompt prompt)
		: base(context)
	{
		_context = context;
		base.Labels = presets;
		_prompt = prompt;
	}

	public override void ApplyChange(string name, Color color)
	{
		ApplyChange((string.IsNullOrEmpty(name) && !base.MultipleTargets) ? null : new ActionLabel(name, color));
	}

	public override void ApplyChange(ILabel? label)
	{
		IEnumerable<SlideCue> cues = _context.Cues.Distinct();
		IPresentation presentation = cues.FirstOrDefault()?.ParentPresentation;
		if (presentation == null)
		{
			return;
		}
		if (CanApply(label))
		{
			presentation.AssignSlideLabel(label as ActionLabel, cues);
			publish();
		}
		else
		{
			if (!_prompt.ConfirmOverwrite(label?.Text))
			{
				return;
			}
			base.Labels?.Where((ILabel l) => cues.Select((SlideCue c) => c.SlideAction?.Label?.Text).Contains(l.Text)).ForEach(delegate(ILabel l)
			{
				l.Color = label?.Color;
			});
			presentation.AssignSlideColor(label?.Color ?? Colors.Transparent, cues);
			publish();
		}
		void publish()
		{
			EventPublisher.Publish(_context.ToChangedEvent());
		}
	}

	public override void SaveToPreferences(string name, Color color)
	{
		DataVault.SlideLabels.Add(new ActionLabel(name, color));
	}
}
