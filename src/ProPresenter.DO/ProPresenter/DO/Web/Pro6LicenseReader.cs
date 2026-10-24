using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace ProPresenter.DO.Web;

internal static class Pro6LicenseReader
{
	private static readonly string MapdataFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Renewed Vision\\ProPresenter 6\\Mapdata");

	private static byte[] GetBytes<T>(T value)
	{
		using MemoryStream memoryStream = new MemoryStream();
		new DataContractSerializer(typeof(T)).WriteObject(memoryStream, value);
		return memoryStream.ToArray();
	}

	public static bool TryLoadPro6License([NotNullWhen(true)] out string? name, [NotNullWhen(true)] out string? key)
	{
		name = null;
		key = null;
		try
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(MapdataFile);
			byte[] bytes2 = ProtectedData.Unprotect(optionalEntropy: GetBytes(long.Parse(xmlDocument.SelectSingleNode("//MAPDATA/MAPDATA0")?.InnerText ?? string.Empty)), encryptedData: Convert.FromBase64String(xmlDocument.SelectSingleNode("//MAPDATA/MAPDATA1")?.InnerText ?? string.Empty), scope: DataProtectionScope.LocalMachine);
			XmlDocument xmlDocument2 = new XmlDocument();
			xmlDocument2.LoadXml(Encoding.UTF8.GetString(bytes2));
			name = xmlDocument2.SelectSingleNode("//RVRegistrationDocument/RegistrationInfo/Username")?.InnerText;
			key = xmlDocument2.SelectSingleNode("//RVRegistrationDocument/RegistrationInfo/License")?.InnerText;
			return name != null && key != null;
		}
		catch
		{
			return false;
		}
	}
}
