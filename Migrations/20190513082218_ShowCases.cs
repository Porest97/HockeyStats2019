using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HockeyStats2019.Migrations
{
    public partial class ShowCases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShowCase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ShowCaseName = table.Column<string>(nullable: true),
                    ArenaId = table.Column<int>(nullable: true),
                    SeriesId = table.Column<int>(nullable: true),
                    ArenaId1 = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    PersonId1 = table.Column<int>(nullable: true),
                    PersonId2 = table.Column<int>(nullable: true),
                    PersonId3 = table.Column<int>(nullable: true),
                    PersonId4 = table.Column<int>(nullable: true),
                    PersonId5 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowCase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShowCase_Arena_ArenaId",
                        column: x => x.ArenaId,
                        principalTable: "Arena",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShowCase_Arena_ArenaId1",
                        column: x => x.ArenaId1,
                        principalTable: "Arena",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShowCase_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShowCase_Person_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShowCase_Person_PersonId2",
                        column: x => x.PersonId2,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShowCase_Person_PersonId3",
                        column: x => x.PersonId3,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShowCase_Person_PersonId4",
                        column: x => x.PersonId4,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShowCase_Person_PersonId5",
                        column: x => x.PersonId5,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShowCase_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShowCase_ArenaId",
                table: "ShowCase",
                column: "ArenaId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowCase_ArenaId1",
                table: "ShowCase",
                column: "ArenaId1");

            migrationBuilder.CreateIndex(
                name: "IX_ShowCase_PersonId",
                table: "ShowCase",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowCase_PersonId1",
                table: "ShowCase",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_ShowCase_PersonId2",
                table: "ShowCase",
                column: "PersonId2");

            migrationBuilder.CreateIndex(
                name: "IX_ShowCase_PersonId3",
                table: "ShowCase",
                column: "PersonId3");

            migrationBuilder.CreateIndex(
                name: "IX_ShowCase_PersonId4",
                table: "ShowCase",
                column: "PersonId4");

            migrationBuilder.CreateIndex(
                name: "IX_ShowCase_PersonId5",
                table: "ShowCase",
                column: "PersonId5");

            migrationBuilder.CreateIndex(
                name: "IX_ShowCase_SeriesId",
                table: "ShowCase",
                column: "SeriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShowCase");
        }
    }
}
