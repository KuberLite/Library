namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookId = c.String(nullable: false, maxLength: 128),
                        BookNumber = c.Int(nullable: false),
                        BookName = c.String(maxLength: 30),
                        ReleaseYear = c.Int(nullable: false),
                        AuthorNumber = c.Int(nullable: false),
                        AuthorLastName = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Book");
        }
    }
}
