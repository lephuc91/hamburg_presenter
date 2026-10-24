using System;
using Pro.Common.Components;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.OutputConfiguration;

public class BlendScreen : LinkedNotifyPropertyChangedBase
{
	private double _gamma;

	private double _radius = 1.0;

	private double _intensity = 1.0;

	private BlendMode _mode;

	public Screen Screen { get; }

	public double Gamma
	{
		get
		{
			return _gamma;
		}
		set
		{
			SetValue("Gamma", ref _gamma, value, OnDataModified);
		}
	}

	public double Radius
	{
		get
		{
			return _radius;
		}
		set
		{
			SetValue("Radius", ref _radius, value, OnDataModified);
		}
	}

	public double Intensity
	{
		get
		{
			return _intensity;
		}
		set
		{
			SetValue("Intensity", ref _intensity, value, OnDataModified);
		}
	}

	public BlendMode BlendMode
	{
		get
		{
			return _mode;
		}
		set
		{
			SetValue("BlendMode", ref _mode, value, OnDataModified);
		}
	}

	public event Action<BlendScreen>? DataModified;

	public ObjectBinder<BlendScreen, IEdgeBlend.Types.IScreen> Bind(IEdgeBlend.Types.IScreen right)
	{
		ObjectBinder<BlendScreen, IEdgeBlend.Types.IScreen> objectBinder = new ObjectBinder<BlendScreen, IEdgeBlend.Types.IScreen>(this, right);
		objectBinder.Bind((BlendScreen l) => l.Screen.WhenPropertyChanges("ID"), (IEdgeBlend.Types.IScreen r) => r.Uuid.WhenValueChanges, delegate(BlendScreen l, IEdgeBlend.Types.IScreen r)
		{
			r.Uuid.Set(l.Screen.ID);
		}, delegate(IEdgeBlend.Types.IScreen r, BlendScreen l)
		{
			l.Screen.SetId(r.Uuid.Value);
		}).Bind((BlendScreen l) => l.WhenPropertyChanges("Gamma"), (IEdgeBlend.Types.IScreen r) => r.Gamma.WhenValueChanges, delegate(BlendScreen l, IEdgeBlend.Types.IScreen r)
		{
			r.Gamma.Set(l.Gamma);
		}, delegate(IEdgeBlend.Types.IScreen r, BlendScreen l)
		{
			l.Gamma = r.Gamma.Value;
		}).Bind((BlendScreen l) => l.WhenPropertyChanges("Radius"), (IEdgeBlend.Types.IScreen r) => r.Radius.WhenValueChanges, delegate(BlendScreen l, IEdgeBlend.Types.IScreen r)
		{
			r.Radius.Set(l.Radius);
		}, delegate(IEdgeBlend.Types.IScreen r, BlendScreen l)
		{
			l.Radius = r.Radius.Value;
		})
			.Bind((BlendScreen l) => l.WhenPropertyChanges("Intensity"), (IEdgeBlend.Types.IScreen r) => r.Intensity.WhenValueChanges, delegate(BlendScreen l, IEdgeBlend.Types.IScreen r)
			{
				r.Intensity.Set(l.Intensity);
			}, delegate(IEdgeBlend.Types.IScreen r, BlendScreen l)
			{
				l.Intensity = r.Intensity.Value;
			})
			.Bind((BlendScreen l) => l.WhenPropertyChanges("BlendMode"), (IEdgeBlend.Types.IScreen r) => r.Mode.WhenValueChanges, delegate(BlendScreen l, IEdgeBlend.Types.IScreen r)
			{
				r.Mode.Set(l.BlendMode.ToEntityEdgeBlendMode());
			}, delegate(IEdgeBlend.Types.IScreen r, BlendScreen l)
			{
				l.BlendMode = r.Mode.Value.ToBlendMode();
			});
		return objectBinder;
	}

	public BlendScreen(Screen screen)
	{
		Screen = screen;
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke(this);
	}

	protected internal EdgeBlend.Types.Screen Serialize()
	{
		return new EdgeBlend.Types.Screen
		{
			Uuid = Screen.ID.ToUUID(),
			Gamma = Gamma,
			Radius = Radius,
			Intensity = Intensity,
			Mode = BlendMode.ToProtoEdgeBlendMode()
		};
	}

	protected internal void Deserialize(EdgeBlend.Types.Screen? blendScreen)
	{
		if (blendScreen != null)
		{
			Gamma = blendScreen.Gamma;
			Radius = blendScreen.Radius;
			Intensity = blendScreen.Intensity;
			BlendMode = blendScreen.Mode.ToBlendMode();
		}
	}
}
