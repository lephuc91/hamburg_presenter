using Pro.Common.Collections;
using Pro.DO.Triggering;
using ProPresenter.DO.Themes;

namespace ProPresenter.UI.SlideEditor;

public class TemplateSlideContainer : SlideContainerBase
{
	private readonly TemplateSlide _template;

	public override string Name
	{
		get
		{
			return _template.Name;
		}
		set
		{
			_template.Name = value;
		}
	}

	public INotifyEnumerableChanged<IAction> Actions => _template.Actions;

	public TemplateSlideContainer(TemplateSlide template)
		: base(template.Slide)
	{
		_template = template;
		LinkProperties("Name", "Name");
		_template.PropertyChanged += base.RaiseLinkedValues;
	}
}
