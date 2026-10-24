using System.Threading.Tasks;

namespace Pro.Common.FileSystem;

public interface IFileUtility
{
	Task<bool> MoveToRecycleBin(string filePath);

	Task<bool> MoveToFolder(string filePath, string targetFolder);
}
