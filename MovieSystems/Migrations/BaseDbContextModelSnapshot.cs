﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieSystems.Context;

#nullable disable

namespace MovieSystems.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    partial class BaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieSystems.Models.Actor", b =>
                {
                    b.Property<int>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActorId"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FilmId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActorId");

                    b.HasIndex("FilmId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("MovieSystems.Models.Film", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FilmId"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PublisherId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("FilmId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("MovieSystems.Models.FilmCrewMember", b =>
                {
                    b.Property<int>("CrewMemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CrewMemberId"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FilmId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CrewMemberId");

                    b.HasIndex("FilmId");

                    b.ToTable("FilmCrewMembers");
                });

            modelBuilder.Entity("MovieSystems.Models.Publisher", b =>
                {
                    b.Property<int>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PublisherId"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PublisherId");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("MovieSystems.Models.Actor", b =>
                {
                    b.HasOne("MovieSystems.Models.Film", null)
                        .WithMany("Actors")
                        .HasForeignKey("FilmId");
                });

            modelBuilder.Entity("MovieSystems.Models.Film", b =>
                {
                    b.HasOne("MovieSystems.Models.Publisher", null)
                        .WithMany("FilmsPublished")
                        .HasForeignKey("PublisherId");
                });

            modelBuilder.Entity("MovieSystems.Models.FilmCrewMember", b =>
                {
                    b.HasOne("MovieSystems.Models.Film", null)
                        .WithMany("Crew")
                        .HasForeignKey("FilmId");
                });

            modelBuilder.Entity("MovieSystems.Models.Film", b =>
                {
                    b.Navigation("Actors");

                    b.Navigation("Crew");
                });

            modelBuilder.Entity("MovieSystems.Models.Publisher", b =>
                {
                    b.Navigation("FilmsPublished");
                });
#pragma warning restore 612, 618
        }
    }
}
