﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SolNWebApp.Models;

namespace SolNWebApp.Migrations
{
    [DbContext(typeof(SolNWebAppContext))]
    [Migration("20190225183606_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SolNWebApp.Models.Atleta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Nome");

                    b.Property<string>("NomeSocial");

                    b.Property<int>("Posicao");

                    b.Property<string>("Telefone");

                    b.HasKey("Id");

                    b.ToTable("Atleta");
                });

            modelBuilder.Entity("SolNWebApp.Models.SituacaoDoAtleta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AtletaId");

                    b.Property<DateTime>("Data");

                    b.Property<int>("Situacao");

                    b.Property<int>("Status");

                    b.Property<double>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("AtletaId");

                    b.ToTable("SituacaoDoAtleta");
                });

            modelBuilder.Entity("SolNWebApp.Models.SituacaoDoAtleta", b =>
                {
                    b.HasOne("SolNWebApp.Models.Atleta", "Atleta")
                        .WithMany("Situacao")
                        .HasForeignKey("AtletaId");
                });
#pragma warning restore 612, 618
        }
    }
}