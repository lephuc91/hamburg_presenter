using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Components;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.UI.ViewModels.OutputConfiguration;

namespace ProPresenter.ViewModels.OutputConfiguration;

public class BlackmagicHardwareAlphaConfigurationVM : LinkedNotifyPropertyChangedBase, IBlackmagicHardwareAlphaConfigurationVM, IHardwareAlphaConfigurationVM, INotifyPropertyChanged
{
	private readonly BlackMagicAlphaKeySettings _bmSettings;

	public ProPresenter.UI.ViewModels.OutputConfiguration.BlackmagicAlphaKeyType AlphaKeyType
	{
		get
		{
			return _bmSettings.AlphaKeyType.ToViewModelType();
		}
		set
		{
			_bmSettings.AlphaKeyType = value.ToDataObjectType();
		}
	}

	public double BlendValue
	{
		get
		{
			return _bmSettings.BlendValue;
		}
		set
		{
			_bmSettings.BlendValue = value;
		}
	}

	public IEnumerable<ProPresenter.UI.ViewModels.OutputConfiguration.BlackmagicAlphaKeyType> SupportedAlphaKeyTypes => _bmSettings.SupportedAlphaKeyTypeConfigurations.Select((ProPresenter.DO.OutputConfiguration.BlackmagicAlphaKeyType v) => v.ToViewModelType());

	public BlackmagicHardwareAlphaConfigurationVM(BlackMagicAlphaKeySettings bmSettings)
	{
		_bmSettings = bmSettings;
		LinkProperties("AlphaKeyType", "AlphaKeyType");
		LinkProperties("BlendValue", "BlendValue");
		_bmSettings.PropertyChanged += base.RaiseLinkedValues;
	}
}
