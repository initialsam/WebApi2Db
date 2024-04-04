using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MDB2Repository.Migrations
{
    public partial class AddTable_FcmTopic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FcmTopic",
                columns: table => new
                {
                    SeqNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FcmTopic", x => x.SeqNo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FcmTopic");
        }
    }
}
