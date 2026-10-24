using System;
using ProPresenter.DO;

namespace ProPresenter.Controller.Remote.Apps;

public static class DesintationExtenstions
{
	public static Destination Encode(this OutputDestination outputDestination)
	{
		return outputDestination switch
		{
			OutputDestination.Presentation => Destination.Presentation, 
			OutputDestination.Announcement => Destination.Announcement, 
			_ => throw new NotSupportedException(), 
		};
	}

	public static OutputDestination Decode(this Destination destination)
	{
		return destination switch
		{
			Destination.Presentation => OutputDestination.Presentation, 
			Destination.Announcement => OutputDestination.Announcement, 
			_ => throw new NotSupportedException(), 
		};
	}
}
