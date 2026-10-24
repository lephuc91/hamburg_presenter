using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.Common.Nullability;
using Pro.DO.Application;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using Pro.DO.Utility;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Transitions;

namespace ProPresenter.DO.Slide;

public abstract class SlideBase : LinkedNotifyPropertyChangedBase, IRenderEquatable<SlideBase>, IRenderHashable, ICloneable<SlideBase>, ISizeableTarget, INotifyPropertyChanged, IHasMediaContainerId, ICanReceiveMediaContainerIdUpdates
{
	private bool _useBackgroundColor;

	private System.Windows.Media.Color _backgroundColor = Colors.Black;

	private UndoStack? _undoStack;

	private TransitionParameters? _selectedTransition;

	private TextDocument? _note;

	public readonly System.Action _ignoreBackgroundColorsChangedAction;

	protected ITransitionDescriptionCollection TransitionDescriptions { get; }

	public abstract SlideType Type { get; }

	public abstract int ManualBuildCount { get; }

	public abstract Vector2<double> Size { get; }

	public Guid ID { get; protected set; } = Guid.NewGuid();

	public bool UseBackgroundColor
	{
		get
		{
			return _useBackgroundColor;
		}
		set
		{
			SetValue("UseBackgroundColor", ref _useBackgroundColor, value, delegate(bool o, bool n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.UseSlideColor), this, "UseBackgroundColor", o, n, null, null, autoFinalize: true);
				InvalidateVisual();
				OnDataModified();
			});
		}
	}

	public System.Windows.Media.Color BackgroundColor
	{
		get
		{
			return _backgroundColor;
		}
		set
		{
			SetValue("BackgroundColor", ref _backgroundColor, value, (Action<System.Windows.Media.Color, System.Windows.Media.Color>?)delegate
			{
				InvalidateVisual();
				OnDataModified();
			}, (Predicate<System.Windows.Media.Color>?)null, referenceComparison: false);
		}
	}

	public TextDocument? Note
	{
		get
		{
			return _note;
		}
		private set
		{
			SetValue<TextDocument>("Note", ref _note, value, delegate(TextDocument o, TextDocument n)
			{
				if (o != null)
				{
					o.DocumentChanged -= NotesChanged;
				}
				if (n != null)
				{
					n.DocumentChanged += NotesChanged;
				}
			});
		}
	}

	public TransitionParameters? SelectedTransition
	{
		get
		{
			return _selectedTransition;
		}
		set
		{
			SetValue<TransitionParameters>("SelectedTransition", ref _selectedTransition, value, delegate(TransitionParameters o, TransitionParameters n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ChangeSlideTransition), this, "SelectedTransition", o, n, null, null, autoFinalize: true);
				OnDataModified();
			});
		}
	}

	public virtual TextDocument? Text => null;

	public virtual TextDocument? DisplayText => null;

	public UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			if (Note != null)
			{
				Note.UndoStack = value;
			}
			_undoStack = value;
			OnUndoStackChanged(value);
		}
	}

	protected internal Func<System.Windows.Media.Color>? BacklightSampler { get; set; }

	protected ITextDocumentFactory? TextDocumentFactory { get; }

	public string ContainerId { get; protected set; } = "";

	public event System.Action? VisualInvalidated;

	public event Action<SlideBase>? DataModified;

	protected SlideBase(ITransitionDescriptionCollection transitionDescriptions)
	{
		TransitionDescriptions = transitionDescriptions;
		SetupNotes(new TextDocument());
		_ignoreBackgroundColorsChangedAction = InvalidateVisual;
		Advanced.Settings.RegisterIgnoreBackgroundColorsChangedAction(_ignoreBackgroundColorsChangedAction);
	}

	protected SlideBase(ITextDocumentFactory? textDocumentFactory, ITransitionDescriptionCollection transitionDescriptions)
		: this(transitionDescriptions)
	{
		TextDocumentFactory = textDocumentFactory;
	}

	public virtual bool RenderEquals([NotNullWhen(true)] SlideBase? other)
	{
		if (other != null && _backgroundColor == other._backgroundColor && _useBackgroundColor == other.UseBackgroundColor)
		{
			return Size == other.Size;
		}
		return false;
	}

	public virtual int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(_backgroundColor, _useBackgroundColor, Size);
	}

	public SlideBase Clone()
	{
		return Clone(userInitiated: false);
	}

	public abstract SlideBase Clone(bool userInitiated);

	public virtual IEnumerable<string> GetAllText()
	{
		return Array.Empty<string>();
	}

	public abstract void ChangeSize(Vector2<double> size);

	protected void CopyProperties(SlideBase slide)
	{
		slide.Note = Note?.Clone();
		slide._backgroundColor = _backgroundColor;
		slide._useBackgroundColor = _useBackgroundColor;
		slide.SelectedTransition = _selectedTransition?.CloneTransitionParameters();
	}

	public void ChangeSlideBackgroundColor(System.Windows.Media.Color originalColor, System.Windows.Media.Color newColor)
	{
		BackgroundColor = newColor;
		UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ChangeSlideColor), delegate
		{
			BackgroundColor = originalColor;
		}, delegate
		{
			BackgroundColor = newColor;
		});
	}

	public void CompleteColorChange(System.Windows.Media.Color originalColor)
	{
		ChangeSlideBackgroundColor(originalColor, BackgroundColor);
	}

	protected internal void InvalidateVisual()
	{
		this.VisualInvalidated?.Invoke();
	}

	protected void OnDataModified()
	{
		this.DataModified?.Invoke(this);
	}

	private void NotesChanged(TextDocument document)
	{
		InvalidateVisual();
		OnDataModified();
	}

	protected virtual void OnUndoStackChanged(UndoStack? value)
	{
	}

	public void Deserialize(PresentationSlide? slide, ApplicationData? applicationData, string containerId)
	{
		TextDocumentFactory.ThrowWhenNull("TextDocumentFactory");
		if (slide != null)
		{
			if (slide.Notes != null)
			{
				Graphics.Types.Text protoText = new Graphics.Types.Text
				{
					RtfData = slide.Notes.RtfData,
					Attributes = slide.Notes.Attributes
				};
				SetupNotes(TextDocumentFactory?.Create(protoText, containerId));
			}
			DeserializeChordChart(new RelativePath(slide.ChordChart));
			DeserializeTemplateGuidelines(slide.TemplateGuidelines);
			DeserializeSlide(slide.BaseSlide, applicationData, containerId, null);
			SelectedTransition = slide.Transition?.ToTransition(TransitionDescriptions);
		}
	}

	private void SetupNotes(TextDocument? note)
	{
		Note = note;
		ParagraphSettings paragraphSettings = Note?.First().Settings;
		if (paragraphSettings != null)
		{
			paragraphSettings.Alignment = ParagraphAlignment.Left;
		}
	}

	public PresentationSlide Serialize()
	{
		Graphics.Types.Text text = Note?.ToProtoText();
		PresentationSlide presentationSlide = new PresentationSlide();
		presentationSlide.BaseSlide = SerializeSlide();
		presentationSlide.ChordChart = SerializeChordChart()?.Serialize();
		presentationSlide.Notes = new PresentationSlide.Types.Notes
		{
			RtfData = (text?.RtfData ?? Array.Empty<byte>().ToByteString()),
			Attributes = (text?.Attributes ?? new Graphics.Types.Text.Types.Attributes())
		};
		presentationSlide.Transition = SelectedTransition?.Serialize();
		presentationSlide.TemplateGuidelines.AddRange(SerializeTemplateGuidelines());
		return presentationSlide;
	}

	public Pro.SerializationInterop.RVProtoData.Slide SerializeSlide()
	{
		Pro.SerializationInterop.RVProtoData.Slide slide = new Pro.SerializationInterop.RVProtoData.Slide();
		slide.Uuid = ID.ToUUID();
		slide.BackgroundColor = BackgroundColor.ToProtoColor();
		slide.DrawsBackgroundColor = UseBackgroundColor;
		slide.Size = Size.ToProtoSize();
		slide.Elements.AddRange(SerializeElements());
		slide.ElementBuildOrder.AddRange(from i in SerializeBuildOrder()
			select i.ToUUID());
		slide.Guidelines.AddRange(SerializeGuidelines());
		return slide;
	}

	public void DeserializeSlide(Pro.SerializationInterop.RVProtoData.Slide slide, ApplicationData? applicationData, string containerId, Guid? newID = null)
	{
		if (!newID.HasValue)
		{
			if (slide?.Uuid != null)
			{
				ID = slide.Uuid.ToGuid();
			}
		}
		else
		{
			ID = newID.Value;
		}
		ContainerId = containerId;
		if (slide != null)
		{
			if (slide.BackgroundColor != null)
			{
				BackgroundColor = slide.BackgroundColor.ToColor();
			}
			UseBackgroundColor = slide.DrawsBackgroundColor;
			ChangeSize(slide.Size.ToVector());
			DeserializeElements(slide.Elements, applicationData, containerId);
			DeserializeBuildOrder(slide.ElementBuildOrder.Select((UUID i) => i.ToGuid()));
			DeserializeGuidelines(slide.Guidelines);
		}
	}

	protected virtual RelativePath SerializeChordChart()
	{
		return RelativePath.Empty();
	}

	protected virtual IEnumerable<Pro.SerializationInterop.RVProtoData.Slide.Types.Element> SerializeElements()
	{
		return Array.Empty<Pro.SerializationInterop.RVProtoData.Slide.Types.Element>();
	}

	protected virtual IEnumerable<Guid> SerializeBuildOrder()
	{
		return Array.Empty<Guid>();
	}

	protected virtual IEnumerable<AlignmentGuide> SerializeGuidelines()
	{
		return Array.Empty<AlignmentGuide>();
	}

	protected virtual IEnumerable<AlignmentGuide> SerializeTemplateGuidelines()
	{
		return Array.Empty<AlignmentGuide>();
	}

	protected virtual void DeserializeChordChart(RelativePath path)
	{
	}

	protected virtual void DeserializeElements(IEnumerable<Pro.SerializationInterop.RVProtoData.Slide.Types.Element> elements, ApplicationData? applicationData, string containerId)
	{
	}

	protected virtual void DeserializeBuildOrder(IEnumerable<Guid> buildOrder)
	{
	}

	protected virtual void DeserializeGuidelines(IEnumerable<AlignmentGuide> guidelines)
	{
	}

	protected virtual void DeserializeTemplateGuidelines(IEnumerable<AlignmentGuide> templateGuidelines)
	{
	}

	public virtual void UpdateContainerId(string containerId)
	{
		ContainerId = containerId;
	}
}
