namespace Pro.Loro;

public interface IConfigure
{
	Configure Fork();

	long MergeInterval();

	bool RecordTimestamp();

	void SetMergeInterval(long interval);

	void SetRecordTimestamp(bool record);

	StyleConfigMap TextStyleConfig();
}
