using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Models
{
    public partial class Flower_ServiceContext : DbContext
    {
        public Flower_ServiceContext()
        {
        }

        public Flower_ServiceContext(DbContextOptions<Flower_ServiceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DeliveryAddress> DeliveryAddresses { get; set; } = null!;
        public virtual DbSet<DeliveryCompany> DeliveryCompanies { get; set; } = null!;
        public virtual DbSet<DeliveryRoute> DeliveryRoutes { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Inventory> Inventories { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public virtual DbSet<Promotion> Promotions { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeliveryAddress>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("PK__Delivery__CAA247C80A33BB3A");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("postal_code");

                entity.Property(e => e.RecipientName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("recipient_name");

                entity.Property(e => e.RecipientPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("recipient_phone");

                entity.Property(e => e.StreetAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("street_address");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DeliveryAddresses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__DeliveryA__user___4E88ABD4");
            });

            modelBuilder.Entity<DeliveryCompany>(entity =>
            {
                entity.HasKey(e => e.CompanyId)
                    .HasName("PK__Delivery__3E267235224CC662");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("company_name");

                entity.Property(e => e.ContactName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("contact_name");

                entity.Property(e => e.ContactPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("contact_phone");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");
            });

            modelBuilder.Entity<DeliveryRoute>(entity =>
            {
                entity.HasKey(e => e.RouteId)
                    .HasName("PK__Delivery__28F706FE8FFF9983");

                entity.Property(e => e.RouteId).HasColumnName("route_id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.DeliveryStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("delivery_status");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.DeliveryRoutes)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__DeliveryR__compa__6383C8BA");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.DeliveryRoutes)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__DeliveryR__order__628FA481");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.EventDate)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("event_date");

                entity.Property(e => e.EventName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("event_name");

                entity.HasMany(d => d.Products)
                    .WithMany(p => p.Events)
                    .UsingEntity<Dictionary<string, object>>(
                        "EventProduct",
                        l => l.HasOne<Product>().WithMany().HasForeignKey("ProductId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__EventProd__produ__6EF57B66"),
                        r => r.HasOne<Event>().WithMany().HasForeignKey("EventId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__EventProd__event__6E01572D"),
                        j =>
                        {
                            j.HasKey("EventId", "ProductId").HasName("PK__EventPro__6700D0F8A431B40E");

                            j.ToTable("EventProducts");

                            j.IndexerProperty<int>("EventId").HasColumnName("event_id");

                            j.IndexerProperty<int>("ProductId").HasColumnName("product_id");
                        });
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.FeedbackId).HasColumnName("feedback_id");

                entity.Property(e => e.FeedbackDate)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("feedback_date");

                entity.Property(e => e.FeedbackText)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("feedback_text");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Feedback__user_i__5DCAEF64");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.LastUpdated)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("last_updated");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.QuantityInStock).HasColumnName("quantity_in_stock");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Inventory__produ__66603565");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.NotificationId).HasColumnName("notification_id");

                entity.Property(e => e.IsRead).HasColumnName("is_read");

                entity.Property(e => e.NotificationDate)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("notification_date");

                entity.Property(e => e.NotificationText)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("notification_text");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Notificat__user___71D1E811");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.DeliveryDate)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("delivery_date");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("order_date");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("total_amount");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Orders__user_id__47DBAE45");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.OrderItemId).HasColumnName("order_item_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("unit_price");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderItem__order__4AB81AF0");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__OrderItem__produ__4BAC3F29");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("card_number");

                entity.Property(e => e.CardholderName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("cardholder_name");

                entity.Property(e => e.ExpirationDate)
                    .HasColumnType("date")
                    .HasColumnName("expiration_date");

                entity.Property(e => e.SecurityCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("security_code");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PaymentMethods)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__PaymentMe__user___5165187F");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("image_url");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("product_name");

                entity.HasMany(d => d.Categories)
                    .WithMany(p => p.Products)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductCategoryMapping",
                        l => l.HasOne<ProductCategory>().WithMany().HasForeignKey("CategoryId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__ProductCa__categ__44FF419A"),
                        r => r.HasOne<Product>().WithMany().HasForeignKey("ProductId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__ProductCa__produ__440B1D61"),
                        j =>
                        {
                            j.HasKey("ProductId", "CategoryId").HasName("PK__ProductC__1A56936EA0FC0C36");

                            j.ToTable("ProductCategoryMapping");

                            j.IndexerProperty<int>("ProductId").HasColumnName("product_id");

                            j.IndexerProperty<int>("CategoryId").HasColumnName("category_id");
                        });
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__ProductC__D54EE9B4D4E5EB5A");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("category_name");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.Property(e => e.PromotionId).HasColumnName("promotion_id");

                entity.Property(e => e.DiscountPercentage)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("discount_percentage");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.PromotionName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("promotion_name");

                entity.Property(e => e.StartDate)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("start_date");

                entity.HasMany(d => d.Products)
                    .WithMany(p => p.Promotions)
                    .UsingEntity<Dictionary<string, object>>(
                        "PromoProduct",
                        l => l.HasOne<Product>().WithMany().HasForeignKey("ProductId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__PromoProd__produ__5AEE82B9"),
                        r => r.HasOne<Promotion>().WithMany().HasForeignKey("PromotionId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__PromoProd__promo__59FA5E80"),
                        j =>
                        {
                            j.HasKey("PromotionId", "ProductId").HasName("PK__PromoPro__68C972B4381FBC2B");

                            j.ToTable("PromoProducts");

                            j.IndexerProperty<int>("PromotionId").HasColumnName("promotion_id");

                            j.IndexerProperty<int>("ProductId").HasColumnName("product_id");
                        });
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.ReviewId).HasColumnName("review_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.ReviewDate)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("review_date");

                entity.Property(e => e.ReviewText)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("review_text");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Reviews__product__5535A963");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Reviews__user_id__5441852A");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.Property(e => e.SaleId).HasColumnName("sale_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.SaleDate)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("sale_date");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("total_amount");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Sales__order_id__693CA210");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__AB6E6164EA62A060")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Addres)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("addres");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password_hash");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserRole",
                        l => l.HasOne<Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserRoles__role___3D5E1FD2"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserRoles__user___3C69FB99"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId").HasName("PK__UserRole__6EDEA153E25A8E2A");

                            j.ToTable("UserRoles");

                            j.IndexerProperty<int>("UserId").HasColumnName("user_id");

                            j.IndexerProperty<int>("RoleId").HasColumnName("role_id");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
