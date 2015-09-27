using System.Data.Entity;
using System.Threading.Tasks;
using Pb.WebApi.Entities;

namespace Pb.WebApi.Database
{
    public interface IHouseContext
    {
        DbSet<House> Houses { get; set; }
        DbSet<Offer> Offers { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}