using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EnventosDB.MVC.Data;

public partial class EventosVivoContext : DbContext
{
    public EventosVivoContext(DbContextOptions<EventosVivoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Guest> Guests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Guests__3214EC07048BC2FA");

            entity.HasIndex(e => e.Contact, "UQ__Guests__F7C04665ED2A9692").IsUnique();

            entity.Property(e => e.Contact).HasMaxLength(13);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_at");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime")
                .HasColumnName("Deleted_at");
            entity.Property(e => e.GuestName).HasMaxLength(150);
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Updated_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
