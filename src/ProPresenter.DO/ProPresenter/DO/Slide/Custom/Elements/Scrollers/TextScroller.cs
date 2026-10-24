using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Custom.Elements.Scrollers;

public class TextScroller : NotifyPropertyChangedBase, ITextScroller, INotifyPropertyChanged, ICloneable<ITextScroller>, IRenderEquatable<ITextScroller>, IRenderHashable
{
	private const double Minimum = 0.0;

	private const double Maximum = 1.0;

	private bool _shouldScrollText;

	private double _scrollRate = 0.5;

	private bool _shouldRepeat = true;

	private Vector2<double> _maxSize = Vector2<double>.One;

	private double _repeatDistance = 100.0;

	private ScrollingType _scrollDirection;

	private bool _startsOffScreen;

	private double _fadeLeft;

	private double _fadeRight;

	private bool _isLinked = true;

	private bool _deserializationInProgress;

	public bool IsLinked
	{
		get
		{
			return _isLinked;
		}
		set
		{
			SetValue("IsLinked", ref _isLinked, value, delegate(bool o, bool n)
			{
				ValueChanged(o, n, UndoActionTypes.TextScrollerSetShouldScrollText, "IsLinked", autoFinalize: true);
				if (n && !_deserializationInProgress)
				{
					if (_fadeLeft < 0.5)
					{
						FadeLeft = _fadeLeft.Clamp(0.0, 0.5);
						FadeRight = _fadeLeft;
					}
					else
					{
						FadeRight = 1.0 - _fadeRight;
					}
				}
			});
		}
	}

	public bool ShouldScrollText
	{
		get
		{
			return _shouldScrollText;
		}
		set
		{
			SetValue("ShouldScrollText", ref _shouldScrollText, value, delegate(bool o, bool n)
			{
				ValueChanged(o, n, UndoActionTypes.TextScrollerSetShouldScrollText, "ShouldScrollText", autoFinalize: true);
			});
		}
	}

	public double ScrollRate
	{
		get
		{
			return _scrollRate;
		}
		set
		{
			SetValue("ScrollRate", ref _scrollRate, value, delegate(double o, double n)
			{
				ValueChanged(o, n, UndoActionTypes.TextScrollerSetScrollRate, "ScrollRate", autoFinalize: false);
			});
		}
	}

	public bool ShouldRepeat
	{
		get
		{
			return _shouldRepeat;
		}
		set
		{
			SetValue("ShouldRepeat", ref _shouldRepeat, value, delegate(bool o, bool n)
			{
				ValueChanged(o, n, UndoActionTypes.TextScrollerSetShouldRepeat, "ShouldRepeat", autoFinalize: true);
			});
		}
	}

	public Vector2<double> MaxSize => _maxSize;

	public double RepeatDistance
	{
		get
		{
			return _repeatDistance;
		}
		set
		{
			SetValue("RepeatDistance", ref _repeatDistance, value, delegate(double o, double n)
			{
				ValueChanged(o, n, UndoActionTypes.TextScrollerSetRepeatDistance, "RepeatDistance", autoFinalize: false);
			});
		}
	}

	public ScrollingType ScrollDirection
	{
		get
		{
			return _scrollDirection;
		}
		set
		{
			SetValue("ScrollDirection", ref _scrollDirection, value, delegate(ScrollingType o, ScrollingType n)
			{
				ValueChanged(o, n, UndoActionTypes.TextScrollerSetScrollDirection, "ScrollDirection", autoFinalize: true);
			});
		}
	}

	public bool StartsOffScreen
	{
		get
		{
			return _startsOffScreen;
		}
		set
		{
			SetValue("StartsOffScreen", ref _startsOffScreen, value, delegate(bool o, bool n)
			{
				ValueChanged(o, n, UndoActionTypes.TextScrollerChangeStartsOffScreen, "StartsOffScreen", autoFinalize: true);
			});
		}
	}

	public double FadeLeft
	{
		get
		{
			return _fadeLeft;
		}
		set
		{
			SetValue("FadeLeft", ref _fadeLeft, value.Clamp(0.0, (IsLinked && !_deserializationInProgress) ? 0.5 : 1.0), delegate(double o, double n)
			{
				ValueChanged(o, n, UndoActionTypes.TextScrollerSetFadeLeft, "FadeLeft", autoFinalize: false);
				if (IsLinked && !_deserializationInProgress)
				{
					FadeRight = n;
				}
			});
		}
	}

	public double FadeRight
	{
		get
		{
			return _fadeRight;
		}
		set
		{
			SetValue("FadeRight", ref _fadeRight, value.Clamp(0.0, (IsLinked && !_deserializationInProgress) ? 0.5 : 1.0), delegate(double o, double n)
			{
				ValueChanged(o, n, UndoActionTypes.TextScrollerSetFadeRight, "FadeRight", autoFinalize: false);
				if (IsLinked && !_deserializationInProgress)
				{
					FadeLeft = n;
				}
			});
		}
	}

	public UndoStack? UndoStack { get; set; }

