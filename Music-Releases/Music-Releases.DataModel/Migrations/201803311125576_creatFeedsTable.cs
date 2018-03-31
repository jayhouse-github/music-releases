namespace Music_Releases.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creatFeedsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ListOfBandsModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ListOfBands = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ListOfBandsModels");
        }
    }
}
