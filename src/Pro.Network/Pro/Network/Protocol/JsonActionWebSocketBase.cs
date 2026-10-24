using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pro.Common.Nullability;

namespace Pro.Network.Protocol;

public abstract class JsonActionWebSocketBase<T> : ActionWebSocketBase<T, string, JObject> where T : new()
{
	protected JsonActionWebSocketBase(WebSocketProviderBase provider)
		: base(provider)
	{
	}

	protected override JObject DecodeMessage(string message)
	{
		return JObject.Parse(message);
	}

	protected override string EncodeMessage(JObject data)
	{
		return data.ToString(Formatting.None);
	}

	protected override string ExtractAction(string actionKey, JObject data)
	{
		string? obj = data[actionKey]?.Value<string>();
		obj.ThrowWhenNull("value");
		return obj;
	}

	protected override JObject InjectAction(string actionKey, JObject data, string action)
	{
		data[actionKey] = action;
		return data;
	}
}
