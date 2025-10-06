using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;

namespace Chateeo.API.Infrastructure
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<ChatModel> Chats { get; set; }
    }

}
