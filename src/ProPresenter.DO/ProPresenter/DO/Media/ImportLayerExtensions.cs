using System;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Media;

public static class ImportLayerExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Action.Types.LayerType ToProtoImportLayer(this ImportLayer layer)
	{
		return layer switch
		{
			ImportLayer.Background => Pro.SerializationInterop.RVProtoData.Action.Types.LayerType.Background, 
			ImportLayer.Foreground => Pro.SerializationInterop.RVProtoData.Action.Types.LayerType.Foreground, 
			_ => throw new NotSupportedException(), 
		};
	}

	public static ImportLayer ToImportLayer(this Pro.SerializationInterop.RVProtoData.Action.Types.LayerType layer)
	{
		return layer switch
		{
			Pro.SerializationInterop.RVProtoData.Action.Types.LayerType.Background => ImportLayer.Background, 
			Pro.SerializationInterop.RVProtoData.Action.Types.LayerType.Foreground => ImportLayer.Foreground, 
			_ => throw new NotSupportedException(), 
		};
	}
}
