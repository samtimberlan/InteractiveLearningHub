using System;
using System.Threading.Tasks;

namespace InteractiveLearningHub.Core.Abstractions
{
    public interface IUserService
    {
        string GetIdentityUserId();
        string GetIdentityUserFullName();
        Guid GetLocalUserIdByIdentityId(string identityId);
        //Task AddUserEmployeeTypeClaimAsync(string employeeType);
    }
}
