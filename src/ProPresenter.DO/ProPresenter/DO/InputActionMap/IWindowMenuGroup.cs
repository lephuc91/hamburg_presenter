using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Collections;
using Pro.SerializationInterop.RVProtoData;
using Pro.UI.InputActions;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.DO.InputActionMap;

public interface IWindowMenuGroup : INotifyEnumerableChanged<InputAction>, IEnumerable<InputAction>, IEnumerable, INotifyCollectionChanged
{
	InputAction Maximize { get; }

	InputAction Minimize { get; }

	InputAction Restore { get; }

	InputAction WelcomeToPro { get; }

	INotifyEnumerableChanged<InputAction> AudienceScreens { get; }

	INotifyEnumerableChanged<InputAction> StageScreens { get; }

	void Deserialize(IEnumerable<KeyMapping> protoKeyMappings);

	void InitializeWindowedOutput(ScreenArrangementCollectionBase audienceScreens, ScreenArrangementCollectionBase stageScreens);
}
