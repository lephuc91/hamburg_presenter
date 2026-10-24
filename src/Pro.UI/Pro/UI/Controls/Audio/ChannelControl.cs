using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.DO.Audio;

namespace Pro.UI.Controls.Audio;

public class ChannelControl<I, O> : FrameworkElement where I : IChannel, new() where O : IChannel, new()
{
	private const double _defaultCellSize = 36.0;

	private const double _defaultHeaderHeight = 40.0;

	private const double _maxSize = 450.0;

	private const double _lineHeight = 18.0;

	private readonly bool _scrollScreen;

	private readonly double _scrollScale;

	private const double _mouseWheelBaseValue = 120.0;

	private const double _headerPadding = 1.0;

	private readonly List<FrameworkElement> _children = new List<FrameworkElement>();

	private readonly Border _border = new Border();

	private readonly Grid _rowLabelGrid = new Grid
	{
		HorizontalAlignment = HorizontalAlignment.Left,
		VerticalAlignment = VerticalAlignment.Stretch
	};

	private readonly Grid _columnLabelGrid = new Grid
	{
		HorizontalAlignment = HorizontalAlignment.Stretch,
		VerticalAlignment = VerticalAlignment.Top
	};

	private readonly TextBlock _rowHeaderTextBlock = new TextBlock
	{
		HorizontalAlignment = HorizontalAlignment.Center,
		VerticalAlignment = VerticalAlignment.Center,
		Margin = new Thickness(10.0, 0.0, 5.0, 0.0),
		LayoutTransform = new RotateTransform(-90.0)
	};

	private readonly TextBlock _columnHeaderTextBlock = new TextBlock
	{
		HorizontalAlignment = HorizontalAlignment.Center,
		VerticalAlignment = VerticalAlignment.Center,
		Margin = new Thickness(0.0, 10.0, 0.0, 5.0)
	};

	private readonly ColumnHeader _columnHeader = new ColumnHeader();

	private readonly RowHeader _rowHeader = new RowHeader();

	private readonly RouterMasterControl _masterControl = new RouterMasterControl();

	private readonly ChannelMatrix<I, O> _matrix = new ChannelMatrix<I, O>();

	private readonly ScrollBar _verticalScrollBar;

	private readonly ScrollBar _horizontalScrollBar;

	public static readonly DependencyProperty AudioMapProperty = DependencyProperty.Register("AudioMap", typeof(AudioMap<I, O>), typeof(ChannelControl<I, O>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(AudioMapChanged)));

