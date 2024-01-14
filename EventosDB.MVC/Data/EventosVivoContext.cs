using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EventosDB.MVC.Data;

public partial class EventosVivoContext : DbContext
{
    public EventosVivoContext(DbContextOptions<EventosVivoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventHost> EventHosts { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<GuestType> GuestTypes { get; set; }

    public virtual DbSet<Invitation> Invitations { get; set; }

    public virtual DbSet<InvitationType> InvitationTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Events__3214EC078053B3EA");

            entity.Property(e => e.Dates).HasMaxLength(300);
            entity.Property(e => e.Description).HasMaxLength(1000);

            entity.HasOne(d => d.EventHost).WithMany(p => p.Events)
                .HasForeignKey(d => d.EventHostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Events__EventHos__534D60F1");
        });

        modelBuilder.Entity<EventHost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EventHos__3214EC071C068F04");

            entity.ToTable("EventHost");

            entity.HasIndex(e => e.Name, "UQ__EventHos__737584F60C32F8E6").IsUnique();

            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(250);
        });

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
            entity.Property(e => e.GuestTypeId).HasDefaultValueSql("((1))");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Updated_at");

            entity.HasOne(d => d.GuestType).WithMany(p => p.Guests)
                .HasForeignKey(d => d.GuestTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Guests__GuestTyp__4AB81AF0");
        });

        modelBuilder.Entity<GuestType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GuestTyp__3214EC0732FD5C49");

            entity.ToTable("GuestType");

            entity.Property(e => e.Designation).HasMaxLength(250);
        });

        modelBuilder.Entity<Invitation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Invitati__3214EC07CEDC86A2");

            entity.ToTable("Invitation");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_at");

            entity.HasOne(d => d.EventHost).WithMany(p => p.Invitations)
                .HasForeignKey(d => d.EventHostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invitatio__Event__5AEE82B9");

            entity.HasOne(d => d.Event).WithMany(p => p.Invitations)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invitatio__Event__59FA5E80");

            entity.HasOne(d => d.InvitationType).WithMany(p => p.Invitations)
                .HasForeignKey(d => d.InvitationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invitatio__Invit__5BE2A6F2");
        });

        modelBuilder.Entity<InvitationType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Invitati__3214EC07FC603E76");

            entity.ToTable("InvitationType");

            entity.HasIndex(e => e.Designation, "UQ__Invitati__5638C9D7CA2C89CB").IsUnique();

            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Designation).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
