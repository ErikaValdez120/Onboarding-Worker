using Worker_onboarding.Domain.Common;
using System.Threading.Tasks;

namespace Worker_onboarding.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
