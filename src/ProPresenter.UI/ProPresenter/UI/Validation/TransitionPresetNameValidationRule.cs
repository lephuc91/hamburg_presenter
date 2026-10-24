using ProPresenter.DO;

namespace ProPresenter.UI.Validation;

public class TransitionPresetNameValidationRule : FilenameValidationRule
{
	protected override string TargetDirectory => CommonPaths.TransitionPresets;

	protected override string FileExtension => ".transitionPreset";
}
