using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebApplicationMVC.Data;

namespace WebApplicationMVC.Models
{
    public static class SeenData
    {
        public static void Intialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebApplicationMVCContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<WebApplicationMVCContext>>()))
            {
                context.VinylRecord.AddRange(
                    new VinylRecord
                    { 
                        Artist = "Warren Zevon",
                        Album = "Excitable Boy",
                        Label = "Asylum Records",
                        RealeaseDate = DateTime.Parse("1978-12-12")
                    },
                    new VinylRecord
                    {
                        Artist = "Ry Cooder",
                        Album = "Borderline",
                        Label = "Warner Bros.",
                        RealeaseDate = DateTime.Parse("1980-10-10")
                    }
                );
                context.SaveChanges();
            }

        }
    }
}
