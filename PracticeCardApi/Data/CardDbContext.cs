using Microsoft.EntityFrameworkCore;
using PracticeCardApi.Models;

namespace PracticeCardApi.Data
{
    public class CardDbContext : DbContext
    {
        public CardDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Card> cards { get; set; }

    }
}
