using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Media;

namespace ProPresenter.UI.MediaLibrary;

public partial class MediaPreview : UserControl, IComponentConnector
{
	public static readonly DependencyProperty MediaProperty = DependencyProperty.Register("Media", typeof(MediaBase), typeof(MediaPreview), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnMediaChanged)));

	private static readonly DependencyProperty VideoInputProperty = DependencyProperty.Register("VideoInput", typeof(LiveVideoInput), typeof(MediaPreview));

	public static readonly DependencyProperty ShowIconForNonVisualMediaProperty = DependencyProperty.Register("ShowIconForNonVisualMedia", typeof(bool), typeof(MediaPreview), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public MediaBase? Media
	{
		get
		{
			return (MediaBase)((DependencyObject)this).GetValue(MediaProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MediaProperty, (object)value);
		}
	}

	private LiveVideoInput? VideoInput
	{
		get
		{
			return (LiveVideoInput)((DependencyObject)this).GetValue(VideoInputProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(VideoInputProperty, (object)value);
		}
	}

	public bool ShowIconForNonVisualMedia
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowIconForNonVisualMediaProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowIconForNonVisualMediaProperty, (object)value);
		}
	}

	private static void OnMediaChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((MediaPreview)(object)d).MediaChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as MediaBase, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as MediaBase);
	}

	public MediaPreview()
	{
		InitializeComponent();
	}

	private void MediaChanged(MediaBase? oldMedia, MediaBase? newMedia)
	{
		if (oldMedia is ILiveVideoMedia liveVideoMedia)
		{
			liveVideoMedia.LiveVideo.PropertyChanged -= LiveVideo_PropertyChanged;
		}
		if (newMedia is ILiveVideoMedia liveVideoMedia2)
		{
			liveVideoMedia2.LiveVideo.PropertyChanged += LiveVideo_PropertyChanged;
		}
		SetVideoInput(newMedia);
		SetAligntment();
	}

	private void LiveVideo_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string? propertyName = e.PropertyName;
		if (propertyName != null && propertyName.Equals("Input"))
		{
			SetVideoInput(Media);
		}
	}

	private void SetVideoInput(MediaBase? media)
	{
		if (media is ILiveVideoMedia liveVideoMedia)
		{
			((DependencyObject)this).SetCurrentValue(VideoInputProperty, (object)liveVideoMedia.LiveVideo.Input);
		}
	}

	private void SetAligntment()
	{
		if (Media is IDrawMedia drawMedia)
		{
			base.HorizontalAlignment = ((drawMedia.Drawing.PreviewImage != null) ? HorizontalAlignment.Center : HorizontalAlignment.Stretch);
			base.VerticalAlignment = ((drawMedia.Drawing.PreviewImage != null) ? VerticalAlignment.Center : VerticalAlignment.Stretch);
		}
		else
		{
			base.HorizontalAlignment = HorizontalAlignment.Stretch;
			base.VerticalAlignment = VerticalAlignment.Stretch;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
