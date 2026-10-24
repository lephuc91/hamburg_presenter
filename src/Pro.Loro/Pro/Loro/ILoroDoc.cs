using System.Collections.Generic;

namespace Pro.Loro;

public interface ILoroDoc
{
	void ApplyDiff(DiffBatch diff);

	void Attach();

	void CheckStateCorrectnessSlow();

	void Checkout(Frontiers frontiers);

	void CheckoutToLatest();

	void ClearNextCommitOptions();

	Ordering CmpWithFrontiers(Frontiers other);

	void Commit();

	void CommitWith(CommitOptions options);

	void CompactChangeStore();

	Configure Config();

	void ConfigDefaultTextStyle(StyleConfig? textStyle);

	void ConfigTextStyle(StyleConfigMap textStyle);

	void DeleteRootContainer(ContainerId cid);

	void Detach();

	DiffBatch Diff(Frontiers a, Frontiers b);

	List<string> ExportJsonInIdSpan(IdSpan idSpan);

	string ExportJsonUpdates(VersionVector startVv, VersionVector endVv);

	string ExportJsonUpdatesWithoutPeerCompression(VersionVector startVv, VersionVector endVv);

	byte[] ExportShallowSnapshot(Frontiers frontiers);

	byte[] ExportSnapshot();

	byte[] ExportSnapshotAt(Frontiers frontiers);

	byte[] ExportStateOnly(Frontiers? frontiers);

	byte[] ExportUpdates(VersionVector vv);

	byte[] ExportUpdatesInRange(List<IdSpan> spans);

	VersionVectorDiff FindIdSpansBetween(Frontiers from, Frontiers to);

	LoroDoc Fork();

	LoroDoc ForkAt(Frontiers frontiers);

	void FreeDiffCalculator();

	void FreeHistoryCache();

	VersionVector? FrontiersToVv(Frontiers frontiers);

	ValueOrContainer? GetByPath(List<Index> path);

	ValueOrContainer? GetByStrPath(string path);

	ChangeMeta? GetChange(Id id);

	List<ContainerId> GetChangedContainersIn(Id id, uint len);

	ValueOrContainer? GetContainer(ContainerId id);

	LoroCounter GetCounter(ContainerIdLike id);

	PosQueryResult GetCursorPos(Cursor cursor);

	LoroValue GetDeepValue();

	LoroValue GetDeepValueWithId();

	LoroList GetList(ContainerIdLike id);

	LoroMap GetMap(ContainerIdLike id);

	LoroMovableList GetMovableList(ContainerIdLike id);

	List<ContainerPath>? GetPathToContainer(ContainerId id);

	uint GetPendingTxnLen();

	LoroText GetText(ContainerIdLike id);

	LoroTree GetTree(ContainerIdLike id);

	LoroValue GetValue();

	bool HasContainer(ContainerId id);

	bool HasHistoryCache();

	ImportStatus Import(byte[] bytes);

	ImportStatus ImportBatch(List<byte[]> bytes);

	ImportStatus ImportJsonUpdates(string json);

	ImportStatus ImportWith(byte[] bytes, string origin);

	bool IsDetached();

	bool IsShallow();

	List<ValueOrContainer> Jsonpath(string path);

	ulong LenChanges();

	ulong LenOps();

	FrontiersOrId MinimizeFrontiers(Frontiers frontiers);

	Frontiers OplogFrontiers();

	VersionVector OplogVv();

	ulong PeerId();

	string RedactJsonUpdates(string json, VersionRange versionRange);

	void RevertTo(Frontiers version);

	void SetChangeMergeInterval(long interval);

	void SetHideEmptyRootContainers(bool hide);

	void SetNextCommitMessage(string msg);

	void SetNextCommitOptions(CommitOptions options);

	void SetNextCommitOrigin(string origin);

	void SetNextCommitTimestamp(long timestamp);

	void SetPeerId(ulong peer);

	void SetRecordTimestamp(bool record);

	VersionVector ShallowSinceVv();

	Frontiers StateFrontiers();

	VersionVector StateVv();

	Subscription Subscribe(ContainerId containerId, Subscriber subscriber);

	Subscription SubscribeFirstCommitFromPeer(FirstCommitFromPeerCallback callback);

	Subscription SubscribeJsonpath(string path, JsonPathSubscriber callback);

	Subscription SubscribeLocalUpdate(LocalUpdateCallback callback);

	Subscription SubscribePreCommit(PreCommitCallback callback);

	Subscription SubscribeRoot(Subscriber subscriber);

	void TravelChangeAncestors(List<Id> ids, ChangeAncestorsTraveler f);

	Frontiers VvToFrontiers(VersionVector vv);
}
