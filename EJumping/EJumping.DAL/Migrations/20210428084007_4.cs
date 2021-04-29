using Microsoft.EntityFrameworkCore.Migrations;

namespace EJumping.DAL.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CorrectAnswer", "CorrectAnswerPoints", "FirstOption", "FourthOption", "QuestionName", "QuizId", "SecondOption", "ThirdOption" },
                values: new object[,]
                {
                    { 7, 2, 0, "That's fine!", null, "Do you mind if I come too?", 1, "I'd like to.", "I don't know if I can." },
                    { 8, 2, 0, "Can I help you?", null, "There's someone at the door.", 1, "Well, go and answer it then.", "He's busy at the moment." },
                    { 9, 3, 0, "I'd like one.", null, "How much butter do I need for this cake?", 1, "I'll use some.", "I'm not sure." },
                    { 10, 2, 0, "Since last week.", null, "How long are you here for?", 1, "Ten days ago.", "Till tomorrow." }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
