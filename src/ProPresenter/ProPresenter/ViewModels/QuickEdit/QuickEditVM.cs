using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.Common.Nullability;
using Pro.UI.Components;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels.QuickEdit;

public class QuickEditVM : LinkedNotifyPropertyChangedBase, IQuickEditVM, INotifyPropertyChanged
{
	private const double SizeScalar = 1.5;

	private readonly IQuickEditPrompt _prompt;

	private CustomPresentation? _presentation;

	private ArrangedCue? _cue;

	public Vector2<double> TargetContainerSize { get; private set; }

	public Vector2<double> RenderSize { get; private set; }

	public Vector2<double> ScaleRatio => Slide?.Size.ComponentwiseQuotient(TargetContainerSize) ?? Vector2<double>.One;

	public Color BackgroundColor
	{
		get
		{
			return slideBackground() ?? presentationBackground() ?? Colors.Black;
			Color? presentationBackground()
			{
				if (_cue?.Source.ParentPresentation?.UseBackgroundColor != true)
				{
					return null;
				}
				return _cue.Source.ParentPresentation.BackgroundColor;
			}
			Color? slideBackground()
			{
				CustomSlide? slide = Slide;
				if (slide == null || !slide.UseBackgroundColor)
				{
					return null;
				}
				return Slide.BackgroundColor;
			}
		}
	}

	public IEnumerable<ClosedBezierPath> TextElements => GetTextElements(Slide);

	public ICommand<(ClosedBezierPath, int)> BreakToNewSlideCommand => new RelayCommand<(ClosedBezierPath, int)>(OnBreakToNewSlideCommand, ((ClosedBezierPath, int) p) => _presentation != null && _cue != null);

	internal CustomSlide? Slide => _cue?.Source.SlideAction?.Slide as CustomSlide;

	internal SlideCue? SlideCue => _cue?.Source;

	public QuickEditVM(IQuickEditPrompt? prompt = null)
	{
		_prompt = prompt ?? new QuickEditPrompt(this);
	}

	public bool CanEdit(CustomSlide? slide)
	{
		if (slide != null)
		{
			return GetTextElements(slide).Any();
		}
		return false;
	}

	public void Edit(ArrangedCue? cue, Vector2<double> position, Vector2<double> containerSize, Vector2<double> renderSize)
	{
		if (cue != null)
		{
			_presentation = cue.Source.ParentPresentation as CustomPresentation;
			_cue = cue;
			TargetContainerSize = containerSize * 1.5;
			RenderSize = renderSize;
			_prompt.Show(position);
		}
	}

	public void HideQuickEditWindow()
	{
		_prompt.Hide();
	}

	private void OnBreakToNewSlideCommand((ClosedBezierPath path, int caretIndex) param)
	{
		(_cue?.Source).ThrowWhenNull("_cue?.Source");
		_presentation?.BreakSlideDocument(_cue.Source, param.caretIndex, param.path);
	}

	private IEnumerable<ClosedBezierPath> GetTextElements(CustomSlide? slide)
	{
		return (from e in slide?.Elements.OfType<ClosedBezierPath>()
			where e.AdditionalInfo.HasFlag(AdditionalInfo.Text) || (e.Text?.HasText ?? false)
			select e) ?? Enumerable.Empty<ClosedBezierPath>();
	}
}
