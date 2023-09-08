using Microsoft.EntityFrameworkCore;

namespace BulkyWebYoutube.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options )
        {
            
        }
    }
}
