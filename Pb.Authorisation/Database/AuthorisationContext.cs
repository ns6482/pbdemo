using Microsoft.AspNet.Identity.EntityFramework;

namespace PbDemo.Authorisation.Database
{
    //see http://odetocode.com/blogs/scott/archive/2014/01/03/asp-net-identity-with-the-entity-framework.aspx
    //by inheriting the IdentityDBContext EF can map identity dbsets ==> database tables, probably would avoid identiy in the real world due to limiations, for e.g. confirm password properties. Probably use a custom dbcontext from scratch.
    /// <summary>
    /// Db for authorisation
    /// </summary>
    public class AuthorisationContext : IdentityDbContext<IdentityUser>, IAuthorisationContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorisationContext"/> class.
        /// </summary>
        public AuthorisationContext()
            : base("AuthorisationContext") //super constructor call, connection strnig will identify by value passed in
        {
        }
    }
}