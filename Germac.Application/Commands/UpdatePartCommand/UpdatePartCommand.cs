using Germac.Application.Commands.UpdateOrderCommand;
using Germac.Domain.Entities;
using Germac.Domain.Repositories;
using Germac.Infrastructure.Queries;
using Germac.Infrastructure.UnitOfWork;
using MediatR;
using Serilog;

namespace Germac.Application.Commands.UpdatePartCommand
{
    public class UpdatePartCommand(IUnitOfWork unitOfWork, IPartRepository partRepository, ILogger logger) : IRequestHandler<UpdatePartRequest, UpdatePartResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IPartRepository _partRepository = partRepository;

        public async Task<UpdatePartResponse> Handle(UpdatePartRequest request, CancellationToken cancellationToken)
        {
            try
            {
                logger.Information($"Starting Command {nameof(UpdatePartCommand)}");
                var oldPart = await _partRepository.GetById(PartQueries.FindById, request.Id);

                if (oldPart != null)
                {
                    var updatedPart = await _partRepository.Update(PartQueries.Update, new Part
                    {
                        PartId = request.PartId,
                        Id = request.Id,
                        Name = request.Name,
                        PartNumber = request.PartNumber,
                        Price = request.Price,
                        Quantity = request.Quantity,
                        UpdateDate = DateTime.Now
                    });

                    if (updatedPart > 0)
                    {
                        _unitOfWork?.Transaction?.Commit();
                        return new UpdatePartResponse
                        {
                            Success = true,
                            Data = updatedPart,
                            ErrorMessage = null
                        };
                    }
                }

                return new UpdatePartResponse
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "Part Not Updated. Part Not in Database"
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
