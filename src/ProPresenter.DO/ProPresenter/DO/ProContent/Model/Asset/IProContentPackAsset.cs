namespace ProPresenter.DO.ProContent.Model.Asset;

public interface IProContentPackAsset : IProContentDownloadableAsset, IProContentAsset
{
	int LoopCount { get; }

	int ImageCount { get; }

	int CountdownCount { get; }
}
