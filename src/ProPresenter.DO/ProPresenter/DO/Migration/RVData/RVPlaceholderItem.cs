using System;
using System.Windows.Controls;

namespace ProPresenter.DO.Migration.RVData;

public class RVPlaceholderItem : Control
{
	public string? FieldName { get; set; }

	public Guid ObjectId { get; set; }

	public string? MessageFieldValue { get; set; }

	public bool IsTimer { get; set; }

	public bool IsClock { get; set; }
}
