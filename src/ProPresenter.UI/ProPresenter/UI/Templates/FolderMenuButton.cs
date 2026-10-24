using System.Windows;
using System.Windows.Controls;

namespace ProPresenter.UI.Templates;

public class FolderMenuButton : Button
{
	static FolderMenuButton()
	{
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(FolderMenuButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(FolderMenuButton)));
	}
}
