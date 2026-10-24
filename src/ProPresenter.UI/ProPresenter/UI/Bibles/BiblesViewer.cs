using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.DO.Arrangements;

namespace ProPresenter.UI.Bibles;

public partial class BiblesViewer : UserControl, IComponentConnector
{
	public static readonly DependencyProperty SelectedSlidesProperty = DependencyProperty.Register("SelectedSlides", typeof(ObservableCollection<ArrangedCue>), typeof(BiblesViewer));

	public ObservableCollection<ArrangedCue>? SelectedSlides
	{
		get
		{
			return (ObservableCollection<ArrangedCue>)((DependencyObject)this).GetValue(SelectedSlidesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedSlidesProperty, (object)value);
		}
	}

	public BiblesViewer()
	{
		InitializeComponent();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
