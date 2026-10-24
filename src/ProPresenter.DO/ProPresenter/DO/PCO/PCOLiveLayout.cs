using System.ComponentModel;

namespace ProPresenter.DO.PCO;

public enum PCOLiveLayout
{
	[Description("normal")]
	Normal,
	[Description("normal_third")]
	NormalThird,
	[Description("countdown")]
	Countdown,
	[Description("countdown_third")]
	CountdownThird,
	[Description("overview")]
	Overview,
	[Description("mobile")]
	Mobile
}
