using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Pro.SerializationInterop.RVProtoData;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class ProNetworkConfigurationMessage : IMessage<ProNetworkConfigurationMessage>, IMessage, IEquatable<ProNetworkConfigurationMessage>, IDeepCloneable<ProNetworkConfigurationMessage>
{
	public enum MessageOneofCase
	{
		None,
		Configuration,
		RestartNetwork,
		Shutdown
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static class Types
	{
		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class RestartNetwork : IMessage<RestartNetwork>, IMessage, IEquatable<RestartNetwork>, IDeepCloneable<RestartNetwork>
		{
			private static readonly MessageParser<RestartNetwork> _parser = new MessageParser<RestartNetwork>(() => new RestartNetwork());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<RestartNetwork> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ProNetworkConfigurationMessage.Descriptor.NestedTypes[0];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RestartNetwork()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RestartNetwork(RestartNetwork other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public RestartNetwork Clone()
			{
				return new RestartNetwork(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as RestartNetwork);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(RestartNetwork other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				return object.Equals(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override int GetHashCode()
			{
				int num = 1;
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
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(RestartNetwork other)
			{
				if (other != null)
				{
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
					_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				}
			}
		}

		[DebuggerDisplay("{ToString(),nq}")]
		public sealed class Shutdown : IMessage<Shutdown>, IMessage, IEquatable<Shutdown>, IDeepCloneable<Shutdown>
		{
			private static readonly MessageParser<Shutdown> _parser = new MessageParser<Shutdown>(() => new Shutdown());

			private UnknownFieldSet _unknownFields;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageParser<Shutdown> Parser => _parser;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public static MessageDescriptor Descriptor => ProNetworkConfigurationMessage.Descriptor.NestedTypes[1];

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			MessageDescriptor IMessage.Descriptor => Descriptor;

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Shutdown()
			{
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Shutdown(Shutdown other)
				: this()
			{
				_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public Shutdown Clone()
			{
				return new Shutdown(this);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override bool Equals(object other)
			{
				return Equals(other as Shutdown);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public bool Equals(Shutdown other)
			{
				if (other == null)
				{
					return false;
				}
				if (other == this)
				{
					return true;
				}
				return object.Equals(_unknownFields, other._unknownFields);
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public override int GetHashCode()
			{
				int num = 1;
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
				if (_unknownFields != null)
				{
					num += _unknownFields.CalculateSize();
				}
				return num;
			}

			[DebuggerNonUserCode]
			[GeneratedCode("protoc", null)]
			public void MergeFrom(Shutdown other)
			{
				if (other != null)
				{
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
					_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
				}
			}
		}
	}

	private static readonly MessageParser<ProNetworkConfigurationMessage> _parser = new MessageParser<ProNetworkConfigurationMessage>(() => new ProNetworkConfigurationMessage());

	private UnknownFieldSet _unknownFields;

	public const int ConfigurationFieldNumber = 1;

	public const int RestartNetworkFieldNumber = 2;

	public const int ShutdownFieldNumber = 3;

	private object message_;

	private MessageOneofCase messageCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<ProNetworkConfigurationMessage> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => ProApiReflection.Descriptor.MessageTypes[4];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProApiNetworkConfiguration Configuration
	{
		get
		{
			if (messageCase_ != MessageOneofCase.Configuration)
			{
				return null;
			}
			return (ProApiNetworkConfiguration)message_;
		}
		set
		{
			message_ = value;
			messageCase_ = ((value != null) ? MessageOneofCase.Configuration : MessageOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.RestartNetwork RestartNetwork
	{
		get
		{
			if (messageCase_ != MessageOneofCase.RestartNetwork)
			{
				return null;
			}
			return (Types.RestartNetwork)message_;
		}
		set
		{
			message_ = value;
			messageCase_ = ((value != null) ? MessageOneofCase.RestartNetwork : MessageOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public Types.Shutdown Shutdown
	{
		get
		{
			if (messageCase_ != MessageOneofCase.Shutdown)
			{
				return null;
			}
			return (Types.Shutdown)message_;
		}
		set
		{
			message_ = value;
			messageCase_ = ((value != null) ? MessageOneofCase.Shutdown : MessageOneofCase.None);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public MessageOneofCase MessageCase => messageCase_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProNetworkConfigurationMessage()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProNetworkConfigurationMessage(ProNetworkConfigurationMessage other)
		: this()
	{
		switch (other.MessageCase)
		{
		case MessageOneofCase.Configuration:
			Configuration = other.Configuration.Clone();
			break;
		case MessageOneofCase.RestartNetwork:
			RestartNetwork = other.RestartNetwork.Clone();
			break;
		case MessageOneofCase.Shutdown:
			Shutdown = other.Shutdown.Clone();
			break;
		}
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ProNetworkConfigurationMessage Clone()
	{
		return new ProNetworkConfigurationMessage(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void ClearMessage()
	{
		messageCase_ = MessageOneofCase.None;
		message_ = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as ProNetworkConfigurationMessage);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(ProNetworkConfigurationMessage other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Configuration, other.Configuration))
		{
			return false;
		}
		if (!object.Equals(RestartNetwork, other.RestartNetwork))
		{
			return false;
		}
		if (!object.Equals(Shutdown, other.Shutdown))
		{
			return false;
		}
		if (MessageCase != other.MessageCase)
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
		if (messageCase_ == MessageOneofCase.Configuration)
		{
			num ^= Configuration.GetHashCode();
		}
		if (messageCase_ == MessageOneofCase.RestartNetwork)
		{
			num ^= RestartNetwork.GetHashCode();
		}
		if (messageCase_ == MessageOneofCase.Shutdown)
		{
			num ^= Shutdown.GetHashCode();
		}
		num ^= (int)messageCase_;
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
		if (messageCase_ == MessageOneofCase.Configuration)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Configuration);
		}
		if (messageCase_ == MessageOneofCase.RestartNetwork)
		{
			output.WriteRawTag(18);
			output.WriteMessage(RestartNetwork);
		}
		if (messageCase_ == MessageOneofCase.Shutdown)
		{
			output.WriteRawTag(26);
			output.WriteMessage(Shutdown);
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
		if (messageCase_ == MessageOneofCase.Configuration)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Configuration);
		}
		if (messageCase_ == MessageOneofCase.RestartNetwork)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(RestartNetwork);
		}
		if (messageCase_ == MessageOneofCase.Shutdown)
		{
			num += 1 + CodedOutputStream.ComputeMessageSize(Shutdown);
		}
		if (_unknownFields != null)
		{
			num += _unknownFields.CalculateSize();
		}
		return num;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(ProNetworkConfigurationMessage other)
	{
		if (other == null)
		{
			return;
		}
		switch (other.MessageCase)
		{
		case MessageOneofCase.Configuration:
			if (Configuration == null)
			{
				Configuration = new ProApiNetworkConfiguration();
			}
			Configuration.MergeFrom(other.Configuration);
			break;
		case MessageOneofCase.RestartNetwork:
			if (RestartNetwork == null)
			{
				RestartNetwork = new Types.RestartNetwork();
			}
			RestartNetwork.MergeFrom(other.RestartNetwork);
			break;
		case MessageOneofCase.Shutdown:
			if (Shutdown == null)
			{
				Shutdown = new Types.Shutdown();
			}
			Shutdown.MergeFrom(other.Shutdown);
			break;
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
			{
				ProApiNetworkConfiguration proApiNetworkConfiguration = new ProApiNetworkConfiguration();
				if (messageCase_ == MessageOneofCase.Configuration)
				{
					proApiNetworkConfiguration.MergeFrom(Configuration);
				}
				input.ReadMessage(proApiNetworkConfiguration);
				Configuration = proApiNetworkConfiguration;
				break;
			}
			case 18u:
			{
				Types.RestartNetwork restartNetwork = new Types.RestartNetwork();
				if (messageCase_ == MessageOneofCase.RestartNetwork)
				{
					restartNetwork.MergeFrom(RestartNetwork);
				}
				input.ReadMessage(restartNetwork);
				RestartNetwork = restartNetwork;
				break;
			}
			case 26u:
			{
				Types.Shutdown shutdown = new Types.Shutdown();
				if (messageCase_ == MessageOneofCase.Shutdown)
				{
					shutdown.MergeFrom(Shutdown);
				}
				input.ReadMessage(shutdown);
				Shutdown = shutdown;
				break;
			}
			}
		}
	}
}
