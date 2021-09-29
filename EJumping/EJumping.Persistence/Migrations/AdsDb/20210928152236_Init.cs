using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EJumping.Persistence.Migrations.AdsDb
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigurationEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    Key = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsSensitive = table.Column<bool>(type: "boolean", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataProtectionKeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FriendlyName = table.Column<string>(type: "text", nullable: true),
                    Xml = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataProtectionKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quizs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    Name = table.Column<string>(type: "text", nullable: true),
                    QuizLogoUrl = table.Column<string>(type: "text", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NormalizedName = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    QuestionName = table.Column<string>(type: "text", nullable: true),
                    FirstOption = table.Column<string>(type: "text", nullable: true),
                    SecondOption = table.Column<string>(type: "text", nullable: true),
                    ThirdOption = table.Column<string>(type: "text", nullable: true),
                    FourthOption = table.Column<string>(type: "text", nullable: true),
                    CorrectAnswer = table.Column<int>(type: "integer", nullable: false),
                    CorrectAnswerPoints = table.Column<int>(type: "integer", nullable: false),
                    QuizId = table.Column<Guid>(type: "uuid", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Quizs_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v1()"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: true),
                    TokenName = table.Column<string>(type: "text", nullable: true),
                    TokenValue = table.Column<string>(type: "text", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ConfigurationEntries",
                columns: new[] { "Id", "CreatedDateTime", "Description", "IsSensitive", "Key", "UpdatedDateTime", "Value" },
                values: new object[] { new Guid("8a051aa5-bcd1-ea11-b098-ac728981bd15"), null, null, false, "SecurityHeaders:Test-Read-From-SqlServer", null, "this-is-read-from-sqlserver" });

            migrationBuilder.InsertData(
                table: "Quizs",
                columns: new[] { "Id", "CreatedDateTime", "Name", "QuizLogoUrl", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("12837d3d-793f-ea11-becb-5cea1d05f660"), null, "Ielts", null, null },
                    { new Guid("12837d3d-793f-ea11-becb-5cea1d05f661"), null, "Toeic", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDateTime", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedDateTime", "UserName" },
                values: new object[] { new Guid("12837d3d-793f-ea11-becb-5cea1d05f660"), 0, null, null, "vincent@gmail.com", false, true, null, "VINCENT@GMAIL.COM", "TUSER1", "AQAAAAEAACcQAAAAEI/8CTFnTa2n7lLHSdaBk39FL2LxJdx8cbYBk8LqKvPSdKMcoObbZzXyQvEjLNUNjA==", null, false, "5M2QLL65J6H6VFIS7VZETKXY27KNVVYJ", false, null, "tuser1" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CorrectAnswer", "CorrectAnswerPoints", "CreatedDateTime", "FirstOption", "FourthOption", "QuestionName", "QuizId", "SecondOption", "ThirdOption", "UpdatedDateTime" },
                values: new object[,]
                {
                    { new Guid("927dd143-5893-414e-aa82-ffeb036d0601"), 1, 0, null, "Would you like me to spell it?", null, "Could you tell me your surname?", new Guid("12837d3d-793f-ea11-becb-5cea1d05f661"), "Do you like my family name?", "How do I say that?", null },
                    { new Guid("ad9c3ac5-08f3-42e0-9f56-0c10242cd012"), 1, 0, null, "It's in the garden.", null, "This plant looks dead.", new Guid("12837d3d-793f-ea11-becb-5cea1d05f661"), "It only needs some water.", "It's sleeping.", null },
                    { new Guid("f1100c71-c629-476c-bb31-897dd35a14c6"), 1, 0, null, "Of course not.", null, "I hope it doesn't rain.", new Guid("12837d3d-793f-ea11-becb-5cea1d05f661"), "Will it be wet?", "So do I.", null },
                    { new Guid("17fc1d9e-e62f-462e-9bb2-e03352b3619b"), 1, 0, null, "For ever.", null, "Are you going to come inside soon?", new Guid("12837d3d-793f-ea11-becb-5cea1d05f661"), "Not long.", "In a minute.", null },
                    { new Guid("9d3d24bb-ac70-4e3a-b73a-c703b50e8773"), 1, 0, null, "I bought it.", null, "Who gave you this book, Lucy?", new Guid("12837d3d-793f-ea11-becb-5cea1d05f661"), "For my birthday.", "My uncle was.", null },
                    { new Guid("3af2c53d-bfb8-4e63-ba00-2724be7f6980"), 1, 0, null, "I know that.", null, "Shall we go out for pizza tonight?", new Guid("12837d3d-793f-ea11-becb-5cea1d05f661"), "It's very good.", "I'm too tired.", null },
                    { new Guid("60bb34dc-2856-4a12-a916-0e9ec9c4c6f5"), 1, 0, null, "That's fine!", null, "Do you mind if I come too?", new Guid("12837d3d-793f-ea11-becb-5cea1d05f661"), "I'd like to.", "I don't know if I can.", null },
                    { new Guid("3d2b173a-2edb-417c-8442-055f5aaf789d"), 1, 0, null, "Can I help you?", null, "There's someone at the door.", new Guid("12837d3d-793f-ea11-becb-5cea1d05f661"), "Well, go and answer it then.", "He's busy at the moment.", null },
                    { new Guid("db7c4909-1aeb-4732-9387-6ae51b3de065"), 1, 0, null, "I'd like one.", null, "How much butter do I need for this cake?", new Guid("12837d3d-793f-ea11-becb-5cea1d05f661"), "I'll use some.", "I'm not sure.", null },
                    { new Guid("ba2fc523-7a46-4496-84c4-ce9a940f65a5"), 1, 0, null, "Since last week.", null, "How long are you here for?", new Guid("12837d3d-793f-ea11-becb-5cea1d05f661"), "Ten days ago.", "Till tomorrow.", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuizId",
                table: "Questions",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId",
                table: "UserTokens",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigurationEntries");

            migrationBuilder.DropTable(
                name: "DataProtectionKeys");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Quizs");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
