using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ErrorReporting;
using Pro.Common.Mathematics;
using Pro.Common.Nullability;
using Pro.Common.ObjectBinding;
using Pro.Common.Strings;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Transitions;
using Pro.DO.Utility;
using Pro.Editor;
using Pro.Editor.Canvas.Transforming;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;
using Pro.UI.Controls;
using ProPresenter.DO.Chords;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Media;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Slide.Builds;
using ProPresenter.DO.Slide.Custom.Elements.Fills;
using ProPresenter.DO.Slide.Custom.Elements.Handles;
using ProPresenter.DO.Slide.Custom.Elements.Scrollers;
using ProPresenter.DO.Slide.Links;

namespace ProPresenter.DO.Slide.Custom.Elements;

public abstract class ClosedBezierPath : BezierPath, IFilledElement
{
	private IFill _fill;

	private TextDocument _originalText;

	private TextDocument? _linkedText;

	private FillLink _fillLink;

	private TextLink _textLink;

	private LineFillMask _lineFillMask;

	private FormattedTextBox? _editTextbox;

	private bool _isEditModeActive;

	private double _currentTextHeight;

	private TextDocument? _lastTextHeightCalculatedFor;

	private FontInfo? _lastFontTextHeightCalculatedFor;

	private int _lastCharacterSizeTextHeightCalculatedFor;

	private double _maxAutoSizeHeight = double.PositiveInfinity;

	private bool _isTextOverflowing;

	private bool _ignoreSizeChanged;

	private int _revealFromIndex;

	private readonly ObservableCollection<ICanvasElement> _canvasChildren = new ObservableCollection<ICanvasElement>();

	private readonly ObservableCollection<UIElement> _customChildren = new ObservableCollection<UIElement>();

	private readonly Func<TextDocument, double> _calculateTextHeight;

	private ITextScroller _textScroller;

	private bool _isMaskForced;

	public override BezierPathType PathType => BezierPathType.Closed;

	public override bool IsAspectRatioLockForced
	{
		get
		{
			if (Fill != null && Fill.Type == FillType.Media)
			{
				return Fill.IsAspectRatioLockForced;
			}
			return false;
		}
	}

	public virtual bool SupportsFill => true;

	public override HandleLocation SupportedCanvasHandles
	{
		get
		{
			if (IsEditModeActive)
			{
				return HandleLocation.None;
			}
			TextDocument originalText = _originalText;
			if ((object)originalText != null && originalText.Settings.ScaleMode == ScaleMode.AdjustContainerHeight)
			{
				return HandleLocation.RightCenter | HandleLocation.LeftCenter;
			}
			return base.SupportedCanvasHandles;
		}
	}

	public double MaxAutoSizeHeight
	{
		get
		{
			return _maxAutoSizeHeight;
		}
		set
		{
			SetValue("MaxAutoSizeHeight", ref _maxAutoSizeHeight, value, AutoAdjustHeight, null, referenceComparison: false);
		}
	}

	public bool IsTextOverflowing
	{
		get
		{
			if (_isTextOverflowing)
			{
				TextDocument displayText = DisplayText;
				if ((object)displayText == null)
				{
					return false;
				}
				return !displayText.Settings.ScaleMode.IsAnyOf(ScaleMode.Down, ScaleMode.UpOrDown);
			}
			return false;
		}
		private set
		{
			SetValue("IsTextOverflowing", ref _isTextOverflowing, value);
		}
	}

	public FillLink FillLink
	{
		get
		{
			return _fillLink;
		}
		[MemberNotNull("_fillLink")]
		private set
		{
			SetValue("FillLink", ref _fillLink, value, delegate(FillLink o, FillLink n)
			{
				if (o != null)
				{
					o.VisualInvalidated -= base.OnVisualInvalidated;
					o.LinkObjectUpdated -= OnFillLinkUpdated;
				}
				if (n != null)
				{
					n.VisualInvalidated += base.OnVisualInvalidated;
					n.LinkObjectUpdated += OnFillLinkUpdated;
				}
			});
		}
	}

