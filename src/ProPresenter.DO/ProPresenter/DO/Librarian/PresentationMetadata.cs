using System;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Librarian;

public class PresentationMetadata
{
	public Guid ID { get; }

	public PresentationType Type { get; }

	public OutputDestination Destination { get; }

	public string? ActiveArrangementName { get; }

	public DateTime? LastUsed { get; }

	public DateTime LastModified { get; }

	public byte[] CopyrightInfoData { get; }

	public PresentationMetadata(Guid id, PresentationType type, OutputDestination destination, string? activeArrangementName, DateTime? lastUsed, DateTime lastModified, byte[] copyrightInfoData)
	{
		ID = id;
		Type = type;
		Destination = destination;
		ActiveArrangementName = activeArrangementName;
		LastUsed = lastUsed;
		LastModified = lastModified;
		CopyrightInfoData = copyrightInfoData;
	}
}
