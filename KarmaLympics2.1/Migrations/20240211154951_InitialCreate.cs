using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KarmaLympics2._1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Occasions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OccasionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OccasionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HostName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HostMail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occasions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChallengeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxPoints = table.Column<int>(type: "int", nullable: false),
                    OccasionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Challenges_Occasions_OccasionId",
                        column: x => x.OccasionId,
                        principalTable: "Occasions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OccasionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Occasions_OccasionId",
                        column: x => x.OccasionId,
                        principalTable: "Occasions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamsChallenges",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    ChallengeId = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PicturePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovalStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsChallenges", x => new { x.TeamId, x.ChallengeId });
                    table.ForeignKey(
                        name: "FK_TeamsChallenges_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TeamsChallenges_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamChallengeResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamChallengeId = table.Column<int>(type: "int", nullable: false),
                    TeamChallengeTeamId = table.Column<int>(type: "int", nullable: false),
                    TeamChallengeChallengeId = table.Column<int>(type: "int", nullable: false),
                    PointsEarned = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamChallengeResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamChallengeResults_TeamsChallenges_TeamChallengeTeamId_TeamChallengeChallengeId",
                        columns: x => new { x.TeamChallengeTeamId, x.TeamChallengeChallengeId },
                        principalTable: "TeamsChallenges",
                        principalColumns: new[] { "TeamId", "ChallengeId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_OccasionId",
                table: "Challenges",
                column: "OccasionId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamChallengeResults_TeamChallengeTeamId_TeamChallengeChallengeId",
                table: "TeamChallengeResults",
                columns: new[] { "TeamChallengeTeamId", "TeamChallengeChallengeId" });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_OccasionId",
                table: "Teams",
                column: "OccasionId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsChallenges_ChallengeId",
                table: "TeamsChallenges",
                column: "ChallengeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamChallengeResults");

            migrationBuilder.DropTable(
                name: "TeamsChallenges");

            migrationBuilder.DropTable(
                name: "Challenges");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Occasions");
        }
    }
}
