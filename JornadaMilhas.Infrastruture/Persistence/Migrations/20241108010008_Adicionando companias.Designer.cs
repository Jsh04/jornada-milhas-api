﻿// <auto-generated />
using System;
using JornadaMilhas.Infrastruture.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JornadaMilhas.Infrastruture.Migrations
{
    [DbContext(typeof(JornadaMilhasDbContext))]
    [Migration("20241108010008_Adicionando companias")]
    partial class Adicionandocompanias
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JornadaMilhas.Common.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("DtCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Genre")
                        .HasMaxLength(1)
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Picture")
                        .HasMaxLength(1000)
                        .HasColumnType("varbinary(1000)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("JornadaMilhas.Common.Persistence.Queue.OutboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Error")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("ProcessedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("OutboxMessage");
                });

            modelBuilder.Entity("JornadaMilhas.Core.Entities.Companies.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("DtCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtFoundation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("OriginCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("JornadaMilhas.Core.Entities.Depoiments.Depoiment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("DepoimentDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtUpdated")
                        .HasColumnType("datetime2");

                    b.Property<long>("IdUser")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Picture")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Depoimentos");
                });

            modelBuilder.Entity("JornadaMilhas.Core.Entities.Destinys.Destiny", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("DescriptionEnglish")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionPortuguese")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Subtitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Destinos");
                });

            modelBuilder.Entity("JornadaMilhas.Core.Entities.ImagemDestino", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("DestinoId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DtCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtUpdated")
                        .HasColumnType("datetime2");

                    b.Property<long>("IdDestino")
                        .HasColumnType("bigint");

                    b.Property<byte[]>("ImagemBytes")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DestinoId");

                    b.ToTable("ImagemDestino");
                });

            modelBuilder.Entity("JornadaMilhas.Core.Entities.Users.UserAdmin.UserAdmin", b =>
                {
                    b.HasBaseType("JornadaMilhas.Common.Entities.User");

                    b.Property<string>("CodeEmployee")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CodeEmployee");

                    b.ToTable("UserAdmin", (string)null);
                });

            modelBuilder.Entity("JornadaMilhas.Core.Entities.Users.UserLimited.UserLimited", b =>
                {
                    b.HasBaseType("JornadaMilhas.Common.Entities.User");

                    b.Property<bool>("EmailExists")
                        .HasColumnType("bit");

                    b.ToTable("UserLimited", (string)null);
                });

            modelBuilder.Entity("JornadaMilhas.Common.Entities.User", b =>
                {
                    b.OwnsOne("JornadaMilhas.Common.ValueObjects.Email", "ConfirmEmail", b1 =>
                        {
                            b1.Property<long>("UserId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("UserId");

                            b1.HasIndex("Address")
                                .IsUnique();

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("JornadaMilhas.Common.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<long>("UserId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("UserId");

                            b1.HasIndex("Address")
                                .IsUnique();

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("JornadaMilhas.Common.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<long>("UserId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Adress")
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)");

                            b1.Property<string>("Cep")
                                .HasMaxLength(8)
                                .HasColumnType("nvarchar(8)");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("District")
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(2)
                                .HasColumnType("nvarchar(2)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("JornadaMilhas.Common.ValueObjects.Cpf", "Cpf", b1 =>
                        {
                            b1.Property<long>("UserId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("nvarchar(11)");

                            b1.HasKey("UserId");

                            b1.HasIndex("Number")
                                .IsUnique();

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("JornadaMilhas.Common.ValueObjects.DateOfBirth", "DtBirth", b1 =>
                        {
                            b1.Property<long>("UserId")
                                .HasColumnType("bigint");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("datetime2");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("JornadaMilhas.Common.ValueObjects.Phone", "Phone", b1 =>
                        {
                            b1.Property<long>("UserId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("nvarchar(11)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("ConfirmEmail")
                        .IsRequired();

                    b.Navigation("Cpf")
                        .IsRequired();

                    b.Navigation("DtBirth")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Phone")
                        .IsRequired();
                });

            modelBuilder.Entity("JornadaMilhas.Core.Entities.Depoiments.Depoiment", b =>
                {
                    b.HasOne("JornadaMilhas.Core.Entities.Users.UserLimited.UserLimited", "User")
                        .WithMany("Depoimentos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("JornadaMilhas.Core.Entities.ImagemDestino", b =>
                {
                    b.HasOne("JornadaMilhas.Core.Entities.Destinys.Destiny", "Destino")
                        .WithMany("Imagens")
                        .HasForeignKey("DestinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destino");
                });

            modelBuilder.Entity("JornadaMilhas.Core.Entities.Users.UserAdmin.UserAdmin", b =>
                {
                    b.HasOne("JornadaMilhas.Common.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("JornadaMilhas.Core.Entities.Users.UserAdmin.UserAdmin", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JornadaMilhas.Core.Entities.Users.UserLimited.UserLimited", b =>
                {
                    b.HasOne("JornadaMilhas.Common.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("JornadaMilhas.Core.Entities.Users.UserLimited.UserLimited", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JornadaMilhas.Core.Entities.Destinys.Destiny", b =>
                {
                    b.Navigation("Imagens");
                });

            modelBuilder.Entity("JornadaMilhas.Core.Entities.Users.UserLimited.UserLimited", b =>
                {
                    b.Navigation("Depoimentos");
                });
#pragma warning restore 612, 618
        }
    }
}
