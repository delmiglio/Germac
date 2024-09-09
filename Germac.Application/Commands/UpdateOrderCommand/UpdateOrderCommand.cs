﻿using Germac.Application.Commands.UpdatePartCommand;
using Germac.Domain.Entities;
using Germac.Domain.Repositories;
using Germac.Infrastructure.Queries;
using Germac.Infrastructure.UnitOfWork;
using MediatR;

namespace Germac.Application.Commands.UpdateOrderCommand
{
    public class UpdateOrderCommand(IUnitOfWork unitOfWork, IOrderRepository orderRepository) : IRequestHandler<UpdateOrderRequest, UpdateOrderResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IOrderRepository _orderRepository = orderRepository;

        public async Task<UpdateOrderResponse> Handle(UpdateOrderRequest request, CancellationToken cancellationToken)
        {
            using var transaction = _unitOfWork?.Connection?.BeginTransaction();
            try
            {
                var oldOrder = await _orderRepository.GetById(OrderQueries.FindById, request.Id);

                if (oldOrder != null)
                {
                    var updatedOrder = await _orderRepository.Update(OrderQueries.Update, new Order
                    {
                        OrderId = request.OrderId,
                        Id = request.Id,
                        TotalPrice = request.TotalPrice,
                        UpdateDate = DateTime.Now
                    });

                    if (updatedOrder > 0)
                    {
                        _unitOfWork?.Transaction?.Commit();
                        return new UpdateOrderResponse
                        {
                            Success = true,
                            Data = updatedOrder,
                            ErrorMessage = null
                        };
                    }
                }

                return new UpdateOrderResponse
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "Order Not Updated. Order Not in Database"
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
