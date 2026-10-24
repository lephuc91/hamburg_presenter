using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.Controller.NetworkAPI;

public class LinkRequestFactory : ILinkRequestFactory
{
	public ILinkRequest? Create(ProLink.Types.HandlerIn protoHandlerIn)
	{
		return protoHandlerIn.RequestCase switch
		{
			ProLink.Types.HandlerIn.RequestOneofCase.GroupName => new GroupNameRequest(), 
			ProLink.Types.HandlerIn.RequestOneofCase.GroupDefinitionRequest => new GroupDefinitionRequest(), 
			ProLink.Types.HandlerIn.RequestOneofCase.GroupJoinConfirmation => new GroupJoinConfirmationRequest(protoHandlerIn.GroupJoinConfirmation.Name), 
			ProLink.Types.HandlerIn.RequestOneofCase.GroupJoinPassword => new GroupJoinPasswordRequest(protoHandlerIn.GroupJoinPassword.Name), 
			ProLink.Types.HandlerIn.RequestOneofCase.AddConnectionResult => GetAddConnectionResult(protoHandlerIn.AddConnectionResult), 
			ProLink.Types.HandlerIn.RequestOneofCase.GroupUpdate => new GroupUpdateRequest(protoHandlerIn.GroupUpdate), 
			ProLink.Types.HandlerIn.RequestOneofCase.MemberStatusChange => new MemberStatusChangeRequest(protoHandlerIn.MemberStatusChange.Members), 
			ProLink.Types.HandlerIn.RequestOneofCase.PropresenterInfo => new ProPresenterInfoRequest(), 
			ProLink.Types.HandlerIn.RequestOneofCase.ServerState => new ServerStateRequest(protoHandlerIn.ServerState), 
			ProLink.Types.HandlerIn.RequestOneofCase.ConfigurationRequest => new ConfigurationRequest(), 
			ProLink.Types.HandlerIn.RequestOneofCase.ZeroconfigNetworkEnvironmentChange => new NetworkEnvironmentRequest(protoHandlerIn.ZeroconfigNetworkEnvironmentChange), 
			_ => null, 
		};
	}

	private static ILinkRequest? GetAddConnectionResult(ProLink.Types.HandlerIn.Types.AddConnectionResult result)
	{
		return result.ResultCase switch
		{
			ProLink.Types.HandlerIn.Types.AddConnectionResult.ResultOneofCase.Success => success(result), 
			ProLink.Types.HandlerIn.Types.AddConnectionResult.ResultOneofCase.Failure => failure(result), 
			_ => null, 
		};
		static AddConnectionFailure failure(ProLink.Types.HandlerIn.Types.AddConnectionResult result)
		{
			ProLink.Types.HandlerIn.Types.AddConnectionResult.Types.Failure failure = result.Failure;
			return failure.ReasonCase switch
			{
				ProLink.Types.HandlerIn.Types.AddConnectionResult.Types.Failure.ReasonOneofCase.Unexpected => new AddConnectionFailure(FailureResultType.Unexpected), 
				ProLink.Types.HandlerIn.Types.AddConnectionResult.Types.Failure.ReasonOneofCase.Declined => new AddConnectionFailure(FailureResultType.Declined), 
				ProLink.Types.HandlerIn.Types.AddConnectionResult.Types.Failure.ReasonOneofCase.Timeout => new AddConnectionFailure(FailureResultType.Timeout), 
				ProLink.Types.HandlerIn.Types.AddConnectionResult.Types.Failure.ReasonOneofCase.LinkDisabled => new AddConnectionFailure(FailureResultType.LinkDisabled), 
				ProLink.Types.HandlerIn.Types.AddConnectionResult.Types.Failure.ReasonOneofCase.InOtherGroup => new AddConnectionFailure(FailureResultType.InOtherGroup, failure.InOtherGroup.MemberName, failure.InOtherGroup.GroupName), 
				ProLink.Types.HandlerIn.Types.AddConnectionResult.Types.Failure.ReasonOneofCase.InvalidIpAddress => new AddConnectionFailure(FailureResultType.InvalidIpAddress), 
				ProLink.Types.HandlerIn.Types.AddConnectionResult.Types.Failure.ReasonOneofCase.AlreadyInGroup => new AddConnectionFailure(FailureResultType.AlreadyInGroup, failure.AlreadyInGroup.MemberName, failure.AlreadyInGroup.GroupName), 
				ProLink.Types.HandlerIn.Types.AddConnectionResult.Types.Failure.ReasonOneofCase.CouldNotAdd => new AddConnectionFailure(FailureResultType.CouldNotAdd, failure.AlreadyInGroup.MemberName), 
				ProLink.Types.HandlerIn.Types.AddConnectionResult.Types.Failure.ReasonOneofCase.CouldNotJoin => new AddConnectionFailure(FailureResultType.CouldNotJoin, "", failure.CouldNotJoin.GroupName), 
				_ => new AddConnectionFailure(FailureResultType.Unexpected), 
			};
		}
		static AddConnectionSuccess success(ProLink.Types.HandlerIn.Types.AddConnectionResult result)
		{
			return new AddConnectionSuccess(result.Success.NewGroupDefinition);
		}
	}
}
