using Germac.Application.Queries.FindOrderQuery;
using Germac.Domain.Repositories;
using Germac.Infrastructure.Queries;
using Germac.Infrastructure.UnitOfWork;
using MediatR;
using Serilog;

namespace Germac.Application.Commands.DeletePartCommand
{
    public class DeletePartCommand(IUnitOfWork unitOfWork, IPartRepository partRepository, ILogger logger) : IRequestHandler<DeletePartRequest, DeletePartResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IPartRepository _partRepository = partRepository;

        public async Task<DeletePartResponse> Handle(DeletePartRequest request, CancellationToken cancellationToken)
        {
            try
            {
                logger.Information($"Starting Command {nameof(DeletePartResponse)}");
                var partToBeDeleted = await _partRepository.GetById(PartQueries.FindById, request.Id);
                if (partToBeDeleted != null)
                {
                    var deletePartResult = await _partRepository.Delete(PartQueries.Delete, request.Id);
                    if (deletePartResult > 0)
                    {
                        return new DeletePartResponse
                        {
                            Success = true,
                            Data = deletePartResult,
                            ErrorMessage = null
                        };
                    }
                }
                return new DeletePartResponse
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "Part Not Deleted. Not Found"
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
