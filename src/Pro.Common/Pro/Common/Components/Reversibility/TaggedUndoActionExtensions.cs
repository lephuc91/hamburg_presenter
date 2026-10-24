namespace Pro.Common.Components.Reversibility;

public static class TaggedUndoActionExtensions
{
	public static TaggedUndoAction<T> ToAction<T>(this T tag, bool strictMatching = false)
	{
		return new TaggedUndoAction<T>(tag, strictMatching);
	}
}
