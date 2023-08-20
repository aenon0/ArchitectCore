using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HRLeaveManagement.Application.Persistance.Contracts;

namespace HRLeaveManagement.Application.DTOs.LeaveRequest.Validator
{
    public class ILeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;        
        public ILeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
        {         
            _leaveRequestRepository = leaveRequestRepository;
            RuleFor(p => p.StartDate)
                .LessThan(p => p.EndDate).WithMessage("{PropertyName} must be before {ComparisionValue}")
                .NotEmpty()
                .NotNull();
            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) => 
                {
                    var leaveTypeExists = await _leaveRequestRepository.Exists(id);
                    return !leaveTypeExists;
                }).WithMessage("{PropertyName} doesn't exist.");


        }
    }
}
