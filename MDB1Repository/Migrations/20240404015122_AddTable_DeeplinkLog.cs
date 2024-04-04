using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MDB1Repository.Migrations
{
    public partial class AddTable_DeeplinkLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeeplinkLog",
                columns: table => new
                {
                    SeqNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    OsType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Source = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Medium = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeeplinkLog", x => x.SeqNo)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeeplinkLog_Source",
                table: "DeeplinkLog",
                column: "Source")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_DeeplinkLog_Topic",
                table: "DeeplinkLog",
                column: "Topic")
                .Annotation("SqlServer:Clustered", false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeeplinkLog");
        }
    }
}
