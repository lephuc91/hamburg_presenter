using System.IO;
using System.Reflection;

namespace Pro.Common.DataStore;

public class EmbeddedResourceReader : IEmbeddedResourceReader
{
	public Stream? Read(Assembly assembly, string resourceName)
	{
		return assembly.GetManifestResourceStream(resourceName);
	}
}
