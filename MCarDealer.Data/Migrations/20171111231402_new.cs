using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MCarDealer.Data.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Suppliers_Supplier_Id",
                table: "Parts");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Suppliers_Supplier_Id",
                table: "Parts",
                column: "Supplier_Id",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Suppliers_Supplier_Id",
                table: "Parts");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Suppliers_Supplier_Id",
                table: "Parts",
                column: "Supplier_Id",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
