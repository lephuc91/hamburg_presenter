using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.OutputConfiguration;

public partial class EdgeBlend : UserControl, IComponentConnector
{
	public static readonly DependencyProperty MaxBlendWidthProperty = DependencyProperty.Register("MaxBlendWidth", typeof(double), typeof(EdgeBlend), new PropertyMetadata((object)0.0));

	private static readonly DependencyProperty BlendWidthProperty = DependencyProperty.Register("BlendWidth", typeof(double), typeof(EdgeBlend), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0, (PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is EdgeBlend { EdgeBlendOptions: not null } edgeBlend && ((DependencyPropertyChangedEventArgs)(ref e)).NewValue is double width)
		{
			edgeBlend.EdgeBlendOptions.Width = width;
		}
	}));

	public static readonly DependencyProperty EdgeBlendOptionsProperty = DependencyProperty.Register("EdgeBlendOptions", typeof(EdgeBlendOptions), typeof(EdgeBlend), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((EdgeBlend)(object)d).EdgeBlendOptionsChanged(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as EdgeBlendOptions);
	}));

	private double MaxBlendWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MaxBlendWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaxBlendWidthProperty, (object)value);
		}
	}

	private double BlendWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(BlendWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BlendWidthProperty, (object)value);
		}
	}

	public EdgeBlendOptions? EdgeBlendOptions
	{
		get
		{
			return (EdgeBlendOptions)((DependencyObject)this).GetValue(EdgeBlendOptionsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EdgeBlendOptionsProperty, (object)value);
		}
	}

	public EdgeBlend()
	{
		InitializeComponent();
	}

	private void EdgeBlendOptionsChanged(EdgeBlendOptions? edgeBlendOptions)
	{
		if (edgeBlendOptions != null)
		{
			((DependencyObject)this).SetCurrentValue(MaxBlendWidthProperty, (object)edgeBlendOptions.MaxWidth);
			((DependencyObject)this).SetCurrentValue(BlendWidthProperty, (object)edgeBlendOptions.Width);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
