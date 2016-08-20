using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LennyIdentity.Models;

namespace LennyIdentity.Migrations
{
    [DbContext(typeof(IdentityContext))]
    [Migration("20160820035734_updatedb")]
    partial class updatedb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("LennyIdentity.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("RoleName")
                        .HasColumnName("rolename");

                    b.HasKey("Id");

                    b.ToTable("t_role");
                });

            modelBuilder.Entity("LennyIdentity.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Password")
                        .HasColumnName("password")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("UserName")
                        .HasColumnName("username")
                        .HasAnnotation("MaxLength", 20);

                    b.HasKey("Id");

                    b.ToTable("t_user");
                });

            modelBuilder.Entity("LennyIdentity.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("RoleId")
                        .HasColumnName("role_id");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("userrole");
                });
        }
    }
}
