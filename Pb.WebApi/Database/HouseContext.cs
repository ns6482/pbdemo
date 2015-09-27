using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Pb.WebApi.Entities;

namespace Pb.WebApi.Database
{
    /// <summary>
    /// The database for the house app
    /// </summary>
    public class HouseContext : DbContext, IHouseContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HouseContext"/> class.
        /// </summary>
        public HouseContext() : base("name=HouseContext")
        {
        }

        /// <summary>
        /// Gets or sets the houses.
        /// </summary>
        /// <value>
        /// The houses.
        /// </value>
        public DbSet<House> Houses { get; set; }
        /// <summary>
        /// Gets or sets the offers.
        /// </summary>
        /// <value>
        /// The offers.
        /// </value>
        public DbSet<Offer> Offers { get; set; }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}