	public event System.Action? DataModified;

	public static ObjectBinder<TextScroller, ISlide.Types.IElement.Types.ITextScroller> CreateBinder(TextScroller? left, ISlide.Types.IElement.Types.ITextScroller right)
	{
		ObjectBinder<TextScroller, ISlide.Types.IElement.Types.ITextScroller> objectBinder = new ObjectBinder<TextScroller, ISlide.Types.IElement.Types.ITextScroller>(left, right);
		objectBinder.Bind((TextScroller l) => l.WhenPropertyChanges("ShouldScrollText"), (ISlide.Types.IElement.Types.ITextScroller r) => r.ShouldScroll.WhenValueChanges, delegate(TextScroller l, ISlide.Types.IElement.Types.ITextScroller r)
		{
			r.ShouldScroll.Set(l.ShouldScrollText);
		}, delegate(ISlide.Types.IElement.Types.ITextScroller r, TextScroller l)
		{
			l.SetValue("ShouldScrollText", ref l._shouldScrollText, r.ShouldScroll.Value, (Action<bool, bool>?)delegate
			{
				l.OnDataModified();
			}, (Predicate<bool>?)null, referenceComparison: false);
		}).Bind((TextScroller l) => l.WhenPropertyChanges("ScrollRate"), (ISlide.Types.IElement.Types.ITextScroller r) => r.ScrollRate.WhenValueChanges, delegate(TextScroller l, ISlide.Types.IElement.Types.ITextScroller r)
		{
			r.ScrollRate.Set(l.ScrollRate);
		}, delegate(ISlide.Types.IElement.Types.ITextScroller r, TextScroller l)
		{
			l.SetValue("ScrollRate", ref l._scrollRate, r.ScrollRate.Value, (Action<double, double>?)delegate
			{
				l.OnDataModified();
			}, (Predicate<double>?)null, referenceComparison: false);
		}).Bind((TextScroller l) => l.WhenPropertyChanges("ShouldRepeat"), (ISlide.Types.IElement.Types.ITextScroller r) => r.ShouldRepeat.WhenValueChanges, delegate(TextScroller l, ISlide.Types.IElement.Types.ITextScroller r)
		{
			r.ShouldRepeat.Set(l.ShouldRepeat);
		}, delegate(ISlide.Types.IElement.Types.ITextScroller r, TextScroller l)
		{
			l.SetValue("ShouldRepeat", ref l._shouldRepeat, r.ShouldRepeat.Value, (Action<bool, bool>?)delegate
			{
				l.OnDataModified();
			}, (Predicate<bool>?)null, referenceComparison: false);
		})
			.Bind((TextScroller l) => l.WhenPropertyChanges("RepeatDistance"), (ISlide.Types.IElement.Types.ITextScroller r) => r.RepeatDistance.WhenValueChanges, delegate(TextScroller l, ISlide.Types.IElement.Types.ITextScroller r)
			{
				r.RepeatDistance.Set(l.RepeatDistance);
			}, delegate(ISlide.Types.IElement.Types.ITextScroller r, TextScroller l)
			{
				l.SetValue("RepeatDistance", ref l._repeatDistance, r.RepeatDistance.Value, (Action<double, double>?)delegate
				{
					l.OnDataModified();
				}, (Predicate<double>?)null, referenceComparison: false);
			})
			.Bind((TextScroller l) => l.WhenPropertyChanges("ScrollDirection"), (ISlide.Types.IElement.Types.ITextScroller r) => r.ScrollingDirection.WhenValueChanges, delegate(TextScroller l, ISlide.Types.IElement.Types.ITextScroller r)
			{
				r.ScrollingDirection.Set(l.ScrollDirection.ToEntityDirection());
			}, delegate(ISlide.Types.IElement.Types.ITextScroller r, TextScroller l)
			{
				l.SetValue("ScrollDirection", ref l._scrollDirection, r.ScrollingDirection.Value.ToScrollingType(), (Action<ScrollingType, ScrollingType>?)delegate
				{
					l.OnDataModified();
				}, (Predicate<ScrollingType>?)null, referenceComparison: false);
			})
			.Bind((TextScroller l) => l.WhenPropertyChanges("StartsOffScreen"), (ISlide.Types.IElement.Types.ITextScroller r) => r.StartsOffScreen.WhenValueChanges, delegate(TextScroller l, ISlide.Types.IElement.Types.ITextScroller r)
			{
				r.StartsOffScreen.Set(l.StartsOffScreen);
			}, delegate(ISlide.Types.IElement.Types.ITextScroller r, TextScroller l)
			{
				l.SetValue("StartsOffScreen", ref l._startsOffScreen, r.StartsOffScreen.Value, (Action<bool, bool>?)delegate
				{
					l.OnDataModified();
				}, (Predicate<bool>?)null, referenceComparison: false);
			})
			.Bind((TextScroller l) => l.WhenPropertyChanges("FadeLeft"), (ISlide.Types.IElement.Types.ITextScroller r) => r.FadeLeft.WhenValueChanges, delegate(TextScroller l, ISlide.Types.IElement.Types.ITextScroller r)
			{
				r.FadeLeft.Set(l.FadeLeft);
			}, delegate(ISlide.Types.IElement.Types.ITextScroller r, TextScroller l)
			{
				double value = r.FadeLeft.Value.Clamp(0.0, l.IsLinked ? 0.5 : 1.0);
				l.SetValue("FadeLeft", ref l._fadeLeft, value, (Action<double, double>?)delegate
				{
					l.OnDataModified();
				}, (Predicate<double>?)null, referenceComparison: false);
			})
			.Bind((TextScroller l) => l.WhenPropertyChanges("FadeRight"), (ISlide.Types.IElement.Types.ITextScroller r) => r.FadeRight.WhenValueChanges, delegate(TextScroller l, ISlide.Types.IElement.Types.ITextScroller r)
			{
				r.FadeRight.Set(l.FadeRight);
			}, delegate(ISlide.Types.IElement.Types.ITextScroller r, TextScroller l)
			{
				double value2 = r.FadeRight.Value.Clamp(0.0, l.IsLinked ? 0.5 : 1.0);
				l.SetValue("FadeRight", ref l._fadeRight, value2, (Action<double, double>?)delegate
				{
					l.OnDataModified();
				}, (Predicate<double>?)null, referenceComparison: false);
			});
		return objectBinder;
	}

