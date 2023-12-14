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
    [Migration("20231214215229_UpdateTotalAttendanceComputedColumn")]
    partial class UpdateTotalAttendanceComputedColumn
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
                            Id = new Guid("cd198600-842d-4937-9b5b-4d268fff09cf"),
                            ConcurrencyStamp = "20ea0bf1-a513-4811-b87d-56aa872eabac",
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
                            Id = new Guid("136df5c0-4394-4045-97d7-72082f206921"),
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(2023, 12, 14, 21, 52, 28, 798, DateTimeKind.Utc).AddTicks(6513),
                            Branch = "B",
                            ConcurrencyStamp = "29785961-0ec0-4c0a-8f15-2e02dfcbf5a2",
                            Email = "example@example.com",
                            EmailConfirmed = true,
                            Grade = 12,
                            LockoutEnabled = false,
                            LockoutEnd = new DateTimeOffset(new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(0, 3, 0, 0, 0)),
                            Name = "Sabit",
                            NormalizedEmail = "EXAMPLE@EXAMPLE.COM",
                            NormalizedUserName = "EXAMPLE@EXAMPLE.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEGYfwsLXKx8Hw+xBmn62nO2nNhkAgzEIy8teDlSslDanrFYu4udOK0w3SjoebuW1Lg==",
                            PhoneNumber = "+905423849022",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "eeb10e17-8a23-42db-9cb5-95478422f1ba",
                            StudentNumber = 653,
                            Surname = "Ünsür",
                            TwoFactorEnabled = false,
                            UserName = "example@example.com"
                        },
                        new
                        {
                            Id = new Guid("f2cf58f5-cf2d-4e56-a31c-d28338b383ae"),
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(2023, 12, 14, 21, 52, 28, 843, DateTimeKind.Utc).AddTicks(4248),
                            ConcurrencyStamp = "dbb961e5-5e5e-40de-be6e-9f27fea6de73",
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            LockoutEnd = new DateTimeOffset(new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(0, 3, 0, 0, 0)),
                            Name = "Admin",
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN@ADMIN.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEApfMmQfkGlAWDFRM5kW7i3NvgemGfreyijV4Nzu2Ob5MaPOlKRPaagGX9yne6l4KA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a507e863-9f13-485d-bea5-ae8b7009f28b",
                            TwoFactorEnabled = false,
                            UserName = "admin@admin.com"
                        },
                        new
                        {
                            Id = new Guid("759e4cc9-78b6-4315-b205-0956de572ad5"),
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(2023, 12, 14, 21, 52, 28, 886, DateTimeKind.Utc).AddTicks(7426),
                            Branch = "A",
                            ConcurrencyStamp = "9c1b1ca1-ab68-484f-999d-e4b8874dcfba",
                            Email = "sabit@sabit.com",
                            EmailConfirmed = true,
                            Grade = 11,
                            LockoutEnabled = false,
                            LockoutEnd = new DateTimeOffset(new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(0, 3, 0, 0, 0)),
                            Name = "Egemen",
                            NormalizedEmail = "SABIT@SABIT.COM",
                            NormalizedUserName = "SABIT@SABIT.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEEggo4XeiMHySXEJrme8iMnR7NyS52wA+AutXY5cpfaUZ2g+6v47QDsQeySbspTI3A==",
                            PhoneNumber = "+905423849022",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "acd0260e-94c7-458a-8df3-5f4cc5f26fa1",
                            StudentNumber = 1532,
                            Surname = "Ünsür",
                            TwoFactorEnabled = false,
                            UserName = "sabit@sabit.com"
                        },
                        new
                        {
                            Id = new Guid("cda9a68d-e4e8-4eea-9341-80017a7b92bd"),
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(2023, 12, 14, 21, 52, 28, 932, DateTimeKind.Utc).AddTicks(1554),
                            Branch = "C",
                            ConcurrencyStamp = "e12e4f08-b4d8-4982-a230-7e7c06300cf6",
                            Email = "mikdat@simsek.com",
                            EmailConfirmed = true,
                            Grade = 12,
                            LockoutEnabled = false,
                            LockoutEnd = new DateTimeOffset(new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new TimeSpan(0, 3, 0, 0, 0)),
                            Name = "Mikdat Can",
                            NormalizedEmail = "MIKDAT@MIKDAT.COM",
                            NormalizedUserName = "MIKDAT@MIKDAT.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEFmja1jT+di1jaT9clu2EollkV9voYxneVGZkgY8dyl7uOmpibm3OM4OOjFQ6tB+Fw==",
                            PhoneNumber = "+905397159877",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "c2f1476e-267d-45d7-baa2-05b75fde7959",
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
                            Id = new Guid("9556bd19-832e-4661-bd64-e0d58eb5e34c"),
                            EndDate = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999),
                            StartDate = new DateTime(2023, 12, 14, 21, 52, 28, 978, DateTimeKind.Utc).AddTicks(9996)
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