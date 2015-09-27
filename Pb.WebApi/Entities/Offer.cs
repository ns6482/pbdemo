using System;

namespace Pb.WebApi.Entities
{
    /// <summary>
    /// Database entity for offer
    /// </summary>
    public class Offer
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int ID { get; set; }
        /// <summary>
        /// Gets or sets the buyer identifier.
        /// </summary>
        /// <value>
        /// The buyer identifier.
        /// </value>
        public string BuyerId { get; set; }
        /// <summary>
        /// Gets or sets the buyer.
        /// </summary>
        /// <value>
        /// The buyer.
        /// </value>
        public string Buyer { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public int Amount { get; set; }
        /// <summary>
        /// Gets or sets the offer date.
        /// </summary>
        /// <value>
        /// The offer date.
        /// </value>
        public DateTime OfferDate { get; set; }
        /// <summary>
        /// Gets or sets the house.
        /// </summary>
        /// <value>
        /// The house.
        /// </value>
        public House House { get; set; }
        /// <summary>
        /// Gets or sets the number chains buyer.
        /// </summary>
        /// <value>
        /// The number chains buyer.
        /// </value>
        public int NumChainsBuyer { get; set; }
        //you might think just accept the highest offer, having no chain could be appealing? So I would imagine the seller would want to decide which offer to accept
    }
}