using System;
using System.Collections.Generic;
using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class RVTimer
{
	[Child]
	[Alias("FieldId", typeof(Guid), false)]
	public Guid FieldId { get; set; }

	[Child]
	[Alias("FieldName", typeof(string), false)]
	public string? FieldName { get; set; }

	[Child]
	[Alias("TimeFormat", typeof(string), false)]
	public string? TimeFormat { get; set; }

	[Child]
	[Alias("Meridiem", typeof(string), false)]
	public string? Meridiem { get; set; }

	[Child]
	[Alias("OverRun", typeof(bool), false)]
	public bool OverRun { get; set; }

	[Child]
	[Alias("TimerType", typeof(string), false)]
	public string? TimerType { get; set; }

	[Child]
	[Alias("EndTime", typeof(string), false)]
	public string? EndTime { get; set; }

	[Collection]
	[Alias("TimerValueDictionary", typeof(KeyValueOfstringanyType), false)]
	public List<KeyValueOfstringanyType>? TimerValueDictionary { get; set; }
}
