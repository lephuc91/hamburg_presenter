using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Pro.SerializationInterop.RVProtoData.FeatureFlags;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v1;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v2;
using Pro.SerializationInterop.RVProtoData.Service.Document;
using Pro.SerializationInterop.RVProtoData.Service.Workspace;

namespace Pro.SerializationInterop.RVProtoData.Application;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ApplicationStartParams : IMessage<ApplicationStartParams>, IMessage, IEquatable<ApplicationStartParams>, IDeepCloneable<ApplicationStartParams>
{
	private static readonly MessageParser<ApplicationStartParams> _parser = new MessageParser<ApplicationStartParams>(() => new ApplicationStartParams());

	private UnknownFieldSet _unknownFields;

	public const int ApplicationFieldNumber = 1;

	private ApplicationParams application_;

	public const int MediaV1FieldNumber = 2;

	private Pro.SerializationInterop.RVProtoData.MediaManagement.v1.CreationOption mediaV1_;

	public const int MediaFieldNumber = 3;

	private Pro.SerializationInterop.RVProtoData.MediaManagement.v2.CreationOption media_;

	public const int FeatureFlagsFieldNumber = 4;

	private Pro.SerializationInterop.RVProtoData.FeatureFlags.CreationOption featureFlags_;

	public const int RegistrationFieldNumber = 6;

	private RegistrationCreationOption registration_;

	public const int DocumentFieldNumber = 7;

	private Pro.SerializationInterop.RVProtoData.Service.Document.CreationOption document_;

	public const int WorkspaceFieldNumber = 8;

