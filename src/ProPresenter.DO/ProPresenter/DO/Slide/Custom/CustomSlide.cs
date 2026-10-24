using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.FileSystem;
using Pro.Common.Mathematics;
using Pro.Common.Nullability;
using Pro.Common.ObjectBinding;
using Pro.Common.Strings;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using Pro.DO.Utility;
using Pro.Editor;
using Pro.Editor.Canvas;
using Pro.Editor.Canvas.Handles;
using Pro.Editor.Canvas.Snapping.Lines;
using Pro.Editor.Canvas.Transforming;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.PDF;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;
using Pro.Text.Fills;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Media;
using ProPresenter.DO.Slide.Builds;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;
using ProPresenter.DO.Slide.Custom.Elements.Shapes;
using ProPresenter.DO.Slide.Links;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.Slide.Custom;

public class CustomSlide : SlideBase, ICanvasElement, INotifyPropertyChanged
{
	private static readonly Vector2<double> ElementMarginOffset = new Vector2<double>(15.0);

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private ImmutableObservableCollection<ICanvasElement>? _canvasChildren;

	private Vector2<double> _size = OutputVault.AudienceScreenArrangementCollection?.FirstOrDefault()?.TotalSize ?? new Vector2<double>(TargetDisplay.PrimaryDisplay.Width, TargetDisplay.PrimaryDisplay.Height);

	private RelativePath _chordChart = RelativePath.Empty();

	private int _manualBuildCount;

	public override SlideType Type => SlideType.Custom;

	public override int ManualBuildCount => _manualBuildCount;

	public MediaSamplerDelegate? BackgroundMediaSampler { get; set; }

	public SlideElementCollection Elements { get; } = new SlideElementCollection();

	public ICanvasElement? CanvasParent => null;

	public ImmutableObservableCollection<ICanvasElement> CanvasChildren
	{
		get
		{
			if (_canvasChildren == null)
			{
				_canvasChildren = Elements.ConvertImmutable<ICanvasElement, SlideElementBase, SlideElementCollection>();
			}
			return _canvasChildren;
		}
	}

	public StaticGuidelineCollection StaticGuides { get; } = new StaticGuidelineCollection();

	public HandleLocation SupportedCanvasHandles => HandleLocation.None;

	public System.Windows.Media.Color HandleColor => Colors.Transparent;

	public ImmutableObservableCollection<IHandleData>? CustomHandles => null;

	public ImmutableObservableCollection<IPopover>? Popovers => null;

	public ImmutableObservableCollection<UIElement>? CustomChildren => null;

	public ChildVisibilityMode ChildVisibilityMode => ChildVisibilityMode.VisibleByDefault;

