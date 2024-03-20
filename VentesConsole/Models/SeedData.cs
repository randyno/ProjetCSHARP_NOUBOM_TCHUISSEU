using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VentesConsole.Data;
using System;
using System.Linq;
namespace VentesConsole.Models;
public static class SeedData // Ajout d’une nouvelle classe SeedData dans Models pour créer la base et ajouter un film si besoin
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new VentesConsoleContext(
        serviceProvider.GetRequiredService<
        DbContextOptions<VentesConsoleContext>>()))
        {
           // context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            // S’il y a déjà des films dans la base
            if (context.Manufacturer.Any())
            {
                return; // On ne fait rien
            }
            // Sinon on en ajoute un
            context.Manufacturer.AddRange(
            new Manufacturer
            {
                Name = "Sony",
                Country = "Japan"
            }
            );
            context.SaveChanges();
        }
    }
}