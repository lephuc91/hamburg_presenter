using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using Pro.Common.Animation;

namespace Pro.UI.Controls.Images;

public partial class AnimatedImageView : UserControl, IComponentConnector
{
	private Storyboard? _storyboard;

	public static readonly DependencyProperty AnimationSourceProperty = DependencyProperty.Register("AnimationSource", typeof(IReadOnlyList<IAnimationFrame>), typeof(AnimatedImageView), new PropertyMetadata((object)Array.Empty<IAnimationFrame>())
	{
		CoerceValueCallback = new CoerceValueCallback(AnimatedImage_CoerceValueCallback),
		PropertyChangedCallback = new PropertyChangedCallback(AnimatedImage_PropertyChangedCallback)
	});

	public static readonly DependencyProperty AutoStartProperty = DependencyProperty.Register("AutoStart", typeof(bool), typeof(AnimatedImageView), new PropertyMetadata((object)true));

	public IReadOnlyList<IAnimationFrame> AnimationSource
	{
		get
		{
			return (IReadOnlyList<IAnimationFrame>)((DependencyObject)this).GetValue(AnimationSourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AnimationSourceProperty, (object)value);
		}
	}

	public bool AutoStart
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AutoStartProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoStartProperty, (object)value);
		}
	}

	private static object AnimatedImage_CoerceValueCallback(DependencyObject d, object baseValue)
	{
		if (baseValue is IReadOnlyList<IAnimationFrame> result)
		{
			return result;
		}
		return Array.Empty<IAnimationFrame>();
	}

	private static void AnimatedImage_PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (!(d is AnimatedImageView animatedImageView))
		{
			return;
		}
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue is IReadOnlyList<IAnimationFrame>)
		{
			animatedImageView.CreateAnimation();
			if (animatedImageView.AutoStart)
			{
				animatedImageView.Animate();
			}
		}
		else
		{
			animatedImageView.ClearView();
		}
	}

	public AnimatedImageView()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		InitializeComponent();
		base.IsVisibleChanged += new DependencyPropertyChangedEventHandler(VisibilityChanged);
	}

	public void CreateAnimation()
	{
		if (AnimationSource.Count <= 0)
		{
			return;
		}
		_storyboard = new Storyboard();
		TimeSpan zero = TimeSpan.Zero;
		ObjectAnimationUsingKeyFrames objectAnimationUsingKeyFrames = new ObjectAnimationUsingKeyFrames();
		foreach (IAnimationFrame item in AnimationSource)
		{
			DiscreteObjectKeyFrame keyFrame = new DiscreteObjectKeyFrame
			{
				Value = item.Image,
				KeyTime = KeyTime.FromTimeSpan(zero)
			};
			objectAnimationUsingKeyFrames.KeyFrames.Add(keyFrame);
			zero += item.Duration;
		}
		_storyboard.Children.Add(objectAnimationUsingKeyFrames);
		Storyboard.SetTargetProperty((DependencyObject)(object)objectAnimationUsingKeyFrames, new PropertyPath("Source"));
		Storyboard.SetTarget((DependencyObject)(object)objectAnimationUsingKeyFrames, (DependencyObject)(object)view);
		((DependencyObject)_storyboard).SetValue(Timeline.RepeatBehaviorProperty, (object)RepeatBehavior.Forever);
		_storyboard.Duration = zero;
	}

	public void Animate()
	{
		_storyboard?.Begin();
	}

	public void Stop()
	{
		_storyboard?.Stop();
	}

	private void ClearView()
	{
		_storyboard?.Remove(view);
		_storyboard = null;
		view.Source = null;
	}

	private void VisibilityChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (base.IsVisible)
		{
			if (AutoStart)
			{
				Animate();
			}
		}
		else
		{
			Stop();
		}
	}
}
