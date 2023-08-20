using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Domain.Common;

namespace HRLeaveManagement.Application.DTOs
{
    public class LeaveAllocationDto : Common.BaseEntityDto
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDto LeaveType { get; set; }    
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
