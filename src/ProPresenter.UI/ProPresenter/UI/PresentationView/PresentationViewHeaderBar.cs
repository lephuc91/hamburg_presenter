using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.DependencyInjection;
using ProPresenter.Controller;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ArrangementView;
using ProPresenter.UI.PresentationView.PresentationTimeline;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Presentation;

namespace ProPresenter.UI.PresentationView;

public partial class PresentationViewHeaderBar : UserControl, IComponentConnector
{
	public static readonly DependencyProperty IsHeaderContentEnabledProperty = DependencyProperty.Register("IsHeaderContentEnabled", typeof(bool), typeof(PresentationViewHeaderBar), new PropertyMetadata((object)true));

	public static readonly DependencyProperty CueProperty = DependencyProperty.Register("Cue", typeof(ProPresenterCue), typeof(PresentationViewHeaderBar), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((PresentationViewHeaderBar)(object)s).OnCueChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as ProPresenterCue, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ProPresenterCue);
	}));

	public static readonly DependencyProperty PresentationVMProperty = DependencyProperty.Register("PresentationVM", typeof(IPresentationVM), typeof(PresentationViewHeaderBar));

	public static readonly DependencyProperty AdditionalContentProperty = DependencyProperty.Register("AdditionalContent", typeof(DataTemplate), typeof(PresentationViewHeaderBar));

	public static readonly DependencyProperty TimelineActionsMenuVMProperty = DependencyProperty.Register("TimelineActionsMenuVM", typeof(IActionsMenuVM), typeof(PresentationViewHeaderBar));

	public IPresentationVM? PresentationVM
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

	public bool IsHeaderContentEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsHeaderContentEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsHeaderContentEnabledProperty, (object)value);
		}
	}

	public IActionsMenuVM TimelineActionsMenuVM
	{
		get
		{
			return (IActionsMenuVM)((DependencyObject)this).GetValue(TimelineActionsMenuVMProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TimelineActionsMenuVMProperty, (object)value);
		}
	}

	public PresentationHeaderVM PresentationHeaderVM { get; }

	public PresentationViewHeaderBar()
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		PresentationHeaderVM = new PresentationHeaderVM(UIServiceProvider.GetService<IApp>(), UIServiceProvider.GetService<ITimelineManager>(), UIServiceProvider.GetService<IMissingFontService>(), UIServiceProvider.GetService<IMissingFontWindowProvider>(), UIServiceProvider.GetService<IOutputService>());
		InitializeComponent();
		base.IsVisibleChanged += new DependencyPropertyChangedEventHandler(OnIsVisibleChanged);
		PresentationHeaderVM.PropertyChanged += delegate(object? s, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "ActiveHeaderView")
			{
				OnActiveHeaderViewChanged(PresentationHeaderVM.ActiveHeaderView);
			}
		};
	}

	private void OnIsVisibleChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if ((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue && HeaderContentPresenter.Content == null)
		{
			IHeaderContentContextMenuVM service = UIServiceProvider.GetService<IHeaderContentContextMenuVM>();
			HeaderContentPresenter.Content = new HeaderContentView(service)
			{
				DataContext = PresentationHeaderVM,
				AdditionalContent = AdditionalContent
			};
		}
	}

	private void OnCueChanged(ProPresenterCue? oldCue, ProPresenterCue? newCue)
	{
		PresentationHeaderVM.DocumentCue = newCue as IDocumentCue;
		if (oldCue is IDocumentCue documentCue)
		{
			documentCue.PropertyChanged -= PCOAction_PropertyChanged;
		}
		if (newCue is IDocumentCue documentCue2)
		{
			documentCue2.PropertyChanged += PCOAction_PropertyChanged;
		}
	}

	private void PCOAction_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string? propertyName = e.PropertyName;
		if (propertyName != null && propertyName.Equals("DocumentAction") && sender is IDocumentCue documentCue)
		{
			PresentationHeaderVM.DocumentCue = documentCue;
		}
	}

	private void OnActiveHeaderViewChanged(PresentationHeaderViewType viewType)
	{
		switch (viewType)
		{
		case PresentationHeaderViewType.Timeline:
			if (TimelineContentPresenter.Content == null)
			{
				TimelineViewer timelineViewer = new TimelineViewer();
				timelineViewer.SetBinding(TimelineViewer.DocumentCueProperty, new Binding("DocumentCue")
				{
					Source = PresentationHeaderVM
				});
				timelineViewer.SetBinding(TimelineViewer.TimelineActionsMenuVMProperty, new Binding("TimelineActionsMenuVM")
				{
					Source = this
				});
				TimelineContentPresenter.Content = timelineViewer;
			}
			break;
		case PresentationHeaderViewType.Arrangements:
			if (ArrangementContentPresenter.Content == null)
			{
				ProPresenter.UI.ArrangementView.ArrangementView arrangementView = new ProPresenter.UI.ArrangementView.ArrangementView();
				arrangementView.SetBinding(ProPresenter.UI.ArrangementView.ArrangementView.DocumentActionProperty, new Binding("DocumentAction")
				{
					Source = PresentationHeaderVM
				});
				ArrangementContentPresenter.Content = arrangementView;
			}
			break;
		case PresentationHeaderViewType.Notes:
			NotesContentPresenter.Content = new NotesView();
			break;
		}
	}

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		base.OnMouseDown(e);
		if (PresentationVM != null && Cue != null)
		{
			PresentationVM.ActivePlaylistItem = Cue;
		}
	}
}
