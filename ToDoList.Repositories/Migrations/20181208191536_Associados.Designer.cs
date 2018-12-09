﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.Repositories.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20181208191536_Associados")]
    partial class Associados
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ToDoList.Domain.Associated", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("adress");

                    b.Property<string>("birthDate");

                    b.Property<string>("cep");

                    b.Property<string>("city");

                    b.Property<string>("cpf");

                    b.Property<string>("dateJoin");

                    b.Property<string>("email");

                    b.Property<int>("maritalstatusid");

                    b.Property<string>("name");

                    b.Property<string>("uf");

                    b.HasKey("id");

                    b.HasIndex("maritalstatusid");

                    b.ToTable("Associated");
                });

            modelBuilder.Entity("ToDoList.Domain.Dependent", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("associatedid");

                    b.Property<string>("birthDate");

                    b.Property<int>("kinshipid");

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.HasIndex("associatedid");

                    b.HasIndex("kinshipid");

                    b.ToTable("Dependent");
                });

            modelBuilder.Entity("ToDoList.Domain.KinShip", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("status");

                    b.HasKey("id");

                    b.ToTable("KinShip");
                });

            modelBuilder.Entity("ToDoList.Domain.MaritalStatus", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("status");

                    b.HasKey("id");

                    b.ToTable("MaritalStatus");
                });

            modelBuilder.Entity("ToDoList.Domain.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name")
                        .IsRequired();

                    b.Property<string>("password")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ToDoList.Domain.Associated", b =>
                {
                    b.HasOne("ToDoList.Domain.MaritalStatus", "maritalStatus")
                        .WithMany()
                        .HasForeignKey("maritalstatusid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ToDoList.Domain.Dependent", b =>
                {
                    b.HasOne("ToDoList.Domain.Associated", "associated")
                        .WithMany("depentents")
                        .HasForeignKey("associatedid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ToDoList.Domain.KinShip", "kinShip")
                        .WithMany()
                        .HasForeignKey("kinshipid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
