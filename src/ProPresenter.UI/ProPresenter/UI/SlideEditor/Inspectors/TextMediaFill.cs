using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Common.Components;
using Pro.Common.Nullability;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Utility;
using Pro.DO.Transitions;
using Pro.Text;
using Pro.Text.Fills;
using Pro.Text.Reversibility;
using Pro.UI.DependencyInjection;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Settings;

namespace ProPresenter.UI.SlideEditor.Inspectors;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_mediaChangeDebouncer" })]
public partial class TextMediaFill : UserControl, IComponentConnector, IDisposable
{
	private bool _ignoreChanges;

	private readonly IDebouncer<VisualMedia?> _mediaChangeDebouncer;

	private readonly IApp _app;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	public static readonly DependencyProperty FillProperty = DependencyProperty.Register("Fill", typeof(TextFillBase), typeof(TextMediaFill), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnFillPropertyChanged)));

	public static readonly DependencyProperty MediaProperty = DependencyProperty.Register("Media", typeof(MediaCue), typeof(TextMediaFill), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnMediaPropertyChanged)));

	public static readonly DependencyProperty MediaProviderProperty = DependencyProperty.Register("MediaProvider", typeof(IMediaProvider), typeof(TextMediaFill));

	public static readonly DependencyProperty MediaContainerIdSourceProperty = DependencyProperty.Register("MediaContainerIdSource", typeof(IHasMediaContainerId), typeof(TextMediaFill));

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public ApplyRunSettingsDelegate? ApplyRunSettingsProvider { get; set; }

	public ApplyParagraphSettingsDelegate? ApplyParagraphSettingsProvider { get; set; }

	public Func<IReadOnlyList<TextDocument>?>? GetDocumentsAction { get; set; }

	public TextFillBase? Fill
	{
		get
		{
			return (TextFillBase)((DependencyObject)this).GetValue(FillProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FillProperty, (object)value);
		}
	}

	public MediaCue? Media
	{
		get
		{
			return (MediaCue)((DependencyObject)this).GetValue(MediaProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MediaProperty, (object)value);
		}
	}

	public IMediaProvider? MediaProvider
	{
		get
		{
			return (IMediaProvider)((DependencyObject)this).GetValue(MediaProviderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MediaProviderProperty, (object)value);
		}
	}

	public IHasMediaContainerId? MediaContainerIdSource
	{
		get
		{
			return (IHasMediaContainerId)((DependencyObject)this).GetValue(MediaContainerIdSourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MediaContainerIdSourceProperty, (object)value);
		}
	}

	private bool IgnoreChanges()
	{
		if (!_ignoreChanges)
		{
			return Fill == null;
		}
		return true;
	}

	private static void OnFillPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		((TextMediaFill)(object)caller).OnFillChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as TextFillBase, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as TextFillBase);
	}

	private static void OnMediaPropertyChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		((TextMediaFill)(object)caller).OnMediaChanged(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as MediaCue);
	}

	public TextMediaFill()
	{
		_app = UIServiceProvider.GetService<IApp>();
		_transitionDescriptions = UIServiceProvider.GetService<ITransitionDescriptionCollection>();
		IDebouncerFactory service = UIServiceProvider.GetService<IDebouncerFactory>();
		InitializeComponent();
		_mediaChangeDebouncer = service.CreateDispatched(delegate(VisualMedia? media)
		{
			if (media != null)
			{
				ChangeFill(new MediaTextFill(media), UndoActionTypes.TextMediaFillMedia);
			}
		}, 200.0);
	}

	private void OnFillChanged(TextFillBase? oldFill, TextFillBase? newFill)
	{
		if (!IgnoreChanges())
		{
			_ignoreChanges = true;
			MediaTextFill mediaTextFill = oldFill as MediaTextFill;
			MediaTextFill mediaTextFill2 = newFill as MediaTextFill;
			mediaTextFill?.Media?.StopObservingSourceFile();
			mediaTextFill2?.Media?.StartObservingSourceFile();
			mediaTextFill2?.Media?.UpdateValidity();
			Media = (mediaTextFill2?.Media as VisualMedia)?.ToCue(_app, _transitionDescriptions, supportsPlaybackMarkers: false);
			if (mediaTextFill?.Media != null)
			{
				mediaTextFill.Media.TextFillDataModified -= Media_DataModified;
			}
			if (mediaTextFill2?.Media != null)
			{
				mediaTextFill2.Media.TextFillDataModified += Media_DataModified;
			}
			_ignoreChanges = false;
		}
	}

	private void Media_DataModified(ITextFillMedia media)
	{
		_mediaChangeDebouncer.Invoke(media as VisualMedia);
	}

	private void OnMediaChanged(MediaCue? newValue)
	{
		if (newValue?.MediaAction?.VisualMedia != null && Fill is MediaTextFill && !IgnoreChanges())
		{
			ChangeFill(new MediaTextFill(newValue.MediaAction.VisualMedia), UndoActionTypes.TextMediaFillMedia);
		}
	}

	private void ChangeFill(MediaTextFill newFill, UndoActionTypes undoActionType)
	{
		TextFillUtility.ChangeFill(GetDocumentsAction, newFill, undoActionType, ApplyRunSettingsProvider, ApplyParagraphSettingsProvider, delegate(MediaTextFill f)
		{
			((DependencyObject)this).SetCurrentValue(FillProperty, (object)f);
		});
	}

	private void ReplaceMedia_Click(object? sender, RoutedEventArgs e)
	{
		if ((Fill as MediaTextFill)?.Media is MediaBase currentMedia)
		{
			MediaProvider?.GetMedia(currentMedia, MediaCallback);
			return;
		}
		MediaContainerIdSource.ThrowWhenNull("MediaContainerIdSource");
		MediaProvider?.GetMedia(MediaContainerIdSource.ContainerId, MediaCallback);
		void MediaCallback(MediaBase? m)
		{
			if (m is VisualMedia media)
			{
				ChangeFill(new MediaTextFill(media), UndoActionTypes.TextMediaFillMedia);
			}
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_mediaChangeDebouncer.Dispose();
		}
	}
}
