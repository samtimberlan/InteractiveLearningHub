using InteractiveLearningHub.Auth.Claims;
using InteractiveLearningHub.Core.Abstractions;
using InteractiveLearningHub.Infrastructure.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InteractiveLearningHub.Auth
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly InteractiveLearningHubDbContext _context;
        private readonly IConfiguration _configuration;
        public UserService(IHttpContextAccessor httpContext, InteractiveLearningHubDbContext context, IConfiguration configuration)
        {
            _httpContext = httpContext;
            _context = context;
            _configuration = configuration;
        }
        public string GetIdentityUserId()
        {
            if (_httpContext.HttpContext.User.Identity.IsAuthenticated)
            {
                string userId = String.Empty;
                string claimName = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
                if (_httpContext.HttpContext.User.HasClaim(claim => claim.Type == claimName))
                {
                    userId = _httpContext.HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == claimName).Value;
                }
                return userId;
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        public string GetIdentityUserFullName()
        {
            if (_httpContext.HttpContext.User.Identity.IsAuthenticated)
            {
                string userFullName = String.Empty;
                string claimName = "name";
                if (_httpContext.HttpContext.User.HasClaim(claim => claim.Type == claimName))
                {
                    userFullName = _httpContext.HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == claimName).Value;
                }
                return userFullName;
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        public Guid GetLocalUserIdByIdentityId(string identityId)
        {
            return _context.ApplicationUsers.FirstOrDefault(user => user.IdentityUserId == identityId).Id;
        }
    }
}
