using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.DO.Audio;

namespace Pro.UI.Controls.Audio;

public partial class AudioChannelTemplate : UserControl, IComponentConnector
{
	public static readonly DependencyProperty AudioChannelProperty = DependencyProperty.Register("AudioChannel", typeof(IChannel), typeof(AudioChannelTemplate), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnAudioChannelChanged)));

	public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register("Orientation", typeof(TemplateOrientation), typeof(AudioChannelTemplate));

	public static readonly DependencyProperty ShowAudioChannelControlsProperty = DependencyProperty.Register("ShowAudioChannelControls", typeof(bool), typeof(AudioChannelTemplate), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true, new PropertyChangedCallback(OnAudioChannelChanged)));

	public static readonly DependencyProperty ShowMuteControlsProperty = DependencyProperty.Register("ShowMuteControls", typeof(bool), typeof(AudioChannelTemplate));

	public static readonly DependencyProperty ShowSoloControlsProperty = DependencyProperty.Register("ShowSoloControls", typeof(bool), typeof(AudioChannelTemplate));

	public static readonly DependencyProperty ShowTestControlsProperty = DependencyProperty.Register("ShowTestControls", typeof(bool), typeof(AudioChannelTemplate));

	public static readonly DependencyProperty ShowChannelIndexProperty = DependencyProperty.Register("ShowChannelIndex", typeof(bool), typeof(AudioChannelTemplate));

	public static readonly DependencyProperty IsNameVerticalProperty = DependencyProperty.Register("IsNameVertical", typeof(bool), typeof(AudioChannelTemplate));

	public static readonly DependencyProperty CanRenameProperty = DependencyProperty.Register("CanRename", typeof(bool), typeof(AudioChannelTemplate), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true, new PropertyChangedCallback(OnAudioChannelChanged)));

	public IChannel? AudioChannel
	{
		get
		{
			return (IChannel)((DependencyObject)this).GetValue(AudioChannelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AudioChannelProperty, (object)value);
		}
	}

	public TemplateOrientation Orientation
	{
		get
		{
			return (TemplateOrientation)((DependencyObject)this).GetValue(OrientationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OrientationProperty, (object)value);
		}
	}

	public bool ShowAudioChannelControls
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowAudioChannelControlsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowAudioChannelControlsProperty, (object)value);
		}
	}

	public bool ShowMuteControls
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowMuteControlsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowMuteControlsProperty, (object)value);
		}
	}

	public bool ShowSoloControls
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowSoloControlsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowSoloControlsProperty, (object)value);
		}
	}

	public bool ShowTestControls
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowTestControlsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowTestControlsProperty, (object)value);
		}
	}

	public bool ShowChannelIndex
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowChannelIndexProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowChannelIndexProperty, (object)value);
		}
	}

	public bool IsNameVertical
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsNameVerticalProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsNameVerticalProperty, (object)value);
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

	private static void OnAudioChannelChanged(DependencyObject caller, DependencyPropertyChangedEventArgs e)
	{
		((AudioChannelTemplate)(object)caller).UpdateNameControlVisibility();
	}

	public AudioChannelTemplate()
	{
		InitializeComponent();
	}

	private void UpdateNameControlVisibility()
	{
		bool isHitTestVisible = CanRename && (AudioChannel?.CanRename ?? false);
		EditableNameText.IsHitTestVisible = isHitTestVisible;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
