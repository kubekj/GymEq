using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MASProjekt.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gyms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Adress = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gyms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GymAreas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Equipment = table.Column<string>(type: "text", nullable: false),
                    GymId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymAreas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GymAreas_Gyms_GymId",
                        column: x => x.GymId,
                        principalTable: "Gyms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TrainerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    SecondName = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UniqueNumber = table.Column<int>(type: "integer", nullable: true),
                    AmountToPay = table.Column<float>(type: "real", nullable: true),
                    AmountPayed = table.Column<float>(type: "real", nullable: true),
                    YearsOfExperience = table.Column<int>(type: "integer", nullable: true),
                    HoursOfWorkInCurrentMonth = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Agreements",
                columns: table => new
                {
                    IdGym = table.Column<int>(type: "integer", nullable: false),
                    IdPerson = table.Column<int>(type: "integer", nullable: false),
                    SignUpDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ResignationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AgreementType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Agreement_PK", x => new { x.IdGym, x.IdPerson });
                    table.ForeignKey(
                        name: "FK_Agreements_Gyms_IdGym",
                        column: x => x.IdGym,
                        principalTable: "Gyms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agreements_Person_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cleanings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DoneAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MaterialsUsed = table.Column<string>(type: "text", nullable: false),
                    MaidId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cleanings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cleanings_Person_MaidId",
                        column: x => x.MaidId,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalTrainings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TrainingType = table.Column<string>(type: "text", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    Opinion = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    ClubMemberId = table.Column<int>(type: "integer", nullable: false),
                    TrainerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalTrainings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PersonalTrainings_Person_ClubMemberId",
                        column: x => x.ClubMemberId,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalTrainings_Person_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Gyms",
                columns: new[] { "ID", "Adress", "Name" },
                values: new object[] { 1, "Szamocka 51", "Zdrogit" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "ID", "ActivityID", "AmountPayed", "AmountToPay", "Birthday", "Discriminator", "Email", "Gender", "Name", "SecondName", "Surname", "UniqueNumber" },
                values: new object[] { 2, null, 120044f, 1000f, new DateTime(2022, 6, 23, 19, 5, 14, 407, DateTimeKind.Utc).AddTicks(6480), "ClubMember", "ee@wp.pl", "Men", "Andrzej", null, "Kejra", 1061559117 });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "ID", "Discriminator", "Email", "Gender", "Name", "SecondName", "Surname" },
                values: new object[] { 3, "Guest", "kl@wp.pl", "Men", "Klocu", null, "12" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "ID", "Discriminator", "Email", "Gender", "HoursOfWorkInCurrentMonth", "Name", "SecondName", "Surname", "YearsOfExperience" },
                values: new object[,]
                {
                    { 4, "Maid", "bw@wp.pl", "Woman", 0f, "Bozena", null, "Wa", 0 },
                    { 5, "Owner", "szef@wp.pl", "Unknown", 0f, "Szeryf", null, "Szefoski", 0 },
                    { 1, "Trainer", "blabla@wp.pl", "Men", 144f, "Jacek", null, "Placek", 2 }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ID", "Description", "End", "Start", "Title", "TrainerId" },
                values: new object[] { 1, "Tanczymy do rana", new DateTime(2022, 6, 23, 19, 5, 14, 407, DateTimeKind.Utc).AddTicks(6460), new DateTime(2022, 6, 23, 19, 5, 14, 407, DateTimeKind.Utc).AddTicks(6460), "Zamba", 1 });

            migrationBuilder.InsertData(
                table: "Agreements",
                columns: new[] { "IdGym", "IdPerson", "AgreementType", "ResignationDate", "SignUpDate" },
                values: new object[] { 1, 1, 1, new DateTime(2022, 6, 23, 19, 5, 14, 407, DateTimeKind.Utc).AddTicks(6470), new DateTime(2022, 6, 23, 19, 5, 14, 407, DateTimeKind.Utc).AddTicks(6470) });

            migrationBuilder.InsertData(
                table: "GymAreas",
                columns: new[] { "ID", "Equipment", "GymId", "Name" },
                values: new object[] { 1, "lawka,lina", 1, "Wolne ciezary" });

            migrationBuilder.InsertData(
                table: "PersonalTrainings",
                columns: new[] { "ID", "ClubMemberId", "Duration", "Opinion", "TrainerId", "TrainingType" },
                values: new object[] { 1, 2, 20, "Super ekstra", 1, "Cardio" });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_TrainerId",
                table: "Activities",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_IdPerson",
                table: "Agreements",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Cleanings_MaidId",
                table: "Cleanings",
                column: "MaidId");

            migrationBuilder.CreateIndex(
                name: "IX_GymAreas_GymId",
                table: "GymAreas",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_ActivityID",
                table: "Person",
                column: "ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalTrainings_ClubMemberId",
                table: "PersonalTrainings",
                column: "ClubMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalTrainings_TrainerId",
                table: "PersonalTrainings",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Person_TrainerId",
                table: "Activities",
                column: "TrainerId",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Person_TrainerId",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "Agreements");

            migrationBuilder.DropTable(
                name: "Cleanings");

            migrationBuilder.DropTable(
                name: "GymAreas");

            migrationBuilder.DropTable(
                name: "PersonalTrainings");

            migrationBuilder.DropTable(
                name: "Gyms");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Activities");
        }
    }
}
