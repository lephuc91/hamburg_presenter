namespace Pro.Text;

public static class TextDocumentExtensions
{
	public static string ToRTF(this TextDocument document)
	{
		return new TextDocumentWriter().WriteDocument(document);
	}

	public static TextDocument ToTextDocument(this string rtfData)
	{
		return new TextDocumentReader().ReadDocument(rtfData);
	}
}
