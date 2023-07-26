using Worker_onboarding.Application.UseCase.V1.PersonOperation.Queries.GetList;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Services
{
    public class WorkerServices : BackgroundService
    {
        private readonly ILogger<WorkerServices> _logger;
        private readonly ISender _mediator;

        public WorkerServices(ILogger<WorkerServices> logger, ISender mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // porque estoy publicando personas?
            _logger.LogInformation("Ejemplo de BackgroundServices");

            // en el workshop indica que es await 
            await _mediator.Send(new ListPerson());
        }
    }
}
