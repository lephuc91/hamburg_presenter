using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Pro.Common.Dispatcher;
using Pro.Common.Logging;
using Pro.Common.Network;
using Pro.Common.SourceGenerator.Attributes;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.NetworkAPI.Receive;
using ProPresenter.Controller.NetworkAPI.Transmit;
using ProPresenter.DO.NetworkLink;
using ProPresenter.DO.Settings;

namespace ProPresenter.Controller.NetworkAPI;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class NetworkLinkService : ObservableObject, INetworkLinkService, INotifyPropertyChanged, IDisposable
{
	private readonly ICommandSender _sender;

	private readonly IServerStateHandler _serverStateHandler;

	private readonly ILinkRequestFactory _requestFactory;

	[Pro.Common.SourceGenerator.Attributes.ActionLink("PluginPath", "SetConfiguration")]
	private readonly IAirCastConfiguration _airCastConfiguration;

	private readonly IUiDispatcher _dispatcher;

	[Pro.Common.SourceGenerator.Attributes.ActionLink("EnableNetwork", "SetConfiguration")]
	[Pro.Common.SourceGenerator.Attributes.ActionLink("NetworkPort", "SetConfiguration")]
	[Pro.Common.SourceGenerator.Attributes.ActionLink("NetworkName", "SetConfiguration")]
	[Pro.Common.SourceGenerator.Attributes.ActionLink("EnableRemoteStageDisplay", "SetConfiguration")]
	[Pro.Common.SourceGenerator.Attributes.ActionLink("RemoteStageDisplayPassword", "SetConfiguration")]
	[Pro.Common.SourceGenerator.Attributes.ActionLink("EnableLink", "SetConfiguration")]
	[Pro.Common.SourceGenerator.Attributes.ActionLink("EnableTcpConnection", "SetConfiguration")]
	[Pro.Common.SourceGenerator.Attributes.ActionLink("TcpConnectionPort", "SetConfiguration")]
	[Pro.Common.SourceGenerator.Attributes.ActionLink("EnableProRemoteV2", "SetConfiguration")]
	[Pro.Common.SourceGenerator.Attributes.ActionLink("ProRemoteV2Password", "SetConfiguration")]
	private readonly INetwork _network;

	private readonly INetworkEnvironment _environment;

	private readonly INetworkChange _networkChange;

	private Func<ILinkRequest?, ILinkResponse?>? _externalRequestHandler;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	private ProPresenter.DO.NetworkLink.Group Group => _network.LinkGroup;

	public IGroupDefinition GroupDefinition => Group;

	public INetworkEnvironment Environment => _environment;

	[Pro.Common.SourceGenerator.Attributes.ActionLink("LocalIPAddress", "SetConfiguration")]
	[Pro.Common.SourceGenerator.Attributes.ActionLink("ConnectedPort", "SetConfiguration")]
	private ServerState ServerState => _serverStateHandler.State;

