using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Pb.WebApi.Database;
using Pb.WebApi.Entities;
using Pb.WebApi.Infrastructure;
using Pb.WebApi.Models.RequestCommands;
using Pb.WebApi.Models.ResponseModels;

namespace Pb.WebApi.Controllers
{
    /// <summary>
    /// Controller for House resource, to view, sell, buy or make an offer on one
    /// </summary>
    [RoutePrefix("api/House")]
    public class HouseController : BaseController
    {
        #region private declaration

        /// <summary>
        /// The _house context
        /// </summary>
        private readonly IHouseContext _houseContext; //will be injected

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HouseController"/> class.
        /// </summary>
        public HouseController()
        {
            _houseContext = new HouseContext();
        }

        #endregion

        //dtos are important here other json will not serialize, circular object graph

        #region public methods

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Houses")]
        [AuthoriseUserType(UserType = "buyer")]
        public HousesResponseModel Get()
        {
            //could use automapper here, bit annoying 

            var houses = _houseContext.Houses.Select(h => new HouseResponseModel
            {
                Id = h.ID,
                Accepted = h.Accepted,
                AcceptedOffer = h.AcceptedOffer,
                Description = h.Description,
                Listed = h.Listed,
                Owner = h.Owner,
                Title = h.Title,
                Offers = h.Offers
            });

            var result = new HousesResponseModel {Results = houses};
            return result;
        }

        /// <summary>
        /// Creates the specified create house command.
        /// </summary>
        /// <param name="createHouseCommand">The create house command.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Sell")]
        [AuthoriseUserType(UserType = "seller")]
        [ValidateModel]
        public async Task<IHttpActionResult> Create(HouseRequestModel createHouseCommand)
        {
            var name = GetUserName();

            var house = new House
            {
                Description = createHouseCommand.Description,
                Title = createHouseCommand.Title,
                Owner = name,
                Value = createHouseCommand.Value,
                Listed = DateTime.Now
            };

            _houseContext.Houses.Add(house);
            await _houseContext.SaveChangesAsync();

            return Ok();
        }


        /// <summary>
        /// Owners the houses.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("owners")]
        [AuthoriseUserType(UserType = "seller")]
        public HousesResponseModel OwnerHouses()
        {
            var name = GetUserName();
            var sellersHouses = _houseContext.Houses.Select(h => new HouseResponseModel
            {
                Id = h.ID,
                Accepted = h.Accepted,
                AcceptedOffer = h.AcceptedOffer,
                Description = h.Description,
                Listed = h.Listed,
                Owner = h.Owner,
                Title = h.Title,
                Offers = h.Offers
            }).Where(h => h.Owner == name);

            var response = new HousesResponseModel {Results = sellersHouses.ToList()};
            return response;
        }

        /// <summary>
        /// Offers the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}/offer")]
        [AuthoriseUserType(UserType = "buyer")]
        [ValidateModel]
        public async Task<IHttpActionResult> Offer(int id, OfferRequestModel model)
        {
            //find the house
            var house = await _houseContext.Houses.FindAsync(id);

            //get name of logged in user
            var name = GetUserName();

            //add offer to house
            house.Offers.Add(new Offer
            {
                Amount = model.Amount,
                Buyer = name,
                NumChainsBuyer = model.NumChainsBuyer,
                OfferDate = DateTime.Now
            });

            await _houseContext.SaveChangesAsync();

            //make offer on house
            return Ok();
        }

        #endregion

        #region private functions

        #endregion
    }
}