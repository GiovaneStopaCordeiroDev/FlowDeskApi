using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowDesk_API_.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoEnuns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TecnicoResponsavelId",
                table: "Chamados",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TecnicoResponsavelId",
                table: "Chamados",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
