using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeTube.Migrations
{
    public partial class addRatingToComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Movie");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Comment",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Comment");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Movie",
                nullable: false,
                defaultValue: 0);
        }
    }
}
