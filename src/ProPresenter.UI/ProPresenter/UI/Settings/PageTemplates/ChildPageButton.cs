using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.UI.ViewModels.Settings;

namespace ProPresenter.UI.Settings.PageTemplates;

[ContentProperty("CustomContent")]
public partial class ChildPageButton : UserControl, IComponentConnector
{
	public static readonly DependencyProperty CustomContentProperty = DependencyProperty.Register("CustomContent", typeof(UIElement), typeof(ChildPageButton), new PropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty ChildPageVMProperty = DependencyProperty.Register("ChildPageVM", typeof(ISettingsItemVM), typeof(ChildPageButton), new PropertyMetadata((PropertyChangedCallback)null));

	public UIElement? CustomContent
	{
		get
		{
			return (UIElement)((DependencyObject)this).GetValue(CustomContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CustomContentProperty, (object)value);
		}
	}

	public ISettingsItemVM? ChildPageVM
	{
		get
		{
			return (ISettingsItemVM)((DependencyObject)this).GetValue(ChildPageVMProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ChildPageVMProperty, (object)value);
		}
	}

	public ChildPageButton()
	{
		InitializeComponent();
	}

	private void ButtonBase_OnClick(object? sender, RoutedEventArgs e)
	{
		OnGotoPage();
	}

	protected virtual void OnGotoPage()
	{
	}
}
