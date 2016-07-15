namespace MedicalDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntryModels",
                c => new
                    {
                        EntryId = c.Int(nullable: false, identity: true),
                        First_Name = c.String(nullable: false, unicode: false),
                        Middle_Name = c.String(nullable: false, unicode: false),
                        Last_Name = c.String(nullable: false, unicode: false),
                        DOB = c.DateTime(nullable: false, precision: 0),
                        Marital_Status = c.Int(nullable: false),
                        Visa_Category = c.Int(nullable: false),
                        Passport_Number = c.String(nullable: false, unicode: false),
                        Category = c.String(nullable: false, unicode: false),
                        Nationality = c.String(nullable: false, unicode: false),
                        Gender = c.Int(nullable: false),
                        Emirates_ID = c.String(nullable: false, unicode: false),
                        City_of_Residence = c.String(nullable: false, unicode: false),
                        Date_Time = c.String(unicode: false),
                        Company_Name = c.String(nullable: false, unicode: false),
                        UID_Number = c.String(unicode: false),
                        SubGroup_Name = c.String(nullable: false, unicode: false),
                        Emirates_Of_Visa = c.String(nullable: false, unicode: false),
                        Work_Location = c.String(nullable: false, unicode: false),
                        Entity_Id = c.String(nullable: false, unicode: false),
                        Entity_Type = c.String(nullable: false, unicode: false),
                        Establishment_Id = c.String(nullable: false, unicode: false),
                        medical_card = c.String(unicode: false),
                        photo = c.String(unicode: false),
                        passport_copy = c.String(unicode: false),
                        id_copy = c.String(unicode: false),
                        Rid = c.Int(nullable: false),
                        Sid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EntryId)
                .ForeignKey("dbo.GrossSalaries", t => t.Sid, cascadeDelete: true)
                .ForeignKey("dbo.Relationships", t => t.Rid, cascadeDelete: true)
                .Index(t => t.Rid)
                .Index(t => t.Sid);
            
            CreateTable(
                "dbo.FileDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(unicode: false),
                        Extension = c.String(unicode: false),
                        EntryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EntryModels", t => t.EntryId, cascadeDelete: true)
                .Index(t => t.EntryId);
            
            CreateTable(
                "dbo.GrossSalaries",
                c => new
                    {
                        Sid = c.Int(nullable: false, identity: true),
                        Value = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Sid);
            
            CreateTable(
                "dbo.Relationships",
                c => new
                    {
                        Rid = c.Int(nullable: false, identity: true),
                        RelationName = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Rid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EntryModels", "Rid", "dbo.Relationships");
            DropForeignKey("dbo.EntryModels", "Sid", "dbo.GrossSalaries");
            DropForeignKey("dbo.FileDetails", "EntryId", "dbo.EntryModels");
            DropIndex("dbo.FileDetails", new[] { "EntryId" });
            DropIndex("dbo.EntryModels", new[] { "Sid" });
            DropIndex("dbo.EntryModels", new[] { "Rid" });
            DropTable("dbo.Relationships");
            DropTable("dbo.GrossSalaries");
            DropTable("dbo.FileDetails");
            DropTable("dbo.EntryModels");
        }
    }
}
