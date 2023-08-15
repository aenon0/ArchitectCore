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

    }
}
