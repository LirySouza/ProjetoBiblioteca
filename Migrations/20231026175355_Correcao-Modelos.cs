using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoBiblioteca.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoModelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Data_Aluno_AlunoId",
                table: "Data");

            migrationBuilder.DropForeignKey(
                name: "FK_Data_Livro_LivroId",
                table: "Data");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Data",
                table: "Data");

            migrationBuilder.RenameTable(
                name: "Data",
                newName: "Datas");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Datas",
                newName: "DataId");

            migrationBuilder.RenameIndex(
                name: "IX_Data_LivroId",
                table: "Datas",
                newName: "IX_Datas_LivroId");

            migrationBuilder.RenameIndex(
                name: "IX_Data_AlunoId",
                table: "Datas",
                newName: "IX_Datas_AlunoId");

            migrationBuilder.AlterColumn<int>(
                name: "AlunoId",
                table: "Datas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Datas",
                table: "Datas",
                column: "DataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Datas_Aluno_AlunoId",
                table: "Datas",
                column: "AlunoId",
                principalTable: "Aluno",
                principalColumn: "AlunoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Datas_Livro_LivroId",
                table: "Datas",
                column: "LivroId",
                principalTable: "Livro",
                principalColumn: "LivroId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Datas_Aluno_AlunoId",
                table: "Datas");

            migrationBuilder.DropForeignKey(
                name: "FK_Datas_Livro_LivroId",
                table: "Datas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Datas",
                table: "Datas");

            migrationBuilder.RenameTable(
                name: "Datas",
                newName: "Data");

            migrationBuilder.RenameColumn(
                name: "DataId",
                table: "Data",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Datas_LivroId",
                table: "Data",
                newName: "IX_Data_LivroId");

            migrationBuilder.RenameIndex(
                name: "IX_Datas_AlunoId",
                table: "Data",
                newName: "IX_Data_AlunoId");

            migrationBuilder.AlterColumn<int>(
                name: "AlunoId",
                table: "Data",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Data",
                table: "Data",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Data_Aluno_AlunoId",
                table: "Data",
                column: "AlunoId",
                principalTable: "Aluno",
                principalColumn: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Data_Livro_LivroId",
                table: "Data",
                column: "LivroId",
                principalTable: "Livro",
                principalColumn: "LivroId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
