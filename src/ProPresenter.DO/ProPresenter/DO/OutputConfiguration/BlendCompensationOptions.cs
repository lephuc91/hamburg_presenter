using System;
using Pro.Common.Components;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.OutputConfiguration;

public class BlendCompensationOptions : LinkedNotifyPropertyChangedBase, ICloneable<BlendCompensationOptions>
{
	private double _blackLevel;

	public double BlackLevel
	{
		get
		{
			return _blackLevel;
		}
		set
		{
			SetValue("BlackLevel", ref _blackLevel, value, OnBlendCompensationChanged);
		}
	}

	public event Action<BlendCompensationOptions>? BlendCompensationChanged;

	public ObjectBinder<BlendCompensationOptions, IScreen.Types.IBlendCompensation> Bind(IScreen.Types.IBlendCompensation right)
	{
		ObjectBinder<BlendCompensationOptions, IScreen.Types.IBlendCompensation> objectBinder = new ObjectBinder<BlendCompensationOptions, IScreen.Types.IBlendCompensation>(this, right);
		objectBinder.Bind((BlendCompensationOptions l) => l.WhenPropertyChanges("BlackLevel"), (IScreen.Types.IBlendCompensation r) => r.BlackLevel.WhenValueChanges, delegate(BlendCompensationOptions l, IScreen.Types.IBlendCompensation r)
		{
			r.BlackLevel.Set(l.BlackLevel);
		}, delegate(IScreen.Types.IBlendCompensation r, BlendCompensationOptions l)
		{
			l.BlackLevel = r.BlackLevel.Value;
		});
		return objectBinder;
	}

	private void OnBlendCompensationChanged()
	{
		this.BlendCompensationChanged?.Invoke(this);
	}

	protected internal Pro.SerializationInterop.RVProtoData.Screen.Types.BlendCompensation Serialize()
	{
		return new Pro.SerializationInterop.RVProtoData.Screen.Types.BlendCompensation
		{
			BlackLevel = BlackLevel
		};
	}

	protected internal void Deserialize(Pro.SerializationInterop.RVProtoData.Screen.Types.BlendCompensation blendCompensation)
	{
		if (blendCompensation != null)
		{
			BlackLevel = blendCompensation.BlackLevel;
		}
	}

	public BlendCompensationOptions Clone()
	{
		return new BlendCompensationOptions
		{
			BlackLevel = BlackLevel
		};
	}
}
