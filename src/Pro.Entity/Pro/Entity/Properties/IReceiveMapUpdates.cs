using Pro.Loro;

namespace Pro.Entity.Properties;

internal interface IReceiveMapUpdates
{
	void UpdateMap(LoroMap map);

	void UpdateMapOnInternalMapUpdate(LoroMap map);
}
