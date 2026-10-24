using System.IO;
using System.Xml;

namespace ProPresenter.DO.Bibles.Formats;

internal static class RVMetadataLoader
{
	private const string MetadataFilename = "RVMetadata.xml";

	private const string BaseXPath = "//RVBibleMetdata";

	public static void TryParseMetadata(string biblePath, ref string name, ref string trackingAbbreviation, ref string displayAbbreviation, out string version, out string revision, ref string copyright)
	{
		version = string.Empty;
		revision = string.Empty;
		string path = Path.Combine(biblePath, "RVMetadata.xml");
		if (File.Exists(path))
		{
			XmlDocument xmlDocument = new XmlDocument();
			using FileStream inStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			xmlDocument.Load(inStream);
			name = xmlDocument.DocumentElement?.GetValue("//RVBibleMetdata/name", name) ?? string.Empty;
			trackingAbbreviation = xmlDocument.DocumentElement?.GetValue("//RVBibleMetdata/abbreviation", trackingAbbreviation) ?? string.Empty;
			displayAbbreviation = xmlDocument.DocumentElement?.GetValue("//RVBibleMetdata/displayAbbreviation", displayAbbreviation).ToUpperInvariant() ?? string.Empty;
			version = xmlDocument.DocumentElement?.GetValue("//RVBibleMetdata/version") ?? string.Empty;
			revision = xmlDocument.DocumentElement?.GetValue("//RVBibleMetdata/revision") ?? string.Empty;
			copyright = xmlDocument.DocumentElement?.GetValue("//RVBibleMetdata/license", copyright) ?? string.Empty;
		}
	}
}
