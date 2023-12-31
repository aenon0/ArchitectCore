﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HRLeaveManagement.Application.DTOs;
using HRLeaveManagement.Application.Features.LeaveTypes.Request;
using HRLeaveManagement.Application.Features.LeaveTypes.Request.Queries;
using HRLeaveManagement.Application.Persistance.Contracts;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeListRequestHandler : IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDto>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public GetLeaveTypeListRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        //public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken) 
        //{
        //    var leaveTypes = await _leaveTypeRepository.GetAll();
        //    return _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
        //}

        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _leaveTypeRepository.GetAll();
            return _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
        }
    }
}
