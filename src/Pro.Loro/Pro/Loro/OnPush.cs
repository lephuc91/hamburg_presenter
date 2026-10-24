namespace Pro.Loro;

public interface OnPush
{
	UndoItemMeta OnPush(UndoOrRedo undoOrRedo, CounterSpan span, DiffEvent? diffEvent);
}
