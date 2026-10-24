using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.DO.Token;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Timer;

namespace ProPresenter.DO.Messages;

public class ClockToken : MessageTokenBase
{
	public override string Content => LocalizedStrings.Get("MESSAGES_WINDOW_TOKEN_CLOCK_title");

	public ClockData ClockData { get; } = new ClockData();

	public override ObjectBinder<MessageTokenBase, IMessage.Types.ITokenValue> BindValue(IUiScheduler scheduler, IEntityFactory entityFactory, IMessage.Types.ITokenValue right)
	{
		IMessage.Types.ITokenValue.Types.ITokenValueType.IClock clock = right.TokenValueType.Value as IMessage.Types.ITokenValue.Types.ITokenValueType.IClock;
		if (clock == null)
		{
			clock = entityFactory.Create<IMessage.Types.ITokenValue.Types.ITokenValueType.IClock>();
			right.TokenValueType.Set(clock);
		}
		ObjectBinder<ClockData, IClock.Types.IFormat> formatBinder = ProPresenter.DO.Timer.ClockData.CreateBinder(ClockData, clock.Value.Format.Value);
		ObjectBinder<MessageTokenBase, IMessage.Types.ITokenValue> objectBinder = base.BindValue(scheduler, entityFactory, right);
		objectBinder.DoOnInitializeRightFromLeft(formatBinder.InitializeRightFromLeft).DoOnInitializeLeftFromRight(formatBinder.InitializeLeftFromRight).RegisterChildDisposable(() => formatBinder);
		return objectBinder;
	}

	public ClockToken()
	{
		ClockData.DataModified += base.OnDataModified;
	}

	public override TokenBase Clone()
	{
		ClockToken clockToken = new ClockToken();
		clockToken.ClockData.DateFormatLength = ClockData.DateFormatLength;
		clockToken.ClockData.TimeFormatLength = ClockData.TimeFormatLength;
		clockToken.ClockData.Use24HourFormat = ClockData.Use24HourFormat;
		clockToken.ID = base.ID;
		return CopyProperties(clockToken);
	}

	protected override void OnSerializeToken(Pro.SerializationInterop.RVProtoData.Message.Types.Token token)
	{
		token.Clock = new Pro.SerializationInterop.RVProtoData.Message.Types.Token.Types.TokenTypeClock();
	}

	protected override void OnDeserializeToken(Pro.SerializationInterop.RVProtoData.Message.Types.Token token)
	{
	}

	protected override void OnSerializeTokenValue(Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue tokenValue)
	{
		tokenValue.Clock = new Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue.Types.TokenValueClock
		{
			Format = ClockData.Serialize()
		};
	}

	protected override void OnDeserializeTokenValue(Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue tokenValue)
	{
		ClockData.Deserialize(tokenValue.Clock.Format);
	}

	protected override void OnUndoStackChanged(UndoStack? value)
	{
		base.OnUndoStackChanged(value);
		ClockData.UndoStack = value;
	}
}
