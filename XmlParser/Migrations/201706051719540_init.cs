namespace XmlParser_DB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Metadata",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchemaVers = c.String(),
                        SchemaType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Metadata");
        }
    }
}
