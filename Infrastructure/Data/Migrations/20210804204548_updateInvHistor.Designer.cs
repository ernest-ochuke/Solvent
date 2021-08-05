﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(SolventContext))]
    [Migration("20210804204548_updateInvHistor")]
    partial class updateInvHistor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Core.Entities.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UniqueIdentityNumber")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("UniqueIdentityNumber")
                        .IsUnique()
                        .HasFilter("[UniqueIdentityNumber] IS NOT NULL");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("Core.Entities.CardProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BankId")
                        .HasColumnType("int");

                    b.Property<int>("ChipCertificationId")
                        .HasColumnType("int");

                    b.Property<int>("ChipId")
                        .HasColumnType("int");

                    b.Property<int?>("ChipTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("ChipCertificationId");

                    b.HasIndex("ChipTypeId");

                    b.ToTable("CardProducts");
                });

            modelBuilder.Entity("Core.Entities.ChipCertification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BankId")
                        .HasColumnType("int");

                    b.Property<string>("CertificationStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CertificationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ChipTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ParentCertificationrRef")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferenceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("ChipTypeId");

                    b.ToTable("ChipCertifications");
                });

            modelBuilder.Entity("Core.Entities.ChipInventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ChipTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateEntered")
                        .HasColumnType("datetime2");

                    b.Property<string>("KCV")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChipTypeId");

                    b.ToTable("ChipInventories");
                });

            modelBuilder.Entity("Core.Entities.ChipInventoryHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<int>("ChipInventoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRequested")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MediatorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.Property<string>("Requester")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChipInventoryId");

                    b.ToTable("ChipInventoryHistories");
                });

            modelBuilder.Entity("Core.Entities.ChipType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LoaDirPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoaReferenceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ChipTypes");
                });

            modelBuilder.Entity("Core.Entities.CardProduct", b =>
                {
                    b.HasOne("Core.Entities.Bank", "Bank")
                        .WithMany("CardProducts")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.ChipCertification", "ChipCertification")
                        .WithMany()
                        .HasForeignKey("ChipCertificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.ChipType", "ChipType")
                        .WithMany()
                        .HasForeignKey("ChipTypeId");

                    b.Navigation("Bank");

                    b.Navigation("ChipCertification");

                    b.Navigation("ChipType");
                });

            modelBuilder.Entity("Core.Entities.ChipCertification", b =>
                {
                    b.HasOne("Core.Entities.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.ChipType", "ChipType")
                        .WithMany()
                        .HasForeignKey("ChipTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");

                    b.Navigation("ChipType");
                });

            modelBuilder.Entity("Core.Entities.ChipInventory", b =>
                {
                    b.HasOne("Core.Entities.ChipType", "ChipType")
                        .WithMany()
                        .HasForeignKey("ChipTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChipType");
                });

            modelBuilder.Entity("Core.Entities.ChipInventoryHistory", b =>
                {
                    b.HasOne("Core.Entities.ChipInventory", "ChipInventory")
                        .WithMany("History")
                        .HasForeignKey("ChipInventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChipInventory");
                });

            modelBuilder.Entity("Core.Entities.Bank", b =>
                {
                    b.Navigation("CardProducts");
                });

            modelBuilder.Entity("Core.Entities.ChipInventory", b =>
                {
                    b.Navigation("History");
                });
#pragma warning restore 612, 618
        }
    }
}
