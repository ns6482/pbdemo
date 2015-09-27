using System.Data.Entity.Validation;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PbDemo.Authorisation.Database;
using PbDemo.Authorisation.Models;

namespace PbDemo.Authorisation.Repositories
{
    /// <summary>
    /// Authorisation repo, Identity is larger thing, I only want a few methods
    /// </summary>
    public class AuthorisationRepository : IAuthorisationRepository
    {
        /// <summary>
        /// The _CTX
        /// </summary>
        private readonly AuthorisationContext _ctx;

        /// <summary>
        /// The _user manager
        /// </summary>
        private readonly UserManager<IdentityUser> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorisationRepository"/> class.
        /// </summary>
        public AuthorisationRepository()
        {
            _ctx = new AuthorisationContext();

            //again to save time using Identity's UserManager class, ideally we would have our own user authenticator, for e.g. would need to check how many times password is hashed (OWASP guidelines suggest hashing a couple of times)
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
            //userManager is enough to find or create a user
        }

        /// <summary>
        /// Finds the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            var user = await _userManager.FindAsync(userName, password);
            return user;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            //cleanup after ourselves
            _ctx.Dispose();
            _userManager.Dispose();
        }

        /// <summary>
        /// Registers the buyer.
        /// </summary>
        /// <param name="buyerModel">The buyer model.</param>
        /// <returns></returns>
        public async Task<IdentityResult> RegisterBuyer(UserModel buyerModel)
        {
            return await RegisterUser(buyerModel, "buyer"); //todo const
        }

        /// <summary>
        /// Registers the seller.
        /// </summary>
        /// <param name="sellerModel">The seller model.</param>
        /// <returns></returns>
        public async Task<IdentityResult> RegisterSeller(UserModel sellerModel)
        {
            return await RegisterUser(sellerModel, "seller");
        }

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="userModel">The user model.</param>
        /// <param name="actorClaim">The actor claim.</param>
        /// <returns></returns>
        private async Task<IdentityResult> RegisterUser(UserModel userModel, string actorClaim)
        {
            try
            {
                var user = new IdentityUser
                {
                    UserName = userModel.UserName
                };

                var claim = new IdentityUserClaim {ClaimType = ClaimTypes.Actor, ClaimValue = actorClaim};
                claim.UserId = user.Id;

                user.Claims.Add(claim);
                var result = await _userManager.CreateAsync(user, userModel.Password);

                return result;
            }
            catch (DbEntityValidationException)
            {
                return IdentityResult.Failed();
            }
        }
    }
}