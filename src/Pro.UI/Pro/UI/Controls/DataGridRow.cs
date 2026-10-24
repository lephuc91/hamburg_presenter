using System.Windows;
using System.Windows.Controls;

namespace Pro.UI.Controls;

public class DataGridRow : System.Windows.Controls.DataGridRow
{
	private bool _canChangeSelection;

	static DataGridRow()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		System.Windows.Controls.DataGridRow.IsSelectedProperty.OverrideMetadata(typeof(DataGridRow), (PropertyMetadata)(object)new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, null, (CoerceValueCallback)delegate(DependencyObject d, object v)
		{
			DataGridRow dataGridRow = (DataGridRow)(object)d;
			return (!dataGridRow._canChangeSelection) ? ((object)dataGridRow.IsSelected) : v;
		}));
	}

	internal void SetIsSelected(bool isSelected)
	{
		_canChangeSelection = true;
		((DependencyObject)this).SetCurrentValue(System.Windows.Controls.DataGridRow.IsSelectedProperty, (object)isSelected);
		_canChangeSelection = false;
	}
}
