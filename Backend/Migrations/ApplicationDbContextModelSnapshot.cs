﻿// <auto-generated />
using System;
using CourseHouse.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoursesHouse.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Backend.Models.CourseModels.CourseCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CategoryId");

                    b.ToTable("CourseCategories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "IT"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Math"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Physics"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Biology"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "Chemistry"
                        },
                        new
                        {
                            CategoryId = 6,
                            CategoryName = "History"
                        },
                        new
                        {
                            CategoryId = 7,
                            CategoryName = "Geography"
                        },
                        new
                        {
                            CategoryId = 8,
                            CategoryName = "Literature"
                        },
                        new
                        {
                            CategoryId = 9,
                            CategoryName = "Music"
                        },
                        new
                        {
                            CategoryId = 10,
                            CategoryName = "Art"
                        },
                        new
                        {
                            CategoryId = 11,
                            CategoryName = "Sport"
                        },
                        new
                        {
                            CategoryId = 12,
                            CategoryName = "Cooking"
                        },
                        new
                        {
                            CategoryId = 13,
                            CategoryName = "Gardening"
                        },
                        new
                        {
                            CategoryId = 14,
                            CategoryName = "Photography"
                        },
                        new
                        {
                            CategoryId = 15,
                            CategoryName = "Fashion"
                        },
                        new
                        {
                            CategoryId = 16,
                            CategoryName = "Health"
                        },
                        new
                        {
                            CategoryId = 17,
                            CategoryName = "Psychology"
                        },
                        new
                        {
                            CategoryId = 18,
                            CategoryName = "Business"
                        },
                        new
                        {
                            CategoryId = 19,
                            CategoryName = "Marketing"
                        },
                        new
                        {
                            CategoryId = 20,
                            CategoryName = "Economy"
                        },
                        new
                        {
                            CategoryId = 21,
                            CategoryName = "Management"
                        });
                });

            modelBuilder.Entity("Backend.Models.CourseModels.CourseCategoryMapping", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("CourseCategoryMapping");
                });

            modelBuilder.Entity("Backend.Models.UserModels.UserTestAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AnswerId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserTestAnswers");
                });

            modelBuilder.Entity("CourseHouse.Models.Content", b =>
                {
                    b.Property<int>("ContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ContentType")
                        .HasColumnType("int");

                    b.Property<string>("ContentUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Correct")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("CourseViewId")
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ContentId");

                    b.HasIndex("CourseViewId");

                    b.ToTable("Contents");
                });

            modelBuilder.Entity("CourseHouse.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CourseDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("CoursePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("PurchaseId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("CourseId");

                    b.HasIndex("PurchaseId");

                    b.HasIndex("UserId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CourseHouse.Models.CourseComment", b =>
                {
                    b.Property<int>("CourseCommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CommentContent")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("varchar(450)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("id")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("CourseCommentId");

                    b.HasIndex("CourseId");

                    b.HasIndex("id");

                    b.ToTable("CourseComments");
                });

            modelBuilder.Entity("CourseHouse.Models.CourseGrade", b =>
                {
                    b.Property<int>("CourseGradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<decimal>("Grade")
                        .HasColumnType("decimal(2,2)");

                    b.Property<string>("id")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("CourseGradeId");

                    b.HasIndex("CourseId");

                    b.HasIndex("id");

                    b.ToTable("CourseGrades");
                });

            modelBuilder.Entity("CourseHouse.Models.CourseView", b =>
                {
                    b.Property<int>("ViewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("CourseViewOrder")
                        .HasColumnType("int");

                    b.HasKey("ViewId");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseViews");
                });

            modelBuilder.Entity("CourseHouse.Models.CreditCard", b =>
                {
                    b.Property<int>("CreditCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CreditCardNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cvv")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("HolderName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("id")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("CreditCardId");

                    b.HasIndex("id");

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("CourseHouse.Models.LastVisited", b =>
                {
                    b.Property<int>("LastVisitedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("LastVisitedCourses")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("LastVisitedTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("id")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LastVisitedId");

                    b.HasIndex("id");

                    b.ToTable("LastVisited");
                });

            modelBuilder.Entity("CourseHouse.Models.Purchase", b =>
                {
                    b.Property<int>("PurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("CreditCardId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchasedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("TotalSpend")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("id")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("PurchaseId");

                    b.HasIndex("CourseId");

                    b.HasIndex("CreditCardId");

                    b.HasIndex("id");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("CourseHouse.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CourseHouse.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "6d35dcd9-5dc8-4fc3-8b64-0a4320dbf20d",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "eeca333f-43ab-4d78-93d7-fbe8f068eaa2",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Backend.Models.CourseModels.CourseCategoryMapping", b =>
                {
                    b.HasOne("Backend.Models.CourseModels.CourseCategory", "CourseCategory")
                        .WithMany("CourseCategoryMappings")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseHouse.Models.Course", "Course")
                        .WithMany("CourseCategoryMappings")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("CourseCategory");
                });

            modelBuilder.Entity("CourseHouse.Models.Content", b =>
                {
                    b.HasOne("CourseHouse.Models.CourseView", "CourseView")
                        .WithMany("Content")
                        .HasForeignKey("CourseViewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseView");
                });

            modelBuilder.Entity("CourseHouse.Models.Course", b =>
                {
                    b.HasOne("CourseHouse.Models.Purchase", null)
                        .WithMany("PurachasedCourses")
                        .HasForeignKey("PurchaseId");

                    b.HasOne("CourseHouse.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CourseHouse.Models.CourseComment", b =>
                {
                    b.HasOne("CourseHouse.Models.Course", "Course")
                        .WithMany("Comments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseHouse.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("CourseHouse.Models.CourseGrade", b =>
                {
                    b.HasOne("CourseHouse.Models.Course", "Course")
                        .WithMany("Grades")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseHouse.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("CourseHouse.Models.CourseView", b =>
                {
                    b.HasOne("CourseHouse.Models.Course", "Course")
                        .WithMany("CourseViews")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("CourseHouse.Models.CreditCard", b =>
                {
                    b.HasOne("CourseHouse.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CourseHouse.Models.LastVisited", b =>
                {
                    b.HasOne("CourseHouse.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CourseHouse.Models.Purchase", b =>
                {
                    b.HasOne("CourseHouse.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseHouse.Models.CreditCard", "CereditCard")
                        .WithMany()
                        .HasForeignKey("CreditCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseHouse.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CereditCard");

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CourseHouse.Models.User", b =>
                {
                    b.HasOne("CourseHouse.Models.Course", null)
                        .WithMany("EnrolledUsers")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CourseHouse.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CourseHouse.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseHouse.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CourseHouse.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Models.CourseModels.CourseCategory", b =>
                {
                    b.Navigation("CourseCategoryMappings");
                });

            modelBuilder.Entity("CourseHouse.Models.Course", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("CourseCategoryMappings");

                    b.Navigation("CourseViews");

                    b.Navigation("EnrolledUsers");

                    b.Navigation("Grades");
                });

            modelBuilder.Entity("CourseHouse.Models.CourseView", b =>
                {
                    b.Navigation("Content");
                });

            modelBuilder.Entity("CourseHouse.Models.Purchase", b =>
                {
                    b.Navigation("PurachasedCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
