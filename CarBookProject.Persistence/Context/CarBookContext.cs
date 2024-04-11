using CarBook.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarBookProject.Persistence.Context
{
    public class CarBookContext : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CarBookDb;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Reservation>()
                .HasOne(x => x.PickupLocation)
                .WithMany(y => y.PickUpReservations)
                .HasForeignKey(x => x.PickupLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Reservation>()
                .HasOne(x => x.DropOffLocation)
                .WithMany(y => y.DropOffReservations)
                .HasForeignKey(x => x.DropOffLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

			//Reservation
			modelBuilder.Entity<Reservation>()
				.HasOne(p => p.AppUser)
				.WithMany(u => u.Reservations)
				.HasForeignKey(p => p.AppUserId)
				.OnDelete(DeleteBehavior.Restrict);

            //Payment
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.AppUser)
                .WithMany(u => u.Payments)
                .HasForeignKey(p => p.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Reservation)
                .WithMany(u => u.Payments)
                .HasForeignKey(p => p.ReservationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            //Invoices
            modelBuilder.Entity<Invoice>()
				.HasOne(i => i.AppUser)
				.WithMany(p => p.Invoices)
				.HasForeignKey(p => p.AppUserId)
				.OnDelete(DeleteBehavior.Restrict);
		}

		public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarDescription> CarDescriptions { get; set; }
        public DbSet<CarFeature> CarFeatures { get; set; }
        public DbSet<CarPricing> CarPricings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FooterAddress> FooterAddresses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<DropOffLocation> DropOffLocations { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<RentACar> RentACars { get; set; }
        public DbSet<RentACarProcess> RentACarProcesses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }
}
