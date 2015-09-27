using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pb.WebApi.Entities
{
    /// <summary>
    /// Database entity for House
    /// </summary>
    public class House
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int ID { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int Value { get; set; }
        /// <summary>
        /// Gets or sets the owner identifier.
        /// </summary>
        /// <value>
        /// The owner identifier.
        /// </value>
        public string OwnerId { get; set; }
        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>
        /// The owner.
        /// </value>
        public string Owner { get; set; }

        /// <summary>
        /// Gets or sets the listed.
        /// </summary>
        /// <value>
        /// The listed.
        /// </value>
        [Required]
        public DateTime Listed { get; set; }

        /// <summary>
        /// Gets or sets the accepted offer.
        /// </summary>
        /// <value>
        /// The accepted offer.
        /// </value>
        public int? AcceptedOffer { get; set; }
        /// <summary>
        /// Gets or sets the accepted.
        /// </summary>
        /// <value>
        /// The accepted.
        /// </value>
        public DateTime? Accepted { get; set; }

        /// <summary>
        /// Gets or sets the offers.
        /// </summary>
        /// <value>
        /// The offers.
        /// </value>
        public virtual ICollection<Offer> Offers { get; set; }
    }
}