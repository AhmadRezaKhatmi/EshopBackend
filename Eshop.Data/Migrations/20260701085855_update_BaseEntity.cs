using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class update_BaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ProductVisits");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ProductSelectedCategories");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ProductGalleries");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ProductCategories");

            migrationBuilder.RenameColumn(
                name: "ModificationDateTime",
                table: "Users",
                newName: "LastUpdateDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Users",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Users",
                newName: "IsActivated");

            migrationBuilder.RenameColumn(
                name: "CreationDateTime",
                table: "Users",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "ModificationDateTime",
                table: "UserRoles",
                newName: "LastUpdateDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "UserRoles",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "CreationDateTime",
                table: "UserRoles",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "ModificationDateTime",
                table: "Sliders",
                newName: "LastUpdateDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Sliders",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "CreationDateTime",
                table: "Sliders",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "ModificationDateTime",
                table: "Roles",
                newName: "LastUpdateDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Roles",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "CreationDateTime",
                table: "Roles",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "ModificationDateTime",
                table: "ProductVisits",
                newName: "LastUpdateDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ProductVisits",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "CreationDateTime",
                table: "ProductVisits",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "ModificationDateTime",
                table: "ProductSelectedCategories",
                newName: "LastUpdateDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ProductSelectedCategories",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "CreationDateTime",
                table: "ProductSelectedCategories",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "ModificationDateTime",
                table: "Products",
                newName: "LastUpdateDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Products",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "CreationDateTime",
                table: "Products",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "ModificationDateTime",
                table: "ProductGalleries",
                newName: "LastUpdateDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ProductGalleries",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "CreationDateTime",
                table: "ProductGalleries",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "ModificationDateTime",
                table: "ProductCategories",
                newName: "LastUpdateDate");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ProductCategories",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "CreationDateTime",
                table: "ProductCategories",
                newName: "CreateDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastUpdateDate",
                table: "Users",
                newName: "ModificationDateTime");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "Users",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActivated",
                table: "Users",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Users",
                newName: "CreationDateTime");

            migrationBuilder.RenameColumn(
                name: "LastUpdateDate",
                table: "UserRoles",
                newName: "ModificationDateTime");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "UserRoles",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "UserRoles",
                newName: "CreationDateTime");

            migrationBuilder.RenameColumn(
                name: "LastUpdateDate",
                table: "Sliders",
                newName: "ModificationDateTime");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "Sliders",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Sliders",
                newName: "CreationDateTime");

            migrationBuilder.RenameColumn(
                name: "LastUpdateDate",
                table: "Roles",
                newName: "ModificationDateTime");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "Roles",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Roles",
                newName: "CreationDateTime");

            migrationBuilder.RenameColumn(
                name: "LastUpdateDate",
                table: "ProductVisits",
                newName: "ModificationDateTime");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "ProductVisits",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "ProductVisits",
                newName: "CreationDateTime");

            migrationBuilder.RenameColumn(
                name: "LastUpdateDate",
                table: "ProductSelectedCategories",
                newName: "ModificationDateTime");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "ProductSelectedCategories",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "ProductSelectedCategories",
                newName: "CreationDateTime");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "LastUpdateDate",
                table: "Products",
                newName: "ModificationDateTime");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "Products",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Products",
                newName: "CreationDateTime");

            migrationBuilder.RenameColumn(
                name: "LastUpdateDate",
                table: "ProductGalleries",
                newName: "ModificationDateTime");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "ProductGalleries",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "ProductGalleries",
                newName: "CreationDateTime");

            migrationBuilder.RenameColumn(
                name: "LastUpdateDate",
                table: "ProductCategories",
                newName: "ModificationDateTime");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                table: "ProductCategories",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "ProductCategories",
                newName: "CreationDateTime");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UserRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Sliders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ProductVisits",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ProductSelectedCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ProductGalleries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ProductCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
