﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using book_store.Models;

namespace book_store.Migrations
{
    [DbContext(typeof(Dbcontxt))]
    partial class DbcontxtModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("book_store.Models.Auther", b =>
                {
                    b.Property<int>("Id_auther")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_auther");

                    b.ToTable("authers");
                });

            modelBuilder.Entity("book_store.Models.Book", b =>
                {
                    b.Property<int>("Idbook")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AutherId_auther")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imageurl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Idbook");

                    b.HasIndex("AutherId_auther");

                    b.ToTable("books");
                });

            modelBuilder.Entity("book_store.Models.Book", b =>
                {
                    b.HasOne("book_store.Models.Auther", "Auther")
                        .WithMany()
                        .HasForeignKey("AutherId_auther");
                });
#pragma warning restore 612, 618
        }
    }
}