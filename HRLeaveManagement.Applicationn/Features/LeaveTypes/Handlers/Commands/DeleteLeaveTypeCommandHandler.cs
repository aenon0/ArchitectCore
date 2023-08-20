﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using HRLeaveManagement.Application.Features.LeaveTypes.Request.Commands;
using HRLeaveManagement.Application.Persistance.Contracts;
using HRLeaveManagement.Application.Exceptions;
using System.Threading;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        //public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        //{
        //    var leaveType = await _leaveTypeRepository.Get(request.Id);
        //    if (leaveType == null)
        //    {
        //        throw new NotFoundException(nameof(Domain.LeaveType), request.Id);
        //    }
        //    await _leaveTypeRepository.Delete(leaveType);
        //    return Unit.Value;
        //}

        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.Get(request.Id);
            if (leaveType == null)
            {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }
            await _leaveTypeRepository.Delete(leaveType);
            return Unit.Value;
        }
    }
}
