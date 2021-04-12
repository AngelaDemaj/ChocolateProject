using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chocolate.DataAccess.Migrations
{
    public partial class InitialWithSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsBlacklisted = table.Column<bool>(type: "bit", nullable: false),
                    CV = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Category = table.Column<byte>(type: "tinyint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.CheckConstraint("cc_Product_Category", "Category IN (1,2,3)");
                });

            migrationBuilder.CreateTable(
                name: "RawMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentType = table.Column<byte>(type: "tinyint", nullable: false),
                    OrderPlaced = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderFulfilled = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.CheckConstraint("cc_Order_PaymentType", "PaymentType IN (1,2)");
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsHeadOfDepartment = table.Column<bool>(type: "bit", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkExperience = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Degree = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    WorkExperience = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Languages = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Qualifications = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => new { x.CustomerId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_Favorites_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RawMaterialProducts",
                columns: table => new
                {
                    RawMaterialId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterialProducts", x => new { x.RawMaterialId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_RawMaterialProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RawMaterialProducts_RawMaterials_RawMaterialId",
                        column: x => x.RawMaterialId,
                        principalTable: "RawMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discounts_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RawMaterialSuppliers",
                columns: table => new
                {
                    RawMaterialId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterialSuppliers", x => new { x.RawMaterialId, x.SupplierId });
                    table.ForeignKey(
                        name: "FK_RawMaterialSuppliers_RawMaterials_RawMaterialId",
                        column: x => x.RawMaterialId,
                        principalTable: "RawMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RawMaterialSuppliers_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StorageUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageUnits_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostCode = table.Column<short>(type: "smallint", maxLength: 100, nullable: false),
                    AddressNumber = table.Column<short>(type: "smallint", maxLength: 100, nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    WarehouseId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    CandidateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MailType = table.Column<byte>(type: "tinyint", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    WarehouseId = table.Column<int>(type: "int", nullable: true),
                    CandidateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                    table.CheckConstraint("cc_Email_MailType", "MailType IN (1,2)");
                    table.ForeignKey(
                        name: "FK_Emails_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emails_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emails_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emails_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emails_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Interviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfInterview = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interviews_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interviews_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leaves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveType = table.Column<byte>(type: "tinyint", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfDays = table.Column<int>(type: "int", nullable: false),
                    File = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaves", x => x.Id);
                    table.CheckConstraint("cc_Leave_Status", "Status IN (1,2,3)");
                    table.CheckConstraint("cc_Leave_LeaveType", "LeaveType IN (1,2,3,4,5)");
                    table.ForeignKey(
                        name: "FK_Leaves_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    When = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meetings_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneType = table.Column<byte>(type: "tinyint", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    WarehouseId = table.Column<int>(type: "int", nullable: true),
                    CandidateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.CheckConstraint("cc_Phone_PhoneType", "PhoneType IN (1,2)");
                    table.ForeignKey(
                        name: "FK_Phones_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Phones_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Phones_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Phones_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Phones_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CandidatePositions",
                columns: table => new
                {
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    RecruitStatus = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatePositions", x => new { x.CandidateId, x.PositionId });
                    table.CheckConstraint("cc_CandidatePosition_RecruitStatus", "RecruitStatus IN (1,2,3,4,5,6,7)");
                    table.ForeignKey(
                        name: "FK_CandidatePositions_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatePositions_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscountLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    DiscountPercentage = table.Column<double>(type: "float", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountLevels_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorageUnitId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sectors_StorageUnits_StorageUnitId",
                        column: x => x.StorageUnitId,
                        principalTable: "StorageUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveId = table.Column<int>(type: "int", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveHistories_Leaves_LeaveId",
                        column: x => x.LeaveId,
                        principalTable: "Leaves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeMeetings",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    MeetingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeMeetings", x => new { x.EmployeeId, x.MeetingId });
                    table.ForeignKey(
                        name: "FK_EmployeeMeetings_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeMeetings_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReviewDeadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateReviewed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    DiscountLevelId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_DiscountLevels_DiscountLevelId",
                        column: x => x.DiscountLevelId,
                        principalTable: "DiscountLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offers_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shelves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shelves_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfferItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    RawMaterialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferItems_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferItems_RawMaterials_RawMaterialId",
                        column: x => x.RawMaterialId,
                        principalTable: "RawMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductShelves",
                columns: table => new
                {
                    ShelfId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductShelves", x => new { x.ProductId, x.ShelfId });
                    table.ForeignKey(
                        name: "FK_ProductShelves_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductShelves_Shelves_ShelfId",
                        column: x => x.ShelfId,
                        principalTable: "Shelves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RawMaterialShelves",
                columns: table => new
                {
                    ShelfId = table.Column<int>(type: "int", nullable: false),
                    RawMaterialId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterialShelves", x => new { x.RawMaterialId, x.ShelfId });
                    table.ForeignKey(
                        name: "FK_RawMaterialShelves_RawMaterials_RawMaterialId",
                        column: x => x.RawMaterialId,
                        principalTable: "RawMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RawMaterialShelves_Shelves_ShelfId",
                        column: x => x.ShelfId,
                        principalTable: "Shelves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "70d42415-4006-40be-98b6-2ba981ef8dc2", "2f45f598-b142-4f90-9505-715066f8a49b", "Accounting", "ACCOUNTING" },
                    { "130ff858-5251-4344-998a-216b0d98d181", "62661325-41cf-4910-b721-b5b222db991e", "HR", "HR" },
                    { "91516112-cf50-4f2b-81f7-e9e09e193999", "788f7708-320d-4d68-868d-02dff87308b4", "DepartmentHead", "DEPARTMENTHEAD" },
                    { "8b7174ec-6d91-4b05-9f5b-fb2014650d75", "78e8d753-6767-4bb5-92e4-05f2ce9439fb", "Warehouse", "WAREHOUSE" },
                    { "4a140611-352b-4d33-a52f-ba5b68df0ea4", "85bdee88-7a53-4b00-8671-64d0d4d9141c", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "c4c6f346-65b7-4dda-97ce-4422eb58013a", 0, "4d07af7d-56ec-42f7-9a56-078380007221", "Winchester@gmail.com", false, false, null, "WINCHESTER@GMAIL.COM", "WINCHESTER", "AQAAAAEAACcQAAAAEEOlNlM+bStZqD7yKc6VY1hpActr6aRE0+2lmLJQuK1TZKn+Q0eMC7KoufY1g+fUZw==", null, false, "7ab69511-9415-4aa2-99bc-27cc909ad920", false, "Winchester" },
                    { "e1802e5e-a448-4c4e-841c-40b8a0de9dbf", 0, "ac7fb226-d899-4623-b840-e770804814cc", "Takis@gmail.com", false, false, null, "TAKIS@GMAIL.COM", "TAKIS", "AQAAAAEAACcQAAAAEFf5qKjCuRDKWZkkSJ716tewd6v23V44SauQCx/N3x2VgjIuMy/hTFnq361m26Lflg==", null, false, "3c694c18-c80d-4878-9cd2-2e41ac3c90f5", false, "Takis" },
                    { "f6afa472-95ed-4220-bc3a-0c212afa15db", 0, "e3f2a8fb-b104-478b-9137-4bfa021b4a4f", "Hermes@gmail.com", false, false, null, "HERMES@GMAIL.COM", "HERMES", "AQAAAAEAACcQAAAAEG7qhPPdD65NypIg/NmYiFkyNAhboF3hfsCWHO69uFsAG+bGmGz//kZnydR/h9IyqA==", null, false, "e99234d4-9b63-48f3-b545-583300bcd119", false, "Hermes" },
                    { "aeab492c-eb08-4a29-b6d9-0b936a292116", 0, "c05ed543-6af9-4e8e-8f85-9a4384c06c14", "Angela@gmail.com", false, false, null, "ANGELA@GMAIL.COM", "ANGELA", "AQAAAAEAACcQAAAAELD77vHT4CimSWGedqqkKYLzt1VzIj9uTTxmV4EUbkExs5KPUoG30ycjne3L+opCLg==", null, false, "90ea22c0-88d1-4833-8984-8c5248831498", false, "Angela" },
                    { "cd97911d-e70c-4a33-8365-ca3c69189215", 0, "175bae01-0e5f-4bf9-ba53-9fabf74e142b", "Thanasis@gmail.com", false, false, null, "THANASIS@GMAIL.COM", "THANASIS", "AQAAAAEAACcQAAAAEC4TTwCs4adfBCYWOFl7BV095LXwKDQ3grId89ZoTgt/xFCeArn6TRE+BdWOCPIZXw==", null, false, "5c09797b-cc22-41f4-9d29-cfbd392eecb8", false, "Thanasis" },
                    { "9e7b14d3-81eb-456a-a755-33d25dc1fd98", 0, "97ca15b3-b2d5-4642-9465-edf42aa053be", "Vasilis@gmail.com", false, false, null, "VASILIS@GMAIL.COM", "VASILIS", "AQAAAAEAACcQAAAAEGRWIZs85b+byOmGoGaed6WtVOJ8YDzCnoXtqPoYDTPvp7nfgCvs9BzOfWp3U1tgUg==", null, false, "799115fc-2125-476b-989e-126c03b4ea95", false, "Vasilis" },
                    { "d5e7fbf5-2be9-4e35-adf6-d6df34b0d4dd", 0, "1a8e92be-712a-43b2-8be5-01fe7729449f", "Ferenc@gmail.com", false, false, null, "FERENC@GMAIL.COM", "FERENC", "AQAAAAEAACcQAAAAEICvX9/Bpy95egUqIV0TfSj2gpU4IbaeQ6wGV1CN7zoH1oCOSfOTdxxwMtyGT/Kedg==", null, false, "f1834d10-9755-42ee-a830-efa1ef2cbcb0", false, "Ferenc" },
                    { "01cac9a3-aac4-459c-b879-04af9d1f07ee", 0, "62acb82b-542e-4810-8260-1d0b9d564e06", "Tseplo@gmail.com", false, false, null, "TSEPLO@GMAIL.COM", "TSEPLO", "AQAAAAEAACcQAAAAENRF28npV+Zh845Kq+BypTDsP3qfLnx66RwnUJqIoVDopnEaDLNg2Y/nm+mk2j9PYA==", null, false, "9f3d5937-3d4d-4d69-bf10-6bfd04a0ee45", false, "Tseplo" },
                    { "499a186a-847a-44bb-ac77-c8e07cdb1251", 0, "1404c3a1-6b9b-4dfc-b350-ec11ecb68c44", "Shepllo@gmail.com", false, false, null, "SHEPLLO@GMAIL.COM", "SHEPLLO", "AQAAAAEAACcQAAAAEFwJhVKHtbdYxw/rqBTIGp6bUDSIcv2JQ72ZKbLG57vFkeI9UhsQBJHQKepN5YgRWw==", null, false, "51644e51-ee6b-4136-a3fc-c76c834549d4", false, "Shepllo" },
                    { "907f51e7-8c3c-431a-8796-0e79f6a36630", 0, "60c61e7a-1a67-49ca-a6b5-3314edf53f17", "Spooky@gmail.com", false, false, null, "SPOOKY@GMAIL.COM", "SPOOKY", "AQAAAAEAACcQAAAAENNxeI9P6y77e75qen9d2ycsBhRUDRA20+eQSdzbtVgK06Ym+7Lq2Yrt0bIryjHCCw==", null, false, "8694a247-8358-4437-a0e6-e62a6871ae1e", false, "Spooky" },
                    { "4c81c4fe-ece4-43fb-af0d-1b7077eeeb04", 0, "a7582e62-69ad-4816-81cb-b47b56e63caf", "Masikins-Siatis@gmail.com", false, false, null, "MASKINIS-SIATIS@GMAIL.COM", "MASKINIS-SIATIS", "AQAAAAEAACcQAAAAEBcNOkNozFj+gALBApL2WYhDMCSMk6QtnOKFZ3JgSamjiMX7O9nQIAsAUZboQBWoVw==", null, false, "348d6fa5-05ca-45a1-8bd4-d6cc8f7e3758", false, "Maskinis-Siatis" },
                    { "60a94fc9-9ee5-4923-904c-6622c42d9e99", 0, "a3482c9b-b64e-468a-9c67-cb15203b16cc", "Nik@gmail.com", false, false, null, "NIK@GMAIL.COM", "NIK", "AQAAAAEAACcQAAAAEKz9qwyddqVH5RWVnqDSTjgPuTkgA7x4OrvpbSLzZ5huWh5yYj2GGBfXpxGowaAwow==", null, false, "cb158256-3334-46a0-a624-0e7c97571404", false, "Nik" },
                    { "40e78c1b-3314-4ad8-9a13-d3f5ec7965bf", 0, "ddda6c05-0301-4e45-b7c6-bc8c9bb6bb81", "Paris@gmail.com", false, false, null, "PARIS@GMAIL.COM", "PARIS", "AQAAAAEAACcQAAAAEPjoyULzzNx7CcQjb6yHJYFAsf1qjNY9j5t48MvNGLmu28zBqjjDmaRJPMkPv4j7iA==", null, false, "73721c81-1a42-4b19-b1ea-47384896990b", false, "Paris" },
                    { "64fe3c64-6cf0-4de3-8e53-917825b2528e", 0, "918f3216-8ef9-43fe-ae49-1158227cd6cd", "Zongia@gmail.com", false, false, null, "ZONGIA@GMAIL.COM", "ZONGIA", "AQAAAAEAACcQAAAAECMTTh2In/yA2KpQxlE+EAbayEcOCvz8yOI5aZqejdE+nNrJ+82NldJpubB0WFdhxA==", null, false, "69af5815-4ca8-4787-851c-b564ef36bc48", false, "Zongia" },
                    { "9cdad891-9814-4b2f-b769-74b9e2a8e836", 0, "321caaf5-218e-40f2-8e4e-e0945408cbcb", "Boltis@gmail.com", false, false, null, "BOLTSIS@GMAIL.COM", "BOLTSIS", "AQAAAAEAACcQAAAAEC2/NnnEzSQAHqks3tOl7hYoAaQfH6+BesuGz03gPVt0Gk30B4QnYlghucTfhoQuIA==", null, false, "d93743f1-8a01-4375-ac7c-b1272c13c27a", false, "Boltis" },
                    { "c9342ed5-bcf6-47d3-95f9-84a95b7f19f3", 0, "716af3ee-f91f-4326-95b4-e012fc874008", "Poltis@gmail.com", false, false, null, "POLTSIS@GMAIL.COM", "POLTSIS", "AQAAAAEAACcQAAAAEPhxTRXsfVT7cqaxAhCFrU0CE58wO9Gy7uCWEctn9x5moOhYFib46xG+yludYFsdHQ==", null, false, "a607e06b-9c5d-4644-a7df-596003a37b61", false, "Poltis" },
                    { "d066e575-39cd-4ed5-b9e2-bfaeb08999e1", 0, "159bf534-86cc-4bb7-9ac3-44444c27c112", "Koltis@gmail.com", false, false, null, "KOLTSIS@GMAIL.COM", "KOLTSIS", "AQAAAAEAACcQAAAAEMraWtY8go+cKKZdrpNJ5uPqlyuYYcqQIW8Aj1+6KKLJZpsTXXfh96LNatPS4E/O/Q==", null, false, "cfbe5b4d-81d2-4d82-84c0-bd21d52bfb2f", false, "Koltsis" },
                    { "9048a711-c953-47de-8319-9f57cb2347ba", 0, "d0d4e232-81a3-4d6f-9be4-bd0075d40c5f", "Pitsi@gmail.com", false, false, null, "PITSI@GMAIL.COM", "PITSI", "AQAAAAEAACcQAAAAED6X6Htt4Jq5KT6Gre7YO0h1RaO2gmU1XPpGF2/y+sQSmSYn8iJohNeSVFIwMcaVdg==", null, false, "48f31c91-7a92-4e4b-b058-66f412e99fcc", false, "Pitsi" },
                    { "a8f92bc6-3d6b-4315-8101-acea88fe480a", 0, "04911b76-1dd7-4f5f-9103-d673f1686428", "TiKsereis@gmail.com", false, false, null, "TIKSEREIS@GMAIL.COM", "TIKSEREIS", "AQAAAAEAACcQAAAAEEXFGzQXAXOmJhs/cIjSat3wc9gmkUkNBGUB+AFgomXAzJNEzuAtIi71TTFmH3IEDw==", null, false, "011910e0-3822-44cf-a116-7956715dbe62", false, "TiKsereis" },
                    { "fd5aeaed-9088-457d-b91d-8c9074ef6c14", 0, "e89f89d1-e311-4db2-b5e3-261941bf798b", "PikaPika@gmail.com", false, false, null, "PIKAPIKA@GMAIL.COM", "PIKAPIKA", "AQAAAAEAACcQAAAAEIn6BrTLc4PqvWvxDPa5pxdvc8GYmJ5UHUXQoWDAvRBAOjYmTR0+Rk7iU8e18AKW0g==", null, false, "6640f11f-120f-4b41-a66c-4769e3c67a20", false, "PikaPika" },
                    { "ed6ea617-258e-41e9-8c1c-5c4823c5e87f", 0, "bd3504b0-ec3f-4eae-a5cf-127af7845707", "Bella@gmail.com", false, false, null, "BELLA@GMAIL.COM", "BELLA", "AQAAAAEAACcQAAAAEF6nhTUV1iNpUnpX4P2pdhM6VcRrls/iVVJldLk8wRxvEMAoQdeBcUXl01VlhJjc7g==", null, false, "d594a9b1-6add-4dc0-969d-02638176c62d", false, "Bella" },
                    { "5b60d6d4-5351-4f6a-9e0e-8acaa79daf94f", 0, "ef500dec-2ada-48cb-8871-e57896bc6271", "Kamatero@gmail.com", false, false, null, "KAMATERO@GMAIL.COM", "KAMATERO", "AQAAAAEAACcQAAAAEAvJCS0Q8REUE67ubD9BJUlNdPiyHZYNKOz/p88lh2cBY5awXAOQDxfhXd+uWsZAEQ==", null, false, "c476cb73-83d9-4dae-a714-656d4da82b51", false, "Kamatero" },
                    { "2a023c9a-1676-4bf2-8ee8-a98b11e961d0", 0, "68e48e5e-79a7-4424-998c-058b78fedccd", "EasyBrizzy@gmail.com", false, false, null, "EASYBRIZZY@GMAIL.COM", "EASYBRIZZY", "AQAAAAEAACcQAAAAEJT2g5NyqXxLHl6BEM6CwWv60UrNJPaTXErBlAEfJZgLw38q9Ek2aIAYRDTtN9x3XQ==", null, false, "4ca835e0-d1d2-4477-a35e-eff3fb2c20c7", false, "EasyBrizzy" },
                    { "a620855c-c81a-4720-8c5f-cf724e1d0951", 0, "5662fc43-9968-42d7-8d0d-7f93769a6653", "Zouzoulas@gmail.com", false, false, null, "ZOUZOULAS@GMAIL.COM", "ZOUZOULAS", "AQAAAAEAACcQAAAAEHQ+3Ek6/n4yYWjnB06Emhn5KBhXylPwSgs0CZxywVwqo9YaCQC222YHsf+TU9R0wg==", null, false, "de7f7123-ccb6-4efa-ad50-b3317458e06d", false, "Zouzoulas" },
                    { "437c2a07-2931-43de-9dfb-4d415247c508", 0, "de2ff312-233b-4776-bb1d-569680e00969", "Wow@gmail.com", false, false, null, "WOW@GMAIL.COM", "WOW", "AQAAAAEAACcQAAAAEMiNvzEVecIj/K/WqyVMdck7u8uMvyCQlZLgEXEU7cGdtiBMze5OH2W1ZoDI/yuNCg==", null, false, "fe3a061f-5ee5-48e3-b1b8-41dd80ee917a", false, "Wow" }
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "CV", "DateOfBirth", "FileName", "FirstName", "IsBlacklisted", "LastName" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2000, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kennard", false, "Ramsey" },
                    { 2, null, new DateTime(2000, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dominic", false, "Greenwood" },
                    { 3, null, new DateTime(2001, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Benjamin", false, "Hunt" },
                    { 4, null, new DateTime(2003, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Victor", false, "Lambert" },
                    { 5, null, new DateTime(1997, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ferdinand", false, "Smith" },
                    { 6, null, new DateTime(1981, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Melinda", false, "Gross" },
                    { 7, null, new DateTime(1987, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Laura", false, "Parham" },
                    { 8, null, new DateTime(2002, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lucy", false, "Johnson" },
                    { 9, null, new DateTime(2002, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Harper", false, "Fernandez" },
                    { 10, null, new DateTime(2000, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Georgia", false, "Lawson" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[,]
                {
                    { 9, "Josh", "Barnett", null },
                    { 12, "Ashley", "Barrett", null }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[,]
                {
                    { 11, "Dexter", "Friedman", null },
                    { 10, "John-Paul", "Gabler", null },
                    { 8, "Logan", "Cunningham", null },
                    { 7, "Andrew", "Wang", null },
                    { 6, "Greg", "Kasavin", null },
                    { 5, "Jen", "Zee", null },
                    { 4, "Darren", "Korb", null },
                    { 3, "Gavin", "Simon", null },
                    { 2, "Amir", "Rao", null },
                    { 1, "Makis", "Metamorfwsi", null }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Human Resources" },
                    { 2, "Procurement" },
                    { 3, "Sales" },
                    { 4, "Eshop" },
                    { 5, "Warehouse" },
                    { 6, "Accounting" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "Category", "Description", "IsDeleted", "Name", "Price", "Weight" },
                values: new object[,]
                {
                    { 45, "2000016233454541", (byte)2, "Once you go black,you never go back", false, "Black Solo", 5.5, 0.10000000000000001 },
                    { 2, "2000012334154568", (byte)1, "Clean cut white chocolate bar", false, "Whitey", 7.5, 0.10000000000000001 },
                    { 47, "2000012833454573", (byte)1, "The strong one", false, "Weight of Love", 11.5, 0.13 },
                    { 48, "2000012334954561", (byte)2, "Psychotic taste", false, "El Camino", 12.5, 0.20000000000000001 },
                    { 4, "2000013233454570", (byte)2, "The better type of bites", false, "Classy", 12.5, 0.29999999999999999 },
                    { 50, "2000021233454666", (byte)1, "Chocolate issues", false, "Pitsi Go", 8.5, 0.5 },
                    { 3, "2000012332454569", (byte)1, "Clean cut mix chocolate bar", false, "Mix-DaChoc", 10.5, 0.10000000000000001 },
                    { 1, "2000012334054567", (byte)1, "Clean cut black chocolate bar", false, "Darky", 7.5, 0.10000000000000001 },
                    { 44, "2000051233454679", (byte)1, "The one you want share", false, "White Stripe", 5.5, 0.40000000000000002 },
                    { 49, "2000012334541543", (byte)3, "If you want to lost your mind.Try it!", false, "Bellisimo", 2.5, 0.29999999999999999 },
                    { 43, "2000041233454678", (byte)3, "To tasty to love it", false, "Bittersweet Symphony", 4.5, 0.29999999999999999 },
                    { 46, "2000017233454551", (byte)3, "Gold on the chocolate", false, "Gold Gold Gold", 12.5, 0.12 },
                    { 41, "2000021233454696", (byte)1, "B is for best", false, "Balaclava", 1.5, 0.10000000000000001 },
                    { 17, "2007001233454675", (byte)3, "The best taste", false, "Semisweet Lozan", 2.5, 0.5 },
                    { 18, "200081233454655", (byte)1, "Sweet Arctic Choco", false, "Arabella", 6.5, 0.5 },
                    { 19, "2000091233454690", (byte)1, "Couverture Chocolate", false, "Couverture", 2.5, 0.29999999999999999 },
                    { 20, "20000123103454610", (byte)2, "Ruby Ruby Ruby", false, "Ruby Lozan", 10.5, 0.29999999999999999 },
                    { 21, "2000101233454612", (byte)3, "Snap out of it", false, "Raw", 8.5, 0.5 },
                    { 22, "2000021233454698", (byte)2, "Put an almold on me", false, "Almond Flavour", 9.5, 0.90000000000000002 },
                    { 23, "2003001233454612", (byte)3, "One for the road", false, "Goji Berrie", 10.5, 0.40000000000000002 },
                    { 24, "2000014233454613", (byte)1, "The truble tou want", false, "Crumble Truble", 9.5, 0.20000000000000001 },
                    { 25, "2000012335454656", (byte)2, "For vegan lovers", false, "Vegan", 3.5, 0.29999999999999999 },
                    { 26, "2000012363454689", (byte)3, "Old fashion choco", false, "Almond Milky", 9.5, 0.10000000000000001 },
                    { 27, "2000012337454681", (byte)1, "The banana lovers", false, "Banana Dark", 10.5, 0.80000000000000004 },
                    { 28, "2000012383454628", (byte)2, "Im in love with choco", false, "White Love", 2.5, 0.10000000000000001 },
                    { 29, "2000012933454621", (byte)3, "I wanna get off with mystic choco", false, "Mystic Choco", 3.5, 0.90000000000000002 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "Category", "Description", "IsDeleted", "Name", "Price", "Weight" },
                values: new object[,]
                {
                    { 30, "2000011233454629", (byte)2, "Four out of Five", false, "Sweet sweet", 4.5, 0.80000000000000004 },
                    { 31, "2000011233454620", (byte)3, "Easy Choice", false, "Dark Almond", 6.5, 0.69999999999999996 },
                    { 16, "2000601233454674", (byte)2, "Sugar sugar honey honey", false, "Sweet Choco of Mine", 9.5, 0.29999999999999999 },
                    { 15, "2005001233454673", (byte)1, "You drive me crazy", false, "Crazy Choco Loco", 8.5, 0.20000000000000001 },
                    { 33, "2000031233454645", (byte)2, "The best way", false, "Milky Away", 9.5, 0.20000000000000001 },
                    { 14, "2000401233454662", (byte)1, "Bittersweet love for all", false, "Bittersweet Love", 9.5, 0.29999999999999999 },
                    { 40, "2000011233454635", (byte)3, "Best choice for developers", false, "CoffeScript", 2.5, 0.29999999999999999 },
                    { 39, "2000012933454634", (byte)2, "The morning choice", false, "Adorable", 5.5, 0.80000000000000004 },
                    { 38, "2000018233454661", (byte)1, "Sugar sugar, forever sugar", false, "Honey Honey", 2.5, 0.69999999999999996 },
                    { 37, "2000012373454667", (byte)3, "I bet you look good", false, "Brown Monkey", 10.5, 0.59999999999999998 },
                    { 36, "2000016233454645", (byte)2, "The one that never ends", false, "Waffer", 9.5, 0.5 },
                    { 35, "2000051233454640", (byte)1, "The bite that hurts", false, "Spooky Bite", 6.5, 0.40000000000000002 },
                    { 34, "2000041233454646", (byte)3, "Stairway to heaven", false, "Darky Way", 3.5, 0.29999999999999999 },
                    { 32, "2000021233454621", (byte)1, "The choice you wanted", false, "Vegan Almond", 5.5, 0.10000000000000001 },
                    { 5, "2000012343454571", (byte)3, "Super Wafer", false, "ChocoMist", 7.5, 0.14999999999999999 },
                    { 7, "2000012334654573", (byte)2, "Oh that smell!", false, "Mystic Flavour", 13.5, 0.29999999999999999 },
                    { 8, "2000012334547582", (byte)1, "So dark and sweet", false, "Dark Hell", 12.5, 0.25 },
                    { 9, "2000012833454581", (byte)1, "So white and sweet", false, "White Heaven", 12.5, 0.25 },
                    { 10, "2000012334954678", (byte)3, "Eat it drink it", false, "Milky Way", 10.5, 0.25 },
                    { 11, "2001001233454623", (byte)1, "The taste you wanted", false, "Waffer Flavour", 10.5, 0.29999999999999999 },
                    { 12, "2000012233454690", (byte)3, "Only for coffee addicts!", false, "Coffee Choco", 9.5, 0.29999999999999999 },
                    { 13, "2000031233454671", (byte)3, "Golden Retriver Chocolate", false, "Golden Choice", 13.5, 0.25 },
                    { 6, "2000015233454572", (byte)2, "The Bites you didn't know you wanted!", false, "CoffeeFountain", 12.5, 0.29999999999999999 },
                    { 42, "2000031233454691", (byte)2, "100% Cocoa", false, "Cocoa Power", 3.5, 0.20000000000000001 }
                });

            migrationBuilder.InsertData(
                table: "RawMaterials",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 11, "Semisweet Chocolate", 4.5 },
                    { 19, "Vegan Chocolate", 2.5 },
                    { 17, "Goji Berries Chocolate", 3.1499999999999999 },
                    { 16, "Almond Chocolate", 2.5 },
                    { 15, "Raw Chocolate", 3.5 },
                    { 14, "Ruby", 4.5 },
                    { 13, "Couverture Chocolate", 2.5 },
                    { 12, "Sweet German Chocolate", 3.5 },
                    { 10, "Baking Chocolate", 3.1499999999999999 },
                    { 20, "Almond Milk Chocolate", 2.3500000000000001 },
                    { 9, "Bittersweet Chocolate", 2.3500000000000001 },
                    { 7, "Cocoa Chocolate", 2.5 },
                    { 6, "Golden Retriever Chocolate", 2.5 },
                    { 5, "CoffeSyrup", 3.5 },
                    { 4, "Waffer", 4.5 },
                    { 3, "Milk Chocolate", 3.1499999999999999 },
                    { 2, "White Chocolate", 2.3500000000000001 },
                    { 1, "Dark Chocolate", 2.4500000000000002 }
                });

            migrationBuilder.InsertData(
                table: "RawMaterials",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 8, "Cocoa Power", 2.5 },
                    { 18, "Crumbe Chocolate", 2.5 }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[,]
                {
                    { 12, "Business", "SA" },
                    { 1, "AlphaChoc", "SA" },
                    { 13, "Systems", "LLC" },
                    { 14, "Rest", "SA" },
                    { 15, "CBS", "LTD" },
                    { 10, "Paradise", "SA" },
                    { 8, "Light", "LLC" },
                    { 9, "Echo", "LTD" },
                    { 6, "Ifet", "SA" },
                    { 5, "GiannaImport", "SA" },
                    { 4, "Marmita", "LLC" },
                    { 3, "Papavlaxos", "LTD" },
                    { 2, "DreamLine", "SA" },
                    { 7, "Gene", "LLC" },
                    { 11, "Cosmos", "LTD" }
                });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 4, false, "Amsterdam Warehouse" },
                    { 3, false, "Reykjavik Warehouse" },
                    { 2, false, "Vienna Warehouse" },
                    { 1, false, "Athens Warehouse" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressNumber", "CandidateId", "Comments", "Country", "CustomerId", "EmployeeId", "Location", "PostCode", "SupplierId", "WarehouseId" },
                values: new object[,]
                {
                    { 66, (short)71, 1, "Candidate 1", "Greece", null, null, "Kalymnou", (short)22992, null, null },
                    { 8, (short)109, null, "Supplier 6", "Greece", null, null, "Kokkinou", (short)15347, 6, null },
                    { 7, (short)180, null, "Supplier 5", "Greece", null, null, "Parmeniona", (short)15348, 5, null },
                    { 74, (short)42, 9, "Candidate 9", "Greece", null, null, "Patmou", (short)21662, null, null },
                    { 6, (short)12, null, "Supplier 4", "Greece", null, null, "Manola", (short)15346, 4, null },
                    { 5, (short)122, null, "Supplier 3", "Greece", null, null, "Plapouta", (short)15345, 3, null },
                    { 75, (short)42, 10, "Candidate 10", "Greece", null, null, "Lerou", (short)21612, null, null },
                    { 4, (short)45, null, "Supplier 2", "Greece", null, null, "Manis", (short)15342, 2, null },
                    { 3, (short)9, null, "Supplier 1", "Greece", null, null, "Hpeirou", (short)15232, 1, null },
                    { 73, (short)83, 8, "Candidate 8", "Greece", null, null, "Kefalonias", (short)21012, null, null },
                    { 54, (short)23, null, "Customer 1", "Greece", 1, null, "Xaralampou", (short)17456, null, null },
                    { 64, (short)71, null, "Customer 11", "Greece", 11, null, "Valsamikou", (short)22992, null, null },
                    { 55, (short)33, null, "Customer 2", "Greece", 2, null, "Kolokotroni", (short)17482, null, null },
                    { 63, (short)68, null, "Customer 10", "Greece", 10, null, "Alatiou", (short)22992, null, null },
                    { 62, (short)82, null, "Customer 9", "Greece", 9, null, "Piperiou", (short)22992, null, null },
                    { 56, (short)22, null, "Customer 3", "Greece", 3, null, "Pitsou", (short)13382, null, null },
                    { 61, (short)82, null, "Customer 8", "Greece", 8, null, "Anithou", (short)13992, null, null },
                    { 60, (short)57, null, "Customer 7", "Greece", 7, null, "Maintanou", (short)13772, null, null },
                    { 59, (short)52, null, "Customer 6", "Greece", 6, null, "Paprikas", (short)13772, null, null },
                    { 65, (short)71, null, "Customer 12", "Greece", 12, null, "Ladiou", (short)22132, null, null },
                    { 57, (short)88, null, "Customer 4", "Greece", 4, null, "Pikatsou", (short)13382, null, null },
                    { 9, (short)17, null, "Supplier 7", "Greece", null, null, "Dromena", (short)15349, 7, null },
                    { 47, (short)28, null, "Supplier 9", "Greece", null, null, "Pierrou", (short)15451, 9, null },
                    { 67, (short)52, 2, "Candidate 2", "Greece", null, null, "Rodou", (short)22980, null, null },
                    { 35, (short)69, null, "Our Fourth Warehouse", "Holland", null, null, "Hollandias", (short)11321, null, 4 },
                    { 34, (short)52, null, "Our Third Warehouse", "Island", null, null, "Islandias", (short)11231, null, 3 },
                    { 68, (short)45, 3, "Candidate 3", "Greece", null, null, "Mykonou", (short)21380, null, null },
                    { 2, (short)12, null, "Our Second Warehouse", "Greece", null, null, "Attikis", (short)15344, null, 2 },
                    { 1, (short)3, null, "Our First Warehouse", "Greece", null, null, "Thessalonikis", (short)15354, null, 1 },
                    { 69, (short)33, 4, "Candidate 4", "Greece", null, null, "Parou", (short)21900, null, null },
                    { 46, (short)52, null, "Supplier 8", "Greece", null, null, "Krouskaki", (short)15322, 8, null },
                    { 58, (short)132, null, "Customer 5", "Greece", 5, null, "Raitsou", (short)13382, null, null },
                    { 52, (short)71, null, "Supplier 11", "Greece", null, null, "Mpampakou", (short)12422, 14, null },
                    { 70, (short)5, 5, "Candidate 5", "Greece", null, null, "Leukadas", (short)21032, null, null },
                    { 51, (short)71, null, "Supplier 11", "Greece", null, null, "Mpampakou", (short)11422, 13, null },
                    { 50, (short)71, null, "Supplier 11", "Greece", null, null, "Plitsiou", (short)15322, 12, null },
                    { 71, (short)56, 6, "Candidate 6", "Greece", null, null, "Porou", (short)21011, null, null },
                    { 49, (short)69, null, "Supplier 11", "Greece", null, null, "Georgakopoulou", (short)15422, 11, null },
                    { 48, (short)68, null, "Supplier 10", "Greece", null, null, "Samou", (short)15422, 10, null },
                    { 72, (short)90, 7, "Candidate 7", "Greece", null, null, "Kritis", (short)21055, null, null },
                    { 53, (short)33, null, "Supplier 11", "Greece", null, null, "Naki", (short)12422, 15, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4a140611-352b-4d33-a52f-ba5b68df0ea4", "e1802e5e-a448-4c4e-841c-40b8a0de9dbf" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "130ff858-5251-4344-998a-216b0d98d181", "aeab492c-eb08-4a29-b6d9-0b936a292116" },
                    { "70d42415-4006-40be-98b6-2ba981ef8dc2", "cd97911d-e70c-4a33-8365-ca3c69189215" },
                    { "8b7174ec-6d91-4b05-9f5b-fb2014650d75", "9e7b14d3-81eb-456a-a755-33d25dc1fd98" }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "EndDate", "SupplierId" },
                values: new object[,]
                {
                    { 5, new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 2, new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, new DateTime(2021, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 6, new DateTime(2021, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 3, new DateTime(2021, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2022, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 1, new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "CandidateId", "CustomerId", "EmployeeId", "Mail", "MailType", "SupplierId", "WarehouseId" },
                values: new object[,]
                {
                    { 45, null, 1, null, "noescape@gmail.com", (byte)1, null, null },
                    { 38, null, null, null, "questforhonor@gmail.com", (byte)2, 13, null },
                    { 34, null, null, null, "sinkingfeeling@gmail.com", (byte)2, 9, null },
                    { 60, 4, null, null, "waterwall@gmail.com", (byte)1, null, null },
                    { 61, 5, null, null, "thespine@gmail.com", (byte)1, null, null },
                    { 37, null, null, null, "strangevoyage@gmail.com", (byte)2, 12, null },
                    { 36, null, null, null, "snakesoul@gmail.com", (byte)2, 11, null },
                    { 40, null, null, null, "vagrantsong@gmail.com", (byte)2, 15, null },
                    { 62, 6, null, null, "coasting@gmail.com", (byte)1, null, null },
                    { 35, null, null, null, "dreaddesign@gmail.com", (byte)2, 10, null },
                    { 39, null, null, null, "knightofthesea@gmail.com", (byte)2, 14, null },
                    { 33, null, null, null, "dirtydeal@gmail.com", (byte)2, 8, null },
                    { 63, 7, null, null, "vanishingpoint@gmail.com", (byte)1, null, null },
                    { 30, null, null, null, "flutterfly@gmail.com", (byte)2, 5, null },
                    { 67, 10, null, null, "paperboats@gmail.com", (byte)1, null, null },
                    { 27, null, null, null, "mourningsong@gmail.com", (byte)2, 2, null },
                    { 64, 7, null, null, "traces@gmail.com", (byte)1, null, null },
                    { 32, null, null, null, "astepcloser@gmail.com", (byte)2, 7, null },
                    { 28, null, null, null, "eightscribes@gmail.com", (byte)2, 3, null },
                    { 31, null, null, null, "trashpack@gmail.com", (byte)2, 6, null },
                    { 66, 9, null, null, "incircles@gmail.com", (byte)1, null, null },
                    { 29, null, null, null, "glorioustradition@gmail.com", (byte)2, 4, null },
                    { 65, 8, null, null, "cutapart@gmail.com", (byte)1, null, null },
                    { 26, null, null, null, "theherald@gmail.com", (byte)2, 1, null },
                    { 41, null, null, null, "warehouseone@gmail.com", (byte)2, null, 1 },
                    { 48, null, 4, null, "wretchedshades@gmail.com", (byte)1, null, null },
                    { 49, null, 5, null, "lamentoforpheus@gmail.com", (byte)1, null, null },
                    { 58, 2, null, null, "stainedglass@gmail.com", (byte)1, null, null },
                    { 53, null, 9, null, "goodridance@gmail.com", (byte)1, null, null },
                    { 44, null, null, null, "warehousefour@gmail.com", (byte)2, null, 4 },
                    { 43, null, null, null, "warehousethree@gmail.com", (byte)2, null, 3 },
                    { 46, null, 2, null, "houseofhades@gmail.com", (byte)1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "CandidateId", "CustomerId", "EmployeeId", "Mail", "MailType", "SupplierId", "WarehouseId" },
                values: new object[,]
                {
                    { 54, null, 10, null, "finalexpense@gmail.com", (byte)1, null, null },
                    { 51, null, 7, null, "fromolympous@gmail.com", (byte)1, null, null },
                    { 55, null, 11, null, "mouthofstyx@gmail.com", (byte)1, null, null },
                    { 50, null, 6, null, "thepainfulway@gmail.com", (byte)1, null, null },
                    { 42, null, null, null, "warehousetwo@gmail.com", (byte)2, null, 2 },
                    { 57, 1, null, null, "oldfriends@gmail.com", (byte)1, null, null },
                    { 56, null, 12, null, "primorgialchaos@gmail.com", (byte)1, null, null },
                    { 59, 3, null, null, "forecast@gmail.com", (byte)1, null, null },
                    { 52, null, 8, null, "throughasphodel@gmail.com", (byte)1, null, null },
                    { 47, null, 3, null, "outoftartarus@gmail.com", (byte)1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "DepartmentId", "FirstName", "HireDate", "IsHeadOfDepartment", "LastName", "UserId", "WorkExperience" },
                values: new object[,]
                {
                    { 23, new DateTime(1980, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Liam", new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Cider", "2a023c9a-1676-4bf2-8ee8-a98b11e961d0", "Most experienced of all" },
                    { 20, new DateTime(1979, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Peter", new DateTime(2019, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Flavoured", "fd5aeaed-9088-457d-b91d-8c9074ef6c14", "The one that never bored" },
                    { 3, new DateTime(1980, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Robert", new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Paulsen", "aeab492c-eb08-4a29-b6d9-0b936a292116", "His Name was Robert Paulsen" },
                    { 4, new DateTime(1990, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Richard", new DateTime(2019, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Chester", "cd97911d-e70c-4a33-8365-ca3c69189215", "Wow so inadequeate" },
                    { 5, new DateTime(1980, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Thomas", new DateTime(2019, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Inferino", "9e7b14d3-81eb-456a-a755-33d25dc1fd98", "The best experience" },
                    { 6, new DateTime(1979, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Lee", new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Gooper", "d5e7fbf5-2be9-4e35-adf6-d6df34b0d4dd", "The best of the best" },
                    { 17, new DateTime(1987, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Antony", new DateTime(2020, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Somersby", "d066e575-39cd-4ed5-b9e2-bfaeb08999e1", "The trainig is my cause" },
                    { 21, new DateTime(1979, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Paris", new DateTime(2019, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "OverIce", "ed6ea617-258e-41e9-8c1c-5c4823c5e87f", "Something really nice" },
                    { 7, new DateTime(1980, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Marla", new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Singer", "01cac9a3-aac4-459c-b879-04af9d1f07ee", "The bestest" },
                    { 22, new DateTime(1980, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Leon", new DateTime(2019, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Pisher", "5b60d6d4-5351-4f6a-9e0e-8acaa79daf94f", "The best of the best" },
                    { 8, new DateTime(1970, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Charlie", new DateTime(2018, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Dell", "499a186a-847a-44bb-ac77-c8e07cdb1251", "The best experience ever" },
                    { 9, new DateTime(1980, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Rob", new DateTime(2020, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Lanza", "907f51e7-8c3c-431a-8796-0e79f6a36630", "What a wonderfull experience" },
                    { 10, new DateTime(1985, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Holly", new DateTime(2020, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "McCallany", "4c81c4fe-ece4-43fb-af0d-1b7077eeeb04", "Super douper experience" },
                    { 25, new DateTime(1982, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Anna", new DateTime(2018, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Banana", "c4c6f346-65b7-4dda-97ce-4422eb58013a", "I know it's my destiny" },
                    { 11, new DateTime(1976, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Lucy", new DateTime(2019, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Bissonnette", "a620855c-c81a-4720-8c5f-cf724e1d0951", "The best of all" },
                    { 16, new DateTime(1987, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Lucy", new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Loo", "c9342ed5-bcf6-47d3-95f9-84a95b7f19f3", "To catch the knowledge is my cause" },
                    { 2, new DateTime(1975, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tyler", new DateTime(2019, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Durden", "f6afa472-95ed-4220-bc3a-0c212afa15db", "So cool" },
                    { 12, new DateTime(1987, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Ella", new DateTime(2021, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Bailey", "60a94fc9-9ee5-4923-904c-6622c42d9e99", "I wanna be the very best" },
                    { 13, new DateTime(1989, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Jare", new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Vleto", "40e78c1b-3314-4ad8-9a13-d3f5ec7965bf", "Like no one ever was" },
                    { 14, new DateTime(1989, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Anais", new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Winston", "64fe3c64-6cf0-4de3-8e53-917825b2528e", "The smartest of all" },
                    { 15, new DateTime(1978, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Matt", new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Kim", "9cdad891-9814-4b2f-b769-74b9e2a8e836", "The strongest of all" },
                    { 19, new DateTime(1978, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Nick", new DateTime(2020, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Meow", "a8f92bc6-3d6b-4315-8101-acea88fe480a", "Super experienced" },
                    { 24, new DateTime(1982, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Zan", new DateTime(2018, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Wow", "437c2a07-2931-43de-9dfb-4d415247c508", "The power thats inside" },
                    { 1, new DateTime(1980, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "George", new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Chromosone", "e1802e5e-a448-4c4e-841c-40b8a0de9dbf", "Something good I guess" },
                    { 18, new DateTime(1988, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Mary", new DateTime(2019, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Watermelon", "9048a711-c953-47de-8319-9f57cb2347ba", "Ultra experienced" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "OrderFulfilled", "OrderPlaced", "PaymentType" },
                values: new object[,]
                {
                    { 2, 3, null, new DateTime(2021, 3, 18, 14, 37, 0, 0, DateTimeKind.Unspecified), (byte)1 },
                    { 3, 5, new DateTime(2021, 4, 10, 12, 27, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 2, 5, 37, 0, 0, DateTimeKind.Unspecified), (byte)1 },
                    { 4, 7, new DateTime(2021, 4, 2, 12, 56, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 27, 19, 45, 0, 0, DateTimeKind.Unspecified), (byte)2 },
                    { 5, 9, new DateTime(2021, 4, 11, 16, 5, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 7, 11, 30, 0, 0, DateTimeKind.Unspecified), (byte)2 },
                    { 1, 1, null, new DateTime(2021, 4, 2, 12, 30, 0, 0, DateTimeKind.Unspecified), (byte)2 },
                    { 6, 11, null, new DateTime(2021, 4, 10, 23, 45, 0, 0, DateTimeKind.Unspecified), (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "CandidateId", "CustomerId", "EmployeeId", "Number", "PhoneType", "SupplierId", "WarehouseId" },
                values: new object[] { 31, null, null, null, "2109381126", (byte)2, 6, null });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "CandidateId", "CustomerId", "EmployeeId", "Number", "PhoneType", "SupplierId", "WarehouseId" },
                values: new object[,]
                {
                    { 63, 7, null, null, "2109381158", (byte)1, null, null },
                    { 44, null, null, null, "2109381139", (byte)2, null, 4 },
                    { 57, 1, null, null, "2109381152", (byte)1, null, null },
                    { 32, null, null, null, "2109381127", (byte)2, 7, null },
                    { 30, null, null, null, "2109381125", (byte)2, 5, null },
                    { 41, null, null, null, "2109381136", (byte)2, null, 1 },
                    { 33, null, null, null, "2109381128", (byte)2, 8, null },
                    { 34, null, null, null, "2109381129", (byte)2, 9, null },
                    { 62, 6, null, null, "2109381157", (byte)1, null, null },
                    { 58, 2, null, null, "2109381153", (byte)1, null, null },
                    { 35, null, null, null, "2109381130", (byte)2, 10, null },
                    { 42, null, null, null, "2109381137", (byte)2, null, 2 },
                    { 36, null, null, null, "2109381131", (byte)2, 11, null },
                    { 61, 5, null, null, "2109381156", (byte)1, null, null },
                    { 37, null, null, null, "2109381132", (byte)2, 12, null },
                    { 38, null, null, null, "2109381133", (byte)2, 13, null },
                    { 60, 4, null, null, "2109381155", (byte)1, null, null },
                    { 39, null, null, null, "2109381134", (byte)2, 14, null },
                    { 59, 3, null, null, "2109381154", (byte)1, null, null },
                    { 43, null, null, null, "2109381138", (byte)2, null, 3 },
                    { 40, null, null, null, "2109381135", (byte)2, 15, null },
                    { 27, null, null, null, "2109381122", (byte)2, 2, null },
                    { 28, null, null, null, "2109381123", (byte)2, 3, null },
                    { 48, null, 4, null, "2109381143", (byte)1, null, null },
                    { 64, 8, null, null, "2109381159", (byte)1, null, null },
                    { 56, null, 12, null, "2109381151", (byte)1, null, null },
                    { 55, null, 11, null, "2109381150", (byte)1, null, null },
                    { 65, 9, null, null, "2109381160", (byte)1, null, null },
                    { 26, null, null, null, "2109381121", (byte)2, 1, null },
                    { 45, null, 1, null, "2109381140", (byte)1, null, null },
                    { 54, null, 10, null, "2109381149", (byte)1, null, null },
                    { 66, 10, null, null, "2109381161", (byte)1, null, null },
                    { 46, null, 2, null, "2109381141", (byte)1, null, null },
                    { 52, null, 8, null, "2109381147", (byte)1, null, null },
                    { 51, null, 7, null, "2109381146", (byte)1, null, null },
                    { 29, null, null, null, "2109381124", (byte)2, 4, null },
                    { 50, null, 6, null, "2109381145", (byte)1, null, null },
                    { 47, null, 3, null, "2109381142", (byte)1, null, null },
                    { 49, null, 5, null, "2109381144", (byte)1, null, null },
                    { 53, null, 9, null, "2109381148", (byte)1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Degree", "DepartmentId", "Description", "IsActive", "Languages", "Name", "Qualifications", "WorkExperience" },
                values: new object[,]
                {
                    { 9, "Degree in relative field", 5, "Warehouse Manager to manage one of our local Warehouses", true, "Greek, English", "Warehouse Manager", "Logical-Thinking", "Utleast 3 years of experience in Warehouse management" },
                    { 8, "No need", 5, "Warehouse Worker for one of our local Warehouses", true, "Greek, English", "Warehouse Worker", "Strong physical skills", "Experience with getting your hands dirty" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Degree", "DepartmentId", "Description", "IsActive", "Languages", "Name", "Qualifications", "WorkExperience" },
                values: new object[,]
                {
                    { 7, "Degree in relative field", 4, "E-Shop Senior Developer for our company's e-shop", true, "Greek, English", "E-Shop Senior Developer", "Leadership skills and a strong programming background", "Minimum 6 years of experience in projects created with .net 5" },
                    { 6, "Degree in relative field", 4, "E-Shop Junior Developer for our company's e-shop", true, "Greek, English", "E-Shop Junior Developer", "Basic knowledge with any Object-Oriented programming language", "Minimum 2 years of experience in projects created with .net 5" },
                    { 10, "Degree in relative field", 6, "Senior Accountant to help us do our taxes", true, "Greek, English", "Senior Accountant", "How skilled are you with tax evasion?", "Utleast 5 years of experience" },
                    { 1, "Degree in relative field", 1, "Senior Recruiter for our small company", true, "Greek, English", "Senior Recruiter", "Strong Communication Skills", "Minimum 5 years of experience and a cover letter from your previous employer" },
                    { 4, "Degree in relative field", 3, "Senior Sales Analyst to manage our sales figures", true, "Greek, English", "Senior Sales Analyst", "Strong background in Math", "Minimum 4 years of experience" },
                    { 3, "Degree in relative field", 2, "Senior Procurement Manager for our small company", true, "Greek, English", "Senior Procurement Manager", "Creative Problem-Solcing", "Minimum 7 years of experience" },
                    { 2, "Degree in relative field", 1, "Junior Recruiter for our small company", true, "Greek, English", "Junior Recruiter", "Strong Communication Skills", "Minimum 2 years of experience and a cover letter from your previous employer" },
                    { 5, "Degree in relative field", 3, "Junior Sales Analyst who is willing to work for free", true, "Greek, English", "Junior Sales Analyst", "Willing to work for free", "Internship" }
                });

            migrationBuilder.InsertData(
                table: "RawMaterialProducts",
                columns: new[] { "ProductId", "RawMaterialId" },
                values: new object[,]
                {
                    { 42, 1 },
                    { 1, 2 },
                    { 32, 3 },
                    { 20, 2 },
                    { 3, 5 },
                    { 5, 16 },
                    { 34, 14 },
                    { 9, 13 },
                    { 2, 4 },
                    { 10, 8 },
                    { 19, 6 },
                    { 23, 5 },
                    { 11, 12 }
                });

            migrationBuilder.InsertData(
                table: "RawMaterialSuppliers",
                columns: new[] { "RawMaterialId", "SupplierId" },
                values: new object[,]
                {
                    { 5, 6 },
                    { 1, 5 },
                    { 2, 5 },
                    { 4, 3 },
                    { 3, 3 },
                    { 1, 3 },
                    { 1, 6 },
                    { 2, 6 },
                    { 1, 4 },
                    { 2, 2 },
                    { 1, 7 },
                    { 1, 1 },
                    { 3, 1 },
                    { 6, 7 },
                    { 5, 7 },
                    { 6, 2 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "StorageUnits",
                columns: new[] { "Id", "Name", "WarehouseId" },
                values: new object[,]
                {
                    { 8, "S8", 3 },
                    { 1, "S1", 1 },
                    { 2, "S2", 1 },
                    { 6, "S6", 1 }
                });

            migrationBuilder.InsertData(
                table: "StorageUnits",
                columns: new[] { "Id", "Name", "WarehouseId" },
                values: new object[,]
                {
                    { 5, "S5", 4 },
                    { 9, "S9", 4 },
                    { 7, "S7", 2 },
                    { 3, "S3", 2 },
                    { 4, "S4", 3 },
                    { 10, "S10", 1 }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressNumber", "CandidateId", "Comments", "Country", "CustomerId", "EmployeeId", "Location", "PostCode", "SupplierId", "WarehouseId" },
                values: new object[,]
                {
                    { 10, (short)19, null, "Employee 1", "Greece", null, 1, "Dromou", (short)15350, null, null },
                    { 14, (short)98, null, "Employee 5", "Greece", null, 5, "Karpeta", (short)15354, null, null },
                    { 15, (short)20, null, "Employee 6", "Greece", null, 6, "Kaoutsa", (short)15355, null, null },
                    { 37, (short)52, null, "Employee 17", "Greece", null, 17, "Pasalimani", (short)15322, null, null },
                    { 41, (short)76, null, "Employee 21", "Greece", null, 21, "Alimou", (short)13762, null, null },
                    { 16, (short)76, null, "Employee 7", "Greece", null, 7, "Gkariza", (short)15356, null, null },
                    { 17, (short)46, null, "Employee 8", "Greece", null, 8, "Imalakou", (short)15357, null, null },
                    { 18, (short)3, null, "Employee 9", "Greece", null, 9, "Papputsi", (short)15358, null, null },
                    { 44, (short)171, null, "Employee 24", "Greece", null, 24, "Ionias", (short)17456, null, null },
                    { 19, (short)8, null, "Employee 10", "Greece", null, 10, "Fterou", (short)15359, null, null },
                    { 39, (short)47, null, "Employee 19", "Greece", null, 19, "Eirinis", (short)11122, null, null },
                    { 20, (short)6, null, "Employee 11", "Greece", null, 11, "Diakou", (short)15360, null, null },
                    { 24, (short)34, null, "Employee 15", "Greece", null, 15, "Trixia", (short)15364, null, null },
                    { 38, (short)42, null, "Employee 18", "Greece", null, 18, "Apiranthou", (short)15442, null, null },
                    { 23, (short)63, null, "Employee 14", "Greece", null, 14, "Kiramenaiou", (short)15363, null, null },
                    { 42, (short)16, null, "Employee 22", "Greece", null, 22, "Mpizaniou", (short)13762, null, null },
                    { 22, (short)84, null, "Employee 13", "Greece", null, 13, "Karra", (short)15362, null, null },
                    { 43, (short)169, null, "Employee 23", "Greece", null, 23, "Ionias", (short)17456, null, null },
                    { 13, (short)78, null, "Employee 4", "Greece", null, 4, "Dagkoto", (short)15353, null, null },
                    { 12, (short)5, null, "Employee 3", "Greece", null, 3, "Kalama", (short)15352, null, null },
                    { 21, (short)9, null, "Employee 12", "Greece", null, 12, "Pliktrou", (short)15361, null, null },
                    { 11, (short)2, null, "Employee 2", "Greece", null, 2, "Idioumenaki", (short)15351, null, null },
                    { 36, (short)34, null, "Employee 16", "Greece", null, 16, "Kalamakiou", (short)15364, null, null },
                    { 45, (short)23, null, "Employee 25", "Greece", null, 25, "Naupliou", (short)17456, null, null },
                    { 40, (short)99, null, "Employee 20", "Greece", null, 20, "Kalamakiou", (short)13322, null, null }
                });

            migrationBuilder.InsertData(
                table: "CandidatePositions",
                columns: new[] { "CandidateId", "PositionId", "RecruitStatus" },
                values: new object[,]
                {
                    { 1, 1, (byte)1 },
                    { 4, 4, (byte)2 },
                    { 6, 6, (byte)3 },
                    { 3, 3, (byte)2 },
                    { 7, 7, (byte)4 },
                    { 8, 8, (byte)4 },
                    { 5, 5, (byte)3 },
                    { 10, 10, (byte)7 },
                    { 9, 9, (byte)5 },
                    { 2, 2, (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "DiscountLevels",
                columns: new[] { "Id", "Amount", "DiscountId", "DiscountPercentage" },
                values: new object[,]
                {
                    { 1, 1000.0, 1, 0.02 },
                    { 2, 3000.0, 1, 0.050000000000000003 },
                    { 9, 12000.0, 5, 0.035000000000000003 },
                    { 12, 5000.0, 6, 0.080000000000000002 },
                    { 5, 1500.0, 3, 0.02 },
                    { 13, 4000.0, 7, 0.050000000000000003 },
                    { 10, 20000.0, 5, 0.070000000000000007 }
                });

            migrationBuilder.InsertData(
                table: "DiscountLevels",
                columns: new[] { "Id", "Amount", "DiscountId", "DiscountPercentage" },
                values: new object[,]
                {
                    { 4, 7000.0, 2, 0.059999999999999998 },
                    { 14, 10000.0, 7, 0.089999999999999997 },
                    { 8, 3000.0, 4, 0.059999999999999998 },
                    { 3, 3000.0, 2, 0.34999999999999998 },
                    { 6, 3000.0, 3, 0.050000000000000003 },
                    { 7, 2000.0, 4, 0.050000000000000003 },
                    { 11, 1000.0, 6, 0.02 }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "CandidateId", "CustomerId", "EmployeeId", "Mail", "MailType", "SupplierId", "WarehouseId" },
                values: new object[,]
                {
                    { 13, null, null, 13, "imabeebeebee@gmail.com", (byte)2, null, null },
                    { 14, null, null, 14, "koralimikrokoralo@gmail.com", (byte)2, null, null },
                    { 18, null, null, 18, "downsideballad@gmail.com", (byte)2, null, null },
                    { 1, null, null, 1, "ijustwanttosleep@gmail.com", (byte)2, null, null },
                    { 25, null, null, 25, "nighthowlers@gmail.com", (byte)2, null, null },
                    { 2, null, null, 2, "endmysuffering@gmail.com", (byte)2, null, null },
                    { 15, null, null, 15, "kaimikrokoralaki@gmail.com", (byte)2, null, null },
                    { 11, null, null, 11, "longislandicetea@gmail.com", (byte)2, null, null },
                    { 23, null, null, 23, "moontouched@gmail.com", (byte)2, null, null },
                    { 12, null, null, 12, "mylovelylittlelumps@gmail.com", (byte)2, null, null },
                    { 22, null, null, 22, "forbiddenknowledge@gmail.com", (byte)2, null, null },
                    { 16, null, null, 16, "intheflame@gmail.com", (byte)2, null, null },
                    { 10, null, null, 10, "twoshotsoftequila@gmail.com", (byte)2, null, null },
                    { 6, null, null, 6, "myoldfriend@gmail.com", (byte)2, null, null },
                    { 20, null, null, 20, "lifesentence@gmail.com", (byte)2, null, null },
                    { 17, null, null, 17, "downriver@gmail.com", (byte)2, null, null },
                    { 5, null, null, 5, "hellodarkness@gmail.com", (byte)2, null, null },
                    { 21, null, null, 21, "survivingexile@gmail.com", (byte)2, null, null },
                    { 4, null, null, 4, "livelovelaugh@gmail.com", (byte)2, null, null },
                    { 19, null, null, 19, "pathtoglory@gmail.com", (byte)2, null, null },
                    { 7, null, null, 7, "ihavecometo@gmail.com", (byte)2, null, null },
                    { 8, null, null, 8, "talktoyouagain@gmail.com", (byte)2, null, null },
                    { 24, null, null, 24, "throughthevalley@gmail.com", (byte)2, null, null },
                    { 3, null, null, 3, "existenceispain@gmail.com", (byte)2, null, null },
                    { 9, null, null, 9, "whenpigsfly@gmail.com", (byte)2, null, null }
                });

            migrationBuilder.InsertData(
                table: "Interviews",
                columns: new[] { "Id", "CandidateId", "Comments", "DateOfInterview", "EmployeeId", "Rating" },
                values: new object[,]
                {
                    { 2, 3, "Great energy", new DateTime(2021, 4, 2, 12, 30, 0, 0, DateTimeKind.Unspecified), 3, 5 },
                    { 1, 1, null, new DateTime(2021, 4, 18, 19, 30, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { 3, 5, null, new DateTime(2021, 4, 22, 14, 30, 0, 0, DateTimeKind.Unspecified), 5, 0 },
                    { 5, 9, "Mixed Feelings", new DateTime(2021, 3, 27, 17, 30, 0, 0, DateTimeKind.Unspecified), 9, 3 },
                    { 4, 7, "Not Impressed", new DateTime(2021, 3, 29, 13, 30, 0, 0, DateTimeKind.Unspecified), 7, 2 }
                });

            migrationBuilder.InsertData(
                table: "Leaves",
                columns: new[] { "Id", "EmployeeId", "File", "FileName", "LeaveType", "NumberOfDays", "StartDate", "Status" },
                values: new object[,]
                {
                    { 4, 15, null, null, (byte)4, 2, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)1 },
                    { 9, 19, null, null, (byte)4, 7, new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)1 },
                    { 7, 11, null, null, (byte)1, 7, new DateTime(2021, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)1 },
                    { 15, 17, null, null, (byte)2, 5, new DateTime(2021, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)1 },
                    { 10, 1, null, null, (byte)2, 1, new DateTime(2021, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Leaves",
                columns: new[] { "Id", "EmployeeId", "File", "FileName", "LeaveType", "NumberOfDays", "StartDate", "Status" },
                values: new object[,]
                {
                    { 12, 22, null, null, (byte)1, 2, new DateTime(2021, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)1 },
                    { 1, 2, null, null, (byte)1, 2, new DateTime(2021, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)1 },
                    { 14, 18, null, null, (byte)4, 4, new DateTime(2021, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)1 },
                    { 6, 2, null, null, (byte)5, 1, new DateTime(2021, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)1 },
                    { 8, 2, null, null, (byte)3, 4, new DateTime(2021, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)1 },
                    { 11, 11, null, null, (byte)5, 2, new DateTime(2021, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)1 },
                    { 2, 5, null, null, (byte)3, 5, new DateTime(2021, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)1 },
                    { 13, 20, null, null, (byte)3, 3, new DateTime(2021, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)1 },
                    { 3, 10, null, null, (byte)1, 2, new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)1 },
                    { 5, 9, null, null, (byte)2, 1, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "CandidateId", "CustomerId", "EmployeeId", "Number", "PhoneType", "SupplierId", "WarehouseId" },
                values: new object[,]
                {
                    { 23, null, null, 23, "2109381118", (byte)2, null, null },
                    { 4, null, null, 4, "2109854167", (byte)2, null, null },
                    { 3, null, null, 3, "2109924167", (byte)2, null, null },
                    { 16, null, null, 16, "2109381111", (byte)2, null, null },
                    { 20, null, null, 20, "2109381115", (byte)2, null, null },
                    { 6, null, null, 6, "2109854467", (byte)2, null, null },
                    { 2, null, null, 2, "2109924145", (byte)2, null, null },
                    { 1, null, null, 1, "2109923145", (byte)2, null, null },
                    { 25, null, null, 25, "2109381120", (byte)2, null, null },
                    { 12, null, null, 12, "2109384537", (byte)2, null, null },
                    { 5, null, null, 5, "2109852267", (byte)2, null, null },
                    { 21, null, null, 21, "2109381116", (byte)2, null, null },
                    { 22, null, null, 22, "2109381117", (byte)2, null, null },
                    { 13, null, null, 13, "2119385437", (byte)2, null, null },
                    { 17, null, null, 17, "2109381112", (byte)2, null, null },
                    { 14, null, null, 14, "2109385453", (byte)2, null, null },
                    { 11, null, null, 11, "2109763537", (byte)2, null, null },
                    { 15, null, null, 15, "2109385498", (byte)2, null, null },
                    { 18, null, null, 18, "2109381113", (byte)2, null, null },
                    { 9, null, null, 9, "2109948737", (byte)2, null, null },
                    { 19, null, null, 19, "2109381114", (byte)2, null, null },
                    { 8, null, null, 8, "2109654537", (byte)2, null, null },
                    { 24, null, null, 24, "2109381119", (byte)2, null, null },
                    { 7, null, null, 7, "2109854537", (byte)2, null, null },
                    { 10, null, null, 10, "2109754537", (byte)2, null, null }
                });

            migrationBuilder.InsertData(
                table: "Sectors",
                columns: new[] { "Id", "Name", "StorageUnitId" },
                values: new object[,]
                {
                    { 5, "Sector 5", 5 },
                    { 1, "Sector 1", 1 },
                    { 2, "Sector 2", 2 },
                    { 6, "Sector 6", 6 },
                    { 10, "Sector 10", 10 },
                    { 3, "Sector 3", 3 },
                    { 7, "Sector 7", 7 }
                });

            migrationBuilder.InsertData(
                table: "Sectors",
                columns: new[] { "Id", "Name", "StorageUnitId" },
                values: new object[] { 4, "Sector 4", 4 });

            migrationBuilder.InsertData(
                table: "Sectors",
                columns: new[] { "Id", "Name", "StorageUnitId" },
                values: new object[] { 8, "Sector 8", 8 });

            migrationBuilder.InsertData(
                table: "Sectors",
                columns: new[] { "Id", "Name", "StorageUnitId" },
                values: new object[] { 9, "Sector 9", 9 });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "DateCreated", "DateReviewed", "DiscountLevelId", "EmployeeId", "Name", "ReviewDeadline", "SupplierId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, "Offer 1", new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2021, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11, 1, "Offer 6", new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 5, new DateTime(2021, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, 1, "Offer 5", new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 4, new DateTime(2021, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, 1, "Offer 4", new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 7, new DateTime(2021, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 13, 1, "Offer 7", new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 9, new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, "Offer 9", new DateTime(2021, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, new DateTime(2021, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 1, "Offer 2", new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, "Offer 8", new DateTime(2021, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2021, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 1, "Offer 3", new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.InsertData(
                table: "Shelves",
                columns: new[] { "Id", "Name", "SectorId" },
                values: new object[,]
                {
                    { 13, "Shelf 13", 7 },
                    { 10, "Shelf 10", 5 },
                    { 9, "Shelf 9", 5 },
                    { 16, "Shelf 16", 8 },
                    { 15, "Shelf 15", 8 },
                    { 8, "Shelf 8", 4 },
                    { 7, "Shelf 7", 4 },
                    { 14, "Shelf 14", 7 },
                    { 6, "Shelf 6", 3 },
                    { 19, "Shelf 19", 10 },
                    { 3, "Shelf 3", 3 },
                    { 20, "Shelf 20", 10 },
                    { 17, "Shelf 17", 9 },
                    { 12, "Shelf 12", 6 },
                    { 11, "Shelf 11", 6 },
                    { 4, "Shelf 4", 2 },
                    { 2, "Shelf 2", 2 },
                    { 1, "Shelf 1", 1 },
                    { 5, "Shelf 5", 3 },
                    { 18, "Shelf 18", 9 }
                });

            migrationBuilder.InsertData(
                table: "OfferItems",
                columns: new[] { "Id", "OfferId", "Quantity", "RawMaterialId" },
                values: new object[,]
                {
                    { 1, 1, 150, 1 },
                    { 15, 7, 1000, 5 },
                    { 14, 7, 2800, 1 },
                    { 13, 6, 2000, 5 },
                    { 12, 6, 1000, 2 },
                    { 11, 6, 390, 1 },
                    { 10, 5, 500, 2 },
                    { 9, 5, 340, 1 },
                    { 16, 7, 100, 6 },
                    { 7, 4, 200, 1 },
                    { 8, 4, 100, 4 },
                    { 6, 3, 420, 3 },
                    { 5, 3, 322, 1 },
                    { 18, 9, 200, 6 },
                    { 4, 2, 234, 6 },
                    { 3, 2, 100, 2 },
                    { 17, 8, 100, 1 },
                    { 2, 1, 110, 3 }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "DateReceived", "OfferId", "SupplierId" },
                values: new object[,]
                {
                    { 6, new DateTime(2021, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null },
                    { 2, new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, null },
                    { 5, new DateTime(2020, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null },
                    { 1, new DateTime(2021, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, null },
                    { 4, new DateTime(2020, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, null },
                    { 7, new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null },
                    { 3, new DateTime(2021, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CandidateId",
                table: "Addresses",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_EmployeeId",
                table: "Addresses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_SupplierId",
                table: "Addresses",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_WarehouseId",
                table: "Addresses",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePositions_CandidateId_PositionId_RecruitStatus",
                table: "CandidatePositions",
                columns: new[] { "CandidateId", "PositionId", "RecruitStatus" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePositions_PositionId",
                table: "CandidatePositions",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Name",
                table: "Departments",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountLevels_DiscountId",
                table: "DiscountLevels",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_SupplierId",
                table: "Discounts",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_CandidateId",
                table: "Emails",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_CustomerId",
                table: "Emails",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_EmployeeId",
                table: "Emails",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_Mail",
                table: "Emails",
                column: "Mail",
                unique: true,
                filter: "[Mail] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_SupplierId",
                table: "Emails",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_WarehouseId",
                table: "Emails",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMeetings_MeetingId",
                table: "EmployeeMeetings",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_ProductId",
                table: "Favorites",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_CandidateId",
                table: "Interviews",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_EmployeeId",
                table: "Interviews",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveHistories_LeaveId",
                table: "LeaveHistories",
                column: "LeaveId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_EmployeeId",
                table: "Leaves",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_EmployeeId",
                table: "Meetings",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItems_OfferId",
                table: "OfferItems",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItems_RawMaterialId",
                table: "OfferItems",
                column: "RawMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_DiscountLevelId",
                table: "Offers",
                column: "DiscountLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_EmployeeId",
                table: "Offers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_SupplierId",
                table: "Offers",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_CandidateId",
                table: "Phones",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_CustomerId",
                table: "Phones",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_EmployeeId",
                table: "Phones",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_Number",
                table: "Phones",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phones_SupplierId",
                table: "Phones",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_WarehouseId",
                table: "Phones",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ProductId",
                table: "Photos",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_DepartmentId",
                table: "Positions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_Name",
                table: "Positions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Barcode",
                table: "Products",
                column: "Barcode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductShelves_ProductId_ShelfId",
                table: "ProductShelves",
                columns: new[] { "ProductId", "ShelfId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductShelves_ShelfId",
                table: "ProductShelves",
                column: "ShelfId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_OfferId",
                table: "Purchases",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_SupplierId",
                table: "Purchases",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterialProducts_ProductId",
                table: "RawMaterialProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterialProducts_RawMaterialId_ProductId",
                table: "RawMaterialProducts",
                columns: new[] { "RawMaterialId", "ProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterials_Name",
                table: "RawMaterials",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterialShelves_ShelfId",
                table: "RawMaterialShelves",
                column: "ShelfId");

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterialSuppliers_SupplierId",
                table: "RawMaterialSuppliers",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Sectors_StorageUnitId",
                table: "Sectors",
                column: "StorageUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Shelves_SectorId",
                table: "Shelves",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageUnits_WarehouseId",
                table: "StorageUnits",
                column: "WarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CandidatePositions");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "EmployeeMeetings");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Interviews");

            migrationBuilder.DropTable(
                name: "LeaveHistories");

            migrationBuilder.DropTable(
                name: "OfferItems");

            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "ProductShelves");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "RawMaterialProducts");

            migrationBuilder.DropTable(
                name: "RawMaterialShelves");

            migrationBuilder.DropTable(
                name: "RawMaterialSuppliers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "Leaves");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Shelves");

            migrationBuilder.DropTable(
                name: "RawMaterials");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "DiscountLevels");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Sectors");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "StorageUnits");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
