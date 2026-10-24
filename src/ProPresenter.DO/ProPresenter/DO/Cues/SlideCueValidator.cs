using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.DO.Triggering;
using Pro.Localization;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.DO.Cues;

public class SlideCueValidator : LinkedNotifyPropertyChangedBase
{
	private readonly SlideCue _slideCue;

	private readonly Action<bool, string> _callback;

	private readonly IActionValidator _actionValidator;

	public SlideCueValidator(SlideCue slideCue, Action<bool, string> callback, IActionValidator? actionValidator = null)
	{
		_slideCue = slideCue;
		_callback = callback;
		_actionValidator = actionValidator ?? new ActionValidator();
		LinkAction("IsValid", Validate);
		LinkAction("IsTextOverflowing", Validate);
		_slideCue.Actions.CollectionChanged += Actions_CollectionChanged;
		SetupActions(_slideCue.Actions);
		if (_slideCue.SlideAction?.Slide is CustomSlide customSlide)
		{
			customSlide.Elements.ForEach(delegate(SlideElementBase e)
			{
				e.PropertyChanged += base.RaiseLinkedValues;
			});
			customSlide.Elements.CollectionChanged += Elements_CollectionChanged;
		}
		Validate();
	}

	private void Actions_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		TeardownActions(e.OldItems?.OfType<ActionBase>() ?? Array.Empty<ActionBase>());
		SetupActions(e.NewItems?.OfType<ActionBase>() ?? Array.Empty<ActionBase>());
		Validate();
	}

	private void SetupActions(IEnumerable<IAction> actions)
	{
		actions.ForEach(delegate(IAction a)
		{
			a.PropertyChanged += base.RaiseLinkedValues;
		});
	}

	private void TeardownActions(IEnumerable<IAction> actions)
	{
		actions.ForEach(delegate(IAction a)
		{
			a.PropertyChanged -= base.RaiseLinkedValues;
		});
	}

	private void Elements_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath e)
		{
			e.PropertyChanged -= base.RaiseLinkedValues;
		});
		e.NewItems?.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath e)
		{
			e.PropertyChanged += base.RaiseLinkedValues;
		});
	}

	private void Validate()
	{
		string warningMessage;
		bool arg = _actionValidator.Validate(_slideCue.Actions, out warningMessage);
		if (_slideCue.SlideAction?.Slide is CustomSlide customSlide && customSlide.Elements.AnyOf((ClosedBezierPath e) => e.IsTextOverflowing))
		{
			arg = false;
			string newLine = Environment.NewLine;
			global::_003C_003Ey__InlineArray2<string> buffer = default(global::_003C_003Ey__InlineArray2<string>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<string>, string>(ref buffer, 0) = warningMessage;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<string>, string>(ref buffer, 1) = LocalizedStrings.Get("PRESENTATION_SLIDE_ACTION_VALIDATION_TEXT_ELEMENT_OVERFILLED_ERROR_tooltip");
			warningMessage = string.Join(newLine, global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray2<string>, string>(in buffer, 2)).Trim();
		}
		_callback(arg, warningMessage);
	}
}
