using System;
using System.Collections.Generic;
using Pro.Common.Nullability;
using ProPresenterCore.ProCore.Interop;

namespace Pro.Network.Protocol;

public abstract class ActionWebSocketBase<T, K, V> : WebSocketBase<T> where T : new() where K : notnull
{
	public class ActionResponse
	{
		public bool InjectAction { get; }

		public V Data { get; }

		public ActionResponse(bool injectAction, V data)
		{
			InjectAction = injectAction;
			Data = data;
		}
	}

	public delegate ActionResponse? ActionHandlerDelegate(V data, T clientInfo);

	private readonly Dictionary<ProNetworkEndpointType, Dictionary<K, ActionHandlerDelegate>> _actionMaps = new Dictionary<ProNetworkEndpointType, Dictionary<K, ActionHandlerDelegate>>();

	protected ActionWebSocketBase(WebSocketProviderBase provider)
		: base(provider)
	{
	}

	protected abstract V DecodeMessage(string message);

	protected abstract string EncodeMessage(V data);

	protected abstract string GetActionKey(ProNetworkEndpointType endpoint);

	protected abstract K ExtractAction(string actionKey, V data);

	protected abstract V InjectAction(string actionKey, V data, K action);

	protected void RegisterAction(ProNetworkEndpointType endpoint, K action, ActionHandlerDelegate handler)
	{
		endpoint.ThrowWhenNull("endpoint");
		if (!_actionMaps.TryGetValue(endpoint, out Dictionary<K, ActionHandlerDelegate> value))
		{
			value = new Dictionary<K, ActionHandlerDelegate>();
			_actionMaps.Add(endpoint, value);
		}
		value[action] = handler;
	}

	protected override string? OnMessageReceived(ProNetworkEndpointType endpoint, string message, T clientInfo)
	{
		try
		{
			if (!_actionMaps.TryGetValue(endpoint, out Dictionary<K, ActionHandlerDelegate> value))
			{
				return null;
			}
			V data = DecodeMessage(message);
			string actionKey = GetActionKey(endpoint);
			K val = ExtractAction(actionKey, data);
			if (!value.TryGetValue(val, out var value2))
			{
				return null;
			}
			ActionResponse actionResponse = value2(data, clientInfo);
			if (actionResponse != null)
			{
				return EncodeMessage(actionResponse.InjectAction ? InjectAction(actionKey, actionResponse.Data, val) : actionResponse.Data);
			}
		}
		catch
		{
		}
		return null;
	}

	protected void BroadcastMessage(ProNetworkEndpointType endpoint, K action, V data, Predicate<T>? predicate = null)
	{
		string actionKey = GetActionKey(endpoint);
		V data2 = InjectAction(actionKey, data, action);
		Broadcast(endpoint, EncodeMessage(data2), predicate);
	}
}
