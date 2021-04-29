using Microsoft.EntityFrameworkCore.Migrations;

namespace EJumping.DAL.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ThirdOption",
                table: "Questions",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "SecondOption",
                table: "Questions",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "FourthOption",
                table: "Questions",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "FirstOption",
                table: "Questions",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CorrectAnswer", "CorrectAnswerPoints", "FirstOption", "FourthOption", "QuestionName", "QuizId", "SecondOption", "ThirdOption" },
                values: new object[,]
                {
                    { 1, 1, 0, "Would you like me to spell it?", null, "Could you tell me your surname?", 1, "Do you like my family name?", "How do I say that?" },
                    { 2, 2, 0, "It's in the garden.", null, "This plant looks dead.", 1, "It only needs some water.", "It's sleeping." },
                    { 3, 3, 0, "Of course not.", null, "I hope it doesn't rain.", 1, "Will it be wet?", "So do I." },
                    { 4, 3, 0, "For ever.", null, "Are you going to come inside soon?", 1, "Not long.", "In a minute." },
                    { 5, 1, 0, "I bought it.", null, "Who gave you this book, Lucy?", 1, "For my birthday.", "My uncle was." },
                    { 6, 2, 0, "I know that.", null, "Shall we go out for pizza tonight?", 1, "It's very good.", "I'm too tired." }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AlterColumn<int>(
                name: "ThirdOption",
                table: "Questions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SecondOption",
                table: "Questions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FourthOption",
                table: "Questions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FirstOption",
                table: "Questions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
