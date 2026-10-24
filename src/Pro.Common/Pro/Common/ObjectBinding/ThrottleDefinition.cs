using System;
using System.Reactive.Concurrency;

namespace Pro.Common.ObjectBinding;

public record ThrottleDefinition(IScheduler Scheduler, TimeSpan Timeout);
