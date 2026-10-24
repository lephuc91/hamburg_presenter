using System;
using System.CodeDom.Compiler;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.DO.Triggering;
using Pro.UI.Components;
using Pro.UI.DependencyInjection;
using Pro.UI.Utility;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.Thumbnails;

namespace ProPresenter.UI.SlideEditor;

public partial class EditorPreviewItem : UserControl, IComponentConnector
{
	private readonly IMediaCueThumbnailOverlayVMFactory _overlayVMFactory;

	public static readonly DependencyProperty SourceProperty;

	public static readonly DependencyProperty SlideCueProperty;

	public static readonly DependencyProperty ActionsProperty;

	public static readonly DependencyProperty IncludeBackgroundProperty;

	public static readonly DependencyProperty IsSourceEnabledProperty;

	public static readonly DependencyProperty SecondaryBackgroundColorProperty;

	public static readonly DependencyProperty IndexProperty;

	public static readonly DependencyProperty LabelTextProperty;

	public static readonly DependencyProperty LabelColorProperty;

	public static readonly DependencyProperty GroupLabelColorProperty;

	public static readonly DependencyProperty IsActiveProperty;

	public static readonly DependencyProperty IsSelectedProperty;

	public static readonly DependencyProperty UpdateSeletedSlidesCommandProperty;

	public static readonly DependencyProperty PreviewItemContextMenuProperty;

	public static readonly DependencyProperty IncludeTextPlaceholderProperty;

	public static readonly DependencyProperty CanRenameProperty;

	public static readonly DependencyProperty OverlayVMProperty;

	public CustomSlide? Source
	{
		get
		{
			return (CustomSlide)((DependencyObject)this).GetValue(SourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SourceProperty, (object)value);
		}
	}

	public SlideCue? SlideCue
	{
		get
		{
			return (SlideCue)((DependencyObject)this).GetValue(SlideCueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SlideCueProperty, (object)value);
		}
	}

	public INotifyEnumerableChanged<ActionBase>? Actions
	{
		get
		{
			return (INotifyEnumerableChanged<ActionBase>)((DependencyObject)this).GetValue(ActionsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActionsProperty, (object)value);
		}
	}

