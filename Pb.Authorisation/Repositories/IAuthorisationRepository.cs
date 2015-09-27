using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PbDemo.Authorisation.Repositories
{
    /// <summary>
    /// Authorisation repo, Identity is larger thing, I only want a few methods
    /// </summary>
    internal interface IAuthorisationRepository : IDisposable
    {
        /// <summary>
        /// Finds the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        Task<IdentityUser> FindUser(string userName, string password); //assume password will be hashed, and encrypted
    }
}