using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LennyIdentity.Migrations
{
    public partial class updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_t-role",
                table: "t-role");

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_role",
                table: "t-role",
                column: "id");

            migrationBuilder.RenameTable(
                name: "t-role",
                newName: "t_role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_t_role",
                table: "t_role");

            migrationBuilder.AddPrimaryKey(
                name: "PK_t-role",
                table: "t_role",
                column: "id");

            migrationBuilder.RenameTable(
                name: "t_role",
                newName: "t-role");
        }
    }
}
