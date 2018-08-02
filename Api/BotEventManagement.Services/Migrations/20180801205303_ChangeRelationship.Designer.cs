﻿// <auto-generated />
using System;
using BotEventManagement.Services.Model.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BotEventManagement.Services.Migrations
{
    [DbContext(typeof(BotEventManagementContext))]
    [Migration("20180801205303_ChangeRelationship")]
    partial class ChangeRelationship
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BotEventManagement.Services.Model.Database.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<string>("EventId");

                    b.Property<string>("Name");

                    b.Property<int>("SpeakerId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("SpeakerId");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("BotEventManagement.Services.Model.Database.Event", b =>
                {
                    b.Property<string>("EventId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("EventId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("BotEventManagement.Services.Model.Database.EventParticipants", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EventId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("EventParticipants");
                });

            modelBuilder.Entity("BotEventManagement.Services.Model.Database.Speaker", b =>
                {
                    b.Property<int>("SpeakerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Biography");

                    b.Property<string>("EventId");

                    b.Property<string>("Name");

                    b.Property<string>("UploadedPhoto");

                    b.HasKey("SpeakerId");

                    b.HasIndex("EventId");

                    b.ToTable("Speaker");
                });

            modelBuilder.Entity("BotEventManagement.Services.Model.Database.Activity", b =>
                {
                    b.HasOne("BotEventManagement.Services.Model.Database.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId");

                    b.HasOne("BotEventManagement.Services.Model.Database.Speaker", "Speaker")
                        .WithMany("Activity")
                        .HasForeignKey("SpeakerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BotEventManagement.Services.Model.Database.Event", b =>
                {
                    b.OwnsOne("BotEventManagement.Services.Model.Database.Address", "Address", b1 =>
                        {
                            b1.Property<string>("EventId");

                            b1.Property<double>("Latitude")
                                .HasColumnName("Latitude");

                            b1.Property<double>("Longitude")
                                .HasColumnName("Longitude");

                            b1.Property<string>("Street")
                                .HasColumnName("Street");

                            b1.ToTable("Event");

                            b1.HasOne("BotEventManagement.Services.Model.Database.Event")
                                .WithOne("Address")
                                .HasForeignKey("BotEventManagement.Services.Model.Database.Address", "EventId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("BotEventManagement.Services.Model.Database.EventParticipants", b =>
                {
                    b.HasOne("BotEventManagement.Services.Model.Database.Event", "Event")
                        .WithMany("EventParticipants")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("BotEventManagement.Services.Model.Database.Speaker", b =>
                {
                    b.HasOne("BotEventManagement.Services.Model.Database.Event", "Event")
                        .WithMany("Speakers")
                        .HasForeignKey("EventId");
                });
#pragma warning restore 612, 618
        }
    }
}
