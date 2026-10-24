using ProPresenter.DO.WhatsNew;
using ProPresenter.UI.ViewModels.WhatsNew;

namespace ProPresenter.WhatsNew;

public interface IFeatureFactory
{
	IFeatureItemVM Create(IFeatureItem featureItem);
}
