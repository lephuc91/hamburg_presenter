using System;
using Pro.Data.SQLite;

namespace Pro.Data.Entities;

[Table("RecentlyAppliedTemplateSlides")]
public class RecentlyAppliedTemplateSlide : EntityBase<RecentlyAppliedTemplateSlide>
{
	public Guid TemplateSlideId { get; set; }

	public DateTime DateApplied { get; set; }
}
