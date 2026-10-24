using System.Linq;
using System.Windows.Media.Imaging;
using Pro.Common.Mathematics;
using ProPresenter.DO.Cues;
using ProPresenter.Rendering;
using ProPresenter.UI.SlideQuickEdit;
using ProPresenter.ViewModels.QuickEdit;

namespace ProPresenter.ViewModels;

public class QuickEditPrompt : IQuickEditPrompt
{
	private readonly QuickEditVM _vm;

	private QuickEditWindow? _quickEditWindow;

	public QuickEditPrompt(QuickEditVM quickEditVM)
	{
		_vm = quickEditVM;
	}

	public void Hide()
	{
		_quickEditWindow?.Close();
	}

	public void Show(Vector2<double> position)
	{
		if (_quickEditWindow != null)
		{
			_quickEditWindow.Close();
		}
		SlidePreviewRenderParams renderParams = new SlidePreviewRenderParams(_vm.TargetContainerSize.Cast<int>(), _vm.SlideCue.GetIncludeBackground(), IncludeBackgroundMedia: true, _vm.BackgroundColor, ElementsRenderOption.ExcludeText, _vm.Slide?.Elements.ToArray());
		BitmapSource bitmapSource = SlidePreviewRenderer.RenderSlidePreview(_vm.Slide, renderParams).BitmapSource;
		_quickEditWindow = new QuickEditWindow
		{
			DataContext = _vm
		};
		_quickEditWindow.Show();
		_quickEditWindow.UpdateContent(position, bitmapSource);
	}
}
