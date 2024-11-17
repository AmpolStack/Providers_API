using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Providers_API.Models;

namespace Providers_API.DAL.DBContext;

public partial class ProvidersPlatformContext : DbContext
{
    public ProvidersPlatformContext()
    {
    }

    public ProvidersPlatformContext(DbContextOptions<ProvidersPlatformContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Active> Actives { get; set; }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<Commentary> Commentaries { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Active>(entity =>
        {
            entity.HasKey(e => e.ActiveId).HasName("PK__Active__F89858215C8B7AF8");

            entity.ToTable("Active");

            entity.Property(e => e.ActiveId).HasColumnName("active_id");
            entity.Property(e => e.ActiveName)
                .HasMaxLength(150)
                .HasColumnName("active_name");
            entity.Property(e => e.ActiveType)
                .HasMaxLength(50)
                .HasColumnName("active_type");
            entity.Property(e => e.ProductCode)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("product_code");
            entity.Property(e => e.ShippingMethod)
                .HasMaxLength(100)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("shipping_method");
        });

        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.ActivityId).HasName("PK__Activity__482FBD63CD597765");

            entity.ToTable("Activity");

            entity.Property(e => e.ActivityId).HasColumnName("activity_id");
            entity.Property(e => e.ActivityName)
                .HasMaxLength(150)
                .HasColumnName("activity_name");
            entity.Property(e => e.ActivityType)
                .HasMaxLength(50)
                .HasColumnName("activity_type");
            entity.Property(e => e.CiiuCode).HasColumnName("CIIU_code");
        });

        modelBuilder.Entity<Commentary>(entity =>
        {
            entity.HasKey(e => new { e.PostId, e.UserId }).HasName("PK__Commenta__D54C6416C00F9E17");

            entity.ToTable("Commentary");

            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Assessment).HasColumnName("assessment");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(200)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("image_Url");
            entity.Property(e => e.Text)
                .HasMaxLength(300)
                .HasColumnName("text");

            entity.HasOne(d => d.Post).WithMany(p => p.Commentaries)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Commentar__post___4AB81AF0");

            entity.HasOne(d => d.User).WithMany(p => p.Commentaries)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Commentar__user___4BAC3F29");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__Contact__024E7A86F1D1B110");

            entity.ToTable("Contact");

            entity.Property(e => e.ContactId).HasColumnName("contact_id");
            entity.Property(e => e.ContactDescription)
                .HasMaxLength(100)
                .HasColumnName("contact_description");
            entity.Property(e => e.ContactType)
                .HasMaxLength(50)
                .HasColumnName("contact_type");
            entity.Property(e => e.ProviderId).HasColumnName("provider_id");
            entity.Property(e => e.Value)
                .HasMaxLength(100)
                .HasColumnName("value");

            entity.HasOne(d => d.Provider).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Contact__provide__3C69FB99");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__Post__3ED787668A487740");

            entity.ToTable("Post");

            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Description)
                .HasMaxLength(300)
                .HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(200)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("image_Url");
            entity.Property(e => e.ProviderId).HasColumnName("provider_id");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");

            entity.HasOne(d => d.Provider).WithMany(p => p.Posts)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Post__provider_i__45F365D3");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.ProviderId).HasName("PK__Provider__00E213106FFF78AE");

            entity.ToTable("Provider");

            entity.Property(e => e.ProviderId).HasColumnName("provider_id");
            entity.Property(e => e.AssociationPrefix)
                .HasMaxLength(20)
                .HasColumnName("Association_prefix");
            entity.Property(e => e.EntityName)
                .HasMaxLength(100)
                .HasColumnName("entity_name");
            entity.Property(e => e.Nit).HasColumnName("NIT");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Providers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Provider__user_i__398D8EEE");

            entity.HasMany(d => d.Actives).WithMany(p => p.Providers)
                .UsingEntity<Dictionary<string, object>>(
                    "ProviderActive",
                    r => r.HasOne<Active>().WithMany()
                        .HasForeignKey("ActiveId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Provider___activ__534D60F1"),
                    l => l.HasOne<Provider>().WithMany()
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Provider___provi__52593CB8"),
                    j =>
                    {
                        j.HasKey("ProviderId", "ActiveId").HasName("PK__Provider__0F6B96923D6A42A9");
                        j.ToTable("Provider_Active");
                        j.IndexerProperty<int>("ProviderId").HasColumnName("provider_id");
                        j.IndexerProperty<int>("ActiveId").HasColumnName("active_id");
                    });

            entity.HasMany(d => d.Activities).WithMany(p => p.Providers)
                .UsingEntity<Dictionary<string, object>>(
                    "ProviderActivity",
                    r => r.HasOne<Activity>().WithMany()
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Provider___activ__4222D4EF"),
                    l => l.HasOne<Provider>().WithMany()
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Provider___provi__412EB0B6"),
                    j =>
                    {
                        j.HasKey("ProviderId", "ActivityId").HasName("PK__Provider__2460E8C6CF2137E5");
                        j.ToTable("Provider_Activity");
                        j.IndexerProperty<int>("ProviderId").HasColumnName("provider_id");
                        j.IndexerProperty<int>("ActivityId").HasColumnName("activity_id");
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__B9BE370FE01A48BC");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Address)
                .HasMaxLength(120)
                .HasColumnName("address");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.UserType)
                .HasMaxLength(20)
                .HasColumnName("user_type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
