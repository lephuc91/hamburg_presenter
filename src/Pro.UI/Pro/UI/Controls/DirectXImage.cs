using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Mathematics;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Utility;
using Pro.UI.Utility;
using RenewedVision.Wpf.Interop.DirectX;

namespace Pro.UI.Controls;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_d3dImageSource" })]
public class DirectXImage : Image, IDisposable
{
	private readonly D3D11Image _d3dImageSource;

	private TimeSpan _lastRender;

	public static readonly DependencyProperty RequestRenderCommandProperty = DependencyProperty.Register("RequestRenderCommand", typeof(IRelayCommand<RequestRenderParameter>), typeof(DirectXImage));

	public static readonly DependencyProperty AspectRatioProperty = DependencyProperty.Register("AspectRatio", typeof(double), typeof(DirectXImage), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1.7777777777777777, FrameworkPropertyMetadataOptions.AffectsMeasure));

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public IRelayCommand<RequestRenderParameter>? RequestRenderCommand
	{
		get
		{
			return (IRelayCommand<RequestRenderParameter>)((DependencyObject)this).GetValue(RequestRenderCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RequestRenderCommandProperty, (object)value);
		}
	}

	public double AspectRatio
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(AspectRatioProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AspectRatioProperty, (object)value);
		}
	}

	public event Action<DirectXImage>? HostWindowOpened;

	public event Action<DirectXImage>? HostWindowClosed;

	public DirectXImage()
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		_d3dImageSource = new D3D11Image
		{
			OnRender = DoRequestRender
		};
		base.Source = _d3dImageSource;
		RenderOptions.SetBitmapScalingMode((DependencyObject)(object)this, BitmapScalingMode.HighQuality);
		base.Loaded += DirectXImage_Loaded;
		base.IsVisibleChanged += new DependencyPropertyChangedEventHandler(DirectXImage_IsVisibleChanged);
	}

	private void DirectXImage_IsVisibleChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (base.IsVisible)
		{
			CompositionTarget.Rendering += CompositionTarget_Rendering;
		}
		else
		{
			CompositionTarget.Rendering -= CompositionTarget_Rendering;
		}
	}

	private void CompositionTarget_Rendering(object? sender, EventArgs e)
	{
		RenderingEventArgs renderingEventArgs = (RenderingEventArgs)e;
		if (_lastRender != renderingEventArgs.RenderingTime)
		{
			_d3dImageSource.RequestRender();
			_lastRender = renderingEventArgs.RenderingTime;
		}
	}

	private void DirectXImage_Loaded(object? sender, RoutedEventArgs e)
	{
		Window window = Window.GetWindow((DependencyObject)(object)this);
		if (window != null)
		{
			this.HostWindowOpened?.Invoke(this);
			window.Closing += HostWindow_Closing;
			_d3dImageSource.WindowOwner = new WindowInteropHelper(window).EnsureHandle();
			_d3dImageSource.RequestRender();
		}
		base.Loaded -= DirectXImage_Loaded;
	}

	private void HostWindow_Closing(object? sender, CancelEventArgs e)
	{
		if (!e.Cancel)
		{
			_d3dImageSource.OnRender = null;
			CompositionTarget.Rendering -= CompositionTarget_Rendering;
			this.HostWindowClosed?.Invoke(this);
		}
	}

	private void DoRequestRender(nint texture, bool isNew)
	{
		RequestRenderParameter parameter = new RequestRenderParameter(texture, new Vector2<int>(_d3dImageSource.PixelWidth, _d3dImageSource.PixelHeight));
		RequestRenderCommand?.Invoke(parameter);
	}

	private Vector2<int> GetPixelSize(Vector2<double> size)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		PresentationSource presentationSource = PresentationSource.FromVisual(this);
		if (presentationSource == null)
		{
			return Vector2<int>.Zero;
		}
		Matrix transformToDevice = presentationSource.CompositionTarget.TransformToDevice;
		Vector val = ((Matrix)(ref transformToDevice)).Transform((Vector)size);
		return new Vector2<int>((int)((Vector)(ref val)).X, (int)((Vector)(ref val)).Y);
	}

	protected override Size MeasureOverride(Size constraint)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		Vector2<double> vector = new Vector2<double>(AspectRatio, 1.0).ScaleToFitSize((Vector2<double>)constraint);
		Vector2<int> pixelSize = GetPixelSize(vector);
		_d3dImageSource.SetPixelSize(pixelSize.X, pixelSize.Y);
		return vector;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_d3dImageSource.Dispose();
		}
	}
}
