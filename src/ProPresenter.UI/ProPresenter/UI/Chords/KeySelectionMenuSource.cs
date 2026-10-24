using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using Pro.UI.Components;
using ProPresenter.DO.Chords;

namespace ProPresenter.UI.Chords;

public partial class KeySelectionMenuSource : FrameworkCollection, IComponentConnector
{
	public static readonly DependencyProperty SelectedKeyProperty = DependencyProperty.Register("SelectedKey", typeof(Key), typeof(KeySelectionMenuSource), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public Key SelectedKey
	{
		get
		{
			return (Key)((DependencyObject)this).GetValue(SelectedKeyProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedKeyProperty, (object)value);
		}
	}

	public KeySelectionMenuSource()
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
