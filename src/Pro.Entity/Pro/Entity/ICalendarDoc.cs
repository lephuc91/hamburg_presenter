using System;

namespace Pro.Entity;

public interface ICalendarDoc : IEntityDocument, IEntity, IDisposable, IDocument, ICanExportSnapshot, ICalendar
{
}
