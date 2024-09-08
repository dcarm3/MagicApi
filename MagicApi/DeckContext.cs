using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class DeckContext : DbContext {
    private readonly IConfiguration _configuration;

    public DeckContext(IConfiguration configuration) {
        _configuration = configuration;
    }

    public DbSet<Deck> Decks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);
    }
}

public class Deck {
    public int Id { get; set; }
    public string CommanderId { get; set; }
    public string Cards { get; set; } 
}
