using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.UI.Thumbnails;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI.PresentationView;

public partial class PresentationViewer : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register("Items", typeof(IEnumerable<ProPresenterCue>), typeof(PresentationViewer), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, FrameworkPropertyMetadataOptions.AffectsMeasure));

	public static readonly DependencyProperty GotFocusCommandProperty = DependencyProperty.Register("GotFocusCommand", typeof(ICommand), typeof(PresentationViewer));

	public static readonly DependencyProperty SelectPlaylistItemCommandProperty = DependencyProperty.Register("SelectPlaylistItemCommand", typeof(ICommand<ProPresenterCue>), typeof(PresentationViewer));

	public static readonly DependencyProperty PCOLiveVMProperty = DependencyProperty.Register("PCOLiveVM", typeof(IPCOLiveVM), typeof(PresentationViewer));

	public static readonly DependencyProperty TriggerMediaItemCommandProperty = DependencyProperty.Register("TriggerMediaItemCommand", typeof(ICommand), typeof(PresentationViewer));

	public IEnumerable<ProPresenterCue> Items
	{
		get
		{
			return (IEnumerable<ProPresenterCue>)((DependencyObject)this).GetValue(ItemsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemsProperty, (object)value);
		}
	}

	public ICommand GotFocusCommand
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

	public ICommand<ProPresenterCue> SelectPlaylistItemCommand
	{
		get
		{
			return (ICommand<ProPresenterCue>)((DependencyObject)this).GetValue(SelectPlaylistItemCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectPlaylistItemCommandProperty, (object)value);
		}
	}

	public IPCOLiveVM PCOLiveVM
	{
		get
		{
			return (IPCOLiveVM)((DependencyObject)this).GetValue(PCOLiveVMProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PCOLiveVMProperty, (object)value);
		}
	}

	public ICommand<MediaCue> TriggerMediaItemCommand
	{
		get
		{
			return (ICommand<MediaCue>)((DependencyObject)this).GetValue(TriggerMediaItemCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TriggerMediaItemCommandProperty, (object)value);
		}
	}

	public PresentationViewer()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		InitializeComponent();
		base.GotKeyboardFocus += delegate
		{
			GotFocusCommand?.Invoke();
		};
		base.DataContextChanged += new DependencyPropertyChangedEventHandler(PresentationViewer_DataContextChanged);
	}

	private void PresentationViewer_DataContextChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).OldValue is IPresentationVM presentationVM)
		{
			presentationVM.FindThumbnailProvider = null;
		}
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue is IPresentationVM presentationVM2)
		{
			presentationVM2.FindThumbnailProvider = FindThumbnail;
			presentationVM2.TogglePresentationView = viewStatusBar.DoTogglePresentationView;
		}
	}

	private void PresentationView_MouseDown(object? sender, MouseButtonEventArgs e)
	{
		if ((sender as FrameworkElement)?.DataContext is ProPresenterCue parameter)
		{
			SelectPlaylistItemCommand?.Invoke(parameter);
		}
	}

	private Thumbnail? FindThumbnail(ArrangedCue? arrangedCue)
	{
		if (arrangedCue != null)
		{
			foreach (CustomPresentationThumbnailPanel item in ((DependencyObject)(object)this).FindVisualChildren<CustomPresentationThumbnailPanel>())
			{
				Thumbnail thumbnail = item.GetThumbnail(arrangedCue);
				if (thumbnail != null)
				{
					return thumbnail;
				}
			}
		}
		return null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
