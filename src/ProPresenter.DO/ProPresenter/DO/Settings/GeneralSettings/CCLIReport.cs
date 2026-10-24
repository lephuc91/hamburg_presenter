using System;
using System.Globalization;
using System.Linq;
using Pro.Common.Components;
using Pro.Common.Strings;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Settings.GeneralSettings;

public class CCLIReport : NotifyPropertyChangedBase
{
	private ReportState _reportState = ReportState.Pending;

	public DateTime DateUsed { get; }

	public string Title { get; }

	public string Author { get; }

	public string Publisher { get; }

	public string Copyright { get; }

	public string CCLINumber { get; }

	public ReportState ReportState
	{
		get
		{
			return _reportState;
		}
		set
		{
			SetValue("ReportState", ref _reportState, value, OnDataModified);
		}
	}

	public event Action? DataModified;

	public CCLIReport(CCLIData ccliData)
		: this(DateTime.Today, ccliData.Title, ccliData.Author, ccliData.Publisher, ccliData.Copyright, ccliData.SongNumber, ReportState.Pending)
	{
	}

	public CCLIReport(DateTime dateUsed, string title, string author, string publisher, string copyright, string songNumber, ReportState reportState)
	{
		DateUsed = dateUsed;
		Title = Clean(title);
		Author = Clean(author);
		Publisher = Clean(publisher);
		Copyright = Clean(copyright);
		CCLINumber = Clean(songNumber);
		ReportState = reportState;
	}

	private string Clean(string data)
	{
		if (string.IsNullOrEmpty(data))
		{
			return string.Empty;
		}
		return LineBreaks.Replace(data.Replace('\t', ' '));
	}

	public string Encode()
	{
		global::_003C_003Ey__InlineArray7<object> buffer = default(global::_003C_003Ey__InlineArray7<object>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray7<object>, object>(ref buffer, 0) = DateUsed.ToString(CultureInfo.InvariantCulture);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray7<object>, object>(ref buffer, 1) = Title;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray7<object>, object>(ref buffer, 2) = Author;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray7<object>, object>(ref buffer, 3) = Publisher;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray7<object>, object>(ref buffer, 4) = Copyright;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray7<object>, object>(ref buffer, 5) = CCLINumber;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray7<object>, object>(ref buffer, 6) = ReportState;
		return string.Join("\t", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray7<object>, object>(in buffer, 7));
	}

	public string EncodeForExport()
	{
		global::_003C_003Ey__InlineArray6<string> buffer = default(global::_003C_003Ey__InlineArray6<string>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray6<string>, string>(ref buffer, 0) = DateUsed.ToString(CultureInfo.InvariantCulture);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray6<string>, string>(ref buffer, 1) = Title;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray6<string>, string>(ref buffer, 2) = Author;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray6<string>, string>(ref buffer, 3) = Publisher;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray6<string>, string>(ref buffer, 4) = Copyright;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray6<string>, string>(ref buffer, 5) = CCLINumber;
		return string.Join("\t", global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray6<string>, string>(in buffer, 6));
	}

	public static CCLIReport? Decode(string data)
	{
		if (string.IsNullOrWhiteSpace(data))
		{
			return null;
		}
		string[] source = data.Split('\t');
		DateTime result;
		ReportState result2;
		return new CCLIReport(DateTime.TryParse(source.ElementAtOrDefault(0) ?? string.Empty, CultureInfo.InvariantCulture, DateTimeStyles.None, out result) ? result : DateTime.Now, source.ElementAtOrDefault(1) ?? string.Empty, source.ElementAtOrDefault(2) ?? string.Empty, source.ElementAtOrDefault(3) ?? string.Empty, source.ElementAtOrDefault(4) ?? string.Empty, source.ElementAtOrDefault(5) ?? string.Empty, Enum.TryParse<ReportState>(source.ElementAtOrDefault(6) ?? string.Empty, out result2) ? result2 : ReportState.Skipped);
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}
}
