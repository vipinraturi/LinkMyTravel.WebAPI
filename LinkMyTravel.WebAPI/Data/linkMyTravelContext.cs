using LinkMyTravel.Model;
using LinkMyTravel.WebAPI.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LinkMyTravel.Data
{
    public class LinkMyTravelContext: IdentityDbContext<AppUser>
    {
		public LinkMyTravelContext(DbContextOptions<LinkMyTravelContext> options)
            :base(options) {
        }

        public DbSet<StudentMasters> StudentMasters { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
