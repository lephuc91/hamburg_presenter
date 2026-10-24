using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using CommunityToolkit.Mvvm.Input;
using Pro.UI.Controls;
using Pro.UI.Utility;
using ProPresenter.DO.LiveVideo;

namespace ProPresenter.UI.Settings.PageTemplates.Inputs.Video;

public partial class VideoInputPreviewSettings : UserControl, IComponentConnector
{
	public static readonly DependencyProperty VideoInputProperty = DependencyProperty.Register("VideoInput", typeof(LiveVideoInput), typeof(VideoInputPreviewSettings));

	public static readonly DependencyProperty IsPreviewActiveProperty = DependencyProperty.Register("IsPreviewActive", typeof(bool), typeof(VideoInputPreviewSettings), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty CaptureThumbnailCommandProperty = DependencyProperty.Register("CaptureThumbnailCommand", typeof(ICommand), typeof(VideoInputPreviewSettings));

	public static readonly DependencyProperty SelectThumbnailCommandProperty = DependencyProperty.Register("SelectThumbnailCommand", typeof(ICommand), typeof(VideoInputPreviewSettings));

	public static readonly DependencyProperty ClearThumbnailCommandProperty = DependencyProperty.Register("ClearThumbnailCommand", typeof(ICommand), typeof(VideoInputPreviewSettings));

	public static readonly DependencyProperty ToggleVideoInputAudioMonitoringCommandProperty = DependencyProperty.Register("ToggleVideoInputAudioMonitoringCommand", typeof(ICommand), typeof(VideoInputPreviewSettings));

	public static readonly DependencyProperty RequestRenderCommandProperty = DependencyProperty.Register("RequestRenderCommand", typeof(IRelayCommand<RequestRenderParameter>), typeof(VideoInputPreviewSettings));

	public static readonly DependencyProperty GotFocusCommandProperty = DependencyProperty.Register("GotFocusCommand", typeof(ICommand), typeof(VideoInputPreviewSettings));

	public LiveVideoInput? VideoInput
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

	public bool IsPreviewActive
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsPreviewActiveProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsPreviewActiveProperty, (object)value);
		}
	}

	public ICommand? CaptureThumbnailCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(CaptureThumbnailCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CaptureThumbnailCommandProperty, (object)value);
		}
	}

	public ICommand? SelectThumbnailCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(SelectThumbnailCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectThumbnailCommandProperty, (object)value);
		}
	}

	public ICommand? ClearThumbnailCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(ClearThumbnailCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClearThumbnailCommandProperty, (object)value);
		}
	}

	public ICommand? ToggleVideoInputAudioMonitoringCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(ToggleVideoInputAudioMonitoringCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ToggleVideoInputAudioMonitoringCommandProperty, (object)value);
		}
	}

	public double PreviewAspectRatio => 1.7777777777777777;

	public IRelayCommand<RequestRenderParameter>? RequestRenderCommand
	{
		get
		{
			return (IRelayCommand<RequestRenderParameter>)((DependencyObject)this).GetValue(RequestRenderCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RequestRenderCommandProperty, (object)value);
		}
	}

	public ICommand? GotFocusCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(GotFocusCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(GotFocusCommandProperty, (object)value);
		}
	}

	public VideoInputPreviewSettings()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		InitializeComponent();
		base.GotFocus += VideoSettings_GotFocus;
		base.IsVisibleChanged += new DependencyPropertyChangedEventHandler(VideoSettings_IsVisibleChanged);
	}

	private void VideoSettings_IsVisibleChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		OnGotFocus();
	}

	private void VideoSettings_GotFocus(object? sender, RoutedEventArgs e)
	{
		OnGotFocus();
	}

	private void OnGotFocus()
	{
		if (base.IsVisible)
		{
			GotFocusCommand?.Invoke();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
