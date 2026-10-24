using System;
using Pro.Common.Components.Reversibility;
using Pro.Localization;

namespace ProPresenter.DO.OutputConfiguration;

public class AudienceScreenArrangementCollection : ScreenArrangementCollectionBase
{
	public override ScreenTargetType TargetType => ScreenTargetType.Audience;

	public override string DefaultScreenArrangementName => LocalizedStrings.Get("SCREEN_CONFIGURATION_SCREEN_name");

	public AudienceScreenArrangementCollection(IScreenArrangementFactory factory, UndoStack undoStack, Func<bool> canAddMoreScreens)
		: base(factory, undoStack, canAddMoreScreens)
	{
	}
}
