﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokemonBackend.Core.Data.Context;

#nullable disable

namespace PokemonBackend.Migrations
{
    [DbContext(typeof(PokemonContext))]
    [Migration("20220730181522_PokemonModelChanges")]
    partial class PokemonModelChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PokemonBackend.Models.Pokemon", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("BaseAttack")
                        .HasColumnType("int");

                    b.Property<int>("BaseDefense")
                        .HasColumnType("int");

                    b.Property<int>("BaseHP")
                        .HasColumnType("int");

                    b.Property<int>("BaseSP_Attack")
                        .HasColumnType("int");

                    b.Property<int>("BaseSP_Defense")
                        .HasColumnType("int");

                    b.Property<int>("BaseSpeed")
                        .HasColumnType("int");

                    b.Property<string>("NameChinese")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEnglish")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameFrench")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameJapanese")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type0")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type1")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Pokemon");
                });
#pragma warning restore 612, 618
        }
    }
}
