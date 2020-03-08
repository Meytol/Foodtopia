using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Key = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeactivatedByUserId = table.Column<int>(nullable: true),
                    DeactivatedOn = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: true),
                    IsMale = table.Column<bool>(nullable: false),
                    AvatarImageAddress = table.Column<string>(nullable: true),
                    LastLogin = table.Column<DateTime>(nullable: false),
                    PhonenumberConfirmed = table.Column<bool>(nullable: false),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsLockout = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTime>(nullable: true),
                    AccessFailedCount = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationActions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    ActionLevel = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationActions_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationActions_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationActions_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationActions_ApplicationActions_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ApplicationActions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationActions_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AuthenticationCodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(maxLength: 10, nullable: true),
                    ExpiryDurationTime = table.Column<TimeSpan>(nullable: false),
                    IsUse = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthenticationCodes_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AuthenticationCodes_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AuthenticationCodes_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuthenticationCodes_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Carts_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Carts_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    HtmlBody = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emails_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Emails_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Emails_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emails_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FoodCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DefaultImageAddress = table.Column<string>(nullable: true),
                    DefaultImageAlt = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodCategories_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FoodCategories_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FoodCategories_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodCategories_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    FoodCategoryId = table.Column<int>(nullable: false),
                    DefaultImageAddress = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foods_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Foods_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Foods_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Foods_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DiscountCodeId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provinces_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Provinces_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Provinces_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Provinces_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RestaurantFoodComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsConfirmed = table.Column<int>(nullable: false),
                    Text = table.Column<string>(maxLength: 1000, nullable: true),
                    Score = table.Column<short>(nullable: false),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantFoodComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantFoodComments_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RestaurantFoodComments_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RestaurantFoodComments_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RestaurantFoodComments_RestaurantFoodComments_ParentId",
                        column: x => x.ParentId,
                        principalTable: "RestaurantFoodComments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RestaurantFoodComments_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RestaurantTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    AvatarImageAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantTypes_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RestaurantTypes_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RestaurantTypes_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RestaurantTypes_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Roles_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Roles_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Roles_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Smses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Body = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Smses_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Smses_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Smses_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Smses_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserDiscountCodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EndUserId = table.Column<int>(nullable: true),
                    DiscountType = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: true),
                    Percentage = table.Column<float>(nullable: true),
                    MaxAmount = table.Column<decimal>(nullable: true),
                    ExpireDate = table.Column<DateTime>(nullable: true),
                    MaxUsage = table.Column<int>(nullable: false),
                    Usage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDiscountCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDiscountCodes_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserDiscountCodes_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserDiscountCodes_Users_EndUserId",
                        column: x => x.EndUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserDiscountCodes_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDiscountCodes_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmailUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EmailId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailUsers_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmailUsers_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmailUsers_Emails_EmailId",
                        column: x => x.EmailId,
                        principalTable: "Emails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmailUsers_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmailUsers_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FoodTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    FoodId = table.Column<int>(nullable: false),
                    FoodCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodTypes_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FoodTypes_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FoodTypes_FoodCategories_FoodCategoryId",
                        column: x => x.FoodCategoryId,
                        principalTable: "FoodCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FoodTypes_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FoodTypes_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodTypes_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RestaurantFoods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    FoodId = table.Column<int>(nullable: false),
                    MakingTime = table.Column<TimeSpan>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    CustomizeFoodName = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantFoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantFoods_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RestaurantFoods_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RestaurantFoods_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RestaurantFoods_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RestaurantFoods_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ProvinceId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    CityCode = table.Column<string>(maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cities_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cities_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cities_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cities_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleActions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    ActionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleActions_ApplicationActions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "ApplicationActions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleActions_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleActions_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleActions_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleActions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleActions_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SmsUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    SmsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmsUsers_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SmsUsers_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SmsUsers_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SmsUsers_Smses_SmsId",
                        column: x => x.SmsId,
                        principalTable: "Smses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SmsUsers_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CartRestaurantFoods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CartId = table.Column<int>(nullable: false),
                    RestaurantFoodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartRestaurantFoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartRestaurantFoods_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartRestaurantFoods_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartRestaurantFoods_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartRestaurantFoods_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartRestaurantFoods_RestaurantFoods_RestaurantFoodId",
                        column: x => x.RestaurantFoodId,
                        principalTable: "RestaurantFoods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartRestaurantFoods_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RestaurantFoodId = table.Column<int>(nullable: false),
                    Quentity = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    OrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_RestaurantFoods_RestaurantFoodId",
                        column: x => x.RestaurantFoodId,
                        principalTable: "RestaurantFoods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RestaurantFoodDiscounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RestaurantFoodId = table.Column<int>(nullable: false),
                    DiscountType = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: true),
                    Percentage = table.Column<float>(nullable: true),
                    MaxAmount = table.Column<decimal>(nullable: true),
                    ExpireDate = table.Column<DateTime>(nullable: true),
                    MaxUsage = table.Column<int>(nullable: false),
                    Usage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantFoodDiscounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantFoodDiscounts_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RestaurantFoodDiscounts_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RestaurantFoodDiscounts_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RestaurantFoodDiscounts_RestaurantFoods_RestaurantFoodId",
                        column: x => x.RestaurantFoodId,
                        principalTable: "RestaurantFoods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RestaurantFoodDiscounts_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RestaurantFoodImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(maxLength: 250, nullable: true),
                    AltText = table.Column<string>(maxLength: 250, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    RestaurantFoodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantFoodImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantFoodImages_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RestaurantFoodImages_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RestaurantFoodImages_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RestaurantFoodImages_RestaurantFoods_RestaurantFoodId",
                        column: x => x.RestaurantFoodId,
                        principalTable: "RestaurantFoods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RestaurantFoodImages_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RestaurantFoodReatings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Score = table.Column<short>(nullable: false),
                    RestaurantFoodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantFoodReatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantFoodReatings_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RestaurantFoodReatings_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RestaurantFoodReatings_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RestaurantFoodReatings_RestaurantFoods_RestaurantFoodId",
                        column: x => x.RestaurantFoodId,
                        principalTable: "RestaurantFoods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RestaurantFoodReatings_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AvaterImageAddress = table.Column<string>(nullable: true),
                    BannerImageAddress = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Address = table.Column<string>(maxLength: 1000, nullable: true),
                    PrimaryPhoneNumber = table.Column<string>(maxLength: 10, nullable: true),
                    SecondryPhoneNumber = table.Column<string>(maxLength: 10, nullable: true),
                    MobilePhoneNumber = table.Column<string>(maxLength: 11, nullable: true),
                    RestaurantTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurants_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Restaurants_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Restaurants_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Restaurants_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Restaurants_RestaurantTypes_RestaurantTypeId",
                        column: x => x.RestaurantTypeId,
                        principalTable: "RestaurantTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Restaurants_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 10, nullable: true),
                    Address = table.Column<string>(maxLength: 1500, nullable: true),
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAddresses_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAddresses_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAddresses_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAddresses_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RestaurantUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RestaurantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantUsers_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RestaurantUsers_Users_DeletedByUserId",
                        column: x => x.DeletedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RestaurantUsers_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RestaurantUsers_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RestaurantUsers_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationActions_CreatedByUserId",
                table: "ApplicationActions",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationActions_DeletedByUserId",
                table: "ApplicationActions",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationActions_OwnerUserId",
                table: "ApplicationActions",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationActions_ParentId",
                table: "ApplicationActions",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationActions_UpdatedByUserId",
                table: "ApplicationActions",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationCodes_CreatedByUserId",
                table: "AuthenticationCodes",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationCodes_DeletedByUserId",
                table: "AuthenticationCodes",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationCodes_OwnerUserId",
                table: "AuthenticationCodes",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationCodes_UpdatedByUserId",
                table: "AuthenticationCodes",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartRestaurantFoods_CartId",
                table: "CartRestaurantFoods",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartRestaurantFoods_CreatedByUserId",
                table: "CartRestaurantFoods",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartRestaurantFoods_DeletedByUserId",
                table: "CartRestaurantFoods",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartRestaurantFoods_OwnerUserId",
                table: "CartRestaurantFoods",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartRestaurantFoods_RestaurantFoodId",
                table: "CartRestaurantFoods",
                column: "RestaurantFoodId");

            migrationBuilder.CreateIndex(
                name: "IX_CartRestaurantFoods_UpdatedByUserId",
                table: "CartRestaurantFoods",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CreatedByUserId",
                table: "Carts",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_DeletedByUserId",
                table: "Carts",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_OwnerUserId",
                table: "Carts",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UpdatedByUserId",
                table: "Carts",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CreatedByUserId",
                table: "Cities",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_DeletedByUserId",
                table: "Cities",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_OwnerUserId",
                table: "Cities",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_UpdatedByUserId",
                table: "Cities",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_CreatedByUserId",
                table: "Emails",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_DeletedByUserId",
                table: "Emails",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_OwnerUserId",
                table: "Emails",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_UpdatedByUserId",
                table: "Emails",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailUsers_CreatedByUserId",
                table: "EmailUsers",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailUsers_DeletedByUserId",
                table: "EmailUsers",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailUsers_EmailId",
                table: "EmailUsers",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailUsers_OwnerUserId",
                table: "EmailUsers",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailUsers_UpdatedByUserId",
                table: "EmailUsers",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodCategories_CreatedByUserId",
                table: "FoodCategories",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodCategories_DeletedByUserId",
                table: "FoodCategories",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodCategories_OwnerUserId",
                table: "FoodCategories",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodCategories_UpdatedByUserId",
                table: "FoodCategories",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_CreatedByUserId",
                table: "Foods",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_DeletedByUserId",
                table: "Foods",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_OwnerUserId",
                table: "Foods",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_UpdatedByUserId",
                table: "Foods",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodTypes_CreatedByUserId",
                table: "FoodTypes",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodTypes_DeletedByUserId",
                table: "FoodTypes",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodTypes_FoodCategoryId",
                table: "FoodTypes",
                column: "FoodCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodTypes_FoodId",
                table: "FoodTypes",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodTypes_OwnerUserId",
                table: "FoodTypes",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodTypes_UpdatedByUserId",
                table: "FoodTypes",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_CreatedByUserId",
                table: "OrderDetails",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_DeletedByUserId",
                table: "OrderDetails",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OwnerUserId",
                table: "OrderDetails",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_RestaurantFoodId",
                table: "OrderDetails",
                column: "RestaurantFoodId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_UpdatedByUserId",
                table: "OrderDetails",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CreatedByUserId",
                table: "Orders",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeletedByUserId",
                table: "Orders",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OwnerUserId",
                table: "Orders",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UpdatedByUserId",
                table: "Orders",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_CreatedByUserId",
                table: "Provinces",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_DeletedByUserId",
                table: "Provinces",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_OwnerUserId",
                table: "Provinces",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_UpdatedByUserId",
                table: "Provinces",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoodComments_CreatedByUserId",
                table: "RestaurantFoodComments",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoodComments_DeletedByUserId",
                table: "RestaurantFoodComments",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoodComments_OwnerUserId",
                table: "RestaurantFoodComments",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoodComments_ParentId",
                table: "RestaurantFoodComments",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoodComments_UpdatedByUserId",
                table: "RestaurantFoodComments",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoodDiscounts_CreatedByUserId",
                table: "RestaurantFoodDiscounts",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoodDiscounts_DeletedByUserId",
                table: "RestaurantFoodDiscounts",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoodDiscounts_OwnerUserId",
                table: "RestaurantFoodDiscounts",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoodDiscounts_RestaurantFoodId",
                table: "RestaurantFoodDiscounts",
                column: "RestaurantFoodId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoodDiscounts_UpdatedByUserId",
                table: "RestaurantFoodDiscounts",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoodImages_CreatedByUserId",
                table: "RestaurantFoodImages",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoodImages_DeletedByUserId",
                table: "RestaurantFoodImages",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoodImages_OwnerUserId",
                table: "RestaurantFoodImages",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoodImages_RestaurantFoodId",
                table: "RestaurantFoodImages",
                column: "RestaurantFoodId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoodImages_UpdatedByUserId",
                table: "RestaurantFoodImages",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoodReatings_CreatedByUserId",
                table: "RestaurantFoodReatings",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoodReatings_DeletedByUserId",
                table: "RestaurantFoodReatings",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoodReatings_OwnerUserId",
                table: "RestaurantFoodReatings",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoodReatings_RestaurantFoodId",
                table: "RestaurantFoodReatings",
                column: "RestaurantFoodId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoodReatings_UpdatedByUserId",
                table: "RestaurantFoodReatings",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoods_CreatedByUserId",
                table: "RestaurantFoods",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoods_DeletedByUserId",
                table: "RestaurantFoods",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoods_FoodId",
                table: "RestaurantFoods",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoods_OwnerUserId",
                table: "RestaurantFoods",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFoods_UpdatedByUserId",
                table: "RestaurantFoods",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CityId",
                table: "Restaurants",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CreatedByUserId",
                table: "Restaurants",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_DeletedByUserId",
                table: "Restaurants",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_OwnerUserId",
                table: "Restaurants",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_RestaurantTypeId",
                table: "Restaurants",
                column: "RestaurantTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_UpdatedByUserId",
                table: "Restaurants",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantTypes_CreatedByUserId",
                table: "RestaurantTypes",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantTypes_DeletedByUserId",
                table: "RestaurantTypes",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantTypes_OwnerUserId",
                table: "RestaurantTypes",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantTypes_UpdatedByUserId",
                table: "RestaurantTypes",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantUsers_CreatedByUserId",
                table: "RestaurantUsers",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantUsers_DeletedByUserId",
                table: "RestaurantUsers",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantUsers_OwnerUserId",
                table: "RestaurantUsers",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantUsers_RestaurantId",
                table: "RestaurantUsers",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantUsers_UpdatedByUserId",
                table: "RestaurantUsers",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleActions_ActionId",
                table: "RoleActions",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleActions_CreatedByUserId",
                table: "RoleActions",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleActions_DeletedByUserId",
                table: "RoleActions",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleActions_OwnerUserId",
                table: "RoleActions",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleActions_RoleId",
                table: "RoleActions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleActions_UpdatedByUserId",
                table: "RoleActions",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CreatedByUserId",
                table: "Roles",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_DeletedByUserId",
                table: "Roles",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_OwnerUserId",
                table: "Roles",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UpdatedByUserId",
                table: "Roles",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Smses_CreatedByUserId",
                table: "Smses",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Smses_DeletedByUserId",
                table: "Smses",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Smses_OwnerUserId",
                table: "Smses",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Smses_UpdatedByUserId",
                table: "Smses",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SmsUsers_CreatedByUserId",
                table: "SmsUsers",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SmsUsers_DeletedByUserId",
                table: "SmsUsers",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SmsUsers_OwnerUserId",
                table: "SmsUsers",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SmsUsers_SmsId",
                table: "SmsUsers",
                column: "SmsId");

            migrationBuilder.CreateIndex(
                name: "IX_SmsUsers_UpdatedByUserId",
                table: "SmsUsers",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_CityId",
                table: "UserAddresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_CreatedByUserId",
                table: "UserAddresses",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_DeletedByUserId",
                table: "UserAddresses",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_OwnerUserId",
                table: "UserAddresses",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_UpdatedByUserId",
                table: "UserAddresses",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiscountCodes_CreatedByUserId",
                table: "UserDiscountCodes",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiscountCodes_DeletedByUserId",
                table: "UserDiscountCodes",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiscountCodes_EndUserId",
                table: "UserDiscountCodes",
                column: "EndUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiscountCodes_OwnerUserId",
                table: "UserDiscountCodes",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiscountCodes_UpdatedByUserId",
                table: "UserDiscountCodes",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_CreatedByUserId",
                table: "UserRoles",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_DeletedByUserId",
                table: "UserRoles",
                column: "DeletedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_OwnerUserId",
                table: "UserRoles",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UpdatedByUserId",
                table: "UserRoles",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthenticationCodes");

            migrationBuilder.DropTable(
                name: "CartRestaurantFoods");

            migrationBuilder.DropTable(
                name: "EmailUsers");

            migrationBuilder.DropTable(
                name: "FoodTypes");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "RestaurantFoodComments");

            migrationBuilder.DropTable(
                name: "RestaurantFoodDiscounts");

            migrationBuilder.DropTable(
                name: "RestaurantFoodImages");

            migrationBuilder.DropTable(
                name: "RestaurantFoodReatings");

            migrationBuilder.DropTable(
                name: "RestaurantUsers");

            migrationBuilder.DropTable(
                name: "RoleActions");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "SmsUsers");

            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.DropTable(
                name: "UserDiscountCodes");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "FoodCategories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "RestaurantFoods");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "ApplicationActions");

            migrationBuilder.DropTable(
                name: "Smses");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "RestaurantTypes");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
