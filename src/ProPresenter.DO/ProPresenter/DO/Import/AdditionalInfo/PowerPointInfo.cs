namespace ProPresenter.DO.Import.AdditionalInfo;

public record PowerPointInfo(bool UseLegacyPPTImport, bool IgnoreBackgrounds) : IPowerPointInfo;
