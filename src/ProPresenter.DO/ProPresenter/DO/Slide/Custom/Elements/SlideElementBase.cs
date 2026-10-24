using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Transitions;
using Pro.DO.Utility;
using Pro.Editor;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Slide.Builds;
using ProPresenter.DO.Slide.Links;

namespace ProPresenter.DO.Slide.Custom.Elements;

public abstract class SlideElementBase : SimpleCanvasElement, IRenderEquatable<SlideElementBase>, IRenderHashable, ICloneable<SlideElementBase>, IHasMediaContainerId, ICanReceiveMediaContainerIdUpdates
{
	private UndoStack? _undoStack;

	private string _name = string.Empty;

	private ICanvasElement? _canvasParent;

	private double _opacity = 1.0;

	private bool _isLocked;

	private bool _isHidden;

	private bool _isAspectRatioLocked;

	private int _zOrder;

	private ElementFlipMode _flipMode;

	private Build? _buildIn;

	private Build? _buildOut;

	private RevealType _revealType;

	private AdditionalInfo _additionalInfo;

	private VisibilityLink _visibilityLink;

	private string InternalName => _name;

	public Guid ID { get; protected set; } = Guid.NewGuid();

	public abstract SlideElementType ElementType { get; }

	public override ICanvasElement? CanvasParent => _canvasParent;

