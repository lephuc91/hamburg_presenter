using System;
using Pro.Common.SourceGenerator.Attributes;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v2;

namespace ProPresenter.DO.Media;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(MediaReferenceInfo.Types.Availability.AvailabilityOneofCase), typeof(MediaAvailability), SourceToDestinationMethodName = "ToMediaAvailability", ExcludeSourceNames = new string[] { "None" })]
public static class MediaAvailabilityExtensions
{
	public static MediaAvailability ToMediaAvailability(this MediaReferenceInfo.Types.Availability.AvailabilityOneofCase source)
	{
		return source switch
		{
			MediaReferenceInfo.Types.Availability.AvailabilityOneofCase.Ready => MediaAvailability.Ready, 
			MediaReferenceInfo.Types.Availability.AvailabilityOneofCase.Missing => MediaAvailability.Missing, 
			MediaReferenceInfo.Types.Availability.AvailabilityOneofCase.Downloading => MediaAvailability.Downloading, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}
}
