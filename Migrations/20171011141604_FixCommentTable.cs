using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeTube.Migrations
{
    public partial class FixCommentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_CommentedById",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Movie_MovieId1",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_CommentedById",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_MovieId1",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "CommentedById",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "MovieId1",
                table: "Comment");

            migrationBuilder.AddColumn<long>(
                name: "CommentId",
                table: "Movie",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "MovieId",
                table: "Comment",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ApplicationUserId",
                table: "Comment",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ApplicationUserId",
                table: "Comment",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_MovieId",
                table: "Comment",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_ApplicationUserId",
                table: "Comment",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Movie_MovieId",
                table: "Comment",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_ApplicationUserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Movie_MovieId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ApplicationUserId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_MovieId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Movie");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Comment",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "Comment",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "CommentedById",
                table: "Comment",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MovieId1",
                table: "Comment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CommentedById",
                table: "Comment",
                column: "CommentedById");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_MovieId1",
                table: "Comment",
                column: "MovieId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_CommentedById",
                table: "Comment",
                column: "CommentedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Movie_MovieId1",
                table: "Comment",
                column: "MovieId1",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
