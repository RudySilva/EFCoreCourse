using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseEFCore.Migrations
{
    public partial class addEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedIn",
                table: "Orders",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETdATE()");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clients",
                type: "VARCHAR(80)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clients");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedIn",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETdATE()",
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
