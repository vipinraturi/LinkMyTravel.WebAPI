using LinkMyTravel.Model;
using LinkMyTravel.WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace LinkMyTravel.Data
{
    public class LinkMyTravelContext:DbContext
	{
		public LinkMyTravelContext(DbContextOptions<LinkMyTravelContext> options)
            :base(options) { }
		public LinkMyTravelContext() { }
		public DbSet<StudentMasters> StudentMasters { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
