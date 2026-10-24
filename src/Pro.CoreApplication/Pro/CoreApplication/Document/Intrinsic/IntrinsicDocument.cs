using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Google.Protobuf;
using Pro.SerializationInterop.RVProtoData.Service.Document;

namespace Pro.CoreApplication.Document.Intrinsic;

public abstract record IntrinsicDocument(byte[] Data, Guid Id) : IReadyDocument, IDocument
{
	private readonly Pro.SerializationInterop.RVProtoData.Service.Document.Intrinsic.Types.Kind _kind;

	protected IntrinsicDocument(Pro.SerializationInterop.RVProtoData.Service.Document.Intrinsic.Types.Kind kind, byte[] data, Guid id)
		: this(data, id)
	{
		_kind = kind;
	}

	public void SerializeTo(DocumentSet documentSet)
	{
		Pro.SerializationInterop.RVProtoData.Service.Document.Intrinsic item = new Pro.SerializationInterop.RVProtoData.Service.Document.Intrinsic
		{
			Uuid = Id.ToString(),
			Kind = _kind,
			Body = ByteString.CopyFrom(Data)
		};
		documentSet.Intrinsics.Add(item);
	}

	public virtual bool Equals(IntrinsicDocument? other)
	{
		if ((object)other != null && Id == other.Id && _kind == other._kind)
		{
			return Data.SequenceEqual(other.Data);
		}
		return false;
	}

	public override int GetHashCode()
	{
		HashCode hashCode = default(HashCode);
		hashCode.Add(Id);
		hashCode.Add(_kind);
		byte[] data = Data;
		foreach (byte value in data)
		{
			hashCode.Add(value);
		}
		return hashCode.ToHashCode();
	}

	[CompilerGenerated]
	protected virtual bool PrintMembers(StringBuilder builder)
	{
		RuntimeHelpers.EnsureSufficientExecutionStack();
		builder.Append("Data = ");
		builder.Append(Data);
		builder.Append(", Id = ");
		builder.Append(Id.ToString());
		return true;
	}
}
