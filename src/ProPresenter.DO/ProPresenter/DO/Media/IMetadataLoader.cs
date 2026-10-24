using System;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Pro.Common.FileSystem;

namespace ProPresenter.DO.Media;

public interface IMetadataLoader
{
	public interface IResult
	{
	}

	public record SuccessfulResult(MediaMetadata Metadata, BitmapSource? Thumbnail = null) : IResult;

	public record ImportedResult(string ContainerId, Guid MediaReferenceId, string FinalUrl) : IResult;

	public record FailedResult : IResult;

	public record PendingResult : IResult;

	public interface IIdentifiedResult
	{
	}

	public record UuidIdentifiedResult(string? ContainerId, Guid Identifier, IResult Result) : IIdentifiedResult;

	IObservable<IIdentifiedResult> WhenMediaReferenceChanged { get; }

	WatcherReference? StartWatchingMediaFile(string path);

	Task<IResult> LoadMetadataAsync(MediaMetadataRequest request, bool applyTransform = false);
}
