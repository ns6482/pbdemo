using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace Pb.WebApi.Controllers
{
    /// <summary>
    /// Base class to provide standard functions for controllers, for e.g. get user name
    /// </summary>
    public abstract class BaseController : ApiController
    {
        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <returns></returns>
        protected string GetUserName()
        {
            var identity = User.Identity as ClaimsIdentity;

            if (identity == null) return "";

            var name = identity.Claims.First(c => c.Type == "sub").Value;
            return name;
        }
    }
}