using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.UI;

namespace ProPresenter.DO.Analytics.Events.TestPattern;

public record TestPatternShownEvent(TestPatternShownSource Source) : IAnalyticEvent
{
	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			e.UiTestPatterns = new TestPatterns
			{
				Source = Source.ToProto()
			};
		});
	}
}
