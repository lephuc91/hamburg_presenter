using System;
using System.Diagnostics.CodeAnalysis;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

namespace Pro.CoreApplication.Media.V2.CoreInteraction;

public sealed record ImportMediaV2(string ContainerId, Guid MediaReferenceId, string TargetUrl, AssetImported.Types.Error? Error)
{
	[MemberNotNullWhen(true, "Error")]
	public bool HasError
	{
		[MemberNotNullWhen(true, "Error")]
		get
		{
			return Error.HasValue;
		}
	}
}
