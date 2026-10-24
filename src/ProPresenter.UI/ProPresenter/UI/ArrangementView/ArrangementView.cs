using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.DO.Actions;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI.ArrangementView;

public partial class ArrangementView : UserControl, IComponentConnector
{
	public static readonly DependencyProperty DocumentActionProperty = DependencyProperty.Register("DocumentAction", typeof(DocumentAction), typeof(ArrangementView), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((IArrangementVM)((ArrangementView)(object)s).DataContext).DocumentAction = (DocumentAction)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
	}));

	public DocumentAction? DocumentAction
	{
		get
		{
			return (DocumentAction)((DependencyObject)this).GetValue(DocumentActionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DocumentActionProperty, (object)value);
		}
	}

	public ArrangementView()
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
