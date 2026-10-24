namespace ProPresenter.DO.Slide.Custom.Elements.Shadows;

public class DropShadow : ShadowBase
{
	public override ShadowType Type => ShadowType.Drop;

	public override IShadow Clone()
	{
		DropShadow dropShadow = new DropShadow();
		CopyProperties(dropShadow);
		return dropShadow;
	}
}
