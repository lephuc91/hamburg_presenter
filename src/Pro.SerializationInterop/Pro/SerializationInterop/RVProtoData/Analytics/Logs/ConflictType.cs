using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData.Analytics.Logs;

public enum ConflictType
{
	[OriginalName("DUPLICATE_ID")]
	DuplicateId,
	[OriginalName("DUPLICATE_NAME")]
	DuplicateName,
	[OriginalName("DUPLICATE_PATH")]
	DuplicatePath,
	[OriginalName("DOCUMENT_NOT_FOUND")]
	DocumentNotFound,
	[OriginalName("DOCUMENT_ALREADY_DELETED")]
	DocumentAlreadyDeleted,
	[OriginalName("CONCURRENT_MODIFICATION")]
	ConcurrentModification
}
