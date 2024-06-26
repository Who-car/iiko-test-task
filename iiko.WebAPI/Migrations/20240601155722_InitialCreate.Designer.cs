﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebAPI.DataAccess;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240601155722_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebAPI.Entities.Client", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<Guid>("SystemId")
                        .HasColumnType("uuid");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            SystemId = new Guid("db66578d-dc8a-4d0f-c6ca-75f2c6c9dbf7"),
                            Username = "Shane_Sanford"
                        },
                        new
                        {
                            Id = 2L,
                            SystemId = new Guid("29b7df70-4906-c060-0578-5ea69537a406"),
                            Username = "Paula_Schaden59"
                        },
                        new
                        {
                            Id = 3L,
                            SystemId = new Guid("af1c453d-f0f5-e9a8-f770-c59d63ba921b"),
                            Username = "Florencio_Fahey98"
                        },
                        new
                        {
                            Id = 4L,
                            SystemId = new Guid("407d3410-0d2d-3975-cacd-fa436aabc74c"),
                            Username = "Furman0"
                        },
                        new
                        {
                            Id = 5L,
                            SystemId = new Guid("264d10f5-b6a5-7d81-25f7-fad757bb1599"),
                            Username = "Robert_Collins91"
                        },
                        new
                        {
                            Id = 6L,
                            SystemId = new Guid("104b6838-3a35-576d-de6a-c9b6cc753783"),
                            Username = "Easton.Robel90"
                        },
                        new
                        {
                            Id = 7L,
                            SystemId = new Guid("70219038-81b2-4afa-5beb-a5f9a879902f"),
                            Username = "Jewell.Lynch13"
                        },
                        new
                        {
                            Id = 8L,
                            SystemId = new Guid("4a641665-61ff-abe4-985b-b092d3a29bf8"),
                            Username = "Felicity4"
                        },
                        new
                        {
                            Id = 9L,
                            SystemId = new Guid("33c6a3b5-2996-8374-3519-78e334bcb891"),
                            Username = "Nicole89"
                        },
                        new
                        {
                            Id = 10L,
                            SystemId = new Guid("582a7ae6-d7d3-0940-c32d-de0df1992c38"),
                            Username = "Catherine.Cremin57"
                        },
                        new
                        {
                            Id = 11L,
                            SystemId = new Guid("16e32d8c-6121-a1dc-1450-ecf4e876d399"),
                            Username = "Stacy93"
                        },
                        new
                        {
                            Id = 12L,
                            SystemId = new Guid("15bc4826-6f49-ad93-59a6-35a4dcc627fb"),
                            Username = "Robyn.Reilly"
                        },
                        new
                        {
                            Id = 13L,
                            SystemId = new Guid("c21e3ed7-dea7-4ec0-35b1-1533cffdfbe6"),
                            Username = "Shawn_Robel"
                        },
                        new
                        {
                            Id = 14L,
                            SystemId = new Guid("bc2bd8da-86c6-0d12-5a6b-7b8942b3edb3"),
                            Username = "Virgie.Ortiz99"
                        },
                        new
                        {
                            Id = 15L,
                            SystemId = new Guid("275aaa6a-861a-163c-bb44-3cdcd3074f12"),
                            Username = "Makenna_Shanahan"
                        },
                        new
                        {
                            Id = 16L,
                            SystemId = new Guid("02d4bec6-12af-beb6-cd3b-a829d369988a"),
                            Username = "Polly88"
                        },
                        new
                        {
                            Id = 17L,
                            SystemId = new Guid("b3bb7725-dd41-d82f-7cc0-15fac2a34c4a"),
                            Username = "Clovis91"
                        },
                        new
                        {
                            Id = 18L,
                            SystemId = new Guid("fdbfb29b-9145-5a89-1db1-935cd974f14b"),
                            Username = "Ladarius_Dach54"
                        },
                        new
                        {
                            Id = 19L,
                            SystemId = new Guid("91229917-4e08-fa26-04bf-4fa26d727942"),
                            Username = "Leif55"
                        },
                        new
                        {
                            Id = 20L,
                            SystemId = new Guid("4d29ba57-a365-15f5-11a1-1016f47a0656"),
                            Username = "Jarret.Douglas"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
