using System.Windows;
using System.Windows.Controls;
using Pro.UI.Controls;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels.ProContent.Group;

namespace ProPresenter.UI.ProContent;

public class ProContentGroupListBox : ListBoxBase<IProContentGroupVM, Pro.UI.Controls.ListBoxItem>
{
	public static readonly DependencyProperty FocusSearchBoxProperty = DependencyProperty.Register("FocusSearchBox", typeof(bool), typeof(ProContentGroupListBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(FocusSearchPropertyChanged)));

	public bool FocusSearchBox
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(FocusSearchBoxProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FocusSearchBoxProperty, (object)value);
		}
	}

	private static void FocusSearchPropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		if (callerObject is ProContentGroupListBox proContentGroupListBox)
		{
			proContentGroupListBox.FocusOnSearchbox();
		}
	}

	protected override void OnActiveItemChanged(IProContentGroupVM? activeItem)
	{
		base.OnActiveItemChanged(activeItem);
		if (activeItem is IProContentSearchGroupVM item)
		{
			TextBox textBox = ((DependencyObject)(object)(base.ItemContainerGenerator.ContainerFromItem(item) as Pro.UI.Controls.ListBoxItem))?.FindVisualChild<TextBox>();
			if (textBox != null)
			{
				textBox.Focus();
				textBox.SelectAll();
			}
		}
	}

	private void FocusOnSearchbox()
	{
		if (FocusSearchBox)
		{
			OnActiveItemChanged(base.ActiveItem);
		}
	}
}
