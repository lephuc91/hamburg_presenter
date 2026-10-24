using System;
using Google.Protobuf;

namespace Pro.Serialization.DataManagement;

public interface IProtoSyncedFileData<K, T> : ISyncedFileData<K, T>, IDisposable where K : class, IMessage<K>, new() where T : class
{
}
