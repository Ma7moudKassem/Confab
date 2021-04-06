﻿// <auto-generated />
using System;
using Confab.Services.Tickets.Core.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Confab.Services.Tickets.Core.DAL.Migrations
{
    [DbContext(typeof(TicketsDbContext))]
    [Migration("20210406170136_Tickets_Service_Init")]
    partial class Tickets_Service_Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Confab.Services.Tickets.Core.Entities.Conference", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("From")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("ParticipantsLimit")
                        .HasColumnType("integer");

                    b.Property<DateTime>("To")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Conferences");
                });

            modelBuilder.Entity("Confab.Services.Tickets.Core.Entities.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<Guid>("ConferenceId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("PurchasedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("TicketSaleId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("UsedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("UserId")
                        .IsConcurrencyToken()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("ConferenceId");

                    b.HasIndex("TicketSaleId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Confab.Services.Tickets.Core.Entities.TicketSale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("Amount")
                        .HasColumnType("integer");

                    b.Property<Guid>("ConferenceId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("From")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("To")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ConferenceId");

                    b.ToTable("TicketSales");
                });

            modelBuilder.Entity("Confab.Services.Tickets.Core.Entities.Ticket", b =>
                {
                    b.HasOne("Confab.Services.Tickets.Core.Entities.Conference", "Conference")
                        .WithMany()
                        .HasForeignKey("ConferenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Confab.Services.Tickets.Core.Entities.TicketSale", "TicketSale")
                        .WithMany("Tickets")
                        .HasForeignKey("TicketSaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conference");

                    b.Navigation("TicketSale");
                });

            modelBuilder.Entity("Confab.Services.Tickets.Core.Entities.TicketSale", b =>
                {
                    b.HasOne("Confab.Services.Tickets.Core.Entities.Conference", null)
                        .WithMany("TicketSales")
                        .HasForeignKey("ConferenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Confab.Services.Tickets.Core.Entities.Conference", b =>
                {
                    b.Navigation("TicketSales");
                });

            modelBuilder.Entity("Confab.Services.Tickets.Core.Entities.TicketSale", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
