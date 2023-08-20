using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Request.Commands
{
    public class DeleteLeaveAllocationCommand : IRequest
    {
        public int Id { get; set; } 
    }
}
