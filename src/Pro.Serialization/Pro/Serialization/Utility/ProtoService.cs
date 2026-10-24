using Google.Protobuf;
using Pro.Common.FileSystem;

namespace Pro.Serialization.Utility;

public class ProtoService : IProtoService
{
	public FileIOResult TryReadFile<K>(string fullPath, out K? data) where K : IMessage<K>, new()
	{
		return ProtoHelper.TryReadFile<K>(fullPath, out data);
	}
}
