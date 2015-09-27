using System.ComponentModel.DataAnnotations;

namespace Pb.WebApi.Models.RequestCommands
{
    /// <summary>
    /// Used typically creating a new house
    /// </summary>
    public class HouseRequestModel
    {
        //probably put a some more validations here
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [Required]
        public int Value { get; set; }
    }
}