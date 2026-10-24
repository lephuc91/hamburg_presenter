using System;
using System.Text.Json.Serialization;

namespace Pro.Common.Serialization.Enum;

[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
public sealed class JsonStringEnumDefaultValueAttribute : JsonAttribute
{
}
