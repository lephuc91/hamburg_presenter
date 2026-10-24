using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.Components;
using ProPresenter.DO.Cues;
using ProPresenter.UI.PresentationView;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI.PCO;

public partial class HeaderBarView : UserControl, IComponentConnector
{
	public static readonly DependencyProperty PresentationVMProperty = DependencyProperty.Register("PresentationVM", typeof(IPresentationVM), typeof(HeaderBarView));

	public static readonly DependencyProperty CueProperty = DependencyProperty.Register("Cue", typeof(ProPresenterCue), typeof(HeaderBarView));

	public static readonly DependencyProperty LinkNewPresentationCommandProperty = DependencyProperty.Register("LinkNewPresentationCommand", typeof(ICommand<LinkCommandParameters>), typeof(HeaderBarView));

	public static readonly DependencyProperty LinkImportCommandProperty = DependencyProperty.Register("LinkImportCommand", typeof(ICommand<LinkCommandParameters>), typeof(HeaderBarView));

	public static readonly DependencyProperty LinkDocumentCommandProperty = DependencyProperty.Register("LinkDocumentCommand", typeof(ICommand<LinkCommandParameters>), typeof(HeaderBarView));

	public static readonly DependencyProperty LinkMediaCommandProperty = DependencyProperty.Register("LinkMediaCommand", typeof(ICommand<LinkCommandParameters>), typeof(HeaderBarView));

	public static readonly DependencyProperty LinkDropFilesCommandProperty = DependencyProperty.Register("LinkDropFilesCommand", typeof(ICommand<LinkCommandParameters>), typeof(HeaderBarView));

	public static readonly DependencyProperty LinkSongSelectItemCommandProperty = DependencyProperty.Register("LinkSongSelectItemCommand", typeof(ICommand<LinkCommandParameters>), typeof(HeaderBarView));

	public static readonly DependencyProperty LinkMultiTracksItemCommandProperty = DependencyProperty.Register("LinkMultiTracksItemCommand", typeof(ICommand<LinkCommandParameters>), typeof(HeaderBarView));

	public static readonly DependencyProperty UnlinkCommandProperty = DependencyProperty.Register("UnlinkCommand", typeof(ICommand<ProPresenterCue>), typeof(HeaderBarView));

	public static readonly DependencyProperty UploadCommandProperty = DependencyProperty.Register("UploadCommand", typeof(ICommand<ProPresenterCue>), typeof(HeaderBarView));

	public static readonly DependencyProperty OpenAttachmentsCommandProperty = DependencyProperty.Register("OpenAttachmentsCommand", typeof(ICommand<ProPresenterCue>), typeof(HeaderBarView));

	public static readonly DependencyProperty OpenSearchCommandProperty = DependencyProperty.Register("OpenSearchCommand", typeof(ICommand<ProPresenterCue>), typeof(HeaderBarView));

	public static readonly DependencyProperty ItemActivatedCommandProperty = DependencyProperty.Register("ItemActivatedCommand", typeof(ICommand<ProPresenterCue>), typeof(HeaderBarView));

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

	public ProPresenterCue? Cue
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

	public ICommand<LinkCommandParameters>? LinkNewPresentationCommand
	{
		get
		{
			return (ICommand<LinkCommandParameters>)((DependencyObject)this).GetValue(LinkNewPresentationCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LinkNewPresentationCommandProperty, (object)value);
		}
	}

	public ICommand<LinkCommandParameters>? LinkImportCommand
	{
		get
		{
			return (ICommand<LinkCommandParameters>)((DependencyObject)this).GetValue(LinkImportCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LinkImportCommandProperty, (object)value);
		}
	}

	public ICommand<LinkCommandParameters>? LinkDocumentCommand
	{
		get
		{
			return (ICommand<LinkCommandParameters>)((DependencyObject)this).GetValue(LinkDocumentCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LinkDocumentCommandProperty, (object)value);
		}
	}

	public ICommand<LinkCommandParameters>? LinkMediaCommand
	{
		get
		{
			return (ICommand<LinkCommandParameters>)((DependencyObject)this).GetValue(LinkMediaCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LinkMediaCommandProperty, (object)value);
		}
	}

	public ICommand<LinkCommandParameters>? LinkDropFilesCommand
	{
		get
		{
			return (ICommand<LinkCommandParameters>)((DependencyObject)this).GetValue(LinkDropFilesCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LinkDropFilesCommandProperty, (object)value);
		}
	}

	public ICommand<LinkCommandParameters>? LinkSongSelectItemCommand
	{
		get
		{
			return (ICommand<LinkCommandParameters>)((DependencyObject)this).GetValue(LinkSongSelectItemCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LinkSongSelectItemCommandProperty, (object)value);
		}
	}

	public ICommand<LinkCommandParameters>? LinkMultiTracksItemCommand
	{
		get
		{
			return (ICommand<LinkCommandParameters>)((DependencyObject)this).GetValue(LinkMultiTracksItemCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LinkMultiTracksItemCommandProperty, (object)value);
		}
	}

	public ICommand<ProPresenterCue>? UnlinkCommand
	{
		get
		{
			return (ICommand<ProPresenterCue>)((DependencyObject)this).GetValue(UnlinkCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(UnlinkCommandProperty, (object)value);
		}
	}

	public ICommand<ProPresenterCue>? UploadCommand
	{
		get
		{
			return (ICommand<ProPresenterCue>)((DependencyObject)this).GetValue(UploadCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(UploadCommandProperty, (object)value);
		}
	}

	public ICommand<ProPresenterCue>? OpenAttachmentsCommand
	{
		get
		{
			return (ICommand<ProPresenterCue>)((DependencyObject)this).GetValue(OpenAttachmentsCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OpenAttachmentsCommandProperty, (object)value);
		}
	}

	public ICommand<ProPresenterCue>? OpenSearchCommand
	{
		get
		{
			return (ICommand<ProPresenterCue>)((DependencyObject)this).GetValue(OpenSearchCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OpenSearchCommandProperty, (object)value);
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

	public HeaderBarView()
	{
		InitializeComponent();
	}
}
