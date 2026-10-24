using System;
using System.Threading;
using System.Threading.Tasks;
using ProPresenter.DO.Organization.Avatar.Model;

namespace ProPresenter.DO.Organization;

public interface IOrganizationConsumer
{
	Task<IAvatarResult> GetAvatarAsync(DateTimeOffset cachedAvatarTimestamp, CancellationToken cancellationToken = default(CancellationToken));
}
