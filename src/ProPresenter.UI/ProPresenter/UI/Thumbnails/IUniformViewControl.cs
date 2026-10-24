using ProPresenter.DO;
using ProPresenter.DO.PanelSourcing;

namespace ProPresenter.UI.Thumbnails;

public interface IUniformViewControl
{
	int Index { get; set; }

	IUniformViewSource? Source { get; set; }

	bool IsSelected { get; set; }

	IPanelViewSettings? ViewSettings { get; set; }

	void TearDown();
}
