﻿using Germac.Domain.Entities;
using Germac.Domain.Repositories;
using Germac.Infrastructure.Queries;
using Germac.Infrastructure.UnitOfWork;
using MediatR;

namespace Germac.Application.Command.UpdatePartCommand
{
    public class UpdatePartCommand : IRequestHandler<UpdatePartRequest, UpdatePartResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPartRepository _partRepository;

        public UpdatePartCommand(IUnitOfWork unitOfWork, IPartRepository partRepository)
        {
            _unitOfWork = unitOfWork;
            _partRepository = partRepository;
        }

        public async Task<UpdatePartResponse> Handle(UpdatePartRequest request, CancellationToken cancellationToken)
        {
            using (var transaction = _unitOfWork.Connection.BeginTransaction())
            {
                try
                {
                    var oldPart = await _partRepository.GetById(PartQueries.Find, request.Id);

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
                            _unitOfWork.Transaction.Commit();
                            return new UpdatePartResponse
                            {

                            };
                        }
                    }

                    return new UpdatePartResponse
                    {

                    };
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
