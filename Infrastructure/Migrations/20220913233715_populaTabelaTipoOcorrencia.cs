using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class populaTabelaTipoOcorrencia : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("insert into TipoOcorrencia values ('Em rota de entrega'), ('Entregue com sucesso'),('Cliente ausente'), ('Avaria no produto')");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from TipoOcorrencia");
        }
    }
}
