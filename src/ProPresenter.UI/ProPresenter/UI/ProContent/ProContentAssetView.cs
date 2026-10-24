using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using Pro.Common.Mathematics;
using ProPresenter.DO;
using ProPresenter.DO.PanelSourcing;
using ProPresenter.UI.Thumbnails;
using ProPresenter.UI.ViewModels.ProContent.Collection;

namespace ProPresenter.UI.ProContent;

public partial class ProContentAssetView : UserControl, IUniformViewControl, IComponentConnector
{
	public static readonly DependencyProperty ContentViewTypeProperty = DependencyProperty.Register("ContentViewType", typeof(LayoutType), typeof(ProContentAssetView), new PropertyMetadata((object)LayoutType.CarouselSmall));

	public static readonly DependencyProperty AspectRatioProperty = DependencyProperty.Register("AspectRatio", typeof(double), typeof(ProContentAssetView), new PropertyMetadata((object)1.0));

	public LayoutType ContentViewType
	{
		get
		{
			return (LayoutType)((DependencyObject)this).GetValue(ContentViewTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ContentViewTypeProperty, (object)value);
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

	public int Index { get; set; }

	public bool IsSelected { get; set; }

	public IPanelViewSettings? ViewSettings { get; set; }

	public IUniformViewSource? Source
	{
		get
		{
			return base.DataContext as IUniformViewSource;
		}
		set
		{
			base.DataContext = value;
		}
	}

	public ProContentAssetView()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		InitializeComponent();
		base.DataContextChanged += new DependencyPropertyChangedEventHandler(ProContentAssetView_DataContextChanged);
	}

	private void ProContentAssetView_DataContextChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		BindingOperations.ClearBinding((DependencyObject)(object)this, AspectRatioProperty);
		SetBinding(AspectRatioProperty, new Binding("ThumbnailAspectRatio")
		{
			Source = base.DataContext
		});
		if (Source != null)
		{
			((DependencyObject)this).SetCurrentValue(AspectRatioProperty, (object)Source.ThumbnailAspectRatio);
		}
	}

	public void SetPreviewSize(Vector2<double> size)
	{
		PreviewGrid.Width = size.X;
		PreviewGrid.Height = size.Y;
	}

	public void TearDown()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