	public static readonly DependencyProperty BorderThicknessProperty = DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(ChannelControl<I, O>));

	public static readonly DependencyProperty BorderBrushProperty = DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(ChannelControl<I, O>));

	public static readonly DependencyProperty ToggleBrushProperty = DependencyProperty.Register("ToggleBrush", typeof(Brush), typeof(ChannelControl<I, O>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.LightSkyBlue, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty BackgroundProperty = DependencyProperty.Register("Background", typeof(Brush), typeof(ChannelControl<I, O>));

	public static readonly DependencyProperty ShowInputChannelIndexProperty = DependencyProperty.Register("ShowInputChannelIndex", typeof(bool), typeof(ChannelControl<I, O>));

	public static readonly DependencyProperty ShowInputAudioControlsProperty = DependencyProperty.Register("ShowInputAudioControls", typeof(bool), typeof(ChannelControl<I, O>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty ShowInputMuteControlsProperty = DependencyProperty.Register("ShowInputMuteControls", typeof(bool), typeof(ChannelControl<I, O>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty ShowInputSoloControlsProperty = DependencyProperty.Register("ShowInputSoloControls", typeof(bool), typeof(ChannelControl<I, O>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty ShowInputTestControlsProperty = DependencyProperty.Register("ShowInputTestControls", typeof(bool), typeof(ChannelControl<I, O>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty ShowOutputChannelIndexProperty = DependencyProperty.Register("ShowOutputChannelIndex", typeof(bool), typeof(ChannelControl<I, O>));

	public static readonly DependencyProperty ShowOutputAudioControlsProperty = DependencyProperty.Register("ShowOutputAudioControls", typeof(bool), typeof(ChannelControl<I, O>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty ShowOutputMuteControlsProperty = DependencyProperty.Register("ShowOutputMuteControls", typeof(bool), typeof(ChannelControl<I, O>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty ShowOutputSoloControlsProperty = DependencyProperty.Register("ShowOutputSoloControls", typeof(bool), typeof(ChannelControl<I, O>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty ShowOutputTestControlsProperty = DependencyProperty.Register("ShowOutputTestControls", typeof(bool), typeof(ChannelControl<I, O>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty CellSizeProperty = DependencyProperty.Register("CellSize", typeof(double), typeof(ChannelControl<I, O>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)36.0, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty HeaderTemplateHeightProperty = DependencyProperty.Register("HeaderTemplateHeight", typeof(double), typeof(ChannelControl<I, O>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)40.0, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty RowHeaderLabelProperty = DependencyProperty.Register("RowHeaderText", typeof(string), typeof(ChannelControl<I, O>));

	public static readonly DependencyProperty ColumnHeaderTextProperty = DependencyProperty.Register("ColumnHeaderText", typeof(string), typeof(ChannelControl<I, O>));

	public static readonly DependencyProperty RotateColumnTemplateProperty = DependencyProperty.Register("RotateColumnTemplate", typeof(bool), typeof(ChannelControl<I, O>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));

	public static readonly DependencyProperty ShowMuteAndSoloButtonsProperty = DependencyProperty.Register("ShowMuteAndSoloButtons", typeof(bool), typeof(ChannelControl<I, O>));

	public static readonly DependencyProperty AutoOnlyProperty = DependencyProperty.Register("AutoOnly", typeof(bool), typeof(ChannelControl<I, O>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, new PropertyChangedCallback(AutoOnlyChanged)));

	public AudioMap<I, O>? AudioMap
	{
		get
		{
			return (AudioMap<I, O>)((DependencyObject)this).GetValue(AudioMapProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AudioMapProperty, (object)value);
		}
	}

	public Thickness BorderThickness
	{
		get
		{
			return (Thickness)((DependencyObject)this).GetValue(BorderThicknessProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BorderThicknessProperty, (object)value);
		}
	}

	public Brush BorderBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(BorderBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BorderBrushProperty, (object)value);
		}
	}

	public Brush ToggleBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(ToggleBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ToggleBrushProperty, (object)value);
		}
	}

	public Brush Background
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(BackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BackgroundProperty, (object)value);
		}
	}

	public bool ShowInputChannelIndex
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowInputChannelIndexProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowInputChannelIndexProperty, (object)value);
		}
	}

	public bool ShowInputAudioControls
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowInputAudioControlsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowInputAudioControlsProperty, (object)value);
		}
	}

	public bool ShowInputMuteControls
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowInputMuteControlsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowInputMuteControlsProperty, (object)value);
		}
	}

	public bool ShowInputSoloControls
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowInputSoloControlsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowInputSoloControlsProperty, (object)value);
		}
	}

	public bool ShowInputTestControls
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowInputTestControlsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowInputTestControlsProperty, (object)value);
		}
	}

	public bool ShowOutputChannelIndex
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowOutputChannelIndexProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowOutputChannelIndexProperty, (object)value);
		}
	}

	public bool ShowOutputAudioControls
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowOutputAudioControlsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowOutputAudioControlsProperty, (object)value);
		}
	}

	public bool ShowOutputMuteControls
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowOutputMuteControlsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowOutputMuteControlsProperty, (object)value);
		}
	}

	public bool ShowOutputSoloControls
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowOutputSoloControlsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowOutputSoloControlsProperty, (object)value);
		}
	}

	public bool ShowOutputTestControls
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowOutputTestControlsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowOutputTestControlsProperty, (object)value);
		}
	}

	public double CellSize
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(CellSizeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CellSizeProperty, (object)value);
		}
	}

	public double HeaderTemplateHeight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(HeaderTemplateHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HeaderTemplateHeightProperty, (object)value);
		}
	}

	public string RowHeaderText
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(RowHeaderLabelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RowHeaderLabelProperty, (object)value);
		}
	}

	public string ColumnHeaderText
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(ColumnHeaderTextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ColumnHeaderTextProperty, (object)value);
		}
	}

	public bool RotateColumnTemplate
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(RotateColumnTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RotateColumnTemplateProperty, (object)value);
		}
	}

	public bool ShowMuteAndSoloButtons
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowMuteAndSoloButtonsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowMuteAndSoloButtonsProperty, (object)value);
		}
	}

	protected override int VisualChildrenCount => _children.Count;

	private ChannelSet<I>? InputChannels => AudioMap?.InputSet;

	private ChannelSet<O>? OutputChannels => AudioMap?.OutputSet;

	public bool AutoOnly
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AutoOnlyProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoOnlyProperty, (object)value);
		}
	}

	private static void AudioMapChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((ChannelControl<I, O>)(object)callerObject).OnAudioMapChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as AudioMap<I, O>, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as AudioMap<I, O>);
	}

	private static void AutoOnlyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((ChannelControl<I, O>)(object)callerObject)._masterControl.AutoOnly = (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
	}

	public ChannelControl()
	{
		_scrollScreen = SystemParameters.WheelScrollLines <= 0;
		_scrollScale = ((!_scrollScreen) ? ((double)SystemParameters.WheelScrollLines * 18.0) : 0.0);
		_border.SetBinding(Border.BorderThicknessProperty, getBinding("BorderThickness"));
		_border.SetBinding(Border.BorderBrushProperty, getBinding("BorderBrush"));
		_rowLabelGrid.SetBinding(Panel.BackgroundProperty, getBinding("Background"));
		_columnLabelGrid.SetBinding(Panel.BackgroundProperty, getBinding("Background"));
		_rowHeaderTextBlock.SetBinding(TextBlock.TextProperty, getBinding("RowHeaderText"));
		_columnHeaderTextBlock.SetBinding(TextBlock.TextProperty, getBinding("ColumnHeaderText"));
		_columnHeader.SetBinding(Control.BackgroundProperty, getBinding("Background"));
		_columnHeader.SetBinding(ColumnHeader.TemplateWidthProperty, getBinding("CellSize"));
		_columnHeader.SetBinding(ColumnHeader.TemplateHeightProperty, getBinding("HeaderTemplateHeight"));
		_columnHeader.SetBinding(ColumnHeader.ShowChannelIndexProperty, getBinding("ShowOutputChannelIndex"));
		_columnHeader.SetBinding(ColumnHeader.ShowChannelControlsProperty, getBinding("ShowOutputAudioControls"));
		_columnHeader.SetBinding(ColumnHeader.ShowMuteControlsProperty, getBinding("ShowOutputMuteControls"));
		_columnHeader.SetBinding(ColumnHeader.ShowSoloControlsProperty, getBinding("ShowOutputSoloControls"));
		_columnHeader.SetBinding(ColumnHeader.ShowTestControlsProperty, getBinding("ShowOutputTestControls"));
		_columnHeader.SetBinding(ColumnHeader.RotateTemplateLabelsProperty, getBinding("RotateColumnTemplate"));
		_rowHeader.SetBinding(Control.BackgroundProperty, getBinding("Background"));
		_rowHeader.SetBinding(RowHeader.TemplateHeightProperty, getBinding("CellSize"));
		_rowHeader.SetBinding(RowHeader.ShowChannelIndexProperty, getBinding("ShowInputChannelIndex"));
		_rowHeader.SetBinding(RowHeader.ShowChannelControlsProperty, getBinding("ShowInputAudioControls"));
		_rowHeader.SetBinding(RowHeader.ShowMuteControlsProperty, getBinding("ShowInputMuteControls"));
		_rowHeader.SetBinding(RowHeader.ShowSoloControlsProperty, getBinding("ShowInputSoloControls"));
		_rowHeader.SetBinding(RowHeader.ShowTestControlsProperty, getBinding("ShowInputTestControls"));
		_masterControl.SetBinding(Control.BackgroundProperty, getBinding("Background"));
		_masterControl.SetBinding(RouterMasterControl.ShowMuteAndSoloButtonsProperty, getBinding("ShowMuteAndSoloButtons"));
		_masterControl.AutoMap += delegate
		{
			AudioMap?.AutoMap();
		};
		_masterControl.ClearMap += delegate
		{
			AudioMap?.ClearMap();
		};
		_matrix.SetBinding(ChannelMatrix<I, O>.BackgroundProperty, getBinding("Background"));
		_matrix.SetBinding(ChannelMatrix<I, O>.AudioMapProperty, getBinding("AudioMap"));
		_matrix.SetBinding(ChannelMatrix<I, O>.CellSizeProperty, getBinding("CellSize"));
		_matrix.SetBinding(ChannelMatrix<I, O>.ToggleBrushProperty, getBinding("ToggleBrush"));
		_verticalScrollBar = new ScrollBar
		{
			Orientation = Orientation.Vertical,
			Minimum = 0.0,
			SmallChange = 36.0,
			LargeChange = 108.0,
			Margin = new Thickness(10.0, 0.0, 0.0, 0.0),
			Visibility = Visibility.Hidden
		};
		_horizontalScrollBar = new ScrollBar
		{
			Orientation = Orientation.Horizontal,
			Minimum = 0.0,
			SmallChange = 36.0,
			LargeChange = 108.0,
			Margin = new Thickness(0.0, 10.0, 0.0, 0.0),
			Visibility = Visibility.Hidden
		};
		_verticalScrollBar.ValueChanged += delegate
		{
			InvalidateArrange();
		};
		_verticalScrollBar.Scroll += delegate
		{
			InvalidateArrange();
		};
		_horizontalScrollBar.ValueChanged += delegate
		{
			InvalidateArrange();
		};
		_horizontalScrollBar.Scroll += delegate
		{
			InvalidateArrange();
		};
		AddChild(_matrix);
		AddChild(_columnHeader);
		AddChild(_rowHeader);
		AddChild(_columnLabelGrid);
		AddChild(_rowLabelGrid);
		_rowLabelGrid.Children.Add(_rowHeaderTextBlock);
		_columnLabelGrid.Children.Add(_columnHeaderTextBlock);
		AddChild(_masterControl);
		AddChild(_verticalScrollBar);
		AddChild(_horizontalScrollBar);
		AddChild(_border);
		base.Loaded += delegate
		{
			InvalidateArrange();
		};
		Binding getBinding(string name)
		{
			return new Binding(name)
			{
				Source = this
			};
		}
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		_masterControl.Measure(availableSize);
		_border.Measure(availableSize);
		_columnLabelGrid.Measure(availableSize);
		_rowLabelGrid.Measure(availableSize);
		RowHeader rowHeader = _rowHeader;
		Size desiredSize = _masterControl.DesiredSize;
		double width = ((Size)(ref desiredSize)).Width;
		desiredSize = _rowLabelGrid.DesiredSize;
		rowHeader.TemplateWidth = width - ((Size)(ref desiredSize)).Width;
		_columnHeader.TemplateHeight = HeaderTemplateHeight;
		_columnHeader.Measure(availableSize);
		_rowHeader.Measure(availableSize);
		_matrix.Measure(availableSize);
		desiredSize = _masterControl.DesiredSize;
		double height = ((Size)(ref desiredSize)).Height;
		desiredSize = _rowLabelGrid.DesiredSize;
		double num = height + Math.Max(((Size)(ref desiredSize)).Height, (double)(InputChannels?.ChannelCount ?? 0) * CellSize);
		if (_columnHeader.TemplateHeight > CellSize)
		{
			num += _columnHeader.TemplateHeight - CellSize;
		}
		desiredSize = _masterControl.DesiredSize;
		double width2 = ((Size)(ref desiredSize)).Width;
		desiredSize = _columnLabelGrid.DesiredSize;
		double num2 = width2 + Math.Max(((Size)(ref desiredSize)).Width, (double)(OutputChannels?.ChannelCount ?? 0) * CellSize);
		measureScrollBar(_horizontalScrollBar, num2, Math.Min(num2, 450.0));
		measureScrollBar(_verticalScrollBar, num, Math.Min(num, 450.0));
		double num3 = Math.Min(num2, 450.0);
		desiredSize = _verticalScrollBar.DesiredSize;
		double x = num3 + ((Size)(ref desiredSize)).Width;
		double num4 = Math.Min(num, 450.0);
		desiredSize = _horizontalScrollBar.DesiredSize;
		return new Vector2<double>(x, num4 + ((Size)(ref desiredSize)).Height);
		static void measureScrollBar(ScrollBar scrollBar, double extent, double available)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			scrollBar.Measure(new Vector2<double>(available));
			scrollBar.Visibility = ((!(extent > available)) ? Visibility.Hidden : Visibility.Visible);
			scrollBar.Maximum = Math.Max(extent - available, 0.0);
			scrollBar.ViewportSize = available;
		}
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		Size desiredSize = _masterControl.DesiredSize;
		double width = ((Size)(ref desiredSize)).Width;
		desiredSize = _masterControl.DesiredSize;
		double height = ((Size)(ref desiredSize)).Height;
		desiredSize = _columnLabelGrid.DesiredSize;
		double height2 = ((Size)(ref desiredSize)).Height;
		desiredSize = _columnHeader.DesiredSize;
		double num = Math.Max(height, height2 + ((Size)(ref desiredSize)).Height);
		Grid rowLabelGrid = _rowLabelGrid;
		Vector2<double> position = new Vector2<double>(0.0, num);
		desiredSize = _rowLabelGrid.DesiredSize;
		rowLabelGrid.Arrange(new Rect<double>(position, new Vector2<double>(((Size)(ref desiredSize)).Width, ((Size)(ref finalSize)).Height - num - _horizontalScrollBar.ActualHeight)));
		Grid columnLabelGrid = _columnLabelGrid;
		Vector2<double> position2 = new Vector2<double>(width, 0.0);
		double x = ((Size)(ref finalSize)).Width - width - _verticalScrollBar.ActualWidth;
		desiredSize = _columnLabelGrid.DesiredSize;
		columnLabelGrid.Arrange(new Rect<double>(position2, new Vector2<double>(x, ((Size)(ref desiredSize)).Height)));
		RowHeader rowHeader = _rowHeader;
		desiredSize = _rowLabelGrid.DesiredSize;
		Vector2<double> position3 = new Vector2<double>(((Size)(ref desiredSize)).Width, num - _verticalScrollBar.Value);
		desiredSize = _rowLabelGrid.DesiredSize;
		double x2 = width - ((Size)(ref desiredSize)).Width;
		desiredSize = _rowHeader.DesiredSize;
		rowHeader.Arrange(new Rect<double>(position3, new Vector2<double>(x2, ((Size)(ref desiredSize)).Height + 1.0)));
		ColumnHeader columnHeader = _columnHeader;
		double x3 = width - _horizontalScrollBar.Value;
		desiredSize = _columnLabelGrid.DesiredSize;
		Vector2<double> position4 = new Vector2<double>(x3, ((Size)(ref desiredSize)).Height);
		desiredSize = _columnHeader.DesiredSize;
		double x4 = ((Size)(ref desiredSize)).Width + 1.0;
		desiredSize = _columnHeader.DesiredSize;
		columnHeader.Arrange(new Rect<double>(position4, new Vector2<double>(x4, ((Size)(ref desiredSize)).Height + 1.0)));
		_masterControl.Arrange(new Rect<double>((Vector2<double>)_masterControl.DesiredSize));
		ScrollBar verticalScrollBar = _verticalScrollBar;
		double width2 = ((Size)(ref finalSize)).Width;
		desiredSize = _verticalScrollBar.DesiredSize;
		Vector2<double> position5 = new Vector2<double>(width2 - ((Size)(ref desiredSize)).Width, 0.0);
		desiredSize = _verticalScrollBar.DesiredSize;
		verticalScrollBar.Arrange(new Rect<double>(position5, new Vector2<double>(((Size)(ref desiredSize)).Width, ((Size)(ref finalSize)).Height)));
		ScrollBar horizontalScrollBar = _horizontalScrollBar;
		double height3 = ((Size)(ref finalSize)).Height;
		desiredSize = _horizontalScrollBar.DesiredSize;
		Vector2<double> position6 = new Vector2<double>(0.0, height3 - ((Size)(ref desiredSize)).Height);
		double width3 = ((Size)(ref finalSize)).Width;
		desiredSize = _horizontalScrollBar.DesiredSize;
		horizontalScrollBar.Arrange(new Rect<double>(position6, new Vector2<double>(width3, ((Size)(ref desiredSize)).Height)));
		_matrix.Arrange(new Rect<double>(new Vector2<double>(width, num) - new Vector2<double>(_horizontalScrollBar.Value, _verticalScrollBar.Value), (Vector2<double>)_matrix.DesiredSize));
		_border.Arrange(new Rect<double>((Vector2<double>)finalSize));
		return finalSize;
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		drawingContext.DrawRectangle(Background, null, new Rect(base.RenderSize));
	}

	protected override Visual GetVisualChild(int index)
	{
		return _children[index];
	}

	private void AddChild(FrameworkElement child)
	{
		AddVisualChild(child);
		_children.Add(child);
	}

	protected override void OnMouseWheel(MouseWheelEventArgs e)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Invalid comparison between Unknown and I4
		if (base.IsMouseOver)
		{
			e.Handled = true;
			ScrollBar scrollBar = (((int)Keyboard.Modifiers == 4) ? _horizontalScrollBar : _verticalScrollBar);
			scrollBar.Value += (double)(-e.Delta) / 120.0 * ((!_scrollScreen) ? _scrollScale : scrollBar.ViewportSize);
			InvalidateArrange();
		}
	}

	private void OnAudioMapChanged(AudioMap<I, O>? oldValue, AudioMap<I, O>? newValue)
	{
		if (oldValue != null)
		{
			oldValue.MapInvalidated -= base.InvalidateVisual;
			CollectionChangedEventManager.RemoveHandler((INotifyCollectionChanged)oldValue.InputSet, (EventHandler<NotifyCollectionChangedEventArgs>)CollectionChange_RefreshChannels);
			CollectionChangedEventManager.RemoveHandler((INotifyCollectionChanged)oldValue.OutputSet, (EventHandler<NotifyCollectionChangedEventArgs>)CollectionChange_RefreshChannels);
		}
		if (newValue != null)
		{
			newValue.MapInvalidated += base.InvalidateVisual;
			CollectionChangedEventManager.AddHandler((INotifyCollectionChanged)newValue.InputSet, (EventHandler<NotifyCollectionChangedEventArgs>)CollectionChange_RefreshChannels);
			CollectionChangedEventManager.AddHandler((INotifyCollectionChanged)newValue.OutputSet, (EventHandler<NotifyCollectionChangedEventArgs>)CollectionChange_RefreshChannels);
			_masterControl.SetBinding(RouterMasterControl.MutedProperty, new Binding("MuteActive")
			{
				Source = newValue
			});
			_masterControl.SetBinding(RouterMasterControl.SoloActiveProperty, new Binding("SoloActive")
			{
				Source = newValue
			});
			RefreshChannels();
		}
	}

	private void CollectionChange_RefreshChannels(object? sender, NotifyCollectionChangedEventArgs args)
	{
		RefreshChannels();
	}

	private void RefreshChannels()
	{
		_rowHeader.Channels = InputChannels?.Cast<IChannel>();
		_columnHeader.Channels = OutputChannels?.Cast<IChannel>();
		InvalidateMeasure();
		InvalidateArrange();
		InvalidateVisual();
	}
}