	public IFill Fill
	{
		get
		{
			return _fill;
		}
		[MemberNotNull("_fill")]
		set
		{
			SetValue("Fill", ref _fill, value, delegate(IFill o, IFill n)
			{
				this.FillChanged?.Invoke(o, n);
				if (o != null)
				{
					TeardownFill(o);
				}
				if (n != null)
				{
					n.OnSizeChanged(Size, Size);
					SetupFill(n);
				}
				OnVisualInvalidated();
				OnDataModified();
				OnPropertyChanged("DisplayName");
				ReloadChildren();
				base.UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementFill), this, "Fill", o, n);
			});
		}
	}

	public abstract string DefaultShapeName { get; }

	protected override string DisplayName
	{
		get
		{
			if (!string.IsNullOrEmpty(TextLink?.LinkedObject?.DisplayText))
			{
				return TextLink?.LinkedObject?.DisplayText ?? string.Empty;
			}
			if ((object)DisplayText != null && DisplayText.HasText)
			{
				return DisplayText.AllText.TruncateAtNewLine(DisplayText.AllText.Length);
			}
			if (!string.IsNullOrEmpty(FillLink?.LinkedObject?.DisplayText))
			{
				return FillLink?.LinkedObject?.DisplayText ?? string.Empty;
			}
			if (!string.IsNullOrEmpty(Fill?.DisplayName))
			{
				return Fill?.DisplayName ?? string.Empty;
			}
			return DefaultShapeName;
		}
	}

	public TextLink TextLink
	{
		get
		{
			return _textLink;
		}
		[MemberNotNull("_textLink")]
		private set
		{
			SetValue("TextLink", ref _textLink, value, delegate(TextLink o, TextLink n)
			{
				if (o != null)
				{
					o.VisualInvalidated -= base.OnVisualInvalidated;
					o.LinkObjectUpdated -= OnTextLinkUpdated;
				}
				if (n != null)
				{
					n.VisualInvalidated += base.OnVisualInvalidated;
					n.LinkObjectUpdated += OnTextLinkUpdated;
					n.UndoStack = base.UndoStack;
				}
			});
		}
	}

	public TextDocument DisplayText => _linkedText ?? _originalText;

	public TextDocument Text
	{
		get
		{
			return _originalText;
		}
		[MemberNotNull("_originalText")]
		set
		{
			SetValue("Text", ref _originalText, value, delegate(TextDocument o, TextDocument n)
			{
				if (o != null)
				{
					TeardownDocument(o);
				}
				if (n != null)
				{
					SetupDocument(n);
					OnTextDocumentChanged(n);
				}
				OnPropertyChanged("DisplayText");
				OnPropertyChanged("DisplayName");
				AutoAdjustHeight();
				OnVisualInvalidated();
			});
		}
	}

	public ChildBuildCollection ChildBuilds { get; }

	public override IEnumerable<IBuild> AllBuilds => ChildBuilds.Prepend<IBuild>(base.BuildIn).Append(base.BuildOut).NonNull()
		.Skip(RevealFromIndex);

	public int RevealFromIndex
	{
		get
		{
			return _revealFromIndex;
		}
		set
		{
			SetValue("RevealFromIndex", ref _revealFromIndex, value, delegate(int o, int n)
			{
				base.UndoStack?.Commit(UndoActionTypes.ElementRevealFromIndex.ToAction(), this, "RevealFromIndex", o, n, null, null, autoFinalize: true);
				OnPropertyChanged("RevealCount");
				OnPropertyChanged("AllBuilds");
				OnDataModified();
			});
		}
	}

	public override int RevealCount => ChildBuilds.Count - ((RevealFromIndex - 1 <= ChildBuilds.Count) ? RevealFromIndex : 0);

	public LineFillMask LineFillMask
	{
		get
		{
			return _lineFillMask;
		}
		[MemberNotNull("_lineFillMask")]
		private set
		{
			SetValue("LineFillMask", ref _lineFillMask, value, delegate(LineFillMask o, LineFillMask n)
			{
				if (o != null)
				{
					o.PropertyChanged -= OnLineFillMaskChanged;
				}
				if (n != null)
				{
					n.PropertyChanged += OnLineFillMaskChanged;
					n.UndoStack = base.UndoStack;
				}
				OnVisualInvalidated();
			});
		}
	}

	public FormattedTextBox? EditTextbox
	{
		get
		{
			return _editTextbox;
		}
		private set
		{
			SetValue<FormattedTextBox>("EditTextbox", ref _editTextbox, value, delegate(FormattedTextBox o, FormattedTextBox n)
			{
				if (o != null)
				{
					TeardownEditTextbox(o);
				}
				if (n != null)
				{
					SetupEditTextbox(n);
				}
				IsEditModeActive = n != null;
			});
		}
	}

	public override bool IsEditModeActive
	{
		get
		{
			return _isEditModeActive;
		}
		protected set
		{
			SetValue("IsEditModeActive", ref _isEditModeActive, value, delegate(bool o, bool n)
			{
				OnPropertyChanged("SupportedCanvasHandles");
				OnVisualInvalidated();
				if (!n)
				{
					_isMaskForced = false;
				}
			});
		}
	}

	[MemberNotNullWhen(true, "EditTextbox")]
	public bool IsInlineEditActive
	{
		[MemberNotNullWhen(true, "EditTextbox")]
		get
		{
			if (IsEditModeActive && ShouldEditInline)
			{
				return !_isMaskForced;
			}
			return false;
		}
	}

	public bool ShouldEditInline
	{
		get
		{
			TextTransform? textTransform = Text?.Settings.Transform;
			if (textTransform.HasValue)
			{
				return textTransform.GetValueOrDefault() == TextTransform.None;
			}
			return false;
		}
	}

	public override bool MaskWhileEditing => !IsInlineEditActive;

	public override ImmutableObservableCollection<ICanvasElement> CanvasChildren { get; }

	public override ImmutableObservableCollection<UIElement> CustomChildren { get; }

	public override ChildVisibilityMode ChildVisibilityMode => ChildVisibilityMode.HiddenUntilActivated;

	public override bool SupportsEditMode
	{
		get
		{
			TextLink textLink = TextLink;
			if (textLink == null || textLink.IsEnabled)
			{
				return TextLink?.LinkedObject == null;
			}
			return true;
		}
	}

	public ITextScroller TextScroller
	{
		get
		{
			return _textScroller;
		}
		[MemberNotNull("_textScroller")]
		private set
		{
			SetValue("TextScroller", ref _textScroller, value, delegate(ITextScroller o, ITextScroller n)
			{
				if (o != null)
				{
					o.DataModified -= base.OnDataModified;
					o.DataModified -= base.OnVisualInvalidated;
				}
				if (n != null)
				{
					n.DataModified += base.OnDataModified;
					n.DataModified += base.OnVisualInvalidated;
					n.UndoStack = base.UndoStack;
				}
			});
		}
	}

	protected IMediaFactory MediaFactory { get; }

	protected ITextDocumentFactory TextDocumentFactory { get; }

	public event Action<IFill, IFill>? FillChanged;

	public event Action<HTMLFill, Vector2<double>>? DrawWebFill;

	public override ObjectBinder<BezierPath, ISlide.Types.IElement> CreateBinder(IUiScheduler uiScheduler, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, ISlide.Types.IElement right, IErrorReporter errorReporter)
	{
		IEntityFactory entityFactory = factoryProvider.EntityFactory;
		ObjectBinder<ClosedBezierPath, ISlide.Types.IElement> elementBinder = new ObjectBinder<ClosedBezierPath, ISlide.Types.IElement>(this, right);
		elementBinder.Bind((ClosedBezierPath l) => l.WhenPropertyChanges("TextScroller"), (ISlide.Types.IElement r) => r.TextScroller.WhenValueChanges, delegate(ClosedBezierPath l, ISlide.Types.IElement r)
		{
			ISlide.Types.IElement.Types.ITextScroller textScroller = entityFactory.Create<ISlide.Types.IElement.Types.ITextScroller>();
			r.TextScroller.Set(textScroller);
			ObjectBinder<TextScroller, ISlide.Types.IElement.Types.ITextScroller> objectBinder = ProPresenter.DO.Slide.Custom.Elements.Scrollers.TextScroller.CreateBinder(l.TextScroller as TextScroller, textScroller);
			objectBinder.InitializeRightFromLeft();
			textScroller.RegisterLinkedDisposable(objectBinder);
		}, delegate(ISlide.Types.IElement r, ClosedBezierPath l)
		{
			ObjectBinder<TextScroller, ISlide.Types.IElement.Types.ITextScroller> objectBinder2 = ProPresenter.DO.Slide.Custom.Elements.Scrollers.TextScroller.CreateBinder(l.TextScroller as TextScroller, r.TextScroller.Value);
			objectBinder2.InitializeLeftFromRight();
			r.TextScroller.Value.RegisterLinkedDisposable(objectBinder2);
		});
		ObjectBinder<BezierPath, ISlide.Types.IElement> objectBinder3 = base.CreateBinder(uiScheduler, factoryProvider, transitionDescriptions, right, errorReporter);
		objectBinder3.DoOnInitializeRightFromLeft(elementBinder.InitializeRightFromLeft).DoOnInitializeLeftFromRight(elementBinder.InitializeLeftFromRight).RegisterChildDisposable(() => elementBinder);
		return objectBinder3;
	}

	protected override ObjectBinder<BezierPath, IGraphics.Types.IElement> CreateGraphicsElementBinder(IUiScheduler uiScheduler, IProPresenterDOFactoryProvider factoryProvider, IGraphics.Types.IElement right, IErrorReporter errorReporter)
	{
		IEntityFactory entityFactory = factoryProvider.EntityFactory;
		ObjectBinder<BezierPath, IGraphics.Types.IElement> objectBinder = base.CreateGraphicsElementBinder(uiScheduler, factoryProvider, right, errorReporter);
		objectBinder.Bind(delegate(BezierPath l)
		{
			ClosedBezierPath path = l as ClosedBezierPath;
			return (path != null) ? (from _ in l.WhenPropertyChanges("Text")
				select Observable.FromEvent(delegate(Action<TextDocument> h)
				{
					path.Text.DocumentChanged += h;
				}, delegate(Action<TextDocument> h)
				{
					path.Text.DocumentChanged -= h;
				}).StartWith(path.Text)).Switch().ToUnit() : Observable.Empty<Unit>();
		}, (IGraphics.Types.IElement r) => r.Text.WhenAnyValueChanges, delegate(BezierPath l, IGraphics.Types.IElement r)
		{
			if (l is ClosedBezierPath closedBezierPath)
			{
				IGraphics.Types.IText text = entityFactory.Create<IGraphics.Types.IText>();
				TextDocument.SerializeToEntity(entityFactory, closedBezierPath.Text, text);
				r.Text.Set(text);
			}
		}, delegate(IGraphics.Types.IElement r, BezierPath l)
		{
			if (l is ClosedBezierPath closedBezierPath2)
			{
				TextDocument text2 = TextDocument.DeserializeEntity(factoryProvider.TextFillMediaFactory, r.Text.Value, l.ContainerId);
				closedBezierPath2.Text = text2;
			}
		}, null, uiScheduler.Scheduler).Bind((BezierPath l) => (l is ClosedBezierPath propertyChangedObject) ? propertyChangedObject.WhenPropertyChanges("LineFillMask").ToUnit() : Observable.Empty<Unit>(), (IGraphics.Types.IElement r) => r.Mask.WhenValueChanges, delegate(BezierPath l, IGraphics.Types.IElement r)
		{
			if (l is ClosedBezierPath closedBezierPath3)
			{
				IGraphics.Types.IElement.Types.IMask.ITextLineMask textLineMask = entityFactory.Create<IGraphics.Types.IElement.Types.IMask.ITextLineMask>();
				r.Mask.Set(textLineMask);
				ObjectBinder<LineFillMask, IGraphics.Types.IElement.Types.IMask> objectBinder2 = CreateGraphicsTextLineMaskBinder(closedBezierPath3.LineFillMask, textLineMask);
				objectBinder2.InitializeRightFromLeft();
				textLineMask.RegisterLinkedDisposable(objectBinder2);
			}
		}, delegate(IGraphics.Types.IElement r, BezierPath l)
		{
			if (l is ClosedBezierPath closedBezierPath4)
			{
				ObjectBinder<LineFillMask, IGraphics.Types.IElement.Types.IMask> objectBinder3 = CreateGraphicsTextLineMaskBinder(closedBezierPath4.LineFillMask, r.Mask.Value);
				objectBinder3.InitializeLeftFromRight();
				r.Mask.Value.RegisterLinkedDisposable(objectBinder3);
			}
		}, null, uiScheduler.Scheduler).Bind<Unit, Unit>(null, (IGraphics.Types.IElement r) => r.Fill.WhenValueChanges.ToUnit(), delegate(BezierPath l, IGraphics.Types.IElement r)
		{
			if (l is ClosedBezierPath closedBezierPath5)
			{
				IGraphics.Types.IFill fill = entityFactory.Create<IGraphics.Types.IFill>();
				r.Fill.Set(fill);
				ObjectBinder<ClosedBezierPath, IGraphics.Types.IFill> objectBinder4 = closedBezierPath5.CreateFillBinder(uiScheduler, factoryProvider, fill);
				objectBinder4.InitializeRightFromLeft();
				fill.RegisterLinkedDisposable(objectBinder4);
			}
		}, delegate(IGraphics.Types.IElement r, BezierPath l)
		{
			if (l is ClosedBezierPath closedBezierPath6)
			{
				ObjectBinder<ClosedBezierPath, IGraphics.Types.IFill> objectBinder5 = closedBezierPath6.CreateFillBinder(uiScheduler, factoryProvider, r.Fill.Value);
				objectBinder5.InitializeLeftFromRight();
				r.Fill.Value.RegisterLinkedDisposable(objectBinder5);
			}
		});
		return objectBinder;
	}

	private static ObjectBinder<LineFillMask, IGraphics.Types.IElement.Types.IMask> CreateGraphicsTextLineMaskBinder(LineFillMask left, IGraphics.Types.IElement.Types.IMask right)
	{
		return new ObjectBinder<LineFillMask, IGraphics.Types.IElement.Types.IMask>(left, right);
	}

	protected ClosedBezierPath(IMediaFactory mediaFactory, ITextDocumentFactory textDocumentFactory, string containerId, Func<TextDocument, double>? calculateTextHeight = null)
	{
		MediaFactory = mediaFactory;
		TextDocumentFactory = textDocumentFactory;
		base.UpdateContainerId(containerId);
		_calculateTextHeight = calculateTextHeight ?? new Func<TextDocument, double>(GetArrangedTextHeight);
		ChildBuilds = new ChildBuildCollection(this);
		ChildBuilds.DataModified += delegate
		{
			OnDataModified();
			OnPropertyChanged("AllBuilds");
		};
		Text = new TextDocument();
		Fill = new SolidColorFill();
		FillLink = new FillLink();
		TextLink = new TextLink();
		LineFillMask = new LineFillMask();
		TextScroller = new TextScroller();
		CanvasChildren = new ImmutableObservableCollection<ICanvasElement>(_canvasChildren);
		CustomChildren = new ImmutableObservableCollection<UIElement>(_customChildren);
		base.CustomHandlesCollection.Add(new TextOverflowHandleData(this));
	}

	public override bool RenderEquals([NotNullWhen(true)] SlideElementBase? other)
	{
		if (base.RenderEquals(other) && other is ClosedBezierPath closedBezierPath && _fill != null && _fill.RenderEquals(closedBezierPath.Fill) && _fillLink != null && _fillLink.RenderEquals(closedBezierPath._fillLink) && (object)DisplayText != null && DisplayText.Equals(closedBezierPath.DisplayText) && _textLink != null && _textLink.RenderEquals(closedBezierPath._textLink) && _textScroller != null && _textScroller.RenderEquals(closedBezierPath._textScroller) && _lineFillMask != null && _lineFillMask.RenderEquals(closedBezierPath._lineFillMask))
		{
			return AllBuilds.ContentsMatchExactly(closedBezierPath.AllBuilds, (IBuild l, IBuild r) => l.RenderEquals(r));
		}
		return false;
	}

	public override int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(new IEnumerable[1] { AllBuilds.ToArray() }, base.GetRenderHashCode(), _fill, _fillLink, DisplayText, _textLink, _lineFillMask);
	}

	protected virtual void OnTextDocumentChanged(TextDocument document)
	{
		TextLink textLink = TextLink;
		if (textLink != null && textLink.IsEnabled)
		{
			SetLinkedText(null);
		}
		double textHeight = CalculateTextHeight();
		AutoAdjustHeight(textHeight);
		UpdateTextOverflow(textHeight);
		OnVisualInvalidated();
		OnDataModified();
		OnPropertyChanged("DisplayText");
		OnPropertyChanged("Text");
		OnPropertyChanged("DisplayName");
		UpdateRevealRanges();
		UpdateTextContainerIds(Text, base.ContainerId);
	}

	private void OnTextDocumentSettingsChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "ScaleMode")
		{
			OnPropertyChanged("SupportedCanvasHandles");
			OnPropertyChanged("IsTextOverflowing");
		}
	}

	private void OnLineFillMaskChanged(object? sender, PropertyChangedEventArgs e)
	{
		OnVisualInvalidated();
		OnDataModified();
	}

	protected virtual void ReloadChildren()
	{
		_canvasChildren.Clear();
		if (Fill != null)
		{
			_canvasChildren.AddRange(Fill.GetEditableChildren(this));
		}
	}

	protected override void OnSizeChanged(Vector2<double> oldValue, Vector2<double> newValue, bool applySideEffects = true)
	{
		Fill?.OnSizeChanged(oldValue, newValue);
		if (_editTextbox != null)
		{
			_editTextbox.Width = newValue.X;
			_editTextbox.Height = newValue.Y;
		}
		double textHeight = CalculateTextHeight();
		AutoAdjustHeight(textHeight);
		UpdateTextOverflow(textHeight);
		if ((object)Text != null)
		{
			Text.Settings.LayoutWidth = newValue.X;
		}
		if (TextScroller != null)
		{
			TextScroller.UpdateMaxSize(newValue, applySideEffects);
		}
	}

	protected override void OnResolveLinkedData(ILinkData? linkData)
	{
		base.OnResolveLinkedData(linkData);
		TextLink textLink = TextLink;
		if (textLink != null && textLink.IsEnabled)
		{
			SetLinkedText(linkData);
		}
		else
		{
			TransposeText(linkData?.KeyInformation?.BaseKey, linkData?.KeyInformation?.TargetKey);
		}
		if (FillLink != null && FillLink.IsEnabled && FillLink.LinkedObject != null)
		{
			IFill fill = FillLink.LinkedObject.GetFill(linkData);
			if (fill != null)
			{
				Fill = fill;
			}
			else if (Fill != null)
			{
				Fill.IsEnabled = false;
			}
		}
	}

	protected internal override void CopyProperties(SlideElementBase slideElement)
	{
		ClosedBezierPath closedBezierPath = (ClosedBezierPath)slideElement;
		base.CopyProperties((SlideElementBase)closedBezierPath);
		closedBezierPath.MaxAutoSizeHeight = MaxAutoSizeHeight;
		closedBezierPath.Fill = _fill.Clone();
		closedBezierPath._currentTextHeight = _currentTextHeight;
		closedBezierPath._lastTextHeightCalculatedFor = _lastTextHeightCalculatedFor;
		closedBezierPath._lastFontTextHeightCalculatedFor = _lastFontTextHeightCalculatedFor;
		closedBezierPath._lastCharacterSizeTextHeightCalculatedFor = _lastCharacterSizeTextHeightCalculatedFor;
		closedBezierPath.Text = _originalText.Clone();
		closedBezierPath.FillLink = (FillLink)FillLink.Clone();
		closedBezierPath.TextLink = (TextLink)TextLink.Clone();
		if (_linkedText != null)
		{
			closedBezierPath._linkedText = _linkedText.Clone();
			closedBezierPath._lastTextHeightCalculatedFor = null;
		}
		for (int i = 0; i < ChildBuilds.Count; i++)
		{
			ChildBuild childBuild = ChildBuilds.ElementAtOrDefault(i);
			ChildBuild childBuild2 = closedBezierPath.ChildBuilds.ElementAtOrDefault(i);
			if (childBuild2 != null && childBuild != null)
			{
				childBuild2.Start = childBuild.Start;
				childBuild2.Delay = childBuild.Delay;
			}
		}
		closedBezierPath.LineFillMask = LineFillMask.Clone();
		closedBezierPath.TextScroller = TextScroller.Clone();
	}

	protected internal override void CopyBuildProperties(SlideElementBase slideElement)
	{
		ClosedBezierPath obj = (ClosedBezierPath)slideElement;
		obj.ChildBuilds.Clear();
		base.CopyBuildProperties(slideElement);
		obj.RevealFromIndex = RevealFromIndex;
		obj.UpdateRevealRanges();
	}

	public override void OnEnterEditMode(Vector2<double> point, double zoomFactor, bool isMaskForced)
	{
		if (IsLocked)
		{
			return;
		}
		_canvasChildren.Clear();
		_isMaskForced = isMaskForced;
		if (!_isMaskForced && ShouldEditInline)
		{
			if (EditTextbox == null)
			{
				EditTextbox = new FormattedTextBox(base.BacklightSampler, point)
				{
					SpellCheckEnable = true,
					Document = Text,
					Width = Size.X,
					Height = Size.Y
				};
				_customChildren.Add(EditTextbox);
			}
		}
		else
		{
			IsEditModeActive = true;
		}
		EditTextbox?.AdjustCaretWidth(zoomFactor);
	}

	public void EditChildren()
	{
		ReloadChildren();
	}

	public override void OnDeselected()
	{
		IsEditModeActive = false;
		EditTextbox = null;
		base.UndoStack?.FinalizeNextAction();
		_customChildren.Clear();
	}

	protected internal override Pro.SerializationInterop.RVProtoData.Slide.Types.Element Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Slide.Types.Element element = base.Serialize();
		if (TextLink != null && TextLink.IsEnabled)
		{
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink dataLink = TextLink.Serialize();
			element.DataLinks.Add(dataLink);
			BackWriteTextTransformToLinks(dataLink);
		}
		if (FillLink != null && FillLink.IsEnabled)
		{
			element.DataLinks.Add(FillLink.Serialize());
		}
		element.RevealFromIndex = (uint)RevealFromIndex;
		element.ChildBuilds.AddRange(ChildBuilds.Select((ChildBuild b) => b.Serialize()));
		return element;
	}

	private void BackWriteTextTransformToLinks(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink protoTextLink)
	{
		if ((object)Text != null)
		{
			if (protoTextLink.AlternateText != null)
			{
				protoTextLink.AlternateText.TextTransform = Text.Settings.Transform.SerializeForLink();
			}
			if (protoTextLink.SlideText != null)
			{
				protoTextLink.SlideText.ElementTextTransform = Text.Settings.Transform.SerializeForLink();
			}
		}
	}

	protected override Graphics.Types.Fill? SerializeFill()
	{
		return Fill?.Serialize();
	}

	protected override Graphics.Types.Text SerializeText()
	{
		return Text.ToProtoText();
	}

	protected override Graphics.Types.Text.Types.LineFillMask? SerializeLineFillMask()
	{
		return LineFillMask?.Serialize();
	}

	protected override Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextScroller? SerializeTextScroller()
	{
		return TextScroller?.Serialize();
	}

	protected override void DeserializeChildBuilds(IEnumerable<Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.ChildBuild> protoChildBuilds)
	{
		foreach (Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.ChildBuild protoChildBuild in protoChildBuilds)
		{
			int index = (int)protoChildBuild.Index;
			(ChildBuilds.FirstOrDefault((ChildBuild b) => b.Index == index) ?? ChildBuilds.Add(index)).Deserialize(protoChildBuild);
		}
	}

	protected override void DeserializeRevealFromIndex(uint index)
	{
		RevealFromIndex = (int)index;
	}

	protected internal override void DeserializeLinks(IEnumerable<Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink> protoDataLinks, IEnumerable<SlideElementBase> otherElements)
	{
		base.DeserializeLinks(protoDataLinks, otherElements);
		IEnumerable<ClosedBezierPath> otherElements2 = otherElements.OfType<ClosedBezierPath>();
		if (TextLink != null)
		{
			TextLink.LinkedObject = DataLinkFactory.GenerateLinkedTextObject(protoDataLinks, otherElements2);
		}
		if (FillLink != null)
		{
			FillLink.LinkedObject = DataLinkFactory.GenerateLinkedFillObject(protoDataLinks, otherElements2);
		}
		if ((object)Text != null && DataLinkFactory.TryGetTextTransform(protoDataLinks, Text.Settings.Transform, out var textTransform))
		{
			Text.Settings.Transform = textTransform;
		}
	}

	protected override void DeserializeFill(Graphics.Types.Fill fill, string containerId)
	{
		base.ContainerId = containerId;
		if (fill != null)
		{
			Fill = FillGenerator.DeserializeFill(fill, MediaFactory, containerId);
		}
	}

	protected override void DeserializeText(Graphics.Types.Text? text, ApplicationData? applicationData, string containerId)
	{
		base.ContainerId = containerId;
		TextDocument textDocument = ((text == null) ? null : TextDocumentFactory.Create(text, containerId));
		if ((object)textDocument == null)
		{
			Text?.Clear();
			return;
		}
		Text = textDocument;
		UpdateTextContainerIds(Text, containerId);
	}

	protected override void DeserializeLineFillMask(Graphics.Types.Text.Types.LineFillMask protoLineFillMask)
	{
		LineFillMask?.Deserialize(protoLineFillMask);
	}

	protected override void DeserializeTextScroller(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.TextScroller textScroller)
	{
		TextScroller?.Deserialize(textScroller);
	}

	private void SetupFill(IFill fill)
	{
		fill.UndoStack = base.UndoStack;
		fill.VisualInvalidated += base.OnVisualInvalidated;
		fill.DataModified += Fill_DataModified;
		fill.UpdateContainerId(base.ContainerId);
		if (fill is HTMLFill hTMLFill)
		{
			hTMLFill.DrawWebPage += HtmlFill_DrawWebPage;
			HtmlFill_DrawWebPage(hTMLFill);
		}
	}

	private void TeardownFill(IFill fill)
	{
		fill.VisualInvalidated -= base.OnVisualInvalidated;
		fill.DataModified -= Fill_DataModified;
		if (fill is HTMLFill hTMLFill)
		{
			hTMLFill.DrawWebPage -= HtmlFill_DrawWebPage;
		}
	}

	private void SetupDocument(TextDocument document)
	{
		document.DocumentChanged += OnTextDocumentChanged;
		document.Settings.PropertyChanged += OnTextDocumentSettingsChanged;
		document.UndoStack = base.UndoStack;
		UpdateTextContainerIds(Text, base.ContainerId);
	}

	private void TeardownDocument(TextDocument document)
	{
		document.DocumentChanged -= OnTextDocumentChanged;
		document.Settings.PropertyChanged -= OnTextDocumentSettingsChanged;
		document.UndoStack = null;
	}

	private void TeardownEditTextbox(FormattedTextBox textBox)
	{
		textBox.ExitRequested -= OnDeselected;
	}

	private void SetupEditTextbox(FormattedTextBox textBox)
	{
		textBox.ExitRequested += OnDeselected;
	}

	private void AutoAdjustHeight()
	{
		AutoAdjustHeight(CalculateTextHeight());
	}

	private void AutoAdjustHeight(double textHeight)
	{
		UpdateTextOverflow(textHeight);
		if (!_ignoreSizeChanged)
		{
			TextDocument displayText = DisplayText;
			if ((object)displayText != null && displayText.Settings.ScaleMode == ScaleMode.AdjustContainerHeight)
			{
				_ignoreSizeChanged = true;
				base.UndoStack?.StartIgnoring();
				FitToText(textHeight);
				base.UndoStack?.StopIgnoring();
				_ignoreSizeChanged = false;
			}
		}
	}

	public void FitToText()
	{
		FitToText(CalculateTextHeight());
	}

	private void FitToText(double textHeight)
	{
		textHeight = Math.Min(textHeight, GetMaxAutoHeight());
		TextDocument displayText = DisplayText;
		double num = ((((object)displayText != null && displayText.Settings.Alignment == DocumentAlignment.Bottom) ? Math.Min(Size.Y, Math.Abs(MaxAutoSizeHeight - Position.Y)) : Size.Y) - textHeight) * GetAutoPositionScalar();
		Position = new Vector2<double>(Position.X, Math.Max(0.0, Position.Y + num));
		Size = new Vector2<double>(Size.X, textHeight);
	}

	private void UpdateTextOverflow(double textHeight)
	{
		TextDocument displayText = DisplayText;
		IsTextOverflowing = (object)displayText != null && displayText.HasText && textHeight > Size.Y;
	}

	private double CalculateTextHeight()
	{
		if (!(DisplayText != _lastTextHeightCalculatedFor))
		{
			FontInfo? lastFontTextHeightCalculatedFor = _lastFontTextHeightCalculatedFor;
			FontInfo font = DisplayText.Attributes.RunSettings.Font;
			if (lastFontTextHeightCalculatedFor.HasValue && !(lastFontTextHeightCalculatedFor.GetValueOrDefault() != font) && _lastCharacterSizeTextHeightCalculatedFor == DisplayText.Attributes.RunSettings.CharacterSize)
			{
				return _currentTextHeight;
			}
		}
		_lastTextHeightCalculatedFor = DisplayText.Clone();
		_lastFontTextHeightCalculatedFor = DisplayText.Attributes.RunSettings.Font;
		_lastCharacterSizeTextHeightCalculatedFor = DisplayText.Attributes.RunSettings.CharacterSize;
		double currentTextHeight = _calculateTextHeight(DisplayText) + DisplayText.Settings.Margins.Top + DisplayText.Settings.Margins.Bottom;
		_currentTextHeight = currentTextHeight;
		return _currentTextHeight;
	}

	private double GetAutoPositionScalar()
	{
		return DisplayText?.Settings.Alignment switch
		{
			DocumentAlignment.Top => 0.0, 
			DocumentAlignment.Middle => 0.5, 
			DocumentAlignment.Bottom => 1.0, 
			_ => throw new NotSupportedException(), 
		};
	}

	private double GetMaxAutoHeight()
	{
		double top = Position.Y;
		double height = Size.Y;
		return DisplayText?.Settings.Alignment switch
		{
			DocumentAlignment.Top => MaxAutoSizeHeight - top, 
			DocumentAlignment.Middle => MaxAutoSizeHeight - Math.Abs(elementCenter() - boundsCenter()) * 2.0, 
			DocumentAlignment.Bottom => top + adjustedBottom(), 
			_ => throw new NotSupportedException(), 
		};
		double adjustedBottom()
		{
			if (!(top + height > MaxAutoSizeHeight))
			{
				return height;
			}
			return Math.Abs(MaxAutoSizeHeight - top);
		}
		double boundsCenter()
		{
			return MaxAutoSizeHeight / 2.0;
		}
		double elementCenter()
		{
			return top + height / 2.0;
		}
	}

	private double GetArrangedTextHeight(TextDocument document)
	{
		if (UnitTestDetector.IsInUnitTest)
		{
			return 0.0;
		}
		if (!document.HasText)
		{
			return ArrangedText.GetEmptyTextHeight(document.Attributes.RunSettings);
		}
		return ArrangedText.CalculateHeight(SharedTypefaceLibrary.Library, document, new Vector2<double>(Size.X.Abs(), double.PositiveInfinity));
	}

	private void Fill_DataModified(IFill fill)
	{
		OnDataModified();
		OnPropertyChanged("DisplayName");
	}

	private void OnFillLinkUpdated()
	{
		OnVisualInvalidated();
		OnDataModified();
	}

	private void OnTextLinkUpdated()
	{
		TextLink textLink = TextLink;
		if (textLink != null && textLink.IsEnabled)
		{
			SetLinkedText(null);
		}
		else if (_linkedText != null)
		{
			ChangeLinkedText(null);
		}
		OnVisualInvalidated();
		OnDataModified();
		OnPropertyChanged("Name");
	}

	private void ChangeLinkedText(TextDocument? linkedText)
	{
		TextDocument? linkedText2 = _linkedText;
		_linkedText = linkedText;
		if (linkedText2 != _linkedText)
		{
			OnPropertyChanged("DisplayText");
		}
	}

	private void SetLinkedText(ILinkData? linkData)
	{
		ILinkedTextObject linkedTextObject = TextLink?.LinkedObject;
		if (linkedTextObject != null)
		{
			switch (linkedTextObject.FormattingType)
			{
			case FormattingType.None:
				insertLinkText(linkedTextObject.GetText(linkData));
				break;
			case FormattingType.Full:
			{
				TextDocument textDocument = ((linkData != null && (object)_linkedText != null) ? linkedTextObject.GetFormattedText(linkData, _linkedText) : null);
				if (textDocument != null)
				{
					ChangeLinkedText(textDocument);
				}
				else
				{
					insertLinkText(linkedTextObject.GetText(linkData));
				}
				break;
			}
			case FormattingType.Additional:
				insertLinkText(linkedTextObject.GetText(linkData) ?? string.Empty);
				linkedTextObject.FormatText(linkData, _linkedText);
				break;
			}
		}
		else
		{
			ChangeLinkedText(null);
		}
		TransposeText(linkData?.KeyInformation?.BaseKey, linkData?.KeyInformation?.TargetKey);
		AutoAdjustHeight();
		void insertLinkText(string? linkText)
		{
			ChangeLinkedText(_originalText?.CloneAsEmpty());
			_linkedText?.InsertTextAndParagraphs(0, linkText ?? string.Empty);
		}
	}

	private void TransposeText(Key? baseKey, Key? targetKey)
	{
		TextDocument displayText = DisplayText;
		if ((object)displayText == null || !displayText.Settings.ChordPro.Enabled)
		{
			return;
		}
		if ((object)_linkedText == null)
		{
			_linkedText = Text?.Clone();
		}
		TextDocument text = DisplayText;
		text.IterateAllRuns(delegate(Pro.Text.Range range, RunBase run)
		{
			string chordAnnotation = run.Settings.ChordAnnotation;
			if (!chordAnnotation.NullableIsNullOrWhiteSpace())
			{
				ChordTranspositionProvider.ChordTranspose(baseKey ?? Key.Default, targetKey ?? Key.Default, text.Settings.ChordPro.Notation, chordAnnotation, out string transposedChord, out (int, int)[] superscriptRanges);
				run.Settings.ChordAnnotation = transposedChord;
				run.Settings.ChordSuperscriptRanges = superscriptRanges.Select(((int start, int end) r) => new Pro.Text.Range(r.start, r.end)).ToArray();
			}
		});
	}

	protected override void OnUndoStackChanged(UndoStack? undoStack)
	{
		if (Fill != null)
		{
			Fill.UndoStack = undoStack;
		}
		if (base.Shadow != null)
		{
			base.Shadow.UndoStack = undoStack;
		}
		if (base.Stroke != null)
		{
			base.Stroke.UndoStack = undoStack;
		}
		if ((object)Text != null)
		{
			Text.UndoStack = undoStack;
		}
		if (FillLink != null)
		{
			FillLink.UndoStack = undoStack;
		}
		if (TextLink != null)
		{
			TextLink.UndoStack = undoStack;
		}
		if (TextScroller != null)
		{
			TextScroller.UndoStack = undoStack;
		}
		if (LineFillMask != null)
		{
			LineFillMask.UndoStack = undoStack;
		}
	}

	private void HtmlFill_DrawWebPage(HTMLFill htmlFill)
	{
		this.DrawWebFill?.Invoke(htmlFill, Size);
	}

	private void UpdateRevealRanges()
	{
		if (base.RevealType == RevealType.None)
		{
			ChildBuilds.Clear();
			return;
		}
		Pro.Text.Range[] source = GetTextRevealRanges().ToArray();
		List<ChildBuild> list = new List<ChildBuild>();
		int index = 0;
		foreach (Pro.Text.Range item in source.Where((Pro.Text.Range r) => r != Pro.Text.Range.Empty))
		{
			ChildBuild childBuild = ChildBuilds.FirstOrDefault((ChildBuild b) => b.Index == index) ?? ChildBuilds.Add(index);
			childBuild.Range = item;
			list.Add(childBuild);
			index++;
		}
		ChildBuilds.Remove(ChildBuilds.Except(list).ToArray());
		OnPropertyChanged("RevealCount");
	}

	private IEnumerable<Pro.Text.Range> GetTextRevealRanges()
	{
		if (base.BuildIn == null)
		{
			return Array.Empty<Pro.Text.Range>();
		}
		List<Pro.Text.Range> revealRanges = new List<Pro.Text.Range>();
		TextDocument originalText = _originalText;
		if (base.RevealType == RevealType.Bullet)
		{
			bool firstParagraph = true;
			originalText?.IterateAllParagraphs(delegate(Pro.Text.Range range, Paragraph paragraph)
			{
				if (!firstParagraph && paragraph.TextLength > 0)
				{
					revealRanges.Add(range);
				}
				firstParagraph = false;
			});
		}
		else if (base.RevealType == RevealType.Underline)
		{
			originalText?.IterateAllRuns(delegate(Pro.Text.Range range, RunBase run)
			{
				if (run.Settings.Underline)
				{
					revealRanges.Add(range);
				}
			});
			int num = 1;
			while (num < revealRanges.Count)
			{
				if (revealRanges[num - 1].End == revealRanges[num].Start)
				{
					revealRanges[num - 1] = new Pro.Text.Range(revealRanges[num - 1].Start, revealRanges[num].End);
					revealRanges.RemoveAt(num);
				}
				else
				{
					num++;
				}
			}
		}
		return revealRanges;
	}

	protected override void OnBuildInChanged(Build? o, Build? n)
	{
		RevealFromIndex = 0;
	}

	protected override void OnRevealTypeChanged(RevealType o, RevealType n)
	{
		if (n == RevealType.None)
		{
			RevealFromIndex = 0;
		}
		UpdateRevealRanges();
	}

	public override void UpdateContainerId(string containerId)
	{
		base.UpdateContainerId(containerId);
		Fill?.UpdateContainerId(containerId);
		UpdateTextContainerIds(Text, containerId);
	}

	private static void UpdateTextContainerIds(TextDocument text, string containerId)
	{
		text.IterateAllRuns(delegate(Pro.Text.Range range, RunBase run)
		{
			run.Settings.Fill?.UpdateContainerId(containerId);
		});
	}
}
