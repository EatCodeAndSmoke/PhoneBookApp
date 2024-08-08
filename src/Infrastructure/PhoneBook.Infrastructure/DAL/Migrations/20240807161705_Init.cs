using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PhoneBook.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameGe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameEng = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SearchTerm = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CorrelationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CorrelationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    PersonalNumber = table.Column<string>(type: "nchar(11)", fixedLength: true, maxLength: 11, nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SearchTerm = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CorrelationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meanings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lang = table.Column<byte>(type: "tinyint", nullable: false),
                    Meaning = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WordId = table.Column<int>(type: "int", nullable: false),
                    CorrelationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meanings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meanings_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumberType = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    CorrelationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelationType = table.Column<int>(type: "int", nullable: false),
                    PrimaryPersonId = table.Column<int>(type: "int", nullable: false),
                    SecondaryPersonId = table.Column<int>(type: "int", nullable: false),
                    CorrelationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relations_People_PrimaryPersonId",
                        column: x => x.PrimaryPersonId,
                        principalTable: "People",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Relations_People_SecondaryPersonId",
                        column: x => x.SecondaryPersonId,
                        principalTable: "People",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CorrelationId", "CreatedAt", "NameEng", "NameGe", "SearchTerm", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "4ef09574-14ba-40a0-a1cd-361709cd8b6f", new DateTimeOffset(new DateTime(2024, 8, 7, 16, 17, 4, 571, DateTimeKind.Unspecified).AddTicks(4958), new TimeSpan(0, 0, 0, 0, 0)), "Tbilisi", "თბილისი", "Tbilisiთბილისი", null },
                    { 2, "b199a83e-3d42-455a-8028-c68642b72c53", new DateTimeOffset(new DateTime(2024, 8, 7, 16, 17, 4, 571, DateTimeKind.Unspecified).AddTicks(4997), new TimeSpan(0, 0, 0, 0, 0)), "Kutaisi", "ქუთაისი", "Kutaisiქუთაისი", null }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "Id", "Code", "CorrelationId", "CreatedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "er.city.not_found", "09bc29f6-67e4-446b-bfc0-7c8737dfdca0", new DateTimeOffset(new DateTime(2024, 8, 7, 16, 17, 4, 574, DateTimeKind.Unspecified).AddTicks(8658), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 2, "er.person.already_ext", "84caeef1-652f-419e-a0c7-e7b9d9d6cb77", new DateTimeOffset(new DateTime(2024, 8, 7, 16, 17, 4, 574, DateTimeKind.Unspecified).AddTicks(8662), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 3, "er.person.not_found", "c1343203-776c-4b79-8b51-9c12b0c70fe3", new DateTimeOffset(new DateTime(2024, 8, 7, 16, 17, 4, 574, DateTimeKind.Unspecified).AddTicks(8664), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 4, "er.pr.already_exist", "6869dd4d-360f-45f5-94d9-9d67b1431063", new DateTimeOffset(new DateTime(2024, 8, 7, 16, 17, 4, 574, DateTimeKind.Unspecified).AddTicks(8667), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 5, "er.pr.not_found", "3e0b26c8-ef52-4bfb-be17-7d349eb88c62", new DateTimeOffset(new DateTime(2024, 8, 7, 16, 17, 4, 574, DateTimeKind.Unspecified).AddTicks(8669), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 6, "er.pn.already_exist", "b8e9eb29-faba-49f1-9466-8fa122d5c856", new DateTimeOffset(new DateTime(2024, 8, 7, 16, 17, 4, 574, DateTimeKind.Unspecified).AddTicks(8676), new TimeSpan(0, 0, 0, 0, 0)), null },
                    { 7, "er.pn.not_found", "a6c1a3ac-0e74-4ba3-9cd7-1e1992029902", new DateTimeOffset(new DateTime(2024, 8, 7, 16, 17, 4, 574, DateTimeKind.Unspecified).AddTicks(8678), new TimeSpan(0, 0, 0, 0, 0)), null }
                });

            migrationBuilder.InsertData(
                table: "Meanings",
                columns: new[] { "Id", "CorrelationId", "CreatedAt", "Lang", "Meaning", "UpdatedAt", "WordId" },
                values: new object[,]
                {
                    { 1, "298bbf76-099a-46b6-8640-8e70750b8fc5", new DateTimeOffset(new DateTime(2024, 8, 7, 16, 17, 4, 571, DateTimeKind.Unspecified).AddTicks(7359), new TimeSpan(0, 0, 0, 0, 0)), (byte)1, "ქალაქი ვერ მოიძებნა", null, 1 },
                    { 2, "65819af4-5211-4fb1-873f-32e3127e2b83", new DateTimeOffset(new DateTime(2024, 8, 7, 16, 17, 4, 571, DateTimeKind.Unspecified).AddTicks(7363), new TimeSpan(0, 0, 0, 0, 0)), (byte)0, "city not found", null, 1 },
                    { 3, "709c5783-1101-4e6c-839a-31721ec606fd", new DateTimeOffset(new DateTime(2024, 8, 7, 16, 17, 4, 571, DateTimeKind.Unspecified).AddTicks(7365), new TimeSpan(0, 0, 0, 0, 0)), (byte)1, "ფიზიკური პირი ასეთი მონაცემებით უკვე არსებობს", null, 2 },
                    { 4, "4685f2e1-b437-4e8b-8045-a414f14e84c7", new DateTimeOffset(new DateTime(2024, 8, 7, 16, 17, 4, 571, DateTimeKind.Unspecified).AddTicks(7377), new TimeSpan(0, 0, 0, 0, 0)), (byte)0, "person with similar data already exists", null, 2 },
                    { 5, "37233ece-a69c-49b2-a86d-c9d8cbe5340c", new DateTimeOffset(new DateTime(2024, 8, 7, 16, 17, 4, 571, DateTimeKind.Unspecified).AddTicks(7380), new TimeSpan(0, 0, 0, 0, 0)), (byte)1, "ფიზიკური პირი ვერ მოიძებნა", null, 3 },
                    { 6, "4032934b-5d91-457e-b22e-6adf304b5acf", new DateTimeOffset(new DateTime(2024, 8, 7, 16, 17, 4, 571, DateTimeKind.Unspecified).AddTicks(7382), new TimeSpan(0, 0, 0, 0, 0)), (byte)0, "person not found", null, 3 },
                    { 7, "5d641bc0-a990-4f96-9211-16f151be152e", new DateTimeOffset(new DateTime(2024, 8, 7, 16, 17, 4, 571, DateTimeKind.Unspecified).AddTicks(7384), new TimeSpan(0, 0, 0, 0, 0)), (byte)1, "ასეთი კავშირი უკვე არსებობს", null, 4 },
                    { 8, "8f711270-b55c-421c-821c-3a6dde0919c5", new DateTimeOffset(new DateTime(2024, 8, 7, 16, 17, 4, 571, DateTimeKind.Unspecified).AddTicks(7387), new TimeSpan(0, 0, 0, 0, 0)), (byte)0, "similar relation already exists", null, 4 },
                    { 9, "ebdbb1d8-0b55-4671-87b6-5fd68dc77306", new DateTimeOffset(new DateTime(2024, 8, 7, 16, 17, 4, 571, DateTimeKind.Unspecified).AddTicks(7389), new TimeSpan(0, 0, 0, 0, 0)), (byte)1, "კავშირი ვერ მოიძება", null, 5 },
                    { 10, "ec8e8759-e082-4b5e-a420-6b6b86dc6a2f", new DateTimeOffset(new DateTime(2024, 8, 7, 16, 17, 4, 571, DateTimeKind.Unspecified).AddTicks(7392), new TimeSpan(0, 0, 0, 0, 0)), (byte)0, "relation not found", null, 5 },
                    { 11, "3415f08e-dfc4-4e1e-8406-cea056fcfbd0", new DateTimeOffset(new DateTime(2024, 8, 7, 16, 17, 4, 571, DateTimeKind.Unspecified).AddTicks(7394), new TimeSpan(0, 0, 0, 0, 0)), (byte)1, "ტელეფონის ნომერი უკვე არსებობს", null, 6 },
                    { 12, "6a4dc351-1b58-41de-8c6b-62be488c7d83", new DateTimeOffset(new DateTime(2024, 8, 7, 16, 17, 4, 571, DateTimeKind.Unspecified).AddTicks(7399), new TimeSpan(0, 0, 0, 0, 0)), (byte)0, "phone number already exists", null, 6 },
                    { 13, "34b5e7fd-8b6f-472f-8cc8-c301b41e9707", new DateTimeOffset(new DateTime(2024, 8, 7, 16, 17, 4, 571, DateTimeKind.Unspecified).AddTicks(7401), new TimeSpan(0, 0, 0, 0, 0)), (byte)1, "ტელეფონის ნომერი ვერ მოიძებნა", null, 7 },
                    { 14, "19b586d2-b5a3-4b21-af26-ddf68f66fd7b", new DateTimeOffset(new DateTime(2024, 8, 7, 16, 17, 4, 571, DateTimeKind.Unspecified).AddTicks(7404), new TimeSpan(0, 0, 0, 0, 0)), (byte)0, "phone number not found", null, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meanings_WordId",
                table: "Meanings",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_People_CityId",
                table: "People",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_People_PersonalNumber",
                table: "People",
                column: "PersonalNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_PersonId",
                table: "PhoneNumbers",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_PrimaryPersonId",
                table: "Relations",
                column: "PrimaryPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_SecondaryPersonId",
                table: "Relations",
                column: "SecondaryPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Words_Code",
                table: "Words",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meanings");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "Relations");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
