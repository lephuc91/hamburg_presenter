using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.OutputConfiguration;

public class BlackMagicAlphaKeySettings : ObservableObject, IDeviceSpecificAlphaKeySettings, INotifyPropertyChanged
{
	[ObservableProperty]
	private BlackmagicAlphaKeyType _alphaKeyType;

	[ObservableProperty]
	private double _blendValue = 1.0;

	public IReadOnlyCollection<BlackmagicAlphaKeyType> SupportedAlphaKeyTypeConfigurations { get; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public BlackmagicAlphaKeyType AlphaKeyType
	{
		get
		{
			return _alphaKeyType;
		}
		set
		{
			if (!EqualityComparer<BlackmagicAlphaKeyType>.Default.Equals(_alphaKeyType, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.AlphaKeyType);
				_alphaKeyType = value;
				OnAlphaKeyTypeChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.AlphaKeyType);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public double BlendValue
	{
		get
		{
			return _blendValue;
		}
		set
		{
			if (!EqualityComparer<double>.Default.Equals(_blendValue, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.BlendValue);
				_blendValue = value;
				OnBlendValueChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.BlendValue);
			}
		}
	}

	public event System.Action? DataModified;

	public ObjectBinder<IDeviceSpecificAlphaKeySettings, IOutputDisplay.Types.IBlackmagic> Bind(IOutputDisplay.Types.IBlackmagic entity)
	{
		ObjectBinder<IDeviceSpecificAlphaKeySettings, IOutputDisplay.Types.IBlackmagic> objectBinder = new ObjectBinder<IDeviceSpecificAlphaKeySettings, IOutputDisplay.Types.IBlackmagic>(this, entity);
		objectBinder.Bind((IDeviceSpecificAlphaKeySettings l) => (l is BlackMagicAlphaKeySettings propertyChangedObject) ? propertyChangedObject.WhenPropertyChanges("AlphaKeyType").ToUnit() : Observable.Empty<Unit>(), (IOutputDisplay.Types.IBlackmagic r) => r.KeyMode.WhenValueChanges, delegate(IDeviceSpecificAlphaKeySettings l, IOutputDisplay.Types.IBlackmagic r)
		{
			r.KeyMode.Set(((BlackMagicAlphaKeySettings)l).AlphaKeyType.ToEntityKeyMode());
		}, delegate(IOutputDisplay.Types.IBlackmagic r, IDeviceSpecificAlphaKeySettings l)
		{
			BlackMagicAlphaKeySettings blackMagicAlphaKeySettings = (BlackMagicAlphaKeySettings)l;
			BlackmagicAlphaKeyType blackmagicAlphaKeyType = r.KeyMode.Value.ToBlackmagicAlphaKeyType();
			if (blackMagicAlphaKeySettings.SupportedAlphaKeyTypeConfigurations.Contains(blackmagicAlphaKeyType))
			{
				blackMagicAlphaKeySettings.AlphaKeyType = blackmagicAlphaKeyType;
			}
		}).Bind((IDeviceSpecificAlphaKeySettings l) => (l is BlackMagicAlphaKeySettings propertyChangedObject2) ? propertyChangedObject2.WhenPropertyChanges("BlendValue").ToUnit() : Observable.Empty<Unit>(), (IOutputDisplay.Types.IBlackmagic r) => r.BlendValue.WhenValueChanges, delegate(IDeviceSpecificAlphaKeySettings l, IOutputDisplay.Types.IBlackmagic r)
		{
			r.BlendValue.Set(((BlackMagicAlphaKeySettings)l).BlendValue);
		}, delegate(IOutputDisplay.Types.IBlackmagic r, IDeviceSpecificAlphaKeySettings l)
		{
			((BlackMagicAlphaKeySettings)l).BlendValue = r.BlendValue.Value;
		});
		return objectBinder;
	}

	public BlackMagicAlphaKeySettings(IReadOnlyCollection<BlackmagicAlphaKeyType> supportedAlphaKeyTypes)
	{
		if (supportedAlphaKeyTypes.Count == 0)
		{
			throw new ArgumentException("At least one option needs to be supported to allow for hardware alpha configuration", "supportedAlphaKeyTypes");
		}
		SupportedAlphaKeyTypeConfigurations = supportedAlphaKeyTypes;
		AlphaKeyType = supportedAlphaKeyTypes.First();
	}

	public void Serialize(OutputDisplay settings)
	{
		settings.Blackmagic = new OutputDisplay.Types.Blackmagic
		{
			KeyMode = AlphaKeyType.ToProtoKeyMode(),
			BlendValue = BlendValue
		};
	}

	public void Deserialize(OutputDisplay settings)
	{
		OutputDisplay.Types.Blackmagic blackmagic = settings?.Blackmagic;
		if (blackmagic != null)
		{
			BlackmagicAlphaKeyType blackmagicAlphaKeyType = blackmagic.KeyMode.ToBlackmagicAlphaKeyType();
			if (SupportedAlphaKeyTypeConfigurations.Contains(blackmagicAlphaKeyType))
			{
				AlphaKeyType = blackmagicAlphaKeyType;
			}
			BlendValue = blackmagic.BlendValue;
		}
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnAlphaKeyTypeChanged(BlackmagicAlphaKeyType value)
	{
		OnDataModified();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnBlendValueChanged(double value)
	{
		OnDataModified();
	}
}
