using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ErrorReporting;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Transitions;
using Pro.Editor.Canvas;
using Pro.Editor.Canvas.Handles;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Builds;
using ProPresenter.DO.Slide.Custom.Elements.Feathers;
using ProPresenter.DO.Slide.Custom.Elements.Shadows;
using ProPresenter.DO.Slide.Custom.Elements.Shapes;
using ProPresenter.DO.Slide.Custom.Elements.Strokes;
using ProPresenter.DO.Slide.Links;

namespace ProPresenter.DO.Slide.Custom.Elements;

public abstract class BezierPath : SlideElementBase
{
	private bool _pointsValid;

	private BezierPoint[]? _points;

	private Vector2<double> _position = Vector2<double>.Zero;

	private Vector2<double> _size = Vector2<double>.Zero;

	private Rect<double>? _tightBounds;

	private Rect<double>? _snapBounds;

	private Angle<double> _rotation = Angle<double>.Zero;

	private readonly ObservableCollection<IHandleData> _customHandles = new ObservableCollection<IHandleData>();

	private ImmutableObservableCollection<IHandleData>? _customHandlesCollection;

	private IFeather _feather = new Feather();

	private IShadow _shadow = new DropShadow();

	private IStroke _stroke = new Stroke();

	public abstract BezierPathType PathType { get; }

	public override SlideElementType ElementType => SlideElementType.BezierPath;

	public BezierPoint[] Points
	{
		get
		{
			if (!_pointsValid || _points == null)
			{
				_points = GeneratePoints().ToArray();
				SetupPoints(_points);
				_pointsValid = true;
			}
			return _points;
		}
	}

