using System;
using Pro.Entity;
using Pro.Entity.Merged.Entities;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.OutputConfiguration;

public class ScreenArrangementFactory : IScreenArrangementFactory
{
	public ScreenArrangementBase FromProtoScreen(ProPresenterScreen protoScreen)
	{
		return GenerateScreen(protoScreen);
	}

	public ScreenArrangementBase FromArrangementType(ScreenArrangementType screenArrangementType, ScreenTargetType targetType, Screen[] screens, Guid screenID)
	{
		return screenArrangementType switch
		{
			ScreenArrangementType.Single => new SingleScreenArrangement(targetType, screens, 1, screenID), 
			ScreenArrangementType.Mirror => new SingleScreenArrangement(targetType, screens, Math.Max(screens.Length, 2), screenID), 
			ScreenArrangementType.Group => new CombinedScreenArrangement(targetType, screens, screenID), 
			ScreenArrangementType.EdgeBlend => new EdgeBlendScreenArrangement(targetType, screens, screenID), 
			_ => throw new NotSupportedException("Unknown arrangement type"), 
		};
	}

	private static ScreenArrangementBase GenerateScreen(ProPresenterScreen protoScreen)
	{
		ScreenTargetType screenTargetType = protoScreen.ScreenType.ToScreenTargetType();
		return protoScreen.ArrangementCase switch
		{
			ProPresenterScreen.ArrangementOneofCase.ArrangementCombined => new CombinedScreenArrangement(screenTargetType, null, null), 
			ProPresenterScreen.ArrangementOneofCase.ArrangementEdgeBlend => new EdgeBlendScreenArrangement(screenTargetType, null, null), 
			_ => new SingleScreenArrangement(screenTargetType, null, 1, null), 
		};
	}

	public ScreenArrangementBase FromEntity(IMergedScreen e)
	{
		ScreenTargetType screenTargetType = e.ScreenType.Value.ToScreenTargetType();
		if (e.Arrangement.Value is IProPresenterScreen.Types.IArrangement.IArrangementCombined)
		{
			return new CombinedScreenArrangement(screenTargetType, null, null);
		}
		if (e.Arrangement.Value is IProPresenterScreen.Types.IArrangement.IArrangementEdgeBlend)
		{
			return new EdgeBlendScreenArrangement(screenTargetType, null, null);
		}
		return new SingleScreenArrangement(screenTargetType, null, 1, null);
	}
}
