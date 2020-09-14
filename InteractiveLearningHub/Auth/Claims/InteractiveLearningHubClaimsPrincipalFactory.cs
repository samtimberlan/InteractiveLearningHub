using InteractiveLearningHub.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InteractiveLearningHub.Auth.Claims
{
    public class InteractiveLearningHubClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOptions<IdentityOptions> _options;
        private readonly RoleManager<IdentityRole> _roleManager;

        public InteractiveLearningHubClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager, IOptions<IdentityOptions> options, RoleManager<IdentityRole> roleManager) : base(userManager, roleManager, options)
        {
            _userManager = userManager;
            _options = options;
            _roleManager = roleManager;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("User Type", user.Type));
            return identity;
        }

        public async Task AddUserEmployeeTypeClaimAsync(string employeeType, ApplicationUser user)
        {
            if (employeeType == EmployeeType.General ||
                employeeType == EmployeeType.Employee ||
                employeeType == EmployeeType.HRDepartment ||
                employeeType == EmployeeType.ITDepartment
                )
            {
                await _userManager.AddClaimAsync(user, new Claim(nameof(EmployeeType), employeeType));
            }

        }
    }
}
