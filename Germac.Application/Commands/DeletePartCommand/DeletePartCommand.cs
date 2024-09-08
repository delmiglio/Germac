using Germac.Application.Command.DeletePartCommand;
using Germac.Domain.Repositories;
using Germac.Infrastructure.Queries;
using Germac.Infrastructure.UnitOfWork;
using MediatR;

namespace Germac.Application.Commands.DeletePartCommand
{
    public class DeletePartCommand(IUnitOfWork unitOfWork, IPartRepository partRepository) : IRequestHandler<DeletePartRequest, DeletePartResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IPartRepository _partRepository = partRepository;

        public async Task<DeletePartResponse> Handle(DeletePartRequest request, CancellationToken cancellationToken)
        {
            using var transaction = _unitOfWork?.Connection?.BeginTransaction();
            try
            {
                var partToBeDeleted = _partRepository.GetById(PartQueries.Find, request.Id);
                if (partToBeDeleted != null)
                {
                    var deletePartResult = await _partRepository.Delete(PartQueries.Delete, request.Id);
                    if (deletePartResult > 0)
                    {
                        _unitOfWork?.Transaction?.Commit();
                        return new DeletePartResponse();
                    }
                }

                return new DeletePartResponse();
            }
            catch (Exception)
            {
                _unitOfWork?.Transaction?.Rollback();
                throw;
            }
        }
    }
}
