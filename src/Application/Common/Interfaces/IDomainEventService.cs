using DesafioOnboardingWorker.Domain.Common;
using System.Threading.Tasks;

namespace DesafioOnboardingWorker.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
