namespace Pro.Loro;

public interface IUndoManager
{
	void AddExcludeOriginPrefix(string prefix);

	bool CanRedo();

	bool CanUndo();

	void GroupEnd();

	void GroupStart();

	ulong Peer();

	void RecordNewCheckpoint();

	bool Redo();

	uint RedoCount();

	void SetMaxUndoSteps(uint size);

	void SetMergeInterval(long interval);

	void SetOnPop(OnPop? onPop);

	void SetOnPush(OnPush? onPush);

	UndoItemMeta? TopRedoMeta();

	LoroValue? TopRedoValue();

	UndoItemMeta? TopUndoMeta();

	LoroValue? TopUndoValue();

	bool Undo();

	uint UndoCount();
}
