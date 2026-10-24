using Pro.DO.Label;

namespace ProPresenter.DO.Slide.Links;

public interface ISlideLabelInfo
{
	ILabel? Current { get; }

	ILabel? Next { get; }
}
