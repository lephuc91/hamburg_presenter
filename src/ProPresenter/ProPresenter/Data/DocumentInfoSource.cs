using System;

namespace ProPresenter.Data;

public sealed class DocumentInfoSource
{
	public Guid Id { get; init; }

	public string? Kind { get; init; }

	public string? FileName { get; init; }

	public bool SentToCore { get; init; }

	public byte[]? LastSentVersion { get; init; }

	public byte[] CurrentVersionVector { get; init; } = Array.Empty<byte>();
}
