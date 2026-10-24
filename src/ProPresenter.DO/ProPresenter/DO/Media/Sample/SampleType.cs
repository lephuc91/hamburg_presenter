using System.Runtime.Serialization;

namespace ProPresenter.DO.Media.Sample;

public enum SampleType
{
	[EnumMember(Value = "group")]
	Group,
	[EnumMember(Value = "content")]
	Content
}
