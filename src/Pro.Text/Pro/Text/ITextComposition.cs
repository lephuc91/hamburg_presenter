using System;

namespace Pro.Text;

public interface ITextComposition
{
	event Action Started;

	event Action<string>? Updated;

	event Action<string?>? Complete;

	void SetFocus();

	void Cancel();
}
