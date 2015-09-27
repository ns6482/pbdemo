using System.Collections.Generic;

namespace Pb.WebApi.Models.ResponseModels
{
    /// <summary>
    /// DTO typically used when returning a list of houses
    /// </summary>
    public class HousesResponseModel
    {
        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        /// <value>
        /// The results.
        /// </value>
        public IEnumerable<HouseResponseModel> Results { get; set; }
    }
}