namespace ProPresenter.UI.SlideEditor.Inspectors;

public abstract class TextSettingsCommandParameters<A, V>
{
	public A SettingsAction { get; }

	public V UndoActionType { get; }

	public bool AutoFinalize { get; }

	protected TextSettingsCommandParameters(A settingsAction, V undoActionType, bool autoFinalize)
	{
		SettingsAction = settingsAction;
		UndoActionType = undoActionType;
		AutoFinalize = autoFinalize;
	}
}
