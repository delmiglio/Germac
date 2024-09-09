using Germac.Application.DTO;
using Germac.Domain.Entities;
using Germac.Domain.Repositories;
using Germac.Infrastructure.Queries;
using Germac.Infrastructure.UnitOfWork;
using MediatR;
using Serilog;

namespace Germac.Application.Commands.AddPartsOrder
{
    public class AddPartsOrderCommand(IUnitOfWork unitOfWork, IOrderRepository orderRepository, IPartRepository partRepository, IPartOrderRepository partOrderRepository, ILogger logger) : IRequestHandler<AddPartsOrderRequest, AddPartsOrderResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<AddPartsOrderResponse> Handle(AddPartsOrderRequest request, CancellationToken cancellationToken)
        {
            try
            {
                logger.Information($"Starting Command {nameof(AddPartsOrderCommand)}");
                var orderExists = await orderRepository.GetById(OrderQueries.FindById, request.OrderId);

                if (orderExists == null)
                {
                    return new AddPartsOrderResponse
                    {
                        Success = false,
                        Data = null,
                        ErrorMessage = "Order Not Updated. Order Not in Database"
                    };
                }

                var requestPartIds = request.PartsOrdered.Select(partOrdered => partOrdered.PartId);

                var parts = await partRepository.GetAll(PartQueries.FindByIdList, requestPartIds.ToArray());
                var partIdsNotInPartList = parts.Select(part => part.Id).Except(requestPartIds);

                if (partIdsNotInPartList.Any())
                {
                    logger.Information($"Some Parts Not Found in Database: {string.Join(',', partIdsNotInPartList)}. Please Check");
                    return new AddPartsOrderResponse
                    {
                        Success = false,
                        Data = null,
                        ErrorMessage = $"Some Parts Not Found in Database: {string.Join(',', partIdsNotInPartList)}. Please Check"
                    };
                }

                var partsWithoutStock = parts.Where(part => part.Quantity <= 0).Select(part => part);

                if (partsWithoutStock.Any())
                {
                    logger.Information($"Some Parts Are with Unavaiable Stock. Id's: {string.Join(',', partsWithoutStock)}. Names: {string.Join(',', partsWithoutStock.ToList().Select(part => part.Name))}. Please Check");
                    return new AddPartsOrderResponse
                    {
                        Success = false,
                        Data = null,
                        ErrorMessage = $"Some Parts Are with Unavaiable Stock. Id's: {string.Join(',', partsWithoutStock)}. Names: {string.Join(',', partsWithoutStock.ToList().Select(part => part.Name))}. Please Check"
                    };
                };

                var partsWithLessQuantityThanOrdered = parts
                     .Join(request.PartsOrdered, part => part.Id, orderedPart => orderedPart.PartId, (part, orderedPart) => new { part, orderedPart })
                     .Where(x => x.part.Quantity < x.orderedPart.Quantity)
                     .Select(x => new OrderPartDTO
                     {
                         PartId = x.part.Id,
                         Quantity = x.part.Quantity,
                         Name = x.part.Name
                     }).ToList();

                if (partsWithLessQuantityThanOrdered.Count != 0)
                {
                    logger.Information($"Some Parts Cannot be withdraw from stock. Id's: {string.Join(',', partsWithLessQuantityThanOrdered.Select(part => part.PartId))}. Names: {string.Join(',', partsWithLessQuantityThanOrdered.Select(part => part.Name))}. Please Check");
                    return new AddPartsOrderResponse
                    {
                        Success = false,
                        Data = null,
                        ErrorMessage = $"Some Parts Cannot be withdraw from Stock. Id's: {string.Join(',', partsWithLessQuantityThanOrdered.Select(part => part.PartId))}. Names: {string.Join(',', partsWithLessQuantityThanOrdered.Select(part => part.Name))}. Please Check"
                    };
                };

                request.PartsOrdered.ToList().ForEach(partOrdered =>
                {
                    var insertPartOrder = partOrderRepository.Add(PartOrderQueries.Insert, new PartOrder(partOrdered.PartId, request.OrderId, partOrdered.Quantity));
                    var updatePartQuantities = partRepository.Update(PartQueries.UpdateQuantity, new Part(partOrdered.PartId, parts.FirstOrDefault(part => part.PartId == partOrdered.PartId).Quantity - partOrdered.Quantity));
                });

                return new AddPartsOrderResponse
                {
                    Success = true,
                    Data = null,
                    ErrorMessage = null
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
