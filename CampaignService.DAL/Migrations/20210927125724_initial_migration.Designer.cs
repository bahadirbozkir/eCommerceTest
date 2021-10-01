﻿// <auto-generated />
using System;
using CampaignService.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CampaignService.DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210927125724_initial_migration")]
    partial class initial_migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CampaignService.DAL.Entity.Action", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("AmountType")
                        .HasColumnType("int");

                    b.Property<long>("CampaignId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("CampaignService.DAL.Entity.Campaign", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("DiscountType")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("CampaignService.DAL.Entity.Condition", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("CampaignId")
                        .HasColumnType("bigint");

                    b.Property<int>("ConditionType")
                        .HasColumnType("int");

                    b.Property<int>("MultiplierFactor")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.ToTable("Conditions");
                });

            modelBuilder.Entity("CampaignService.DAL.Entity.ConditionProduct", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("ConditionId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ConditionId");

                    b.ToTable("ConditionProducts");
                });

            modelBuilder.Entity("CampaignService.DAL.Entity.Action", b =>
                {
                    b.HasOne("CampaignService.DAL.Entity.Campaign", null)
                        .WithMany("Actions")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CampaignService.DAL.Entity.Condition", b =>
                {
                    b.HasOne("CampaignService.DAL.Entity.Campaign", null)
                        .WithMany("Conditions")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CampaignService.DAL.Entity.ConditionProduct", b =>
                {
                    b.HasOne("CampaignService.DAL.Entity.Campaign", null)
                        .WithMany("ConditionProducts")
                        .HasForeignKey("ConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampaignService.DAL.Entity.Condition", null)
                        .WithMany("ConditionProducts")
                        .HasForeignKey("ConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
