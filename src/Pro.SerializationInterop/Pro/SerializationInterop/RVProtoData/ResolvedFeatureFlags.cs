using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ResolvedFeatureFlags : IMessage<ResolvedFeatureFlags>, IMessage, IEquatable<ResolvedFeatureFlags>, IDeepCloneable<ResolvedFeatureFlags>
{
	private static readonly MessageParser<ResolvedFeatureFlags> _parser = new MessageParser<ResolvedFeatureFlags>(() => new ResolvedFeatureFlags());

	private UnknownFieldSet _unknownFields;

	public const int ContentStoreStagingEnabledFieldNumber = 1;

	private bool contentStoreStagingEnabled_;

	public const int StagingApiEndpointEnabledFieldNumber = 8;

	private bool stagingApiEndpointEnabled_;

	public const int ProContentStagingEnabledFieldNumber = 10;

	private bool proContentStagingEnabled_;

	public const int CoreNetworkapiPlaylistFieldNumber = 11;

	private bool coreNetworkapiPlaylist_;

	public const int CoreNetworkapiPresentationFieldNumber = 12;

	private bool coreNetworkapiPresentation_;

	public const int CoreClientSyncFieldNumber = 15;

	private bool coreClientSync_;

	public const int HdrRenderingEnabledFieldNumber = 17;

	private bool hdrRenderingEnabled_;

	public const int ServerDrivenFeatureFlagsFieldNumber = 18;

	private bool serverDrivenFeatureFlags_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ResolvedFeatureFlags> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProCoreFeatureFlagsReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool ContentStoreStagingEnabled
	{
		get
		{
			return contentStoreStagingEnabled_;
		}
		set
		{
			contentStoreStagingEnabled_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool StagingApiEndpointEnabled
	{
		get
		{
			return stagingApiEndpointEnabled_;
		}
		set
		{
			stagingApiEndpointEnabled_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool ProContentStagingEnabled
	{
		get
		{
			return proContentStagingEnabled_;
		}
		set
		{
			proContentStagingEnabled_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool CoreNetworkapiPlaylist
	{
		get
		{
			return coreNetworkapiPlaylist_;
		}
		set
		{
			coreNetworkapiPlaylist_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool CoreNetworkapiPresentation
	{
		get
		{
			return coreNetworkapiPresentation_;
		}
		set
		{
			coreNetworkapiPresentation_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool CoreClientSync
	{
		get
		{
			return coreClientSync_;
		}
		set
		{
			coreClientSync_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HdrRenderingEnabled
	{
		get
		{
			return hdrRenderingEnabled_;
		}
		set
		{
			hdrRenderingEnabled_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool ServerDrivenFeatureFlags
	{
		get
		{
			return serverDrivenFeatureFlags_;
		}
		set
		{
			serverDrivenFeatureFlags_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResolvedFeatureFlags()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResolvedFeatureFlags(ResolvedFeatureFlags other)
		: this()
	{
		contentStoreStagingEnabled_ = other.contentStoreStagingEnabled_;
		stagingApiEndpointEnabled_ = other.stagingApiEndpointEnabled_;
		proContentStagingEnabled_ = other.proContentStagingEnabled_;
		coreNetworkapiPlaylist_ = other.coreNetworkapiPlaylist_;
		coreNetworkapiPresentation_ = other.coreNetworkapiPresentation_;
		coreClientSync_ = other.coreClientSync_;
		hdrRenderingEnabled_ = other.hdrRenderingEnabled_;
		serverDrivenFeatureFlags_ = other.serverDrivenFeatureFlags_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ResolvedFeatureFlags Clone()
	{
		return new ResolvedFeatureFlags(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ResolvedFeatureFlags);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ResolvedFeatureFlags other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (ContentStoreStagingEnabled != other.ContentStoreStagingEnabled)
		{
			return false;
		}
		if (StagingApiEndpointEnabled != other.StagingApiEndpointEnabled)
		{
			return false;
		}
		if (ProContentStagingEnabled != other.ProContentStagingEnabled)
		{
			return false;
		}
		if (CoreNetworkapiPlaylist != other.CoreNetworkapiPlaylist)
		{
			return false;
		}
		if (CoreNetworkapiPresentation != other.CoreNetworkapiPresentation)
		{
			return false;
		}
		if (CoreClientSync != other.CoreClientSync)
		{
			return false;
		}
		if (HdrRenderingEnabled != other.HdrRenderingEnabled)
		{
			return false;
		}
		if (ServerDrivenFeatureFlags != other.ServerDrivenFeatureFlags)
		{
			return false;
		}
		return object.Equals(_unknownFields, other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override int GetHashCode()
	{
		int num = 1;
		if (ContentStoreStagingEnabled)
		{
			num ^= ContentStoreStagingEnabled.GetHashCode();
		}
		if (StagingApiEndpointEnabled)
		{
			num ^= StagingApiEndpointEnabled.GetHashCode();
		}
		if (ProContentStagingEnabled)
		{
			num ^= ProContentStagingEnabled.GetHashCode();
		}
		if (CoreNetworkapiPlaylist)
		{
			num ^= CoreNetworkapiPlaylist.GetHashCode();
		}
		if (CoreNetworkapiPresentation)
		{
			num ^= CoreNetworkapiPresentation.GetHashCode();
		}
		if (CoreClientSync)
		{
			num ^= CoreClientSync.GetHashCode();
		}
		if (HdrRenderingEnabled)
		{
			num ^= HdrRenderingEnabled.GetHashCode();
		}
		if (ServerDrivenFeatureFlags)
		{
			num ^= ServerDrivenFeatureFlags.GetHashCode();
		}
		if (_unknownFields != null)
		{
			num ^= _unknownFields.GetHashCode();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override string ToString()
	{
		return JsonFormatter.ToDiagnosticString(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void WriteTo(CodedOutputStream output)
	{
		if (ContentStoreStagingEnabled)
		{
			output.WriteRawTag(8);
			output.WriteBool(ContentStoreStagingEnabled);
		}
		if (StagingApiEndpointEnabled)
		{
			output.WriteRawTag(64);
			output.WriteBool(StagingApiEndpointEnabled);
		}
		if (ProContentStagingEnabled)
		{
			output.WriteRawTag(80);
			output.WriteBool(ProContentStagingEnabled);
		}
		if (CoreNetworkapiPlaylist)
		{
			output.WriteRawTag(88);
			output.WriteBool(CoreNetworkapiPlaylist);
		}
		if (CoreNetworkapiPresentation)
		{
			output.WriteRawTag(96);
			output.WriteBool(CoreNetworkapiPresentation);
		}
		if (CoreClientSync)
		{
			output.WriteRawTag(120);
			output.WriteBool(CoreClientSync);
		}
		if (HdrRenderingEnabled)
		{
			output.WriteRawTag(136, 1);
			output.WriteBool(HdrRenderingEnabled);
		}
		if (ServerDrivenFeatureFlags)
		{
			output.WriteRawTag(144, 1);
			output.WriteBool(ServerDrivenFeatureFlags);
		}
		if (_unknownFields != null)
		{
			_unknownFields.WriteTo(output);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int CalculateSize()
	{
		int num = 0;
		if (ContentStoreStagingEnabled)
		{
			num += 2;
		}
		if (StagingApiEndpointEnabled)
		{
			num += 2;
		}
		if (ProContentStagingEnabled)
		{
			num += 2;
		}
		if (CoreNetworkapiPlaylist)
		{
			num += 2;
		}
		if (CoreNetworkapiPresentation)
		{
			num += 2;
		}
		if (CoreClientSync)
		{
			num += 2;
		}
		if (HdrRenderingEnabled)
		{
			num += 3;
		}
		if (ServerDrivenFeatureFlags)
		{
			num += 3;
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ResolvedFeatureFlags other)
	{
		if (other != null)
		{
			if (other.ContentStoreStagingEnabled)
			{
				ContentStoreStagingEnabled = other.ContentStoreStagingEnabled;
			}
			if (other.StagingApiEndpointEnabled)
			{
				StagingApiEndpointEnabled = other.StagingApiEndpointEnabled;
			}
			if (other.ProContentStagingEnabled)
			{
				ProContentStagingEnabled = other.ProContentStagingEnabled;
			}
			if (other.CoreNetworkapiPlaylist)
			{
				CoreNetworkapiPlaylist = other.CoreNetworkapiPlaylist;
			}
			if (other.CoreNetworkapiPresentation)
			{
				CoreNetworkapiPresentation = other.CoreNetworkapiPresentation;
			}
			if (other.CoreClientSync)
			{
				CoreClientSync = other.CoreClientSync;
			}
			if (other.HdrRenderingEnabled)
			{
				HdrRenderingEnabled = other.HdrRenderingEnabled;
			}
			if (other.ServerDrivenFeatureFlags)
			{
				ServerDrivenFeatureFlags = other.ServerDrivenFeatureFlags;
			}
			_unknownFields = UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(CodedInputStream input)
	{
		uint num;
		while ((num = input.ReadTag()) != 0 && (num & 7) != 4)
		{
			switch (num)
			{
			default:
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				break;
			case 8u:
				ContentStoreStagingEnabled = input.ReadBool();
				break;
			case 64u:
				StagingApiEndpointEnabled = input.ReadBool();
				break;
			case 80u:
				ProContentStagingEnabled = input.ReadBool();
				break;
			case 88u:
				CoreNetworkapiPlaylist = input.ReadBool();
				break;
			case 96u:
				CoreNetworkapiPresentation = input.ReadBool();
				break;
			case 120u:
				CoreClientSync = input.ReadBool();
				break;
			case 136u:
				HdrRenderingEnabled = input.ReadBool();
				break;
			case 144u:
				ServerDrivenFeatureFlags = input.ReadBool();
				break;
			}
		}
	}
}
