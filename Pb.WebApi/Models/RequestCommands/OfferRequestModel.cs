using System.ComponentModel.DataAnnotations;

namespace Pb.WebApi.Models.RequestCommands
{
    /// <summary>
    /// DTO, used typically when creating a new offer
    /// </summary>
    public class OfferRequestModel
    {
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        [Required]
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets the number chains buyer.
        /// </summary>
        /// <value>
        /// The number chains buyer.
        /// </value>
        [Required]
        public int NumChainsBuyer { get; set; }
    }
}