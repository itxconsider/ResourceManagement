﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResourceManagement.Database;

#nullable disable

namespace ResourceManagement.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220408045429_ModifySomeModel")]
    partial class ModifySomeModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ResourceManagement.Models.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ResourceManagement.Models.Position", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("ResourceManagement.Models.Resource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PositionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PositionId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PositionId1");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("ResourceManagement.Models.Responsibility", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Responsibilities");
                });

            modelBuilder.Entity("ResourceManagement.Models.Work", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("EndAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResourceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResourceId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ResponsibilityId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ResponsibilityId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("StartAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("WorkGroupId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("WorkGroupId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ResourceId1");

                    b.HasIndex("ResponsibilityId1");

                    b.HasIndex("WorkGroupId1");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("ResourceManagement.Models.WorkGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WorkGroups");
                });

            modelBuilder.Entity("ResourceManagement.Models.WorkGroupResource", b =>
                {
                    b.Property<Guid>("WorkGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("WorkGroupId", "ResourceId");

                    b.HasIndex("ResourceId");

                    b.ToTable("WorkGroupResources");
                });

            modelBuilder.Entity("ResourceManagement.Models.Resource", b =>
                {
                    b.HasOne("ResourceManagement.Models.Position", "Position")
                        .WithMany("Resources")
                        .HasForeignKey("PositionId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");
                });

            modelBuilder.Entity("ResourceManagement.Models.Work", b =>
                {
                    b.HasOne("ResourceManagement.Models.Resource", "Resource")
                        .WithMany("Workings")
                        .HasForeignKey("ResourceId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResourceManagement.Models.Responsibility", "Responsibility")
                        .WithMany()
                        .HasForeignKey("ResponsibilityId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResourceManagement.Models.WorkGroup", "WorkGroup")
                        .WithMany()
                        .HasForeignKey("WorkGroupId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resource");

                    b.Navigation("Responsibility");

                    b.Navigation("WorkGroup");
                });

            modelBuilder.Entity("ResourceManagement.Models.WorkGroupResource", b =>
                {
                    b.HasOne("ResourceManagement.Models.Resource", "Resource")
                        .WithMany("WorkGroupResources")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResourceManagement.Models.WorkGroup", "WorkGroup")
                        .WithMany("WorkGroupResources")
                        .HasForeignKey("WorkGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resource");

                    b.Navigation("WorkGroup");
                });

            modelBuilder.Entity("ResourceManagement.Models.Position", b =>
                {
                    b.Navigation("Resources");
                });

            modelBuilder.Entity("ResourceManagement.Models.Resource", b =>
                {
                    b.Navigation("WorkGroupResources");

                    b.Navigation("Workings");
                });

            modelBuilder.Entity("ResourceManagement.Models.WorkGroup", b =>
                {
                    b.Navigation("WorkGroupResources");
                });
#pragma warning restore 612, 618
        }
    }
}