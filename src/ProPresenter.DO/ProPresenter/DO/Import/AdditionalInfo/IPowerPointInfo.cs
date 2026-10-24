namespace ProPresenter.DO.Import.AdditionalInfo;

public interface IPowerPointInfo
{
	bool UseLegacyPPTImport { get; }

	bool IgnoreBackgrounds { get; }
}
