using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Get_Rhythm
{
    class Get_RhythmContext : DbContext
    {
        // Map the Band class to the Band table in the database
        public DbSet<Band> Band { get; set; }

        // Map the Album class to the Album table in the database
        public DbSet<Album> Album { get; set; }

        // Map the Song class to the Song table in the database
        public DbSet<Song> Song { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;database=BandDatabase");
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }
    }
}