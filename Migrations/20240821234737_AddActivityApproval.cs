using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagementAPIB.Migrations
{
    /// <inheritdoc />
    public partial class AddActivityApproval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityApproval",
                table: "ActivityApproval");

            migrationBuilder.RenameTable(
                name: "ActivityApproval",
                newName: "ActivityApprovals");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityApprovals",
                table: "ActivityApprovals",
                column: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityApprovals",
                table: "ActivityApprovals");

            migrationBuilder.RenameTable(
                name: "ActivityApprovals",
                newName: "ActivityApproval");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityApproval",
                table: "ActivityApproval",
                column: "ID");
        }
    }
}