	public sealed override Vector2<double> Position
	{
		get
		{
			return _position;
		}
		set
		{
			SetValue("Position", ref _position, value, delegate(Vector2<double> o, Vector2<double> n)
			{
				OnPositionChanged(o, n);
				InvalidateBounds();
				OnVisualInvalidated();
				base.UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementPosition), this, "Position", o, n);
			});
		}
	}

	public sealed override Vector2<double> Size
	{
		get
		{
			return _size;
		}
		set
		{
			SetValue("Size", ref _size, this.EnsurePositiveSize(value), delegate(Vector2<double> o, Vector2<double> n)
			{
				using (base.UndoStack?.Transaction())
				{
					OnSizeChanged(o, n, applySideEffects: false);
					InvalidateBounds();
					OnVisualInvalidated();
					base.UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementSize), this, "Size", o, n);
				}
			});
		}
	}

	public sealed override Angle<double> Rotation
	{
		get
		{
			return _rotation;
		}
		set
		{
			SetValue("Rotation", ref _rotation, value, delegate(Angle<double> o, Angle<double> n)
			{
				OnRotationChanged();
				InvalidateBounds();
				OnVisualInvalidated();
				base.UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementRotation), this, "Rotation", o, n);
			});
		}
	}

	public override ImmutableObservableCollection<IHandleData> CustomHandles
	{
		get
		{
			if (_customHandlesCollection == null)
			{
				_customHandlesCollection = new ImmutableObservableCollection<IHandleData>(_customHandles);
			}
			return _customHandlesCollection;
		}
	}

	protected ObservableCollection<IHandleData> CustomHandlesCollection => _customHandles;

	public Rect<double> TightBounds
	{
		get
		{
			Rect<double> valueOrDefault = _tightBounds.GetValueOrDefault();
			if (!_tightBounds.HasValue)
			{
				valueOrDefault = BezierPathMath.CalculateTightBounds(this, includeFlipAndRotation: false, includeStroke: true);
				_tightBounds = valueOrDefault;
			}
			return _tightBounds.Value;
		}
	}

	public override Rect<double> SnapBounds
	{
		get
		{
			Rect<double> valueOrDefault = _snapBounds.GetValueOrDefault();
			if (!_snapBounds.HasValue)
			{
				valueOrDefault = BezierPathMath.CalculateTightBounds(this, includeFlipAndRotation: true, includeStroke: true);
				_snapBounds = valueOrDefault;
			}
			return _snapBounds.Value;
		}
	}

	public virtual bool SupportsStroke => true;

	public virtual bool SupportsShadow => true;

	public sealed override bool UseBitmapCache
	{
		get
		{
			IFeather feather = Feather;
			if (feather != null && feather.IsEnabled)
			{
				return feather.Radius > 0.0;
			}
			return false;
		}
	}

	public IStroke Stroke
	{
		get
		{
			return _stroke;
		}
		set
		{
			SetValue("Stroke", ref _stroke, value, delegate(IStroke o, IStroke n)
			{
				TeardownStroke(o);
				SetupStroke(n);
				OnVisualInvalidated();
				OnDataModified();
			});
		}
	}

	public IFeather Feather
	{
		get
		{
			return _feather;
		}
		set
		{
			SetValue("Feather", ref _feather, value, delegate(IFeather o, IFeather n)
			{
				TeardownFeather(o);
				SetupFeather(n);
				OnVisualInvalidated();
				OnDataModified();
			});
		}
	}

	public IShadow Shadow
	{
		get
		{
			return _shadow;
		}
		set
		{
			SetValue("Shadow", ref _shadow, value, delegate(IShadow o, IShadow n)
			{
				TeardownShadow(o);
				SetupShadow(n);
				OnVisualInvalidated();
				OnDataModified();
			});
		}
	}

	public virtual ObjectBinder<BezierPath, ISlide.Types.IElement> CreateBinder(IUiScheduler uiScheduler, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, ISlide.Types.IElement right, IErrorReporter errorReporter)
	{
		IEntityFactory entityFactory = factoryProvider.EntityFactory;
		ObjectBinder<BezierPath, ISlide.Types.IElement> objectBinder = new ObjectBinder<BezierPath, ISlide.Types.IElement>(this, right);
		ObjectBinder<BezierPath, Pro.Entity.Collections.ICollection<ISlide.Types.IElement.Types.IDataLink>> dataLinksBinder = BindDataLinks(uiScheduler, entityFactory, right.DataLinks);
		objectBinder.Bind((BezierPath l) => l.WhenPropertyChanges("AdditionalInfo"), (ISlide.Types.IElement r) => r.Info.WhenValueChanges, delegate(BezierPath l, ISlide.Types.IElement r)
		{
			r.Info.Set((uint)l.AdditionalInfo);
		}, delegate(ISlide.Types.IElement r, BezierPath l)
		{
			l.AdditionalInfo = (AdditionalInfo)r.Info.Value;
		}).Bind((BezierPath l) => l.WhenPropertyChanges("RevealType"), (ISlide.Types.IElement r) => r.RevealType.WhenValueChanges, delegate(BezierPath l, ISlide.Types.IElement r)
		{
			r.RevealType.Set(l.RevealType.ToEntityTextRevealType());
		}, delegate(ISlide.Types.IElement r, BezierPath l)
		{
			l.RevealType = r.RevealType.Value.ToTextRevealType();
		}).Bind<Unit, IGraphics.Types.IElement>(null, (ISlide.Types.IElement r) => r._Element.WhenValueChanges, delegate(BezierPath l, ISlide.Types.IElement r)
		{
			IGraphics.Types.IElement element = entityFactory.Create<IGraphics.Types.IElement>();
			r._Element.Set(element);
			ObjectBinder<BezierPath, IGraphics.Types.IElement> objectBinder2 = l.CreateGraphicsElementBinder(uiScheduler, factoryProvider, element, errorReporter);
			objectBinder2.InitializeRightFromLeft();
			element.RegisterLinkedDisposable(objectBinder2);
		}, delegate(ISlide.Types.IElement r, BezierPath l)
		{
			ObjectBinder<BezierPath, IGraphics.Types.IElement> objectBinder3 = l.CreateGraphicsElementBinder(uiScheduler, factoryProvider, r._Element.Value, errorReporter);
			objectBinder3.InitializeLeftFromRight();
			r._Element.Value.RegisterLinkedDisposable(objectBinder3);
		}, null, uiScheduler.Scheduler)
			.Bind((BezierPath l) => l.WhenPropertyChanges("BuildIn"), (ISlide.Types.IElement r) => r.BuildIn.WhenValueChanges, delegate(BezierPath l, ISlide.Types.IElement r)
			{
				if (l.BuildIn == null)
				{
					r.BuildIn.Set(null);
				}
				else
				{
					ISlide.Types.IElement.Types.IBuild build = entityFactory.Create<ISlide.Types.IElement.Types.IBuild>();
					r.BuildIn.Set(build);
					ObjectBinder<Build, ISlide.Types.IElement.Types.IBuild> objectBinder4 = Build.CreateBinder(l.BuildIn, build, entityFactory);
					objectBinder4.InitializeRightFromLeft();
					build.RegisterLinkedDisposable(objectBinder4);
				}
			}, delegate(ISlide.Types.IElement r, BezierPath l)
			{
				if (r.BuildIn.Value == null)
				{
					l.BuildIn = null;
				}
				else
				{
					Build buildIn = (l.BuildIn = new Build(l, transitionDescriptions));
					ObjectBinder<Build, ISlide.Types.IElement.Types.IBuild> objectBinder5 = Build.CreateBinder(buildIn, r.BuildIn.Value, entityFactory);
					objectBinder5.InitializeLeftFromRight();
					r.BuildIn.Value.RegisterLinkedDisposable(objectBinder5);
				}
			}, null, uiScheduler.Scheduler)
			.Bind((BezierPath l) => l.WhenPropertyChanges("BuildOut"), (ISlide.Types.IElement r) => r.BuildOut.WhenValueChanges, delegate(BezierPath l, ISlide.Types.IElement r)
			{
				if (l.BuildOut == null)
				{
					r.BuildOut.Set(null);
				}
				else
				{
					ISlide.Types.IElement.Types.IBuild build3 = entityFactory.Create<ISlide.Types.IElement.Types.IBuild>();
					r.BuildOut.Set(build3);
					ObjectBinder<Build, ISlide.Types.IElement.Types.IBuild> objectBinder6 = Build.CreateBinder(l.BuildOut, build3, entityFactory);
					objectBinder6.InitializeRightFromLeft();
					build3.RegisterLinkedDisposable(objectBinder6);
				}
			}, delegate(ISlide.Types.IElement r, BezierPath l)
			{
				if (r.BuildOut.Value == null)
				{
					l.BuildOut = null;
				}
				else
				{
					Build buildIn2 = (l.BuildOut = new Build(l, transitionDescriptions));
					ObjectBinder<Build, ISlide.Types.IElement.Types.IBuild> objectBinder7 = Build.CreateBinder(buildIn2, r.BuildOut.Value, entityFactory);
					objectBinder7.InitializeLeftFromRight();
					r.BuildOut.Value.RegisterLinkedDisposable(objectBinder7);
				}
			}, null, uiScheduler.Scheduler)
			.DoOnInitializeLeftFromRight(dataLinksBinder.InitializeLeftFromRight)
			.DoOnInitializeRightFromLeft(dataLinksBinder.InitializeRightFromLeft)
			.RegisterChildDisposable(() => dataLinksBinder);
		return objectBinder;
	}

	protected virtual ObjectBinder<BezierPath, Pro.Entity.Collections.ICollection<ISlide.Types.IElement.Types.IDataLink>> BindDataLinks(IUiScheduler scheduler, IEntityFactory entityFactory, Pro.Entity.Collections.ICollection<ISlide.Types.IElement.Types.IDataLink> dataLinks)
	{
		ObjectBinder<BezierPath, Pro.Entity.Collections.ICollection<ISlide.Types.IElement.Types.IDataLink>> objectBinder = new ObjectBinder<BezierPath, Pro.Entity.Collections.ICollection<ISlide.Types.IElement.Types.IDataLink>>(this, dataLinks);
		objectBinder.Bind(delegate(BezierPath l)
		{
			if (l is ClosedBezierPath closedBezierPath)
			{
				return Observable.Merge<Unit>(closedBezierPath.VisibilityLink.WhenPropertyChanges("IsEnabled").ToUnit(), closedBezierPath.FillLink.WhenPropertyChanges("IsEnabled").ToUnit().Merge(closedBezierPath.FillLink.WhenPropertyChanges("LinkedObject").ToUnit()), closedBezierPath.TextLink.WhenPropertyChanges("IsEnabled").ToUnit().Merge(closedBezierPath.TextLink.WhenPropertyChanges("LinkedObject").ToUnit()));
			}
			return (l != null) ? l.VisibilityLink.WhenPropertyChanges("IsEnabled").ToUnit() : Observable.Empty<Unit>();
		}, (Pro.Entity.Collections.ICollection<ISlide.Types.IElement.Types.IDataLink> r) => r.WhenCollectionChanges, delegate(BezierPath l, Pro.Entity.Collections.ICollection<ISlide.Types.IElement.Types.IDataLink> r)
		{
			ProPresenter.DO.Slide.Links.VisibilityLink.HandleModelChanges(scheduler, l, entityFactory, r);
			FillLink.HandleModelChanges(entityFactory, l, r);
			TextLink.HandleModelChanges(entityFactory, l, r);
		}, delegate(Pro.Entity.Collections.ICollection<ISlide.Types.IElement.Types.IDataLink> r, BezierPath l)
		{
			ProPresenter.DO.Slide.Links.VisibilityLink.HandleEntityChanges(scheduler, l, entityFactory, r);
			FillLink.HandleEntityChanges(l, r);
			TextLink.HandleEntityChanges(entityFactory, General.Settings, l, r);
		});
		return objectBinder;
	}

	protected virtual ObjectBinder<BezierPath, IGraphics.Types.IElement> CreateGraphicsElementBinder(IUiScheduler uiScheduler, IProPresenterDOFactoryProvider factoryProvider, IGraphics.Types.IElement right, IErrorReporter errorReporter)
	{
		IEntityFactory entityFactory = factoryProvider.EntityFactory;
		ObjectBinder<BezierPath, IGraphics.Types.IElement> objectBinder = SlideElementBase.Bind(uiScheduler, this, right);
		objectBinder.Bind((BezierPath l) => l.WhenPropertyChanges("Position").Merge(l.WhenPropertyChanges("Size")), (IGraphics.Types.IElement r) => r.Bounds.WhenValueChanges, delegate(BezierPath l, IGraphics.Types.IElement r)
		{
			r.Bounds.Set(new IGraphics.Types.Rect(l.Position.ToPoint(), l.Size.ToSize()));
		}, delegate(IGraphics.Types.IElement r, BezierPath l)
		{
			l.SetValue("Position", ref l._position, r.Bounds.Value.Origin.ToVector2d(), delegate(Vector2<double> o, Vector2<double> n)
			{
				l.OnPositionChanged(o, n);
				l.InvalidateBounds();
				l.OnVisualInvalidated();
			});
			l.SetValue("Size", ref l._size, l.EnsurePositiveSize(r.Bounds.Value.Size.ToVector2d()), delegate(Vector2<double> o, Vector2<double> n)
			{
				l.OnSizeChanged(o, n, applySideEffects: false);
				l.InvalidateBounds();
				l.OnVisualInvalidated();
			});
		}, null, uiScheduler.Scheduler).Bind((BezierPath l) => l.WhenPropertyChanges("Rotation"), (IGraphics.Types.IElement r) => r.Rotation.WhenValueChanges, delegate(BezierPath l, IGraphics.Types.IElement r)
		{
			r.Rotation.Set(l.Rotation.Value);
		}, delegate(IGraphics.Types.IElement r, BezierPath l)
		{
			l.SetValue("Rotation", ref l._rotation, new Angle<double>(r.Rotation.Value), (Action<Angle<double>, Angle<double>>?)delegate
			{
				l.OnRotationChanged();
				l.InvalidateBounds();
				l.OnVisualInvalidated();
			}, (Predicate<Angle<double>>?)null, referenceComparison: false);
		}).Bind<Unit, Unit>(null, (IGraphics.Types.IElement r) => r.Path.WhenValueChanges.ToUnit(), delegate(BezierPath l, IGraphics.Types.IElement r)
		{
			IGraphics.Types.IPath path = entityFactory.Create<IGraphics.Types.IPath>();
			r.Path.Set(path);
			ObjectBinder<BezierPath, IGraphics.Types.IPath> objectBinder2 = CreateGraphicsPathBinder(uiScheduler, factoryProvider, l, path, errorReporter);
			objectBinder2.InitializeRightFromLeft();
			path.RegisterLinkedDisposable(objectBinder2);
		}, delegate(IGraphics.Types.IElement r, BezierPath l)
		{
			ObjectBinder<BezierPath, IGraphics.Types.IPath> objectBinder3 = CreateGraphicsPathBinder(uiScheduler, factoryProvider, l, r.Path.Value, errorReporter);
			objectBinder3.InitializeLeftFromRight();
			r.Path.Value.RegisterLinkedDisposable(objectBinder3);
		}, null, uiScheduler.Scheduler)
			.Bind((BezierPath l) => l.WhenPropertyChanges("Stroke"), (IGraphics.Types.IElement r) => r.Stroke.WhenValueChanges, delegate(BezierPath l, IGraphics.Types.IElement r)
			{
				IGraphics.Types.IStroke stroke = entityFactory.Create<IGraphics.Types.IStroke>();
				r.Stroke.Set(stroke);
				ObjectBinder<IStroke, IGraphics.Types.IStroke> objectBinder4 = ProPresenter.DO.Slide.Custom.Elements.Strokes.Stroke.CreateBinder(l.Stroke, stroke);
				objectBinder4.InitializeRightFromLeft();
				stroke.RegisterLinkedDisposable(objectBinder4);
			}, delegate(IGraphics.Types.IElement r, BezierPath l)
			{
				ObjectBinder<IStroke, IGraphics.Types.IStroke> objectBinder5 = ProPresenter.DO.Slide.Custom.Elements.Strokes.Stroke.CreateBinder(l.Stroke, r.Stroke.Value);
				objectBinder5.InitializeLeftFromRight();
				r.Stroke.Value.RegisterLinkedDisposable(objectBinder5);
			}, null, uiScheduler.Scheduler)
			.Bind((BezierPath l) => l.WhenPropertyChanges("Shadow"), (IGraphics.Types.IElement r) => r.Shadow.WhenValueChanges, delegate(BezierPath l, IGraphics.Types.IElement r)
			{
				IGraphics.Types.IShadow shadow = entityFactory.Create<IGraphics.Types.IShadow>();
				r.Shadow.Set(shadow);
				ObjectBinder<IShadow, IGraphics.Types.IShadow> objectBinder6 = ShadowBase.CreateBinder(entityFactory, l.Shadow, shadow);
				objectBinder6.InitializeRightFromLeft();
				shadow.RegisterLinkedDisposable(objectBinder6);
			}, delegate(IGraphics.Types.IElement r, BezierPath l)
			{
				ObjectBinder<IShadow, IGraphics.Types.IShadow> objectBinder7 = ShadowBase.CreateBinder(entityFactory, l.Shadow, r.Shadow.Value);
				objectBinder7.InitializeLeftFromRight();
				r.Shadow.Value.RegisterLinkedDisposable(objectBinder7);
			}, null, uiScheduler.Scheduler)
			.Bind((BezierPath l) => l.WhenPropertyChanges("Feather"), (IGraphics.Types.IElement r) => r.Feather.WhenValueChanges, delegate(BezierPath l, IGraphics.Types.IElement r)
			{
				IGraphics.Types.IFeather feather = entityFactory.Create<IGraphics.Types.IFeather>();
				r.Feather.Set(feather);
				ObjectBinder<IFeather, IGraphics.Types.IFeather> objectBinder8 = ProPresenter.DO.Slide.Custom.Elements.Feathers.Feather.CreateBinder(l.Feather, feather);
				objectBinder8.InitializeRightFromLeft();
				feather.RegisterLinkedDisposable(objectBinder8);
			}, delegate(IGraphics.Types.IElement r, BezierPath l)
			{
				ObjectBinder<IFeather, IGraphics.Types.IFeather> objectBinder9 = ProPresenter.DO.Slide.Custom.Elements.Feathers.Feather.CreateBinder(l.Feather, r.Feather.Value);
				objectBinder9.InitializeLeftFromRight();
				r.Feather.Value.RegisterLinkedDisposable(objectBinder9);
			}, null, uiScheduler.Scheduler);
		return objectBinder;
	}

	private static ObjectBinder<BezierPath, IGraphics.Types.IPath> CreateGraphicsPathBinder(IUiScheduler uiScheduler, IProPresenterDOFactoryProvider factoryProvider, BezierPath left, IGraphics.Types.IPath right, IErrorReporter errorReporter)
	{
		IEntityFactory entityFactory = factoryProvider.EntityFactory;
		ObjectBinder<BezierPath, IGraphics.Types.IPath> objectBinder = new ObjectBinder<BezierPath, IGraphics.Types.IPath>(left, right);
		objectBinder.Bind<Unit, bool>(null, (IGraphics.Types.IPath r) => r.Closed.WhenValueChanges, delegate(BezierPath l, IGraphics.Types.IPath r)
		{
			r.Closed.Set(l.PathType == BezierPathType.Closed);
		}, delegate(IGraphics.Types.IPath r, BezierPath l)
		{
			BezierPathType bezierPathType = ((!r.Closed.Value) ? BezierPathType.Open : BezierPathType.Closed);
			if (l.PathType != bezierPathType)
			{
				errorReporter.Error("Unexpected path type change while binding slide elements.");
			}
		}).Bind((BezierPath l) => l.WhenPropertyChanges("Points"), (IGraphics.Types.IPath r) => r.Points.WhenCollectionChanges, delegate(BezierPath l, IGraphics.Types.IPath r)
		{
			r.Points.SynchronizeFrom(l.Points, ArePointsEqual, delegate(BezierPoint m)
			{
				IGraphics.Types.IPath.Types.IBezierPoint bezierPoint = entityFactory.Create<IGraphics.Types.IPath.Types.IBezierPoint>();
				ObjectBinder<BezierPoint, IGraphics.Types.IPath.Types.IBezierPoint> objectBinder2 = BezierPoint.CreateBinder(m, bezierPoint);
				objectBinder2.InitializeRightFromLeft();
				bezierPoint.RegisterLinkedDisposable(objectBinder2);
				return bezierPoint;
			});
		}, delegate(IGraphics.Types.IPath r, BezierPath l)
		{
			BezierPoint[] array = new BezierPoint[r.Points.Items.Count];
			Array.Copy(l.Points, array, Math.Min(array.Length, l.Points.Length));
			for (int i = l.Points.Length; i < array.Length; i++)
			{
				BezierPoint bezierPoint2 = new BezierPoint();
				IGraphics.Types.IPath.Types.IBezierPoint bezierPoint3 = r.Points.Items[i];
				array[i] = bezierPoint2;
				ObjectBinder<BezierPoint, IGraphics.Types.IPath.Types.IBezierPoint> objectBinder3 = BezierPoint.CreateBinder(bezierPoint2, bezierPoint3);
				objectBinder3.InitializeLeftFromRight();
				bezierPoint3.RegisterLinkedDisposable(objectBinder3);
			}
			l.OnPointsDeserialized(array);
		}, null, uiScheduler.Scheduler).Bind<Unit, IGraphics.Types.IPath.Types.Shape>(null, (IGraphics.Types.IPath r) => r.Shape.WhenValueChanges, delegate(BezierPath l, IGraphics.Types.IPath r)
		{
			r.Shape.Set(l.CreateEntityShape());
		}, delegate(IGraphics.Types.IPath r, BezierPath l)
		{
			if (!l.IsSyncCompatibleShape(r.Shape.Value.Type))
			{
				errorReporter.Error("Unexpected shape shift while binding slide elements.");
			}
		});
		return objectBinder;
	}

	private static bool ArePointsEqual(BezierPoint m, IGraphics.Types.IPath.Types.IBezierPoint e)
	{
		if (m.Position == e.Point.Value.ToVector2d() && m.Q0 == e.Q0.Value.ToVector2d() && m.Q1 == e.Q1.Value.ToVector2d())
		{
			return m.IsCurved == e.Curved.Value;
		}
		return false;
	}

	protected BezierPath()
	{
		base.PropertyChanged += delegate(object? _, PropertyChangedEventArgs args)
		{
			if (args.PropertyName == "FlipMode")
			{
				InvalidateBounds();
			}
		};
		SetupStroke(_stroke);
		SetupShadow(_shadow);
		SetupFeather(_feather);
	}

	public override bool RenderEquals([NotNullWhen(true)] SlideElementBase? other)
	{
		if (base.RenderEquals(other) && other is BezierPath bezierPath && Points.ContentsMatchExactly(bezierPath.Points, (BezierPoint l, BezierPoint r) => l.RenderEquals(r)) && _stroke.RenderEquals(bezierPath._stroke) && _shadow.RenderEquals(bezierPath._shadow))
		{
			return _feather.RenderEquals(bezierPath._feather);
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(new IEnumerable[1] { Points }, base.GetRenderHashCode(), _stroke, _shadow, _feather);
	}

	protected abstract IEnumerable<BezierPoint> GeneratePoints();

	protected virtual void OnPositionChanged(Vector2<double> oldValue, Vector2<double> newValue)
	{
	}

	protected virtual void OnSizeChanged(Vector2<double> oldValue, Vector2<double> newValue, bool applySideEffects = true)
	{
	}

	protected virtual void OnRotationChanged()
	{
	}

	public virtual BezierPoint? InsertPoint(BezierPoint startPoint, BezierPoint endPoint, double t)
	{
		return null;
	}

	protected void InvalidatePoints()
	{
		if (_pointsValid && _points != null)
		{
			TeardownPoints(_points);
		}
		_pointsValid = false;
		_points = null;
		OnPropertyChanged("Points");
		InvalidateBounds();
		OnVisualInvalidated();
		OnDataModified();
	}

	private void InvalidateBounds()
	{
		_tightBounds = null;
		_snapBounds = null;
	}

	public virtual void HandleDragStarted(BezierPoint point)
	{
	}

	public virtual void HandleDragged(BezierPoint point)
	{
	}

	public virtual void HandleDragCompleted(BezierPoint point)
	{
	}

	public virtual void PointToggleStarted(BezierPoint point)
	{
	}

	public virtual void PointToggleCompleted(BezierPoint point)
	{
	}

	private void OnBezierPointPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		OnVisualInvalidated();
	}

	public override bool DoesSelectionIntersect(Rect<double> selectionBounds)
	{
		return BezierPathMath.Intersects(this, selectionBounds);
	}

	private void SetupStroke(IStroke stroke)
	{
		stroke.UndoStack = base.UndoStack;
		stroke.PropertyChanged += OnStrokePropertyChanged;
		stroke.VisualInvalidated += base.OnVisualInvalidated;
		stroke.DataModified += OnStrokeDataModified;
	}

	private void TeardownStroke(IStroke? stroke)
	{
		if (stroke != null)
		{
			stroke.UndoStack = null;
			stroke.PropertyChanged -= OnStrokePropertyChanged;
			stroke.VisualInvalidated -= base.OnVisualInvalidated;
			stroke.DataModified -= OnStrokeDataModified;
		}
	}

	private void OnStrokePropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (propertyName == "IsEnabled" || propertyName == "StrokeThickness")
		{
			InvalidateBounds();
		}
	}

	private void OnStrokeDataModified(IStroke stroke)
	{
		OnDataModified();
	}

	private void SetupFeather(IFeather feather)
	{
		feather.UndoStack = base.UndoStack;
		feather.VisualInvalidated += base.OnVisualInvalidated;
		feather.DataModified += OnFeatherDataModified;
	}

	private void TeardownFeather(IFeather? feather)
	{
		if (feather != null)
		{
			feather.UndoStack = null;
			feather.VisualInvalidated -= base.OnVisualInvalidated;
			feather.DataModified -= OnFeatherDataModified;
		}
	}

	private void OnFeatherDataModified(IFeather feather)
	{
		OnPropertyChanged("UseBitmapCache");
		OnDataModified();
	}

	private void SetupShadow(IShadow shadow)
	{
		shadow.UndoStack = base.UndoStack;
		shadow.VisualInvalidated += base.OnVisualInvalidated;
		shadow.DataModified += ShadowDataModified;
	}

	private void TeardownShadow(IShadow? shadow)
	{
		if (shadow != null)
		{
			shadow.VisualInvalidated -= base.OnVisualInvalidated;
			shadow.DataModified -= ShadowDataModified;
			shadow.UndoStack = null;
		}
	}

	private void ShadowDataModified(IShadow shadow)
	{
		OnDataModified();
	}

	protected internal override void CopyProperties(SlideElementBase slideElement)
	{
		BezierPath bezierPath = (BezierPath)slideElement;
		bezierPath.Shadow = _shadow.Clone();
		bezierPath.Stroke = _stroke.Clone();
		bezierPath.Feather = _feather.Clone();
		base.CopyProperties(bezierPath);
	}

	protected override Graphics.Types.Path SerializePath()
	{
		Graphics.Types.Path path = new Graphics.Types.Path();
		path.Closed = PathType == BezierPathType.Closed;
		path.Shape = SerializeShape();
		path.Points.AddRange(Points.Select((BezierPoint p) => p.Serialize()).ToArray());
		return path;
	}

	protected override Graphics.Types.Stroke SerializeStroke()
	{
		return Stroke.Serialize();
	}

	protected override Graphics.Types.Shadow SerializeShadow()
	{
		return Shadow.Serialize();
	}

	protected override Graphics.Types.Feather SerializeFeather()
	{
		return Feather.Serialize();
	}

	protected override void DeserializePath(Graphics.Types.Path? path)
	{
		if (path != null)
		{
			if (path.Shape != null)
			{
				DeserializeShape(path.Shape);
			}
			OnPointsDeserialized(path.Points.Select(DeserializePoint).ToArray());
			InvalidatePoints();
		}
	}

	protected override void DeserializeStroke(Graphics.Types.Stroke? stroke)
	{
		if (stroke != null)
		{
			Stroke = stroke.DeserializeStroke();
		}
	}

	protected override void DeserializeShadow(Graphics.Types.Shadow? shadow)
	{
		if (shadow != null)
		{
			Shadow = shadow.DeserializeShadow();
		}
	}

	protected override void DeserializeFeather(Graphics.Types.Feather? feather)
	{
		if (feather != null)
		{
			Feather = feather.DeserializeFeather();
		}
	}

	protected abstract Graphics.Types.Path.Types.Shape SerializeShape();

	protected virtual void DeserializeShape(Graphics.Types.Path.Types.Shape shape)
	{
	}

	private static BezierPoint DeserializePoint(Graphics.Types.Path.Types.BezierPoint protoPoint)
	{
		BezierPoint bezierPoint = new BezierPoint();
		bezierPoint.Deserialize(protoPoint);
		return bezierPoint;
	}

	protected virtual void OnPointsDeserialized(BezierPoint[] points)
	{
	}

	private void OnBezierPointDataModified(BezierPoint point)
	{
		OnDataModified();
	}

	private void SetupPoints(IEnumerable<BezierPoint> points)
	{
		foreach (BezierPoint point in points)
		{
			point.PropertyChanged += OnBezierPointPropertyChanged;
			point.DataModified += OnBezierPointDataModified;
		}
	}

	private void TeardownPoints(IEnumerable<BezierPoint> points)
	{
		foreach (BezierPoint point in points)
		{
			point.PropertyChanged -= OnBezierPointPropertyChanged;
			point.DataModified -= OnBezierPointDataModified;
		}
	}

	protected abstract bool IsSyncCompatibleShape(IGraphics.Types.IPath.Types.Shape.Types.Type type);
}
