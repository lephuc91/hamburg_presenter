using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class FileProperties : IMessage<FileProperties>, IMessage, IEquatable<FileProperties>, IDeepCloneable<FileProperties>
{
	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class RemoteProperties : IMessage<RemoteProperties>, IMessage, IEquatable<RemoteProperties>, IDeepCloneable<RemoteProperties>
		{
			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static class Types
			{
				[DebuggerDisplay("{ToString(),nq}")]
				public sealed class ProContent : IMessage<ProContent>, IMessage, IEquatable<ProContent>, IDeepCloneable<ProContent>
				{
					private static readonly MessageParser<ProContent> _parser = new MessageParser<ProContent>(() => new ProContent());

					private UnknownFieldSet _unknownFields;

					public const int DownloadIdentifierFieldNumber = 1;

					private string downloadIdentifier_ = "";

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageParser<ProContent> Parser => _parser;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public static MessageDescriptor Descriptor => RemoteProperties.Descriptor.NestedTypes[0];

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					MessageDescriptor IMessage.Descriptor => Descriptor;

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public string DownloadIdentifier
					{
						get
						{
							return downloadIdentifier_;
						}
						set
						{
							downloadIdentifier_ = ProtoPreconditions.CheckNotNull(value, "value");
						}
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ProContent()
					{
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ProContent(ProContent other)
						: this()
					{
						downloadIdentifier_ = other.downloadIdentifier_;
						_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public ProContent Clone()
					{
						return new ProContent(this);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public override bool Equals(object other)
					{
						return Equals(other as ProContent);
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public bool Equals(ProContent other)
					{
						if (other == null)
						{
							return false;
						}
						if (other == this)
						{
							return true;
						}
						if (DownloadIdentifier != other.DownloadIdentifier)
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
						if (DownloadIdentifier.Length != 0)
						{
							num ^= DownloadIdentifier.GetHashCode();
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
						if (DownloadIdentifier.Length != 0)
						{
							output.WriteRawTag(10);
							output.WriteString(DownloadIdentifier);
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
						if (DownloadIdentifier.Length != 0)
						{
							num += 1 + CodedOutputStream.ComputeStringSize(DownloadIdentifier);
						}
						if (_unknownFields != null)
						{
							num += _unknownFields.CalculateSize();
						}
						return num;
					}

					[DebuggerNonUserCode]
					[GeneratedCode("protoc", null)]
					public void MergeFrom(ProContent other)
					{
						if (other != null)
						{
							if (other.DownloadIdentifier.Length != 0)
							{
								DownloadIdentifier = other.DownloadIdentifier;
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
							if (num != 10)
							{
								_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
							}
							else
							{
								DownloadIdentifier = input.ReadString();
							}
						}
					}
				}
			}

			private static readonly MessageParser<RemoteProperties> _parser = new MessageParser<RemoteProperties>(() => new RemoteProperties());

			private UnknownFieldSet _unknownFields;

			public const int ProcontentFieldNumber = 1;

			private Types.ProContent procontent_;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<RemoteProperties> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => FileProperties.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Types.ProContent Procontent
			{
				get
				{
					return procontent_;
				}
				set
				{
					procontent_ = value;
				}
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RemoteProperties()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RemoteProperties(RemoteProperties other)
				: this()
			{
				procontent_ = ((other.procontent_ != null) ? other.procontent_.Clone() : null);
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RemoteProperties Clone()
			{
				return new RemoteProperties(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as RemoteProperties);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(RemoteProperties other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				if (!object.Equals(Procontent, other.Procontent))
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
				if (procontent_ != null)
				{
					num ^= Procontent.GetHashCode();
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
				if (procontent_ != null)
				{
					output.WriteRawTag(10);
					output.WriteMessage(Procontent);
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
				if (procontent_ != null)
				{
					num += 1 + CodedOutputStream.ComputeMessageSize(Procontent);
				}
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(RemoteProperties other)
			{
				if (other == null)
				{
					return;
				}
				if (other.procontent_ != null)
				{
					if (procontent_ == null)
					{
						Procontent = new Types.ProContent();
					}
					Procontent.MergeFrom(other.Procontent);
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
					if (num != 10)
					{
						_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
						continue;
					}
					if (procontent_ == null)
					{
						Procontent = new Types.ProContent();
					}
					input.ReadMessage(Procontent);
				}
			}
		}
	}

	private static readonly MessageParser<FileProperties> _parser = new MessageParser<FileProperties>(() => new FileProperties());

	private UnknownFieldSet _unknownFields;

	public const int LocalUrlFieldNumber = 1;

	private URL localUrl_;

	public const int RemotePropertiesFieldNumber = 2;

	private Types.RemoteProperties remoteProperties_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<FileProperties> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => FilePropertiesReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public URL LocalUrl
	{
		get
		{
			return localUrl_;
		}
		set
		{
			localUrl_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.RemoteProperties RemoteProperties
	{
		get
		{
			return remoteProperties_;
		}
		set
		{
			remoteProperties_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public FileProperties()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public FileProperties(FileProperties other)
		: this()
	{
		localUrl_ = ((other.localUrl_ != null) ? other.localUrl_.Clone() : null);
		remoteProperties_ = ((other.remoteProperties_ != null) ? other.remoteProperties_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public FileProperties Clone()
	{
		return new FileProperties(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as FileProperties);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(FileProperties other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(LocalUrl, other.LocalUrl))
		{
			return false;
		}
		if (!object.Equals(RemoteProperties, other.RemoteProperties))
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
		if (localUrl_ != null)
		{
			num ^= LocalUrl.GetHashCode();
		}
		if (remoteProperties_ != null)
		{
			num ^= RemoteProperties.GetHashCode();
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
		if (localUrl_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(LocalUrl);
		}
		if (remoteProperties_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(RemoteProperties);
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
		if (localUrl_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(LocalUrl);
		}
		if (remoteProperties_ != null)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(RemoteProperties);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(FileProperties other)
	{
		if (other == null)
		{
			return;
		}
		if (other.localUrl_ != null)
		{
			if (localUrl_ == null)
			{
				LocalUrl = new URL();
			}
			LocalUrl.MergeFrom(other.LocalUrl);
		}
		if (other.remoteProperties_ != null)
		{
			if (remoteProperties_ == null)
			{
				RemoteProperties = new Types.RemoteProperties();
			}
			RemoteProperties.MergeFrom(other.RemoteProperties);
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
				if (localUrl_ == null)
				{
					LocalUrl = new URL();
				}
				input.ReadMessage(LocalUrl);
				break;
			case 18u:
				if (remoteProperties_ == null)
				{
					RemoteProperties = new Types.RemoteProperties();
				}
				input.ReadMessage(RemoteProperties);
				break;
			}
		}
	}
}
