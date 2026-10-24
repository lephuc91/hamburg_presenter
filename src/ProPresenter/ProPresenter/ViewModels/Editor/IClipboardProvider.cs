using System.Collections.Generic;

namespace ProPresenter.ViewModels.Editor;

public interface IClipboardProvider
{
	bool ContainsData<T>();

	bool ContainsImage();

	IEnumerable<T>? GetData<T>();

	void SetData<T>(T data);

	string? GetImage();
}
