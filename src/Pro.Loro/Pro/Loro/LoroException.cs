namespace Pro.Loro;

public class LoroException : UniffiException
{
	public class UnmatchedContext : LoroException
	{
		public UnmatchedContext(string message)
			: base(message)
		{
		}
	}

	public class DecodeVersionVectorException : LoroException
	{
		public DecodeVersionVectorException(string message)
			: base(message)
		{
		}
	}

	public class DecodeException : LoroException
	{
		public DecodeException(string message)
			: base(message)
		{
		}
	}

	public class DecodeDataCorruptionException : LoroException
	{
		public DecodeDataCorruptionException(string message)
			: base(message)
		{
		}
	}

	public class DecodeChecksumMismatchException : LoroException
	{
		public DecodeChecksumMismatchException(string message)
			: base(message)
		{
		}
	}

	public class IncompatibleFutureEncodingException : LoroException
	{
		public IncompatibleFutureEncodingException(string message)
			: base(message)
		{
		}
	}

	public class JsException : LoroException
	{
		public JsException(string message)
			: base(message)
		{
		}
	}

	public class LockException : LoroException
	{
		public LockException(string message)
			: base(message)
		{
		}
	}

	public class DuplicatedTransactionException : LoroException
	{
		public DuplicatedTransactionException(string message)
			: base(message)
		{
		}
	}

	public class NotFoundException : LoroException
	{
		public NotFoundException(string message)
			: base(message)
		{
		}
	}

	public class TransactionException : LoroException
	{
		public TransactionException(string message)
			: base(message)
		{
		}
	}

	public class OutOfBound : LoroException
	{
		public OutOfBound(string message)
			: base(message)
		{
		}
	}

	public class UsedOpId : LoroException
	{
		public UsedOpId(string message)
			: base(message)
		{
		}
	}

	public class TreeException : LoroException
	{
		public TreeException(string message)
			: base(message)
		{
		}
	}

	public class ArgErr : LoroException
	{
		public ArgErr(string message)
			: base(message)
		{
		}
	}

	public class AutoCommitNotStarted : LoroException
	{
		public AutoCommitNotStarted(string message)
			: base(message)
		{
		}
	}

	public class StyleConfigMissing : LoroException
	{
		public StyleConfigMissing(string message)
			: base(message)
		{
		}
	}

	public class Unknown : LoroException
	{
		public Unknown(string message)
			: base(message)
		{
		}
	}

	public class FrontiersNotFound : LoroException
	{
		public FrontiersNotFound(string message)
			: base(message)
		{
		}
	}

	public class ImportWhenInTxn : LoroException
	{
		public ImportWhenInTxn(string message)
			: base(message)
		{
		}
	}

	public class MisuseDetachedContainer : LoroException
	{
		public MisuseDetachedContainer(string message)
			: base(message)
		{
		}
	}

	public class NotImplemented : LoroException
	{
		public NotImplemented(string message)
			: base(message)
		{
		}
	}

	public class ReattachAttachedContainer : LoroException
	{
		public ReattachAttachedContainer(string message)
			: base(message)
		{
		}
	}

	public class EditWhenDetached : LoroException
	{
		public EditWhenDetached(string message)
			: base(message)
		{
		}
	}

	public class UndoInvalidIdSpan : LoroException
	{
		public UndoInvalidIdSpan(string message)
			: base(message)
		{
		}
	}

	public class UndoWithDifferentPeerId : LoroException
	{
		public UndoWithDifferentPeerId(string message)
			: base(message)
		{
		}
	}

	public class InvalidJsonSchema : LoroException
	{
		public InvalidJsonSchema(string message)
			: base(message)
		{
		}
	}

	public class Utf8InUnicodeCodePoint : LoroException
	{
		public Utf8InUnicodeCodePoint(string message)
			: base(message)
		{
		}
	}

	public class Utf16InUnicodeCodePoint : LoroException
	{
		public Utf16InUnicodeCodePoint(string message)
			: base(message)
		{
		}
	}

	public class EndIndexLessThanStartIndex : LoroException
	{
		public EndIndexLessThanStartIndex(string message)
			: base(message)
		{
		}
	}

	public class InvalidRootContainerName : LoroException
	{
		public InvalidRootContainerName(string message)
			: base(message)
		{
		}
	}

	public class ImportUpdatesThatDependsOnOutdatedVersion : LoroException
	{
		public ImportUpdatesThatDependsOnOutdatedVersion(string message)
			: base(message)
		{
		}
	}

	public class ImportUnsupportedEncodingMode : LoroException
	{
		public ImportUnsupportedEncodingMode(string message)
			: base(message)
		{
		}
	}

	public class SwitchToVersionBeforeShallowRoot : LoroException
	{
		public SwitchToVersionBeforeShallowRoot(string message)
			: base(message)
		{
		}
	}

	public class ContainerDeleted : LoroException
	{
		public ContainerDeleted(string message)
			: base(message)
		{
		}
	}

	public class ConcurrentOpsWithSamePeerId : LoroException
	{
		public ConcurrentOpsWithSamePeerId(string message)
			: base(message)
		{
		}
	}

	public class InvalidPeerId : LoroException
	{
		public InvalidPeerId(string message)
			: base(message)
		{
		}
	}

	public class ContainersNotFound : LoroException
	{
		public ContainersNotFound(string message)
			: base(message)
		{
		}
	}

	public class UndoGroupAlreadyStarted : LoroException
	{
		public UndoGroupAlreadyStarted(string message)
			: base(message)
		{
		}
	}

	private LoroException(string message)
		: base(message)
	{
	}
}
