using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GPDAL.Migrations
{
    public partial class dbthree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GPworkout_AspNetUsers_Id",
                table: "GPworkout");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GPworkout",
                table: "GPworkout");

            migrationBuilder.AlterColumn<int>(
                name: "WorkId",
                table: "GPworkout",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "GPworkout",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_GPworkout",
                table: "GPworkout",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_GPworkout_Id",
                table: "GPworkout",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GPworkout_AspNetUsers_Id",
                table: "GPworkout",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GPworkout_AspNetUsers_Id",
                table: "GPworkout");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GPworkout",
                table: "GPworkout");

            migrationBuilder.DropIndex(
                name: "IX_GPworkout_Id",
                table: "GPworkout");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "GPworkout",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WorkId",
                table: "GPworkout",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GPworkout",
                table: "GPworkout",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GPworkout_AspNetUsers_Id",
                table: "GPworkout",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
