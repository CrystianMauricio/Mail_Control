﻿// <auto-generated />
using System;
using Backend.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Email.Management.Migrations
{
    [DbContext(typeof(DaoContext))]
    partial class DaoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Backend.Domain.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30) CHARACTER SET utf8mb4")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .HasMaxLength(130)
                        .HasColumnType("varchar(130) CHARACTER SET utf8mb4")
                        .HasColumnName("password");

                    b.Property<Guid>("Token")
                        .HasColumnType("char(36)")
                        .HasColumnName("token");

                    b.HasKey("Id")
                        .HasName("pk_user");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Email", "Password");

                    b.ToTable("user");
                });

            modelBuilder.Entity("Email.Management.Domain.Mail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150) CHARACTER SET utf8mb4")
                        .HasColumnName("email_address");

                    b.Property<bool>("EnableSsl")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("enable_ssl");

                    b.Property<string>("Host")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150) CHARACTER SET utf8mb4")
                        .HasColumnName("host");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT")
                        .HasColumnName("password");

                    b.Property<int>("Port")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(587)
                        .HasColumnName("port");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_mail");

                    b.HasIndex("UserId");

                    b.ToTable("mail");
                });

            modelBuilder.Entity("Email.Management.Domain.Template", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .HasColumnType("MEDIUMTEXT")
                        .HasColumnName("content");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasColumnName("description");

                    b.Property<bool>("IsHtml")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_html");

                    b.Property<long>("MailId")
                        .HasColumnType("bigint")
                        .HasColumnName("mail_id");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasColumnName("name");

                    b.Property<string>("Subject")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasColumnName("subject");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_template");

                    b.HasIndex("MailId");

                    b.HasIndex("UserId");

                    b.ToTable("template");
                });

            modelBuilder.Entity("Email.Management.Domain.Mail", b =>
                {
                    b.HasOne("Backend.Domain.User", "User")
                        .WithMany("Mails")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_mail_user_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Email.Management.Domain.Template", b =>
                {
                    b.HasOne("Email.Management.Domain.Mail", "Mail")
                        .WithMany("Templates")
                        .HasForeignKey("MailId")
                        .HasConstraintName("fk_template_mail_mail_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Domain.User", "User")
                        .WithMany("Templates")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_template_user_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mail");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Backend.Domain.User", b =>
                {
                    b.Navigation("Mails");

                    b.Navigation("Templates");
                });

            modelBuilder.Entity("Email.Management.Domain.Mail", b =>
                {
                    b.Navigation("Templates");
                });
#pragma warning restore 612, 618
        }
    }
}