using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NatijaUz.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class @fixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "USER_NAME",
                schema: "sys",
                table: "SYS_USER",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "ROLE",
                schema: "sys",
                table: "SYS_USER",
                type: "text",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldMaxLength: 15)
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AlterColumn<string>(
                name: "PHONE_NUMBER",
                schema: "sys",
                table: "SYS_USER",
                type: "varchar(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(9)",
                oldMaxLength: 9)
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<string>(
                name: "PASSWORD",
                schema: "sys",
                table: "SYS_USER",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 1000)
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<long>(
                name: "MODIFIED_USER_ID",
                schema: "sys",
                table: "SYS_USER",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 14);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MODIFIED_AT",
                schema: "sys",
                table: "SYS_USER",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 13);

            migrationBuilder.AlterColumn<long>(
                name: "LEARNING_CENTER_ID",
                schema: "sys",
                table: "SYS_USER",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<string>(
                name: "FULL_NAME",
                schema: "sys",
                table: "SYS_USER",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<long>(
                name: "CREATE_USER_ID",
                schema: "sys",
                table: "SYS_USER",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 12);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED_AT",
                schema: "sys",
                table: "SYS_USER",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 11);

            migrationBuilder.AlterColumn<long>(
                name: "ID",
                schema: "sys",
                table: "SYS_USER",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 0)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "ADDRESS",
                schema: "sys",
                table: "SYS_USER",
                type: "text",
                maxLength: 500,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.AddColumn<DateTime>(
                name: "DATE_OF_BIRTH",
                schema: "sys",
                table: "SYS_USER",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("Relational:ColumnOrder", 7);

            migrationBuilder.AddColumn<string>(
                name: "EMAIL",
                schema: "sys",
                table: "SYS_USER",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AddColumn<string>(
                name: "PINFL",
                schema: "sys",
                table: "SYS_USER",
                type: "varchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AddColumn<string>(
                name: "STATUS",
                schema: "sys",
                table: "SYS_USER",
                type: "text",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 9);

            migrationBuilder.AlterColumn<string>(
                name: "TITLE",
                schema: "academic",
                table: "SYS_TEST",
                type: "varchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "QUESTION_COUNT",
                schema: "academic",
                table: "SYS_TEST",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<long>(
                name: "MODIFIED_USER_ID",
                schema: "academic",
                table: "SYS_TEST",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MODIFIED_AT",
                schema: "academic",
                table: "SYS_TEST",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 9);

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                schema: "academic",
                table: "SYS_TEST",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean")
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<long>(
                name: "GROUP_ID",
                schema: "academic",
                table: "SYS_TEST",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DEADLINE",
                schema: "academic",
                table: "SYS_TEST",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<long>(
                name: "CREATE_USER_ID",
                schema: "academic",
                table: "SYS_TEST",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED_AT",
                schema: "academic",
                table: "SYS_TEST",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<long>(
                name: "ID",
                schema: "academic",
                table: "SYS_TEST",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 0)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "STATUS",
                schema: "academic",
                table: "SYS_TEST",
                type: "text",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<int>(
                name: "QUESTION_NUMBER",
                schema: "submission",
                table: "SYS_SUBMISSION_ANSWER",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<long>(
                name: "MODIFIED_USER_ID",
                schema: "submission",
                table: "SYS_SUBMISSION_ANSWER",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MODIFIED_AT",
                schema: "submission",
                table: "SYS_SUBMISSION_ANSWER",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<bool>(
                name: "IS_CORRECT",
                schema: "submission",
                table: "SYS_SUBMISSION_ANSWER",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean")
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<char>(
                name: "DETECTED_ANSWER",
                schema: "submission",
                table: "SYS_SUBMISSION_ANSWER",
                type: "character(1)",
                nullable: false,
                oldClrType: typeof(char),
                oldType: "character(1)")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<long>(
                name: "CREATE_USER_ID",
                schema: "submission",
                table: "SYS_SUBMISSION_ANSWER",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED_AT",
                schema: "submission",
                table: "SYS_SUBMISSION_ANSWER",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<long>(
                name: "ID",
                schema: "submission",
                table: "SYS_SUBMISSION_ANSWER",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 0)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "STATUS",
                schema: "submission",
                table: "SYS_SUBMISSION_ANSWER",
                type: "text",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "TOTAL_SCORE",
                schema: "submission",
                table: "SYS_SUBMISSION",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<long>(
                name: "TEST_ID",
                schema: "submission",
                table: "SYS_SUBMISSION",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SUBMITTED_AT",
                schema: "submission",
                table: "SYS_SUBMISSION",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<long>(
                name: "STUDENT_ID",
                schema: "submission",
                table: "SYS_SUBMISSION",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "STATUS",
                schema: "submission",
                table: "SYS_SUBMISSION",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AlterColumn<long>(
                name: "MODIFIED_USER_ID",
                schema: "submission",
                table: "SYS_SUBMISSION",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 12);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MODIFIED_AT",
                schema: "submission",
                table: "SYS_SUBMISSION",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 11);

            migrationBuilder.AlterColumn<string>(
                name: "IMAGE_URL",
                schema: "submission",
                table: "SYS_SUBMISSION",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<long>(
                name: "CREATE_USER_ID",
                schema: "submission",
                table: "SYS_SUBMISSION",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED_AT",
                schema: "submission",
                table: "SYS_SUBMISSION",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 9);

            migrationBuilder.AlterColumn<int>(
                name: "CORRECT_COUNT",
                schema: "submission",
                table: "SYS_SUBMISSION",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<long>(
                name: "ID",
                schema: "submission",
                table: "SYS_SUBMISSION",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 0)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "SUBMISSION_STATUS",
                schema: "submission",
                table: "SYS_SUBMISSION",
                type: "text",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<string>(
                name: "PHONE_NUMBER",
                schema: "sys",
                table: "SYS_LEARNING_CENTER",
                type: "varchar(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(9)",
                oldMaxLength: 9)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<long>(
                name: "OWNER_USER_ID",
                schema: "sys",
                table: "SYS_LEARNING_CENTER",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                schema: "sys",
                table: "SYS_LEARNING_CENTER",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<long>(
                name: "MODIFIED_USER_ID",
                schema: "sys",
                table: "SYS_LEARNING_CENTER",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 9);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MODIFIED_AT",
                schema: "sys",
                table: "SYS_LEARNING_CENTER",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AlterColumn<long>(
                name: "CREATE_USER_ID",
                schema: "sys",
                table: "SYS_LEARNING_CENTER",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED_AT",
                schema: "sys",
                table: "SYS_LEARNING_CENTER",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<string>(
                name: "ADDRESS",
                schema: "sys",
                table: "SYS_LEARNING_CENTER",
                type: "varchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500)
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<long>(
                name: "ID",
                schema: "sys",
                table: "SYS_LEARNING_CENTER",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .Annotation("Relational:ColumnOrder", 0)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "STATUS",
                schema: "sys",
                table: "SYS_LEARNING_CENTER",
                type: "text",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<long>(
                name: "MODIFIED_USER_ID",
                schema: "academic",
                table: "SYS_GROUP_MEMBER",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 7)
                .OldAnnotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MODIFIED_AT",
                schema: "academic",
                table: "SYS_GROUP_MEMBER",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 6)
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<long>(
                name: "CREATE_USER_ID",
                schema: "academic",
                table: "SYS_GROUP_MEMBER",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 5)
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED_AT",
                schema: "academic",
                table: "SYS_GROUP_MEMBER",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 4)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AddColumn<string>(
                name: "STATUS",
                schema: "academic",
                table: "SYS_GROUP_MEMBER",
                type: "text",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<long>(
                name: "MODIFIED_USER_ID",
                schema: "academic",
                table: "SYS_GROUP",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 9)
                .OldAnnotation("Relational:ColumnOrder", 8);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MODIFIED_AT",
                schema: "academic",
                table: "SYS_GROUP",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 8)
                .OldAnnotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<long>(
                name: "CREATE_USER_ID",
                schema: "academic",
                table: "SYS_GROUP",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 7)
                .OldAnnotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED_AT",
                schema: "academic",
                table: "SYS_GROUP",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 6)
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AddColumn<string>(
                name: "STATUS",
                schema: "academic",
                table: "SYS_GROUP",
                type: "text",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AddColumn<string>(
                name: "STATUS",
                schema: "academic",
                table: "SYS_ANSWER_KEY",
                type: "text",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.CreateTable(
                name: "SYS_PENDING_REGISTRATIONS",
                schema: "sys",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    USER_NAME = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    PASSWORD = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    FULL_NAME = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    PINFL = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    PHONE_NUMBER = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false),
                    ADDRESS = table.Column<string>(type: "text", maxLength: 500, nullable: false),
                    DATE_OF_BIRTH = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EMAIL = table.Column<string>(type: "varchar(255)", nullable: false),
                    CODE = table.Column<string>(type: "varchar(6)", nullable: false),
                    EXPIRES_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ATTEMPT_COUNT = table.Column<int>(type: "integer", nullable: false),
                    LearningCenterId = table.Column<long>(type: "bigint", nullable: true),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_PENDING_REGISTRATIONS", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SYS_USER_EMAIL",
                schema: "sys",
                table: "SYS_USER",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SYS_USER_PINFL",
                schema: "sys",
                table: "SYS_USER",
                column: "PINFL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SYS_USER_USER_NAME",
                schema: "sys",
                table: "SYS_USER",
                column: "USER_NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SYS_PENDING_REGISTRATIONS_EMAIL",
                schema: "sys",
                table: "SYS_PENDING_REGISTRATIONS",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SYS_PENDING_REGISTRATIONS_PHONE_NUMBER",
                schema: "sys",
                table: "SYS_PENDING_REGISTRATIONS",
                column: "PHONE_NUMBER",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SYS_PENDING_REGISTRATIONS_PINFL",
                schema: "sys",
                table: "SYS_PENDING_REGISTRATIONS",
                column: "PINFL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SYS_PENDING_REGISTRATIONS_USER_NAME",
                schema: "sys",
                table: "SYS_PENDING_REGISTRATIONS",
                column: "USER_NAME",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SYS_PENDING_REGISTRATIONS",
                schema: "sys");

            migrationBuilder.DropIndex(
                name: "IX_SYS_USER_EMAIL",
                schema: "sys",
                table: "SYS_USER");

            migrationBuilder.DropIndex(
                name: "IX_SYS_USER_PINFL",
                schema: "sys",
                table: "SYS_USER");

            migrationBuilder.DropIndex(
                name: "IX_SYS_USER_USER_NAME",
                schema: "sys",
                table: "SYS_USER");

            migrationBuilder.DropColumn(
                name: "ADDRESS",
                schema: "sys",
                table: "SYS_USER");

            migrationBuilder.DropColumn(
                name: "DATE_OF_BIRTH",
                schema: "sys",
                table: "SYS_USER");

            migrationBuilder.DropColumn(
                name: "EMAIL",
                schema: "sys",
                table: "SYS_USER");

            migrationBuilder.DropColumn(
                name: "PINFL",
                schema: "sys",
                table: "SYS_USER");

            migrationBuilder.DropColumn(
                name: "STATUS",
                schema: "sys",
                table: "SYS_USER");

            migrationBuilder.DropColumn(
                name: "STATUS",
                schema: "academic",
                table: "SYS_TEST");

            migrationBuilder.DropColumn(
                name: "STATUS",
                schema: "submission",
                table: "SYS_SUBMISSION_ANSWER");

            migrationBuilder.DropColumn(
                name: "SUBMISSION_STATUS",
                schema: "submission",
                table: "SYS_SUBMISSION");

            migrationBuilder.DropColumn(
                name: "STATUS",
                schema: "sys",
                table: "SYS_LEARNING_CENTER");

            migrationBuilder.DropColumn(
                name: "STATUS",
                schema: "academic",
                table: "SYS_GROUP_MEMBER");

            migrationBuilder.DropColumn(
                name: "STATUS",
                schema: "academic",
                table: "SYS_GROUP");

            migrationBuilder.DropColumn(
                name: "STATUS",
                schema: "academic",
                table: "SYS_ANSWER_KEY");

            migrationBuilder.AlterColumn<string>(
                name: "USER_NAME",
                schema: "sys",
                table: "SYS_USER",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "ROLE",
                schema: "sys",
                table: "SYS_USER",
                type: "text",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldMaxLength: 15)
                .OldAnnotation("Relational:ColumnOrder", 8);

            migrationBuilder.AlterColumn<string>(
                name: "PHONE_NUMBER",
                schema: "sys",
                table: "SYS_USER",
                type: "varchar(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(9)",
                oldMaxLength: 9)
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<string>(
                name: "PASSWORD",
                schema: "sys",
                table: "SYS_USER",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 1000)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<long>(
                name: "MODIFIED_USER_ID",
                schema: "sys",
                table: "SYS_USER",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 14);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MODIFIED_AT",
                schema: "sys",
                table: "SYS_USER",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 13);

            migrationBuilder.AlterColumn<long>(
                name: "LEARNING_CENTER_ID",
                schema: "sys",
                table: "SYS_USER",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<string>(
                name: "FULL_NAME",
                schema: "sys",
                table: "SYS_USER",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<long>(
                name: "CREATE_USER_ID",
                schema: "sys",
                table: "SYS_USER",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 12);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED_AT",
                schema: "sys",
                table: "SYS_USER",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .OldAnnotation("Relational:ColumnOrder", 11);

            migrationBuilder.AlterColumn<long>(
                name: "ID",
                schema: "sys",
                table: "SYS_USER",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<string>(
                name: "TITLE",
                schema: "academic",
                table: "SYS_TEST",
                type: "varchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300)
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "QUESTION_COUNT",
                schema: "academic",
                table: "SYS_TEST",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<long>(
                name: "MODIFIED_USER_ID",
                schema: "academic",
                table: "SYS_TEST",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MODIFIED_AT",
                schema: "academic",
                table: "SYS_TEST",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 9);

            migrationBuilder.AlterColumn<bool>(
                name: "IS_ACTIVE",
                schema: "academic",
                table: "SYS_TEST",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean")
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<long>(
                name: "GROUP_ID",
                schema: "academic",
                table: "SYS_TEST",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DEADLINE",
                schema: "academic",
                table: "SYS_TEST",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<long>(
                name: "CREATE_USER_ID",
                schema: "academic",
                table: "SYS_TEST",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 8);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED_AT",
                schema: "academic",
                table: "SYS_TEST",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .OldAnnotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<long>(
                name: "ID",
                schema: "academic",
                table: "SYS_TEST",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<int>(
                name: "QUESTION_NUMBER",
                schema: "submission",
                table: "SYS_SUBMISSION_ANSWER",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<long>(
                name: "MODIFIED_USER_ID",
                schema: "submission",
                table: "SYS_SUBMISSION_ANSWER",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 8);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MODIFIED_AT",
                schema: "submission",
                table: "SYS_SUBMISSION_ANSWER",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<bool>(
                name: "IS_CORRECT",
                schema: "submission",
                table: "SYS_SUBMISSION_ANSWER",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean")
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<char>(
                name: "DETECTED_ANSWER",
                schema: "submission",
                table: "SYS_SUBMISSION_ANSWER",
                type: "character(1)",
                nullable: false,
                oldClrType: typeof(char),
                oldType: "character(1)")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<long>(
                name: "CREATE_USER_ID",
                schema: "submission",
                table: "SYS_SUBMISSION_ANSWER",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED_AT",
                schema: "submission",
                table: "SYS_SUBMISSION_ANSWER",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<long>(
                name: "ID",
                schema: "submission",
                table: "SYS_SUBMISSION_ANSWER",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "TOTAL_SCORE",
                schema: "submission",
                table: "SYS_SUBMISSION",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<long>(
                name: "TEST_ID",
                schema: "submission",
                table: "SYS_SUBMISSION",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SUBMITTED_AT",
                schema: "submission",
                table: "SYS_SUBMISSION",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<long>(
                name: "STUDENT_ID",
                schema: "submission",
                table: "SYS_SUBMISSION",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "STATUS",
                schema: "submission",
                table: "SYS_SUBMISSION",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 8);

            migrationBuilder.AlterColumn<long>(
                name: "MODIFIED_USER_ID",
                schema: "submission",
                table: "SYS_SUBMISSION",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 12);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MODIFIED_AT",
                schema: "submission",
                table: "SYS_SUBMISSION",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 11);

            migrationBuilder.AlterColumn<string>(
                name: "IMAGE_URL",
                schema: "submission",
                table: "SYS_SUBMISSION",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .OldAnnotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<long>(
                name: "CREATE_USER_ID",
                schema: "submission",
                table: "SYS_SUBMISSION",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED_AT",
                schema: "submission",
                table: "SYS_SUBMISSION",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .OldAnnotation("Relational:ColumnOrder", 9);

            migrationBuilder.AlterColumn<int>(
                name: "CORRECT_COUNT",
                schema: "submission",
                table: "SYS_SUBMISSION",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<long>(
                name: "ID",
                schema: "submission",
                table: "SYS_SUBMISSION",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<string>(
                name: "PHONE_NUMBER",
                schema: "sys",
                table: "SYS_LEARNING_CENTER",
                type: "varchar(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(9)",
                oldMaxLength: 9)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<long>(
                name: "OWNER_USER_ID",
                schema: "sys",
                table: "SYS_LEARNING_CENTER",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                schema: "sys",
                table: "SYS_LEARNING_CENTER",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<long>(
                name: "MODIFIED_USER_ID",
                schema: "sys",
                table: "SYS_LEARNING_CENTER",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 9);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MODIFIED_AT",
                schema: "sys",
                table: "SYS_LEARNING_CENTER",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 8);

            migrationBuilder.AlterColumn<long>(
                name: "CREATE_USER_ID",
                schema: "sys",
                table: "SYS_LEARNING_CENTER",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED_AT",
                schema: "sys",
                table: "SYS_LEARNING_CENTER",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .OldAnnotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<string>(
                name: "ADDRESS",
                schema: "sys",
                table: "SYS_LEARNING_CENTER",
                type: "varchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<long>(
                name: "ID",
                schema: "sys",
                table: "SYS_LEARNING_CENTER",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<long>(
                name: "MODIFIED_USER_ID",
                schema: "academic",
                table: "SYS_GROUP_MEMBER",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 6)
                .OldAnnotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MODIFIED_AT",
                schema: "academic",
                table: "SYS_GROUP_MEMBER",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 5)
                .OldAnnotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<long>(
                name: "CREATE_USER_ID",
                schema: "academic",
                table: "SYS_GROUP_MEMBER",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 4)
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED_AT",
                schema: "academic",
                table: "SYS_GROUP_MEMBER",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 3)
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<long>(
                name: "MODIFIED_USER_ID",
                schema: "academic",
                table: "SYS_GROUP",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 8)
                .OldAnnotation("Relational:ColumnOrder", 9);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MODIFIED_AT",
                schema: "academic",
                table: "SYS_GROUP",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 7)
                .OldAnnotation("Relational:ColumnOrder", 8);

            migrationBuilder.AlterColumn<long>(
                name: "CREATE_USER_ID",
                schema: "academic",
                table: "SYS_GROUP",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 6)
                .OldAnnotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CREATED_AT",
                schema: "academic",
                table: "SYS_GROUP",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone")
                .Annotation("Relational:ColumnOrder", 5)
                .OldAnnotation("Relational:ColumnOrder", 6);
        }
    }
}
