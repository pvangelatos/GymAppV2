using GymAppV2.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GymAppV2.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Member> Members { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<GymProgram> GymPrograms { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Member>(e =>
            {
                e.HasIndex(m => m.Email).IsUnique();
                e.Property(m => m.Email).HasMaxLength(256).IsRequired();
                e.Property(m => m.Firstname).HasMaxLength(100).IsRequired();
                e.Property(m => m.Lastname).HasMaxLength(100).IsRequired();
                e.Property(m => m.Phone).HasMaxLength(20);
            });

            builder.Entity<Trainer>(e =>
            {
                e.HasIndex(t => t.Email).IsUnique();
                e.Property(t => t.Email).HasMaxLength(256).IsRequired();
                e.Property(t => t.Firstname).HasMaxLength(100).IsRequired();
                e.Property(t => t.Lastname).HasMaxLength(100).IsRequired();
                e.Property(t => t.Specialization).HasMaxLength(200);
            });

            builder.Entity<GymProgram>(e =>
            {
                e.Property(p => p.Name).HasMaxLength(200).IsRequired();
                e.Property(p => p.Description).HasMaxLength(1000);
                e.HasOne(p => p.Trainer)
                    .WithMany(t => t.Programs)
                    .HasForeignKey(p => p.TrainerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<TimeSlot>(e =>
            {
                e.HasOne(ts => ts.GymProgram)
                    .WithMany(p => p.TimeSlots)
                    .HasForeignKey(ts => ts.GymProgramId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Booking>(e =>
            {
                e.Property(b => b.Status).HasConversion<string>();
                e.HasOne(b => b.Member)
                    .WithMany(m => m.Bookings)
                    .HasForeignKey(b => b.MemberId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(b => b.TimeSlot)
                    .WithMany(ts => ts.Bookings)
                    .HasForeignKey(b => b.TimeSlotId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<SubscriptionPlan>(e =>
            {
                e.Property(p => p.Name).HasMaxLength(200).IsRequired();
                e.Property(p => p.Price).HasPrecision(10, 2);
            });

            builder.Entity<Subscription>(e =>
            {
                e.HasOne(s => s.Member)
                    .WithMany(m => m.Subscriptions)
                    .HasForeignKey(s => s.MemberId)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(s => s.Plan)
                    .WithMany()
                    .HasForeignKey(s => s.SubscriptionPlanId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Payment>(e =>
            {
                e.Property(p => p.Amount).HasPrecision(10, 2);
                e.Property(p => p.Method).HasConversion<string>();
                e.HasOne(p => p.Subscription)
                    .WithMany()
                    .HasForeignKey(p => p.SubscriptionId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
