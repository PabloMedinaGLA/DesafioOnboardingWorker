using Andreani.ARQ.AMQStreams.Interface;
using System.Threading.Tasks;
using System;
using Andreani.Scheme.Onboarding;
using DnsClient.Internal;
using Microsoft.Extensions.Logging;
using System.Diagnostics.Eventing.Reader;

namespace DesafioOnboardingWorker.Services
{
    public class Subscriber : ISubscriber
    {
        private ILogger<Subscriber> _logger;

        public Subscriber(ILogger<Subscriber> logger)
        {
            _logger = logger;
        }
        public async Task ReciveCustomEvent(Pedido @event)
        {
            _logger.LogInformation("id {0}", @event.id);
        }
    }
}
