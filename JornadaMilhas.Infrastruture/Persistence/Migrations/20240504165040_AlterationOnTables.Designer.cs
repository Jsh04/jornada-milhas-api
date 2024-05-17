﻿// <auto-generated />
using System;
using JornadaMilhas.Infrastruture.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JornadaMilhas.Infrastruture.Persistence.Migrations
{
    [DbContext(typeof(JornadaMilhasDbContext))]
    [Migration("20240504165040_AlterationOnTables")]
    partial class AlterationOnTables
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

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("JornadaMilhas.Core.Entities.Depoimento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("DescricaoDepoimento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtUpdated")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Foto")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<long>("IdUsuario")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Users");

                    b.HasDiscriminator().HasValue("UserAdmin");
                });

            modelBuilder.Entity("JornadaMilhas.Core.Entities.Users.UserLimited.UserLimited", b =>
                {
                    b.HasBaseType("JornadaMilhas.Common.Entities.User");

                    b.Property<bool>("EmailExists")
                        .HasColumnType("bit");

                    b.ToTable("Users");

                    b.HasDiscriminator().HasValue("UserLimited");
                });

            modelBuilder.Entity("JornadaMilhas.Common.Entities.User", b =>
                {
                    b.OwnsOne("JornadaMilhas.Common.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<long>("UserId")
                                .HasColumnType("bigint");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("JornadaMilhas.Common.ValueObjects.Email", "ConfirmEmail", b1 =>
                        {
                            b1.Property<long>("UserId")
                                .HasColumnType("bigint");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("JornadaMilhas.Common.ValueObjects.Cpf", "Cpf", b1 =>
                        {
                            b1.Property<long>("UserId")
                                .HasColumnType("bigint");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("JornadaMilhas.Common.ValueObjects.DateOfBirth", "DtBirth", b1 =>
                        {
                            b1.Property<long>("UserId")
                                .HasColumnType("bigint");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("JornadaMilhas.Common.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<long>("UserId")
                                .HasColumnType("bigint");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("JornadaMilhas.Common.ValueObjects.Phone", "Phone", b1 =>
                        {
                            b1.Property<long>("UserId")
                                .HasColumnType("bigint");

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

            modelBuilder.Entity("JornadaMilhas.Core.Entities.Depoimento", b =>
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