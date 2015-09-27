using System.Collections.Generic;
using Pb.WebApi.Entities;

namespace Pb.WebApi.Models.ResponseModels
{
    /// <summary>
    /// DTO return an array of offers
    /// </summary>
    public class OffersResponseModel
    {
        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        /// <value>
        /// The results.
        /// </value>
        public IEnumerable<Offer> Results { get; set; }
    }
}