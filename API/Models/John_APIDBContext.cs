using Microsoft.EntityFrameworkCore;
namespace API.Models
{
  public class John_APIDBContext : DbContext
  {
    public John_APIDBContext()
    {
    }

    public John_APIDBContext(DbContextOptions<John_APIDBContext> options)
        : base(options)
    {
    }
  }
}
