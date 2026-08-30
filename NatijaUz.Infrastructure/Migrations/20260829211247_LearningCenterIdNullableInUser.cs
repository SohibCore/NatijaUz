using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NatijaUz.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LearningCenterIdNullableInUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "LEARNING_CENTER_ID",
                schema: "sys",
                table: "SYS_USER",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "USER_NAME",
                schema: "sys",
                table: "SYS_USER",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "USER_NAME",
                schema: "sys",
                table: "SYS_USER");

            migrationBuilder.AlterColumn<long>(
                name: "LEARNING_CENTER_ID",
                schema: "sys",
                table: "SYS_USER",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
