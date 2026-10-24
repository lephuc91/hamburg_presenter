using System.Threading.Tasks;

namespace ProPresenter.DO.CloudOnboarding;

public interface IMediaFileProvider
{
	Task<long> GetUnmanagedMediaBytesAsync();

	bool HasUnmanagedMedia();
}
