using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.AspNet.Identity;
using PbDemo.Authorisation.Enums;
using PbDemo.Authorisation.Models;
using PbDemo.Authorisation.Repositories;


namespace PbDemo.Authorisation.Controllers
{
    /// <summary>
    /// Controller for registering users, sellers and buyers
    /// </summary>
    [RoutePrefix("api/User")]
    //[EnableCors(origins: "http://localhost:32822", headers: "*", methods: "*")]
 
    public class UserController : ApiController
    {
        /// <summary>
        /// The _repo
        /// </summary>
        private readonly AuthorisationRepository _repo; //TODO inject this, use IAuthorisationRepsitory

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>

        public UserController()
        {
            _repo = new AuthorisationRepository();
        }

        /// <summary>
        /// Registers the buyer.
        /// </summary>
        /// <param name="userModel">The user model.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("Register/Buyer")]
        [HttpPost]
        public async Task<IHttpActionResult> RegisterBuyer(UserModel userModel)
        {
            return await Register(userModel, UserType.Buyer);
        }

        /// <summary>
        /// Registers the seller.
        /// </summary>
        /// <param name="userModel">The user model.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("Register/Seller")]
        [HttpPost]
        public async Task<IHttpActionResult> RegisterSeller(UserModel userModel)
        {
            return await Register(userModel, UserType.Seller);
        }

        /// <summary>
        /// Registers the specified user model.
        /// </summary>
        /// <param name="userModel">The user model.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        private async Task<IHttpActionResult> Register(UserModel userModel, UserType type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result;

            if (type == UserType.Buyer)
                result = await _repo.RegisterBuyer(userModel);
            else
                result = await _repo.RegisterSeller(userModel);

            var errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        /// <summary>
        /// Releases the unmanaged resources that are used by the object and, optionally, releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }

        #region private

        //todo put this in generic error handling class, i.e. infrastructure
        /// <summary>
        /// Gets the error result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }

    #endregion private
}