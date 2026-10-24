using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.DO.Audio;

namespace Pro.UI.Controls.Audio;

public class ChannelMatrix<I, O> : FrameworkElement where I : IChannel, new() where O : IChannel, new()
{
	private static readonly Pen BorderPen = new Pen(Brushes.Black, 1.0);

	private static readonly Vector2<double>[] DirectionScalarMap = new Vector2<double>[8]
	{
		new Vector2<double>(1.0, 0.0),
		new Vector2<double>(1.0, 1.0),
		new Vector2<double>(0.0, 1.0),
		new Vector2<double>(-1.0, 1.0),
		new Vector2<double>(-1.0, 0.0),
		new Vector2<double>(-1.0, -1.0),
		new Vector2<double>(0.0, -1.0),
		new Vector2<double>(1.0, -1.0)
	};

	private bool _isTogglingOn;

	private readonly List<(I input, O output)> _currentLinePairs = new List<(I, O)>();

	private Vector2<double> _clickPoint;

	public static readonly DependencyProperty AudioMapProperty = DependencyProperty.Register("AudioMap", typeof(AudioMap<I, O>), typeof(ChannelMatrix<I, O>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ChannelMatrix<I, O>)(object)s).OnAudioMapChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as AudioMap<I, O>, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as AudioMap<I, O>);
	}));

	public static readonly DependencyProperty CellSizeProperty = DependencyProperty.Register("CellSize", typeof(double), typeof(ChannelMatrix<I, O>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty ToggleBrushProperty = DependencyProperty.Register("ToggleBrush", typeof(Brush), typeof(ChannelMatrix<I, O>), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.LightSkyBlue, FrameworkPropertyMetadataOptions.AffectsRender));

	public static readonly DependencyProperty BackgroundProperty = DependencyProperty.Register("Background", typeof(Brush), typeof(ChannelMatrix<I, O>));

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

	private ChannelSet<I>? InputChannels => AudioMap?.InputSet;

	private ChannelSet<O>? OutputChannels => AudioMap?.OutputSet;

	private void OnAudioMapChanged(AudioMap<I, O>? oldValue, AudioMap<I, O>? newValue)
	{
		if (oldValue != null)
		{
			oldValue.MapInvalidated -= base.InvalidateVisual;
			oldValue.InputSet.CollectionChanged -= OnSetResized;
			oldValue.OutputSet.CollectionChanged -= OnSetResized;
		}
		if (newValue != null)
		{
			newValue.MapInvalidated += base.InvalidateVisual;
			newValue.InputSet.CollectionChanged += OnSetResized;
			newValue.OutputSet.CollectionChanged += OnSetResized;
			OnSetResized();
		}
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		return new Vector2<double>(OutputChannels?.ChannelCount ?? 0, InputChannels?.ChannelCount ?? 0) * CellSize;
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		if (AudioMap == null)
		{
			return;
		}
		drawingContext.DrawRectangle(Brushes.Transparent, null, new Rect(base.RenderSize));
		if (InputChannels == null || OutputChannels == null)
		{
			return;
		}
		Vector2<double> zero = Vector2<double>.Zero;
		bool flag = true;
		foreach (I inputChannel in InputChannels)
		{
			foreach (O outputChannel in OutputChannels)
			{
				if (flag)
				{
					FormattedText formattedText = new FormattedText(outputChannel.Name, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 12.0, Brushes.DarkSlateGray, VisualTreeHelper.GetDpi(this).PixelsPerDip);
					drawingContext.DrawText(formattedText, new Point(zero.X, zero.Y));
					flag = false;
				}
				drawingContext.DrawRectangle(AudioMap.IsMapped(inputChannel, outputChannel) ? ToggleBrush : Background, BorderPen, new Rect<double>(zero, new Vector2<double>(CellSize)));
				zero.X += CellSize;
			}
			zero.X = 0.0;
			zero.Y += CellSize;
		}
	}

	protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (AudioMap == null)
		{
			return;
		}
		_clickPoint = (Vector2<double>)e.GetPosition(this);
		if (_clickPoint.X < 0.0 || _clickPoint.Y < 0.0)
		{
			return;
		}
		var (val, val2) = GetPairFromPoint(_clickPoint);
		if (val != null && val2 != null)
		{
			_isTogglingOn = !AudioMap.IsMapped(val, val2);
			if (!object.Equals(val, default(I)) && !object.Equals(val2, default(O)))
			{
				AudioMap.Toggle(val, val2);
			}
			CaptureMouse();
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		if (AudioMap != null && e.LeftButton == MouseButtonState.Pressed && base.IsMouseCaptured)
		{
			Vector2<double> endPoint = (Vector2<double>)e.GetPosition(this);
			GeneratePairsFromLine(_clickPoint, endPoint);
			Toggle(_isTogglingOn);
		}
	}

	private void Toggle(bool toggleOn)
	{
		foreach (var (input, output) in _currentLinePairs)
		{
			if (toggleOn)
			{
				AudioMap?.ToggleOn(input, output);
			}
			else
			{
				AudioMap?.ToggleOff(input, output);
			}
		}
	}

	protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		ReleaseMouseCapture();
		_currentLinePairs.Clear();
	}

	protected override void OnMouseLeave(MouseEventArgs e)
	{
		if (base.IsMouseCaptured)
		{
			_currentLinePairs.Clear();
		}
	}

	private (I? input, O? output) GetPairFromPoint(Vector2<double> point)
	{
		if (InputChannels == null || OutputChannels == null)
		{
			return (input: default(I), output: default(O));
		}
		return (input: FindChannel(InputChannels, (int)Math.Floor(point.Y / CellSize)), output: FindChannel(OutputChannels, (int)Math.Floor(point.X / CellSize)));
	}

	private static T? FindChannel<T>(IEnumerable<T> channels, int index) where T : IChannel
	{
		return channels.FirstOrDefault((T c) => c.Index == index);
	}

	private void GeneratePairsFromLine(Vector2<double> startPoint, Vector2<double> endPoint)
	{
		Toggle(!_isTogglingOn);
		_currentLinePairs.Clear();
		startPoint = startPoint.ComponentwiseQuotient(new Vector2<double>(CellSize)).Floor().ComponentwiseProduct(new Vector2<double>(CellSize)) + new Vector2<double>(CellSize / 2.0);
		endPoint = endPoint.ComponentwiseQuotient(new Vector2<double>(CellSize)).Floor().ComponentwiseProduct(new Vector2<double>(CellSize)) + new Vector2<double>(CellSize / 2.0);
		int num = ((int)Math.Round(endPoint.Angle(startPoint).Mod(360.0) / 45.0, 0)).Mod(DirectionScalarMap.Length);
		Vector2<double> scale = DirectionScalarMap[num];
		Vector2<double> vector = new Vector2<double>(CellSize).ComponentwiseProduct(scale);
		Vector2<double> vector2 = startPoint;
		Vector2<double> vector3 = endPoint + vector;
		Vector2<double> vector4;
		do
		{
			var (val, val2) = GetPairFromPoint(vector2);
			if (val != null && val2 != null)
			{
				AddPairToLine((input: val, output: val2));
				vector2 += vector;
				vector4 = (vector3 - vector2).ComponentwiseProduct(scale);
				continue;
			}
			break;
		}
		while (vector4.X > 0.0 || vector4.Y > 0.0);
	}

	private void AddPairToLine((I input, O output) pair)
	{
		if (AudioMap != null && _isTogglingOn != AudioMap.IsMapped(pair.input, pair.output))
		{
			_currentLinePairs.Add(pair);
		}
	}

	private void OnSetResized(object? sender, NotifyCollectionChangedEventArgs e)
	{
		OnSetResized();
	}

	private void OnSetResized()
	{
		InvalidateMeasure();
		InvalidateArrange();
		InvalidateVisual();
	}
}
