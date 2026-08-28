using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace NatijaUz.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "academic");

            migrationBuilder.EnsureSchema(
                name: "sys");

            migrationBuilder.EnsureSchema(
                name: "submission");

            migrationBuilder.CreateTable(
                name: "SYS_LEARNING_CENTER",
                schema: "sys",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NAME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ADDRESS = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    PHONE_NUMBER = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false),
                    OWNER_USER_ID = table.Column<long>(type: "bigint", nullable: false),
                    CREATE_USER_ID = table.Column<long>(type: "bigint", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MODIFIED_USER_ID = table.Column<long>(type: "bigint", nullable: true),
                    MODIFIED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_LEARNING_CENTER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SYS_USER",
                schema: "sys",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FULL_NAME = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    PHONE_NUMBER = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false),
                    PASSWORD = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    ROLE = table.Column<string>(type: "text", maxLength: 15, nullable: false),
                    LEARNING_CENTER_ID = table.Column<long>(type: "bigint", nullable: false),
                    CREATE_USER_ID = table.Column<long>(type: "bigint", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MODIFIED_USER_ID = table.Column<long>(type: "bigint", nullable: true),
                    MODIFIED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_USER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SYS_USER_SYS_LEARNING_CENTER_LEARNING_CENTER_ID",
                        column: x => x.LEARNING_CENTER_ID,
                        principalSchema: "sys",
                        principalTable: "SYS_LEARNING_CENTER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SYS_GROUP",
                schema: "academic",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NAME = table.Column<string>(type: "varchar(200)", maxLength: 300, nullable: false),
                    SUBJECT = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    LEARNING_CENTER_ID = table.Column<long>(type: "bigint", nullable: false),
                    TEACHER_ID = table.Column<long>(type: "bigint", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CREATE_USER_ID = table.Column<long>(type: "bigint", nullable: true),
                    MODIFIED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MODIFIED_USER_ID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_GROUP", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SYS_GROUP_SYS_LEARNING_CENTER_LEARNING_CENTER_ID",
                        column: x => x.LEARNING_CENTER_ID,
                        principalSchema: "sys",
                        principalTable: "SYS_LEARNING_CENTER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SYS_GROUP_SYS_USER_TEACHER_ID",
                        column: x => x.TEACHER_ID,
                        principalSchema: "sys",
                        principalTable: "SYS_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SYS_GROUP_MEMBER",
                schema: "academic",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GROUP_ID = table.Column<long>(type: "bigint", nullable: false),
                    STUDENT_ID = table.Column<long>(type: "bigint", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CREATE_USER_ID = table.Column<long>(type: "bigint", nullable: true),
                    MODIFIED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MODIFIED_USER_ID = table.Column<long>(type: "bigint", nullable: true),
                    JoinedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_GROUP_MEMBER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SYS_GROUP_MEMBER_SYS_GROUP_GROUP_ID",
                        column: x => x.GROUP_ID,
                        principalSchema: "academic",
                        principalTable: "SYS_GROUP",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SYS_GROUP_MEMBER_SYS_USER_STUDENT_ID",
                        column: x => x.STUDENT_ID,
                        principalSchema: "sys",
                        principalTable: "SYS_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SYS_TEST",
                schema: "academic",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TITLE = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    GROUP_ID = table.Column<long>(type: "bigint", nullable: false),
                    QUESTION_COUNT = table.Column<int>(type: "integer", nullable: false),
                    DEADLINE = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "boolean", nullable: false),
                    CREATE_USER_ID = table.Column<long>(type: "bigint", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MODIFIED_USER_ID = table.Column<long>(type: "bigint", nullable: true),
                    MODIFIED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_TEST", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SYS_TEST_SYS_GROUP_GROUP_ID",
                        column: x => x.GROUP_ID,
                        principalSchema: "academic",
                        principalTable: "SYS_GROUP",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SYS_ANSWER_KEY",
                schema: "academic",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TEST_ID = table.Column<long>(type: "bigint", nullable: false),
                    QUESTION_NUMBER = table.Column<int>(type: "integer", nullable: false),
                    CORRECT_ANSWER = table.Column<char>(type: "character(1)", nullable: false),
                    CreateUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ModifiedUserId = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_ANSWER_KEY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SYS_ANSWER_KEY_SYS_TEST_TEST_ID",
                        column: x => x.TEST_ID,
                        principalSchema: "academic",
                        principalTable: "SYS_TEST",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SYS_SUBMISSION",
                schema: "submission",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TEST_ID = table.Column<long>(type: "bigint", nullable: false),
                    STUDENT_ID = table.Column<long>(type: "bigint", nullable: false),
                    IMAGE_URL = table.Column<string>(type: "text", nullable: false),
                    STATUS = table.Column<string>(type: "text", nullable: false),
                    SUBMITTED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CORRECT_COUNT = table.Column<int>(type: "integer", nullable: true),
                    TOTAL_SCORE = table.Column<decimal>(type: "numeric", nullable: true),
                    CREATE_USER_ID = table.Column<long>(type: "bigint", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MODIFIED_USER_ID = table.Column<long>(type: "bigint", nullable: true),
                    MODIFIED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_SUBMISSION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SYS_SUBMISSION_SYS_TEST_TEST_ID",
                        column: x => x.TEST_ID,
                        principalSchema: "academic",
                        principalTable: "SYS_TEST",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SYS_SUBMISSION_SYS_USER_STUDENT_ID",
                        column: x => x.STUDENT_ID,
                        principalSchema: "sys",
                        principalTable: "SYS_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SYS_SUBMISSION_ANSWER",
                schema: "submission",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubmissionId = table.Column<long>(type: "bigint", nullable: false),
                    QUESTION_NUMBER = table.Column<int>(type: "integer", nullable: false),
                    DETECTED_ANSWER = table.Column<char>(type: "character(1)", nullable: false),
                    IS_CORRECT = table.Column<bool>(type: "boolean", nullable: false),
                    CREATE_USER_ID = table.Column<long>(type: "bigint", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MODIFIED_USER_ID = table.Column<long>(type: "bigint", nullable: true),
                    MODIFIED_AT = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_SUBMISSION_ANSWER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SYS_SUBMISSION_ANSWER_SYS_SUBMISSION_SubmissionId",
                        column: x => x.SubmissionId,
                        principalSchema: "submission",
                        principalTable: "SYS_SUBMISSION",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SYS_ANSWER_KEY_TEST_ID",
                schema: "academic",
                table: "SYS_ANSWER_KEY",
                column: "TEST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SYS_GROUP_LEARNING_CENTER_ID",
                schema: "academic",
                table: "SYS_GROUP",
                column: "LEARNING_CENTER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SYS_GROUP_TEACHER_ID",
                schema: "academic",
                table: "SYS_GROUP",
                column: "TEACHER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SYS_GROUP_MEMBER_GROUP_ID",
                schema: "academic",
                table: "SYS_GROUP_MEMBER",
                column: "GROUP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SYS_GROUP_MEMBER_STUDENT_ID",
                schema: "academic",
                table: "SYS_GROUP_MEMBER",
                column: "STUDENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SYS_LEARNING_CENTER_PHONE_NUMBER",
                schema: "sys",
                table: "SYS_LEARNING_CENTER",
                column: "PHONE_NUMBER",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SYS_SUBMISSION_STUDENT_ID",
                schema: "submission",
                table: "SYS_SUBMISSION",
                column: "STUDENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SYS_SUBMISSION_TEST_ID",
                schema: "submission",
                table: "SYS_SUBMISSION",
                column: "TEST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SYS_SUBMISSION_ANSWER_SubmissionId",
                schema: "submission",
                table: "SYS_SUBMISSION_ANSWER",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_SYS_TEST_GROUP_ID",
                schema: "academic",
                table: "SYS_TEST",
                column: "GROUP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SYS_USER_LEARNING_CENTER_ID",
                schema: "sys",
                table: "SYS_USER",
                column: "LEARNING_CENTER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SYS_USER_PHONE_NUMBER",
                schema: "sys",
                table: "SYS_USER",
                column: "PHONE_NUMBER",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SYS_ANSWER_KEY",
                schema: "academic");

            migrationBuilder.DropTable(
                name: "SYS_GROUP_MEMBER",
                schema: "academic");

            migrationBuilder.DropTable(
                name: "SYS_SUBMISSION_ANSWER",
                schema: "submission");

            migrationBuilder.DropTable(
                name: "SYS_SUBMISSION",
                schema: "submission");

            migrationBuilder.DropTable(
                name: "SYS_TEST",
                schema: "academic");

            migrationBuilder.DropTable(
                name: "SYS_GROUP",
                schema: "academic");

            migrationBuilder.DropTable(
                name: "SYS_USER",
                schema: "sys");

            migrationBuilder.DropTable(
                name: "SYS_LEARNING_CENTER",
                schema: "sys");
        }
    }
}
