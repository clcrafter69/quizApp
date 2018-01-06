using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace QuizWebApp.Migrations
{
    public partial class changeNav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScoreLevelId",
                table: "Leaders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Leaders_ScoreLevelId",
                table: "Leaders",
                column: "ScoreLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leaders_Scores_ScoreLevelId",
                table: "Leaders",
                column: "ScoreLevelId",
                principalTable: "Scores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leaders_Scores_ScoreLevelId",
                table: "Leaders");

            migrationBuilder.DropIndex(
                name: "IX_Leaders_ScoreLevelId",
                table: "Leaders");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ScoreLevelId",
                table: "Leaders");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Questions",
                nullable: true);
        }
    }
}
