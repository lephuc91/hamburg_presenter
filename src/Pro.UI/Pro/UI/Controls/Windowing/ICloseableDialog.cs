namespace Pro.UI.Controls.Windowing;

public interface ICloseableDialog : ICloseable
{
	bool? DialogResult { get; set; }
}
