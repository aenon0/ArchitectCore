using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Domain;

namespace HRLeaveManagement.Application.Persistance.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        public Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
        public Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();
        public Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus);
    }
}
