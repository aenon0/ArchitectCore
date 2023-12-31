﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.DTOs.Common;

namespace HRLeaveManagement.Application.DTOs.LeaveRequest
{
    public class UpdateLeaveRequestDto : BaseEntityDto, ILeaveRequestDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public string RequestComments { get; set; } 
        public bool Cancelled { get; set; }
            
    }
}