	public bool RenderEquals([NotNullWhen(true)] ITextScroller? other)
	{
		if (other is TextScroller textScroller && _shouldScrollText == textScroller._shouldScrollText && _scrollRate == textScroller._scrollRate && _shouldRepeat == textScroller._shouldRepeat && _repeatDistance == textScroller._repeatDistance && _scrollDirection == textScroller._scrollDirection && _startsOffScreen == textScroller._startsOffScreen && _fadeLeft == textScroller._fadeLeft)
		{
			return _fadeRight == textScroller._fadeRight;
		}
		return false;
	}

	public int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(_shouldScrollText, _scrollRate, _shouldRepeat, _repeatDistance, _scrollDirection, _startsOffScreen, _fadeLeft, _fadeRight);
	}

	public Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextScroller Serialize()
	{
		return new Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextScroller
		{
			ShouldScroll = ShouldScrollText,
			ShouldRepeat = ShouldRepeat,
			ScrollRate = ScrollRate,
			RepeatDistance = ((GetMaxDimension() == 0.0) ? 0.0 : (RepeatDistance / GetMaxDimension())).Clamp(0.0, 1.0),
			ScrollingDirection = ScrollDirection.ToProtoDirection(),
			StartsOffScreen = StartsOffScreen,
			FadeLeft = FadeLeft,
			FadeRight = FadeRight
		};
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextScroller? protoTextScroller)
	{
		if (protoTextScroller != null)
		{
			_deserializationInProgress = true;
			ShouldScrollText = protoTextScroller.ShouldScroll;
			ShouldRepeat = protoTextScroller.ShouldRepeat;
			ScrollRate = protoTextScroller.ScrollRate;
			ScrollDirection = protoTextScroller.ScrollingDirection.ToScrollingType();
			RepeatDistance = protoTextScroller.RepeatDistance.Clamp(0.0, 1.0) * GetMaxDimension();
			StartsOffScreen = protoTextScroller.StartsOffScreen;
			FadeLeft = protoTextScroller.FadeLeft;
			FadeRight = protoTextScroller.FadeRight;
			IsLinked = Math.Abs(protoTextScroller.FadeLeft - protoTextScroller.FadeRight) < 0.0002;
			_deserializationInProgress = false;
		}
	}

	public ITextScroller Clone()
	{
		return new TextScroller
		{
			_shouldScrollText = _shouldScrollText,
			_scrollRate = _scrollRate,
			_shouldRepeat = _shouldRepeat,
			_maxSize = _maxSize,
			_repeatDistance = _repeatDistance,
			_scrollDirection = _scrollDirection,
			_startsOffScreen = _startsOffScreen,
			_fadeLeft = _fadeLeft,
			_fadeRight = _fadeRight
		};
	}

	private double GetMaxDimension()
	{
		return GetMaxDimension(_maxSize);
	}

	private double GetMaxDimension(Vector2<double> size)
	{
		if (!ScrollDirection.IsVertical())
		{
			return size.X;
		}
		return size.Y;
	}

	private void ValueChanged(object o, object n, UndoActionTypes undoAction, string name, bool autoFinalize)
	{
		UndoStack?.Commit(undoAction.ToAction(), this, name, o, n, null, null, autoFinalize);
		OnDataModified();
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public void UpdateMaxSize(Vector2<double> value, bool applySideEffects = true)
	{
		SetValue("MaxSize", ref _maxSize, value, delegate(Vector2<double> _, Vector2<double> n)
		{
			if (applySideEffects)
			{
				RepeatDistance = RepeatDistance.Clamp(0.0, GetMaxDimension(n));
			}
		});
	}
}
