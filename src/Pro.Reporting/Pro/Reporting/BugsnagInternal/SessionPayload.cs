using System;
using System.Collections.Generic;
using Bugsnag;
using Bugsnag.Payload;

namespace Pro.Reporting.BugsnagInternal;

internal class SessionPayload : Dictionary<string, object>, IPayload
{
	private readonly IConfiguration _configuration;

	public Uri Endpoint { get; }

	public KeyValuePair<string, string>[] Headers { get; }

	public SessionPayload(IConfiguration configuration, Session session, App app, Device device)
	{
		_configuration = configuration;
		Endpoint = configuration.SessionEndpoint;
		Headers = new KeyValuePair<string, string>[2]
		{
			new KeyValuePair<string, string>("Bugsnag-Api-Key", configuration.ApiKey),
			new KeyValuePair<string, string>("Bugsnag-Payload-Version", "1.0")
		};
		this.AddToPayload("notifier", NotifierInfo.Instance);
		this.AddToPayload("app", app);
		this.AddToPayload("device", device);
		this.AddToPayload("sessions", new Session[1] { session });
	}

	public byte[] Serialize()
	{
		return Serializer.SerializeObjectToByteArray(this, _configuration.MetadataFilters);
	}
}
