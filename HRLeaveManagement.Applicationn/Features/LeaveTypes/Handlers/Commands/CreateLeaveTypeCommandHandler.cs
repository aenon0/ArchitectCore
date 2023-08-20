using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using HRLeaveManagement.Application.Persistance.Contracts;
using HRLeaveManagement.Application.DTOs.LeaveType.Validators;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Responses;
using System.Threading;
using HRLeaveManagement.Domain;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeRequestHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        //public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        //{
        //    var response = new BaseCommandResponse();
        //    var validator = new CreateLeaveTypeDtoValidator();
        //    var validationResult = validator.Validate(request.CreateLeaveTypeDto);
        //    if (validationResult.IsValid == false)
        //    {
        //        response.Success = false;
        //        response.Message = "Creation Failed";
        //        response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        //        //throw new ValidationException(validationResult);
        //    }
        //    var leaveType = _mapper.Map<LeaveType>(request.CreateLeaveTypeDto);
        //    leaveType = await _leaveTypeRepository.Add(leaveType);

        //    response.Success = true;
        //    response.Message = "Creation Successful";
        //    response.Id = leaveType.Id;
        //    return response;
        //}

        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveTypeDtoValidator();
            var validationResult = validator.Validate(request.CreateLeaveTypeDto);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                //throw new ValidationException(validationResult);
            }
            var leaveType = _mapper.Map<LeaveType>(request.CreateLeaveTypeDto);
            leaveType = await _leaveTypeRepository.Add(leaveType);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = leaveType.Id;
            return response;
        }
    }
}
