using Microsoft.EntityFrameworkCore;
using TituloEmAtraso.Models;

namespace TituloEmAtraso.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    public DbSet<TituloAtraso> TituloAtraso { get; set; }
    public DbSet<Parcela> Parcela { get; set; }
  }
}