	[GeneratedRegex("[\\s\\-_]+")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex SafeNameReplaceRegex()
	{
		return _003CRegexGenerator_g_003EFDBB621A7266593264A3784C53E4820C187E0E9870C29266C7FF9E377C635B5DD__SafeNameReplaceRegex_0.Instance;
	}

	[GeneratedRegex("[^A-Za-z0-9\\-]+")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex SafeNameRemoveRegex()
	{
		return _003CRegexGenerator_g_003EFDBB621A7266593264A3784C53E4820C187E0E9870C29266C7FF9E377C635B5DD__SafeNameRemoveRegex_1.Instance;
	}

	public NetworkLinkService(ICommandSender sender, IServerStateHandler serverStateHandler, INetwork network, INetworkEnvironment environment, IUiDispatcher dispatcher, ILinkRequestFactory requestFactory, IAirCastConfiguration airCastConfiguration, INetworkChange networkChange)
	{
		_sender = sender;
		_serverStateHandler = serverStateHandler;
		_network = network;
		_environment = environment;
		_dispatcher = dispatcher;
		_requestFactory = requestFactory;
		_airCastConfiguration = airCastConfiguration;
		_networkChange = networkChange;
		_sender.SetLinkCallback(OnLinkCallback);
		_networkChange.NetworkAvailabilityChanged += OnReconnect;
		AddPropertyLinks();
		SetConfiguration();
	}

	private ProApiOut? OnLinkCallback(ProLink.Types.HandlerIn handlerIn)
	{
		if (handlerIn.RequestCase == ProLink.Types.HandlerIn.RequestOneofCase.LogRequest)
		{
			HandleLogRequest(handlerIn.LogRequest);
			return null;
		}
		ILinkRequest request = _requestFactory.Create(handlerIn);
		try
		{
			ProApiOut proApiOut = _dispatcher.Invoke(() => _externalRequestHandler?.Invoke(request)?.Serialize());
			if (proApiOut == null)
			{
				ProApiOut proApiOut2;
				if (!(request is GroupDefinitionRequest))
				{
					if (!(request is ProPresenterInfoRequest))
					{
						AddConnectionSuccess addConnectionSuccess = request as AddConnectionSuccess;
						if (addConnectionSuccess == null)
						{
							MemberStatusChangeRequest memberStatusChangeRequest = request as MemberStatusChangeRequest;
							if (memberStatusChangeRequest == null)
							{
								GroupUpdateRequest groupUpdateRequest = request as GroupUpdateRequest;
								if (groupUpdateRequest == null)
								{
									ServerStateRequest serverStateRequest = request as ServerStateRequest;
									if (serverStateRequest == null)
									{
										NetworkEnvironmentRequest networkEnvironmentRequest = request as NetworkEnvironmentRequest;
										proApiOut2 = ((networkEnvironmentRequest == null) ? null : NoResponseDispatched(delegate
										{
											_environment.Update(networkEnvironmentRequest.Environment);
										}));
									}
									else
									{
										proApiOut2 = NoResponseDispatched(delegate
										{
											HandleServerStateRequest(serverStateRequest);
										});
									}
								}
								else
								{
									proApiOut2 = NoResponseDispatched(delegate
									{
										Group.Deserialize(groupUpdateRequest.Group);
									});
								}
							}
							else
							{
								proApiOut2 = NoResponseDispatched(delegate
								{
									Group.Deserialize(memberStatusChangeRequest.Members);
								});
							}
						}
						else
						{
							proApiOut2 = NoResponseDispatched(delegate
							{
								Group.Deserialize(addConnectionSuccess.Group);
							});
						}
					}
					else
					{
						proApiOut2 = new OutboundMessageBuilder().Handler().ProPresenterInfo().Build();
					}
				}
				else
				{
					proApiOut2 = new OutboundMessageBuilder().Handler().GroupDefinition(_network.LinkGroup).Build();
				}
				proApiOut = proApiOut2;
			}
			return proApiOut;
		}
		catch (TaskCanceledException)
		{
			return null;
		}
	}

	private ProApiOut? NoResponseDispatched(System.Action action)
	{
		_dispatcher.Invoke(action);
		return null;
	}

	private void HandleServerStateRequest(ServerStateRequest serverStateRequest)
	{
		_serverStateHandler.Handle(serverStateRequest.ServerState);
		if (!string.IsNullOrEmpty(_serverStateHandler.State.LocalIPAddress))
		{
			_network.LocalIPAddress = _serverStateHandler.State.LocalIPAddress;
			_network.NetworkPort = _serverStateHandler.State.ConnectedPort;
		}
	}

	private static void HandleLogRequest(ProLink.Types.HandlerIn.Types.LogRequest logRequest)
	{
		object obj = logRequest.Severity switch
		{
			ProLink.Types.HandlerIn.Types.LogRequest.Types.Severity.Debug => new Action<string, object[]>(Log.Debug), 
			ProLink.Types.HandlerIn.Types.LogRequest.Types.Severity.DebugWarning => new Action<string, object[]>(Log.DebugWarning), 
			ProLink.Types.HandlerIn.Types.LogRequest.Types.Severity.Info => new Action<string, object[]>(Log.Info), 
			ProLink.Types.HandlerIn.Types.LogRequest.Types.Severity.Warning => new Action<string, object[]>(Log.Warning), 
			ProLink.Types.HandlerIn.Types.LogRequest.Types.Severity.Error => new Action<string, object[]>(Log.Error), 
			ProLink.Types.HandlerIn.Types.LogRequest.Types.Severity.FatalError => new Action<string, object[]>(Log.FatalError), 
			_ => null, 
		};
		if (obj != null)
		{
			object[] arg = new string[1] { logRequest.Message };
			obj("[INetwork Helper] {0}", arg);
		}
	}

	public void AddConnection(string? ip, int port, string groupName)
	{
		SendCommand(delegate(ProLink.Types.ClientAction a)
		{
			a.AddConnection = new ProLink.Types.ClientAction.Types.AddConnection
			{
				Ip = ip,
				Port = (uint)port,
				GroupName = groupName
			};
		});
	}

	public void RemoveConnection(string ip, int port)
	{
		SendCommand(delegate(ProLink.Types.ClientAction a)
		{
			a.RemoveConnection = new ProLink.Types.ClientAction.Types.RemoveConnection
			{
				Ip = ip,
				Port = (uint)port
			};
		});
	}

	public void Cancel()
	{
		SendCommand(delegate(ProLink.Types.ClientAction a)
		{
			a.CancelAction = new ProLink.Types.ClientAction.Types.CancelAction();
		});
	}

	public void AddRequestHandler(Func<ILinkRequest?, ILinkResponse?> handler)
	{
		if (_externalRequestHandler != null)
		{
			throw new InvalidOperationException("The current implementation does not support multiple request handlers");
		}
		_externalRequestHandler = handler;
	}

	private void SendCommand(Action<ProLink.Types.ClientAction> setter)
	{
		ProLink.Types.ClientAction clientAction = new ProLink.Types.ClientAction();
		setter(clientAction);
		_sender.SendCommand(clientAction);
	}

	private void OnReconnect(object? sender, NetworkAvailabilityEventArgs e)
	{
		if (e.IsAvailable)
		{
			_sender.SendReconnect();
		}
	}

	private void SetConfiguration()
	{
		_sender.SendConfiguration(GetCurrentConfiguration());
	}

	private ProApiNetworkConfiguration GetCurrentConfiguration()
	{
		return new ProApiNetworkConfiguration
		{
			EnableNetwork = _network.EnableNetwork,
			Port = (uint)((_network.NetworkPort == _network.DefaultPort) ? _serverStateHandler.State.ConnectedPort : _network.NetworkPort),
			NetworkName = MakeNetworkNameSafe(_network.NetworkName),
			StageEnable = _network.EnableRemoteStageDisplay,
			StagePassword = _network.RemoteStageDisplayPassword,
			LinkEnable = _network.EnableLink,
			WebResourceRoot = "web/",
			TcpStreamEnable = _network.EnableTcpConnection,
			TcpStreamPort = (uint)((_network.TcpConnectionPort == _network.DefaultPort) ? _serverStateHandler.State.TcpConnectedPort : _network.TcpConnectionPort),
			Airplay = new AirplayConfiguration
			{
				FairplayPath = _airCastConfiguration.PluginPath
			},
			ProremoteWebsocketEnable = _network.EnableProRemoteV2,
			ProremoteWebsocketPassword = _network.ProRemoteV2Password
		};
	}

	private static string MakeNetworkNameSafe(string name)
	{
		if (name == null)
		{
			return string.Empty;
		}
		name = SafeNameReplaceRegex().Replace(name, "-");
		name = SafeNameRemoveRegex().Replace(name, "");
		return name;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		RemovePropertyLinks();
		_networkChange.NetworkAvailabilityChanged -= OnReconnect;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _airCastConfiguration_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "PluginPath")
		{
			SetConfiguration();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _network_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (propertyName == null)
		{
			return;
		}
		switch (propertyName.Length)
		{
		case 11:
			switch (propertyName[7])
			{
			case 'P':
				if (propertyName == "NetworkPort")
				{
					SetConfiguration();
				}
				break;
			case 'N':
				if (propertyName == "NetworkName")
				{
					SetConfiguration();
				}
				break;
			}
			break;
		case 19:
			switch (propertyName[0])
			{
			case 'E':
				if (propertyName == "EnableTcpConnection")
				{
					SetConfiguration();
				}
				break;
			case 'P':
				if (propertyName == "ProRemoteV2Password")
				{
					SetConfiguration();
				}
				break;
			}
			break;
		case 17:
			switch (propertyName[0])
			{
			case 'T':
				if (propertyName == "TcpConnectionPort")
				{
					SetConfiguration();
				}
				break;
			case 'E':
				if (propertyName == "EnableProRemoteV2")
				{
					SetConfiguration();
				}
				break;
			}
			break;
		case 13:
			if (propertyName == "EnableNetwork")
			{
				SetConfiguration();
			}
			break;
		case 24:
			if (propertyName == "EnableRemoteStageDisplay")
			{
				SetConfiguration();
			}
			break;
		case 26:
			if (propertyName == "RemoteStageDisplayPassword")
			{
				SetConfiguration();
			}
			break;
		case 10:
			if (propertyName == "EnableLink")
			{
				SetConfiguration();
			}
			break;
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void ServerState_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (!(propertyName == "LocalIPAddress"))
		{
			if (propertyName == "ConnectedPort")
			{
				SetConfiguration();
			}
		}
		else
		{
			SetConfiguration();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_airCastConfiguration.PropertyChanged += _airCastConfiguration_PropertyChanged;
		_network.PropertyChanged += _network_PropertyChanged;
		ServerState.PropertyChanged += ServerState_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		_airCastConfiguration.PropertyChanged -= _airCastConfiguration_PropertyChanged;
		_network.PropertyChanged -= _network_PropertyChanged;
		ServerState.PropertyChanged -= ServerState_PropertyChanged;
	}
}
