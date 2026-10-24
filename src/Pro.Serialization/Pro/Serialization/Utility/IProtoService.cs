using Google.Protobuf;
using Pro.Common.FileSystem;

namespace Pro.Serialization.Utility;

public interface IProtoService
{
	FileIOResult TryReadFile<K>(string fullPath, out K? data) where K : IMessage<K>, new();
}
