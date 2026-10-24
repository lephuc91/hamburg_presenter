using ProPresenter.DO;

namespace ProPresenter.UI.Validation;

public class ThemeValidationRule : FilenameValidationRule
{
	protected override string TargetDirectory => CommonPaths.Themes;

	protected override string FileExtension => ".proTheme";
}
