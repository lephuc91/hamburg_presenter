using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using CommunityToolkit.Mvvm.Input;
using ProPresenter.UI.ViewModels.ProContent.Asset;
using ProPresenter.UI.ViewModels.ProContent.Collection;

namespace ProPresenter.UI.ProContent;

public partial class ProContentCarouselView : UserControl, IComponentConnector
{
	private readonly RelayCommand _scrollBackwardCommand;

	private readonly RelayCommand _scrollForwardCommand;

	public static readonly DependencyProperty SelectAssetCommandProperty = DependencyProperty.Register("SelectAssetCommand", typeof(IAsyncRelayCommand<IProContentAssetVM>), typeof(ProContentCarouselView));

	private static readonly DependencyProperty ScrollBackwardCommandProperty = DependencyProperty.Register("ScrollBackwardCommand", typeof(ICommand), typeof(ProContentCarouselView));

	private static readonly DependencyProperty CanScrollBackwardProperty = DependencyProperty.Register("CanScrollBackward", typeof(bool), typeof(ProContentCarouselView), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, new PropertyChangedCallback(CanScrollPropertyChanged)));

	private static readonly DependencyProperty ScrollForwardCommandProperty = DependencyProperty.Register("ScrollForwardCommand", typeof(ICommand), typeof(ProContentCarouselView));

	private static readonly DependencyProperty CanScrollForwardProperty = DependencyProperty.Register("CanScrollForward", typeof(bool), typeof(ProContentCarouselView), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true, new PropertyChangedCallback(CanScrollPropertyChanged)));

	private static readonly DependencyProperty LayoutTypeProperty = DependencyProperty.Register("LayoutType", typeof(LayoutType), typeof(ProContentCarouselView), new PropertyMetadata((object)LayoutType.CarouselSmall, new PropertyChangedCallback(LayoutTypePropertyChanged)));

	private static readonly DependencyProperty AssetViewDataProperty = DependencyProperty.Register("AssetViewData", typeof(ProContentAssetViewData), typeof(ProContentCarouselView), new PropertyMetadata((PropertyChangedCallback)null));

	private static readonly DependencyProperty ThumbnailAspectRatioProperty = DependencyProperty.Register("ThumbnailAspectRatio", typeof(double), typeof(ProContentCarouselView), new PropertyMetadata((object)1.7777777777777777));

	public IAsyncRelayCommand<IProContentAssetVM>? SelectAssetCommand
	{
		get
		{
			return (IAsyncRelayCommand<IProContentAssetVM>)((DependencyObject)this).GetValue(SelectAssetCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectAssetCommandProperty, (object)value);
		}
	}

	private ICommand? ScrollBackwardCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(ScrollBackwardCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ScrollBackwardCommandProperty, (object)value);
		}
	}

	private bool CanScrollBackward
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanScrollBackwardProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanScrollBackwardProperty, (object)value);
		}
	}

	private ICommand? ScrollForwardCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(ScrollForwardCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ScrollForwardCommandProperty, (object)value);
		}
	}

	private bool CanScrollForward
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanScrollForwardProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanScrollForwardProperty, (object)value);
		}
	}

	private LayoutType LayoutType
	{
		get
		{
			return (LayoutType)((DependencyObject)this).GetValue(LayoutTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LayoutTypeProperty, (object)value);
		}
	}

	private ProContentAssetViewData? AssetViewData
	{
		get
		{
			return (ProContentAssetViewData)((DependencyObject)this).GetValue(AssetViewDataProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AssetViewDataProperty, (object)value);
		}
	}

	private double ThumbnailAspectRatio
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ThumbnailAspectRatioProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ThumbnailAspectRatioProperty, (object)value);
		}
	}

	private static void CanScrollPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is ProContentCarouselView proContentCarouselView)
		{
			proContentCarouselView._scrollBackwardCommand.NotifyCanExecuteChanged();
			proContentCarouselView._scrollForwardCommand.NotifyCanExecuteChanged();
		}
	}

	private static void LayoutTypePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is ProContentCarouselView proContentCarouselView)
		{
			proContentCarouselView.SetAssetViewData();
		}
	}

	public ProContentCarouselView()
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		InitializeComponent();
		_scrollBackwardCommand = new RelayCommand(OnScrollBack, () => CanScrollBackward);
		_scrollForwardCommand = new RelayCommand(OnScrollForward, () => CanScrollForward);
		((DependencyObject)this).SetCurrentValue(ScrollBackwardCommandProperty, (object)_scrollBackwardCommand);
		((DependencyObject)this).SetCurrentValue(ScrollForwardCommandProperty, (object)_scrollForwardCommand);
		base.DataContextChanged += new DependencyPropertyChangedEventHandler(ProContentCarouselView_DataContextChanged);
	}

	private void ProContentCarouselView_DataContextChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		SetBinding(LayoutTypeProperty, new Binding("LayoutType")
		{
			Source = base.DataContext
		});
		SetBinding(ThumbnailAspectRatioProperty, new Binding("ThumbnailAspectRatio")
		{
			Source = base.DataContext
		});
		SetAssetViewData();
	}

	protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
	{
		SetAssetViewData();
		base.OnRenderSizeChanged(sizeInfo);
	}

	private void SetAssetViewData()
	{
		((DependencyObject)this).SetCurrentValue(AssetViewDataProperty, (object)LayoutType.GetAssetViewData(base.ActualWidth, ThumbnailAspectRatio));
	}

	private void OnScrollBack()
	{
		ProContentAssetList.ScrollBackward();
	}

	private void OnScrollForward()
	{
		ProContentAssetList.ScrollForward();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
