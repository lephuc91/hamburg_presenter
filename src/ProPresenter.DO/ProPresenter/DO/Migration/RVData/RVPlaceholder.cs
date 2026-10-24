using System;
using System.Collections.Generic;
using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class RVPlaceholder
{
	[Child]
	[Alias("FieldId", typeof(Guid), false)]
	public Guid FieldId { get; set; }

	[Child]
	[Alias("FieldName", typeof(string), false)]
	public string? FieldName { get; set; }

	[Child]
	[Alias("FieldValue", typeof(string), false)]
	public string? FieldValue { get; set; }

	[Child]
	[Alias("IsClock", typeof(bool), false)]
	public bool IsClock { get; set; }

	[Child]
	[Alias("IsTimer", typeof(bool), false)]
	public bool IsTimer { get; set; }

	[Child]
	[Alias("PlaceholderType", typeof(string), false)]
	public string? PlaceholderType { get; set; }

	[Child]
	[Optional]
	[Alias("TimeFormat", typeof(string), false)]
	public string? TimeFormat { get; set; }

	[Child]
	[Optional]
	[Alias("Meridiem", typeof(string), false)]
	public string? Meridiem { get; set; }

	[Child]
	[Optional]
	[Alias("OverRun", typeof(bool), false)]
	public bool OverRun { get; set; }

	[Child]
	[Optional]
	[Alias("TimerType", typeof(string), false)]
	public string? TimerType { get; set; }

	[Child]
	[Optional]
	[Alias("EndTime", typeof(string), false)]
	public string? EndTime { get; set; }

	[Collection]
	[Optional]
	[Alias("TimerValueDictionary", typeof(KeyValueOfstringanyType), false)]
	public List<KeyValueOfstringanyType>? TimerValueDictionary { get; set; }
}
