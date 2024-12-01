﻿// <auto-generated />
using System;
using ISCC.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ISCC.Storage.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20241130064226_ProjectPlan_AddTemporaryProperties")]
    partial class ProjectPlan_AddTemporaryProperties
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ISCC.Storage.Entities.ActualMaterialWorkItemDataEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("ActualMaterialCost")
                        .HasColumnType("numeric");

                    b.Property<int>("ActualQuantity")
                        .HasColumnType("integer");

                    b.Property<decimal>("ActualWorkCost")
                        .HasColumnType("numeric");

                    b.Property<int>("ActualWorkers")
                        .HasColumnType("integer");

                    b.Property<DateTime>("End")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("MaterialWorkItemId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("MaterialWorkItemId");

                    b.ToTable("ActualMaterialWorkItems");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.MaterialWorkItemEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("ContractMaterialUnitCost")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ContractWorkUnitCost")
                        .HasColumnType("numeric");

                    b.Property<decimal>("LaborIntensity")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<decimal>("PlannedMaterialUnitCost")
                        .HasColumnType("numeric");

                    b.Property<int>("PlannedQuantity")
                        .HasColumnType("integer");

                    b.Property<decimal>("PlannedWorkUnitCost")
                        .HasColumnType("numeric");

                    b.Property<Guid>("ProjectPlanId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProjectPlanId");

                    b.ToTable("MaterialWorkItems");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.OneTimeExpenseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateOnly>("PaymentDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("OneTimeExpenses");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.PaymentDateEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("Payment")
                        .HasColumnType("date");

                    b.Property<Guid>("RegularExpensesId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RegularExpensesId");

                    b.ToTable("PaymentDates");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.ProjectEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateOnly>("PlannedEndDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.ProjectPlanEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AverageMonthlyWorkers")
                        .HasColumnType("integer");

                    b.Property<DateOnly?>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateOnly>("PlannedEndDate")
                        .HasColumnType("date");

                    b.Property<decimal>("PlannedLaborIntensity")
                        .HasColumnType("numeric");

                    b.Property<Guid?>("PreviousPlanId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("PreviousPlanId")
                        .IsUnique();

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectPlans");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.RegularExpenseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.ToTable("RegularExpenses");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.ActualMaterialWorkItemDataEntity", b =>
                {
                    b.HasOne("ISCC.Storage.Entities.MaterialWorkItemEntity", "MaterialWorkItem")
                        .WithMany("ActualData")
                        .HasForeignKey("MaterialWorkItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaterialWorkItem");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.MaterialWorkItemEntity", b =>
                {
                    b.HasOne("ISCC.Storage.Entities.ProjectPlanEntity", "ProjectPlan")
                        .WithMany("MaterialWorkItems")
                        .HasForeignKey("ProjectPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectPlan");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.PaymentDateEntity", b =>
                {
                    b.HasOne("ISCC.Storage.Entities.RegularExpenseEntity", "RegularExpense")
                        .WithMany("PaymentDates")
                        .HasForeignKey("RegularExpensesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RegularExpense");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.ProjectPlanEntity", b =>
                {
                    b.HasOne("ISCC.Storage.Entities.ProjectPlanEntity", "PreviousPlan")
                        .WithOne()
                        .HasForeignKey("ISCC.Storage.Entities.ProjectPlanEntity", "PreviousPlanId");

                    b.HasOne("ISCC.Storage.Entities.ProjectEntity", "Project")
                        .WithMany("Plans")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PreviousPlan");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.MaterialWorkItemEntity", b =>
                {
                    b.Navigation("ActualData");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.ProjectEntity", b =>
                {
                    b.Navigation("Plans");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.ProjectPlanEntity", b =>
                {
                    b.Navigation("MaterialWorkItems");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.RegularExpenseEntity", b =>
                {
                    b.Navigation("PaymentDates");
                });
#pragma warning restore 612, 618
        }
    }
}