using System.ComponentModel;
using System.Linq;
using Pro.Common.Components;
using ProPresenter.DO;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels;

public class UtilityViewVM : LinkedNotifyPropertyChangedBase, IUtilityViewVM, INotifyPropertyChanged
{
	private bool _ignoreCollectionChanged;

	private readonly IApp _app;

	public UtilityViewType SelectedViewType
	{
		get
		{
			return _app.SelectedUtilityView;
		}
		set
		{
			_app.SelectedUtilityView = value;
			value.Publish();
		}
	}

	public UtilityViewTypeCollection UtilityViewTabs { get; }

	public UtilityViewVM(IApp app)
	{
		_app = app;
		UtilityViewTabs = new UtilityViewTypeCollection(_app.UtilityViewTabs);
		LinkProperties("SelectedUtilityView", "SelectedViewType");
		LinkAction("UtilityViewTabs", delegate
		{
			if (!_ignoreCollectionChanged)
			{
				UtilityViewTabs.Reset(_app.UtilityViewTabs);
			}
		});
		_app.PropertyChanged += base.RaiseLinkedValues;
		UtilityViewTabs.CollectionChanged += delegate
		{
			_ignoreCollectionChanged = true;
			_app.UtilityViewTabs = UtilityViewTabs.ToList();
			_ignoreCollectionChanged = false;
		};
	}
}
