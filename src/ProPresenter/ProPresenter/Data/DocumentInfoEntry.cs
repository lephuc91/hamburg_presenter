using System;

namespace ProPresenter.Data;

public readonly record struct DocumentInfoEntry(Guid Id, string? Kind, string? FileName, bool SentToCore, byte[]? LastSentVersionVector, byte[] CurrentVersionVector);
