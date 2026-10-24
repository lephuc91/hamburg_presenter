using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using Pro.UI.InputActions;
using ProPresenter.DO.InputActionMap.OutputScreen;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.DO.InputActionMap;

public class WindowMenuGroup : InputActionGroupBase, IWindowMenuGroup, INotifyEnumerableChanged<InputAction>, IEnumerable<InputAction>, IEnumerable, INotifyCollectionChanged
{
	private const int IndexOffset = 4;

	private IEnumerable<KeyMapping>? _protoKeyMappings;

	private readonly PairedCollection<ScreenArrangementBase, InputAction> _audienceScreens;

	private readonly PairedCollection<ScreenArrangementBase, InputAction> _stageScreens;

	public InputAction Restore { get; }

	public InputAction Minimize { get; }

	public InputAction Maximize { get; }

	public InputAction WelcomeToPro { get; }

	public INotifyEnumerableChanged<InputAction> AudienceScreens => _audienceScreens;

	public INotifyEnumerableChanged<InputAction> StageScreens => _stageScreens;

	public WindowMenuGroup(string label, InputActionGroupCollectionBase parent)
		: base(label, parent)
	{
		Restore = Add("MAIN_MENU_WINDOW_RESTORE_title", LocalizedStrings.Get("MAIN_MENU_WINDOW_RESTORE_title"));
		Minimize = Add("MAIN_MENU_WINDOW_MINIMIZE_title", LocalizedStrings.Get("MAIN_MENU_WINDOW_MINIMIZE_title"));
		Maximize = Add("MAIN_MENU_WINDOW_ZOOM_windows_title", LocalizedStrings.Get("MAIN_MENU_WINDOW_ZOOM_windows_title"));
		WelcomeToPro = Add("MAIN_MENU_WINDOW_WELCOME_TO_PROPRESENTER_title", LocalizedStrings.Get("MAIN_MENU_WINDOW_WELCOME_TO_PROPRESENTER_title"));
		_audienceScreens = new PairedCollection<ScreenArrangementBase, InputAction>(null, CreateInputAction);
		_stageScreens = new PairedCollection<ScreenArrangementBase, InputAction>(null, CreateInputAction);
	}

	public void InitializeWindowedOutput(ScreenArrangementCollectionBase? audienceScreens, ScreenArrangementCollectionBase? stageScreens)
	{
		_audienceScreens.ChangeSource(audienceScreens);
		_stageScreens.ChangeSource(stageScreens);
		SetupScreenCollection(_audienceScreens);
		SetupScreenCollection(_stageScreens);
		OnReset();
		DeserializeScreens();
	}

	private void SetupScreenCollection(INotifyEnumerableChanged<InputAction> screens)
	{
		screens.CollectionChanged += OutputScreens_CollectionChanged;
		screens.ForEach(delegate(InputAction s)
		{
			AddScreen(base.Collection.Count, s);
		});
	}

	private void OutputScreens_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.Action == NotifyCollectionChangedAction.Move)
		{
			_protoKeyMappings = this.Serialize().ToArray();
		}
		e.OldItems?.OfType<OutputScreenInputAction>().ForEach(RemoveScreen);
		e.NewItems?.OfType<OutputScreenInputAction>().Reverse().ForEach(delegate(OutputScreenInputAction s)
		{
			if (s.Screen != null)
			{
				int newStartingIndex = e.NewStartingIndex;
				if (s.Screen.ScreenTargetType == ScreenTargetType.Stage)
				{
					OutputScreenInputAction outputScreenInputAction = base.Collection.OfType<OutputScreenInputAction>().FirstOrDefault(delegate(OutputScreenInputAction s)
					{
						ScreenArrangementBase? screen = s.Screen;
						return screen != null && screen.ScreenTargetType == ScreenTargetType.Stage;
					});
					newStartingIndex += ((outputScreenInputAction != null) ? base.Collection.IndexOf(outputScreenInputAction) : 5);
				}
				else
				{
					newStartingIndex += 4;
				}
				AddScreen(newStartingIndex, s);
			}
		});
		DeserializeScreens();
		CheckConflict();
		_protoKeyMappings = null;
	}

	private void AddScreen(int index, InputAction outputScreen)
	{
		index = index.Clamp(0, base.Collection.Count);
		Insert(index, outputScreen);
	}

	private void RemoveScreen(InputAction outputScreen)
	{
		Remove(outputScreen);
	}

	private InputAction CreateInputAction(ScreenArrangementBase sourceItem)
	{
		return new OutputScreenInputAction(sourceItem, null, this, LocalizedStrings.Get("NEW_WINDOWED_OUTPUT_title"));
	}

	public void Deserialize(IEnumerable<KeyMapping> protoKeyMappings)
	{
		_protoKeyMappings = protoKeyMappings.Where((KeyMapping i) => i.MenuItem != null).ToArray();
		this.DeserializeMenu(protoKeyMappings);
		DeserializeScreens();
	}

	private void DeserializeScreens()
	{
		if (_protoKeyMappings == null)
		{
			return;
		}
		foreach (KeyMapping protoKeyMap in _protoKeyMappings)
		{
			base.Collection.OfType<OutputScreenInputAction>().FirstOrDefaultBy((OutputScreenInputAction i) => i.Screen?.ID.ToString() == protoKeyMap.MenuItem)?.DeserializeKeyboardGesture(protoKeyMap);
		}
	}
}
