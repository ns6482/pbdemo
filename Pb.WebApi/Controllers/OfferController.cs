using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Pb.WebApi.Database;
using Pb.WebApi.Infrastructure;

namespace Pb.WebApi.Controllers
{
    /// <summary>
    /// Class for Offer resource, for now just to accept an offer, but other functions could follow
    /// </summary>
    [RoutePrefix("api/Offer")]
    public class OfferController : BaseController
    {
        #region private declaration

        /// <summary>
        /// The _house context
        /// </summary>
        private readonly IHouseContext _houseContext; //will be injected

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OfferController"/> class.
        /// </summary>
        public OfferController()
        {
            _houseContext = new HouseContext();
        }

        #endregion

        #region public methods

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}/accept")]
        [AuthoriseUserType(UserType = "seller")]
        public async Task<IHttpActionResult> Put(int id)
        {
            //get offer

            var offer = _houseContext.Offers.Include("House").SingleOrDefault(o => o.ID == id);

            var owner = GetUserName();

            //logic that doesn't belong in the controller, probably should be in the business domain namespace
            //in case someone other than the owner tries to accept somebody elses offer, or offer accepted already
            if (offer != null && (offer.House.Owner != owner || offer.House.Accepted != null))
            {
                //could not find offer for current user
                return NotFound();
            }

            //update house to say offer accepted
            if (offer != null)
            {
                var house = offer.House;
                house.AcceptedOffer = offer.ID;
                house.Accepted = DateTime.Now;

                await _houseContext.SaveChangesAsync();
            }


            return Ok();
        }

        //possible that other REST actions could go here, for example
        //delete to cancel offer
        //get to see details of an offer
        //get colletion of all offers (useful for admin screen)

        #endregion
    }
}