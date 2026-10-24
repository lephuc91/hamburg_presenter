using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.Components;
using ProPresenter.DO.Arrangements;

namespace ProPresenter.UI.ArrangementView;

public partial class GroupToken : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ArrangementGroupProperty = DependencyProperty.Register("ArrangementGroup", typeof(CueGroup), typeof(GroupToken));

	public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register("IsActive", typeof(bool), typeof(GroupToken), new PropertyMetadata((object)false));

	public static readonly DependencyProperty ShowCloseButtonProperty = DependencyProperty.Register("ShowCloseButton", typeof(bool), typeof(GroupToken), new PropertyMetadata((object)false));

	public static readonly DependencyProperty FullOpacityProperty = DependencyProperty.Register("FullOpacity", typeof(bool), typeof(GroupToken), new PropertyMetadata((object)false));

	public static readonly DependencyProperty RemoveArrangementGroupCommandProperty = DependencyProperty.Register("RemoveArrangementGroupCommand", typeof(ICommand<CueGroup>), typeof(GroupToken));

	public CueGroup? ArrangementGroup
	{
		get
		{
			return (CueGroup)((DependencyObject)this).GetValue(ArrangementGroupProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ArrangementGroupProperty, (object)value);
		}
	}

	public bool IsActive
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsActiveProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsActiveProperty, (object)value);
		}
	}

	public bool ShowCloseButton
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowCloseButtonProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowCloseButtonProperty, (object)value);
		}
	}

	public bool FullOpacity
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(FullOpacityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FullOpacityProperty, (object)value);
		}
	}

	public ICommand<CueGroup>? RemoveArrangementGroupCommand
	{
		get
		{
			return (ICommand<CueGroup>)((DependencyObject)this).GetValue(RemoveArrangementGroupCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RemoveArrangementGroupCommandProperty, (object)value);
		}
	}

	public GroupToken(CueGroup group)
	{
		ArrangementGroup = group;
		InitializeComponent();
	}
}
