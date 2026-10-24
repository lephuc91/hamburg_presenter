using System;
using Google.Protobuf;

namespace Pro.Serialization.DataManagement;

public interface IProtoSyncedData<T> : ISyncedData<IProtoSyncedData<T>, T>, IDisposable where T : IMessage<T>, new()
{
}
