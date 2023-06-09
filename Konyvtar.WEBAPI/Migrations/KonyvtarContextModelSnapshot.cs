﻿// <auto-generated />
using System;
using Konyvtar.WEBAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Konyvtar.WEBAPI.Migrations
{
    [DbContext(typeof(KonyvtarContext))]
    partial class KonyvtarContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Konyvtar.WEBAPI.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfBorrowing")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfReturn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsBorrowed")
                        .HasColumnType("bit");

                    b.Property<string>("NameOfBorrower")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Konyvtar.WEBAPI.Borrowed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateOfBorrowing")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfReturn")
                        .HasColumnType("datetime2");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Borroweds");
                });

            modelBuilder.Entity("Konyvtar.WEBAPI.Members", b =>
                {
                    b.Property<int>("MemberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MemberName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberID");

                    b.ToTable("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
