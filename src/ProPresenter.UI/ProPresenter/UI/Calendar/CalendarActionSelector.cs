using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.UI.Calendar;

public partial class CalendarActionSelector : UserControl, IComponentConnector, IStyleConnector
{
	private Playlist<ProPresenterCue>? _playlistParent;

	private static readonly DependencyProperty SelectTargetPlaylistCommandProperty = DependencyProperty.Register("SelectTargetPlaylistCommand", typeof(ICommand<Playlist<ProPresenterCue>>), typeof(CalendarActionSelector));

	private static readonly DependencyProperty SelectTargetCueCommandProperty = DependencyProperty.Register("SelectTargetCueCommand", typeof(ICommand<(Playlist<ProPresenterCue>, ProPresenterCue)>), typeof(CalendarActionSelector));

	private ICommand<Playlist<ProPresenterCue>>? SelectTargetPlaylistCommand
	{
		get
		{
			return (ICommand<Playlist<ProPresenterCue>>)((DependencyObject)this).GetValue(SelectTargetPlaylistCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectTargetPlaylistCommandProperty, (object)value);
		}
	}

	private ICommand<(Playlist<ProPresenterCue>? Playlist, ProPresenterCue Cue)>? SelectTargetCueCommand
	{
		get
		{
			return (ICommand<(Playlist<ProPresenterCue>, ProPresenterCue)>)((DependencyObject)this).GetValue(SelectTargetCueCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectTargetCueCommandProperty, (object)value);
		}
	}

	public CalendarActionSelector()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		InitializeComponent();
		base.DataContextChanged += new DependencyPropertyChangedEventHandler(CalendarView_DataContextChanged);
	}

	private void CalendarView_DataContextChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue != null)
		{
			SetBinding(SelectTargetPlaylistCommandProperty, new Binding("SelectTargetPlaylistCommand")
			{
				Source = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue
			});
			SetBinding(SelectTargetCueCommandProperty, new Binding("SelectTargetCueCommand")
			{
				Source = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue
			});
		}
	}

	private void Playlist_PreviewClick(object? sender, MouseButtonEventArgs e)
	{
		if (sender is MenuItem { DataContext: Playlist<ProPresenterCue> dataContext })
		{
			_playlistParent = dataContext;
		}
		if (e.OriginalSource is FrameworkElement depObj)
		{
			MenuItem menuItem2 = ((DependencyObject)(object)depObj).FindVisualParent<MenuItem>();
			if (menuItem2 != null && menuItem2.DataContext == _playlistParent)
			{
				SelectTargetPlaylistCommand?.Invoke<Playlist<ProPresenterCue>>(_playlistParent);
			}
		}
	}

	private void PlaylistItem_PreviewClick(object? sender, MouseButtonEventArgs e)
	{
		if (sender is MenuItem { DataContext: ProPresenterCue dataContext })
		{
			SelectTargetCueCommand?.Invoke((_playlistParent, dataContext));
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
