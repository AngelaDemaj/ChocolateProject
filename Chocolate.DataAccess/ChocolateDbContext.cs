using Chocolate.DataAccess.Configurations;
using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace Chocolate.DataAccess
{
    //we inherit from identitydbcontext to implement Microsoft identity login mechanism
    public class ChocolateDbContext : IdentityDbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidatePosition> CandidatePositions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<DiscountLevel> DiscountLevels { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<LeaveHistory> LeaveHistories { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<EmployeeMeeting> EmployeeMeetings { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<OfferItem> OfferItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductShelf> ProductShelves { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<RawMaterial> RawMaterials { get; set; }
        public DbSet<RawMaterialShelf> RawMaterialShelves { get; set; }
        public DbSet<RawMaterialProduct> RawMaterialProducts { get; set; }
        public DbSet<RawMaterialSupplier> RawMaterialSuppliers { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<StorageUnit> StorageUnits { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        private readonly DbContextOptions _options;

        public ChocolateDbContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //this implements all configurations that inherit from IEntityTypeConfiguration
            //if we did not write this line, we needed to apply configurations for all entities. For Example:
            //builder.ApplyConfiguration(new AddressConfiguration());
            //builder.ApplyConfiguration(new CandidateConfiguration());
            //instead we wrote:
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);

            #region Roles
            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                {
                    Id = "4a140611-352b-4d33-a52f-ba5b68df0ea4",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "70d42415-4006-40be-98b6-2ba981ef8dc2",
                    Name = "Accounting",
                    NormalizedName = "ACCOUNTING"
                },
                new IdentityRole
                {
                    Id = "130ff858-5251-4344-998a-216b0d98d181",
                    Name = "HR",
                    NormalizedName = "HR"
                },
                new IdentityRole
                {
                    Id = "91516112-cf50-4f2b-81f7-e9e09e193999",
                    Name = "DepartmentHead",
                    NormalizedName = "DEPARTMENTHEAD"
                },
                new IdentityRole
                {
                    Id = "8b7174ec-6d91-4b05-9f5b-fb2014650d75",
                    Name = "Warehouse",
                    NormalizedName = "WAREHOUSE"
                }
                );
            #endregion Roles

            #region Users
            builder.Entity<IdentityUser>()
                .HasData(
                new IdentityUser
                {
                    Id = "e1802e5e-a448-4c4e-841c-40b8a0de9dbf",
                    UserName = "Takis",
                    NormalizedUserName = "TAKIS",
                    Email = "Takis@gmail.com",
                    NormalizedEmail = "TAKIS@GMAIL.COM",
                    PasswordHash = new PasswordHasher<IdentityUser>()
                        .HashPassword(null, "P@ssw0rd")
                },
                new IdentityUser
                {
                    Id = "f6afa472-95ed-4220-bc3a-0c212afa15db",
                    UserName = "Hermes",
                    NormalizedUserName = "HERMES",
                    Email = "Hermes@gmail.com",
                    NormalizedEmail = "HERMES@GMAIL.COM",
                    PasswordHash = new PasswordHasher<IdentityUser>()
                        .HashPassword(null, "P@ssw0rd")
                },
                new IdentityUser
                {
                    Id = "aeab492c-eb08-4a29-b6d9-0b936a292116",
                    UserName = "Angela",
                    NormalizedUserName = "ANGELA",
                    Email = "Angela@gmail.com",
                    NormalizedEmail = "ANGELA@GMAIL.COM",
                    PasswordHash = new PasswordHasher<IdentityUser>()
                        .HashPassword(null, "P@ssw0rd")
                },
                new IdentityUser
                {
                    Id = "cd97911d-e70c-4a33-8365-ca3c69189215",
                    UserName = "Thanasis",
                    NormalizedUserName = "THANASIS",
                    Email = "Thanasis@gmail.com",
                    NormalizedEmail = "THANASIS@GMAIL.COM",
                    PasswordHash = new PasswordHasher<IdentityUser>()
                        .HashPassword(null, "P@ssw0rd")
                },
                new IdentityUser
                {
                    Id = "9e7b14d3-81eb-456a-a755-33d25dc1fd98",
                    UserName = "Vasilis",
                    NormalizedUserName = "VASILIS",
                    Email = "Vasilis@gmail.com",
                    NormalizedEmail = "VASILIS@GMAIL.COM",
                    PasswordHash = new PasswordHasher<IdentityUser>()
                        .HashPassword(null, "P@ssw0rd")
                },
                new IdentityUser
                {
                    Id = "d5e7fbf5-2be9-4e35-adf6-d6df34b0d4dd",
                    UserName = "Ferenc",
                    NormalizedUserName = "FERENC",
                    Email = "Ferenc@gmail.com",
                    NormalizedEmail = "FERENC@GMAIL.COM",
                    PasswordHash = new PasswordHasher<IdentityUser>()
                        .HashPassword(null, "P@ssw0rd")
                },
                new IdentityUser
                {
                    Id = "01cac9a3-aac4-459c-b879-04af9d1f07ee",
                    UserName = "Tseplo",
                    NormalizedUserName = "TSEPLO",
                    Email = "Tseplo@gmail.com",
                    NormalizedEmail = "TSEPLO@GMAIL.COM",
                    PasswordHash = new PasswordHasher<IdentityUser>()
                        .HashPassword(null, "P@ssw0rd")
                },
                new IdentityUser
                {
                    Id = "499a186a-847a-44bb-ac77-c8e07cdb1251",
                    UserName = "Shepllo",
                    NormalizedUserName = "SHEPLLO",
                    Email = "Shepllo@gmail.com",
                    NormalizedEmail = "SHEPLLO@GMAIL.COM",
                    PasswordHash = new PasswordHasher<IdentityUser>()
                        .HashPassword(null, "P@ssw0rd")
                },
                new IdentityUser
                {
                    Id = "907f51e7-8c3c-431a-8796-0e79f6a36630",
                    UserName = "Spooky",
                    NormalizedUserName = "SPOOKY",
                    Email = "Spooky@gmail.com",
                    NormalizedEmail = "SPOOKY@GMAIL.COM",
                    PasswordHash = new PasswordHasher<IdentityUser>()
                        .HashPassword(null, "P@ssw0rd")
                },
                new IdentityUser
                {
                    Id = "4c81c4fe-ece4-43fb-af0d-1b7077eeeb04",
                    UserName = "Maskinis-Siatis",
                    NormalizedUserName = "MASKINIS-SIATIS",
                    Email = "Masikins-Siatis@gmail.com",
                    NormalizedEmail = "MASKINIS-SIATIS@GMAIL.COM",
                    PasswordHash = new PasswordHasher<IdentityUser>()
                        .HashPassword(null, "P@ssw0rd")
                },
                new IdentityUser
                {
                    Id = "a620855c-c81a-4720-8c5f-cf724e1d0951",
                    UserName = "Zouzoulas",
                    NormalizedUserName = "ZOUZOULAS",
                    Email = "Zouzoulas@gmail.com",
                    NormalizedEmail = "ZOUZOULAS@GMAIL.COM",
                    PasswordHash = new PasswordHasher<IdentityUser>()
                        .HashPassword(null, "P@ssw0rd")
                },
                new IdentityUser
                {
                    Id = "60a94fc9-9ee5-4923-904c-6622c42d9e99",
                    UserName = "Nik",
                    NormalizedUserName = "NIK",
                    Email = "Nik@gmail.com",
                    NormalizedEmail = "NIK@GMAIL.COM",
                    PasswordHash = new PasswordHasher<IdentityUser>()
                        .HashPassword(null, "P@ssw0rd")
                },
                new IdentityUser
                {
                    Id = "40e78c1b-3314-4ad8-9a13-d3f5ec7965bf",
                    UserName = "Paris",
                    NormalizedUserName = "PARIS",
                    Email = "Paris@gmail.com",
                    NormalizedEmail = "PARIS@GMAIL.COM",
                    PasswordHash = new PasswordHasher<IdentityUser>()
                        .HashPassword(null, "P@ssw0rd")
                },
                new IdentityUser
                {
                    Id = "64fe3c64-6cf0-4de3-8e53-917825b2528e",
                    UserName = "Zongia",
                    NormalizedUserName = "ZONGIA",
                    Email = "Zongia@gmail.com",
                    NormalizedEmail = "ZONGIA@GMAIL.COM",
                    PasswordHash = new PasswordHasher<IdentityUser>()
                        .HashPassword(null, "P@ssw0rd")
                },
                new IdentityUser
                {
                    Id = "9cdad891-9814-4b2f-b769-74b9e2a8e836",
                    UserName = "Boltis",
                    NormalizedUserName = "BOLTSIS",
                    Email = "Boltis@gmail.com",
                    NormalizedEmail = "BOLTSIS@GMAIL.COM",
                    PasswordHash = new PasswordHasher<IdentityUser>()
                        .HashPassword(null, "P@ssw0rd")
                },
                new IdentityUser
                {
                    Id = "c9342ed5-bcf6-47d3-95f9-84a95b7f19f3",
                    UserName = "Poltis",
                    NormalizedUserName = "POLTSIS",
                    Email = "Poltis@gmail.com",
                    NormalizedEmail = "POLTSIS@GMAIL.COM",
                    PasswordHash = new PasswordHasher<IdentityUser>()
                        .HashPassword(null, "P@ssw0rd")
                },
                new IdentityUser
                {
                    Id = "d066e575-39cd-4ed5-b9e2-bfaeb08999e1",
                    UserName = "Koltsis",
                    NormalizedUserName = "KOLTSIS",
                    Email = "Koltis@gmail.com",
                    NormalizedEmail = "KOLTSIS@GMAIL.COM",
                    PasswordHash = new PasswordHasher<IdentityUser>()
                    .HashPassword(null, "P@ssw0rd")
                },
                new IdentityUser
                {
                    Id = "9048a711-c953-47de-8319-9f57cb2347ba",
                    UserName = "Pitsi",
                    NormalizedUserName = "PITSI",
                    Email = "Pitsi@gmail.com",
                    NormalizedEmail = "PITSI@GMAIL.COM",
                    PasswordHash = new PasswordHasher<IdentityUser>()
                    .HashPassword(null, "P@ssw0rd")
                },
                new IdentityUser
                {
                    Id = "a8f92bc6-3d6b-4315-8101-acea88fe480a",
                    UserName = "TiKsereis",
                    NormalizedUserName = "TIKSEREIS",
                    Email = "TiKsereis@gmail.com",
                    NormalizedEmail = "TIKSEREIS@GMAIL.COM",
                    PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(null, "P@ssw0rd")
                },
                new IdentityUser
                {
                    Id = "fd5aeaed-9088-457d-b91d-8c9074ef6c14",
                    UserName = "PikaPika",
                    NormalizedUserName = "PIKAPIKA",
                    Email = "PikaPika@gmail.com",
                    NormalizedEmail = "PIKAPIKA@GMAIL.COM",
                    PasswordHash = new PasswordHasher<IdentityUser>()
                        .HashPassword(null, "P@ssw0rd")
                },
                new IdentityUser
                {
                    Id = "ed6ea617-258e-41e9-8c1c-5c4823c5e87f",
                    UserName = "Bella",
                    NormalizedUserName = "BELLA",
                    Email = "Bella@gmail.com",
                    NormalizedEmail = "BELLA@GMAIL.COM",
                    PasswordHash = new PasswordHasher<IdentityUser>()
                        .HashPassword(null, "P@ssw0rd")
                },
                new IdentityUser
                {
                    Id = "5b60d6d4-5351-4f6a-9e0e-8acaa79daf94f",
                    UserName = "Kamatero",
                    NormalizedUserName = "KAMATERO",
                    Email = "Kamatero@gmail.com",
                    NormalizedEmail = "KAMATERO@GMAIL.COM",
                    PasswordHash = new PasswordHasher<IdentityUser>()
                        .HashPassword(null, "P@ssw0rd")
                },
                new IdentityUser
                {
                    Id = "2a023c9a-1676-4bf2-8ee8-a98b11e961d0",
                    UserName = "EasyBrizzy",
                    NormalizedUserName = "EASYBRIZZY",
                    Email = "EasyBrizzy@gmail.com",
                    NormalizedEmail = "EASYBRIZZY@GMAIL.COM",
                    PasswordHash = new PasswordHasher<IdentityUser>()
                        .HashPassword(null, "P@ssw0rd")
                },
                new IdentityUser
                {
                    Id = "437c2a07-2931-43de-9dfb-4d415247c508",
                    UserName = "Wow",
                    NormalizedUserName = "WOW",
                    Email = "Wow@gmail.com",
                    NormalizedEmail = "WOW@GMAIL.COM",
                    PasswordHash = new PasswordHasher<IdentityUser>()
                        .HashPassword(null, "P@ssw0rd")
                },
                 new IdentityUser
                 {
                     Id = "c4c6f346-65b7-4dda-97ce-4422eb58013a",
                     UserName = "Winchester",
                     NormalizedUserName = "WINCHESTER",
                     Email = "Winchester@gmail.com",
                     NormalizedEmail = "WINCHESTER@GMAIL.COM",
                     PasswordHash = new PasswordHasher<IdentityUser>()
                        .HashPassword(null, "P@ssw0rd")
                 }
                );
            #endregion Users

            #region UserRoles
            builder.Entity<IdentityUserRole<string>>()
                .HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "4a140611-352b-4d33-a52f-ba5b68df0ea4",
                    UserId = "e1802e5e-a448-4c4e-841c-40b8a0de9dbf"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "70d42415-4006-40be-98b6-2ba981ef8dc2",
                    UserId = "cd97911d-e70c-4a33-8365-ca3c69189215"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "130ff858-5251-4344-998a-216b0d98d181",
                    UserId = "aeab492c-eb08-4a29-b6d9-0b936a292116"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "8b7174ec-6d91-4b05-9f5b-fb2014650d75",
                    UserId = "9e7b14d3-81eb-456a-a755-33d25dc1fd98"
                }


            );
            #endregion UserRoles

            #region Suppliers

            builder.Entity<Supplier>()
                .HasData
                (
                    new Supplier
                    {
                        Id = 1,
                        Name = "AlphaChoc",
                        Type = "SA"
                    }, new Supplier
                    {
                        Id = 2,
                        Name = "DreamLine",
                        Type = "SA"
                    }, new Supplier
                    {
                        Id = 3,
                        Name = "Papavlaxos",
                        Type = "LTD"
                    }, new Supplier
                    {
                        Id = 4,
                        Name = "Marmita",
                        Type = "LLC"
                    }, new Supplier
                    {
                        Id = 5,
                        Name = "GiannaImport",
                        Type = "SA"
                    }, new Supplier
                    {
                        Id = 6,
                        Name = "Ifet",
                        Type = "SA"
                    }, new Supplier
                    {
                        Id = 7,
                        Name = "Gene",
                        Type = "LLC"
                    },
                    new Supplier
                    {
                        Id = 8,
                        Name = "Light",
                        Type = "LLC"
                    },
                    new Supplier
                    {
                        Id = 9,
                        Name = "Echo",
                        Type = "LTD"
                    },
                    new Supplier
                    {
                        Id = 10,
                        Name = "Paradise",
                        Type = "SA"
                    },
                    new Supplier
                    {
                        Id = 11,
                        Name = "Cosmos",
                        Type = "LTD"
                    },
                    new Supplier
                    {
                        Id = 12,
                        Name = "Business",
                        Type = "SA"
                    },
                    new Supplier
                    {
                        Id = 13,
                        Name = "Systems",
                        Type = "LLC"
                    },
                    new Supplier
                    {
                        Id = 14,
                        Name = "Rest",
                        Type = "SA"
                    },
                    new Supplier
                    {
                        Id = 15,
                        Name = "CBS",
                        Type = "LTD"
                    }
                );
            #endregion Suppliers

            #region Employees

            builder.Entity<Employee>()
                .HasData
                (
                    new Employee
                    {
                        Id = 1,
                        FirstName = "George",
                        LastName = "Chromosone",
                        WorkExperience = "Something good I guess",
                        IsHeadOfDepartment = false,
                        HireDate = DateTime.Parse("2020/02/02"),
                        DateOfBirth = DateTime.Parse("1980/02/20"),
                        DepartmentId = 1,
                        UserId = "e1802e5e-a448-4c4e-841c-40b8a0de9dbf"
                    },
                    new Employee
                    {
                        Id = 2,
                        FirstName = "Tyler",
                        LastName = "Durden",
                        WorkExperience = "So cool",
                        IsHeadOfDepartment = true,
                        HireDate = DateTime.Parse("2019/01/05"),
                        DateOfBirth = DateTime.Parse("1975/01/12"),
                        DepartmentId = 1,
                        UserId = "f6afa472-95ed-4220-bc3a-0c212afa15db"
                    },
                    new Employee
                    {
                        Id = 3,
                        FirstName = "Robert",
                        LastName = "Paulsen",
                        WorkExperience = "His Name was Robert Paulsen",
                        IsHeadOfDepartment = false,
                        HireDate = DateTime.Parse("2019/08/06"),
                        DateOfBirth = DateTime.Parse("1980/08/15"),
                        DepartmentId = 2,
                        UserId = "aeab492c-eb08-4a29-b6d9-0b936a292116"
                    },
                    new Employee
                    {
                        Id = 4,
                        FirstName = "Richard",
                        LastName = "Chester",
                        WorkExperience = "Wow so inadequeate",
                        IsHeadOfDepartment = false,
                        HireDate = DateTime.Parse("2019/10/09"),
                        DateOfBirth = DateTime.Parse("1990/07/10"),
                        DepartmentId = 2,
                        UserId = "cd97911d-e70c-4a33-8365-ca3c69189215"
                    },
                    new Employee
                    {
                        Id = 5,
                        FirstName = "Thomas",
                        LastName = "Inferino",
                        WorkExperience = "The best experience",
                        IsHeadOfDepartment = false,
                        HireDate = DateTime.Parse("2019/01/04"),
                        DateOfBirth = DateTime.Parse("1980/05/17"),
                        DepartmentId = 2,
                        UserId = "9e7b14d3-81eb-456a-a755-33d25dc1fd98"
                    },
                    new Employee
                    {
                        Id = 6,
                        FirstName = "Lee",
                        LastName = "Gooper",
                        WorkExperience = "The best of the best",
                        IsHeadOfDepartment = true,
                        HireDate = DateTime.Parse("2018/01/01"),
                        DateOfBirth = DateTime.Parse("1979/06/21"),
                        DepartmentId = 2,
                        UserId = "d5e7fbf5-2be9-4e35-adf6-d6df34b0d4dd"
                    },
                    new Employee
                    {
                        Id = 7,
                        FirstName = "Marla",
                        LastName = "Singer",
                        WorkExperience = "The bestest",
                        IsHeadOfDepartment = false,
                        HireDate = DateTime.Parse("2020/09/10"),
                        DateOfBirth = DateTime.Parse("1980/02/20"),
                        DepartmentId = 3,
                        UserId = "01cac9a3-aac4-459c-b879-04af9d1f07ee"
                    },
                    new Employee
                    {
                        Id = 8,
                        FirstName = "Charlie",
                        LastName = "Dell",
                        WorkExperience = "The best experience ever",
                        IsHeadOfDepartment = false,
                        HireDate = DateTime.Parse("2018/02/02"),
                        DateOfBirth = DateTime.Parse("1970/03/21"),
                        DepartmentId = 3,
                        UserId = "499a186a-847a-44bb-ac77-c8e07cdb1251"
                    },
                    new Employee
                    {
                        Id = 9,
                        FirstName = "Rob",
                        LastName = "Lanza",
                        WorkExperience = "What a wonderfull experience",
                        IsHeadOfDepartment = false,
                        HireDate = DateTime.Parse("2020/12/02"),
                        DateOfBirth = DateTime.Parse("1980/02/20"),
                        DepartmentId = 3,
                        UserId = "907f51e7-8c3c-431a-8796-0e79f6a36630"
                    },
                    new Employee
                    {
                        Id = 10,
                        FirstName = "Holly",
                        LastName = "McCallany",
                        WorkExperience = "Super douper experience",
                        IsHeadOfDepartment = false,
                        HireDate = DateTime.Parse("2020/05/05"),
                        DateOfBirth = DateTime.Parse("1985/03/20"),
                        DepartmentId = 3,
                        UserId = "4c81c4fe-ece4-43fb-af0d-1b7077eeeb04"
                    },
                    new Employee
                    {
                        Id = 11,
                        FirstName = "Lucy",
                        LastName = "Bissonnette",
                        WorkExperience = "The best of all",
                        IsHeadOfDepartment = true,
                        HireDate = DateTime.Parse("2019/03/02"),
                        DateOfBirth = DateTime.Parse("1976/02/20"),
                        DepartmentId = 3,
                        UserId = "a620855c-c81a-4720-8c5f-cf724e1d0951"
                    },
                    new Employee
                    {
                        Id = 12,
                        FirstName = "Ella",
                        LastName = "Bailey",
                        WorkExperience = "I wanna be the very best",
                        IsHeadOfDepartment = false,
                        HireDate = DateTime.Parse("2021/10/12"),
                        DateOfBirth = DateTime.Parse("1987/09/20"),
                        DepartmentId = 4,
                        UserId = "60a94fc9-9ee5-4923-904c-6622c42d9e99"
                    },
                    new Employee
                    {
                        Id = 13,
                        FirstName = "Jare",
                        LastName = "Vleto",
                        WorkExperience = "Like no one ever was",
                        IsHeadOfDepartment = false,
                        HireDate = DateTime.Parse("2020/09/01"),
                        DateOfBirth = DateTime.Parse("1989/09/22"),
                        DepartmentId = 4,
                        UserId = "40e78c1b-3314-4ad8-9a13-d3f5ec7965bf"
                    },
                    new Employee
                    {
                        Id = 14,
                        FirstName = "Anais",
                        LastName = "Winston",
                        WorkExperience = "The smartest of all",
                        IsHeadOfDepartment = false,
                        HireDate = DateTime.Parse("2019/02/02"),
                        DateOfBirth = DateTime.Parse("1989/12/12"),
                        DepartmentId = 4,
                        UserId = "64fe3c64-6cf0-4de3-8e53-917825b2528e"
                    },
                    new Employee
                    {
                        Id = 15,
                        FirstName = "Matt",
                        LastName = "Kim",
                        WorkExperience = "The strongest of all",
                        IsHeadOfDepartment = true,
                        HireDate = DateTime.Parse("2018/01/01"),
                        DateOfBirth = DateTime.Parse("1978/03/04"),
                        DepartmentId = 4,
                        UserId = "9cdad891-9814-4b2f-b769-74b9e2a8e836"
                    },
                    new Employee
                    {
                        Id = 16,
                        FirstName = "Lucy",
                        LastName = "Loo",
                        WorkExperience = "To catch the knowledge is my cause",
                        IsHeadOfDepartment = true,
                        HireDate = DateTime.Parse("2019/09/01"),
                        DateOfBirth = DateTime.Parse("1987/04/05"),
                        DepartmentId = 1,
                        UserId = "c9342ed5-bcf6-47d3-95f9-84a95b7f19f3"
                    },
                    new Employee
                    {
                        Id = 17,
                        FirstName = "Antony",
                        LastName = "Somersby",
                        WorkExperience = "The trainig is my cause",
                        IsHeadOfDepartment = false,
                        HireDate = DateTime.Parse("2020/10/02"),
                        DateOfBirth = DateTime.Parse("1987/04/05"),
                        DepartmentId = 2,
                        UserId = "d066e575-39cd-4ed5-b9e2-bfaeb08999e1"
                    },
                    new Employee
                    {
                        Id = 18,
                        FirstName = "Mary",
                        LastName = "Watermelon",
                        WorkExperience = "Ultra experienced",
                        IsHeadOfDepartment = false,
                        HireDate = DateTime.Parse("2019/11/03"),
                        DateOfBirth = DateTime.Parse("1988/05/06"),
                        DepartmentId = 3,
                        UserId = "9048a711-c953-47de-8319-9f57cb2347ba"
                    },
                    new Employee
                    {
                        Id = 19,
                        FirstName = "Nick",
                        LastName = "Meow",
                        WorkExperience = "Super experienced",
                        IsHeadOfDepartment = true,
                        HireDate = DateTime.Parse("2020/12/04"),
                        DateOfBirth = DateTime.Parse("1978/06/07"),
                        DepartmentId = 4,
                        UserId = "a8f92bc6-3d6b-4315-8101-acea88fe480a"
                    },
                    new Employee
                    {
                        Id = 20,
                        FirstName = "Peter",
                        LastName = "Flavoured",
                        WorkExperience = "The one that never bored",
                        IsHeadOfDepartment = false,
                        HireDate = DateTime.Parse("2019/01/05"),
                        DateOfBirth = DateTime.Parse("1979/07/07"),
                        DepartmentId = 1,
                        UserId = "fd5aeaed-9088-457d-b91d-8c9074ef6c14"
                    },
                    new Employee
                    {
                        Id = 21,
                        FirstName = "Paris",
                        LastName = "OverIce",
                        WorkExperience = "Something really nice",
                        IsHeadOfDepartment = false,
                        HireDate = DateTime.Parse("2019/02/06"),
                        DateOfBirth = DateTime.Parse("1979/08/08"),
                        DepartmentId = 2,
                        UserId = "ed6ea617-258e-41e9-8c1c-5c4823c5e87f"
                    },
                    new Employee
                    {
                        Id = 22,
                        FirstName = "Leon",
                        LastName = "Pisher",
                        WorkExperience = "The best of the best",
                        IsHeadOfDepartment = true,
                        HireDate = DateTime.Parse("2019/03/07"),
                        DateOfBirth = DateTime.Parse("1980/09/10"),
                        DepartmentId = 3,
                        UserId = "5b60d6d4-5351-4f6a-9e0e-8acaa79daf94f"
                    },
                    new Employee
                    {
                        Id = 23,
                        FirstName = "Liam",
                        LastName = "Cider",
                        WorkExperience = "Most experienced of all",
                        IsHeadOfDepartment = false,
                        HireDate = DateTime.Parse("2019/04/08"),
                        DateOfBirth = DateTime.Parse("1980/10/11"),
                        DepartmentId = 3,
                        UserId = "2a023c9a-1676-4bf2-8ee8-a98b11e961d0"
                    },
                    new Employee
                    {
                        Id = 24,
                        FirstName = "Zan",
                        LastName = "Wow",
                        WorkExperience = "The power thats inside",
                        IsHeadOfDepartment = false,
                        HireDate = DateTime.Parse("2018/05/09"),
                        DateOfBirth = DateTime.Parse("1982/11/12"),
                        DepartmentId = 4,
                        UserId = "437c2a07-2931-43de-9dfb-4d415247c508"
                    },
                    new Employee
                    {
                        Id = 25,
                        FirstName = "Anna",
                        LastName = "Banana",
                        WorkExperience = "I know it's my destiny",
                        IsHeadOfDepartment = true,
                        HireDate = DateTime.Parse("2018/06/10"),
                        DateOfBirth = DateTime.Parse("1982/12/12"),
                        DepartmentId = 1,
                        UserId = "c4c6f346-65b7-4dda-97ce-4422eb58013a"
                    }
                );

            #endregion Employees

            #region Customers
            builder.Entity<Customer>()
                .HasData(
                new Customer
                {
                    Id = 1,
                    FirstName = "Makis",
                    LastName = "Metamorfwsi"
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Amir",
                    LastName = "Rao"
                },
                new Customer
                {
                    Id = 3,
                    FirstName = "Gavin",
                    LastName = "Simon"
                },
                new Customer
                {
                    Id = 4,
                    FirstName = "Darren",
                    LastName = "Korb"
                },
                new Customer
                {
                    Id = 5,
                    FirstName = "Jen",
                    LastName = "Zee"
                },
                new Customer
                {
                    Id = 6,
                    FirstName = "Greg",
                    LastName = "Kasavin"
                },
                new Customer
                {
                    Id = 7,
                    FirstName = "Andrew",
                    LastName = "Wang"
                },
                new Customer
                {
                    Id = 8,
                    FirstName = "Logan",
                    LastName = "Cunningham"
                },
                new Customer
                {
                    Id = 9,
                    FirstName = "Josh",
                    LastName = "Barnett"
                },
                new Customer
                {
                    Id = 10,
                    FirstName = "John-Paul",
                    LastName = "Gabler"
                },
                new Customer
                {
                    Id = 11,
                    FirstName = "Dexter",
                    LastName = "Friedman"
                },
                new Customer
                {
                    Id = 12,
                    FirstName = "Ashley",
                    LastName = "Barrett"
                }
                );
            #endregion Customers

            #region Orders
            builder.Entity<Order>()
                .HasData(
                new Order
                {
                    Id = 1,
                    CustomerId = 1,
                    OrderPlaced = new DateTime(2021, 04, 2, 12, 30, 00),
                    PaymentType = PaymentType.CreditCard
                },
                new Order
                {
                    Id = 2,
                    CustomerId = 3,
                    OrderPlaced = new DateTime(2021, 03, 18, 14, 37, 00),
                    PaymentType = PaymentType.PayOnDelivery
                },
                new Order
                {
                    Id = 3,
                    CustomerId = 5,
                    OrderPlaced = new DateTime(2021, 04, 2, 5, 37, 00),
                    OrderFulfilled = new DateTime(2021, 04, 10, 12, 27, 00),
                    PaymentType = PaymentType.PayOnDelivery
                },
                new Order
                {
                    Id = 4,
                    CustomerId = 7,
                    OrderPlaced = new DateTime(2021, 03, 27, 19, 45, 00),
                    OrderFulfilled = new DateTime(2021, 04, 2, 12, 56, 00),
                    PaymentType = PaymentType.CreditCard
                },
                new Order
                {
                    Id = 5,
                    CustomerId = 9,
                    OrderPlaced = new DateTime(2021, 04, 7, 11, 30, 00),
                    OrderFulfilled = new DateTime(2021, 04, 11, 16, 05, 00),
                    PaymentType = PaymentType.CreditCard
                },
                new Order
                {
                    Id = 6,
                    CustomerId = 11,
                    OrderPlaced = new DateTime(2021, 04, 10, 23, 45, 00),
                    PaymentType = PaymentType.PayOnDelivery
                }

                ); ;
            #endregion

            #region Addresses

            builder.Entity<Address>()
                .HasData(

            #region Warehouses

                new Address
                {
                    Id = 1,
                    Country = "Greece",
                    Location = "Thessalonikis",
                    AddressNumber = 3,
                    PostCode = 15354,
                    Comments = "Our First Warehouse",
                    WarehouseId = 1
                },
                new Address
                {
                    Id = 2,
                    Country = "Greece",
                    Location = "Attikis",
                    AddressNumber = 12,
                    PostCode = 15344,
                    Comments = "Our Second Warehouse",
                    WarehouseId = 2
                },
                new Address
                {
                    Id = 34,
                    Country = "Island",
                    Location = "Islandias",
                    AddressNumber = 52,
                    PostCode = 11231,
                    Comments = "Our Third Warehouse",
                    WarehouseId = 3
                },
                new Address
                {
                    Id = 35,
                    Country = "Holland",
                    Location = "Hollandias",
                    AddressNumber = 69,
                    PostCode = 11321,
                    Comments = "Our Fourth Warehouse",
                    WarehouseId = 4
                },

            #endregion Warehouses

            #region Suppliers

                new Address
                {
                    Id = 3,
                    Country = "Greece",
                    Location = "Hpeirou",
                    AddressNumber = 9,
                    PostCode = 15232,
                    Comments = "Supplier 1",
                    SupplierId = 1
                },
                new Address
                {
                    Id = 4,
                    Country = "Greece",
                    Location = "Manis",
                    AddressNumber = 45,
                    PostCode = 15342,
                    Comments = "Supplier 2",
                    SupplierId = 2
                },
                new Address
                {
                    Id = 5,
                    Country = "Greece",
                    Location = "Plapouta",
                    AddressNumber = 122,
                    PostCode = 15345,
                    Comments = "Supplier 3",
                    SupplierId = 3
                },
                new Address
                {
                    Id = 6,
                    Country = "Greece",
                    Location = "Manola",
                    AddressNumber = 12,
                    PostCode = 15346,
                    Comments = "Supplier 4",
                    SupplierId = 4
                },
                new Address
                {
                    Id = 7,
                    Country = "Greece",
                    Location = "Parmeniona",
                    AddressNumber = 180,
                    PostCode = 15348,
                    Comments = "Supplier 5",
                    SupplierId = 5
                },
                new Address
                {
                    Id = 8,
                    Country = "Greece",
                    Location = "Kokkinou",
                    AddressNumber = 109,
                    PostCode = 15347,
                    Comments = "Supplier 6",
                    SupplierId = 6
                },
                new Address
                {
                    Id = 9,
                    Country = "Greece",
                    Location = "Dromena",
                    AddressNumber = 17,
                    PostCode = 15349,
                    Comments = "Supplier 7",
                    SupplierId = 7
                },
                new Address
                {
                    Id = 46,
                    Country = "Greece",
                    Location = "Krouskaki",
                    AddressNumber = 52,
                    PostCode = 15322,
                    Comments = "Supplier 8",
                    SupplierId = 8
                },
                new Address
                {
                    Id = 47,
                    Country = "Greece",
                    Location = "Pierrou",
                    AddressNumber = 28,
                    PostCode = 15451,
                    Comments = "Supplier 9",
                    SupplierId = 9
                },
                new Address
                {
                    Id = 48,
                    Country = "Greece",
                    Location = "Samou",
                    AddressNumber = 68,
                    PostCode = 15422,
                    Comments = "Supplier 10",
                    SupplierId = 10
                },
                new Address
                {
                    Id = 49,
                    Country = "Greece",
                    Location = "Georgakopoulou",
                    AddressNumber = 69,
                    PostCode = 15422,
                    Comments = "Supplier 11",
                    SupplierId = 11
                },
                new Address
                {
                    Id = 50,
                    Country = "Greece",
                    Location = "Plitsiou",
                    AddressNumber = 71,
                    PostCode = 15322,
                    Comments = "Supplier 11",
                    SupplierId = 12
                },
                new Address
                {
                    Id = 51,
                    Country = "Greece",
                    Location = "Mpampakou",
                    AddressNumber = 71,
                    PostCode = 11422,
                    Comments = "Supplier 11",
                    SupplierId = 13
                },
                new Address
                {
                    Id = 52,
                    Country = "Greece",
                    Location = "Mpampakou",
                    AddressNumber = 71,
                    PostCode = 12422,
                    Comments = "Supplier 11",
                    SupplierId = 14
                },
                new Address
                {
                    Id = 53,
                    Country = "Greece",
                    Location = "Naki",
                    AddressNumber = 33,
                    PostCode = 12422,
                    Comments = "Supplier 11",
                    SupplierId = 15
                },


            #endregion

            #region Employees

                new Address
                {
                    Id = 10,
                    Country = "Greece",
                    Location = "Dromou",
                    AddressNumber = 19,
                    PostCode = 15350,
                    Comments = "Employee 1",
                    EmployeeId = 1
                },
                new Address
                {
                    Id = 11,
                    Country = "Greece",
                    Location = "Idioumenaki",
                    AddressNumber = 2,
                    PostCode = 15351,
                    Comments = "Employee 2",
                    EmployeeId = 2
                },
                new Address
                {
                    Id = 12,
                    Country = "Greece",
                    Location = "Kalama",
                    AddressNumber = 5,
                    PostCode = 15352,
                    Comments = "Employee 3",
                    EmployeeId = 3
                },
                new Address
                {
                    Id = 13,
                    Country = "Greece",
                    Location = "Dagkoto",
                    AddressNumber = 78,
                    PostCode = 15353,
                    Comments = "Employee 4",
                    EmployeeId = 4
                },
                new Address
                {
                    Id = 14,
                    Country = "Greece",
                    Location = "Karpeta",
                    AddressNumber = 98,
                    PostCode = 15354,
                    Comments = "Employee 5",
                    EmployeeId = 5
                },
                new Address
                {
                    Id = 15,
                    Country = "Greece",
                    Location = "Kaoutsa",
                    AddressNumber = 20,
                    PostCode = 15355,
                    Comments = "Employee 6",
                    EmployeeId = 6
                },
                new Address
                {
                    Id = 16,
                    Country = "Greece",
                    Location = "Gkariza",
                    AddressNumber = 76,
                    PostCode = 15356,
                    Comments = "Employee 7",
                    EmployeeId = 7
                },
                new Address
                {
                    Id = 17,
                    Country = "Greece",
                    Location = "Imalakou",
                    AddressNumber = 46,
                    PostCode = 15357,
                    Comments = "Employee 8",
                    EmployeeId = 8
                },
                new Address
                {
                    Id = 18,
                    Country = "Greece",
                    Location = "Papputsi",
                    AddressNumber = 3,
                    PostCode = 15358,
                    Comments = "Employee 9",
                    EmployeeId = 9
                },
                new Address
                {
                    Id = 19,
                    Country = "Greece",
                    Location = "Fterou",
                    AddressNumber = 8,
                    PostCode = 15359,
                    Comments = "Employee 10",
                    EmployeeId = 10
                },
                new Address
                {
                    Id = 20,
                    Country = "Greece",
                    Location = "Diakou",
                    AddressNumber = 6,
                    PostCode = 15360,
                    Comments = "Employee 11",
                    EmployeeId = 11
                },
                new Address
                {
                    Id = 21,
                    Country = "Greece",
                    Location = "Pliktrou",
                    AddressNumber = 9,
                    PostCode = 15361,
                    Comments = "Employee 12",
                    EmployeeId = 12
                },
                new Address
                {
                    Id = 22,
                    Country = "Greece",
                    Location = "Karra",
                    AddressNumber = 84,
                    PostCode = 15362,
                    Comments = "Employee 13",
                    EmployeeId = 13
                },
                new Address
                {
                    Id = 23,
                    Country = "Greece",
                    Location = "Kiramenaiou",
                    AddressNumber = 63,
                    PostCode = 15363,
                    Comments = "Employee 14",
                    EmployeeId = 14
                },
                new Address
                {
                    Id = 24,
                    Country = "Greece",
                    Location = "Trixia",
                    AddressNumber = 34,
                    PostCode = 15364,
                    Comments = "Employee 15",
                    EmployeeId = 15
                },
                new Address
                {
                    Id = 36,
                    Country = "Greece",
                    Location = "Kalamakiou",
                    AddressNumber = 34,
                    PostCode = 15364,
                    Comments = "Employee 16",
                    EmployeeId = 16
                },
                new Address
                {
                    Id = 37,
                    Country = "Greece",
                    Location = "Pasalimani",
                    AddressNumber = 52,
                    PostCode = 15322,
                    Comments = "Employee 17",
                    EmployeeId = 17
                },
                new Address
                {
                    Id = 38,
                    Country = "Greece",
                    Location = "Apiranthou",
                    AddressNumber = 42,
                    PostCode = 15442,
                    Comments = "Employee 18",
                    EmployeeId = 18
                },
                new Address
                {
                    Id = 39,
                    Country = "Greece",
                    Location = "Eirinis",
                    AddressNumber = 47,
                    PostCode = 11122,
                    Comments = "Employee 19",
                    EmployeeId = 19
                },
                new Address
                {
                    Id = 40,
                    Country = "Greece",
                    Location = "Kalamakiou",
                    AddressNumber = 99,
                    PostCode = 13322,
                    Comments = "Employee 20",
                    EmployeeId = 20
                },
                new Address
                {
                    Id = 41,
                    Country = "Greece",
                    Location = "Alimou",
                    AddressNumber = 76,
                    PostCode = 13762,
                    Comments = "Employee 21",
                    EmployeeId = 21
                },
                new Address
                {
                    Id = 42,
                    Country = "Greece",
                    Location = "Mpizaniou",
                    AddressNumber = 16,
                    PostCode = 13762,
                    Comments = "Employee 22",
                    EmployeeId = 22
                },
                new Address
                {
                    Id = 43,
                    Country = "Greece",
                    Location = "Ionias",
                    AddressNumber = 169,
                    PostCode = 17456,
                    Comments = "Employee 23",
                    EmployeeId = 23
                },
                new Address
                {
                    Id = 44,
                    Country = "Greece",
                    Location = "Ionias",
                    AddressNumber = 171,
                    PostCode = 17456,
                    Comments = "Employee 24",
                    EmployeeId = 24
                },
                new Address
                {
                    Id = 45,
                    Country = "Greece",
                    Location = "Naupliou",
                    AddressNumber = 23,
                    PostCode = 17456,
                    Comments = "Employee 25",
                    EmployeeId = 25
                },

            #endregion

            #region Customers

                new Address
                {
                    Id = 54,
                    Country = "Greece",
                    Location = "Xaralampou",
                    AddressNumber = 23,
                    PostCode = 17456,
                    Comments = "Customer 1",
                    CustomerId = 1
                },
                new Address
                {
                    Id = 55,
                    Country = "Greece",
                    Location = "Kolokotroni",
                    AddressNumber = 33,
                    PostCode = 17482,
                    Comments = "Customer 2",
                    CustomerId = 2
                },
                new Address
                {
                    Id = 56,
                    Country = "Greece",
                    Location = "Pitsou",
                    AddressNumber = 22,
                    PostCode = 13382,
                    Comments = "Customer 3",
                    CustomerId = 3
                },
                new Address
                {
                    Id = 57,
                    Country = "Greece",
                    Location = "Pikatsou",
                    AddressNumber = 88,
                    PostCode = 13382,
                    Comments = "Customer 4",
                    CustomerId = 4
                },
                new Address
                {
                    Id = 58,
                    Country = "Greece",
                    Location = "Raitsou",
                    AddressNumber = 132,
                    PostCode = 13382,
                    Comments = "Customer 5",
                    CustomerId = 5
                },
                new Address
                {
                    Id = 59,
                    Country = "Greece",
                    Location = "Paprikas",
                    AddressNumber = 52,
                    PostCode = 13772,
                    Comments = "Customer 6",
                    CustomerId = 6
                },
                new Address
                {
                    Id = 60,
                    Country = "Greece",
                    Location = "Maintanou",
                    AddressNumber = 57,
                    PostCode = 13772,
                    Comments = "Customer 7",
                    CustomerId = 7
                },
                new Address
                {
                    Id = 61,
                    Country = "Greece",
                    Location = "Anithou",
                    AddressNumber = 82,
                    PostCode = 13992,
                    Comments = "Customer 8",
                    CustomerId = 8
                },
                new Address
                {
                    Id = 62,
                    Country = "Greece",
                    Location = "Piperiou",
                    AddressNumber = 82,
                    PostCode = 22992,
                    Comments = "Customer 9",
                    CustomerId = 9
                },
                new Address
                {
                    Id = 63,
                    Country = "Greece",
                    Location = "Alatiou",
                    AddressNumber = 68,
                    PostCode = 22992,
                    Comments = "Customer 10",
                    CustomerId = 10
                },
                new Address
                {
                    Id = 64,
                    Country = "Greece",
                    Location = "Valsamikou",
                    AddressNumber = 71,
                    PostCode = 22992,
                    Comments = "Customer 11",
                    CustomerId = 11
                },
                new Address
                {
                    Id = 65,
                    Country = "Greece",
                    Location = "Ladiou",
                    AddressNumber = 71,
                    PostCode = 22132,
                    Comments = "Customer 12",
                    CustomerId = 12
                },

            #endregion

            #region Candidates
                new Address
                {
                    Id = 66,
                    Country = "Greece",
                    Location = "Kalymnou",
                    AddressNumber = 71,
                    PostCode = 22992,
                    Comments = "Candidate 1",
                    CandidateId = 1
                },
                new Address
                {
                    Id = 67,
                    Country = "Greece",
                    Location = "Rodou",
                    AddressNumber = 52,
                    PostCode = 22980,
                    Comments = "Candidate 2",
                    CandidateId = 2
                },
                new Address
                {
                    Id = 68,
                    Country = "Greece",
                    Location = "Mykonou",
                    AddressNumber = 45,
                    PostCode = 21380,
                    Comments = "Candidate 3",
                    CandidateId = 3
                },
                new Address
                {
                    Id = 69,
                    Country = "Greece",
                    Location = "Parou",
                    AddressNumber = 33,
                    PostCode = 21900,
                    Comments = "Candidate 4",
                    CandidateId = 4
                },
                new Address
                {
                    Id = 70,
                    Country = "Greece",
                    Location = "Leukadas",
                    AddressNumber = 5,
                    PostCode = 21032,
                    Comments = "Candidate 5",
                    CandidateId = 5
                },
                new Address
                {
                    Id = 71,
                    Country = "Greece",
                    Location = "Porou",
                    AddressNumber = 56,
                    PostCode = 21011,
                    Comments = "Candidate 6",
                    CandidateId = 6
                },
                new Address
                {
                    Id = 72,
                    Country = "Greece",
                    Location = "Kritis",
                    AddressNumber = 90,
                    PostCode = 21055,
                    Comments = "Candidate 7",
                    CandidateId = 7
                },
                new Address
                {
                    Id = 73,
                    Country = "Greece",
                    Location = "Kefalonias",
                    AddressNumber = 83,
                    PostCode = 21012,
                    Comments = "Candidate 8",
                    CandidateId = 8
                },
                new Address
                {
                    Id = 74,
                    Country = "Greece",
                    Location = "Patmou",
                    AddressNumber = 42,
                    PostCode = 21662,
                    Comments = "Candidate 9",
                    CandidateId = 9
                },
                new Address
                {
                    Id = 75,
                    Country = "Greece",
                    Location = "Lerou",
                    AddressNumber = 42,
                    PostCode = 21612,
                    Comments = "Candidate 10",
                    CandidateId = 10
                }

                #endregion

                );
            #endregion

            #region Emails

            builder.Entity<Email>()
                .HasData(

            #region Employees

                new Email
                {
                    Id = 1,
                    Mail = "ijustwanttosleep@gmail.com",
                    MailType = MailType.Work,
                    EmployeeId = 1
                },
                new Email
                {
                    Id = 2,
                    Mail = "endmysuffering@gmail.com",
                    MailType = MailType.Work,
                    EmployeeId = 2
                },
                new Email
                {
                    Id = 3,
                    Mail = "existenceispain@gmail.com",
                    MailType = MailType.Work,
                    EmployeeId = 3
                },
                new Email
                {
                    Id = 4,
                    Mail = "livelovelaugh@gmail.com",
                    MailType = MailType.Work,
                    EmployeeId = 4
                },
                new Email
                {
                    Id = 5,
                    Mail = "hellodarkness@gmail.com",
                    MailType = MailType.Work,
                    EmployeeId = 5
                },
                new Email
                {
                    Id = 6,
                    Mail = "myoldfriend@gmail.com",
                    MailType = MailType.Work,
                    EmployeeId = 6
                },
                new Email
                {
                    Id = 7,
                    Mail = "ihavecometo@gmail.com",
                    MailType = MailType.Work,
                    EmployeeId = 7
                },
                new Email
                {
                    Id = 8,
                    Mail = "talktoyouagain@gmail.com",
                    MailType = MailType.Work,
                    EmployeeId = 8
                },
                new Email
                {
                    Id = 9,
                    Mail = "whenpigsfly@gmail.com",
                    MailType = MailType.Work,
                    EmployeeId = 9
                },
                new Email
                {
                    Id = 10,
                    Mail = "twoshotsoftequila@gmail.com",
                    MailType = MailType.Work,
                    EmployeeId = 10
                },
                new Email
                {
                    Id = 11,
                    Mail = "longislandicetea@gmail.com",
                    MailType = MailType.Work,
                    EmployeeId = 11
                },
                new Email
                {
                    Id = 12,
                    Mail = "mylovelylittlelumps@gmail.com",
                    MailType = MailType.Work,
                    EmployeeId = 12
                },
                new Email
                {
                    Id = 13,
                    Mail = "imabeebeebee@gmail.com",
                    MailType = MailType.Work,
                    EmployeeId = 13
                },
                new Email
                {
                    Id = 14,
                    Mail = "koralimikrokoralo@gmail.com",
                    MailType = MailType.Work,
                    EmployeeId = 14
                },
                new Email
                {
                    Id = 15,
                    Mail = "kaimikrokoralaki@gmail.com",
                    MailType = MailType.Work,
                    EmployeeId = 15
                },
                new Email
                {
                    Id = 16,
                    Mail = "intheflame@gmail.com",
                    MailType = MailType.Work,
                    EmployeeId = 16
                },
                new Email
                {
                    Id = 17,
                    Mail = "downriver@gmail.com",
                    MailType = MailType.Work,
                    EmployeeId = 17
                },
                new Email
                {
                    Id = 18,
                    Mail = "downsideballad@gmail.com",
                    MailType = MailType.Work,
                    EmployeeId = 18
                },
                new Email
                {
                    Id = 19,
                    Mail = "pathtoglory@gmail.com",
                    MailType = MailType.Work,
                    EmployeeId = 19
                },
                new Email
                {
                    Id = 20,
                    Mail = "lifesentence@gmail.com",
                    MailType = MailType.Work,
                    EmployeeId = 20
                },
                new Email
                {
                    Id = 21,
                    Mail = "survivingexile@gmail.com",
                    MailType = MailType.Work,
                    EmployeeId = 21
                },
                new Email
                {
                    Id = 22,
                    Mail = "forbiddenknowledge@gmail.com",
                    MailType = MailType.Work,
                    EmployeeId = 22
                },
                new Email
                {
                    Id = 23,
                    Mail = "moontouched@gmail.com",
                    MailType = MailType.Work,
                    EmployeeId = 23
                },
                new Email
                {
                    Id = 24,
                    Mail = "throughthevalley@gmail.com",
                    MailType = MailType.Work,
                    EmployeeId = 24
                },
                new Email
                {
                    Id = 25,
                    Mail = "nighthowlers@gmail.com",
                    MailType = MailType.Work,
                    EmployeeId = 25
                },


            #endregion Employees

            #region Suppliers
                new Email
                {
                    Id = 26,
                    Mail = "theherald@gmail.com",
                    MailType = MailType.Work,
                    SupplierId = 1
                },
                new Email
                {
                    Id = 27,
                    Mail = "mourningsong@gmail.com",
                    MailType = MailType.Work,
                    SupplierId = 2
                },
                new Email
                {
                    Id = 28,
                    Mail = "eightscribes@gmail.com",
                    MailType = MailType.Work,
                    SupplierId = 3
                },
                new Email
                {
                    Id = 29,
                    Mail = "glorioustradition@gmail.com",
                    MailType = MailType.Work,
                    SupplierId = 4
                },
                new Email
                {
                    Id = 30,
                    Mail = "flutterfly@gmail.com",
                    MailType = MailType.Work,
                    SupplierId = 5
                },
                new Email
                {
                    Id = 31,
                    Mail = "trashpack@gmail.com",
                    MailType = MailType.Work,
                    SupplierId = 6
                },
                new Email
                {
                    Id = 32,
                    Mail = "astepcloser@gmail.com",
                    MailType = MailType.Work,
                    SupplierId = 7
                },
                new Email
                {
                    Id = 33,
                    Mail = "dirtydeal@gmail.com",
                    MailType = MailType.Work,
                    SupplierId = 8
                },
                new Email
                {
                    Id = 34,
                    Mail = "sinkingfeeling@gmail.com",
                    MailType = MailType.Work,
                    SupplierId = 9
                },
                new Email
                {
                    Id = 35,
                    Mail = "dreaddesign@gmail.com",
                    MailType = MailType.Work,
                    SupplierId = 10
                },
                new Email
                {
                    Id = 36,
                    Mail = "snakesoul@gmail.com",
                    MailType = MailType.Work,
                    SupplierId = 11
                },
                new Email
                {
                    Id = 37,
                    Mail = "strangevoyage@gmail.com",
                    MailType = MailType.Work,
                    SupplierId = 12
                },
                new Email
                {
                    Id = 38,
                    Mail = "questforhonor@gmail.com",
                    MailType = MailType.Work,
                    SupplierId = 13
                },
                new Email
                {
                    Id = 39,
                    Mail = "knightofthesea@gmail.com",
                    MailType = MailType.Work,
                    SupplierId = 14
                },
                new Email
                {
                    Id = 40,
                    Mail = "vagrantsong@gmail.com",
                    MailType = MailType.Work,
                    SupplierId = 15
                },

            #endregion

            #region Warehouse
                new Email
                {
                    Id = 41,
                    Mail = "warehouseone@gmail.com",
                    MailType = MailType.Work,
                    WarehouseId = 1
                },
                new Email
                {
                    Id = 42,
                    Mail = "warehousetwo@gmail.com",
                    MailType = MailType.Work,
                    WarehouseId = 2
                },
                new Email
                {
                    Id = 43,
                    Mail = "warehousethree@gmail.com",
                    MailType = MailType.Work,
                    WarehouseId = 3
                },
                new Email
                {
                    Id = 44,
                    Mail = "warehousefour@gmail.com",
                    MailType = MailType.Work,
                    WarehouseId = 4
                },

            #endregion

            #region Customers
                new Email
                {
                    Id = 45,
                    Mail = "noescape@gmail.com",
                    MailType = MailType.Personal,
                    CustomerId = 1
                },
                new Email
                {
                    Id = 46,
                    Mail = "houseofhades@gmail.com",
                    MailType = MailType.Personal,
                    CustomerId = 2
                },
                new Email
                {
                    Id = 47,
                    Mail = "outoftartarus@gmail.com",
                    MailType = MailType.Personal,
                    CustomerId = 3
                },
                new Email
                {
                    Id = 48,
                    Mail = "wretchedshades@gmail.com",
                    MailType = MailType.Personal,
                    CustomerId = 4
                },
                new Email
                {
                    Id = 49,
                    Mail = "lamentoforpheus@gmail.com",
                    MailType = MailType.Personal,
                    CustomerId = 5
                },
                new Email
                {
                    Id = 50,
                    Mail = "thepainfulway@gmail.com",
                    MailType = MailType.Personal,
                    CustomerId = 6
                },
                new Email
                {
                    Id = 51,
                    Mail = "fromolympous@gmail.com",
                    MailType = MailType.Personal,
                    CustomerId = 7
                },
                new Email
                {
                    Id = 52,
                    Mail = "throughasphodel@gmail.com",
                    MailType = MailType.Personal,
                    CustomerId = 8
                },
                new Email
                {
                    Id = 53,
                    Mail = "goodridance@gmail.com",
                    MailType = MailType.Personal,
                    CustomerId = 9
                },
                new Email
                {
                    Id = 54,
                    Mail = "finalexpense@gmail.com",
                    MailType = MailType.Personal,
                    CustomerId = 10
                },
                new Email
                {
                    Id = 55,
                    Mail = "mouthofstyx@gmail.com",
                    MailType = MailType.Personal,
                    CustomerId = 11
                },
                new Email
                {
                    Id = 56,
                    Mail = "primorgialchaos@gmail.com",
                    MailType = MailType.Personal,
                    CustomerId = 12
                },


            #endregion

            #region Candidates
                new Email
                {
                    Id = 57,
                    Mail = "oldfriends@gmail.com",
                    MailType = MailType.Personal,
                    CandidateId = 1
                },
                new Email
                {
                    Id = 58,
                    Mail = "stainedglass@gmail.com",
                    MailType = MailType.Personal,
                    CandidateId = 2
                },
                new Email
                {
                    Id = 59,
                    Mail = "forecast@gmail.com",
                    MailType = MailType.Personal,
                    CandidateId = 3
                },
                new Email
                {
                    Id = 60,
                    Mail = "waterwall@gmail.com",
                    MailType = MailType.Personal,
                    CandidateId = 4
                },
                new Email
                {
                    Id = 61,
                    Mail = "thespine@gmail.com",
                    MailType = MailType.Personal,
                    CandidateId = 5
                },
                new Email
                {
                    Id = 62,
                    Mail = "coasting@gmail.com",
                    MailType = MailType.Personal,
                    CandidateId = 6
                },
                new Email
                {
                    Id = 63,
                    Mail = "vanishingpoint@gmail.com",
                    MailType = MailType.Personal,
                    CandidateId = 7
                },
                new Email
                {
                    Id = 64,
                    Mail = "traces@gmail.com",
                    MailType = MailType.Personal,
                    CandidateId = 7
                },
                new Email
                {
                    Id = 65,
                    Mail = "cutapart@gmail.com",
                    MailType = MailType.Personal,
                    CandidateId = 8
                },
                new Email
                {
                    Id = 66,
                    Mail = "incircles@gmail.com",
                    MailType = MailType.Personal,
                    CandidateId = 9
                },
                new Email
                {
                    Id = 67,
                    Mail = "paperboats@gmail.com",
                    MailType = MailType.Personal,
                    CandidateId = 10
                }

            #endregion
                );

            #endregion Emails

            #region Phones

            builder.Entity<Phone>()
                .HasData(

            #region Employees

                new Phone
                {
                    Id = 1,
                    Number = "2109923145",
                    PhoneType = PhoneType.Work,
                    EmployeeId = 1
                },
                new Phone
                {
                    Id = 2,
                    Number = "2109924145",
                    PhoneType = PhoneType.Work,
                    EmployeeId = 2
                },
                new Phone
                {
                    Id = 3,
                    Number = "2109924167",
                    PhoneType = PhoneType.Work,
                    EmployeeId = 3
                },
                new Phone
                {
                    Id = 4,
                    Number = "2109854167",
                    PhoneType = PhoneType.Work,
                    EmployeeId = 4
                },
                new Phone
                {
                    Id = 5,
                    Number = "2109852267",
                    PhoneType = PhoneType.Work,
                    EmployeeId = 5
                },
                new Phone
                {
                    Id = 6,
                    Number = "2109854467",
                    PhoneType = PhoneType.Work,
                    EmployeeId = 6
                },
                new Phone
                {
                    Id = 7,
                    Number = "2109854537",
                    PhoneType = PhoneType.Work,
                    EmployeeId = 7
                },
                new Phone
                {
                    Id = 8,
                    Number = "2109654537",
                    PhoneType = PhoneType.Work,
                    EmployeeId = 8
                },
                new Phone
                {
                    Id = 9,
                    Number = "2109948737",
                    PhoneType = PhoneType.Work,
                    EmployeeId = 9
                },
                new Phone
                {
                    Id = 10,
                    Number = "2109754537",
                    PhoneType = PhoneType.Work,
                    EmployeeId = 10
                },
                new Phone
                {
                    Id = 11,
                    Number = "2109763537",
                    PhoneType = PhoneType.Work,
                    EmployeeId = 11
                },
                new Phone
                {
                    Id = 12,
                    Number = "2109384537",
                    PhoneType = PhoneType.Work,
                    EmployeeId = 12
                },
                new Phone
                {
                    Id = 13,
                    Number = "2119385437",
                    PhoneType = PhoneType.Work,
                    EmployeeId = 13
                },
                new Phone
                {
                    Id = 14,
                    Number = "2109385453",
                    PhoneType = PhoneType.Work,
                    EmployeeId = 14
                },
                new Phone
                {
                    Id = 15,
                    Number = "2109385498",
                    PhoneType = PhoneType.Work,
                    EmployeeId = 15
                },
                new Phone
                {
                    Id = 16,
                    Number = "2109381111",
                    PhoneType = PhoneType.Work,
                    EmployeeId = 16
                },
                new Phone
                {
                    Id = 17,
                    Number = "2109381112",
                    PhoneType = PhoneType.Work,
                    EmployeeId = 17
                },
                new Phone
                {
                    Id = 18,
                    Number = "2109381113",
                    PhoneType = PhoneType.Work,
                    EmployeeId = 18
                },
                new Phone
                {
                    Id = 19,
                    Number = "2109381114",
                    PhoneType = PhoneType.Work,
                    EmployeeId = 19
                },
                new Phone
                {
                    Id = 20,
                    Number = "2109381115",
                    PhoneType = PhoneType.Work,
                    EmployeeId = 20
                },
                new Phone
                {
                    Id = 21,
                    Number = "2109381116",
                    PhoneType = PhoneType.Work,
                    EmployeeId = 21
                },
                new Phone
                {
                    Id = 22,
                    Number = "2109381117",
                    PhoneType = PhoneType.Work,
                    EmployeeId = 22
                },
                new Phone
                {
                    Id = 23,
                    Number = "2109381118",
                    PhoneType = PhoneType.Work,
                    EmployeeId = 23
                },
                new Phone
                {
                    Id = 24,
                    Number = "2109381119",
                    PhoneType = PhoneType.Work,
                    EmployeeId = 24
                },
                new Phone
                {
                    Id = 25,
                    Number = "2109381120",
                    PhoneType = PhoneType.Work,
                    EmployeeId = 25
                },

            #endregion Employees

            #region Suppliers
                new Phone
                {
                    Id = 26,
                    Number = "2109381121",
                    PhoneType = PhoneType.Work,
                    SupplierId = 1
                },
                new Phone
                {
                    Id = 27,
                    Number = "2109381122",
                    PhoneType = PhoneType.Work,
                    SupplierId = 2
                },
                new Phone
                {
                    Id = 28,
                    Number = "2109381123",
                    PhoneType = PhoneType.Work,
                    SupplierId = 3
                },
                new Phone
                {
                    Id = 29,
                    Number = "2109381124",
                    PhoneType = PhoneType.Work,
                    SupplierId = 4
                },
                new Phone
                {
                    Id = 30,
                    Number = "2109381125",
                    PhoneType = PhoneType.Work,
                    SupplierId = 5
                },
                new Phone
                {
                    Id = 31,
                    Number = "2109381126",
                    PhoneType = PhoneType.Work,
                    SupplierId = 6
                },
                new Phone
                {
                    Id = 32,
                    Number = "2109381127",
                    PhoneType = PhoneType.Work,
                    SupplierId = 7
                },
                new Phone
                {
                    Id = 33,
                    Number = "2109381128",
                    PhoneType = PhoneType.Work,
                    SupplierId = 8
                },
                new Phone
                {
                    Id = 34,
                    Number = "2109381129",
                    PhoneType = PhoneType.Work,
                    SupplierId = 9
                },
                new Phone
                {
                    Id = 35,
                    Number = "2109381130",
                    PhoneType = PhoneType.Work,
                    SupplierId = 10
                },
                new Phone
                {
                    Id = 36,
                    Number = "2109381131",
                    PhoneType = PhoneType.Work,
                    SupplierId = 11
                },
                new Phone
                {
                    Id = 37,
                    Number = "2109381132",
                    PhoneType = PhoneType.Work,
                    SupplierId = 12
                },
                new Phone
                {
                    Id = 38,
                    Number = "2109381133",
                    PhoneType = PhoneType.Work,
                    SupplierId = 13
                },
                new Phone
                {
                    Id = 39,
                    Number = "2109381134",
                    PhoneType = PhoneType.Work,
                    SupplierId = 14
                },
                new Phone
                {
                    Id = 40,
                    Number = "2109381135",
                    PhoneType = PhoneType.Work,
                    SupplierId = 15
                },
            #endregion

            #region Warehouses
                new Phone
                {
                    Id = 41,
                    Number = "2109381136",
                    PhoneType = PhoneType.Work,
                    WarehouseId = 1
                },
                new Phone
                {
                    Id = 42,
                    Number = "2109381137",
                    PhoneType = PhoneType.Work,
                    WarehouseId = 2
                },
                new Phone
                {
                    Id = 43,
                    Number = "2109381138",
                    PhoneType = PhoneType.Work,
                    WarehouseId = 3
                },
                new Phone
                {
                    Id = 44,
                    Number = "2109381139",
                    PhoneType = PhoneType.Work,
                    WarehouseId = 4
                },

            #endregion

            #region Customers
                new Phone
                {
                    Id = 45,
                    Number = "2109381140",
                    PhoneType = PhoneType.Personal,
                    CustomerId = 1
                },
                new Phone
                {
                    Id = 46,
                    Number = "2109381141",
                    PhoneType = PhoneType.Personal,
                    CustomerId = 2
                },
                new Phone
                {
                    Id = 47,
                    Number = "2109381142",
                    PhoneType = PhoneType.Personal,
                    CustomerId = 3
                },
                new Phone
                {
                    Id = 48,
                    Number = "2109381143",
                    PhoneType = PhoneType.Personal,
                    CustomerId = 4
                },
                new Phone
                {
                    Id = 49,
                    Number = "2109381144",
                    PhoneType = PhoneType.Personal,
                    CustomerId = 5
                },
                new Phone
                {
                    Id = 50,
                    Number = "2109381145",
                    PhoneType = PhoneType.Personal,
                    CustomerId = 6
                },
                new Phone
                {
                    Id = 51,
                    Number = "2109381146",
                    PhoneType = PhoneType.Personal,
                    CustomerId = 7
                },
                new Phone
                {
                    Id = 52,
                    Number = "2109381147",
                    PhoneType = PhoneType.Personal,
                    CustomerId = 8
                },
                new Phone
                {
                    Id = 53,
                    Number = "2109381148",
                    PhoneType = PhoneType.Personal,
                    CustomerId = 9
                },
                new Phone
                {
                    Id = 54,
                    Number = "2109381149",
                    PhoneType = PhoneType.Personal,
                    CustomerId = 10
                },
                new Phone
                {
                    Id = 55,
                    Number = "2109381150",
                    PhoneType = PhoneType.Personal,
                    CustomerId = 11
                },
                new Phone
                {
                    Id = 56,
                    Number = "2109381151",
                    PhoneType = PhoneType.Personal,
                    CustomerId = 12
                },

            #endregion

            #region Candidates
                new Phone
                {
                    Id = 57,
                    Number = "2109381152",
                    PhoneType = PhoneType.Personal,
                    CandidateId = 1
                },
                new Phone
                {
                    Id = 58,
                    Number = "2109381153",
                    PhoneType = PhoneType.Personal,
                    CandidateId = 2
                },
                new Phone
                {
                    Id = 59,
                    Number = "2109381154",
                    PhoneType = PhoneType.Personal,
                    CandidateId = 3
                },
                new Phone
                {
                    Id = 60,
                    Number = "2109381155",
                    PhoneType = PhoneType.Personal,
                    CandidateId = 4
                },
                new Phone
                {
                    Id = 61,
                    Number = "2109381156",
                    PhoneType = PhoneType.Personal,
                    CandidateId = 5
                },
                new Phone
                {
                    Id = 62,
                    Number = "2109381157",
                    PhoneType = PhoneType.Personal,
                    CandidateId = 6
                },
                new Phone
                {
                    Id = 63,
                    Number = "2109381158",
                    PhoneType = PhoneType.Personal,
                    CandidateId = 7
                },
                new Phone
                {
                    Id = 64,
                    Number = "2109381159",
                    PhoneType = PhoneType.Personal,
                    CandidateId = 8
                },
                new Phone
                {
                    Id = 65,
                    Number = "2109381160",
                    PhoneType = PhoneType.Personal,
                    CandidateId = 9
                },
                new Phone
                {
                    Id = 66,
                    Number = "2109381161",
                    PhoneType = PhoneType.Personal,
                    CandidateId = 10
                }

                #endregion
                );

            #endregion Phones

            #region RawMaterials

            builder.Entity<RawMaterial>()
                .HasData(
                new RawMaterial
                {
                    Id = 1,
                    Name = "Dark Chocolate",
                    Price = 2.45
                },
                new RawMaterial
                {
                    Id = 2,
                    Name = "White Chocolate",
                    Price = 2.35
                },
                new RawMaterial
                {
                    Id = 3,
                    Name = "Milk Chocolate",
                    Price = 3.15
                },
                new RawMaterial
                {
                    Id = 4,
                    Name = "Waffer",
                    Price = 4.50f
                },
                new RawMaterial
                {
                    Id = 5,
                    Name = "CoffeSyrup",
                    Price = 3.50f
                },
                new RawMaterial
                {
                     Id = 6,
                     Name = "Golden Retriever Chocolate",
                     Price = 2.5f
                },
                new RawMaterial
                {
                     Id = 7,
                     Name = "Cocoa Chocolate",
                     Price = 2.5f
                },
                new RawMaterial
                {
                    Id = 8,
                    Name = "Cocoa Power",
                    Price = 2.5f
                },
                new RawMaterial
                {
                    Id = 9,
                    Name = "Bittersweet Chocolate",
                    Price = 2.35
                },
                new RawMaterial
                {
                    Id = 10,
                    Name = "Baking Chocolate",
                    Price = 3.15
                },
                new RawMaterial
                {
                    Id = 11,
                    Name = "Semisweet Chocolate",
                    Price = 4.50f
                },
                new RawMaterial
                {
                    Id = 12,
                    Name = "Sweet German Chocolate",
                    Price = 3.50f
                },
                new RawMaterial
                {
                    Id = 13,
                    Name = "Couverture Chocolate",
                    Price = 2.5f
                },
                new RawMaterial
                {
                     Id = 14,
                     Name = "Ruby",
                     Price = 4.50f
                },
                new RawMaterial
                {
                    Id = 15,
                    Name = "Raw Chocolate",
                    Price = 3.50f
                },
                new RawMaterial
                {
                    Id = 16,
                    Name = "Almond Chocolate",
                    Price = 2.5f
                },
                new RawMaterial
                {
                    Id = 17,
                    Name = "Goji Berries Chocolate",
                    Price = 3.15
                },
                new RawMaterial
                {
                    Id = 18,
                    Name = "Crumbe Chocolate",
                    Price = 2.5f
                },
                new RawMaterial
                {
                    Id = 19,
                    Name = "Vegan Chocolate",
                    Price = 2.5f
                },
                new RawMaterial
                {
                     Id = 20,
                     Name = "Almond Milk Chocolate",
                     Price = 2.35
                }

                );

            #endregion RawMaterials

            #region RawMaterialSupplier

            builder.Entity<RawMaterialSupplier>()
                .HasData
                (
                    new RawMaterialSupplier
                    {
                        RawMaterialId = 1,
                        SupplierId = 1
                    },
                    new RawMaterialSupplier
                    {
                        RawMaterialId = 3,
                        SupplierId = 1
                    },
                    new RawMaterialSupplier
                    {
                        RawMaterialId = 2,
                        SupplierId = 2
                    },
                    new RawMaterialSupplier
                    {
                        RawMaterialId = 6,
                        SupplierId = 2
                    },
                    new RawMaterialSupplier
                    {
                        RawMaterialId = 1,
                        SupplierId = 3
                    },
                    new RawMaterialSupplier
                    {
                        RawMaterialId = 3,
                        SupplierId = 3
                    },
                    new RawMaterialSupplier
                    {
                        RawMaterialId = 4,
                        SupplierId = 3
                    },
                    new RawMaterialSupplier
                    {
                        RawMaterialId = 1,
                        SupplierId = 4
                    },
                    new RawMaterialSupplier
                    {
                        RawMaterialId = 4,
                        SupplierId = 4
                    },
                    new RawMaterialSupplier
                    {
                        RawMaterialId = 1,
                        SupplierId = 5
                    },
                    new RawMaterialSupplier
                    {
                        RawMaterialId = 2,
                        SupplierId = 5
                    },
                    new RawMaterialSupplier
                    {
                        RawMaterialId = 1,
                        SupplierId = 6
                    },
                    new RawMaterialSupplier
                    {
                        RawMaterialId = 2,
                        SupplierId = 6
                    },
                    new RawMaterialSupplier
                    {
                        RawMaterialId = 5,
                        SupplierId = 6
                    },
                    new RawMaterialSupplier
                    {
                        RawMaterialId = 1,
                        SupplierId = 7
                    },
                    new RawMaterialSupplier
                    {
                        RawMaterialId = 5,
                        SupplierId = 7
                    },
                    new RawMaterialSupplier
                    {
                        RawMaterialId = 6,
                        SupplierId = 7
                    }
                );

            #endregion RawMaterialSupplier

            #region Discounts

            builder.Entity<Discount>()
                .HasData
                (
                    new Discount
                    {
                        Id = 1,
                        EndDate = DateTime.Parse("2021/12/31"),
                        SupplierId = 1
                    },
                    new Discount
                    {
                        Id = 2,
                        EndDate = DateTime.Parse("2021/06/30"),
                        SupplierId = 2
                    },
                    new Discount
                    {
                        Id = 3,
                        EndDate = DateTime.Parse("2021/07/30"),
                        SupplierId = 3
                    },
                    new Discount
                    {
                        Id = 4,
                        EndDate = DateTime.Parse("2022/5/30"),
                        SupplierId = 4
                    },
                    new Discount
                    {
                        Id = 5,
                        EndDate = DateTime.Parse("2021/12/31"),
                        SupplierId = 5
                    },
                    new Discount
                    {
                        Id = 6,
                        EndDate = DateTime.Parse("2021/05/30"),
                        SupplierId = 6
                    },
                    new Discount
                    {
                        Id = 7,
                        EndDate = DateTime.Parse("2021/08/30"),
                        SupplierId = 7,
                    }
                );

            #endregion Discounts

            #region Discount Levels

            builder.Entity<DiscountLevel>()
                .HasData
                (
                    new DiscountLevel
                    {
                        Id = 1,
                        Amount = 1000,
                        DiscountPercentage = 0.02,
                        DiscountId = 1
                    },
                    new DiscountLevel
                    {
                        Id = 2,
                        Amount = 3000,
                        DiscountPercentage = 0.05,
                        DiscountId = 1
                    },
                    new DiscountLevel
                    {
                        Id = 3,
                        Amount = 3000,
                        DiscountPercentage = 0.35,
                        DiscountId = 2
                    },
                    new DiscountLevel
                    {
                        Id = 4,
                        Amount = 7000,
                        DiscountPercentage = 0.06,
                        DiscountId = 2
                    },
                    new DiscountLevel
                    {
                        Id = 5,
                        Amount = 1500,
                        DiscountPercentage = 0.02,
                        DiscountId = 3
                    },
                    new DiscountLevel
                    {
                        Id = 6,
                        Amount = 3000,
                        DiscountPercentage = 0.05,
                        DiscountId = 3
                    },
                    new DiscountLevel
                    {
                        Id = 7,
                        Amount = 2000,
                        DiscountPercentage = 0.05,
                        DiscountId = 4
                    },
                    new DiscountLevel
                    {
                        Id = 8,
                        Amount = 3000,
                        DiscountPercentage = 0.06,
                        DiscountId = 4
                    },
                    new DiscountLevel
                    {
                        Id = 9,
                        Amount = 12000,
                        DiscountPercentage = 0.035,
                        DiscountId = 5
                    },
                    new DiscountLevel
                    {
                        Id = 10,
                        Amount = 20000,
                        DiscountPercentage = 0.07,
                        DiscountId = 5
                    },
                    new DiscountLevel
                    {
                        Id = 11,
                        Amount = 1000,
                        DiscountPercentage = 0.02,
                        DiscountId = 6
                    },
                    new DiscountLevel
                    {
                        Id = 12,
                        Amount = 5000,
                        DiscountPercentage = 0.08,
                        DiscountId = 6
                    },
                    new DiscountLevel
                    {
                        Id = 13,
                        Amount = 4000,
                        DiscountPercentage = 0.05,
                        DiscountId = 7
                    },
                    new DiscountLevel
                    {
                        Id = 14,
                        Amount = 10000,
                        DiscountPercentage = 0.09,
                        DiscountId = 7
                    }
                );

            #endregion Discount Levels

            #region Offers

            builder.Entity<Offer>()
                .HasData
                (
                    new Offer
                    {
                        Id = 1,
                        Name = "Offer 1",
                        DateCreated = DateTime.Parse("2021/02/20"),
                        EmployeeId = 1,
                        SupplierId = 1,
                        ReviewDeadline = DateTime.Parse("2021/03/15"),
                        DiscountLevelId = 1
                    },
                    new Offer
                    {
                        Id = 2,
                        Name = "Offer 2",
                        DateCreated = DateTime.Parse("2021/02/20"),
                        EmployeeId = 1,
                        SupplierId = 2,
                        ReviewDeadline = DateTime.Parse("2021/03/15"),
                        DiscountLevelId = 3
                    },
                    new Offer
                    {
                        Id = 3,
                        Name = "Offer 3",
                        DateCreated = DateTime.Parse("2021/02/20"),
                        EmployeeId = 1,
                        SupplierId = 3,
                        ReviewDeadline = DateTime.Parse("2021/03/15"),
                        DiscountLevelId = 5
                    },
                    new Offer
                    {
                        Id = 4,
                        Name = "Offer 4",
                        DateCreated = DateTime.Parse("2021/02/20"),
                        EmployeeId = 1,
                        SupplierId = 4,
                        ReviewDeadline = DateTime.Parse("2021/03/15"),
                        DiscountLevelId = 7
                    },
                    new Offer
                    {
                        Id = 5,
                        Name = "Offer 5",
                        DateCreated = DateTime.Parse("2021/02/20"),
                        EmployeeId = 1,
                        SupplierId = 5,
                        ReviewDeadline = DateTime.Parse("2021/03/15"),
                        DiscountLevelId = 9
                    },
                    new Offer
                    {
                        Id = 6,
                        Name = "Offer 6",
                        DateCreated = DateTime.Parse("2021/02/20"),
                        EmployeeId = 1,
                        SupplierId = 6,
                        ReviewDeadline = DateTime.Parse("2021/03/15"),
                        DiscountLevelId = 11
                    },
                    new Offer
                    {
                        Id = 7,
                        Name = "Offer 7",
                        DateCreated = DateTime.Parse("2021/02/20"),
                        EmployeeId = 1,
                        SupplierId = 7,
                        ReviewDeadline = DateTime.Parse("2021/03/15"),
                        DiscountLevelId = 13
                    },
                    new Offer
                    {
                        Id = 8,
                        Name = "Offer 8",
                        DateCreated = DateTime.Parse("2020/12/31"),
                        ReviewDeadline = DateTime.Parse("2021/01/31"),
                        DateReviewed = DateTime.Parse("2021/01/15"),
                        DiscountLevelId = 1,
                        EmployeeId = 3,
                        SupplierId = 1
                    },
                    new Offer
                    {
                        Id = 9,
                        Name = "Offer 9",
                        DateCreated = DateTime.Parse("2020/12/5"),
                        ReviewDeadline = DateTime.Parse("2021/01/05"),
                        DateReviewed = DateTime.Parse("2021/01/03"),
                        SupplierId = 2,
                        DiscountLevelId = 3,
                        EmployeeId = 3
                    }
                );

            #endregion Offers

            #region OfferItems

            builder.Entity<OfferItem>()
                .HasData
                (
                    new OfferItem
                    {
                        Id = 1,
                        OfferId = 1,
                        Quantity = 150,
                        RawMaterialId = 1
                    },
                    new OfferItem
                    {
                        Id = 2,
                        OfferId = 1,
                        Quantity = 110,
                        RawMaterialId = 3
                    },
                    new OfferItem
                    {
                        Id = 3,
                        OfferId = 2,
                        Quantity = 100,
                        RawMaterialId = 2
                    },
                    new OfferItem
                    {
                        Id = 4,
                        OfferId = 2,
                        Quantity = 234,
                        RawMaterialId = 6
                    },
                    new OfferItem
                    {
                        Id = 5,
                        OfferId = 3,
                        Quantity = 322,
                        RawMaterialId = 1
                    },
                    new OfferItem
                    {
                        Id = 6,
                        OfferId = 3,
                        Quantity = 420,
                        RawMaterialId = 3
                    },
                    new OfferItem
                    {
                        Id = 7,
                        OfferId = 4,
                        Quantity = 200,
                        RawMaterialId = 1
                    },
                    new OfferItem
                    {
                        Id = 8,
                        OfferId = 4,
                        Quantity = 100,
                        RawMaterialId = 4
                    },
                    new OfferItem
                    {
                        Id = 9,
                        OfferId = 5,
                        Quantity = 340,
                        RawMaterialId = 1
                    },
                    new OfferItem
                    {
                        Id = 10,
                        OfferId = 5,
                        Quantity = 500,
                        RawMaterialId = 2
                    },
                    new OfferItem
                    {
                        Id = 11,
                        OfferId = 6,
                        Quantity = 390,
                        RawMaterialId = 1
                    },
                    new OfferItem
                    {
                        Id = 12,
                        OfferId = 6,
                        Quantity = 1000,
                        RawMaterialId = 2
                    },
                    new OfferItem
                    {
                        Id = 13,
                        OfferId = 6,
                        Quantity = 2000,
                        RawMaterialId = 5
                    },
                    new OfferItem
                    {
                        Id = 14,
                        OfferId = 7,
                        Quantity = 2800,
                        RawMaterialId = 1
                    },
                    new OfferItem
                    {
                        Id = 15,
                        OfferId = 7,
                        Quantity = 1000,
                        RawMaterialId = 5
                    },
                    new OfferItem
                    {
                        Id = 16,
                        OfferId = 7,
                        Quantity = 100,
                        RawMaterialId = 6
                    },
                    new OfferItem
                    {
                        Id = 17,
                        OfferId = 8,
                        Quantity = 100,
                        RawMaterialId = 1
                    },
                    new OfferItem
                    {
                        Id = 18,
                        OfferId = 9,
                        Quantity = 200,
                        RawMaterialId = 6
                    }
                );

            #endregion OfferItems

            #region Purchases

            builder.Entity<Purchase>()
                .HasData
                (
                    new Purchase
                    {
                        Id = 1,
                        OfferId = 8,
                        DateReceived = DateTime.Parse("2021/01/17")
                    },
                    new Purchase
                    {
                        Id = 2,
                        OfferId = 9,
                        DateReceived = DateTime.Parse("2021/01/10")
                    },
                    new Purchase
                    {
                        Id = 3,
                        OfferId = 7,
                        DateReceived = DateTime.Parse("2021/02/12")
                    },
                    new Purchase
                    {
                        Id = 4,
                        OfferId = 6,
                        DateReceived = DateTime.Parse("2020/12/23")
                    },
                    new Purchase
                    {
                        Id = 5,
                        OfferId = 5,
                        DateReceived = DateTime.Parse("2020/12/23")
                    },
                    new Purchase
                    {
                        Id = 6,
                        OfferId = 4,
                        DateReceived = DateTime.Parse("2021/3/23")
                    },
                    new Purchase
                    {
                        Id = 7,
                        OfferId = 3,
                        DateReceived = DateTime.Parse("2021/4/01")
                    }

                );

            #endregion Purchases

            #region Products

            builder.Entity<Product>()
            .HasData(
                new Product
                {
                    Id = 1,
                    Name = "Darky",
                    Price = 7.50,
                    Barcode = "2000012334054567",
                    Description = "Clean cut black chocolate bar",
                    IsDeleted = false,
                    Category = ProductCategory.Bars,
                    Weight = 0.1
                },
                new Product
                {
                    Id = 2,
                    Name = "Whitey",
                    Price = 7.50,
                    Barcode = "2000012334154568",
                    Description = "Clean cut white chocolate bar",
                    IsDeleted = false,
                    Category = ProductCategory.Bars,
                    Weight = 0.1
                },
                new Product
                {
                    Id = 3,
                    Name = "Mix-DaChoc",
                    Price = 10.50,
                    Barcode = "2000012332454569",
                    Description = "Clean cut mix chocolate bar",
                    IsDeleted = false,
                    Category = ProductCategory.Bars,
                    Weight = 0.1
                },
                new Product
                {
                    Id = 4,
                    Name = "Classy",
                    Price = 12.50,
                    Barcode = "2000013233454570",
                    Description = "The better type of bites",
                    IsDeleted = false,
                    Category = ProductCategory.Bites,
                    Weight = 0.3
                },
                new Product
                {
                    Id = 5,
                    Name = "ChocoMist",
                    Price = 7.50,
                    Barcode = "2000012343454571",
                    Description = "Super Wafer",
                    IsDeleted = false,
                    Category = ProductCategory.Wafers,
                    Weight = 0.15
                },
                new Product
                {
                    Id = 6,
                    Name = "CoffeeFountain",
                    Price = 12.50,
                    Barcode = "2000015233454572",
                    Description = "The Bites you didn't know you wanted!",
                    IsDeleted = false,
                    Category = ProductCategory.Bites,
                    Weight = 0.3
                },
                 new Product
                 {
                     Id = 7,
                     Name = "Mystic Flavour",
                     Price = 13.50,
                     Barcode = "2000012334654573",
                     Description = "Oh that smell!",
                     IsDeleted = false,
                     Category = ProductCategory.Bites,
                     Weight = 0.3
                 },
                new Product
                {
                    Id = 8,
                    Name = "Dark Hell",
                    Price = 12.50,
                    Barcode = "2000012334547582",
                    Description = "So dark and sweet",
                    IsDeleted = false,
                    Category = ProductCategory.Bars,
                    Weight = 0.25
                },
                new Product
                {
                    Id = 9,
                    Name = "White Heaven",
                    Price = 12.50,
                    Barcode = "2000012833454581",
                    Description = "So white and sweet",
                    IsDeleted = false,
                    Category = ProductCategory.Bars,
                    Weight = 0.25
                },
                new Product
                {
                    Id = 10,
                    Name = "Milky Way",
                    Price = 10.50,
                    Barcode = "2000012334954678",
                    Description = "Eat it drink it",
                    IsDeleted = false,
                    Category = ProductCategory.Wafers,
                    Weight = 0.25
                },
                new Product
                {
                    Id = 11,
                    Name = "Waffer Flavour",
                    Price = 10.50,
                    Barcode = "2001001233454623",
                    Description = "The taste you wanted",
                    IsDeleted = false,
                    Category = ProductCategory.Bars,
                    Weight = 0.30
                },
                new Product
                {
                    Id = 12,
                    Name = "Coffee Choco",
                    Price = 9.50,
                    Barcode = "2000012233454690",
                    Description = "Only for coffee addicts!",
                    IsDeleted = false,
                    Category = ProductCategory.Wafers,
                    Weight = 0.30
                },
                new Product
                {
                    Id = 13,
                    Name = "Golden Choice",
                    Price = 13.50,
                    Barcode = "2000031233454671",
                    Description = "Golden Retriver Chocolate",
                    IsDeleted = false,
                    Category = ProductCategory.Wafers,
                    Weight = 0.25
                },
                new Product
                {
                    Id = 14,
                    Name = "Bittersweet Love",
                    Price = 9.50,
                    Barcode = "2000401233454662",
                    Description = "Bittersweet love for all",
                    IsDeleted = false,
                    Category = ProductCategory.Bars,
                    Weight = 0.3
                },
                new Product
                {
                    Id = 15,
                    Name = "Crazy Choco Loco",
                    Price = 8.50,
                    Barcode = "2005001233454673",
                    Description = "You drive me crazy",
                    IsDeleted = false,
                    Category = ProductCategory.Bars,
                    Weight = 0.2
                },
                new Product
                {
                    Id = 16,
                    Name = "Sweet Choco of Mine",
                    Price = 9.50,
                    Barcode = "2000601233454674",
                    Description = "Sugar sugar honey honey",
                    IsDeleted = false,
                    Category = ProductCategory.Bites,
                    Weight = 0.3
                },
                new Product
                {
                    Id = 17,
                    Name = "Semisweet Lozan",
                    Price = 2.50,
                    Barcode = "2007001233454675",
                    Description = "The best taste",
                    IsDeleted = false,
                    Category = ProductCategory.Wafers,
                    Weight = 0.5
                },
                new Product
                {
                    Id = 18,
                    Name = "Arabella",
                    Price = 6.50,
                    Barcode = "200081233454655",
                    Description = "Sweet Arctic Choco",
                    IsDeleted = false,
                    Category = ProductCategory.Bars,
                    Weight = 0.5
                },
                new Product
                {
                    Id = 19,
                    Name = "Couverture",
                    Price = 2.50,
                    Barcode = "2000091233454690",
                    Description = "Couverture Chocolate",
                    IsDeleted = false,
                    Category = ProductCategory.Bars,
                    Weight = 0.3
                },
                new Product
                {
                    Id = 20,
                    Name = "Ruby Lozan",
                    Price = 10.50,
                    Barcode = "20000123103454610",
                    Description = "Ruby Ruby Ruby",
                    IsDeleted = false,
                    Category = ProductCategory.Bites,
                    Weight = 0.30
                },
                new Product
                {
                    Id = 21,
                    Name = "Raw",
                    Price = 8.50,
                    Barcode = "2000101233454612",
                    Description = "Snap out of it",
                    IsDeleted = false,
                    Category = ProductCategory.Wafers,
                    Weight = 0.5
                },
                new Product
                {
                    Id = 22,
                    Name = "Almond Flavour",
                    Price = 9.50,
                    Barcode = "2000021233454698",
                    Description = "Put an almold on me",
                    IsDeleted = false,
                    Category = ProductCategory.Bites,
                    Weight = 0.9
                },
                new Product
                {
                    Id = 23,
                    Name = "Goji Berrie",
                    Price = 10.50,
                    Barcode = "2003001233454612",
                    Description = "One for the road",
                    IsDeleted = false,
                    Category = ProductCategory.Wafers,
                    Weight = 0.4
                },
                new Product
                {
                    Id = 24,
                    Name = "Crumble Truble",
                    Price = 9.50,
                    Barcode = "2000014233454613",
                    Description = "The truble tou want",
                    IsDeleted = false,
                    Category = ProductCategory.Bars,
                    Weight = 0.2
                },
                new Product
                {
                    Id = 25,
                    Name = "Vegan",
                    Price = 3.50,
                    Barcode = "2000012335454656",
                    Description = "For vegan lovers",
                    IsDeleted = false,
                    Category = ProductCategory.Bites,
                    Weight = 0.3
                },
                new Product
                {
                    Id = 26,
                    Name = "Almond Milky",
                    Price = 9.50,
                    Barcode = "2000012363454689",
                    Description = "Old fashion choco",
                    IsDeleted = false,
                    Category = ProductCategory.Wafers,
                    Weight = 0.10
                },
                new Product
                {
                    Id = 27,
                    Name = "Banana Dark",
                    Price = 10.50,
                    Barcode = "2000012337454681",
                    Description = "The banana lovers",
                    IsDeleted = false,
                    Category = ProductCategory.Bars,
                    Weight = 0.8
                },
                new Product
                {
                     Id = 28,
                     Name = "White Love",
                     Price = 2.50,
                     Barcode = "2000012383454628",
                     Description = "Im in love with choco",
                     IsDeleted = false,
                     Category = ProductCategory.Bites,
                     Weight = 0.10
                },
                new Product
                {
                     Id = 29,
                     Name = "Mystic Choco",
                     Price = 3.50,
                     Barcode = "2000012933454621",
                     Description = "I wanna get off with mystic choco",
                     IsDeleted = false,
                     Category = ProductCategory.Wafers,
                     Weight = 0.9
                },
                new Product
                {
                    Id = 30,
                    Name = "Sweet sweet",
                    Price = 4.50,
                    Barcode = "2000011233454629",
                    Description = "Four out of Five",
                    IsDeleted = false,
                    Category = ProductCategory.Bites,
                    Weight = 0.8
                },
                new Product
                {
                     Id = 31,
                     Name = "Dark Almond",
                     Price = 6.50,
                     Barcode = "2000011233454620",
                     Description = "Easy Choice",
                     IsDeleted = false,
                     Category = ProductCategory.Wafers,
                     Weight = 0.7
                },
                new Product
                {
                    Id = 32,
                    Name = "Vegan Almond",
                    Price = 5.50,
                    Barcode = "2000021233454621",
                    Description = "The choice you wanted",
                    IsDeleted = false,
                    Category = ProductCategory.Bars,
                    Weight = 0.1
                },
                new Product
                {
                    Id = 33,
                    Name = "Milky Away",
                    Price = 9.50,
                    Barcode = "2000031233454645",
                    Description = "The best way",
                    IsDeleted = false,
                    Category = ProductCategory.Bites,
                    Weight = 0.2
                },
                new Product
                {
                    Id = 34,
                    Name = "Darky Way",
                    Price = 3.50,
                    Barcode = "2000041233454646",
                    Description = "Stairway to heaven",
                    IsDeleted = false,
                    Category = ProductCategory.Wafers,
                    Weight = 0.3
                },
                new Product
                {
                     Id = 35,
                     Name = "Spooky Bite",
                     Price = 6.50,
                     Barcode = "2000051233454640",
                     Description = "The bite that hurts",
                     IsDeleted = false,
                     Category = ProductCategory.Bars,
                     Weight = 0.4
                },
                new Product
                {
                     Id = 36,
                     Name = "Waffer",
                     Price = 9.50,
                     Barcode = "2000016233454645",
                     Description = "The one that never ends",
                     IsDeleted = false,
                     Category = ProductCategory.Bites,
                     Weight = 0.5
                },
                new Product
                {
                    Id = 37,
                    Name = "Brown Monkey",
                    Price = 10.50,
                    Barcode = "2000012373454667",
                    Description = "I bet you look good",
                    IsDeleted = false,
                    Category = ProductCategory.Wafers,
                    Weight = 0.6
                },
                new Product
                {
                    Id = 38,
                    Name = "Honey Honey",
                    Price = 2.50,
                    Barcode = "2000018233454661",
                    Description = "Sugar sugar, forever sugar",
                    IsDeleted = false,
                    Category = ProductCategory.Bars,
                    Weight = 0.7
                },
                new Product
                {
                    Id = 39,
                    Name = "Adorable",
                    Price = 5.50,
                    Barcode = "2000012933454634",
                    Description = "The morning choice",
                    IsDeleted = false,
                    Category = ProductCategory.Bites,
                    Weight = 0.8
                },
                new Product
                {
                     Id = 40,
                     Name = "CoffeScript",
                     Price = 2.50,
                     Barcode = "2000011233454635",
                     Description = "Best choice for developers",
                     IsDeleted = false,
                     Category = ProductCategory.Wafers,
                     Weight = 0.3
                },
                new Product
                {
                     Id = 41,
                     Name = "Balaclava",
                     Price = 1.50,
                     Barcode = "2000021233454696",
                     Description = "B is for best",
                     IsDeleted = false,
                     Category = ProductCategory.Bars,
                     Weight = 0.1
                },
                new Product
                {
                     Id = 42,
                     Name = "Cocoa Power",
                     Price = 3.50,
                     Barcode = "2000031233454691",
                     Description = "100% Cocoa",
                     IsDeleted = false,
                     Category = ProductCategory.Bites,
                     Weight = 0.2
                },
                new Product
                {
                     Id = 43,
                     Name = "Bittersweet Symphony",
                     Price = 4.50,
                     Barcode = "2000041233454678",
                     Description = "To tasty to love it",
                     IsDeleted = false,
                     Category = ProductCategory.Wafers,
                     Weight = 0.3
                },
                new Product
                {
                     Id = 44,
                     Name = "White Stripe",
                     Price = 5.50,
                     Barcode = "2000051233454679",
                     Description = "The one you want share",
                     IsDeleted = false,
                     Category = ProductCategory.Bars,
                     Weight = 0.4
                },
                new Product
                {
                     Id = 45,
                     Name = "Black Solo",
                     Price = 5.50,
                     Barcode = "2000016233454541",
                     Description = "Once you go black,you never go back",
                     IsDeleted = false,
                     Category = ProductCategory.Bites,
                     Weight = 0.10
                },
                new Product
                {
                     Id = 46,
                     Name = "Gold Gold Gold",
                     Price = 12.50,
                     Barcode = "2000017233454551",
                     Description = "Gold on the chocolate",
                     IsDeleted = false,
                     Category = ProductCategory.Wafers,
                     Weight = 0.12
                },
                new Product
                {
                     Id = 47,
                     Name = "Weight of Love",
                     Price = 11.50,
                     Barcode = "2000012833454573",
                     Description = "The strong one",
                     IsDeleted = false,
                     Category = ProductCategory.Bars,
                     Weight = 0.13
                },
                new Product
                {
                    Id = 48,
                    Name = "El Camino",
                    Price = 12.50,
                    Barcode = "2000012334954561",
                    Description = "Psychotic taste",
                    IsDeleted = false,
                    Category = ProductCategory.Bites,
                    Weight = 0.2
                },
                new Product
                {
                    Id = 49,
                    Name = "Bellisimo",
                    Price = 2.50,
                    Barcode = "2000012334541543",
                    Description = "If you want to lost your mind.Try it!",
                    IsDeleted = false,
                    Category = ProductCategory.Wafers,
                    Weight = 0.3
                },
                new Product
                {
                    Id = 50,
                    Name = "Pitsi Go",
                    Price = 8.50,
                    Barcode = "2000021233454666",
                    Description = "Chocolate issues",
                    IsDeleted = false,
                    Category = ProductCategory.Bars,
                    Weight = 0.5
                }
                );

            #endregion Products

            #region StorageUnits

            builder.Entity<StorageUnit>()
                .HasData(
                new StorageUnit
                {
                    Id = 1,
                    Name = "S1",
                    WarehouseId = 1
                },
                new StorageUnit
                {   
                    Id = 2,
                    Name = "S2",
                    WarehouseId = 1
                },
                new StorageUnit
                {   
                    Id = 3,
                    Name = "S3",
                    WarehouseId = 2
                },
                new StorageUnit
                {   
                    Id = 4,
                    Name = "S4",
                    WarehouseId = 3
                },
                new StorageUnit
                {   
                     Id = 5,
                     Name = "S5",
                     WarehouseId = 4
                },
                new StorageUnit
                {   
                     Id = 6,
                     Name = "S6",
                     WarehouseId = 1
                },
                new StorageUnit
                {   
                    Id = 7,
                    Name = "S7",
                    WarehouseId = 2
                },
                new StorageUnit
                {   
                    Id = 8,
                    Name = "S8",
                    WarehouseId = 3
                },
                new StorageUnit
                {   
                    Id = 9,
                    Name = "S9",
                    WarehouseId = 4
                },
                new StorageUnit
                {   
                    Id = 10,
                    Name = "S10",
                    WarehouseId = 1
                }
                );

            #endregion StorageUnits

            #region Warehouses

            builder.Entity<Warehouse>()
                .HasData(
                new Warehouse
                {   
                    Id = 1,
                    Name = "Athens Warehouse"
                },
                new Warehouse
                {
                    Id = 2,
                    Name = "Vienna Warehouse"
                },
                new Warehouse
                {
                     Id = 3,
                     Name = "Reykjavik Warehouse"
                },
                new Warehouse
                {
                     Id = 4,
                     Name = "Amsterdam Warehouse"
                }
                );

            #endregion Warehouses

            #region Sectors

            builder.Entity<Sector>()
                .HasData(
                new Sector
                {
                    Id = 1,
                    Name = "Sector 1",
                    StorageUnitId = 1
                },
                new Sector
                {
                    Id = 2,
                    Name = "Sector 2",
                    StorageUnitId = 2
                },
                new Sector
                {
                    Id = 3,
                    Name = "Sector 3",
                    StorageUnitId = 3
                },
                new Sector
                {
                    Id = 4,
                    Name = "Sector 4",
                    StorageUnitId = 4
                },
                new Sector
                {
                    Id = 5,
                    Name = "Sector 5",
                    StorageUnitId = 5
                },
                new Sector
                {
                    Id = 6,
                    Name = "Sector 6",
                    StorageUnitId = 6
                },
                new Sector
                {
                    Id = 7,
                    Name = "Sector 7",
                    StorageUnitId = 7
                },
                new Sector
                {
                    Id = 8,
                    Name = "Sector 8",
                    StorageUnitId = 8
                },
                new Sector
                {
                     Id = 9,
                     Name = "Sector 9",
                     StorageUnitId = 9
                },
                new Sector
                {
                    Id = 10,
                    Name = "Sector 10",
                    StorageUnitId = 10
                }
                );

            #endregion Sectors

            #region Shelves

            builder.Entity<Shelf>()
                .HasData(
                new Shelf
                {
                    Id = 1,
                    Name = "Shelf 1",
                    SectorId = 1
                },
                new Shelf
                {
                    Id = 2,
                    Name = "Shelf 2",
                    SectorId = 2
                },
                new Shelf
                {
                    Id = 3,
                    Name = "Shelf 3",
                    SectorId = 3
                },
                new Shelf
                {
                    Id = 4,
                    Name = "Shelf 4",
                    SectorId = 2
                },
                new Shelf
                {
                    Id = 5,
                    Name = "Shelf 5",
                    SectorId = 3
                }, 
                new Shelf
                {
                    Id = 6,
                    Name = "Shelf 6",
                    SectorId = 3
                },
                new Shelf
                {
                    Id = 7,
                    Name = "Shelf 7",
                    SectorId = 4
                }, 
                new Shelf
                {
                    Id = 8,
                    Name = "Shelf 8",
                    SectorId = 4
                },
                new Shelf
                {
                    Id = 9,
                    Name = "Shelf 9",
                    SectorId = 5
                },
                new Shelf
                {
                    Id = 10,
                    Name = "Shelf 10",
                    SectorId = 5
                },
                new Shelf
                {
                    Id = 11,
                    Name = "Shelf 11",
                    SectorId = 6
                },
                new Shelf
                {
                    Id = 12,
                    Name = "Shelf 12",
                    SectorId = 6
                },
                new Shelf
                {
                    Id = 13,
                    Name = "Shelf 13",
                    SectorId = 7
                },
                new Shelf
                {
                    Id = 14,
                    Name = "Shelf 14",
                    SectorId = 7
                },
                new Shelf
                {
                    Id = 15,
                    Name = "Shelf 15",
                    SectorId = 8
                },
                new Shelf
                {
                    Id = 16,
                    Name = "Shelf 16",
                    SectorId = 8
                },
                new Shelf
                {
                    Id = 17,
                    Name = "Shelf 17",
                    SectorId = 9
                },
                new Shelf
                {
                    Id = 18,
                    Name = "Shelf 18",
                    SectorId = 9
                },
                new Shelf
                {
                    Id = 19,
                    Name = "Shelf 19",
                    SectorId = 10
                },
                new Shelf
                {
                    Id = 20,
                    Name = "Shelf 20",
                    SectorId = 10
                }
                );

            #endregion Shelves

            #region Departments

            builder.Entity<Department>()
                .HasData
                (
                    new Department
                    {
                        Id = 1,
                        Name = "Human Resources"
                    },
                    new Department
                    {
                        Id = 2,
                        Name = "Procurement"
                    },
                    new Department
                    {
                        Id = 3,
                        Name = "Sales"
                    },
                    new Department
                    {
                        Id = 4,
                        Name = "Eshop"
                    },
                    new Department
                    {
                        Id = 5,
                        Name = "Warehouse"
                    },
                    new Department
                    {
                        Id = 6,
                        Name = "Accounting"
                    }
                );

            #endregion Departments

            #region Positions
            builder.Entity<Position>()
                .HasData(
                new Position
                {
                    Id = 1,
                    DepartmentId = 1,
                    Name = "Senior Recruiter",
                    Description = "Senior Recruiter for our small company",
                    Degree = "Degree in relative field",
                    WorkExperience = "Minimum 5 years of experience and a cover letter from your previous employer",
                    Languages = "Greek, English",
                    Qualifications = "Strong Communication Skills",
                    IsActive = true
                },
                new Position
                {
                    Id = 2,
                    DepartmentId = 1,
                    Name = "Junior Recruiter",
                    Description = "Junior Recruiter for our small company",
                    Degree = "Degree in relative field",
                    WorkExperience = "Minimum 2 years of experience and a cover letter from your previous employer",
                    Languages = "Greek, English",
                    Qualifications = "Strong Communication Skills",
                    IsActive = true
                },
                new Position
                {
                    Id = 3,
                    DepartmentId = 2,
                    Name = "Senior Procurement Manager",
                    Description = "Senior Procurement Manager for our small company",
                    Degree = "Degree in relative field",
                    WorkExperience = "Minimum 7 years of experience",
                    Languages = "Greek, English",
                    Qualifications = "Creative Problem-Solcing",
                    IsActive = true
                },
                new Position
                {
                    Id = 4,
                    DepartmentId = 3,
                    Name = "Senior Sales Analyst",
                    Description = "Senior Sales Analyst to manage our sales figures",
                    Degree = "Degree in relative field",
                    WorkExperience = "Minimum 4 years of experience",
                    Languages = "Greek, English",
                    Qualifications = "Strong background in Math",
                    IsActive = true
                },
                new Position
                {
                    Id = 5,
                    DepartmentId = 3,
                    Name = "Junior Sales Analyst",
                    Description = "Junior Sales Analyst who is willing to work for free",
                    Degree = "Degree in relative field",
                    WorkExperience = "Internship",
                    Languages = "Greek, English",
                    Qualifications = "Willing to work for free",
                    IsActive = true
                },
                new Position
                {
                    Id = 6,
                    DepartmentId = 4,
                    Name = "E-Shop Junior Developer",
                    Description = "E-Shop Junior Developer for our company's e-shop",
                    Degree = "Degree in relative field",
                    WorkExperience = "Minimum 2 years of experience in projects created with .net 5",
                    Languages = "Greek, English",
                    Qualifications = "Basic knowledge with any Object-Oriented programming language",
                    IsActive = true
                },
                new Position
                {
                    Id = 7,
                    DepartmentId = 4,
                    Name = "E-Shop Senior Developer",
                    Description = "E-Shop Senior Developer for our company's e-shop",
                    Degree = "Degree in relative field",
                    WorkExperience = "Minimum 6 years of experience in projects created with .net 5",
                    Languages = "Greek, English",
                    Qualifications = "Leadership skills and a strong programming background",
                    IsActive = true
                },
                new Position
                {
                    Id = 8,
                    DepartmentId = 5,
                    Name = "Warehouse Worker",
                    Description = "Warehouse Worker for one of our local Warehouses",
                    Degree = "No need",
                    WorkExperience = "Experience with getting your hands dirty",
                    Languages = "Greek, English",
                    Qualifications = "Strong physical skills",
                    IsActive = true
                },
                new Position
                {
                    Id = 9,
                    DepartmentId = 5,
                    Name = "Warehouse Manager",
                    Description = "Warehouse Manager to manage one of our local Warehouses",
                    Degree = "Degree in relative field",
                    WorkExperience = "Utleast 3 years of experience in Warehouse management",
                    Languages = "Greek, English",
                    Qualifications = "Logical-Thinking",
                    IsActive = true
                },
                new Position
                {
                    Id = 10,
                    DepartmentId = 6,
                    Name = "Senior Accountant",
                    Description = "Senior Accountant to help us do our taxes",
                    Degree = "Degree in relative field",
                    WorkExperience = "Utleast 5 years of experience",
                    Languages = "Greek, English",
                    Qualifications = "How skilled are you with tax evasion?",
                    IsActive = true
                }
                );
            #endregion

            #region Candidates
            builder.Entity<Candidate>()
                .HasData(
                new Candidate
                {
                    Id = 1,
                    FirstName = "Kennard",
                    LastName = "Ramsey",
                    DateOfBirth = DateTime.Parse("2000/02/02"),
                    IsBlacklisted = false
                },
                new Candidate
                {
                    Id = 2,
                    FirstName = "Dominic",
                    LastName = "Greenwood",
                    DateOfBirth = DateTime.Parse("2000/12/08"),
                    IsBlacklisted = false
                },
                new Candidate
                {
                    Id = 3,
                    FirstName = "Benjamin",
                    LastName = "Hunt",
                    DateOfBirth = DateTime.Parse("2001/12/08"),
                    IsBlacklisted = false
                },
                new Candidate
                {
                    Id = 4,
                    FirstName = "Victor",
                    LastName = "Lambert",
                    DateOfBirth = DateTime.Parse("2003/11/08"),
                    IsBlacklisted = false
                },
                new Candidate
                {
                    Id = 5,
                    FirstName = "Ferdinand",
                    LastName = "Smith",
                    DateOfBirth = DateTime.Parse("1997/08/13"),
                    IsBlacklisted = false
                },
                new Candidate
                {
                    Id = 6,
                    FirstName = "Melinda",
                    LastName = "Gross",
                    DateOfBirth = DateTime.Parse("1981/08/13"),
                    IsBlacklisted = false
                },
                new Candidate
                {
                    Id = 7,
                    FirstName = "Laura",
                    LastName = "Parham",
                    DateOfBirth = DateTime.Parse("1987/10/23"),
                    IsBlacklisted = false
                },
                new Candidate
                {
                    Id = 8,
                    FirstName = "Lucy",
                    LastName = "Johnson",
                    DateOfBirth = DateTime.Parse("2002/11/27"),
                    IsBlacklisted = false
                },
                new Candidate
                {
                    Id = 9,
                    FirstName = "Harper",
                    LastName = "Fernandez",
                    DateOfBirth = DateTime.Parse("2002/06/16"),
                    IsBlacklisted = false
                },
                new Candidate
                {
                    Id = 10,
                    FirstName = "Georgia",
                    LastName = "Lawson",
                    DateOfBirth = DateTime.Parse("2000/09/13"),
                    IsBlacklisted = false
                }
                
                
                );
            #endregion

            #region Interviews
            builder.Entity<Interview>()
                .HasData(
                new Interview
                {
                    Id = 1,
                    CandidateId = 1,
                    EmployeeId = 1,
                    DateOfInterview = new DateTime(2021, 04, 18, 19, 30, 00)
                },
                new Interview
                {
                    Id = 2,
                    CandidateId = 3,
                    EmployeeId = 3,
                    DateOfInterview = new DateTime(2021, 04, 2, 12, 30, 00),
                    Comments = "Great energy",
                    Rating = 5
                },
                new Interview
                {
                    Id = 3,
                    CandidateId = 5,
                    EmployeeId = 5,
                    DateOfInterview = new DateTime(2021, 04, 22, 14, 30, 00)
                },
                new Interview
                {
                    Id = 4,
                    CandidateId = 7,
                    EmployeeId = 7,
                    DateOfInterview = new DateTime(2021, 03, 29, 13, 30, 00),
                    Comments = "Not Impressed",
                    Rating = 2
                },
                new Interview
                {
                    Id = 5,
                    CandidateId = 9,
                    EmployeeId = 9,
                    DateOfInterview = new DateTime(2021, 03, 27, 17, 30, 00),
                    Comments = "Mixed Feelings",
                    Rating = 3
                }

                );
            #endregion

            #region CandidatePositions

            builder.Entity<CandidatePosition>()
                .HasData(
                    new CandidatePosition
                    {
                        CandidateId = 1,
                        PositionId = 1,
                        RecruitStatus = RecruitStatus.Unopened
                    },
                    new CandidatePosition
                    {
                        CandidateId = 2,
                        PositionId = 2,
                        RecruitStatus = RecruitStatus.Unopened
                    },
                    new CandidatePosition
                    {
                        CandidateId = 3,
                        PositionId = 3,
                        RecruitStatus = RecruitStatus.Reviewed
                    },
                    new CandidatePosition
                    {
                        CandidateId = 4,
                        PositionId = 4,
                        RecruitStatus = RecruitStatus.Reviewed
                    },
                    new CandidatePosition
                    {
                        CandidateId = 5,
                        PositionId = 5,
                        RecruitStatus = RecruitStatus.Interviewing
                    },
                    new CandidatePosition
                    {
                        CandidateId = 6,
                        PositionId = 6,
                        RecruitStatus = RecruitStatus.Interviewing
                    },
                    new CandidatePosition
                    {
                        CandidateId = 7,
                        PositionId = 7,
                        RecruitStatus = RecruitStatus.Interviewed
                    },
                    new CandidatePosition
                    {
                        CandidateId = 8,
                        PositionId = 8,
                        RecruitStatus = RecruitStatus.Interviewed
                    },
                    new CandidatePosition
                    {
                        CandidateId = 9,
                        PositionId = 9,
                        RecruitStatus = RecruitStatus.Rejected
                    },
                    new CandidatePosition
                    {
                        CandidateId = 10,
                        PositionId = 10,
                        RecruitStatus = RecruitStatus.Hired
                    }

                    );
            

            #endregion

            #region RawMaterialProduct
            builder.Entity<RawMaterialProduct>()
                  .HasData(
                new RawMaterialProduct
                {
                    ProductId = 1,
                    RawMaterialId = 2
                },
                new RawMaterialProduct
                {
                    ProductId = 3,
                    RawMaterialId = 5
                },
                new RawMaterialProduct
                {
                    ProductId = 2,
                    RawMaterialId = 4
                },
                new RawMaterialProduct
                {
                    ProductId = 10,
                    RawMaterialId = 8
                },
                new RawMaterialProduct
                {
                    ProductId = 5,
                    RawMaterialId = 16
                },
                new RawMaterialProduct
                {
                    ProductId = 9,
                    RawMaterialId = 13
                },
                new RawMaterialProduct
                {
                    ProductId = 19,
                    RawMaterialId = 6
                },
                new RawMaterialProduct
                {
                    ProductId = 11,
                    RawMaterialId = 12
                },
                new RawMaterialProduct
                {
                    ProductId = 20,
                    RawMaterialId = 2
                },
                new RawMaterialProduct
                {
                    ProductId = 34,
                    RawMaterialId = 14
                },
                new RawMaterialProduct
                {
                    ProductId = 42,
                    RawMaterialId = 1
                },
                new RawMaterialProduct
                {
                    ProductId = 32,
                    RawMaterialId = 3
                },
                new RawMaterialProduct
                {
                    ProductId = 23,
                    RawMaterialId = 5
                }
                );
            #endregion

            #region Leave
            builder.Entity<Leave>()
                 .HasData(
               new Leave
               {
                   Id = 1,
                   LeaveType = LeaveType.Annual,
                   EmployeeId = 2,
                   StartDate = new DateTime(2021,03,02),
                   NumberOfDays = 2
               },
               new Leave
               {
                    Id = 2,
                    LeaveType = LeaveType.Maternity,
                    EmployeeId = 5,
                    StartDate = new DateTime(2021, 05, 03),
                    NumberOfDays = 5
               },
               new Leave
               {
                   Id = 3,
                   LeaveType = LeaveType.Annual,
                   EmployeeId = 10,
                   StartDate = new DateTime(2021, 09, 10),
                   NumberOfDays = 2
               },
               new Leave
               {
                    Id = 4,
                    LeaveType = LeaveType.Paternity,
                    EmployeeId = 15,
                    StartDate = new DateTime(2021, 01, 01),
                    NumberOfDays = 2
               },
               new Leave
               {
                   Id = 5,
                   LeaveType = LeaveType.Sick,
                   EmployeeId = 9,
                   StartDate = new DateTime(2021, 02, 02),
                   NumberOfDays = 1
               },
               new Leave
               {
                   Id = 6,
                   LeaveType = LeaveType.Study,
                   EmployeeId = 2,
                   StartDate = new DateTime(2021, 04, 05),
                   NumberOfDays = 1
               },
               new Leave
               {
                   Id = 7,
                   LeaveType = LeaveType.Annual,
                   EmployeeId = 11,
                   StartDate = new DateTime(2021, 10, 11),
                   NumberOfDays = 7
               },
               new Leave
               {
                   Id = 8,
                   LeaveType = LeaveType.Maternity,
                   EmployeeId = 2,
                   StartDate = new DateTime(2021, 8, 02),
                   NumberOfDays = 4
               },
               new Leave
               {
                   Id = 9,
                   LeaveType = LeaveType.Paternity,
                   EmployeeId = 19,
                   StartDate = new DateTime(2021, 12, 12),
                   NumberOfDays = 7
               },
               new Leave
               {
                   Id = 10,
                   LeaveType = LeaveType.Sick,
                   EmployeeId = 1,
                   StartDate = new DateTime(2021, 01, 02),
                   NumberOfDays = 1
               },
               new Leave
               {
                   Id = 11,
                   LeaveType = LeaveType.Study,
                   EmployeeId = 11,
                   StartDate = new DateTime(2021, 02, 03),
                   NumberOfDays = 2
               },
               new Leave
               {
                   Id = 12,
                   LeaveType = LeaveType.Annual,
                   EmployeeId = 22,
                   StartDate = new DateTime(2021, 03, 04),
                   NumberOfDays = 2
               },
               new Leave
               {
                   Id = 13,
                   LeaveType = LeaveType.Maternity,
                   EmployeeId = 20,
                   StartDate = new DateTime(2021, 04, 05),
                   NumberOfDays = 3
               },
               new Leave
               {
                   Id = 14,
                   LeaveType = LeaveType.Paternity,
                   EmployeeId = 18,
                   StartDate = new DateTime(2021, 05, 11),
                   NumberOfDays = 4
               },
               new Leave
               {
                   Id = 15,
                   LeaveType = LeaveType.Sick,
                   EmployeeId = 17,
                   StartDate = new DateTime(2021, 06, 12),
                   NumberOfDays = 5
               }
               );

            #endregion
        }
    }
}
