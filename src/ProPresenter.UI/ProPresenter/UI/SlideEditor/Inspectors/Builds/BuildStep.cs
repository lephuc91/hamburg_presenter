using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Utility;
using ProPresenter.DO.Slide.Builds;
using ProPresenter.UI.ViewModels.Editor;

namespace ProPresenter.UI.SlideEditor.Inspectors.Builds;

public partial class BuildStep : UserControl, IComponentConnector
{
	public static readonly DependencyProperty BuildVMProperty = DependencyProperty.Register("BuildVM", typeof(IBuildInspectorVM), typeof(BuildStep), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((BuildStep)(object)s).OnBuildVMChanged(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as IBuildInspectorVM);
	}));

	public static readonly DependencyProperty BuildProperty = DependencyProperty.Register("Build", typeof(IBuild), typeof(BuildStep));

	public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(BuildStep));

	private static readonly DependencyProperty StartNumberProperty = DependencyProperty.Register("StartNumber", typeof(int), typeof(BuildStep));

	public static readonly DependencyProperty IndexProperty = DependencyProperty.Register("Index", typeof(int), typeof(BuildStep));

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

	public IBuild? Build
	{
		get
		{
			return (IBuild)((DependencyObject)this).GetValue(BuildProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BuildProperty, (object)value);
		}
	}

	public bool IsSelected
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsSelectedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsSelectedProperty, (object)value);
		}
	}

	private int StartNumber
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(StartNumberProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StartNumberProperty, (object)value);
		}
	}

	public int Index
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(IndexProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IndexProperty, (object)value);
		}
	}

	public BuildStep()
	{
		InitializeComponent();
	}

	private void OnBuildVMChanged(IBuildInspectorVM? newValue)
	{
		if (newValue != null)
		{
			newValue.SelectedBuilds.CollectionChanged += delegate
			{
				UpdateSelection();
			};
			UpdateStartNumber();
			UpdateSelection();
		}
	}

	protected override void OnMouseUp(MouseButtonEventArgs e)
	{
		if (Build != null)
		{
			BuildVM?.SelectBuildsCommand.Invoke<IBuild>(Build);
		}
	}

	private void UpdateStartNumber()
	{
		if (BuildVM != null && Build != null && BuildVM.BuildIndexMap.TryGetValue(Build, out var value))
		{
			StartNumber = value;
		}
	}

	private void UpdateSelection()
	{
		IsSelected = Build != null && (BuildVM?.SelectedBuilds.Contains(Build) ?? false);
	}
}
