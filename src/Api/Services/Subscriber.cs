using System.Runtime.InteropServices;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Andreani.ARQ.AMQStreams.Interface;
using Andreani.Scheme.Onboarding;
using IPublisher = Andreani.ARQ.AMQStreams.Interface.IPublisher;
using Worker_onboarding.Application.UseCase.V1.PedidoOperation.Commands.Update;

namespace Api.Services
{

    public class Subscriber : ISubscriber
    {

        private ILogger<ISubscriber> _logger;
        private IPublisher _publisher;
        private readonly ISender _mediator;

        public Subscriber(ILogger<Subscriber> logger, IPublisher publisher, ISender mediator)
        {
            _logger = logger;
            _publisher = publisher;
            _mediator = mediator;
        }

        public async Task RecivePedidoCreado(Pedido response)
        {
            // enviar el evento 
            Pedido publisherPedido = await _mediator.Send(new UpdatePedidoCommand{pedido = response});
            await _publisher.To<Pedido>(publisherPedido, publisherPedido.id);
            //await _mediator.Send(@event);
        }




    }



}
