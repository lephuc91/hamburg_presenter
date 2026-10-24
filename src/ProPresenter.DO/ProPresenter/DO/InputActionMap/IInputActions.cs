using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.SerializationInterop.RVProtoData;
using Pro.UI.InputActions;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.InputActionMap;

public interface IInputActions : IReadOnlyCollection<InputActionGroupBase>, IEnumerable<InputActionGroupBase>, IEnumerable, INotifyEnumerableChanged<InputActionGroupBase>, INotifyCollectionChanged, IDocumentProvider
{
	CommonInputActionGroup CommonInputActions { get; }

	ProPresenterGroup ProCommon { get; }

	ProMenuGroup ProMenu { get; }

	FileMenuGroup FileMenu { get; }

	EditMenuGroup EditMenu { get; }

	PresentationMenuGroup PresentationMenu { get; }

	EditorMenuGroup EditorMenu { get; }

	ReflowMenuGroup ReflowMenu { get; }

	ScreensMenuGroup ScreensMenu { get; }

	CalendarMenuGroup CalendarMenu { get; }

	ViewMenuGroup ViewMenu { get; }

	WindowMenuGroup WindowMenu { get; }

	HelpMenuGroup HelpMenu { get; }

	ClearGroupGroup ClearGroups { get; }

	GroupLabelGroup GroupLabels { get; }

	MacroGroup Macros { get; }

	MacroGroupsGroup MacroGroups { get; }

	PropGroup Props { get; }

	PropsGroupsGroup PropGroups { get; }

	UndoStack UndoStack { get; }

	void Deserialize(KeyMappingDocument document);

	void InitializeShowGroups();

	void ResetAll();
}
