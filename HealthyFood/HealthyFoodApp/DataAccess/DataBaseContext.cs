using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<HealthyFood> HealthyFood { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<HealthyFoodOrderItem> HealthyFoodOrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<HealthyFood>(x => x.ToTable("HealthyFood"));
            builder.Entity<Order>(x => x.ToTable("Order"));
            builder.Entity<Location>(x => x.ToTable("Location"));
            builder.Entity<HealthyFoodOrderItem>(x => x.ToTable("HealthyFoodOrderItem"));

            builder.Entity<HealthyFood>().HasData
            (
                new HealthyFood("penne", " salmon steaks,  mushroom , pine nut", "https://images.immediate.co.uk/production/volatile/sites/30/2020/08/recipe-image-legacy-id-1244455_7-e831545.jpg?resize=960,872?quality=90&webp=true&resize=300,272",  300) { Id = 1 },
                new HealthyFood("Tuna spaghetti", "red chilli, ,tuna , spinach ", "https://images.immediate.co.uk/production/volatile/sites/30/2020/10/Tuna-Caper-Chilli-Spaghetti-0d409ad.jpg?resize=960,872?quality=90&webp=true&resize=300,272", 500) { Id = 2 },
                new HealthyFood("Vegan burger", "chickpeas , pitta bread , Tomato ", "https://images.immediate.co.uk/production/volatile/sites/30/2020/08/vegan-burger-f4eb0ad.jpg?resize=960,872?quality=90&webp=true&resize=300,272", 460) { Id = 3 },
                new HealthyFood("Omelette pancakes", "Garlic , Egg , Tomato ", "https://images.immediate.co.uk/production/volatile/sites/30/2020/08/omelette-pancakes-with-tomato-pepper-sauce-557a351.jpg?resize=960,872?quality=90&webp=true&resize=300,272", 350) { Id = 4 },
                new HealthyFood("avocado wraps", "chicken breast , Tomato , Avocado ", "https://images.immediate.co.uk/production/volatile/sites/30/2020/08/spicychickenavocadowraps_5865-4035909.jpg?resize=960,872?quality=90&webp=true&resize=300,272", 200) { Id = 5 },
                new HealthyFood(" broccoli salad", "Broccoli , nigella seeds , Tomato ", "https://images.immediate.co.uk/production/volatile/sites/30/2020/08/chicken-broccoli-beetroot-salad-with-avocado-pesto-5f17f37.jpg?resize=960,872?quality=90&webp=true&resize=300,272", 480) { Id = 6 },
                new HealthyFood("ham omelette", "onion , Egg , Tomato ", "https://images.immediate.co.uk/production/volatile/sites/30/2022/03/Healthy-pepper-ham-omelette-f80d4d4.jpg?resize=960,872?quality=90&webp=true&resize=300,272", 600) { Id = 7 },
                new HealthyFood("Burrito bowl", "Avocado , Egg , honey ", "https://images.immediate.co.uk/production/volatile/sites/30/2020/08/burrito-bowl-3629880.jpg?resize=960,872?quality=90&webp=true&resize=300,272", 400) { Id = 8 }
            );


            builder.Entity<Location>().HasData
            (
                new Location("Fresh Kitchen", "record", 8, 22) { Id = 1 },
                new Location("Fresh Kitchen", "Gligor Prlicev", 8, 22) { Id = 2 },
                new Location("Fresh Kitchen", "Kiril Pejcinovski", 8, 22) { Id = 3 },
                new Location("Fresh Kitchen", "Ilindenska", 8, 22) { Id = 4 }
           );
        }
    }
}
