using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using Pro.Text;
using Pro.UI.Utility;
using ProPresenter.UI.SlideEditor.Inspectors;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI.SlideEditor;

public partial class MainEditorMenu : MenuItem, IComponentConnector
{
	private static readonly DependencyProperty EditorCommandTargetProperty = DependencyProperty.Register("EditorCommandTarget", typeof(object), typeof(MainEditorMenu));

	private static readonly DependencyProperty LigaturesEnabledProperty = DependencyProperty.Register("LigaturesEnabled", typeof(bool), typeof(MainEditorMenu));

	private static readonly DependencyProperty CapitalizationTypeProperty = DependencyProperty.Register("CapitalizationType", typeof(CapitalizationType), typeof(MainEditorMenu));

	private static readonly DependencyProperty ParagraphAlignmentProperty = DependencyProperty.Register("ParagraphAlignment", typeof(ParagraphAlignment), typeof(MainEditorMenu));

	private static readonly DependencyProperty DocumentAlignmentProperty = DependencyProperty.Register("DocumentAlignment", typeof(DocumentAlignment), typeof(MainEditorMenu));

	private object? EditorCommandTarget
	{
		get
		{
			return ((DependencyObject)this).GetValue(EditorCommandTargetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EditorCommandTargetProperty, value);
		}
	}

	private bool LigaturesEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(LigaturesEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LigaturesEnabledProperty, (object)value);
		}
	}

	private CapitalizationType CapitalizationType
	{
		get
		{
			return (CapitalizationType)((DependencyObject)this).GetValue(CapitalizationTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CapitalizationTypeProperty, (object)value);
		}
	}

	private ParagraphAlignment ParagraphAlignment
	{
		get
		{
			return (ParagraphAlignment)((DependencyObject)this).GetValue(ParagraphAlignmentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ParagraphAlignmentProperty, (object)value);
		}
	}

	private DocumentAlignment DocumentAlignment
	{
		get
		{
			return (DocumentAlignment)((DependencyObject)this).GetValue(DocumentAlignmentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DocumentAlignmentProperty, (object)value);
		}
	}

	public MainEditorMenu()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		InitializeComponent();
		base.DataContextChanged += new DependencyPropertyChangedEventHandler(MenuLayout_DataContextChanged);
	}

	private void MenuLayout_DataContextChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).OldValue is IMenuLayoutVM menuLayoutVM)
		{
			menuLayoutVM.PropertyChanged -= MenuLayoutVM_PropertyChanged;
		}
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue is IMenuLayoutVM menuLayoutVM2)
		{
			menuLayoutVM2.PropertyChanged += MenuLayoutVM_PropertyChanged;
		}
	}

	private void MenuLayoutVM_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (sender is IMenuLayoutVM menuLayoutVM)
		{
			if (e.PropertyName == "EditorCommandTarget")
			{
				((DependencyObject)this).SetCurrentValue(EditorCommandTargetProperty, (object)CommandTargets.FindTarget(menuLayoutVM.EditorCommandTarget));
			}
			else if (e.PropertyName == "EditorTextCommandTarget" && CommandTargets.FindTarget(menuLayoutVM.EditorTextCommandTarget) is TextInspector source)
			{
				SetBinding(LigaturesEnabledProperty, new Binding("LigaturesEnabled")
				{
					Source = source
				});
				SetBinding(CapitalizationTypeProperty, new Binding("Capitalization")
				{
					Source = source
				});
				SetBinding(ParagraphAlignmentProperty, new Binding("ParagraphAlignment")
				{
					Source = source
				});
				SetBinding(DocumentAlignmentProperty, new Binding("DocumentAlignment")
				{
					Source = source
				});
			}
		}
	}
}
