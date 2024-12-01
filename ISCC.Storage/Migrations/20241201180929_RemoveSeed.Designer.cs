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
    [Migration("20241201180929_RemoveSeed")]
    partial class RemoveSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ISCC.Storage.Entities.GroupTaskEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid?>("ParentGroupId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ParentGroupId");

                    b.HasIndex("ProjectId");

                    b.ToTable("GroupTasks");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.OneTimeExpenseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<decimal>("PricePerUnit")
                        .HasColumnType("numeric");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.Property<Guid>("UnitTypeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UnitTypeId");

                    b.ToTable("OneTimeExpenses");
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

                    b.Property<decimal>("TotalActualPrice")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalActualPriceMaterial")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalActualPriceWork")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalCostPrice")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalCostPriceMaterial")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalCostPriceWork")
                        .HasColumnType("numeric");

                    b.Property<double>("TotalLabor")
                        .HasColumnType("double precision");

                    b.Property<decimal>("TotalPriceExpense")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.ProjectPlanEntity", b =>
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

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.Property<decimal>("TotalActualPrice")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalActualPriceMaterial")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalActualPriceWork")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalCostPrice")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalCostPriceMaterial")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalCostPriceWork")
                        .HasColumnType("numeric");

                    b.Property<double>("TotalLabor")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectPlans");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.RegularExpenseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("DurationInMonths")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<decimal>("PricePerUnit")
                        .HasColumnType("numeric");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.Property<Guid>("UnitTypeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UnitTypeId");

                    b.ToTable("RegularExpenses");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.ResourceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("ActualPricePerUnitMaterial")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ActualPricePerUnitWork")
                        .HasColumnType("numeric");

                    b.Property<decimal>("CostPricePerUnitMaterial")
                        .HasColumnType("numeric");

                    b.Property<decimal>("CostPricePerUnitWork")
                        .HasColumnType("numeric");

                    b.Property<double>("LaborPerUnit")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("ProjectPlanId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<decimal>("Surcharge")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalActualPrice")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalActualPriceMaterial")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalActualPriceWork")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalCostPrice")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalCostPriceMaterial")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalCostPriceWork")
                        .HasColumnType("numeric");

                    b.Property<double>("TotalLabor")
                        .HasColumnType("double precision");

                    b.Property<Guid>("UnitTypeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProjectPlanId");

                    b.HasIndex("UnitTypeId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.TaskEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<decimal>("PercentageContent")
                        .HasColumnType("numeric");

                    b.Property<Guid>("ProjectPlanId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalActualPrice")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalActualPriceMaterial")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalActualPriceWork")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalCostPrice")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalCostPriceMaterial")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalCostPriceWork")
                        .HasColumnType("numeric");

                    b.Property<double>("TotalLabor")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("ProjectPlanId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.UnitTypeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)");

                    b.HasKey("Id");

                    b.ToTable("UnitTypes");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.GroupTaskEntity", b =>
                {
                    b.HasOne("ISCC.Storage.Entities.GroupTaskEntity", "ParentGroup")
                        .WithMany("SubGroups")
                        .HasForeignKey("ParentGroupId");

                    b.HasOne("ISCC.Storage.Entities.ProjectEntity", "Project")
                        .WithMany("GroupTasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentGroup");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.OneTimeExpenseEntity", b =>
                {
                    b.HasOne("ISCC.Storage.Entities.ProjectEntity", "Project")
                        .WithMany("OneTimeExpenses")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISCC.Storage.Entities.UnitTypeEntity", "UnitType")
                        .WithMany("OneTimeExpenses")
                        .HasForeignKey("UnitTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("UnitType");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.ProjectPlanEntity", b =>
                {
                    b.HasOne("ISCC.Storage.Entities.ProjectEntity", "Project")
                        .WithMany("Plans")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.RegularExpenseEntity", b =>
                {
                    b.HasOne("ISCC.Storage.Entities.ProjectEntity", "Project")
                        .WithMany("RegularExpenses")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISCC.Storage.Entities.UnitTypeEntity", "UnitType")
                        .WithMany("RegularExpenses")
                        .HasForeignKey("UnitTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("UnitType");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.ResourceEntity", b =>
                {
                    b.HasOne("ISCC.Storage.Entities.ProjectPlanEntity", "ProjectPlan")
                        .WithMany("Resources")
                        .HasForeignKey("ProjectPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISCC.Storage.Entities.UnitTypeEntity", "UnitType")
                        .WithMany("Resources")
                        .HasForeignKey("UnitTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectPlan");

                    b.Navigation("UnitType");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.TaskEntity", b =>
                {
                    b.HasOne("ISCC.Storage.Entities.GroupTaskEntity", "GroupTask")
                        .WithMany("Tasks")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISCC.Storage.Entities.ProjectPlanEntity", "ProjectPlan")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GroupTask");

                    b.Navigation("ProjectPlan");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.GroupTaskEntity", b =>
                {
                    b.Navigation("SubGroups");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.ProjectEntity", b =>
                {
                    b.Navigation("GroupTasks");

                    b.Navigation("OneTimeExpenses");

                    b.Navigation("Plans");

                    b.Navigation("RegularExpenses");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.ProjectPlanEntity", b =>
                {
                    b.Navigation("Resources");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("ISCC.Storage.Entities.UnitTypeEntity", b =>
                {
                    b.Navigation("OneTimeExpenses");

                    b.Navigation("RegularExpenses");

                    b.Navigation("Resources");
                });
#pragma warning restore 612, 618
        }
    }
}