	public UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			_undoStack = value;
			UndoStackChanged(_undoStack);
		}
	}

	public bool IsLinkedDataResolved { get; private set; }

	public bool IsFromTemplate
	{
		get
		{
			return AdditionalInfo.HasFlag(AdditionalInfo.Template);
		}
		set
		{
			if (value)
			{
				AdditionalInfo |= AdditionalInfo.Template;
			}
			else
			{
				AdditionalInfo &= ~AdditionalInfo.Template;
			}
		}
	}

	protected abstract string DisplayName { get; }

	public AdditionalInfo AdditionalInfo
	{
		get
		{
			return _additionalInfo;
		}
		protected set
		{
			_additionalInfo = value;
			OnDataModified();
		}
	}

	public string Name
	{
		get
		{
			if (!string.IsNullOrEmpty(_name))
			{
				return _name;
			}
			return DisplayName;
		}
		set
		{
			SetValue("Name", ref _name, value, delegate(string o, string n)
			{
				OnVisualInvalidated();
				OnPropertyChanged("InternalName");
				UndoStack?.Commit(UndoActionTypes.ElementName.ToAction(), this, "Name", o, n);
			});
		}
	}

	public double Opacity
	{
		get
		{
			return _opacity;
		}
		set
		{
			value = value.Clamp(0.0, 1.0);
			SetValue("Opacity", ref _opacity, value, delegate(double o, double n)
			{
				OnVisualInvalidated();
				UndoStack?.Commit(UndoActionTypes.ElementOpacity.ToAction(), this, "Opacity", o, n);
			});
		}
	}

	public sealed override bool IsLocked
	{
		get
		{
			return _isLocked;
		}
		set
		{
			SetValue("IsLocked", ref _isLocked, value, delegate(bool o, bool n)
			{
				UndoStack?.Commit(UndoActionTypes.ElementLocked.ToAction(), this, "IsLocked", o, n);
			});
		}
	}

	public sealed override bool IsHidden
	{
		get
		{
			return _isHidden;
		}
		set
		{
			SetValue("IsHidden", ref _isHidden, value, delegate(bool o, bool n)
			{
				UndoStack?.Commit(UndoActionTypes.ElementHidden.ToAction(), this, "IsHidden", o, n);
				OnPropertyChanged("IsLocked");
				OnPropertyChanged("IsSelectable");
				OnVisualInvalidated();
			});
		}
	}

	public sealed override bool IsSelectable => !IsHidden;

	public sealed override bool IsAspectRatioLocked
	{
		get
		{
			return _isAspectRatioLocked;
		}
		set
		{
			SetValue("IsAspectRatioLocked", ref _isAspectRatioLocked, value, delegate(bool o, bool n)
			{
				UndoStack?.Commit(UndoActionTypes.ElementAspectRatioLocked.ToAction(), this, "IsAspectRatioLocked", o, n);
			});
		}
	}

	public ElementFlipMode FlipMode
	{
		get
		{
			return _flipMode;
		}
		set
		{
			SetValue("FlipMode", ref _flipMode, value, delegate(ElementFlipMode o, ElementFlipMode n)
			{
				OnVisualInvalidated();
				UndoStack?.Commit(UndoActionTypes.ElementFlip.ToAction(), this, "FlipMode", o, n, null, null, autoFinalize: true);
			});
		}
	}

	public override int ZOrder
	{
		get
		{
			return _zOrder;
		}
		set
		{
			SetValue("ZOrder", ref _zOrder, value, delegate(int o, int n)
			{
				OnVisualInvalidated();
				UndoStack?.Commit(UndoActionTypes.ElementZOrder.ToAction(), this, "ZOrder", o, n);
			});
		}
	}

	public VisibilityLink VisibilityLink
	{
		get
		{
			return _visibilityLink;
		}
		[MemberNotNull("_visibilityLink")]
		private set
		{
			SetValue("VisibilityLink", ref _visibilityLink, value, delegate(VisibilityLink o, VisibilityLink n)
			{
				if (o != null)
				{
					o.LinkObjectUpdated -= VisibilityLink_LinkObjectUpdated;
				}
				if (n != null)
				{
					n.LinkObjectUpdated += VisibilityLink_LinkObjectUpdated;
				}
			});
		}
	}

	public Build? BuildIn
	{
		get
		{
			return _buildIn;
		}
		set
		{
			SetValue<Build>("BuildIn", ref _buildIn, value, delegate(Build o, Build n)
			{
				UndoStack?.Commit(UndoActionTypes.AddBuildIn.ToAction(), this, "BuildIn", o, n);
				if (o != null)
				{
					o.DataModified -= OnDataModified;
				}
				OnDataModified();
				if (n != null)
				{
					n.DataModified += OnDataModified;
				}
				OnBuildInChanged(o, n);
			});
		}
	}

	public Build? BuildOut
	{
		get
		{
			return _buildOut;
		}
		set
		{
			SetValue<Build>("BuildOut", ref _buildOut, value, delegate(Build o, Build n)
			{
				UndoStack?.Commit(UndoActionTypes.AddBuildOut.ToAction(), this, "BuildOut", o, n);
				if (o != null)
				{
					o.DataModified -= OnDataModified;
				}
				OnDataModified();
				if (n != null)
				{
					n.DataModified += OnDataModified;
				}
				OnBuildOutChanged(o, n);
			});
		}
	}

	public virtual IEnumerable<IBuild> AllBuilds => new Build[2] { BuildIn, BuildOut }.NonNull();

	public RevealType RevealType
	{
		get
		{
			return _revealType;
		}
		set
		{
			SetValue("RevealType", ref _revealType, value, delegate(RevealType o, RevealType n)
			{
				UndoStack?.Commit(UndoActionTypes.ElementRevealType.ToAction(), this, "RevealType", o, n);
				OnDataModified();
				OnRevealTypeChanged(o, n);
			});
		}
	}

	public virtual int RevealCount => 0;

	public Func<Vector2<double>, System.Windows.Media.Color>? BacklightSampler { get; protected internal set; }

	public string ContainerId { get; protected set; } = "";

	public event Action<SlideElementBase>? DataModified;

	public static ObjectBinder<T, IGraphics.Types.IElement> Bind<T>(IUiScheduler uiScheduler, T left, IGraphics.Types.IElement right) where T : SlideElementBase
	{
		ObjectBinder<T, IGraphics.Types.IElement> objectBinder = new ObjectBinder<T, IGraphics.Types.IElement>(left, right);
		objectBinder.Bind((T l) => l.WhenPropertyChanges("ID"), (IGraphics.Types.IElement r) => r.Uuid.WhenValueChanges, delegate(T l, IGraphics.Types.IElement r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(IGraphics.Types.IElement r, T l)
		{
			l.ID = r.Uuid.Value;
		}).Bind((T l) => l.WhenPropertyChanges("InternalName"), (IGraphics.Types.IElement r) => r.Name.WhenValueChanges, delegate(T l, IGraphics.Types.IElement r)
		{
			r.Name.Set(l.InternalName);
		}, delegate(IGraphics.Types.IElement r, T l)
		{
			l.SetValue("Name", ref l._name, r.Name.Value, (Action<string, string>?)delegate
			{
				l.OnVisualInvalidated();
			}, (Predicate<string>?)null, referenceComparison: false);
		}).Bind((T l) => l.WhenPropertyChanges("Opacity"), (IGraphics.Types.IElement r) => r.Opacity.WhenValueChanges, delegate(T l, IGraphics.Types.IElement r)
		{
			r.Opacity.Set(l.Opacity);
		}, delegate(IGraphics.Types.IElement r, T l)
		{
			l.SetValue("Opacity", ref l._opacity, Math.Clamp(r.Opacity.Value, 0.0, 1.0), (Action<double, double>?)delegate
			{
				l.OnVisualInvalidated();
			}, (Predicate<double>?)null, referenceComparison: false);
		})
			.Bind((T l) => l.WhenPropertyChanges("IsLocked"), (IGraphics.Types.IElement r) => r.Locked.WhenValueChanges, delegate(T l, IGraphics.Types.IElement r)
			{
				r.Locked.Set(l.IsLocked);
			}, delegate(IGraphics.Types.IElement r, T l)
			{
				l.SetValue("IsLocked", ref l._isLocked, r.Locked.Value);
			})
			.Bind((T l) => l.WhenPropertyChanges("IsHidden"), (IGraphics.Types.IElement r) => r.Hidden.WhenValueChanges, delegate(T l, IGraphics.Types.IElement r)
			{
				r.Hidden.Set(l.IsHidden);
			}, delegate(IGraphics.Types.IElement r, T l)
			{
				l.SetValue("IsHidden", ref l._isHidden, r.Hidden.Value, (Action<bool, bool>?)delegate
				{
					l.OnPropertyChanged("IsLocked");
					l.OnPropertyChanged("IsSelectable");
					l.OnVisualInvalidated();
				}, (Predicate<bool>?)null, referenceComparison: false);
			})
			.Bind((T l) => l.WhenPropertyChanges("FlipMode"), (IGraphics.Types.IElement r) => r.FlipMode.WhenValueChanges, delegate(T l, IGraphics.Types.IElement r)
			{
				r.FlipMode.Set(l.FlipMode.ToEntityFlipMode());
			}, delegate(IGraphics.Types.IElement r, T l)
			{
				l.SetValue("FlipMode", ref l._flipMode, r.FlipMode.Value.ToFlipMode(), (Action<ElementFlipMode, ElementFlipMode>?)delegate
				{
					l.OnVisualInvalidated();
				}, (Predicate<ElementFlipMode>?)null, referenceComparison: false);
			})
			.Bind((T l) => l.WhenPropertyChanges("IsAspectRatioLocked").Merge(l.WhenPropertyChanges("IsAspectRatioLockForced")), (IGraphics.Types.IElement r) => r.AspectRatioLocked.WhenValueChanges, delegate(T l, IGraphics.Types.IElement r)
			{
				r.AspectRatioLocked.Set(l.IsAspectRatioLocked || l.IsAspectRatioLockForced);
			}, delegate(IGraphics.Types.IElement r, T l)
			{
				l.SetValue("IsAspectRatioLocked", ref l._isAspectRatioLocked, r.AspectRatioLocked.Value);
			});
		return objectBinder;
	}

	protected SlideElementBase()
	{
		LinkAction(new global::_003C_003Ez__ReadOnlyArray<string>(new string[10] { "Position", "Size", "Rotation", "Name", "Opacity", "IsLocked", "IsHidden", "IsAspectRatioLocked", "FlipMode", "ZOrder" }), OnDataModified);
		LinkProperties("DisplayName", "Name");
		base.PropertyChanged += base.RaiseLinkedValues;
		VisibilityLink = new VisibilityLink();
	}

	public virtual bool RenderEquals([NotNullWhen(true)] SlideElementBase? other)
	{
		if (other != null && Position == other.Position && Size == other.Size && Rotation == other.Rotation && _name == other._name && _opacity == other._opacity && _isLocked == other._isLocked && _isHidden == other._isHidden && _zOrder == other._zOrder && _flipMode == other._flipMode && (_buildIn?.RenderEquals(other._buildIn) ?? (_buildIn == other._buildIn)) && (_buildOut?.RenderEquals(other._buildOut) ?? (_buildOut == other._buildOut)) && _revealType == other._revealType && _additionalInfo == other._additionalInfo)
		{
			return VisibilityLink.RenderEquals(other.VisibilityLink);
		}
		return false;
	}

	public virtual int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(Position, Size, Rotation, _name, _opacity, _isLocked, _isHidden, _zOrder, _flipMode, _buildIn, _buildOut, _revealType, _additionalInfo, VisibilityLink);
	}

	internal void SetCanvasParent(ICanvasElement? parent)
	{
		_canvasParent = parent;
	}

	public abstract SlideElementBase Clone();

	internal SlideElementBase CloneWithID()
	{
		SlideElementBase slideElementBase = Clone();
		slideElementBase.ID = ID;
		return slideElementBase;
	}

	protected virtual void OnUndoStackChanged(UndoStack? undoStack)
	{
	}

	private void UndoStackChanged(UndoStack? undoStack)
	{
		if (VisibilityLink != null)
		{
			VisibilityLink.UndoStack = undoStack;
		}
		OnUndoStackChanged(undoStack);
	}

	public void ResolveLinkedData(ILinkData? linkData)
	{
		UndoStack?.StartIgnoring();
		OnResolveLinkedData(linkData);
		IsLinkedDataResolved = true;
		UndoStack?.StopIgnoring();
	}

	protected virtual void OnResolveLinkedData(ILinkData? linkData)
	{
	}

	protected internal virtual Pro.SerializationInterop.RVProtoData.Slide.Types.Element Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Slide.Types.Element element = new Pro.SerializationInterop.RVProtoData.Slide.Types.Element
		{
			Element_ = SerializeElement(),
			BuildIn = BuildIn?.Serialize(),
			BuildOut = BuildOut?.Serialize(),
			RevealType = RevealType.ToProtoTextRevealType(),
			Info = (uint)AdditionalInfo,
			TextScroller = SerializeTextScroller()
		};
		VisibilityLink visibilityLink = VisibilityLink;
		if (visibilityLink != null && visibilityLink.IsEnabled)
		{
			element.DataLinks.Add(VisibilityLink.Serialize());
		}
		return element;
	}

	private Graphics.Types.Element SerializeElement()
	{
		return new Graphics.Types.Element
		{
			Uuid = ID.ToUUID(),
			Name = _name,
			Bounds = new Rect<double>(Position, Size).ToProtoRect(),
			Rotation = Rotation.ToProtoAngle(),
			Opacity = Opacity,
			Locked = IsLocked,
			Hidden = IsHidden,
			FlipMode = FlipMode.ToProtoFlipMode(),
			AspectRatioLocked = (IsAspectRatioLocked || IsAspectRatioLockForced),
			Path = SerializePath(),
			Fill = SerializeFill(),
			Stroke = SerializeStroke(),
			Shadow = SerializeShadow(),
			Feather = SerializeFeather(),
			Text = SerializeText(),
			TextLineMask = SerializeLineFillMask()
		};
	}

	protected virtual Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextScroller? SerializeTextScroller()
	{
		return null;
	}

	protected virtual Graphics.Types.Path? SerializePath()
	{
		return null;
	}

	protected virtual Graphics.Types.Fill? SerializeFill()
	{
		return null;
	}

	protected virtual Graphics.Types.Stroke? SerializeStroke()
	{
		return null;
	}

	protected virtual Graphics.Types.Shadow? SerializeShadow()
	{
		return null;
	}

	protected virtual Graphics.Types.Feather? SerializeFeather()
	{
		return null;
	}

	protected virtual Graphics.Types.Text? SerializeText()
	{
		return null;
	}

	protected virtual Graphics.Types.Text.Types.LineFillMask? SerializeLineFillMask()
	{
		return null;
	}

	protected internal void Deserialize(Pro.SerializationInterop.RVProtoData.Slide.Types.Element element, ApplicationData? applicationData, ITransitionDescriptionCollection transitionDescriptions, string containerId)
	{
		if (element != null)
		{
			DeserializeElement(element.Element_, applicationData, containerId);
			DeserializeBuildIn(element.BuildIn, transitionDescriptions);
			DeserializeBuildOut(element.BuildOut, transitionDescriptions);
			DeserializeChildBuilds(element.ChildBuilds);
			RevealType = element.RevealType.ToTextRevealType();
			DeserializeRevealFromIndex(element.RevealFromIndex);
			AdditionalInfo = (AdditionalInfo)element.Info;
			DeserializeTextScroller(element.TextScroller);
		}
	}

	protected internal virtual void DeserializeLinks(IEnumerable<Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink> protoDataLinks, IEnumerable<SlideElementBase> otherElements)
	{
		VisibilityCriterion visibilityCriterion;
		IEnumerable<VisibilityCondition> enumerable = DataLinkFactory.GenerateVisibilityConditions(protoDataLinks, otherElements, out visibilityCriterion);
		if (enumerable.Any() && VisibilityLink != null)
		{
			VisibilityLink.IsEnabled = true;
			VisibilityLink.Conditions.Clear();
			VisibilityLink.Conditions.AddConditions(enumerable);
			VisibilityLink.Criterion = visibilityCriterion;
		}
	}

	private void DeserializeElement(Graphics.Types.Element element, ApplicationData? applicationData, string containerId)
	{
		if (element != null)
		{
			ID = element.Uuid?.ToGuid() ?? Guid.NewGuid();
			Name = element.Name;
			Position = element.Bounds?.Origin?.ToVector() ?? Vector2<double>.Zero;
			Size = element.Bounds?.Size?.ToVector() ?? Vector2<double>.Zero;
			Rotation = element.Rotation.ToAngle();
			Opacity = element.Opacity;
			IsLocked = element.Locked;
			IsHidden = element.Hidden;
			FlipMode = element.FlipMode.ToElementFlipMode();
			IsAspectRatioLocked = element.AspectRatioLocked;
			DeserializePath(element.Path);
			DeserializeFill(element.Fill, containerId);
			DeserializeStroke(element.Stroke);
			DeserializeShadow(element.Shadow);
			DeserializeFeather(element.Feather);
			DeserializeText(element.Text, applicationData, containerId);
			DeserializeLineFillMask(element.TextLineMask);
		}
	}

	private void DeserializeBuildIn(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.Build buildIn, ITransitionDescriptionCollection transitionDescriptions)
	{
		if (buildIn != null)
		{
			if (BuildIn?.ID != buildIn.Uuid.ToGuid())
			{
				BuildIn = new Build(this, transitionDescriptions);
			}
			BuildIn.DataModified -= OnDataModified;
			BuildIn.Deserialize(buildIn);
			BuildIn.DataModified += OnDataModified;
		}
	}

	private void DeserializeBuildOut(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.Build buildOut, ITransitionDescriptionCollection transitionDescriptions)
	{
		if (buildOut != null)
		{
			if (BuildOut?.ID != buildOut.Uuid.ToGuid())
			{
				BuildOut = new Build(this, transitionDescriptions);
			}
			BuildOut.DataModified -= OnDataModified;
			BuildOut.Deserialize(buildOut);
			BuildOut.DataModified += OnDataModified;
		}
	}

	protected virtual void DeserializeTextScroller(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextScroller textScroller)
	{
	}

	protected virtual void DeserializeChildBuilds(IEnumerable<Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.ChildBuild> protoChildBuilds)
	{
	}

	protected virtual void DeserializeRevealFromIndex(uint index)
	{
	}

	protected virtual void DeserializePath(Graphics.Types.Path path)
	{
	}

	protected virtual void DeserializeFill(Graphics.Types.Fill fill, string containerId)
	{
	}

	protected virtual void DeserializeStroke(Graphics.Types.Stroke stroke)
	{
	}

	protected virtual void DeserializeShadow(Graphics.Types.Shadow shadow)
	{
	}

	protected virtual void DeserializeFeather(Graphics.Types.Feather feather)
	{
	}

	protected virtual void DeserializeText(Graphics.Types.Text? text, ApplicationData? applicationData, string containerId)
	{
	}

	protected virtual void DeserializeLineFillMask(Graphics.Types.Text.Types.LineFillMask protoLineFillMask)
	{
	}

	protected internal virtual void CopyProperties(SlideElementBase slideElement)
	{
		slideElement._name = _name;
		slideElement._additionalInfo = _additionalInfo;
		slideElement.Position = Position;
		slideElement.Size = Size;
		slideElement.Rotation = Rotation;
		slideElement.Opacity = Opacity;
		slideElement.IsLocked = IsLocked;
		slideElement.IsHidden = IsHidden;
		slideElement.IsAspectRatioLocked = IsAspectRatioLocked;
		slideElement.FlipMode = FlipMode;
		slideElement.VisibilityLink = (VisibilityLink)VisibilityLink.Clone();
		slideElement.ContainerId = ContainerId;
		CopyBuildProperties(slideElement);
	}

	protected internal virtual void CopyBuildProperties(SlideElementBase slideElement)
	{
		slideElement._buildIn = ((_buildIn != null) ? new Build(slideElement, _buildIn) : null);
		slideElement._buildOut = ((_buildOut != null) ? new Build(slideElement, _buildOut) : null);
		slideElement.RevealType = RevealType;
	}

	protected void OnDataModified()
	{
		this.DataModified?.Invoke(this);
	}

	protected virtual void OnBuildInChanged(Build? o, Build? n)
	{
	}

	protected virtual void OnBuildOutChanged(Build? o, Build? n)
	{
	}

	protected virtual void OnRevealTypeChanged(RevealType o, RevealType n)
	{
	}

	private void VisibilityLink_LinkObjectUpdated()
	{
		OnVisualInvalidated();
		OnDataModified();
	}

	public void FinalizeName()
	{
		SetValue("Name", ref _name, Name);
	}

	public virtual void UpdateContainerId(string containerId)
	{
		ContainerId = containerId;
	}
}
