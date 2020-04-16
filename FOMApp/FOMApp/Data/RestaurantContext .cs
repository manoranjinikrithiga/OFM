using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SearchService.Models;

namespace SearchService.Data
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext (DbContextOptions<RestaurantContext > options) : base(options)
        {
        }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

        protected override void OnModelCreating
            (ModelBuilder builder)
        {
            builder.Entity<MenuItem>(ConfigureMenuItem);
            builder.Entity<Restaurant>(ConfigureRestaurant);
        }

            private void ConfigureMenuItem
           (EntityTypeBuilder<MenuItem> builder)
        {            
            builder.ToTable("MenuItems");
            builder.Property(c => c.Id)
                .ForSqlServerUseSequenceHiLo("menu_hilo")
                .IsRequired();
            builder.Property(c => c.DishName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c => c.Price)
                .IsRequired();
            
            builder.HasOne(c => c.Restaurant)
                .WithMany()
                .HasForeignKey(c => c.RestaurantId);

        }
        

        private void ConfigureRestaurant
          (EntityTypeBuilder<Restaurant> builder)
        {
            builder.ToTable("Restaurants");
            builder.Property(c => c.Id)
                .ForSqlServerUseSequenceHiLo("restaurant_hilo")
                .IsRequired();
            builder.Property(c => c.Location)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c => c.Distance)
               .IsRequired();
            builder.Property(c => c.Rating)
               .IsRequired();
            builder.Property(c => c.Cuisine)
                .IsRequired()
                .HasMaxLength(100);
    }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<MenuItem>().HasData(
        //        new MenuItem
        //        {
        //            Id = 1,
        //            DishName = "Mutton Briyani",
        //            Description = "Briyani cooked wiyj Mutton in dum.",
        //        },
        //        new MenuItem
        //        {
        //            Id = 2,
        //            DishName = "Parotta",
        //            Description = "Parotta made of Wheat.",
        //        },
        //        new MenuItem
        //        {
        //            Id = 3,
        //            DishName = "Mixed fried rice",
        //            Description = "Fried rice with praws ,egg, chicken and vegie. ",
        //        }
        //    );
        //}

    }    
}
