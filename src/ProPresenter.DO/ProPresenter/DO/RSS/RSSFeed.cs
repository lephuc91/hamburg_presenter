using System.Collections.Generic;
using Pro.Serialization.Control;
using Pro.Serialization.Utility;

namespace ProPresenter.DO.RSS;

public class RSSFeed
{
	[MixedCollection]
	public List<Channel> Channels { get; set; } = new List<Channel>();

	public static RSSFeed? LoadFeed(string rssXMLData)
	{
		return XHelper.ReadRawData<RSSFeed>(rssXMLData) ?? new RSSFeed();
	}
}
