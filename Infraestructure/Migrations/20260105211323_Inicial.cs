using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comercios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Local_Latitud = table.Column<double>(type: "float", nullable: true),
                    Local_Longitud = table.Column<double>(type: "float", nullable: true),
                    Local_Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Local_Referencia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comercios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Repartidores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroPlaca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false),
                    IdRepartidor = table.Column<int>(type: "int", nullable: true),
                    RepartidorId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repartidores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repartidores_Repartidores_RepartidorId",
                        column: x => x.RepartidorId,
                        principalTable: "Repartidores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoServicio = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Origen_Latitud = table.Column<double>(type: "float", nullable: true),
                    Origen_Longitud = table.Column<double>(type: "float", nullable: true),
                    Origen_Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Origen_Referencia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Destino_Latitud = table.Column<double>(type: "float", nullable: true),
                    Destino_Longitud = table.Column<double>(type: "float", nullable: true),
                    Destino_Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Destino_Referencia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CostoEnvio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalProductos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdRepartidor = table.Column<int>(type: "int", nullable: true),
                    IdComercio = table.Column<int>(type: "int", nullable: true),
                    DescripcionPaquete = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Comercios_IdComercio",
                        column: x => x.IdComercio,
                        principalTable: "Comercios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pedidos_Repartidores_IdRepartidor",
                        column: x => x.IdRepartidor,
                        principalTable: "Repartidores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DetallePedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdPedido = table.Column<int>(type: "int", nullable: false),
                    pedidoId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallePedidos_Pedidos_pedidoId",
                        column: x => x.pedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_pedidoId",
                table: "DetallePedidos",
                column: "pedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdComercio",
                table: "Pedidos",
                column: "IdComercio");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdRepartidor",
                table: "Pedidos",
                column: "IdRepartidor");

            migrationBuilder.CreateIndex(
                name: "IX_Repartidores_RepartidorId",
                table: "Repartidores",
                column: "RepartidorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallePedidos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Comercios");

            migrationBuilder.DropTable(
                name: "Repartidores");
        }
    }
}
