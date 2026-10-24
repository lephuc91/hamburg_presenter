using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.Controls;
using ProPresenter.Controller.Outputs;

namespace ProPresenter.UI.Transitions;

public partial class TransitionListBox : ListBox, IComponentConnector
{
	public static readonly DependencyProperty OutputControllerProperty = DependencyProperty.Register("OutputController", typeof(ssAPIOutput), typeof(TransitionListBox));

	public static readonly DependencyProperty NoResultsTextProperty = DependencyProperty.Register("NoResultsText", typeof(string), typeof(TransitionListBox), new PropertyMetadata((object)string.Empty));

	public static readonly DependencyProperty IsInstructionVisibleProperty = DependencyProperty.Register("IsInstructionVisible", typeof(bool), typeof(TransitionListBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));

	public ssAPIOutput? OutputController
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

	public string? NoResultsText
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(NoResultsTextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(NoResultsTextProperty, (object)value);
		}
	}

	public bool IsInstructionVisible
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsInstructionVisibleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsInstructionVisibleProperty, (object)value);
		}
	}

	public TransitionListBox()
	{
		InitializeComponent();
	}

	protected override DependencyObject GetContainerForItemOverride()
	{
		return (DependencyObject)(object)new SelectOnMouseUpListBoxItem();
	}
}
