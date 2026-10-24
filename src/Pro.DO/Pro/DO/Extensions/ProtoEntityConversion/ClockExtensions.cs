using System;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Extensions.ProtoEntityConversion;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(IClock.Types.IFormat.Types.DateFormatterStyle), typeof(Clock.Types.Format.Types.DateFormatterStyle), SourceToDestinationMethodName = "ToProto", DestinationToSourceMethodName = "ToEntity")]
public static class ClockExtensions
{
	public static Clock.Types.Format ToProto(this IClock.Types.IFormat format)
	{
		return new Clock.Types.Format
		{
			DateType = format.DateType.Value.ToProto(),
			TimeFormat = format.TimeFormat.Value.ToProto(),
			MilitaryTimeEnabled = format.MilitaryTimeEnabled.Value
		};
	}

	public static IClock.Types.IFormat ToEntity(this Clock.Types.Format proto, IEntityFactory entityFactory)
	{
		IClock.Types.IFormat format = entityFactory.Create<IClock.Types.IFormat>();
		format.DateType.Set(proto.DateType.ToEntity());
		format.TimeFormat.Set(proto.TimeFormat.ToEntity());
		format.MilitaryTimeEnabled.Set(proto.MilitaryTimeEnabled);
		return format;
	}

	public static Clock.Types.Format.Types.DateFormatterStyle ToProto(this IClock.Types.IFormat.Types.DateFormatterStyle source)
	{
		return source switch
		{
			IClock.Types.IFormat.Types.DateFormatterStyle.None => Clock.Types.Format.Types.DateFormatterStyle.None, 
			IClock.Types.IFormat.Types.DateFormatterStyle.Short => Clock.Types.Format.Types.DateFormatterStyle.Short, 
			IClock.Types.IFormat.Types.DateFormatterStyle.Medium => Clock.Types.Format.Types.DateFormatterStyle.Medium, 
			IClock.Types.IFormat.Types.DateFormatterStyle.Long => Clock.Types.Format.Types.DateFormatterStyle.Long, 
			IClock.Types.IFormat.Types.DateFormatterStyle.Full => Clock.Types.Format.Types.DateFormatterStyle.Full, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static IClock.Types.IFormat.Types.DateFormatterStyle ToEntity(this Clock.Types.Format.Types.DateFormatterStyle source)
	{
		return source switch
		{
			Clock.Types.Format.Types.DateFormatterStyle.None => IClock.Types.IFormat.Types.DateFormatterStyle.None, 
			Clock.Types.Format.Types.DateFormatterStyle.Short => IClock.Types.IFormat.Types.DateFormatterStyle.Short, 
			Clock.Types.Format.Types.DateFormatterStyle.Medium => IClock.Types.IFormat.Types.DateFormatterStyle.Medium, 
			Clock.Types.Format.Types.DateFormatterStyle.Long => IClock.Types.IFormat.Types.DateFormatterStyle.Long, 
			Clock.Types.Format.Types.DateFormatterStyle.Full => IClock.Types.IFormat.Types.DateFormatterStyle.Full, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}
}
