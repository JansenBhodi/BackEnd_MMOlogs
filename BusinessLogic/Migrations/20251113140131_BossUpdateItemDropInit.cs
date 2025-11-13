using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessLogic.Migrations
{
    /// <inheritdoc />
    public partial class BossUpdateItemDropInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Bosses",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Bosses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxLife",
                table: "Bosses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ItemDrops",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Vitality = table.Column<int>(type: "INTEGER", nullable: false),
                    ClassStat_StatName = table.Column<string>(type: "TEXT", nullable: false),
                    ClassStat_StatValue = table.Column<int>(type: "INTEGER", nullable: false),
                    PrimaryStat_StatName = table.Column<string>(type: "TEXT", nullable: false),
                    PrimaryStat_StatValue = table.Column<int>(type: "INTEGER", nullable: false),
                    SecondaryStat_StatName = table.Column<string>(type: "TEXT", nullable: false),
                    SecondaryStat_StatValue = table.Column<int>(type: "INTEGER", nullable: false),
                    TertiaryStat_StatName = table.Column<string>(type: "TEXT", nullable: true),
                    TertiaryStat_StatValue = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDrops", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BossItemDrop",
                columns: table => new
                {
                    BossesId = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemDropsID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BossItemDrop", x => new { x.BossesId, x.ItemDropsID });
                    table.ForeignKey(
                        name: "FK_BossItemDrop_Bosses_BossesId",
                        column: x => x.BossesId,
                        principalTable: "Bosses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BossItemDrop_ItemDrops_ItemDropsID",
                        column: x => x.ItemDropsID,
                        principalTable: "ItemDrops",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BossItemDrop_ItemDropsID",
                table: "BossItemDrop",
                column: "ItemDropsID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BossItemDrop");

            migrationBuilder.DropTable(
                name: "ItemDrops");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Bosses");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Bosses");

            migrationBuilder.DropColumn(
                name: "MaxLife",
                table: "Bosses");
        }
    }
}
