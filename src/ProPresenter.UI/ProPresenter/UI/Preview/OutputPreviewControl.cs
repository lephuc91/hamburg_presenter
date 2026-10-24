using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.UI.Controls;
using ProPresenter.UI.ViewModels.Preview;

namespace ProPresenter.UI.Preview;

[ContentProperty("ChildContent")]
public partial class OutputPreviewControl : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ChildContentProperty = DependencyProperty.Register("ChildContent", typeof(FrameworkElement), typeof(OutputPreviewControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null));

	private IOutputPreviewVM? PreviewVM => base.DataContext as IOutputPreviewVM;

	public FrameworkElement ChildContent
	{
		get
		{
			return (FrameworkElement)((DependencyObject)this).GetValue(ChildContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ChildContentProperty, (object)value);
		}
	}

	public OutputPreviewControl()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		InitializeComponent();
		base.DataContextChanged += new DependencyPropertyChangedEventHandler(OutputPreviewControl_DataContextChanged);
	}

	private void OutputPreviewControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		base.DataContextChanged -= new DependencyPropertyChangedEventHandler(OutputPreviewControl_DataContextChanged);
		SetPreviewContent();
	}

	private void SetPreviewContent()
	{
		if (PreviewVM == null)
		{
			return;
		}
		if (PreviewVM.IsLegacyRenderMode)
		{
			PreviewRenderTarget previewRenderTarget = new PreviewRenderTarget(PreviewVM.LoadPreview, PreviewVM.UnloadPreview);
			previewRenderTarget.SetBinding(PreviewRenderTarget.AspectRatioProperty, new Binding("AspectRatio")
			{
				Source = PreviewVM
			});
			if (ChildContent != null)
			{
				throw new NotSupportedException("ChildContent is not supported in legacy render mode.");
			}
			MainContent.Content = previewRenderTarget;
			return;
		}
		Grid grid = new Grid
		{
			HorizontalAlignment = HorizontalAlignment.Center,
			VerticalAlignment = VerticalAlignment.Center,
			Background = Brushes.Black
		};
		DirectXImage directXImage = new DirectXImage
		{
			Stretch = Stretch.Uniform
		};
		directXImage.SetBinding(DirectXImage.AspectRatioProperty, new Binding("AspectRatio")
		{
			Source = PreviewVM
		});
		directXImage.SetBinding(DirectXImage.RequestRenderCommandProperty, new Binding("RequestRenderCommand")
		{
			Source = PreviewVM
		});
		directXImage.HostWindowClosed += PreviewArea_HostClosed;
		directXImage.HostWindowOpened += PreviewArea_HostOpened;
		ContentControl contentControl = new ContentControl();
		contentControl.SetBinding(ContentControl.ContentProperty, new Binding("ChildContent")
		{
			Source = this
		});
		grid.Children.Add(directXImage);
		grid.Children.Add(contentControl);
		MainContent.Content = grid;
	}

	private void PreviewArea_HostClosed(DirectXImage directXImage)
	{
		PreviewVM?.UnloadPreview(IntPtr.Zero);
	}

	private void PreviewArea_HostOpened(DirectXImage directXImage)
	{
		PreviewVM?.LoadPreview(IntPtr.Zero);
	}
}
