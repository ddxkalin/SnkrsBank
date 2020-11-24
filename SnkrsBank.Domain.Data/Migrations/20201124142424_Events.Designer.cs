﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SnkrsBank.Domain.Data;

namespace SnkrsBank.Domain.Data.Migrations
{
    [DbContext(typeof(SnkrsBankDbContext))]
    [Migration("20201124142424_Events")]
    partial class Events
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.Brand", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.Category", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("Slug")
                        .IsUnique()
                        .HasFilter("[Slug] IS NOT NULL");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.Event", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SneakerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("SneakerId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.EventParticipant", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EventId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("EventParticipant");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.Keyword", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SneakerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("SneakerId");

                    b.ToTable("Keyword");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.Rating", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RatedById")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("RatedOn")
                        .HasColumnType("datetime2");

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("RatedById");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.SalePost", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SneakerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("SneakerId");

                    b.HasIndex("UserId");

                    b.ToTable("SalePosts");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.Sneaker", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BrandId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Colorway")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Condition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PosterImageLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RetailPrice")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("Slug")
                        .IsUnique()
                        .HasFilter("[Slug] IS NOT NULL");

                    b.ToTable("Sneakers");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.SneakerCategory", b =>
                {
                    b.Property<string>("SneakerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SneakerId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("SneakerCategory");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.SneakerRating", b =>
                {
                    b.Property<string>("RatingId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SneakerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RatingId", "SneakerId");

                    b.HasIndex("SneakerId");

                    b.ToTable("SneakerRating");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTimeOffset>("EmailConfirmationTokenResentOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.UserOwnedSneaker", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SneakerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "SneakerId");

                    b.HasIndex("SneakerId");

                    b.ToTable("UserOwnedSneaker");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.UserRating", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RatingId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RatingId");

                    b.HasIndex("RatingId");

                    b.ToTable("UserRating");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.UserRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.UserWatchedSneaker", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SneakerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "SneakerId");

                    b.HasIndex("SneakerId");

                    b.ToTable("UserWatchedSneaker");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.UserWishlist", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SneakerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "SneakerId");

                    b.HasIndex("SneakerId");

                    b.ToTable("UserWishlist");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("SnkrsBank.Domain.Models.UserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SnkrsBank.Domain.Models.User", null)
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SnkrsBank.Domain.Models.User", null)
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("SnkrsBank.Domain.Models.UserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SnkrsBank.Domain.Models.User", null)
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SnkrsBank.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.Event", b =>
                {
                    b.HasOne("SnkrsBank.Domain.Models.Sneaker", "Sneaker")
                        .WithMany()
                        .HasForeignKey("SneakerId");

                    b.Navigation("Sneaker");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.EventParticipant", b =>
                {
                    b.HasOne("SnkrsBank.Domain.Models.User", "Participant")
                        .WithMany("Events")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SnkrsBank.Domain.Models.Event", "Event")
                        .WithMany("Participants")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.Keyword", b =>
                {
                    b.HasOne("SnkrsBank.Domain.Models.Sneaker", "Sneaker")
                        .WithMany("Keywords")
                        .HasForeignKey("SneakerId");

                    b.Navigation("Sneaker");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.Rating", b =>
                {
                    b.HasOne("SnkrsBank.Domain.Models.User", "RatedBy")
                        .WithMany()
                        .HasForeignKey("RatedById");

                    b.Navigation("RatedBy");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.SalePost", b =>
                {
                    b.HasOne("SnkrsBank.Domain.Models.Sneaker", "Sneaker")
                        .WithMany()
                        .HasForeignKey("SneakerId");

                    b.HasOne("SnkrsBank.Domain.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId");

                    b.Navigation("Sneaker");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.Sneaker", b =>
                {
                    b.HasOne("SnkrsBank.Domain.Models.Brand", "Brand")
                        .WithMany("Brands")
                        .HasForeignKey("BrandId");

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.SneakerCategory", b =>
                {
                    b.HasOne("SnkrsBank.Domain.Models.Category", "Category")
                        .WithMany("SneakersList")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SnkrsBank.Domain.Models.Sneaker", "Sneaker")
                        .WithMany("SneakerCategories")
                        .HasForeignKey("SneakerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Sneaker");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.SneakerRating", b =>
                {
                    b.HasOne("SnkrsBank.Domain.Models.Rating", "Rating")
                        .WithMany("SneakerRatings")
                        .HasForeignKey("RatingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SnkrsBank.Domain.Models.Sneaker", "Sneaker")
                        .WithMany("SneakerRatings")
                        .HasForeignKey("SneakerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Rating");

                    b.Navigation("Sneaker");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.UserOwnedSneaker", b =>
                {
                    b.HasOne("SnkrsBank.Domain.Models.Sneaker", "Sneaker")
                        .WithMany("UserOwnedSneaker")
                        .HasForeignKey("SneakerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SnkrsBank.Domain.Models.User", "User")
                        .WithMany("UserOwnedSneaker")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Sneaker");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.UserRating", b =>
                {
                    b.HasOne("SnkrsBank.Domain.Models.Rating", "Rating")
                        .WithMany("UserRatings")
                        .HasForeignKey("RatingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SnkrsBank.Domain.Models.User", "User")
                        .WithMany("UserRatings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Rating");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.UserWatchedSneaker", b =>
                {
                    b.HasOne("SnkrsBank.Domain.Models.Sneaker", "Sneaker")
                        .WithMany("UserWatchedSneaker")
                        .HasForeignKey("SneakerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SnkrsBank.Domain.Models.User", "User")
                        .WithMany("UserWatchedSneaker")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Sneaker");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.UserWishlist", b =>
                {
                    b.HasOne("SnkrsBank.Domain.Models.Sneaker", "Sneaker")
                        .WithMany("UserWishlists")
                        .HasForeignKey("SneakerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SnkrsBank.Domain.Models.User", "User")
                        .WithMany("UserWishlists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Sneaker");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.Brand", b =>
                {
                    b.Navigation("Brands");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.Category", b =>
                {
                    b.Navigation("SneakersList");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.Event", b =>
                {
                    b.Navigation("Participants");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.Rating", b =>
                {
                    b.Navigation("SneakerRatings");

                    b.Navigation("UserRatings");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.Sneaker", b =>
                {
                    b.Navigation("Keywords");

                    b.Navigation("SneakerCategories");

                    b.Navigation("SneakerRatings");

                    b.Navigation("UserOwnedSneaker");

                    b.Navigation("UserWatchedSneaker");

                    b.Navigation("UserWishlists");
                });

            modelBuilder.Entity("SnkrsBank.Domain.Models.User", b =>
                {
                    b.Navigation("Claims");

                    b.Navigation("Events");

                    b.Navigation("Logins");

                    b.Navigation("Posts");

                    b.Navigation("Roles");

                    b.Navigation("UserOwnedSneaker");

                    b.Navigation("UserRatings");

                    b.Navigation("UserWatchedSneaker");

                    b.Navigation("UserWishlists");
                });
#pragma warning restore 612, 618
        }
    }
}
