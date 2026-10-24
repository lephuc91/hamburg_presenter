using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace Pro.UI.Controls;

public partial class LinesPerSlideControl : UserControl, IComponentConnector
{
	private static readonly DependencyPropertyKey _actualMaximumPropertyKey = DependencyProperty.RegisterReadOnly("ActualMaximum", typeof(int), typeof(LinesPerSlideControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata());

	private static readonly DependencyPropertyKey _actualMinimumPropertyKey = DependencyProperty.RegisterReadOnly("ActualMinimium", typeof(int), typeof(LinesPerSlideControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata());

	private static readonly DependencyPropertyKey _labelsPropertyKey = DependencyProperty.RegisterReadOnly("Labels", typeof(ObservableCollection<string>), typeof(LinesPerSlideControl), new PropertyMetadata());

	private static readonly DependencyPropertyKey _ticksPropertyKey = DependencyProperty.RegisterReadOnly("Ticks", typeof(DoubleCollection), typeof(LinesPerSlideControl), new PropertyMetadata());

	public static readonly DependencyProperty ActualMaximumProperty = _actualMaximumPropertyKey.DependencyProperty;

	public static readonly DependencyProperty ActualMinimumProperty = _actualMinimumPropertyKey.DependencyProperty;

	public static readonly DependencyProperty ActualSelectedValueProperty = DependencyProperty.Register("ActualSelectedValue", typeof(int), typeof(LinesPerSlideControl), new PropertyMetadata((object)0, new PropertyChangedCallback(OnActualSelectedValuePropertyChanged)));

	public static readonly DependencyProperty IsTickedByTwosProperty = DependencyProperty.Register("IsTickedByTwos", typeof(bool), typeof(LinesPerSlideControl), new PropertyMetadata((object)false, new PropertyChangedCallback(OnIsTickedByTwosChanged)));

	public static readonly DependencyProperty LabelsProperty = _labelsPropertyKey.DependencyProperty;

	public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum", typeof(int), typeof(LinesPerSlideControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)4, new PropertyChangedCallback(OnMaximumPropertyChanged)));

	public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum", typeof(int), typeof(LinesPerSlideControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1, new PropertyChangedCallback(OnMinimumPropertyChanged)));

	public static readonly DependencyProperty SelectedValueProperty = DependencyProperty.Register("SelectedValue", typeof(int), typeof(LinesPerSlideControl), new PropertyMetadata((object)0, new PropertyChangedCallback(OnSelectedValuePropertyChanged), new CoerceValueCallback(OnCoerceSelectedValueProperty)));

	public static readonly DependencyProperty TicksProperty = _ticksPropertyKey.DependencyProperty;

	private readonly List<int> _values = new List<int>();

	public int ActualMaximum
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(ActualMaximumProperty);
		}
		private set
		{
			((DependencyObject)this).SetValue(_actualMaximumPropertyKey, (object)value);
		}
	}

	public int ActualMinimum
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(ActualMinimumProperty);
		}
		private set
		{
			((DependencyObject)this).SetValue(_actualMinimumPropertyKey, (object)value);
		}
	}

	public int ActualSelectedValue
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(ActualSelectedValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActualSelectedValueProperty, (object)value);
		}
	}

	public bool IsTickedByTwos
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsTickedByTwosProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsTickedByTwosProperty, (object)value);
		}
	}

	public ObservableCollection<string> Labels
	{
		get
		{
			return (ObservableCollection<string>)((DependencyObject)this).GetValue(LabelsProperty);
		}
		private set
		{
			((DependencyObject)this).SetValue(_labelsPropertyKey, (object)value);
		}
	}

	public int Maximum
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(MaximumProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaximumProperty, (object)value);
		}
	}

	public int Minimum
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(MinimumProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MinimumProperty, (object)value);
		}
	}

	public int SelectedValue
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(SelectedValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedValueProperty, (object)value);
		}
	}

	public DoubleCollection Ticks
	{
		get
		{
			return (DoubleCollection)((DependencyObject)this).GetValue(TicksProperty);
		}
		private set
		{
			((DependencyObject)this).SetValue(_ticksPropertyKey, (object)value);
		}
	}

	public LinesPerSlideControl()
	{
		Labels = new ObservableCollection<string>();
		InitializeComponent();
		InitializeTicks();
	}

	private static void OnActualSelectedValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		LinesPerSlideControl linesPerSlideControl = (LinesPerSlideControl)(object)d;
		linesPerSlideControl.SelectedValue = (linesPerSlideControl.IsTickedByTwos ? linesPerSlideControl._values[(int)((DependencyPropertyChangedEventArgs)(ref e)).NewValue] : ((int)((DependencyPropertyChangedEventArgs)(ref e)).NewValue));
	}

	private static object OnCoerceSelectedValueProperty(DependencyObject d, object baseValue)
	{
		LinesPerSlideControl linesPerSlideControl = (LinesPerSlideControl)(object)d;
		if ((int)baseValue < linesPerSlideControl.Minimum)
		{
			return linesPerSlideControl.Minimum;
		}
		if ((int)baseValue > linesPerSlideControl.Maximum)
		{
			return linesPerSlideControl.Maximum;
		}
		return baseValue;
	}

	private static void OnIsTickedByTwosChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((LinesPerSlideControl)(object)d).InitializeTicks();
	}

	private static void OnMaximumPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((LinesPerSlideControl)(object)d).InitializeTicks();
	}

	private static void OnMinimumPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((LinesPerSlideControl)(object)d).InitializeTicks();
	}

	private static void OnSelectedValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		LinesPerSlideControl linesPerSlideControl = (LinesPerSlideControl)(object)d;
		linesPerSlideControl.ActualSelectedValue = (linesPerSlideControl.IsTickedByTwos ? linesPerSlideControl._values.IndexOf((int)((DependencyPropertyChangedEventArgs)(ref e)).NewValue) : ((int)((DependencyPropertyChangedEventArgs)(ref e)).NewValue));
	}

	private void InitializeTicks()
	{
		DoubleCollection doubleCollection = new DoubleCollection();
		Labels.Clear();
		_values.Clear();
		int num = 0;
		for (int i = Minimum; i <= Maximum; i++)
		{
			if (IsTickedByTwos && (i % 2 == 0 || (double)Math.Abs(i - Minimum) < double.Epsilon || (double)Math.Abs(i - Maximum) < double.Epsilon))
			{
				doubleCollection.Add(num);
				_values.Add(i);
				num++;
				Labels.Add(i.ToString(CultureInfo.CurrentCulture));
			}
			else if (!IsTickedByTwos)
			{
				doubleCollection.Add(i);
				Labels.Add(i.ToString(CultureInfo.CurrentCulture));
			}
		}
		LabeledSlider pART_LabeledSlider = PART_LabeledSlider;
		int num3 = (ActualMinimum = ((!IsTickedByTwos) ? Minimum : 0));
		pART_LabeledSlider.Minimum = num3;
		LabeledSlider pART_LabeledSlider2 = PART_LabeledSlider;
		num3 = (ActualMaximum = (IsTickedByTwos ? (num - 1) : Maximum));
		pART_LabeledSlider2.Maximum = num3;
		Ticks = doubleCollection;
		ActualSelectedValue = ActualMinimum;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
