using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Pro.Common.Mathematics;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.UI.SlideEditor;

namespace ProPresenter.UI.FloatingHeaders;

public class PresentationSlidePreviewItemsFloatingHeader : SlidePreviewItemsFloatingHeaderControlBase<CueGroupKey>
{
	protected override void ScrollToSlide(CustomSlide slide)
	{
		if (slide == null || !base.IsLoaded || base.Items == null)
		{
			return;
		}
		bool scrollToTop = !base.IsVisible;
		CueGroupKey cueGroupKey = base.Items.FirstOrDefault((CueGroupKey i) => i.CueGroup.Cues.Select((SlideCue c) => c.SlideAction?.Slide).Contains(slide));
		ItemsControl cueGroupView;
		if (cueGroupKey != null)
		{
			cueGroupView = (ItemsControl)GetItemControl(cueGroupKey);
			ItemsControl itemsControl = cueGroupView;
			if (itemsControl != null && itemsControl.IsLoaded)
			{
				findContainer();
				return;
			}
			cueGroupView.Loaded += onCueGroupViewLoaded;
			ScrollIntoView(cueGroupKey, 0.0, null, scrollToTop: true);
		}
		void findContainer()
		{
			FrameworkElement container = (FrameworkElement)(object)cueGroupView.ItemContainerGenerator.ContainerFromItem(cueGroupView.ItemContainerGenerator.Items.OfType<SlideCue>().FirstOrDefault((SlideCue t) => t?.SlideAction?.Slide == slide));
			if (container != null)
			{
				if (container.IsLoaded)
				{
					scrollToTarget();
				}
				else
				{
					container.Loaded += onContainerLoaded;
				}
			}
			void onContainerLoaded(object? sender, RoutedEventArgs e)
			{
				container.Loaded -= onContainerLoaded;
				scrollToTarget();
			}
			void scrollToTarget()
			{
				//IL_0021: Unknown result type (might be due to invalid IL or missing references)
				//IL_0031: Unknown result type (might be due to invalid IL or missing references)
				//IL_0036: Unknown result type (might be due to invalid IL or missing references)
				PresentationSlidePreviewItemsFloatingHeader presentationSlidePreviewItemsFloatingHeader = this;
				CueGroupKey item = cueGroupKey;
				Point val = container.TranslatePoint(Vector2<double>.Zero, cueGroupView);
				presentationSlidePreviewItemsFloatingHeader.OnScrollIntoView(item, ((Point)(ref val)).Y, container.ActualHeight, scrollToTop);
			}
		}
		void onCueGroupViewLoaded(object? sender, RoutedEventArgs e)
		{
			cueGroupView.Loaded -= onCueGroupViewLoaded;
			findContainer();
		}
	}
}
