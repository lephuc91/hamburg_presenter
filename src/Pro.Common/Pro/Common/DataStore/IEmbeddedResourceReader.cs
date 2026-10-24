using System.IO;
using System.Reflection;

namespace Pro.Common.DataStore;

public interface IEmbeddedResourceReader
{
	Stream? Read(Assembly assembly, string resourceName);
}
