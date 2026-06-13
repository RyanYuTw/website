using System;
using System.Data.Entity.Migrations;

namespace MyWeb.Migrations
{
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Account = c.String(nullable: false, maxLength: 50),
                    Password = c.String(nullable: false),
                    Name = c.String(maxLength: 20),
                    Email = c.String(),
                    Phone = c.String(maxLength: 20),
                    Mobile = c.String(maxLength: 20),
                    Address = c.String(),
                    Birthday = c.DateTime(),
                    Gender = c.String(),
                    Kind = c.String(),
                    IsActive = c.Boolean(nullable: false),
                    CreatedAt = c.DateTime(nullable: false),
                    LastLoginAt = c.DateTime(),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Account, unique: true, name: "IX_Members_Account");

            CreateTable(
                "dbo.ProductCategories",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 100),
                    NameEn = c.String(),
                    ParentId = c.Int(),
                    SortOrder = c.Int(nullable: false),
                    IsActive = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Products",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 200),
                    NameEn = c.String(),
                    CategoryId = c.Int(nullable: false),
                    Description = c.String(maxLength: 2000),
                    Content = c.String(),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    SalePrice = c.Decimal(precision: 18, scale: 2),
                    Stock = c.Int(nullable: false),
                    ImagePath = c.String(),
                    IsActive = c.Boolean(nullable: false),
                    IsRecommend = c.Boolean(nullable: false),
                    SortOrder = c.Int(nullable: false),
                    CreatedAt = c.DateTime(nullable: false),
                    UpdatedAt = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.CategoryId)
                .Index(t => t.CategoryId);

            CreateTable(
                "dbo.Orders",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    OrderNo = c.String(),
                    MemberId = c.Int(nullable: false),
                    OrderDate = c.DateTime(nullable: false),
                    ReceiverName = c.String(nullable: false),
                    ReceiverPhone = c.String(nullable: false),
                    ReceiverAddress = c.String(nullable: false),
                    ReceiverEmail = c.String(),
                    TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    ShippingFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                    PaymentMethod = c.String(),
                    Status = c.String(),
                    Remark = c.String(),
                    CreatedAt = c.DateTime(nullable: false),
                    UpdatedAt = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .Index(t => t.MemberId);

            CreateTable(
                "dbo.OrderItems",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    OrderId = c.Int(nullable: false),
                    ProductId = c.Int(nullable: false),
                    ProductName = c.String(),
                    UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Quantity = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);

            CreateTable(
                "dbo.BlogCategories",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 100),
                    SortOrder = c.Int(nullable: false),
                    IsActive = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.BlogPosts",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(nullable: false, maxLength: 200),
                    CategoryId = c.Int(nullable: false),
                    Summary = c.String(),
                    Content = c.String(),
                    ImagePath = c.String(),
                    Author = c.String(),
                    ViewCount = c.Int(nullable: false),
                    IsPublished = c.Boolean(nullable: false),
                    PublishedAt = c.DateTime(),
                    CreatedAt = c.DateTime(nullable: false),
                    UpdatedAt = c.DateTime(nullable: false),
                    Tags = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogCategories", t => t.CategoryId, cascadeDelete: false)
                .Index(t => t.CategoryId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.BlogPosts", "CategoryId", "dbo.BlogCategories");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.ProductCategories");
            DropIndex("dbo.BlogPosts", new[] { "CategoryId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "MemberId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Members", "IX_Members_Account");
            DropTable("dbo.BlogPosts");
            DropTable("dbo.BlogCategories");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Orders");
            DropTable("dbo.Products");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Members");
        }
    }
}
