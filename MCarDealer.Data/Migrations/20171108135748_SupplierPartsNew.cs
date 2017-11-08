using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MCarDealer.Data.Migrations
{
    public partial class SupplierPartsNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Part_Suppliers_SupplierId",
                table: "Part");

            migrationBuilder.DropForeignKey(
                name: "FK_PartCar_Part_Part_Id",
                table: "PartCar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Part",
                table: "Part");

            migrationBuilder.RenameTable(
                name: "Part",
                newName: "Parts");

            migrationBuilder.RenameIndex(
                name: "IX_Part_SupplierId",
                table: "Parts",
                newName: "IX_Parts_SupplierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parts",
                table: "Parts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PartCar_Parts_Part_Id",
                table: "PartCar",
                column: "Part_Id",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Suppliers_SupplierId",
                table: "Parts",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartCar_Parts_Part_Id",
                table: "PartCar");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Suppliers_SupplierId",
                table: "Parts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parts",
                table: "Parts");

            migrationBuilder.RenameTable(
                name: "Parts",
                newName: "Part");

            migrationBuilder.RenameIndex(
                name: "IX_Parts_SupplierId",
                table: "Part",
                newName: "IX_Part_SupplierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Part",
                table: "Part",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Part_Suppliers_SupplierId",
                table: "Part",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PartCar_Part_Part_Id",
                table: "PartCar",
                column: "Part_Id",
                principalTable: "Part",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
