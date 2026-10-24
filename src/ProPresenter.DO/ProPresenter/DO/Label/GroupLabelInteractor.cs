using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.DO.Label;
using Pro.Localization;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Label;

public class GroupLabelInteractor : LabelInteractorBase
{
	private readonly ILabelPrompt _prompt;

	private readonly GroupLabelContext _context;

	public override string SaveLabel { get; } = LocalizedStrings.Get("PRESENTATION_LABEL_DIALOG_SAVE_GROUP_label");

	public GroupLabelInteractor(GroupLabelContext context, IEnumerable<ILabel>? presets = null, ILabelPrompt? prompt = null)
		: base(context)
	{
		_context = context;
		base.Labels = presets ?? DataVault.GroupLabels;
		_prompt = prompt ?? new GroupLabelPrompt();
	}

	public override void ApplyChange(string name, Color color)
	{
		ApplyChange(new GroupLabel(name, color));
	}

	public override void ApplyChange(ILabel label)
	{
		IReadOnlyCollection<ArrangedCue> cues = _context.Cues;
		IPresentation presentation = cues?.FirstOrDefault()?.Source.ParentPresentation;
		if (presentation == null)
		{
			return;
		}
		if (CanApply(label))
		{
			presentation.AssignGroupLabel(label as GroupLabel, cues);
		}
		else
		{
			if (!_prompt.ConfirmOverwrite(label.Text))
			{
				return;
			}
			base.Labels?.Where((ILabel l) => cues?.Select((ArrangedCue c) => c.GroupLabel?.Text).Contains(l.Text) ?? false).ForEach(delegate(ILabel l)
			{
				l.Color = label.Color;
			});
			presentation.AssignGroupColor(label.Color ?? Colors.Transparent, cues);
		}
	}

	public override void SaveToPreferences(string name, Color color)
	{
		DataVault.GroupLabels?.Add(new GroupLabel(name, color));
	}
}
