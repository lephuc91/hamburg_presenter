using System.Collections.Generic;
using System.Windows.Media;
using Pro.DO.Label;

namespace ProPresenter.DO.Label;

public interface ILabelInteractor
{
	IEnumerable<ILabel>? Labels { get; }

	string SaveLabel { get; }

	bool MultipleTargets { get; }

	bool MultipleColors { get; }

	ILabel? Target { get; }

	void ApplyChange(ILabel preset);

	void ApplyChange(string name, Color color);

	void SaveToPreferences(string name, Color color);
}
