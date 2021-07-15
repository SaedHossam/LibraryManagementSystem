namespace LibraryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedateDataTypeinCustomersAndInvoices : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BorrowingInvoices", "Date", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Customers", "DateOfBirth", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.ReturningInvoices", "Date", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.SellingInvoices", "Date", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SellingInvoices", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ReturningInvoices", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BorrowingInvoices", "Date", c => c.DateTime(nullable: false));
        }
    }
}
