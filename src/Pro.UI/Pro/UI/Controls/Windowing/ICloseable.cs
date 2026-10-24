namespace Pro.UI.Controls.Windowing;

public interface ICloseable
{
	bool IsClosing { get; }

	void Close();
}
