using System;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity;

internal interface IInternalEntity : IEntity, IDisposable, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource
{
	LoroMap LoroMap { get; }
}
