using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using Pro.DO.Transitions;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;

namespace ProPresenter.UI.PresentationView;

public partial class MediaViewHeaderBar : UserControl, IComponentConnector
{
	public static readonly DependencyProperty MediaItemProperty = DependencyProperty.Register("MediaItem", typeof(ProPresenterCue), typeof(MediaViewHeaderBar), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(CueChangedCallback)));

	public static readonly DependencyProperty AdditionalContentProperty = DependencyProperty.Register("AdditionalContent", typeof(DataTemplate), typeof(MediaViewHeaderBar));

	public static readonly DependencyProperty OutputControllerProperty = DependencyProperty.Register("OutputController", typeof(ssAPIOutput), typeof(MediaViewHeaderBar));

	public static readonly DependencyProperty TransitionHandlerProperty = DependencyProperty.Register("TransitionHandler", typeof(TransitionHandler), typeof(MediaViewHeaderBar));

	public static readonly DependencyProperty MediaActionProperty = DependencyProperty.Register("MediaAction", typeof(MediaAction), typeof(MediaViewHeaderBar));

	public ProPresenterCue MediaItem
	{
		get
		{
			return (ProPresenterCue)((DependencyObject)this).GetValue(MediaItemProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MediaItemProperty, (object)value);
		}
	}

	public DataTemplate AdditionalContent
	{
		get
		{
			return (DataTemplate)((DependencyObject)this).GetValue(AdditionalContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AdditionalContentProperty, (object)value);
		}
	}

	public ssAPIOutput OutputController
	{
		get
		{
			return (ssAPIOutput)((DependencyObject)this).GetValue(OutputControllerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OutputControllerProperty, (object)value);
		}
	}

	public TransitionHandler TransitionHandler
	{
		get
		{
			return (TransitionHandler)((DependencyObject)this).GetValue(TransitionHandlerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TransitionHandlerProperty, (object)value);
		}
	}

	private MediaAction? MediaAction
	{
		get
		{
			return (MediaAction)((DependencyObject)this).GetValue(MediaActionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MediaActionProperty, (object)value);
		}
	}

	private static void CueChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((MediaViewHeaderBar)(object)d).OnCueChanged(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ProPresenterCue);
	}

	public MediaViewHeaderBar()
	{
		InitializeComponent();
		TransitionHandler = new TransitionHandler(DataVault.Transitions);
		TransitionHandler.TransitionFinalized += TransitionUpdated;
	}

	private void TransitionUpdated(TransitionParameters? newTransition)
	{
		if (MediaAction != null)
		{
			MediaAction.SelectedTransition = newTransition;
		}
	}

	private void OnCueChanged(ProPresenterCue? proPresenterCue)
	{
		if (proPresenterCue == null)
		{
			((DependencyObject)this).SetCurrentValue(MediaActionProperty, (object)null);
		}
		else if (proPresenterCue is IMediaCue source)
		{
			SetBinding(MediaActionProperty, new Binding("MediaAction")
			{
				Source = source
			});
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