	private Pro.SerializationInterop.RVProtoData.Service.Workspace.CreationOption workspace_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ApplicationStartParams> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ParamsReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ApplicationParams Application
	{
		get
		{
			return application_;
		}
		set
		{
			application_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Pro.SerializationInterop.RVProtoData.MediaManagement.v1.CreationOption MediaV1
	{
		get
		{
			return mediaV1_;
		}
		set
		{
			mediaV1_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Pro.SerializationInterop.RVProtoData.MediaManagement.v2.CreationOption Media
	{
		get
		{
			return media_;
		}
		set
		{
			media_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Pro.SerializationInterop.RVProtoData.FeatureFlags.CreationOption FeatureFlags
	{
		get
		{
			return featureFlags_;
		}
		set
		{
			featureFlags_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RegistrationCreationOption Registration
	{
		get
		{
			return registration_;
		}
		set
		{
			registration_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Pro.SerializationInterop.RVProtoData.Service.Document.CreationOption Document
	{
		get
		{
			return document_;
		}
		set
		{
			document_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Pro.SerializationInterop.RVProtoData.Service.Workspace.CreationOption Workspace
	{
		get
		{
			return workspace_;
		}
		set
		{
			workspace_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ApplicationStartParams()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ApplicationStartParams(ApplicationStartParams other)
		: this()
	{
		application_ = ((other.application_ != null) ? other.application_.Clone() : null);
		mediaV1_ = ((other.mediaV1_ != null) ? other.mediaV1_.Clone() : null);
		media_ = ((other.media_ != null) ? other.media_.Clone() : null);
		featureFlags_ = ((other.featureFlags_ != null) ? other.featureFlags_.Clone() : null);
		registration_ = ((other.registration_ != null) ? other.registration_.Clone() : null);
		document_ = ((other.document_ != null) ? other.document_.Clone() : null);
		workspace_ = ((other.workspace_ != null) ? other.workspace_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ApplicationStartParams Clone()
	{
		return new ApplicationStartParams(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ApplicationStartParams);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ApplicationStartParams other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Application, other.Application))
		{
			return false;
		}
		if (!object.Equals(MediaV1, other.MediaV1))
		{
			return false;
		}
		if (!object.Equals(Media, other.Media))
		{
			return false;
		}
		if (!object.Equals(FeatureFlags, other.FeatureFlags))
		{
			return false;
		}
		if (!object.Equals(Registration, other.Registration))
		{
			return false;
		}
		if (!object.Equals(Document, other.Document))
		{
			return false;
		}
		if (!object.Equals(Workspace, other.Workspace))
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
		if (application_ != null)
		{
			num ^= Application.GetHashCode();
		}
		if (mediaV1_ != null)
		{
			num ^= MediaV1.GetHashCode();
		}
		if (media_ != null)
		{
			num ^= Media.GetHashCode();
		}
		if (featureFlags_ != null)
		{
			num ^= FeatureFlags.GetHashCode();
		}
		if (registration_ != null)
		{
			num ^= Registration.GetHashCode();
		}
		if (document_ != null)
		{
			num ^= Document.GetHashCode();
		}
		if (workspace_ != null)
		{
			num ^= Workspace.GetHashCode();
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
		if (application_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Application);
		}
		if (mediaV1_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(MediaV1);
		}
		if (media_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Media);
		}
		if (featureFlags_ != null)
		{
			output.WriteRawTag(34);
			output.WriteMessage(FeatureFlags);
		}
		if (registration_ != null)
		{
			output.WriteRawTag(50);
			output.WriteMessage(Registration);
		}
		if (document_ != null)
		{
			output.WriteRawTag(58);
			output.WriteMessage(Document);
		}
		if (workspace_ != null)
		{
			output.WriteRawTag(66);
			output.WriteMessage(Workspace);
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
		if (application_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Application);
		}
		if (mediaV1_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(MediaV1);
		}
		if (media_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Media);
		}
		if (featureFlags_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(FeatureFlags);
		}
		if (registration_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Registration);
		}
		if (document_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Document);
		}
		if (workspace_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Workspace);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ApplicationStartParams other)
	{
		if (other == null)
		{
			return;
		}
		if (other.application_ != null)
		{
			if (application_ == null)
			{
				Application = new ApplicationParams();
			}
			Application.MergeFrom(other.Application);
		}
		if (other.mediaV1_ != null)
		{
			if (mediaV1_ == null)
			{
				MediaV1 = new Pro.SerializationInterop.RVProtoData.MediaManagement.v1.CreationOption();
			}
			MediaV1.MergeFrom(other.MediaV1);
		}
		if (other.media_ != null)
		{
			if (media_ == null)
			{
				Media = new Pro.SerializationInterop.RVProtoData.MediaManagement.v2.CreationOption();
			}
			Media.MergeFrom(other.Media);
		}
		if (other.featureFlags_ != null)
		{
			if (featureFlags_ == null)
			{
				FeatureFlags = new Pro.SerializationInterop.RVProtoData.FeatureFlags.CreationOption();
			}
			FeatureFlags.MergeFrom(other.FeatureFlags);
		}
		if (other.registration_ != null)
		{
			if (registration_ == null)
			{
				Registration = new RegistrationCreationOption();
			}
			Registration.MergeFrom(other.Registration);
		}
		if (other.document_ != null)
		{
			if (document_ == null)
			{
				Document = new Pro.SerializationInterop.RVProtoData.Service.Document.CreationOption();
			}
			Document.MergeFrom(other.Document);
		}
		if (other.workspace_ != null)
		{
			if (workspace_ == null)
			{
				Workspace = new Pro.SerializationInterop.RVProtoData.Service.Workspace.CreationOption();
			}
			Workspace.MergeFrom(other.Workspace);
		}
		_unknownFields = UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
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
			case 10u:
				if (application_ == null)
				{
					Application = new ApplicationParams();
				}
				input.ReadMessage(Application);
				break;
			case 18u:
				if (mediaV1_ == null)
				{
					MediaV1 = new Pro.SerializationInterop.RVProtoData.MediaManagement.v1.CreationOption();
				}
				input.ReadMessage(MediaV1);
				break;
			case 26u:
				if (media_ == null)
				{
					Media = new Pro.SerializationInterop.RVProtoData.MediaManagement.v2.CreationOption();
				}
				input.ReadMessage(Media);
				break;
			case 34u:
				if (featureFlags_ == null)
				{
					FeatureFlags = new Pro.SerializationInterop.RVProtoData.FeatureFlags.CreationOption();
				}
				input.ReadMessage(FeatureFlags);
				break;
			case 50u:
				if (registration_ == null)
				{
					Registration = new RegistrationCreationOption();
				}
				input.ReadMessage(Registration);
				break;
			case 58u:
				if (document_ == null)
				{
					Document = new Pro.SerializationInterop.RVProtoData.Service.Document.CreationOption();
				}
				input.ReadMessage(Document);
				break;
			case 66u:
				if (workspace_ == null)
				{
					Workspace = new Pro.SerializationInterop.RVProtoData.Service.Workspace.CreationOption();
				}
				input.ReadMessage(Workspace);
				break;
			}
		}
	}
}
