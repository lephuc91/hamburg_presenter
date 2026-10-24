using System;
using System.Linq;
using Pro.Common.Components.Reversibility;
using Pro.Localization;
using ProPresenter.DO.Events;

namespace ProPresenter.DO.OutputConfiguration;

public class StageScreenArrangementCollection : ScreenArrangementCollectionBase
{
	public override ScreenTargetType TargetType => ScreenTargetType.Stage;

	public override string DefaultScreenArrangementName => LocalizedStrings.Get("SCREEN_CONFIGURATION_STAGE_SCREEN_name");

	public StageScreenArrangementCollection(IScreenArrangementFactory factory, UndoStack undoStack, Func<bool> canAddMoreScreens)
		: base(factory, undoStack, canAddMoreScreens)
	{
	}

	public override ScreenArrangementBase GetDefaultScreen()
	{
		return GetDefaultScreen(isAudience: false);
	}

	protected override void OnCollectionModified()
	{
		base.OnCollectionModified();
		StageScreensUpdated.Publish(base.Collection.Select((ScreenArrangementBase s) => (ID: s.ID, Name: s.Name)));
	}
}
