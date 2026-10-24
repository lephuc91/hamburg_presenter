namespace Pro.Text;

public static class SharedTypefaceLibrary
{
	private static readonly TypefaceLibrary _library = new TypefaceLibrary();

	public static TypefaceLibrary Library => _library;
}
