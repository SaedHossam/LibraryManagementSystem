namespace LibraryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        NumberOfCopies = c.Int(nullable: false),
                        AvailableNumberOfCopies = c.Int(nullable: false),
                        PriceOfReservation = c.Int(nullable: false),
                        ReservationPerieodInDays = c.Int(nullable: false),
                        PriceOfSelling = c.Int(nullable: false),
                        Cost = c.Int(nullable: false),
                        FinePerDay = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.BorrowingInvoiceItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BorrowingInvoiceId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        IsReturned = c.Boolean(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        SubTotal = c.Int(nullable: false),
                        ReturningInvoiceItemId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.BorrowingInvoices", t => t.BorrowingInvoiceId, cascadeDelete: true)
                .Index(t => t.BorrowingInvoiceId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.BorrowingInvoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CusomerId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        SubTotal = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                        PaymentMethodId = c.Int(nullable: false),
                        CreditCardId = c.Int(),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CreditCards", t => t.CreditCardId)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethodId, cascadeDelete: true)
                .Index(t => t.PaymentMethodId)
                .Index(t => t.CreditCardId)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardHolderName = c.String(nullable: false),
                        CardNumber = c.Int(nullable: false),
                        ExpireDate = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Gender = c.Boolean(nullable: false),
                        Image = c.String(),
                        JobTitleId = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        CountryId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.JobTitles", t => t.JobTitleId, cascadeDelete: true)
                .Index(t => t.JobTitleId)
                .Index(t => t.CountryId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobTitles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReturningInvoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CusomerId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        SubTotal = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                        PaymentMethodId = c.Int(nullable: false),
                        CreditCardId = c.Int(),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CreditCards", t => t.CreditCardId)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethodId, cascadeDelete: true)
                .Index(t => t.PaymentMethodId)
                .Index(t => t.CreditCardId)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.ReturningInvoiceItems",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        BorrowingInvoiceItemId = c.Int(nullable: false),
                        LateDays = c.Int(nullable: false),
                        Fine = c.Int(nullable: false),
                        ReturningInvoice_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BorrowingInvoiceItems", t => t.Id)
                .ForeignKey("dbo.ReturningInvoices", t => t.ReturningInvoice_Id)
                .Index(t => t.Id)
                .Index(t => t.ReturningInvoice_Id);
            
            CreateTable(
                "dbo.SellingInvoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CusomerId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        SubTotal = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                        PaymentMethodId = c.Int(nullable: false),
                        CreditCardId = c.Int(),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CreditCards", t => t.CreditCardId)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethodId, cascadeDelete: true)
                .Index(t => t.PaymentMethodId)
                .Index(t => t.CreditCardId)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.SellingInvoiceItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SellingInvoiceId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        Quabtity = c.Int(nullable: false),
                        SubTotal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.SellingInvoices", t => t.SellingInvoiceId, cascadeDelete: true)
                .Index(t => t.SellingInvoiceId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PaymentMethodCustomers",
                c => new
                    {
                        PaymentMethod_Id = c.Int(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PaymentMethod_Id, t.Customer_Id })
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethod_Id, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .Index(t => t.PaymentMethod_Id)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.SellingInvoiceItems", "SellingInvoiceId", "dbo.SellingInvoices");
            DropForeignKey("dbo.SellingInvoiceItems", "BookId", "dbo.Books");
            DropForeignKey("dbo.SellingInvoices", "PaymentMethodId", "dbo.PaymentMethods");
            DropForeignKey("dbo.SellingInvoices", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.SellingInvoices", "CreditCardId", "dbo.CreditCards");
            DropForeignKey("dbo.ReturningInvoiceItems", "ReturningInvoice_Id", "dbo.ReturningInvoices");
            DropForeignKey("dbo.ReturningInvoiceItems", "Id", "dbo.BorrowingInvoiceItems");
            DropForeignKey("dbo.ReturningInvoices", "PaymentMethodId", "dbo.PaymentMethods");
            DropForeignKey("dbo.ReturningInvoices", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.ReturningInvoices", "CreditCardId", "dbo.CreditCards");
            DropForeignKey("dbo.PaymentMethodCustomers", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.PaymentMethodCustomers", "PaymentMethod_Id", "dbo.PaymentMethods");
            DropForeignKey("dbo.BorrowingInvoices", "PaymentMethodId", "dbo.PaymentMethods");
            DropForeignKey("dbo.Customers", "JobTitleId", "dbo.JobTitles");
            DropForeignKey("dbo.CreditCards", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Customers", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.BorrowingInvoices", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.BorrowingInvoices", "CreditCardId", "dbo.CreditCards");
            DropForeignKey("dbo.BorrowingInvoiceItems", "BorrowingInvoiceId", "dbo.BorrowingInvoices");
            DropForeignKey("dbo.BorrowingInvoiceItems", "BookId", "dbo.Books");
            DropIndex("dbo.PaymentMethodCustomers", new[] { "Customer_Id" });
            DropIndex("dbo.PaymentMethodCustomers", new[] { "PaymentMethod_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.SellingInvoiceItems", new[] { "BookId" });
            DropIndex("dbo.SellingInvoiceItems", new[] { "SellingInvoiceId" });
            DropIndex("dbo.SellingInvoices", new[] { "Customer_Id" });
            DropIndex("dbo.SellingInvoices", new[] { "CreditCardId" });
            DropIndex("dbo.SellingInvoices", new[] { "PaymentMethodId" });
            DropIndex("dbo.ReturningInvoiceItems", new[] { "ReturningInvoice_Id" });
            DropIndex("dbo.ReturningInvoiceItems", new[] { "Id" });
            DropIndex("dbo.ReturningInvoices", new[] { "Customer_Id" });
            DropIndex("dbo.ReturningInvoices", new[] { "CreditCardId" });
            DropIndex("dbo.ReturningInvoices", new[] { "PaymentMethodId" });
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.Customers", new[] { "CityId" });
            DropIndex("dbo.Customers", new[] { "CountryId" });
            DropIndex("dbo.Customers", new[] { "JobTitleId" });
            DropIndex("dbo.CreditCards", new[] { "CustomerId" });
            DropIndex("dbo.BorrowingInvoices", new[] { "Customer_Id" });
            DropIndex("dbo.BorrowingInvoices", new[] { "CreditCardId" });
            DropIndex("dbo.BorrowingInvoices", new[] { "PaymentMethodId" });
            DropIndex("dbo.BorrowingInvoiceItems", new[] { "BookId" });
            DropIndex("dbo.BorrowingInvoiceItems", new[] { "BorrowingInvoiceId" });
            DropIndex("dbo.Books", new[] { "CategoryId" });
            DropTable("dbo.PaymentMethodCustomers");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Categories");
            DropTable("dbo.SellingInvoiceItems");
            DropTable("dbo.SellingInvoices");
            DropTable("dbo.ReturningInvoiceItems");
            DropTable("dbo.ReturningInvoices");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.JobTitles");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Customers");
            DropTable("dbo.CreditCards");
            DropTable("dbo.BorrowingInvoices");
            DropTable("dbo.BorrowingInvoiceItems");
            DropTable("dbo.Books");
        }
    }
}
