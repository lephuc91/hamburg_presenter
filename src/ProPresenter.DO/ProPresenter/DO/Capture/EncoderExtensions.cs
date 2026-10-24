namespace ProPresenter.DO.Capture;

public static class EncoderExtensions
{
	public static void SetDestinationDefaults(this StreamEncoder encoder, DestinationType destinationType)
	{
		switch (destinationType)
		{
		case DestinationType.Disk:
			encoder.Codec = Codec.H264;
			encoder.Encoding = Encoder.DiskDefault;
			break;
		case DestinationType.RTMP:
			encoder.Codec = Codec.Automatic;
			encoder.Encoding = Encoder.RtmpDefault;
			break;
		case DestinationType.Resi:
			encoder.Codec = Codec.Automatic;
			encoder.Encoding = new Encoder();
			break;
		}
	}

	public static string BitrateToString(this uint bitrate)
	{
		double num = bitrate;
		if (bitrate >= 1000000)
		{
			num /= 1000000.0;
			return $"{num} Mbps";
		}
		num /= 1000.0;
		return $"{num} kbps";
	}
}
