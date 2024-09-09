using Germac.Domain.Repositories;
using Germac.Infrastructure.Queries;
using Germac.Infrastructure.UnitOfWork;
using MediatR;

namespace Germac.Application.Commands.DeleteOrderCommand
{
    public class DeleteOrderCommand(IUnitOfWork unitOfWork, IOrderRepository orderRepository) : IRequestHandler<DeleteOrderRequest, DeleteOrderResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IOrderRepository _orderRepository = orderRepository;

        public async Task<DeleteOrderResponse> Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var orderToBeDeleted = await _orderRepository.GetById(OrderQueries.FindById, request.Id);
                if (orderToBeDeleted != null)
                {
                    var deleteOrderResult = await _orderRepository.Delete(OrderQueries.Delete, request.Id);
                    if (deleteOrderResult > 0)
                    {
                        return new DeleteOrderResponse
                        {
                            Success = true,
                            Data = deleteOrderResult,
                            ErrorMessage = null
                        };
                    }
                }
                return new DeleteOrderResponse
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "Order Not Deleted. Not Found"
                };
            }
            catch (Exception)
            {
                _unitOfWork?.Transaction?.Rollback();
                throw;
            }
        }
    }
}
