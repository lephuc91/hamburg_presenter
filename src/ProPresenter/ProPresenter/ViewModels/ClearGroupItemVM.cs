using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Pro.Common.Components;
using Pro.DO.Triggering;
using ProPresenter.DO.ClearGroups;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels;

public class ClearGroupItemVM : LinkedNotifyPropertyChangedBase, IClearGroupItemVM, ITriggerable, INotifyPropertyChanged
{
	public ClearGroup Item { get; }

	public string Name
	{
		get
		{
			return Item?.Name ?? string.Empty;
		}
		set
		{
			if (Item != null)
			{
				Item.Name = value;
			}
			OnPropertyChanged("Name");
		}
	}

	public BitmapSource? Icon => Item.Icon;

	public bool IsHiddenInPreview => Item?.IsHiddenInPreview ?? false;

	public Color IconFill => Item.IconFill;

	public ValidationRule NameValidationRule { get; }

	public ClearGroupItemVM(ClearGroup clearGroup, StringValueValidationRule nameValidationRule)
	{
		Item = clearGroup;
		NameValidationRule = nameValidationRule;
		LinkProperties("IsHiddenInPreview", "IsHiddenInPreview");
		LinkProperties("Name", "Name");
		LinkProperties(new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "IsIconTinted", "IconTint" }), "IconFill");
		LinkProperties("Icon", "Icon");
		Item.PropertyChanged += base.RaiseLinkedValues;
	}
}
