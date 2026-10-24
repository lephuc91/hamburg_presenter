namespace Pro.Loro;

public interface OnPop
{
	void OnPop(UndoOrRedo undoOrRedo, CounterSpan span, UndoItemMeta undoMeta);
}
