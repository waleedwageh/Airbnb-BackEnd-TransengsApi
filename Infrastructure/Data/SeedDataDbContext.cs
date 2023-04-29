using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class SeedDataDbContext
    {
        public static async Task SeedData(ApplicationContext context,ILoggerFactory loggerFactory){
          try{
                if(!context.Property_Tybes.Any()){
                var propertytypesdata = File.ReadAllText("../Infrastructure/Data/SeedData/propertytypes.json");
                var propertytypes = JsonSerializer.Deserialize<List<property_tybe>>(propertytypesdata);
                foreach (var item in propertytypes)
                {
                    context.Property_Tybes.Add(item);
                }
               await context.SaveChangesAsync();
            }
                if (!context.Amenities.Any())
                {
                    var amenitiesdata = File.ReadAllText("../Infrastructure/Data/SeedData/Amenities.json");
                    var amenities = JsonSerializer.Deserialize<List<amenity>>(amenitiesdata);
                    foreach (var item in amenities)
                    {
                        context.Amenities.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
          catch(Exception ex){
              var logger = loggerFactory.CreateLogger<SeedDataDbContext>();
              logger.LogError(ex.Message);
          }
        }
    }
}