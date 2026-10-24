namespace ProPresenter.DO.PCO;

public class PCOUpdateInformation
{
	public PCOItem Item { get; }

	public string? FileAttachmentPath { get; }

	public PCOUpdateInformation(PCOItem item, string? contentPath = null)
	{
		Item = item;
		FileAttachmentPath = contentPath;
	}
}
