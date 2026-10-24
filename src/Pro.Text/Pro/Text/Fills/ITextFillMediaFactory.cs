namespace Pro.Text.Fills;

public interface ITextFillMediaFactory
{
	ITextFillMedia CreateImageMedia(string containerId);

	ITextFillMedia CreateVideoMedia(string containerId);
}
