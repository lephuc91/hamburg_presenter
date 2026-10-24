using Pro.Common.Utility;

namespace ProPresenter.DO.PCO;

public static class PCOLiveLinkGenerator
{
	private const string BaseURL = "https://planningcenteronline.com/live/{0}?layout={1}&countdown={2}&theme={3}&toolbar_enabled=false";

	public static string Generate(string? planID, PCOLiveLayout layout, PCOLiveCountdownType countdownType, PCOLiveTheme theme)
	{
		global::_003C_003Ey__InlineArray4<object> buffer = default(global::_003C_003Ey__InlineArray4<object>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 0) = planID;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 1) = layout.GetEnumDescription();
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 2) = countdownType.GetEnumDescription();
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray4<object>, object>(ref buffer, 3) = theme.GetEnumDescription();
		return string.Format("https://planningcenteronline.com/live/{0}?layout={1}&countdown={2}&theme={3}&toolbar_enabled=false", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray4<object>, object>(in buffer, 4));
	}
}
