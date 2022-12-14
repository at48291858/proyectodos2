// <auto-generated />
using System;
using BodegaLucyCF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BodegaLucyCF.Migrations
{
    [DbContext(typeof(BdLucyContext))]
    [Migration("20221118042203_MigracionBdLucyV1")]
    partial class MigracionBdLucyV1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BodegaLucyCF.Models.Compra", b =>
                {
                    b.Property<int>("Codigo_Compra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo_Compra"), 1L, 1);

                    b.Property<int>("Codigo_Distribuidor")
                        .HasColumnType("int");

                    b.Property<int>("Codigo_Usuario")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha_Compra")
                        .HasColumnType("datetime2");

                    b.Property<float>("IGV_Compra")
                        .HasColumnType("real");

                    b.Property<string>("Numero_Comprobante_Compra")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Serie_Comprobante_Compra")
                        .IsRequired()
                        .HasColumnType("nvarchar(4)");

                    b.Property<float>("Subtotal_Compra")
                        .HasColumnType("real");

                    b.Property<string>("Tipo_Comprobante")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<float>("Total_Compra")
                        .HasColumnType("real");

                    b.HasKey("Codigo_Compra");

                    b.HasIndex("Codigo_Distribuidor");

                    b.HasIndex("Codigo_Usuario");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("BodegaLucyCF.Models.Detalle_Compra", b =>
                {
                    b.Property<int>("Codigo_Detalle_Compra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo_Detalle_Compra"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("Codigo_Compra")
                        .HasColumnType("int");

                    b.Property<int>("Codigo_Paquete")
                        .HasColumnType("int");

                    b.Property<float>("Importe_Detalle_Compra")
                        .HasColumnType("real");

                    b.Property<float>("Precio_Unitario")
                        .HasColumnType("real");

                    b.HasKey("Codigo_Detalle_Compra");

                    b.HasIndex("Codigo_Compra");

                    b.HasIndex("Codigo_Paquete");

                    b.ToTable("Detalle_Compras");
                });

            modelBuilder.Entity("BodegaLucyCF.Models.Distribuidor", b =>
                {
                    b.Property<int>("Codigo_Distribuidor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo_Distribuidor"), 1L, 1);

                    b.Property<string>("Direccion_Distribuidor")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("Estado_Distribuidor")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre_Contacto")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("RUC_Distribuidor")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Razon_Social_Distribuidor")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefono_Contacto")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Telefono_Distribuidor")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)");

                    b.HasKey("Codigo_Distribuidor");

                    b.ToTable("Distribuidores");
                });

            modelBuilder.Entity("BodegaLucyCF.Models.Paquete", b =>
                {
                    b.Property<int>("Codigo_Paquete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo_Paquete"), 1L, 1);

                    b.Property<int>("Cantidad_Por_Paquete")
                        .HasColumnType("int");

                    b.Property<string>("Contenido_Por_Unidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Descripcion_Paquete")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Nombre_Paquete")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Codigo_Paquete");

                    b.ToTable("Paquetes");
                });

            modelBuilder.Entity("BodegaLucyCF.Models.Usuario", b =>
                {
                    b.Property<int>("Codigo_Usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo_Usuario"), 1L, 1);

                    b.Property<string>("Apellido_Materno_Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Apellido_Paterno_Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Correo_Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("DNI_Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Direccion_Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("Estado_Usuario")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre_Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Pregunta_Secreta")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Respuesta_Secreta")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Telefono_Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("User_Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("clave_Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Codigo_Usuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("BodegaLucyCF.Models.Compra", b =>
                {
                    b.HasOne("BodegaLucyCF.Models.Distribuidor", "distribuidor")
                        .WithMany()
                        .HasForeignKey("Codigo_Distribuidor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BodegaLucyCF.Models.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("Codigo_Usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("distribuidor");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("BodegaLucyCF.Models.Detalle_Compra", b =>
                {
                    b.HasOne("BodegaLucyCF.Models.Compra", "compra")
                        .WithMany()
                        .HasForeignKey("Codigo_Compra")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BodegaLucyCF.Models.Paquete", "paquete")
                        .WithMany()
                        .HasForeignKey("Codigo_Paquete")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("compra");

                    b.Navigation("paquete");
                });
#pragma warning restore 612, 618
        }
    }
}
