﻿// <auto-generated />
using DataAccess.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(HastaneContext))]
    [Migration("20211105185535_changeDataLenght")]
    partial class changeDataLenght
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Entities.Doktor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DoktorAdi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DoktorSoyadi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DoktorTcNo")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("DoktorTcNo")
                        .IsUnique();

                    b.ToTable("Doktorlar");
                });

            modelBuilder.Entity("Entities.Entities.DoktorHastane", b =>
                {
                    b.Property<int>("DoktorId")
                        .HasColumnType("int");

                    b.Property<int>("HastaneId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("DoktorId", "HastaneId");

                    b.HasIndex("HastaneId");

                    b.ToTable("DoktorHastane");
                });

            modelBuilder.Entity("Entities.Entities.Hastane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HastaneAdi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("HastaneAdres")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Hastaneler");
                });

            modelBuilder.Entity("Entities.Entities.DoktorHastane", b =>
                {
                    b.HasOne("Entities.Entities.Doktor", "Doktor")
                        .WithMany("doktorHastaneler")
                        .HasForeignKey("DoktorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Entities.Hastane", "Hastane")
                        .WithMany("doktorHastaneler")
                        .HasForeignKey("HastaneId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Doktor");

                    b.Navigation("Hastane");
                });

            modelBuilder.Entity("Entities.Entities.Doktor", b =>
                {
                    b.Navigation("doktorHastaneler");
                });

            modelBuilder.Entity("Entities.Entities.Hastane", b =>
                {
                    b.Navigation("doktorHastaneler");
                });
#pragma warning restore 612, 618
        }
    }
}
