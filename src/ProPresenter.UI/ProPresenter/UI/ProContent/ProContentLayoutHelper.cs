using System;
using System.Windows;
using Pro.Common.Mathematics;
using ProPresenter.UI.ViewModels.ProContent.Collection;

namespace ProPresenter.UI.ProContent;

public static class ProContentLayoutHelper
{
	private const double CAROUSELSMALL_MAX_IMAGE_PREVIEW_WIDTH = 240.0;

	private const double CAROUSELLARGE_MAX_IMAGE_PREVIEW_WIDTH = 360.0;

	private const int MIN_CAROUSELSMALL_COLUMN_COUNT = 3;

	private const int MIN_CAROUSELLARGE_COLUMN_COUNT = 2;

	public static readonly Thickness COLLECTION_MARGIN = new Thickness(30.0, 0.0, 30.0, 0.0);

	public static ProContentAssetViewData GetAssetViewData(this LayoutType layoutType, double availableWidth, double aspectRatio)
	{
		double num = ((layoutType == LayoutType.CarouselLarge) ? 360.0 : 240.0);
		double num2 = ProContentAssetList.THUMBNAIL_MARGIN.Left + ProContentAssetList.THUMBNAIL_MARGIN.Right;
		availableWidth = Math.Max(0.0, availableWidth - (COLLECTION_MARGIN.Left + COLLECTION_MARGIN.Right));
		double num3 = num + num2;
		int num4 = (int)Math.Max((layoutType == LayoutType.CarouselLarge) ? 2 : 3, Math.Ceiling(availableWidth / num3));
		double num5 = Math.Max(0.0, availableWidth / (double)num4 - num2);
		double y = num5 / aspectRatio;
		return new ProContentAssetViewData(num4, new Vector2<double>(num5, y));
	}
}
