using Pb.WebApi.Entities;

namespace Pb.WebApi.Models.ResponseModels
{
    /// <summary>
    /// DTO, typically used when returning an offer
    /// </summary>
    public class OfferResponseModel
    {
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public Offer Result { get; set; }
    }
}