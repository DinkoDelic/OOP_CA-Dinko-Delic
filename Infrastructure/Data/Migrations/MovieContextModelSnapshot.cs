﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(MovieContext))]
    partial class MovieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("Core.Entities.Actor", b =>
                {
                    b.Property<int>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ActorId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("Core.Entities.Director", b =>
                {
                    b.Property<int>("DirectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("DirectorId");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("Core.Entities.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AgeRating")
                        .HasColumnType("TEXT");

                    b.Property<int>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Genre")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Storyline")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Core.Entities.MovieActor", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ActorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MovieId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("MoviesActors");
                });

            modelBuilder.Entity("Core.Entities.MovieDirector", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DirectorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MovieId", "DirectorId");

                    b.HasIndex("DirectorId");

                    b.ToTable("MoviesDrectors");
                });

            modelBuilder.Entity("Core.Entities.MovieWriter", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WriterId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MovieId", "WriterId");

                    b.HasIndex("WriterId");

                    b.ToTable("MoviesWriters");
                });

            modelBuilder.Entity("Core.Entities.Writer", b =>
                {
                    b.Property<int>("WriterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("WriterId");

                    b.ToTable("Writers");
                });

            modelBuilder.Entity("Core.Entities.MovieActor", b =>
                {
                    b.HasOne("Core.Entities.Actor", "Actor")
                        .WithMany("MoviesLink")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Movie", "Movie")
                        .WithMany("ActorsLink")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Core.Entities.MovieDirector", b =>
                {
                    b.HasOne("Core.Entities.Director", "Director")
                        .WithMany("MoviesLink")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Movie", "Movie")
                        .WithMany("DirectorsLink")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Director");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Core.Entities.MovieWriter", b =>
                {
                    b.HasOne("Core.Entities.Movie", "Movie")
                        .WithMany("WritersLink")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Writer", "Writer")
                        .WithMany("MoviesLink")
                        .HasForeignKey("WriterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Writer");
                });

            modelBuilder.Entity("Core.Entities.Actor", b =>
                {
                    b.Navigation("MoviesLink");
                });

            modelBuilder.Entity("Core.Entities.Director", b =>
                {
                    b.Navigation("MoviesLink");
                });

            modelBuilder.Entity("Core.Entities.Movie", b =>
                {
                    b.Navigation("ActorsLink");

                    b.Navigation("DirectorsLink");

                    b.Navigation("WritersLink");
                });

            modelBuilder.Entity("Core.Entities.Writer", b =>
                {
                    b.Navigation("MoviesLink");
                });
#pragma warning restore 612, 618
        }
    }
}
