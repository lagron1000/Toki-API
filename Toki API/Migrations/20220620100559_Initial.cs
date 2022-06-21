using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Toki_API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsersDB",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    server = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDB", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContactsDB",
                columns: table => new
                {
                    intId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ContactHolderId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Server = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lastdate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    lastmsgId = table.Column<int>(type: "int", nullable: true),
                    lastmsgChatId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lastmsgCreated = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactsDB", x => new { x.intId, x.ContactHolderId });
                    table.ForeignKey(
                        name: "FK_ContactsDB_UsersDB_ContactHolderId",
                        column: x => x.ContactHolderId,
                        principalTable: "UsersDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MessagesDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ChatId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sent = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SentBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessagesDB", x => new { x.Id, x.ChatId, x.Created });
                    table.ForeignKey(
                        name: "FK_MessagesDB_ContactsDB_Id_ChatId",
                        columns: x => new { x.Id, x.ChatId },
                        principalTable: "ContactsDB",
                        principalColumns: new[] { "intId", "ContactHolderId" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ContactsDB_ContactHolderId",
                table: "ContactsDB",
                column: "ContactHolderId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactsDB_lastmsgId_lastmsgChatId_lastmsgCreated",
                table: "ContactsDB",
                columns: new[] { "lastmsgId", "lastmsgChatId", "lastmsgCreated" });

            migrationBuilder.AddForeignKey(
                name: "FK_ContactsDB_MessagesDB_lastmsgId_lastmsgChatId_lastmsgCreated",
                table: "ContactsDB",
                columns: new[] { "lastmsgId", "lastmsgChatId", "lastmsgCreated" },
                principalTable: "MessagesDB",
                principalColumns: new[] { "Id", "ChatId", "Created" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactsDB_MessagesDB_lastmsgId_lastmsgChatId_lastmsgCreated",
                table: "ContactsDB");

            migrationBuilder.DropTable(
                name: "MessagesDB");

            migrationBuilder.DropTable(
                name: "ContactsDB");

            migrationBuilder.DropTable(
                name: "UsersDB");
        }
    }
}
