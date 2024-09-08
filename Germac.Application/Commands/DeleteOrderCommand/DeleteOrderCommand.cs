using Germac.Application.Command.DeleteOrderCommand;
using Germac.Domain.Repositories;
using Germac.Infrastructure.Queries;
using Germac.Infrastructure.UnitOfWork;
using MediatR;

namespace Germac.Application.Command.DeleteOrderCommand
{
    public class DeleteOrderCommand : IRequestHandler<DeleteOrderRequest, DeleteOrderResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderCommand(IUnitOfWork unitOfWork, IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteOrderResponse> Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
            using (var transaction = _unitOfWork.Connection.BeginTransaction())
            {
                try
                {
                    var OrderToBeDeleted = _orderRepository.GetById(OrderQueries.Find, request.Id);
                    if (OrderToBeDeleted != null)
                    {
                        var deleteOrderResult = await _orderRepository.Delete(OrderQueries.Delete, request.Id);
                        if (deleteOrderResult > 0)
                        {
                            _unitOfWork.Transaction.Commit();
                            return new DeleteOrderResponse();
                        }
                    }

                    return new DeleteOrderResponse();
                }
                catch (Exception)
                {
                    _unitOfWork.Transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
