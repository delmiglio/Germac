using Germac.Domain.Repositories;
using Germac.Infrastructure.Queries;
using Germac.Infrastructure.UnitOfWork;
using MediatR;

namespace Germac.Application.Command.DeletePartCommand
{
    public class DeletePartCommand : IRequestHandler<DeletePartRequest, DeletePartResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPartRepository _partRepository;

        public DeletePartCommand(IUnitOfWork unitOfWork, IPartRepository partRepository)
        {
            _partRepository = partRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeletePartResponse> Handle(DeletePartRequest request, CancellationToken cancellationToken)
        {
            using (var transaction = _unitOfWork.Connection.BeginTransaction())
            {
                try
                {
                    var partToBeDeleted = _partRepository.GetById(PartQueries.Find, request.Id);
                    if (partToBeDeleted != null)
                    {
                        var deletePartResult = await _partRepository.Delete(PartQueries.Delete, request.Id);
                        if (deletePartResult > 0)
                        {
                            _unitOfWork.Transaction.Commit();
                            return new DeletePartResponse();
                        }
                    }

                    return new DeletePartResponse();
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