	private bool IncludeBackground
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IncludeBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IncludeBackgroundProperty, (object)value);
		}
	}

	public bool IsSourceEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsSourceEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsSourceEnabledProperty, (object)value);
		}
	}

	public Color SecondaryBackgroundColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(SecondaryBackgroundColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SecondaryBackgroundColorProperty, (object)value);
		}
	}

	public int Index
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(IndexProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IndexProperty, (object)value);
		}
	}

	public string? LabelText
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(LabelTextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LabelTextProperty, (object)value);
		}
	}

	public Color LabelColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(LabelColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LabelColorProperty, (object)value);
		}
	}

	public Color GroupLabelColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(GroupLabelColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(GroupLabelColorProperty, (object)value);
		}
	}

	public bool IsActive
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsActiveProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsActiveProperty, (object)value);
		}
	}

	public bool IsSelected
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsSelectedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsSelectedProperty, (object)value);
		}
	}

	public ICommand<CustomSlide>? UpdateSelectedSlidesCommand
	{
		get
		{
			return (ICommand<CustomSlide>)((DependencyObject)this).GetValue(UpdateSeletedSlidesCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(UpdateSeletedSlidesCommandProperty, (object)value);
		}
	}

	public ContextMenu? PreviewItemContextMenu
	{
		get
		{
			return (ContextMenu)((DependencyObject)this).GetValue(PreviewItemContextMenuProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PreviewItemContextMenuProperty, (object)value);
		}
	}

	public bool IncludeTextPlaceholder
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IncludeTextPlaceholderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IncludeTextPlaceholderProperty, (object)value);
		}
	}

	public bool CanRename
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanRenameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanRenameProperty, (object)value);
		}
	}

	private IMediaOverlayVM? OverlayVM
	{
		get
		{
			return (IMediaOverlayVM)((DependencyObject)this).GetValue(OverlayVMProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OverlayVMProperty, (object)value);
		}
	}

	private static void SlideCuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is EditorPreviewItem editorPreviewItem)
		{
			editorPreviewItem.OnSlideCueChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as SlideCue, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as SlideCue);
		}
	}

	private static void ActionsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is EditorPreviewItem editorPreviewItem && ((DependencyPropertyChangedEventArgs)(ref e)).NewValue is INotifyEnumerableChanged<IAction> actions)
		{
			editorPreviewItem.OverlayVM = editorPreviewItem._overlayVMFactory?.Create(actions, OverlayType.MissingIconWithScrim);
		}
	}

	static EditorPreviewItem()
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		SourceProperty = DependencyProperty.Register("Source", typeof(CustomSlide), typeof(EditorPreviewItem));
		SlideCueProperty = DependencyProperty.Register("SlideCue", typeof(SlideCue), typeof(EditorPreviewItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(SlideCuePropertyChanged)));
		ActionsProperty = DependencyProperty.Register("Actions", typeof(INotifyEnumerableChanged<ActionBase>), typeof(EditorPreviewItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(ActionsPropertyChanged)));
		IncludeBackgroundProperty = DependencyProperty.Register("IncludeBackground", typeof(bool), typeof(EditorPreviewItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		IsSourceEnabledProperty = DependencyProperty.Register("IsSourceEnabled", typeof(bool), typeof(EditorPreviewItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		SecondaryBackgroundColorProperty = DependencyProperty.Register("SecondaryBackgroundColor", typeof(Color), typeof(EditorPreviewItem));
		IndexProperty = DependencyProperty.Register("Index", typeof(int), typeof(EditorPreviewItem));
		LabelTextProperty = DependencyProperty.Register("LabelText", typeof(string), typeof(EditorPreviewItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
		LabelColorProperty = DependencyProperty.Register("LabelColor", typeof(Color), typeof(EditorPreviewItem));
		GroupLabelColorProperty = DependencyProperty.Register("GroupLabelColor", typeof(Color), typeof(EditorPreviewItem));
		IsActiveProperty = DependencyProperty.Register("IsActive", typeof(bool), typeof(EditorPreviewItem));
		IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(EditorPreviewItem));
		UpdateSeletedSlidesCommandProperty = DependencyProperty.Register("UpdateSelectedSlidesCommand", typeof(ICommand<CustomSlide>), typeof(EditorPreviewItem));
		PreviewItemContextMenuProperty = DependencyProperty.Register("PreviewItemContextMenu", typeof(ContextMenu), typeof(EditorPreviewItem));
		IncludeTextPlaceholderProperty = DependencyProperty.Register("IncludeTextPlaceholder", typeof(bool), typeof(EditorPreviewItem));
		CanRenameProperty = DependencyProperty.Register("CanRename", typeof(bool), typeof(EditorPreviewItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		OverlayVMProperty = DependencyProperty.Register("OverlayVM", typeof(IMediaOverlayVM), typeof(EditorPreviewItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null));
		Control.BackgroundProperty.OverrideMetadata(typeof(EditorPreviewItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.Transparent));
	}

	public EditorPreviewItem()
	{
		InitializeComponent();
		_overlayVMFactory = UIServiceProvider.GetService<IMediaCueThumbnailOverlayVMFactory>();
	}

	protected override void OnContextMenuOpening(ContextMenuEventArgs e)
	{
		if (Source != null)
		{
			UpdateSelectedSlidesCommand?.Invoke<CustomSlide>(Source);
		}
		base.OnContextMenuOpening(e);
	}

	private void OnSlideCueChanged(SlideCue? oldSlideCue, SlideCue? newSlideCue)
	{
		if (oldSlideCue != null)
		{
			oldSlideCue.Actions.CollectionChanged -= Actions_CollectionChanged;
			oldSlideCue.Actions.OfType<MediaAction>().ForEach(delegate(MediaAction a)
			{
				a.PropertyChanged -= MediAction_PropertyChanged;
			});
		}
		if (newSlideCue != null)
		{
			newSlideCue.Actions.CollectionChanged += Actions_CollectionChanged;
			newSlideCue.Actions.OfType<MediaAction>().ForEach(delegate(MediaAction a)
			{
				a.PropertyChanged += MediAction_PropertyChanged;
			});
		}
		UpdateIncludeBackground();
		OverlayVM = _overlayVMFactory?.Create(newSlideCue, OverlayType.MissingIconWithScrim);
	}

	private void MediAction_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "TriggerLayer")
		{
			UpdateIncludeBackground();
		}
	}

	private void Actions_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<MediaAction>().ForEach(delegate(MediaAction a)
		{
			a.PropertyChanged -= MediAction_PropertyChanged;
		});
		e.NewItems?.OfType<MediaAction>().ForEach(delegate(MediaAction a)
		{
			a.PropertyChanged += MediAction_PropertyChanged;
		});
		UpdateIncludeBackground();
	}

	private void UpdateIncludeBackground()
	{
		((DependencyObject)this).SetCurrentValue(IncludeBackgroundProperty, (object)(SlideCue?.GetIncludeBackground() ?? true));
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
