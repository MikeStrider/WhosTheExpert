using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WhosTheExpert.Migrations
{
    public partial class _21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromName",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ToName",
                table: "Reviews");

            migrationBuilder.AddColumn<int>(
                name: "WrittenByUserId",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WrittenForUserId",
                table: "Reviews",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WrittenByUserId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "WrittenForUserId",
                table: "Reviews");

            migrationBuilder.AddColumn<string>(
                name: "FromName",
                table: "Reviews",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ToName",
                table: "Reviews",
                nullable: false,
                defaultValue: "");
        }
    }
}
