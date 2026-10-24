using ProPresenter.DO.Props;

namespace ProPresenter.DO.Presentation;

public class PropsRepo : IPropsRepo
{
	public IPropCueCollection Props => DataVault.PropCueCollection;
}
