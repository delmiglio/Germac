﻿using Germac.Domain.Repositories;
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
            using var transaction = _unitOfWork?.Connection?.BeginTransaction();
            try
            {
                var OrderToBeDeleted = _orderRepository.GetById(OrderQueries.Find, request.Id);
                if (OrderToBeDeleted != null)
                {
                    var deleteOrderResult = await _orderRepository.Delete(OrderQueries.Delete, request.Id);
                    if (deleteOrderResult > 0)
                    {
                        _unitOfWork?.Transaction?.Commit();
                        return new DeleteOrderResponse();
                    }
                }

                return new DeleteOrderResponse();
            }
            catch (Exception)
            {
                _unitOfWork?.Transaction?.Rollback();
                throw;
            }
        }
    }
}
