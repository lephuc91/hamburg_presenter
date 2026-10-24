using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace Rv.Data;

public static class CustomOptionsExtensions
{
	public static readonly Extension<MessageOptions, bool> Atomic = new Extension<MessageOptions, bool>(51200, FieldCodec.ForBool(409600u, defaultValue: false));

	public static readonly Extension<FieldOptions, bool> Optional = new Extension<FieldOptions, bool>(51300, FieldCodec.ForBool(410400u, defaultValue: false));

	public static readonly Extension<FieldOptions, bool> Obsolete = new Extension<FieldOptions, bool>(51301, FieldCodec.ForBool(410408u, defaultValue: false));

	public static readonly Extension<FieldOptions, string> MapKeyField = new Extension<FieldOptions, string>(51302, FieldCodec.ForString(410418u, ""));

	public static readonly Extension<OneofOptions, bool> OptionalOneof = new Extension<OneofOptions, bool>(51400, FieldCodec.ForBool(411200u, defaultValue: false));
}
