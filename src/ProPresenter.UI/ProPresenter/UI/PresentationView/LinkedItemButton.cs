using System.Windows;
using System.Windows.Markup;
using Pro.UI.Components;
using Pro.UI.Controls;
using ProPresenter.DO.Cues;

namespace ProPresenter.UI.PresentationView;

public partial class LinkedItemButton : BorderlessButton, IComponentConnector
{
	public static readonly DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(LinkedItemButton));

	public static readonly DependencyProperty UnlinkCommandProperty = DependencyProperty.Register("UnlinkCommand", typeof(ICommand<ProPresenterCue>), typeof(LinkedItemButton));

	public static readonly DependencyProperty UploadCommandProperty = DependencyProperty.Register("UploadCommand", typeof(ICommand<ProPresenterCue>), typeof(LinkedItemButton));

	public string Label
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(LabelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LabelProperty, (object)value);
		}
	}

	public ICommand<ProPresenterCue> UnlinkCommand
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

	public ICommand<ProPresenterCue> UploadCommand
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

	public LinkedItemButton()
	{
		InitializeComponent();
	}
}
