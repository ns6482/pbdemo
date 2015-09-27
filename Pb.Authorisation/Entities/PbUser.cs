using Microsoft.AspNet.Identity.EntityFramework;

namespace PbDemo.Authorisation.Entities
{
    /// <summary>
    /// Database User
    /// </summary>
    public class PbUser : IdentityUser
    {
        /// <summary>
        /// Gets or sets the type of the user.
        /// </summary>
        /// <value>
        /// The type of the user.
        /// </value>
        public string UserType { get; set; }
    }
}