	public Vector2<double> Position
	{
		get
		{
			return Vector2<double>.Zero;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public override Vector2<double> Size => _size;

	Vector2<double> ICanvasElement.Size
	{
		get
		{
			return _size;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public Angle<double> Rotation
	{
		get
		{
			return Angle<double>.Zero;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public Rect<double> SnapBounds => new Rect<double>(Vector2<double>.Zero, Size);

	public int ZOrder
	{
		get
		{
			return 0;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public bool IsLocked
	{
		get
		{
			return false;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public bool IsHidden
	{
		get
		{
			return false;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public bool IsAspectRatioLocked
	{
		get
		{
			return false;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public bool IsAspectRatioLockForced => false;

	public bool IsEditModeActive => false;

	public bool SupportsEditMode => false;

	public bool MaskWhileEditing => false;

	public bool SupportsRotation => false;

	public bool IsSnappingSource => true;

	public bool IsSelectable => true;

	public bool UseBitmapCache => false;

	public override TextDocument? Text => GetPrimaryTextElement(useDisplayText: false)?.Text;

	public override TextDocument? DisplayText => GetPrimaryTextElement(useDisplayText: true)?.DisplayText;

	public RelativePath? ChordChart
	{
		get
		{
			return _chordChart;
		}
		internal set
		{
			SetValue("ChordChart", ref _chordChart, value, (System.Action)delegate
			{
				OnPropertyChanged("ChordChartFileName");
				OnDataModified();
			}, (Predicate<RelativePath>?)null, referenceComparison: false);
		}
	}

	public string? ChordChartFileName => _chordChart?.Filename;

	public BuildCollection Builds { get; }

	private VisualMedia? BackgroundMedia { get; set; }

	public bool IsBackgroundMediaPending
	{
		get
		{
			VisualMedia? backgroundMedia = BackgroundMedia;
			if (backgroundMedia != null && backgroundMedia.IsValid)
			{
				return BackgroundMedia.IsPending;
			}
			return false;
		}
	}

	public double BlurAmount
	{
		get
		{
			return this.GetBlurAmount();
		}
		set
		{
			this.SynchronizeBlurAmount(value);
			OnPropertyChanged("BlurAmount");
		}
	}

	public static ObjectBinder<CustomSlide, ISlide> CreateBinder(IUiScheduler uiScheduler, CustomSlide left, ISlide right)
	{
		IEntityFactory entityFactory = left._factoryProvider.EntityFactory;
		ObjectBinder<SlideElementCollection, IComplexCollection<ISlide.Types.IElement>> slideElementsBinder = SlideElementCollection.CreateBinder(uiScheduler, left._factoryProvider, left.TransitionDescriptions, left._factoryProvider.ErrorReporter, left, right.Elements);
		ObjectBinder<StaticGuidelineCollection, IComplexCollection<IAlignmentGuide>> staticGuidelinesBinder = StaticGuidelineCollection.CreateBinder(uiScheduler, entityFactory, left.StaticGuides, right.Guidelines);
		ObjectBinder<CustomSlide, ISlide> objectBinder = new ObjectBinder<CustomSlide, ISlide>(left, right);
		objectBinder.Bind((CustomSlide l) => l.WhenPropertyChanges("ID"), (ISlide r) => r.Uuid.WhenValueChanges, delegate(CustomSlide l, ISlide r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(ISlide r, CustomSlide l)
		{
			l.ID = r.Uuid.Value;
		}).Bind((CustomSlide l) => l.WhenPropertyChanges("Size"), (ISlide r) => r.Size.WhenValueChanges, delegate(CustomSlide l, ISlide r)
		{
			r.Size.Set(l.Size.ToSize());
		}, delegate(ISlide r, CustomSlide l)
		{
			Vector2<double> vector = r.Size.Value?.ToVector2d() ?? Vector2<double>.One;
			if (!(l._size == vector))
			{
				l._size = vector;
				l.OnPropertyChanged("Size");
				l.InvalidateVisual();
				l.OnDataModified();
			}
		}).Bind((CustomSlide l) => l.WhenPropertyChanges("UseBackgroundColor"), (ISlide r) => r.DrawsBackgroundColor.WhenValueChanges, delegate(CustomSlide l, ISlide r)
		{
			r.DrawsBackgroundColor.Set(l.UseBackgroundColor);
		}, delegate(ISlide r, CustomSlide l)
		{
			l.UseBackgroundColor = r.DrawsBackgroundColor.Value;
		})
			.Bind((CustomSlide l) => l.WhenPropertyChanges("BackgroundColor"), (ISlide r) => r.BackgroundColor.WhenValueChanges, delegate(CustomSlide l, ISlide r)
			{
				r.BackgroundColor.Set(l.BackgroundColor.ToEntityColor());
			}, delegate(ISlide r, CustomSlide l)
			{
				l.BackgroundColor = r.BackgroundColor.Value?.ToColor() ?? Colors.Black;
			})
			.Bind((CustomSlide l) => l.Builds.WhenCollectionChanges().ToUnit(), (ISlide r) => r.ElementBuildOrder.WhenCollectionChanges.ToUnit(), delegate(CustomSlide l, ISlide r)
			{
				synchronizeBuildOrderLeftToRight(l, r);
			}, delegate(ISlide r, CustomSlide l)
			{
				synchronizeBuildOrderRightToLeft(r, l);
			})
			.DoOnInitializeRightFromLeft(delegate
			{
				slideElementsBinder.InitializeRightFromLeft();
				synchronizeBuildOrderLeftToRight(left, right);
				staticGuidelinesBinder.InitializeRightFromLeft();
			})
			.DoOnInitializeLeftFromRight(delegate
			{
				slideElementsBinder.InitializeLeftFromRight();
				synchronizeBuildOrderRightToLeft(right, left);
				staticGuidelinesBinder.InitializeLeftFromRight();
			})
			.RegisterChildDisposable(() => new global::_003C_003Ez__ReadOnlyArray<IDisposable>(new IDisposable[2] { slideElementsBinder, staticGuidelinesBinder }));
		return objectBinder;
		static void synchronizeBuildOrderLeftToRight(CustomSlide l, ISlide r)
		{
			l.Builds.Select((IBuild b) => b.ID).SynchronizeTo(r.ElementBuildOrder.Items, (Guid source, Guid destination) => source == destination, delegate(Guid source, int index)
			{
				r.ElementBuildOrder.Insert(index, source);
			}, r.ElementBuildOrder.Move, r.ElementBuildOrder.RemoveAt);
		}
		static void synchronizeBuildOrderRightToLeft(ISlide r, CustomSlide l)
		{
			l.Builds.Reset(r.ElementBuildOrder.Items.ToArray(), l.Elements);
		}
	}

	public CustomSlide(IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, TemplateSlide? template = null)
		: base(factoryProvider.TextDocumentFactory, transitionDescriptions)
	{
		LinkProperties("Text", "Text");
		LinkProperties("DisplayText", "DisplayText");
		LinkProperties(new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "IsPending", "IsValid" }), "IsBackgroundMediaPending");
		LinkAction("RevealCount", UpdateManualBuildCount);
		Elements.CollectionChanged += OnElementCollectionChanged;
		Builds = new BuildCollection(transitionDescriptions);
		Builds.DataModified += base.OnDataModified;
		Builds.CollectionChanged += delegate
		{
			UpdateManualBuildCount();
		};
		Builds.BuildPropertyChanged += UpdateManualBuildCount;
		StaticGuides.DataModified += base.OnDataModified;
		if (template != null)
		{
			ChangeSize(template.Slide.Size);
			this.ApplyTemplate(template);
		}
		_factoryProvider = factoryProvider;
	}

	public override bool RenderEquals([NotNullWhen(true)] SlideBase? other)
	{
		if (base.RenderEquals(other) && other is CustomSlide customSlide && BackgroundMediaSampler?.Invoke() == customSlide.BackgroundMediaSampler?.Invoke() && _chordChart?.FullPath == customSlide._chordChart?.FullPath && Elements.ContentsMatchExactly(customSlide.Elements, (SlideElementBase lhs, SlideElementBase rhs) => lhs.RenderEquals(rhs)) && Builds.ContentsMatchExactly(customSlide.Builds, (IBuild lhs, IBuild rhs) => lhs.RenderEquals(rhs)))
		{
			return IsBackgroundMediaPending == customSlide.IsBackgroundMediaPending;
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(new IEnumerable[2] { Elements, Builds }, base.GetRenderHashCode(), ChordChart?.FullPath ?? string.Empty);
	}

	public bool DoesSelectionIntersect(Rect<double> selectionBounds)
	{
		return false;
	}

	private void Element_DataModified(SlideElementBase element)
	{
		OnDataModified();
	}

	private void OnElementCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.Cast<SlideElementBase>().ForEach(TeardownElement);
		e.NewItems?.Cast<SlideElementBase>().ForEach(SetupElement);
		InvalidateVisual();
		OnDataModified();
		UpdateManualBuildCount();
		OnPropertyChanged("Text");
		OnPropertyChanged("DisplayText");
		OnPropertyChanged("BlurAmount");
	}

	private void SetupElement(SlideElementBase element)
	{
		element.VisualInvalidated += base.InvalidateVisual;
		element.DataModified += Element_DataModified;
		element.SetCanvasParent(this);
		element.PropertyChanged += base.RaiseLinkedValues;
		element.UpdateContainerId(base.ContainerId);
		element.SynchronizeBlurAmount(BlurAmount);
	}

	private void TeardownElement(SlideElementBase element)
	{
		element.VisualInvalidated -= base.InvalidateVisual;
		element.DataModified -= Element_DataModified;
		element.SetCanvasParent(null);
		element.PropertyChanged -= base.RaiseLinkedValues;
	}

	public sealed override void ChangeSize(Vector2<double> size)
	{
		if (_size == size)
		{
			return;
		}
		base.UndoStack?.BeginCommit(UndoActionTypes.ChangePresentationResolution.ToAction());
		Vector2<double> original = _size;
		Vector2<double> scalar = size.ComponentwiseQuotient(original);
		base.UndoStack?.Commit(delegate
		{
			ChangeSize(original);
		}, delegate
		{
			ChangeSize(size);
		});
		base.UndoStack?.StartIgnoring();
		foreach (SlideElementBase element in Elements)
		{
			if (element is ClosedBezierPath closedBezierPath)
			{
				closedBezierPath.MaxAutoSizeHeight = size.Y;
				closedBezierPath.Text?.IterateRuns(Pro.Text.Range.All, splitRuns: true, delegate(RunBase run)
				{
					run.Settings.CharacterSize = (int)Math.Round((double)run.Settings.CharacterSize * scalar.Y);
				});
			}
			element.Scale(scalar);
		}
		StaticGuides.ForEach(delegate(StaticSL g)
		{
			g.Scale(_size, size);
		});
		base.UndoStack?.StopIgnoring();
		_size = size;
		OnPropertyChanged("Size");
		InvalidateVisual();
		OnDataModified();
		base.UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	public override SlideBase Clone(bool userInitiated)
	{
		return Clone(null, preserveID: false, userInitiated);
	}

	public CustomSlide Clone(Action<SlideElementBase?, SlideElementBase>? elementCloneCallback, bool preserveID = false, bool userInitiated = false, bool includeBackgroundMedia = true, bool ignoreMediaNotifications = false)
	{
		CustomSlide customSlide = new CustomSlide(_factoryProvider, base.TransitionDescriptions);
		customSlide.UpdateContainerId(base.ContainerId);
		if (preserveID)
		{
			customSlide.ID = base.ID;
		}
		customSlide._size = _size;
		Dictionary<SlideElementBase, SlideElementBase> elementMap = new Dictionary<SlideElementBase, SlideElementBase>();
		foreach (SlideElementBase item in Elements.OrderBy((SlideElementBase e) => e.ZOrder))
		{
			SlideElementBase slideElementBase = (preserveID ? item.CloneWithID() : item.Clone());
			customSlide.OnAddElement(slideElementBase, userInitiated);
			elementCloneCallback?.Invoke(item, slideElementBase);
			elementMap.Add(item, slideElementBase);
		}
		if (ignoreMediaNotifications)
		{
			GetTrackedMediaFromElements(customSlide.Elements).OfType<FileMediaBase>().ForEach(delegate(FileMediaBase x)
			{
				x.DisconnectMediaNotifications();
			});
		}
		customSlide._chordChart = _chordChart;
		customSlide.StaticGuides.AddStaticSLs(StaticGuides.CloneItems());
		if (includeBackgroundMedia)
		{
			customSlide.SetupBackgroundMedia(BackgroundMedia?.Clone() as VisualMedia);
			if (ignoreMediaNotifications)
			{
				customSlide.BackgroundMedia?.DisconnectMediaNotifications();
			}
		}
		customSlide.Builds.Clear();
		foreach (IBuild build2 in Builds)
		{
			SlideElementBase element = build2.Element;
			SlideElementBase slideElementBase2 = elementMap[element];
			if (!(build2 is Build other))
			{
				ChildBuild childBuild = build2 as ChildBuild;
				if (childBuild != null)
				{
					ChildBuild childBuild2 = (slideElementBase2 as ClosedBezierPath)?.ChildBuilds.FirstOrDefault((ChildBuild b) => b.Index == childBuild.Index);
					if (childBuild2 != null)
					{
						customSlide.Builds.AddBuild(childBuild2);
					}
				}
			}
			else
			{
				Build build = new Build(slideElementBase2, other);
				if (element.BuildIn == build2)
				{
					customSlide.Builds.AddBuildIn(slideElementBase2, build);
				}
				else if (element.BuildOut == build2)
				{
					customSlide.Builds.AddBuildOut(slideElementBase2, build);
				}
			}
		}
		foreach (SlideElementBase element2 in customSlide.Elements)
		{
			element2.UpdateElementLinks((Guid id, string name) => elementMap.Any<KeyValuePair<SlideElementBase, SlideElementBase>>((KeyValuePair<SlideElementBase, SlideElementBase> kv) => kv.Key.ID == id), (Guid id, string name) => elementMap.FirstOrDefault<KeyValuePair<SlideElementBase, SlideElementBase>>((KeyValuePair<SlideElementBase, SlideElementBase> kv) => kv.Key.ID == id).Value);
		}
		CopyProperties(customSlide);
		return customSlide;
	}

	public void OnSelected()
	{
	}

	public void OnDeselected()
	{
	}

	public void OnEnterEditMode(Vector2<double> point, double zoomFactor, bool isMaskForced)
	{
	}

	public CustomShape MakeElementEditable(ClosedBezierPath element)
	{
		if (element is CustomShape result)
		{
			return result;
		}
		RemoveElement(element);
		CustomShape customShape = new CustomShape(_factoryProvider.MediaFactory, _factoryProvider.TextDocumentFactory, element, base.ContainerId);
		AddElement(customShape, userInitiated: false);
		return customShape;
	}

	public void AddElement(SlideElementBase element, bool userInitiated, bool repositionElement = true, bool resetZIndex = true)
	{
		AddElements(element.ToEnumerable(), userInitiated, repositionElement, resetZIndex);
	}

	public IEnumerable<ICanvasElement> DuplicateElements(IEnumerable<ICanvasElement>? elements, bool respostionElement = true)
	{
		IEnumerable<SlideElementBase> enumerable = elements?.OfType<SlideElementBase>().CloneItems() ?? Enumerable.Empty<SlideElementBase>();
		AddMediaReferences(enumerable.ToArray(), applyTransform: true, userInitiated: true);
		AddElements(enumerable.NonNull(), userInitiated: true, respostionElement);
		return enumerable;
	}

	public void AddElements(IEnumerable<SlideElementBase> elements, bool userInitiated, bool repositionElements = true, bool resetZIndex = true, bool addMediaReferences = false)
	{
		base.UndoStack?.BeginCommit(UndoActionTypes.AddShape.ToAction());
		foreach (SlideElementBase element in elements)
		{
			if (repositionElements)
			{
				Vector2<double>[] source = Elements.Select((SlideElementBase e) => e.Position).ToArray();
				while (source.Contains(element.Position))
				{
					element.Position += ElementMarginOffset;
				}
			}
			element.AllBuilds.ForEach(delegate(IBuild b)
			{
				Builds.AddBuild(b, isReversible: true);
			});
		}
		base.UndoStack?.Commit(delegate
		{
			RemoveElements(elements);
		}, delegate
		{
			OnAddElements(elements, userInitiated: true, resetZIndex, addMediaReferences);
		});
		OnAddElements(elements, userInitiated, resetZIndex, addMediaReferences);
		base.UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	public void RemoveElement(SlideElementBase element, bool updateDataLinks = true)
	{
		RemoveElements(new SlideElementBase[1] { element }, updateDataLinks);
	}

	public void RemoveElements(IEnumerable<SlideElementBase> elements, bool updateDataLinks = true)
	{
		base.UndoStack?.BeginCommit(UndoActionTypes.DeleteElements.ToAction());
		foreach (SlideElementBase element in elements)
		{
			Builds.RemoveBuilds(element);
			if (!Elements.Remove(element))
			{
				throw new InvalidOperationException("Element doesn't belong to this slide");
			}
			element.UndoStack = null;
			element.BacklightSampler = null;
			if (updateDataLinks)
			{
				Elements.ForEach(delegate(SlideElementBase e)
				{
					e.HandleRemovedElement(element);
				});
			}
		}
		RemoveMediaReferences(elements.ToArray());
		base.UndoStack?.Commit(delegate
		{
			OnAddElements(elements, userInitiated: true, resetZIndex: false, addMediaReferences: true);
		}, delegate
		{
			RemoveElements(elements);
		});
		base.UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	private void OnAddElements(IEnumerable<SlideElementBase> elements, bool userInitiated, bool resetZIndex = true, bool addMediaReferences = false)
	{
		elements.ForEach(delegate(SlideElementBase e)
		{
			OnAddElement(e, userInitiated, resetZIndex, addMediaReferences);
		});
	}

	private void OnAddElement(SlideElementBase element, bool userInitiated, bool resetZIndex = true, bool addMediaReferences = false)
	{
		if (addMediaReferences)
		{
			AddMediaReferences(new global::_003C_003Ez__ReadOnlySingleElementList<SlideElementBase>(element), applyTransform: false, userInitiated);
		}
		element.UndoStack = base.UndoStack;
		element.BacklightSampler = (Vector2<double> p) => OnSampleBacklight(element.Position, p);
		if (element is ClosedBezierPath closedBezierPath)
		{
			closedBezierPath.MaxAutoSizeHeight = Size.Y;
			closedBezierPath.UpdateElementLinks((Guid id, string name) => Elements.Any((SlideElementBase e) => e.ID == id || e.Name == name), (Guid id, string name) => Elements.OfType<ClosedBezierPath>().FirstOrDefaultBy((ClosedBezierPath e) => e.ID == id, (ClosedBezierPath e) => e.Name == name));
		}
		Elements.Add(element, resetZIndex);
	}

	private static void AddMediaReferences(IReadOnlyList<SlideElementBase> elements, bool applyTransform, bool userInitiated)
	{
		if (applyTransform)
		{
			GetTrackedMediaFromElements(elements).ForEach(delegate(ITrackedMedia x)
			{
				x.AddToMediaServiceAndApplyTransform(userInitiated);
			});
		}
		else
		{
			GetTrackedMediaFromElements(elements).ForEach(delegate(ITrackedMedia x)
			{
				x.AddToMediaService(userInitiated);
			});
		}
	}

	private static void RemoveMediaReferences(IReadOnlyList<SlideElementBase> elements)
	{
		GetTrackedMediaFromElements(elements).ForEach(delegate(ITrackedMedia x)
		{
			x.RemoveFromMediaService(deleteAssets: false);
		});
	}

	public void ChangeChordChart(RelativePath pdfFilename, int pageNumber)
	{
		string? fullPath = pdfFilename.FullPath;
		if (fullPath == null || fullPath.IsPDFFile())
		{
			BitmapSource source = new PdfRenderer(pdfFilename).RenderPageToImage(pageNumber, 1.0);
			string mediaImported = CommonPaths.MediaImported;
			string text = Path.GetFileNameWithoutExtension(pdfFilename).DuplicateName(Directory.GetFiles(mediaImported), Path.GetFileNameWithoutExtension);
			RelativePath relativePath = (RelativePath)Path.Combine(mediaImported, text + ".png");
			if (source.TryWriteImage(relativePath))
			{
				ChangeChordChart(relativePath);
			}
		}
	}

	public void ChangeChordChart(RelativePath imageFilename)
	{
		if (ChordChart == imageFilename)
		{
			OnPropertyChanged("ChordChart");
			return;
		}
		RelativePath currentValue = ChordChart;
		base.UndoStack?.Commit(UndoActionTypes.AddChordChart.ToAction(), delegate
		{
			ChordChart = currentValue;
		}, delegate
		{
			ChordChart = imageFilename;
		}, null, null, autoFinalize: true);
		ChordChart = imageFilename;
	}

	public void RemoveChordChart()
	{
		RelativePath currentValue = ChordChart;
		base.UndoStack?.Commit(UndoActionTypes.RemoveChordChart.ToAction(), delegate
		{
			ChordChart = currentValue;
		}, delegate
		{
			ChordChart = null;
		}, null, null, autoFinalize: true);
		ChordChart = null;
	}

	public override IEnumerable<string> GetAllText()
	{
		return from e in Elements.OfType<ClosedBezierPath>().Where(delegate(ClosedBezierPath e)
			{
				TextDocument displayText = e.DisplayText;
				if ((object)displayText != null && displayText.HasText)
				{
					TextLink textLink = e.TextLink;
					if (textLink == null)
					{
						return false;
					}
					return !textLink.IsEnabled;
				}
				return false;
			})
			orderby e.ZOrder descending
			select e.DisplayText?.AllText ?? string.Empty;
	}

	public ClosedBezierPath? GetPrimaryTextElement(bool useDisplayText)
	{
		IOrderedEnumerable<ClosedBezierPath> textElements = GetTextElements(useDisplayText);
		return textElements.FirstOrDefault(delegate(ClosedBezierPath e)
		{
			if (!e.AdditionalInfo.HasFlag(AdditionalInfo.Text))
			{
				if (!useDisplayText)
				{
					TextDocument text = e.Text;
					if ((object)text != null && text.HasText)
					{
						goto IL_0050;
					}
				}
				if (useDisplayText)
				{
					return e.DisplayText?.HasText ?? false;
				}
				return false;
			}
			goto IL_0050;
			IL_0050:
			return true;
		}) ?? textElements.FirstOrDefault();
	}

	public ClosedBezierPath? GetLargestTextElementInBounds(bool useDisplayText)
	{
		return GetTextElements(useDisplayText).FirstOrDefault((ClosedBezierPath e) => new Rect<double>(Size).Intersects(new Rect<double>(e.Position, e.Size)));
	}

	private IOrderedEnumerable<ClosedBezierPath> GetTextElements(bool useDisplayText)
	{
		return from e in Elements.OfType<ClosedBezierPath>().Where(delegate(ClosedBezierPath e)
			{
				if (!useDisplayText)
				{
					TextLink textLink = e.TextLink;
					if (textLink == null || textLink.IsEnabled)
					{
						return e.TextLink?.LinkedObject == null;
					}
				}
				return true;
			})
			orderby e.Size.X * e.Size.Y descending, e.ZOrder descending
			select e;
	}

	protected override void OnUndoStackChanged(UndoStack? value)
	{
		StaticGuides.UndoStack = value;
		Elements.ForEach(delegate(SlideElementBase e)
		{
			e.UndoStack = value;
		});
		Builds.UndoStack = value;
	}

	private System.Windows.Media.Color OnSampleBacklight(Vector2<double> origin, Vector2<double> position)
	{
		position += origin;
		System.Windows.Media.Color final = Colors.Black;
		if (new Rect<double>(Vector2<double>.Zero, Size).Contains(position))
		{
			if (base.UseBackgroundColor)
			{
				mix(base.BackgroundColor);
			}
			else if (base.BacklightSampler != null)
			{
				mix(base.BacklightSampler());
			}
		}
		else
		{
			mix(Colors.LightGray);
		}
		foreach (ClosedBezierPath item in from e in Elements.OfType<ClosedBezierPath>()
			where e.Fill != null && e.Fill.IsEnabled && e.TightBounds.Contains(position)
			orderby e.ZOrder descending
			select e)
		{
			System.Windows.Media.Color? color = item.Fill?.Sample().Multiply(item.Opacity);
			if (color.HasValue)
			{
				mix(color.Value);
			}
		}
		return final;
		void mix(System.Windows.Media.Color s)
		{
			final = final.Blend(s);
		}
	}

	protected override RelativePath SerializeChordChart()
	{
		return ChordChart ?? RelativePath.Empty();
	}

	protected override IEnumerable<Pro.SerializationInterop.RVProtoData.Slide.Types.Element> SerializeElements()
	{
		return from e in Elements
			orderby e.ZOrder descending
			select e.Serialize();
	}

	protected override IEnumerable<Guid> SerializeBuildOrder()
	{
		return Builds.Select((IBuild b) => b.ID);
	}

	protected override IEnumerable<AlignmentGuide> SerializeGuidelines()
	{
		return StaticGuides.Where((StaticSL s) => s.IsEditable).Select(ToProtoAlignmentGuide);
	}

	protected override IEnumerable<AlignmentGuide> SerializeTemplateGuidelines()
	{
		return StaticGuides.Where((StaticSL s) => !s.IsEditable).Select(ToProtoAlignmentGuide);
	}

	protected override void DeserializeChordChart(RelativePath path)
	{
		ChordChart = path;
	}

	protected override void DeserializeElements(IEnumerable<Pro.SerializationInterop.RVProtoData.Slide.Types.Element> elements, ApplicationData? applicationData, string containerId)
	{
		base.TextDocumentFactory.ThrowWhenNull("TextDocumentFactory");
		Elements.DeserializeCollection(elements.Reverse(), (SlideElementBase e, Pro.SerializationInterop.RVProtoData.Slide.Types.Element p) => e.ID == p.Element_.Uuid.ToGuid(), (Pro.SerializationInterop.RVProtoData.Slide.Types.Element p) => p.GetElementFromGraphicsType(_factoryProvider, containerId), delegate(SlideElementBase e)
		{
			AddElement(e, userInitiated: false, repositionElement: false);
		}, delegate(SlideElementBase e)
		{
			RemoveElement(e);
		}, delegate(SlideElementBase e, Pro.SerializationInterop.RVProtoData.Slide.Types.Element p)
		{
			if (e is ClosedBezierPath closedBezierPath)
			{
				closedBezierPath.MaxAutoSizeHeight = Size.Y;
			}
			e.Deserialize(p, applicationData, base.TransitionDescriptions, containerId);
		});
		Elements.ForEach(delegate(SlideElementBase e)
		{
			e.DeserializeLinks(elements.First((Pro.SerializationInterop.RVProtoData.Slide.Types.Element p) => e.ID == p.Element_.Uuid.ToGuid()).DataLinks, Elements);
		});
		double? num = (from e in Elements.Reverse().OfType<ClosedBezierPath>().Where(delegate(ClosedBezierPath e)
			{
				IFill fill = e.Fill;
				return fill != null && fill.Type == FillType.BackgroundEffectBlur;
			})
			select e.Fill as BackgroundEffectBlurFill).FirstOrDefault()?.BlurAmount;
		double? num2 = (from e in Elements.Reverse().OfType<ClosedBezierPath>()
			where e.Text != null
			select e).SelectMany((ClosedBezierPath t) => t.Text.SelectMany((Paragraph p) => from r in p
			where r.Settings.Fill.TextFillType == TextFillType.BackgroundBlur
			select r.Settings.Fill as BackgroundBlurTextFill)).FirstOrDefault()?.Blur;
		BlurAmount = num ?? num2 ?? 0.5;
	}

	protected override void DeserializeBuildOrder(IEnumerable<Guid> buildOrder)
	{
		Builds.Reset(buildOrder, Elements);
	}

	protected override void DeserializeGuidelines(IEnumerable<AlignmentGuide> guidelines)
	{
		StaticGuides.AddStaticSLs(from g in guidelines.Distinct()
			select ToStaticSL(g, isEditable: true));
	}

	protected override void DeserializeTemplateGuidelines(IEnumerable<AlignmentGuide> templateGuidelines)
	{
		StaticGuides.AddStaticSLs(from g in templateGuidelines.Distinct()
			select ToStaticSL(g, isEditable: false));
	}

	private void UpdateManualBuildCount()
	{
		int num = Builds.Count((IBuild b) => b.Start == StartMode.OnClick);
		if (num != _manualBuildCount)
		{
			_manualBuildCount = num;
			OnPropertyChanged("ManualBuildCount");
		}
	}

	private static AlignmentGuide ToProtoAlignmentGuide(StaticSL guideline)
	{
		return new AlignmentGuide
		{
			Uuid = guideline.Id.ToUUID(),
			Location = guideline.Position,
			Orientation = ((!guideline.IsHorizontal) ? AlignmentGuide.Types.GuidelineOrientation.Vertical : AlignmentGuide.Types.GuidelineOrientation.Horizontal)
		};
	}

	private static StaticSL ToStaticSL(AlignmentGuide alignmentGuide, bool isEditable)
	{
		return new StaticSL(alignmentGuide.Orientation == AlignmentGuide.Types.GuidelineOrientation.Horizontal)
		{
			Id = alignmentGuide.Uuid.ToGuid(),
			Position = alignmentGuide.Location,
			IsEditable = isEditable
		};
	}

	public void ResetID(Guid? id = null)
	{
		base.ID = id ?? Guid.NewGuid();
	}

	public void SetupBackgroundMedia(VisualMedia? media)
	{
		if (BackgroundMedia != null)
		{
			BackgroundMedia.PropertyChanged -= base.RaiseLinkedValues;
		}
		if (media != null)
		{
			media.PropertyChanged += base.RaiseLinkedValues;
		}
		BackgroundMedia = media;
		this.SetupSlideBackgroundSampler(media);
		media?.UpdateContainerId(base.ContainerId);
		OnPropertyChanged("IsBackgroundMediaPending");
	}

	public static IReadOnlyList<ITrackedMedia> GetTrackedMediaFromElements(IReadOnlyList<SlideElementBase> elements)
	{
		IEnumerable<ITrackedMedia> collection = (from x in (from x in elements.OfType<IFilledElement>()
				select x.Fill).OfType<MediaFill>()
			select x.Media).OfType<ITrackedMedia>();
		IEnumerable<ITrackedMedia> collection2 = elements.OfType<ClosedBezierPath>().SelectMany(delegate(ClosedBezierPath x)
		{
			List<ITrackedMedia> foundMedia = new List<ITrackedMedia>();
			x.Text.IterateAllRuns(delegate(Pro.Text.Range range, RunBase run)
			{
				if (run.Settings.Fill is MediaTextFill { Media: ITrackedMedia media })
				{
					foundMedia.Add(media);
				}
			});
			return foundMedia;
		});
		List<ITrackedMedia> list = new List<ITrackedMedia>();
		list.AddRange(collection);
		list.AddRange(collection2);
		return new _003C_003Ez__ReadOnlyList<ITrackedMedia>(list);
	}

	public override void UpdateContainerId(string containerId)
	{
		base.UpdateContainerId(containerId);
		Elements.ForEach(delegate(SlideElementBase x)
		{
			x.UpdateContainerId(base.ContainerId);
		});
		BackgroundMedia?.UpdateContainerId(base.ContainerId);
	}
}
