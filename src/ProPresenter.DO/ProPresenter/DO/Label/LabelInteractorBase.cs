using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.DO.Label;

namespace ProPresenter.DO.Label;

public abstract class LabelInteractorBase : ILabelInteractor
{
	private readonly ILabelContext _context;

	public IEnumerable<ILabel>? Labels { get; protected set; }

	public bool MultipleTargets => _context.Targets?.NonNull().Distinct().Any((ILabel l) => l.Text != Target?.Text) ?? false;

	public bool MultipleColors => _context.Targets?.NonNull().Distinct().Any(delegate(ILabel l)
	{
		Color? color = l.Color;
		Color? color2 = Target?.Color;
		if (color.HasValue != color2.HasValue)
		{
			return true;
		}
		return color.HasValue && color.GetValueOrDefault() != color2.GetValueOrDefault();
	}) ?? false;

	public ILabel? Target => _context.Target;

	public abstract string SaveLabel { get; }

	public LabelInteractorBase(ILabelContext context)
	{
		_context = context;
	}

	public abstract void ApplyChange(ILabel preset);

	public abstract void ApplyChange(string name, Color color);

	public abstract void SaveToPreferences(string name, Color color);

	protected bool CanApply(ILabel? label)
	{
		ILabel label2 = Labels?.FirstOrDefault((ILabel l) => l.Text == label?.Text);
		if (label != null)
		{
			IEnumerable<ILabel>? labels = Labels;
			if ((labels == null || !labels.Contains<ILabel>(label)) && (MultipleTargets || label2 != null))
			{
				if (label2 == null)
				{
					return !string.IsNullOrEmpty(label.Text);
				}
				return false;
			}
		}
		return true;
	}
}
