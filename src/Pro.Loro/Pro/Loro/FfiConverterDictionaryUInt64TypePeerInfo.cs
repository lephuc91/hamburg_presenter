using System.Collections.Generic;
using System.Linq;

namespace Pro.Loro;

internal class FfiConverterDictionaryUInt64TypePeerInfo : FfiConverterRustBuffer<Dictionary<ulong, PeerInfo>>
{
	public static FfiConverterDictionaryUInt64TypePeerInfo INSTANCE = new FfiConverterDictionaryUInt64TypePeerInfo();

	public override Dictionary<ulong, PeerInfo> Read(BigEndianStream stream)
	{
		Dictionary<ulong, PeerInfo> dictionary = new Dictionary<ulong, PeerInfo>();
		int num = stream.ReadInt();
		for (int i = 0; i < num; i++)
		{
			ulong key = FfiConverterUInt64.INSTANCE.Read(stream);
			PeerInfo value = FfiConverterTypePeerInfo.INSTANCE.Read(stream);
			dictionary[key] = value;
		}
		return dictionary;
	}

	public override int AllocationSize(Dictionary<ulong, PeerInfo> value)
	{
		int num = 4;
		if (value == null)
		{
			return num;
		}
		int num2 = value.Select<KeyValuePair<ulong, PeerInfo>, int>((KeyValuePair<ulong, PeerInfo> item) => FfiConverterUInt64.INSTANCE.AllocationSize(item.Key) + FfiConverterTypePeerInfo.INSTANCE.AllocationSize(item.Value)).Sum();
		return num + num2;
	}

	public override void Write(Dictionary<ulong, PeerInfo> value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteInt(0);
			return;
		}
		stream.WriteInt(value.Count);
		foreach (KeyValuePair<ulong, PeerInfo> item in value)
		{
			FfiConverterUInt64.INSTANCE.Write(item.Key, stream);
			FfiConverterTypePeerInfo.INSTANCE.Write(item.Value, stream);
		}
	}
}
