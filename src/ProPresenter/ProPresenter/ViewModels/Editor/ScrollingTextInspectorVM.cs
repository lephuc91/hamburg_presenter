using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Editor;
using Pro.Text;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Slide;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Scrollers;
using ProPresenter.UI.ViewModels.Editor;

namespace ProPresenter.ViewModels.Editor;

public class ScrollingTextInspectorVM : NotifyPropertyChangedBase, IScrollingTextInspectorVM
{
	private readonly IScrollingTextInspectorPrompt _prompt;

	private readonly ObservableCollection<ICanvasElement> _selectedElements;

	private bool _ignoreChanges;

	public bool ShouldScrollText
	{
		get
		{
			return TextScroller?.ShouldScrollText ?? false;
		}
		set
		{
			if (TextScroller == null || TextScroller.ShouldScrollText == value)
			{
				return;
			}
			bool removeReveal = false;
			bool removeFill = false;
			if (value)
			{
				if (SelectedElements.Any((ClosedBezierPath e) => e.RevealType != RevealType.None))
				{
					removeReveal = true;
					if (!_prompt.ConfirmRemoveTextReveal())
					{
						return;
					}
				}
				if (SelectedElements.Any((ClosedBezierPath e) => e.Text.Any((Paragraph p) => p.Any(checkTextFillIncompatible))))
				{
					removeFill = true;
					if (!_prompt.ConfirmRemoveTextFill())
					{
						return;
					}
				}
			}
			ScrollingTextShownEvent.Publish(value);
			Execute(delegate(ClosedBezierPath element)
			{
				if (removeReveal)
				{
					element.RevealType = RevealType.None;
				}
				if (removeFill)
				{
					element.Text.IterateRuns(Pro.Text.Range.All, splitRuns: true, delegate(RunBase r)
					{
						if (checkTextFillIncompatible(r))
						{
							r.Settings.Fill = new SolidTextFill();
						}
					});
				}
				element.TextScroller.ShouldScrollText = value;
			}, UndoActionTypes.TextScrollerSetShouldScrollText, autoFinalize: true);
			static bool checkTextFillIncompatible(RunBase run)
			{
				return run.Settings.Fill.TextFillType.IsAnyOf(TextFillType.BackgroundInvert, TextFillType.BackgroundBlur, TextFillType.CutOut, TextFillType.Media);
			}
		}
	}

	public double ScrollRate
	{
		get
		{
			return TextScroller?.ScrollRate ?? 5.0;
		}
		set
		{
			if (TextScroller != null && TextScroller.ScrollRate != value)
			{
				Execute(delegate(ClosedBezierPath t)
				{
					t.TextScroller.ScrollRate = value;
				}, UndoActionTypes.TextScrollerSetScrollRate, autoFinalize: false);
			}
		}
	}

	public bool ShouldRepeat
	{
		get
		{
			return TextScroller?.ShouldRepeat ?? false;
		}
		set
		{
			if (TextScroller != null && TextScroller.ShouldRepeat != value)
			{
				Execute(delegate(ClosedBezierPath t)
				{
					t.TextScroller.ShouldRepeat = value;
				}, UndoActionTypes.TextScrollerSetShouldRepeat, autoFinalize: true);
			}
		}
	}

	public double RepeatDistance
	{
		get
		{
			return TextScroller?.RepeatDistance ?? 0.0;
		}
		set
		{
			if (TextScroller != null && RepeatDistance != value)
			{
				Execute(delegate(ClosedBezierPath t)
				{
					t.TextScroller.RepeatDistance = value;
				}, UndoActionTypes.TextScrollerSetRepeatDistance, autoFinalize: false);
			}
		}
	}

	public ScrollingType ScrollDirection
	{
		get
		{
			return TextScroller?.ScrollDirection ?? ScrollingType.Right;
		}
		set
		{
			if (TextScroller != null && TextScroller.ScrollDirection != value)
			{
				Execute(delegate(ClosedBezierPath t)
				{
					t.TextScroller.ScrollDirection = value;
				}, UndoActionTypes.TextScrollerSetScrollDirection, autoFinalize: true);
			}
		}
	}

