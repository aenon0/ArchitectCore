﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HRLeaveManagement.Application.Persistance.Contracts;

namespace HRLeaveManagement.Application.DTOs.LeaveAllocation.Validators
{
    public class UpdateLeaveAllocationDtoValidator : AbstractValidator<UpdateLeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        public UpdateLeaveAllocationDtoValidator(ILeaveAllocationRepository leaveAllocationRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            Include(new ILeaveAllocationDtoValidator(_leaveAllocationRepository));
            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present.");
        }
    }
}
