using System.Collections.Generic;

namespace Pro.Loro;

public interface ILoroTree
{
	List<TreeId>? Children(TreeParentId parent);

	uint? ChildrenNum(TreeParentId parent);

	bool Contains(TreeId target);

	TreeId Create(TreeParentId parent);

	TreeId CreateAt(TreeParentId parent, uint index);

	void Delete(TreeId target);

	void DisableFractionalIndex();

	LoroDoc? Doc();

	void EnableFractionalIndex(byte jitter);

	string? FractionalIndex(TreeId target);

	LoroTree? GetAttached();

	Id? GetLastMoveId(TreeId target);

	LoroMap GetMeta(TreeId target);

	LoroValue GetValue();

	LoroValue GetValueWithMeta();

	ContainerId Id();

	bool IsAttached();

	bool IsDeleted();

	bool IsFractionalIndexEnabled();

	bool IsNodeDeleted(TreeId target);

	void Mov(TreeId target, TreeParentId parent);

	void MovAfter(TreeId target, TreeId after);

	void MovBefore(TreeId target, TreeId before);

	void MovTo(TreeId target, TreeParentId parent, uint to);

	List<TreeId> Nodes();

	TreeParentId Parent(TreeId target);

	List<TreeId> Roots();

	Subscription? Subscribe(Subscriber subscriber);
}
