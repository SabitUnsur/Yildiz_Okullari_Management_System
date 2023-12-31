﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231214213810_dbseed")]
    partial class dbseed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Entities.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("721417b8-b7d2-4e12-b0c6-b647c5b1a592"),
                            ConcurrencyStamp = "ec75a9d4-5df6-4837-b4c4-7e8ce35e473d",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Entities.Attendance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("AttendanceTotalLectureHour")
                        .HasColumnType("integer");

                    b.Property<int?>("AttendanceType")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("ExcuseType")
                        .HasColumnType("integer");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TermId")
                        .HasColumnType("uuid");

                    b.Property<decimal?>("TotalAttendance")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("TermId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("Entities.FamilyInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FatherFullName")
                        .HasColumnType("text");

                    b.Property<string>("FatherPhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("MotherFullName")
                        .HasColumnType("text");

                    b.Property<string>("MotherPhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("FamilyInfos");
                });

            modelBuilder.Entity("Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Branch")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("FamilyInfoId")
                        .HasColumnType("uuid");

                    b.Property<int?>("Gender")
                        .HasColumnType("integer");

                    b.Property<int?>("Grade")
                        .HasColumnType("integer");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<int?>("StudentNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<Guid?>("TermId")
                        .HasColumnType("uuid");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("FamilyInfoId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("TermId");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("fb217184-d9aa-4ef0-a1d4-43cfb435f1de"),
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(2023, 12, 14, 21, 38, 9, 821, DateTimeKind.Utc).AddTicks(9708),
                            Branch = "B",
                            ConcurrencyStamp = "0d3223f6-b183-4286-8967-d9a43f7ad8f4",
                            Email = "example@example.com",
                            EmailConfirmed = true,
                            Grade = 12,
                            LockoutEnabled = false,
                            LockoutEnd = new DateTimeOffset(new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(0, 3, 0, 0, 0)),
                            Name = "Sabit",
                            NormalizedEmail = "EXAMPLE@EXAMPLE.COM",
                            NormalizedUserName = "EXAMPLE@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEJQuW2geFMR4pYpn8/6hmjgd4VqiDYcVoqum0WTOf9DX45e64QJx/GMhpzpjjutswg==",
                            PhoneNumber = "+905423849022",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "4d626afc-93ec-4b44-81be-bd9960abd3f0",
                            StudentNumber = 653,
                            Surname = "Ünsür",
                            TwoFactorEnabled = false,
                            UserName = "example@example.com"
                        },
                        new
                        {
                            Id = new Guid("c4b48cae-1439-4fb4-9a6f-e0ae3bf2f039"),
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(2023, 12, 14, 21, 38, 9, 864, DateTimeKind.Utc).AddTicks(5048),
                            ConcurrencyStamp = "a8cde033-a26e-4f89-9c2b-bfd5eb5a09fc",
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            LockoutEnd = new DateTimeOffset(new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(0, 3, 0, 0, 0)),
                            Name = "Admin",
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN@ADMIN.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEA/GZRk8gE5NiKIp90InGUGxUJjshYYLQS7l5ZIQmQGn80fy3MbKzQO8aA8bvefaXg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "21ee5afe-ea84-473f-a983-285df567489f",
                            TwoFactorEnabled = false,
                            UserName = "admin@admin.com"
                        },
                        new
                        {
                            Id = new Guid("fddb7619-d482-429f-bbfe-6a540a84af99"),
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(2023, 12, 14, 21, 38, 9, 907, DateTimeKind.Utc).AddTicks(851),
                            Branch = "A",
                            ConcurrencyStamp = "b10235b3-424f-41b6-8b72-9b04d1aee125",
                            Email = "sabit@sabit.com",
                            EmailConfirmed = true,
                            Grade = 11,
                            LockoutEnabled = false,
                            LockoutEnd = new DateTimeOffset(new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(0, 3, 0, 0, 0)),
                            Name = "Egemen",
                            NormalizedEmail = "SABIT@SABIT.COM",
                            NormalizedUserName = "SABIT@SABIT.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEHfaVIP/Qcyht4VWaOyAKKpUb7bw98t2wmsoFlOq+nF05IFZiVvpvSjnjNNEIa3HDA==",
                            PhoneNumber = "+905423849022",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "c58cb35e-ebbf-4327-9981-961bd0eabe71",
                            StudentNumber = 1532,
                            Surname = "Ünsür",
                            TwoFactorEnabled = false,
                            UserName = "sabit@sabit.com"
                        },
                        new
                        {
                            Id = new Guid("64fab00e-6543-4d2d-88a0-c970ff1c3f80"),
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(2023, 12, 14, 21, 38, 9, 948, DateTimeKind.Utc).AddTicks(9355),
                            Branch = "C",
                            ConcurrencyStamp = "4b0b7028-1467-45a5-a61f-3c2313cd9c33",
                            Email = "mikdat@simsek.com",
                            EmailConfirmed = true,
                            Grade = 12,
                            LockoutEnabled = false,
                            LockoutEnd = new DateTimeOffset(new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(0, 3, 0, 0, 0)),
                            Name = "Mikdat Can",
                            NormalizedEmail = "MIKDAT@MIKDAT.COM",
                            NormalizedUserName = "MIKDAT@MIKDAT.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAENt7paubuDZBg5cULa6PBxor2UQldsh9t5QajhCESbInWDFHYj9lNyHKgAipVBnJdA==",
                            PhoneNumber = "+905397159877",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "4ecaa236-aeaf-4387-bad7-426f023cc96c",
                            StudentNumber = 16,
                            Surname = "Şimşek",
                            TwoFactorEnabled = false,
                            UserName = "mikdat@simsek.com"
                        });
                });

            modelBuilder.Entity("Entities.Term", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Terms");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f81dedd7-a7d8-42eb-85b9-c1f6a3977439"),
                            EndDate = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999),
                            StartDate = new DateTime(2023, 12, 14, 21, 38, 9, 993, DateTimeKind.Utc).AddTicks(2405)
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Entities.Attendance", b =>
                {
                    b.HasOne("Entities.Person", "Person")
                        .WithMany("Attendances")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Term", "Term")
                        .WithMany()
                        .HasForeignKey("TermId");

                    b.Navigation("Person");

                    b.Navigation("Term");
                });

            modelBuilder.Entity("Entities.Person", b =>
                {
                    b.HasOne("Entities.FamilyInfo", "FamilyInfo")
                        .WithMany("Persons")
                        .HasForeignKey("FamilyInfoId");

                    b.HasOne("Entities.Term", "Term")
                        .WithMany("TermPeople")
                        .HasForeignKey("TermId");

                    b.Navigation("FamilyInfo");

                    b.Navigation("Term");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.FamilyInfo", b =>
                {
                    b.Navigation("Persons");
                });

            modelBuilder.Entity("Entities.Person", b =>
                {
                    b.Navigation("Attendances");
                });

            modelBuilder.Entity("Entities.Term", b =>
                {
                    b.Navigation("TermPeople");
                });
#pragma warning restore 612, 618
        }
    }
}
