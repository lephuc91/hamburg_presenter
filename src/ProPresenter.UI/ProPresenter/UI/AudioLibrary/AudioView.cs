using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Utility;
using Pro.UI.Components;
using Pro.UI.Controls;
using Pro.UI.Utility;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Settings;

namespace ProPresenter.UI.AudioLibrary;

public partial class AudioView : UserControl, IComponentConnector, IStyleConnector
{
	private const double DragCollapseThreshold = 100.0;

	public static readonly DependencyProperty GotFocusCommandProperty = DependencyProperty.Register("GotFocusCommand", typeof(ICommand), typeof(AudioView));

	public static readonly DependencyProperty TriggerAudioCommandProperty = DependencyProperty.Register("TriggerAudioCommand", typeof(ICommand<MediaCue>), typeof(AudioView));

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

	public ICommand<MediaCue?>? TriggerAudioCommand
	{
		get
		{
			return (ICommand<MediaCue>)((DependencyObject)this).GetValue(TriggerAudioCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TriggerAudioCommandProperty, (object)value);
		}
	}

	public AudioView()
	{
		InitializeComponent();
	}

	private void AudioRowSplitter_DragDelta(object? sender, DragDeltaEventArgs e)
	{
		if (e.VerticalChange <= -100.0)
		{
			Layout.Settings.AudioOutlineVisible = false;
		}
		else if (e.VerticalChange >= 100.0)
		{
			Layout.Settings.AudioOutlineVisible = true;
		}
	}

	private void AudioView_GotFocus(object? sender, RoutedEventArgs e)
	{
		GotFocusCommand?.Invoke();
	}

	private void AudioItemListBox_PreviewMouseLeftButtonUp(object? sender, MouseButtonEventArgs e)
	{
		if (!KeyboardHelper.IsModifierPressed((ModifierKeys)2, (ModifierKeys)4))
		{
			System.Windows.Controls.ListBoxItem listBoxItem = sender as System.Windows.Controls.ListBoxItem;
			EditableTextBlock? obj = ((DependencyObject)(object)listBoxItem)?.FindVisualChild<EditableTextBlock>();
			if (obj == null || !obj.IsInEditMode)
			{
				TriggerAudioCommand?.Invoke<MediaCue>(listBoxItem?.DataContext as MediaCue);
			}
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
