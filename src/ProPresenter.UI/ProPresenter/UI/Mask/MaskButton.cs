using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Components;
using ProPresenter.DO.Cues;
using ProPresenter.UI.Commands;

namespace ProPresenter.UI.Mask;

public partial class MaskButton : Button, IComponentConnector
{
	public static readonly DependencyProperty SelectedMaskProperty = DependencyProperty.Register("SelectedMask", typeof(SlideCue), typeof(MaskButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty MasksProperty = DependencyProperty.Register("Masks", typeof(IEnumerable<SlideCue>), typeof(MaskButton));

	public static readonly DependencyProperty SelectMaskCommandProperty = DependencyProperty.Register("SelectMaskCommand", typeof(ICommand<SlideCue>), typeof(MaskButton));

	public static readonly DependencyProperty EditMasksCommandProperty = DependencyProperty.Register("EditMasksCommand", typeof(ICommand<ShowSource>), typeof(MaskButton));

	public static readonly DependencyProperty AddNewMaskCommandProperty = DependencyProperty.Register("AddNewMaskCommand", typeof(ICommand), typeof(MaskButton));

	public SlideCue? SelectedMask
	{
		get
		{
			return (SlideCue)((DependencyObject)this).GetValue(SelectedMaskProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedMaskProperty, (object)value);
		}
	}

	public IEnumerable<SlideCue>? Masks
	{
		get
		{
			return (IEnumerable<SlideCue>)((DependencyObject)this).GetValue(MasksProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MasksProperty, (object)value);
		}
	}

	public ICommand<SlideCue>? SelectMaskCommand
	{
		get
		{
			return (ICommand<SlideCue>)((DependencyObject)this).GetValue(SelectMaskCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectMaskCommandProperty, (object)value);
		}
	}

	public ICommand<ShowSource>? EditMasksCommand
	{
		get
		{
			return (ICommand<ShowSource>)((DependencyObject)this).GetValue(EditMasksCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EditMasksCommandProperty, (object)value);
		}
	}

	public ICommand? AddNewMaskCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(AddNewMaskCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddNewMaskCommandProperty, (object)value);
		}
	}

	public MaskButton()
	{
		SelectMaskCommand = new RelayCommand<SlideCue>(delegate(SlideCue c)
		{
			((DependencyObject)this).SetValue(SelectedMaskProperty, (object)c);
		});
		InitializeComponent();
	}

	private void ContextMenu_Opened(object? sender, RoutedEventArgs e)
	{
		base.ContextMenu.Items.Refresh();
	}
}
