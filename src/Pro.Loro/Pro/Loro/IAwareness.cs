using System.Collections.Generic;

namespace Pro.Loro;

public interface IAwareness
{
	AwarenessPeerUpdate Apply(byte[] encodedPeersInfo);

	byte[] Encode(List<ulong> peers);

	byte[] EncodeAll();

	Dictionary<ulong, PeerInfo> GetAllStates();

	LoroValue? GetLocalState();

	ulong Peer();

	List<ulong> RemoveOutdated();

	void SetLocalState(LoroValueLike value);
}
