using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Collections;
using Pro.UI.Components;

namespace ProPresenter.UI.Props;

public partial class AutoClearDurationMenuSource : FrameworkCollection, IComponentConnector
{
	public static readonly DependencyProperty AutoClearDurationProperty = DependencyProperty.Register("AutoClearDuration", typeof(double), typeof(AutoClearDurationMenuSource), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		if (s is AutoClearDurationMenuSource autoClearDurationMenuSource && ((DependencyPropertyChangedEventArgs)(ref e)).NewValue is double value)
		{
			((DependencyObject)autoClearDurationMenuSource).SetCurrentValue(IsCustomAutoClearDurationProperty, (object)(!autoClearDurationMenuSource.AutoClearDurationSource.Concat(0.0.ToEnumerable()).Contains(value)));
		}
	}));

	public static readonly DependencyProperty AutoClearDurationSourceProperty = DependencyProperty.Register("AutoClearDurationSource", typeof(IReadOnlyList<double>), typeof(AutoClearDurationMenuSource), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)new double[7] { 5.0, 10.0, 15.0, 20.0, 30.0, 45.0, 60.0 }));

	public static readonly DependencyProperty SetAutoClearCommandProperty = DependencyProperty.Register("SetAutoClearCommand", typeof(ICommand<double>), typeof(AutoClearDurationMenuSource));

	public static readonly DependencyProperty SetCustomAutoClearCommandProperty = DependencyProperty.Register("SetCustomAutoClearCommand", typeof(ICommand), typeof(AutoClearDurationMenuSource));

	public static readonly DependencyProperty SetAutoClearCommandToDefaultProperty = DependencyProperty.Register("SetAutoClearCommandToDefault", typeof(ICommand), typeof(AutoClearDurationMenuSource));

	private static readonly DependencyProperty IsCustomAutoClearDurationProperty = DependencyProperty.Register("IsCustomAutoClearDuration", typeof(bool), typeof(AutoClearDurationMenuSource));

	private static readonly DependencyProperty DefaultAutoClearDurationProperty = DependencyProperty.Register("DefaultAutoClearDuration", typeof(double), typeof(AutoClearDurationMenuSource));

	private static readonly DependencyProperty AutoClearFollowsPropDurationProperty = DependencyProperty.Register("AutoClearFollowsPropDuration", typeof(bool), typeof(AutoClearDurationMenuSource));

	private static readonly DependencyProperty IsAutoClearCommandToDefaultAvailableProperty = DependencyProperty.Register("IsAutoClearCommandToDefaultAvailable", typeof(bool), typeof(AutoClearDurationMenuSource));

	public double AutoClearDuration
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(AutoClearDurationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoClearDurationProperty, (object)value);
		}
	}

	public IReadOnlyList<double> AutoClearDurationSource
	{
		get
		{
			return (IReadOnlyList<double>)((DependencyObject)this).GetValue(AutoClearDurationSourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoClearDurationSourceProperty, (object)value);
		}
	}

	public ICommand<double> SetAutoClearCommand
	{
		get
		{
			return (ICommand<double>)((DependencyObject)this).GetValue(SetAutoClearCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SetAutoClearCommandProperty, (object)value);
		}
	}

	public ICommand SetCustomAutoClearCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(SetCustomAutoClearCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SetCustomAutoClearCommandProperty, (object)value);
		}
	}

	public ICommand SetAutoClearCommandToDefault
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(SetAutoClearCommandToDefaultProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SetAutoClearCommandToDefaultProperty, (object)value);
		}
	}

	private bool IsCustomAutoClearDuration
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsCustomAutoClearDurationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsCustomAutoClearDurationProperty, (object)value);
		}
	}

	public double DefaultAutoClearDuration
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(DefaultAutoClearDurationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DefaultAutoClearDurationProperty, (object)value);
		}
	}

	public bool AutoClearFollowsPropDuration
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AutoClearFollowsPropDurationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoClearFollowsPropDurationProperty, (object)value);
		}
	}

	public bool IsAutoClearCommandToDefaultAvailable
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsAutoClearCommandToDefaultAvailableProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsAutoClearCommandToDefaultAvailableProperty, (object)value);
		}
	}

	public AutoClearDurationMenuSource()
	{
		InitializeComponent();
	}
}
