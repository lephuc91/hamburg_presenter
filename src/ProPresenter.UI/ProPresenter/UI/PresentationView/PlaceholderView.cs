using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Mathematics;
using Pro.UI.Components;
using Pro.UI.Controls;
using Pro.UI.Utility;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI.PresentationView;

public partial class PlaceholderView : UserControl, IVirtualizableControl, IComponentConnector
{
	public static readonly DependencyProperty PresentationVMProperty = DependencyProperty.Register("PresentationVM", typeof(IPresentationVM), typeof(PlaceholderView));

	public static readonly DependencyProperty CueProperty = DependencyProperty.Register("Cue", typeof(ProPresenterCue), typeof(PlaceholderView));

	public static readonly DependencyProperty LinkStateProperty = DependencyProperty.Register("LinkState", typeof(LinkState), typeof(PlaceholderView), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)LinkState.Unlinked, (PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((PlaceholderView)(object)s).UpdateContent();
	}));

	public static readonly DependencyProperty ThumbnailContextMenuProperty = DependencyProperty.Register("ThumbnailContextMenu", typeof(ContextMenu), typeof(PlaceholderView));

	public static readonly DependencyProperty ItemActivatedCommandProperty = DependencyProperty.Register("ItemActivatedCommand", typeof(ICommand<ProPresenterCue>), typeof(PlaceholderView));

	public static readonly DependencyProperty TriggerMediaItemCommandProperty = DependencyProperty.Register("TriggerMediaItemCommand", typeof(ICommand<MediaCue>), typeof(PlaceholderView));

	public IPresentationVM PresentationVM
	{
		get
		{
			return (IPresentationVM)((DependencyObject)this).GetValue(PresentationVMProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PresentationVMProperty, (object)value);
		}
	}

	public ProPresenterCue Cue
	{
		get
		{
			return (ProPresenterCue)((DependencyObject)this).GetValue(CueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CueProperty, (object)value);
		}
	}

	public LinkState LinkState
	{
		get
		{
			return (LinkState)((DependencyObject)this).GetValue(LinkStateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LinkStateProperty, (object)value);
		}
	}

	public ContextMenu ThumbnailContextMenu
	{
		get
		{
			return (ContextMenu)((DependencyObject)this).GetValue(ThumbnailContextMenuProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ThumbnailContextMenuProperty, (object)value);
		}
	}

	public ICommand<ProPresenterCue>? ItemActivatedCommand
	{
		get
		{
			return (ICommand<ProPresenterCue>)((DependencyObject)this).GetValue(ItemActivatedCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemActivatedCommandProperty, (object)value);
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

	public bool InView
	{
		get
		{
			return VirtualizableControl?.InView ?? false;
		}
		set
		{
			if (VirtualizableControl != null)
			{
				VirtualizableControl.InView = value;
			}
		}
	}

	public Rect<double> Viewport
	{
		get
		{
			return VirtualizableControl?.Viewport ?? Rect<double>.Empty;
		}
		set
		{
			if (VirtualizableControl != null)
			{
				VirtualizableControl.Viewport = value;
			}
		}
	}

	private IVirtualizableControl? VirtualizableControl
	{
		get
		{
			if (!(base.Content is IVirtualizableControl result))
			{
				return null;
			}
			return result;
		}
	}

	public PlaceholderView()
	{
		InitializeComponent();
	}

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		ItemActivatedCommand?.Invoke(Cue);
	}

	private void UpdateContent()
	{
		base.Content = LinkState switch
		{
			LinkState.Unlinked => null, 
			LinkState.DocumentLinked => base.Resources["PresentationView"], 
			LinkState.MediaLinked => base.Resources["MediaView"], 
			_ => null, 
		};
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
