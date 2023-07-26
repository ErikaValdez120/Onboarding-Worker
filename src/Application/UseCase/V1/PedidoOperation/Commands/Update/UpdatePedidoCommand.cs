using Andreani.Scheme.Onboarding;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Worker_onboarding.Application.UseCase.V1.PedidoOperation.Commands.Update
{
    public class UpdatePedidoCommand: IRequest<Pedido> 
    {
        public Pedido pedido { get; set; }

    }

    public class UpdatePedidoHandler : IRequestHandler<UpdatePedidoCommand,Pedido> 
    {
        public async Task<Pedido> Handle(UpdatePedidoCommand request, CancellationToken cancellationToken)
        {
            Pedido pedidoActualizado = request.pedido;

            pedidoActualizado.numeroDePedido= new Random().Next();
            pedidoActualizado.estadoDelPedido = 2.ToString();

            return pedidoActualizado;
        }
    }
}
