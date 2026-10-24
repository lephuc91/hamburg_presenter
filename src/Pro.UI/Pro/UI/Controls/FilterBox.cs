using System.Windows;

namespace Pro.UI.Controls;

public class FilterBox : SearchBox
{
	static FilterBox()
	{
		PlaceholderTextBox.PlaceholderPathTypeProperty.OverrideMetadata(typeof(FilterBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)PathType.Filter));
	}
}
