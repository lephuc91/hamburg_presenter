using System;
using Pro.Entity.Merged.Entities;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.OutputConfiguration;

public interface IScreenArrangementFactory
{
	ScreenArrangementBase FromArrangementType(ScreenArrangementType screenArrangementType, ScreenTargetType targetType, Screen[] screens, Guid screenID);

	ScreenArrangementBase FromEntity(IMergedScreen e);

	ScreenArrangementBase FromProtoScreen(ProPresenterScreen protoScreen);
}
