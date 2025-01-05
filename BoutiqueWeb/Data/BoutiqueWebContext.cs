using BoutiqueWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BoutiqueWeb.Data;

public class BoutiqueWebContext : DbContext
{
  public DbSet<Client> Clients { get; set; } = null!;
  public DbSet<Produit> Produits { get; set; } = null!;
  public DbSet<Commande> Commandes { get; set; } = null!;
  public string DbPath { get; private set; }


  public BoutiqueWebContext()
  {
    // Path to SQLite database file
    DbPath = "EFBoutiqueWeb.db";
  }


  // The following configures EF to create a SQLite database file locally
  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    // Use SQLite as database
    options.UseSqlite($"Data Source={DbPath}");
    // Optional: log SQL queries to console
    //options.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
  }
}