	public bool StartsOffScreen
	{
		get
		{
			return TextScroller?.StartsOffScreen ?? false;
		}
		set
		{
			if (TextScroller != null && TextScroller.StartsOffScreen != value)
			{
				Execute(delegate(ClosedBezierPath t)
				{
					t.TextScroller.StartsOffScreen = value;
				}, UndoActionTypes.TextScrollerChangeStartsOffScreen, autoFinalize: true);
			}
		}
	}

	public bool IsLinked
	{
		get
		{
			return TextScroller?.IsLinked ?? false;
		}
		set
		{
			if (TextScroller != null && TextScroller.IsLinked != value)
			{
				Execute(delegate(ClosedBezierPath t)
				{
					t.TextScroller.IsLinked = value;
				}, UndoActionTypes.TextScrollerSetIsLinked, autoFinalize: false);
			}
		}
	}

	public double FadeLeft
	{
		get
		{
			return TextScroller?.FadeLeft ?? 0.0;
		}
		set
		{
			if (TextScroller != null && TextScroller.FadeLeft != value)
			{
				Execute(delegate(ClosedBezierPath t)
				{
					t.TextScroller.FadeLeft = value;
				}, UndoActionTypes.TextScrollerSetFadeLeft, autoFinalize: false);
			}
		}
	}

	public double FadeRight
	{
		get
		{
			return TextScroller?.FadeRight ?? 0.0;
		}
		set
		{
			if (TextScroller != null && TextScroller.FadeRight != value)
			{
				Execute(delegate(ClosedBezierPath t)
				{
					t.TextScroller.FadeRight = value;
				}, UndoActionTypes.TextScrollerSetFadeRight, autoFinalize: false);
			}
		}
	}

	public ICommand EnableStartPositionCommand => new RelayCommand(delegate
	{
		StartsOffScreen = true;
	});

	public ICommand DisableStartPositionCommand => new RelayCommand(delegate
	{
		StartsOffScreen = false;
	});

	private IEnumerable<ClosedBezierPath> SelectedElements => _selectedElements.OfType<ClosedBezierPath>();

	private ClosedBezierPath? FirstElement => SelectedElements.FirstOrDefault();

	private ITextScroller? TextScroller => FirstElement?.TextScroller;

	private UndoStack? UndoStack => TextScroller?.UndoStack;

	public ScrollingTextInspectorVM(ObservableCollection<ICanvasElement> selectedElements, IScrollingTextInspectorPrompt? prompt = null)
	{
		_selectedElements = selectedElements;
		_selectedElements.CollectionChanged += delegate(object? s, NotifyCollectionChangedEventArgs e)
		{
			e.OldItems?.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath elem)
			{
				elem.TextScroller.PropertyChanged -= NotifyPropertyChanges;
			});
			e.NewItems?.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath elem)
			{
				elem.TextScroller.PropertyChanged += NotifyPropertyChanges;
			});
			NotifyPropertyChanges();
		};
		_prompt = prompt ?? new ScrollingTextInspectorPrompt();
	}

	private void NotifyPropertyChanges(object? s, PropertyChangedEventArgs e)
	{
		NotifyPropertyChanges();
	}

	private void NotifyPropertyChanges()
	{
		_ignoreChanges = true;
		OnPropertyChanged("ShouldScrollText");
		OnPropertyChanged("ScrollRate");
		OnPropertyChanged("ShouldRepeat");
		OnPropertyChanged("RepeatDistance");
		OnPropertyChanged("ScrollDirection");
		OnPropertyChanged("StartsOffScreen");
		OnPropertyChanged("IsLinked");
		OnPropertyChanged("FadeLeft");
		OnPropertyChanged("FadeRight");
		_ignoreChanges = false;
	}

	private void Execute(Action<ClosedBezierPath> action, UndoActionTypes undoType, bool autoFinalize)
	{
		if (!_ignoreChanges)
		{
			UndoStack?.BeginCommit(undoType.ToAction());
			SelectedElements.ForEach(action);
			UndoStack?.EndCommit(null, null, autoFinalize);
		}
	}
}
