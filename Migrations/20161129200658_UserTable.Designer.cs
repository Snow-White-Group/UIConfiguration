using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using UIConfiguration.Models;

namespace UIConfiguration.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161129200658_UserTable")]
    partial class UserTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("UIConfiguration.Models.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EMail")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<bool>("Newsletter");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("SpeechID");

                    b.Property<string>("Thumbnail");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });
        }
    }
}
