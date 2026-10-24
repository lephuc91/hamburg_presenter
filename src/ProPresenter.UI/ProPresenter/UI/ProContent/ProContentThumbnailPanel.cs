using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Pro.UI.Utility;
using ProPresenter.UI.Thumbnails;
using ProPresenter.UI.Utility;
using ProPresenter.UI.ViewModels.ProContent.Asset;
using ProPresenter.UI.ViewModels.ProContent.Collection;

namespace ProPresenter.UI.ProContent;

public class ProContentThumbnailPanel : UniformViewPanel<IProContentAssetVM, ProContentAssetView>
{
	public static readonly DependencyProperty SelectAssetCommandProperty = DependencyProperty.Register("SelectAssetCommand", typeof(IAsyncRelayCommand<IProContentAssetVM>), typeof(ProContentThumbnailPanel), new PropertyMetadata((PropertyChangedCallback)null));

	private static readonly DependencyProperty ThumbnailAspectRatioProperty = DependencyProperty.Register("ThumbnailAspectRatio", typeof(double), typeof(ProContentThumbnailPanel), new PropertyMetadata((object)1.7777777777777777));

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

	public ProContentThumbnailPanel()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		base.DataContextChanged += new DependencyPropertyChangedEventHandler(ProContentThumbnailPanel_DataContextChanged);
		new DragItemWrapper<ProContentAssetView, IProContentAssetVM>(this).EnableDragging();
	}

	private void ProContentThumbnailPanel_DataContextChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		SetBinding(ThumbnailAspectRatioProperty, new Binding("ThumbnailAspectRatio")
		{
			Source = base.DataContext
		});
		SetRowCapacity();
	}

	protected override void OnSetupThumbnailControl(ProContentAssetView thumbnailControl, IProContentAssetVM item)
	{
		base.OnSetupThumbnailControl(thumbnailControl, item);
		thumbnailControl.ContentViewType = LayoutType.Grid;
	}

	protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		if (e.FindHitElement<Button>(this) == null)
		{
			ProContentAssetView? proContentAssetView = e.FindHitElement<ProContentAssetView>(this);
			IProContentAssetVM proContentAssetVM = proContentAssetView?.DataContext as IProContentAssetVM;
			if (proContentAssetView != null && proContentAssetVM != null)
			{
				SelectAssetCommand?.Invoke(proContentAssetVM);
			}
		}
		base.OnPreviewMouseLeftButtonUp(e);
	}

	protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
	{
		SetRowCapacity();
		base.OnRenderSizeChanged(sizeInfo);
	}

	private void SetRowCapacity()
	{
		ProContentAssetViewData assetViewData = LayoutType.Grid.GetAssetViewData(base.ActualWidth, ThumbnailAspectRatio);
		base.RowCapacity = assetViewData.ColumnCount;
	}
}
