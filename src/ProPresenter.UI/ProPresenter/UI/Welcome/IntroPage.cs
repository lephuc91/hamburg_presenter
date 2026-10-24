using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using ProPresenter.UI.ViewModels.Welcome;

namespace ProPresenter.UI.Welcome;

public partial class IntroPage : UserControl, IComponentConnector
{
	private readonly Storyboard _animationStoryboard;

	private static readonly DependencyProperty HorizontalScrollOffsetAnimationProperty = DependencyProperty.Register("HorizontalScrollOffsetAnimation", typeof(double), typeof(IntroPage), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0, new PropertyChangedCallback(HorizontalScrollOffsetPropertyChanged)));

	private double HorizontalScrollOffsetAnimation
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(HorizontalScrollOffsetAnimationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HorizontalScrollOffsetAnimationProperty, (object)value);
		}
	}

	public IntroPage()
	{
		_animationStoryboard = new Storyboard();
		InitializeComponent();
	}

	private void OnDataContextPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (sender is IIntroVM introVM && e.PropertyName == "CurrentPage")
		{
			_animationStoryboard.Remove();
			DoubleAnimation doubleAnimation = new DoubleAnimation
			{
				EasingFunction = new CircleEase
				{
					EasingMode = EasingMode.EaseOut
				},
				From = scrollViewer.HorizontalOffset,
				To = (double)(introVM.CurrentPage - 1) * scrollViewer.ActualWidth,
				Duration = new Duration(TimeSpan.FromMilliseconds(500L, 0L))
			};
			_animationStoryboard.Children.Add(doubleAnimation);
			Storyboard.SetTargetProperty((DependencyObject)(object)doubleAnimation, new PropertyPath(HorizontalScrollOffsetAnimationProperty));
			Storyboard.SetTarget((DependencyObject)(object)doubleAnimation, (DependencyObject)(object)this);
			_animationStoryboard.Begin();
		}
	}

	private static void HorizontalScrollOffsetPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is IntroPage introPage)
		{
			introPage.scrollViewer?.ScrollToHorizontalOffset((double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
	}

	private void OnDataContextChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).OldValue is INotifyPropertyChanged notifyPropertyChanged)
		{
			notifyPropertyChanged.PropertyChanged -= OnDataContextPropertyChanged;
		}
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue is INotifyPropertyChanged notifyPropertyChanged2)
		{
			notifyPropertyChanged2.PropertyChanged += OnDataContextPropertyChanged;
		}
	}
}
