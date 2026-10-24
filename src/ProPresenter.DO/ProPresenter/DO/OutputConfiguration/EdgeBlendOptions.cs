using System;
using System.Diagnostics.CodeAnalysis;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.OutputConfiguration;

public class EdgeBlendOptions : NotifyPropertyChangedBase
{
	private double _width = 200.0;

	private BlendScreen _firstScreen;

	private BlendScreen _secondScreen;

	public double Width
	{
		get
		{
			return _width;
		}
		set
		{
			SetValue("Width", ref _width, value, (Action<double, double>?)delegate
			{
				this.WidthChanged?.Invoke();
				OnEdgeBlendChanged();
			}, (Predicate<double>?)null, referenceComparison: false);
		}
	}

	public double MaxWidth => Math.Min(FirstScreen.Screen.Bounds.Size.X, SecondScreen.Screen.Bounds.Size.X);

	public BlendScreen FirstScreen
	{
		get
		{
			return _firstScreen;
		}
		[MemberNotNull("_firstScreen")]
		set
		{
			SetValue("FirstScreen", ref _firstScreen, value, (Action<BlendScreen, BlendScreen>?)delegate
			{
				OnEdgeBlendChanged();
			}, (Predicate<BlendScreen>?)null, referenceComparison: false);
		}
	}

	public BlendScreen SecondScreen
	{
		get
		{
			return _secondScreen;
		}
		[MemberNotNull("_secondScreen")]
		set
		{
			SetValue("SecondScreen", ref _secondScreen, value, (Action<BlendScreen, BlendScreen>?)delegate
			{
				OnEdgeBlendChanged();
			}, (Predicate<BlendScreen>?)null, referenceComparison: false);
		}
	}

	internal event System.Action? WidthChanged;

	public event Action<EdgeBlendOptions>? EdgeBlendChanged;

	public ObjectBinder<EdgeBlendOptions, IEdgeBlend> Bind(IEntityFactory entityFactory, IEdgeBlend right)
	{
		ObjectBinder<EdgeBlendOptions, IEdgeBlend> objectBinder = new ObjectBinder<EdgeBlendOptions, IEdgeBlend>(this, right);
		objectBinder.Bind((EdgeBlendOptions l) => l.WhenPropertyChanges("FirstScreen"), (IEdgeBlend r) => r.FirstScreen.WhenValueChanges, delegate(EdgeBlendOptions l, IEdgeBlend r)
		{
			IEdgeBlend.Types.IScreen screen = entityFactory.Create<IEdgeBlend.Types.IScreen>();
			ObjectBinder<BlendScreen, IEdgeBlend.Types.IScreen> objectBinder2 = l.FirstScreen.Bind(screen);
			objectBinder2.InitializeRightFromLeft();
			screen.RegisterLinkedDisposable(objectBinder2);
			r.FirstScreen.Set(screen);
			r.Uuid.Set(l.FirstScreen.Screen.ID);
		}, delegate(IEdgeBlend r, EdgeBlendOptions l)
		{
			ObjectBinder<BlendScreen, IEdgeBlend.Types.IScreen> objectBinder3 = l.FirstScreen.Bind(r.FirstScreen.Value);
			objectBinder3.InitializeLeftFromRight();
			r.FirstScreen.Value.RegisterLinkedDisposable(objectBinder3);
		}).Bind((EdgeBlendOptions l) => l.WhenPropertyChanges("SecondScreen"), (IEdgeBlend r) => r.SecondScreen.WhenValueChanges, delegate(EdgeBlendOptions l, IEdgeBlend r)
		{
			IEdgeBlend.Types.IScreen screen2 = entityFactory.Create<IEdgeBlend.Types.IScreen>();
			ObjectBinder<BlendScreen, IEdgeBlend.Types.IScreen> objectBinder4 = l.SecondScreen.Bind(screen2);
			objectBinder4.InitializeRightFromLeft();
			screen2.RegisterLinkedDisposable(objectBinder4);
			r.SecondScreen.Set(screen2);
		}, delegate(IEdgeBlend r, EdgeBlendOptions l)
		{
			ObjectBinder<BlendScreen, IEdgeBlend.Types.IScreen> objectBinder5 = l.SecondScreen.Bind(r.SecondScreen.Value);
			objectBinder5.InitializeLeftFromRight();
			r.SecondScreen.Value.RegisterLinkedDisposable(objectBinder5);
		}).DoOnInitializeLeftFromRight(delegate
		{
			Width = FirstScreen.Screen.Bounds.Right - SecondScreen.Screen.Bounds.Left;
		});
		return objectBinder;
	}

	public EdgeBlendOptions(BlendScreen firstScreen, BlendScreen secondScreen)
	{
		FirstScreen = firstScreen;
		FirstScreen.DataModified += delegate
		{
			OnEdgeBlendChanged();
		};
		SecondScreen = secondScreen;
		SecondScreen.DataModified += delegate
		{
			OnEdgeBlendChanged();
		};
	}

	protected internal EdgeBlend Serialize()
	{
		return new EdgeBlend
		{
			LeftScreen = FirstScreen.Serialize(),
			RightScreen = SecondScreen.Serialize(),
			Uuid = FirstScreen.Screen.ID.ToUUID()
		};
	}

	protected internal void Deserialize(EdgeBlend protoEdgeBlend)
	{
		if (protoEdgeBlend.FirstScreen != null || protoEdgeBlend.SecondScreen != null)
		{
			FirstScreen.Deserialize(protoEdgeBlend.FirstScreen);
			SecondScreen.Deserialize(protoEdgeBlend.SecondScreen);
			if (FirstScreen != null && SecondScreen != null)
			{
				BlendScreen firstScreen = FirstScreen;
				double radius = (SecondScreen.Radius = protoEdgeBlend.Radius.ToFeatureRange(0.0, 100.0));
				firstScreen.Radius = radius;
				BlendScreen firstScreen2 = FirstScreen;
				radius = (SecondScreen.Intensity = protoEdgeBlend.Intensity.ToFeatureRange(0.0, 100.0));
				firstScreen2.Intensity = radius;
				BlendScreen firstScreen3 = FirstScreen;
				BlendMode blendMode2 = (SecondScreen.BlendMode = protoEdgeBlend.Mode.ToBlendMode());
				firstScreen3.BlendMode = blendMode2;
			}
		}
		else
		{
			FirstScreen.Deserialize(protoEdgeBlend.LeftScreen);
			SecondScreen.Deserialize(protoEdgeBlend.RightScreen);
		}
	}

	protected void OnEdgeBlendChanged()
	{
		this.EdgeBlendChanged?.Invoke(this);
	}
}
