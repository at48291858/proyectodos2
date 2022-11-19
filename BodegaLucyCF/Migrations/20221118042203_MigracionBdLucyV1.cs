using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BodegaLucyCF.Migrations
{
    public partial class MigracionBdLucyV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Distribuidores",
                columns: table => new
                {
                    Codigo_Distribuidor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Razon_Social_Distribuidor = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    RUC_Distribuidor = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    Direccion_Distribuidor = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Telefono_Distribuidor = table.Column<string>(type: "nvarchar(9)", nullable: false),
                    Nombre_Contacto = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    Telefono_Contacto = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    Estado_Distribuidor = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distribuidores", x => x.Codigo_Distribuidor);
                });

            migrationBuilder.CreateTable(
                name: "Paquetes",
                columns: table => new
                {
                    Codigo_Paquete = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Paquete = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Cantidad_Por_Paquete = table.Column<int>(type: "int", nullable: false),
                    Contenido_Por_Unidad = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Descripcion_Paquete = table.Column<string>(type: "nvarchar(70)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquetes", x => x.Codigo_Paquete);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Codigo_Usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI_Usuario = table.Column<string>(type: "nvarchar(8)", nullable: false),
                    Nombre_Usuario = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Apellido_Paterno_Usuario = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Apellido_Materno_Usuario = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Direccion_Usuario = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Correo_Usuario = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Telefono_Usuario = table.Column<string>(type: "nvarchar(9)", nullable: false),
                    User_Usuario = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    clave_Usuario = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Pregunta_Secreta = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Respuesta_Secreta = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Estado_Usuario = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Codigo_Usuario);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Codigo_Compra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_Compra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo_Comprobante = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Serie_Comprobante_Compra = table.Column<string>(type: "nvarchar(4)", nullable: false),
                    Numero_Comprobante_Compra = table.Column<string>(type: "nvarchar(8)", nullable: false),
                    Codigo_Usuario = table.Column<int>(type: "int", nullable: false),
                    Codigo_Distribuidor = table.Column<int>(type: "int", nullable: false),
                    IGV_Compra = table.Column<float>(type: "real", nullable: false),
                    Subtotal_Compra = table.Column<float>(type: "real", nullable: false),
                    Total_Compra = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Codigo_Compra);
                    table.ForeignKey(
                        name: "FK_Compras_Distribuidores_Codigo_Distribuidor",
                        column: x => x.Codigo_Distribuidor,
                        principalTable: "Distribuidores",
                        principalColumn: "Codigo_Distribuidor",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Compras_Usuarios_Codigo_Usuario",
                        column: x => x.Codigo_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Codigo_Usuario",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Detalle_Compras",
                columns: table => new
                {
                    Codigo_Detalle_Compra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo_Compra = table.Column<int>(type: "int", nullable: false),
                    Codigo_Paquete = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio_Unitario = table.Column<float>(type: "real", nullable: false),
                    Importe_Detalle_Compra = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle_Compras", x => x.Codigo_Detalle_Compra);
                    table.ForeignKey(
                        name: "FK_Detalle_Compras_Compras_Codigo_Compra",
                        column: x => x.Codigo_Compra,
                        principalTable: "Compras",
                        principalColumn: "Codigo_Compra",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Detalle_Compras_Paquetes_Codigo_Paquete",
                        column: x => x.Codigo_Paquete,
                        principalTable: "Paquetes",
                        principalColumn: "Codigo_Paquete",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_Codigo_Distribuidor",
                table: "Compras",
                column: "Codigo_Distribuidor");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_Codigo_Usuario",
                table: "Compras",
                column: "Codigo_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Compras_Codigo_Compra",
                table: "Detalle_Compras",
                column: "Codigo_Compra");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Compras_Codigo_Paquete",
                table: "Detalle_Compras",
                column: "Codigo_Paquete");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle_Compras");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Paquetes");

            migrationBuilder.DropTable(
                name: "Distribuidores");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
