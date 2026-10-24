using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.DO.Audio;
using Pro.ssAPI.Devices;

namespace ProPresenter.UI.Settings.PageTemplates.Inputs;

public partial class ChannelFader : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ChannelProperty = DependencyProperty.Register("Channel", typeof(DeviceChannel), typeof(ChannelFader), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(ChannelPropertyChanged)));

	public static readonly DependencyProperty ChannelNameProperty = DependencyProperty.Register("ChannelName", typeof(string), typeof(ChannelFader));

	public static readonly DependencyProperty ChannelMapProperty = DependencyProperty.Register("ChannelMap", typeof(AudioMap<DeviceChannel, Bus>), typeof(ChannelFader));

	public static readonly DependencyProperty AllChannelLevelsProperty = DependencyProperty.Register("AllChannelLevels", typeof(IEnumerable<IAudioChannelLevel>), typeof(ChannelFader), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((ChannelFader)(object)callerObject).UpdateChannelLevelBindings();
	}));

	public static readonly DependencyProperty ThisChannelLevelProperty = DependencyProperty.Register("ThisChannelLevel", typeof(IAudioChannelLevel), typeof(ChannelFader));

	public DeviceChannel? Channel
	{
		get
		{
			return (DeviceChannel)((DependencyObject)this).GetValue(ChannelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ChannelProperty, (object)value);
		}
	}

	public string ChannelName
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(ChannelNameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ChannelNameProperty, (object)value);
		}
	}

	public AudioMap<DeviceChannel, Bus>? ChannelMap
	{
		get
		{
			return (AudioMap<DeviceChannel, Bus>)((DependencyObject)this).GetValue(ChannelMapProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ChannelMapProperty, (object)value);
		}
	}

	public IEnumerable<IAudioChannelLevel>? AllChannelLevels
	{
		get
		{
			return (IEnumerable<IAudioChannelLevel>)((DependencyObject)this).GetValue(AllChannelLevelsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AllChannelLevelsProperty, (object)value);
		}
	}

	public IAudioChannelLevel? ThisChannelLevel
	{
		get
		{
			return (IAudioChannelLevel)((DependencyObject)this).GetValue(ThisChannelLevelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ThisChannelLevelProperty, (object)value);
		}
	}

	private static void ChannelPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((ChannelFader)(object)callerObject).OnChannelChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as DeviceChannel, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as DeviceChannel);
	}

	public ChannelFader()
	{
		InitializeComponent();
		UpdateChannelLevelBindings();
	}

	private void UpdateChannelLevelBindings()
	{
		if (Channel != null)
		{
			IAudioChannelLevel audioChannelLevel = AllChannelLevels?.ElementAtOrDefault(Channel.Index);
			((DependencyObject)this).SetCurrentValue(ThisChannelLevelProperty, (object)audioChannelLevel);
		}
	}

	private void OnChannelChanged(DeviceChannel? oldChannel, DeviceChannel? newChannel)
	{
		if (oldChannel != null)
		{
			oldChannel.PropertyChanged -= OnChannelPropertyChanged;
		}
		if (newChannel != null)
		{
			newChannel.PropertyChanged += OnChannelPropertyChanged;
		}
		UpdateChannelLevelBindings();
	}

	private void OnChannelPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Index")
		{
			UpdateChannelLevelBindings();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
