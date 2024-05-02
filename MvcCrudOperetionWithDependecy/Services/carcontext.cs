using Microsoft.EntityFrameworkCore;
using MvcCrudOperetionWithDependecy.Entities;

namespace MvcCrudOperetionWithDependecy.Services
{
    public class carcontext:DbContext
    {

        public carcontext(DbContextOptions options) : base(options)
        {


        }
        public DbSet<Car> cars {get; set;}
    }
}
