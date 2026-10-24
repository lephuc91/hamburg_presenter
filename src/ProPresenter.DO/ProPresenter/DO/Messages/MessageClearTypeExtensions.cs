using System;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Messages;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(MessageClearType), typeof(Pro.SerializationInterop.RVProtoData.Message.Types.ClearType), SourceToDestinationMethodName = "ToProtoMessageClearType", DestinationToSourceMethodName = "ToMessageClearType")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(MessageClearType), typeof(IMessage.Types.ClearType), SourceToDestinationMethodName = "ToEntityClearType", DestinationToSourceMethodName = "ToMessageClearType")]
public static class MessageClearTypeExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Message.Types.ClearType ToProtoMessageClearType(this MessageClearType source)
	{
		return source switch
		{
			MessageClearType.Manual => Pro.SerializationInterop.RVProtoData.Message.Types.ClearType.Manual, 
			MessageClearType.AfterTimers => Pro.SerializationInterop.RVProtoData.Message.Types.ClearType.AfterTimers, 
			MessageClearType.AfterTime => Pro.SerializationInterop.RVProtoData.Message.Types.ClearType.AfterTime, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static MessageClearType ToMessageClearType(this Pro.SerializationInterop.RVProtoData.Message.Types.ClearType source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Message.Types.ClearType.Manual => MessageClearType.Manual, 
			Pro.SerializationInterop.RVProtoData.Message.Types.ClearType.AfterTime => MessageClearType.AfterTime, 
			Pro.SerializationInterop.RVProtoData.Message.Types.ClearType.AfterTimers => MessageClearType.AfterTimers, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static IMessage.Types.ClearType ToEntityClearType(this MessageClearType source)
	{
		return source switch
		{
			MessageClearType.Manual => IMessage.Types.ClearType.Manual, 
			MessageClearType.AfterTimers => IMessage.Types.ClearType.AfterTimers, 
			MessageClearType.AfterTime => IMessage.Types.ClearType.AfterTime, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static MessageClearType ToMessageClearType(this IMessage.Types.ClearType source)
	{
		return source switch
		{
			IMessage.Types.ClearType.Manual => MessageClearType.Manual, 
			IMessage.Types.ClearType.AfterTime => MessageClearType.AfterTime, 
			IMessage.Types.ClearType.AfterTimers => MessageClearType.AfterTimers, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}
}
