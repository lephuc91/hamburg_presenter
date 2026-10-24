using ProPresenter.DO.WhatsNew.Model;

namespace ProPresenter.DO.WhatsNew;

public interface IFeatureItem
{
	string ImageName { get; set; }

	string Title { get; set; }

	string Description { get; set; }

	FeatureLink? FeatureLink { get; set; }
}
