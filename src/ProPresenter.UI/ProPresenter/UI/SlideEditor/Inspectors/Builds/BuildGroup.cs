using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.DO.Slide.Builds;
using ProPresenter.UI.ViewModels.Editor;

namespace ProPresenter.UI.SlideEditor.Inspectors.Builds;

public partial class BuildGroup : UserControl, IComponentConnector
{
	public static readonly DependencyProperty BuildVMProperty = DependencyProperty.Register("BuildVM", typeof(IBuildInspectorVM), typeof(BuildGroup));

	public static readonly DependencyProperty BuildsProperty = DependencyProperty.Register("Builds", typeof(ObservableCollection<IBuild>), typeof(BuildGroup));

	public IBuildInspectorVM? BuildVM
	{
		get
		{
			return (IBuildInspectorVM)((DependencyObject)this).GetValue(BuildVMProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BuildVMProperty, (object)value);
		}
	}

	public ObservableCollection<IBuild>? Builds
	{
		get
		{
			return (ObservableCollection<IBuild>)((DependencyObject)this).GetValue(BuildsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BuildsProperty, (object)value);
		}
	}

	internal UIElement IndicatorElement => GroupBorder;

	public BuildGroup()
	{
		InitializeComponent();
	}
}
